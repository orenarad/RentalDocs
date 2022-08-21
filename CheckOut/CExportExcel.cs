using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Core;
using Microsoft.Office.Interop.Excel;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace EquipmentCheckOut
{
    class CExportExcel : Component
    {
        private int docID;

        public CExportExcel(int DocID)
        {
            docID = DocID;
        }

        public bool CreateExcelFile()
        {
            string fileName;

            using (CDocument doc = new CDocument(docID, true))
            {
                // define new excel file
                Microsoft.Office.Interop.Excel.Application xlapp = new Microsoft.Office.Interop.Excel.Application();
                Workbook wb = xlapp.Workbooks.Add();
                Worksheet ws = wb.Worksheets[1];
                Range range = ws.Range[ws.Cells[1, 1], ws.Cells[1, 1]];
                Font font = range.Font;
                try
                {
                    // save as dialog
                    SaveFileDialog saveAs = new SaveFileDialog();
                    saveAs.AddExtension = true;
                    saveAs.CheckPathExists = true;
                    saveAs.CreatePrompt = false;
                    saveAs.DefaultExt = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                    saveAs.Filter = "Excel|*.xlsx";
                    saveAs.FileName = doc.ProjecName + " - " + doc.Subject;
                    if (saveAs.ShowDialog() == DialogResult.OK)
                        fileName = saveAs.FileName;
                    else
                        // we continue this procedure only if the user have okayed
                        return false;

                        
                    // open document and collect data
                    string docTitle;
                    int thisRow = 1;
                    switch (doc.DocumentType)
                    {
                        case DocumentType.Quotation:
                            docTitle = Properties.Settings.Default.TITLE_QUOTE;
                            break;
                        case DocumentType.ExitCertificate:
                            docTitle = Properties.Settings.Default.TITLE_SHIPMENT;
                            break;
                        case DocumentType.ReturnCertificate:
                            docTitle = Properties.Settings.Default.TITLE_RECEIVE;
                            break;
                        default:
                            docTitle = Properties.Settings.Default.TITLE_BILL;
                            break;
                    }
                    // write data to excel file...

                    // start with header containing document details:
                    ws.Name = doc.DocumentNumber.ToString();
                    ws.Cells[thisRow, 1] = docTitle + " מס'";
                    ws.Cells[thisRow, 2] = doc.DocumentNumber.ToString();
                    thisRow++;
                    ws.Cells[thisRow, 1] = " תאריך";
                    ws.Cells[thisRow, 2] = doc.Date1.ToShortDateString();
                    thisRow++;
                    if (doc.DocumentType != DocumentType.Bill)
                    {
                        ws.Cells[thisRow, 1] = doc.Date2Name.Substring(0, doc.Date2Name.Length-1);
                        ws.Cells[thisRow, 2] = doc.Date2.ToShortDateString();
                        thisRow++;
                    }
                    ws.Cells[thisRow, 1] = "לכבוד";
                    ws.Cells[thisRow, 2] = doc.ClientName;
                    thisRow++;
                    ws.Cells[thisRow, 2] = doc.ClientDetails;
                    thisRow++;
                    ws.Cells[thisRow, 1] = "מס' לקוח";
                    ws.Cells[thisRow, 2] = doc.ClientHashavshevetNo.ToString();
                    thisRow++;
                    ws.Cells[thisRow, 1] = "פרויקט";
                    ws.Cells[thisRow, 2] = doc.ProjecName;
                    thisRow++;
                    ws.Cells[thisRow, 1] = "נושא";
                    ws.Cells[thisRow, 2] = doc.Subject;
                    thisRow++;
                    ws.Cells[thisRow, 1] = "נוצר ע''י";
                    ws.Cells[thisRow, 2] = doc.UserName;
                    thisRow += 2;

                    // rows header bold
                    range = ws.Range[ws.Cells[thisRow, 1], ws.Cells[thisRow, 9]];
                    font = range.Font;
                    font.Bold = true;
                    ws.Cells[thisRow, 1] = "מס' פריט";
                    ws.Cells[thisRow, 2] = "ממסמך";
                    ws.Cells[thisRow, 3] = "פריט";
                    ws.Cells[thisRow, 4] = "תיאור";
                    ws.Cells[thisRow, 5] = "מחיר";
                    ws.Cells[thisRow, 6] = "כמות";
                    ws.Cells[thisRow, 7] = "ימים";
                    ws.Cells[thisRow, 8] = "הנחה";
                    ws.Cells[thisRow, 9] = "סה''כ";
                    thisRow++;
                    // write document rows:
                    int firstRowNo = thisRow;   // will be used for the SUM formula
                    using (System.Data.DataTable rows = doc.GetDocumentRows())
                    {
                        foreach (System.Data.DataRow row in rows.Rows)
                        {
                            ws.Cells[thisRow, 1] = row["ProductID"].ToString();
                            try { ws.Cells[thisRow, 2] = row["DocNumber"].ToString(); }
                            catch { }
                            ws.Cells[thisRow, 3] = row["ProductName"].ToString();
                            try { ws.Cells[thisRow, 4] = row["ProductDesc"].ToString(); }
                            catch { }
                            double price = double.Parse(row["SalesPrice"].ToString());
                            if (price > 0)
                                ws.Cells[thisRow, 5] = double.Parse(row["SalesPrice"].ToString());
                            else
                                ws.Cells[thisRow, 5] = double.Parse(row["RentalPrice"].ToString());
                            ws.Cells[thisRow, 6] = (int)row["Quantity"];
                            ws.Cells[thisRow, 7] = (int)row["Days"];
                            ws.Cells[thisRow, 8] = double.Parse(row["Discount"].ToString());
                            range = ws.Range[ws.Cells[thisRow, 9], ws.Cells[thisRow, 9]];
                            range.Formula = "=E" + thisRow.ToString() + "*F" + thisRow.ToString() + "*G" + thisRow.ToString() + "*(1-H" + thisRow.ToString() + ")";

                            thisRow++;
                        }

                        // tatal row
                        if (doc.DocumentType == DocumentType.Quotation || doc.DocumentType == DocumentType.Bill)
                        {
                            ws.Cells[thisRow + 2, 8] = "סה''כ";
                            range = ws.Range[ws.Cells[thisRow + 2, 9], ws.Cells[thisRow + 2, 9]];
                            range.Formula = "=SUM(I" + firstRowNo.ToString() + ":I" + thisRow.ToString() + ")";
                        }

                        // columns formatting
                        range = ws.Range[ws.Cells[firstRowNo, 5], ws.Cells[thisRow, 5]];
                        range.Style = "Currency";
                        range = ws.Range[ws.Cells[firstRowNo, 8], ws.Cells[thisRow, 8]];
                        range.Style = "Percent";
                        range = ws.Range[ws.Cells[firstRowNo, 9], ws.Cells[thisRow+2, 9]];
                        range.Style = "Currency";

                        // close file and cleanup
                        wb.SaveAs(fileName);
                        wb.Close();

                    }
                }
                catch 
                {
                    MessageBox.Show("There was a problem creating Excel file...", "Make Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // close file and cleanup
                    Marshal.ReleaseComObject(font);
                    Marshal.ReleaseComObject(range);
                    Marshal.ReleaseComObject(ws);
                    Marshal.ReleaseComObject(wb);
                    Marshal.ReleaseComObject(xlapp);
                }
                // function returns true;
                return true;
            }

        }
    }
}

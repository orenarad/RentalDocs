using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentCheckOut
{
    public partial class frmExportSelection : Form
    {
        bool DraftMode = true;
        CDocument currentDocument;

        public frmExportSelection(CDocument Doc)
        {
            InitializeComponent();
            currentDocument = Doc;

            btnOpt1.Tag = DocumentType.Quotation;
            btnOpt2.Tag = DocumentType.ExitCertificate;
            btnOpt3.Tag = DocumentType.Bill;

            if (Doc.DocumentNumber == 0)
            {
                DraftMode = true;
                btnPrint.Text = "הדפס מקור";
                btnPDF.Text = "הדפס טיוטה";
            }
            else
            {
                DraftMode = false;
                btnPrint.Text = "הדפס העתק";
                btnPDF.Text = "שמור PDF";
            }
        }

        private void frmExportSelection_FormClosed(object sender, FormClosedEventArgs e)
        {
            currentDocument.Dispose();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (DraftMode == true)
            {
                // give the document a Doc-Number and proceed to print
                currentDocument.DocumentNumber = new CDocuments().GetNextDocumentNumber(currentDocument.DocumentType);
                // set current time 
                currentDocument.Date1 = DateTime.Now;
                currentDocument.Update();
            }

            // send document to be printed in the default printer
            using (CPrintDocument pd = new CPrintDocument(currentDocument.ID))
            {
                // Mark the document as printed
                if (currentDocument.Printed == false)
                {
                    currentDocument.Printed = true;
                    currentDocument.Update();
                }
                pd.Print();
            }

            DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            if (DraftMode == true)
            {
                // send document to be printed in the default printer
                using (CPrintDocument pd = new CPrintDocument(currentDocument.ID))
                {
                    pd.Print();
                }
            }
            else
            {
                // send document to be printed in the "cutePDF" printer
                using (CPrintDocument pd = new CPrintDocument(currentDocument.ID))
                {
                    try
                    {
                        pd.PrinterSettings.PrinterName = "CutePDF Writer";
                        pd.DefaultPageSettings.PaperSize = new System.Drawing.Printing.PaperSize("A4", 827, 1169);
                        pd.Print();
                    }
                    catch
                    {
                        MessageBox.Show("No CutePDF Writer Installed...", "Make PDF", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

            DialogResult = System.Windows.Forms.DialogResult.Yes;

        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            // initialize Excel calss
            bool xls = false;
            using (CExportExcel xl = new CExportExcel(currentDocument.ID))
            {
                Cursor = Cursors.WaitCursor;
                //try
                //{
                xls = xl.CreateExcelFile();
                //}
                //catch
                //{
                //    MessageBox.Show("There was a problem creating Excel file...", "Make Excel", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}
                Cursor = Cursors.Default;
            }
            if (xls == true)
                DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        private void btnNewDoc_Click(object sender, EventArgs e)
        {
            panOptions.Visible = true;
        }

        private void btnOptCancel_Click(object sender, EventArgs e)
        {
            panOptions.Visible = false;
        }

        private void btnOpt1_Click(object sender, EventArgs e)
        {
            frmDocument owner = (frmDocument)this.Owner;
            int currentUserID = owner.CurrentUserID;
            Button sdr = (Button)sender;
            if (new CFolderPermissions().FolderActionByUser(currentUserID, (int)sdr.Tag, 1) == true)
            {
                using (frmDocument docForm = new frmDocument((DocumentType)sdr.Tag, currentDocument.ID, false))
                {
                    docForm.AllowPrint = true;
                    docForm.RecordLocked = false;
                    docForm.CurrentUserID = currentUserID;
                    if (docForm.ShowDialog(this) == DialogResult.OK)
                    {

                    }
                }
            }
            else
            {
                MessageBox.Show(Properties.Settings.Default.MsgNoPermission,
                        Properties.Settings.Default.MsgCantProceed,
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
            }
        }
    }
}

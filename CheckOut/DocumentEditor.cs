using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentCheckOut
{
    public partial class DocumentEditor : UserControl
    {
        ItemsCatalog[] catalogItems;
        List<DocumentRow> DocumentRows = new List<DocumentRow>();
        DocumentRow.RowMode editorMode = DocumentRow.RowMode.Quotation;

        public event EventHandler DocumentChanged;

        public DocumentEditor()
        {
            InitializeComponent();
            lblTotal.Text = "סה\"כ: " + double.Parse("0").ToString("C");
            // load catalog from db to pass it to each new document row
            using (DataTable catalog = new CCatalogProducts().AllCatalogProducts(true))
            {
                catalogItems = new ItemsCatalog[catalog.Rows.Count];
                int i = 0;
                foreach (DataRow row in catalog.Rows)
                {
                    catalogItems[i].ItemID = (int)row["ID"];
                    catalogItems[i].ItemName = row["Product"].ToString();
                    catalogItems[i].ItemDescription = row["Description"].ToString() + "";
                    catalogItems[i].RentalPrice = Convert.ToDouble((object)row["RentalPrice"]);
                    catalogItems[i].SalesPrice = Convert.ToDouble((object)row["SalesPrice"]);
                    i++;
                }
            }
        }

        public bool ShowSummaryBar
        {
            get { return panSummary.Visible; }
            set { panSummary.Visible = value; }
        }

        public void SetMode(DocumentRow.RowMode Mode)
        {
            editorMode = Mode;
            ShowSummaryBar = (editorMode == DocumentRow.RowMode.Quotation | editorMode == DocumentRow.RowMode.Bill);
            // add first blank row just below header labels
            AddDocumentRow(0);
        }

        public int AddNewRow()
        {
            return AddDocumentRow(DocumentRows[DocumentRows.Count - 1].Location.Y + DocumentRows[DocumentRows.Count - 1].Height - 1);
        }

        public int FindRow(string FindText, int StartIndex)
        {
            // goes through the rows and
            // returns the index of match
            for (int i = StartIndex; i < DocumentRows.Count; i++)
            {
                if (DocumentRows[i].ItemName.IndexOf(FindText, StringComparison.CurrentCultureIgnoreCase) != -1)
                {
                    return i;
                }
            }
            return -1;
        }

        public void RowFocus(int RowIndex)
        {
            DocumentRows[RowIndex].Focus();
        }

        public void ImportFromRelatedDoc()
        {
            DocumentRow_RequestRelatedDoc(Rows[Rows.Count-1], new EventArgs());
        }

        private int AddDocumentRow(int Top)
        {
            int Idx = DocumentRows.Count;
            DocumentRows.Add(new DocumentRow(editorMode));
            DocumentRow thisRow = (DocumentRow)DocumentRows[Idx];
            thisRow.MyIndex = Idx;
            thisRow.HasHeader = (Idx == 0);
            thisRow.Name = "Row" + Idx.ToString();
            thisRow.Location = new Point(0, Top);
            thisRow.Anchor = AnchorStyles.Left | AnchorStyles.Top | AnchorStyles.Right;
            thisRow.Width = ClientRectangle.Width;
            thisRow.PassCatalog(catalogItems);
            thisRow.RowCalculated += new EventHandler(this.DocumentRow_RowCalculated);
            thisRow.RowAdded += new EventHandler(this.DocumentRow_RowAdded);
            thisRow.RowExitPoint += new EventHandler(this.DocumentRow_RowExitPoint);
            thisRow.DeletePressed += new EventHandler(this.DocumentRow_DeletePressed);
            thisRow.RequestRelatedDocs += new EventHandler(this.DocumentRow_RequestRelatedDoc);
            thisRow.DaysChanged += new RowActionHandler(this.DocumentRow_DaysChanged);
            thisRow.DiscountChanged += new RowActionHandler(this.DocumentRow_DiscountChanged);
            thisRow.RowChanged += new EventHandler(this.DocumentRow_RowChanged);
            Controls.Add(thisRow);

            panSummary.Top = thisRow.Location.Y + thisRow.Height;

            return Idx;
        }

        private void DocumentRow_RowCalculated(object sender, EventArgs e)
        {
            double total = 0;
            foreach (DocumentRow drow in DocumentRows)
            {
                total += drow.TotalValue;
            }
            lblTotal.Text = "סה\"כ: " + total.ToString("C");

            // copy days & discount values from the last row to the new row.
            int index = DocumentRows.Count - 1;
            DocumentRows[index].Days = DocumentRows[index - 1].Days;
            DocumentRows[index].Discount = DocumentRows[index - 1].Discount;
        }

        private void DocumentRow_RowAdded(object sender, EventArgs e)
        {
            AddDocumentRow(DocumentRows[DocumentRows.Count - 1].Location.Y + DocumentRows[DocumentRows.Count - 1].Height - 1);
        }

        private void DocumentRow_RowExitPoint(object sender, EventArgs e)
        {
            // set focus on the next row.
            DocumentRow thisRow = (DocumentRow)sender;
            int Idx = thisRow.MyIndex;
            DocumentRows[Idx + 1].Focus();
        }

        private void DocumentRow_DeletePressed(object sender, EventArgs e)
        {
            DocumentRow thisRow = (DocumentRow)sender;
            int Idx = thisRow.MyIndex;
            Controls.Remove(thisRow);
            DocumentRows.RemoveAt(Idx);
            int rowHeight = DocumentRows[DocumentRows.Count - 1].Height - 1;
            for (int i = Idx; i < DocumentRows.Count; i++ )
            {
                DocumentRows[i].MyIndex--;
                DocumentRows[i].Top -= rowHeight;
            }
            panSummary.Top -= rowHeight;
            OnDocumentChanged();
        }

        private void DocumentRow_DaysChanged(object sender, DocumentRowEventArgs e)
        {
            DocumentRow thisRow = (DocumentRow)sender;
            int Idx = thisRow.MyIndex;
            int newDaysValue = thisRow.Days;
            switch (e.ActionTaken)
            {
                case DocumentRowEventArgs.Action.All:
                    foreach (DocumentRow row in DocumentRows)
                    {
                        if (row != thisRow)
                        {
                            row.Days = newDaysValue;
                            row.CalculateRow();
                        }
                    }
                    break;

                case DocumentRowEventArgs.Action.Down:
                    for (int i = Idx + 1; i < DocumentRows.Count; i++)
                    {
                        DocumentRows[i].Days = newDaysValue;
                        DocumentRows[i].CalculateRow();
                    }
                    break;

                case DocumentRowEventArgs.Action.Up:
                    for (int i = 0; i < Idx; i++)
                    {
                        DocumentRows[i].Days = newDaysValue;
                        DocumentRows[i].CalculateRow();
                    }
                    break;
            }
        }

        private void DocumentRow_DiscountChanged(object sender, DocumentRowEventArgs e)
        {
            DocumentRow thisRow = (DocumentRow)sender;
            int Idx = thisRow.MyIndex;
            double newDiscountValue = thisRow.Discount;
            switch (e.ActionTaken)
            {
                case DocumentRowEventArgs.Action.All:
                    foreach (DocumentRow row in DocumentRows)
                    {
                        if (row != thisRow)
                        {
                            row.Discount = newDiscountValue;
                            row.CalculateRow();
                        }
                    }
                    break;

                case DocumentRowEventArgs.Action.Down:
                    for (int i = Idx + 1; i < DocumentRows.Count; i++)
                    {
                        DocumentRows[i].Discount = newDiscountValue;
                        DocumentRows[i].CalculateRow();
                    }
                    break;

                case DocumentRowEventArgs.Action.Up:
                    for (int i = 0; i < Idx; i++)
                    {
                        DocumentRows[i].Discount = newDiscountValue;
                        DocumentRows[i].CalculateRow();
                    }
                    break;
            }
        }

        private void DocumentRow_RequestRelatedDoc(object sender, EventArgs e)
        {
            frmDocument docWnd = (frmDocument)Parent.FindForm();
            int projectID = docWnd.GetProjectID();
            if (projectID == 0)
            {
                MessageBox.Show(Properties.Settings.Default.MsgNoProject, Properties.Settings.Default.MsgCantProceed, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string quantity = "Quantity";
            int currUser = docWnd.CurrentUserID;
            DocumentType docType;
            bool limitQtty = false;

            switch (editorMode)
            {
                case DocumentRow.RowMode.Receive:
                    docType = DocumentType.ExitCertificate;
                    quantity = "Balance";
                    limitQtty = true;
                    break;

                case DocumentRow.RowMode.Bill:
                    docType = DocumentType.ReturnCertificate;
                    break;

                default:
                    docType = DocumentType.Quotation;
                    break;
            }
            using (frmDocumentsSearch2 docSearchFrm = new frmDocumentsSearch2(projectID, currUser, docType))
            {
                if (docSearchFrm.ShowDialog(this) == DialogResult.OK)
                {
                    int c = 0;
                    DocumentRow thisRow = (DocumentRow)sender;
                    List<frmDocumentsSearch2.DocItem> selItems = docSearchFrm.GetCheckedItems();
                    int[] ids = new int[selItems.Count];
                    for (int i = 0; i<selItems.Count; i++)
                    {
                        ids[i] = selItems[i].DocumentProductID;
                    }
                    using (DataTable rows = new CDocumentRow(0).GetDocumentRows(ids))
                    {
                        foreach (DataRow row in rows.Rows)
                        {
                            // if this is a receive certificate check if this item is already in the list
                            if (editorMode == DocumentRow.RowMode.Receive && FoundInDocument((int)row["ID"]))
                            {

                            }
                            else 
                            { 
                                CDocumentRow drow = new CDocumentRow((int)row["DocumentID"]);
                                int qttyLimit = 0;
                                drow.RelatedRowIdDocumentNo = (int)row["DocNumber"];
                                drow.ProductID = (int)row["ProductID"];
                                drow.DBId = (int)row["ID"];
                                drow.ProductName = row["ProductName"].ToString();
                                drow.ProductDescription = row["ProductDesc"].ToString();
                                drow.RentalPrice = double.Parse(row["RentalPrice"].ToString());
                                drow.SalesPrice = double.Parse(row["SalesPrice"].ToString());
                                drow.Days = (int)row["Days"];
                                int qtty = 0;
                                foreach (frmDocumentsSearch2.DocItem di in selItems)
                                {
                                    if (drow.DBId == di.DocumentProductID)
                                    {
                                        qtty = di.Quantity;
                                        break;
                                    }
                                }
                                drow.Quantity = qtty;// (int)row[quantity];
                                if (limitQtty == true)
                                    qttyLimit = (int)row[quantity];
                                drow.Discount = double.Parse(row["Discount"].ToString());

                                if (c == 0)
                                    thisRow.LoadRow(drow, qttyLimit);
                                else
                                {
                                    Rows[Rows.Count - 1].LoadRow(drow, qttyLimit); 
                                }
                                c++;
                            }
                        }
                    }
                }
            }
        }

        private bool FoundInDocument(int DBId)
        {
            bool ret = false;
            foreach (DocumentRow row in DocumentRows)
            {
                if (row.RelatedDocumentNumber == DBId)
                {
                    ret = true;
                    break;
                }
            }
            return ret;
        }

        private void DocumentRow_RowChanged(object sender, EventArgs e)
        {
            OnDocumentChanged();
        }

        protected virtual void OnDocumentChanged()
        {
            if (DocumentChanged != null)
                DocumentChanged(this, new EventArgs());
        }
        
        public List<DocumentRow> Rows
        {
            get
            {
                return DocumentRows;
            }
        }
    }
}

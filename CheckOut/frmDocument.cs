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
    public partial class frmDocument : Form
    {
        bool needSave = false;
        bool saved = false;
        bool moveOverlap = false;

        CDocument currentDocument;
        DocumentType documentType;
        DocumentRow.RowMode editorMode;

        public enum NewBasedOn
        {
            None,
            ThisProject,
            AnyProject
        }

        private string DOC_QUOTE = Properties.Settings.Default.TITLE_QUOTE;
        private string DOC_CERT_OUT = Properties.Settings.Default.TITLE_SHIPMENT;
        private string DOC_CERT_IN = Properties.Settings.Default.TITLE_RECEIVE;
        private string DOC_BILL = Properties.Settings.Default.TITLE_BILL;

        private string Date2Name = "";
        private string DATE2_QUOTE = Properties.Settings.Default.DATE2_QUOTE;
        private string DATE2_SHIP = Properties.Settings.Default.DATE2_SHIP;
        private string DATE2_RECEIVE = Properties.Settings.Default.DATE2_RECEIVE;

        public int CurrentUserID = 0;
        public bool RecordLocked = false;
        public bool AllowPrint = false;

        private string FormText = "";

        public frmDocument(DocumentType DocType, int BaseDocID = 0, bool ProjectAsBaseDoc = false)
        {
            InitializeComponent();
            if (BaseDocID == 0)
            {
                // create a new blank document as per specified "DocType"
                switch (DocType)
                {
                    case DocumentType.Quotation:
                        editorMode = DocumentRow.RowMode.Quotation;
                        Date2Name = Properties.Settings.Default.DATE2_QUOTE;
                        break;

                    case DocumentType.ExitCertificate:
                        editorMode = DocumentRow.RowMode.Shipment;
                        Date2Name = Properties.Settings.Default.DATE2_SHIP;
                        break;

                    case DocumentType.ReturnCertificate:
                        editorMode = DocumentRow.RowMode.Receive;
                        Date2Name = Properties.Settings.Default.DATE2_RECEIVE;
                        break;

                    case DocumentType.Bill:
                        editorMode = DocumentRow.RowMode.Bill;
                        break;
                }

                documentEditor1.SetMode(editorMode);
                PopulateProjects();
                SetDocType(DocType);

                needSave = false;
            }
            else
            {
                // create a new document based on "BaseDocID" as per specified "DocType"

                // load base document
                using (CDocument baseDocument = new CDocument(BaseDocID))
                {
                    // set the editor mode  
                    switch (DocType)
                    {
                        case DocumentType.Quotation:
                            editorMode = DocumentRow.RowMode.Quotation;
                            Date2Name = Properties.Settings.Default.DATE2_QUOTE;
                            break;

                        case DocumentType.ExitCertificate:
                            editorMode = DocumentRow.RowMode.Shipment;
                            Date2Name = Properties.Settings.Default.DATE2_SHIP;
                            break;

                        case DocumentType.ReturnCertificate:
                            editorMode = DocumentRow.RowMode.Receive;
                            Date2Name = Properties.Settings.Default.DATE2_RECEIVE;
                            break;

                        default:
                            editorMode = DocumentRow.RowMode.Bill;
                            break;
                    }

                    SetDocType(DocType);
                    documentEditor1.SetMode(editorMode);
                    PopulateProjects();
                    if (ProjectAsBaseDoc == true)
                    {
                        // select correct project in the projects combo
                        try
                        {
                            cboProjects.SelectedIndex = Program.GetComboIndexOfId(cboProjects, baseDocument.ProjectID);
                        }
                        catch { MessageBox.Show("Error reading project ID"); }
                        // fill details from base document
                        txtClient.Text = baseDocument.ClientName + "";
                        txtClientDetails.Text = baseDocument.ClientDetails + "";
                        txtSubject.Text = baseDocument.Subject;
                    }
                    // Copy rows from base document...
                    using (DataTable rows = new CDocumentRow(0).GetDocumentRows(baseDocument.DocumentType, baseDocument.ProjectID))
                    {
                        //using (DataTable rows = baseDocument.GetDocumentRows())
                        //{
                        foreach (DataRow row in rows.Rows)
                        {
                            if ((int)row["DocumentID"] == baseDocument.ID)
                            {
                                if ((int)row["Balance"] > 0)
                                {
                                    CDocumentRow dr = new CDocumentRow(0);
                                    dr.ProductID = (int)row["ProductID"];
                                    dr.ProductName = row["ProductName"].ToString();
                                    dr.RelatedRowID = (int)row["ID"];
                                    dr.RelatedRowIdDocumentNo = baseDocument.DocumentNumber;
                                    dr.ProductDescription = row["ProductDesc"].ToString();
                                    dr.Quantity = (int)row["Quantity"];
                                    dr.Days = (int)row["Days"];
                                    dr.RentalPrice = double.Parse(row["RentalPrice"].ToString());
                                    dr.SalesPrice = double.Parse(row["SalesPrice"].ToString());
                                    dr.Discount = double.Parse(row["Discount"].ToString());
                                    if (row["DocNumber"].ToString().Length > 0)
                                    {
                                        dr.RelatedRowIdDocumentNo = (int)row["DocNumber"];
                                        dr.DBId = (int)row["ID"];
                                    }

                                    int Idx = documentEditor1.Rows.Count;
                                    documentEditor1.Rows[Idx - 1].LoadRow(dr);
                                }
                            }
                        }
                    }
                }
                moveOverlap = true;
            }

        
        }

        public frmDocument(int DocumentID)
        {
            InitializeComponent();
            PopulateProjects();

            bool DoSave = false;

            // load document into the form
            currentDocument = new CDocument(DocumentID);
            switch (currentDocument.DocumentType)
            {
                case DocumentType.Quotation:
                    editorMode = DocumentRow.RowMode.Quotation;
                    Date2Name = Properties.Settings.Default.DATE2_QUOTE;
                    break;

                case DocumentType.ExitCertificate:
                    editorMode = DocumentRow.RowMode.Shipment;
                    Date2Name = Properties.Settings.Default.DATE2_SHIP;
                    break;

                case DocumentType.ReturnCertificate:
                    editorMode = DocumentRow.RowMode.Receive;
                    Date2Name = Properties.Settings.Default.DATE2_RECEIVE;
                    break;

                case DocumentType.Bill:
                    editorMode = DocumentRow.RowMode.Bill;
                    break;
            }

            SetDocType(currentDocument.DocumentType);
            documentEditor1.SetMode(editorMode);

            Text = FormText + " " + currentDocument.DocumentNumber.ToString();
            try
            {
                cboProjects.SelectedIndex = Program.GetComboIndexOfId(cboProjects, currentDocument.ProjectID);
            }
            catch { MessageBox.Show("Error reading project ID"); }
            dtpDate1.Value = currentDocument.Date1;
            if (dtpDate2.Visible == true)
                dtpDate2.Value = currentDocument.Date2;
            txtClient.Text = currentDocument.ClientName + "";
            txtClientDetails.Text = currentDocument.ClientDetails + "";
            txtSubject.Text = currentDocument.Subject;
            txtNotes.Text = currentDocument.Notes;

            // load rows...
            using (DataTable rows = currentDocument.GetDocumentRows())
            {
                int quantity = 0;
                DataTable itemsBalance = null;
                if (currentDocument.DocumentType == DocumentType.ReturnCertificate && currentDocument.Printed == false)
                {
                    /// if this is a draft return certificate we need to go over the list to meke sure
                    /// the items in it are still unreturned.
                    /// 
                    string having = "";
                    foreach (DataRow row in rows.Rows)
                    {
                        having += "(DocumentProduct.ProductID = " + row["ProductID"].ToString() + ") or ";
                    }
                    if (having.Length > 0)
                    {
                        having = having.Substring(0, having.Length - 4);
                        /// create a query with the balance of items in this project
                        /// 

                        using (CRecord rec = new CRecord(
                                        "SELECT     DocumentProduct.ProductID, SUM(DocumentProduct.Quantity) AS Expr1, ISNULL(SUM(Documents_SumOfQuantityRelated.SumOfQuantity), 0) AS SumOfQuantity, " +
                                        "           SUM(DocumentProduct.Quantity - ISNULL(Documents_SumOfQuantityRelated.SumOfQuantity, 0)) AS Balance " +
                                        "FROM       [Document] INNER JOIN DocumentProduct ON [Document].ID = DocumentProduct.DocumentID LEFT OUTER JOIN Documents_SumOfQuantityRelated ON DocumentProduct.ID = Documents_SumOfQuantityRelated.RelatedDocProdID " +
                                        "WHERE      ([Document].ProjectID = 3) AND ([Document].DocType = 3) " +
                                        "GROUP BY   DocumentProduct.ProductID " +
                                        "HAVING     " + having))
                        {
                            itemsBalance = rec.Table.Copy();
                        }
                    }

                }

                foreach (DataRow row in rows.Rows)
                {
                    quantity = (int)row["Quantity"];
                    int balance = 0;
                    if (itemsBalance != null)
                    {
                        foreach (DataRow balanceRow in itemsBalance.Rows)
                        {
                            if ((int)balanceRow["ProductID"] == (int)row["ProductID"])
                            {
                                balance = (int)balanceRow["Balance"];
                                if (balance == 0)
                                {
                                    // can't add this item, it has retured
                                    MessageBox.Show(Properties.Settings.Default.MsgItemsReturned, Properties.Settings.Default.MsgMessage, MessageBoxButtons.OK,MessageBoxIcon.Information);
                                    quantity = 0;
                                    DoSave = true;
                                }
                                else if (balance < (int)row["Quantity"])
                                {
                                    // change items quantity
                                    MessageBox.Show(Properties.Settings.Default.MsgItemsQttyChange, Properties.Settings.Default.MsgMessage, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    quantity = balance;
                                    DoSave = true;
                                }
                            }
                        }
                    }
                    if (quantity > 0)
                    {
                        CDocumentRow dr = new CDocumentRow(currentDocument.ID);
                        dr.ProductID = (int)row["ProductID"];
                        dr.ProductName = row["ProductName"].ToString();
                        dr.ProductDescription = row["ProductDesc"].ToString();
                        dr.Quantity = quantity;
                        dr.QuantityLimit = balance;
                        dr.Days = (int)row["Days"];
                        dr.RentalPrice = double.Parse(row["RentalPrice"].ToString());
                        dr.SalesPrice = double.Parse(row["SalesPrice"].ToString());
                        dr.Discount = double.Parse(row["Discount"].ToString());
                        if (row["DocNumber"].ToString().Length > 0)
                        {
                            dr.RelatedRowIdDocumentNo = (int)row["DocNumber"];
                            dr.DBId = (int)row["RelatedDocProdID"];
                        }

                        int Idx = documentEditor1.Rows.Count;
                        documentEditor1.Rows[Idx-1].LoadRow(dr);
                    }
                }
            }

            needSave = DoSave;
            btnExport.Visible = true;
            if (currentDocument.DocumentType == DocumentType.Quotation)
                btnNewDoc.Visible = true;
            if (currentDocument.Printed == true)
            {
                if (currentDocument.DocumentType != DocumentType.Quotation)
                {
                    btnSave.Visible = false;
                    Text += " (לקריאה בלבד)";
                    btnImport.Visible = false;
                    btnNewDoc.Visible = true;
                }
            }
        }

        public int GetProjectID()
        {
            int ret = 0;
            if (cboProjects.SelectedIndex > -1)
            {
                ComboItem ci = (ComboItem)cboProjects.SelectedItem;
                ret = ci.ID;
            }
            return ret;
        }

        public void SetProject(int ProjectID)
        {
            int projIdx = Program.GetComboIndexOfId(cboProjects, ProjectID);
            if (projIdx > -1)
            {
                cboProjects.SelectedIndex = projIdx;
                cboProjects_Validated(cboProjects, new EventArgs());
            }
        }

        private void SetDocType(DocumentType DocType)
        {
            documentType = DocType;
            //DateTime date2;

            switch (DocType)
            {
                case DocumentType.Quotation:
                    FormText = DOC_QUOTE;
                    lblDate2.Text = Date2Name;
                    dtpDate1.Value = DateTime.Today;
                    dtpDate2.Value = DateTime.Today.AddMonths(1);
                    //SetupGrid(DocType);
                    break;

                case DocumentType.ExitCertificate:
                    FormText = DOC_CERT_OUT;
                    lblDate2.Text = Date2Name;
                    dtpDate1.Value = DateTime.Today;
                    dtpDate2.Value = DateTime.Today.AddDays(1);
                    break;

                case DocumentType.ReturnCertificate:
                    FormText = DOC_CERT_IN;
                    lblDate2.Text = Date2Name;
                    dtpDate1.Value = DateTime.Today;
                    dtpDate2.Value = DateTime.Today;
                    break;

                case DocumentType.Bill:
                    FormText = DOC_BILL;
                    lblDate2.Text = Date2Name;
                    dtpDate1.Value = DateTime.Today;
                    dtpDate2.Visible = false;
                    break;

                default:
                    break;
            }
            Text = FormText;
        }

        private void SetupGrid(DocumentType DocType)
        {
            switch (DocType)
            {
                case DocumentType.Quotation:
                    break;

                default:
                    break;
            }
        }

        private void PopulateProjects()
        {
            using (DataTable projects = new CRentalProjects().AllRentalProjects(true))
            {
                foreach (DataRow row in projects.Rows)
                {
                    ComboItem ci = new ComboItem(row["ProjectName"].ToString(), (int)row["ID"]);
                    cboProjects.Items.Add(ci);
                }
            }
        }

        private void frmDocument_FormClosing(object sender, FormClosingEventArgs e)
        {
            // save window size
            if (WindowState == FormWindowState.Maximized)
            {
                Properties.Settings.Default.DocMaximised = true;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.DocMaximised = false;
                Properties.Settings.Default.DocLocation = Location;
                Properties.Settings.Default.DocSize = Size;
            }
            Properties.Settings.Default.Save();

            if (RecordLocked == true)
            {
                if (saved == true)
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                return;
            }

            // need save logic:
            if (needSave == true)
            {
                switch (MessageBox.Show(Properties.Settings.Default.MsgSaveChanges, 
                                        Properties.Settings.Default.MsgBeforeClosing,
                                        MessageBoxButtons.YesNoCancel,
                                        MessageBoxIcon.Question,
                                        MessageBoxDefaultButton.Button1,
                                        MessageBoxOptions.RtlReading))
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        SaveDocument();
                        break;

                    case System.Windows.Forms.DialogResult.Cancel:
                        e.Cancel = true;
                        break;
                }
            }
            if (saved == true)
                DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmDocument_Load(object sender, EventArgs e)
        {
            // recover window size
            if (Properties.Settings.Default.DocMaximised == true)
            {
                WindowState = FormWindowState.Maximized;
                Location = Properties.Settings.Default.DocLocation;
                Size = Properties.Settings.Default.DocSize;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                Location = Properties.Settings.Default.DocLocation;
                Size = Properties.Settings.Default.DocSize;
            }
            if (moveOverlap == true)
            {
                Point loc = Location;
                loc.Offset(30, 30);
                Location = loc;
            }

            // if this document is saved and non changable than lock it
            if (currentDocument != null)
                if (currentDocument.Printed == true)
                    RecordLocked = true;
        }

        private void cboProjects_Validating(object sender, CancelEventArgs e)
        {
            if (cboProjects.Text.Length > 0)
            {
                e.Cancel = cboProjects.FindStringExact(cboProjects.Text) < 0;
                if (e.Cancel == true)
                    MessageBox.Show("יש לבחור פרויקט מהרשימה", "טעות", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboProjects_Validated(object sender, EventArgs e)
        {
            if (cboProjects.Text.Length > 0)
            {
                ComboItem ci = (ComboItem)cboProjects.SelectedItem;
                using (CRentalProject rp = new CRentalProject(ci.ID))
                {
                    using (CRentalClient rc = new CRentalClient(rp.RentalClientID))
                    {
                        txtClient.Text = rc.ClientName;
                        txtClientDetails.Text = rc.ClientDetails;
                    }
                }

            }
        }

        private void SaveDocument()
        {
            // save this document
            //=================================================================

            // if we have a live CDocument instance then update it, if we don't
            // then we have a new document we need to add to the database...

            // before saving make sure document is ready to be saved as per Save button status:
            if (btnSave.Enabled == false)
            {
                MessageBox.Show(Properties.Settings.Default.MsgMissingField,
                                    Properties.Settings.Default.MsgCantProceed,
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                return;
            }

            ComboItem ci = (ComboItem)cboProjects.SelectedItem;
            if (currentDocument == null)
            {
                // create a new document instance:
                bool draft = false;
                if (documentType != DocumentType.Quotation)
                    draft = true;
                currentDocument = new CDocuments().NewDocument(documentType, ci.ID, txtSubject.Text, dtpDate1.Value, CurrentUserID, draft, ci.Text);
                Text = FormText + " " + currentDocument.DocumentNumber.ToString();
            }
            else
            {
                currentDocument.ProjectID = ci.ID;
                currentDocument.Subject = txtSubject.Text;
                currentDocument.Date1 = dtpDate1.Value;
                Text = FormText + " " + currentDocument.DocumentNumber.ToString();
            }

            if (currentDocument.DocumentType == DocumentType.Quotation)
                currentDocument.Date1 = DateTime.Now;
            if (dtpDate2.Visible == true)
                currentDocument.Date2 = dtpDate2.Value;
            currentDocument.ClientName = txtClient.Text;
            currentDocument.ClientDetails = txtClientDetails.Text;
            currentDocument.Notes = txtNotes.Text;

            currentDocument.Update();

            // now save the rows of the document:
            //
            // first mark previous rows of the document for deletion:
            currentDocument.DeleteAllDocumentRows(true);
            
            // now read through the document rows and save each line to db
            int rowAddedCount = 0;
            foreach (DocumentRow row in documentEditor1.Rows)
            {
                if (row.IsEmpty == false)
                {
                    CDocumentRow newRow = new CDocumentRow(currentDocument.ID);
                    newRow.RelatedRowID = row.RelatedDocumentNumber;
                    newRow.ProductID = row.ItemID;
                    newRow.ProductName = row.ItemName;
                    newRow.ProductDescription = row.ItemDescription;
                    if (row.IsRental == true)
                        newRow.RentalPrice = row.Price;
                    else
                        newRow.SalesPrice = row.Price;
                    newRow.Quantity = row.Quantity;
                    newRow.Days = row.Days;
                    newRow.Discount = row.Discount;
                    //newRow.RelatedDocID = row.RelatedDocID;
                    if (currentDocument.AddNewDocumentRow(newRow) > 0)
                        rowAddedCount++;
                }
            }

            if (currentDocument.HasDocumentRows == rowAddedCount)
            {
                // permanently delete old rows from db
                currentDocument.DeleteMarkedDocumentRows();
                needSave = false;
                saved = true;
                btnExport.Visible = true;

                // if this is a 
            }
            else
                MessageBox.Show("Not all rows saved...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void cboProjects_TextChanged(object sender, EventArgs e)
        {
            bool enableSave = false;
            if ((cboProjects.Text.Length * txtSubject.Text.Length) > 0)
                enableSave = true;

            btnSave.Enabled = enableSave;
            needSave = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveDocument();
        }

        private void txtClient_TextChanged(object sender, EventArgs e)
        {
            needSave = true;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            // before printing we make sure this document saved in the database
            if (needSave == true)
            {
                DialogResult dr = MessageBox.Show(Properties.Settings.Default.MsgNotSaved,
                    Properties.Settings.Default.MsgCantProceed,
                    MessageBoxButtons.OKCancel,
                    MessageBoxIcon.Question,
                    MessageBoxDefaultButton.Button1,
                    MessageBoxOptions.RtlReading);
                switch (dr)
                {
                    case System.Windows.Forms.DialogResult.OK:
                        SaveDocument();
                        if (needSave == false)
                            break;
                        else
                            return;

                    case System.Windows.Forms.DialogResult.Cancel:
                        return;
                }
            }

            if (AllowPrint == true)
            {
                using (frmExportSelection expFrm = new frmExportSelection(currentDocument))
                {
                    if (expFrm.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
                    {
                        if (currentDocument.DocumentType != DocumentType.Quotation)
                        {
                            RecordLocked = true;
                            Text += " (לקריאה בלבד)";
                            btnSave.Visible = false;
                        }
                        Text = FormText + " " + currentDocument.DocumentNumber.ToString();
                        saved = true;
                        btnNewDoc.Visible = true;
                    }
                }
            }
            else
                MessageBox.Show(Properties.Settings.Default.MsgNoPermission,
                    Properties.Settings.Default.MsgCantProceed,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        private void documentEditor1_DocumentChanged(object sender, EventArgs e)
        {
            if (txtSubject.Text.Length == 0)
            {
                // try and pull the subject of a related document...
                if (documentEditor1.Rows.Count > 0)
                {
                    int firstDocRowID = documentEditor1.Rows[0].RelatedDocumentNumber;
                    string subject = new CDocuments().GetDocumentRowSubject(firstDocRowID);
                    if (subject.Length > 0)
                        txtSubject.Text = subject;
                }

            }
            needSave = true;
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            documentEditor1.ImportFromRelatedDoc();
        }

        private void btnNewDoc_Click(object sender, EventArgs e)
        {
            if (new CFolderPermissions().FolderActionByUser(CurrentUserID, (int)NextDocumentType(currentDocument.DocumentType), 1) == true)
            {
                using (frmDocument docForm = new frmDocument(NextDocumentType(documentType), currentDocument.ID, true))
                {
                    docForm.AllowPrint = true;
                    docForm.RecordLocked = false;
                    docForm.CurrentUserID = CurrentUserID;
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

        private DocumentType NextDocumentType(DocumentType baseType)
        {
            /// set the editor mode base on the base document, under the logic that this 
            /// document in incremented from the base document
            /// 
            /// base doc    generated doc
            /// ============================
            /// Quote       Shipment
            /// Shipment    Receive
            /// Receive     Bill
            /// Bill        Quote
            DocumentType dt;
            switch (baseType)
            {
                case DocumentType.Quotation:
                    dt = DocumentType.ExitCertificate;
                    break;

                case DocumentType.ExitCertificate:
                    dt = DocumentType.ReturnCertificate;
                    break;

                case DocumentType.ReturnCertificate:
                    dt = DocumentType.Bill;
                    break;

                default:
                    dt = DocumentType.Quotation;
                    break;
            }
            return dt;
        }

        private int FindItemInDocumant(string FindCritiria, int startRow)
        {
            // finds an item in the document rows and sets focus to this item
            // returs the found item position

            for (int i = startRow; i < documentEditor1.Rows.Count; i++)
            {

            }

            return 0;
        }

        private void txtFind_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                FindInRows();
            }
        }

        private void picFind_Click(object sender, EventArgs e)
        {
            FindInRows();
        }

        private void FindInRows()
        {
            if (txtFind.Tag == null)
                txtFind.Tag = 0;
            int lastSearch = (int)txtFind.Tag;
            int f = documentEditor1.FindRow(txtFind.Text, lastSearch);
            if (f == -1)
            {
                // eof
                MessageBox.Show(Properties.Settings.Default.MsgEndOfDoc, Properties.Settings.Default.MsgFindInDoc, MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtFind.Tag = 0;
            }
            else
            {
                txtFind.Tag = f+1;
                documentEditor1.RowFocus(f);
            }
        }
    }
}

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
    public partial class ctlDocuments : ctlUIPanel
    {
        public ctlDocuments()
        {
            InitializeComponent();
            FolderID = 10;
            rdbClient.Checked = true;
        }

        public void PopulateFolders()
        {
            // populate folders

            // clear current list:
            cboDocType.Items.Clear();

            // get permitted folders
            using (DataTable folders = new CFolderPermissions().DocTypesByUser(CurrentUserID))
            {
                foreach (DataRow row in folders.Rows)
                {
                    ComboItem ci = new ComboItem(row["Folder"].ToString(), (int)row["ID"]);
                    cboDocType.Items.Add(ci);
                }
            }
            if (cboDocType.Items.Count > 0)
                cboDocType.SelectedIndex = 0;
        }

        private void ctlProjects_Resize(object sender, EventArgs e)
        {
            lvwDocuments.Columns[0].Width = 90;
            lvwDocuments.Columns[1].Width = 100;
            lvwDocuments.Columns[2].Width = 210;
            lvwDocuments.Columns[3].Width = lvwDocuments.ClientRectangle.Width - 400;
        }

        private DataTable GetDocumentsData()
        {
            DataTable ret = new DataTable();
            if (cboDocType.SelectedIndex == -1)
                return ret;
            // get selected folder to show
            ComboItem dt = (ComboItem)cboDocType.SelectedItem;
            DocumentType ft = (DocumentType)dt.ID;
            // get selected client
            int cl = 0;
            if (cboClients.Text.Length > 0)
            {
               ComboItem ci = (ComboItem)cboClients.SelectedItem;
               cl = ci.ID;
            }

            if (txtSearch.Text.Length > 0)
                if (cboClients.Text.Length > 0)
                    // By search AND filter
                    ret = new CDocuments().SearchDocuments(txtSearch.Text, ft, cl, rdbProject.Checked).Copy();
                else
                    // By search
                    ret = new CDocuments().SearchDocuments(txtSearch.Text, ft).Copy();
            else
                if (cboClients.Text.Length > 0)
                    // All AND filter
                    ret = new CDocuments().AllDocuments(ft, cl, rdbProject.Checked).Copy();
                else
                    // All
                    ret = new CDocuments().AllDocuments(ft).Copy();

            return ret;
        }

        private void picGo_Click(object sender, EventArgs e)
        {
            PopulateDocuments();
        }

        private void PopulateDocuments()
        {
            lvwDocuments.BeginUpdate();
            Cursor = Cursors.WaitCursor;
            lvwDocuments.Items.Clear();
            using (DataTable clients = GetDocumentsData())
            {
                foreach (DataRow row in clients.Rows)
                {
                    ListViewItem lvi = new ListViewItem(DateTime.Parse(row["Date1"].ToString()).ToShortDateString());
                    lvi.SubItems.Add(row["DocNumber"].ToString());
                    lvi.SubItems.Add(row["ProjectName"].ToString() + " - " + row["ClientName"].ToString());
                    lvi.SubItems.Add(row["Subject"].ToString());
                    lvi.Tag = (int)row["ID"];
                    lvwDocuments.Items.Add(lvi);
                }
                lblSumm.Text = "נמצאו " + clients.Rows.Count.ToString() + " מסמכים";
            }
            lvwDocuments.EndUpdate();
            Cursor = Cursors.Default;
            ctlProjects_Resize(this, new EventArgs());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Return)
            //    PopulateDocuments();
        }

        public override void AddNew()
        {
            ComboItem ci = (ComboItem)cboDocType.SelectedItem;

            if (AllowNew(ci.ID) == false)
            {
                MessageBox.Show(Properties.Settings.Default.MsgNoPermission,
                    Properties.Settings.Default.MsgCantProceed,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            bool retOK = false;
            if ((DocumentType)ci.ID == DocumentType.CheckOut)
            {
                using (frmChechOut chktFrom = new frmChechOut())
                {
                    chktFrom.AllowPrint = AllowExport(ci.ID);
                    chktFrom.CurrentUserID = CurrentUserID;
                    if (chktFrom.ShowDialog(this) == DialogResult.OK)
                        retOK = true;
                }
            }
            else
            {
                using (frmDocument docForm = new frmDocument((DocumentType)ci.ID))
                {
                    docForm.AllowPrint = AllowExport(ci.ID);
                    docForm.CurrentUserID = CurrentUserID;
                    if (docForm.ShowDialog(this) == DialogResult.OK)
                        retOK = true;
                }
            }
            if (retOK == true)
            {
                PopulateDocuments();
                mainUi ui = (mainUi)FindForm();
                ui.AskRefreshProjects();
            }
        }

        public override void EditItem()
        {
            if (lvwDocuments.SelectedItems.Count == 0)
                return;

            int docID = (int)lvwDocuments.SelectedItems[0].Tag;
            ComboItem ci = (ComboItem)cboDocType.SelectedItem;

            // use document window for documents
            if (ci.ID != (int)DocumentType.CheckOut)
            {
                using (frmDocument docForm = new frmDocument(docID))
                {
                    docForm.AllowPrint = AllowExport(ci.ID);
                    docForm.RecordLocked = !AllowEdit(ci.ID);
                    docForm.CurrentUserID = CurrentUserID;
                    if (docForm.ShowDialog(this) == DialogResult.OK)
                    {
                        PopulateDocuments();
                        mainUi ui = (mainUi)FindForm();
                        ui.AskRefreshProjects();
                    }
                }
            }
            else
            {
                // use checkout window for checkout
                using (frmChechOut chkoutForm = new frmChechOut(docID))
                {
                    chkoutForm.AllowPrint = AllowExport(ci.ID);
                    chkoutForm.CurrentUserID = CurrentUserID;
                    if (chkoutForm.ShowDialog(this) == DialogResult.OK)
                    {
                        PopulateDocuments();
                        mainUi ui = (mainUi)FindForm();
                        ui.AskRefreshProjects();
                    }
                }
            }
        }

        public override void ExportItem()
        {
            if (lvwDocuments.SelectedItems.Count == 0)
                return;

            int docID = (int)lvwDocuments.SelectedItems[0].Tag;
            ComboItem ci = (ComboItem)cboDocType.SelectedItem;

            if (AllowExport(ci.ID) == true)
            {
                using (CDocument doc = new CDocument(docID))
                {
                    using (frmExportSelection expFrm = new frmExportSelection(doc))
                    {
                        expFrm.ShowDialog(this);
                    }
                }
            }
            else
                MessageBox.Show(Properties.Settings.Default.MsgNoPermission,
                    Properties.Settings.Default.MsgCantProceed,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
        }

        public override void Refresh()
        {
            PopulateDocuments();
        }

        private void rdbClient_CheckedChanged(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            cboClients.Text = "";
            cboClients.Items.Clear();
            DataTable list;
            string table;
            if (rdbClient.Checked == true)
            {
                // populate with clients
                list = new CRentalClients().AllRentalClients(true);
                table = "ClientName";
            }
            else
            {
                // populate with projectss
                list = new CRentalProjects().AllRentalProjects(true);
                table = "ProjectName";
            }
            foreach (DataRow row in list.Rows)
            {
                ComboItem ci = new ComboItem(row[table].ToString(), (int)row["ID"]);
                cboClients.Items.Add(ci);
            }
            list.Dispose();

            Cursor = Cursors.Default;

            PopulateDocuments();
        }

        private void cboClients_Validating(object sender, CancelEventArgs e)
        {
            if (cboClients.Text.Length > 0)
            {
                e.Cancel = cboClients.FindStringExact(cboClients.Text) < 0;
                if (e.Cancel == true)
                    MessageBox.Show("יש לבחור מהרשימה", "טעות", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void cboDocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDocuments();
        }

        private void cboClients_Validated(object sender, EventArgs e)
        {
            PopulateDocuments();
        }

        private void lvwQuotes_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditItem();
        }

        private void cboClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDocuments();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //if (txtSearch.Text.Length == 0)
                PopulateDocuments();
        }
    }
}

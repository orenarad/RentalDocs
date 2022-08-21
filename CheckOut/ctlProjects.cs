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
    public partial class ctlProjects : ctlUIPanel
    {
        public ctlProjects()
        {
            InitializeComponent();
            FolderID = 9;

            PopulateProjects();
        }

        public void PopulateNewMenu()
        {
            cmsNewDoc.Items.Clear();

            using (DataTable folders = new CFolderPermissions().FoldersByUser(CurrentUserID, false))
            {
                foreach (DataRow row in folders.Rows)
                {
                    if (bool.Parse(row["IsDocument"].ToString()) == true)
                    {
                        ToolStripItem tsi = cmsNewDoc.Items.Add(row["Folder"].ToString());
                        tsi.Tag = (int)row["ID"];
                    }
                }
            }
        }

        private void ctlProjects_Resize(object sender, EventArgs e)
        {
            lvwDocuments.Columns[0].Width = 90;
            lvwDocuments.Columns[1].Width = 100;
            lvwDocuments.Columns[2].Width = lvwDocuments.ClientRectangle.Width - 190;
        }

        private DataTable GetProjectsData()
        {
            DataTable ret;
            if (txtSearch.Text.Length > 0)
                ret = new CRentalProjects().SearchRentalProjects(txtSearch.Text, chkActive.Checked).Copy();
            else
                ret = new CRentalProjects().AllRentalProjects(chkActive.Checked).Copy();
            return ret;
        }

        private void picGo_Click(object sender, EventArgs e)
        {
            PopulateProjects();
        }

        private void PopulateProjects()
        {
            lbxProjects.BeginUpdate();
            Cursor = Cursors.WaitCursor;
            lbxProjects.Items.Clear();
            using (DataTable clients = GetProjectsData())
            {
                PimpedListBoxItem pitem = new PimpedListBoxItem();
                foreach (DataRow row in clients.Rows)
                {
                    pitem.Title = row["ProjectName"].ToString();
                    if ((bool)row["Inactive"] == true)
                        pitem.Title += " (לא פעיל)";
                    pitem.SubTitle = row["ClientName"].ToString();
                    pitem.DbID = (int)row["ID"];
                    lbxProjects.Items.Add(pitem);
                }
                lblSumm.Text = "נמצאו " + clients.Rows.Count.ToString() + " פרויקטים";
            }
            lbxProjects.EndUpdate();
            Cursor = Cursors.Default;
            ctlProjects_Resize(this, new EventArgs());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Return)
            //    PopulateProjects();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //if (txtSearch.Text.Length == 0)
                PopulateProjects();
        }

        public override void AddNew()
        {
            if (AllowNew(FolderID) == false)
            {
                MessageBox.Show(Properties.Settings.Default.MsgNoPermission,
                    Properties.Settings.Default.MsgCantProceed,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using (frmProject projectForm = new frmProject())
            {
                if (projectForm.ShowDialog(this) == DialogResult.OK)
                {
                    PopulateProjects();
                }
            }
        }

        public override void EditItem()
        {
            if (lbxProjects.SelectedItems.Count > 0)
            {
                PimpedListBoxItem p = (PimpedListBoxItem)lbxProjects.SelectedItem;
                using (frmProject projectForm = new frmProject(p.DbID))
                {
                    projectForm.RecordLocked = !AllowEdit(FolderID);
                    if (projectForm.ShowDialog(this) == DialogResult.OK)
                    {
                        PopulateProjects();
                    }
                }
            }
        }

        public override void Refresh()
        {
            PopulateProjects();
            PopulateDocuments();
            btnNew.Enabled = false;
        }

        public void RefreshDocuments()
        {
            PopulateDocuments();
        }

        private void lvwDocuments_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvwDocuments.SelectedItems.Count == 0)
                return;

            int docID = (int)lvwDocuments.SelectedItems[0].Tag;
            int folID = (int)lvwDocuments.SelectedItems[0].Group.Tag;

            // use document window for documents
            if (folID != (int)DocumentType.CheckOut)
            {
                using (frmDocument docForm = new frmDocument(docID))
                {
                    docForm.AllowPrint = AllowExport(folID);
                    docForm.CurrentUserID = CurrentUserID;
                    docForm.RecordLocked = !AllowEdit(folID);
                    if (docForm.ShowDialog(this) == DialogResult.OK)
                    {
                        PopulateDocuments();
                        mainUi ui = (mainUi)FindForm();
                        ui.AskRefreshDocuments();
                    }
                }
            }
            else
            {
                // use checkout window for checkout
                using (frmChechOut chkForm = new frmChechOut(docID))
                {
                    if (chkForm.ShowDialog(this) == DialogResult.OK)
                    {
                        PopulateDocuments();
                        mainUi ui = (mainUi)FindForm();
                        ui.AskRefreshDocuments();
                    }
                }
            }
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            PopulateProjects();
        }

        private void lbxProjects_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditItem();
        }

        private void lbxProjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateDocuments();
            btnNew.Enabled = (lbxProjects.SelectedItems.Count > 0);
        }

        private void PopulateDocuments()
        {
            // populate documents list for selected project
            lvwDocuments.Items.Clear();
            if (lbxProjects.SelectedItems.Count == 0)
                return;

            lvwDocuments.BeginUpdate();

            PimpedListBoxItem proj = (PimpedListBoxItem)lbxProjects.SelectedItem;


            using (DataTable fp = new CFolderPermissions().FoldersByUser(CurrentUserID, false))
            {
                using (DataTable docs = new CDocuments().AllDocuments(proj.DbID, true))
                { 
                    foreach (DataRow row in docs.Rows)
                    {
                        ListViewItem lvi = new ListViewItem(DateTime.Parse(row["Date1"].ToString()).ToShortDateString());
                        lvi.SubItems.Add(row["DocNumber"].ToString());
                        lvi.SubItems.Add(row["Subject"].ToString());
                        lvi.Tag = (int)row["ID"];
                        foreach (DataRow fps in fp.Rows)
                        {
                            // include only document types permitted for user
                            if ((int)fps["ID"] == (int)row["DocType"])
                            {
                                lvwDocuments.Items.Add(lvi);
                                switch ((DocumentType)row["DocType"])
                                {
                                    case DocumentType.Quotation:
                                        lvwDocuments.Groups[0].Items.Add(lvi);
                                        lvwDocuments.Groups[0].Tag = (int)row["DocType"];
                                        break;

                                    case DocumentType.ExitCertificate:
                                        lvwDocuments.Groups[1].Items.Add(lvi);
                                        lvwDocuments.Groups[1].Tag = (int)row["DocType"];
                                        break;

                                    case DocumentType.ReturnCertificate:
                                        lvwDocuments.Groups[2].Items.Add(lvi);
                                        lvwDocuments.Groups[2].Tag = (int)row["DocType"];
                                        break;

                                    case DocumentType.Bill:
                                        lvwDocuments.Groups[3].Items.Add(lvi);
                                        lvwDocuments.Groups[3].Tag = (int)row["DocType"];
                                        break;

                                    case DocumentType.CheckOut:
                                        lvwDocuments.Groups[4].Items.Add(lvi);
                                        lvwDocuments.Groups[4].Tag = (int)row["DocType"];
                                        break;
                                }
                                break;
                            }
                        }
                    }
                }
            }

            lvwDocuments.EndUpdate();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            Button btnSender = (Button)sender;
            Point ptLowerLeft = new Point(0, btnSender.Height);
            ptLowerLeft = btnSender.PointToScreen(ptLowerLeft);
            cmsNewDoc.Show(ptLowerLeft);
        }

        private void cmsNewDoc_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            // ignore if no project selected:
            if (lbxProjects.SelectedItems.Count == 0)
                return;

            // get requested document type:
            DocumentType dt = (DocumentType)e.ClickedItem.Tag;
            // check user permission:
            if (AllowNew((int)e.ClickedItem.Tag) == false)
            {
                MessageBox.Show(Properties.Settings.Default.MsgNoPermission,
                    Properties.Settings.Default.MsgCantProceed,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            PimpedListBoxItem proj = (PimpedListBoxItem)lbxProjects.SelectedItem;
            // upen document form:
            if (dt != DocumentType.CheckOut)
            {
                using (frmDocument docForm = new frmDocument(dt))
                {
                    docForm.AllowPrint = AllowExport((int)e.ClickedItem.Tag);
                    docForm.SetProject(proj.DbID);
                    docForm.CurrentUserID = CurrentUserID;
                    if (docForm.ShowDialog(this) == DialogResult.OK)
                    {
                        PopulateDocuments();
                        mainUi ui = (mainUi)FindForm();
                        ui.AskRefreshDocuments();
                    }
                
                }
            }
            else
            {
                using (frmChechOut chkoutForm = new frmChechOut())
                {
                    chkoutForm.AllowPrint = AllowExport((int)e.ClickedItem.Tag);
                    chkoutForm.SetProject(proj.DbID);
                    chkoutForm.CurrentUserID = CurrentUserID;
                    if (chkoutForm.ShowDialog(this) == DialogResult.OK)
                    {
                        PopulateDocuments();
                        mainUi ui = (mainUi)FindForm();
                        ui.AskRefreshDocuments();
                    }
                }
            }
        }
    }
}

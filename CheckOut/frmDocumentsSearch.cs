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
    public partial class frmDocumentsSearch : Form
    {
        private int currentUserID = 0;
        private int currentProjectID = 0;
        private DocumentType docType;

        private const string ALL = "הכל";

        public frmDocumentsSearch(int ProjectID, int CurrentUserID, DocumentType DocType)
        {
            currentUserID = CurrentUserID;
            currentProjectID = ProjectID;
            InitializeComponent();
            PopulateFolders(DocType);
            cboDocType.Enabled = (DocType != DocumentType.ExitCertificate);
            docType = DocType;
        }

        public void PopulateFolders(DocumentType DocType)
        {
            // populate folders
            using (DataTable folders = new CFolderPermissions().DocTypesByUser(currentUserID))
            {
                foreach (DataRow row in folders.Rows)
                {
                    ComboItem ci = new ComboItem(row["Folder"].ToString(), (int)row["ID"]);
                    cboDocType.Items.Add(ci);
                }
            }
            if (cboDocType.Items.Count > 0)
                cboDocType.SelectedIndex = Program.GetComboIndexOfId(cboDocType, (int)DocType);
        }

        private void cboDocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboDocType.SelectedIndex < 0)
                return;
            ComboItem ci = (ComboItem)cboDocType.SelectedItem;
            //lvwDocument.Items.Clear();
            lbxDocs.Items.Clear();
            int docNo = 0;
            lbxDocs.Items.Add(new ComboItem(ALL, 0));
            // populate documents for this project and folder

            // if this document mode is ReturnCertificate than only balance is allowd to be listed
            using (DataTable getrows = new CDocumentRow(0).GetDocumentRows((DocumentType)ci.ID, currentProjectID))
            {
                ListViewGroup lvg = new ListViewGroup();
                foreach (DataRow row in getrows.Rows)
                {
                    if ((int)row["DocNumber"] > 0)
                    {
                        if ((int)row["Balance"] > 0)
                        {
                            if (docNo != (int)row["DocNumber"])
                            {
                                // start a new group for this document
                                lvg = new ListViewGroup(row["DocNumber"].ToString() + " - " + row["Subject"].ToString() + " - " + DateTime.Parse(row["Date1"].ToString()).ToShortDateString());
                                lbxDocs.Items.Add(lvg);
                                
                            }
                            docNo = (int)row["DocNumber"];
                            ListViewItem lvi = new ListViewItem(row["ProductName"].ToString());
                            lvi.SubItems.Add(row["ProductDesc"].ToString());
                            lvi.SubItems.Add(row["Balance"].ToString());
                            lvi.Tag = (int)row["ID"];
                            lvg.Items.Add((ListViewItem)lvi);
                            //lvwDocument.Items.Add(lvi);
                        }
                    }
                }
            }
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lbxDocs.Items.Count; i++)
            {
                lbxDocs.SetItemChecked(i, true);
            }
        }

        private void btnSelDoc_Click(object sender, EventArgs e)
        {
            if (lvwDocument.SelectedItems.Count > 0)
            {
                foreach (ListViewItem lvi in lvwDocument.SelectedItems[0].Group.Items)
                {
                    lvi.Checked = true;
                }
            }
        }

        private void lvwDocument_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            // go through all the listbox stored listviewitems and check this item.
            foreach (object lbxItem in lbxDocs.Items)
            {
                try //avoiding the first item which is NOT a list view group
                {
                    ListViewGroup lvg = (ListViewGroup)lbxItem;
                    foreach (ListViewItem lvi in lvg.Items)
                    {
                        if (lvi.Tag == e.Item.Tag)
                        {
                            lvi.Checked = e.Item.Checked;
                            break;
                        }
                    }
                }
                catch { }
            }
            //////////foreach (ListViewItem lvi in lvwDocument.Items)
            //////////{
            //////////    if (lvi.Checked == true)
            //////////    {
            //////////        btnOK.Enabled = true;
            //////////        return;
            //////////    }
            //////////}
            //////////btnOK.Enabled = false;
        }

        public int[] GetCheckedItems()
        {
            if (lvwDocument.CheckedItems.Count > 0)
            {
                int[] ret = new int[lvwDocument.CheckedItems.Count];
                int i = 0;
                foreach (ListViewItem lvi in lvwDocument.CheckedItems)
                {
                    ret[i] = (int)lvi.Tag;
                    i++;
                }
                return ret;
            }
            else
                return null;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void lbxDocs_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ListViewGroup lvg = (ListViewGroup)lbxDocs.Items[e.Index];
            foreach (ListViewItem lvi in lvg.Items)
            {
                lvi.Checked = (e.NewValue == CheckState.Checked);
            }
        }

        private void lbxDocs_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvwDocument.Items.Clear();
            lvwDocument.Groups.Clear();
            if (lbxDocs.Text == ALL)
            {
                foreach (object lbxItem in lbxDocs.Items)
                {
                    try
                    {
                        ListViewGroup lvg = (ListViewGroup)lbxItem;
                        ListViewGroup g = lvwDocument.Groups.Add("", lvg.Header);

                        foreach (ListViewItem glvi in lvg.Items)
                        {
                            ListViewItem lvi = new ListViewItem(glvi.Text);
                            lvi.SubItems.Add(glvi.SubItems[1].Text);
                            lvi.SubItems.Add(glvi.SubItems[2].Text);
                            lvi.Checked = glvi.Checked;
                            lvi.Tag = glvi.Tag;
                            lvwDocument.Items.Add(lvi);
                            g.Items.Add(lvi);
                        }
                    }
                    catch { }
                }

            }
            else
            {
                ListViewGroup lvg = (ListViewGroup)lbxDocs.SelectedItem;
                lvwDocument.Groups.Add("", lvg.Header);
                foreach (ListViewItem glvi in lvg.Items)
                {
                    ListViewItem lvi = new ListViewItem(glvi.Text);
                    lvi.SubItems.Add(glvi.SubItems[1].Text);
                    lvi.SubItems.Add(glvi.SubItems[2].Text);
                    lvi.Checked = glvi.Checked;
                    lvi.Tag = glvi.Tag;
                    lvwDocument.Items.Add(lvi);
                    lvwDocument.Groups[0].Items.Add(lvi);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

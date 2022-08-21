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
    public partial class frmDocumentsSearch2 : Form
    {
        private int currentUserID = 0;
        private int currentProjectID = 0;
        private DocumentType docType;
        DataTable DocItems = null;
        int selectedFolderIndex = -1;

        private const string ALL = "הכל";
        private const string SEL_ALL = "בחר הכל";
        private const string SEL_NONE = "בטל הכל";


        public struct DocItem
        {
            public int DocumentProductID;
            public int Quantity;
        }

        public frmDocumentsSearch2(int ProjectID, int CurrentUserID, DocumentType DocType)
        {
            currentUserID = CurrentUserID;
            currentProjectID = ProjectID;
            InitializeComponent();

            // build DocItems table structure
            DocItems = new DataTable();
            DocItems.Columns.Add("DocItemID", typeof(int));
            DocItems.Columns.Add("DocID", typeof(int));
            DocItems.Columns.Add("DocNumber", typeof(int));
            DocItems.Columns.Add("DocSubject", typeof(string));
            DocItems.Columns.Add("Item", typeof(string));
            DocItems.Columns.Add("Description", typeof(string));
            DocItems.Columns.Add("Quantity1", typeof(int));
            DocItems.Columns.Add("Quantity2", typeof(int));

            PopulateFolders(DocType);
            cboDocType.Enabled = (DocType != DocumentType.ExitCertificate);
            docType = DocType;

            lvwDocument.Columns[0].Width = 40;
            lvwDocument.Columns[1].Width = 40;
            lvwDocument.Columns[2].Width = 200;
            lvwDocument.Columns[3].Width = 300;

            btnChkAll.Text = SEL_ALL;
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
                return; // exit function if selection is blank.

            // clear current table...
            DocItems.Rows.Clear();

            // clear listbox   
            lbxDocs.Items.Clear();
            lbxDocs.Items.Add(new ComboItem(ALL, 0));

            // loads the DocItems table as per selected doc type
            string docHeader = "";
            ComboItem ci = (ComboItem)cboDocType.SelectedItem;
            using (DataTable getrows = new CDocumentRow(0).GetDocumentRows((DocumentType)ci.ID, currentProjectID))
            {
                foreach (DataRow row in getrows.Rows)
                {
                    if ((int)row["DocNumber"] > 0)
                    {
                        if ((int)row["Balance"] > 0)
                        {
                            DataRow n_row = DocItems.NewRow();
                            n_row["DocItemID"] = (int)row["ID"];
                            n_row["DocID"] = (int)row["DocumentID"];
                            n_row["DocNumber"] = row["DocNumber"].ToString();
                            n_row["DocSubject"] = row["Subject"].ToString();
                            n_row["Item"] = row["ProductName"].ToString();
                            n_row["Description"] = row["ProductDesc"].ToString();
                            n_row["Quantity1"] = row["Balance"].ToString();
                            n_row["Quantity2"] = 0;
                            DocItems.Rows.Add(n_row);
                            if (docHeader != n_row["DocNumber"].ToString())
                            {
                                lbxDocs.Items.Add(new ComboItem(n_row["DocNumber"] + " - " +
                                                                n_row["DocSubject"],
                                                                (int)n_row["DocID"]));
                                docHeader = n_row["DocNumber"].ToString();
                            }
                        }
                    }
                }
            }
            lbxDocs.SelectedIndex = 0;
            selectedFolderIndex = cboDocType.SelectedIndex;
        }

        private int CheckedItemsCount()
        {
            int c = 0;
            foreach (DataRow r in DocItems.Rows)
            {
                if ((bool)r["Checked"] == true)
                    c++;
            }
            return c;
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
        }

        private void lvwDocument_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            //if (lvwDocument.FocusedItem != null)
            //{
                // copy the max available quantity to the selected quantity
                int qtty = 0;
                if (e.Item.Checked == true)
                    int.TryParse(e.Item.SubItems[1].Text, out qtty);
            
                e.Item.Text = qtty.ToString();

                // store the value in the table 
                if (StoreQuantityValue((int)e.Item.Tag, qtty) == false)
                    MessageBox.Show("Couldn't store value...");
            //}
            btnOK.Enabled = EnableOK();

            bool AllChecked = true;
            foreach (ListViewItem lvi in lvwDocument.Items)
            {
                if (lvi.Checked == false)
                {
                    AllChecked = false;
                    break;
                }
            }
            if (AllChecked == true)
                btnChkAll.Text = SEL_NONE;
            else
                btnChkAll.Text = SEL_ALL;

        }

        private bool EnableOK()
        {
            foreach (DataRow row in DocItems.Rows)
            {
                if ((int)row["Quantity2"] > 0)
                    return true;
            }
            return false;
        }

        private bool StoreQuantityValue(int DocItemID, int SelectedQtty)
        {
            // return true if succesful
            foreach (DataRow row in DocItems.Rows)
            {
                if ((int)row["DocItemID"] == DocItemID)
                {
                    row["Quantity2"] = SelectedQtty;
                    return true;
                }
            }
            return false;
        }

        public List<DocItem> GetCheckedItems()
        {
            // this is called from the owner form to receive the selectd items.

            // returns a struct with ID and Quantity
            List<DocItem> ret = new List<DocItem>();

            foreach (DataRow row in DocItems.Rows)
            {
                if ((int)row["Quantity2"] != 0)
                {
                    DocItem di;
                    di.DocumentProductID = (int)row["DocItemID"];
                    di.Quantity = (int)row["Quantity2"];
                    ret.Add(di);
                }
            }
            return ret;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void lbxDocs_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            // checking the listbox will select all items assosiated with the list item
        }

        private void lbxDocs_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateListview();
        }

        private void UpdateListview()
        {
            if (lbxDocs.SelectedIndex == -1)
                return;

            // loads the items assosiated with the list item onto the list view

            // clear listview
            lvwDocument.Items.Clear();
            lvwDocument.Groups.Clear();

            // filter list to search....
            string filter = txtSearch.Text;

            lvwDocument.BeginUpdate();
            int docGroup = 0;
            ComboItem selectedDoc = (ComboItem)lbxDocs.SelectedItem;

            ListViewGroup lvg = new ListViewGroup();
            bool AllChecked = true;

            foreach (DataRow row in DocItems.Rows)
            {
                if (selectedDoc.ID == 0 || selectedDoc.ID == (int)row["DocID"])
                {
                    // filter to search?
                    string item = row["Item"].ToString();
                    if (filter.Length < 2 || (filter.Length > 1 && item.IndexOf(filter, StringComparison.CurrentCultureIgnoreCase) > -1))
                    {

                        if (docGroup != (int)row["DocID"])
                        {
                            lvg = new ListViewGroup(row["DocID"].ToString(),
                                                    row["DocNumber"] + " - " +
                                                    row["DocSubject"]);
                            lvwDocument.Groups.Add(lvg);
                            docGroup = (int)row["DocID"];
                        }
                        ListViewItem lvi = new ListViewItem(lvg);
                        lvi.Text = row["Quantity2"].ToString();
                        lvi.SubItems.Add(row["Quantity1"].ToString());
                        lvi.SubItems.Add(row["Item"].ToString());
                        lvi.SubItems.Add(row["Description"].ToString());
                        if (row["Quantity2"].ToString() != "0")
                            lvi.Checked = true;
                        else
                            if (AllChecked == true)
                                AllChecked = false;
                        lvi.Tag = (int)row["DocItemID"];
                        lvg.Items.Add(lvi);
                        lvwDocument.Items.Add(lvi);

                    }
                }
            }
            if (AllChecked == true)
                btnChkAll.Text = SEL_NONE;
            else
                btnChkAll.Text = SEL_ALL;

            lvwDocument.EndUpdate();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lvwDocument_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (Program.IsInteger(e.Label) == false)
                e.CancelEdit = true;
            else
            {
                int suggested;
                int.TryParse(e.Label, out suggested);
                if (suggested < 0)
                    e.CancelEdit = true;
                else
                {
                    int available;
                    int.TryParse(lvwDocument.Items[e.Item].SubItems[1].Text, out available);
                    if (suggested > available)
                    {
                        e.CancelEdit = true;
                        lvwDocument.Items[e.Item].Text = available.ToString();
                        suggested = available;
                    } 
               
                    // set checkbox
                    lvwDocument.Items[e.Item].Checked = (suggested > 0);

                    // store the value in the table 
                    if (StoreQuantityValue((int)lvwDocument.Items[e.Item].Tag, suggested) == false)
                        MessageBox.Show("Couldn't store value...");
                }
            }
        }

        private void FilterTable(string SearchText)
        {

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            //if (txtSearch.Text.Length < 2)
                UpdateListview();
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show(e.KeyChar.ToString());
        }

        private void btnChkAll_Click(object sender, EventArgs e)
        {
            bool sel = (btnChkAll.Text == SEL_ALL);
            foreach (ListViewItem lvi in lvwDocument.Items)
            {
                lvi.Checked = sel;
            }
        }
    }
}

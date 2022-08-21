using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentCheckOut
{
    public partial class frmFindItem : Form
    {
        public frmFindItem()
        {
            InitializeComponent();
            CategoryTreeView ctv = new CategoryTreeView(tvwCategories);
            ctv.Dispose();
            tvwCategories.ExpandAll();
            tvwCategories.SelectedNode = tvwCategories.Nodes[0];
        }

        //public frmFindItem(CCategory ShowCategory)
        //{
        //    InitializeComponent();
        //    tvwCategories.Nodes.Add(PopulateCategories(new CCategory(1)));
        //    tvwCategories.ExpandAll();
        //    tvwCategories.SelectedNode = tvwCategories.Nodes[0];
        //}

        public CItem[] GetSelectedItems()
        {
            if (lvwSelectedItems.Items.Count > 0)
            {
                CItem[] selectedItems = new CItem[lvwSelectedItems.Items.Count];
                int i = 0;
                foreach (ListViewItem lvi in lvwSelectedItems.Items)
                {
                    selectedItems[i] = new CItem((int)lvi.Tag);
                    i++;
                }
                return selectedItems;
            }
            else
                return null;
        }

        public CItem FirstItem
        {
            get
            {
                if (lvwSelectedItems.Items.Count > 0)
                    return new CItem((int)lvwSelectedItems.Items[0].Tag);
                else
                    return null;
            }
        }

        private void PopulateItems(DataTable Items)
        {
            PopulateItems(Items, 0);
        }

        private void PopulateItems(DataTable Items, int SelectID)
        {
            lvwItems.BeginUpdate();
            lvwItems.Items.Clear();

            ListViewItem lvi;

            foreach (DataRow row in Items.Rows)
            {
                lvi = new ListViewItem(row["ID"].ToString());
                lvi.Tag = (int)row["ID"];
                lvi.SubItems.Add(row["Name"].ToString());
                if (row["Description"].ToString().Length > 0) 
                    lvi.SubItems[1].Text += " - " + row["Description"].ToString();
                lvi.SubItems.Add(row["SerNo"].ToString());
                lvwItems.Items.Add(lvi);
                if ((int)row["ID"] == SelectID)
                {
                    lvi.Selected = true;
                    lvi.EnsureVisible();
                }
            }
            lvwItems.EndUpdate();
        }

        private void tvwCategories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CCategory cat = new CCategory((int)e.Node.Tag);
            PopulateItems(cat.Items);
        }

        private void lvwItems_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FindItem(txtFind.Text);
        }

        private void FindItem(string p)
        {
            if (p.Length > 1)
            {
                PopulateItems(new CItems().SearchItems(p));
            }
        }

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                FindItem(txtFind.Text);
        }

        private void txtSerials_KeyUp(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Return)
            //    FindSerials(txtSerials.Text);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FindSerials(txtSerials.Text);
        }

        private void FindSerials(string p)
        {
            string serials = p;
            serials = serials.Trim();
            string ser;
            int c = serials.IndexOf("+");

            for (; serials.Length > 0; )
            {
                if (c > -1)
                    ser = serials.Substring(0, c);
                else
                    ser = serials;

                //CItem item = new CItem(ser);
                //if (item.IsEmpty != true)
                //{
                //    // create a new listitem for the found serial
                //    ListViewItem lvi = new ListViewItem(item.ID.ToString());
                //    lvi.Tag = item.ID;
                //    lvi.SubItems.Add(item.Name);
                //    lvi.SubItems[1].Text += " - " + item.Description;
                //    lvi.SubItems.Add(item.SerialNo);
                //    AddToSelectedList(lvi);
                //}
                //else
                //    MessageBox.Show("Serial No. " + ser + " was not found", "Search Items", MessageBoxButtons.OK, MessageBoxIcon.Information);

                //item.Dispose();

                if (c > -1)
                    serials = serials.Substring(c + 1);
                else
                    serials = "";
                c = serials.IndexOf("+");
            }
        }

        private void lvwItems_DoubleClick(object sender, EventArgs e)
        {
            if (lvwItems.SelectedItems.Count > 0)
                AddToSelectedList((ListViewItem)lvwItems.SelectedItems[0].Clone());
        }

        private void lvwSelectedItems_DoubleClick(object sender, EventArgs e)
        {
            if (lvwSelectedItems.SelectedItems.Count > 0)
                lvwSelectedItems.Items.Remove(lvwSelectedItems.SelectedItems[0]);
            // enable OK button only if selected list is not empty
            btnOK.Enabled = (lvwSelectedItems.Items.Count > 0);
        }

        private void AddToSelectedList(ListViewItem SelItem)
        {
            foreach (ListViewItem lvi in lvwSelectedItems.Items)
            {
                if (lvi.Text == SelItem.Text) 
                    return;
            }
            //CItem item = new CItem(int.Parse(SelItem.Text));
            //if (item.Status == CItem.ItemStatus.Malfunction)
            //    MessageBox.Show("This item has an unresolved malfunction.", "Selecing Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            //if (item.Status == CItem.ItemStatus.Out)
            //    MessageBox.Show("This item currently Out on Production.", "Selecing Item", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            lvwSelectedItems.Items.Add(SelItem);
            btnOK.Enabled = (lvwSelectedItems.Items.Count > 0);
        }

        private void frmFindItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            //try
            //{
            //    SelectedItem.Dispose();
            //}
            //catch { }
        }

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            frmItem fi = new frmItem();
            if (fi.ShowDialog(this) == DialogResult.OK)
            {
                CRecord rec = new CRecord(new SqlCommand("SELECT MAX(ID) As MI FROM Item"));
                int newID = (int)rec.Table.Rows[0][0];
                PopulateItems(new CItems().AllItems, newID);
                rec.Dispose();
            }
        }

        private void cmsiSelect_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = (lvwItems.SelectedItems.Count == 0);
        }

        private void cmsiOpen_Click(object sender, EventArgs e)
        {
            frmItem fi = new frmItem(new CItem((int)lvwItems.SelectedItems[0].Tag),0);
            if (fi.ShowDialog(this) == DialogResult.OK)
            {
                if (txtFind.Text.Length > 1)
                    FindItem(txtFind.Text);
                else
                    PopulateItems(new CCategory((int)tvwCategories.SelectedNode.Tag).Items);
            }
        }

        private void btnShowCats_Click(object sender, EventArgs e)
        {
            if (this.Width > 498)
            {
                tvwCategories.Visible = false;
                this.Width = 498;
            }
            else
            {
                tvwCategories.Visible = true;
                this.Width = 723;
            }
        }

        private void lvwSelectedItems_Validated(object sender, EventArgs e)
        {
        }

    }
}

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
    public partial class frmCase : Form
    {
        CCase currentCase;

        public frmCase()
        {
            InitializeComponent();
            PopulateInvoke();

            currentCase = null;
            tsbSave.Text = "Save";
            llbCategory.Text = new CCategory(1).Category;
            llbCategory.Tag = 1;
            this.Text = "New Case";

        }

        public frmCase(CCase Case)
        {
            InitializeComponent();
            PopulateInvoke();

            currentCase = Case;
            tsbSave.Text = "Save and Close";
            tsdAdd.Enabled = true;

            this.Text = "Case - " + currentCase.CaseName;
            txtID.Text = currentCase.ID.ToString();
            llbCategory.Text = currentCase.Category.Category;
            llbCategory.Tag = currentCase.Category.ID;
            txtName.Text = currentCase.CaseName;
            chkActive.Checked = currentCase.Active;
            txtDesc.Text = currentCase.Description;
            if (currentCase.Invoke != null)
                cboInvoking.Text = currentCase.Invoke.Invokes;

            PopulateItems();
        }

        public void SetCategory(CCategory Category)
        {
            llbCategory.Text = Category.Category;
            llbCategory.Tag = Category.ID;
            Category.Dispose();
        }

        private void PopulateItems()
        {
            lvwItems.Items.Clear();
            ListViewItem lvi;
            DataTable i = new CItems().ItemsInCase(currentCase.ID);
            CItem item;
            foreach (DataRow row in i.Rows)
            {
                item = new CItem((int)row["ID"]);
                lvi = new ListViewItem(item.ID.ToString());
                lvi.SubItems.Add(item.Name);
                lvi.SubItems.Add(item.SerialNo);
                lvi.SubItems.Add(item.DefaultQuantity.ToString());
                lvi.Tag = item.ID;
                lvwItems.Items.Add(lvi);
            }
            i.Dispose();
        }

        private void PopulateInvoke()
        {
            ComboItem ci = new ComboItem("none", 0);
            cboInvoking.Items.Add(ci);
            DataTable iv = new CInvokes().AllInvokes;
            foreach (DataRow row in iv.Rows)
            {
                ci = new ComboItem(row[1].ToString(), (int)row[0]);
                cboInvoking.Items.Add(ci);
            }
            cboInvoking.SelectedIndex = 0;
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (currentCase == null)
                currentCase = new CCases().NewCase(txtName.Text);
            else
                currentCase.CaseName = txtName.Text;
            currentCase.Description = txtDesc.Text;
            currentCase.Active = chkActive.Checked;
            ComboItem ci = (ComboItem)cboInvoking.SelectedItem;
            if (ci.ID > 0)
                currentCase.Invoke = new CInvoke(ci.ID);
            else
                currentCase.Invoke = null;
            currentCase.Category = new CCategory((int)llbCategory.Tag);
            currentCase.Update();

            if (tsbSave.Text == "Save")
            {
                tsbSave.Text = "Save and Close";
                tsdAdd.Enabled = true;
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            tsbSave.Enabled = txtName.Text.Length > 0;
        }

        private void lvwItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwItems.SelectedItems.Count > 0)
            {
                tsbRemove.Enabled = true;
                tsl.Enabled = true;
                tstQtty.Enabled = true;
                tstQtty.Text = lvwItems.SelectedItems[0].SubItems[3].Text;
            }
            else
            {
                tsbRemove.Enabled = false;
                tsl.Enabled = false;
                tstQtty.Enabled = false;
                tstQtty.Text = "0";
            }
        }

        private void tstQtty_Validating(object sender, CancelEventArgs e)
        {
            if (Program.IsInteger(tstQtty.Text) == false)
            {
                MessageBox.Show("Please input a valid number", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }
            else
            {
                int val = int.Parse(tstQtty.Text);
                if (val < 1)
                {
                    MessageBox.Show("Please input a value greater than 0", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }
                else
                {
                    int id = (int)lvwItems.SelectedItems[0].Tag;
                    CItem item = new CItem(id);
                    item.DefaultQuantity = val;
                    item.Update();
                    PopulateItems();
                }
            }
        }

        private void tsbRemove_Click(object sender, EventArgs e)
        {
            int idx = lvwItems.SelectedItems[0].Index;
            int id = (int)lvwItems.SelectedItems[0].Tag;
            CItem item = new CItem(id);
            item.DefaultCase = null;
            item.Update();
            PopulateItems();
            try
            {
                lvwItems.Items[idx].Selected = true;
            }
            catch { }
        }

        private void lvwItems_DoubleClick(object sender, EventArgs e)
        {
            if (lvwItems.SelectedItems.Count > 0)
            {
                int id = (int)lvwItems.SelectedItems[0].Tag;
                frmItem itmForm = new frmItem(new CItem(id),0);
                if (itmForm.ShowDialog(this) == DialogResult.OK)
                    PopulateItems();
            }
        }

        private void llbCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCatSelector cs;
            if (currentCase == null)
                cs = new frmCatSelector(new CCategory(1));
            else
                cs = new frmCatSelector(currentCase.Category);
            if (cs.ShowDialog(this) == DialogResult.OK)
            {
                llbCategory.Text = cs.SelectedCategory.Category;
                llbCategory.Tag = cs.SelectedCategory.ID;
                cs.Close();
            }
        }

        private void tsmNewItem_Click(object sender, EventArgs e)
        {
            frmItem fi = new frmItem();
            fi.SetCase(currentCase);
            fi.SetCategory(currentCase.Category);
            if (fi.ShowDialog(this) == DialogResult.OK)
                PopulateItems();
        }

        private void tsmExistItem_Click(object sender, EventArgs e)
        {
            frmFindItem ffi = new frmFindItem();
            if (ffi.ShowDialog(this) == DialogResult.OK)
            {
                if (ffi.GetSelectedItems() != null)
                {
                    foreach (CItem item in ffi.GetSelectedItems())
                    {
                        currentCase.AddItem(item);
                    }
                }
                PopulateItems();
                ffi.Close();
            }
        }

        private void frmCase_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                currentCase.Dispose();
            }
            catch { };
        }
    }
}

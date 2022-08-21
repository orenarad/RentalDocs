using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EquipmentCheckOut
{
    public partial class frmOptions : Form
    {
        public frmOptions()
        {
            InitializeComponent();
            RefreshCategories(new CCategory(1));
        }

        private void RefreshCategories(CCategory SelectedCategory)
        {
            tvwCategories.BeginUpdate();
            tvwCategories.Nodes.Clear();
            CategoryTreeView ctv = new CategoryTreeView(tvwCategories);
            ctv.Dispose();
            tvwCategories.ExpandAll();
            if (SelectedCategory != null) tvwCategories.SelectedNode = GetNodeByCategory(tvwCategories.Nodes, SelectedCategory);
            tvwCategories.EndUpdate();
        }

        private TreeNode GetNodeByCategory(TreeNodeCollection Nodes, CCategory Category)
        {
            CCategory c;
            TreeNode res = null;
            foreach (TreeNode tn in Nodes)
            {
                c = new CCategory((int)tn.Tag);
                if (c.ID == Category.ID)
                {
                    res = tn;
                    break;
                }
                res = GetNodeByCategory(tn.Nodes, Category);
            }
            return res;
        }
        
        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tvwCategories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvwCategories.SelectedNode != null)
            {
                int id = (int)tvwCategories.SelectedNode.Tag;
                CCategory cat = new CCategory(id);
                txtCatID.Text = cat.ID.ToString();
                txtCatName.Text = cat.Category;
                if (cat.Parent != null)
                {
                    llbParent.Text = cat.Parent.Category;
                    llbParent.Tag = cat.Parent.ID;
                }
                else
                {
                    llbParent.Text = "(none)";
                    llbParent.Tag = 0;
                }
            }
        }

        private void txtCatName_TextChanged(object sender, EventArgs e)
        {
            btnSaveCat.Enabled = (txtCatName.Text.Length > 0);
        }

        private void btnNewChild_Click(object sender, EventArgs e)
        {
            frmCategory fc = new frmCategory();
            fc.SetParent(new CCategory(int.Parse(txtCatID.Text)));
            if (fc.ShowDialog(this) == DialogResult.OK)
            {
                RefreshCategories(fc.GetCategory);
                fc.Close();
                fc.Dispose();
            }
        }

        private void btnNewSibling_Click(object sender, EventArgs e)
        {
            frmCategory fc = new frmCategory();
            fc.SetParent(new CCategory(int.Parse(txtCatID.Text)).Parent);
            if (fc.ShowDialog(this) == DialogResult.OK)
            {
                RefreshCategories(fc.GetCategory);
                fc.Close();
                fc.Dispose();
            }
        }

        private void btnSaveCat_Click(object sender, EventArgs e)
        {
            CCategory cat = new CCategory(int.Parse(txtCatID.Text));
            cat.Category = txtCatName.Text;
            cat.Update();
            RefreshCategories(cat);
            cat.Dispose();

        }

        private void btnDeleteCat_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("((( function not active )))",
                "Confirm Delete",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //if (MessageBox.Show("Deleting this category will move all the Items and Cases under it to the root Category. Proceed?",
            //    "Confirm Delete",
            //    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                //CCategory cat = new CCategory(int.Parse(txtCatID.Text));
                //DataTable items = new CItems().ItemsByCategory(int.Parse(txtCatID.Text));
                //CCases cases = new CCases(cat);
                //items.SetCategory(new CCategory(1));
                //items.Dispose();
                //cases.SetCategory(new CCategory(1));
                //cases.Dispose();

                //SqlCommand cmd = new SqlCommand("DELETE FROM Category WHERE ID = " + cat.ID.ToString());
                //CRecord rec = new CRecord(cmd);
                //cat.Dispose();
            }
        }
    }
}

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
    public partial class frmCategory : Form
    {
        CCategory currentCategory;

        public frmCategory()
        {
            InitializeComponent();

            currentCategory = null;
            this.Text = "New Category";
            CCategory c = new CCategory(1);
            llbParent.Text = c.Category;
            llbParent.Tag = 1;
            c.Dispose();
        }

        public void SetParent(CCategory Parent)
        {
            llbParent.Text = Parent.Category;
            llbParent.Tag = Parent.ID;
            Parent.Dispose();
        }

        public frmCategory(CCategory Category)
        {
            InitializeComponent();

            currentCategory = Category;
            Category.Dispose();
            this.Text = "Category - " + currentCategory.Category;
            txtID.Text = currentCategory.ID.ToString();
            txtCategory.Text = currentCategory.Category;
            llbParent.Text = currentCategory.Parent.Category;
            llbParent.Tag = currentCategory.Parent.ID;
        }

        private void txtCategory_TextChanged(object sender, EventArgs e)
        {
            tsbSave.Enabled = txtCategory.Text.Length > 0;
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (currentCategory == null)
                currentCategory = new CCategories().NewCategory(txtCategory.Text);
            else
                currentCategory.Category = txtCategory.Text;
            currentCategory.Parent = new CCategory((int)llbParent.Tag);
            currentCategory.Update();
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void frmCategory_FormClosed(object sender, FormClosedEventArgs e)
        {
            try { currentCategory.Dispose(); }
            catch { }
        }

        public CCategory GetCategory
        {
            get
            {
                return currentCategory;
            }
        }
    }
}

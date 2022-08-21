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
    public partial class frmCatSelector : Form
    {
        public frmCatSelector(CCategory Category)
        {
            InitializeComponent();
            CategoryTreeView ctv = new CategoryTreeView(tvwCategories);
            ctv.Dispose();
            tvwCategories.ExpandAll();
            foreach (TreeNode tn in tvwCategories.Nodes)
            {
                if (Category.ID == (int)tn.Tag)
                {
                    tvwCategories.SelectedNode = tn;
                    break;
                }
            }
            Category.Dispose();
        }

        public CCategory SelectedCategory
        {
            get
            {
                int id = (int)tvwCategories.SelectedNode.Tag;
                return new CCategory(id);
            }
        }

        private void tvwCategories_DoubleClick(object sender, EventArgs e)
        {
            if (tvwCategories.SelectedNode != null)
            {
                this.DialogResult = DialogResult.OK;
                this.Hide();
            }
        }
    }
}

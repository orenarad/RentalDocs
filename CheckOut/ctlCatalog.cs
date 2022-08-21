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
    public partial class ctlCatalog : ctlUIPanel
    {
        public ctlCatalog()
        {
            InitializeComponent();
            FolderID = 1;

            // populate departments
            using (DataTable deps = new CCatalogDepatments().AllCatalogDepatments)
            {
                ComboItem ci = new ComboItem("הכל", 0);
                cboDep.Items.Add(ci);
                foreach (DataRow row in deps.Rows)
                {
                    ComboItem dep = new ComboItem(row["Department_HE"].ToString(), (int)row["ID"]);
                    cboDep.Items.Add(dep);
                }
                ci = new ComboItem("פריטים לא פעילים", -1);
                cboDep.Items.Add(ci);
                cboDep.SelectedIndex = 0;
            }

            PopulateCatalog();
        }

        private void ctlCatalog_Resize(object sender, EventArgs e)
        {
            lvwCatalog.Columns[2].Width = 90;
            lvwCatalog.Columns[1].Width = 90;
            lvwCatalog.Columns[0].Width = lvwCatalog.ClientRectangle.Width - 180;
        }

        private DataTable GetCatalogData()
        {
            DataTable ret;
            ComboItem selCat = (ComboItem)cboCategory.SelectedItem;
            ComboItem selDep = (ComboItem)cboDep.SelectedItem;

            if (selCat.ID > 0)
            {
                if (txtSearch.Text.Length > 1)
                {
                    //  search by text and category
                    int[] categories = new int[1] {selCat.ID};
                    using (DataTable catalog = new CCatalogProducts().SearchCatalogProducts(txtSearch.Text, categories))
                    {
                        ret = catalog.Copy();
                    }
                }
                else
                {
                    //  search by category
                    using (DataTable catalog = new CCatalogProducts().CatalogProductsByCategory(selCat.ID))
                    {
                        ret = catalog.Copy();
                    }
                }
            }
            else if (selDep.ID > 0)
            {
                if (txtSearch.Text.Length > 1)
                {
                    //  search by text and department
                    int[] categories;
                    using (CCatalogDepatment catDep = new CCatalogDepatment(selDep.ID))
                    {
                        categories = catDep.GetCategories();
                    }
                    using (DataTable catalog = new CCatalogProducts().SearchCatalogProducts(txtSearch.Text, categories))
                    {
                        ret = catalog.Copy();
                    }
                }
                else
                {
                    using (DataTable catalog = new CCatalogProducts().CatalogProductsByDepartment(selDep.ID))
                    {
                        ret = catalog.Copy();
                    }
                }
            }
            else if (selDep.ID < 0)
            {
                // show only inactive items

                // By search:
                if (txtSearch.Text.Length > 1)
                {
                    //  search by text
                    using (DataTable catalog = new CCatalogProducts().SearchCatalogProducts(txtSearch.Text, false))
                    {
                        ret = catalog.Copy();
                    }
                }
                else // all
                {
                    using (DataTable catalog = new CCatalogProducts().AllCatalogProducts(false))
                    {
                        ret = catalog.Copy();
                    }
                }
            }
            else if (txtSearch.Text.Length > 0)
            {
                //  search by text
                using (DataTable catalog = new CCatalogProducts().SearchCatalogProducts(txtSearch.Text))
                {
                    ret = catalog.Copy();
                }
            }
            else
            {
                //  return all
                using (DataTable catalog = new CCatalogProducts().AllCatalogProducts(true))
                {
                    ret = catalog.Copy();
                }
            }
            return ret;
        }

        private void cboDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            // populate categories
            cboCategory.Items.Clear();
            ComboItem ci = new ComboItem("הכל", 0);
            cboCategory.Items.Add(ci);
            // get depatment
            ci = (ComboItem)cboDep.SelectedItem;
            cboCategory.Enabled = (ci.ID > 0);
            if (ci.ID > 0)
            {
                using (DataTable cats = new CCatalogCategories().AllCatalogCategories(ci.ID))
                {
                    foreach (DataRow row in cats.Rows)
                    {
                        ComboItem cat = new ComboItem(row["Category_HE"].ToString(), (int)row["ID"]);
                        cboCategory.Items.Add(cat);
                    }
                }
            }

            cboCategory.SelectedIndex = 0;

            PopulateCatalog();
        }

        private void picGo_Click(object sender, EventArgs e)
        {
            PopulateCatalog();
        }

        private void PopulateCatalog()
        {
            lvwCatalog.BeginUpdate();
            Cursor = Cursors.WaitCursor;
            lvwCatalog.Items.Clear();
            using (DataTable catalog = GetCatalogData())
            {
                foreach (DataRow row in catalog.Rows)
                {
                    ListViewItem lvi = new ListViewItem(row["Product"].ToString());
                    if (row["Description"].ToString().Length > 0)
                        lvi.Text += " - " + row["Description"].ToString();
                    lvi.SubItems.Add(string.Format("{0:0.00} ₪", row["RentalPrice"]));
                    lvi.SubItems.Add(string.Format("{0:0.00} ₪", row["SalesPrice"]));
                    lvi.Tag = (int)row["ID"];
                    lvwCatalog.Items.Add(lvi);
                }
                lblSumm.Text = "נמצאו " + catalog.Rows.Count.ToString() + " פריטים";
            }
            ctlCatalog_Resize(this, new EventArgs());
            lvwCatalog.EndUpdate();
            Cursor = Cursors.Default;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                PopulateCatalog();
        }

        private void cboCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCategory.Focused == true)
                PopulateCatalog();
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

            ComboItem ci = (ComboItem)cboCategory.SelectedItem;
            using (frmCatalogProduct prodForm = new frmCatalogProduct((byte)ci.ID))
            {
                if (prodForm.ShowDialog(this) == DialogResult.OK)
                {
                    PopulateCatalog();
                }
            }
        }

        public override void EditItem()
        {
            if (lvwCatalog.SelectedItems.Count > 0)
            {
                int selID = (int)lvwCatalog.SelectedItems[0].Tag;
                using (frmCatalogProduct prodForm = new frmCatalogProduct(selID))
                {
                    prodForm.RecordLocked = !AllowEdit(FolderID);
                    if (prodForm.ShowDialog(this) == DialogResult.OK)
                    {
                        PopulateCatalog();
                    }
                }
            }
        }

        public override void Refresh()
        {
            PopulateCatalog();
        }

        private void lvwCatalog_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditItem();
        }
    }
}

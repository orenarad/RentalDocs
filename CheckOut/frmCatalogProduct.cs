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
    public partial class frmCatalogProduct : Form
    {
        bool needSave = false;

        CCatalogProduct currentProduct;

        public bool RecordLocked = false;

        public frmCatalogProduct(byte CategoryID)
        {
            // empty form preset with the current category selected in the cataloge UI
            InitializeComponent();
            PopulateDepartments();
            if (CategoryID == 0)
                CategoryID = 36;
            SetDepartmentAndCategory((int)CategoryID);
            needSave = false;
        }

        public frmCatalogProduct(int ProductID)
        {
            // construct the form with a product
            InitializeComponent();
            PopulateDepartments();

            currentProduct = new CCatalogProduct(ProductID);

            Text = currentProduct.ProductName;
            txtID.Text = currentProduct.ID.ToString();
            txtName.Text = currentProduct.ProductName;
            txtDescription.Text = currentProduct.ProductDescription;
            SetDepartmentAndCategory(currentProduct.CatalogCategoryID);
            txtRentalPrice.Text = string.Format("{0:0.00}", currentProduct.RentalPrice);
            txtSalesPrice.Text = string.Format("{0:0.00}", currentProduct.SalesPrice);
            chkActive.Checked = !currentProduct.Inactive;

            needSave = false;
        }

        private void SetDepartmentAndCategory(int CategoryID)
        {
            int i = 0;
            using (CCatalogCategory cat = new CCatalogCategory(CategoryID))
            {
                // select the correct department in the combo
                foreach (object obj in cboDep.Items)
                {
                    ComboItem depItem = (ComboItem)obj;
                    if (depItem.ID == cat.CatalogDepartmentID)
                    {
                        cboDep.SelectedIndex = i;
                        // not the category combo refreshes
                        break;
                    }
                    i++;
                }
            }
            i = 0;
            foreach (object obj in cboCat.Items)
            {
                ComboItem catItem = (ComboItem)obj;
                if (catItem.ID == CategoryID)
                {
                    cboCat.SelectedIndex = i;
                    break;
                }
                i++;
            }
        }

        private void PopulateDepartments()
        {
            // populate departments
            using (DataTable deps = new CCatalogDepatments().AllCatalogDepatments)
            {
                foreach (DataRow row in deps.Rows)
                {
                    ComboItem dep = new ComboItem(row["Department_HE"].ToString(), (int)row["ID"]);
                    cboDep.Items.Add(dep);
                }
                cboDep.SelectedIndex = 0;
            }
        }

        private void cboDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            // populate categories
            cboCat.Items.Clear();
            // get depatment
            ComboItem ci = (ComboItem)cboDep.SelectedItem;
            if (ci.ID > 0)
            {
                using (DataTable cats = new CCatalogCategories().AllCatalogCategories(ci.ID))
                {
                    foreach (DataRow row in cats.Rows)
                    {
                        ComboItem cat = new ComboItem(row["Category_HE"].ToString(), (int)row["ID"]);
                        cboCat.Items.Add(cat);
                    }
                }
            }
            cboCat.SelectedIndex = 0;
            needSave = true;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = (txtName.Text.Length > 0);
            needSave = true;
        }

        private void frmCatalogProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                currentProduct.Dispose();
            }
            catch { };
        }

        private void frmCatalogProduct_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (RecordLocked == true)
                return;

            if (needSave == true)
            {
                DialogResult dr = MessageBox.Show("האם לשמור את השינויים?", "שמירה",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
                switch (dr)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        // save and close
                        if (btnOK.Enabled == false)
                        {
                            MessageBox.Show(Properties.Settings.Default.MsgCantSaveEmpty,
                                        Properties.Settings.Default.MsgCantProceed,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                            txtName.Focus();
                        }
                        else
                        {
                            SaveProduct();
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        }
                        break;

                    case System.Windows.Forms.DialogResult.No:
                        // just close
                        break;

                    case System.Windows.Forms.DialogResult.Cancel:
                        // cancel closing the form
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void SaveProduct()
        {
            // save this product
            //=================================================================
            // Collect Data from combo boxes
            ComboItem cat = (ComboItem)cboCat.SelectedItem;

            // if we have a live product instance then update it, if we don't
            // then we have a new product we need to add to the catalog...

            if (currentProduct == null)
            {
                // create a new item in the catalog:
                currentProduct = new CCatalogProducts().NewCatalogProduct(cat.ID, txtName.Text, float.Parse(txtRentalPrice.Text), float.Parse(txtSalesPrice.Text));
                Text = currentProduct.ProductName;
                txtID.Text = currentProduct.ID.ToString();
            }
            else
            {
                currentProduct.ProductName = txtName.Text;
                currentProduct.CatalogCategoryID = cat.ID;
                currentProduct.RentalPrice = float.Parse(txtRentalPrice.Text);
                currentProduct.SalesPrice = float.Parse(txtSalesPrice.Text);
            }
            currentProduct.ProductDescription = txtDescription.Text + "";
            currentProduct.Inactive = !chkActive.Checked;

            currentProduct.Update();

            needSave = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveProduct();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            needSave = true;
        }

        private void cboCat_SelectedIndexChanged(object sender, EventArgs e)
        {
            needSave = true;
        }

        private void txtRentalPrice_Validating(object sender, CancelEventArgs e)
        {
            if (Program.IsNumeric(txtRentalPrice.Text) == true)
            {
                float price = float.Parse(txtRentalPrice.Text);
                txtRentalPrice.Text = string.Format("{0:0.00}", price);
            }
            else
            {
                if (txtRentalPrice.Text.Length == 0)
                    txtRentalPrice.Text = "0.00";
                else
                { 
                    MessageBox.Show("חייב ערך מספרי", "טעות", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
            }
        }

        private void txtSalesPrice_Validating(object sender, CancelEventArgs e)
        {
            if (Program.IsNumeric(txtSalesPrice.Text) == true)
            {
                float price = float.Parse(txtSalesPrice.Text);
                txtSalesPrice.Text = string.Format("{0:0.00}", price);
            }
            else
                if (txtSalesPrice.Text.Length == 0)
                    txtSalesPrice.Text = "0.00";
                else
                {
                    MessageBox.Show("חייב ערך מספרי", "טעות", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    e.Cancel = true;
                }
        }

        private void frmCatalogProduct_Load(object sender, EventArgs e)
        {
            if (RecordLocked == true)
            {
                Text += " (לקריאה בלבד)";
                btnOK.Visible = false;
            }
            
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (txtName.Text.Length == 0)
            {
                MessageBox.Show(Properties.Settings.Default.MsgCantSaveEmpty,
                            Properties.Settings.Default.MsgCantProceed,
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                e.Cancel = true;
            }
        }
    }
}

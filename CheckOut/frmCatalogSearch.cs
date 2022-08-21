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
    public partial class frmCatalogSearch : Form
    {
        private int resultItemID = 0;
        private string resultProduct = "";

        public frmCatalogSearch(string SearchString)
        {
            InitializeComponent();
            txtSearch.Text = SearchString;
            SearchCatalog(SearchString);
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                SearchCatalog(txtSearch.Text);
        }

        public int ResultItemID
        {
            get
            {
                return resultItemID;
            }
        }

        public string ResultProduct
        {
            get
            {
                return resultProduct;
            }
        }

        private void SearchCatalog(string SearchString)
        {
            lbxResults.Items.Clear();
            using (DataTable catalogSearch = new CCatalogProducts().SearchCatalogProducts(SearchString))
            {
                foreach (DataRow row in catalogSearch.Rows)
                {
                    PimpedListBoxItem pitem = new PimpedListBoxItem();
                    pitem.DbID = (int)row["ID"];
                    pitem.Title = row["Product"].ToString();
                    pitem.SubTitle = row["Description"].ToString();
                    double rentalPrice;
                    double.TryParse(row["RentalPrice"].ToString(), out rentalPrice);
                    pitem.Data = rentalPrice.ToString("C");
                    lbxResults.Items.Add(pitem);
                }
            }
        }

        private void lbxResults_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxResults.SelectedItems.Count > 0)
            {
                PimpedListBoxItem plbi = (PimpedListBoxItem)lbxResults.SelectedItem;
                resultItemID = plbi.DbID;
                resultProduct = plbi.Title;

            }
        }

        private void lbxResults_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (resultItemID > 0)
                DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}

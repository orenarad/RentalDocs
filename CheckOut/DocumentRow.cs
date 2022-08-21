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
    public delegate void RowActionHandler(object sender, DocumentRowEventArgs e);

    public struct ItemsCatalog
    {
        public int ItemID;
        public string ItemName;
        public string ItemDescription;
        public double RentalPrice;
        public double SalesPrice;
    }

    public partial class DocumentRow : UserControl
    {
        ItemsCatalog[] catalogItems;
        private bool isEmptyRow = true; 
        private Color SALES_FORECOLOR = Color.Navy;
        private int quantityLimit = 0;

        private const string RELATED_DOC_TITLE_SHIP = "ממסמך";
        private const string RELATED_DOC_TITLE_RECEIVE = "ממסמך";
        private const string RELATED_DOC_TITLE_BILL = "ממסמך";

        public enum RowMode
        {
            Quotation,
            Shipment,
            Receive,
            Bill
        }
        private RowMode Mode = 0; 

        public event EventHandler RowAdded;
        public event EventHandler RowCalculated;
        public event EventHandler RowExitPoint;
        public event EventHandler DeletePressed;
        public event EventHandler RequestRelatedDocs;
        public event RowActionHandler DaysChanged;
        public event RowActionHandler DiscountChanged;
        public event EventHandler RowChanged;

        public int MyIndex = 0;
        public int DatabaseID = 0;

        public DocumentRow(RowMode SetMode)
        {
            int v = 0;
            InitializeComponent();
            txtPrice.Text = v.ToString("C");
            txtTotal.Text = v.ToString("C");
            txtDiscount.Text = v.ToString("P");
            v++;
            txtDays.Text = v.ToString();
            txtQtty.Text = v.ToString();

            HasHeader = false;

            #region SetMode
            // turn on/off relevant filed for this mode
            Mode = SetMode;
		    switch (SetMode)
                {
                    case RowMode.Quotation:
                        txtItem.Enabled = txtDescription.Enabled = btnSearch.Visible = true;
                        txtTotal.Visible = true;
                        lblTotal.Visible = true;
                        txtDiscount.Visible = true;
                        lblDiscount.Visible = true;
                        txtDays.Visible = true;
                        lblDays.Visible = true;
                        txtPrice.Visible = true;
                        lblPrice.Visible = true;
                        txtRelatedDocID.Visible = false;
                        lblRelatedDocID.Visible = false;
                        btnSearchDoc.Visible = false;
                        break;

                    case RowMode.Shipment:
                        txtItem.Enabled = txtDescription.Enabled = btnSearch.Enabled = true;
                        txtTotal.Visible = false;
                        lblTotal.Visible = false;
                        txtDiscount.Visible = true;
                        lblDiscount.Visible = true;
                        txtDays.Visible = false;
                        lblDays.Visible = false;
                        txtPrice.Visible = true;
                        lblPrice.Visible = true;
                        txtRelatedDocID.Visible = true;
                        lblRelatedDocID.Visible = true;
                        btnSearchDoc.Visible = true;
                        lblRelatedDocID.Text = RELATED_DOC_TITLE_SHIP;
                        break;

                    case RowMode.Receive:
                        txtItem.Enabled = txtDescription.Enabled = btnSearch.Enabled = false;
                        txtTotal.Visible = false;
                        lblTotal.Visible = false;
                        txtDiscount.Visible = false;
                        lblDiscount.Visible = false;
                        txtDays.Visible = true;
                        lblDays.Visible = true;
                        txtPrice.Visible = false;
                        lblPrice.Visible = false;
                        txtRelatedDocID.Visible = true;
                        lblRelatedDocID.Visible = true;
                        btnSearchDoc.Visible = true;
                        lblRelatedDocID.Text = RELATED_DOC_TITLE_RECEIVE;
                        break;

                    case RowMode.Bill:
                        txtItem.Enabled = txtDescription.Enabled = btnSearch.Enabled = true;
                        txtTotal.Visible = true;
                        lblTotal.Visible = true;
                        txtDiscount.Visible = true;
                        lblDiscount.Visible = true;
                        txtDays.Visible = true;
                        lblDays.Visible = true;
                        txtPrice.Visible = true;
                        lblPrice.Visible = true;
                        txtRelatedDocID.Visible = true;
                        lblRelatedDocID.Visible = true;
                        btnSearchDoc.Visible = true;
                        lblRelatedDocID.Text = RELATED_DOC_TITLE_BILL;
                        break;
                }

            // arrange position on fields
            int leftX = btnDel.Width + ((txtTotal.Width - 1) * Convert.ToByte(txtTotal.Visible));
            txtDiscount.Left = lblDiscount.Left = leftX;
            leftX += ((lblDiscount.Width - 1) * Convert.ToByte(lblDiscount.Visible));
            txtDays.Left = lblDays.Left = leftX;
            leftX += ((txtDays.Width - 1) * Convert.ToByte(txtDays.Visible));
            txtQtty.Left = lblQtty.Left = leftX;
            leftX += lblQtty.Width - 1;
            txtPrice.Left = lblPrice.Left = leftX;
            leftX += ((txtPrice.Width - 1) * Convert.ToByte(txtPrice.Visible));
            txtDescription.Left = lblDescription.Left = leftX;
            // measure from the right
            leftX = this.Width - (txtItem.Width - 1) - ((txtRelatedDocID.Width - 1) * Convert.ToByte(txtRelatedDocID.Visible)) - (txtItemID.Width - 1) - (btnSearch.Width - 1) -1;
            txtDescription.Width = lblDescription.Width = leftX - txtDescription.Left + 1;
            txtItem.Left = lblItem.Left = leftX;
            leftX += txtItem.Width - 1;
            txtRelatedDocID.Left = lblRelatedDocID.Left = leftX;
            btnSearchDoc.Left = leftX + 2;
            leftX += ((txtRelatedDocID.Width - 1) * Convert.ToByte(txtRelatedDocID.Visible));
            txtItemID.Left = lblItemID.Left = leftX;
            leftX += txtItemID.Width - 1;
            btnSearch.Left = leftX;
            #endregion            

        }

        // some external properties
        public bool IsEmpty
        {
            get { return isEmptyRow; }
        }

        public bool HasHeader
        {
            get { return this.Height > 23; }
            set { this.Height = 23 + (15 * Convert.ToByte(value)); }
        }

        public int ItemID
        {
            get { return int.Parse(txtItemID.Text); }
            set { txtItemID.Text = value.ToString(); }
        }

        public string ItemName
        {
            get { return txtItem.Text; }
            set { txtItem.Text = value; }
        }

        public string ItemDescription
        {
            get { return txtDescription.Text + ""; }
            set { txtDescription.Text = value; }
        }

        public int Quantity
        {
            get { return int.Parse(txtQtty.Text); }
            set { txtQtty.Text = value.ToString(); }
        }

        public int QuantityLimit
        {
            get { return quantityLimit; }
            set { quantityLimit = value; }
        }

        public int Days
        {
            get { return int.Parse(txtDays.Text); }
            set { txtDays.Text = value.ToString(); }
        }

        public int RelatedDocumentNumber
        {
            get
            {
                int ret = 0;
                if (txtRelatedDocID.Tag != null)
                    int.TryParse(txtRelatedDocID.Tag.ToString(), out ret);

                return ret;
            }
            //set { txtDays.Text = value.ToString(); }
        }

        public double Price
        {
            get
            {
                double pricelValue = 0;
                double.TryParse(txtPrice.Text,
                    System.Globalization.NumberStyles.Number |
                    System.Globalization.NumberStyles.AllowCurrencySymbol,
                    System.Globalization.CultureInfo.CreateSpecificCulture("he-IL"),
                    out pricelValue);
                return pricelValue;
            }
            set { txtPrice.Text = value.ToString("C"); }
        }

        public bool IsRental
        {
            get
            {
                if (txtPrice.ForeColor == SALES_FORECOLOR)
                    return false;
                else
                    return true;
            }
        }

        public double Discount
        {
            get 
            {
                double discount = 0;
                string strvalue = txtDiscount.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
                double.TryParse(strvalue, out discount);
                discount = discount / 100;
                return discount;
            }
            set { txtDiscount.Text = value.ToString("P"); }
        }

        public double TotalValue
        {
            get
            {
                double totalValue = 0;
                double.TryParse(txtTotal.Text,
                    System.Globalization.NumberStyles.Number |
                    System.Globalization.NumberStyles.AllowCurrencySymbol,
                    System.Globalization.CultureInfo.CreateSpecificCulture("he-IL"),
                    out totalValue);
                return totalValue;
            }
        }

        public void PassCatalog(ItemsCatalog[] Items)
        {
            catalogItems = Items;

            AutoCompleteStringCollection source = new AutoCompleteStringCollection();
            foreach (ItemsCatalog item in catalogItems)
            {
                source.Add(item.ItemName);
            }
            txtItem.AutoCompleteCustomSource = source;
        }

        private void txtItem_Validating(object sender, CancelEventArgs e)
        {
            if (txtItem.Text.Length == 0)
                return;

            int itemPos = txtItem.AutoCompleteCustomSource.IndexOf(txtItem.Text);
            if (itemPos > -1)
            {
                PopulateRow(itemPos);
            }
            else
            {
                if (txtItemID.Text.Length == 0)
                {
                    // this is not an item from the autocomplete list so bring up the search product dialog.
                    using (frmCatalogSearch csFrm = new frmCatalogSearch(txtItem.Text))
                    {
                        if (csFrm.ShowDialog(this) == DialogResult.OK)
                        {
                            itemPos = txtItem.AutoCompleteCustomSource.IndexOf(csFrm.ResultProduct);
                            PopulateRow(itemPos);
                        }
                        else
                        {
                            MessageBox.Show(Properties.Settings.Default.MsgNoItem, Properties.Settings.Default.MsgError, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                            return;
                        }
                    }

                }
            }
            CalculateRow();
        }

        private void PopulateRow(int ItemIndex)
        {
            if (ItemIndex < 0)
                return;

            if (txtItemID.Text.Length == 0)
                OnRowAdded();
            txtItemID.Text = catalogItems[ItemIndex].ItemID.ToString();
            txtItem.Text = catalogItems[ItemIndex].ItemName;
            txtDescription.Text = catalogItems[ItemIndex].ItemDescription;
            if (catalogItems[ItemIndex].SalesPrice > 0)
            {
                txtPrice.ForeColor = SALES_FORECOLOR;
                txtPrice.Text = catalogItems[ItemIndex].SalesPrice.ToString("C");
            }
            else
            {
                txtPrice.ForeColor = SystemColors.WindowText;
                txtPrice.Text = catalogItems[ItemIndex].RentalPrice.ToString("C");
            }
            //txtDescription.Enabled = true;
            txtPrice.Enabled = true;
            txtQtty.Enabled = true;
            txtDays.Enabled = true;
            txtDiscount.Enabled = true;
            txtTotal.Enabled = true;
            btnDel.Enabled = true;
            txtQtty.Focus();
            isEmptyRow = false;
        }

        public void LoadRow(CDocumentRow LoadedRow, int LimitQuantity)
        {
            LoadRow(LoadedRow);
            quantityLimit = LimitQuantity;
        }

        public void LoadRow(CDocumentRow LoadedRow)
        {
            if (txtItemID.Text.Length == 0)
                OnRowAdded();
            if (LoadedRow.RelatedRowIdDocumentNo > 0)
            {
                txtRelatedDocID.Text = LoadedRow.RelatedRowIdDocumentNo.ToString();
                txtRelatedDocID.Tag = LoadedRow.DBId;
            }
            txtItemID.Text = LoadedRow.ProductID.ToString();
            txtItem.Text = LoadedRow.ProductName;
            txtDescription.Text = LoadedRow.ProductDescription; ;
            if (LoadedRow.SalesPrice > 0)
            {
                txtPrice.ForeColor = SALES_FORECOLOR;
                txtPrice.Text = LoadedRow.SalesPrice.ToString("C");
            }
            else
            {
                txtPrice.ForeColor = SystemColors.WindowText;
                txtPrice.Text = LoadedRow.RentalPrice.ToString("C");
            }
            txtQtty.Text = LoadedRow.Quantity.ToString();
            quantityLimit = LoadedRow.QuantityLimit;
            txtDays.Text = LoadedRow.Days.ToString();
            txtDiscount.Text = LoadedRow.Discount.ToString("P");

            //txtDescription.Enabled = true;
            txtPrice.Enabled = true;
            txtQtty.Enabled = true;
            txtDays.Enabled = true;
            txtDiscount.Enabled = true;
            txtTotal.Enabled = true;
            btnDel.Enabled = true;
            txtQtty.Focus();
            isEmptyRow = false;

            //if (txtRelatedDocID.Tag != null)
            //    txtDescription.Text = "### " + txtRelatedDocID.Tag.ToString() + " ###";

            CalculateRow();
        }

        private void txtQtty_Validating(object sender, CancelEventArgs e)
        {
            int value = 0;
            TextBox tx = (TextBox)sender;
            if (int.TryParse(tx.Text.ToString(), out value) == true)
            {
                if (value < 1)
                {
                    MessageBox.Show(Properties.Settings.Default.MsgValueHigherThanZero, Properties.Settings.Default.MsgError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    e.Cancel = true;
                }
                if (quantityLimit > 0)
                {
                    if (value > quantityLimit)
                    {
                        MessageBox.Show("רק " + quantityLimit.ToString() + " ניתנים לזיכוי", Properties.Settings.Default.MsgError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txtQtty.Text = quantityLimit.ToString();
                        e.Cancel = true;
                    }
                }
            }
            else
            {
                MessageBox.Show(Properties.Settings.Default.MsgMustBeNum, Properties.Settings.Default.MsgError, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void txtPrice_Validating(object sender, CancelEventArgs e)
        {
            float value = 0;
            TextBox tx = (TextBox)sender;
            if (float.TryParse(tx.Text,
                System.Globalization.NumberStyles.Number | 
                System.Globalization.NumberStyles.AllowCurrencySymbol,
                System.Globalization.CultureInfo.CreateSpecificCulture("he-IL"), 
                out value) == true)
            {
                //if (value <= 0)
                //{
                //    MessageBox.Show("חייב ערך גבוה מ-0", "טעות", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    e.Cancel = true;
                //}
            }
            else
            {
                MessageBox.Show("חייב ערך מספרי", "טעות", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void txtDiscount_Validating(object sender, CancelEventArgs e)
        {
            float value = 0;
            string strvalue = txtDiscount.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
            if (float.TryParse(strvalue, out value) == true)
            {
                //if (value <= 0)
                //{
                //    MessageBox.Show("חייב ערך גבוה מ-0", "טעות", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    e.Cancel = true;
                //}
            }
            else
            {
                MessageBox.Show("חייב ערך מספרי", "טעות", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void txtPrice_Validated(object sender, EventArgs e)
        {
            double value = 0;
            double.TryParse(txtPrice.Text,
                System.Globalization.NumberStyles.Number |
                System.Globalization.NumberStyles.AllowCurrencySymbol,
                System.Globalization.CultureInfo.CreateSpecificCulture("he-IL"),
                out value);
            txtPrice.Text = value.ToString("C");
            CalculateRow();
        }

        private void txtDiscount_Validated(object sender, EventArgs e)
        {
            //if (txtDiscount.Focused != true)
            //    return;
            double value = 0;
            string strvalue = txtDiscount.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
            double.TryParse(strvalue, out value);
            value = value / 100;
            txtDiscount.Text = value.ToString("P");
            CalculateRow();
        }

        public void CalculateRow()
        {
            double discountValue = 0;
            string strvalue = txtDiscount.Text.Replace(System.Globalization.CultureInfo.CurrentCulture.NumberFormat.PercentSymbol, "");
            double.TryParse(strvalue, out discountValue);
            double discount = discountValue / 100;
            discount = 1 - discount;

            double priceValue = 0;
            double.TryParse(txtPrice.Text,
                System.Globalization.NumberStyles.Number |
                System.Globalization.NumberStyles.AllowCurrencySymbol,
                System.Globalization.CultureInfo.CreateSpecificCulture("he-IL"),
                out priceValue);
            double totalPrice = priceValue;

            totalPrice = totalPrice * Convert.ToInt16((object)txtDays.Text) * Convert.ToInt16((object)txtQtty.Text);
            totalPrice = totalPrice * discount;
            txtTotal.Text = totalPrice.ToString("C");

            OnRowCalculated();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            using (frmCatalogSearch csFrm = new frmCatalogSearch(""))
            {
                if (csFrm.ShowDialog(this) == DialogResult.OK)
                {
                    int itemPos = txtItem.AutoCompleteCustomSource.IndexOf(csFrm.ResultProduct);
                    PopulateRow(itemPos);
                    txtRelatedDocID.Text = "";
                    txtRelatedDocID.Tag = null;
                    CalculateRow();
                }
            }
        }

        protected virtual void OnRowAdded()
        {
            if (RowAdded != null)
                RowAdded(this, new EventArgs());
        }

        protected virtual void OnRowCalculated()
        {
            if (RowCalculated != null)
                RowCalculated(this, new EventArgs());
        }

        protected virtual void OnRowExitPoint()
        {
            if (RowExitPoint != null)
                RowExitPoint(this, new EventArgs());
        }

        protected virtual void OnDeletePressed()
        {
            if (DeletePressed != null)
                DeletePressed(this, new EventArgs());
        }

        protected virtual void OnRequestRelatedDocs()
        {
            if (RequestRelatedDocs != null)
                RequestRelatedDocs(this, new EventArgs());
        }

        protected virtual void OnDaysChanged(DocumentRowEventArgs.Action ActTaken)
        {
            if (DaysChanged != null)
                DaysChanged(this, new DocumentRowEventArgs(ActTaken));
        }

        protected virtual void OnDiscountChanged(DocumentRowEventArgs.Action ActTaken)
        {
            if (DiscountChanged != null)
                DiscountChanged(this, new DocumentRowEventArgs(ActTaken));
        }

        protected virtual void OnRowChanged()
        {
            if (RowChanged != null)
                RowChanged(this, new EventArgs());
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            OnDeletePressed();
        }

        private void txtItem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                txtItem_Validating(txtItem, new CancelEventArgs());
        }

        private void txtDays_KeyDown(object sender, KeyEventArgs e)
        {
            CancelEventArgs cancel = new CancelEventArgs();
            if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Down)
            {
                // Ctrl + Down pressed - copy value to lower rows
                if (sender == txtDays)
                {
                    txtPrice_Validating(sender, cancel);
                    if (cancel.Cancel == false)
                        OnDaysChanged(DocumentRowEventArgs.Action.Down);
                }
                else if (sender == txtDiscount)
                {
                    txtDiscount_Validating(sender, cancel);
                    if (cancel.Cancel == false)
                        OnDiscountChanged(DocumentRowEventArgs.Action.Down);
                }
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.Up)
            {
                // Ctrl + Up pressed - copy value to upper rows
                if (sender == txtDays)
                {
                    txtPrice_Validating(sender, cancel);
                    if (cancel.Cancel == false)
                        OnDaysChanged(DocumentRowEventArgs.Action.Up);
                }
                else if (sender == txtDiscount)
                {
                    txtDiscount_Validating(sender, cancel);
                    if (cancel.Cancel == false)
                        OnDiscountChanged(DocumentRowEventArgs.Action.Up);
                }
            }
            else if (e.Modifiers == Keys.Control && e.KeyCode == Keys.A)
            {
                // Ctrl + A pressed - copy value to all rows
                if (sender == txtDays)
                {
                    txtPrice_Validating(sender, cancel);
                    if (cancel.Cancel == false)
                        OnDaysChanged(DocumentRowEventArgs.Action.All);
                }
                else if (sender == txtDiscount)
                {
                    txtDiscount_Validating(sender, cancel);
                    if (cancel.Cancel == false)
                        OnDiscountChanged(DocumentRowEventArgs.Action.All);
                }
            }
        }

        private void btnSearchDoc_Click(object sender, EventArgs e)
        {
            OnRequestRelatedDocs();
        }

        private void txtItem_TextChanged(object sender, EventArgs e)
        {
            OnRowChanged();
        }

        private void DocumentRow_Enter(object sender, EventArgs e)
        {
            txtItemID.BackColor = Color.Gold;
            txtRelatedDocID.BackColor = Color.Gold;
            txtItem.BackColor = Color.Gold;
            txtDescription.BackColor = Color.Gold;
            txtPrice.BackColor = Color.Gold;
            txtQtty.BackColor = Color.Gold;
            txtDays.BackColor = Color.Gold;
            txtDiscount.BackColor = Color.Gold;
            txtTotal.BackColor = Color.Gold;
            txtItem.Select(0, 0);
        }

        private void DocumentRow_Leave(object sender, EventArgs e)
        {
            txtItemID.BackColor = SystemColors.Control;
            txtRelatedDocID.BackColor = SystemColors.Control;
            txtItem.BackColor = SystemColors.Window;
            txtDescription.BackColor = SystemColors.Window;
            txtPrice.BackColor = SystemColors.Window;
            txtQtty.BackColor = SystemColors.Window;
            txtDays.BackColor = SystemColors.Window;
            txtDiscount.BackColor = SystemColors.Window;
            txtTotal.BackColor = SystemColors.Control;
        }
    }

    public class DocumentRowEventArgs : EventArgs
    {
        public enum Action { Up, Down, All }

        private Action cationTaken;

        public DocumentRowEventArgs(Action ActionTaken)
        {
            cationTaken = ActionTaken;
        }

        public Action ActionTaken
        {
            get
            {
                return cationTaken;
            }
        }
    }
}

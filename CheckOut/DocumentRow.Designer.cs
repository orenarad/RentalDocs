namespace EquipmentCheckOut
{
    partial class DocumentRow
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DocumentRow));
            this.btnSearch = new System.Windows.Forms.Button();
            this.txtItemID = new System.Windows.Forms.TextBox();
            this.txtItem = new System.Windows.Forms.TextBox();
            this.txtPrice = new System.Windows.Forms.TextBox();
            this.txtQtty = new System.Windows.Forms.TextBox();
            this.txtDays = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.btnDel = new System.Windows.Forms.Button();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblItemID = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblQtty = new System.Windows.Forms.Label();
            this.lblDays = new System.Windows.Forms.Label();
            this.lblDiscount = new System.Windows.Forms.Label();
            this.lblTotal = new System.Windows.Forms.Label();
            this.txtRelatedDocID = new System.Windows.Forms.TextBox();
            this.lblRelatedDocID = new System.Windows.Forms.Label();
            this.btnSearchDoc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Location = new System.Drawing.Point(737, 15);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSearch.Size = new System.Drawing.Size(26, 23);
            this.btnSearch.TabIndex = 0;
            this.btnSearch.TabStop = false;
            this.btnSearch.Text = "...";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // txtItemID
            // 
            this.txtItemID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItemID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItemID.Enabled = false;
            this.txtItemID.Location = new System.Drawing.Point(708, 15);
            this.txtItemID.Margin = new System.Windows.Forms.Padding(0);
            this.txtItemID.Name = "txtItemID";
            this.txtItemID.ReadOnly = true;
            this.txtItemID.Size = new System.Drawing.Size(30, 23);
            this.txtItemID.TabIndex = 1;
            this.txtItemID.TabStop = false;
            this.txtItemID.TextChanged += new System.EventHandler(this.txtItem_TextChanged);
            // 
            // txtItem
            // 
            this.txtItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtItem.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtItem.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtItem.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtItem.Location = new System.Drawing.Point(463, 15);
            this.txtItem.Margin = new System.Windows.Forms.Padding(0);
            this.txtItem.Name = "txtItem";
            this.txtItem.Size = new System.Drawing.Size(180, 23);
            this.txtItem.TabIndex = 5;
            this.txtItem.WordWrap = false;
            this.txtItem.TextChanged += new System.EventHandler(this.txtItem_TextChanged);
            this.txtItem.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtItem_KeyDown);
            this.txtItem.Validating += new System.ComponentModel.CancelEventHandler(this.txtItem_Validating);
            // 
            // txtPrice
            // 
            this.txtPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtPrice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPrice.Enabled = false;
            this.txtPrice.Location = new System.Drawing.Point(214, 15);
            this.txtPrice.Margin = new System.Windows.Forms.Padding(0);
            this.txtPrice.Name = "txtPrice";
            this.txtPrice.Size = new System.Drawing.Size(65, 23);
            this.txtPrice.TabIndex = 9;
            this.txtPrice.TextChanged += new System.EventHandler(this.txtItem_TextChanged);
            this.txtPrice.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrice_Validating);
            this.txtPrice.Validated += new System.EventHandler(this.txtPrice_Validated);
            // 
            // txtQtty
            // 
            this.txtQtty.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtQtty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtQtty.Enabled = false;
            this.txtQtty.Location = new System.Drawing.Point(175, 15);
            this.txtQtty.Margin = new System.Windows.Forms.Padding(0);
            this.txtQtty.Name = "txtQtty";
            this.txtQtty.Size = new System.Drawing.Size(40, 23);
            this.txtQtty.TabIndex = 11;
            this.txtQtty.Tag = "1";
            this.txtQtty.Text = "1";
            this.txtQtty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtQtty.TextChanged += new System.EventHandler(this.txtItem_TextChanged);
            this.txtQtty.Validating += new System.ComponentModel.CancelEventHandler(this.txtQtty_Validating);
            this.txtQtty.Validated += new System.EventHandler(this.txtPrice_Validated);
            // 
            // txtDays
            // 
            this.txtDays.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDays.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDays.Enabled = false;
            this.txtDays.Location = new System.Drawing.Point(136, 15);
            this.txtDays.Margin = new System.Windows.Forms.Padding(0);
            this.txtDays.Name = "txtDays";
            this.txtDays.Size = new System.Drawing.Size(40, 23);
            this.txtDays.TabIndex = 13;
            this.txtDays.Tag = "1";
            this.txtDays.Text = "1";
            this.txtDays.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDays.TextChanged += new System.EventHandler(this.txtItem_TextChanged);
            this.txtDays.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDays_KeyDown);
            this.txtDays.Validated += new System.EventHandler(this.txtPrice_Validated);
            // 
            // txtDiscount
            // 
            this.txtDiscount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtDiscount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDiscount.Enabled = false;
            this.txtDiscount.Location = new System.Drawing.Point(87, 15);
            this.txtDiscount.Margin = new System.Windows.Forms.Padding(0);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.Size = new System.Drawing.Size(50, 23);
            this.txtDiscount.TabIndex = 15;
            this.txtDiscount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDiscount.TextChanged += new System.EventHandler(this.txtItem_TextChanged);
            this.txtDiscount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtDays_KeyDown);
            this.txtDiscount.Validating += new System.ComponentModel.CancelEventHandler(this.txtDiscount_Validating);
            this.txtDiscount.Validated += new System.EventHandler(this.txtDiscount_Validated);
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTotal.Enabled = false;
            this.txtTotal.Location = new System.Drawing.Point(23, 15);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(0);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(65, 23);
            this.txtTotal.TabIndex = 17;
            this.txtTotal.TabStop = false;
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDel.Enabled = false;
            this.btnDel.Image = ((System.Drawing.Image)(resources.GetObject("btnDel.Image")));
            this.btnDel.Location = new System.Drawing.Point(0, 15);
            this.btnDel.Name = "btnDel";
            this.btnDel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnDel.Size = new System.Drawing.Size(23, 23);
            this.btnDel.TabIndex = 18;
            this.btnDel.TabStop = false;
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtDescription.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDescription.Enabled = false;
            this.txtDescription.Location = new System.Drawing.Point(278, 15);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(0);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(186, 23);
            this.txtDescription.TabIndex = 7;
            this.txtDescription.WordWrap = false;
            this.txtDescription.TextChanged += new System.EventHandler(this.txtItem_TextChanged);
            // 
            // lblItemID
            // 
            this.lblItemID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItemID.Location = new System.Drawing.Point(708, 0);
            this.lblItemID.Name = "lblItemID";
            this.lblItemID.Size = new System.Drawing.Size(30, 15);
            this.lblItemID.TabIndex = 0;
            this.lblItemID.Text = "מס\'";
            // 
            // lblItem
            // 
            this.lblItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblItem.Location = new System.Drawing.Point(463, 0);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(180, 15);
            this.lblItem.TabIndex = 4;
            this.lblItem.Text = "פריט";
            // 
            // lblDescription
            // 
            this.lblDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblDescription.Location = new System.Drawing.Point(278, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(186, 15);
            this.lblDescription.TabIndex = 6;
            this.lblDescription.Text = "תיאור";
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(214, 0);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(65, 15);
            this.lblPrice.TabIndex = 8;
            this.lblPrice.Text = "מחיר";
            // 
            // lblQtty
            // 
            this.lblQtty.Location = new System.Drawing.Point(175, 0);
            this.lblQtty.Name = "lblQtty";
            this.lblQtty.Size = new System.Drawing.Size(40, 15);
            this.lblQtty.TabIndex = 10;
            this.lblQtty.Text = "כמות";
            this.lblQtty.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDays
            // 
            this.lblDays.Location = new System.Drawing.Point(136, 0);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(40, 15);
            this.lblDays.TabIndex = 12;
            this.lblDays.Text = "ימים";
            this.lblDays.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblDiscount
            // 
            this.lblDiscount.Location = new System.Drawing.Point(87, 0);
            this.lblDiscount.Name = "lblDiscount";
            this.lblDiscount.Size = new System.Drawing.Size(50, 15);
            this.lblDiscount.TabIndex = 14;
            this.lblDiscount.Text = "הנחה";
            this.lblDiscount.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lblTotal
            // 
            this.lblTotal.Location = new System.Drawing.Point(23, 0);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(65, 15);
            this.lblTotal.TabIndex = 16;
            this.lblTotal.Text = "סה\"כ";
            // 
            // txtRelatedDocID
            // 
            this.txtRelatedDocID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRelatedDocID.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtRelatedDocID.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtRelatedDocID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRelatedDocID.Location = new System.Drawing.Point(642, 15);
            this.txtRelatedDocID.Margin = new System.Windows.Forms.Padding(0);
            this.txtRelatedDocID.Name = "txtRelatedDocID";
            this.txtRelatedDocID.ReadOnly = true;
            this.txtRelatedDocID.Size = new System.Drawing.Size(67, 23);
            this.txtRelatedDocID.TabIndex = 3;
            this.txtRelatedDocID.WordWrap = false;
            this.txtRelatedDocID.TextChanged += new System.EventHandler(this.txtItem_TextChanged);
            // 
            // lblRelatedDocID
            // 
            this.lblRelatedDocID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRelatedDocID.Location = new System.Drawing.Point(642, 0);
            this.lblRelatedDocID.Name = "lblRelatedDocID";
            this.lblRelatedDocID.Size = new System.Drawing.Size(67, 15);
            this.lblRelatedDocID.TabIndex = 2;
            this.lblRelatedDocID.Text = "מסמך בסיס";
            // 
            // btnSearchDoc
            // 
            this.btnSearchDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchDoc.Location = new System.Drawing.Point(644, 17);
            this.btnSearchDoc.Name = "btnSearchDoc";
            this.btnSearchDoc.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnSearchDoc.Size = new System.Drawing.Size(17, 19);
            this.btnSearchDoc.TabIndex = 19;
            this.btnSearchDoc.TabStop = false;
            this.btnSearchDoc.UseVisualStyleBackColor = true;
            this.btnSearchDoc.Click += new System.EventHandler(this.btnSearchDoc_Click);
            // 
            // DocumentRow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.btnSearchDoc);
            this.Controls.Add(this.txtRelatedDocID);
            this.Controls.Add(this.lblRelatedDocID);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.txtTotal);
            this.Controls.Add(this.txtDiscount);
            this.Controls.Add(this.txtDays);
            this.Controls.Add(this.txtQtty);
            this.Controls.Add(this.txtPrice);
            this.Controls.Add(this.txtItem);
            this.Controls.Add(this.txtItemID);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblTotal);
            this.Controls.Add(this.lblDiscount);
            this.Controls.Add(this.lblDays);
            this.Controls.Add(this.lblQtty);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.lblItem);
            this.Controls.Add(this.lblItemID);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MinimumSize = new System.Drawing.Size(580, 0);
            this.Name = "DocumentRow";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Size = new System.Drawing.Size(763, 38);
            this.Enter += new System.EventHandler(this.DocumentRow_Enter);
            this.Leave += new System.EventHandler(this.DocumentRow_Leave);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtItemID;
        private System.Windows.Forms.TextBox txtItem;
        private System.Windows.Forms.TextBox txtPrice;
        private System.Windows.Forms.TextBox txtQtty;
        private System.Windows.Forms.TextBox txtDays;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblItemID;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblQtty;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.Label lblDiscount;
        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.TextBox txtRelatedDocID;
        private System.Windows.Forms.Label lblRelatedDocID;
        private System.Windows.Forms.Button btnSearchDoc;
    }
}

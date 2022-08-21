namespace EquipmentCheckOut
{
    partial class ctlClients
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlClients));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lvwCatalog = new System.Windows.Forms.ListView();
            this.colItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colRental = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colBuy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.picGo = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSumm = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.picGo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(732, 23);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(88, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "חיפוש לקוחות:";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtSearch.Location = new System.Drawing.Point(617, 43);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearch.Size = new System.Drawing.Size(200, 29);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lvwCatalog
            // 
            this.lvwCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCatalog.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwCatalog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colItem,
            this.colRental,
            this.colBuy});
            this.lvwCatalog.FullRowSelect = true;
            this.lvwCatalog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwCatalog.Location = new System.Drawing.Point(0, 0);
            this.lvwCatalog.MultiSelect = false;
            this.lvwCatalog.Name = "lvwCatalog";
            this.lvwCatalog.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvwCatalog.RightToLeftLayout = true;
            this.lvwCatalog.Size = new System.Drawing.Size(604, 449);
            this.lvwCatalog.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwCatalog.TabIndex = 3;
            this.lvwCatalog.UseCompatibleStateImageBehavior = false;
            this.lvwCatalog.View = System.Windows.Forms.View.Details;
            this.lvwCatalog.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwCatalog_MouseDoubleClick);
            // 
            // colItem
            // 
            this.colItem.Text = "שם לקוח";
            this.colItem.Width = 131;
            // 
            // colRental
            // 
            this.colRental.Text = "פרטי לקוח";
            this.colRental.Width = 90;
            // 
            // colBuy
            // 
            this.colBuy.Text = "מס\' חשבשבת";
            this.colBuy.Width = 79;
            // 
            // picGo
            // 
            this.picGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picGo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picGo.Image = ((System.Drawing.Image)(resources.GetObject("picGo.Image")));
            this.picGo.Location = new System.Drawing.Point(617, 299);
            this.picGo.Name = "picGo";
            this.picGo.Size = new System.Drawing.Size(26, 26);
            this.picGo.TabIndex = 4;
            this.picGo.TabStop = false;
            this.picGo.Click += new System.EventHandler(this.picGo_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(771, 140);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "סנן לפי:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(699, 191);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(121, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "לקוחות פעילים בלבד";
            // 
            // lblSumm
            // 
            this.lblSumm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumm.AutoSize = true;
            this.lblSumm.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblSumm.Location = new System.Drawing.Point(617, 337);
            this.lblSumm.Name = "lblSumm";
            this.lblSumm.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSumm.Size = new System.Drawing.Size(123, 17);
            this.lblSumm.TabIndex = 10;
            this.lblSumm.Text = "נמצאו 00100 פריטים";
            this.lblSumm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // chkActive
            // 
            this.chkActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(617, 193);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(15, 14);
            this.chkActive.TabIndex = 11;
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // ctlClients
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.lblSumm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picGo);
            this.Controls.Add(this.lvwCatalog);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "ctlClients";
            this.Size = new System.Drawing.Size(831, 449);
            this.Resize += new System.EventHandler(this.ctlClients_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picGo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListView lvwCatalog;
        private System.Windows.Forms.PictureBox picGo;
        private System.Windows.Forms.ColumnHeader colItem;
        private System.Windows.Forms.ColumnHeader colRental;
        private System.Windows.Forms.ColumnHeader colBuy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSumm;
        private System.Windows.Forms.CheckBox chkActive;
    }
}

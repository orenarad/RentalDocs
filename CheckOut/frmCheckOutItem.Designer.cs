namespace EquipmentCheckOut
{
    partial class frmCheckOutItem
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.dtpEnterSer = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.llbCategory = new System.Windows.Forms.LinkLabel();
            this.label11 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cboDefCase = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIncluding = new System.Windows.Forms.TextBox();
            this.txtSerNo = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.lvwMoves = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsMoves = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openMovementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orenJobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnTab2 = new System.Windows.Forms.Button();
            this.btnTab1 = new System.Windows.Forms.Button();
            this.panDetails = new System.Windows.Forms.Panel();
            this.btnClearCatalogItem = new System.Windows.Forms.Button();
            this.btnSearchCatalog = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCatalogItem = new System.Windows.Forms.TextBox();
            this.panMoves = new System.Windows.Forms.Panel();
            this.lblRecords = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnDuplicate = new System.Windows.Forms.Button();
            this.cmsMoves.SuspendLayout();
            this.panDetails.SuspendLayout();
            this.panMoves.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpEnterSer
            // 
            this.dtpEnterSer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpEnterSer.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnterSer.Location = new System.Drawing.Point(279, 251);
            this.dtpEnterSer.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpEnterSer.Name = "dtpEnterSer";
            this.dtpEnterSer.RightToLeftLayout = true;
            this.dtpEnterSer.Size = new System.Drawing.Size(115, 23);
            this.dtpEnterSer.TabIndex = 6;
            this.dtpEnterSer.ValueChanged += new System.EventHandler(this.dtpEnterSer_ValueChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.Location = new System.Drawing.Point(400, 257);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 16);
            this.label12.TabIndex = 41;
            this.label12.Text = "כניסה לשירות";
            // 
            // llbCategory
            // 
            this.llbCategory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.llbCategory.Location = new System.Drawing.Point(193, 49);
            this.llbCategory.Name = "llbCategory";
            this.llbCategory.Size = new System.Drawing.Size(204, 16);
            this.llbCategory.TabIndex = 1;
            this.llbCategory.TabStop = true;
            this.llbCategory.Text = "Category";
            this.llbCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbCategory_LinkClicked);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Location = new System.Drawing.Point(400, 49);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 16);
            this.label11.TabIndex = 40;
            this.label11.Text = "קטגוריה";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(33, 19);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(51, 19);
            this.chkActive.TabIndex = 10;
            this.chkActive.Text = "פעיל";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Location = new System.Drawing.Point(400, 283);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 16);
            this.label7.TabIndex = 34;
            this.label7.Text = "ארגז";
            // 
            // cboDefCase
            // 
            this.cboDefCase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDefCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDefCase.FormattingEnabled = true;
            this.cboDefCase.Location = new System.Drawing.Point(13, 280);
            this.cboDefCase.Name = "cboDefCase";
            this.cboDefCase.Size = new System.Drawing.Size(381, 23);
            this.cboDefCase.TabIndex = 7;
            this.cboDefCase.SelectedIndexChanged += new System.EventHandler(this.cboDefCase_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Location = new System.Drawing.Point(400, 312);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 16);
            this.label6.TabIndex = 32;
            this.label6.Text = "הערות";
            // 
            // txtComments
            // 
            this.txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComments.Location = new System.Drawing.Point(13, 309);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(381, 122);
            this.txtComments.TabIndex = 9;
            this.txtComments.TextChanged += new System.EventHandler(this.txtComments_TextChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(400, 225);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 16);
            this.label5.TabIndex = 30;
            this.label5.Text = "מספר סידורי";
            // 
            // txtIncluding
            // 
            this.txtIncluding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIncluding.Location = new System.Drawing.Point(13, 133);
            this.txtIncluding.Multiline = true;
            this.txtIncluding.Name = "txtIncluding";
            this.txtIncluding.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIncluding.Size = new System.Drawing.Size(381, 83);
            this.txtIncluding.TabIndex = 4;
            this.txtIncluding.TextChanged += new System.EventHandler(this.txtIncluding_TextChanged);
            // 
            // txtSerNo
            // 
            this.txtSerNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerNo.Location = new System.Drawing.Point(13, 222);
            this.txtSerNo.Name = "txtSerNo";
            this.txtSerNo.Size = new System.Drawing.Size(381, 23);
            this.txtSerNo.TabIndex = 5;
            this.txtSerNo.TextChanged += new System.EventHandler(this.txtSerNo_TextChanged);
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(13, 104);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(381, 23);
            this.txtDesc.TabIndex = 3;
            this.txtDesc.TextChanged += new System.EventHandler(this.txtDesc_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Location = new System.Drawing.Point(400, 136);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 16);
            this.label4.TabIndex = 26;
            this.label4.Text = "הפריט כולל";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Location = new System.Drawing.Point(400, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 16);
            this.label3.TabIndex = 25;
            this.label3.Text = "תיאור";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Location = new System.Drawing.Point(400, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 16);
            this.label2.TabIndex = 24;
            this.label2.Text = "שם הפריט";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(13, 75);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(381, 23);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(400, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 16);
            this.label1.TabIndex = 22;
            this.label1.Text = "מזהה פריט";
            // 
            // txtID
            // 
            this.txtID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtID.Enabled = false;
            this.txtID.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtID.Location = new System.Drawing.Point(278, 17);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(116, 23);
            this.txtID.TabIndex = 0;
            // 
            // lvwMoves
            // 
            this.lvwMoves.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwMoves.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvwMoves.ContextMenuStrip = this.cmsMoves;
            this.lvwMoves.FullRowSelect = true;
            this.lvwMoves.Location = new System.Drawing.Point(0, 30);
            this.lvwMoves.MultiSelect = false;
            this.lvwMoves.Name = "lvwMoves";
            this.lvwMoves.RightToLeftLayout = true;
            this.lvwMoves.Size = new System.Drawing.Size(306, 39);
            this.lvwMoves.TabIndex = 0;
            this.lvwMoves.UseCompatibleStateImageBehavior = false;
            this.lvwMoves.View = System.Windows.Forms.View.Details;
            this.lvwMoves.DoubleClick += new System.EventHandler(this.lvwMoves_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "פרויקט";
            this.columnHeader1.Width = 122;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "תאריך";
            this.columnHeader2.Width = 78;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "צוות";
            this.columnHeader3.Width = 81;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "סטטוס";
            this.columnHeader4.Width = 142;
            // 
            // cmsMoves
            // 
            this.cmsMoves.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsMoves.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMovementToolStripMenuItem,
            this.orenJobToolStripMenuItem});
            this.cmsMoves.Name = "cmsMoves";
            this.cmsMoves.Size = new System.Drawing.Size(167, 48);
            // 
            // openMovementToolStripMenuItem
            // 
            this.openMovementToolStripMenuItem.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.openMovementToolStripMenuItem.Name = "openMovementToolStripMenuItem";
            this.openMovementToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.openMovementToolStripMenuItem.Text = "Open Movement...";
            this.openMovementToolStripMenuItem.Click += new System.EventHandler(this.openMovementToolStripMenuItem_Click);
            // 
            // orenJobToolStripMenuItem
            // 
            this.orenJobToolStripMenuItem.Name = "orenJobToolStripMenuItem";
            this.orenJobToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.orenJobToolStripMenuItem.Text = "Open Job...";
            this.orenJobToolStripMenuItem.Click += new System.EventHandler(this.orenJobToolStripMenuItem_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(421, 521);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 32);
            this.btnCancel.TabIndex = 11;
            this.btnCancel.Text = "ביטול";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(327, 521);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 32);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "אישור";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Location = new System.Drawing.Point(180, -2);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(341, 33);
            this.panel3.TabIndex = 16;
            // 
            // btnTab2
            // 
            this.btnTab2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnTab2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTab2.Location = new System.Drawing.Point(90, 0);
            this.btnTab2.Name = "btnTab2";
            this.btnTab2.Size = new System.Drawing.Size(91, 32);
            this.btnTab2.TabIndex = 15;
            this.btnTab2.Text = "תנועות";
            this.btnTab2.UseVisualStyleBackColor = false;
            this.btnTab2.Click += new System.EventHandler(this.btnTab2_Click);
            // 
            // btnTab1
            // 
            this.btnTab1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTab1.Location = new System.Drawing.Point(0, 0);
            this.btnTab1.Name = "btnTab1";
            this.btnTab1.Size = new System.Drawing.Size(91, 32);
            this.btnTab1.TabIndex = 14;
            this.btnTab1.Text = "פרטים";
            this.btnTab1.UseVisualStyleBackColor = true;
            this.btnTab1.Click += new System.EventHandler(this.btnTab1_Click);
            // 
            // panDetails
            // 
            this.panDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panDetails.Controls.Add(this.btnClearCatalogItem);
            this.panDetails.Controls.Add(this.btnSearchCatalog);
            this.panDetails.Controls.Add(this.label8);
            this.panDetails.Controls.Add(this.txtCatalogItem);
            this.panDetails.Controls.Add(this.dtpEnterSer);
            this.panDetails.Controls.Add(this.label1);
            this.panDetails.Controls.Add(this.label12);
            this.panDetails.Controls.Add(this.label6);
            this.panDetails.Controls.Add(this.chkActive);
            this.panDetails.Controls.Add(this.txtComments);
            this.panDetails.Controls.Add(this.llbCategory);
            this.panDetails.Controls.Add(this.label11);
            this.panDetails.Controls.Add(this.txtID);
            this.panDetails.Controls.Add(this.txtName);
            this.panDetails.Controls.Add(this.label7);
            this.panDetails.Controls.Add(this.label2);
            this.panDetails.Controls.Add(this.cboDefCase);
            this.panDetails.Controls.Add(this.label3);
            this.panDetails.Controls.Add(this.label4);
            this.panDetails.Controls.Add(this.txtDesc);
            this.panDetails.Controls.Add(this.label5);
            this.panDetails.Controls.Add(this.txtIncluding);
            this.panDetails.Controls.Add(this.txtSerNo);
            this.panDetails.Location = new System.Drawing.Point(0, 31);
            this.panDetails.Name = "panDetails";
            this.panDetails.Size = new System.Drawing.Size(521, 476);
            this.panDetails.TabIndex = 17;
            // 
            // btnClearCatalogItem
            // 
            this.btnClearCatalogItem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearCatalogItem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClearCatalogItem.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClearCatalogItem.Image = global::EquipmentCheckOut.Properties.Resources.DEL19;
            this.btnClearCatalogItem.Location = new System.Drawing.Point(13, 437);
            this.btnClearCatalogItem.Name = "btnClearCatalogItem";
            this.btnClearCatalogItem.Size = new System.Drawing.Size(23, 23);
            this.btnClearCatalogItem.TabIndex = 45;
            this.btnClearCatalogItem.UseVisualStyleBackColor = true;
            this.btnClearCatalogItem.Click += new System.EventHandler(this.btnClearCatalogItem_Click);
            // 
            // btnSearchCatalog
            // 
            this.btnSearchCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearchCatalog.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchCatalog.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchCatalog.Location = new System.Drawing.Point(35, 437);
            this.btnSearchCatalog.Name = "btnSearchCatalog";
            this.btnSearchCatalog.Size = new System.Drawing.Size(29, 23);
            this.btnSearchCatalog.TabIndex = 44;
            this.btnSearchCatalog.Text = "---";
            this.btnSearchCatalog.UseVisualStyleBackColor = true;
            this.btnSearchCatalog.Click += new System.EventHandler(this.btnSearchCatalog_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Location = new System.Drawing.Point(400, 440);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 16);
            this.label8.TabIndex = 43;
            this.label8.Text = "פריט מחירון";
            // 
            // txtCatalogItem
            // 
            this.txtCatalogItem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCatalogItem.Enabled = false;
            this.txtCatalogItem.Location = new System.Drawing.Point(63, 437);
            this.txtCatalogItem.Name = "txtCatalogItem";
            this.txtCatalogItem.Size = new System.Drawing.Size(331, 23);
            this.txtCatalogItem.TabIndex = 42;
            this.txtCatalogItem.Text = "--ללא--";
            this.txtCatalogItem.TextChanged += new System.EventHandler(this.txtCatalogItem_TextChanged);
            // 
            // panMoves
            // 
            this.panMoves.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panMoves.Controls.Add(this.lblRecords);
            this.panMoves.Controls.Add(this.checkBox1);
            this.panMoves.Controls.Add(this.lvwMoves);
            this.panMoves.Location = new System.Drawing.Point(446, 491);
            this.panMoves.Name = "panMoves";
            this.panMoves.Size = new System.Drawing.Size(306, 104);
            this.panMoves.TabIndex = 18;
            this.panMoves.Visible = false;
            // 
            // lblRecords
            // 
            this.lblRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRecords.Location = new System.Drawing.Point(49, 78);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(245, 13);
            this.lblRecords.TabIndex = 12;
            this.lblRecords.Text = "סהכ נמצאו";
            // 
            // checkBox1
            // 
            this.checkBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(155, 5);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(135, 19);
            this.checkBox1.TabIndex = 11;
            this.checkBox1.Text = "הצג רק הערות/בעיות";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // btnDuplicate
            // 
            this.btnDuplicate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDuplicate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDuplicate.Location = new System.Drawing.Point(12, 521);
            this.btnDuplicate.Name = "btnDuplicate";
            this.btnDuplicate.Size = new System.Drawing.Size(87, 32);
            this.btnDuplicate.TabIndex = 19;
            this.btnDuplicate.Text = "שיכפול...";
            this.btnDuplicate.UseVisualStyleBackColor = true;
            this.btnDuplicate.Click += new System.EventHandler(this.btnDuplicate_Click);
            // 
            // frmCheckOutItem
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(520, 566);
            this.Controls.Add(this.btnDuplicate);
            this.Controls.Add(this.panMoves);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panDetails);
            this.Controls.Add(this.btnTab1);
            this.Controls.Add(this.btnTab2);
            this.Controls.Add(this.panel3);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(460, 530);
            this.Name = "frmCheckOutItem";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "פריט ציוד";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmCheckOutItem_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmItem_FormClosed);
            this.Load += new System.EventHandler(this.frmCheckOutItem_Load);
            this.cmsMoves.ResumeLayout(false);
            this.panDetails.ResumeLayout(false);
            this.panDetails.PerformLayout();
            this.panMoves.ResumeLayout(false);
            this.panMoves.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboDefCase;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIncluding;
        private System.Windows.Forms.TextBox txtSerNo;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.ListView lvwMoves;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.LinkLabel llbCategory;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DateTimePicker dtpEnterSer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ContextMenuStrip cmsMoves;
        private System.Windows.Forms.ToolStripMenuItem openMovementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orenJobToolStripMenuItem;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnTab2;
        private System.Windows.Forms.Button btnTab1;
        private System.Windows.Forms.Panel panDetails;
        private System.Windows.Forms.Panel panMoves;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.Button btnDuplicate;
        private System.Windows.Forms.Button btnSearchCatalog;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCatalogItem;
        private System.Windows.Forms.Button btnClearCatalogItem;
    }
}
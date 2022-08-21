namespace EquipmentCheckOut
{
    partial class frmItem
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDupItem = new System.Windows.Forms.ToolStripButton();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.dtpEnterSer = new System.Windows.Forms.DateTimePicker();
            this.label12 = new System.Windows.Forms.Label();
            this.llbCategory = new System.Windows.Forms.LinkLabel();
            this.label11 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboInvoked = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.nudDefQtty = new System.Windows.Forms.NumericUpDown();
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
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvwMoves = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblRecords = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.btnSolved = new System.Windows.Forms.Button();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtProblem = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.lvwMaintenance = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblTitle = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmsMoves = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.openMovementToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.orenJobToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDefQtty)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.cmsMoves.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.toolStripSeparator1,
            this.tsbDupItem});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(496, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSave.Enabled = false;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(93, 22);
            this.tsbSave.Text = "Save and Close";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDupItem
            // 
            this.tsbDupItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDupItem.Enabled = false;
            this.tsbDupItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDupItem.Name = "tsbDupItem";
            this.tsbDupItem.Size = new System.Drawing.Size(91, 22);
            this.tsbDupItem.Text = "Duplicate Item";
            this.tsbDupItem.Click += new System.EventHandler(this.tsbDupItem_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Controls.Add(this.tabPage2);
            this.tabControl.Controls.Add(this.tabPage3);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(6, 6);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(484, 482);
            this.tabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.dtpEnterSer);
            this.tabPage1.Controls.Add(this.label12);
            this.tabPage1.Controls.Add(this.llbCategory);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.chkActive);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.cboInvoked);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.nudDefQtty);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.cboDefCase);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.txtComments);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtIncluding);
            this.tabPage1.Controls.Add(this.txtSerNo);
            this.tabPage1.Controls.Add(this.txtDesc);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.txtName);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.txtID);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(476, 455);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Details";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // dtpEnterSer
            // 
            this.dtpEnterSer.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEnterSer.Location = new System.Drawing.Point(118, 241);
            this.dtpEnterSer.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.dtpEnterSer.Name = "dtpEnterSer";
            this.dtpEnterSer.Size = new System.Drawing.Size(99, 22);
            this.dtpEnterSer.TabIndex = 6;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(15, 247);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 14);
            this.label12.TabIndex = 41;
            this.label12.Text = "Enter Service";
            // 
            // llbCategory
            // 
            this.llbCategory.AutoSize = true;
            this.llbCategory.Location = new System.Drawing.Point(115, 48);
            this.llbCategory.Name = "llbCategory";
            this.llbCategory.Size = new System.Drawing.Size(53, 14);
            this.llbCategory.TabIndex = 1;
            this.llbCategory.TabStop = true;
            this.llbCategory.Text = "Category";
            this.llbCategory.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbCategory_LinkClicked);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(15, 48);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 14);
            this.label11.TabIndex = 40;
            this.label11.Text = "Category";
            // 
            // chkActive
            // 
            this.chkActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(397, 19);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(57, 18);
            this.chkActive.TabIndex = 10;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(15, 337);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(66, 14);
            this.label9.TabIndex = 38;
            this.label9.Text = "Invoked as";
            // 
            // cboInvoked
            // 
            this.cboInvoked.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboInvoked.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboInvoked.FormattingEnabled = true;
            this.cboInvoked.Location = new System.Drawing.Point(118, 334);
            this.cboInvoked.Name = "cboInvoked";
            this.cboInvoked.Size = new System.Drawing.Size(336, 22);
            this.cboInvoked.TabIndex = 8;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(15, 308);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(96, 14);
            this.label8.TabIndex = 36;
            this.label8.Text = "Default Quantity";
            // 
            // nudDefQtty
            // 
            this.nudDefQtty.Location = new System.Drawing.Point(118, 306);
            this.nudDefQtty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudDefQtty.Name = "nudDefQtty";
            this.nudDefQtty.Size = new System.Drawing.Size(54, 22);
            this.nudDefQtty.TabIndex = 7;
            this.nudDefQtty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 14);
            this.label7.TabIndex = 34;
            this.label7.Text = "Default Case";
            // 
            // cboDefCase
            // 
            this.cboDefCase.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDefCase.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDefCase.FormattingEnabled = true;
            this.cboDefCase.Location = new System.Drawing.Point(118, 278);
            this.cboDefCase.Name = "cboDefCase";
            this.cboDefCase.Size = new System.Drawing.Size(336, 22);
            this.cboDefCase.TabIndex = 7;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 365);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 14);
            this.label6.TabIndex = 32;
            this.label6.Text = "Comment";
            // 
            // txtComments
            // 
            this.txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComments.Location = new System.Drawing.Point(118, 362);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(336, 80);
            this.txtComments.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 216);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 14);
            this.label5.TabIndex = 30;
            this.label5.Text = "Serial Number";
            // 
            // txtIncluding
            // 
            this.txtIncluding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtIncluding.Location = new System.Drawing.Point(118, 129);
            this.txtIncluding.Multiline = true;
            this.txtIncluding.Name = "txtIncluding";
            this.txtIncluding.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIncluding.Size = new System.Drawing.Size(336, 78);
            this.txtIncluding.TabIndex = 4;
            // 
            // txtSerNo
            // 
            this.txtSerNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSerNo.Location = new System.Drawing.Point(118, 213);
            this.txtSerNo.Name = "txtSerNo";
            this.txtSerNo.Size = new System.Drawing.Size(336, 22);
            this.txtSerNo.TabIndex = 5;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(118, 101);
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.Size = new System.Drawing.Size(336, 22);
            this.txtDesc.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 132);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 14);
            this.label4.TabIndex = 26;
            this.label4.Text = "Including";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 104);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 14);
            this.label3.TabIndex = 25;
            this.label3.Text = "Description";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 76);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 14);
            this.label2.TabIndex = 24;
            this.label2.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Location = new System.Drawing.Point(118, 73);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(336, 22);
            this.txtName.TabIndex = 2;
            this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 14);
            this.label1.TabIndex = 22;
            this.label1.Text = "ID";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtID.Location = new System.Drawing.Point(118, 17);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(72, 22);
            this.txtID.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvwMoves);
            this.tabPage2.Controls.Add(this.panel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(476, 455);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Movements";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvwMoves
            // 
            this.lvwMoves.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvwMoves.ContextMenuStrip = this.cmsMoves;
            this.lvwMoves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwMoves.FullRowSelect = true;
            this.lvwMoves.Location = new System.Drawing.Point(3, 3);
            this.lvwMoves.MultiSelect = false;
            this.lvwMoves.Name = "lvwMoves";
            this.lvwMoves.Size = new System.Drawing.Size(470, 427);
            this.lvwMoves.TabIndex = 0;
            this.lvwMoves.UseCompatibleStateImageBehavior = false;
            this.lvwMoves.View = System.Windows.Forms.View.Details;
            this.lvwMoves.DoubleClick += new System.EventHandler(this.lvwMoves_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Job";
            this.columnHeader1.Width = 122;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Checkout";
            this.columnHeader2.Width = 78;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Checkin";
            this.columnHeader3.Width = 81;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Crew";
            this.columnHeader4.Width = 142;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblRecords);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 430);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(470, 22);
            this.panel2.TabIndex = 1;
            // 
            // lblRecords
            // 
            this.lblRecords.AutoSize = true;
            this.lblRecords.Location = new System.Drawing.Point(3, 3);
            this.lblRecords.Name = "lblRecords";
            this.lblRecords.Size = new System.Drawing.Size(48, 14);
            this.lblRecords.TabIndex = 0;
            this.lblRecords.Text = "label13";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.btnSolved);
            this.tabPage3.Controls.Add(this.lblDesc);
            this.tabPage3.Controls.Add(this.txtProblem);
            this.tabPage3.Controls.Add(this.label10);
            this.tabPage3.Controls.Add(this.lvwMaintenance);
            this.tabPage3.Controls.Add(this.lblTitle);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(476, 455);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Maintenance";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // btnSolved
            // 
            this.btnSolved.Enabled = false;
            this.btnSolved.Location = new System.Drawing.Point(39, 230);
            this.btnSolved.Name = "btnSolved";
            this.btnSolved.Size = new System.Drawing.Size(115, 23);
            this.btnSolved.TabIndex = 5;
            this.btnSolved.Text = "Problem Solved";
            this.btnSolved.UseVisualStyleBackColor = true;
            this.btnSolved.Click += new System.EventHandler(this.btnSolved_Click);
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.ForeColor = System.Drawing.SystemColors.GrayText;
            this.lblDesc.Location = new System.Drawing.Point(36, 77);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(69, 14);
            this.lblDesc.TabIndex = 4;
            this.lblDesc.Text = "Description";
            // 
            // txtProblem
            // 
            this.txtProblem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProblem.Enabled = false;
            this.txtProblem.ForeColor = System.Drawing.SystemColors.GrayText;
            this.txtProblem.Location = new System.Drawing.Point(39, 94);
            this.txtProblem.Multiline = true;
            this.txtProblem.Name = "txtProblem";
            this.txtProblem.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtProblem.Size = new System.Drawing.Size(392, 130);
            this.txtProblem.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 280);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(120, 14);
            this.label10.TabIndex = 2;
            this.label10.Text = "Maintenance History";
            // 
            // lvwMaintenance
            // 
            this.lvwMaintenance.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwMaintenance.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8});
            this.lvwMaintenance.FullRowSelect = true;
            this.lvwMaintenance.Location = new System.Drawing.Point(6, 297);
            this.lvwMaintenance.MultiSelect = false;
            this.lvwMaintenance.Name = "lvwMaintenance";
            this.lvwMaintenance.Size = new System.Drawing.Size(464, 152);
            this.lvwMaintenance.TabIndex = 1;
            this.lvwMaintenance.UseCompatibleStateImageBehavior = false;
            this.lvwMaintenance.View = System.Windows.Forms.View.Details;
            this.lvwMaintenance.DoubleClick += new System.EventHandler(this.lvwMoves_DoubleClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Job";
            this.columnHeader5.Width = 149;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Checkin";
            this.columnHeader6.Width = 80;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Crew";
            this.columnHeader7.Width = 124;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Solved";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Location = new System.Drawing.Point(36, 37);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(118, 14);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "No Current Problems";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(6);
            this.panel1.Size = new System.Drawing.Size(496, 494);
            this.panel1.TabIndex = 2;
            // 
            // cmsMoves
            // 
            this.cmsMoves.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsMoves.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMovementToolStripMenuItem,
            this.orenJobToolStripMenuItem});
            this.cmsMoves.Name = "cmsMoves";
            this.cmsMoves.Size = new System.Drawing.Size(167, 70);
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
            // frmItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(210)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(496, 519);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(310, 400);
            this.Name = "frmItem";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Item";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmItem_FormClosed);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudDefQtty)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.cmsMoves.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboInvoked;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudDefQtty;
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
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ListView lvwMoves;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtProblem;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ListView lvwMaintenance;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button btnSolved;
        private System.Windows.Forms.LinkLabel llbCategory;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ToolStripButton tsbDupItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DateTimePicker dtpEnterSer;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblRecords;
        private System.Windows.Forms.ContextMenuStrip cmsMoves;
        private System.Windows.Forms.ToolStripMenuItem openMovementToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem orenJobToolStripMenuItem;
    }
}
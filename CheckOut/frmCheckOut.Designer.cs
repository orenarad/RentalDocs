namespace EquipmentCheckOut
{
    partial class frmChechOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmChechOut));
            this.cmsMovements = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiOpenItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiCheckBack = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsiAddItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiReplaceItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiRemoveItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.cmsiAddCase = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsiRemoveCase = new System.Windows.Forms.ToolStripMenuItem();
            this.lblClosed = new System.Windows.Forms.Label();
            this.gpbDetails = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMNotes = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMIncluding = new System.Windows.Forms.TextBox();
            this.chkMBack = new System.Windows.Forms.CheckBox();
            this.chkMIssue = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.nudMQtty = new System.Windows.Forms.NumericUpDown();
            this.lvwMoves = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel5 = new System.Windows.Forms.Panel();
            this.btnNewDoc = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCrew = new System.Windows.Forms.TextBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dtpDate1 = new System.Windows.Forms.DateTimePicker();
            this.dtpDate2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.lblOut = new System.Windows.Forms.Label();
            this.cboProjects = new System.Windows.Forms.ComboBox();
            this.txtSubject = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmsMovements.SuspendLayout();
            this.gpbDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMQtty)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmsMovements
            // 
            this.cmsMovements.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsMovements.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiOpenItem,
            this.cmsiCheckBack,
            this.toolStripSeparator3,
            this.cmsiAddItem,
            this.cmsiReplaceItem,
            this.cmsiRemoveItem,
            this.toolStripSeparator4,
            this.cmsiAddCase,
            this.cmsiRemoveCase});
            this.cmsMovements.Name = "cmsMovements";
            this.cmsMovements.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cmsMovements.Size = new System.Drawing.Size(160, 170);
            this.cmsMovements.Opening += new System.ComponentModel.CancelEventHandler(this.cmsMovements_Opening);
            // 
            // cmsiOpenItem
            // 
            this.cmsiOpenItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsiOpenItem.Name = "cmsiOpenItem";
            this.cmsiOpenItem.Size = new System.Drawing.Size(159, 22);
            this.cmsiOpenItem.Text = "פתיחת פריט...";
            this.cmsiOpenItem.Click += new System.EventHandler(this.openItemToolStripMenuItem_Click);
            // 
            // cmsiCheckBack
            // 
            this.cmsiCheckBack.Name = "cmsiCheckBack";
            this.cmsiCheckBack.Size = new System.Drawing.Size(159, 22);
            this.cmsiCheckBack.Text = "זיכוי פריט";
            this.cmsiCheckBack.Click += new System.EventHandler(this.cmsiCheckBack_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(156, 6);
            // 
            // cmsiAddItem
            // 
            this.cmsiAddItem.Name = "cmsiAddItem";
            this.cmsiAddItem.Size = new System.Drawing.Size(159, 22);
            this.cmsiAddItem.Text = "הוספת פריטים...";
            this.cmsiAddItem.Click += new System.EventHandler(this.cmsiAddItem_Click);
            // 
            // cmsiReplaceItem
            // 
            this.cmsiReplaceItem.Name = "cmsiReplaceItem";
            this.cmsiReplaceItem.Size = new System.Drawing.Size(159, 22);
            this.cmsiReplaceItem.Text = "החלפת פריט...";
            this.cmsiReplaceItem.Click += new System.EventHandler(this.cmsiReplaceItem_Click);
            // 
            // cmsiRemoveItem
            // 
            this.cmsiRemoveItem.Name = "cmsiRemoveItem";
            this.cmsiRemoveItem.Size = new System.Drawing.Size(159, 22);
            this.cmsiRemoveItem.Text = "הסרת פריטים";
            this.cmsiRemoveItem.Click += new System.EventHandler(this.cmsiRemoveItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(156, 6);
            // 
            // cmsiAddCase
            // 
            this.cmsiAddCase.Name = "cmsiAddCase";
            this.cmsiAddCase.Size = new System.Drawing.Size(159, 22);
            this.cmsiAddCase.Text = "הוספת ארגזים...";
            this.cmsiAddCase.Click += new System.EventHandler(this.cmsiAddCase_Click);
            // 
            // cmsiRemoveCase
            // 
            this.cmsiRemoveCase.Name = "cmsiRemoveCase";
            this.cmsiRemoveCase.Size = new System.Drawing.Size(159, 22);
            this.cmsiRemoveCase.Text = "הסרת ארגז";
            this.cmsiRemoveCase.Click += new System.EventHandler(this.cmsiRemoveCase_Click);
            // 
            // lblClosed
            // 
            this.lblClosed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClosed.AutoSize = true;
            this.lblClosed.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblClosed.ForeColor = System.Drawing.Color.Navy;
            this.lblClosed.Location = new System.Drawing.Point(893, 5);
            this.lblClosed.Name = "lblClosed";
            this.lblClosed.Size = new System.Drawing.Size(103, 15);
            this.lblClosed.TabIndex = 20;
            this.lblClosed.Text = "This Job is Closed!";
            this.lblClosed.Visible = false;
            // 
            // gpbDetails
            // 
            this.gpbDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gpbDetails.Controls.Add(this.label14);
            this.gpbDetails.Controls.Add(this.txtMNotes);
            this.gpbDetails.Controls.Add(this.label13);
            this.gpbDetails.Controls.Add(this.txtMIncluding);
            this.gpbDetails.Controls.Add(this.chkMBack);
            this.gpbDetails.Controls.Add(this.chkMIssue);
            this.gpbDetails.Controls.Add(this.label12);
            this.gpbDetails.Controls.Add(this.nudMQtty);
            this.gpbDetails.ForeColor = System.Drawing.SystemColors.WindowText;
            this.gpbDetails.Location = new System.Drawing.Point(6, 358);
            this.gpbDetails.Name = "gpbDetails";
            this.gpbDetails.Size = new System.Drawing.Size(707, 104);
            this.gpbDetails.TabIndex = 7;
            this.gpbDetails.TabStop = false;
            this.gpbDetails.Text = "פרטים";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Enabled = false;
            this.label14.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label14.Location = new System.Drawing.Point(340, 19);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(44, 15);
            this.label14.TabIndex = 16;
            this.label14.Text = "הערות:";
            // 
            // txtMNotes
            // 
            this.txtMNotes.Enabled = false;
            this.txtMNotes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMNotes.Location = new System.Drawing.Point(103, 19);
            this.txtMNotes.Multiline = true;
            this.txtMNotes.Name = "txtMNotes";
            this.txtMNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMNotes.Size = new System.Drawing.Size(231, 75);
            this.txtMNotes.TabIndex = 15;
            this.txtMNotes.Validated += new System.EventHandler(this.txtMNotes_Validated);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Enabled = false;
            this.label13.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label13.Location = new System.Drawing.Point(667, 19);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(34, 15);
            this.label13.TabIndex = 14;
            this.label13.Text = "כולל:";
            // 
            // txtMIncluding
            // 
            this.txtMIncluding.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMIncluding.Enabled = false;
            this.txtMIncluding.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMIncluding.Location = new System.Drawing.Point(390, 19);
            this.txtMIncluding.Multiline = true;
            this.txtMIncluding.Name = "txtMIncluding";
            this.txtMIncluding.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMIncluding.Size = new System.Drawing.Size(271, 76);
            this.txtMIncluding.TabIndex = 13;
            this.txtMIncluding.Validated += new System.EventHandler(this.txtMIncluding_Validated);
            // 
            // chkMBack
            // 
            this.chkMBack.AutoSize = true;
            this.chkMBack.Enabled = false;
            this.chkMBack.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkMBack.Location = new System.Drawing.Point(6, 46);
            this.chkMBack.Name = "chkMBack";
            this.chkMBack.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkMBack.Size = new System.Drawing.Size(45, 19);
            this.chkMBack.TabIndex = 10;
            this.chkMBack.Text = "חזר";
            this.chkMBack.UseVisualStyleBackColor = true;
            this.chkMBack.CheckedChanged += new System.EventHandler(this.chkMBack_CheckedChanged);
            // 
            // chkMIssue
            // 
            this.chkMIssue.AutoSize = true;
            this.chkMIssue.Enabled = false;
            this.chkMIssue.ForeColor = System.Drawing.SystemColors.WindowText;
            this.chkMIssue.Location = new System.Drawing.Point(6, 72);
            this.chkMIssue.Name = "chkMIssue";
            this.chkMIssue.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkMIssue.Size = new System.Drawing.Size(51, 19);
            this.chkMIssue.TabIndex = 11;
            this.chkMIssue.Text = "בעיה";
            this.chkMIssue.UseVisualStyleBackColor = true;
            this.chkMIssue.CheckedChanged += new System.EventHandler(this.chkMIssue_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Enabled = false;
            this.label12.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label12.Location = new System.Drawing.Point(60, 19);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(37, 15);
            this.label12.TabIndex = 12;
            this.label12.Text = "כמות:";
            // 
            // nudMQtty
            // 
            this.nudMQtty.Enabled = false;
            this.nudMQtty.Location = new System.Drawing.Point(6, 17);
            this.nudMQtty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMQtty.Name = "nudMQtty";
            this.nudMQtty.Size = new System.Drawing.Size(48, 23);
            this.nudMQtty.TabIndex = 9;
            this.nudMQtty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nudMQtty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudMQtty.ValueChanged += new System.EventHandler(this.nudMQtty_ValueChanged);
            // 
            // lvwMoves
            // 
            this.lvwMoves.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwMoves.BackColor = System.Drawing.SystemColors.Window;
            this.lvwMoves.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwMoves.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader2});
            this.lvwMoves.ContextMenuStrip = this.cmsMovements;
            this.lvwMoves.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwMoves.FullRowSelect = true;
            this.lvwMoves.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwMoves.Location = new System.Drawing.Point(0, 37);
            this.lvwMoves.Name = "lvwMoves";
            this.lvwMoves.RightToLeftLayout = true;
            this.lvwMoves.ShowItemToolTips = true;
            this.lvwMoves.Size = new System.Drawing.Size(713, 315);
            this.lvwMoves.TabIndex = 4;
            this.lvwMoves.UseCompatibleStateImageBehavior = false;
            this.lvwMoves.View = System.Windows.Forms.View.Details;
            this.lvwMoves.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwMoves_ItemSelectionChanged);
            this.lvwMoves.SelectedIndexChanged += new System.EventHandler(this.lvwMoves_SelectedIndexChanged);
            this.lvwMoves.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwMoves_MouseDoubleClick);
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "ID";
            this.columnHeader5.Width = 45;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "פריט";
            this.columnHeader1.Width = 415;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "מס\' סידורי";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "כמות";
            this.columnHeader4.Width = 69;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "הערה";
            this.columnHeader2.Width = 111;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel5.Controls.Add(this.btnNewDoc);
            this.panel5.Controls.Add(this.btnImport);
            this.panel5.Controls.Add(this.btnExport);
            this.panel5.Controls.Add(this.btnSave);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1024, 37);
            this.panel5.TabIndex = 8;
            // 
            // btnNewDoc
            // 
            this.btnNewDoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewDoc.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewDoc.Image = global::EquipmentCheckOut.Properties.Resources.ADD;
            this.btnNewDoc.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewDoc.Location = new System.Drawing.Point(477, 4);
            this.btnNewDoc.Name = "btnNewDoc";
            this.btnNewDoc.Size = new System.Drawing.Size(158, 28);
            this.btnNewDoc.TabIndex = 3;
            this.btnNewDoc.Text = "צור תעודת השכרה...";
            this.btnNewDoc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNewDoc.UseVisualStyleBackColor = true;
            this.btnNewDoc.Visible = false;
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Image = global::EquipmentCheckOut.Properties.Resources.INSERT;
            this.btnImport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnImport.Location = new System.Drawing.Point(641, 4);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(72, 28);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "יבא";
            this.btnImport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnImport.UseVisualStyleBackColor = true;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(863, 4);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 28);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "יצא";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSave.Location = new System.Drawing.Point(944, 4);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 28);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "שמור";
            this.btnSave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label6.Location = new System.Drawing.Point(980, 154);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 15);
            this.label6.TabIndex = 55;
            this.label6.Text = "צוות:";
            // 
            // txtCrew
            // 
            this.txtCrew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCrew.Location = new System.Drawing.Point(725, 154);
            this.txtCrew.Multiline = true;
            this.txtCrew.Name = "txtCrew";
            this.txtCrew.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCrew.Size = new System.Drawing.Size(225, 69);
            this.txtCrew.TabIndex = 3;
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotes.Location = new System.Drawing.Point(725, 299);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(284, 158);
            this.txtNotes.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label7.Location = new System.Drawing.Point(968, 281);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 15);
            this.label7.TabIndex = 56;
            this.label7.Text = "הערות:";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label4.Location = new System.Drawing.Point(968, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 53;
            this.label4.Text = "הוצאה:";
            // 
            // dtpDate1
            // 
            this.dtpDate1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate1.Location = new System.Drawing.Point(725, 66);
            this.dtpDate1.Name = "dtpDate1";
            this.dtpDate1.RightToLeftLayout = true;
            this.dtpDate1.Size = new System.Drawing.Size(118, 23);
            this.dtpDate1.TabIndex = 1;
            // 
            // dtpDate2
            // 
            this.dtpDate2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpDate2.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDate2.Location = new System.Drawing.Point(725, 96);
            this.dtpDate2.Name = "dtpDate2";
            this.dtpDate2.RightToLeftLayout = true;
            this.dtpDate2.Size = new System.Drawing.Size(118, 23);
            this.dtpDate2.TabIndex = 2;
            this.dtpDate2.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.WindowText;
            this.label3.Location = new System.Drawing.Point(965, 124);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 15);
            this.label3.TabIndex = 52;
            this.label3.Text = "פרויקט:";
            // 
            // lblOut
            // 
            this.lblOut.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblOut.AutoSize = true;
            this.lblOut.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lblOut.Location = new System.Drawing.Point(982, 96);
            this.lblOut.Name = "lblOut";
            this.lblOut.Size = new System.Drawing.Size(30, 15);
            this.lblOut.TabIndex = 54;
            this.lblOut.Text = "זיכוי:";
            this.lblOut.Visible = false;
            // 
            // cboProjects
            // 
            this.cboProjects.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProjects.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cboProjects.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboProjects.FormattingEnabled = true;
            this.cboProjects.Location = new System.Drawing.Point(725, 125);
            this.cboProjects.Name = "cboProjects";
            this.cboProjects.Size = new System.Drawing.Size(225, 23);
            this.cboProjects.TabIndex = 5;
            this.cboProjects.TextChanged += new System.EventHandler(this.cboProjects_TextChanged);
            this.cboProjects.Validating += new System.ComponentModel.CancelEventHandler(this.cboProjects_Validating);
            // 
            // txtSubject
            // 
            this.txtSubject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSubject.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtSubject.Location = new System.Drawing.Point(725, 251);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(284, 27);
            this.txtSubject.TabIndex = 0;
            this.txtSubject.TextChanged += new System.EventHandler(this.cboProjects_TextChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(970, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 20);
            this.label1.TabIndex = 59;
            this.label1.Text = "נושא:";
            // 
            // frmChechOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1024, 463);
            this.Controls.Add(this.txtSubject);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboProjects);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtCrew);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.lblOut);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpDate2);
            this.Controls.Add(this.dtpDate1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.gpbDetails);
            this.Controls.Add(this.lvwMoves);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.lblClosed);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(1040, 502);
            this.Name = "frmChechOut";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "CheckOut";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmChechOut_FormClosing);
            this.Load += new System.EventHandler(this.frmChechOut_Load);
            this.cmsMovements.ResumeLayout(false);
            this.gpbDetails.ResumeLayout(false);
            this.gpbDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMQtty)).EndInit();
            this.panel5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblClosed;
        private System.Windows.Forms.ContextMenuStrip cmsMovements;
        private System.Windows.Forms.ToolStripMenuItem cmsiOpenItem;
        private System.Windows.Forms.ToolStripMenuItem cmsiCheckBack;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cmsiAddItem;
        private System.Windows.Forms.ToolStripMenuItem cmsiRemoveItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cmsiAddCase;
        private System.Windows.Forms.ToolStripMenuItem cmsiRemoveCase;
        private System.Windows.Forms.ListView lvwMoves;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.GroupBox gpbDetails;
        private System.Windows.Forms.CheckBox chkMBack;
        private System.Windows.Forms.CheckBox chkMIssue;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown nudMQtty;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtMIncluding;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtMNotes;
        private System.Windows.Forms.ToolStripMenuItem cmsiReplaceItem;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnNewDoc;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCrew;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDate1;
        private System.Windows.Forms.DateTimePicker dtpDate2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblOut;
        private System.Windows.Forms.ComboBox cboProjects;
        private System.Windows.Forms.TextBox txtSubject;
        private System.Windows.Forms.Label label1;
    }
}
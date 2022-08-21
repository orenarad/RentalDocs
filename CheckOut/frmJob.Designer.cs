namespace EquipmentCheckOut
{
    partial class frmJob
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.txtCheckedBy = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPickedUpBy = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtIssuedBy = new System.Windows.Forms.TextBox();
            this.txtOpenDesk = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtJobName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtCrew = new System.Windows.Forms.TextBox();
            this.txtProd = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpIn = new System.Windows.Forms.DateTimePicker();
            this.dtpOut = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbSave = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCheckIn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPrint = new System.Windows.Forms.ToolStripSplitButton();
            this.tsbPreview = new System.Windows.Forms.ToolStripMenuItem();
            this.lblClosed = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.gpbDetails = new System.Windows.Forms.GroupBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtMNotes = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtMIncluding = new System.Windows.Forms.TextBox();
            this.chkMBack = new System.Windows.Forms.CheckBox();
            this.chkMIssue = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.nudMQtty = new System.Windows.Forms.NumericUpDown();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lvwMoves = new System.Windows.Forms.ListView();
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.cmsMovements.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.gpbDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMQtty)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Navy;
            this.label1.Location = new System.Drawing.Point(13, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Job ID:";
            // 
            // txtID
            // 
            this.txtID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(143, 21);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(51, 23);
            this.txtID.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(10, 495);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(153, 154);
            this.tabControl1.TabIndex = 4;
            this.tabControl1.Visible = false;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Window;
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(145, 126);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Details";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 42);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(7, 6, 7, 6);
            this.tabPage2.Size = new System.Drawing.Size(145, 108);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Movements";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.Navy;
            this.label11.Location = new System.Drawing.Point(13, 332);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(85, 15);
            this.label11.TabIndex = 35;
            this.label11.Text = "Checked In By:";
            // 
            // txtCheckedBy
            // 
            this.txtCheckedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCheckedBy.Location = new System.Drawing.Point(143, 329);
            this.txtCheckedBy.Name = "txtCheckedBy";
            this.txtCheckedBy.Size = new System.Drawing.Size(158, 23);
            this.txtCheckedBy.TabIndex = 9;
            this.txtCheckedBy.TextChanged += new System.EventHandler(this.txtCheckedBy_TextChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(13, 302);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 15);
            this.label10.TabIndex = 33;
            this.label10.Text = "Picked Up By:";
            // 
            // txtPickedUpBy
            // 
            this.txtPickedUpBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPickedUpBy.Location = new System.Drawing.Point(143, 299);
            this.txtPickedUpBy.Name = "txtPickedUpBy";
            this.txtPickedUpBy.Size = new System.Drawing.Size(158, 23);
            this.txtPickedUpBy.TabIndex = 8;
            this.txtPickedUpBy.TextChanged += new System.EventHandler(this.txtPickedUpBy_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(13, 272);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 15);
            this.label9.TabIndex = 31;
            this.label9.Text = "Issued By:";
            // 
            // txtIssuedBy
            // 
            this.txtIssuedBy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIssuedBy.Location = new System.Drawing.Point(143, 269);
            this.txtIssuedBy.Name = "txtIssuedBy";
            this.txtIssuedBy.Size = new System.Drawing.Size(158, 23);
            this.txtIssuedBy.TabIndex = 7;
            this.txtIssuedBy.TextChanged += new System.EventHandler(this.txtIssuedBy_TextChanged);
            // 
            // txtOpenDesk
            // 
            this.txtOpenDesk.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtOpenDesk.Location = new System.Drawing.Point(143, 172);
            this.txtOpenDesk.Name = "txtOpenDesk";
            this.txtOpenDesk.Size = new System.Drawing.Size(158, 23);
            this.txtOpenDesk.TabIndex = 5;
            this.txtOpenDesk.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.Navy;
            this.label8.Location = new System.Drawing.Point(13, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 15);
            this.label8.TabIndex = 29;
            this.label8.Text = "Open Desk Document:";
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.Navy;
            this.label7.Location = new System.Drawing.Point(13, 378);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 15);
            this.label7.TabIndex = 28;
            this.label7.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.txtNotes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNotes.Location = new System.Drawing.Point(16, 396);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(285, 148);
            this.txtNotes.TabIndex = 10;
            this.txtNotes.TextChanged += new System.EventHandler(this.txtNotes_TextChanged);
            // 
            // txtJobName
            // 
            this.txtJobName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtJobName.Location = new System.Drawing.Point(143, 51);
            this.txtJobName.Name = "txtJobName";
            this.txtJobName.Size = new System.Drawing.Size(158, 23);
            this.txtJobName.TabIndex = 1;
            this.txtJobName.TextChanged += new System.EventHandler(this.txtJobName_TextChanged);
            this.txtJobName.Validating += new System.ComponentModel.CancelEventHandler(this.txtJobName_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.Location = new System.Drawing.Point(13, 242);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "Crew:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 19;
            this.label2.Text = "Job Name:";
            // 
            // txtCrew
            // 
            this.txtCrew.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtCrew.Location = new System.Drawing.Point(143, 239);
            this.txtCrew.Name = "txtCrew";
            this.txtCrew.Size = new System.Drawing.Size(158, 23);
            this.txtCrew.TabIndex = 6;
            this.txtCrew.TextChanged += new System.EventHandler(this.txtCrew_TextChanged);
            // 
            // txtProd
            // 
            this.txtProd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtProd.Location = new System.Drawing.Point(143, 82);
            this.txtProd.Name = "txtProd";
            this.txtProd.Size = new System.Drawing.Size(158, 23);
            this.txtProd.TabIndex = 2;
            this.txtProd.TextChanged += new System.EventHandler(this.txtProd_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(13, 146);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 15);
            this.label5.TabIndex = 26;
            this.label5.Text = "Check In:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.Navy;
            this.label3.Location = new System.Drawing.Point(13, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(124, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Production Company:";
            // 
            // dtpIn
            // 
            this.dtpIn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpIn.Location = new System.Drawing.Point(143, 142);
            this.dtpIn.Name = "dtpIn";
            this.dtpIn.Size = new System.Drawing.Size(158, 23);
            this.dtpIn.TabIndex = 4;
            this.dtpIn.ValueChanged += new System.EventHandler(this.dtpIn_ValueChanged);
            // 
            // dtpOut
            // 
            this.dtpOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpOut.Location = new System.Drawing.Point(143, 112);
            this.dtpOut.Name = "dtpOut";
            this.dtpOut.Size = new System.Drawing.Size(158, 23);
            this.dtpOut.TabIndex = 3;
            this.dtpOut.ValueChanged += new System.EventHandler(this.dtpOut_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(13, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 15);
            this.label4.TabIndex = 25;
            this.label4.Text = "Check Out:";
            // 
            // cmsMovements
            // 
            this.cmsMovements.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
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
            this.cmsMovements.Size = new System.Drawing.Size(176, 170);
            this.cmsMovements.Opening += new System.ComponentModel.CancelEventHandler(this.cmsMovements_Opening);
            // 
            // cmsiOpenItem
            // 
            this.cmsiOpenItem.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmsiOpenItem.Name = "cmsiOpenItem";
            this.cmsiOpenItem.Size = new System.Drawing.Size(175, 22);
            this.cmsiOpenItem.Text = "Open Item...";
            this.cmsiOpenItem.Click += new System.EventHandler(this.openItemToolStripMenuItem_Click);
            // 
            // cmsiCheckBack
            // 
            this.cmsiCheckBack.Name = "cmsiCheckBack";
            this.cmsiCheckBack.Size = new System.Drawing.Size(175, 22);
            this.cmsiCheckBack.Text = "Check Back Item";
            this.cmsiCheckBack.Click += new System.EventHandler(this.cmsiCheckBack_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(172, 6);
            // 
            // cmsiAddItem
            // 
            this.cmsiAddItem.Name = "cmsiAddItem";
            this.cmsiAddItem.Size = new System.Drawing.Size(175, 22);
            this.cmsiAddItem.Text = "Add Items...";
            this.cmsiAddItem.Click += new System.EventHandler(this.cmsiAddItem_Click);
            // 
            // cmsiReplaceItem
            // 
            this.cmsiReplaceItem.Name = "cmsiReplaceItem";
            this.cmsiReplaceItem.Size = new System.Drawing.Size(175, 22);
            this.cmsiReplaceItem.Text = "Replace Item...";
            this.cmsiReplaceItem.Click += new System.EventHandler(this.cmsiReplaceItem_Click);
            // 
            // cmsiRemoveItem
            // 
            this.cmsiRemoveItem.Name = "cmsiRemoveItem";
            this.cmsiRemoveItem.Size = new System.Drawing.Size(175, 22);
            this.cmsiRemoveItem.Text = "Remove Items";
            this.cmsiRemoveItem.Click += new System.EventHandler(this.cmsiRemoveItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(172, 6);
            // 
            // cmsiAddCase
            // 
            this.cmsiAddCase.Name = "cmsiAddCase";
            this.cmsiAddCase.Size = new System.Drawing.Size(175, 22);
            this.cmsiAddCase.Text = "Add Cases To Job...";
            this.cmsiAddCase.Click += new System.EventHandler(this.cmsiAddCase_Click);
            // 
            // cmsiRemoveCase
            // 
            this.cmsiRemoveCase.Name = "cmsiRemoveCase";
            this.cmsiRemoveCase.Size = new System.Drawing.Size(175, 22);
            this.cmsiRemoveCase.Text = "Remove Case";
            this.cmsiRemoveCase.Click += new System.EventHandler(this.cmsiRemoveCase_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbSave,
            this.toolStripSeparator1,
            this.tsbCheckIn,
            this.toolStripSeparator2,
            this.tsbPrint});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1025, 25);
            this.toolStrip1.TabIndex = 5;
            // 
            // tsbSave
            // 
            this.tsbSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbSave.Enabled = false;
            this.tsbSave.Image = global::EquipmentCheckOut.Properties.Resources.save;
            this.tsbSave.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsbSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSave.Name = "tsbSave";
            this.tsbSave.Size = new System.Drawing.Size(35, 22);
            this.tsbSave.Text = "Save";
            this.tsbSave.ToolTipText = "Save";
            this.tsbSave.Click += new System.EventHandler(this.tsbSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbCheckIn
            // 
            this.tsbCheckIn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCheckIn.Enabled = false;
            this.tsbCheckIn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCheckIn.Name = "tsbCheckIn";
            this.tsbCheckIn.Size = new System.Drawing.Size(57, 22);
            this.tsbCheckIn.Text = "Check In";
            this.tsbCheckIn.Click += new System.EventHandler(this.tsbCheckIn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbPrint
            // 
            this.tsbPrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPrint.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbPreview});
            this.tsbPrint.Enabled = false;
            this.tsbPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPrint.Name = "tsbPrint";
            this.tsbPrint.Size = new System.Drawing.Size(122, 22);
            this.tsbPrint.Text = "Print Delivery Note";
            this.tsbPrint.ButtonClick += new System.EventHandler(this.tsbPrint_Click);
            // 
            // tsbPreview
            // 
            this.tsbPreview.Name = "tsbPreview";
            this.tsbPreview.Size = new System.Drawing.Size(152, 22);
            this.tsbPreview.Text = "Print Preview...";
            this.tsbPreview.Click += new System.EventHandler(this.tsbPreview_Click);
            // 
            // lblClosed
            // 
            this.lblClosed.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClosed.AutoSize = true;
            this.lblClosed.BackColor = System.Drawing.SystemColors.ControlLight;
            this.lblClosed.ForeColor = System.Drawing.Color.Navy;
            this.lblClosed.Location = new System.Drawing.Point(894, 5);
            this.lblClosed.Name = "lblClosed";
            this.lblClosed.Size = new System.Drawing.Size(103, 15);
            this.lblClosed.TabIndex = 20;
            this.lblClosed.Text = "This Job is Closed!";
            this.lblClosed.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(210)))), ((int)(((byte)(240)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.txtJobName);
            this.panel1.Controls.Add(this.txtCheckedBy);
            this.panel1.Controls.Add(this.txtCrew);
            this.panel1.Controls.Add(this.txtProd);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.txtNotes);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtPickedUpBy);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.dtpIn);
            this.panel1.Controls.Add(this.txtID);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.txtIssuedBy);
            this.panel1.Controls.Add(this.dtpOut);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtOpenDesk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(316, 556);
            this.panel1.TabIndex = 36;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel4);
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(316, 25);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(709, 556);
            this.panel2.TabIndex = 37;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.gpbDetails);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 442);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(5);
            this.panel4.Size = new System.Drawing.Size(709, 114);
            this.panel4.TabIndex = 1;
            // 
            // gpbDetails
            // 
            this.gpbDetails.Controls.Add(this.label14);
            this.gpbDetails.Controls.Add(this.txtMNotes);
            this.gpbDetails.Controls.Add(this.label13);
            this.gpbDetails.Controls.Add(this.txtMIncluding);
            this.gpbDetails.Controls.Add(this.chkMBack);
            this.gpbDetails.Controls.Add(this.chkMIssue);
            this.gpbDetails.Controls.Add(this.label12);
            this.gpbDetails.Controls.Add(this.nudMQtty);
            this.gpbDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gpbDetails.ForeColor = System.Drawing.Color.Navy;
            this.gpbDetails.Location = new System.Drawing.Point(5, 5);
            this.gpbDetails.Name = "gpbDetails";
            this.gpbDetails.Size = new System.Drawing.Size(699, 104);
            this.gpbDetails.TabIndex = 0;
            this.gpbDetails.TabStop = false;
            this.gpbDetails.Text = "Movement Details";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Enabled = false;
            this.label14.ForeColor = System.Drawing.Color.Navy;
            this.label14.Location = new System.Drawing.Point(323, 26);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(41, 15);
            this.label14.TabIndex = 16;
            this.label14.Text = "Notes:";
            // 
            // txtMNotes
            // 
            this.txtMNotes.Enabled = false;
            this.txtMNotes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMNotes.Location = new System.Drawing.Point(379, 22);
            this.txtMNotes.Multiline = true;
            this.txtMNotes.Name = "txtMNotes";
            this.txtMNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMNotes.Size = new System.Drawing.Size(189, 75);
            this.txtMNotes.TabIndex = 15;
            this.txtMNotes.Validated += new System.EventHandler(this.txtMNotes_Validated);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Enabled = false;
            this.label13.ForeColor = System.Drawing.Color.Navy;
            this.label13.Location = new System.Drawing.Point(16, 26);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 15);
            this.label13.TabIndex = 14;
            this.label13.Text = "Including:";
            // 
            // txtMIncluding
            // 
            this.txtMIncluding.Enabled = false;
            this.txtMIncluding.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMIncluding.Location = new System.Drawing.Point(94, 22);
            this.txtMIncluding.Multiline = true;
            this.txtMIncluding.Name = "txtMIncluding";
            this.txtMIncluding.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMIncluding.Size = new System.Drawing.Size(221, 76);
            this.txtMIncluding.TabIndex = 13;
            this.txtMIncluding.Validated += new System.EventHandler(this.txtMIncluding_Validated);
            // 
            // chkMBack
            // 
            this.chkMBack.AutoSize = true;
            this.chkMBack.Enabled = false;
            this.chkMBack.ForeColor = System.Drawing.Color.Navy;
            this.chkMBack.Location = new System.Drawing.Point(580, 52);
            this.chkMBack.Name = "chkMBack";
            this.chkMBack.Size = new System.Drawing.Size(100, 19);
            this.chkMBack.TabIndex = 10;
            this.chkMBack.Text = "Checked Back";
            this.chkMBack.UseVisualStyleBackColor = true;
            this.chkMBack.CheckedChanged += new System.EventHandler(this.chkMBack_CheckedChanged);
            // 
            // chkMIssue
            // 
            this.chkMIssue.AutoSize = true;
            this.chkMIssue.Enabled = false;
            this.chkMIssue.ForeColor = System.Drawing.Color.Navy;
            this.chkMIssue.Location = new System.Drawing.Point(580, 78);
            this.chkMIssue.Name = "chkMIssue";
            this.chkMIssue.Size = new System.Drawing.Size(71, 19);
            this.chkMIssue.TabIndex = 11;
            this.chkMIssue.Text = "Problem";
            this.chkMIssue.UseVisualStyleBackColor = true;
            this.chkMIssue.CheckedChanged += new System.EventHandler(this.chkMIssue_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Enabled = false;
            this.label12.ForeColor = System.Drawing.Color.Navy;
            this.label12.Location = new System.Drawing.Point(576, 26);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(56, 15);
            this.label12.TabIndex = 12;
            this.label12.Text = "Quantity:";
            // 
            // nudMQtty
            // 
            this.nudMQtty.Enabled = false;
            this.nudMQtty.Location = new System.Drawing.Point(638, 22);
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
            // panel3
            // 
            this.panel3.Controls.Add(this.lvwMoves);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(709, 476);
            this.panel3.TabIndex = 0;
            // 
            // lvwMoves
            // 
            this.lvwMoves.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwMoves.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader5,
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader2});
            this.lvwMoves.ContextMenuStrip = this.cmsMovements;
            this.lvwMoves.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwMoves.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwMoves.FullRowSelect = true;
            this.lvwMoves.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwMoves.Location = new System.Drawing.Point(0, 0);
            this.lvwMoves.Name = "lvwMoves";
            this.lvwMoves.ShowItemToolTips = true;
            this.lvwMoves.Size = new System.Drawing.Size(709, 476);
            this.lvwMoves.TabIndex = 1;
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
            this.columnHeader1.Text = "Item";
            this.columnHeader1.Width = 415;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Serial No";
            this.columnHeader3.Width = 70;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Quantity";
            this.columnHeader4.Width = 69;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Comment";
            this.columnHeader2.Width = 111;
            // 
            // frmJob
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(210)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1025, 581);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblClosed);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.tabControl1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(557, 502);
            this.Name = "frmJob";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = " ";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmJob_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmJob_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.cmsMovements.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.gpbDetails.ResumeLayout(false);
            this.gpbDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudMQtty)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TextBox txtOpenDesk;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TextBox txtJobName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtCrew;
        private System.Windows.Forms.TextBox txtProd;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpIn;
        private System.Windows.Forms.DateTimePicker dtpOut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbCheckIn;
        private System.Windows.Forms.ToolStripSplitButton tsbPrint;
        private System.Windows.Forms.ToolStripMenuItem tsbPreview;
        private System.Windows.Forms.Label lblClosed;
        private System.Windows.Forms.ContextMenuStrip cmsMovements;
        private System.Windows.Forms.ToolStripMenuItem cmsiOpenItem;
        private System.Windows.Forms.ToolStripMenuItem cmsiCheckBack;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtCheckedBy;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPickedUpBy;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtIssuedBy;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem cmsiAddItem;
        private System.Windows.Forms.ToolStripMenuItem cmsiRemoveItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem cmsiAddCase;
        private System.Windows.Forms.ToolStripMenuItem cmsiRemoveCase;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel3;
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
    }
}
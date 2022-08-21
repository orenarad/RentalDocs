namespace EquipmentCheckOut
{
    partial class frmWiz
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lnkChange = new System.Windows.Forms.LinkLabel();
            this.lblJobName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnNext = new System.Windows.Forms.Button();
            this.btnFinished = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panStep1 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbxSelectedCases = new System.Windows.Forms.ListBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.lbxCases = new System.Windows.Forms.ListBox();
            this.txtSearchCase = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panStep2 = new System.Windows.Forms.Panel();
            this.grpItem = new System.Windows.Forms.GroupBox();
            this.lblNotice = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.nudQtty = new System.Windows.Forms.NumericUpDown();
            this.txtIncluding = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.llbChange = new System.Windows.Forms.LinkLabel();
            this.lblItem = new System.Windows.Forms.Label();
            this.llbExlude = new System.Windows.Forms.LinkLabel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.btnAddID = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.txtIDs = new System.Windows.Forms.TextBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.rbnInvoke = new System.Windows.Forms.RadioButton();
            this.rbnSearch = new System.Windows.Forms.RadioButton();
            this.lvwItems = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cboSelectedCases = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lvwSelectedItems = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsCaseItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChange = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClear = new System.Windows.Forms.ToolStripMenuItem();
            this.label9 = new System.Windows.Forms.Label();
            this.panStep3 = new System.Windows.Forms.Panel();
            this.butPreview = new System.Windows.Forms.Button();
            this.chkPrintOptions = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.nudCopies = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panStep1.SuspendLayout();
            this.panStep2.SuspendLayout();
            this.grpItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtty)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.cmsCaseItems.SuspendLayout();
            this.panStep3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCopies)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.lnkChange);
            this.panel1.Controls.Add(this.lblJobName);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(740, 84);
            this.panel1.TabIndex = 0;
            // 
            // lnkChange
            // 
            this.lnkChange.AutoSize = true;
            this.lnkChange.LinkColor = System.Drawing.Color.Gray;
            this.lnkChange.Location = new System.Drawing.Point(199, 46);
            this.lnkChange.Name = "lnkChange";
            this.lnkChange.Size = new System.Drawing.Size(56, 14);
            this.lnkChange.TabIndex = 3;
            this.lnkChange.TabStop = true;
            this.lnkChange.Text = "Change...";
            this.lnkChange.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkChange_LinkClicked);
            // 
            // lblJobName
            // 
            this.lblJobName.AutoSize = true;
            this.lblJobName.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblJobName.ForeColor = System.Drawing.Color.Navy;
            this.lblJobName.Location = new System.Drawing.Point(15, 42);
            this.lblJobName.Name = "lblJobName";
            this.lblJobName.Size = new System.Drawing.Size(175, 19);
            this.lblJobName.TabIndex = 2;
            this.lblJobName.Text = "JobName, Production";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "Equipment Checkout Wizard";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(24, 506);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnBack
            // 
            this.btnBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBack.Enabled = false;
            this.btnBack.Location = new System.Drawing.Point(398, 506);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(75, 25);
            this.btnBack.TabIndex = 2;
            this.btnBack.Text = "<< Back";
            this.btnBack.UseVisualStyleBackColor = true;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnNext
            // 
            this.btnNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNext.Enabled = false;
            this.btnNext.Location = new System.Drawing.Point(479, 506);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(75, 25);
            this.btnNext.TabIndex = 3;
            this.btnNext.Text = "Next >>";
            this.btnNext.UseVisualStyleBackColor = true;
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnFinished
            // 
            this.btnFinished.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFinished.Enabled = false;
            this.btnFinished.Location = new System.Drawing.Point(640, 506);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(75, 25);
            this.btnFinished.TabIndex = 4;
            this.btnFinished.Text = "Finish";
            this.btnFinished.UseVisualStyleBackColor = true;
            this.btnFinished.Click += new System.EventHandler(this.btnFinished_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panStep1);
            this.panel2.Controls.Add(this.panStep2);
            this.panel2.Controls.Add(this.panStep3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 84);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(740, 403);
            this.panel2.TabIndex = 5;
            // 
            // panStep1
            // 
            this.panStep1.Controls.Add(this.btnAdd);
            this.panStep1.Controls.Add(this.label4);
            this.panStep1.Controls.Add(this.label3);
            this.panStep1.Controls.Add(this.lbxSelectedCases);
            this.panStep1.Controls.Add(this.btnRemove);
            this.panStep1.Controls.Add(this.lbxCases);
            this.panStep1.Controls.Add(this.txtSearchCase);
            this.panStep1.Controls.Add(this.label2);
            this.panStep1.Location = new System.Drawing.Point(352, 6);
            this.panStep1.Name = "panStep1";
            this.panStep1.Size = new System.Drawing.Size(721, 457);
            this.panStep1.TabIndex = 0;
            this.panStep1.VisibleChanged += new System.EventHandler(this.panStep1_VisibleChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(352, 109);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(39, 25);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = ">>>";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(43, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 14);
            this.label4.TabIndex = 10;
            this.label4.Text = "Search Case";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(395, 58);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "Selected Cases:";
            // 
            // lbxSelectedCases
            // 
            this.lbxSelectedCases.FormattingEnabled = true;
            this.lbxSelectedCases.ItemHeight = 14;
            this.lbxSelectedCases.Location = new System.Drawing.Point(398, 81);
            this.lbxSelectedCases.Name = "lbxSelectedCases";
            this.lbxSelectedCases.Size = new System.Drawing.Size(300, 284);
            this.lbxSelectedCases.TabIndex = 5;
            this.lbxSelectedCases.DoubleClick += new System.EventHandler(this.lbxSelectedCases_DoubleClick);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(352, 340);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(39, 25);
            this.btnRemove.TabIndex = 4;
            this.btnRemove.Text = "<<<";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // lbxCases
            // 
            this.lbxCases.FormattingEnabled = true;
            this.lbxCases.ItemHeight = 14;
            this.lbxCases.Location = new System.Drawing.Point(46, 109);
            this.lbxCases.Name = "lbxCases";
            this.lbxCases.Size = new System.Drawing.Size(300, 256);
            this.lbxCases.Sorted = true;
            this.lbxCases.TabIndex = 2;
            this.lbxCases.DoubleClick += new System.EventHandler(this.lbxCases_DoubleClick);
            // 
            // txtSearchCase
            // 
            this.txtSearchCase.Location = new System.Drawing.Point(46, 81);
            this.txtSearchCase.Name = "txtSearchCase";
            this.txtSearchCase.Size = new System.Drawing.Size(300, 22);
            this.txtSearchCase.TabIndex = 0;
            this.txtSearchCase.TextChanged += new System.EventHandler(this.txtSearchCase_TextChanged);
            this.txtSearchCase.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCaseIDs_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(15, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 19);
            this.label2.TabIndex = 1;
            this.label2.Text = "Step 1: Choose cases.";
            // 
            // panStep2
            // 
            this.panStep2.Controls.Add(this.grpItem);
            this.panStep2.Controls.Add(this.groupBox1);
            this.panStep2.Controls.Add(this.lvwSelectedItems);
            this.panStep2.Controls.Add(this.label9);
            this.panStep2.Location = new System.Drawing.Point(12, 13);
            this.panStep2.Name = "panStep2";
            this.panStep2.Size = new System.Drawing.Size(740, 403);
            this.panStep2.TabIndex = 11;
            this.panStep2.Visible = false;
            this.panStep2.VisibleChanged += new System.EventHandler(this.panStep2_VisibleChanged);
            // 
            // grpItem
            // 
            this.grpItem.Controls.Add(this.lblNotice);
            this.grpItem.Controls.Add(this.btnUpdate);
            this.grpItem.Controls.Add(this.label14);
            this.grpItem.Controls.Add(this.nudQtty);
            this.grpItem.Controls.Add(this.txtIncluding);
            this.grpItem.Controls.Add(this.label13);
            this.grpItem.Controls.Add(this.llbChange);
            this.grpItem.Controls.Add(this.lblItem);
            this.grpItem.Controls.Add(this.llbExlude);
            this.grpItem.Location = new System.Drawing.Point(356, 257);
            this.grpItem.Name = "grpItem";
            this.grpItem.Size = new System.Drawing.Size(360, 132);
            this.grpItem.TabIndex = 6;
            this.grpItem.TabStop = false;
            this.grpItem.Text = "Selected Item";
            this.grpItem.Visible = false;
            // 
            // lblNotice
            // 
            this.lblNotice.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.lblNotice.Location = new System.Drawing.Point(0, 115);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(354, 14);
            this.lblNotice.TabIndex = 8;
            this.lblNotice.Text = "* Only first selected item will be updated";
            this.lblNotice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblNotice.Visible = false;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(260, 89);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(94, 23);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.Text = "Update List";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(254, 50);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(52, 14);
            this.label14.TabIndex = 6;
            this.label14.Text = "Quantity";
            // 
            // nudQtty
            // 
            this.nudQtty.Location = new System.Drawing.Point(312, 48);
            this.nudQtty.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudQtty.Name = "nudQtty";
            this.nudQtty.Size = new System.Drawing.Size(42, 22);
            this.nudQtty.TabIndex = 5;
            this.nudQtty.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtIncluding
            // 
            this.txtIncluding.Location = new System.Drawing.Point(79, 48);
            this.txtIncluding.Multiline = true;
            this.txtIncluding.Name = "txtIncluding";
            this.txtIncluding.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtIncluding.Size = new System.Drawing.Size(169, 64);
            this.txtIncluding.TabIndex = 4;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 51);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(58, 14);
            this.label13.TabIndex = 3;
            this.label13.Text = "Including";
            // 
            // llbChange
            // 
            this.llbChange.AutoSize = true;
            this.llbChange.Location = new System.Drawing.Point(57, 25);
            this.llbChange.Name = "llbChange";
            this.llbChange.Size = new System.Drawing.Size(56, 14);
            this.llbChange.TabIndex = 2;
            this.llbChange.TabStop = true;
            this.llbChange.Text = "Change...";
            this.llbChange.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbChange_LinkClicked);
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.Location = new System.Drawing.Point(15, 25);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(30, 14);
            this.lblItem.TabIndex = 1;
            this.lblItem.Text = "item";
            // 
            // llbExlude
            // 
            this.llbExlude.AutoSize = true;
            this.llbExlude.Location = new System.Drawing.Point(119, 25);
            this.llbExlude.Name = "llbExlude";
            this.llbExlude.Size = new System.Drawing.Size(50, 14);
            this.llbExlude.TabIndex = 0;
            this.llbExlude.TabStop = true;
            this.llbExlude.Text = "Remove";
            this.llbExlude.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbExlude_LinkClicked);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGo);
            this.groupBox1.Controls.Add(this.btnAddID);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtIDs);
            this.groupBox1.Controls.Add(this.txtSearch);
            this.groupBox1.Controls.Add(this.rbnInvoke);
            this.groupBox1.Controls.Add(this.rbnSearch);
            this.groupBox1.Controls.Add(this.lvwItems);
            this.groupBox1.Controls.Add(this.cboSelectedCases);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(21, 50);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(329, 339);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Arrange Case";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(281, 86);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(32, 25);
            this.btnGo.TabIndex = 1;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // btnAddID
            // 
            this.btnAddID.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddID.Location = new System.Drawing.Point(271, 306);
            this.btnAddID.Name = "btnAddID";
            this.btnAddID.Size = new System.Drawing.Size(42, 25);
            this.btnAddID.TabIndex = 6;
            this.btnAddID.Text = "Add";
            this.btnAddID.UseVisualStyleBackColor = true;
            this.btnAddID.Click += new System.EventHandler(this.btnAddID_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 289);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(237, 14);
            this.label8.TabIndex = 11;
            this.label8.Text = "Add Items by ID: (e.g 125+254+445+325 etc.)";
            // 
            // txtIDs
            // 
            this.txtIDs.Location = new System.Drawing.Point(21, 306);
            this.txtIDs.Name = "txtIDs";
            this.txtIDs.Size = new System.Drawing.Size(244, 22);
            this.txtIDs.TabIndex = 5;
            this.txtIDs.TextChanged += new System.EventHandler(this.txtIDs_TextChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(210)))), ((int)(((byte)(240)))));
            this.txtSearch.Enabled = false;
            this.txtSearch.Location = new System.Drawing.Point(110, 88);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(165, 22);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.EnabledChanged += new System.EventHandler(this.txtSearch_EnabledChanged);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // rbnInvoke
            // 
            this.rbnInvoke.AutoSize = true;
            this.rbnInvoke.Checked = true;
            this.rbnInvoke.Location = new System.Drawing.Point(21, 65);
            this.rbnInvoke.Name = "rbnInvoke";
            this.rbnInvoke.Size = new System.Drawing.Size(115, 18);
            this.rbnInvoke.TabIndex = 1;
            this.rbnInvoke.TabStop = true;
            this.rbnInvoke.Text = "Suggested Items";
            this.rbnInvoke.UseVisualStyleBackColor = true;
            this.rbnInvoke.CheckedChanged += new System.EventHandler(this.rbnInvoke_CheckedChanged);
            // 
            // rbnSearch
            // 
            this.rbnSearch.AutoSize = true;
            this.rbnSearch.Location = new System.Drawing.Point(21, 89);
            this.rbnSearch.Name = "rbnSearch";
            this.rbnSearch.Size = new System.Drawing.Size(89, 18);
            this.rbnSearch.TabIndex = 2;
            this.rbnSearch.Text = "Search Item";
            this.rbnSearch.UseVisualStyleBackColor = true;
            this.rbnSearch.CheckedChanged += new System.EventHandler(this.rbnSearch_CheckedChanged);
            // 
            // lvwItems
            // 
            this.lvwItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader5});
            this.lvwItems.FullRowSelect = true;
            this.lvwItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwItems.Location = new System.Drawing.Point(21, 114);
            this.lvwItems.MultiSelect = false;
            this.lvwItems.Name = "lvwItems";
            this.lvwItems.Size = new System.Drawing.Size(292, 166);
            this.lvwItems.TabIndex = 4;
            this.lvwItems.UseCompatibleStateImageBehavior = false;
            this.lvwItems.View = System.Windows.Forms.View.Details;
            this.lvwItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwItems_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Item";
            this.columnHeader1.Width = 172;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Ser No";
            this.columnHeader5.Width = 97;
            // 
            // cboSelectedCases
            // 
            this.cboSelectedCases.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSelectedCases.FormattingEnabled = true;
            this.cboSelectedCases.Location = new System.Drawing.Point(90, 31);
            this.cboSelectedCases.Name = "cboSelectedCases";
            this.cboSelectedCases.Size = new System.Drawing.Size(223, 22);
            this.cboSelectedCases.TabIndex = 0;
            this.cboSelectedCases.SelectedIndexChanged += new System.EventHandler(this.cboSelectedCases_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 34);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(36, 14);
            this.label6.TabIndex = 4;
            this.label6.Text = "Case:";
            // 
            // lvwSelectedItems
            // 
            this.lvwSelectedItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.lvwSelectedItems.ContextMenuStrip = this.cmsCaseItems;
            this.lvwSelectedItems.FullRowSelect = true;
            this.lvwSelectedItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwSelectedItems.HideSelection = false;
            this.lvwSelectedItems.Location = new System.Drawing.Point(356, 16);
            this.lvwSelectedItems.Name = "lvwSelectedItems";
            this.lvwSelectedItems.Size = new System.Drawing.Size(359, 235);
            this.lvwSelectedItems.TabIndex = 0;
            this.lvwSelectedItems.UseCompatibleStateImageBehavior = false;
            this.lvwSelectedItems.View = System.Windows.Forms.View.Details;
            this.lvwSelectedItems.SelectedIndexChanged += new System.EventHandler(this.lvwSelectedItems_SelectedIndexChanged);
            this.lvwSelectedItems.DoubleClick += new System.EventHandler(this.lvwSelectedItems_DoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Item";
            this.columnHeader2.Width = 184;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Ser No";
            this.columnHeader3.Width = 89;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Qtty";
            // 
            // cmsCaseItems
            // 
            this.cmsCaseItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenItem,
            this.tsmiChange,
            this.tsmiRemove,
            this.tsmiClear});
            this.cmsCaseItems.Name = "cmsCaseItems";
            this.cmsCaseItems.Size = new System.Drawing.Size(207, 92);
            this.cmsCaseItems.Opening += new System.ComponentModel.CancelEventHandler(this.cmsCaseItems_Opening);
            // 
            // tsmiOpenItem
            // 
            this.tsmiOpenItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsmiOpenItem.Name = "tsmiOpenItem";
            this.tsmiOpenItem.Size = new System.Drawing.Size(206, 22);
            this.tsmiOpenItem.Text = "Open Item...";
            this.tsmiOpenItem.Click += new System.EventHandler(this.tsmiOpenItem_Click);
            // 
            // tsmiChange
            // 
            this.tsmiChange.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.tsmiChange.Name = "tsmiChange";
            this.tsmiChange.Size = new System.Drawing.Size(206, 22);
            this.tsmiChange.Text = "Change Item...";
            this.tsmiChange.Click += new System.EventHandler(this.tsmiChange_Click);
            // 
            // tsmiRemove
            // 
            this.tsmiRemove.Name = "tsmiRemove";
            this.tsmiRemove.Size = new System.Drawing.Size(206, 22);
            this.tsmiRemove.Text = "Remove Item from Case";
            this.tsmiRemove.Click += new System.EventHandler(this.tsmiRemove_Click);
            // 
            // tsmiClear
            // 
            this.tsmiClear.Name = "tsmiClear";
            this.tsmiClear.Size = new System.Drawing.Size(206, 22);
            this.tsmiClear.Text = "Clear Case";
            this.tsmiClear.Click += new System.EventHandler(this.tsmiClear_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Navy;
            this.label9.Location = new System.Drawing.Point(15, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 19);
            this.label9.TabIndex = 1;
            this.label9.Text = "Step 2: Case Contents.";
            // 
            // panStep3
            // 
            this.panStep3.Controls.Add(this.butPreview);
            this.panStep3.Controls.Add(this.chkPrintOptions);
            this.panStep3.Controls.Add(this.label12);
            this.panStep3.Controls.Add(this.txtComments);
            this.panStep3.Controls.Add(this.btnPrint);
            this.panStep3.Controls.Add(this.nudCopies);
            this.panStep3.Controls.Add(this.label11);
            this.panStep3.Controls.Add(this.label10);
            this.panStep3.Location = new System.Drawing.Point(31, 133);
            this.panStep3.Name = "panStep3";
            this.panStep3.Size = new System.Drawing.Size(740, 403);
            this.panStep3.TabIndex = 1;
            this.panStep3.VisibleChanged += new System.EventHandler(this.panStep3_VisibleChanged);
            // 
            // butPreview
            // 
            this.butPreview.Location = new System.Drawing.Point(308, 256);
            this.butPreview.Name = "butPreview";
            this.butPreview.Size = new System.Drawing.Size(101, 25);
            this.butPreview.TabIndex = 10;
            this.butPreview.Text = "Print Preview";
            this.butPreview.UseVisualStyleBackColor = true;
            this.butPreview.Click += new System.EventHandler(this.butPreview_Click);
            // 
            // chkPrintOptions
            // 
            this.chkPrintOptions.AutoSize = true;
            this.chkPrintOptions.Checked = true;
            this.chkPrintOptions.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrintOptions.Location = new System.Drawing.Point(227, 232);
            this.chkPrintOptions.Name = "chkPrintOptions";
            this.chkPrintOptions.Size = new System.Drawing.Size(144, 18);
            this.chkPrintOptions.TabIndex = 9;
            this.chkPrintOptions.Text = "Show printing options";
            this.chkPrintOptions.UseVisualStyleBackColor = true;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(160, 81);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 14);
            this.label12.TabIndex = 8;
            this.label12.Text = "Comments:";
            // 
            // txtComments
            // 
            this.txtComments.Location = new System.Drawing.Point(227, 81);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(286, 103);
            this.txtComments.TabIndex = 0;
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(227, 256);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(75, 25);
            this.btnPrint.TabIndex = 2;
            this.btnPrint.Text = "Print";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // nudCopies
            // 
            this.nudCopies.Location = new System.Drawing.Point(466, 204);
            this.nudCopies.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudCopies.Name = "nudCopies";
            this.nudCopies.Size = new System.Drawing.Size(47, 22);
            this.nudCopies.TabIndex = 1;
            this.nudCopies.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(224, 206);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 14);
            this.label11.TabIndex = 4;
            this.label11.Text = "Number of Copies to print:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Navy;
            this.label10.Location = new System.Drawing.Point(15, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(179, 19);
            this.label10.TabIndex = 2;
            this.label10.Text = "Step 3: Print Delivery Note";
            // 
            // frmWiz
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(210)))), ((int)(((byte)(240)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(740, 544);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.btnFinished);
            this.Controls.Add(this.btnNext);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmWiz";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Equipment Checkout Wizard";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmWiz_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panStep1.ResumeLayout(false);
            this.panStep1.PerformLayout();
            this.panStep2.ResumeLayout(false);
            this.panStep2.PerformLayout();
            this.grpItem.ResumeLayout(false);
            this.grpItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtty)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.cmsCaseItems.ResumeLayout(false);
            this.panStep3.ResumeLayout(false);
            this.panStep3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudCopies)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnNext;
        private System.Windows.Forms.Button btnFinished;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panStep1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbxCases;
        private System.Windows.Forms.TextBox txtSearchCase;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbxSelectedCases;
        private System.Windows.Forms.LinkLabel lnkChange;
        private System.Windows.Forms.Label lblJobName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panStep2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListView lvwSelectedItems;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboSelectedCases;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbnInvoke;
        private System.Windows.Forms.RadioButton rbnSearch;
        private System.Windows.Forms.ListView lvwItems;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnAddID;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtIDs;
        private System.Windows.Forms.Panel panStep3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.NumericUpDown nudCopies;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.CheckBox chkPrintOptions;
        private System.Windows.Forms.Button butPreview;
        private System.Windows.Forms.GroupBox grpItem;
        private System.Windows.Forms.LinkLabel llbExlude;
        private System.Windows.Forms.LinkLabel llbChange;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.NumericUpDown nudQtty;
        private System.Windows.Forms.TextBox txtIncluding;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label lblNotice;
        private System.Windows.Forms.ContextMenuStrip cmsCaseItems;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiRemove;
        private System.Windows.Forms.ToolStripMenuItem tsmiClear;
        private System.Windows.Forms.ToolStripMenuItem tsmiChange;
        private System.Windows.Forms.Button btnGo;
    }
}
namespace EquipmentCheckOut
{
    partial class frmJobs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmJobs));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsddbNew = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmiNewJob = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNewCase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbDelJob = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOptions = new System.Windows.Forms.ToolStripButton();
            this.lvwJobs = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslJobs = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslItems = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslCases = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslSchedule = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSearchJob = new System.Windows.Forms.Button();
            this.txtSearchJob = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnFind = new System.Windows.Forms.Button();
            this.txtSearchItems = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnRefreshItems = new System.Windows.Forms.Button();
            this.cboJob = new System.Windows.Forms.ComboBox();
            this.chkJob = new System.Windows.Forms.CheckBox();
            this.chkProblem = new System.Windows.Forms.CheckBox();
            this.chkIn = new System.Windows.Forms.CheckBox();
            this.chkOut = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tvwItemsCats = new System.Windows.Forms.TreeView();
            this.lvwItems = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsItems = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeItemsCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiDuplicate = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tvwCaseCat = new System.Windows.Forms.TreeView();
            this.lvwCases = new System.Windows.Forms.ListView();
            this.cmsCases = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiOpenCase = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiChangeCaseCategory = new System.Windows.Forms.ToolStripMenuItem();
            this.imlCase = new System.Windows.Forms.ImageList(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tabControl2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.cmsItems.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.cmsCases.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsddbNew,
            this.tsbDelJob,
            this.toolStripSeparator2,
            this.tsbOptions});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(949, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsddbNew
            // 
            this.tsddbNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsddbNew.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNewJob,
            this.tsmiNewItem,
            this.tsmiNewCase});
            this.tsddbNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsddbNew.Name = "tsddbNew";
            this.tsddbNew.Size = new System.Drawing.Size(55, 22);
            this.tsddbNew.Text = "New...";
            this.tsddbNew.TextDirection = System.Windows.Forms.ToolStripTextDirection.Horizontal;
            this.tsddbNew.ButtonClick += new System.EventHandler(this.tsddbNew_Click);
            // 
            // tsmiNewJob
            // 
            this.tsmiNewJob.Name = "tsmiNewJob";
            this.tsmiNewJob.Size = new System.Drawing.Size(136, 22);
            this.tsmiNewJob.Text = "New Job...";
            this.tsmiNewJob.Click += new System.EventHandler(this.tsmiNewJob_Click);
            // 
            // tsmiNewItem
            // 
            this.tsmiNewItem.Name = "tsmiNewItem";
            this.tsmiNewItem.Size = new System.Drawing.Size(136, 22);
            this.tsmiNewItem.Text = "New Item...";
            this.tsmiNewItem.Click += new System.EventHandler(this.tsmiNewItem_Click);
            // 
            // tsmiNewCase
            // 
            this.tsmiNewCase.Name = "tsmiNewCase";
            this.tsmiNewCase.Size = new System.Drawing.Size(136, 22);
            this.tsmiNewCase.Text = "New Case...";
            this.tsmiNewCase.Click += new System.EventHandler(this.tsmiNewCase_Click);
            // 
            // tsbDelJob
            // 
            this.tsbDelJob.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDelJob.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelJob.Name = "tsbDelJob";
            this.tsbDelJob.Size = new System.Drawing.Size(48, 22);
            this.tsbDelJob.Text = "Delete";
            this.tsbDelJob.Click += new System.EventHandler(this.tsbDelJob_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbOptions
            // 
            this.tsbOptions.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOptions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOptions.Name = "tsbOptions";
            this.tsbOptions.Size = new System.Drawing.Size(62, 22);
            this.tsbOptions.Text = "Options...";
            this.tsbOptions.Click += new System.EventHandler(this.tsbOptions_Click);
            // 
            // lvwJobs
            // 
            this.lvwJobs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwJobs.BackColor = System.Drawing.SystemColors.Window;
            this.lvwJobs.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvwJobs.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwJobs.FullRowSelect = true;
            this.lvwJobs.Location = new System.Drawing.Point(9, 48);
            this.lvwJobs.MultiSelect = false;
            this.lvwJobs.Name = "lvwJobs";
            this.lvwJobs.Size = new System.Drawing.Size(899, 522);
            this.lvwJobs.TabIndex = 1;
            this.lvwJobs.UseCompatibleStateImageBehavior = false;
            this.lvwJobs.View = System.Windows.Forms.View.Details;
            this.lvwJobs.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwJobs_ItemSelectionChanged);
            this.lvwJobs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwJobs_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Job Name";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Production";
            this.columnHeader2.Width = 283;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Check Out";
            this.columnHeader3.Width = 125;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Check In";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Status";
            this.columnHeader5.Width = 93;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslJobs,
            this.tslItems,
            this.tslCases,
            this.tslSchedule});
            this.statusStrip1.Location = new System.Drawing.Point(0, 676);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(949, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslJobs
            // 
            this.tslJobs.BackColor = System.Drawing.SystemColors.Control;
            this.tslJobs.Name = "tslJobs";
            this.tslJobs.Size = new System.Drawing.Size(0, 17);
            this.tslJobs.Visible = false;
            // 
            // tslItems
            // 
            this.tslItems.BackColor = System.Drawing.SystemColors.Control;
            this.tslItems.Name = "tslItems";
            this.tslItems.Size = new System.Drawing.Size(0, 17);
            this.tslItems.Visible = false;
            // 
            // tslCases
            // 
            this.tslCases.BackColor = System.Drawing.SystemColors.Control;
            this.tslCases.Name = "tslCases";
            this.tslCases.Size = new System.Drawing.Size(0, 17);
            this.tslCases.Visible = false;
            // 
            // tslSchedule
            // 
            this.tslSchedule.Name = "tslSchedule";
            this.tslSchedule.Size = new System.Drawing.Size(124, 17);
            this.tslSchedule.Text = "toolStripStatusLabel1";
            this.tslSchedule.Visible = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(12, 38);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(50, 8);
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(925, 620);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnClear);
            this.tabPage1.Controls.Add(this.btnSearchJob);
            this.tabPage1.Controls.Add(this.txtSearchJob);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.lvwJobs);
            this.tabPage1.Location = new System.Drawing.Point(4, 37);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(6, 45, 6, 6);
            this.tabPage1.Size = new System.Drawing.Size(917, 579);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Jobs";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClear.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(529, 15);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(64, 23);
            this.btnClear.TabIndex = 7;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSearchJob
            // 
            this.btnSearchJob.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnSearchJob.Enabled = false;
            this.btnSearchJob.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearchJob.Location = new System.Drawing.Point(462, 15);
            this.btnSearchJob.Name = "btnSearchJob";
            this.btnSearchJob.Size = new System.Drawing.Size(61, 23);
            this.btnSearchJob.TabIndex = 6;
            this.btnSearchJob.Text = "Search";
            this.btnSearchJob.UseVisualStyleBackColor = true;
            this.btnSearchJob.Click += new System.EventHandler(this.btnSearchJob_Click);
            // 
            // txtSearchJob
            // 
            this.txtSearchJob.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtSearchJob.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSearchJob.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchJob.Location = new System.Drawing.Point(95, 15);
            this.txtSearchJob.Name = "txtSearchJob";
            this.txtSearchJob.Size = new System.Drawing.Size(361, 22);
            this.txtSearchJob.TabIndex = 5;
            this.txtSearchJob.TextChanged += new System.EventHandler(this.txtSearchJob_TextChanged);
            this.txtSearchJob.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchJob_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.SteelBlue;
            this.label5.Location = new System.Drawing.Point(10, 14);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(79, 18);
            this.label5.TabIndex = 3;
            this.label5.Text = "Search Jobs";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.splitContainer1);
            this.tabPage2.Location = new System.Drawing.Point(4, 37);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage2.Size = new System.Drawing.Size(917, 579);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Items";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(6, 6);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.tabControl2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lvwItems);
            this.splitContainer1.Size = new System.Drawing.Size(905, 567);
            this.splitContainer1.SplitterDistance = 262;
            this.splitContainer1.TabIndex = 0;
            // 
            // tabControl2
            // 
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage5);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl2";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(262, 567);
            this.tabControl2.TabIndex = 1;
            this.tabControl2.SelectedIndexChanged += new System.EventHandler(this.tabControl2_SelectedIndexChanged);
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnFind);
            this.tabPage4.Controls.Add(this.txtSearchItems);
            this.tabPage4.Controls.Add(this.label2);
            this.tabPage4.Controls.Add(this.btnRefreshItems);
            this.tabPage4.Controls.Add(this.cboJob);
            this.tabPage4.Controls.Add(this.chkJob);
            this.tabPage4.Controls.Add(this.chkProblem);
            this.tabPage4.Controls.Add(this.chkIn);
            this.tabPage4.Controls.Add(this.chkOut);
            this.tabPage4.Controls.Add(this.label1);
            this.tabPage4.Location = new System.Drawing.Point(4, 27);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(254, 536);
            this.tabPage4.TabIndex = 0;
            this.tabPage4.Text = "Filter";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Enabled = false;
            this.btnFind.Location = new System.Drawing.Point(185, 32);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(42, 23);
            this.btnFind.TabIndex = 11;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // txtSearchItems
            // 
            this.txtSearchItems.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearchItems.Location = new System.Drawing.Point(32, 32);
            this.txtSearchItems.Name = "txtSearchItems";
            this.txtSearchItems.Size = new System.Drawing.Size(147, 26);
            this.txtSearchItems.TabIndex = 10;
            this.txtSearchItems.TextChanged += new System.EventHandler(this.txtSearchItems_TextChanged);
            this.txtSearchItems.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearchItems_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 18);
            this.label2.TabIndex = 9;
            this.label2.Text = "Search for Items:";
            // 
            // btnRefreshItems
            // 
            this.btnRefreshItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshItems.Location = new System.Drawing.Point(152, 495);
            this.btnRefreshItems.Name = "btnRefreshItems";
            this.btnRefreshItems.Size = new System.Drawing.Size(75, 23);
            this.btnRefreshItems.TabIndex = 8;
            this.btnRefreshItems.Text = "Refresh";
            this.btnRefreshItems.UseVisualStyleBackColor = true;
            this.btnRefreshItems.Click += new System.EventHandler(this.btnRefreshItems_Click);
            // 
            // cboJob
            // 
            this.cboJob.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboJob.Enabled = false;
            this.cboJob.FormattingEnabled = true;
            this.cboJob.Location = new System.Drawing.Point(39, 316);
            this.cboJob.Name = "cboJob";
            this.cboJob.Size = new System.Drawing.Size(188, 26);
            this.cboJob.TabIndex = 7;
            // 
            // chkJob
            // 
            this.chkJob.AutoSize = true;
            this.chkJob.Enabled = false;
            this.chkJob.Location = new System.Drawing.Point(39, 291);
            this.chkJob.Name = "chkJob";
            this.chkJob.Size = new System.Drawing.Size(77, 22);
            this.chkJob.TabIndex = 6;
            this.chkJob.Text = "In a Job:";
            this.chkJob.UseVisualStyleBackColor = true;
            // 
            // chkProblem
            // 
            this.chkProblem.AutoSize = true;
            this.chkProblem.Location = new System.Drawing.Point(39, 239);
            this.chkProblem.Name = "chkProblem";
            this.chkProblem.Size = new System.Drawing.Size(115, 22);
            this.chkProblem.TabIndex = 5;
            this.chkProblem.Text = "Has a Problem";
            this.chkProblem.UseVisualStyleBackColor = true;
            this.chkProblem.CheckedChanged += new System.EventHandler(this.chkOut_CheckedChanged);
            // 
            // chkIn
            // 
            this.chkIn.AutoSize = true;
            this.chkIn.Location = new System.Drawing.Point(39, 187);
            this.chkIn.Name = "chkIn";
            this.chkIn.Size = new System.Drawing.Size(81, 22);
            this.chkIn.TabIndex = 3;
            this.chkIn.Text = "In House";
            this.chkIn.UseVisualStyleBackColor = true;
            this.chkIn.CheckedChanged += new System.EventHandler(this.chkOut_CheckedChanged);
            // 
            // chkOut
            // 
            this.chkOut.AutoSize = true;
            this.chkOut.Checked = true;
            this.chkOut.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkOut.Location = new System.Drawing.Point(39, 152);
            this.chkOut.Name = "chkOut";
            this.chkOut.Size = new System.Drawing.Size(106, 22);
            this.chkOut.TabIndex = 2;
            this.chkOut.Text = "Checked Out";
            this.chkOut.UseVisualStyleBackColor = true;
            this.chkOut.CheckedChanged += new System.EventHandler(this.chkOut_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 18);
            this.label1.TabIndex = 1;
            this.label1.Text = "Show only Items that are:";
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.tvwItemsCats);
            this.tabPage5.Location = new System.Drawing.Point(4, 27);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(254, 536);
            this.tabPage5.TabIndex = 1;
            this.tabPage5.Text = "Categories";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // tvwItemsCats
            // 
            this.tvwItemsCats.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwItemsCats.HideSelection = false;
            this.tvwItemsCats.Location = new System.Drawing.Point(3, 3);
            this.tvwItemsCats.Name = "tvwItemsCats";
            this.tvwItemsCats.Size = new System.Drawing.Size(248, 530);
            this.tvwItemsCats.TabIndex = 0;
            this.tvwItemsCats.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwCategories_AfterSelect);
            // 
            // lvwItems
            // 
            this.lvwItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10});
            this.lvwItems.ContextMenuStrip = this.cmsItems;
            this.lvwItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwItems.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwItems.FullRowSelect = true;
            this.lvwItems.HideSelection = false;
            this.lvwItems.Location = new System.Drawing.Point(0, 0);
            this.lvwItems.Name = "lvwItems";
            this.lvwItems.Size = new System.Drawing.Size(639, 567);
            this.lvwItems.TabIndex = 0;
            this.lvwItems.UseCompatibleStateImageBehavior = false;
            this.lvwItems.View = System.Windows.Forms.View.Details;
            this.lvwItems.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwItems_ItemSelectionChanged);
            this.lvwItems.DoubleClick += new System.EventHandler(this.lvwItems_DoubleClick);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "ID";
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Item";
            this.columnHeader7.Width = 188;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Serial Number";
            this.columnHeader8.Width = 103;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Status";
            this.columnHeader9.Width = 113;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "Def. Case";
            this.columnHeader10.Width = 134;
            // 
            // cmsItems
            // 
            this.cmsItems.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenItem,
            this.tsmiChangeItemsCategory,
            this.toolStripMenuItem1,
            this.tsmiDuplicate});
            this.cmsItems.Name = "cmsItems";
            this.cmsItems.Size = new System.Drawing.Size(211, 76);
            this.cmsItems.Opening += new System.ComponentModel.CancelEventHandler(this.cmsItems_Opening);
            // 
            // tsmiOpenItem
            // 
            this.tsmiOpenItem.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsmiOpenItem.Name = "tsmiOpenItem";
            this.tsmiOpenItem.Size = new System.Drawing.Size(210, 22);
            this.tsmiOpenItem.Text = "Open Item...";
            this.tsmiOpenItem.Click += new System.EventHandler(this.openItemToolStripMenuItem_Click);
            // 
            // tsmiChangeItemsCategory
            // 
            this.tsmiChangeItemsCategory.Name = "tsmiChangeItemsCategory";
            this.tsmiChangeItemsCategory.Size = new System.Drawing.Size(210, 22);
            this.tsmiChangeItemsCategory.Text = "Change Item\'s Category...";
            this.tsmiChangeItemsCategory.Click += new System.EventHandler(this.tsmiChangeItemsCategory_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(207, 6);
            // 
            // tsmiDuplicate
            // 
            this.tsmiDuplicate.Name = "tsmiDuplicate";
            this.tsmiDuplicate.Size = new System.Drawing.Size(210, 22);
            this.tsmiDuplicate.Text = "Duplicate Item...";
            this.tsmiDuplicate.Click += new System.EventHandler(this.tsmiDuplicate_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.splitContainer2);
            this.tabPage3.Location = new System.Drawing.Point(4, 37);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(6);
            this.tabPage3.Size = new System.Drawing.Size(917, 579);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Cases";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(6, 6);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tvwCaseCat);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.lvwCases);
            this.splitContainer2.Size = new System.Drawing.Size(905, 567);
            this.splitContainer2.SplitterDistance = 299;
            this.splitContainer2.TabIndex = 1;
            // 
            // tvwCaseCat
            // 
            this.tvwCaseCat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwCaseCat.HideSelection = false;
            this.tvwCaseCat.Location = new System.Drawing.Point(0, 0);
            this.tvwCaseCat.Name = "tvwCaseCat";
            this.tvwCaseCat.Size = new System.Drawing.Size(299, 567);
            this.tvwCaseCat.TabIndex = 2;
            this.tvwCaseCat.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwCaseCat_AfterSelect);
            // 
            // lvwCases
            // 
            this.lvwCases.ContextMenuStrip = this.cmsCases;
            this.lvwCases.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvwCases.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvwCases.HideSelection = false;
            this.lvwCases.LargeImageList = this.imlCase;
            this.lvwCases.Location = new System.Drawing.Point(0, 0);
            this.lvwCases.Name = "lvwCases";
            this.lvwCases.Size = new System.Drawing.Size(602, 567);
            this.lvwCases.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwCases.TabIndex = 1;
            this.lvwCases.TileSize = new System.Drawing.Size(300, 54);
            this.lvwCases.UseCompatibleStateImageBehavior = false;
            this.lvwCases.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.lvwCases_ItemSelectionChanged);
            this.lvwCases.DoubleClick += new System.EventHandler(this.lvwCases_DoubleClick);
            // 
            // cmsCases
            // 
            this.cmsCases.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiOpenCase,
            this.tsmiChangeCaseCategory});
            this.cmsCases.Name = "cmsItems";
            this.cmsCases.Size = new System.Drawing.Size(212, 48);
            // 
            // tsmiOpenCase
            // 
            this.tsmiOpenCase.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold);
            this.tsmiOpenCase.Name = "tsmiOpenCase";
            this.tsmiOpenCase.Size = new System.Drawing.Size(211, 22);
            this.tsmiOpenCase.Text = "Open Case...";
            this.tsmiOpenCase.Click += new System.EventHandler(this.tsmiOpenCase_Click);
            // 
            // tsmiChangeCaseCategory
            // 
            this.tsmiChangeCaseCategory.Name = "tsmiChangeCaseCategory";
            this.tsmiChangeCaseCategory.Size = new System.Drawing.Size(211, 22);
            this.tsmiChangeCaseCategory.Text = "Change Case\'s Category...";
            this.tsmiChangeCaseCategory.Click += new System.EventHandler(this.tsmiChangeCaseCategory_Click);
            // 
            // imlCase
            // 
            this.imlCase.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imlCase.ImageStream")));
            this.imlCase.TransparentColor = System.Drawing.Color.Transparent;
            this.imlCase.Images.SetKeyName(0, "Flight-Case-18x18x19-1_jpg59a53705-c2ba-445c-a5c1-ae451d641245Large.jpg");
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(848, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 14);
            this.label4.TabIndex = 4;
            this.label4.Text = "VS2013 08.06.14";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // frmJobs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(210)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(949, 698);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.toolStrip1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "frmJobs";
            this.ShowIcon = false;
            this.Text = "Equipment Checkout";
            this.Load += new System.EventHandler(this.frmJobs_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tabControl2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.cmsItems.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.cmsCases.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ListView lvwJobs;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView tvwItemsCats;
        private System.Windows.Forms.ListView lvwItems;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TreeView tvwCaseCat;
        private System.Windows.Forms.ListView lvwCases;
        private System.Windows.Forms.ImageList imlCase;
        private System.Windows.Forms.ToolStripButton tsbOptions;
        private System.Windows.Forms.ContextMenuStrip cmsItems;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeItemsCategory;
        private System.Windows.Forms.ContextMenuStrip cmsCases;
        private System.Windows.Forms.ToolStripMenuItem tsmiOpenCase;
        private System.Windows.Forms.ToolStripMenuItem tsmiChangeCaseCategory;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ToolStripStatusLabel tslJobs;
        private System.Windows.Forms.ToolStripStatusLabel tslItems;
        private System.Windows.Forms.ToolStripStatusLabel tslCases;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiDuplicate;
        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.CheckBox chkIn;
        private System.Windows.Forms.CheckBox chkOut;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkProblem;
        private System.Windows.Forms.ComboBox cboJob;
        private System.Windows.Forms.CheckBox chkJob;
        private System.Windows.Forms.Button btnRefreshItems;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.TextBox txtSearchItems;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ToolStripButton tsbDelJob;
        private System.Windows.Forms.ToolStripSplitButton tsddbNew;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewJob;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiNewCase;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripStatusLabel tslSchedule;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TextBox txtSearchJob;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSearchJob;
        private System.Windows.Forms.Button btnClear;
    }
}


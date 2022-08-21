namespace EquipmentCheckOut
{
    partial class mainUi
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainUi));
            this.panLogIn = new System.Windows.Forms.Panel();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.btnLogIn = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLoginFail = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tmrIdle = new System.Windows.Forms.Timer(this.components);
            this.panTopNenu = new System.Windows.Forms.Panel();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnNew = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picPref = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblUser = new System.Windows.Forms.Label();
            this.picLogout = new System.Windows.Forms.PictureBox();
            this.panLeftMenu = new System.Windows.Forms.Panel();
            this.lbxFolders = new System.Windows.Forms.ListBox();
            this.panClient = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ctlCheckOut = new EquipmentCheckOut.ctlCheckOut();
            this.ctlDocs = new EquipmentCheckOut.ctlDocuments();
            this.ctlProjects = new EquipmentCheckOut.ctlProjects();
            this.ctlClients = new EquipmentCheckOut.ctlClients();
            this.ctlCatalog = new EquipmentCheckOut.ctlCatalog();
            this.ctlAdmin = new EquipmentCheckOut.ctlAdmin();
            this.panLogIn.SuspendLayout();
            this.panTopNenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPref)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).BeginInit();
            this.panLeftMenu.SuspendLayout();
            this.panClient.SuspendLayout();
            this.SuspendLayout();
            // 
            // panLogIn
            // 
            this.panLogIn.Controls.Add(this.linkLabel1);
            this.panLogIn.Controls.Add(this.btnLogIn);
            this.panLogIn.Controls.Add(this.txtPassword);
            this.panLogIn.Controls.Add(this.txtUsername);
            this.panLogIn.Controls.Add(this.label5);
            this.panLogIn.Controls.Add(this.label4);
            this.panLogIn.Controls.Add(this.lblLoginFail);
            this.panLogIn.Controls.Add(this.label3);
            this.panLogIn.Location = new System.Drawing.Point(92, 354);
            this.panLogIn.Name = "panLogIn";
            this.panLogIn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panLogIn.Size = new System.Drawing.Size(43, 21);
            this.panLogIn.TabIndex = 1;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(4, 7);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(43, 15);
            this.linkLabel1.TabIndex = 5;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "login...";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // btnLogIn
            // 
            this.btnLogIn.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLogIn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogIn.Location = new System.Drawing.Point(-123, 51);
            this.btnLogIn.Name = "btnLogIn";
            this.btnLogIn.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnLogIn.Size = new System.Drawing.Size(75, 23);
            this.btnLogIn.TabIndex = 4;
            this.btnLogIn.Text = "כניסה";
            this.btnLogIn.UseVisualStyleBackColor = true;
            this.btnLogIn.Click += new System.EventHandler(this.btnLogIn_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPassword.Location = new System.Drawing.Point(-123, 22);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtPassword.Size = new System.Drawing.Size(286, 23);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyUp);
            // 
            // txtUsername
            // 
            this.txtUsername.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtUsername.Location = new System.Drawing.Point(-123, -23);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.txtUsername.Size = new System.Drawing.Size(286, 23);
            this.txtUsername.TabIndex = 2;
            this.txtUsername.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtUsername_KeyUp);
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(121, 4);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(45, 15);
            this.label5.TabIndex = 1;
            this.label5.Text = "סיסמא:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(93, -41);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(73, 15);
            this.label4.TabIndex = 1;
            this.label4.Text = "שם משתמש:";
            // 
            // lblLoginFail
            // 
            this.lblLoginFail.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblLoginFail.AutoSize = true;
            this.lblLoginFail.ForeColor = System.Drawing.Color.Red;
            this.lblLoginFail.Location = new System.Drawing.Point(-76, 99);
            this.lblLoginFail.Name = "lblLoginFail";
            this.lblLoginFail.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblLoginFail.Size = new System.Drawing.Size(242, 15);
            this.lblLoginFail.TabIndex = 0;
            this.lblLoginFail.Text = "שם המשתמש או הסיסמא שהוקשו אינם נכונים";
            this.lblLoginFail.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-123, -87);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(289, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "על מנת להכנס למערכת אנא הזינו שם משתמש וסיסמא";
            // 
            // tmrIdle
            // 
            this.tmrIdle.Tick += new System.EventHandler(this.tmrIdle_Tick);
            // 
            // panTopNenu
            // 
            this.panTopNenu.BackColor = System.Drawing.Color.LightGray;
            this.panTopNenu.Controls.Add(this.label1);
            this.panTopNenu.Controls.Add(this.btnRefresh);
            this.panTopNenu.Controls.Add(this.btnExport);
            this.panTopNenu.Controls.Add(this.btnEdit);
            this.panTopNenu.Controls.Add(this.btnNew);
            this.panTopNenu.Controls.Add(this.panel1);
            this.panTopNenu.Controls.Add(this.pictureBox1);
            this.panTopNenu.Controls.Add(this.lblUser);
            this.panTopNenu.Controls.Add(this.picLogout);
            this.panTopNenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panTopNenu.Location = new System.Drawing.Point(0, 0);
            this.panTopNenu.Name = "panTopNenu";
            this.panTopNenu.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panTopNenu.Size = new System.Drawing.Size(1237, 35);
            this.panTopNenu.TabIndex = 0;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnRefresh.Location = new System.Drawing.Point(990, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 28);
            this.btnRefresh.TabIndex = 0;
            this.btnRefresh.Text = "רענן";
            this.btnRefresh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExport.Location = new System.Drawing.Point(750, 3);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(75, 28);
            this.btnExport.TabIndex = 3;
            this.btnExport.Text = "יצא";
            this.btnExport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEdit.Location = new System.Drawing.Point(830, 3);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 28);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "ערוך";
            this.btnEdit.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::EquipmentCheckOut.Properties.Resources.ADD;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(910, 3);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(75, 28);
            this.btnNew.TabIndex = 1;
            this.btnNew.Text = "חדש";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.panel1.Controls.Add(this.picPref);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(35, 35);
            this.panel1.TabIndex = 4;
            // 
            // picPref
            // 
            this.picPref.BackColor = System.Drawing.Color.Transparent;
            this.picPref.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPref.Image = ((System.Drawing.Image)(resources.GetObject("picPref.Image")));
            this.picPref.Location = new System.Drawing.Point(5, 5);
            this.picPref.Name = "picPref";
            this.picPref.Size = new System.Drawing.Size(25, 25);
            this.picPref.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picPref.TabIndex = 4;
            this.picPref.TabStop = false;
            this.picPref.Click += new System.EventHandler(this.picPref_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1164, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(70, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Location = new System.Drawing.Point(72, 9);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(38, 15);
            this.lblUser.TabIndex = 1;
            this.lblUser.Text = "label1";
            // 
            // picLogout
            // 
            this.picLogout.BackColor = System.Drawing.Color.Transparent;
            this.picLogout.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogout.Image = ((System.Drawing.Image)(resources.GetObject("picLogout.Image")));
            this.picLogout.Location = new System.Drawing.Point(41, 6);
            this.picLogout.Name = "picLogout";
            this.picLogout.Size = new System.Drawing.Size(25, 25);
            this.picLogout.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLogout.TabIndex = 0;
            this.picLogout.TabStop = false;
            this.picLogout.Click += new System.EventHandler(this.picLogout_Click);
            // 
            // panLeftMenu
            // 
            this.panLeftMenu.Controls.Add(this.lbxFolders);
            this.panLeftMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.panLeftMenu.Location = new System.Drawing.Point(1068, 35);
            this.panLeftMenu.Name = "panLeftMenu";
            this.panLeftMenu.Size = new System.Drawing.Size(169, 571);
            this.panLeftMenu.TabIndex = 3;
            // 
            // lbxFolders
            // 
            this.lbxFolders.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbxFolders.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbxFolders.Font = new System.Drawing.Font("Segoe UI", 15F);
            this.lbxFolders.FormattingEnabled = true;
            this.lbxFolders.ItemHeight = 28;
            this.lbxFolders.Items.AddRange(new object[] {
            "מחירון ציוד",
            "הצעות מחיר",
            "תעודות משלוח",
            "תעודות החזרה",
            "Checkout"});
            this.lbxFolders.Location = new System.Drawing.Point(0, 0);
            this.lbxFolders.Name = "lbxFolders";
            this.lbxFolders.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbxFolders.Size = new System.Drawing.Size(169, 364);
            this.lbxFolders.TabIndex = 0;
            this.lbxFolders.SelectedIndexChanged += new System.EventHandler(this.lbxFolders_SelectedIndexChanged);
            // 
            // panClient
            // 
            this.panClient.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panClient.Controls.Add(this.ctlCheckOut);
            this.panClient.Controls.Add(this.ctlDocs);
            this.panClient.Controls.Add(this.ctlProjects);
            this.panClient.Controls.Add(this.ctlClients);
            this.panClient.Controls.Add(this.ctlCatalog);
            this.panClient.Controls.Add(this.ctlAdmin);
            this.panClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panClient.Location = new System.Drawing.Point(0, 35);
            this.panClient.Name = "panClient";
            this.panClient.Size = new System.Drawing.Size(1068, 571);
            this.panClient.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.SteelBlue;
            this.label1.Location = new System.Drawing.Point(344, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 5;
            this.label1.Text = "AZURE";
            this.label1.Visible = false;
            // 
            // ctlCheckOut
            // 
            this.ctlCheckOut.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlCheckOut.Cursor = System.Windows.Forms.Cursors.Default;
            this.ctlCheckOut.FolderID = 11;
            this.ctlCheckOut.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ctlCheckOut.Location = new System.Drawing.Point(12, 131);
            this.ctlCheckOut.Name = "ctlCheckOut";
            this.ctlCheckOut.Size = new System.Drawing.Size(749, 93);
            this.ctlCheckOut.TabIndex = 5;
            this.ctlCheckOut.Visible = false;
            // 
            // ctlDocs
            // 
            this.ctlDocs.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlDocs.Cursor = System.Windows.Forms.Cursors.Default;
            this.ctlDocs.FolderID = 10;
            this.ctlDocs.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ctlDocs.Location = new System.Drawing.Point(12, 230);
            this.ctlDocs.Name = "ctlDocs";
            this.ctlDocs.Size = new System.Drawing.Size(749, 42);
            this.ctlDocs.TabIndex = 4;
            this.ctlDocs.Visible = false;
            // 
            // ctlProjects
            // 
            this.ctlProjects.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlProjects.Cursor = System.Windows.Forms.Cursors.Default;
            this.ctlProjects.FolderID = 9;
            this.ctlProjects.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ctlProjects.Location = new System.Drawing.Point(12, 278);
            this.ctlProjects.Name = "ctlProjects";
            this.ctlProjects.Size = new System.Drawing.Size(749, 39);
            this.ctlProjects.TabIndex = 3;
            this.ctlProjects.Visible = false;
            // 
            // ctlClients
            // 
            this.ctlClients.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlClients.Cursor = System.Windows.Forms.Cursors.Default;
            this.ctlClients.FolderID = 8;
            this.ctlClients.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ctlClients.Location = new System.Drawing.Point(393, 323);
            this.ctlClients.Name = "ctlClients";
            this.ctlClients.Size = new System.Drawing.Size(368, 52);
            this.ctlClients.TabIndex = 2;
            this.ctlClients.Visible = false;
            // 
            // ctlCatalog
            // 
            this.ctlCatalog.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlCatalog.Cursor = System.Windows.Forms.Cursors.Default;
            this.ctlCatalog.FolderID = 1;
            this.ctlCatalog.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ctlCatalog.Location = new System.Drawing.Point(12, 323);
            this.ctlCatalog.Name = "ctlCatalog";
            this.ctlCatalog.Size = new System.Drawing.Size(342, 61);
            this.ctlCatalog.TabIndex = 1;
            this.ctlCatalog.Visible = false;
            // 
            // ctlAdmin
            // 
            this.ctlAdmin.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ctlAdmin.FolderID = 6;
            this.ctlAdmin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.ctlAdmin.Location = new System.Drawing.Point(12, 6);
            this.ctlAdmin.Name = "ctlAdmin";
            this.ctlAdmin.Size = new System.Drawing.Size(497, 58);
            this.ctlAdmin.TabIndex = 0;
            this.ctlAdmin.Visible = false;
            // 
            // mainUi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1237, 606);
            this.Controls.Add(this.panLogIn);
            this.Controls.Add(this.panClient);
            this.Controls.Add(this.panLeftMenu);
            this.Controls.Add(this.panTopNenu);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(740, 370);
            this.Name = "mainUi";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.mainUi_FormClosing);
            this.Load += new System.EventHandler(this.mainUi_Load);
            this.Resize += new System.EventHandler(this.mainUi_Resize);
            this.panLogIn.ResumeLayout(false);
            this.panLogIn.PerformLayout();
            this.panTopNenu.ResumeLayout(false);
            this.panTopNenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPref)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLogout)).EndInit();
            this.panLeftMenu.ResumeLayout(false);
            this.panClient.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panLogIn;
        private System.Windows.Forms.Button btnLogIn;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblLoginFail;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer tmrIdle;
        private System.Windows.Forms.Panel panTopNenu;
        private System.Windows.Forms.Panel panLeftMenu;
        private System.Windows.Forms.Panel panClient;
        private System.Windows.Forms.ListBox lbxFolders;
        private System.Windows.Forms.PictureBox picLogout;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picPref;
        private ctlAdmin ctlAdmin;
        private ctlCatalog ctlCatalog;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnEdit;
        private ctlClients ctlClients;
        private ctlProjects ctlProjects;
        private ctlDocuments ctlDocs;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Button btnRefresh;
        private ctlCheckOut ctlCheckOut;
        private System.Windows.Forms.Label label1;


    }
}
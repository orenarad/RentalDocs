namespace EquipmentCheckOut
{
    partial class ctlAdmin
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlAdmin));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            this.btnCUCats = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.btnEditUser = new System.Windows.Forms.Button();
            this.btnAddUser = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lvwButtons = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.lvwFolders = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.lbxUser = new System.Windows.Forms.ListBox();
            this.btnFolders = new System.Windows.Forms.Button();
            this.userBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblLHFile = new System.Windows.Forms.Label();
            this.btnLHBrowse = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnCUCats
            // 
            this.btnCUCats.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCUCats.Location = new System.Drawing.Point(122, 25);
            this.btnCUCats.Name = "btnCUCats";
            this.btnCUCats.Size = new System.Drawing.Size(169, 35);
            this.btnCUCats.TabIndex = 2;
            this.btnCUCats.Text = "CheckOut Categories...";
            this.btnCUCats.UseVisualStyleBackColor = true;
            this.btnCUCats.Click += new System.EventHandler(this.btnCUCats_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnCUCats);
            this.groupBox1.Location = new System.Drawing.Point(20, 249);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(811, 74);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Checkout Settings:";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnDeleteUser);
            this.groupBox2.Controls.Add(this.btnEditUser);
            this.groupBox2.Controls.Add(this.btnAddUser);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.lvwButtons);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lvwFolders);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.lbxUser);
            this.groupBox2.Controls.Add(this.btnFolders);
            this.groupBox2.Location = new System.Drawing.Point(20, 14);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(811, 229);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Users and Permissions";
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteUser.Image = ((System.Drawing.Image)(resources.GetObject("btnDeleteUser.Image")));
            this.btnDeleteUser.Location = new System.Drawing.Point(95, 178);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(30, 34);
            this.btnDeleteUser.TabIndex = 13;
            this.btnDeleteUser.UseCompatibleTextRendering = true;
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // btnEditUser
            // 
            this.btnEditUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditUser.Image = ((System.Drawing.Image)(resources.GetObject("btnEditUser.Image")));
            this.btnEditUser.Location = new System.Drawing.Point(59, 178);
            this.btnEditUser.Name = "btnEditUser";
            this.btnEditUser.Size = new System.Drawing.Size(30, 34);
            this.btnEditUser.TabIndex = 12;
            this.btnEditUser.UseCompatibleTextRendering = true;
            this.btnEditUser.UseVisualStyleBackColor = true;
            this.btnEditUser.Click += new System.EventHandler(this.btnEditUser_Click);
            // 
            // btnAddUser
            // 
            this.btnAddUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddUser.Image = global::EquipmentCheckOut.Properties.Resources.ADD;
            this.btnAddUser.Location = new System.Drawing.Point(23, 178);
            this.btnAddUser.Name = "btnAddUser";
            this.btnAddUser.Size = new System.Drawing.Size(30, 34);
            this.btnAddUser.TabIndex = 11;
            this.btnAddUser.UseCompatibleTextRendering = true;
            this.btnAddUser.UseVisualStyleBackColor = true;
            this.btnAddUser.Click += new System.EventHandler(this.btnAddUser_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(454, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(114, 17);
            this.label3.TabIndex = 10;
            this.label3.Text = "Permitted Buttons:";
            // 
            // lvwButtons
            // 
            this.lvwButtons.CheckBoxes = true;
            this.lvwButtons.FullRowSelect = true;
            this.lvwButtons.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwButtons.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            this.lvwButtons.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.lvwButtons.Location = new System.Drawing.Point(457, 54);
            this.lvwButtons.MultiSelect = false;
            this.lvwButtons.Name = "lvwButtons";
            this.lvwButtons.ShowGroups = false;
            this.lvwButtons.Size = new System.Drawing.Size(130, 157);
            this.lvwButtons.TabIndex = 9;
            this.lvwButtons.UseCompatibleStateImageBehavior = false;
            this.lvwButtons.View = System.Windows.Forms.View.List;
            this.lvwButtons.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwButtons_ItemChecked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Permitted Folders:";
            // 
            // lvwFolders
            // 
            this.lvwFolders.CheckBoxes = true;
            this.lvwFolders.FullRowSelect = true;
            this.lvwFolders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lvwFolders.HideSelection = false;
            this.lvwFolders.Location = new System.Drawing.Point(149, 54);
            this.lvwFolders.MultiSelect = false;
            this.lvwFolders.Name = "lvwFolders";
            this.lvwFolders.ShowGroups = false;
            this.lvwFolders.Size = new System.Drawing.Size(288, 157);
            this.lvwFolders.TabIndex = 7;
            this.lvwFolders.UseCompatibleStateImageBehavior = false;
            this.lvwFolders.View = System.Windows.Forms.View.List;
            this.lvwFolders.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwFolders_ItemChecked);
            this.lvwFolders.SelectedIndexChanged += new System.EventHandler(this.lvwFolders_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Select User:";
            // 
            // lbxUser
            // 
            this.lbxUser.FormattingEnabled = true;
            this.lbxUser.ItemHeight = 17;
            this.lbxUser.Location = new System.Drawing.Point(23, 54);
            this.lbxUser.Name = "lbxUser";
            this.lbxUser.Size = new System.Drawing.Size(102, 106);
            this.lbxUser.TabIndex = 5;
            this.lbxUser.SelectedIndexChanged += new System.EventHandler(this.lbxUser_SelectedIndexChanged);
            // 
            // btnFolders
            // 
            this.btnFolders.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFolders.Location = new System.Drawing.Point(612, 177);
            this.btnFolders.Name = "btnFolders";
            this.btnFolders.Size = new System.Drawing.Size(78, 34);
            this.btnFolders.TabIndex = 4;
            this.btnFolders.Text = "Folders...";
            this.btnFolders.UseVisualStyleBackColor = true;
            this.btnFolders.Click += new System.EventHandler(this.btnFolders_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btnLHBrowse);
            this.groupBox3.Controls.Add(this.lblLHFile);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Location = new System.Drawing.Point(20, 329);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(811, 74);
            this.groupBox3.TabIndex = 5;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Letter Head";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Letter Head File:";
            // 
            // lblLHFile
            // 
            this.lblLHFile.AutoSize = true;
            this.lblLHFile.Location = new System.Drawing.Point(143, 33);
            this.lblLHFile.Name = "lblLHFile";
            this.lblLHFile.Size = new System.Drawing.Size(71, 17);
            this.lblLHFile.TabIndex = 1;
            this.lblLHFile.Text = "987654321";
            // 
            // btnLHBrowse
            // 
            this.btnLHBrowse.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLHBrowse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLHBrowse.Location = new System.Drawing.Point(760, 29);
            this.btnLHBrowse.Name = "btnLHBrowse";
            this.btnLHBrowse.Size = new System.Drawing.Size(29, 25);
            this.btnLHBrowse.TabIndex = 14;
            this.btnLHBrowse.Text = "...";
            this.btnLHBrowse.UseVisualStyleBackColor = true;
            this.btnLHBrowse.Click += new System.EventHandler(this.btnLHBrowse_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // ctlAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "ctlAdmin";
            this.Size = new System.Drawing.Size(848, 464);
            this.Load += new System.EventHandler(this.ctlAdmin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.userBindingSource)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnCUCats;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnFolders;
        private System.Windows.Forms.BindingSource userBindingSource;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView lvwButtons;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvwFolders;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lbxUser;
        private System.Windows.Forms.Button btnAddUser;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.Button btnEditUser;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnLHBrowse;
        private System.Windows.Forms.Label lblLHFile;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}

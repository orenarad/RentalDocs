namespace EquipmentCheckOut
{
    partial class frmFolders
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.chkShowInMenu = new System.Windows.Forms.CheckBox();
            this.txtFolderName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.lbxFolders = new System.Windows.Forms.ListBox();
            this.txtOrder = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.chkIsDocument = new System.Windows.Forms.CheckBox();
            this.chkPrintable = new System.Windows.Forms.CheckBox();
            this.txtDocTerms = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(159, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 15);
            this.label1.TabIndex = 11;
            this.label1.Text = "מס\' זיהוי:";
            // 
            // txtID
            // 
            this.txtID.Enabled = false;
            this.txtID.Location = new System.Drawing.Point(242, 12);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(67, 23);
            this.txtID.TabIndex = 1;
            // 
            // chkShowInMenu
            // 
            this.chkShowInMenu.AutoSize = true;
            this.chkShowInMenu.Checked = true;
            this.chkShowInMenu.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkShowInMenu.FlatAppearance.BorderSize = 2;
            this.chkShowInMenu.Location = new System.Drawing.Point(242, 180);
            this.chkShowInMenu.Name = "chkShowInMenu";
            this.chkShowInMenu.Size = new System.Drawing.Size(130, 19);
            this.chkShowInMenu.TabIndex = 6;
            this.chkShowInMenu.Text = "מופיע בתפריט ראשי";
            this.chkShowInMenu.UseVisualStyleBackColor = true;
            this.chkShowInMenu.Validating += new System.ComponentModel.CancelEventHandler(this.chkCheckField_Validating);
            // 
            // txtFolderName
            // 
            this.txtFolderName.Location = new System.Drawing.Point(242, 41);
            this.txtFolderName.Name = "txtFolderName";
            this.txtFolderName.Size = new System.Drawing.Size(202, 23);
            this.txtFolderName.TabIndex = 2;
            this.txtFolderName.Validating += new System.ComponentModel.CancelEventHandler(this.txtFeild_Validating);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 15);
            this.label2.TabIndex = 12;
            this.label2.Text = "שם תיקיה:";
            // 
            // txtDescription
            // 
            this.txtDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDescription.Location = new System.Drawing.Point(242, 70);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDescription.Size = new System.Drawing.Size(370, 46);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.Validating += new System.ComponentModel.CancelEventHandler(this.txtFeild_Validating);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(159, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 15);
            this.label3.TabIndex = 13;
            this.label3.Text = "תיאור:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(158, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(40, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "מקדם:";
            // 
            // txtPrefix
            // 
            this.txtPrefix.Enabled = false;
            this.txtPrefix.Location = new System.Drawing.Point(242, 122);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(107, 23);
            this.txtPrefix.TabIndex = 4;
            this.txtPrefix.Text = "0";
            this.txtPrefix.Validating += new System.ComponentModel.CancelEventHandler(this.txtFeild_Validating);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(537, 382);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 30);
            this.btnOK.TabIndex = 10;
            this.btnOK.Text = "סגור";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lbxFolders
            // 
            this.lbxFolders.Dock = System.Windows.Forms.DockStyle.Left;
            this.lbxFolders.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbxFolders.FormattingEnabled = true;
            this.lbxFolders.IntegralHeight = false;
            this.lbxFolders.ItemHeight = 21;
            this.lbxFolders.Location = new System.Drawing.Point(0, 0);
            this.lbxFolders.Name = "lbxFolders";
            this.lbxFolders.Size = new System.Drawing.Size(152, 421);
            this.lbxFolders.TabIndex = 0;
            this.lbxFolders.SelectedIndexChanged += new System.EventHandler(this.lbxFolders_SelectedIndexChanged);
            // 
            // txtOrder
            // 
            this.txtOrder.Location = new System.Drawing.Point(242, 151);
            this.txtOrder.Name = "txtOrder";
            this.txtOrder.Size = new System.Drawing.Size(107, 23);
            this.txtOrder.TabIndex = 5;
            this.txtOrder.Text = "0";
            this.txtOrder.Validating += new System.ComponentModel.CancelEventHandler(this.txtFeild_Validating);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 15);
            this.label4.TabIndex = 15;
            this.label4.Text = "סדר מיון:";
            // 
            // chkIsDocument
            // 
            this.chkIsDocument.AutoSize = true;
            this.chkIsDocument.Checked = true;
            this.chkIsDocument.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsDocument.FlatAppearance.BorderSize = 2;
            this.chkIsDocument.Location = new System.Drawing.Point(242, 205);
            this.chkIsDocument.Name = "chkIsDocument";
            this.chkIsDocument.Size = new System.Drawing.Size(57, 19);
            this.chkIsDocument.TabIndex = 7;
            this.chkIsDocument.Text = "מסמך";
            this.chkIsDocument.UseVisualStyleBackColor = true;
            this.chkIsDocument.Validating += new System.ComponentModel.CancelEventHandler(this.chkCheckField_Validating);
            // 
            // chkPrintable
            // 
            this.chkPrintable.AutoSize = true;
            this.chkPrintable.Checked = true;
            this.chkPrintable.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrintable.FlatAppearance.BorderSize = 2;
            this.chkPrintable.Location = new System.Drawing.Point(242, 230);
            this.chkPrintable.Name = "chkPrintable";
            this.chkPrintable.Size = new System.Drawing.Size(64, 19);
            this.chkPrintable.TabIndex = 8;
            this.chkPrintable.Text = "הדפסה";
            this.chkPrintable.UseVisualStyleBackColor = true;
            this.chkPrintable.Validating += new System.ComponentModel.CancelEventHandler(this.chkCheckField_Validating);
            // 
            // txtDocTerms
            // 
            this.txtDocTerms.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDocTerms.Location = new System.Drawing.Point(242, 255);
            this.txtDocTerms.Multiline = true;
            this.txtDocTerms.Name = "txtDocTerms";
            this.txtDocTerms.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDocTerms.Size = new System.Drawing.Size(370, 118);
            this.txtDocTerms.TabIndex = 9;
            this.txtDocTerms.Validating += new System.ComponentModel.CancelEventHandler(this.txtFeild_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(159, 254);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "תנאי מסמך:";
            // 
            // frmFolders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(620, 421);
            this.Controls.Add(this.txtDocTerms);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.chkPrintable);
            this.Controls.Add(this.chkIsDocument);
            this.Controls.Add(this.txtOrder);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbxFolders);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtPrefix);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtFolderName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.chkShowInMenu);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(520, 400);
            this.Name = "frmFolders";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ניהול תיקיות";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmFolders_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.CheckBox chkShowInMenu;
        private System.Windows.Forms.TextBox txtFolderName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.ListBox lbxFolders;
        private System.Windows.Forms.TextBox txtOrder;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkIsDocument;
        private System.Windows.Forms.CheckBox chkPrintable;
        private System.Windows.Forms.TextBox txtDocTerms;
        private System.Windows.Forms.Label label6;
    }
}
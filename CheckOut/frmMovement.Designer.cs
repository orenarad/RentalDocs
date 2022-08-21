namespace EquipmentCheckOut
{
    partial class frmMovement
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.llbChange = new System.Windows.Forms.LinkLabel();
            this.lblCrew = new System.Windows.Forms.Label();
            this.lblDates = new System.Windows.Forms.Label();
            this.lblJob = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lblItem = new System.Windows.Forms.Label();
            this.lblCase = new System.Windows.Forms.Label();
            this.chkBack = new System.Windows.Forms.CheckBox();
            this.nudQtty = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chkIssue = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtIncluding = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtty)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.Controls.Add(this.llbChange);
            this.panel1.Controls.Add(this.lblCrew);
            this.panel1.Controls.Add(this.lblDates);
            this.panel1.Controls.Add(this.lblJob);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lblItem);
            this.panel1.Controls.Add(this.lblCase);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(345, 173);
            this.panel1.TabIndex = 0;
            // 
            // llbChange
            // 
            this.llbChange.AutoSize = true;
            this.llbChange.Location = new System.Drawing.Point(239, 147);
            this.llbChange.Name = "llbChange";
            this.llbChange.Size = new System.Drawing.Size(84, 14);
            this.llbChange.TabIndex = 6;
            this.llbChange.TabStop = true;
            this.llbChange.Text = "Change Item...";
            this.llbChange.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.llbChange_LinkClicked);
            // 
            // lblCrew
            // 
            this.lblCrew.AutoSize = true;
            this.lblCrew.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblCrew.ForeColor = System.Drawing.Color.Navy;
            this.lblCrew.Location = new System.Drawing.Point(12, 70);
            this.lblCrew.Name = "lblCrew";
            this.lblCrew.Size = new System.Drawing.Size(38, 13);
            this.lblCrew.TabIndex = 5;
            this.lblCrew.Text = "Crew:";
            // 
            // lblDates
            // 
            this.lblDates.AutoSize = true;
            this.lblDates.ForeColor = System.Drawing.Color.Navy;
            this.lblDates.Location = new System.Drawing.Point(12, 94);
            this.lblDates.Name = "lblDates";
            this.lblDates.Size = new System.Drawing.Size(36, 14);
            this.lblDates.TabIndex = 2;
            this.lblDates.Text = "Date:";
            // 
            // lblJob
            // 
            this.lblJob.AutoSize = true;
            this.lblJob.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lblJob.ForeColor = System.Drawing.Color.Navy;
            this.lblJob.Location = new System.Drawing.Point(12, 46);
            this.lblJob.Name = "lblJob";
            this.lblJob.Size = new System.Drawing.Size(30, 13);
            this.lblJob.TabIndex = 1;
            this.lblJob.Text = "Job:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label1.Location = new System.Drawing.Point(12, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Item Movement";
            // 
            // lblItem
            // 
            this.lblItem.AutoSize = true;
            this.lblItem.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblItem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblItem.Location = new System.Drawing.Point(11, 143);
            this.lblItem.Name = "lblItem";
            this.lblItem.Size = new System.Drawing.Size(44, 19);
            this.lblItem.TabIndex = 3;
            this.lblItem.Text = "Item:";
            // 
            // lblCase
            // 
            this.lblCase.AutoSize = true;
            this.lblCase.ForeColor = System.Drawing.Color.Navy;
            this.lblCase.Location = new System.Drawing.Point(12, 119);
            this.lblCase.Name = "lblCase";
            this.lblCase.Size = new System.Drawing.Size(50, 14);
            this.lblCase.TabIndex = 4;
            this.lblCase.Text = "In Case:";
            // 
            // chkBack
            // 
            this.chkBack.AutoSize = true;
            this.chkBack.ForeColor = System.Drawing.Color.Navy;
            this.chkBack.Location = new System.Drawing.Point(116, 408);
            this.chkBack.Name = "chkBack";
            this.chkBack.Size = new System.Drawing.Size(99, 18);
            this.chkBack.TabIndex = 3;
            this.chkBack.Text = "Checked Back";
            this.chkBack.UseVisualStyleBackColor = true;
            // 
            // nudQtty
            // 
            this.nudQtty.Location = new System.Drawing.Point(116, 183);
            this.nudQtty.Name = "nudQtty";
            this.nudQtty.Size = new System.Drawing.Size(48, 22);
            this.nudQtty.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.Navy;
            this.label4.Location = new System.Drawing.Point(12, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 14);
            this.label4.TabIndex = 8;
            this.label4.Text = "Quantity:";
            // 
            // txtNotes
            // 
            this.txtNotes.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNotes.Location = new System.Drawing.Point(116, 310);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(217, 92);
            this.txtNotes.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Navy;
            this.label5.Location = new System.Drawing.Point(13, 310);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 14);
            this.label5.TabIndex = 10;
            this.label5.Text = "Notes:";
            // 
            // chkIssue
            // 
            this.chkIssue.AutoSize = true;
            this.chkIssue.ForeColor = System.Drawing.Color.Navy;
            this.chkIssue.Location = new System.Drawing.Point(116, 432);
            this.chkIssue.Name = "chkIssue";
            this.chkIssue.Size = new System.Drawing.Size(71, 18);
            this.chkIssue.TabIndex = 4;
            this.chkIssue.Text = "Problem";
            this.chkIssue.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(177, 466);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 25);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(258, 466);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtIncluding
            // 
            this.txtIncluding.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIncluding.Location = new System.Drawing.Point(116, 211);
            this.txtIncluding.Multiline = true;
            this.txtIncluding.Name = "txtIncluding";
            this.txtIncluding.Size = new System.Drawing.Size(217, 92);
            this.txtIncluding.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Navy;
            this.label2.Location = new System.Drawing.Point(13, 214);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 14);
            this.label2.TabIndex = 12;
            this.label2.Text = "Including:";
            // 
            // frmMovement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(201)))), ((int)(((byte)(210)))), ((int)(((byte)(240)))));
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(345, 504);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIncluding);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.chkIssue);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nudQtty);
            this.Controls.Add(this.chkBack);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Navy;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMovement";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Movement";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmMovement_FormClosed);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudQtty)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDates;
        private System.Windows.Forms.Label lblJob;
        private System.Windows.Forms.Label lblItem;
        private System.Windows.Forms.Label lblCase;
        private System.Windows.Forms.CheckBox chkBack;
        private System.Windows.Forms.NumericUpDown nudQtty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chkIssue;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblCrew;
        private System.Windows.Forms.TextBox txtIncluding;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.LinkLabel llbChange;
    }
}
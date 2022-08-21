namespace EquipmentCheckOut
{
    partial class frmExportSelection
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
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnPDF = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnNewDoc = new System.Windows.Forms.Button();
            this.panOptions = new System.Windows.Forms.Panel();
            this.btnOptCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnOpt3 = new System.Windows.Forms.Button();
            this.btnOpt2 = new System.Windows.Forms.Button();
            this.btnOpt1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.panOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrint.Location = new System.Drawing.Point(12, 15);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(167, 44);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "הדפס מקור";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnPDF
            // 
            this.btnPDF.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnPDF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPDF.Location = new System.Drawing.Point(12, 73);
            this.btnPDF.Name = "btnPDF";
            this.btnPDF.Size = new System.Drawing.Size(167, 44);
            this.btnPDF.TabIndex = 1;
            this.btnPDF.Text = "שמור PDF";
            this.btnPDF.UseVisualStyleBackColor = false;
            this.btnPDF.Click += new System.EventHandler(this.btnPDF_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(12, 247);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(167, 44);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "ביטול";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnExcel
            // 
            this.btnExcel.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExcel.Location = new System.Drawing.Point(12, 131);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(167, 44);
            this.btnExcel.TabIndex = 2;
            this.btnExcel.Text = "שמור Excel";
            this.btnExcel.UseVisualStyleBackColor = false;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnNewDoc
            // 
            this.btnNewDoc.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnNewDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewDoc.Location = new System.Drawing.Point(12, 189);
            this.btnNewDoc.Name = "btnNewDoc";
            this.btnNewDoc.Size = new System.Drawing.Size(167, 44);
            this.btnNewDoc.TabIndex = 3;
            this.btnNewDoc.Text = "מסמך חדש";
            this.btnNewDoc.UseVisualStyleBackColor = false;
            this.btnNewDoc.Click += new System.EventHandler(this.btnNewDoc_Click);
            // 
            // panOptions
            // 
            this.panOptions.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panOptions.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panOptions.Controls.Add(this.label2);
            this.panOptions.Controls.Add(this.btnOptCancel);
            this.panOptions.Controls.Add(this.label1);
            this.panOptions.Controls.Add(this.btnOpt3);
            this.panOptions.Controls.Add(this.btnOpt2);
            this.panOptions.Controls.Add(this.btnOpt1);
            this.panOptions.Location = new System.Drawing.Point(12, 15);
            this.panOptions.Name = "panOptions";
            this.panOptions.Size = new System.Drawing.Size(167, 276);
            this.panOptions.TabIndex = 5;
            this.panOptions.Visible = false;
            // 
            // btnOptCancel
            // 
            this.btnOptCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnOptCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOptCancel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.btnOptCancel.Location = new System.Drawing.Point(15, 222);
            this.btnOptCancel.Name = "btnOptCancel";
            this.btnOptCancel.Size = new System.Drawing.Size(136, 36);
            this.btnOptCancel.TabIndex = 6;
            this.btnOptCancel.Text = "ביטול";
            this.btnOptCancel.UseVisualStyleBackColor = false;
            this.btnOptCancel.Click += new System.EventHandler(this.btnOptCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(130, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "איזה סוג מסמך ליצור?";
            // 
            // btnOpt3
            // 
            this.btnOpt3.BackColor = System.Drawing.SystemColors.Control;
            this.btnOpt3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpt3.Location = new System.Drawing.Point(15, 177);
            this.btnOpt3.Name = "btnOpt3";
            this.btnOpt3.Size = new System.Drawing.Size(136, 36);
            this.btnOpt3.TabIndex = 4;
            this.btnOpt3.Text = "חשבון השכרה";
            this.btnOpt3.UseVisualStyleBackColor = false;
            this.btnOpt3.Click += new System.EventHandler(this.btnOpt1_Click);
            // 
            // btnOpt2
            // 
            this.btnOpt2.BackColor = System.Drawing.SystemColors.Control;
            this.btnOpt2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpt2.Location = new System.Drawing.Point(15, 132);
            this.btnOpt2.Name = "btnOpt2";
            this.btnOpt2.Size = new System.Drawing.Size(136, 36);
            this.btnOpt2.TabIndex = 3;
            this.btnOpt2.Text = "תעודת השכרה";
            this.btnOpt2.UseVisualStyleBackColor = false;
            this.btnOpt2.Click += new System.EventHandler(this.btnOpt1_Click);
            // 
            // btnOpt1
            // 
            this.btnOpt1.BackColor = System.Drawing.SystemColors.Control;
            this.btnOpt1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpt1.Location = new System.Drawing.Point(15, 87);
            this.btnOpt1.Name = "btnOpt1";
            this.btnOpt1.Size = new System.Drawing.Size(136, 36);
            this.btnOpt1.TabIndex = 2;
            this.btnOpt1.Tag = "";
            this.btnOpt1.Text = "הצעת מחיר";
            this.btnOpt1.UseVisualStyleBackColor = false;
            this.btnOpt1.Click += new System.EventHandler(this.btnOpt1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.label2.Location = new System.Drawing.Point(29, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "העתק למסמך חדש";
            // 
            // frmExportSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(191, 303);
            this.ControlBox = false;
            this.Controls.Add(this.panOptions);
            this.Controls.Add(this.btnNewDoc);
            this.Controls.Add(this.btnExcel);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPDF);
            this.Controls.Add(this.btnPrint);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmExportSelection";
            this.Opacity = 0.9D;
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmExportSelection";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmExportSelection_FormClosed);
            this.panOptions.ResumeLayout(false);
            this.panOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnPDF;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.Button btnNewDoc;
        private System.Windows.Forms.Panel panOptions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnOpt3;
        private System.Windows.Forms.Button btnOpt2;
        private System.Windows.Forms.Button btnOpt1;
        private System.Windows.Forms.Button btnOptCancel;
        private System.Windows.Forms.Label label2;
    }
}
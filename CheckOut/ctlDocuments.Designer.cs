namespace EquipmentCheckOut
{
    partial class ctlDocuments
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlDocuments));
            this.lvwDocuments = new System.Windows.Forms.ListView();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDocNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colProject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSumm = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picGo = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboClients = new System.Windows.Forms.ComboBox();
            this.cboDocType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.rdbClient = new System.Windows.Forms.RadioButton();
            this.rdbProject = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.picGo)).BeginInit();
            this.SuspendLayout();
            // 
            // lvwDocuments
            // 
            this.lvwDocuments.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwDocuments.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwDocuments.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colDate,
            this.colDocNo,
            this.colProject,
            this.colSubject});
            this.lvwDocuments.FullRowSelect = true;
            this.lvwDocuments.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwDocuments.Location = new System.Drawing.Point(0, 0);
            this.lvwDocuments.MultiSelect = false;
            this.lvwDocuments.Name = "lvwDocuments";
            this.lvwDocuments.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvwDocuments.RightToLeftLayout = true;
            this.lvwDocuments.Size = new System.Drawing.Size(604, 450);
            this.lvwDocuments.TabIndex = 3;
            this.lvwDocuments.UseCompatibleStateImageBehavior = false;
            this.lvwDocuments.View = System.Windows.Forms.View.Details;
            this.lvwDocuments.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwQuotes_MouseDoubleClick);
            // 
            // colDate
            // 
            this.colDate.Text = "תאריך";
            this.colDate.Width = 107;
            // 
            // colDocNo
            // 
            this.colDocNo.Text = "מספר מסמך";
            this.colDocNo.Width = 120;
            // 
            // colProject
            // 
            this.colProject.Text = "פרויקט";
            this.colProject.Width = 220;
            // 
            // colSubject
            // 
            this.colSubject.Text = "נושא";
            this.colSubject.Width = 136;
            // 
            // lblSumm
            // 
            this.lblSumm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumm.AutoSize = true;
            this.lblSumm.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblSumm.Location = new System.Drawing.Point(617, 337);
            this.lblSumm.Name = "lblSumm";
            this.lblSumm.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSumm.Size = new System.Drawing.Size(123, 17);
            this.lblSumm.TabIndex = 18;
            this.lblSumm.Text = "נמצאו 00100 פריטים";
            this.lblSumm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.SteelBlue;
            this.label2.Location = new System.Drawing.Point(770, 97);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "סנן לפי:";
            // 
            // picGo
            // 
            this.picGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picGo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picGo.Image = ((System.Drawing.Image)(resources.GetObject("picGo.Image")));
            this.picGo.Location = new System.Drawing.Point(617, 299);
            this.picGo.Name = "picGo";
            this.picGo.Size = new System.Drawing.Size(26, 26);
            this.picGo.TabIndex = 15;
            this.picGo.TabStop = false;
            this.picGo.Click += new System.EventHandler(this.picGo_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtSearch.Location = new System.Drawing.Point(617, 43);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSearch.Size = new System.Drawing.Size(200, 29);
            this.txtSearch.TabIndex = 14;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(738, 23);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(82, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "חיפוש מסמך:";
            // 
            // cboClients
            // 
            this.cboClients.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboClients.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cboClients.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cboClients.FormattingEnabled = true;
            this.cboClients.Location = new System.Drawing.Point(617, 219);
            this.cboClients.Name = "cboClients";
            this.cboClients.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboClients.Size = new System.Drawing.Size(200, 25);
            this.cboClients.TabIndex = 22;
            this.cboClients.SelectedIndexChanged += new System.EventHandler(this.cboClients_SelectedIndexChanged);
            this.cboClients.Validating += new System.ComponentModel.CancelEventHandler(this.cboClients_Validating);
            this.cboClients.Validated += new System.EventHandler(this.cboClients_Validated);
            // 
            // cboDocType
            // 
            this.cboDocType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocType.FormattingEnabled = true;
            this.cboDocType.Location = new System.Drawing.Point(617, 143);
            this.cboDocType.Name = "cboDocType";
            this.cboDocType.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboDocType.Size = new System.Drawing.Size(200, 25);
            this.cboDocType.TabIndex = 24;
            this.cboDocType.SelectedIndexChanged += new System.EventHandler(this.cboDocType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(753, 123);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(67, 17);
            this.label5.TabIndex = 23;
            this.label5.Text = "סוג מסמך:";
            // 
            // rdbClient
            // 
            this.rdbClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbClient.AutoSize = true;
            this.rdbClient.Location = new System.Drawing.Point(763, 192);
            this.rdbClient.Name = "rdbClient";
            this.rdbClient.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdbClient.Size = new System.Drawing.Size(54, 21);
            this.rdbClient.TabIndex = 25;
            this.rdbClient.Text = "לקוח";
            this.rdbClient.UseVisualStyleBackColor = true;
            this.rdbClient.CheckedChanged += new System.EventHandler(this.rdbClient_CheckedChanged);
            // 
            // rdbProject
            // 
            this.rdbProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdbProject.AutoSize = true;
            this.rdbProject.Location = new System.Drawing.Point(683, 192);
            this.rdbProject.Name = "rdbProject";
            this.rdbProject.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.rdbProject.Size = new System.Drawing.Size(65, 21);
            this.rdbProject.TabIndex = 26;
            this.rdbProject.Text = "פרויקט";
            this.rdbProject.UseVisualStyleBackColor = true;
            // 
            // ctlDocuments
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.rdbProject);
            this.Controls.Add(this.rdbClient);
            this.Controls.Add(this.cboDocType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cboClients);
            this.Controls.Add(this.lblSumm);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picGo);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwDocuments);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "ctlDocuments";
            this.Size = new System.Drawing.Size(831, 450);
            this.Resize += new System.EventHandler(this.ctlProjects_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picGo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwDocuments;
        private System.Windows.Forms.ColumnHeader colDocNo;
        private System.Windows.Forms.ColumnHeader colSubject;
        private System.Windows.Forms.Label lblSumm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picGo;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboClients;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ColumnHeader colProject;
        private System.Windows.Forms.ComboBox cboDocType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton rdbClient;
        private System.Windows.Forms.RadioButton rdbProject;
    }
}

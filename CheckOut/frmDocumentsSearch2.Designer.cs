namespace EquipmentCheckOut
{
    partial class frmDocumentsSearch2
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
            this.lvwDocument = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cboDocType = new System.Windows.Forms.ComboBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lbxDocs = new System.Windows.Forms.ListBox();
            this.btnChkAll = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwDocument
            // 
            this.lvwDocument.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwDocument.CheckBoxes = true;
            this.lvwDocument.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader3,
            this.columnHeader1,
            this.columnHeader2});
            this.lvwDocument.FullRowSelect = true;
            this.lvwDocument.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwDocument.HideSelection = false;
            this.lvwDocument.LabelEdit = true;
            this.lvwDocument.Location = new System.Drawing.Point(201, 0);
            this.lvwDocument.MultiSelect = false;
            this.lvwDocument.Name = "lvwDocument";
            this.lvwDocument.RightToLeftLayout = true;
            this.lvwDocument.ShowItemToolTips = true;
            this.lvwDocument.Size = new System.Drawing.Size(626, 354);
            this.lvwDocument.TabIndex = 4;
            this.lvwDocument.UseCompatibleStateImageBehavior = false;
            this.lvwDocument.View = System.Windows.Forms.View.Details;
            this.lvwDocument.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.lvwDocument_AfterLabelEdit);
            this.lvwDocument.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwDocument_ItemChecked);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "נבחר";
            this.columnHeader4.Width = 40;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "זמין";
            this.columnHeader3.Width = 40;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "פריט";
            this.columnHeader1.Width = 238;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "תיאור";
            this.columnHeader2.Width = 286;
            // 
            // cboDocType
            // 
            this.cboDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocType.FormattingEnabled = true;
            this.cboDocType.Location = new System.Drawing.Point(0, 3);
            this.cboDocType.Name = "cboDocType";
            this.cboDocType.Size = new System.Drawing.Size(195, 23);
            this.cboDocType.TabIndex = 0;
            this.cboDocType.SelectedIndexChanged += new System.EventHandler(this.cboDocType_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(663, 361);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "אישור";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(744, 361);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "ביטול";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(0, 45);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(195, 23);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-1, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "חיפוש:";
            // 
            // lbxDocs
            // 
            this.lbxDocs.FormattingEnabled = true;
            this.lbxDocs.IntegralHeight = false;
            this.lbxDocs.ItemHeight = 15;
            this.lbxDocs.Location = new System.Drawing.Point(0, 74);
            this.lbxDocs.Name = "lbxDocs";
            this.lbxDocs.Size = new System.Drawing.Size(195, 280);
            this.lbxDocs.TabIndex = 8;
            this.lbxDocs.SelectedIndexChanged += new System.EventHandler(this.lbxDocs_SelectedIndexChanged);
            // 
            // btnChkAll
            // 
            this.btnChkAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChkAll.Location = new System.Drawing.Point(201, 361);
            this.btnChkAll.Name = "btnChkAll";
            this.btnChkAll.Size = new System.Drawing.Size(75, 25);
            this.btnChkAll.TabIndex = 9;
            this.btnChkAll.Text = "סמן הכל";
            this.btnChkAll.UseVisualStyleBackColor = true;
            this.btnChkAll.Click += new System.EventHandler(this.btnChkAll_Click);
            // 
            // frmDocumentsSearch2
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(826, 392);
            this.Controls.Add(this.btnChkAll);
            this.Controls.Add(this.lbxDocs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cboDocType);
            this.Controls.Add(this.lvwDocument);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDocumentsSearch2";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "העתק ממסמך";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView lvwDocument;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ComboBox cboDocType;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ListBox lbxDocs;
        private System.Windows.Forms.Button btnChkAll;
    }
}
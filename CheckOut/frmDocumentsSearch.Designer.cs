namespace EquipmentCheckOut
{
    partial class frmDocumentsSearch
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
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cboDocType = new System.Windows.Forms.ComboBox();
            this.btnSelectAll = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnSelDoc = new System.Windows.Forms.Button();
            this.lbxDocs = new System.Windows.Forms.CheckedListBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lvwDocument
            // 
            this.lvwDocument.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwDocument.CheckBoxes = true;
            this.lvwDocument.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvwDocument.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwDocument.HideSelection = false;
            this.lvwDocument.Location = new System.Drawing.Point(201, 0);
            this.lvwDocument.MultiSelect = false;
            this.lvwDocument.Name = "lvwDocument";
            this.lvwDocument.RightToLeftLayout = true;
            this.lvwDocument.ShowItemToolTips = true;
            this.lvwDocument.Size = new System.Drawing.Size(626, 299);
            this.lvwDocument.TabIndex = 1;
            this.lvwDocument.UseCompatibleStateImageBehavior = false;
            this.lvwDocument.View = System.Windows.Forms.View.Details;
            this.lvwDocument.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvwDocument_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "פריט";
            this.columnHeader1.Width = 240;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "תיאור";
            this.columnHeader2.Width = 322;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "כמות";
            this.columnHeader3.Width = 39;
            // 
            // cboDocType
            // 
            this.cboDocType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDocType.FormattingEnabled = true;
            this.cboDocType.Location = new System.Drawing.Point(0, 0);
            this.cboDocType.Name = "cboDocType";
            this.cboDocType.Size = new System.Drawing.Size(195, 23);
            this.cboDocType.TabIndex = 0;
            this.cboDocType.SelectedIndexChanged += new System.EventHandler(this.cboDocType_SelectedIndexChanged);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelectAll.Location = new System.Drawing.Point(201, 307);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(75, 25);
            this.btnSelectAll.TabIndex = 3;
            this.btnSelectAll.Text = "בחר הכל";
            this.btnSelectAll.UseVisualStyleBackColor = true;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // btnOK
            // 
            this.btnOK.Enabled = false;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOK.Location = new System.Drawing.Point(658, 307);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 25);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "אישור";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnSelDoc
            // 
            this.btnSelDoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSelDoc.Location = new System.Drawing.Point(282, 307);
            this.btnSelDoc.Name = "btnSelDoc";
            this.btnSelDoc.Size = new System.Drawing.Size(102, 25);
            this.btnSelDoc.TabIndex = 2;
            this.btnSelDoc.Text = "בחר תעודה";
            this.btnSelDoc.UseVisualStyleBackColor = true;
            this.btnSelDoc.Visible = false;
            this.btnSelDoc.Click += new System.EventHandler(this.btnSelDoc_Click);
            // 
            // lbxDocs
            // 
            this.lbxDocs.FormattingEnabled = true;
            this.lbxDocs.IntegralHeight = false;
            this.lbxDocs.Location = new System.Drawing.Point(0, 29);
            this.lbxDocs.Name = "lbxDocs";
            this.lbxDocs.Size = new System.Drawing.Size(195, 270);
            this.lbxDocs.TabIndex = 6;
            this.lbxDocs.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lbxDocs_ItemCheck);
            this.lbxDocs.SelectedIndexChanged += new System.EventHandler(this.lbxDocs_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Location = new System.Drawing.Point(739, 307);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 25);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "ביטול";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // frmDocumentsSearch
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(826, 339);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.lbxDocs);
            this.Controls.Add(this.btnSelDoc);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnSelectAll);
            this.Controls.Add(this.cboDocType);
            this.Controls.Add(this.lvwDocument);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmDocumentsSearch";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "העתק ממסמך";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvwDocument;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ComboBox cboDocType;
        private System.Windows.Forms.Button btnSelectAll;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnSelDoc;
        private System.Windows.Forms.CheckedListBox lbxDocs;
        private System.Windows.Forms.Button btnCancel;

    }
}
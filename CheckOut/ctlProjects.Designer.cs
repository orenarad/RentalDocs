namespace EquipmentCheckOut
{
    partial class ctlProjects
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
            System.Windows.Forms.ListViewGroup listViewGroup1 = new System.Windows.Forms.ListViewGroup("הצעות מחיר", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("תעודות השכרה", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup3 = new System.Windows.Forms.ListViewGroup("תעודות החזרה", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup4 = new System.Windows.Forms.ListViewGroup("חשבונות השכרה", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.ListViewGroup listViewGroup5 = new System.Windows.Forms.ListViewGroup("רשימות ציוד", System.Windows.Forms.HorizontalAlignment.Left);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlProjects));
            this.lvwDocuments = new System.Windows.Forms.ListView();
            this.colDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colDocNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSubject = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbxProjects = new EquipmentCheckOut.PimpedListBox();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.lblSumm = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.picGo = new System.Windows.Forms.PictureBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnNew = new System.Windows.Forms.Button();
            this.cmsNewDoc = new System.Windows.Forms.ContextMenuStrip(this.components);
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
            this.colSubject});
            this.lvwDocuments.FullRowSelect = true;
            listViewGroup1.Header = "הצעות מחיר";
            listViewGroup1.Name = "listViewGroup1";
            listViewGroup2.Header = "תעודות השכרה";
            listViewGroup2.Name = "listViewGroup2";
            listViewGroup3.Header = "תעודות החזרה";
            listViewGroup3.Name = "listViewGroup3";
            listViewGroup4.Header = "חשבונות השכרה";
            listViewGroup4.Name = "listViewGroup4";
            listViewGroup5.Header = "רשימות ציוד";
            listViewGroup5.Name = "listViewGroup5";
            this.lvwDocuments.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup1,
            listViewGroup2,
            listViewGroup3,
            listViewGroup4,
            listViewGroup5});
            this.lvwDocuments.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwDocuments.Location = new System.Drawing.Point(0, 43);
            this.lvwDocuments.MultiSelect = false;
            this.lvwDocuments.Name = "lvwDocuments";
            this.lvwDocuments.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvwDocuments.RightToLeftLayout = true;
            this.lvwDocuments.Size = new System.Drawing.Size(359, 407);
            this.lvwDocuments.TabIndex = 3;
            this.lvwDocuments.UseCompatibleStateImageBehavior = false;
            this.lvwDocuments.View = System.Windows.Forms.View.Details;
            this.lvwDocuments.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwDocuments_MouseDoubleClick);
            // 
            // colDate
            // 
            this.colDate.Text = "תאריך";
            // 
            // colDocNo
            // 
            this.colDocNo.Text = "מספר מסמך";
            this.colDocNo.Width = 131;
            // 
            // colSubject
            // 
            this.colSubject.Text = "נושא";
            this.colSubject.Width = 90;
            // 
            // lbxProjects
            // 
            this.lbxProjects.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxProjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbxProjects.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lbxProjects.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.lbxProjects.FormattingEnabled = true;
            this.lbxProjects.IntegralHeight = false;
            this.lbxProjects.Location = new System.Drawing.Point(363, 0);
            this.lbxProjects.Name = "lbxProjects";
            this.lbxProjects.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lbxProjects.Size = new System.Drawing.Size(240, 450);
            this.lbxProjects.TabIndex = 12;
            this.lbxProjects.SelectedIndexChanged += new System.EventHandler(this.lbxProjects_SelectedIndexChanged);
            this.lbxProjects.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxProjects_MouseDoubleClick);
            // 
            // chkActive
            // 
            this.chkActive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(617, 190);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(15, 14);
            this.chkActive.TabIndex = 19;
            this.chkActive.UseVisualStyleBackColor = true;
            this.chkActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
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
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(688, 188);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(132, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "פרויקטים פעילים בלבד";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(770, 140);
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
            this.label1.Location = new System.Drawing.Point(721, 23);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "חיפוש פרויקטים:";
            // 
            // btnNew
            // 
            this.btnNew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNew.ContextMenuStrip = this.cmsNewDoc;
            this.btnNew.Enabled = false;
            this.btnNew.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNew.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNew.Image = global::EquipmentCheckOut.Properties.Resources.ADD;
            this.btnNew.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNew.Location = new System.Drawing.Point(282, 7);
            this.btnNew.Name = "btnNew";
            this.btnNew.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.btnNew.Size = new System.Drawing.Size(75, 28);
            this.btnNew.TabIndex = 22;
            this.btnNew.Text = "חדש";
            this.btnNew.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // cmsNewDoc
            // 
            this.cmsNewDoc.Name = "cmsNewDoc";
            this.cmsNewDoc.Size = new System.Drawing.Size(61, 4);
            this.cmsNewDoc.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.cmsNewDoc_ItemClicked);
            // 
            // ctlProjects
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.btnNew);
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.lblSumm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.picGo);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbxProjects);
            this.Controls.Add(this.lvwDocuments);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "ctlProjects";
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
        private PimpedListBox lbxProjects;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Label lblSumm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox picGo;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.ColumnHeader colDate;
        private System.Windows.Forms.ContextMenuStrip cmsNewDoc;
    }
}

namespace EquipmentCheckOut
{
    partial class ctlCheckOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ctlCheckOut));
            this.label1 = new System.Windows.Forms.Label();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lvwItems = new System.Windows.Forms.ListView();
            this.colID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colItem = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colSerNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.picGo = new System.Windows.Forms.PictureBox();
            this.cboProject = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblSumm = new System.Windows.Forms.Label();
            this.btnTab1 = new System.Windows.Forms.Button();
            this.btnTab2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.picGo)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(783, 23);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "חיפוש בציוד:";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.txtSearch.Location = new System.Drawing.Point(658, 43);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(200, 29);
            this.txtSearch.TabIndex = 1;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // lvwItems
            // 
            this.lvwItems.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwItems.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvwItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colID,
            this.colItem,
            this.colSerNo,
            this.colStatus});
            this.lvwItems.FullRowSelect = true;
            this.lvwItems.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwItems.Location = new System.Drawing.Point(0, 31);
            this.lvwItems.MultiSelect = false;
            this.lvwItems.Name = "lvwItems";
            this.lvwItems.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lvwItems.RightToLeftLayout = true;
            this.lvwItems.Size = new System.Drawing.Size(645, 418);
            this.lvwItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwItems.TabIndex = 3;
            this.lvwItems.UseCompatibleStateImageBehavior = false;
            this.lvwItems.View = System.Windows.Forms.View.Details;
            this.lvwItems.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lvwItems_MouseDoubleClick);
            // 
            // colID
            // 
            this.colID.Text = "מס\'";
            this.colID.Width = 56;
            // 
            // colItem
            // 
            this.colItem.Text = "פריט";
            this.colItem.Width = 401;
            // 
            // colSerNo
            // 
            this.colSerNo.Text = "מס\' סידורי";
            this.colSerNo.Width = 95;
            // 
            // colStatus
            // 
            this.colStatus.Text = "סטטוס";
            // 
            // picGo
            // 
            this.picGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.picGo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picGo.Image = ((System.Drawing.Image)(resources.GetObject("picGo.Image")));
            this.picGo.Location = new System.Drawing.Point(658, 299);
            this.picGo.Name = "picGo";
            this.picGo.Size = new System.Drawing.Size(26, 26);
            this.picGo.TabIndex = 4;
            this.picGo.TabStop = false;
            this.picGo.Click += new System.EventHandler(this.picGo_Click);
            // 
            // cboProject
            // 
            this.cboProject.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cboProject.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProject.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.cboProject.FormattingEnabled = true;
            this.cboProject.Location = new System.Drawing.Point(659, 185);
            this.cboProject.Name = "cboProject";
            this.cboProject.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cboProject.Size = new System.Drawing.Size(143, 29);
            this.cboProject.TabIndex = 5;
            this.cboProject.SelectedIndexChanged += new System.EventHandler(this.cboProject_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(812, 140);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "סנן לפי:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(812, 191);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "פרויקט:";
            // 
            // lblSumm
            // 
            this.lblSumm.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumm.AutoSize = true;
            this.lblSumm.ForeColor = System.Drawing.Color.SteelBlue;
            this.lblSumm.Location = new System.Drawing.Point(658, 337);
            this.lblSumm.Name = "lblSumm";
            this.lblSumm.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSumm.Size = new System.Drawing.Size(123, 17);
            this.lblSumm.TabIndex = 10;
            this.lblSumm.Text = "נמצאו 00100 פריטים";
            this.lblSumm.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // btnTab1
            // 
            this.btnTab1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTab1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTab1.Location = new System.Drawing.Point(554, 0);
            this.btnTab1.Name = "btnTab1";
            this.btnTab1.Size = new System.Drawing.Size(91, 32);
            this.btnTab1.TabIndex = 11;
            this.btnTab1.Text = "פריטים";
            this.btnTab1.UseVisualStyleBackColor = true;
            this.btnTab1.Click += new System.EventHandler(this.btnTab1_Click);
            // 
            // btnTab2
            // 
            this.btnTab2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTab2.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnTab2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTab2.Location = new System.Drawing.Point(464, 0);
            this.btnTab2.Name = "btnTab2";
            this.btnTab2.Size = new System.Drawing.Size(91, 32);
            this.btnTab2.TabIndex = 12;
            this.btnTab2.Text = "ארגזים";
            this.btnTab2.UseVisualStyleBackColor = false;
            this.btnTab2.Click += new System.EventHandler(this.btnTab2_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(-8, -9);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(474, 41);
            this.panel1.TabIndex = 13;
            // 
            // ctlCheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnTab2);
            this.Controls.Add(this.btnTab1);
            this.Controls.Add(this.lblSumm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cboProject);
            this.Controls.Add(this.picGo);
            this.Controls.Add(this.lvwItems);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.Name = "ctlCheckOut";
            this.Size = new System.Drawing.Size(872, 449);
            this.Resize += new System.EventHandler(this.ctlCheckOut_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picGo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ListView lvwItems;
        private System.Windows.Forms.PictureBox picGo;
        private System.Windows.Forms.ColumnHeader colID;
        private System.Windows.Forms.ColumnHeader colItem;
        private System.Windows.Forms.ColumnHeader colSerNo;
        private System.Windows.Forms.ComboBox cboProject;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblSumm;
        private System.Windows.Forms.Button btnTab1;
        private System.Windows.Forms.Button btnTab2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColumnHeader colStatus;
    }
}

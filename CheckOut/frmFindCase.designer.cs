namespace EquipmentCheckOut
{
    partial class frmFindCase
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
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.tvwCategories = new System.Windows.Forms.TreeView();
            this.txtFind = new System.Windows.Forms.TextBox();
            this.lvwCases = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnNewCase = new System.Windows.Forms.Button();
            this.btnShowCats = new System.Windows.Forms.Button();
            this.lvwSelectedCases = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Enabled = false;
            this.btnOK.Location = new System.Drawing.Point(274, 474);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(355, 474);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tvwCategories
            // 
            this.tvwCategories.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvwCategories.Location = new System.Drawing.Point(0, 0);
            this.tvwCategories.Name = "tvwCategories";
            this.tvwCategories.Size = new System.Drawing.Size(200, 509);
            this.tvwCategories.TabIndex = 2;
            this.tvwCategories.Visible = false;
            this.tvwCategories.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvwCategories_AfterSelect);
            // 
            // txtFind
            // 
            this.txtFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFind.Location = new System.Drawing.Point(137, 12);
            this.txtFind.Name = "txtFind";
            this.txtFind.Size = new System.Drawing.Size(238, 22);
            this.txtFind.TabIndex = 0;
            this.txtFind.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFind_KeyUp);
            // 
            // lvwCases
            // 
            this.lvwCases.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwCases.Location = new System.Drawing.Point(7, 40);
            this.lvwCases.Name = "lvwCases";
            this.lvwCases.ShowItemToolTips = true;
            this.lvwCases.Size = new System.Drawing.Size(423, 205);
            this.lvwCases.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvwCases.TabIndex = 3;
            this.lvwCases.UseCompatibleStateImageBehavior = false;
            this.lvwCases.View = System.Windows.Forms.View.List;
            this.lvwCases.DoubleClick += new System.EventHandler(this.lvwItems_DoubleClick);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(68, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "Find Case:";
            // 
            // btnFind
            // 
            this.btnFind.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFind.Location = new System.Drawing.Point(381, 11);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(49, 23);
            this.btnFind.TabIndex = 1;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnNewCase
            // 
            this.btnNewCase.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNewCase.Location = new System.Drawing.Point(7, 474);
            this.btnNewCase.Name = "btnNewCase";
            this.btnNewCase.Size = new System.Drawing.Size(83, 23);
            this.btnNewCase.TabIndex = 7;
            this.btnNewCase.Text = "New Case...";
            this.btnNewCase.UseVisualStyleBackColor = true;
            this.btnNewCase.Visible = false;
            this.btnNewCase.Click += new System.EventHandler(this.btnNewItem_Click);
            // 
            // btnShowCats
            // 
            this.btnShowCats.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowCats.Location = new System.Drawing.Point(7, 11);
            this.btnShowCats.Name = "btnShowCats";
            this.btnShowCats.Size = new System.Drawing.Size(48, 23);
            this.btnShowCats.TabIndex = 10;
            this.btnShowCats.Text = "<< Cat";
            this.btnShowCats.UseVisualStyleBackColor = true;
            this.btnShowCats.Click += new System.EventHandler(this.btnShowCats_Click);
            // 
            // lvwSelectedCases
            // 
            this.lvwSelectedCases.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lvwSelectedCases.Location = new System.Drawing.Point(7, 265);
            this.lvwSelectedCases.Name = "lvwSelectedCases";
            this.lvwSelectedCases.ShowItemToolTips = true;
            this.lvwSelectedCases.Size = new System.Drawing.Size(423, 203);
            this.lvwSelectedCases.TabIndex = 11;
            this.lvwSelectedCases.UseCompatibleStateImageBehavior = false;
            this.lvwSelectedCases.View = System.Windows.Forms.View.List;
            this.lvwSelectedCases.DoubleClick += new System.EventHandler(this.lvwSelectedCases_DoubleClick);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 14);
            this.label2.TabIndex = 12;
            this.label2.Text = "Selected Cases:";
            // 
            // frmFindCase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(434, 509);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lvwSelectedCases);
            this.Controls.Add(this.btnShowCats);
            this.Controls.Add(this.btnNewCase);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lvwCases);
            this.Controls.Add(this.txtFind);
            this.Controls.Add(this.tvwCategories);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(450, 270);
            this.Name = "frmFindCase";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Select Case";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmFindItem_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TreeView tvwCategories;
        private System.Windows.Forms.TextBox txtFind;
        private System.Windows.Forms.ListView lvwCases;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnNewCase;
        private System.Windows.Forms.Button btnShowCats;
        private System.Windows.Forms.ListView lvwSelectedCases;
        private System.Windows.Forms.Label label2;
    }
}
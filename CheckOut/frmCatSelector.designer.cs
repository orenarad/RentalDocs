﻿namespace EquipmentCheckOut
{
    partial class frmCatSelector
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
            this.tvwCategories = new System.Windows.Forms.TreeView();
            this.SuspendLayout();
            // 
            // tvwCategories
            // 
            this.tvwCategories.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvwCategories.Location = new System.Drawing.Point(0, 0);
            this.tvwCategories.Name = "tvwCategories";
            this.tvwCategories.Size = new System.Drawing.Size(338, 478);
            this.tvwCategories.TabIndex = 0;
            this.tvwCategories.DoubleClick += new System.EventHandler(this.tvwCategories_DoubleClick);
            // 
            // frmCatSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(338, 478);
            this.Controls.Add(this.tvwCategories);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmCatSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Select Category";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView tvwCategories;
    }
}
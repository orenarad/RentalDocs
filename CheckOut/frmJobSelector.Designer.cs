namespace EquipmentCheckOut
{
    partial class frmJobSelector
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
            this.lbxJobs = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbxJobs
            // 
            this.lbxJobs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbxJobs.FormattingEnabled = true;
            this.lbxJobs.Location = new System.Drawing.Point(0, 0);
            this.lbxJobs.Name = "lbxJobs";
            this.lbxJobs.ScrollAlwaysVisible = true;
            this.lbxJobs.Size = new System.Drawing.Size(292, 264);
            this.lbxJobs.TabIndex = 0;
            this.lbxJobs.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.lbxJobs_MouseDoubleClick);
            // 
            // frmJobSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 264);
            this.Controls.Add(this.lbxJobs);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmJobSelector";
            this.Opacity = 0.85;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Job Selector";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxJobs;
    }
}
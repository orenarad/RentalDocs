using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentCheckOut
{
    public partial class frmJobSelector : Form
    {
        int selectedJobID = 0;

        public frmJobSelector()
        {
            InitializeComponent();

            DataTable jobs = new CJobs().AllJobs;
            foreach (DataRow row in jobs.Rows)
            {
                ComboItem ci = new ComboItem(row["Production"] + " - " + row["Job"], (int)row["ID"]);
                lbxJobs.Items.Add(ci);
            }
            jobs.Dispose();
        }

        public CJob SelectedJob
        {
            get
            {
                if (selectedJobID > 0)
                    return new CJob(selectedJobID);
                else
                    return null;
            }
        }

        private void lbxJobs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ComboItem ci = (ComboItem)lbxJobs.SelectedItem;
            selectedJobID = ci.ID;
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }
    }
}

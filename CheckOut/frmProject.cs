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
    public partial class frmProject : Form
    {
        bool needSave = false;

        CRentalProject currentProject;

        public bool RecordLocked = false;

        public frmProject()
        {
            // empty form preset
            InitializeComponent();
            PopulateClients();

            needSave = false;
        }

        public frmProject(int ProjectID)
        {
            // construct the form with a project
            InitializeComponent();
            PopulateClients();

            currentProject = new CRentalProject(ProjectID);

            Text = currentProject.ProjectName;
            txtID.Text = currentProject.ID.ToString();
            int cidx = Program.GetComboIndexOfId(cboClient, currentProject.RentalClientID);
            if (cidx > -1)
                cboClient.SelectedIndex = cidx;
            txtName.Text = currentProject.ProjectName;
            txtDetails.Text = currentProject.ProjectDetails;
            chkActive.Checked = !currentProject.Inactive;

            needSave = false;
        }

        private void PopulateClients()
        {
            using (DataTable clients = new CRentalClients().AllRentalClients(true))
            {
                foreach (DataRow row in clients.Rows)
                {
                    ComboItem ci = new ComboItem(row["ClientName"].ToString(), (int)row["ID"]);
                    cboClient.Items.Add(ci);
                }
            }
            cboClient.SelectedIndex = 0;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = txtName.Text.Length > 0;
            needSave = true;
        }

        private void frmProjectProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                currentProject.Dispose();
            }
            catch { };
        }

        private void frmProject_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (RecordLocked == true)
                return;

            if (needSave == true)
            {
                DialogResult dr = MessageBox.Show("האם לשמור את השינויים?", "שמירה",MessageBoxButtons.YesNoCancel,MessageBoxIcon.Question);
                switch (dr)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        // save and close
                        SaveProject();
                        this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        break;

                    case System.Windows.Forms.DialogResult.No:
                        // just close
                        break;

                    case System.Windows.Forms.DialogResult.Cancel:
                        // cancel closing the form
                        e.Cancel = true;
                        break;
                }
            }
        }

        private void SaveProject()
        {
            // save this project
            //=================================================================

            // if we have a live CRentalProject instance then update it, if we don't
            // then we have a new project we need to add to the database...

            ComboItem ci = (ComboItem)cboClient.SelectedItem;
            if (currentProject == null)
            {
                // create a new client in the catalog:
                currentProject = new CRentalProjects().NewRentalProject(ci.ID, txtName.Text);
                Text = currentProject.ProjectName;
                txtID.Text = currentProject.ID.ToString();
            }
            else
            {
                currentProject.ProjectName = txtName.Text;
                currentProject.RentalClientID = ci.ID;
            }

            currentProject.ProjectDetails = txtDetails.Text + "";
            currentProject.Inactive = !chkActive.Checked;
            currentProject.Update();
            needSave = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveProject();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void txtDetilas_TextChanged(object sender, EventArgs e)
        {
            needSave = true;
        }

        private void cboClient_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = cboClient.FindStringExact(cboClient.Text) < 0;
            if (e.Cancel == true)
                MessageBox.Show("יש לבחור לקוח מהרשימה", "בחירת לקוח",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
        }

        private void frmProject_Load(object sender, EventArgs e)
        {
            if (RecordLocked == true)
            {
                Text += " (לקריאה בלבד)";
                btnOK.Visible = false;
            }
        }
    }
}

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
    public partial class frmUser : Form
    {
        private bool needSave = false;
        CUser currentUser;

        public frmUser()
        {
            InitializeComponent();
        }

        public frmUser(int UserID)
        {
            InitializeComponent();
            currentUser = new CUser(UserID);
            txtID.Text = currentUser.ID.ToString();
            txtUsername.Text = currentUser.User;
            txtPassword.Text = currentUser.Password;
            txtFullname.Text = currentUser.Fullname;
            txtColor.Text = currentUser.ColorSchema.ToArgb().ToString();
            txtColor.BackColor = currentUser.ColorSchema;
            needSave = false;
            this.Text = "User: " + currentUser.User;
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {
            needSave = true;
            int enableOK = (txtUsername.Text.Length * txtPassword.Text.Length);
            btnSave.Enabled = (enableOK > 0);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (currentUser != null)
            {   // save existing user
                currentUser.User = txtUsername.Text;
                currentUser.Password = txtPassword.Text;
                currentUser.Fullname = txtFullname.Text;
            }
            else
            {   // save new user
                currentUser = new CUsers().NewUser(txtUsername.Text, txtPassword.Text);
                currentUser.Fullname = txtFullname.Text;
            }
            currentUser.Update();
            needSave = false;
            this.Close();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void frmUser_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (needSave == true)
            {
                switch (MessageBox.Show("Do you wish to save the changes made?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
                {
                    case System.Windows.Forms.DialogResult.Cancel:
                        e.Cancel = true;
                        break;

                    case System.Windows.Forms.DialogResult.Yes:
                        if (currentUser != null) currentUser.Dispose();
                        btnSave_Click(this, new EventArgs());
                        break;

                    default:
                        if (currentUser != null) currentUser.Dispose();
                        break;
                }
            }
        }

        
    }
}

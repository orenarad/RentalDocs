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
    public partial class frmClient : Form
    {
        bool needSave = false;

        CRentalClient currentClient;

        public bool RecordLocked = false;

        public frmClient()
        {
            // empty form preset with the current category selected in the cataloge UI
            InitializeComponent();
            needSave = false;
        }

        public frmClient(int ClientID)
        {
            // construct the form with a product
            InitializeComponent();

            currentClient = new CRentalClient(ClientID);

            Text = currentClient.ClientName;
            txtID.Text = currentClient.ID.ToString();
            txtName.Text = currentClient.ClientName;
            txtDetails.Text = currentClient.ClientDetails;
            txtHashavshevetNo.Text = currentClient.HashavshevetNumber.ToString();
            chkActive.Checked = !currentClient.Inactive;

            needSave = false;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = txtName.Text.Length > 0;
            needSave = true;
        }

        private void frmCatalogProduct_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                currentClient.Dispose();
            }
            catch { };
        }

        private void frmCatalogProduct_FormClosing(object sender, FormClosingEventArgs e)
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
                        SaveClient();
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

        private void SaveClient()
        {
            // save this product
            //=================================================================

            // if we have a live CRentalClient instance then update it, if we don't
            // then we have a new client we need to add to the database...

            if (currentClient == null)
            {
                // create a new client in the catalog:
                currentClient = new CRentalClients().NewRentalClient(txtName.Text);
                Text = currentClient.ClientName;
                txtID.Text = currentClient.ID.ToString();
            }
            else
                currentClient.ClientName = txtName.Text;

            currentClient.ClientDetails = txtDetails.Text + "";
            int HashavshevetNumber = 0;
            if (int.TryParse(txtHashavshevetNo.Text, out HashavshevetNumber) == true)  
            {
                currentClient.HashavshevetNumber = HashavshevetNumber;
            }
            currentClient.Inactive = !chkActive.Checked;
            currentClient.Update();
            needSave = false;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveClient();
            DialogResult = System.Windows.Forms.DialogResult.OK;
            Close();
        }

        private void txtDetilas_TextChanged(object sender, EventArgs e)
        {
            needSave = true;
        }

        private void txtRentalPrice_Validating(object sender, CancelEventArgs e)
        {
            if (Program.IsNumeric(txtHashavshevetNo.Text) == true)
            {
                MessageBox.Show("חייב ערך מספרי", "טעות", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Cancel = true;
            }
        }

        private void frmClient_Load(object sender, EventArgs e)
        {
            if (RecordLocked == true)
            {
                Text += " (לקריאה בלבד)";
                btnOK.Visible = false;
            }
        }
    }
}

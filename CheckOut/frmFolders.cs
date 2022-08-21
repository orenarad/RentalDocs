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
    public partial class frmFolders : Form
    {
        CFolder currentFolder;
        public frmFolders()
        {
            InitializeComponent();

            // populate folders
            using (DataTable folders = new  CFolders().AllFolders)
            {
                foreach (DataRow row in folders.Rows)
                {
                    ComboItem ci = new ComboItem(row["Folder"].ToString(), (int)row["ID"]);
                    lbxFolders.Items.Add(ci);
                }
            }

            lbxFolders.SelectedIndex = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lbxFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            // load form with folder record
            ComboItem ci = (ComboItem)lbxFolders.SelectedItem;
            currentFolder = new CFolder(ci.ID);

            txtID.Text = ci.ID.ToString();
            txtFolderName.Text = currentFolder.Folder;
            txtDescription.Text = currentFolder.Description;
            txtPrefix.Text = currentFolder.Perfix.ToString();
            txtOrder.Text = currentFolder.ListOrder.ToString();
            txtDocTerms.Text = currentFolder.DocTerms;
            chkIsDocument.Checked = currentFolder.IsDocument;
            chkPrintable.Checked = currentFolder.IsPrintable;
            chkShowInMenu.Checked = currentFolder.ShowInMenu;
        }

        private void frmFolders_FormClosing(object sender, FormClosingEventArgs e)
        {
            currentFolder.Dispose();
        }

        private void txtFeild_Validating(object sender, CancelEventArgs e)
        {
            TextBox field = (TextBox)sender;
            int value;

            switch (field.Name)
            {
                case "txtFolderName":
                    if (field.Text.Length == 0)
                    {
                        MessageBox.Show(Properties.Settings.Default.MsgCantSaveEmpty, 
                                        Properties.Settings.Default.MsgCantProceed,
                                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                        e.Cancel = true;
                        return;
                    }
                    currentFolder.Folder = field.Text;
                    currentFolder.Update();
                    break;

                case "txtDescription":
                    currentFolder.Description = field.Text;
                    currentFolder.Update();
                    break;

                case "txtDocTerms":
                    currentFolder.DocTerms = field.Text;
                    currentFolder.Update();
                    break;

                case "txtPrefix":
                    int.TryParse(field.Text, out value);
                    if (value == 0)
                    {
                        if (value.ToString() != field.Text)
                        {
                            MessageBox.Show(Properties.Settings.Default.MsgOnlyNumeric,
                                            Properties.Settings.Default.MsgCantProceed,
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                            return;
                        }
                    }
                    currentFolder.Perfix = value;
                    currentFolder.Update();
                    break;

                case "txtOrder":
                    int.TryParse(field.Text, out value);
                    if (value == 0)
                    {
                        if (value.ToString() != field.Text)
                        {
                            MessageBox.Show(Properties.Settings.Default.MsgOnlyNumeric,
                                            Properties.Settings.Default.MsgCantProceed,
                                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                            e.Cancel = true;
                            return;
                        }
                    }
                    currentFolder.ListOrder = value;
                    currentFolder.Update();
                    break;
            }

        }

        private void chkCheckField_Validating(object sender, CancelEventArgs e)
        {
            CheckBox field = (CheckBox)sender;

            switch (field.Name)
            {
                case "chkShowInMenu":
                    currentFolder.ShowInMenu = field.Checked;
                    break;

                case "chkIsDocument":
                    currentFolder.IsDocument = field.Checked;
                    break;

                case "chkPrintable":
                    currentFolder.IsPrintable = field.Checked;
                    break;
            }
            currentFolder.Update();
        }
    }
}

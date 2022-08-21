using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentCheckOut
{
    public partial class ctlClients : ctlUIPanel
    {
        public ctlClients()
        {
            InitializeComponent();
            FolderID = 8;

            PopulateClients();
        }

        private void ctlClients_Resize(object sender, EventArgs e)
        {
            lvwCatalog.Columns[2].Width = 100;
            lvwCatalog.Columns[1].Width = lvwCatalog.ClientRectangle.Width - 250;
            lvwCatalog.Columns[0].Width = 150;
        }

        private DataTable GetClientsData()
        {
            DataTable ret;
            if (txtSearch.Text.Length > 0)
                ret = new CRentalClients().SearchRentalClients(txtSearch.Text, chkActive.Checked).Copy();
            else
                ret = new CRentalClients().AllRentalClients(chkActive.Checked).Copy();
            return ret;
        }

        private void picGo_Click(object sender, EventArgs e)
        {
            PopulateClients();
        }

        private void PopulateClients()
        {
            lvwCatalog.BeginUpdate();
            Cursor = Cursors.WaitCursor;
            lvwCatalog.Items.Clear();
            using (DataTable clients = GetClientsData())
            {
                foreach (DataRow row in clients.Rows)
                {
                    ListViewItem lvi = new ListViewItem(row["ClientName"].ToString());
                    lvi.SubItems.Add(row["ClientDetails"].ToString() + "");
                    lvi.SubItems.Add(row["HashavshevetNumber"].ToString() + "");
                    lvi.Tag = (int)row["ID"];
                    lvwCatalog.Items.Add(lvi);
                }
                lblSumm.Text = "נמצאו " + clients.Rows.Count.ToString() + " לקוחות";
            }
            lvwCatalog.EndUpdate();
            Cursor = Cursors.Default;
            ctlClients_Resize(this, new EventArgs());
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                PopulateClients();
        }

        public override void AddNew()
        {
            if (AllowNew(FolderID) == false)
            {
                MessageBox.Show(Properties.Settings.Default.MsgNoPermission,
                    Properties.Settings.Default.MsgCantProceed,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            using (frmClient clientForm = new frmClient())
            {
                if (clientForm.ShowDialog(this) == DialogResult.OK)
                {
                    PopulateClients();
                }
            }
        }

        public override void EditItem()
        {
            if (lvwCatalog.SelectedItems.Count > 0)
            {
                int selID = (int)lvwCatalog.SelectedItems[0].Tag;
                using (frmClient clientForm = new frmClient(selID))
                {
                    clientForm.RecordLocked = !AllowEdit(FolderID);
                    if (clientForm.ShowDialog(this) == DialogResult.OK)
                    {
                        PopulateClients();
                    }
                }
            }
        }

        public override void Refresh()
        {
            PopulateClients();
        }
        private void lvwCatalog_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditItem();
        }

        private void chkActive_CheckedChanged(object sender, EventArgs e)
        {
            PopulateClients();
        }
    }
}

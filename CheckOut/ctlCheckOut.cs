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
    public partial class ctlCheckOut : ctlUIPanel
    {
        bool tabPosition = true;    // true = Items, false = cases

        public ctlCheckOut()
        {
            InitializeComponent();
            FolderID = 5;

            // populate projects
            using (DataTable proj = new CRentalProjects().AllRentalProjects(true))
            {
                ComboItem ci = new ComboItem("הכל", 0);
                cboProject.Items.Add(ci);
                foreach (DataRow row in proj.Rows)
                {
                    ComboItem prj = new ComboItem(row["ProjectName"].ToString(), (int)row["ID"]);
                    cboProject.Items.Add(prj);
                }
                cboProject.SelectedIndex = 0;
            }

            PopulateItems();
        }

        private void ctlCheckOut_Resize(object sender, EventArgs e)
        {
            lvwItems.Columns[0].Width = 40;
            lvwItems.Columns[1].Width = lvwItems.ClientRectangle.Width - 290;
            lvwItems.Columns[2].Width = 90;
            lvwItems.Columns[3].Width = 160;
        }

        private DataTable GetItemsData()
        {
            DataTable ret = new DataTable();
            ComboItem selProject = (ComboItem)cboProject.SelectedItem;

            if (txtSearch.Text.Length > 1)
            {
                if (tabPosition == true)    // items
                    ret = new CItems().SearchItemsDocs(txtSearch.Text + "");
                else                        // cases
                    ret = new CCases().SearchCases(txtSearch.Text + "");
            }

            return ret;
        }

        private void cboProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            PopulateItems();
        }

        private void picGo_Click(object sender, EventArgs e)
        {
            PopulateItems();
        }

        private void PopulateItems()
        {
            lvwItems.BeginUpdate();
            Cursor = Cursors.WaitCursor;
            lvwItems.Items.Clear();
            using (DataTable items = GetItemsData())
            {
                foreach (DataRow row in items.Rows)
                {
                    if (tabPosition == true)
                    {
                        ListViewItem lvi = new ListViewItem(row["ID"].ToString());
                        lvi.Tag = (int)row["ID"];
                        lvi.UseItemStyleForSubItems = false;
                        lvi.SubItems.Add(row["Name"].ToString() + " - " + row["Description"].ToString());
                        lvi.SubItems.Add(row["SerNo"].ToString());
                        string status = "בבית";
                        Color cs = Color.Black;
                        try
                        {
                            if ((int)row["Issue"] == 1)
                            {
                                status = "בעייה";
                                cs = Color.Red;
                            }
                            if ((int)row["Back"] == 0)
                            {
                                status = "בחוץ: " + row["Prod"];
                                cs = Color.Navy;
                            }
                        }
                        catch { }
                        lvi.SubItems.Add(status);
                        lvi.SubItems[3].ForeColor = cs;
                        lvwItems.Items.Add(lvi);
                    }
                    else
                    {

                    }
                }
                lblSumm.Text = "נמצאו " + items.Rows.Count.ToString() + " פריטים";
            }
            ctlCheckOut_Resize(this, new EventArgs());
            lvwItems.EndUpdate();
            Cursor = Cursors.Default;
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                PopulateItems();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length == 0)
                PopulateItems();
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

            // new item/case form...
            using (frmCheckOutItem chkoutForm = new frmCheckOutItem())
            {
                if (chkoutForm.ShowDialog(this) == DialogResult.OK)
                {
                    PopulateItems();
                }
            }
        }

        public override void EditItem()
        {
            if (lvwItems.SelectedItems.Count > 0)
            {
                int selID = (int)lvwItems.SelectedItems[0].Tag;
                // edit item/case form
                using (frmCheckOutItem chkoutForm = new frmCheckOutItem(selID))
                {
                    chkoutForm.RecordLocked = !AllowEdit(FolderID);
                    chkoutForm.AllowNew = AllowNew(FolderID);
                    if (chkoutForm.ShowDialog(this) == DialogResult.OK)
                    {
                        PopulateItems();
                    }
                }
            }
        }

        public override void Refresh()
        {
            PopulateItems();
        }

        private void btnTab1_Click(object sender, EventArgs e)
        {
            tabPosition = true;
            btnTab1.BackColor = SystemColors.ButtonFace;
            btnTab2.BackColor = SystemColors.ButtonShadow;
            lvwItems.View = View.Details;
            lvwItems.Focus();
            PopulateItems();
        }

        private void btnTab2_Click(object sender, EventArgs e)
        {
            tabPosition = false;
            btnTab2.BackColor = SystemColors.ButtonFace;
            btnTab1.BackColor = SystemColors.ButtonShadow;
            lvwItems.View = View.LargeIcon;
            lvwItems.Focus();
            PopulateItems();
        }

        private void lvwItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            EditItem();
        }
    }
}

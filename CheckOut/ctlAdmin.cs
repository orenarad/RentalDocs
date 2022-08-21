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
    public partial class ctlAdmin : ctlUIPanel
    {
        struct PermissionTag
        {
            public int ID ;
            public int PermissionID ;
            public bool IsPrintable;
        }

        ListViewItem lviPrint;

        public ctlAdmin()
        {
            InitializeComponent();
            FolderID = 6;
        }

        private void ctlAdmin_Load(object sender, EventArgs e)
        {
            PopulateUsers();
            PopulateBaseFolders();
            PopulateBaseButtons();
            if (lbxUser.Items.Count > 0) lbxUser.SelectedIndex = 0;

            string letterHeadFile;
            using (CRecord lh = new CRecord("Settings"))
            {
                letterHeadFile = lh.Table.Rows[0]["LHPath"].ToString();
            }
            lblLHFile.Text = letterHeadFile;
        }

        private void PopulateBaseButtons()
        {
            lvwButtons.Items.Clear();
            using (DataTable btns = new CButtons().AllButtons)
            {
                foreach (DataRow row in btns.Rows)
                {
                    PermissionTag ft = new PermissionTag();
                    ft.ID = (int)row["ID"];
                    ListViewItem lvi = new ListViewItem(row["Button"].ToString());
                    lvi.Tag = ft;
                    lvwButtons.Items.Add(lvi);
                }
                lviPrint = lvwButtons.Items[2];
            }
        }

        private void PopulateBaseFolders()
        {
            lvwFolders.Items.Clear();
            using (DataTable flds = new CFolders().AllFolders)
            {
                foreach (DataRow row in flds.Rows)
                {
                    PermissionTag ft = new PermissionTag();
                    ft.ID = (int)row["ID"];
                    ft.IsPrintable = Convert.ToBoolean(row["IsPrintable"]);
                    ListViewItem lvi = new ListViewItem(row["Folder"].ToString());
                    lvi.Tag = ft;
                    lvwFolders.Items.Add(lvi);
                }
            }
        }

        private void PopulateUsers()
        {
            lbxUser.Items.Clear();
            DataTable users = new CUsers().AllUsers;
            foreach (DataRow row in users.Rows)
            {
                ComboItem ci = new ComboItem(row["FullName"].ToString(), (int)row["ID"]);
                lbxUser.Items.Add(ci);
            }
            users.Dispose();
        }

        private void btnCUCats_Click(object sender, EventArgs e)
        {
            frmOptions optionsForm = new frmOptions();
            optionsForm.ShowDialog(this);
        }

        private void btnUser_Click(object sender, EventArgs e)
        {
            frmUser userForm = new frmUser();
            userForm.ShowDialog(this);
            userForm.Dispose();
            PopulateUsers();
        }

        private void btnFolders_Click(object sender, EventArgs e)
        {
            using (frmFolders userFolders = new frmFolders())
            {
                userFolders.ShowDialog(this);
            }
        }

        private void lbxUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update user's folder permission:
            if (lbxUser.SelectedIndex > -1)
            {
                ComboItem ci = (ComboItem)lbxUser.SelectedItem;
                using (DataTable fp = new CFolderPermissions().FoldersByUser(ci.ID, false))
                {
                    foreach (ListViewItem lvi in lvwFolders.Items)
                    {
                        PermissionTag ft = (PermissionTag)lvi.Tag;
                        lvi.Checked = false;
                        ft.PermissionID = 0;
                        foreach (DataRow row in fp.Rows)
                        {
                            if ((int)row["ID"] == ft.ID)
                            {
                                lvi.Checked = true;
                                ft.PermissionID = (int)row["PermissionID"];
                            }
                        }
                        lvi.Tag = ft;
                    }
                }
                if (lvwFolders.Items.Count > 0) lvwFolders.Items[0].Selected = true;
                lvwFolders_SelectedIndexChanged(this, new EventArgs());
            }

        }

        private void lvwFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            // update folder button permission
            if (lvwFolders.SelectedItems.Count > 0)
            {
                PermissionTag ft = (PermissionTag)lvwFolders.SelectedItems[0].Tag;
                if (ft.IsPrintable == true)
                {
                    if (lvwButtons.Items.Count == 2)
                        lvwButtons.Items.Add(lviPrint);
                }
                else
                {
                    if (lvwButtons.Items.Count == 3)
                        lvwButtons.Items[2].Remove();
                }

                using (DataTable bp = new CButtonPermissions().ButtonsByFolderPermissionID(ft.PermissionID))
                {
                    foreach (ListViewItem lvi in lvwButtons.Items)
                    {
                        ft = (PermissionTag)lvi.Tag;
                        lvi.Checked = false;
                        ft.PermissionID = 0;
                        foreach (DataRow row in bp.Rows)
                        {
                            if ((int)row["ID"] == ft.ID)
                            {
                                lvi.Checked = true;
                                ft.PermissionID = (int)row["PermissionID"];
                            }
                        }
                        lvi.Tag = ft;
                    }
                }
            }
        }

        private void lvwFolders_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lvwFolders.Focused == true)
            {
                PermissionTag pt = (PermissionTag)e.Item.Tag;
                if (e.Item.Checked == true)
                {
                    // add permission record
                    ComboItem ci = (ComboItem)lbxUser.SelectedItem;
                    CFolderPermission fps = new CFolderPermissions().NewFolderPermission(ci.ID, pt.ID);
                    pt.PermissionID = fps.ID;
                    e.Item.Tag = pt;
                    fps.Dispose();
                }
                else
                {
                    // delete permission record
                    //CFolderPermission fp = new CFolderPermission(pt.PermissionID);
                    //fp.DeleteRelatedButtonPermissions();
                    //fp.Dispose();
                    CRecord delFolderPermission = new CRecord("FolderPermission", pt.PermissionID, true);
                    delFolderPermission.Dispose();
                    lvwFolders_SelectedIndexChanged(this, new EventArgs());
                }
            }
        }

        private void lvwButtons_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (lvwButtons.Focused == true)
            {
                PermissionTag pt = (PermissionTag)e.Item.Tag;
                if (e.Item.Checked == true)
                {
                    // add premission record
                    PermissionTag folderPermittion = (PermissionTag)lvwFolders.SelectedItems[0].Tag;
                    CButtonPermission bps = new CButtonPermissions().NewButtonPermission(folderPermittion.PermissionID, pt.ID);
                    pt.PermissionID = bps.ID;
                    e.Item.Tag = pt;
                    bps.Dispose();
                }
                else
                {
                    // delete permission record
                    CRecord delButtonPermission = new CRecord("ButtonPermission", pt.PermissionID, true);
                    delButtonPermission.Dispose();
                }
            }
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            frmUser userForm = new frmUser();
            if (userForm.ShowDialog(this) == DialogResult.OK)
                PopulateUsers();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            if (lbxUser.SelectedIndex > -1)
            {
                ComboItem ci = (ComboItem)lbxUser.SelectedItem;
                frmUser userForm = new frmUser(ci.ID);
                if (userForm.ShowDialog(this) == DialogResult.OK)
                    PopulateUsers();
            }
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            if (lbxUser.SelectedIndex > -1)
            {
                ComboItem ci = (ComboItem)lbxUser.SelectedItem;
                if (MessageBox.Show("Delete this user?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    //
                    CRecord delUser = new CRecord("[User]", ci.ID, true);
                    delUser.Dispose();
                    PopulateUsers();
                    if (lbxUser.Items.Count > 0) lbxUser.SelectedIndex = 0;
                }
            }
        }

        private void btnLHBrowse_Click(object sender, EventArgs e)
        {
            // Create an instance of the open file dialog box.
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Image Files|*.jpg";
                ofd.Multiselect = false;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    string command = "UPDATE Settings SET LHPath = '" + ofd.FileName + "' WHERE id = 1";
                    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(command))
                    {
                        using (CRecord rec = new CRecord(cmd)) { }
                    }
                    lblLHFile.Text = ofd.FileName;
                }
            }
        }
    }
}

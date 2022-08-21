using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Data.SqlClient;

namespace EquipmentCheckOut
{
    public partial class mainUi : Form
    {
        #region API STUFF
        [DllImport("user32.dll")]
        public static extern Boolean GetLastInputInfo(ref tagLASTINPUTINFO plii);
        public struct tagLASTINPUTINFO
        {
            public uint cbSize;
            public Int32 dwTime;
        }
        
        #endregion

        private int CurrentUserID = 0;
        private int IdleMinutesBeforeLogin = 20;
        private object[] uiCtls;

        public mainUi()
        {
            InitializeComponent();
            tmrIdle.Start();
            uiCtls = new object[6];
            uiCtls[0] = ctlCatalog;
            uiCtls[1] = ctlClients;
            uiCtls[2] = ctlProjects;
            uiCtls[3] = ctlDocs;
            uiCtls[4] = ctlAdmin;
            uiCtls[5] = ctlCheckOut;

            foreach (object obj in uiCtls)
            {
                ctlUIPanel uip = (ctlUIPanel)obj;
                uip.Dock = DockStyle.Fill;
                uip.Refresh();
            }
        }

        private void tmrIdle_Tick(object sender, EventArgs e)
        {
            tagLASTINPUTINFO LastInput = new tagLASTINPUTINFO();
            Int32 IdleTime;
            LastInput.cbSize = (uint)Marshal.SizeOf(LastInput);
            LastInput.dwTime = 0;

            if (GetLastInputInfo(ref LastInput))
            {
                IdleTime = System.Environment.TickCount - LastInput.dwTime;
                if (IdleTime > (IdleMinutesBeforeLogin * 60000))
                {
                    panLogIn.Visible = true;
                    //foreach (Form forms in Application.OpenForms)
                    //{
                    //    if (forms.Name != this.Name)
                    //        forms.Visible = false;
                    //}
                }
            }
        }

        private void mainUi_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                Properties.Settings.Default.Maximised = true;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                Properties.Settings.Default.Maximised = false;
                Properties.Settings.Default.Location = Location;
                Properties.Settings.Default.Size = Size;
            }
            Properties.Settings.Default.Save();

            if (lbxFolders.SelectedItems.Count > 0)
            {
                ComboItem ci = (ComboItem)lbxFolders.SelectedItem;
                using (CUser usr = new CUser(CurrentUserID))
                {
                    usr.LastFolder = ci.ID;
                    usr.Update();
                }
            }
        }

        private void mainUi_Load(object sender, EventArgs e)
        {

            // check version No
            using (SqlCommand cmd = new SqlCommand("SELECT CurrentVersion FROM Settings"))
            {
                using (CRecord rec = new CRecord(cmd))
                {
                    float correctVersion = float.Parse(rec.Table.Rows[0][0].ToString());
                    float thisVersion = Properties.Settings.Default.CurrentVersion;
                    this.Text = "מסמכי השכרה - מובי מוביל ישראל - גרסה " + thisVersion.ToString();
                    if (correctVersion > thisVersion)
                    {
                        MessageBox.Show(Properties.Settings.Default.MsgBadVersion + " " + correctVersion.ToString(),
                                        Properties.Settings.Default.MsgCantProceed,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                        this.Close();
                    }
                }
            }

            if (Properties.Settings.Default.Maximised == true)
            {
                WindowState = FormWindowState.Maximized;
                Location = Properties.Settings.Default.Location;
                Size = Properties.Settings.Default.Size;
            }
            else 
            {
                WindowState = FormWindowState.Normal;
                Location = Properties.Settings.Default.Location;
                Size = Properties.Settings.Default.Size;
            }
            panLogIn.Top = 0;
            panLogIn.Left = 0;
            panLogIn.Size = this.ClientSize;
        }        

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            lblLoginFail.Visible = false;
            using (CUser user = new CUsers().ValidateLogIn(txtUsername.Text, txtPassword.Text))
            {
                if (user != null)
                {
                    CurrentUserID = user.ID;
                    foreach (object obj in uiCtls)
                    {
                        ctlUIPanel uip = (ctlUIPanel)obj;
                        uip.CurrentUserID = CurrentUserID;
                    }
                    panLogIn.Visible = false;
                    lblLoginFail.Visible = false;
                    txtPassword.Text = "";
                    PopulateFolders();
                    lblUser.Text = user.Fullname;
                    panTopNenu.BackColor = user.ColorSchema;
                    user.Dispose();

                    // post login actions required:
                    ctlDocs.PopulateFolders();
                    ctlProjects.PopulateNewMenu();
                    // set folder to last folder of this user
                    int folderIdx = 0;
                    int i = 0;
                    foreach (object item in lbxFolders.Items)
                    {
                        ComboItem ci = (ComboItem)item;
                        if (ci.ID == user.LastFolder)
                            folderIdx = i;
                        i++;
                    }
                    lbxFolders.SelectedIndex = folderIdx;

                }
                else
                {
                    CurrentUserID = 0;
                    lblLoginFail.Visible = true;
                    txtUsername.Focus();
                }
            }
            this.Cursor = Cursors.Default;
        }

        private void PopulateFolders()
        {
            // populate available folders list as per user permissions
            lbxFolders.Items.Clear();
            using (DataTable flds = new CFolderPermissions().FoldersByUser(CurrentUserID, true))
            {
                foreach (DataRow row in flds.Rows)
                {
                    lbxFolders.Items.Add(new ComboItem(row["Folder"].ToString(), (int)row["ID"]));
                }
                lbxFolders.SelectedIndex = 0;
            }
        }

        private void txtUsername_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                btnLogIn_Click(this, new EventArgs());
        }

        private void mainUi_Resize(object sender, EventArgs e)
        {
            panLogIn.Size = this.ClientSize;
        }

        private void lbxFolders_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lbxFolders.SelectedIndex > -1)
            {
                ComboItem ci = (ComboItem)lbxFolders.SelectedItem;
                using (CFolder fold = new CFolder(ci.ID))
                {
                    btnExport.Visible = fold.IsPrintable;
                }
                foreach (object obj in uiCtls)
                {
                    ctlUIPanel uip = (ctlUIPanel)obj;
                    if (uip.FolderID == ci.ID)
                        uip.Visible = true;
                    else
                        uip.Visible = false;
                }
            }
        }

        private void picLogout_Click(object sender, EventArgs e)
        {
            panLogIn.Visible = true;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in panClient.Controls)
            {
                if (ctl.Visible)
                {
                    ctlUIPanel uiCtl = (ctlUIPanel)ctl;
                    uiCtl.AddNew();
                    break;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in panClient.Controls)
            {
                if (ctl.Visible)
                {
                    ctlUIPanel uiCtl = (ctlUIPanel)ctl;
                    uiCtl.EditItem();
                    break;
                }
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in panClient.Controls)
            {
                if (ctl.Visible)
                {
                    ctlUIPanel uiCtl = (ctlUIPanel)ctl;
                    uiCtl.ExportItem();
                    break;
                }
            }
        }

        private void picPref_Click(object sender, EventArgs e)
        {
            using (frmUserColor ucFrm = new frmUserColor())
            {

                Point loc = picPref.PointToScreen(picPref.Location); 
                loc.X -= picPref.Left + 4;
                loc.Y += picPref.Height;
                ucFrm.Location = loc;
                ucFrm.ShowDialog(this);
                using (CUser user = new CUser(CurrentUserID))
                {
                    user.ColorSchema = ucFrm.SelectedColor;
                    user.Update();
                }
                panTopNenu.BackColor = ucFrm.SelectedColor;
            }
            
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            CurrentUserID = 1;
            foreach (object obj in uiCtls)
            {
                ctlUIPanel uip = (ctlUIPanel)obj;
                uip.CurrentUserID = CurrentUserID;
            }
            panLogIn.Visible = false;
            lblLoginFail.Visible = false;
            txtPassword.Text = "";
            PopulateFolders();
            lblUser.Text = "אורן ארד";
            panTopNenu.BackColor = Color.SpringGreen;

            // post login actions required:
            ctlDocs.PopulateFolders();
            ctlProjects.PopulateNewMenu();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            foreach (Control ctl in panClient.Controls)
            {
                if (ctl.Visible)
                {
                    ctlUIPanel uiCtl = (ctlUIPanel)ctl;
                    Cursor = Cursors.WaitCursor;
                    uiCtl.Refresh();
                    Cursor = Cursors.Default;
                    break;
                }
            }
        }

        public void AskRefreshDocuments()
        {
            Cursor = Cursors.WaitCursor;
            ctlDocs.Refresh();
            Cursor = Cursors.Default;
        }

        public void AskRefreshProjects()
        {
            Cursor = Cursors.WaitCursor;
            ctlProjects.RefreshDocuments();
            Cursor = Cursors.Default;
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentCheckOut
{
    public partial class frmJob : Form
    {
        CJob currentJob;
        bool jobClosed = false;
        bool needSave = false;

        private class MovementDetails
        {
            public string Including;
            public string Notes;
            public int Quantity;
            public bool Back;
            public bool Issue;

            public MovementDetails()
            {
                Quantity = 1;
                Back = false;
                Issue = false;
            }

            public void Reset()
            {
                Including = "";
                Notes = "";
                Quantity = 1;
                Back = false;
                Issue = false;
            }
        }

        const string CheckInButtonCheckIn = "Check In";
        const string CheckInButtonClose = "Close Job";
        const string CheckInButtonOpen = "Open Job";

        const string CheckText = " (Checked In)";
        const string AddComment = "";
        const string HasComment = "Has Comment";
        const string HasProblem = "Has Problem";

        const string ContMenuCheckIn = "Check In Item";
        const string ContMenuCheckIns = "Check In Items";
        const string ContMenuUnCheckIn = "UnCheck In Item";
        const string ContMenuUnCheckIns = "UnCheck In Items";

        const string ListItemAddItem = "ADDITEM";
        const string ListItemAddCase = "ADDCASE";
        const string ListGroupAdd = "ADD";

        public frmJob()
        {
            InitializeComponent();
            currentJob = null;

            this.Text = "New Job";

            dtpOut.Value = DateTime.Today.AddDays(1);
            dtpIn.Value = DateTime.Today.AddDays(2);

            AddLastLineToList();

            needSave = false;
        }

        public frmJob(CJob Job)
        {
            InitializeComponent();
            currentJob = Job;

            this.Text = currentJob.Job;

            txtID.Text = currentJob.ID.ToString();
            txtJobName.Text = currentJob.Job;
            txtProd.Text = currentJob.Production;
            dtpOut.Value = currentJob.CheckOut;
            dtpIn.Value = currentJob.CheckIn;
            txtIssuedBy.Text = currentJob.IssuedBy;
            txtPickedUpBy.Text = currentJob.PickedUpBy;
            txtCheckedBy.Text = currentJob.CheckedInBy;
            txtOpenDesk.Text = currentJob.OpenDeskDocumentNo;
            txtCrew.Text = currentJob.Crew;
            txtNotes.Text = currentJob.Notes;

            PopulateMovements();
            if (currentJob.Status != CJob.JobStatus.NoEquipment)
            {
                tsbPrint.Enabled = true;
                tsbCheckIn.Enabled = true;
            }
            else
            {
                tsbPrint.Enabled = false;
                tsbCheckIn.Enabled = false;
            }

            jobClosed = currentJob.IsClosed;
            DisableJob(currentJob.IsClosed);
            
            needSave = false;
        }

        private int GetLastVisibleItemIndex()
        {
            int result = 0;
            foreach (ListViewItem lvi in lvwMoves.Items)
            {
                if (lvi.Bounds.Bottom < lvwMoves.ClientRectangle.Bottom)
                {
                    result = lvi.Index;
                }
            }
            return result;
        }

        private void PopulateMovements()
        {
            //int lvisible = GetLastVisibleItemIndex();
            lvwMoves.BeginUpdate();
            lvwMoves.Items.Clear();
            lvwMoves.Groups.Clear();
            ListViewGroup lvg = new ListViewGroup();
            ListViewItem lvi;
            Font fb = new System.Drawing.Font(lvwMoves.Font.FontFamily, lvwMoves.Font.Size, FontStyle.Bold);

            DataTable moves = new CMovements().MovementsByJob(currentJob.ID);
            int _thiscase = 0;
            foreach (DataRow m in moves.Rows)
            {
                if ((int)m["CaseID"] != _thiscase)
                {
                    // start a group
                    string _thiscasename = m["CaseName"].ToString();
                    _thiscase = (int)m["CaseID"];
                    lvg = lvwMoves.Groups[_thiscase.ToString()];
                    if (lvg == null)
                        lvg = AddGroupToList(_thiscasename, _thiscase);
                }

                MovementDetails moveDetails = new MovementDetails();
                
                lvi = new ListViewItem(m["ItemID"].ToString());
                lvi.Tag = (int)m["ID"];
                lvi.Name = m["ItemID"].ToString();
                lvi.ToolTipText = m["Description"].ToString();
                lvi.SubItems.Add(m["Name"].ToString());
                lvi.SubItems.Add(m["SerNo"].ToString());
                moveDetails.Quantity = (int)m["Quantity"];
                lvi.SubItems.Add(moveDetails.Quantity.ToString());
                if ((int)m["Back"] == 1)
                {
                    moveDetails.Back = true;   
                    lvi.SubItems[1].Text += CheckText;
                    lvi.ForeColor = Color.Gray;
                    lvi.SubItems[1].ForeColor = Color.Gray;
                    lvi.SubItems[2].ForeColor = Color.Gray;
                    lvi.SubItems[3].ForeColor = Color.Gray;
                }
                lvi.UseItemStyleForSubItems = false;
                moveDetails.Notes = m["Notes"].ToString();
                moveDetails.Including = m["ItemIncluding"].ToString();
                if (moveDetails.Including.Length > 0)
                    lvi.SubItems[1].Font = fb;
                if ((int)m["HasIssue"] == 1)
                {
                    lvi.SubItems.Add(HasProblem).ForeColor = Color.Red;
                    moveDetails.Issue = true;
                }
                else
                {
                    if (m["Notes"].ToString().Length > 0)
                        lvi.SubItems.Add(HasComment).ForeColor = Color.Gray;
                    else
                        lvi.SubItems.Add(AddComment).ForeColor = Color.Navy;
                }
                lvi.SubItems[3].Tag = moveDetails;
                lvg.Items.Add(lvi);
                lvwMoves.Items.Add(lvi);

            }

            if (currentJob.IsClosed != true)
                AddLastLineToList();

            lvwMoves.EndUpdate();
            //if (lvisible > lvwMoves.Items.Count)
            //    lvwMoves.Items[lvwMoves.Items.Count-1].EnsureVisible();
            //else
            //    lvwMoves.Items[lvisible+1].EnsureVisible();
        }

        private void AddLastLineToList()
        {
            foreach (ListViewGroup g in lvwMoves.Groups)
            {
                AddLastLineToGroup(g);
            }

            ListViewGroup lvg = new ListViewGroup("");
            lvg.Tag = -2;
            lvg.Name = ListGroupAdd;
            lvwMoves.Groups.Add(lvg);
            ListViewItem lvi = new ListViewItem();
            lvi.Tag = -2;
            lvi.Name = ListItemAddCase;
            lvi.ForeColor = Color.Navy;
            lvi.ToolTipText = "Add More Cases To The List";
            lvi.SubItems.Add("Add Cases...");
            lvg.Items.Add(lvi);
            lvwMoves.Items.Add(lvi);
        }

        private void AddLastLineToGroup(ListViewGroup grp)
        {
            ListViewItem lvi = new ListViewItem();
            lvi.Tag = -1;
            lvi.ForeColor = Color.Navy;
            lvi.Name = ListItemAddItem;
            lvi.ToolTipText = "Add Another Item To This Case";
            lvi.SubItems.Add("Add Items...");
            grp.Items.Add(lvi);
            lvwMoves.Items.Add(lvi);
        }

        private void AddMovementToList(CItem Item, int Quantity, ListViewGroup grp)
        {
            if (lvwMoves.Items[Item.ID.ToString()] == null)
            {
                ListViewItem lvi = CreateMovementFromItem(Item, Quantity);
                grp.Items.Add(lvi);
                lvwMoves.Items.Add(lvi);
            }
        }

        private ListViewItem CreateMovementFromItem(CItem Item, int Quantity)
        {
            Font fb = new System.Drawing.Font(lvwMoves.Font.FontFamily, lvwMoves.Font.Size, FontStyle.Bold);
            ListViewItem lvi = new ListViewItem(Item.ID.ToString());
            MovementDetails md = new MovementDetails();
            md.Including = Item.Including;
            md.Quantity = Quantity;
            lvi.Tag = 0;
            lvi.Name = Item.ID.ToString();
            lvi.ToolTipText = Item.Description;
            lvi.SubItems.Add(Item.Name);
            lvi.SubItems.Add(Item.SerialNo);
            lvi.SubItems.Add(Quantity.ToString());
            lvi.UseItemStyleForSubItems = false;
            lvi.SubItems.Add(AddComment).ForeColor = Color.Navy;
            lvi.SubItems[3].Tag = md;
            if (Item.Including.Length > 0)
                lvi.SubItems[1].Font = fb;

            return lvi;
        }

        private ListViewGroup AddGroupToList(string CaseName, int CaseID)
        {
            if (lvwMoves.Groups[CaseID.ToString()] == null)
            {
                ListViewGroup lvg = new ListViewGroup(CaseName);
                lvg.Name = CaseID.ToString();
                lvg.Tag = CaseID;
                lvwMoves.Groups.Add(lvg);
                return lvg;
            }
            else
                return null;
        }

        private void txtJobName_TextChanged(object sender, EventArgs e)
        {
            tsbSave.Enabled = (txtJobName.Text.Length > 0);
            needSave = true;
        }

        public int JobID
        {
            get
            {
                return currentJob.ID;
            }
        }

        private void dtpOut_ValueChanged(object sender, EventArgs e)
        {
            dtpIn.Value = dtpOut.Value.AddDays(1);
            needSave = true;
        }

        private void txtProd_TextChanged(object sender, EventArgs e)
        {
            needSave = true;
        }

        private void dtpIn_ValueChanged(object sender, EventArgs e)
        {
            needSave = true;
        }

        private void lvwMoves_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (jobClosed == false)
            {
                if (lvwMoves.SelectedItems.Count > 0)
                {
                    int Idx = lvwMoves.SelectedItems[0].Index;
                    ListViewItem lvi = lvwMoves.SelectedItems[0];
                    int id = (int)lvi.Tag;
                    switch (id)
                    {
                        case -2:
                            AddCase();
                            break;

                        case -1:
                            AddItem();
                            break;

                        default:
                            openItemToolStripMenuItem_Click(this, new EventArgs());
                            break;
                    }
                }
            }
        }

        private void lvwMoves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvwMoves.SelectedItems.Count > 0)
            {
                PopulateDetails(lvwMoves.SelectedItems[0]);
            }
        }

        private void PopulateDetails(ListViewItem MItem)
        {
            int id = (int)MItem.Tag;
            MovementDetails moveDetails = new MovementDetails();
            if (id > -1) moveDetails = (MovementDetails)MItem.SubItems[3].Tag;
            txtMIncluding.Text = moveDetails.Including;
            txtMNotes.Text = moveDetails.Notes;
            nudMQtty.Value = moveDetails.Quantity;
            chkMBack.Checked = moveDetails.Back;
            chkMIssue.Checked = moveDetails.Issue;
            gpbDetails.Tag = MItem;
            if (jobClosed == false)
                foreach (Control c in gpbDetails.Controls)
                {
                    c.Enabled = (id > -1);
                }
            else
                foreach (Control c in gpbDetails.Controls)
                {
                    c.Enabled = false;
                }
            if (id == 0)
            {
                chkMBack.Enabled = false;
                chkMIssue.Enabled = false;
            }
        }

        //private void UpdateMovementInList(int ListIndex, CMovement move)
        //{
        //    ListViewItem lvi = lvwMoves.Items[ListIndex];
        //    CItem item = move.Item;
        //    lvi.Text = item.ID.ToString();                  // = new ListViewItem(m["ItemID"].ToString());
        //    lvi.Tag = move.ID;                              // (int)m["ID"];
        //    lvi.ToolTipText = item.Description;             // m["Description"].ToString();
        //    lvi.SubItems[1].Text = item.Name;               //.Add(m["Name"].ToString());
        //    lvi.SubItems[2].Text = item.SerialNo;           //.Add(m["SerNo"].ToString());
        //    lvi.SubItems[3].Text = move.Quantity.ToString();//.Add(m["Quantity"].ToString());
        //    if (move.Back == true)                          // ((int)m["Back"] == 1)
        //    {
        //        lvi.SubItems[1].Text += " (Checked back)";
        //        lvi.SubItems[1].ForeColor = Color.Gray;
        //    }
        //    else
        //        lvi.SubItems[1].ForeColor = lvi.ForeColor;
        //    lvi.UseItemStyleForSubItems = false;
        //    if (move.HasIssue == true)                      // ((int)m["HasIssue"] == 1)
        //    {
        //        lvi.SubItems[4].Text = "Has Problem";       // .Add("Has Problem").ForeColor = Color.Red;
        //        lvi.SubItems[4].ForeColor = Color.Red;
        //    }
        //    else
        //    {
        //        if (move.Notes.Length > 0)                  // (m["Notes"].ToString().Length > 0)
        //        {
        //            lvi.SubItems[4].Text = "Has Comment";   //.Add("Has Comment").ForeColor = Color.Gray;
        //            lvi.SubItems[4].ForeColor = Color.Gray;
        //        }
        //        else
        //        {
        //            lvi.SubItems[4].Text = "Add Commnet";   //.Add("Add Comment...").ForeColor = Color.Navy;
        //            lvi.SubItems[4].ForeColor = Color.Navy;
        //        }
        //    }
        //    item.Dispose();
        //    lvi.Selected = false;
        //}

        private void SaveJob()
        {
            // if a new job then add a new job to DB and return object
            if (currentJob == null)
                currentJob = new CJobs().NewJob(txtJobName.Text, dtpOut.Value, dtpIn.Value);
            // update fields:
            currentJob.Job = txtJobName.Text;
            currentJob.CheckOut = dtpOut.Value;
            currentJob.CheckIn = dtpIn.Value;
            currentJob.IssuedBy = txtIssuedBy.Text;
            currentJob.PickedUpBy = txtPickedUpBy.Text;
            currentJob.CheckedInBy = txtCheckedBy.Text;
            currentJob.Production = txtProd.Text;
            currentJob.OpenDeskDocumentNo = txtOpenDesk.Text;
            currentJob.Crew = txtCrew.Text;
            currentJob.Notes = txtNotes.Text;
            currentJob.Update();

            // mark all previous db movements as deleted:
            currentJob.DeleteAllMovements(true);

            // read list and add all new movements to db:
            int moveCount = 0;
            using (CRecord rec = new CRecord())
            {
                //rec.DBConnection.Open();

                for (int cx = 0; cx < lvwMoves.Groups.Count; cx++)
                {
                    int caseID = (int)lvwMoves.Groups[cx].Tag;
                    for (int ix = 0; ix < lvwMoves.Groups[cx].Items.Count; ix++)
                    {
                        // add this item to db
                        int itemID = 0;
                        int.TryParse(lvwMoves.Groups[cx].Items[ix].Name, out itemID);
                        if (itemID > 0)
                        {
                            string insertInto = "INSERT INTO Movement "
                                                    + "(Quantity, ItemID, ItemIncluding, CaseID, JobID, Notes, Back, HasIssue) "
                                                    + "VALUES "
                                                    + "(@Quantity, @ItemID, @ItemIncluding, @CaseID, @JobID, @Notes, @Back, @HasIssue)";
                            SqlCommand cmd = new SqlCommand();
                            //cmd.Connection = rec.DBConnection;
                            cmd.CommandText = insertInto;

                            ListViewItem lvi = lvwMoves.Groups[cx].Items[ix];
                            MovementDetails md = (MovementDetails)lvi.SubItems[3].Tag;

                            cmd.Parameters.AddWithValue("@Quantity", md.Quantity);
                            cmd.Parameters.AddWithValue("@ItemID", itemID);
                            cmd.Parameters.AddWithValue("@ItemIncluding", md.Including + "");
                            cmd.Parameters.AddWithValue("@CaseID", caseID);
                            cmd.Parameters.AddWithValue("@JobID", currentJob.ID);
                            cmd.Parameters.AddWithValue("@Notes", md.Notes + "");
                            cmd.Parameters.AddWithValue("@Back", Convert.ToInt32(md.Back).ToString() + "");
                            cmd.Parameters.AddWithValue("@HasIssue", Convert.ToInt32(md.Issue).ToString() + "");
                            cmd.ExecuteNonQuery();

                            moveCount++;
                        }
                    }
                }
            }
            // verify all records added
            if (currentJob.HasMovements == moveCount)
            {
                // premanentally delete old movements from db:
                currentJob.DeleteMarkedMovements();
                // 
                needSave = false;
                PopulateMovements();
                this.Text = currentJob.Job;
                if (currentJob.Status != CJob.JobStatus.NoEquipment)
                {
                    tsbPrint.Enabled = true;
                    tsbCheckIn.Enabled = true;
                }
                else
                {
                    tsbPrint.Enabled = false;
                    tsbCheckIn.Enabled = false;
                }
            }
            else
                MessageBox.Show("Not all items saved...", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            SaveJob();
        }

        private void tsbCheckIn_Click(object sender, EventArgs e)
        {
            switch (tsbCheckIn.Text)
            {
                case CheckInButtonCheckIn:
                    switch (MessageBox.Show("Close this Job?", "Check In", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.No:
                            currentJob.CheckAllItemsIn();
                            PopulateMovements();
                            break;

                        case DialogResult.Yes:
                            currentJob.CheckAllItemsIn();
                            currentJob.CloseJob();
                            
                            jobClosed = true;
                            PopulateMovements();
                            DisableJob(true);
                            break;

                        case DialogResult.Cancel:
                            break;
                    }
                    break;

                case CheckInButtonOpen:
                    if (MessageBox.Show("Open This Job?", "Open Job", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        currentJob.UncloseJob();
                        jobClosed = false;
                        DisableJob(false);
                        PopulateMovements();
                    }
                    break;

                case CheckInButtonClose:
                    currentJob.CloseJob();
                    PopulateMovements();
                    DisableJob(true);
                    break;
            }
            if (lvwMoves.Items.Count > 0) PopulateDetails(lvwMoves.Items[0]);
        }

        private void DisableJob(bool Close)
        {
            txtJobName.Enabled = !Close;
            txtProd.Enabled = !Close;
            dtpIn.Enabled = !Close;
            dtpOut.Enabled = !Close;
            txtOpenDesk.Enabled = !Close;
            txtCrew.Enabled = !Close;
            txtIssuedBy.Enabled = !Close;
            txtPickedUpBy.Enabled = !Close;
            txtCheckedBy.Enabled = !Close;
            txtNotes.Enabled = !Close;
            tsbSave.Enabled = !Close;
            if (Close == false)
                if(currentJob.Status == CJob.JobStatus.EquipmentOut)
                    tsbCheckIn.Text = CheckInButtonCheckIn;
                else
                    tsbCheckIn.Text = CheckInButtonClose;
            else
                tsbCheckIn.Text = CheckInButtonOpen;
            lblClosed.Visible = Close;
        }

        private void tsbPrint_Click(object sender, EventArgs e)
        {
            CPrintManifest pm = new CPrintManifest(currentJob);
            PrintDialog pd = new PrintDialog();
            pd.Document = pm;
            if (pd.ShowDialog() == DialogResult.OK)
            {
                pm.PrinterSettings = pd.PrinterSettings;
                pm.Print();
            }
        }

        private void tsbPreview_Click(object sender, EventArgs e)
        {
            CPrintManifest pm = new CPrintManifest(currentJob);
            pm.ShowPreview();
            pm.Dispose();
        }

        private void frmJob_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            { 
                currentJob.Dispose();
                this.DialogResult = DialogResult.OK;
            }
            catch { }
        }

        private void RemoveCase()
        {
            if (MessageBox.Show("Remove the case and all it's contents from this job?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                // 19.03.2014 - changes in movement will not be saved in db but only
                //              the listview.
                //==================================================================
                //ListViewGroup grp = lvwMoves.SelectedItems[0].Group;
                //string where = " WHERE (ID = ";
                //foreach (ListViewItem item in grp.Items)
                //{
                //    if ((int)item.Tag > 0)
                //        where += item.Tag.ToString() + ") OR (ID = ";
                //    item.Remove();
                //}
                //where = where.Substring(0, where.Length - 11) + ")";
                //MessageBox.Show(where);
                //CRecord rec = new CRecord(new SqlCommand("DELETE FROM Movement" + where));
                //rec.Dispose();
                //PopulateMovements();
                //===================================================================

                ListViewGroup lvg = lvwMoves.SelectedItems[0].Group;
                for (int i = lvg.Items.Count; i > 0; i--)
                {
                    lvwMoves.Items.Remove(lvg.Items[i - 1]);
                }
                lvwMoves.Groups.Remove(lvg);
                needSave = true;

                PopulateDetails(lvwMoves.Items[lvwMoves.Items.Count - 1]);

                EnableToolBarButtons();
            }
        }

        private void RemoveItem()
        {
            if (MessageBox.Show("Remove the selected Items from this job?",
                "Confirm",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                foreach (ListViewItem lvi in lvwMoves.SelectedItems)
                {
                    int id = (int)lvi.Tag;
                    if (id > 0)
                    {
                        // 19.03.2014 - changes in movement will not be saved in db but only
                        //              the listview.
                        //==================================================================
                        //CMovement move = new CMovement(id);
                        //CRecord rec = new CRecord(new SqlCommand("DELETE FROM Movement WHERE ID = " + move.ID));
                        //move.Dispose();
                        lvi.Remove();
                        PopulateDetails(lvwMoves.Items[lvwMoves.Items.Count - 1]);
                        needSave = true;
                    }
                }
                EnableToolBarButtons();
            }
        }

        private void AddItem()
        {
            int case_id = (int)lvwMoves.SelectedItems[0].Group.Tag;

            frmFindItem ffi = new frmFindItem();
            if (ffi.ShowDialog(this) == DialogResult.OK)
            {
                ListViewGroup grp = lvwMoves.SelectedItems[0].Group;
                if (ffi.GetSelectedItems() != null)
                {
                    grp.Items[ListItemAddItem].Remove();

                    foreach (CItem item in ffi.GetSelectedItems())
                    {
                        // 19.03.2014 - changes in movement will not be saved in db but only
                        //              the listview.
                        //==================================================================
                        //CMovement newmove = new CMovements().NewMovement(currentJob.ID, item, case_id);
                        AddMovementToList(item, 1, grp);
                        //newmove.Dispose();
                        //iD = item.ID;
                    }
                    ffi.Close();
                    ffi.Dispose();
                    //PopulateMovements();
                    AddLastLineToGroup(grp);
                    needSave = true;
                }
            }
            EnableToolBarButtons();
        }

        private void ReplaceItem(ListViewItem ListItem)
        {
            int case_id = (int)ListItem.Group.Tag;

            frmFindItem ffi = new frmFindItem();
            if (ffi.ShowDialog(this) == DialogResult.OK)
            {
                CItem item = ffi.FirstItem;
                if (item != null)
                {
                    if (lvwMoves.Items[item.ID.ToString()] == null)
                    {
                        lvwMoves.BeginUpdate();

                        ListViewGroup grp = ListItem.Group;
                        if (ffi.GetSelectedItems() != null)
                        {
                            int idx = ListItem.Index;
                            Font fb = new System.Drawing.Font(lvwMoves.Font.FontFamily, lvwMoves.Font.Size, FontStyle.Bold);
                            MovementDetails md = new MovementDetails();
                            lvwMoves.Items[idx].Tag = 0;
                            lvwMoves.Items[idx].Name = item.ID.ToString();
                            md.Including = item.Including;
                            md.Quantity = 1;
                            lvwMoves.Items[idx].ToolTipText = item.Description;
                            lvwMoves.Items[idx].SubItems[1].Text = item.Name;
                            lvwMoves.Items[idx].SubItems[2].Text = item.SerialNo;
                            lvwMoves.Items[idx].SubItems[3].Text = "1";
                            lvwMoves.Items[idx].SubItems[4].Text = "";
                            lvwMoves.Items[idx].SubItems[3].Tag = md;
                            if (md.Including.Length > 0)
                                lvwMoves.Items[idx].SubItems[1].Font = fb;
                            else
                                lvwMoves.Items[idx].SubItems[1].Font = lvwMoves.Font;

                            PopulateDetails(lvwMoves.Items[idx]);

                            ffi.Close();
                            ffi.Dispose();
                            needSave = true;
                        }

                        lvwMoves.EndUpdate();
                    }
                    else
                        MessageBox.Show(item.Name + " is already on the list.", "Replace Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            EnableToolBarButtons();
        }

        private int GetLastIndexOfGroup(ListViewItem lvi)
        {
            int result = lvi.Index;
            foreach (ListViewItem lvim in lvi.Group.Items)
            {
                result = lvim.Index;
            }
            return result;
        }

        private int GetIndexOfItem(int ItemID)
        {
            int result = 0;
            foreach (ListViewItem lvi in lvwMoves.Items)
            {
                CMovement move = new CMovement((int)lvi.Tag);
                if (move.Item.ID == ItemID)
                {
                    result = lvi.Index;
                    break;
                }
            }
            return result;
        }

        private void AddCase()
        {
            frmFindCase ffc = new frmFindCase();
            if (ffc.ShowDialog(this) == DialogResult.OK)
            {
                if (ffc.GetSelectedCases() != null)
                {
                    foreach (CCase cs in ffc.GetSelectedCases())
                    {
                        ListViewGroup lvg = AddGroupToList(cs.CaseName, cs.ID);
                        if (lvg != null)
                        {
                            foreach (DataRow row in cs.DefaultItems.Rows)
                            {
                                // 19.03.2014 - changes in movement will not be saved in db but only
                                //              the listview.
                                //moves.NewMovement(currentJob.ID, new CItem((int)row["ID"]), cs.ID);
                                AddMovementToList(new CItem((int)row["ID"]), (int)row["DefaultQtty"], lvg);
                            }
                            AddLastLineToGroup(lvg);
                            needSave = true;
                        }
                    }
                    ffc.Close();
                    ffc.Dispose();
                    ListViewGroup addGroup = lvwMoves.Groups[ListGroupAdd];
                    lvwMoves.Groups.Remove(addGroup);
                    lvwMoves.Groups.Add(addGroup);
                    lvwMoves.SelectedItems[0].Selected = false;
                    lvwMoves.Items[ListItemAddCase].EnsureVisible();
                }
            }
            EnableToolBarButtons();
        }

        private void EnableToolBarButtons()
        {
            if (currentJob != null)
            {
                // enable buttons
                bool hasMoves = false;
                int id;
                foreach (ListViewItem i in lvwMoves.Items)
                {
                    int.TryParse(i.Text, out id);
                    if (id > 0)
                    {
                        hasMoves = true;
                        break;
                    }
                }
                tsbPrint.Enabled = hasMoves;
                tsbCheckIn.Enabled = hasMoves;
            }
        }

        //private void openMovementToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    if (currentJob.IsClosed == false)
        //    {
        //        if (lvwMoves.SelectedItems.Count > 0)
        //        {
        //            int Idx = lvwMoves.SelectedItems[0].Index;
        //            ListViewItem lvi = lvwMoves.SelectedItems[0];
        //            int id = (int)lvi.Tag;
        //            frmMovement MoveFrm = new frmMovement(new CMovement(id));
        //            if (MoveFrm.ShowDialog(this) == DialogResult.OK)
        //            {
        //                PopulateMovements();
        //                try
        //                {
        //                    lvwMoves.Items[Idx].EnsureVisible();
        //                    lvwMoves.Items[Idx].Selected = true;
        //                }
        //                catch { }
        //                MoveFrm.Close();
        //                MoveFrm.Dispose();
        //            }
        //        }
        //    }
        //}

        private void openItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwMoves.SelectedItems.Count > 0)
            {
                int Idx = lvwMoves.SelectedItems[0].Index;
                ListViewItem lvi = lvwMoves.SelectedItems[0];
                int id = int.Parse(lvi.Text);
                frmItem fi = new frmItem(new CItem(id),0);
                if (fi.ShowDialog(this) == DialogResult.OK)
                {
                    // update this list item
                    lvwMoves.Items[Idx].SubItems[1].Text = fi.Item.Name;
                    lvwMoves.Items[Idx].SubItems[2].Text = fi.Item.SerialNo;
                    fi.Close();
                    fi.Dispose();
                }
            }
        }

        private void cmsMovements_Opening(object sender, CancelEventArgs e)
        {
            if (jobClosed == true)
            {
                e.Cancel = true;
                return;
            }
            if (MousePosition.Y < (this.Top + 100))
            {
                e.Cancel = true;
                return;
            }

            if (lvwMoves.SelectedItems.Count == 0)
            {
                e.Cancel = true;
                return;
            }

            ListViewItem lvi = lvwMoves.SelectedItems[0];
            int tag = (int)lvi.Tag;
            if (tag < 0)
                e.Cancel = true;
            else
            {
                // enable or disable items on the menu:
                cmsiCheckBack.Enabled = (tag > 0);
                if (lvi.ForeColor == Color.Gray)
                    cmsiCheckBack.Text = ContMenuUnCheckIn;
                else
                    cmsiCheckBack.Text = ContMenuCheckIn;

            }
        }

        private void cmsiCheckBack_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lvi in lvwMoves.SelectedItems)
            {
                // 19.03.2014 - changes in movement will not be saved in db but only
                //              the listview.
                //==================================================================
                //int id = (int)lvi.Tag;
                //CMovement move = new CMovement(id);
                //CRecord rec = new CRecord(new SqlCommand("Update Movement Set Back = 1 WHERE ID = " + move.ID));
                //move.Dispose();
                if ((int)lvi.Tag > -1)
                {
                    MovementDetails md = (MovementDetails)lvi.SubItems[3].Tag;
                    if (lvi.ForeColor == Color.Gray)
                    {
                        lvi.SubItems[1].Text = lvi.SubItems[1].Text.Substring(0, lvi.SubItems[1].Text.Length - CheckText.Length);
                        lvi.ForeColor = SystemColors.WindowText;
                        lvi.SubItems[1].ForeColor = SystemColors.WindowText;
                        lvi.SubItems[2].ForeColor = SystemColors.WindowText;
                        lvi.SubItems[3].ForeColor = SystemColors.WindowText;
                        md.Back = false;
                        chkMBack.Checked = false;
                    }
                    else
                    {
                        lvi.SubItems[1].Text += CheckText;
                        lvi.ForeColor = Color.Gray;
                        lvi.SubItems[1].ForeColor = Color.Gray;
                        lvi.SubItems[2].ForeColor = Color.Gray;
                        lvi.SubItems[3].ForeColor = Color.Gray;
                        md.Back = true;
                        chkMBack.Checked = true;
                    }
                    lvi.Selected = false;
                    needSave = true;
                }
            }
        }

        private void cmsiAddCase_Click(object sender, EventArgs e)
        {
            AddCase();
        }

        private void cmsiRemoveCase_Click(object sender, EventArgs e)
        {
            RemoveCase();
        }

        private void cmsiAddItem_Click(object sender, EventArgs e)
        {
            AddItem();
        }

        private void cmsiReplaceItem_Click(object sender, EventArgs e)
        {
            ReplaceItem(lvwMoves.SelectedItems[0]);
        }

        private void cmsiRemoveItem_Click(object sender, EventArgs e)
        {
            RemoveItem();
        }

        private void nudMQtty_ValueChanged(object sender, EventArgs e)
        {
            if (nudMQtty.Focused == true)
            {
                if (lvwMoves.SelectedItems.Count > 0)
                {
                    ListViewItem MItem = (ListViewItem)gpbDetails.Tag;
                    if ((int)MItem.Tag > -1)
                    {
                        lvwMoves.SelectedItems[0].SubItems[3].Text = nudMQtty.Value.ToString();
                        MovementDetails md = (MovementDetails)MItem.SubItems[3].Tag;
                        md.Quantity = (int)nudMQtty.Value;
                        needSave = true;
                    }
                }
            }
        }

        private void chkMIssue_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMIssue.Focused == true)
            {
                if (lvwMoves.SelectedItems.Count > 0)
                {
                    ListViewItem MItem = (ListViewItem)gpbDetails.Tag;
                    MovementDetails md = (MovementDetails)MItem.SubItems[3].Tag;
                    if ((int)MItem.Tag > -1)
                    {
                        if (chkMIssue.Checked == true)
                        {
                            lvwMoves.SelectedItems[0].SubItems[4].Text = HasProblem;
                            lvwMoves.SelectedItems[0].SubItems[4].ForeColor = Color.Red;
                        }
                        else
                            if (md.Notes.Length > 0)
                            {
                                lvwMoves.SelectedItems[0].SubItems[4].Text = HasComment;
                                lvwMoves.SelectedItems[0].SubItems[4].ForeColor = Color.Gray;
                            }
                            else
                            {
                                lvwMoves.SelectedItems[0].SubItems[4].Text = AddComment;
                                lvwMoves.SelectedItems[0].SubItems[4].ForeColor = Color.Navy;
                            }
                        md.Issue = chkMIssue.Checked;
                        needSave = true;
                    }
                }
            }
        }

        private void chkMBack_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMBack.Focused == true)
            {
                if (lvwMoves.SelectedItems.Count > 0)
                {
                    ListViewItem MItem = (ListViewItem)gpbDetails.Tag;
                    MovementDetails md = (MovementDetails)MItem.SubItems[3].Tag;
                    if ((int)MItem.Tag > -1)
                    {
                        if (chkMBack.Checked == false)
                        {
                            lvwMoves.SelectedItems[0].SubItems[1].Text = lvwMoves.SelectedItems[0].SubItems[1].Text.Substring(0, lvwMoves.SelectedItems[0].SubItems[1].Text.Length - CheckText.Length);
                            lvwMoves.SelectedItems[0].ForeColor = SystemColors.WindowText;
                            lvwMoves.SelectedItems[0].SubItems[1].ForeColor = SystemColors.WindowText;
                            lvwMoves.SelectedItems[0].SubItems[2].ForeColor = SystemColors.WindowText;
                            lvwMoves.SelectedItems[0].SubItems[3].ForeColor = SystemColors.WindowText;
                        }
                        else
                        {
                            lvwMoves.SelectedItems[0].SubItems[1].Text += CheckText;
                            lvwMoves.SelectedItems[0].ForeColor = Color.Gray;
                            lvwMoves.SelectedItems[0].SubItems[1].ForeColor = Color.Gray;
                            lvwMoves.SelectedItems[0].SubItems[2].ForeColor = Color.Gray;
                            lvwMoves.SelectedItems[0].SubItems[3].ForeColor = Color.Gray;
                        }
                        md.Back = chkMBack.Checked;
                        needSave = true;
                    }
                }
            }
        }

        private void txtMNotes_Validated(object sender, EventArgs e)
        {
            if (lvwMoves.SelectedItems.Count > 0)
            {
                ListViewItem MItem = (ListViewItem)gpbDetails.Tag;
                MovementDetails md = (MovementDetails)MItem.SubItems[3].Tag;
                if ((int)MItem.Tag > -1)
                {
                    md.Notes = txtMNotes.Text;
                    if (md.Issue == true)
                    {
                        lvwMoves.SelectedItems[0].SubItems[4].Text = HasProblem;
                        lvwMoves.SelectedItems[0].SubItems[4].ForeColor = Color.Red;
                    }
                    else
                        if (md.Notes.Length > 0)
                        {
                            lvwMoves.SelectedItems[0].SubItems[4].Text = HasComment;
                            lvwMoves.SelectedItems[0].SubItems[4].ForeColor = Color.Gray;
                        }
                        else
                        {
                            lvwMoves.SelectedItems[0].SubItems[4].Text = AddComment;
                            lvwMoves.SelectedItems[0].SubItems[4].ForeColor = Color.Navy;
                        }
                    needSave = true;
                }
            }
        }

        private void txtMIncluding_Validated(object sender, EventArgs e)
        {
            if (lvwMoves.SelectedItems.Count > 0)
            {
                ListViewItem MItem = (ListViewItem)gpbDetails.Tag;
                MovementDetails md = (MovementDetails)MItem.SubItems[3].Tag;
                Font fb = new System.Drawing.Font(lvwMoves.Font.FontFamily, lvwMoves.Font.Size, FontStyle.Bold);
                if ((int)MItem.Tag > -1)
                {
                    md.Including = txtMIncluding.Text;
                    if (txtMIncluding.Text.Length > 0)
                        lvwMoves.SelectedItems[0].SubItems[1].Font = fb;
                    needSave = true;
                }
            }
        }

        private void lvwMoves_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            // paint the selected item so it will be visible when listview loses focus
            if ((int)e.Item.Tag > -1)
            {
                if (e.Item.Selected)
                {
                    e.Item.BackColor = Color.LightBlue;
                    e.Item.SubItems[1].BackColor = Color.LightBlue;
                    e.Item.SubItems[2].BackColor = Color.LightBlue;
                    e.Item.SubItems[3].BackColor = Color.LightBlue;
                    e.Item.SubItems[4].BackColor = Color.LightBlue;
                }
                else
                {
                    e.Item.BackColor = SystemColors.Window;
                    e.Item.SubItems[1].BackColor = SystemColors.Window;
                    e.Item.SubItems[2].BackColor = SystemColors.Window;
                    e.Item.SubItems[3].BackColor = SystemColors.Window;
                    e.Item.SubItems[4].BackColor = SystemColors.Window;
                }
            }
        }

        private void txtJobName_Validating(object sender, CancelEventArgs e)
        {
            //if (txtJobName.Text.Length == 0)
            //{
            //    MessageBox.Show("You must provide a Job Name", "Can't Proceed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    e.Cancel = true;
            //}
        }

        private void txtCrew_TextChanged(object sender, EventArgs e)
        {
            needSave = true;
        }

        private void txtIssuedBy_TextChanged(object sender, EventArgs e)
        {
            needSave = true;
        }

        private void txtPickedUpBy_TextChanged(object sender, EventArgs e)
        {
            needSave = true;
        }

        private void txtCheckedBy_TextChanged(object sender, EventArgs e)
        {
            needSave = true;
        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {
            needSave = true;
        }

        private void frmJob_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (needSave == true) 
            {
                DialogResult res = MessageBox.Show("Do you want to save the changes made to this job?", "Save Changes", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (res == System.Windows.Forms.DialogResult.Yes)
                {
                    //Save Job and exit form
                    SaveJob();
                }
                else if (res == System.Windows.Forms.DialogResult.Cancel)
                    // cancel form closing
                    e.Cancel = true;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace EquipmentCheckOut
{
    public partial class frmJobs : Form
    {
        private enum JobsListStatus
        {
            OpenedJobs,
            SearchResults
        }

        public frmJobs()
        {
            InitializeComponent();
            PopulateJobsList(new CJobs().OpenedJobs, lvwJobs);
            lvwJobs.Tag = JobsListStatus.OpenedJobs;
            RefreshItemCategories();
            RefreshCaseCategories();
            UpdateByFilter();
        }

        private void frmJobs_Load(object sender, EventArgs e)
        {
            SetTab();
        }

        private void PopulateJobsList(DataTable Jobs, ListView Target)
        {
            Target.BeginUpdate();
            Target.Items.Clear();
            //bool col = false;
            ListViewItem lvi;
            if (Jobs.Rows.Count > 0)
            {
                foreach (DataRow row in Jobs.Rows)
                {
                    lvi = new ListViewItem(row["Job"].ToString());
                    lvi.Tag = (int)row["ID"];
                    lvi.SubItems.Add(row["Production"].ToString());
                    lvi.SubItems.Add(Program.FriendlyDate(DateTime.Parse(row["CheckOut"].ToString())));
                    lvi.SubItems.Add(Program.FriendlyDate(DateTime.Parse(row["CheckIn"].ToString())));
                    try
                    {
                        if (bool.Parse(row["Closed"].ToString()) == true)
                        {
                            lvi.SubItems.Add("Closed");
                            lvi.ForeColor = Color.DimGray;
                        }
                        else
                            lvi.SubItems.Add("Opened");
                    }
                    catch
                    {
                        lvi.SubItems.Add("Opened");
                    }
                    Target.Items.Add(lvi);
                }
                RefreshItems();
                tslJobs.Text = StatusStripJobs(Jobs.Rows.Count);
            }
            else
            {
                lvi = new ListViewItem("... No Job to diplay");
                lvi.ForeColor = Color.Navy;
                lvi.Tag = -1;
                Target.Items.Add(lvi);
                tslJobs.Text = StatusStripJobs(0);
            }
            Target.EndUpdate();
            EnableDel();
        }

        private void RefreshItemCategories()
        {
            tvwItemsCats.BeginUpdate();
            tvwItemsCats.Nodes.Clear();
            PopulateCategories(tvwItemsCats);
            tvwItemsCats.ExpandAll();
            tvwItemsCats.SelectedNode = tvwItemsCats.Nodes[0];
            tvwItemsCats.EndUpdate();
        }

        private void RefreshCaseCategories()
        {
            tvwCaseCat.BeginUpdate();
            tvwCaseCat.Nodes.Clear();
            PopulateCategories(tvwCaseCat);
            tvwCaseCat.ExpandAll();
            tvwCaseCat.SelectedNode = tvwCaseCat.Nodes[0];
            tvwCaseCat.EndUpdate();
        }

        private void PopulateCategories(TreeView treeView)
        {
            CategoryTreeView ctv = new CategoryTreeView(treeView);
            ctv.Dispose();
        }

        private void PopulateItems(DataTable itemsTable)
        {
            lvwItems.BeginUpdate();
            lvwItems.Items.Clear();
            DataTable dt = itemsTable;
            ListViewItem lvi;
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    lvi = new ListViewItem(row["ID"].ToString());
                    lvi.UseItemStyleForSubItems = false;
                    lvi.Tag = (int)row["ID"];
                    lvi.SubItems.Add(row["Name"].ToString());
                    lvi.SubItems.Add(row["SerNo"].ToString());

                    string status = "In House";
                    Color cs = Color.Black;
                    try
                    {
                        if ((int)row["Issue"] == 1)
                        {
                            status = "Has Problem";
                            cs = Color.Red;
                        }
                        if ((int)row["Back"] == 0)
                        {
                            status = "Out: " + row["Prod"];
                            cs = Color.Navy;
                        }
                    }
                    catch { }
                    lvi.SubItems.Add(status);

                    lvi.SubItems[3].ForeColor = cs;

                    lvi.SubItems.Add(row["CaseName"].ToString());
                    lvwItems.Items.Add(lvi);
                }
            }
            else
            {
                lvi = new ListViewItem();
                lvi.SubItems.Add("... No Item to display");
                lvi.ForeColor = Color.Navy;
                lvi.Tag = -1;
                lvwItems.Items.Add(lvi);
            }
            lvwItems.EndUpdate();
            tslItems.Text = StatusStripItems();
            EnableDel();
        }

        private void lvwJobs_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvwJobs.SelectedItems.Count > 0)
            {
                int id = (int)lvwJobs.SelectedItems[0].Tag;
                if (id > 0)
                {
                    CJob job = new CJob(id);
                    frmJob jobForm = new frmJob(job);
                    jobForm.ShowDialog(this);
                    if ((JobsListStatus)lvwJobs.Tag == JobsListStatus.SearchResults)
                        PopulateJobsList(new CJobs().SearchJobs(txtSearchJob.Text), lvwJobs);
                    else
                        PopulateJobsList(new CJobs().OpenedJobs, lvwJobs);
                }
            }
        }

        private void tvwCategories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (tvwItemsCats.Focused == true)
            {
                int id = (int)e.Node.Tag;
                PopulateItems(new CCategory(id).Items);
            }
        }

        private void lvwItems_DoubleClick(object sender, EventArgs e)
        {
            if (lvwItems.SelectedItems.Count > 0)
            {
                int viewStart = lvwItems.TopItem.Index;
                int iid = (int)lvwItems.SelectedItems[0].Tag;
                int cid = (int)tvwItemsCats.SelectedNode.Tag;
                frmItem itmForm;
                if (iid > 0)
                {
                    CItem itm = new CItem(iid);
                    int tab = 0;
                    if (itm.Status == CItem.ItemStatus.Malfunction) tab = 2;
                    itmForm = new frmItem(itm, tab);
                }
                else
                {
                    itmForm = new frmItem();
                    itmForm.SetCategory(new CCategory(cid));
                }
                if (itmForm.ShowDialog(this) == DialogResult.OK)
                    if (txtSearchItems.Text.Length > 1)
                    {
                        PopulateItems(new CItems().SearchItems(txtSearchItems.Text));
                    }
                    else
                    {
                        if (tabControl2.SelectedIndex == 0)
                            UpdateByFilter();
                        else
                        {
                            PopulateItems(new CCategory(cid).Items);
                        }
                    }
                try
                {
                    lvwItems.TopItem = lvwItems.Items[viewStart];
                }
                catch { }
                itmForm.Dispose();
            }
        }

        private void tvwCaseCat_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int id = (int)e.Node.Tag;
            PopulateCases(new CCategory(id).Cases);
        }

        private void PopulateCases(DataTable Cases)
        {
            lvwCases.BeginUpdate();
            lvwCases.Items.Clear();
            ListViewItem lvi;
            if (Cases.Rows.Count > 0)
            {
                foreach (DataRow row in Cases.Rows)
                {
                    lvi = new ListViewItem(row["CaseName"].ToString());
                    lvi.Tag = (int)row["ID"];
                    lvi.ImageIndex = 0;

                    lvwCases.Items.Add(lvi);
                }
            }
            else
            {
                lvi = new ListViewItem("... No Case to display");
                lvi.ForeColor = Color.Navy;
                lvi.Tag = -1;
                lvwCases.Items.Add(lvi);
            }
            Cases.Dispose();
            lvwCases.EndUpdate();
            EnableDel();
        }

        private void lvwCases_DoubleClick(object sender, EventArgs e)
        {
            if (lvwCases.SelectedItems.Count > 0)
            {
                int id = (int)lvwCases.SelectedItems[0].Tag;
                int cid = (int)tvwCaseCat.SelectedNode.Tag;
                frmCase cf;
                if (id > 0)
                    cf = new frmCase(new CCase(id));
                else
                {
                    cf = new frmCase();
                    cf.SetCategory(new CCategory(cid));
                }
                if (cf.ShowDialog(this) == DialogResult.OK)
                    PopulateCases(new CCategory(cid).Cases);
            }
        }

        private void FindItem(string p)
        {
            if (p.Length > 1)
            {
                switch (tabControl1.SelectedIndex)
                {

                    case 1:
                        PopulateItems(new CItems().SearchItems(p));
                        break;

                    case 2:
                        PopulateCases(new CCases().SearchCases(p));
                        break;
                }
            }
            else
            {
                int id;
                switch (tabControl1.SelectedIndex)
                {

                    case 1:
                        id = (int)tvwItemsCats.SelectedNode.Tag;
                        PopulateItems(new CCategory(id).Items);
                        break;

                    case 2:
                        id = (int)tvwCaseCat.SelectedNode.Tag;
                        PopulateCases(new CCategory(id).Cases);
                        break;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTab();
        }

        private void SetTab()
        {
            tslSchedule.Visible = false;
            tslJobs.Visible = false;
            tslItems.Visible = false;
            tslCases.Visible = false;
            EnableDel();
            switch (tabControl1.SelectedIndex)
            {
                //case 0:
                //    lblFind.Text = "Find Job:";
                //    tslSchedule.Visible = true;
                //    tsddbNew.Text = "New Job...";
                //    tsbDelJob.Text = "Delete Job";
                //    break;

                case 0:
                    tslJobs.Visible = true;
                    tsddbNew.Text = "New Job...";
                    tsbDelJob.Text = "Delete Job";
                    break;

                case 1:
                    tslItems.Visible = true;
                    tsddbNew.Text = "New Item...";
                    tsbDelJob.Text = "Delete Item";
                    break;

                case 2:
                    tslCases.Visible = true;
                    tsddbNew.Text = "New Case...";
                    tsbDelJob.Text = "Delete Case";
                    break;
            }
        }

        private void EnableDel()
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    tsbDelJob.Enabled = (lvwJobs.SelectedItems.Count > 0);
                    break;

                case 1:
                    tsbDelJob.Enabled = (lvwJobs.SelectedItems.Count > 0);
                    break;

                case 2:
                    tsbDelJob.Enabled = (lvwItems.SelectedItems.Count > 0);
                    break;

                case 3:
                    tsbDelJob.Enabled = (lvwCases.SelectedItems.Count > 0);
                    break;
            }
        }

        private void tsbOptions_Click(object sender, EventArgs e)
        {
            frmOptions fo = new frmOptions();
            if (fo.ShowDialog(this) == DialogResult.OK)
            {
                RefreshItemCategories();
                RefreshCaseCategories();
            }
        }

        private void openItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lvwItems.SelectedItems.Count > 0)
            {
                int iid = (int)lvwItems.SelectedItems[0].Tag;
                int cid = (int)tvwItemsCats.SelectedNode.Tag;
                frmItem itmForm;
                if (iid > 0)
                    itmForm = new frmItem(new CItem(iid),0);
                else
                {
                    itmForm = new frmItem();
                    itmForm.SetCategory(new CCategory(cid));
                }
                if (itmForm.ShowDialog(this) == DialogResult.OK)
                    PopulateItems(new CCategory(cid).Items);
                itmForm.Dispose();
            }
        }

        private void tsmiChangeItemsCategory_Click(object sender, EventArgs e)
        {
            if (lvwItems.SelectedItems.Count > 0)
            {
                int cid = (int)tvwItemsCats.SelectedNode.Tag;
                frmCatSelector fcs = new frmCatSelector(new CCategory(cid));
                if (fcs.ShowDialog(this) == DialogResult.OK)
                {
                    CCategory cat = fcs.SelectedCategory;
                    fcs.Close();
                    fcs.Dispose();
                    foreach (ListViewItem lvi in lvwItems.SelectedItems)
                    {
                        CItem item = new CItem((int)lvi.Tag);
                        item.Category = cat;
                        item.Update();
                        item.Dispose();
                    }
                    tvwItemsCats.SelectedNode = GetNodeByCategory(tvwItemsCats.Nodes, cat);
                    PopulateItems(new CItems().ItemsByCategory(cat.ID));
                    cat.Dispose();
                }
            }
        }

        private TreeNode GetNodeByCategory(TreeNodeCollection Nodes, CCategory Category)
        {
            CCategory c;
            TreeNode res = null;
            foreach (TreeNode tn in Nodes)
            {
                c = new CCategory((int)tn.Tag);
                if (c.ID == Category.ID)
                {
                    res = tn;
                    break;
                }
                res = GetNodeByCategory(tn.Nodes, Category);
            }
            return res;
        }

        private void tsmiOpenCase_Click(object sender, EventArgs e)
        {
            if (lvwCases.SelectedItems.Count > 0)
            {
                int id = (int)lvwCases.SelectedItems[0].Tag;
                int cid = (int)tvwCaseCat.SelectedNode.Tag;
                frmCase cf;
                if (id > 0)
                    cf = new frmCase(new CCase(id));
                else
                {
                    cf = new frmCase();
                    cf.SetCategory(new CCategory(cid));
                }
                if (cf.ShowDialog(this) == DialogResult.OK)
                    PopulateCases(new CCategory(cid).Cases);
            }
        }

        private void tsmiChangeCaseCategory_Click(object sender, EventArgs e)
        {
            int cid = (int)tvwCaseCat.SelectedNode.Tag;
            frmCatSelector fcs = new frmCatSelector(new CCategory(cid));
            if (fcs.ShowDialog(this) == DialogResult.OK)
            {
                CCategory cat = fcs.SelectedCategory;
                fcs.Close();
                fcs.Dispose();
                foreach (ListViewItem lvi in lvwCases.SelectedItems)
                {
                    CCase c = new CCase((int)lvi.Tag);
                    c.Category = cat;
                    c.Update();
                    c.Dispose();
                }
                tvwCaseCat.SelectedNode = GetNodeByCategory(tvwCaseCat.Nodes, cat);
                PopulateCases(new CCases().CasesByCategory(cat.ID));
                cat.Dispose();
            }
        }

        private void lvwItems_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            tslItems.Text = StatusStripItems();
            EnableDel();
        }

        private string StatusStripItems()
        {
            string s = "No Items Displayed";
            if (lvwItems.Items[0].Text.Length > 0)
            {
                s = "Total " + lvwItems.Items.Count.ToString() + " Items Displayed.";
                if (lvwItems.SelectedItems.Count > 0)
                    s += " " + lvwItems.SelectedItems.Count.ToString() + " Selected";
            }
            return s;
        }

        private string StatusStripJobs(int JobsOut)
        {
            string s = "No Jobs Displayed";
            if (JobsOut > 0)
            {
                s = "Total " + JobsOut.ToString() + " Jobs Displayed.";
            }
            return s;
        }

        private void tsmiDuplicate_Click(object sender, EventArgs e)
        {
            int id = (int)lvwItems.SelectedItems[0].Tag;
            int cid = (int)tvwItemsCats.SelectedNode.Tag;

            frmItemDup fid = new frmItemDup(new CItem(id));
            if (fid.ShowDialog(this) == DialogResult.OK)
                PopulateItems(new CCategory(cid).Items);
        }

        private void cmsItems_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = (lvwItems.SelectedItems.Count == 0);
        }

        private void chkOut_CheckedChanged(object sender, EventArgs e)
        {
            UpdateByFilter();
        }

        private void UpdateByFilter()
        {
            txtSearchItems.Text = "";
            if (chkOut.Checked == false & chkIn.Checked == false)
                chkOut.Checked = true;

            // build a statement
            string having = "";
            if (chkOut.Checked == true)
                having = "HAVING (MIN(Movement.Back) = 0 )";
            if (chkIn.Checked == true)
            {
                if (having.Length == 0) having = "HAVING (";
                else
                {
                    having = having.Substring(0, having.Length - 1);
                    having += "OR ";
                }

                having += "MIN(Movement.Back) = 1 )";
            }
            if (chkProblem.Checked == true)
            {
                if (having.Length == 0) having = "HAVING ";
                else having += "AND ";
                having += "MAX(Movement.HasIssue) = 1";
            }
            having += " AND Item.Active = 1";
            SqlCommand cmd = new SqlCommand(CItems.itemSql +
                                                                having + " ORDER BY Item.Name");

            CRecord rec = new CRecord(cmd);
            PopulateItems(rec.Table);
            rec.Dispose();
        }

        private void RefreshItems()
        {
            if (tabControl2.SelectedIndex == 0)
                UpdateByFilter();
            else
            {
                int id = 1;
                try
                {
                    id = (int)tvwItemsCats.SelectedNode.Tag;
                }
                catch {}
                PopulateItems(new CCategory(id).Items);
            }

        }

        private void btnRefreshItems_Click(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FindItem(txtSearchItems.Text);
        }

        private void txtSearchItems_TextChanged(object sender, EventArgs e)
        {
            btnFind.Enabled = txtSearchItems.Text.Length > 1;
        }

        private void txtSearchItems_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
                FindItem(txtSearchItems.Text);
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshItems();
        }

        private void tsddbNew_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    NewJob();
                    break;

                case 1:
                    NewItem();
                    break;

                case 2:
                    NewCase();
                    break;
            }
        }

        private void NewJob()
        {
            // Create Job
            frmJob job = new frmJob();
            if (job.ShowDialog(this) == DialogResult.OK)
            {
                PopulateJobsList(new CJobs().OpenedJobs, lvwJobs);
            }
            job.Dispose();
        }

        private void NewItem()
        {
            frmItem fi = new frmItem();
            try
            {
                int cid = (int)tvwItemsCats.SelectedNode.Tag;
                fi.SetCategory(new CCategory(cid));
            } catch {}
            fi.ShowDialog(this);
            fi.Close();
            PopulateItems(new CCategory((int)tvwItemsCats.SelectedNode.Tag).Items);
        }

        private void NewCase()
        {
            int cid = (int)tvwCaseCat.SelectedNode.Tag;
            frmCase fc = new frmCase();
            fc.SetCategory(new CCategory(cid));
            fc.ShowDialog(this);
            fc.Close();
            PopulateCases(new CCategory((int)tvwCaseCat.SelectedNode.Tag).Cases);
        }

        private void tsmiNewItem_Click(object sender, EventArgs e)
        {
            NewItem();
        }

        private void tsmiNewCase_Click(object sender, EventArgs e)
        {
            NewCase();
        }

        private void tsmiNewJob_Click(object sender, EventArgs e)
        {
            NewJob();
        }

        private void tsbDelJob_Click(object sender, EventArgs e)
        {
            switch (tabControl1.SelectedIndex)
            {
                case 0:
                    DeleteJob();
                    break;

                case 1:
                    DeleteItem();
                    break;

                case 2:
                    DeleteCase();
                    break;
            }
        }

        private void DeleteCase()
        {
            foreach (ListViewItem lvi in lvwCases.SelectedItems)
            {
                CCase c = new CCase((int)lvi.Tag);
                if (MessageBox.Show("Are you sure you want to delete Case " + c.CaseName + "?, this might affect previous records", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    c.DeleteThisCase();
            }
            PopulateCases(new CCategory((int)tvwCaseCat.SelectedNode.Tag).Cases);
        }

        private void DeleteJob()
        {
            CJob job = new CJob((int)lvwJobs.SelectedItems[0].Tag);
            if (MessageBox.Show("Are you sure you want to delete Job " + job.Job + "?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                job.DeleteThisJob();
            PopulateJobsList(new CJobs().OpenedJobs, lvwJobs);
        }

        private void DeleteItem()
        {

        }

        private void lvwJobs_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EnableDel();
        }

        private void lvwCases_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            EnableDel();
        }

        private void txtSearchJob_TextChanged(object sender, EventArgs e)
        {
            btnSearchJob.Enabled = txtSearchJob.Text.Length > 1;
        }

        private void btnSearchJob_Click(object sender, EventArgs e)
        {
            PopulateJobsList(new CJobs().SearchJobs(txtSearchJob.Text), lvwJobs);
            lvwJobs.Tag = JobsListStatus.SearchResults;
        }

        private void txtSearchJob_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                if (txtSearchJob.Text.Length > 1)
                {
                    PopulateJobsList(new CJobs().SearchJobs(txtSearchJob.Text), lvwJobs);
                    lvwJobs.Tag = JobsListStatus.SearchResults;
                }
                else
                {
                    PopulateJobsList(new CJobs().OpenedJobs, lvwJobs);
                    lvwJobs.Tag = JobsListStatus.OpenedJobs;
                }
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            PopulateJobsList(new CJobs().OpenedJobs, lvwJobs);
            lvwJobs.Tag = JobsListStatus.OpenedJobs;
            txtSearchJob.Text = "";
        }
    }
}

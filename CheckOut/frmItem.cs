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
    public partial class frmItem : Form
    {
        CItem currentitem;

        public frmItem()
        {
            InitializeComponent();
            currentitem = null;
            PopulateCombos();

            tabControl.TabPages.RemoveAt(1);
            tabControl.TabPages.RemoveAt(1);

            llbCategory.Text = new CCategory(1).Category;
            llbCategory.Tag = 1;

            this.Text = "New Item";
        }

        public frmItem(CItem Item, int TabIndex)
        {
            InitializeComponent();
            currentitem = Item;

            PopulateCombos();

            this.Text = "Item - " + currentitem.Name;

            chkActive.Checked = currentitem.Active;
            txtID.Text = currentitem.ID.ToString();
            llbCategory.Text = currentitem.Category.Category;
            llbCategory.Tag = currentitem.Category.ID;
            txtName.Text = currentitem.Name;
            txtDesc.Text = currentitem.Description;
            txtIncluding.Text = currentitem.Including;
            txtSerNo.Text = currentitem.SerialNo;
            try
            {
                dtpEnterSer.Value = currentitem.EnterService;
            }
            catch
            {
                dtpEnterSer.Value = new DateTime(2005, 1, 1);
            }
            if (currentitem.DefaultCase == null)
                cboDefCase.SelectedIndex = 0;
            else
                cboDefCase.Text = currentitem.DefaultCase.CaseName;
            nudDefQtty.Value = currentitem.DefaultQuantity;
            if (currentitem.Invoked != null)
                cboInvoked.Text = currentitem.Invoked.Invokes;
            txtComments.Text = currentitem.Comment;
            tsbDupItem.Enabled = true;

            PopulateMoves();

            ShowTab(TabIndex);
        }

        public CItem Item
        {
            get
            {
                return currentitem;
            }
        }

        public void ShowTab(int TabIndex)
        {
            tabControl.SelectedTab = tabControl.TabPages[TabIndex];
        }

        private void PopulateMoves()
        {
            lvwMoves.Items.Clear();
            DataTable moves = new CMovements().MovementsByItem(currentitem.ID);
            ListViewItem lvi;

            lvwMaintenance.Items.Clear();
            lblTitle.Text = "No Current Problems";
            txtProblem.Enabled = false;
            txtProblem.ForeColor = SystemColors.GrayText;
            lblDesc.ForeColor = SystemColors.GrayText;
            btnSolved.Enabled = false;
            txtProblem.Text = "";
            lblTitle.Tag = null;

            foreach (DataRow row in moves.Rows)
            {
                lvi = new ListViewItem(row["Production"].ToString() + ", " + row["Job"].ToString());
                lvi.SubItems.Add(DateTime.Parse(row["CheckOut"].ToString()).ToShortDateString());
                lvi.SubItems.Add(DateTime.Parse(row["CheckIn"].ToString()).ToShortDateString());
                lvi.SubItems.Add(row["Crew"].ToString());
                if ((int)row["Back"] == 0)
                    lvi.ForeColor = Color.Navy;
                lvi.Tag = (int)row["ID"];
                lvwMoves.Items.Insert(0,lvi);

                if (row["Notes"].ToString().Length > 0)
                {
                    bool issue = false;
                    if ((int)row["HasIssue"] == 1) issue = true;
                    AddProblemToMaintenance((int)row["ID"],
                                            issue,
                                            row["Production"] + ", " + row["Job"],
                                            DateTime.Parse(row["CheckIn"].ToString()),
                                            row["Crew"].ToString(),
                                            row["Notes"].ToString());
                }
            }
            lblRecords.Text = "Total Movements: " + lvwMoves.Items.Count.ToString();
        }

        public void SetCategory(CCategory Category)
        {
            llbCategory.Tag = Category.ID;
            llbCategory.Text = Category.Category;
        }

        public void SetCase(CCase Case)
        {
            cboDefCase.Text = Case.CaseName;
        }

        private void AddProblemToMaintenance(int MovementID, bool HasIssue, string Prod_comma_Job, DateTime CheckIn, string Crew, string Notes)
        {
            ListViewItem lvi = new ListViewItem(Prod_comma_Job);
            lvi.SubItems.Add(CheckIn.ToShortDateString());
            lvi.SubItems.Add(Crew);
            if (HasIssue == true)
            {
                if (lblTitle.Tag == null)
                {
                    lblTitle.Text = "Problem from job: " + Prod_comma_Job + " - Crew: " + Crew;
                    txtProblem.Enabled = true;
                    txtProblem.ForeColor = SystemColors.WindowText;
                    lblDesc.ForeColor = SystemColors.WindowText;
                    btnSolved.Enabled = true;
                    txtProblem.Text = Notes;
                    lblTitle.Tag = MovementID;
                }
                lvi.SubItems.Add("No");
            }
            else
                lvi.SubItems.Add("Yes");
            lvi.Tag = MovementID;
            lvwMaintenance.Items.Insert(0, lvi);
        }

        private void PopulateCombos()
        {
            ComboItem ci = new ComboItem("none", 0);
            cboDefCase.Items.Add(ci);
            cboInvoked.Items.Add(ci);
            DataTable cases = new CCases().AllCases;
            foreach (DataRow row in cases.Rows)
            {
                ci = new ComboItem(row["CaseName"].ToString(), (int)row["ID"]);
                cboDefCase.Items.Add(ci);
            }
            DataTable iv = new CInvokes().AllInvokes;
            foreach (DataRow row in iv.Rows)
            {
                ci = new ComboItem(row[1].ToString(), (int)row[0]);
                cboInvoked.Items.Add(ci);
            }
            cboDefCase.SelectedIndex = 0;
            cboInvoked.SelectedIndex = 0;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            tsbSave.Enabled = txtName.Text.Length > 0;
        }

        private void tsbSave_Click(object sender, EventArgs e)
        {
            if (currentitem == null)
                currentitem = new CItems().NewItem(txtName.Text);
            else
                currentitem.Name = txtName.Text;

            currentitem.Category = new CCategory((int)llbCategory.Tag);
            currentitem.Active = chkActive.Checked;
            currentitem.Description = txtDesc.Text;
            currentitem.Including = txtIncluding.Text;
            currentitem.SerialNo = txtSerNo.Text;
            currentitem.EnterService = dtpEnterSer.Value;
            ComboItem ci = (ComboItem)cboDefCase.SelectedItem;
            if (ci.ID > 0)
                currentitem.DefaultCase = new CCase(ci.ID);
            else
                currentitem.DefaultCase = null;
            currentitem.DefaultQuantity = (int)nudDefQtty.Value;
            ci = (ComboItem)cboInvoked.SelectedItem;
            if (ci.ID > 0)
                currentitem.Invoked = new CInvoke(ci.ID);
            else
                currentitem.Invoked = null;
            currentitem.Comment = txtComments.Text;
            currentitem.Update();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnSolved_Click(object sender, EventArgs e)
        {
            CMovement m = new CMovement((int)lblTitle.Tag);
            m.Notes = txtProblem.Text;
            m.HasIssue = false;
            m.Update();
            PopulateMoves();
        }

        private void lvwMoves_DoubleClick(object sender, EventArgs e)
        {
            ListView lv = (ListView)sender;
            int viewStart = lvwMoves.TopItem.Index;

            if (lv.SelectedItems.Count > 0)
            {
                int mID = (int)lv.SelectedItems[0].Tag;
                frmMovement mf = new frmMovement(new CMovement(mID));
                if (mf.ShowDialog(this) == DialogResult.OK)
                    PopulateMoves();
                try
                {
                    lvwMoves.TopItem = lvwMoves.Items[viewStart];
                }
                catch { }
            }
        }

        private void llbCategory_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmCatSelector cs;
            if (currentitem == null)
                cs = new frmCatSelector(new CCategory(1));
            else
                cs = new frmCatSelector(currentitem.Category);
            if (cs.ShowDialog(this) == DialogResult.OK)
            {
                SetCategory(cs.SelectedCategory);
                cs.Close();
            }

        }

        private void frmItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                currentitem.Dispose();
            }
            catch { }
        }

        private void tsbDupItem_Click(object sender, EventArgs e)
        {
            frmItemDup fid = new frmItemDup(currentitem);
            if (fid.ShowDialog(this) == DialogResult.OK)
            {
                
            }
        }

        private void openMovementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lvwMoves_DoubleClick((object)lvwMoves, new EventArgs());
        }

        private void orenJobToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int viewStart = lvwMoves.TopItem.Index;

            if (lvwMoves.SelectedItems.Count > 0)
            {
                int mID = (int)lvwMoves.SelectedItems[0].Tag;
                frmJob jf = new frmJob(new CMovement(mID).Job);
                if (jf.ShowDialog(this) == DialogResult.OK)
                    PopulateMoves();
                try
                {
                    lvwMoves.TopItem = lvwMoves.Items[viewStart];
                }
                catch { }
            }
        
        }
    }
}

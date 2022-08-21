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
    public partial class frmCheckOutItem : Form
    {
        bool needSave = false;

        CItem currentitem;

        public bool RecordLocked = false;
        public bool AllowNew = false;

        bool tabPosition = true;    // true = Details, false = Movements

        const string NO_ITEM = "--ללא--";

        public frmCheckOutItem()
        {
            InitializeComponent();
            currentitem = null;
            PopulateCombos();

            llbCategory.Text = new CCategory(1).Category;
            llbCategory.Tag = 1;
        }

        public frmCheckOutItem(int CheckOutItemID)
        {
            InitializeComponent();
            currentitem = new CItem(CheckOutItemID);

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
            txtComments.Text = currentitem.Comment;
            txtCatalogItem.Tag = currentitem.CatalogItem;
            if ((int)txtCatalogItem.Tag == 0)
                txtCatalogItem.Text = NO_ITEM;
            else
            {
                using (CCatalogProduct cata = new CCatalogProduct((int)txtCatalogItem.Tag))
                {
                    txtCatalogItem.Text = cata.ProductName;
                }
            }
            PopulateMoves();
            needSave = false;
        }

        private void frmCheckOutItem_Load(object sender, EventArgs e)
        {
            panMoves.Size = panDetails.Size;
            panMoves.Location = panDetails.Location;

            if (RecordLocked == true)
            {
                Text += " (לקריאה בלבד)";
                btnOK.Visible = false;
            }
            btnDuplicate.Visible = AllowNew;
        }

        public CItem Item
        {
            get
            {
                return currentitem;
            }
        }

        private void btnTab1_Click(object sender, EventArgs e)
        {
            tabPosition = true;
            btnTab1.BackColor = SystemColors.ButtonFace;
            btnTab2.BackColor = SystemColors.ButtonShadow;
            panDetails.Visible = true;
            panMoves.Visible = false;
            txtName.Focus();
        }

        private void btnTab2_Click(object sender, EventArgs e)
        {
            tabPosition = false;
            btnTab2.BackColor = SystemColors.ButtonFace;
            btnTab1.BackColor = SystemColors.ButtonShadow;
            panDetails.Visible = false;
            panMoves.Visible = true;
            lvwMoves.Focus();
        }

        private void PopulateMoves()
        {
            lvwMoves.Items.Clear();
            DataTable moves = new CMovements().MovementsByItem(currentitem.ID);
            ListViewItem lvi;

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
                    //AddProblemToMaintenance((int)row["ID"],
                    //                        issue,
                    //                        row["Production"] + ", " + row["Job"],
                    //                        DateTime.Parse(row["CheckIn"].ToString()),
                    //                        row["Crew"].ToString(),
                    //                        row["Notes"].ToString());
                }
            }
            lblRecords.Text = "סה''כ תנועות: " + lvwMoves.Items.Count.ToString();
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

        //private void AddProblemToMaintenance(int MovementID, bool HasIssue, string Prod_comma_Job, DateTime CheckIn, string Crew, string Notes)
        //{
        //    ListViewItem lvi = new ListViewItem(Prod_comma_Job);
        //    lvi.SubItems.Add(CheckIn.ToShortDateString());
        //    lvi.SubItems.Add(Crew);
        //    if (HasIssue == true)
        //    {
        //        if (lblTitle.Tag == null)
        //        {
        //            lblTitle.Text = "Problem from job: " + Prod_comma_Job + " - Crew: " + Crew;
        //            txtProblem.Enabled = true;
        //            txtProblem.ForeColor = SystemColors.WindowText;
        //            lblDesc.ForeColor = SystemColors.WindowText;
        //            btnSolved.Enabled = true;
        //            txtProblem.Text = Notes;
        //            lblTitle.Tag = MovementID;
        //        }
        //        lvi.SubItems.Add("No");
        //    }
        //    else
        //        lvi.SubItems.Add("Yes");
        //    lvi.Tag = MovementID;
        //    lvwMaintenance.Items.Insert(0, lvi);
        //}

        private void PopulateCombos()
        {
            ComboItem ci = new ComboItem("ללא", 0);
            cboDefCase.Items.Add(ci);
            using (DataTable cases = new CCases().AllCases)
            {
                foreach (DataRow row in cases.Rows)
                {
                    ci = new ComboItem(row["CaseName"].ToString(), (int)row["ID"]);
                    cboDefCase.Items.Add(ci);
                }
            }
            cboDefCase.SelectedIndex = 0;
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            btnOK.Enabled = txtName.Text.Length > 0;
            needSave = true;
        }

        private void SaveChkOutItem()
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
            currentitem.DefaultQuantity = (int)1;
            currentitem.Invoked = null;
            currentitem.Comment = txtComments.Text;
            currentitem.CatalogItem = (int)txtCatalogItem.Tag;
            currentitem.Update();

            needSave = false;
            
            this.DialogResult = DialogResult.OK;
            this.Close();
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
                needSave = true;
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

        private void btnDuplicate_Click(object sender, EventArgs e)
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchCatalog_Click(object sender, EventArgs e)
        {
            using (frmCatalogSearch csFrm = new frmCatalogSearch(""))
            {
                if (csFrm.ShowDialog(this) == DialogResult.OK)
                {
                    txtCatalogItem.Tag = csFrm.ResultItemID;
                    txtCatalogItem.Text = csFrm.ResultProduct;
                }
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SaveChkOutItem();
            this.Close();
        }

        private void frmCheckOutItem_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (RecordLocked == true)
                return;

            if (needSave == true)
            {
                DialogResult dr = MessageBox.Show("האם לשמור את השינויים?", "שמירה", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                switch (dr)
                {
                    case System.Windows.Forms.DialogResult.Yes:
                        // save and close
                        if (btnOK.Enabled == false)
                        {
                            MessageBox.Show(Properties.Settings.Default.MsgCantSaveEmpty,
                                        Properties.Settings.Default.MsgCantProceed,
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                            txtName.Focus();
                        }
                        else
                        {
                            SaveChkOutItem();
                            this.DialogResult = System.Windows.Forms.DialogResult.OK;
                        }
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

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            needSave = true;
        }

        private void txtIncluding_TextChanged(object sender, EventArgs e)
        {
            needSave = true;
        }

        private void txtSerNo_TextChanged(object sender, EventArgs e)
        {
            needSave = true;
        }

        private void dtpEnterSer_ValueChanged(object sender, EventArgs e)
        {
            needSave = true;
        }

        private void cboDefCase_SelectedIndexChanged(object sender, EventArgs e)
        {
            needSave = true;
        }

        private void txtComments_TextChanged(object sender, EventArgs e)
        {
            needSave = true;
        }

        private void txtCatalogItem_TextChanged(object sender, EventArgs e)
        {
            needSave = true;
        }

        private void btnClearCatalogItem_Click(object sender, EventArgs e)
        {
            txtCatalogItem.Tag = 0;
            txtCatalogItem.Text = NO_ITEM;
        }
    }
}

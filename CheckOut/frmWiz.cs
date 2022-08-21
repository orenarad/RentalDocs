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
    public partial class frmWiz : Form
    {
        CJob currentJob;
        CVirtualMovements currentMoves;
        DataTable allCases = new CCases().AllCases;
        DataTable allItems = new CItems().AllItems;

        private int m_step = 0;

        public frmWiz(CJob Job)
        {
            InitializeComponent();
            SetJob(Job);

            PopulateCases("");

            panStep1.Dock = DockStyle.Fill;
            panStep2.Dock = DockStyle.Fill;
            panStep3.Dock = DockStyle.Fill;
            MoveStep(0);
        }

        private void SetJob(CJob Job)
        {
            currentJob = Job;
            currentMoves = new CVirtualMovements(currentJob);
            RefreshCaseCombo();
            lblJobName.Text = currentJob.Job;
            if (currentJob.Production.Length > 0)
                lblJobName.Text += ", " + currentJob.Production;
            lnkChange.Left = lblJobName.Right + 5;
        }

        private void PopulateCases(string SearchStr)
        {
            lbxCases.Items.Clear();
            lbxSelectedCases.Items.Clear();
            ComboItem ci;
            DataView dv = allCases.DefaultView;

            if (SearchStr.Length > 0)
                dv.RowFilter = "[CaseName] LIKE '%" + SearchStr + "%'";
            else
                dv.RowFilter = "";

            foreach (DataRow row in dv.ToTable().Rows)
            {
                ci = new ComboItem(row["CaseName"].ToString() + "       (" + row["ID"].ToString() + ")", (int)row["ID"]);
                if (CaseUsed((int)row["ID"]) == true)
                    lbxSelectedCases.Items.Add(ci);
                else
                    lbxCases.Items.Add(ci);
            }
        }

        private bool CaseUsed(int CaseID)
        {
            bool res = false;
            foreach (object obj in currentMoves)
            {
                CVirtualMovement m = (CVirtualMovement)obj;
                if (m.Case.ID == CaseID)
                {
                    res = true;
                    break;
                }
                m.Dispose();
            }
            return res;
        }

        private void lbxCases_DoubleClick(object sender, EventArgs e)
        {
            if (lbxCases.SelectedItems.Count > 0)
                MoveCaseToSelected();
        }

        private void MoveCaseToSelected()
        {
            ComboItem ci = (ComboItem)lbxCases.SelectedItem;
            lbxSelectedCases.Items.Add(lbxCases.SelectedItem);
            int i = lbxCases.SelectedIndex;
            lbxCases.Items.RemoveAt(i);
            AddCaseToVirtualMoves(ci.ID);
            try
            {
                lbxCases.SelectedIndex = i;
            }
            catch { }
            btnNext.Enabled = (lbxSelectedCases.Items.Count > 0);
            btnFinished.Enabled = (lbxSelectedCases.Items.Count > 0);
        }

        private void MoveSelectedToCase()
        {
            ComboItem ci = (ComboItem)lbxSelectedCases.SelectedItem;
            lbxCases.Items.Add(lbxSelectedCases.SelectedItem);
            int i = lbxSelectedCases.SelectedIndex;
            lbxSelectedCases.Items.RemoveAt(i);
            RemoveCaseFromVirtualMoves(ci.ID);
            try
            {
                lbxSelectedCases.SelectedIndex = i;
            }
            catch { }
            btnNext.Enabled = (lbxSelectedCases.Items.Count > 0);
            btnFinished.Enabled = (lbxSelectedCases.Items.Count > 0);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (lbxCases.SelectedItems.Count > 0)
                MoveCaseToSelected();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (lbxSelectedCases.SelectedItems.Count > 0)
                MoveSelectedToCase();
        }

        private void MoveCasesByID(string IDString)
        {
            string ids = IDString;

            ids = ids.Trim();
            string id;
            int caseid = 0;
            int c = ids.IndexOf("+");

            for (; ids.Length > 0; )
            {
                if (c > -1)
                    id = ids.Substring(0, c);
                else
                    id = ids;
                if (Int32.TryParse(id, out caseid) == true)
                    MoveCaseToSelectedByID(caseid);
                if (c > -1)
                    ids = ids.Substring(c + 1);
                else
                    ids = "";
                c = ids.IndexOf("+");
            }
        }

        private void AddItemsByID(string IDString, int CaseID)
        {
            string ids = IDString;

            ids = ids.Trim();
            string id;
            int c = ids.IndexOf("+");
            int o = 0;

            for (; ids.Length > 0; )
            {
                if (c > -1)
                    id = ids.Substring(0, c);
                else
                    id = ids;

                if (Int32.TryParse(id, out o) == true)
                    AddItemToSelected(int.Parse(id), CaseID);

                if (c > -1)
                    ids = ids.Substring(c + 1);
                else
                    ids = "";
                c = ids.IndexOf("+");
            }
        }

        private void MoveCaseToSelectedByID(int caseid)
        {
            bool found = false;
            foreach (object obj in lbxCases.Items)
            {
                ComboItem ci = (ComboItem)obj;
                if (ci.ID == caseid)
                {
                    found = true;
                    lbxCases.SelectedItem = obj;
                    MoveCaseToSelected();
                    break;
                }
            }
            if (found == false)
                MessageBox.Show("Could not find a case numbered " + caseid.ToString() + ", This case ether don't exists or already selected for this job"
                    , "Case number not found"
                    , MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnAddIDs_Click(object sender, EventArgs e)
        {
            MoveCasesByID(txtSearchCase.Text);
            txtSearchCase.Text = "";
        }

        private void lbxSelectedCases_DoubleClick(object sender, EventArgs e)
        {
            if (lbxSelectedCases.SelectedItems.Count > 0)
                MoveSelectedToCase();
        }

        private void txtCaseIDs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                MoveCasesByID(txtSearchCase.Text);
                txtSearchCase.Text = "";
            }

        }

        private void AddCaseToVirtualMoves(int CaseID)
        {
            CCase aCase = new CCase(CaseID);
            foreach (DataRow row in aCase.DefaultItems.Rows)
            {
                CVirtualMovement vm = new CVirtualMovement((int)row["ID"], CaseID);
                currentMoves.Add(vm);
                vm.Dispose();
            }
            aCase.Dispose();
            RefreshCaseCombo();
        }

        private void RemoveCaseFromVirtualMoves(int CaseID)
        {
            for (int i = 0; i < currentMoves.Count; i++)
            {
                CVirtualMovement vm = currentMoves[i];
                if (vm.Case.ID == CaseID)
                {
                    currentMoves.Remove(i);
                    i -= 1;
                }
                vm.Dispose();
            }
            RefreshCaseCombo();
        }

        private void RefreshCaseCombo()
        {
            int lastID = 0;
            cboSelectedCases.Items.Clear();
            foreach (object obj in currentMoves)
            {
                CVirtualMovement vm = (CVirtualMovement)obj;
                if (lastID != vm.Case.ID)
                {
                    cboSelectedCases.Items.Add(new ComboItem(vm.Case.CaseName, vm.Case.ID));
                    lastID = vm.Case.ID;
                }
                vm.Dispose();
            }
            if (cboSelectedCases.Items.Count > 0) cboSelectedCases.SelectedIndex = 0;
        }

        private void MoveStep(int step)
        {
            switch (step)
            {
                case 0: // step one, select cases
                    panStep1.Visible = true;
                    panStep2.Visible = false;
                    panStep3.Visible = false;
                    break;

                case 1: // step 2, case contents
                    panStep1.Visible = false;
                    panStep2.Visible = true;
                    panStep3.Visible = false;
                    break;

                case 2: // step 3, print
                    panStep1.Visible = false;
                    panStep2.Visible = false;
                    panStep3.Visible = true;
                    break;
            }
            m_step = step;
        }

        private void panStep1_VisibleChanged(object sender, EventArgs e)
        {
            if (panStep1.Visible == true)
            {
                btnBack.Enabled = false;
                btnNext.Enabled = (lbxSelectedCases.Items.Count > 0);
                btnFinished.Enabled = (lbxSelectedCases.Items.Count > 0);
            }

        }

        private void panStep2_VisibleChanged(object sender, EventArgs e)
        {
            if (panStep2.Visible == true)
            {
                btnBack.Enabled = true;
                btnNext.Enabled = true;
                btnFinished.Enabled = true;
            }
        }

        private void panStep3_VisibleChanged(object sender, EventArgs e)
        {
            if (panStep3.Visible == true)
            {
                currentMoves.CommitMovements();
                btnBack.Enabled = true;
                btnNext.Enabled = false;
                btnFinished.Enabled = true;
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            MoveStep(m_step + 1);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            MoveStep(m_step - 1);
        }

        private void cboSelectedCases_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboItem ci = (ComboItem)cboSelectedCases.SelectedItem;

            PopulateCaseItems(ci.ID);
            if (rbnInvoke.Checked == true)
                PopulateInvoked(ci.ID);
        }

        private void PopulateInvoked(int CaseID)
        {
            lvwItems.BeginUpdate();
            lvwItems.Items.Clear();
            CCase _case = new CCase(CaseID);
            if (_case.InvokedItems != null)
            {
                int c = 0;
                DataTable items = _case.InvokedItems;
                foreach (DataRow row in items.Rows)
                {
                    ListViewItem lvi = new ListViewItem(row["Name"].ToString());
                    if (row["Issue"].ToString().Length > 0)
                    {
                        if ((int)row["Issue"] > 0)
                            lvi.ForeColor = Color.Red;
                        if ((int)row["Back"] == 0)
                            lvi.ForeColor = Color.Gray;
                    }
                    lvi.Tag = row["ID"].ToString();
                    lvi.SubItems.Add(row["SerNo"].ToString());
                    lvwItems.Items.Add(lvi);
                    c++;
                    if (c > 20) break;
                }
                items.Dispose();
            }
            _case.Dispose();
            lvwItems.EndUpdate();
        }

        private void PopulateCaseItems(int CaseID)
        {
            lvwSelectedItems.BeginUpdate();
            lvwSelectedItems.Items.Clear();
            foreach (CVirtualMovement vm in currentMoves)
            {
                if (vm.Case.ID == CaseID)
                {
                    if (vm.Quanitity > 0)
                    {
                        ListViewItem lvi = new ListViewItem(vm.Item.Name);
                        lvi.Tag = vm.ListIndex;
                        if (vm.Item.Status == CItem.ItemStatus.Malfunction)
                            lvi.ForeColor = Color.Red;
                        if (vm.Item.Status == CItem.ItemStatus.Out)
                        {
                            //if (vm.Item.CurrentJob.ID != currentJob.ID)
                            //    lvi.ForeColor = Color.Gray;
                        }
                        lvi.SubItems.Add(vm.Item.SerialNo);
                        lvi.SubItems.Add(vm.Quanitity.ToString());
                        lvwSelectedItems.Items.Add(lvi);
                    }
                }
                vm.Dispose();
            }
            lvwSelectedItems.EndUpdate();
            grpItem.Visible = false;
        }

        private void rbnSearch_CheckedChanged(object sender, EventArgs e)
        {
            txtSearch.Enabled = rbnSearch.Checked;
            btnGo.Enabled = rbnSearch.Checked;
            txtSearch.Text = "";
        }

        private void txtSearch_EnabledChanged(object sender, EventArgs e)
        {
            if (txtSearch.Enabled == true)
                txtSearch.BackColor = SystemColors.Window;
            else
                txtSearch.BackColor = Color.FromArgb(201, 210, 240);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
                btnGo_Click(new object(), new EventArgs());
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 1)
            {
                lvwItems.BeginUpdate();
                DataTable items = new CItems().SearchItems(txtSearch.Text);
                lvwItems.Items.Clear();
                foreach (DataRow row in items.Rows)
                {
                    
                    ListViewItem lvi = new ListViewItem(row["Name"].ToString());
                    if (row["Issue"].ToString().Length > 0)
                    {
                        if ((int)row["Issue"] > 0)
                            lvi.ForeColor = Color.Red;
                        if ((int)row["Back"] == 0)
                            lvi.ForeColor = Color.Gray;
                    }
                    lvi.Tag = row["ID"];
                    lvi.SubItems.Add(row["SerNo"].ToString());
                    lvwItems.Items.Add(lvi);
                }
                lvwItems.EndUpdate();
            }
            else
                lvwItems.Items.Clear();
        }

        private void lvwItems_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (lvwItems.SelectedItems.Count > 0)
            {
                ComboItem ci = (ComboItem)cboSelectedCases.SelectedItem;
                int itemID = int.Parse(lvwItems.SelectedItems[0].Tag.ToString());
                AddItemToSelected(itemID, ci.ID);
            }
        }

        private void AddItemToSelected(int ItemID, int CaseID)
        {
            try
            {
                if (IsItemSelected(ItemID) == false)
                {
                    CVirtualMovement vm = new CVirtualMovement(ItemID, CaseID);
                    currentMoves.Add(vm);
                    vm.Dispose();
                }
                else
                {
                    int idx = -1;
                    foreach (CVirtualMovement vm in currentMoves)
                    {
                        if (CaseID == vm.Case.ID & ItemID == vm.Item.ID)
                        {
                            idx = vm.ListIndex;
                            IncreaseQuantity(idx, 1);
                            break;
                        }
                    }
                }
                PopulateCaseItems(CaseID);
            }
            catch
            {
                MessageBox.Show("There is no item with ID " + ItemID.ToString() + ".",
                    "No Item Found",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void IncreaseQuantity(int MoveIndex, int Quantity)
        {
            currentMoves[MoveIndex].Quanitity += Quantity;
        }

        private bool IsItemSelected(int ItemID)
        {
            bool result = false;
            foreach (CVirtualMovement vm in currentMoves)
            {
                if (vm.Item.ID == ItemID)
                {
                    result = true;
                    vm.Dispose();
                    break;
                }
            }
            return result;
        }

        private void txtIDs_TextChanged(object sender, EventArgs e)
        {
            btnAddID.Enabled = (txtIDs.Text.Length > 0);
        }

        private void btnAddID_Click(object sender, EventArgs e)
        {
            ComboItem ci = (ComboItem)cboSelectedCases.SelectedItem;
            AddItemsByID(txtIDs.Text, ci.ID);            
            txtIDs.Text = "";
        }

        private void rbnInvoke_CheckedChanged(object sender, EventArgs e)
        {
            ComboItem ci = (ComboItem)cboSelectedCases.SelectedItem;
            if (rbnInvoke.Checked == true)
                PopulateInvoked(ci.ID);
        }

        private void btnFinished_Click(object sender, EventArgs e)
        {
            MoveStep(2);
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            SendToPrinter();
        }

        private void SendToPrinter()
        {
            CPrintManifest pm = new CPrintManifest(currentJob);
            if (chkPrintOptions.Checked == true)
            {
                PrintDialog pd = new PrintDialog();
                pd.Document = pm;
                pd.PrinterSettings.Copies = (short)nudCopies.Value;
                if (pd.ShowDialog(this) == DialogResult.OK)
                {
                    pm.PrinterSettings = pd.PrinterSettings;
                    pm.Print();
                }
                pd.Dispose();
            }
            else
            {
                pm.PrinterSettings.Copies = (short)nudCopies.Value;
                pm.Print();
            }
            pm.Dispose();
        }

        private void lnkChange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmJobSelector jsel = new frmJobSelector();
            if (jsel.ShowDialog(this) == DialogResult.OK)
            {
                SetJob(jsel.SelectedJob);
                jsel.Dispose();
            }
        }

        private void butPreview_Click(object sender, EventArgs e)
        {
            CPrintManifest pm = new CPrintManifest(currentJob);
            pm.ShowPreview();
            pm.Dispose();
        }

        private void frmWiz_FormClosed(object sender, FormClosedEventArgs e)
        {
            currentJob.Dispose();
        }

        private void lvwSelectedItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblNotice.Visible = (lvwSelectedItems.SelectedItems.Count > 1);
            grpItem.Tag = -1;
            if (lvwSelectedItems.SelectedItems.Count > 0)
            {
                CVirtualMovement vmove = (CVirtualMovement)currentMoves[(int)lvwSelectedItems.SelectedItems[0].Tag];
                lblItem.Text = vmove.Item.Name;
                lblItem.Tag = vmove.Item.ID;
                llbChange.Left = lblItem.Right + 7;
                llbExlude.Left = llbChange.Right + 7;
                txtIncluding.Text = vmove.ItemIncluding;
                nudQtty.Value = vmove.Quanitity;
                grpItem.Tag = vmove.ListIndex;
                grpItem.Visible = true;
                vmove.Dispose();
            }
            else
                grpItem.Visible = false;
        }

        private void llbChange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ChangeItemInCase();
        }

        private void ChangeItemInCase()
        {
            CVirtualMovement vmove = (CVirtualMovement)currentMoves[(int)grpItem.Tag];

            frmFindItem ffi = new frmFindItem();
            if (ffi.ShowDialog(this) == DialogResult.OK)
            {
                vmove.Item = ffi.GetSelectedItems()[0];
                vmove.ItemIncluding = vmove.Item.Including;
                lblItem.Text = vmove.Item.Name;
                lblItem.Tag = vmove.Item.ID;
                llbChange.Left = lblItem.Right + 7;
                llbExlude.Left = llbChange.Right + 7;
                txtIncluding.Text = vmove.ItemIncluding;
                nudQtty.Value = vmove.Quanitity;
                grpItem.Tag = vmove.ListIndex;
                grpItem.Visible = true;
                UpdateCaseCtx();
            }
            vmove.Dispose();
            ffi.Close();
            ffi.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            UpdateCaseCtx();
        }

        private void UpdateCaseCtx()
        {
            int Idx = (int)grpItem.Tag;
            currentMoves[Idx].Item = new CItem((int)lblItem.Tag);
            currentMoves[Idx].ItemIncluding = txtIncluding.Text;
            currentMoves[Idx].Quanitity = (int)nudQtty.Value;
            ComboItem ci = (ComboItem)cboSelectedCases.SelectedItem;
            PopulateCaseItems(ci.ID);
        }

        private void llbExlude_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RemoveItemsFromCase(false);
        }

        private void RemoveItemsFromCase(bool All)
        {
            if (All == true)
                foreach (ListViewItem lvi in lvwSelectedItems.Items)
                {
                    int Idx = (int)lvi.Tag;
                    currentMoves[Idx].Quanitity = 0;
                }
            else
            {
                foreach (ListViewItem lvi in lvwSelectedItems.SelectedItems)
                {
                    int Idx = (int)lvi.Tag;
                    currentMoves[Idx].Quanitity = 0;
                }
            }

            ComboItem ci = (ComboItem)cboSelectedCases.SelectedItem;
            PopulateCaseItems(ci.ID);
        }

        private void tsmiOpenItem_Click(object sender, EventArgs e)
        {
            OpenItem();
        }

        private void OpenItem()
        {
            CVirtualMovement vmove = (CVirtualMovement)currentMoves[(int)grpItem.Tag];
            frmItem fi = new frmItem(new CItem(vmove.Item.ID), 0);
            if (fi.ShowDialog(this) == DialogResult.OK)
            {
                int Idx = (int)grpItem.Tag;
                currentMoves[Idx].Item = new CItem(vmove.Item.ID);
                currentMoves[Idx].ItemIncluding = currentMoves[Idx].Item.Including;
                currentMoves[Idx].Quanitity = currentMoves[Idx].Item.DefaultQuantity;
                ComboItem ci = (ComboItem)cboSelectedCases.SelectedItem;
                PopulateCaseItems(ci.ID);
            }
        }

        private void cmsCaseItems_Opening(object sender, CancelEventArgs e)
        {
            e.Cancel = (lvwSelectedItems.SelectedItems.Count == 0);
        }

        private void tsmiChange_Click(object sender, EventArgs e)
        {
            ChangeItemInCase();
            ComboItem ci = (ComboItem)cboSelectedCases.SelectedItem;
            PopulateCaseItems(ci.ID);
        }

        private void lvwSelectedItems_DoubleClick(object sender, EventArgs e)
        {
            if (lvwSelectedItems.SelectedItems.Count > 0)
            {
                OpenItem();
                ComboItem ci = (ComboItem)cboSelectedCases.SelectedItem;
                PopulateCaseItems(ci.ID);
            }

        }

        private void tsmiRemove_Click(object sender, EventArgs e)
        {
            RemoveItemsFromCase(false);
        }

        private void tsmiClear_Click(object sender, EventArgs e)
        {
            RemoveItemsFromCase(true);
        }

        private void txtSearchCase_TextChanged(object sender, EventArgs e)
        {
            if (txtSearchCase.Text.Length > 1)
                PopulateCases(txtSearchCase.Text);
            else
                PopulateCases("");
        }
    }
}

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
    public partial class frmFindCase : Form
    {
        public frmFindCase()
        {
            InitializeComponent();
            CategoryTreeView ctv = new CategoryTreeView(tvwCategories);
            ctv.Dispose();
            tvwCategories.ExpandAll();
            tvwCategories.SelectedNode = tvwCategories.Nodes[0];
        }

        private void PopulateCases(DataTable Cases)
        {
            PopulateCases(Cases, 0);
        }

        private void PopulateCases(DataTable Cases, int SelectID)
        {
            lvwCases.BeginUpdate();
            lvwCases.Items.Clear();

            ListViewItem lvi;

            foreach (DataRow row in Cases.Rows)
            {
                lvi = new ListViewItem(row["CaseName"].ToString());
                lvi.Tag = (int)row["ID"];
                lvi.Name = row["CaseName"].ToString();
                lvi.ToolTipText = row["Description"].ToString();
                DataTable ci = new CItems().ItemsInCase((int)row["ID"]);
                if (ci.Rows.Count > 0)
                {
                    lvi.ToolTipText += "\r\nContains:";
                    foreach (DataRow r in ci.Rows)
                    {
                        lvi.ToolTipText += "\r\n" + r["Name"].ToString() + "\t" + r["SerNo"].ToString();
                    }
                }
                lvwCases.Items.Add(lvi);
                if ((int)row["ID"] == SelectID)
                {
                    lvi.Selected = true;
                    lvi.EnsureVisible();
                }
            }
            Cases.Dispose();
            lvwCases.EndUpdate();
        }

        private void tvwCategories_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CCategory cat = new CCategory((int)e.Node.Tag);
            PopulateCases(cat.Cases);
        }

        public CCase[] GetSelectedCases()
        {
            // are there cases in the selected cases list?
            if (lvwSelectedCases.Items.Count > 0)
            {
                // build an array of CCase objects to collect cases in list
                CCase[] selectedCases = new CCase[lvwSelectedCases.Items.Count];
                int i = 0;
                foreach (ListViewItem lvi in lvwSelectedCases.Items)
                {
                    // build a new CCase obj of the ID in the list tags
                    selectedCases[i] = new CCase((int)lvi.Tag);
                    i++;
                }
                return selectedCases;
            }
            else
                return null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            FindCase(txtFind.Text);
        }

        private void FindCase(string p)
        {
            if (p.Length > 1)
            {
                PopulateCases(new CCases().SearchCases(p));
            }
        }

        private void txtFind_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
                FindCase(txtFind.Text);
        }

        private void lvwItems_DoubleClick(object sender, EventArgs e)
        {
            if (lvwCases.SelectedItems.Count > 0)
                AddToSelectedList((ListViewItem)lvwCases.SelectedItems[0].Clone());
        }

        private void AddToSelectedList(ListViewItem SelCase)
        {
            foreach (ListViewItem lvi in lvwSelectedCases.Items)
            {
                if (lvi.Text == SelCase.Text)
                    return;
            }
            lvwSelectedCases.Items.Add(SelCase);
            // enable OK button only if selected list is not empty
            btnOK.Enabled = (lvwSelectedCases.Items.Count > 0);
        }

        private void frmFindItem_FormClosed(object sender, FormClosedEventArgs e)
        {
            //try
            //{
            //    SelectedCase.Dispose();
            //}
            //catch { }
        }

        private void btnNewItem_Click(object sender, EventArgs e)
        {
            frmCase fc = new frmCase();
            if (fc.ShowDialog(this) == DialogResult.OK)
            {
                CRecord rec = new CRecord(new SqlCommand("SELECT MAX(ID) As MI FROM [Case]"));
                int newID = (int)rec.Table.Rows[0][0];
                PopulateCases(new CCases().AllCases, newID);
                rec.Dispose();
            }
        }

        private void btnShowCats_Click(object sender, EventArgs e)
        {
            if (this.Width > 450)
            {
                tvwCategories.Visible = false;
                this.Width = 450;
            }
            else
            {
                tvwCategories.Visible = true;
                this.Width = 650;
            }
        }

        private void lvwSelectedCases_DoubleClick(object sender, EventArgs e)
        {
            if (lvwSelectedCases.SelectedItems.Count > 0)
                lvwSelectedCases.Items.Remove(lvwSelectedCases.SelectedItems[0]);
            // enable OK button only if selected list is not empty
            btnOK.Enabled = (lvwSelectedCases.Items.Count > 0);
        }
    }
}

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
    public partial class frmMovement : Form
    {
        CMovement currentMovement;

        public frmMovement(CMovement Movement)
        {
            InitializeComponent();
            currentMovement = Movement;

            lblJob.Text = currentMovement.Job.Job + ", " + currentMovement.Job.Production;
            lblCrew.Text = currentMovement.Job.Crew;
            lblDates.Text = Program.FriendlyDate(currentMovement.Job.CheckOut) + " untill " + Program.FriendlyDate(currentMovement.Job.CheckIn);
            lblItem.Text = currentMovement.Item.Name;
            if (currentMovement.Item.SerialNo.Length > 0) lblItem.Text += "   No. " + currentMovement.Item.SerialNo;
            llbChange.Left = lblItem.Right + 20;
            lblCase.Text = "Case: " + currentMovement.Case.CaseName;
            nudQtty.Value = currentMovement.Quantity;
            chkBack.Checked = currentMovement.Back;
            txtIncluding.Text = currentMovement.ItemIncluding;
            txtNotes.Text = currentMovement.Notes;
            chkIssue.Checked = currentMovement.HasIssue;
        }

        public CMovement Movement
        {
            get
            {
                return currentMovement;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            currentMovement.Back = chkBack.Checked;
            currentMovement.Notes = txtNotes.Text;
            currentMovement.ItemIncluding = txtIncluding.Text;
            currentMovement.Quantity = (int)nudQtty.Value;
            currentMovement.HasIssue = chkIssue.Checked;
            currentMovement.Update();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void frmMovement_FormClosed(object sender, FormClosedEventArgs e)
        {
            currentMovement.Dispose();
        }

        private void llbChange_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmFindItem ffi = new frmFindItem();
            if (ffi.ShowDialog(this) == DialogResult.OK)
            {
                currentMovement.Item = ffi.GetSelectedItems()[0];
                lblItem.Text = currentMovement.Item.Name;
                if (currentMovement.Item.SerialNo.Length > 0) lblItem.Text += "   No. " + currentMovement.Item.SerialNo;
                llbChange.Left = lblItem.Right + 20;
            }
        }
    }
}

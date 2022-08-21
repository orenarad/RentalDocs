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
    public partial class frmUserColor : Form
    {
        public Color SelectedColor;

        public frmUserColor()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            SelectedColor = btn.BackColor;
            DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}

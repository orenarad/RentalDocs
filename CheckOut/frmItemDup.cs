using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace EquipmentCheckOut
{
    public partial class frmItemDup : Form
    {
        CItem currectItem;
        ArrayList serials = new ArrayList();

        public frmItemDup(CItem Item)
        {
            InitializeComponent();
            currectItem = Item;
            lblItem.Text = Item.Name;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            SeperateSerials(txtSerials.Text);
            for (int i = 1; i <= nudCopies.Value; i++)
            {
                CItem nitem = new CItems().NewItem(currectItem.Name);
                nitem.Description = currectItem.Description;
                nitem.Including = currectItem.Including;
                nitem.Active = currectItem.Active;
                nitem.Category = currectItem.Category;
                nitem.Comment = currectItem.Comment;
                nitem.DefaultCase = currectItem.DefaultCase;
                nitem.DefaultQuantity = currectItem.DefaultQuantity;
                nitem.Invoked = currectItem.Invoked;
                try
                {
                    nitem.SerialNo = serials[i - 1].ToString();
                }
                catch { }
                nitem.Update();
                nitem.Dispose();
            }
            this.DialogResult = DialogResult.OK;
        }

        private void SeperateSerials(string Serials)
        {
            string ids = Serials;

            ids = ids.Trim();
            string id;
            int c = ids.IndexOf(",");

            for (; ids.Length > 0; )
            {
                if (c > -1)
                    id = ids.Substring(0, c);
                else
                    id = ids;
                if (id.Length > 0)
                    serials.Add(id);
                if (c > -1)
                    ids = ids.Substring(c + 1);
                else
                    ids = "";
                c = ids.IndexOf("+");
            }
        }
    }
}

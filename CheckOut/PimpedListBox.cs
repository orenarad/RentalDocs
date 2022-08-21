using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EquipmentCheckOut
{
    public struct PimpedListBoxItem
    {
        public string Title;
        public string SubTitle;
        public string Data;
        public int DbID;
    }

    public partial class PimpedListBox : ListBox
    {
        public PimpedListBox()
        {
            InitializeComponent();
            RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            DrawMode = DrawMode.OwnerDrawVariable;
            IntegralHeight = false;
            BorderStyle = System.Windows.Forms.BorderStyle.None;

            DrawItem += new DrawItemEventHandler(lbx_DrawItem);
            MeasureItem += new MeasureItemEventHandler(lbx_MeasureItem);

            //Controls.Add(lbx);
        }

        private void lbx_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
        {
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            if (Items.Count == 0)
                return;
            PimpedListBoxItem pitem = (PimpedListBoxItem)Items[e.Index];
            // Draw the current item text based on the current Font  
            // and the custom brush settings.
            Font titleFont = new System.Drawing.Font(e.Font.FontFamily, 12);
            Font subtitleFont = new System.Drawing.Font(e.Font.FontFamily, 9);
            Font dateFont = new System.Drawing.Font(e.Font.FontFamily, 9);
            Brush titleBrush;
            Brush subtitleBrush;
            Brush dateBrush = new SolidBrush(Color.DarkSlateGray);
            if (e.State == DrawItemState.Selected)  // not working...
            {
                titleBrush = new SolidBrush(Color.White);
                subtitleBrush = new SolidBrush(Color.White);
            }
            else
            {
                titleBrush = new SolidBrush(Color.DarkBlue);
                subtitleBrush = new SolidBrush(Color.Black);
            }
            Rectangle rect = e.Bounds;
            StringFormat sf = new StringFormat(StringFormatFlags.DirectionRightToLeft);
            sf.Trimming = StringTrimming.EllipsisCharacter;

            e.Graphics.DrawString(pitem.Title, titleFont, titleBrush, rect, sf);
            if (pitem.Data != null)
                e.Graphics.DrawString(pitem.Data, dateFont, dateBrush, rect, new StringFormat());
            rect.Offset(0, 20);
            rect.Height -= 21;
            e.Graphics.DrawString(pitem.SubTitle, subtitleFont, subtitleBrush, rect, sf);

            e.Graphics.DrawLine(new Pen(Color.LightBlue), rect.Left + 3, rect.Bottom, rect.Right - 3, rect.Bottom);

            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        private void lbx_MeasureItem(object sender, MeasureItemEventArgs e)
        {
            e.ItemHeight = 40;
        }
    }
}

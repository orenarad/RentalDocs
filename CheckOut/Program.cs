using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace EquipmentCheckOut
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //try
            //{

            Application.Run(new mainUi());
            //Application.Run(new frmFolders());
            //}
            //catch (Exception Ex)
            //{
            //    MessageBox.Show(Ex.Message);
            //}
        }

        public static bool IsNumeric(string Value)
        {
            bool result = false;
            try
            {
                double d = double.Parse(Value);
                result = true;
            }
            catch { }
            return result;

        }

        public static bool IsInteger(string Value)
        {
            bool result = false;
            try
            {
                int d = int.Parse(Value);
                result = true;
            }
            catch { }
            return result;
        }

        public static string FriendlyDate(DateTime Date)
        {
            if (Date == DateTime.Today)
                return "Today";
            else if (Date == DateTime.Today.AddDays(1))
                return "Tomorrow";
            else if (Date < DateTime.Today)
            {
                int days = DateTime.Today.Subtract(Date).Days;
                if (days < 8)
                {
                    if (days == 1)
                        return "Yesterday";
                    else
                        return days.ToString() + " Days Ago";
                }
                else
                    return Date.ToShortDateString();
            }
            else
                return Date.ToShortDateString();
        }

        public static int GetComboIndexOfId(ComboBox comboBox, int SearchId)
        {
            // searchs through a combo box that's using ComboItem objects as Items.
            // returns the list index of the first mached item. returns -1 if 
            // item not found.

            ComboItem ci;
            int i = 0;

            foreach (object obj in comboBox.Items)
            {
                ci = (ComboItem)obj;
                if (ci.ID == SearchId)
                {
                    return i;
                }
                i++;
            }

            return -1;
        }
    }

    class ComboItem
    {
        int m_ItemID;
        string m_ItemText;
        object m_Object = null;

        public ComboItem(string Text, int ID)
        {
            m_ItemID = ID;
            m_ItemText = Text;
        }

        public ComboItem(string Text, object Object)
        {
            m_Object = Object;
            m_ItemText = Text;
        }

        public override string ToString()
        {
            return m_ItemText;
        }

        public int ID
        {
            get
            {
                return m_ItemID;
            }
            set
            {
                m_ItemID = value;
            }
        }

        public string Text
        {
            get
            {
                return m_ItemText;
            }
            set
            {
                m_ItemText = value;
            }
        }

        public object Object
        {
            get
            {
                return m_Object;
            }
            set
            {
                m_Object = value;
            }
        }
    }

    class NodeTag
    {

        int m_NodeItemID = 0;

        public NodeTag(int ItemID)
        {
            m_NodeItemID = ItemID;
        }

        public int ID
        {
            get
            {
                return m_NodeItemID;
            }
            set
            {
                m_NodeItemID = value;
            }
        }
    }

    class ListViewItemTag
    {

        int m_ListViewItemID = 0;

        public ListViewItemTag(int ItemID)
        {
            m_ListViewItemID = ItemID;
        }

        public int ID
        {
            get
            {
                return m_ListViewItemID;
            }
            set
            {
                m_ListViewItemID = value;
            }
        }
    }
}

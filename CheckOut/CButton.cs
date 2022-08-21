using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace EquipmentCheckOut
{
    public class CButton : CRecord
    {
        DataRow row;
        public CButton(int ButtonID)
            : base("Button", ButtonID)
        {
            row = Table.Rows[0];
        }

        public int ID
        {
            get { return (int)row["ID"]; }
        }

        public string Button
        {
            get
            {
                return row["Button"].ToString();
            }
            set
            {
                row["Button"] = value;
            }
        }
    }

    public class CButtons
    {
        public CButtons()
        {
        }

        public DataTable AllButtons
        {
            get
            {
                return new CRecord("Button").Table;
            }
        }

        public CButton NewButton(string Button)
        {
            int newButton;
            newButton = new CRecord().InsertRecordRetriveID("Button", "Button", "'" + Button + "'");
            return new CButton(newButton);
        }

        public CButton this[int ButtonID]
        {
            get
            {
                return new CButton(ButtonID);
            }
        }
    }
}

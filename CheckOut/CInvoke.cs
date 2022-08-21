using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;

namespace EquipmentCheckOut
{
    public class CInvoke :CRecord
    {
        DataRow row;
        public CInvoke(int InvokeID)
            : base("Invoke", InvokeID)
        {
            row = Table.Rows[0];
        }

        public int ID
        {
            get { return (int)row["ID"]; }
        }

        public string Invokes
        {
            get
            {
                return row["Invokes"].ToString();
            }
            set
            {
                row["Invokes"] = value;
            }
        }
    }

    public class CInvokes
    {
        public CInvokes()
        {
        }

        public DataTable AllInvokes
        {
            get
            {
                return new CRecord("Invoke").Table;
            }
        }

        public CInvoke NewInvoke(string Invoke)
        {
            int newInvoke;
            newInvoke = new CRecord().InsertRecordRetriveID("Invoke", "Invokes", Invoke);
            return new CInvoke(newInvoke);
        }
    }
}

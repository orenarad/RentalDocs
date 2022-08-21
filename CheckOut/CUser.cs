using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;
using System.Drawing;

namespace EquipmentCheckOut
{
    public class CUser : CRecord
    {
        DataRow row;
        public CUser (int UserID)
            : base("[User]", UserID)
        {
            row = Table.Rows[0];
        }

        public int ID
        {
            get { return (int)row["ID"]; }
        }

        public string User
        {
            get
            {
                return row["Username"].ToString();
            }
            set
            {
                row["Username"] = value;
            }
        }

        public string Password
        {
            get
            {
                return row["Password"].ToString();
            }
            set
            {
                row["Password"] = value;
            }
        }

        public string Fullname
        {
            get
            {
                return row["Fullname"].ToString();
            }
            set
            {
                row["Fullname"] = value;
            }
        }

        public int LastFolder
        {
            get
            {
                return (int)row["LastFolder"];
            }
            set
            {
                row["LastFolder"] = value;
            }
        }

        public Color ColorSchema
        {
            get
            {
                return Color.FromArgb(255,Color.FromArgb((int)row["ColorSchema"]));
            }
            set
            {
                row["ColorSchema"] = value.ToArgb();
            }
        }
    }

    public class CUsers
    {
        public CUsers()
        {
        }

        public DataTable AllUsers
        {
            get
            {
                return new CRecord("[User]").Table;
            }
        }

        public CUser NewUser(string Username, string Password)
        {
            int newUser;
            newUser = new CRecord().InsertRecordRetriveID("[User]", "Username, Password", "'" + Username + "','" + Password + "'");
            return new CUser(newUser);
        }

        public CUser ValidateLogIn(string Username, string Password)
        {
            SqlCommand cmd = new SqlCommand("SELECT ID FROM [User] WHERE Username = @UN");
            cmd.Parameters.Add("@UN", SqlDbType.NVarChar).Value = Username;
            CRecord rec = new CRecord(cmd);
            if (rec.Table.Rows.Count == 0)
            {
                return null;
            }
            else
            {
                CUser usr = new CUser((int)rec.Table.Rows[0][0]);
                if (usr.Password == Password)
                    return usr;
                else
                    return null;
            }
        }

        public CUser this[int UserID]
        {
            get
            {
                return new CUser(UserID);
            }
        }
    }
}

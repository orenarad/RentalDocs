using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace EquipmentCheckOut
{
    public class CButtonPermission : CRecord
    {
        DataRow row;
        public CButtonPermission(int ButtonPermissionID)
            : base("ButtonPermission", ButtonPermissionID)
        {
            row = Table.Rows[0];
        }

        public int ID
        {
            get { return (int)row["ID"]; }
        }

        public int FolderPermissionID
        {
            get
            {
                return (int)row["FolderPermissionID"];
            }
            set
            {
                row["FolderPermissionID"] = value;
            }
        }

        public int ButtonID
        {
            get
            {
                return (int)row["ButtonID"];
            }
            set
            {
                row["ButtonID"] = value;
            }
        }
    }

    public class CButtonPermissions
    {
        public CButtonPermissions()
        {
        }

        public DataTable AllButtonPermissions
        {
            get
            {
                return new CRecord("ButtonPermission").Table;
            }
        }

        public DataTable ButtonsByFolderPermissionID(int FolderPermissionID)
        {
            DataTable ret = null;
            SqlCommand cmd = new SqlCommand("SELECT     Button.ID, Button.Button, ButtonPermission.ID as PermissionID " +
                                            "FROM       Button INNER JOIN ButtonPermission ON Button.ID = ButtonPermission.ButtonID " +
                                            "WHERE      ButtonPermission.FolderPermissionID = @FolderPermissionID");
            cmd.Parameters.Add("@FolderPermissionID", SqlDbType.Int).Value = FolderPermissionID;
            CRecord rec = new CRecord(cmd);
            ret = rec.Table.Copy();
            rec.Dispose();
            return ret;
        }

        public CButtonPermission NewButtonPermission(int FolderPermissionID, int ButtonID)
        {
            int newButtonPermission;
            newButtonPermission = new CRecord().InsertRecordRetriveID("ButtonPermission", "FolderPermissionID, ButtonID", "'" + FolderPermissionID.ToString() + "','" + ButtonID.ToString() + "'");
            return new CButtonPermission(newButtonPermission);
        }

        public CButtonPermission this[int ButtonPermissionID]
        {
            get
            {
                return new CButtonPermission(ButtonPermissionID);
            }
        }
    }
}

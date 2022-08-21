using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace EquipmentCheckOut
{
    public class CFolderPermission : CRecord
    {
        DataRow row;
        public CFolderPermission(int FolderPermissionID)
            : base("FolderPermission", FolderPermissionID)
        {
            row = Table.Rows[0];
        }

        public int ID
        {
            get { return (int)row["ID"]; }
        }

        public int FolderID
        {
            get
            {
                return (int)row["FolderID"];
            }
            set
            {
                row["FolderID"] = value;
            }
        }

        public int UserID
        {
            get
            {
                return (int)row["UserID"];
            }
            set
            {
                row["UserID"] = value;
            }
        }

        public void DeleteRelatedButtonPermissions()
        {
            //CRecord del = new CRecord("ButtonPermission", "FolderPermissionID", ID, true);
            //del.Dispose();
        }
    }

    public class CFolderPermissions
    {
        public CFolderPermissions()
        {
        }

        public DataTable AllPermissions
        {
            get
            {
                return new CRecord("Permission").Table;
            }
        }

        public DataTable FoldersByUser(int UserID, bool MenuItems)
        {
            DataTable ret = null;
            string menuItems = "";
            if (MenuItems == true)
                menuItems = " AND ShowInMenu = 1 ";
            SqlCommand cmd = new SqlCommand("SELECT     Folder.ID, Folder.Folder, Folder.Description, FolderPermission.ID as PermissionID, Folder.IsDocument " +
                                            "FROM       FolderPermission INNER JOIN Folder ON FolderPermission.FolderID = Folder.ID " +
                                            "WHERE      FolderPermission.UserID = @UserID " + menuItems +
                                            "ORDER BY   Folder.ListOrder");
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            CRecord rec = new CRecord(cmd);
            ret = rec.Table.Copy();
            rec.Dispose();
            return ret;
        }

        public bool FolderActionByUser(int UserID, int FolderID, int ActionID)
        {
            // returns true if a user has permmision to add/edit/export a document in a folder
            bool ret = false;

            using (SqlCommand cmd = new SqlCommand("SELECT     FolderPermission.UserID, FolderPermission.FolderID, ButtonPermission.ButtonID " +
                                            "FROM       FolderPermission INNER JOIN ButtonPermission ON FolderPermission.ID = ButtonPermission.FolderPermissionID INNER JOIN [User] ON FolderPermission.UserID = [User].ID INNER JOIN Button ON ButtonPermission.ButtonID = Button.ID INNER JOIN  Folder ON FolderPermission.FolderID = Folder.ID " +
                                            "WHERE      (FolderPermission.UserID = @UserID) " +
                                            "           AND (ButtonPermission.ButtonID = @ActionID) " +
                                            "           AND (FolderPermission.FolderID = @FolderID)"))
            {
                cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
                cmd.Parameters.Add("@ActionID", SqlDbType.Int).Value = ActionID;
                cmd.Parameters.Add("@FolderID", SqlDbType.Int).Value = FolderID;
                using (CRecord rec = new CRecord(cmd))
                {
                    ret = (rec.Table.Rows.Count > 0);
                }
            }

            return ret;
        }

        public DataTable DocTypesByUser(int UserID)
        {
            DataTable ret = null;
            SqlCommand cmd = new SqlCommand("SELECT     Folder.ID, Folder.Folder, Folder.Description, FolderPermission.ID as PermissionID " +
                                            "FROM       FolderPermission INNER JOIN Folder ON FolderPermission.FolderID = Folder.ID " +
                                            "WHERE      FolderPermission.UserID = @UserID AND IsDocument = 1 " + 
                                            "ORDER BY   Folder.ListOrder");
            cmd.Parameters.Add("@UserID", SqlDbType.Int).Value = UserID;
            CRecord rec = new CRecord(cmd);
            ret = rec.Table.Copy();
            rec.Dispose();
            return ret;
        }

        public CFolderPermission NewFolderPermission(int UserID, int FolderID)
        {
            int newFolderPermission;
            newFolderPermission = new CRecord().InsertRecordRetriveID("FolderPermission", "UserID, FolderID", "'" + UserID.ToString() + "','" + FolderID.ToString() + "'");
            return new CFolderPermission(newFolderPermission);
        }

        public CFolderPermission this[int FolderPermissionID]
        {
            get
            {
                return new CFolderPermission(FolderPermissionID);
            }
        }
    }
}

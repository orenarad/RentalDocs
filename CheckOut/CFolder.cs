using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace EquipmentCheckOut
{
    public class CFolder : CRecord
    {
        DataRow row;
        public CFolder(int FolderID)
            : base("Folder", FolderID)
        {
            row = Table.Rows[0];
        }

        public int ID
        {
            get { return (int)row["ID"]; }
        }

        public string Description
        {
            get
            {
                return row["Description"].ToString();
            }
            set { row["Description"] = value; }
        }

        public string Folder
        {
            get
            {
                return row["Folder"].ToString();
            }
            set
            {
                row["Folder"] = value;
            }
        }

        public int Perfix
        {
            get { return (int)row["Prefix"]; }
            set { row["Prefix"] = value; }
        }

        public string Notes
        {
            get
            {
                if (row["Notes"].ToString().Length > 0)
                    return row["Notes"].ToString();
                else
                    return null;
            }
            set { row["Notes"] = value; }
        }

        public int ListOrder
        {
            get { return (int)row["ListOrder"]; }
            set { row["ListOrder"] = value; }
        }

        public bool ShowInMenu
        {
            get { return (bool)row["ShowInMenu"]; }
            set { row["ShowInMenu"] = value; }
        }

        public bool IsDocument
        {
            get { return (bool)row["IsDocument"]; }
            set { row["IsDocument"] = value; }
        }

        public bool IsPrintable
        {
            get { return (bool)row["IsPrintable"]; }
            set { row["IsPrintable"] = value; }
        }

        public string DocTerms
        {
            get
            {
                if (row["DocTerms"].ToString().Length > 0)
                    return row["DocTerms"].ToString();
                else
                    return null;
            }
            set { row["DocTerms"] = value; }
        }
    }

    public class CFolders
    {
        public CFolders()
        {
        }

        public DataTable AllFolders
        {
            get
            {
                return new CRecord("SELECT * FROM Folder ORDER BY ListOrder").Table;
            }
        }

        public CFolder NewFolder(string FolderName, string Description)
        {
            int newFolder;
            newFolder = new CRecord().InsertRecordRetriveID("Folder", "Folder, Description", "N'" + FolderName.Replace("'", "''") + "',N'" + Description.Replace("'", "''") + "'");
            return new CFolder(newFolder);
        }

        public CFolder this[int FolderID]
        {
            get
            {
                return new CFolder(FolderID);
            }
        }
    }
}

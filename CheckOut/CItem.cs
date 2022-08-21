using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace EquipmentCheckOut
{
    public class CItem : CRecord
    {
        public enum ItemStatus
        {
            InHoues,
            Out,
            Malfunction
        }

        DataRow row;
        internal bool IsEmpty;

        public CItem(int ItemID)
            : base("Item", ItemID)
        {
            row = Table.Rows[0];
        }

        public int ID
        {
            get { return (int)row["ID"]; }
        }

        public CCategory Category
        {
            get
            {
                if (row["Category"] == DBNull.Value)
                    return new CCategory(1);
                else
                    return new CCategory((int)row["Category"]);
            }
            set
            {
                row["Category"] = value.ID;
            }
        }

        public string Name
        {
            get
            {
                return row["Name"].ToString();
            }
            set
            {
                row["Name"] = value;
            }
        }

        public string Description
        {
            get
            {
                try
                {
                    return row["Description"].ToString();
                }
                catch { return ""; }
            }
            set
            {
                row["Description"] = value;
            }
        }

        public string Including
        {
            get
            {
                try
                {
                    return row["Including"].ToString();
                }
                catch { return ""; }
            }
            set
            {
                row["Including"] = value;
            }
        }

        public string SerialNo
        {
            get
            {
                try
                {
                    return row["SerNo"].ToString();
                }
                catch { return ""; }
            }
            set
            {
                row["SerNo"] = value;
            }
        }

        public string Comment
        {
            get
            {
                try
                {
                    return row["Comment"].ToString();
                }
                catch { return ""; }
            }
            set
            {
                row["Comment"] = value;
            }
        }

        public CCase DefaultCase
        {
            get
            {
                try
                {
                    return new CCase((int)row["DefaultCaseID"]);
                }
                catch { return null; }
            }
            set
            {
                if (value == null)
                    row["DefaultCaseID"] = DBNull.Value;
                else
                {
                    row["DefaultCaseID"] = value.ID.ToString();
                    value.Dispose();
                }
            }
        }

        public int DefaultQuantity
        {
            get
            {
                try
                {
                    return (int)row["DefaultQtty"];
                }
                catch { return 0; }
            }
            set
            {
                row["DefaultQtty"] = value;
            }
        }

        public bool Active
        {
            get
            {
                return (bool)row["Active"];
            }
            set
            {
                row["Active"] = value;
            }
        }

        public CInvoke Invoked
        {
            get
            {
                try
                {
                    return new CInvoke((int)row["Invoked"]);
                }
                catch { return null; }
            }
            set
            {
                if (value != null)
                {
                    row["Invoked"] = value.ID;
                    value.Dispose();
                }
                else
                    row["Invoked"] = 0;
            }
        }

        public ItemStatus Status
        {
            get
            {
                return GetItemStatus();
            }
        }

        public DateTime EnterService { get; internal set; }
        public int CatalogItem { get; internal set; }

        private ItemStatus GetItemStatus()
        {
            ItemStatus res = ItemStatus.InHoues;
            SqlCommand cmd = new SqlCommand("SELECT MAX(HasIssue) AS Issue, MIN(Back) AS Back FROM Movement WHERE ItemID = " + ID.ToString());
            CRecord rec = new CRecord(cmd);

            if (rec.Table.Rows[0]["Issue"].ToString().Length > 0)
                if ((int)rec.Table.Rows[0]["Issue"] == 1)
                    res = ItemStatus.Malfunction;
            if (rec.Table.Rows[0]["Back"].ToString().Length > 0)
                if ((int)rec.Table.Rows[0]["Back"] == 0)
                    res = ItemStatus.Out;

            rec.Dispose();
            cmd.Dispose();
            return res;
        }

        public void DeleteThisItem()
        {
            CRecord rec = new CRecord("Item", ID, true);
            rec.Dispose();
            Dispose();
        }
    }

    public class CItems : CRecord
    {
        public const string itemSql = "SELECT         Item.ID, Item.Name, Item.Description, " +
                                 "               Item.Including, Item.SerNo, " +
                                 "               Item.Comment, Item.DefaultCaseID, " +
                                 "               Item.DefaultQtty, Item.Category, Item.Invoked, " +
                                 "               MIN(Movement.Back) AS Back, MAX(Movement.HasIssue) AS Issue, [Case].CaseName, " +
                                 "               (SELECT     Job.Production FROM Job WHERE ID = MAX(dbo.Movement.JobID)) AS Prod " +
                                 "FROM           Job RIGHT OUTER JOIN Movement ON Job.ID = Movement.JobID RIGHT OUTER JOIN Item ON Movement.ItemID = Item.ID LEFT OUTER JOIN [Case] ON Item.DefaultCaseID = [Case].ID " +
                                 "GROUP BY       Item.Name, Item.ID, Item.Description, Item.Including, " +
                                 "               Item.SerNo, Item.Comment, Item.DefaultCaseID, " +
                                 "               Item.DefaultQtty, Item.Category, Item.Invoked, [Case].CaseName ";

        public DataTable AllItems { get; internal set; }

        public CItems() 
            : base (new System.Data.SqlClient.SqlCommand(itemSql))
        {
        }

        public CItems(string SearchCritiria)
            : base(new System.Data.SqlClient.SqlCommand(itemSql +
                                                        "HAVING         (Item.Name LIKE '%" + SearchCritiria + "%') OR (Item.ID LIKE '%" + SearchCritiria + "%') OR (Item.SerNo LIKE '%" + SearchCritiria + "%')"))
        {
        }
    
        public CItems(CCase Case)
            : base(new System.Data.SqlClient.SqlCommand(itemSql +
                                                        "HAVING         (DefaultCaseID = '" + Case.ID.ToString() + "')"))
        {
        }

        public CItems(CInvoke Invoked)
            : base(new System.Data.SqlClient.SqlCommand(itemSql +
                                                        "HAVING         (Invoked = '" + Invoked.ID.ToString() + "')"))
        {
        }

        public CItems(CCategory Category)
            : base(new System.Data.SqlClient.SqlCommand(itemSql +
                                                        "HAVING         (Item.Category = '" + Category.ID.ToString() + "') ORDER BY Name"))
        {
        }

        public CItem NewItem(String Name)
        {
            int newItem;
            newItem = InsertRecordRetriveID("Item","Name", "'" + Name + "'");
            return new CItem(newItem);
        }

        public void SetCategory(CCategory Category)
        {
            foreach (DataRow row in this.Table.Rows)
            {
                row["Category"] = Category.ID;
            }
            this.Update();
            Category.Dispose();
        }

        internal DataTable ItemsByCategory(int iD)
        {
            throw new NotImplementedException();
        }

        internal DataTable ItemsInCase(int iD)
        {
            throw new NotImplementedException();
        }

        internal DataTable ItemsByInvoke(int v)
        {
            throw new NotImplementedException();
        }

        internal DataTable SearchItems(string p)
        {
            throw new NotImplementedException();
        }

        internal DataTable SearchItemsDocs(string v)
        {
            throw new NotImplementedException();
        }

        public CItem this[int ItemID]
        {
            get
            {
                return new CItem(ItemID);
            }
        }
    }
}

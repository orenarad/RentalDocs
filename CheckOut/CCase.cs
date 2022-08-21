using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace EquipmentCheckOut
{
    public class CCase : CRecord
    {
        DataRow row;
        public CCase(int CaseID)
            : base("[Case]", CaseID)
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
                value.Dispose();
            }
        }

        public string CaseName
        {
            get
            {
                return row["CaseName"].ToString();
            }
            set
            {
                row["CaseName"] = value;
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

        public CInvoke Invoke
        {
            get
            {
                try
                {
                    return new CInvoke((int)row["Invoke"]);
                }
                catch { return null; }
            }
            set
            {
                if (value == null)
                    row["Invoke"] = 0;
                else
                {
                    row["Invoke"] = value.ID;
                    value.Dispose();
                }
            }
        }

        public DataTable DefaultItems
        {
            get
            {
                return new CItems().ItemsInCase(ID);
            }
        }

        public DataTable InvokedItems
        {
            get
            {
                if (this.Invoke == null)
                    return null;
                else
                    return new CItems().ItemsByInvoke((int)row["Invoke"]);
            }
        }

        public void AddItem(CItem Item)
        {
            Item.DefaultCase = this;
            Item.Update();
            Item.Dispose();
        }

        public void DeleteThisCase()
        {
            CRecord rec = new CRecord("[Case]", ID, true);
            rec.Dispose();
            Dispose();
        }
    }

    public class CCases
    {
        public CCases() 
        {
        }

        public DataTable AllCases
        {
            get
            {
                return new CRecord("[Case]").Table;
            }
        }

        public DataTable SearchCases(string SearchCritiria)
        {
            return new CRecord("SELECT * FROM [Case] WHERE (CaseName LIKE '%" + SearchCritiria + "%')").Table;
        }

        public DataTable CasesByCategory(int CategoryID)
        {
            return new CRecord(new SqlCommand("SELECT * FROM [Case] WHERE Category = " + CategoryID.ToString())).Table;
        }

        public DataTable CasesByJob(int JobID)
        {
            return new CRecord(new SqlCommand("SELECT     COUNT(*) AS Expr1, " +
                                                        "           [Case].ID, " +
                                                        "           [Case].CaseName, " +
                                                        "           [Case].Description, " +
                                                        "           [Case].Invoke " +
                                                        "FROM       Movement INNER JOIN [Case] ON " +
                                                        "           Movement.CaseID = [Case].ID " +
                                                        "GROUP BY   Movement.JobID, [Case].ID, " +
                                                        "           [Case].CaseName, [Case].Description, " +
                                                        "           [Case].Invoke " +
                                                        "HAVING     (Movement.JobID = " + JobID.ToString() + ") " +
                                                        "ORDER BY   MIN(Movement.ID)")).Table;
        }

        public CCase NewCase(string CaseName)
        {
            int newCase;
            newCase = new CRecord().InsertRecordRetriveID("[Case]", "CaseName", "'" + CaseName + "'");
            return new CCase(newCase);
        }


        //public void SetCategory(CCategory Category)
        //{
        //    foreach (DataRow row in this.Table.Rows)
        //    {
        //        row["Category"] = Category.ID;
        //    }
        //    this.Update();
        //    Category.Dispose();
        //}

        public CCase this[int CaseID]
        {
            get
            {
                return new CCase(CaseID);
            }
        }
    }
}

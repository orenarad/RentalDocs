using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EquipmentCheckOut
{
    public class CCategory : CRecord
    {
        DataRow row;
        public CCategory(int CategoryID)
            : base("Category", CategoryID)
        {
            row = Table.Rows[0];
        }

        public int ID
        {
            get { return (int)row["ID"]; }
        }

        public string Category
        {
            get
            {
                return row["Category"].ToString();
            }
            set
            {
                row["Category"] = value;
            }
        }

        public CCategory Parent
        {
            get
            {
                try
                {
                    return new CCategory((int)row["Parent"]);
                }
                catch { return null; }
            }
            set
            {
                if (value == null)
                    row["Parent"] = 1;
                else
                {
                    row["Parent"] = value.ID;
                    value.Dispose();
                }
            }
        }

        public DataTable Items
        {
            get
            {
                return new CItems().ItemsByCategory(ID);
            }
        }

        public DataTable Cases
        {
            get
            {
                return new CCases().CasesByCategory(this.ID);
            }
        }

        public CCategories Children
        {
            get
            {
                return new CCategories(this);
            }
        }
    }

    public class CCategories : CRecord
    {
        public CCategories() 
            : base ("Category")
        {
        }

        public CCategories(string SearchCritiria)
            : base(new SqlCommand("SELECT * FROM Category WHERE (Category LIKE '" + SearchCritiria + "%')"))
        {
        }

        public CCategories(CCategory Parent)
            : base(new SqlCommand("SELECT * FROM Category WHERE Parent = " + Parent.ID))
        {
        }

        public CCategory NewCategory(string Category)
        {
            int newCat;
            newCat = InsertRecordRetriveID("Category", "Category", "'" + Category + "'");
            return new CCategory(newCat);
        }

        public CCategory this[int CatID]
        {
            get
            {
                return new CCategory(CatID);
            }
        }
    }

    public class CategoryTreeView
    {
        CCategories cats = new CCategories();

        public CategoryTreeView(TreeView treeView)
        {
            treeView.Nodes.Add(PopulateNode(cats.Table.Rows[0]));
        }

        private TreeNode PopulateNode(DataRow catRow)
        {
            TreeNode tn = new TreeNode(catRow["Category"].ToString());
            tn.Tag = (int)catRow["ID"];
            foreach (DataRow row in cats.Table.Rows)
            {
                if (row["Parent"].ToString().Length > 0)
                    if ((int)row["Parent"] == (int)catRow["ID"])
                        tn.Nodes.Add(PopulateNode(row));
            }
            return tn;
        }

        public void Dispose()
        {
            cats.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace EquipmentCheckOut
{
    public class CCatalogProduct : CRecord
    {
        DataRow row;
        public CCatalogProduct(int CatalogProductID)
            : base("CatalogProduct", CatalogProductID)
        {
            row = Table.Rows[0];
        }

        public int ID
        {
            get { return (int)row["ID"]; }
        }

        public int CatalogCategoryID
        {
            get { return (int)row["CatID"]; }
            set { row["CatID"] = value; }
        }

        public string ProductName
        {
            get { return row["Product"].ToString(); }
            set { row["Product"] = value; }
        }

        public string ProductDescription
        {
            get { return row["Description"].ToString() + ""; }
            set { row["Description"] = value + ""; }
        }

        public float RentalPrice
        {
            get { return float.Parse(row["RentalPrice"].ToString()); }
            set { row["RentalPrice"] = value; }
        }

        public float SalesPrice
        {
            get { return float.Parse(row["SalesPrice"].ToString()); }
            set { row["SalesPrice"] = value; }
        }

        public bool Inactive
        {
            get { return (bool)row["Inactive"]; }
            set { row["Inactive"] = value; }
        }
    }

    public class CCatalogProducts
    {
        public CCatalogProducts()
        {
        }

        public DataTable AllCatalogProducts(bool OnlyActive = true)
        {
            string inactive = " = 0";
            if (OnlyActive == false)
                inactive = " = 1"; 
            return new CRecord("SELECT * FROM CatalogProduct Where Inactive" + inactive.ToString()).Table;
        }

        public DataTable CatalogProductsByDepartment(int DepID)
        {
            DataTable ret;
            SqlCommand cmd = new SqlCommand("SELECT       CatalogProduct.* " +
                                            "FROM         CatalogCategory INNER JOIN CatalogProduct ON CatalogCategory.ID = CatalogProduct.CatID " +
                                            "WHERE        CatalogCategory.DepID = @DepId");
            cmd.Parameters.Add("@DepId", SqlDbType.Int).Value = DepID;
            using (CRecord rec = new CRecord(cmd))
            {
                ret = rec.Table.Copy();
            }
            cmd.Dispose();
            return ret;
        }

        public DataTable CatalogProductsByCategory(int CatID)
        {
            DataTable ret;
            SqlCommand cmd = new SqlCommand("SELECT * FROM CatalogProduct WHERE CatID = @CatId");
            cmd.Parameters.Add("@CatId", SqlDbType.Int).Value = CatID;
            using (CRecord rec = new CRecord(cmd))
            {
                ret = rec.Table.Copy();
            }
            cmd.Dispose();
            return ret;
        }

        public DataTable SearchCatalogProducts(string SearchCritiria, bool OnlyActive = true)
        {
            DataTable ret;
            string inactive = "0";
            if (OnlyActive == false)
                inactive = "1";
            SqlCommand cmd = new SqlCommand("SELECT * FROM CatalogProduct WHERE (Inactive = " + inactive + " ) AND (Product LIKE N'%" + SearchCritiria.Replace("'", "''") + "%' OR Description LIKE N'%" + SearchCritiria.Replace("'", "''") + "%')");
            using (CRecord rec = new CRecord(cmd))
            {
                ret = rec.Table.Copy();
            }
            cmd.Dispose();
            return ret;
        }

        public DataTable SearchCatalogProducts(string SearchCritiria, int[] CatID)
        {
            DataTable ret;
            // build a string from the passed categoryIDs:
            string catIds = " AND ((CatID = " + CatID[0].ToString() + ")";
            if (CatID.Length > 1)
            {
                for (int i = 1; i < CatID.Length; i++)
                {
                    catIds += " OR (CatID = " + CatID[i].ToString() + ")";
                }
            }
            catIds += ")";
            // perform search:
            SqlCommand cmd = new SqlCommand("SELECT * FROM CatalogProduct WHERE (Product LIKE N'%" + SearchCritiria.Replace("'", "''") + "%')" + catIds);
            using (CRecord rec = new CRecord(cmd))
            {
                ret = rec.Table.Copy();
            }
            cmd.Dispose();
            return ret;
        }

        public CCatalogProduct NewCatalogProduct(int CatalogCatID, string CatalogProduct, float RentalPrice, float SalesPrice)
        {
            int newCatalogProduct;
            newCatalogProduct = new CRecord().InsertRecordRetriveID("CatalogProduct", "CatID, Product, RentalPrice, SalesPrice", "'" + CatalogCatID.ToString() + "',N'" + CatalogProduct.Replace("'", "''") + "','" + RentalPrice.ToString() + "','" + SalesPrice.ToString() + "'");
            return new CCatalogProduct(newCatalogProduct);
        }

        public CCatalogProduct this[int CatalogProductID]
        {
            get
            {
                return new CCatalogProduct(CatalogProductID);
            }
        }
    }

    public class CCatalogCategory : CRecord
    {
        DataRow row;
        public CCatalogCategory(int CatalogCategoryID)
            : base("CatalogCategory", CatalogCategoryID)
        {
            row = Table.Rows[0];
        }

        public int ID
        {
            get { return (int)row["ID"]; }
        }

        public int CatalogDepartmentID
        {
            get { return (int)row["DepID"]; }
            set { row["DepID"] = value; }
        }

        public string Category_EN
        {
            get { return row["Category_EN"].ToString(); }
            set { row["Category_EN"] = value; }
        }

        public string Category_HE
        {
            get { return row["Category_HE"].ToString(); }
            set { row["Category_HE"] = value; }
        }

        public int ListOrder
        {
            get { return (int)row["ListOrder"]; }
            set { row["ListOrder"] = value; }
        }
    }

    public class CCatalogCategories
    {
        public CCatalogCategories()
        {
        }

        public DataTable AllCatalogCategories()
        {
            return new CRecord("CatalogCategory").Table;
        }

        public DataTable AllCatalogCategories(int DepID)
        {
            DataTable ret;
            SqlCommand cmd = new SqlCommand("SELECT * FROM CatalogCategory WHERE DepID = @DepId ORDER BY ListOrder");
            cmd.Parameters.Add("@DepId", SqlDbType.Int).Value = DepID;
            using (CRecord rec = new CRecord(cmd))
            {
                ret = rec.Table.Copy();
            }
            cmd.Dispose();
            return ret;
        }

        public CCatalogCategory NewCatalogCategory(int CatalogDepID, string Category_EN, string Category_HE)
        {
            int newCatalogCategory;
            newCatalogCategory = new CRecord().InsertRecordRetriveID("CatalogCategory", "DepID, Category_EN, Category_HE", "'" + CatalogDepID.ToString() + "',N'" + Category_EN.Replace("'", "''") + "',N'" + Category_HE.Replace("'", "''") + "'");
            return new CCatalogCategory(newCatalogCategory);
        }

        public CCatalogCategory this[int CatalogCategoryID]
        {
            get
            {
                return new CCatalogCategory(CatalogCategoryID);
            }
        }
    }

    public class CCatalogDepatment : CRecord
    {
        DataRow row;
        public CCatalogDepatment(int CatalogDepatmentID)
            : base("CatalogDepartment", CatalogDepatmentID)
        {
            row = Table.Rows[0];
        }

        public int ID
        {
            get { return (int)row["ID"]; }
        }

        public string Category_EN
        {
            get { return row["Depatment_EN"].ToString(); }
            set { row["Depatment_EN"] = value; }
        }

        public string Category_HE
        {
            get { return row["Depatment_HE"].ToString(); }
            set { row["Depatment_HE"] = value; }
        }

        public int ListOrder
        {
            get { return (int)row["ListOrder"]; }
            set { row["ListOrder"] = value; }
        }

        public int[] GetCategories()
        {
            using (DataTable cats = new CCatalogCategories().AllCatalogCategories(ID))
            {
                int[] catArray;
                catArray = new int[cats.Rows.Count];   // nubmer of cats
                int i = 0;
                foreach (DataRow cat in cats.Rows)
                {
                    catArray[i] = (int)cat["ID"];
                    i++;
                }
                return catArray;
            }
        }
    }

    public class CCatalogDepatments
    {
        public CCatalogDepatments()
        {
        }

        public DataTable AllCatalogDepatments
        {
            get
            {
                return new CRecord("SELECT * FROM CatalogDepartment ORDER BY ListOrder").Table;
            }
        }

        public CCatalogDepatment NewCatalogDepatment(string Depatment_EN, string Depatment_HE)
        {
            int newCatalogDepatment;
            newCatalogDepatment = new CRecord().InsertRecordRetriveID("CatalogDepatment", "Depatment_EN, Depatment_HE", "N'" + Depatment_EN.Replace("'", "''") + "',N'" + Depatment_HE.Replace("'", "''") + "'");
            return new CCatalogDepatment(newCatalogDepatment);
        }

        public CCatalogDepatment this[int CatalogDepatmentID]
        {
            get
            {
                return new CCatalogDepatment(CatalogDepatmentID);
            }
        }
    }

}

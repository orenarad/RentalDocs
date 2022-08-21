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
    public enum DocumentType
    {
        Quotation = 2,
        ExitCertificate = 3,
        ReturnCertificate = 4,
        CheckOut = 5,
        Bill = 7
    }

    public class CDocumentRow
    {
        public int DBId;
        public int DocumentID;
        public int ProductID;
        public string ProductName;
        public string ProductDescription;
        public int Quantity;
        public int QuantityLimit;
        public int Days;
        public double RentalPrice;
        public double SalesPrice;
        public double Discount;
        public int RelatedRowID;
        public int RelatedRowIdDocumentNo;

        public CDocumentRow(int documentID)
        {
            DocumentID = documentID;
            RelatedRowID = 0;
            RentalPrice = 0;
            SalesPrice = 0;
        }

        public const string BALANCED_ROWS = 
                        "SELECT         [Document].DocType, [Document].Date1, [Document].ProjectID, [Document].DocNumber, [Document].Subject, [Document].Printed ,DocumentProduct.*, " +
                        "               ISNULL(Documents_SumOfQuantityRelated.SumOfQuantity,0) as SumOfQuantity, " +
                        "               (DocumentProduct.Quantity - ISNULL(Documents_SumOfQuantityRelated.SumOfQuantity,0)) as Balance " +
                        "FROM           [Document] INNER JOIN DocumentProduct ON [Document].ID = DocumentProduct.DocumentID LEFT OUTER JOIN Documents_SumOfQuantityRelated ON DocumentProduct.ID = Documents_SumOfQuantityRelated.RelatedDocProdID ";


        public DataTable GetDocumentRows(int[] IDs)
        {
            // returns all document rows of a given ids
            string where = " WHERE ";
            foreach (int id in IDs)
            {
                where += "(DocumentProduct.ID = " + id.ToString() + ") OR ";
            }
            where = where.Substring(0, where.Length - 4);
            using (CRecord rec = new CRecord(
                        BALANCED_ROWS +
                        where +
                        " ORDER BY       [Document].ID DESC, DocumentProduct.ID"))
            {
                return rec.Table.Copy();
            }
            //"SELECT         DocumentProduct.*, [Document].DocType, [Document].ProjectID, [Document].DocNumber, [Document].Printed, [Document].Subject, " +
            //"               ISNULL(DocumentProduct_1.ID,0) AS ID2, " +
            //"               ISNULL(DocumentProduct_1.Quantity, 0) AS Quantity2, " +
            //"               (DocumentProduct.Quantity - ISNULL(DocumentProduct_1.Quantity, 0)) as Balance " +
            //"FROM           DocumentProduct INNER JOIN [Document] ON DocumentProduct.DocumentID = [Document].ID LEFT OUTER JOIN DocumentProduct AS DocumentProduct_1 ON DocumentProduct.ID = DocumentProduct_1.RelatedDocProdID " +        }
        }

        public DataTable GetDocumentRows(DocumentType DocType, int ProjectID)
        {
            // returns all document rows for a given project and document type
            using (CRecord rec = new CRecord(
                        BALANCED_ROWS +
                        "WHERE          ([Document].ProjectID = " + ProjectID.ToString() + ") AND ([Document].DocType = " + DocType.ToString("d") + ") " +
                        "ORDER BY       [Document].ID DESC, DocumentProduct.ID"))
            {
                return rec.Table.Copy();
            }
        }
    }

    public class CDocument : CRecord
    {

        DataRow row;

        private string DATE2_QUOTE = Properties.Settings.Default.DATE2_QUOTE;
        private string DATE2_SHIP = Properties.Settings.Default.DATE2_SHIP;
        private string DATE2_RECEIVE = Properties.Settings.Default.DATE2_RECEIVE;


        public CDocument (int DocumentID)
            : base("[Document]",DocumentID)
        {
            row = Table.Rows[0];
        }

        public CDocument (int DocumentID, bool WithNames)
            : base(
                    "SELECT         [Document].*, RentalProject.ProjectName, [User].Fullname, RentalProject.ClientID, RentalClient.HashavshevetNumber " +
                    "FROM           [Document] INNER JOIN RentalProject ON [Document].ProjectID = RentalProject.ID INNER JOIN [User] ON [Document].UserID = [User].ID INNER JOIN RentalClient ON RentalProject.ClientID = RentalClient.ID " +
                    "WHERE		    [Document].ID = " + DocumentID.ToString())
        {
            row = Table.Rows[0];
        }

        public int ID
        {
            get { return (int)row["ID"]; }
        }

        public DocumentType DocumentType
        {
            get { return (DocumentType)row["DocType"]; }
            set { row["DocType"] = value.ToString("d"); }
        }

        public int DocumentNumber
        {
            get { return (int)row["DocNumber"]; }
            set { row["DocNumber"] = value; }
        }

        public int ProjectID
        {
            get { return (int)row["ProjectID"]; }
            set { row["ProjectID"] = value; }
        }

        public string ProjecName
        {
            get { return row["ProjectName"].ToString(); }
        }

        public string ProjecText
        {
            get { return row["ProjectText"].ToString(); }
        }

        public string UserName
        {
            get { return row["Fullname"].ToString(); }
        }

        public string ClientName
        {
            get { return row["ClientName"].ToString() + ""; }
            set { row["ClientName"] = value; }
        }

        public int ClientHashavshevetNo
        {
            get { return (int)row["HashavshevetNumber"]; }
        }

        public string ClientDetails
        {
            get { return row["ClientDetails"].ToString() + ""; }
            set { row["ClientDetails"] = value; }
        }

        public string Subject
        {
            get { return row["Subject"].ToString(); }
            set { row["Subject"] = value; }
        }

        public DateTime Date1
        {
            get { return DateTime.Parse(row["Date1"].ToString()); }
            set { row["Date1"] = value; }
        }

        public DateTime Date2
        {
            get { return DateTime.Parse(row["Date2"].ToString()); }
            set { row["Date2"] = value; }
        }

        public string Date2Name
        {
            get 
            {
                switch (DocumentType)
                {
                    case EquipmentCheckOut.DocumentType.Quotation:
                        return DATE2_QUOTE;

                    case EquipmentCheckOut.DocumentType.ExitCertificate:
                        return DATE2_SHIP;

                    case EquipmentCheckOut.DocumentType.ReturnCertificate:
                        return DATE2_RECEIVE;

                    default:
                        return "";
                }
            }
        }

        public bool Printed
        {
            get
            {
                try
                {
                    return (bool)row["Printed"];
                }
                catch { return false; }
            }
            set { row["Printed"] = value; }
        }

        public string Notes
        {
            get { return row["Notes"].ToString() + ""; }
            set { row["Notes"] = value; }
        }

        public int UserID
        {
            get { return (int)row["UserID"]; }
            set { row["UserID"] = value; }
        }

        public int AddNewDocumentRow(CDocumentRow newDocumentRow)
        {
            double Price;
            if (newDocumentRow.SalesPrice > 0)
            {
                Price = newDocumentRow.SalesPrice;
            }
            else
            {
                Price = newDocumentRow.RentalPrice;
            }

            string columns = "DocumentID, ProductID, ProductName, ProductDesc, Quantity, Days, RentalPrice, SalesPrice, Discount, RelatedDocProdID";
            string values = "'" + ID.ToString() +
                            "','" + newDocumentRow.ProductID.ToString() +
                            "',N'" + newDocumentRow.ProductName.Replace("'", "''") +
                            "',N'" + newDocumentRow.ProductDescription.Replace("'", "''") +
                            "','" + newDocumentRow.Quantity.ToString() +
                            "','" + newDocumentRow.Days.ToString() +
                            "','" + newDocumentRow.RentalPrice.ToString() +
                            "','" + newDocumentRow.SalesPrice.ToString() +
                            "','" + newDocumentRow.Discount.ToString() +
                            "','" + newDocumentRow.RelatedRowID.ToString() + "'";
            using (CRecord rec = new CRecord())
            {
                return rec.InsertRecordRetriveID("DocumentProduct", columns, values);
            }
        }

        public void DeleteAllDocumentRows(bool Mark)
        {
            string command;
            if (Mark == true)
                command = "UPDATE DocumentProduct SET Del = 1 WHERE DocumentID = " + this.ID;
            else
                command = "DELETE From DocumentProduct WHERE DocumentID = " + this.ID;
            using (SqlCommand cmd = new SqlCommand(command))
            {
                using (CRecord rec = new CRecord(cmd)) { }
            }
        }

        public void DeleteMarkedDocumentRows()
        {
            string command = "DELETE From DocumentProduct WHERE (Del = 1) AND (DocumentID = " + this.ID + ")";
            using (SqlCommand cmd = new SqlCommand(command))
            {
                using (CRecord rec = new CRecord(cmd)) { }
            }
        }

        public void DeleteThisDocument()
        {
            DeleteAllDocumentRows(false);
            using (CRecord rec = new CRecord("Document", ID, true)) { }
            Dispose();
        }

        public int HasDocumentRows
        {
            get
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Cnt FROM DocumentProduct WHERE DocumentID = " + this.ID.ToString() + " and (Del is null or Del = 0)"))
                {
                    using (CRecord rec = new CRecord(cmd))
                    {
                        int count = (int)rec.Table.Rows[0][0];
                        return count;
                    }
                }
            }
        }

        public DataTable GetDocumentRows()
        {
            using (CRecord rec = new CRecord(
                        "SELECT         DocumentProduct.*, [Document].DocNumber " +
                        "FROM           [Document] INNER JOIN DocumentProduct AS DocumentProduct_1 ON [Document].ID = DocumentProduct_1.DocumentID RIGHT OUTER JOIN DocumentProduct ON DocumentProduct_1.ID = DocumentProduct.RelatedDocProdID " +
                        "WHERE          DocumentProduct.DocumentID = " + ID.ToString()))
            {
                return rec.Table.Copy();
            }
        }
    }

    public class CDocuments
    {
        public CDocuments()
        {
        }

        public DataTable AllDocuments()
        {
            using (CRecord rec = new CRecord("Document"))
            {
                return rec.Table.Copy();
            }
        }

        public DataTable AllDocuments(int FilterID, bool IsProject)
        {
            string whereID;
            if (IsProject == true)
                whereID = "WHERE ([Document].ProjectID = ";
            else
                whereID = "WHERE (RentalProject.ClientID = ";

            using (CRecord rec = new CRecord("SELECT [Document].*, RentalProject.ProjectName " +
                                             "FROM   [Document] INNER JOIN RentalProject ON [Document].ProjectID = RentalProject.ID " +
                                              whereID + FilterID.ToString() + ") " +
                                             " ORDER BY [Document].ID DESC"))
            {
                return rec.Table.Copy();
            }
        }

        public DataTable AllDocuments(DocumentType DocType)
        {
            using (CRecord rec = new CRecord("SELECT [Document].*, RentalProject.ProjectName " +
                                             "FROM   [Document] INNER JOIN RentalProject ON [Document].ProjectID = RentalProject.ID " +
                                             "WHERE  [Document].DocType = " + (int)DocType +
                                             " ORDER BY [Document].ID DESC"))
            {
                return rec.Table.Copy();
            }
        }

        public DataTable AllDocuments(DocumentType DocType, int FilterID, bool IsProject)
        {
            string whereID;
            if (IsProject == true)
                whereID = "AND ([Document].ProjectID = ";
            else
                whereID = "AND (RentalProject.ClientID = ";

            using (CRecord rec = new CRecord("SELECT [Document].*, RentalProject.ProjectName " +
                                             "FROM   [Document] INNER JOIN RentalProject ON [Document].ProjectID = RentalProject.ID " +
                                             "WHERE  ([Document].DocType = " + (int)DocType + ") " +
                                                whereID + FilterID.ToString() + ") " +
                                             "ORDER BY [Document].ID DESC"))
            {
                return rec.Table.Copy();
            }
        }

        public DataTable SearchDocuments(string SearchString)
        {
            DataTable ret;
            using (SqlCommand cmd = new SqlCommand("SELECT [Document].*, RentalProject.ProjectName " +
                                             "FROM   [Document] INNER JOIN RentalProject ON [Document].ProjectID = RentalProject.ID " +
                                             "WHERE  ([Document].Subject LIKE N'%" + SearchString.Replace("'", "''") + "%') " +
                                                     "OR (RentalProject.ProjectName LIKE N'%" + SearchString.Replace("'", "''") + "%') " +
                                                     "OR ([Document].ClientName LIKE N'%" + SearchString.Replace("'", "''") + "%') " +
                                                     "OR ([Document].DocNumber LIKE N'%" + SearchString.Replace("'", "''") + "%')) " +
                                             "ORDER BY [Document].ID DESC"))
            {
                using (CRecord rec = new CRecord(cmd))
                {
                    ret = rec.Table.Copy();
                }
            }
            return ret;
        }

        public DataTable SearchDocuments(string SearchString, DocumentType DocType)
        {
            DataTable ret;
            using (SqlCommand cmd = new SqlCommand("SELECT [Document].*, RentalProject.ProjectName " +
                                             "FROM   [Document] INNER JOIN RentalProject ON [Document].ProjectID = RentalProject.ID " +
                                             "WHERE  ([Document].DocType = " + (int)DocType + ") " +
                                             "AND (([Document].Subject LIKE N'%" + SearchString.Replace("'", "''") + "%') " +
                                                     "OR (RentalProject.ProjectName LIKE N'%" + SearchString.Replace("'", "''") + "%') " +
                                                     "OR ([Document].ClientName LIKE N'%" + SearchString.Replace("'", "''") + "%') " +
                                                     "OR ([Document].DocNumber LIKE N'%" + SearchString.Replace("'", "''") + "%')) " +
                                             "ORDER BY [Document].ID DESC"))
            {
                using (CRecord rec = new CRecord(cmd))
                {
                    ret = rec.Table.Copy();
                }
            }
            return ret;
        }

        public DataTable SearchDocuments(string SearchString, DocumentType DocType, int ClientID, bool IsProject)
        {
            string whereID;
            if (IsProject == true)
                whereID = "AND ([Document].ProjectID = " + ClientID.ToString() + ") ";
            else
                whereID = "AND (RentalProject.ClientID = " + ClientID.ToString() + ") ";

            DataTable ret;
            using (SqlCommand cmd = new SqlCommand("SELECT [Document].*, RentalProject.ProjectName " +
                                             "FROM   [Document] INNER JOIN RentalProject ON [Document].ProjectID = RentalProject.ID " +
                                             "WHERE  ([Document].DocType = " + (int)DocType + ") " + 
                                             whereID +
                                             "AND (([Document].Subject LIKE N'%" + SearchString.Replace("'", "''") + "%') " +
                                                     "OR (RentalProject.ProjectName LIKE N'%" + SearchString.Replace("'", "''") + "%') " +
                                                     "OR ([Document].ClientName LIKE N'%" + SearchString.Replace("'", "''") + "%') " +
                                                     "OR ([Document].DocNumber LIKE N'%" + SearchString.Replace("'", "''") + "%')) " +
                                             "ORDER BY [Document].ID DESC"))
            {
                using (CRecord rec = new CRecord(cmd))
                {
                    ret = rec.Table.Copy();
                }
            }
            return ret;
        }

        public CDocument NewDocument(DocumentType DocType, int ProjectID, string Subject, DateTime Date1, int UserID, bool Draft, string ProjectText)
        {
            int newDocument;
            int DocNumber = 0;
            
            if (Draft == false)
                DocNumber = GetNextDocumentNumber(DocType);

            newDocument = new CRecord().InsertRecordRetriveID("Document", "DocType, DocNumber, ProjectID, Subject, Date1, UserID, ProjectText",
                                                              "'" + DocType.ToString("d") + "','" + DocNumber.ToString() + "','" + ProjectID.ToString() + "',N'" + Subject.Replace("'", "''") + "','" + Date1.ToString("MM/dd/yyyy") + "','" + UserID.ToString() + "',N'" + ProjectText.Replace("'", "''") + "'");
            return new CDocument(newDocument);
        }

        public CCheckOutDocument NewCheckOutDocument(int ProjectID, string Subject, DateTime DateOut, int UserID)
        {
            int newDocument;
            int DocNumber = 0;
            DocNumber = GetNextDocumentNumber(DocumentType.CheckOut);
            newDocument = new CRecord().InsertRecordRetriveID("Document", "DocType, DocNumber, ProjectID, Subject, Date1, UserID",
                                                              "'" + DocumentType.CheckOut.ToString("d") + "','" + DocNumber.ToString() + "','" + ProjectID.ToString() + "',N'" + Subject.Replace("'", "''") + "','" + DateOut.ToString("MM/dd/yyyy") + "','" + UserID.ToString() + "'");

            return new CCheckOutDocument(newDocument);
        }

        public int GetNextDocumentNumber(DocumentType DocType)
        {
            // return the next number of document based on folder type
            int maxNo = 0;
            using (SqlCommand cmd = new SqlCommand("SELECT     MAX(DocNumber) AS MaxDocNo " +
                                                   "FROM       Document " +
                                                   "WHERE     (DocType = @DocType)"))
            {
                cmd.Parameters.Add("@DocType", SqlDbType.Int).Value = DocType.ToString("d");
                using (CRecord rec = new CRecord(cmd))
                {
                    if (rec.Table.Rows[0][0].ToString().Length > 0)
                        maxNo = (int)rec.Table.Rows[0][0];
                    else
                        using (CFolder folder = new CFolder((int)DocType))
                        {
                            maxNo = folder.Perfix;
                        }
                }
            }
            maxNo++;
            
            return maxNo;
        }

        public string GetDocumentRowSubject(int DocumentRowID)
        {
            if (DocumentRowID == 0)
                return "";

            string ret = "";
            using (SqlCommand cmd = new SqlCommand("SELECT     [Document].Subject " +
                                                   "FROM       DocumentProduct INNER JOIN [Document] ON DocumentProduct.DocumentID = [Document].ID " +
                                                   "WHERE     (DocumentProduct.ID = @DocRowID)"))
            {
                cmd.Parameters.Add("@DocRowID", SqlDbType.Int).Value = DocumentRowID;
                using (CRecord rec = new CRecord(cmd))
                {
                    ret = rec.Table.Rows[0][0].ToString();
                }
            }
            return ret;
        }

        public CDocument this[int DocumentID]
        {
            get
            {
                return new CDocument(DocumentID);
            }
        }
    }

    public class CCheckOutDocument :  CDocument
    {
        DataRow row;

        public enum JobStatus
        {
            NoEquipment,
            EquipmentOut,
            EquipmentBack,
            Closed
        }

        public CCheckOutDocument(int CheckOutDocumentID)
            : base(CheckOutDocumentID)
        {
            row = Table.Rows[0];
            DocumentType = EquipmentCheckOut.DocumentType.CheckOut;
        }

        public CCheckOutDocument(int CheckOutDocumentID, bool WithNames)
            : base(CheckOutDocumentID, WithNames)
        {
            row = Table.Rows[0];
            DocumentType = EquipmentCheckOut.DocumentType.CheckOut;
        }

        public string Crew
        {
            get { return row["ClientDetails"].ToString() + ""; }
            set { row["ClientDetails"] = value; }
        }

        public DateTime DateOut
        {
            get { return DateTime.Parse(row["Date1"].ToString()); }
            set { row["Date1"] = value; }
        }

        public DateTime DateIn
        {
            get { return DateTime.Parse(row["Date2"].ToString()); }
            set { row["Date2"] = value; }
        }

        public DataTable GetCheckOutDocumentRows()
        {
            using (CRecord rec = new CRecord(
                        "SELECT             [Document].DocNumber, Movement.*, Item.Name, Item.Description, Item.SerNo, Item.CatalogItem " +
                        "FROM               [Document] INNER JOIN Movement ON [Document].ID = Movement.DocumentID INNER JOIN Item ON Movement.ItemID = Item.ID " +
                        "WHERE              Movement.DocumentID = " + ID.ToString()))
            {
                return rec.Table.Copy();
            }
        }

        public int HasMovements
        {
            get
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Cnt FROM Movement WHERE DocumentID = " + this.ID.ToString() + " and (Del is null or Del = 0)");
                CRecord rec = new CRecord(cmd);
                int count = (int)rec.Table.Rows[0][0];
                cmd.Dispose();
                rec.Dispose();
                return count;
            }
        }

        public void DeleteAllMovements(bool Mark)
        {
            string command;
            if (Mark == true)
                command = "UPDATE Movement SET Del = 1 WHERE JobID = " + this.ID;
            else
                command = "DELETE From Movement WHERE JobID = " + this.ID;
            using (SqlCommand cmd = new SqlCommand(command))
            {
                using (CRecord rec = new CRecord(cmd)) { }
            }
        }

        public void DeleteMarkedMovements()
        {
            string command = "DELETE From Movement WHERE (Del = 1) AND (JobID = " + this.ID + ")";
            SqlCommand cmd = new SqlCommand(command);
            CRecord rec = new CRecord(cmd);
            cmd.Dispose();
            rec.Dispose();
        }

        public void CheckAllItemsIn()
        {
            SqlCommand cmd = new SqlCommand("UPDATE Movement SET Back = 1 WHERE JobID = " + this.ID.ToString());
            CRecord rec = new CRecord(cmd);
            cmd.Dispose();
            rec.Dispose();
        }

        public JobStatus Status
        {
            get
            {
                return GetStatus();
            }
        }

        private JobStatus GetStatus()
        {
            JobStatus result = JobStatus.EquipmentBack;
            if (this.IsClosed() == true)
            {
                result = JobStatus.Closed;
            }
            else
            {
                DataTable moves = new CMovements().MovementsByDocument(this.ID);
                if (moves.Rows.Count == 0)
                {
                    return JobStatus.NoEquipment;
                }
                else
                {
                    foreach (DataRow row in moves.Rows)
                    {
                        if ((int)row[8] == 1)
                        {
                            result = JobStatus.EquipmentOut;
                            break;
                        }
                    }
                }
            }
            return result;
        }

        public bool IsClosed()
        {
            // a job is "closed" if all movement items are marked as "Back"
            bool ret = false;
            using (SqlCommand cmd = new SqlCommand("SELECT COUNT(ID) AS Cnt FROM Movement WHERE (DocumentID = " + this.ID.ToString() + ") AND (Back is null or Back = 0)"))
            {
                using (CRecord rec= new CRecord(cmd))
                {
                    int count = (int)rec.Table.Rows[0][0];
                    ret = (count == 0);
                }
            }
            return ret;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Collections;

namespace EquipmentCheckOut
{
    public class CMovement : CRecord
    {
        DataRow row;
        public CMovement(int MovementID)
            : base("Movement", MovementID)
        {
            row = Table.Rows[0];
        }

        public int ID
        {
            get { return (int)row["ID"]; }
        }

        public CItem Item
        {
            get
            {
                return new CItem((int)row["ItemID"]);
            }
            set
            {
                row["ItemID"] = value.ID.ToString();
                value.Dispose();
            }
        }

        public string ItemIncluding
        {
            get
            {
                try
                {
                    return row["ItemIncluding"].ToString();
                }
                catch { return ""; }
            }
            set
            {
                row["ItemIncluding"] = value;
            }
        }

        public CCase Case
        {
            get
            {
                return new CCase((int)row["CaseID"]);
            }
            set
            {
                row["CaseID"] = value.ID.ToString();
                value.Dispose();
            }
        }

        public CJob Job
        {
            get
            {
                return new CJob((int)row["JobID"]);
            }
            set
            {
                row["JobID"] = value.ID.ToString();
                value.Dispose();
            }
        }

        public string Notes
        {
            get
            {
                try
                {
                    return row["Notes"].ToString();
                }
                catch { return ""; }
            }
            set
            {
                row["Notes"] = value;
            }
        }

        public int Quantity
        {
            get
            {
                try
                {
                    return (int)row["Quantity"];
                }
                catch { return 1; }
            }
            set
            {
                row["Quantity"] = value;
            }
        }

        public bool Back
        {
            get
            {
                return (bool)((int)row["Back"] > 0);
            }
            set
            {
                if (value == true)
                    row["Back"] = 1;
                else
                    row["Back"] = 0;
            }
        }

        public DateTime TimeOut
        {
            get
            {
                return DateTime.Parse(row["TimeOut"].ToString());
            }
            set
            {
                row["TimeOut"] = value;//.ToString("MM/dd/yyyy");
            }
        }

        public DateTime TimeIn
        {
            get
            {
                return DateTime.Parse(row["TimeIn"].ToString());
            }
            set
            {
                row["TimeIn"] = value;//.ToString("MM/dd/yyyy");
            }
        }

        public bool HasIssue
        {
            get
            {
                return (bool)((int)row["HasIssue"] > 0);
            }
            set
            {
                if (value == true)
                    row["HasIssue"] = 1;
                else
                    row["HasIssue"] = 0;
            }
        }
    }

    public class CMovements 
    {
        public CMovements()
        {
        }

        public DataTable MovementsByJob(int JobID)
        {
            DataView dv = new CRecord("SELECT   Movement.ID, [Case].ID AS CaseID, [Case].CaseName, Item.ID AS ItemID, Item.Description, Movement.ItemIncluding, " +
                                    "           Item.Name, Item.SerNo, Movement.Quantity, Movement.Back, Movement.HasIssue, Movement.Notes " +
                                    "FROM       Movement INNER JOIN Item ON Movement.ItemID = Item.ID INNER JOIN [Case] ON Movement.CaseID = [Case].ID " +
                                    "WHERE      (Movement.JobID = " + JobID.ToString() + ") and (Del = 0 or Del is null)").Table.DefaultView;
            dv.Sort = "ID";
            return dv.ToTable();
        }

        public DataTable MovementsByDocument(int CheckOutDocumentID)
        {
            DataView dv = new CRecord("SELECT   Movement.ID, [Case].ID AS CaseID, [Case].CaseName, Item.ID AS ItemID, Item.Description, Movement.ItemIncluding, " +
                                    "           Item.Name, Item.SerNo, Movement.Quantity, Movement.Back, Movement.HasIssue, Movement.Notes " +
                                    "FROM       Movement INNER JOIN Item ON Movement.ItemID = Item.ID INNER JOIN [Case] ON Movement.CaseID = [Case].ID " +
                                    "WHERE      (Movement.DocumentID = " + CheckOutDocumentID.ToString() + ") and (Del = 0 or Del is null)").Table.DefaultView;
            dv.Sort = "ID";
            return dv.ToTable();
        }



        public DataTable MovementsByJobAndCase(int JobID, int CaseID)
        {
            DataView dv = new CRecord("SELECT Movement.ID, Movement.Quantity, " +
                                                        "       Movement.ItemID, Item.Name, " +
                                                        "       Item.SerNo, Item.Description AS ItemDesc, " +
                                                        "       Movement.ItemIncluding, Movement.CaseID, " +
                                                        "       [Case].CaseName, [Case].Description AS CaseDesc, " +
                                                        "       Movement.JobID, Movement.Notes, " +
                                                        "       Movement.Back, Movement.HasIssue " +
                                                        "FROM   Movement INNER JOIN Item ON Movement.ItemID = Item.ID " +
                                                        "INNER JOIN [Case] ON Movement.CaseID = [Case].ID " +
                                                        "WHERE (JobID = " + JobID.ToString() + ") AND (CaseID = " + CaseID.ToString() + ")").Table.DefaultView;
            return dv.ToTable();
        }

        public DataTable MovementsByItem(int ItemID)
        {
            DataView dv = new CRecord("SELECT   Movement.ID, Movement.Quantity, Movement.ItemID, Item.Name, " +
                                        "       Item.SerNo, Item.Description AS ItemDesc, Movement.ItemIncluding, " +
                                        "       Movement.CaseID, [Case].CaseName, [Case].Description AS CaseDesc, Movement.JobID, Movement.Notes, Movement.Back, " +
                                        "       Movement.HasIssue, Job.Production, Job.Job, Job.Crew, Job.CheckOut, Job.CheckIn " +
                                        "FROM   Movement INNER JOIN  Item ON Movement.ItemID = Item.ID INNER JOIN " +
                                        "       [Case] ON Movement.CaseID = [Case].ID INNER JOIN Job ON Movement.JobID = Job.ID " +
                                        "WHERE  (Movement.ItemID = " + ItemID.ToString() + ")").Table.DefaultView;
            return dv.ToTable();
        }

        public CMovement NewMovement(int JobID, CItem Item, int CaseID)
        {
            int newMovement;
            newMovement = new CRecord().InsertRecordRetriveID("Movement", "ItemID, ItemIncluding, CaseID, JobID", "'" + Item.ID.ToString() + "','" + Item.Including + "','" + CaseID.ToString() + "','" + JobID.ToString() + "'");
            Item.Dispose();
            return new CMovement(newMovement);
        }

        public CMovement NewMovement(CVirtualMovement VMovement, int JobID)
        {
            int newMovement;
            newMovement = new CRecord().InsertRecordRetriveID("Movement", "Quantity, ItemID, ItemIncluding, CaseID, JobID", "'" + VMovement.Quanitity.ToString() + "','" + VMovement.Item.ID.ToString() + "','" + VMovement.ItemIncluding + "','" + VMovement.Case.ID.ToString() + "','" + JobID.ToString() + "'");
            VMovement.Dispose();
            return new CMovement(newMovement);
        }

        public CMovement this[int MovementID]
        {
            get
            {
                return new CMovement(MovementID);
            }
        }
    }

    public class CVirtualMovements : CollectionBase
    {
        private CJob job;

        public CVirtualMovements(CJob Job)
        {
            job = Job;
            DataTable moves = new CMovements().MovementsByJob(Job.ID);
            CVirtualMovement vm;
            foreach (DataRow row in moves.Rows)
            {
                vm = new CVirtualMovement((int)row["ItemID"], (int)row["CaseID"]);
                vm.ID = (int)row["ID"];
                vm.ItemIncluding = row["ItemIncluding"].ToString() + "";
                vm.Quanitity = (int)row["Quantity"];
                vm.ListIndex = this.Add(vm);
                vm.Dispose();
            }
            moves.Dispose(); 
        }

        public int Add(CVirtualMovement Movement)
        {
            int Idx = List.Add(Movement);
            Movement.ListIndex = Idx;
            Movement.Dispose();
            return Idx;
        }

        public void Remove(int Index)
        {
            List.RemoveAt(Index);
        }

        public CVirtualMovement this[int Index]
        {
            get
            {
                return (CVirtualMovement)List[Index];
            }
        }

        public void CommitMovements()
        {
            if (job.HasMovements > 0)
                job.DeleteAllMovements(false);
            CMovements moves = new CMovements();
            foreach (object obj in this)
            {
                CVirtualMovement move = (CVirtualMovement)obj;
                if (move.Quanitity > 0)
                    moves.NewMovement(move, job.ID);
            }
        }
    }

    public class CVirtualMovement
    {
        public int ID { get; set; }
        public CItem Item { get; set; }
        public int ListIndex { get; set; }
        public int Quanitity { get; set; }
        public string ItemIncluding { get; set; }
        public CCase Case { get; set; }
        //public DateTime TimeIn { get; set; }
        //public DateTime TimeOut { get; set; }

        public CVirtualMovement(int itemID, int caseID)
        {
            Item = new CItem(itemID);
            Quanitity = Item.DefaultQuantity;
            ItemIncluding = Item.Including;
            Case = new CCase(caseID);
        }

        public void Dispose()
        {
            Item.Dispose();
            Case.Dispose();
        }
    }
}

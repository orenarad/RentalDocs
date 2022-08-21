using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace EquipmentCheckOut
{
    public class CJob : CRecord
    {
        public enum JobStatus
        {
            NoEquipment,
            EquipmentOut,
            EquipmentBack,
            Closed
        }

        DataRow row;

        public CJob(int JobID)
            : base("Job", JobID)
        {
            row = Table.Rows[0];
        }

        public int ID
        {
            get { return (int)row["ID"]; }
        }

        public string Job
        {
            get
            {
                return row["Job"].ToString();
            }
            set
            {
                row["Job"] = value;
            }
        }

        public string Production
        {
            get
            {
                try
                {
                    return row["Production"].ToString();
                }
                catch { return ""; }
            }
            set
            {
                row["Production"] = value;
            }
        }

        public string OpenDeskDocumentNo
        {
            get
            {
                try
                {
                    return row["OpenDeskDoc"].ToString();
                }
                catch { return ""; }
            }
            set
            {
                row["OpenDeskDoc"] = value;
            }
        }

        public string Crew
        {
            get
            {
                try
                {
                    return row["Crew"].ToString();
                }
                catch { return ""; }
            }
            set
            {
                row["Crew"] = value;
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

        public string IssuedBy
        {
            get
            {
                try
                {
                    return row["IssuedBy"].ToString();
                }
                catch { return ""; }
            }
            set
            {
                row["IssuedBy"] = value;
            }
        }

        public string PickedUpBy
        {
            get
            {
                try
                {
                    return row["PickedUpBy"].ToString();
                }
                catch { return ""; }
            }
            set
            {
                row["PickedUpBy"] = value;
            }
        }

        public string CheckedInBy
        {
            get
            {
                try
                {
                    return row["CheckedInBy"].ToString();
                }
                catch { return ""; }
            }
            set
            {
                row["CheckedInBy"] = value;
            }
        }

        public DateTime CheckOut
        {
            get
            {
                return DateTime.Parse(row["CheckOut"].ToString());
            }
            set
            {
                row["CheckOut"] = value;//.ToString("MM/dd/yyyy");
            }
        }

        public DateTime CheckIn
        {
            get
            {
                return DateTime.Parse(row["CheckIn"].ToString());
            }
            set
            {
                row["CheckIn"] = value;//.ToString("MM/dd/yyyy");
            }
        }

        public bool IsClosed
        {
            get
            {
                try
                {
                    return (bool)row["Closed"];
                }
                catch { return false; }
            }
            set
            {
                row["Closed"] = value;
            }
        }

        public int HasMovements
        {
            get
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) AS Cnt FROM Movement WHERE JobID = " + this.ID.ToString() + " and (Del is null or Del = 0)");
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
                using (CRecord rec = new CRecord(cmd)) {}
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
            if (this.IsClosed == true)
            {
                result = JobStatus.Closed;
            }
            else
            {
                DataTable moves = new CMovements().MovementsByJob(this.ID);
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

        public void CloseJob()
        {
            //CheckIn = DateTime.Today;
            //SqlCommand cmd = new SqlCommand("UPDATE Job SET Closed = 1 WHERE ID = " + this.ID.ToString());
            //CRecord rec = new CRecord(cmd);
            //cmd.Dispose();
            //rec.Dispose();
            IsClosed = true;
            Update();
        }

        public void UncloseJob()
        {
            //SqlCommand cmd = new SqlCommand("UPDATE Job SET Closed = 0 WHERE ID = " + this.ID.ToString());
            //CRecord rec = new CRecord(cmd);
            //cmd.Dispose();
            //rec.Dispose();
            IsClosed = false;
            Update();
        }

        public void DeleteThisJob()
        {
            DeleteAllMovements(false);
            CRecord rec = new CRecord("Job", ID, true);
            rec.Dispose();
            Dispose();
        }
    }

    public class CJobs
    {
        public CJobs() 
        {
        }

        public DataTable OpenedJobs
        {
            get
            {
                DataView dv = new CRecord("Jobs_Opened").Table.DefaultView;
                dv.Sort = "ID DESC";
                return dv.ToTable();
            }
        }

        public DataTable AllJobs
        {
            get
            {
                DataView dv = new CRecord("Job").Table.DefaultView;
                dv.Sort = "ID DESC";
                return dv.ToTable();
            }
        }

        public DataTable SearchJobs(string SearchCritiria)
        {
            DataView dv = new CRecord(new SqlCommand("SELECT ID, Job, Production, CheckOut, CheckIn, Closed FROM Job WHERE (Job.Job LIKE N'%" + SearchCritiria + "%') OR (Job.Production LIKE N'%" + SearchCritiria + "%')")).Table.DefaultView;
            dv.Sort = "ID DESC";
            return dv.ToTable();
        }

        public CJob NewJob(string JobName, DateTime CheckOut, DateTime CheckIn)
        {
            int newJob;
            newJob = new CRecord().InsertRecordRetriveID("Job", "Job, CheckOut, CheckIn", "'" + JobName + "','" + CheckOut.ToString("MM/dd/yyyy") + "','" + CheckIn.ToString("MM/dd/yyyy") +  "'");
            return new CJob(newJob);
        }

        public CJob this[int JobID]
        {
            get
            {
                return new CJob(JobID);
            }
        }
    }
}

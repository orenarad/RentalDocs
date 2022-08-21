using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace EquipmentCheckOut
{
    public class CRentalClient : CRecord
    {
        DataRow row;
        public CRentalClient(int RentalClientID)
            : base("RentalClient", RentalClientID)
        {
            row = Table.Rows[0];
        }

        public int ID
        {
            get { return (int)row["ID"]; }
        }

        public string ClientName
        {
            get { return row["ClientName"].ToString(); }
            set { row["ClientName"] = value; }
        }

        public string ClientDetails
        {
            get { return row["ClientDetails"].ToString() + ""; }
            set { row["ClientDetails"] = value + ""; }
        }

        public bool Inactive
        {
            get { return (bool)row["Inactive"]; }
            set { row["Inactive"] = value; }
        }

        public int HashavshevetNumber
        {
            get 
            {
                if (row["HashavshevetNumber"].ToString().Length > 0)
                    return (int)row["HashavshevetNumber"];
                else
                    return 0;
            }
            set { row["HashavshevetNumber"] = value; }
        }
    }

    public class CRentalClients
    {
        public CRentalClients()
        {
        }

        public DataTable AllRentalClients(bool ActiveOnly)
        {
            DataTable ret;
            string whereActive = "";
            if (ActiveOnly == true)
                whereActive = " WHERE (Inactive = 0 or Inactive is NULL)";
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM RentalClient" + whereActive))
            {
                using (CRecord rec = new CRecord(cmd))
                {
                    ret = rec.Table.Copy();
                }
            }
            return ret;
        }

        public DataTable SearchRentalClients(string SearchCritiria)
        {
            DataTable ret;
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM RentalClient WHERE (ClientName LIKE N'%" + SearchCritiria.Replace("'", "''") + "%')"))
            {
                using (CRecord rec = new CRecord(cmd))
                {
                    ret = rec.Table.Copy();
                }
            }
            return ret;
        }

        public DataTable SearchRentalClients(string SearchCritiria, bool ActiveOnly)
        {
            DataTable ret;
            string whereActive = "";
            if (ActiveOnly == true)
                whereActive = " AND (Inactive = 0 or Inactive is NULL)";
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM RentalClient WHERE (ClientName LIKE N'%" + SearchCritiria.Replace("'", "''") + "%')" + whereActive))
            {
                using (CRecord rec = new CRecord(cmd))
                {
                    ret = rec.Table.Copy();
                }
            }
            return ret;
        }

        public CRentalClient NewRentalClient(string ClientName)
        {
            int newRentalClient;
            newRentalClient = new CRecord().InsertRecordRetriveID("RentalClient", "ClientName", "N'" + ClientName.Replace("'","''") + "'");
            return new CRentalClient(newRentalClient);
        }

        public CRentalClient this[int RentalClientID]
        {
            get
            {
                return new CRentalClient(RentalClientID);
            }
        }
    }

    public class CRentalProject : CRecord
    {
        DataRow row;
        public CRentalProject(int RentalProjectID)
            : base("RentalProject", RentalProjectID)
        {
            row = Table.Rows[0];
        }

        public int ID
        {
            get { return (int)row["ID"]; }
        }

        public int RentalClientID
        {
            get { return (int)row["ClientID"]; }
            set { row["ClientID"] = value; }
        }

        public string ProjectName
        {
            get { return row["ProjectName"].ToString(); }
            set { row["ProjectName"] = value; }
        }

        public string ProjectDetails
        {
            get { return row["ProjectDetails"].ToString(); }
            set { row["ProjectDetails"] = value; }
        }

        public bool Inactive
        {
            get { return (bool)row["Inactive"]; }
            set { row["Inactive"] = value; }
        }
    }

    public class CRentalProjects
    {
        public CRentalProjects()
        {
        }

        public DataTable AllRentalProjects()
        {
            return AllRentalProjects(false);
        }

        public DataTable AllRentalProjects(bool ActiveOnly)
        {
            DataTable ret;
            string whereActive = "";
            if (ActiveOnly == true)
                whereActive = " WHERE (RentalProject.Inactive = 0) or (RentalProject.Inactive is NULL)";

            // 31.03.2015 this new syntax sorts the project based on last ducument created
            using (SqlCommand cmd = new SqlCommand("SELECT     RentalProject.ID, RentalProject.ClientID, RentalClient.ClientName, RentalProject.ProjectName, RentalProject.ProjectDetails, MAX([Document].ID) AS LastDoc, RentalProject.Inactive " +
                                                   "FROM         RentalClient INNER JOIN RentalProject ON RentalClient.ID = RentalProject.ClientID LEFT OUTER JOIN [Document] ON RentalProject.ID = [Document].ProjectID " +
                                                    whereActive +
                                                   "GROUP BY   RentalProject.ID, RentalProject.ClientID, RentalClient.ClientName, RentalProject.ProjectName, RentalProject.ProjectDetails, RentalProject.Inactive " +
                                                   "ORDER BY   LastDoc DESC"))

            //using (SqlCommand cmd = new SqlCommand("SELECT  RentalProject.ID, RentalProject.ClientID, RentalClient.ClientName, RentalProject.ProjectName, RentalProject.ProjectDetails, RentalProject.Inactive " +
            //                                       "FROM    RentalClient INNER JOIN RentalProject ON RentalClient.ID = RentalProject.ClientID" + 
            //                                       whereActive +
            //                                       " ORDER BY RentalProject.ID DESC"))
            {
                using (CRecord rec = new CRecord(cmd))
                {
                    ret = rec.Table.Copy();
                }
            }
            return ret;
        }

        public DataTable SearchRentalProjects(string SearchCritiria)
        {
            DataTable ret;
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM RentalProject WHERE (ProjectName LIKE N'%" + SearchCritiria.Replace("'", "''") + "%')"))
            {
                using (CRecord rec = new CRecord(cmd))
                {
                    ret = rec.Table.Copy();
                }
            }
            return ret;
        }

        public DataTable SearchRentalProjects(string SearchCritiria, bool IsActive)
        {
            DataTable ret;
            string isActive = "";
            if (IsActive == true) 
                isActive = " AND RentalProject.Inactive = 0";
            using (SqlCommand cmd = new SqlCommand("SELECT  RentalProject.ID, RentalProject.ClientID, RentalClient.ClientName, RentalProject.ProjectName, RentalProject.ProjectDetails, RentalProject.Inactive " +
                                                   "FROM    RentalClient INNER JOIN RentalProject ON RentalClient.ID = RentalProject.ClientID " +
                                                   "WHERE   (RentalProject.ProjectName LIKE N'%" + SearchCritiria.Replace("'", "''") + "%' OR RentalClient.ClientName LIKE N'%" + SearchCritiria.Replace("'", "''") + "%') " +
                                                   isActive)) 
                                                   
            {
                using (CRecord rec = new CRecord(cmd))
                {
                    ret = rec.Table.Copy();
                }
            }
            return ret;
        }

        public CRentalProject NewRentalProject(int ClientID, string ProjectName)
        {
            int newRentalProject;
            newRentalProject = new CRecord().InsertRecordRetriveID("RentalProject", "ClientID, ProjectName", "'" + ClientID.ToString() + "',N'" + ProjectName.Replace("'", "''") + "'");
            return new CRentalProject(newRentalProject);
        }

        public CRentalProject this[int RentalProjectID]
        {
            get
            {
                return new CRentalProject(RentalProjectID);
            }
        }
    }
}

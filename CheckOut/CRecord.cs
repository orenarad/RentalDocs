#region Using directives

using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;

#endregion

namespace EquipmentCheckOut
{
    public class CRecord : System.IDisposable
    {
        private SqlConnection conn;
        private DataTable dtRecord = new DataTable();
        private SqlDataAdapter adp;
        //private string conStr = "Data Source=MOVIE;Initial Catalog=Inventory;Integrated Security=SSPI;";
        private string conStr = "Data Source=OREN_ARCH\\SQLEXPRESS;Initial Catalog=Camera;Integrated Security=SSPI;";

        public CRecord(string TableName)
        {
            conn = new SqlConnection(conStr);
            SqlCommand cmdSel;
            if (TableName.StartsWith("SELECT") == true)
                cmdSel = new SqlCommand(TableName, conn);
            else
                cmdSel = new SqlCommand("SELECT * FROM " + TableName, conn);
            OpenAdapter(cmdSel);
        }

        public CRecord(string TableName, int RecordID)
        {
            conn = new SqlConnection(conStr);
            SqlCommand cmdSel = new SqlCommand("SELECT * FROM " + TableName + " WHERE Id = " + RecordID.ToString(), conn);
            OpenAdapter(cmdSel);
        }

        public CRecord(string TableName, int RecordID, bool Delete)
        {
            conn = new SqlConnection(conStr);
            SqlCommand cmdSel = new SqlCommand("DELETE FROM " + TableName + " WHERE Id = " + RecordID.ToString(), conn);
            conn.Open();
            cmdSel.ExecuteNonQuery();
        }
        
        public CRecord(SqlCommand Query)
        {
            conn = new SqlConnection(conStr);
            Query.Connection = conn;

            OpenAdapter(Query);
        }

        public CRecord()
        {
        }

        private void OpenAdapter(SqlCommand cmd)
        {
            adp = new SqlDataAdapter(cmd);
            SqlCommandBuilder cmdBdr = new SqlCommandBuilder(adp);
            conn.Open();
            adp.Fill(dtRecord);
        }

        internal int InsertRecordRetriveID(string TableName, string Columns, string Values)
        {
            string cmdText = "INSERT INTO " + TableName + " (" + Columns + ") VALUES (" + Values + ") SET @NewID = SCOPE_IDENTITY()";
            SqlParameter pNewID = new SqlParameter("@NewID", SqlDbType.Int);
            pNewID.Direction = ParameterDirection.Output;
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Parameters.Add(pNewID);
            cmd.ExecuteNonQuery();
            return (int)pNewID.Value;
        }

        public DataTable Table
        {
            get
            {
                return dtRecord;
            }
        }

        public void Update()
        {
            adp.Update(dtRecord);
        }

        public void Dispose()
        {
            try { adp.Dispose(); } catch {}
            try { dtRecord.Dispose(); } catch {}
            conn.Dispose();
        }
    }
}

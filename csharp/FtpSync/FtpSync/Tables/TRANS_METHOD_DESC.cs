using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace FtpSync
{
    public class TRANS_METHOD_DESC : Sync
    {
        public TRANS_METHOD_DESC(SyncConfigurationElement element, string CS) : base(element, CS)
        {
            Initialize();
        }

        public TRANS_METHOD_DESC(Arguments arguments) : base(arguments)
        {
            Initialize();
        }

        public override sealed void Initialize()
        {
            Data.Columns.Add("TRANS_METHOD", typeof(string)).MaxLength = 3;
            Data.Columns.Add("DESC", typeof(string)).MaxLength = 20;
            Data.Columns.Add("DEL", typeof(string)).MaxLength = 1;
            Data.Columns.Add("DEL_FOCUS", typeof(string)).MaxLength = 1;
	        Data.Columns.Add("UPD_STAMP", typeof(DateTime));
            Data.Columns.Add("UPD_USER_ID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("STATUS", typeof(string)).MaxLength = 1;
	        Data.Columns.Add("ENT_STAMP", typeof(DateTime));
            Data.Columns.Add("ENT_USER_ID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("CHG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("CARD_TYPE", typeof(string)).MaxLength = 4;
        }

        public override void Clean()
        {
            TimeSpan fxStart = timer.Elapsed;

            foreach (DataRow row in Data.Rows)
            {
                if (row["TRANS_METHOD"].GetType().ToString() == "System.DBNull")
                    row["TRANS_METHOD"] = string.Empty;                
            }

            TimeSpan fxEnd = timer.Elapsed;

            CleanTime = Math.Round(fxEnd.TotalMilliseconds - fxStart.TotalMilliseconds,3);
        }

        public override SqlCommand StoredProcedure(SqlConnection connection)
        {
            return new SqlCommand("CSP_SYNC_TRANS_METHOD_DESC", connection);
        }
    }
}
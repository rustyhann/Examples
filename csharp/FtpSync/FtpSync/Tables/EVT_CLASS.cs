using System;
using System.Data;
using System.Data.SqlClient;

namespace FtpSync
{
    public class EVT_CLASS : Sync
    {
        public EVT_CLASS(SyncConfigurationElement element, string CS) : base(element, CS)
        {
            Initialize();
        }

        public EVT_CLASS(Arguments arguments) : base(arguments)
        {
            Initialize();
        }

        public override sealed void Initialize()
        {
            Data.Columns.Add("ORG_CODE", typeof(string)).MaxLength = 2;
            Data.Columns.Add("EVT_CLASS", typeof(string)).MaxLength = 5;
            Data.Columns.Add("EVT_CLS_DESC", typeof(string)).MaxLength = 60;
            Data.Columns.Add("SCOPE", typeof(string)).MaxLength = 1;
            Data.Columns.Add("DEL", typeof(string)).MaxLength = 1;
            Data.Columns.Add("CHG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("DEL_FOCUS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("RETIRE", typeof(string)).MaxLength = 1;
            Data.Columns.Add("UPD_STAMP", typeof(DateTime));
            Data.Columns.Add("UPD_USER_ID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("ENT_STAMP", typeof(DateTime));
            Data.Columns.Add("ENT_USER_ID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("SEQUENCE", typeof(string)).MaxLength = 6;
            Data.Columns.Add("EVT_CLS_DESC_ALT1", typeof(string)).MaxLength = 60;
            Data.Columns.Add("EVT_CLS_DESC_ALT2", typeof(string)).MaxLength = 60;
            Data.Columns.Add("EVT_CLS_DESC_ALT3", typeof(string)).MaxLength = 60;
            Data.Columns.Add("EVT_CLS_DESC_ALT4", typeof(string)).MaxLength = 60;
            Data.Columns.Add("EVT_CLS_DESC_ALT5", typeof(string)).MaxLength = 60;
        }

        public override void Clean()
        {
            TimeSpan fxStart = timer.Elapsed;

            foreach (DataRow row in Data.Rows)
            {
                if (row["ORG_CODE"].GetType().ToString() == "System.DBNull")
                    row["ORG_CODE"] = string.Empty;

                if (row["EVT_CLASS"].GetType().ToString() == "System.DBNull")
                    row["EVT_CLASS"] = string.Empty;
            }

            TimeSpan fxEnd = timer.Elapsed;

            CleanTime = Math.Round(fxEnd.TotalMilliseconds - fxStart.TotalMilliseconds, 3);
        }

        public override SqlCommand StoredProcedure(SqlConnection connection)
        {
            return new SqlCommand("CSP_SYNC_EVT_CLASS", connection);
        }
    }
}
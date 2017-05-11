using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;

namespace FtpSync
{
    public class STATUS_MASTER : Sync
    {
        public STATUS_MASTER(SyncConfigurationElement element, string CS) : base(element, CS)
        {
            Initialize();
        }

        public STATUS_MASTER(Arguments arguments) : base(arguments)
        {
            Initialize();
        }

        public override sealed void Initialize()
        {
            Data.Columns.Add("STATUS_CODE", typeof(string)).MaxLength = 2;
            Data.Columns.Add("STATUS_DESC", typeof(string)).MaxLength = 40;
            Data.Columns.Add("EVT_FUNC_EFB", typeof(string)).MaxLength = 1;
            Data.Columns.Add("USR_DEFN_STS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ABBR_STS_DESC", typeof(string)).MaxLength = 5;
            Data.Columns.Add("MKT_CTL", typeof(string)).MaxLength = 1;
            Data.Columns.Add("MKT_SPL", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PHASE_CTL", typeof(string)).MaxLength = 1;
            Data.Columns.Add("USR_STS_3", typeof(string)).MaxLength = 1;
            Data.Columns.Add("USR_STS_4", typeof(string)).MaxLength = 1;
            Data.Columns.Add("USR_STS_5", typeof(string)).MaxLength = 1;
            Data.Columns.Add("USR_STS_6", typeof(string)).MaxLength = 1;
            Data.Columns.Add("USR_STS_7", typeof(string)).MaxLength = 1;
            Data.Columns.Add("USR_DEFN_LDESC", typeof(string)).MaxLength = 15;
            Data.Columns.Add("STS_COLOR", typeof(int));
            Data.Columns.Add("JOB_FUNC_JFB", typeof(string)).MaxLength = 1;
            Data.Columns.Add("DEL", typeof(string)).MaxLength = 1;
            Data.Columns.Add("CHG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("DEL_FOCUS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("TXT_COLOR", typeof(int));
            Data.Columns.Add("ALLOW_BLOCKS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("LOST_FLAG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PROP_CALC", typeof(string)).MaxLength = 1;
        }

        public override void Clean()
        {
            TimeSpan fxStart = timer.Elapsed;

            foreach (DataRow row in Data.Rows)
            {
                if (row["STATUS_CODE"].GetType().ToString() == "System.DBNull")
                    row["STATUS_CODE"] = string.Empty;

                if (row["STATUS_DESC"].GetType().ToString() == "System.DBNull")
                    row["STATUS_DESC"] = string.Empty;

                if (row["EVT_FUNC_EFB"].GetType().ToString() == "System.DBNull")
                    row["EVT_FUNC_EFB"] = string.Empty;

                if (row["USR_DEFN_STS"].GetType().ToString() == "System.DBNull")
                    row["USR_DEFN_STS"] = string.Empty;

                if (row["ABBR_STS_DESC"].GetType().ToString() == "System.DBNull")
                    row["ABBR_STS_DESC"] = string.Empty;

                if (row["MKT_CTL"].GetType().ToString() == "System.DBNull")
                    row["MKT_CTL"] = string.Empty;

                if (row["MKT_SPL"].GetType().ToString() == "System.DBNull")
                    row["MKT_SPL"] = string.Empty;

                if (row["PHASE_CTL"].GetType().ToString() == "System.DBNull")
                    row["PHASE_CTL"] = string.Empty;

                if (row["USR_STS_3"].GetType().ToString() == "System.DBNull")
                    row["USR_STS_3"] = string.Empty;

                if (row["USR_STS_4"].GetType().ToString() == "System.DBNull")
                    row["USR_STS_4"] = string.Empty;

                if (row["USR_STS_5"].GetType().ToString() == "System.DBNull")
                    row["USR_STS_5"] = string.Empty;

                if (row["USR_STS_6"].GetType().ToString() == "System.DBNull")
                    row["USR_STS_6"] = string.Empty;

                if (row["USR_STS_7"].GetType().ToString() == "System.DBNull")
                    row["USR_STS_7"] = string.Empty;

                if (row["USR_DEFN_LDESC"].GetType().ToString() == "System.DBNull")
                    row["USR_DEFN_LDESC"] = string.Empty;
            }

            TimeSpan fxEnd = timer.Elapsed;

            CleanTime = Math.Round(fxEnd.TotalMilliseconds - fxStart.TotalMilliseconds, 3);
        }

        public override SqlCommand StoredProcedure(SqlConnection connection)
        {
            return new SqlCommand("CSP_SYNC_STATUS_MASTER", connection);
        }
    }
}
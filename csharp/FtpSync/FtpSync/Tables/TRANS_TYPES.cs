using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace FtpSync
{
    public class TRANS_TYPES : Sync
    {
        public TRANS_TYPES(SyncConfigurationElement element, string CS) : base(element, CS)
        {
            Initialize();
        }

        public TRANS_TYPES(Arguments arguments) : base(arguments)
        {
            Initialize();
        }

        public override sealed void Initialize()
        {
            Data.Columns.Add("TSM",                   typeof(string)).MaxLength = 11;
            Data.Columns.Add("ORG_CODE",              typeof(string)).MaxLength = 2;
            Data.Columns.Add("TRANS_TYPE",            typeof(string)).MaxLength = 3;
            Data.Columns.Add("TRANS_SOURCE",          typeof(string)).MaxLength = 2;
            Data.Columns.Add("TRANS_METHOD",          typeof(string)).MaxLength = 6;
            Data.Columns.Add("TRANS_DESC",            typeof(string)).MaxLength = 100;
            Data.Columns.Add("STATUS",                typeof(string)).MaxLength = 1;
            Data.Columns.Add("MEMO_TYPE",             typeof(string)).MaxLength = 1;
            Data.Columns.Add("REF_REQ",               typeof(string)).MaxLength = 1;
            Data.Columns.Add("EXPIR_REQ",             typeof(string)).MaxLength = 1;
            Data.Columns.Add("CONTROL_REQ",           typeof(string)).MaxLength = 1;
            Data.Columns.Add("CC_NBR_REQ",            typeof(string)).MaxLength = 1;
            Data.Columns.Add("CC_ID_REQ",             typeof(string)).MaxLength = 1;
            Data.Columns.Add("TRANS_CLASS",           typeof(string)).MaxLength = 1;
            Data.Columns.Add("TRANS_IND",             typeof(string)).MaxLength = 1;
            Data.Columns.Add("REV_DEPOSIT",           typeof(string)).MaxLength = 1;
            Data.Columns.Add("REV_TYPE",              typeof(string)).MaxLength = 3;
            Data.Columns.Add("CURRENCY",              typeof(string)).MaxLength = 3;
            Data.Columns.Add("TRANSFER",              typeof(string)).MaxLength = 1;
            Data.Columns.Add("GROUP",                 typeof(string)).MaxLength = 6;
            Data.Columns.Add("ACCRUE",                typeof(string)).MaxLength = 3;
            Data.Columns.Add("LATE_CHARGE",           typeof(string)).MaxLength = 3;
            Data.Columns.Add("CC_FIRST_NUM",          typeof(string)).MaxLength = 2;
            Data.Columns.Add("CC_MERCH_ID",           typeof(string)).MaxLength = 240;
            Data.Columns.Add("CC_AUTH_USER",          typeof(string)).MaxLength = 400;
            Data.Columns.Add("CC_AUTH_PWD",           typeof(string)).MaxLength = 240;
            Data.Columns.Add("ENT_STAMP",             typeof(DateTime));
            Data.Columns.Add("ENT_USER_ID",           typeof(string)).MaxLength = 10;
            Data.Columns.Add("UPD_STAMP",             typeof(DateTime));
            Data.Columns.Add("UPD_USER_ID",           typeof(string)).MaxLength = 10;
            Data.Columns.Add("ALLOW_FINAL_INV",       typeof(string)).MaxLength = 1;
            Data.Columns.Add("REFUND",                typeof(string)).MaxLength = 1;
            Data.Columns.Add("ALT_TRANS_DESC_1",      typeof(string)).MaxLength = 100;
            Data.Columns.Add("ALT_TRANS_DESC_2",      typeof(string)).MaxLength = 100;
            Data.Columns.Add("ALT_TRANS_DESC_3",      typeof(string)).MaxLength = 100;
            Data.Columns.Add("ALT_TRANS_DESC_4",      typeof(string)).MaxLength = 100;
            Data.Columns.Add("ALT_TRANS_DESC_5",      typeof(string)).MaxLength = 100;
            Data.Columns.Add("SOURCE_DEFAULT",        typeof(string)).MaxLength = 2;
            Data.Columns.Add("AUTO_AUTHORIZE",        typeof(string)).MaxLength = 1;
            Data.Columns.Add("CB_TRANS",              typeof(string)).MaxLength = 1;
            Data.Columns.Add("USER_REF_REQ",          typeof(string)).MaxLength = 1;
            Data.Columns.Add("CC_ID_HIDE",            typeof(string)).MaxLength = 1;
            Data.Columns.Add("CC_NBR_HIDE",           typeof(string)).MaxLength = 1;
            Data.Columns.Add("CONTROL_HIDE",          typeof(string)).MaxLength = 1;
            Data.Columns.Add("EXPIR_HIDE",            typeof(string)).MaxLength = 1;
            Data.Columns.Add("REF_HIDE",              typeof(string)).MaxLength = 1;
            Data.Columns.Add("USER_REF_HIDE",         typeof(string)).MaxLength = 1;
            Data.Columns.Add("GL_HIDE",               typeof(string)).MaxLength = 1;
            Data.Columns.Add("PAYOR_INFO_HIDE",       typeof(string)).MaxLength = 1;
            Data.Columns.Add("FEE_TSM",               typeof(string)).MaxLength = 11;
            Data.Columns.Add("FEE_PCT",               typeof(decimal));
            Data.Columns.Add("FEE_RES_TYPE",          typeof(string)).MaxLength = 6;
            Data.Columns.Add("FEE_RES_CODE",          typeof(string)).MaxLength = 12;
            Data.Columns.Add("FEE_PCT_AMT",           typeof(decimal));
            Data.Columns.Add("FEE_BASIS",             typeof(int));
            Data.Columns.Add("CC_AUTH_SPECS_SEQ_NBR", typeof(int));
        }

        public override void Clean()
        {
            TimeSpan fxStart = timer.Elapsed;
            
            // These columns cannot be null

            Data.Columns["TRANS_TYPE"].ReadOnly = false;
            Data.Columns["TRANS_SOURCE"].ReadOnly = false;
            Data.Columns["TRANS_METHOD"].ReadOnly = false;

            // If System.DBNull was inserted by LumenWorks.IO, replace it with an empty string
            // This follows Ungerboeck convention

            foreach (DataRow row in Data.Rows)
            {
                if (row["TSM"].GetType().ToString() == "System.DBNull")
                    row["TSM"] = string.Empty;

                if (row["ORG_CODE"].GetType().ToString() == "System.DBNull")
                    row["ORG_CODE"] = string.Empty;

                if (row["TRANS_TYPE"].GetType().ToString() == "System.DBNull")
                    row["TRANS_TYPE"] = string.Empty;

                if (row["TRANS_SOURCE"].GetType().ToString() == "System.DBNull")
                    row["TRANS_SOURCE"] = string.Empty;

                if (row["TRANS_METHOD"].GetType().ToString() == "System.DBNull")
                    row["TRANS_METHOD"] = string.Empty;
            }

            TimeSpan fxEnd = timer.Elapsed;

            CleanTime = Math.Round(fxEnd.TotalMilliseconds - fxStart.TotalMilliseconds,3);
        }

        public override SqlCommand StoredProcedure(SqlConnection connection)
        {
            return new SqlCommand("CSP_SYNC_TRANS_TYPES", connection);
        }
    }
}
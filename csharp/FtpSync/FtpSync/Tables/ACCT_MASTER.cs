using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace FtpSync
{
    public class ACCT_MASTER : Sync
    {
        public ACCT_MASTER(SyncConfigurationElement element, string CS) : base(element, CS)
        {
            Initialize();
        }

        public ACCT_MASTER(Arguments arguments) : base(arguments)
        {
            Initialize();
        }

        public override sealed void Initialize()
        {
            Data.Columns.Add("ORG_CODE", typeof(string)).MaxLength = 2;
            Data.Columns.Add("ACCT_CODE", typeof(string)).MaxLength = 8;
            Data.Columns.Add("MAIN_ACCT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("NAME", typeof(string)).MaxLength = 150;
            Data.Columns.Add("TYPE", typeof(string)).MaxLength = 3;
            Data.Columns.Add("CLASS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("STATUS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("LEGAL_NAME", typeof(string)).MaxLength = 150;
            Data.Columns.Add("COMPANY_NAME", typeof(string)).MaxLength = 150;
            Data.Columns.Add("ALPHA_SEARCH_KEY", typeof(string)).MaxLength = 20;
            Data.Columns.Add("ACRONYM", typeof(string)).MaxLength = 10;
            Data.Columns.Add("ADDRESS_L1", typeof(string)).MaxLength = 100;
            Data.Columns.Add("ADDRESS_L2", typeof(string)).MaxLength = 100;
            Data.Columns.Add("ADDRESS_L3", typeof(string)).MaxLength = 100;
            Data.Columns.Add("ADDRESS_L4", typeof(string)).MaxLength = 100;
            Data.Columns.Add("ADDRESS_L5", typeof(string)).MaxLength = 100;
            Data.Columns.Add("ADDRESS_L6", typeof(string)).MaxLength = 100;
            Data.Columns.Add("CITY", typeof(string)).MaxLength = 50;
            Data.Columns.Add("STATE", typeof(string)).MaxLength = 5;
            Data.Columns.Add("POSTAL_CODE", typeof(string)).MaxLength = 25;
            Data.Columns.Add("COUNTRY", typeof(string)).MaxLength = 3;
            Data.Columns.Add("MAIN_PHONE", typeof(string)).MaxLength = 150;
            Data.Columns.Add("MAIN_FAX", typeof(string)).MaxLength = 150;
            Data.Columns.Add("MOBILE", typeof(string)).MaxLength = 150;
            Data.Columns.Add("PERS_PHONE", typeof(string)).MaxLength = 150;
            Data.Columns.Add("EMAIL_ADDRESS", typeof(string)).MaxLength = 150;
            Data.Columns.Add("WEB_ADDRESS", typeof(string)).MaxLength = 150;
            Data.Columns.Add("SALES_REGION", typeof(string)).MaxLength = 4;
            Data.Columns.Add("REP_CODE", typeof(string)).MaxLength = 8;
            Data.Columns.Add("MKT_SEG_1", typeof(string)).MaxLength = 1;
            Data.Columns.Add("MKT_SEG_2", typeof(string)).MaxLength = 3;
            Data.Columns.Add("KEYWORD_1", typeof(string)).MaxLength = 20;
            Data.Columns.Add("KEYWORD_2", typeof(string)).MaxLength = 20;
            Data.Columns.Add("MKT_SIZE", typeof(decimal));
            Data.Columns.Add("MKT_SIZE_UOM", typeof(string)).MaxLength = 3;
            Data.Columns.Add("IACVB_CODE", typeof(string)).MaxLength = 20;
            Data.Columns.Add("EVT_SALES_DESIG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("TOUR_DESIG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PUBREL_DESIG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("MEMBER_DESIG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("AR_DESIG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("AP_DESIG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("VISITOR_DESIG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("REGIS_DESIG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PERS_DESIG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ASSOC_DESIG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("POSITION", typeof(string)).MaxLength = 6;
            Data.Columns.Add("TITLE", typeof(string)).MaxLength = 100;
            Data.Columns.Add("PREFIX", typeof(string)).MaxLength = 100;
            Data.Columns.Add("FIRST_NAME", typeof(string)).MaxLength = 70;
            Data.Columns.Add("MIDDLE_INITIAL", typeof(string)).MaxLength = 10;
            Data.Columns.Add("LAST_NAME", typeof(string)).MaxLength = 70;
            Data.Columns.Add("LAST_NAME2", typeof(string)).MaxLength = 70;
            Data.Columns.Add("SUFFIX", typeof(string)).MaxLength = 100;
            Data.Columns.Add("NICKNAME", typeof(string)).MaxLength = 50;
            Data.Columns.Add("DEPT", typeof(string)).MaxLength = 6;
            Data.Columns.Add("SALUTATION", typeof(string)).MaxLength = 100;
            Data.Columns.Add("BIRTHDAY", typeof(DateTime));
            Data.Columns.Add("TAX_ID", typeof(string)).MaxLength = 20;
            Data.Columns.Add("ACCURACY", typeof(string)).MaxLength = 1;
            Data.Columns.Add("SELECT", typeof(string)).MaxLength = 1;
            Data.Columns.Add("USERID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("PRIVILEGED", typeof(string)).MaxLength = 1;
            Data.Columns.Add("DIRECT_MAIL", typeof(string)).MaxLength = 1;
            Data.Columns.Add("DUP_STS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("DUP_MULTI", typeof(int));
            Data.Columns.Add("DUP_TYPEOF_DATA", typeof(string)).MaxLength = 10;
            Data.Columns.Add("DUP_CONSOL_ACCT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("LANG_PREF", typeof(string)).MaxLength = 2;
            Data.Columns.Add("ENTER_STAMP", typeof(DateTime));
            Data.Columns.Add("ENTER_USERID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("UPD_STAMP", typeof(DateTime));
            Data.Columns.Add("UPD_USERID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("ACCT_SECURITY", typeof(string)).MaxLength = 10;
            Data.Columns.Add("INET_LOGON", typeof(string)).MaxLength = 1;
            Data.Columns.Add("INET_PWD", typeof(string)).MaxLength = 200;
            Data.Columns.Add("SHIP_METHOD", typeof(string)).MaxLength = 3;
            Data.Columns.Add("GENDER", typeof(string)).MaxLength = 1;
            Data.Columns.Add("LANG_CODE", typeof(string)).MaxLength = 3;
            Data.Columns.Add("EFAX_ADDRESS", typeof(string)).MaxLength = 150;
            Data.Columns.Add("ALERT_FREQ", typeof(int));
            Data.Columns.Add("ALERT_LEAD", typeof(int));
            Data.Columns.Add("ALERT_EMAIL", typeof(string)).MaxLength = 150;
            Data.Columns.Add("USE_ALERT", typeof(string)).MaxLength = 1;
            Data.Columns.Add("TITLE_2", typeof(string)).MaxLength = 100;
            Data.Columns.Add("ADDR_LBL_01", typeof(string)).MaxLength = 255;
            Data.Columns.Add("ADDR_LBL_02", typeof(string)).MaxLength = 255;
            Data.Columns.Add("ADDR_LBL_03", typeof(string)).MaxLength = 255;
            Data.Columns.Add("ADDR_LBL_04", typeof(string)).MaxLength = 255;
            Data.Columns.Add("ADDR_LBL_05", typeof(string)).MaxLength = 255;
            Data.Columns.Add("ADDR_LBL_06", typeof(string)).MaxLength = 255;
            Data.Columns.Add("ADDR_LBL_07", typeof(string)).MaxLength = 255;
            Data.Columns.Add("ADDR_LBL_08", typeof(string)).MaxLength = 255;
            Data.Columns.Add("ADDR_LBL_09", typeof(string)).MaxLength = 255;
            Data.Columns.Add("ADDR_LBL_10", typeof(string)).MaxLength = 255;
            Data.Columns.Add("HOTEL_FLAG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("HOTEL_RATING", typeof(int));
            Data.Columns.Add("HOTEL_CAPACITY", typeof(int));
            Data.Columns.Add("CHK_IN_TIME", typeof(DateTime));
            Data.Columns.Add("CHK_OUT_TIME", typeof(DateTime));
            Data.Columns.Add("METH_OF_NOTIFY", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PAY_LOCATION", typeof(string)).MaxLength = 3;
            Data.Columns.Add("PROP_CNTCT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("PROP_CNTCT_ORG", typeof(string)).MaxLength = 2;
            Data.Columns.Add("MULTI_ORG_ACCT", typeof(string)).MaxLength = 20;
            Data.Columns.Add("SYNC_ORG", typeof(string)).MaxLength = 2;
            Data.Columns.Add("SYNC_ACCT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("SYNC_STS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PP_NBR", typeof(string)).MaxLength = 200;
            Data.Columns.Add("PP_ISSUE_LOC", typeof(string)).MaxLength = 50;
            Data.Columns.Add("PP_ISSUE_DATE", typeof(DateTime));
            Data.Columns.Add("PP_EXP_DATE", typeof(DateTime));
            Data.Columns.Add("BIRTH_PLACE", typeof(string)).MaxLength = 200;
            Data.Columns.Add("NATIONALITY", typeof(string)).MaxLength = 3;
            Data.Columns.Add("ID_NBR", typeof(string)).MaxLength = 200;

            // This column is actually a varbinary(max) in the database
            // It is set to a string value so that if there is any data in the
            // export it will be properly imported

            Data.Columns.Add("ACCT_LOGO", typeof(string)).MaxLength = 8000;

            // In the Clean function this column is dropped from the data table
            // and it is not included in the UBSYNC database because it is not needed

            Data.Columns.Add("SPKR_DESIG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("EXTERNAL_CODE", typeof(string)).MaxLength = 40;
            Data.Columns.Add("EVT_SALES_STS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("TOUR_STS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PUBREL_STS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("MEMBER_STS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("AR_STS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("AP_STS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("VISITOR_STS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("REGIS_STS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PERS_STS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("SPKR_STS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("HOTEL_CODE", typeof(string)).MaxLength = 6;
            Data.Columns.Add("REP_CODE_2", typeof(string)).MaxLength = 8;
            Data.Columns.Add("REP_CODE_3", typeof(string)).MaxLength = 8;
            Data.Columns.Add("MAX_REG_HRS", typeof(int));
            Data.Columns.Add("PRS_POSITION", typeof(string)).MaxLength = 6;
            Data.Columns.Add("PRS_DEPT", typeof(string)).MaxLength = 6;
            Data.Columns.Add("PURGE_IND", typeof(string)).MaxLength = 3;
            Data.Columns.Add("PURGE_VALIDATE", typeof(DateTime));
            Data.Columns.Add("PROP_SORT_ORDER", typeof(string)).MaxLength = 4;
            Data.Columns.Add("UNIQUE_ID", typeof(int));
            Data.Columns.Add("TAX_SCHEME", typeof(string)).MaxLength = 12;
            Data.Columns.Add("TAX_REG_STS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PREF_CNTCT_METHOD", typeof(string)).MaxLength = 4;
            Data.Columns.Add("SOCIAL_NETWORK_1", typeof(string)).MaxLength = 255;
            Data.Columns.Add("SOCIAL_NETWORK_2", typeof(string)).MaxLength = 255;
            Data.Columns.Add("SOCIAL_NETWORK_3", typeof(string)).MaxLength = 255;
            Data.Columns.Add("PRIMARY_ACCT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("EXH_RANK_POINTS", typeof(int));
            Data.Columns.Add("EMAIL_DOMAIN", typeof(string)).MaxLength = 100;
            Data.Columns.Add("ANNUAL_REVENUE", typeof(int));
            Data.Columns.Add("NUM_EMPLOYEES", typeof(int));
            Data.Columns.Add("BIO", typeof(string)).MaxLength = 4000;
            Data.Columns.Add("LEAD", typeof(string)).MaxLength = 1;
        }

        public override void Clean()
        {
            TimeSpan fxStart = timer.Elapsed;

            // This column is dropped because we are not using any images

            Data.Columns.Remove("ACCT_LOGO");

            foreach (DataRow row in Data.Rows)
            {
                if (row["ORG_CODE"].GetType().ToString() == "System.DBNull")
                    row["ORG_CODE"] = string.Empty;

                if (row["ACCT_CODE"].GetType().ToString() == "System.DBNull")
                    row["ACCT_CODE"] = string.Empty;

                if (row["MAIN_ACCT"].GetType().ToString() == "System.DBNull")
                    row["MAIN_ACCT"] = string.Empty;

                if (row["NAME"].GetType().ToString() == "System.DBNull")
                    row["NAME"] = string.Empty;

                if (row["CLASS"].GetType().ToString() == "System.DBNull")
                    row["CLASS"] = string.Empty;

                if (row["STATUS"].GetType().ToString() == "System.DBNull")
                    row["STATUS"] = string.Empty;
            }

            TimeSpan fxEnd = timer.Elapsed;

            CleanTime = Math.Round(fxEnd.TotalMilliseconds - fxStart.TotalMilliseconds, 3);
        }

        public override SqlCommand StoredProcedure(SqlConnection connection)
        {
            return new SqlCommand("CSP_SYNC_ACCT_MASTER", connection);
        }
    }
}
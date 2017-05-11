using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace FtpSync
{
    public class TRANSACTIONS : Sync
    {
        public TRANSACTIONS(SyncConfigurationElement element, string CS) : base(element, CS)
        {
            Initialize();
        }

        public TRANSACTIONS(Arguments arguments) : base(arguments)
        {
            Initialize();
        }

        public override sealed void Initialize()
        {
            Data.Columns.Add("ORG_CODE",               typeof(string)).MaxLength = 2;
            Data.Columns.Add("EXT_ACCT_CODE",          typeof(string)).MaxLength = 8;
            Data.Columns.Add("SEQ",                    typeof(int));
            Data.Columns.Add("TRANS_TYPE",             typeof(string)).MaxLength = 3;
            Data.Columns.Add("TRANS_SOURCE",           typeof(string)).MaxLength = 2;
            Data.Columns.Add("TRANS_METHOD",           typeof(string)).MaxLength = 3;
            Data.Columns.Add("MEMO_TRANS",             typeof(string)).MaxLength = 1;
            Data.Columns.Add("AMT",                    typeof(decimal));
            Data.Columns.Add("OPEN_AMT",               typeof(decimal));
            Data.Columns.Add("DISC_ALLOWED",           typeof(decimal));
            Data.Columns.Add("DISC_TAKEN",             typeof(decimal));
            Data.Columns.Add("TRANS_DATE",             typeof(DateTime));
            Data.Columns.Add("DUE_DATE",               typeof(DateTime));
            Data.Columns.Add("FISCAL_YR",              typeof(int));
            Data.Columns.Add("FISCAL_PERIOD",          typeof(int));
            Data.Columns.Add("CLOSED_DATE",            typeof(DateTime));
            Data.Columns.Add("EVT_ID",                 typeof(int));
            Data.Columns.Add("FUNC_ID",                typeof(int));
            Data.Columns.Add("ORD_NBR",                typeof(int));
            Data.Columns.Add("STATEMENT_ID",           typeof(string)).MaxLength = 10;
            Data.Columns.Add("STATEMENT_DATE",         typeof(DateTime));
            Data.Columns.Add("REFERENCE",              typeof(string)).MaxLength = 50;
            Data.Columns.Add("CC_CHECK",               typeof(string)).MaxLength = 50;
            Data.Columns.Add("CC_CONTROL",             typeof(string)).MaxLength = 1000;
            Data.Columns.Add("CC_EXP_DATE",            typeof(DateTime));
            Data.Columns.Add("CC_NAME",                typeof(string)).MaxLength = 40;
            Data.Columns.Add("CC_AUTHORIZED",          typeof(string)).MaxLength = 40;
            Data.Columns.Add("REASON_CODE",            typeof(string)).MaxLength = 2;
            Data.Columns.Add("LOCKBOX_ID",             typeof(string)).MaxLength = 6;
            Data.Columns.Add("REMARK",                 typeof(string)).MaxLength = 40;
            Data.Columns.Add("LOCKBOX_DATE",           typeof(DateTime));
            Data.Columns.Add("LOCKBOX_BATCH_DATE",     typeof(DateTime));
            Data.Columns.Add("BANK_CODE",              typeof(string)).MaxLength = 2;
            Data.Columns.Add("GL_DEBIT",               typeof(string)).MaxLength = 30;
            Data.Columns.Add("GL_CREDIT",              typeof(string)).MaxLength = 30;
            Data.Columns.Add("EXT_BATCH_ID",           typeof(string)).MaxLength = 10;
            Data.Columns.Add("INT_BATCH_ID",           typeof(string)).MaxLength = 10;
            Data.Columns.Add("GL_POSTING_DATE",        typeof(DateTime));
            Data.Columns.Add("GL_POSTED",              typeof(string)).MaxLength = 1;
            Data.Columns.Add("STATUS",                 typeof(string)).MaxLength = 1;
            Data.Columns.Add("SETTLE_DATE",            typeof(DateTime));
            Data.Columns.Add("STS_1",                  typeof(string)).MaxLength = 1;
            Data.Columns.Add("STS_2",                  typeof(string)).MaxLength = 1;
            Data.Columns.Add("ORD_LINE",               typeof(int));
            Data.Columns.Add("CONTACT",                typeof(string)).MaxLength = 8;
            Data.Columns.Add("RES_TYPE",               typeof(string)).MaxLength = 6;
            Data.Columns.Add("RES_CODE",               typeof(string)).MaxLength = 12;
            Data.Columns.Add("DEL",                    typeof(string)).MaxLength = 1;
            Data.Columns.Add("CHG",                    typeof(string)).MaxLength = 1;
            Data.Columns.Add("ENT_DATE_ISO",           typeof(DateTime));
            Data.Columns.Add("ENT_TIME_ISO",           typeof(DateTime));
            Data.Columns.Add("ENT_USER_ID",            typeof(string)).MaxLength = 10;
            Data.Columns.Add("UPD_DATE_ISO",           typeof(DateTime));
            Data.Columns.Add("UPD_TIME_ISO",           typeof(DateTime));
            Data.Columns.Add("UPD_USER_ID",            typeof(string)).MaxLength = 10;
            Data.Columns.Add("TRANS_CLASS",            typeof(string)).MaxLength = 1;
            Data.Columns.Add("INVOICE",                typeof(int));
            Data.Columns.Add("FC_AMT",                 typeof(decimal));
            Data.Columns.Add("FC_CODE",                typeof(string)).MaxLength = 3;
            Data.Columns.Add("FC_OPEN_AMT",            typeof(decimal));
            Data.Columns.Add("FCA_SEQ",                typeof(int));
            Data.Columns.Add("INTERNAL",               typeof(string)).MaxLength = 1;
            Data.Columns.Add("APPLIED_SEQ",            typeof(int));
            Data.Columns.Add("APPLIED_TO_SEQ",         typeof(int));
            Data.Columns.Add("APPLIED_AMT",            typeof(decimal));
            Data.Columns.Add("APPLIED_TO_AMT",         typeof(decimal));
            Data.Columns.Add("APPLIED_DATE",           typeof(DateTime));
            Data.Columns.Add("APPLIED_USER_ID",        typeof(string)).MaxLength = 10;
            Data.Columns.Add("APPLIED_TO_OPEN",        typeof(decimal));
            Data.Columns.Add("RECONCILED",             typeof(string)).MaxLength = 1;
            Data.Columns.Add("FC_ADJ",                 typeof(string)).MaxLength = 1;
            Data.Columns.Add("FC_ADJ_AMT",             typeof(decimal));
            Data.Columns.Add("PAID_AMT",               typeof(decimal));
            Data.Columns.Add("PAID_CURRENCY",          typeof(string)).MaxLength = 3;
            Data.Columns.Add("FCO_AMT",                typeof(decimal));
            Data.Columns.Add("LC_ADJ_AMT",             typeof(decimal));
            Data.Columns.Add("NAME",                   typeof(string)).MaxLength = 150;
            Data.Columns.Add("ADDR1",                  typeof(string)).MaxLength = 100;
            Data.Columns.Add("ADDR2",                  typeof(string)).MaxLength = 100;
            Data.Columns.Add("ADDR3",                  typeof(string)).MaxLength = 100;
            Data.Columns.Add("CITY",                   typeof(string)).MaxLength = 50;
            Data.Columns.Add("STATE",                  typeof(string)).MaxLength = 5;
            Data.Columns.Add("POSTAL_CODE",            typeof(string)).MaxLength = 25;
            Data.Columns.Add("COUNTRY_CODE",           typeof(string)).MaxLength = 3;
            Data.Columns.Add("AUTHORIZED",             typeof(string)).MaxLength = 1;
            Data.Columns.Add("TR_AMT",                 typeof(decimal));
            Data.Columns.Add("PAY_PLAN_ID",            typeof(int));
            Data.Columns.Add("GL_SOURCE",              typeof(string)).MaxLength = 2;
            Data.Columns.Add("ENTRY_NBR",              typeof(string)).MaxLength = 7;
            Data.Columns.Add("CONTROL_SEQ",            typeof(string)).MaxLength = 10;
            Data.Columns.Add("INT_CHG_STS",            typeof(string)).MaxLength = 2;
            Data.Columns.Add("INT_ACC_STS",            typeof(string)).MaxLength = 2;
            Data.Columns.Add("ORIG_CC_CONTROL",        typeof(string)).MaxLength = 1000;
            Data.Columns.Add("FIRST_NAME",             typeof(string)).MaxLength = 70;
            Data.Columns.Add("LAST_NAME",              typeof(string)).MaxLength = 70;
            Data.Columns.Add("ORD_DEPT",               typeof(string)).MaxLength = 6;
            Data.Columns.Add("DELINQUENT_DATE",        typeof(DateTime));
            Data.Columns.Add("FINANCE_CHARGE",         typeof(decimal));
            Data.Columns.Add("LAST_FINANCE_DATE",      typeof(DateTime));
            Data.Columns.Add("FINANCE_CHARGE_EST",     typeof(decimal));
            Data.Columns.Add("LATE_NOTICE_DATE",       typeof(DateTime));
            Data.Columns.Add("PP_SCHED_CODE",          typeof(string)).MaxLength = 3;
            Data.Columns.Add("TRANS_IND",              typeof(string)).MaxLength = 1;
            Data.Columns.Add("CC_ID_FIELD",            typeof(string)).MaxLength = 50;
            Data.Columns.Add("GRP_SEQ",                typeof(int));
            Data.Columns.Add("GRP_TSM",                typeof(string)).MaxLength = 8;
            Data.Columns.Add("GRP_STS",                typeof(string)).MaxLength = 3;
            Data.Columns.Add("TSM",                    typeof(string)).MaxLength = 8;
            Data.Columns.Add("FYP",                    typeof(string)).MaxLength = 6;
            Data.Columns.Add("GL_FYP",                 typeof(string)).MaxLength = 6;
            Data.Columns.Add("GRP_DATE",               typeof(DateTime));
            Data.Columns.Add("FROM_ACCOUNT",           typeof(string)).MaxLength = 8;
            Data.Columns.Add("TO_ACCOUNT",             typeof(string)).MaxLength = 8;
            Data.Columns.Add("USER_REFERENCE",         typeof(string)).MaxLength = 50;
            Data.Columns.Add("CC_EXP_DATE_ENC",        typeof(string)).MaxLength = 50;
            Data.Columns.Add("CC_NBR_ENC",             typeof(string)).MaxLength = 100;
            Data.Columns.Add("TOTAL_AMT",              typeof(decimal));
            Data.Columns.Add("TOTAL_FC_AMT",           typeof(decimal));
            Data.Columns.Add("TOTAL_INDIC",            typeof(string)).MaxLength = 1;
            Data.Columns.Add("REF_INVOICE",            typeof(int));
            Data.Columns.Add("REVERSE_SEQ",            typeof(int));
            Data.Columns.Add("VOUCHER",                typeof(int));
            Data.Columns.Add("CB_DEPOSIT_SEQ",         typeof(int));
            Data.Columns.Add("TRANS_PRINT",            typeof(string)).MaxLength = 1;
            Data.Columns.Add("BANK_AUTH_CODE",         typeof(string)).MaxLength = 100;
            Data.Columns.Add("USER_REF_NBR1",          typeof(int));
            Data.Columns.Add("USER_REF_NBR2",          typeof(int));
            Data.Columns.Add("CARD_TYPE",              typeof(string)).MaxLength = 4;
            Data.Columns.Add("CARD_ISSUE_NBR_ENC",     typeof(string)).MaxLength = 30;
            Data.Columns.Add("CARD_START_MONTH_ENC",   typeof(string)).MaxLength = 30;
            Data.Columns.Add("CARD_START_YEAR_ENC",    typeof(string)).MaxLength = 30;
            Data.Columns.Add("LOCKBOX_BATCH",          typeof(int));
            Data.Columns.Add("LOCKBOX_SEQ",            typeof(int));
            Data.Columns.Add("CC_TOKEN",               typeof(string)).MaxLength = 256;
            Data.Columns.Add("CC_SWIPE",               typeof(string)).MaxLength = 1;
            Data.Columns.Add("AR_CONTROL",             typeof(string)).MaxLength = 10;
            Data.Columns.Add("TRANSIT_NBR",            typeof(string)).MaxLength = 50;
            Data.Columns.Add("ADJ_RCD_TYPE",           typeof(string)).MaxLength = 3;
            Data.Columns.Add("MAIN_SEQ",               typeof(int));
            Data.Columns.Add("TRANS_INFO_SEQ",         typeof(int));
            Data.Columns.Add("BILL_PROFILE_TOKEN_ENC", typeof(string)).MaxLength = 50;
        }

        public override void Clean()
        {
            TimeSpan fxStart = timer.Elapsed;

            foreach (DataRow row in Data.Rows)
            {
                if (row["ORG_CODE"].GetType().ToString() == "System.DBNull")
                    row["ORG_CODE"] = string.Empty;

                if (row["EXT_ACCT_CODE"].GetType().ToString() == "System.DBNull")
                    row["EXT_ACCT_CODE"] = string.Empty;
            }

            TimeSpan fxEnd = timer.Elapsed;

            CleanTime = Math.Round(fxEnd.TotalMilliseconds - fxStart.TotalMilliseconds,3);
        }

        public override SqlCommand StoredProcedure(SqlConnection connection)
        {
            return new SqlCommand("CSP_SYNC_TRANSACTIONS", connection);
        }
    }
}
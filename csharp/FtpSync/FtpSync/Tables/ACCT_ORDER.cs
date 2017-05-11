using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace FtpSync
{
    public class ACCT_ORDER : Sync
    {
        public ACCT_ORDER(SyncConfigurationElement element, string CS) : base(element, CS)
        {
            Initialize();
        }

        public ACCT_ORDER(Arguments arguments) : base(arguments)
        {
            Initialize();
        }

        public override sealed void Initialize()
        {
            Data.Columns.Add("ORG_CODE", typeof(string)).MaxLength = 2;
            Data.Columns.Add("ORD_NBR", typeof(int));
            Data.Columns.Add("SO_SEARCH", typeof(string)).MaxLength = 9;
            Data.Columns.Add("EVT_ID", typeof(int));
            Data.Columns.Add("ORD_TYPE", typeof(string)).MaxLength = 2;
            Data.Columns.Add("FUNC_ID", typeof(int));
            Data.Columns.Add("EVT_SEARCH", typeof(string)).MaxLength = 7;
            Data.Columns.Add("FUNC_SEARCH", typeof(string)).MaxLength = 7;
            Data.Columns.Add("ORD_FORM", typeof(string)).MaxLength = 2;
            Data.Columns.Add("ORD_DATE", typeof(DateTime));
            Data.Columns.Add("ORD_STS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PRT_STS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("MET_NOTIFY", typeof(string)).MaxLength = 4;
            Data.Columns.Add("CANCEL_DATE", typeof(DateTime));
            Data.Columns.Add("CANCEL_USER", typeof(string)).MaxLength = 10;
            Data.Columns.Add("CANCEL_BY", typeof(string)).MaxLength = 30;
            Data.Columns.Add("CANCEL_REASON", typeof(string)).MaxLength = 2;
            Data.Columns.Add("PO_NBR", typeof(string)).MaxLength = 150;
            Data.Columns.Add("PRICE_LIST", typeof(string)).MaxLength = 10;
            Data.Columns.Add("PRICE_COLUMN", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ARR_DATE", typeof(DateTime));
            Data.Columns.Add("ARR_TIME", typeof(DateTime));
            Data.Columns.Add("DEP_DATE", typeof(DateTime));
            Data.Columns.Add("DEP_TIME", typeof(DateTime));
            Data.Columns.Add("BLOCK_CDE", typeof(string)).MaxLength = 6;
            Data.Columns.Add("PROP_CODE", typeof(string)).MaxLength = 8;
            Data.Columns.Add("RM_TYPE", typeof(string)).MaxLength = 2;
            Data.Columns.Add("RM_PRICE_CDE", typeof(string)).MaxLength = 1;
            Data.Columns.Add("NBR_RMS", typeof(int));
            Data.Columns.Add("COMP_DATE", typeof(DateTime));
            Data.Columns.Add("COMP_TIME", typeof(DateTime));
            Data.Columns.Add("COMP_USER", typeof(string)).MaxLength = 10;
            Data.Columns.Add("RES_FUNC_ID", typeof(int));
            Data.Columns.Add("RES_PHASE", typeof(string)).MaxLength = 1;
            Data.Columns.Add("RES_SEQ", typeof(int));
            Data.Columns.Add("NBR_PERS", typeof(int));
            Data.Columns.Add("ACCT_ISSUE", typeof(int));
            Data.Columns.Add("BATCH", typeof(string)).MaxLength = 10;
            Data.Columns.Add("ORD_ACCT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("ORD_CONTACT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("BILL_TO_CUST", typeof(string)).MaxLength = 8;
            Data.Columns.Add("BILL_TO_CONT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("ORD_TOT", typeof(decimal));
            Data.Columns.Add("ORD_TAX", typeof(decimal));
            Data.Columns.Add("ORD_DUE", typeof(decimal));
            Data.Columns.Add("ACT_TOTAL", typeof(decimal));
            Data.Columns.Add("ACT_TAX", typeof(decimal));
            Data.Columns.Add("ACT_DUE", typeof(decimal));
            Data.Columns.Add("ACT_PAYMENTS", typeof(decimal));
            Data.Columns.Add("ACT_CREDITS", typeof(decimal));
            Data.Columns.Add("ORD_CREDITS", typeof(decimal));
            Data.Columns.Add("COMMENT", typeof(string)).MaxLength = 60;
            Data.Columns.Add("ACT_INACT", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PRT_FLAG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("AMT_DUE_IND", typeof(string)).MaxLength = 1;
            Data.Columns.Add("SETUP_ID", typeof(string)).MaxLength = 8;
            Data.Columns.Add("BOOTH_NBR", typeof(string)).MaxLength = 8000;
            Data.Columns.Add("ORD_DESC", typeof(string)).MaxLength = 40;
            Data.Columns.Add("ORD_SPACE", typeof(string)).MaxLength = 6;
            Data.Columns.Add("ORD_STS_1", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ORD_STS_2", typeof(string)).MaxLength = 1;
            Data.Columns.Add("INTERNAL", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ENT_DATE_ISO", typeof(DateTime));
            Data.Columns.Add("ENT_USER_ID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("UPD_DATE_ISO", typeof(DateTime));
            Data.Columns.Add("UPD_USER_ID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("DEL_MARK", typeof(string)).MaxLength = 1;
            Data.Columns.Add("XTRA_ACCT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("USER_8X", typeof(string)).MaxLength = 8;
            Data.Columns.Add("USER_10X", typeof(string)).MaxLength = 10;
            Data.Columns.Add("USER_DATE", typeof(DateTime));
            Data.Columns.Add("ORDER_DESIG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ORDER_TERMS", typeof(string)).MaxLength = 2;
            Data.Columns.Add("SHIP_METHOD", typeof(string)).MaxLength = 3;
            Data.Columns.Add("USER_6X", typeof(string)).MaxLength = 6;
            Data.Columns.Add("USER_8X2", typeof(string)).MaxLength = 8;
            Data.Columns.Add("USER_10X2", typeof(string)).MaxLength = 10;
            Data.Columns.Add("SO_PRT", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PARENT_FUNC", typeof(int));
            Data.Columns.Add("REQ_CUST", typeof(string)).MaxLength = 8;
            Data.Columns.Add("SO_USER_SEQ", typeof(string)).MaxLength = 4;
            Data.Columns.Add("SO_FUNC_SEQ", typeof(int));
            Data.Columns.Add("SHIP_DOC_ID", typeof(string)).MaxLength = 40;
            Data.Columns.Add("SETUP_QTY", typeof(decimal));
            Data.Columns.Add("SO_ACT_INACT", typeof(string)).MaxLength = 1;
            Data.Columns.Add("SHORT_NOTE", typeof(string)).MaxLength = 60;
            Data.Columns.Add("SO_STATUS", typeof(string)).MaxLength = 2;
            Data.Columns.Add("USER_8X1", typeof(string)).MaxLength = 8;
            Data.Columns.Add("USER_8X3", typeof(string)).MaxLength = 8;
            Data.Columns.Add("CONF_ALL_REGIS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("REQ_CONTACT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("BILL_CYCLE", typeof(string)).MaxLength = 1;
            Data.Columns.Add("DUES_CYCLE", typeof(string)).MaxLength = 1;
            Data.Columns.Add("RENEWAL_DATE", typeof(DateTime));
            Data.Columns.Add("CYCLE_DATE", typeof(DateTime));
            Data.Columns.Add("BKG_ORDER", typeof(string)).MaxLength = 1;
            Data.Columns.Add("TRANS_SOURCE", typeof(string)).MaxLength = 2;
            Data.Columns.Add("INVOICE", typeof(int));
            Data.Columns.Add("ORD_SIGN", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ORD_DAYS", typeof(int));
            Data.Columns.Add("TEMPLATE", typeof(string)).MaxLength = 1;
            Data.Columns.Add("WO_CLOSED", typeof(string)).MaxLength = 1;
            Data.Columns.Add("WO_DUE_DATE", typeof(DateTime));
            Data.Columns.Add("WO_RUSH", typeof(string)).MaxLength = 1;
            Data.Columns.Add("CURRENCY", typeof(string)).MaxLength = 3;
            Data.Columns.Add("FC_ORD_TOT", typeof(decimal));
            Data.Columns.Add("FC_ORD_TAX", typeof(decimal));
            Data.Columns.Add("FC_ORD_DUE", typeof(decimal));
            Data.Columns.Add("FC_ACT_TOT", typeof(decimal));
            Data.Columns.Add("FC_ACT_DUE", typeof(decimal));
            Data.Columns.Add("FC_ACT_PAYMENTS", typeof(decimal));
            Data.Columns.Add("FC_ACT_CREDITS", typeof(decimal));
            Data.Columns.Add("FC_ORD_CREDITS", typeof(decimal));
            Data.Columns.Add("FC_ACT_TAX", typeof(decimal));
            Data.Columns.Add("WO_TIME_OFFSET", typeof(string)).MaxLength = 1;
            Data.Columns.Add("WO_SIGN", typeof(string)).MaxLength = 1;
            Data.Columns.Add("WO_DAYS", typeof(int));
            Data.Columns.Add("WO_END_STAMP", typeof(DateTime));
            Data.Columns.Add("PL_CURRENCY", typeof(string)).MaxLength = 3;
            Data.Columns.Add("TR_CURRENCY", typeof(string)).MaxLength = 3;
            Data.Columns.Add("TRLC_RATE", typeof(decimal));
            Data.Columns.Add("TRFC_RATE", typeof(decimal));
            Data.Columns.Add("TRPL_RATE", typeof(decimal));
            Data.Columns.Add("TAXABLE", typeof(string)).MaxLength = 1;
            Data.Columns.Add("TR_ORD_TOT", typeof(decimal));
            Data.Columns.Add("TR_ORD_TAX", typeof(decimal));
            Data.Columns.Add("TR_ORD_CREDITS", typeof(decimal));
            Data.Columns.Add("TR_ORD_DUE", typeof(decimal));
            Data.Columns.Add("TR_ACT_TOT", typeof(decimal));
            Data.Columns.Add("TR_ACT_TAX", typeof(decimal));
            Data.Columns.Add("TR_ACT_CREDITS", typeof(decimal));
            Data.Columns.Add("TR_ACT_DUE", typeof(decimal));
            Data.Columns.Add("TR_ACT_PAYMENTS", typeof(decimal));
            Data.Columns.Add("PL_ORD_TOT", typeof(decimal));
            Data.Columns.Add("PL_ORD_TAX", typeof(decimal));
            Data.Columns.Add("PL_ORD_CREDITS", typeof(decimal));
            Data.Columns.Add("PL_ORD_DUE", typeof(decimal));
            Data.Columns.Add("PL_ACT_TOT", typeof(decimal));
            Data.Columns.Add("PL_ACT_TAX", typeof(decimal));
            Data.Columns.Add("PL_ACT_CREDITS", typeof(decimal));
            Data.Columns.Add("PL_ACT_DUE", typeof(decimal));
            Data.Columns.Add("PL_ACT_PAYMENTS", typeof(decimal));
            Data.Columns.Add("ASSIGNMENT_NAME", typeof(string)).MaxLength = 150;
            Data.Columns.Add("PAY_PLAN_ID", typeof(int));
            Data.Columns.Add("PP_SCHED_CODE", typeof(string)).MaxLength = 3;
            Data.Columns.Add("NEW_STS", typeof(string)).MaxLength = 2;
            Data.Columns.Add("REPRINT", typeof(string)).MaxLength = 1;
            Data.Columns.Add("CONFIG_CODE", typeof(string)).MaxLength = 12;
            Data.Columns.Add("NG_ORD_CONTACT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("NG_BTO_CONTACT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("NG_REQ_CONTACT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("ORD_ACCT_REP", typeof(string)).MaxLength = 8;
            Data.Columns.Add("ASGN_TOT_SIZE", typeof(decimal));
            Data.Columns.Add("ASGN_OPEN_SIDES", typeof(int));
            Data.Columns.Add("ASGN_LENGTH", typeof(decimal));
            Data.Columns.Add("ASGN_WIDTH", typeof(decimal));
            Data.Columns.Add("PROMO_CODE", typeof(string)).MaxLength = 20;
            Data.Columns.Add("TAX_DETAIL", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ALL_PRT", typeof(string)).MaxLength = 1;
            Data.Columns.Add("MULTI_ORG_ACCT", typeof(string)).MaxLength = 20;
            Data.Columns.Add("ALT_ASSIGN_NAME_1", typeof(string)).MaxLength = 150;
            Data.Columns.Add("ALT_ASSIGN_NAME_2", typeof(string)).MaxLength = 150;
            Data.Columns.Add("USER_REFERENCE", typeof(string)).MaxLength = 30;
            Data.Columns.Add("ORD_COST_TOTAL", typeof(decimal));
            Data.Columns.Add("ACT_COST_TOTAL", typeof(decimal));
            Data.Columns.Add("REF_INV_NBR", typeof(int));
            Data.Columns.Add("SHIPTO_ACCT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("SHIPTO_CONT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("ALT_ASSIGN_NAME_3", typeof(string)).MaxLength = 150;
            Data.Columns.Add("ALT_ASSIGN_NAME_4", typeof(string)).MaxLength = 150;
            Data.Columns.Add("ALT_ASSIGN_NAME_5", typeof(string)).MaxLength = 150;
            Data.Columns.Add("ASGN_TOT_DISP_SIZE", typeof(decimal));
            Data.Columns.Add("CONTRACT_SEQ", typeof(int));
            Data.Columns.Add("ORD_GLACCT", typeof(string)).MaxLength = 30;
            Data.Columns.Add("NEAR_EXHIB", typeof(string)).MaxLength = 255;
            Data.Columns.Add("AWAY_EXHIB", typeof(string)).MaxLength = 255;
            Data.Columns.Add("COMPETITORS", typeof(string)).MaxLength = 255;
            Data.Columns.Add("PREF_ASSIGN", typeof(string)).MaxLength = 255;
            Data.Columns.Add("EXHIB_POINTS", typeof(int));
            Data.Columns.Add("EXHIB_MI", typeof(DateTime));
            Data.Columns.Add("PAVILION", typeof(string)).MaxLength = 255;
            Data.Columns.Add("EXHIB_TXT_01", typeof(string)).MaxLength = 255;
            Data.Columns.Add("EXHIB_TXT_02", typeof(string)).MaxLength = 255;
            Data.Columns.Add("EXHIB_TXT_03", typeof(string)).MaxLength = 255;
            Data.Columns.Add("EXHIB_NBR_01", typeof(decimal));
            Data.Columns.Add("EXHIB_NBR_02", typeof(decimal));
            Data.Columns.Add("EXHIB_NBR_03", typeof(decimal));
            Data.Columns.Add("EXHIB_DTM_01", typeof(DateTime));
            Data.Columns.Add("EXHIB_DTM_02", typeof(DateTime));
            Data.Columns.Add("EXHIB_DTM_03", typeof(DateTime));
            Data.Columns.Add("OCCURRENCE", typeof(int));
            Data.Columns.Add("ORD_FIXED", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ORD_REV_TRANS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("COMM_ORDER", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ORD_ADDR_SEQ", typeof(int));
            Data.Columns.Add("BILLTO_ADDR_SEQ", typeof(int));
            Data.Columns.Add("REQ_ADDR_SEQ", typeof(int));
            Data.Columns.Add("SHIPTO_ADDR_SEQ", typeof(int));
            Data.Columns.Add("OCCURENCE", typeof(int));
            Data.Columns.Add("MAIN_EXHIB_ORDER", typeof(int));
            Data.Columns.Add("PRJ_ID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("ACCT_DESIG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("GEN", typeof(string)).MaxLength = 1;
            Data.Columns.Add("TAX_DATE", typeof(DateTime));
            Data.Columns.Add("AR_CONTROL", typeof(string)).MaxLength = 10;
            Data.Columns.Add("EXHIBITOR_ID", typeof(int));
            Data.Columns.Add("ENT_APP_TYPE", typeof(int));
            Data.Columns.Add("CUST_PAY_INFO", typeof(string)).MaxLength = 255;
            Data.Columns.Add("CUST_PAY_TYPE", typeof(int));
            Data.Columns.Add("DIVISION", typeof(string)).MaxLength = 6;
            Data.Columns.Add("EXHIB_ORD_NBR", typeof(int));
            Data.Columns.Add("BOOTH_ORDER", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ORD_CAT_SEQ", typeof(int));
        }

        public override void Clean()
        {
            TimeSpan fxStart = timer.Elapsed;

            foreach (DataRow row in Data.Rows)
            {
                if (row["ORG_CODE"].GetType().ToString() == "System.DBNull")
                    row["ORG_CODE"] = string.Empty;

                if (row["ORD_NBR"].GetType().ToString() == "System.DBNull")
                    row["ORD_NBR"] = string.Empty;
            }

            TimeSpan fxEnd = timer.Elapsed;

            CleanTime = Math.Round(fxEnd.TotalMilliseconds - fxStart.TotalMilliseconds,3);
        }

        public override SqlCommand StoredProcedure(SqlConnection connection)
        {
            return new SqlCommand("CSP_SYNC_ACCT_ORDER", connection);
        }
    }
}
using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;

namespace FtpSync
{
    public class EVENT_MASTER : Sync
    {
        public EVENT_MASTER(SyncConfigurationElement element, string CS) : base(element, CS)
        {
            Initialize();
        }

        public EVENT_MASTER(Arguments arguments) : base(arguments)
        {
            Initialize();
        }

        public override sealed void Initialize()
        {
            Data.Columns.Add("ORG_CODE", typeof(string)).MaxLength = 2;
            Data.Columns.Add("EVT_ID", typeof(int));
            Data.Columns.Add("EVT_SEARCH", typeof(string)).MaxLength = 12;
            Data.Columns.Add("EVT_DESC", typeof(string)).MaxLength = 150;
            Data.Columns.Add("EVT_DESIGNATION", typeof(string)).MaxLength = 1;
            Data.Columns.Add("CONFIDENTIAL", typeof(string)).MaxLength = 1;
            Data.Columns.Add("START_DATE", typeof(int));
            Data.Columns.Add("END_DATE", typeof(int));
            Data.Columns.Add("MI_DATE", typeof(int));
            Data.Columns.Add("MO_DATE", typeof(int));
            Data.Columns.Add("DECISION_DATE", typeof(int));
            Data.Columns.Add("BOX_OFFICE", typeof(string)).MaxLength = 1;
            Data.Columns.Add("INSUR_REQ", typeof(string)).MaxLength = 1;
            Data.Columns.Add("INSUR_REC", typeof(string)).MaxLength = 1;
            Data.Columns.Add("CONTRACT_STS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("CONTRACT_ID", typeof(string)).MaxLength = 12;
            Data.Columns.Add("CM_FILE_NBR", typeof(int));
            Data.Columns.Add("MTG_NBR", typeof(int));
            Data.Columns.Add("MTG_START_DATE", typeof(int));
            Data.Columns.Add("GROUP_NAME", typeof(string)).MaxLength = 36;
            Data.Columns.Add("EST_REVENUE", typeof(int));
            Data.Columns.Add("PLN_REVENUE", typeof(int));
            Data.Columns.Add("ACT_REVENUE", typeof(int));
            Data.Columns.Add("EST_ATTEND", typeof(int));
            Data.Columns.Add("PLN_ATTEND", typeof(int));
            Data.Columns.Add("ACT_ATTEND", typeof(int));
            Data.Columns.Add("EST_COST", typeof(int));
            Data.Columns.Add("PLN_COST", typeof(int));
            Data.Columns.Add("ACT_COST", typeof(int));
            Data.Columns.Add("BOOKED_BY", typeof(string)).MaxLength = 25;
            Data.Columns.Add("BOOKING_TYPE", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PUBLIC_YN", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ON_SITE_OFFICE", typeof(string)).MaxLength = 6;
            Data.Columns.Add("ON_SITE_PHONE", typeof(string)).MaxLength = 25;
            Data.Columns.Add("DURATION_CODE", typeof(string)).MaxLength = 6;
            Data.Columns.Add("PRICE_LIST", typeof(string)).MaxLength = 10;
            Data.Columns.Add("BKG_BOOK_DATE", typeof(int));
            Data.Columns.Add("BKG_CHG_DATE", typeof(int));
            Data.Columns.Add("BKG_CNCL_DATE", typeof(int));
            Data.Columns.Add("EVT_CATEGORY", typeof(string)).MaxLength = 5;
            Data.Columns.Add("EVT_CLASS", typeof(string)).MaxLength = 5;
            Data.Columns.Add("EVT_TYPE", typeof(string)).MaxLength = 5;
            Data.Columns.Add("EVT_RANK", typeof(string)).MaxLength = 1;
            Data.Columns.Add("EVT_STATUS", typeof(string)).MaxLength = 2;
            Data.Columns.Add("SLSPER", typeof(string)).MaxLength = 8;
            Data.Columns.Add("COORD_1", typeof(string)).MaxLength = 8;
            Data.Columns.Add("COORD_2", typeof(string)).MaxLength = 8;
            Data.Columns.Add("CUST_NBR", typeof(string)).MaxLength = 8;
            Data.Columns.Add("CUST_SUB_NBR", typeof(string)).MaxLength = 2;
            Data.Columns.Add("CUST_PO", typeof(string)).MaxLength = 12;
            Data.Columns.Add("CUST_CNTCT_NAME", typeof(string)).MaxLength = 30;
            Data.Columns.Add("CUST_PHONE", typeof(string)).MaxLength = 12;
            Data.Columns.Add("UPD_DATE", typeof(int));
            Data.Columns.Add("UPD_TIME", typeof(int));
            Data.Columns.Add("UPD_USER_ID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("LAST_BILLED_DATE", typeof(int));
            Data.Columns.Add("SLSPER_ORG", typeof(string)).MaxLength = 2;
            Data.Columns.Add("CUST_ORG", typeof(string)).MaxLength = 2;
            Data.Columns.Add("COORD1_ORG", typeof(string)).MaxLength = 2;
            Data.Columns.Add("ECON_IMPACT_AMT", typeof(int));
            Data.Columns.Add("RETAIN_PCT", typeof(int));
            Data.Columns.Add("CONFLICT_STS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("EVT_CODE_1", typeof(string)).MaxLength = 4;
            Data.Columns.Add("EVT_CODE_2", typeof(string)).MaxLength = 4;
            Data.Columns.Add("DESC_1", typeof(string)).MaxLength = 25;
            Data.Columns.Add("EVT_USR_CODE_1", typeof(string)).MaxLength = 6;
            Data.Columns.Add("EVT_USR_ID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("SEQ_NBR", typeof(int));
            Data.Columns.Add("EVT_GL", typeof(string)).MaxLength = 9;
            Data.Columns.Add("ADV_OFFSET", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ADV_DAYS", typeof(int));
            Data.Columns.Add("BADGE_FMT", typeof(string)).MaxLength = 2;
            Data.Columns.Add("MAJ_GROUP", typeof(string)).MaxLength = 4;
            Data.Columns.Add("MIN_GROUP", typeof(string)).MaxLength = 6;
            Data.Columns.Add("ANCHOR_VENUE", typeof(string)).MaxLength = 6;
            Data.Columns.Add("EVT_GLACCT", typeof(string)).MaxLength = 30;
            Data.Columns.Add("BDG_VOIDS", typeof(int));
            Data.Columns.Add("CANCEL_STAMP", typeof(DateTime));
            Data.Columns.Add("CANCEL_USER_ID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("CANCEL_REASON", typeof(string)).MaxLength = 2;
            Data.Columns.Add("ORD_ATT_INDIC", typeof(string)).MaxLength = 5;
            Data.Columns.Add("ACT_ATT_INDIC", typeof(string)).MaxLength = 5;
            Data.Columns.Add("RVS_REVENUE", typeof(int));
            Data.Columns.Add("RVS_COST", typeof(int));
            Data.Columns.Add("RVS_ATTEND", typeof(int));
            Data.Columns.Add("RVS_OTHER", typeof(decimal));
            Data.Columns.Add("FOR_ATT_INDIC", typeof(string)).MaxLength = 5;
            Data.Columns.Add("RVS_ATT_INDIC", typeof(string)).MaxLength = 5;
            Data.Columns.Add("CAD_NAME", typeof(string)).MaxLength = 20;
            Data.Columns.Add("SENSITIVITY", typeof(string)).MaxLength = 1;
            Data.Columns.Add("CANCEL_APPL", typeof(string)).MaxLength = 2;
            Data.Columns.Add("ALT_EVT_DESC", typeof(string)).MaxLength = 150;
            Data.Columns.Add("ALT_LEGAL_NAME", typeof(string)).MaxLength = 255;
            Data.Columns.Add("BKG_ENT_STAMP", typeof(DateTime));
            Data.Columns.Add("BKG_ENT_USER", typeof(string)).MaxLength = 10;
            Data.Columns.Add("BKG_CHG_STAMP", typeof(DateTime));
            Data.Columns.Add("BKG_CHG_USER", typeof(string)).MaxLength = 10;
            Data.Columns.Add("EVT_COORD3", typeof(string)).MaxLength = 8;
            Data.Columns.Add("EVT_COORD4", typeof(string)).MaxLength = 8;
            Data.Columns.Add("WEB_ADDRESS", typeof(string)).MaxLength = 255;
            Data.Columns.Add("MASTER_EVT", typeof(int));
            Data.Columns.Add("PREV_EVT", typeof(int));
            Data.Columns.Add("ALT_EVT_DESC2", typeof(string)).MaxLength = 150;
            Data.Columns.Add("ALT_LEGAL_NAME2", typeof(string)).MaxLength = 255;
            Data.Columns.Add("NG_EVT_CONTACT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("NG_BILLTO_CONTACT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("GLAA_CODE_01", typeof(string)).MaxLength = 15;
            Data.Columns.Add("GLAA_CODE_02", typeof(string)).MaxLength = 15;
            Data.Columns.Add("GLAA_CODE_03", typeof(string)).MaxLength = 15;
            Data.Columns.Add("GLAA_CODE_04", typeof(string)).MaxLength = 15;
            Data.Columns.Add("GLAA_CODE_05", typeof(string)).MaxLength = 15;
            Data.Columns.Add("GLAA_CODE_06", typeof(string)).MaxLength = 15;
            Data.Columns.Add("GLAA_CODE_07", typeof(string)).MaxLength = 15;
            Data.Columns.Add("GLAA_CODE_08", typeof(string)).MaxLength = 15;
            Data.Columns.Add("GLAA_CODE_09", typeof(string)).MaxLength = 15;
            Data.Columns.Add("USE_GL_SUBS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("GLAA_OPER", typeof(string)).MaxLength = 2;
            Data.Columns.Add("UPD_STAMP", typeof(DateTime));
            Data.Columns.Add("ENT_STAMP", typeof(DateTime));
            Data.Columns.Add("RVS_ATT_SYNC", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ORD_ATT_SYNC", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ACT_ATT_SYNC", typeof(string)).MaxLength = 1;
            Data.Columns.Add("HSG_STDATE", typeof(DateTime));
            Data.Columns.Add("HSG_ENDATE", typeof(DateTime));
            Data.Columns.Add("HSG_CUTOFF", typeof(DateTime));
            Data.Columns.Add("HSG_OFFICE", typeof(string)).MaxLength = 8;
            Data.Columns.Add("HSG_HQ_HOTEL", typeof(string)).MaxLength = 8;
            Data.Columns.Add("HSG_FLAG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("MI_OFFSET_HRS", typeof(decimal));
            Data.Columns.Add("ST_OFFSET_HRS", typeof(decimal));
            Data.Columns.Add("EN_OFFSET_HRS", typeof(decimal));
            Data.Columns.Add("MO_OFFSET_HRS", typeof(decimal));
            Data.Columns.Add("BADGE_XML", typeof(string)).MaxLength = 4000;
            Data.Columns.Add("REG_PAY_SCHED", typeof(string)).MaxLength = 3;
            Data.Columns.Add("REG_PRLIST", typeof(string)).MaxLength = 10;
            Data.Columns.Add("MULTI_ORG_ACCT", typeof(string)).MaxLength = 20;
            Data.Columns.Add("ALT_EVT", typeof(int));
            Data.Columns.Add("REG_ADV_CUTOFF", typeof(DateTime));
            Data.Columns.Add("REG_STD_CUTOFF", typeof(DateTime));
            Data.Columns.Add("REGST_ISS_CLS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("REGST_ISS_TYP", typeof(string)).MaxLength = 2;
            Data.Columns.Add("REG_ADV_OFFSET", typeof(string)).MaxLength = 1;
            Data.Columns.Add("REG_ADV_DAYS", typeof(int));
            Data.Columns.Add("REG_STD_OFFSET", typeof(string)).MaxLength = 1;
            Data.Columns.Add("REG_STD_DAYS", typeof(int));
            Data.Columns.Add("EVT_IN_DATE", typeof(DateTime));
            Data.Columns.Add("EVT_IN_TIME", typeof(DateTime));
            Data.Columns.Add("EVT_START_DATE", typeof(DateTime));
            Data.Columns.Add("EVT_START_TIME", typeof(DateTime));
            Data.Columns.Add("EVT_END_DATE", typeof(DateTime));
            Data.Columns.Add("EVT_END_TIME", typeof(DateTime));
            Data.Columns.Add("EVT_OUT_DATE", typeof(DateTime));
            Data.Columns.Add("EVT_OUT_TIME", typeof(DateTime));
            Data.Columns.Add("RELEASE_DATE", typeof(DateTime));
            Data.Columns.Add("ADV_CUTOFF_DATE", typeof(DateTime));
            Data.Columns.Add("EVT_ABBREV_NAME", typeof(string)).MaxLength = 20;
            Data.Columns.Add("EVT_LEGAL_NAME", typeof(string)).MaxLength = 255;
            Data.Columns.Add("EVT_INDICATOR", typeof(string)).MaxLength = 2;
            Data.Columns.Add("SO_ISSUE_CLASS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("SO_ISSUE_TYPE", typeof(string)).MaxLength = 2;
            Data.Columns.Add("RG_ISSUE_CLASS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("RG_ISSUE_TYPE", typeof(string)).MaxLength = 2;
            Data.Columns.Add("EVT_NOTE_1", typeof(string)).MaxLength = 150;
            Data.Columns.Add("EVT_NOTE_2", typeof(string)).MaxLength = 150;
            Data.Columns.Add("PROF_MI_SIGN", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PROF_ST_SIGN", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PROF_EN_SIGN", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PROF_MO_SIGN", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PROF_TIME_OFFSET", typeof(string)).MaxLength = 1;
            Data.Columns.Add("EVT_RELEASE_INDIC", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PROF_MI_DAYS", typeof(decimal));
            Data.Columns.Add("PROF_ST_DAYS", typeof(decimal));
            Data.Columns.Add("PROF_EN_DAYS", typeof(decimal));
            Data.Columns.Add("PROF_MO_DAYS", typeof(decimal));
            Data.Columns.Add("BILLTO_ACCT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("EVENT_DAYS", typeof(decimal));
            Data.Columns.Add("EVT_LOGO", typeof(SqlBinary));
            Data.Columns.Add("MAX_TOPIC_LVL", typeof(int));
            Data.Columns.Add("EST_OTHER", typeof(decimal));
            Data.Columns.Add("PLN_OTHER", typeof(decimal));
            Data.Columns.Add("ACT_OTHER", typeof(decimal));
            Data.Columns.Add("ALT_EVT_DESC3", typeof(string)).MaxLength = 150;
            Data.Columns.Add("ALT_EVT_DESC4", typeof(string)).MaxLength = 150;
            Data.Columns.Add("ALT_EVT_DESC5", typeof(string)).MaxLength = 150;
            Data.Columns.Add("ALT_LEGAL_NAME3", typeof(string)).MaxLength = 255;
            Data.Columns.Add("ALT_LEGAL_NAME4", typeof(string)).MaxLength = 255;
            Data.Columns.Add("ALT_LEGAL_NAME5", typeof(string)).MaxLength = 255;
            Data.Columns.Add("STD_CUTOFF_DATE", typeof(DateTime));
            Data.Columns.Add("STD_OFFSET", typeof(string)).MaxLength = 1;
            Data.Columns.Add("STD_DAYS", typeof(int));
            Data.Columns.Add("DATE_FMT", typeof(string)).MaxLength = 3;
            Data.Columns.Add("TIME_FMT", typeof(string)).MaxLength = 3;
            Data.Columns.Add("RES_FMT", typeof(string)).MaxLength = 3;
            Data.Columns.Add("DECISION_DATE_ISO", typeof(DateTime));
            Data.Columns.Add("CONFL_ORD_STS", typeof(string)).MaxLength = 2;
            Data.Columns.Add("EXH_PROD_SYNC", typeof(string)).MaxLength = 1;
            Data.Columns.Add("LOST_TO_VAL", typeof(string)).MaxLength = 20;
            Data.Columns.Add("UNSCHED_FLAG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("DEF_PAY_SCHED", typeof(string)).MaxLength = 3;
            Data.Columns.Add("FIRM_DATE", typeof(DateTime));
            Data.Columns.Add("ASSET_CODE", typeof(string)).MaxLength = 12;
            Data.Columns.Add("REQ_ACCT_CODE", typeof(string)).MaxLength = 8;
            Data.Columns.Add("REQ_CNTCT_CODE", typeof(string)).MaxLength = 8;
            Data.Columns.Add("FN_ISSUE_CLASS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("FN_ISSUE_TYPE", typeof(string)).MaxLength = 2;
            Data.Columns.Add("REG_PICKUP_TYPE", typeof(string)).MaxLength = 3;
            Data.Columns.Add("REG_PU_STDATE", typeof(DateTime));
            Data.Columns.Add("REG_PU_ENDATE", typeof(DateTime));
            Data.Columns.Add("ALLOW_ROOMMATE", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ENABLE_TRAVEL", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ORD_ISS_CLASS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ORD_ISS_TYPE", typeof(string)).MaxLength = 2;
            Data.Columns.Add("PURGE_IND", typeof(string)).MaxLength = 3;
            Data.Columns.Add("PURGE_VALIDATE", typeof(DateTime));
            Data.Columns.Add("PURGE_STAMP", typeof(DateTime));
            Data.Columns.Add("PURGE_USER_ID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("AVG_DAILY_RATE", typeof(int));
            Data.Columns.Add("SPACE_GUEST_RATIO", typeof(int));
            Data.Columns.Add("PEAK_NBR_RMS", typeof(int));
            Data.Columns.Add("BOOKED_AREA", typeof(int));
            Data.Columns.Add("TRAVEL_TYPE", typeof(string)).MaxLength = 6;
            Data.Columns.Add("VAL_ASSIGN_AREA", typeof(string)).MaxLength = 1;
            Data.Columns.Add("VAL_ASSIGN_DIM", typeof(string)).MaxLength = 1;
            Data.Columns.Add("VAL_ASSIGN_DIM_INT", typeof(string)).MaxLength = 1;
            Data.Columns.Add("VAL_ASSIGN_OS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("VAL_ASSIGN_FR", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PURGE_VAL_USER_ID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("PRJ_ID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("ACCT_DESIG", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PROMPT_PROMO_CODE", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ECON_IMPACT", typeof(decimal));
            Data.Columns.Add("PORTAL_ID", typeof(int));
            Data.Columns.Add("TAX_SCHEME", typeof(string)).MaxLength = 12;
            Data.Columns.Add("UNIQUE_ID", typeof(int));
            Data.Columns.Add("SOCIAL_NETWORK_1", typeof(string)).MaxLength = 255;
            Data.Columns.Add("SOCIAL_NETWORK_2", typeof(string)).MaxLength = 255;
            Data.Columns.Add("SOCIAL_NETWORK_3", typeof(string)).MaxLength = 255;
            Data.Columns.Add("OUTLOOK_MEETING", typeof(string)).MaxLength = 1;
            Data.Columns.Add("CC_AUTH_CFG", typeof(int));
            Data.Columns.Add("EVAL_ISS_TYPE", typeof(string)).MaxLength = 2;
            Data.Columns.Add("EXH_ISSUE_CLASS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("EXH_ISSUE_TYPE", typeof(string)).MaxLength = 2;
            Data.Columns.Add("EXHIB_REG_RULE_TYPE", typeof(int));
            Data.Columns.Add("LINKED_FUNCS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ENABLE_REG_APPR", typeof(string)).MaxLength = 1;
        }

        public override void Clean()
        {
            TimeSpan fxStart = timer.Elapsed;

            foreach (DataRow row in Data.Rows)
            {
                if (row["ORG_CODE"].GetType().ToString() == "System.DBNull")
                    row["ORG_CODE"] = string.Empty;

                if (row["EVT_DESIGNATION"].GetType().ToString() == "System.DBNull")
                    row["EVT_DESIGNATION"] = string.Empty;

                if (row["CONFIDENTIAL"].GetType().ToString() == "System.DBNull")
                    row["CONFIDENTIAL"] = string.Empty;

                if (row["BOX_OFFICE"].GetType().ToString() == "System.DBNull")
                    row["BOX_OFFICE"] = string.Empty;

                if (row["INSUR_REQ"].GetType().ToString() == "System.DBNull")
                    row["INSUR_REQ"] = string.Empty;

                if (row["INSUR_REC"].GetType().ToString() == "System.DBNull")
                    row["INSUR_REC"] = string.Empty;

                if (row["CONTRACT_STS"].GetType().ToString() == "System.DBNull")
                    row["CONTRACT_STS"] = string.Empty;

                if (row["CONTRACT_ID"].GetType().ToString() == "System.DBNull")
                    row["CONTRACT_ID"] = string.Empty;

                if (row["GROUP_NAME"].GetType().ToString() == "System.DBNull")
                    row["GROUP_NAME"] = string.Empty;

                if (row["BOOKED_BY"].GetType().ToString() == "System.DBNull")
                    row["BOOKED_BY"] = string.Empty;

                if (row["BOOKING_TYPE"].GetType().ToString() == "System.DBNull")
                    row["BOOKING_TYPE"] = string.Empty;

                if (row["PUBLIC_YN"].GetType().ToString() == "System.DBNull")
                    row["PUBLIC_YN"] = string.Empty;

                if (row["ON_SITE_OFFICE"].GetType().ToString() == "System.DBNull")
                    row["ON_SITE_OFFICE"] = string.Empty;

                if (row["DURATION_CODE"].GetType().ToString() == "System.DBNull")
                    row["DURATION_CODE"] = string.Empty;

                if (row["PRICE_LIST"].GetType().ToString() == "System.DBNull")
                    row["PRICE_LIST"] = string.Empty;

                if (row["EVT_RANK"].GetType().ToString() == "System.DBNull")
                    row["EVT_RANK"] = string.Empty;

                if (row["EVT_STATUS"].GetType().ToString() == "System.DBNull")
                    row["EVT_STATUS"] = string.Empty;

                if (row["CUST_SUB_NBR"].GetType().ToString() == "System.DBNull")
                    row["CUST_SUB_NBR"] = string.Empty;

                if (row["CUST_PO"].GetType().ToString() == "System.DBNull")
                    row["CUST_PO"] = string.Empty;

                if (row["CUST_CNTCT_NAME"].GetType().ToString() == "System.DBNull")
                    row["CUST_CNTCT_NAME"] = string.Empty;

                if (row["CUST_PHONE"].GetType().ToString() == "System.DBNull")
                    row["CUST_PHONE"] = string.Empty;

                if (row["UPD_USER_ID"].GetType().ToString() == "System.DBNull")
                    row["UPD_USER_ID"] = string.Empty;

                if (row["SLSPER_ORG"].GetType().ToString() == "System.DBNull")
                    row["SLSPER_ORG"] = string.Empty;

                if (row["CUST_ORG"].GetType().ToString() == "System.DBNull")
                    row["CUST_ORG"] = string.Empty;

                if (row["COORD1_ORG"].GetType().ToString() == "System.DBNull")
                    row["COORD1_ORG"] = string.Empty;

                if (row["CONFLICT_STS"].GetType().ToString() == "System.DBNull")
                    row["CONFLICT_STS"] = string.Empty;

                if (row["EVT_CODE_1"].GetType().ToString() == "System.DBNull")
                    row["EVT_CODE_1"] = string.Empty;

                if (row["EVT_CODE_2"].GetType().ToString() == "System.DBNull")
                    row["EVT_CODE_2"] = string.Empty;

                if (row["DESC_1"].GetType().ToString() == "System.DBNull")
                    row["DESC_1"] = string.Empty;

                if (row["EVT_USR_CODE_1"].GetType().ToString() == "System.DBNull")
                    row["EVT_USR_CODE_1"] = string.Empty;

                if (row["EVT_USR_ID"].GetType().ToString() == "System.DBNull")
                    row["EVT_USR_ID"] = string.Empty;
            }

            TimeSpan fxEnd = timer.Elapsed;

            CleanTime = Math.Round(fxEnd.TotalMilliseconds - fxStart.TotalMilliseconds, 3);
        }

        public override SqlCommand StoredProcedure(SqlConnection connection)
        {
            return new SqlCommand("CSP_SYNC_EVENT_MASTER", connection);
        }
    }
}
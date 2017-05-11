using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Text;

namespace FtpSync
{
    public class EVT_REGIS : Sync
    {
        public EVT_REGIS(SyncConfigurationElement element, string CS) : base(element, CS)
        {
            Initialize();
        }

        public EVT_REGIS(Arguments arguments) : base(arguments)
        {
            Initialize();
        }

        public override sealed void Initialize()
        {
            Data.Columns.Add("ORG_CODE", typeof(string)).MaxLength = 2;
            Data.Columns.Add("REG_SEQ", typeof(int));
            Data.Columns.Add("EVT_ID", typeof(int));
            Data.Columns.Add("FUNC_ID", typeof(int));
            Data.Columns.Add("REG_CONTACT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("STATUS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PRT_STATUS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("CANCEL_DATE_ISO", typeof(DateTime));
            Data.Columns.Add("CANCEL_TIME", typeof(DateTime));
            Data.Columns.Add("CANCEL_USER_ID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("CANCEL_BY", typeof(string)).MaxLength = 30;
            Data.Columns.Add("CANCEL_REASON", typeof(string)).MaxLength = 2;
            Data.Columns.Add("ORD_LINE", typeof(int));
            Data.Columns.Add("STATUS_2", typeof(string)).MaxLength = 1;
            Data.Columns.Add("REG_ACCT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("STATUS_AT_PRINT", typeof(string)).MaxLength = 1;
            Data.Columns.Add("RM_NBR", typeof(string)).MaxLength = 10;
            Data.Columns.Add("ARR_DATE", typeof(DateTime));
            Data.Columns.Add("ARR_TIME", typeof(DateTime));
            Data.Columns.Add("ARR_VIA", typeof(string)).MaxLength = 30;
            Data.Columns.Add("ARR_LOC", typeof(string)).MaxLength = 30;
            Data.Columns.Add("ARR_PICKUP_TIME", typeof(DateTime));
            Data.Columns.Add("ARR_PICKUP_DATE", typeof(DateTime));
            Data.Columns.Add("ARR_PICKUP_LOC", typeof(string)).MaxLength = 30;
            Data.Columns.Add("ARR_TRANSPORTATION", typeof(string)).MaxLength = 30;
            Data.Columns.Add("DEP_DATE", typeof(DateTime));
            Data.Columns.Add("DEP_TIME", typeof(DateTime));
            Data.Columns.Add("DEP_VIA", typeof(string)).MaxLength = 30;
            Data.Columns.Add("DEP_LOCATION", typeof(string)).MaxLength = 30;
            Data.Columns.Add("DEP_PICKUP_DATE", typeof(DateTime));
            Data.Columns.Add("DEP_PICKUP_TIME", typeof(DateTime));
            Data.Columns.Add("DEP_PICKUP_LOC", typeof(string)).MaxLength = 30;
            Data.Columns.Add("DEP_TRANSPORTATION", typeof(string)).MaxLength = 30;
            Data.Columns.Add("LOCAL_TRANSPORTATION", typeof(string)).MaxLength = 30;
            Data.Columns.Add("FILL_092", typeof(decimal));
            Data.Columns.Add("FILL_1X", typeof(string)).MaxLength = 1;
            Data.Columns.Add("FILL_1X2", typeof(string)).MaxLength = 1;
            Data.Columns.Add("FILL_1X3", typeof(string)).MaxLength = 1;
            Data.Columns.Add("FILL_20X", typeof(string)).MaxLength = 20;
            Data.Columns.Add("FILL_20X2", typeof(string)).MaxLength = 20;
            Data.Columns.Add("FILL_20X3", typeof(string)).MaxLength = 20;
            Data.Columns.Add("FILL_6X", typeof(string)).MaxLength = 6;
            Data.Columns.Add("FILL_6X2", typeof(string)).MaxLength = 6;
            Data.Columns.Add("FILL_6X4", typeof(string)).MaxLength = 6;
            Data.Columns.Add("FILL_6X5", typeof(string)).MaxLength = 6;
            Data.Columns.Add("FILL_10X", typeof(string)).MaxLength = 10;
            Data.Columns.Add("FILL_072", typeof(decimal));
            Data.Columns.Add("FILL_30X", typeof(string)).MaxLength = 30;
            Data.Columns.Add("USER_PROFILE", typeof(string)).MaxLength = 10;
            Data.Columns.Add("ENT_DATE_ISO", typeof(DateTime));
            Data.Columns.Add("ENT_TIME_ISO", typeof(DateTime));
            Data.Columns.Add("ENT_USER_ID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("UPD_DATE_ISO", typeof(DateTime));
            Data.Columns.Add("UPD_TIME_ISO", typeof(DateTime));
            Data.Columns.Add("UPD_USER_ID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("ACCUM_EVT_ID", typeof(int));
            Data.Columns.Add("ACCUM_FUNC_ID", typeof(int));
            Data.Columns.Add("ACCUM_PHASE", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ACCUM_RES_SEQ", typeof(int));
            Data.Columns.Add("DEL_MARK", typeof(string)).MaxLength = 1;
            Data.Columns.Add("USER_8X1", typeof(string)).MaxLength = 8;
            Data.Columns.Add("USER_8X2", typeof(string)).MaxLength = 8;
            Data.Columns.Add("USER_8X3", typeof(string)).MaxLength = 10;
            Data.Columns.Add("USER_10X", typeof(string)).MaxLength = 10;
            Data.Columns.Add("ORD_NBR", typeof(int));
            Data.Columns.Add("ORD_TYPE", typeof(string)).MaxLength = 2;
            Data.Columns.Add("ORD_ACCT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("PRI_ACCT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("SEC_ACCT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("PRT_CONF", typeof(string)).MaxLength = 1;
            Data.Columns.Add("CO_NAME", typeof(string)).MaxLength = 40;
            Data.Columns.Add("CHKIN_STAMP", typeof(DateTime));
            Data.Columns.Add("CHKIN_USER", typeof(string)).MaxLength = 10;
            Data.Columns.Add("REG_TYPE", typeof(string)).MaxLength = 12;
            Data.Columns.Add("AMT_01", typeof(decimal));
            Data.Columns.Add("AMT_02", typeof(decimal));
            Data.Columns.Add("AMT_03", typeof(decimal));
            Data.Columns.Add("AMT_04", typeof(decimal));
            Data.Columns.Add("AMT_05", typeof(decimal));
            Data.Columns.Add("AMT_06", typeof(decimal));
            Data.Columns.Add("AMT_07", typeof(decimal));
            Data.Columns.Add("AMT_08", typeof(decimal));
            Data.Columns.Add("AMT_09", typeof(decimal));
            Data.Columns.Add("AMT_10", typeof(decimal));
            Data.Columns.Add("AMT_11", typeof(decimal));
            Data.Columns.Add("AMT_12", typeof(decimal));
            Data.Columns.Add("AMT_13", typeof(decimal));
            Data.Columns.Add("AMT_14", typeof(decimal));
            Data.Columns.Add("AMT_15", typeof(decimal));
            Data.Columns.Add("AMT_16", typeof(decimal));
            Data.Columns.Add("AMT_17", typeof(decimal));
            Data.Columns.Add("AMT_18", typeof(decimal));
            Data.Columns.Add("AMT_19", typeof(decimal));
            Data.Columns.Add("AMT_20", typeof(decimal));
            Data.Columns.Add("AMT_21", typeof(decimal));
            Data.Columns.Add("AMT_22", typeof(decimal));
            Data.Columns.Add("AMT_23", typeof(decimal));
            Data.Columns.Add("AMT_24", typeof(decimal));
            Data.Columns.Add("AMT_25", typeof(decimal));
            Data.Columns.Add("AMT_26", typeof(decimal));
            Data.Columns.Add("AMT_27", typeof(decimal));
            Data.Columns.Add("AMT_28", typeof(decimal));
            Data.Columns.Add("AMT_29", typeof(decimal));
            Data.Columns.Add("AMT_30", typeof(decimal));
            Data.Columns.Add("DTS_01", typeof(DateTime));
            Data.Columns.Add("DTS_02", typeof(DateTime));
            Data.Columns.Add("DTS_03", typeof(DateTime));
            Data.Columns.Add("DTS_04", typeof(DateTime));
            Data.Columns.Add("DTS_05", typeof(DateTime));
            Data.Columns.Add("DTS_06", typeof(DateTime));
            Data.Columns.Add("DTS_07", typeof(DateTime));
            Data.Columns.Add("DTS_08", typeof(DateTime));
            Data.Columns.Add("DTS_09", typeof(DateTime));
            Data.Columns.Add("DTS_10", typeof(DateTime));
            Data.Columns.Add("DTS_11", typeof(DateTime));
            Data.Columns.Add("DTS_12", typeof(DateTime));
            Data.Columns.Add("DTS_13", typeof(DateTime));
            Data.Columns.Add("DTS_14", typeof(DateTime));
            Data.Columns.Add("DTS_15", typeof(DateTime));
            Data.Columns.Add("DTS_16", typeof(DateTime));
            Data.Columns.Add("DTS_17", typeof(DateTime));
            Data.Columns.Add("DTS_18", typeof(DateTime));
            Data.Columns.Add("DTS_19", typeof(DateTime));
            Data.Columns.Add("DTS_20", typeof(DateTime));
            Data.Columns.Add("TXT_01", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_02", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_03", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_04", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_05", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_06", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_07", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_08", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_09", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_10", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_11", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_12", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_13", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_14", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_15", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_16", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_17", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_18", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_19", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_20", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_21", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_22", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_23", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_24", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_25", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_26", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_27", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_28", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_29", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_30", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_31", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_32", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_33", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_34", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_35", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_36", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_37", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_38", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_39", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_40", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_41", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_42", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_43", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_44", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_45", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_46", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_47", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_48", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_49", typeof(string)).MaxLength = 255;
            Data.Columns.Add("TXT_50", typeof(string)).MaxLength = 255;

            // This column is actually a varbinary(max) in the database
            // It is set to a string value so that if there is any data in the
            // export it will be properly imported

            Data.Columns.Add("2D_BC_IMAGE", typeof(string)).MaxLength = 8000;

            // In the Clean function this column is dropped from the data table
            // and it is not included in the UBSYNC database because it is not needed

            Data.Columns.Add("ISSUE_CLASS", typeof(string)).MaxLength = 1;
            Data.Columns.Add("ISSUE_TYPE", typeof(string)).MaxLength = 2;
            Data.Columns.Add("MSTR_REG_ACCT_CODE", typeof(string)).MaxLength = 8;
            Data.Columns.Add("PU_NEEDED", typeof(string)).MaxLength = 1;
            Data.Columns.Add("PU_DATE", typeof(DateTime));
            Data.Columns.Add("PU_TIME", typeof(DateTime));
            Data.Columns.Add("PU_LOC_FROM", typeof(string)).MaxLength = 100;
            Data.Columns.Add("PU_LOC_TO", typeof(string)).MaxLength = 100;
            Data.Columns.Add("PU_REFERENCE", typeof(string)).MaxLength = 255;
            Data.Columns.Add("DO_NEEDED", typeof(string)).MaxLength = 1;
            Data.Columns.Add("DO_DATE", typeof(DateTime));
            Data.Columns.Add("DO_TIME", typeof(DateTime));
            Data.Columns.Add("DO_LOC_FROM", typeof(string)).MaxLength = 100;
            Data.Columns.Add("DO_LOC_TO", typeof(string)).MaxLength = 100;
            Data.Columns.Add("DO_REFERENCE", typeof(string)).MaxLength = 255;
            Data.Columns.Add("ROOM_SHARING", typeof(string)).MaxLength = 2;
            Data.Columns.Add("PREF_ROOMMATE", typeof(string)).MaxLength = 100;
            Data.Columns.Add("ROOMMATE_ACCT", typeof(string)).MaxLength = 8;
            Data.Columns.Add("AR_MODE", typeof(string)).MaxLength = 100;
            Data.Columns.Add("AR_DATE", typeof(DateTime));
            Data.Columns.Add("AR_TIME", typeof(DateTime));
            Data.Columns.Add("AR_LOC_FROM", typeof(string)).MaxLength = 100;
            Data.Columns.Add("AR_LOC_TO", typeof(string)).MaxLength = 100;
            Data.Columns.Add("AR_REFERENCE", typeof(string)).MaxLength = 255;
            Data.Columns.Add("AR_TRANS_NEED", typeof(string)).MaxLength = 1;
            Data.Columns.Add("AR_TRANS_MODE", typeof(string)).MaxLength = 100;
            Data.Columns.Add("AR_STATUS", typeof(string)).MaxLength = 2;
            Data.Columns.Add("DP_MODE", typeof(string)).MaxLength = 100;
            Data.Columns.Add("DP_DATE", typeof(DateTime));
            Data.Columns.Add("DP_TIME", typeof(DateTime));
            Data.Columns.Add("DP_LOC_FROM", typeof(string)).MaxLength = 100;
            Data.Columns.Add("DP_LOC_TO", typeof(string)).MaxLength = 100;
            Data.Columns.Add("DP_REFERENCE", typeof(string)).MaxLength = 255;
            Data.Columns.Add("DP_TRANS_NEED", typeof(string)).MaxLength = 1;
            Data.Columns.Add("DP_TRANS_MODE", typeof(string)).MaxLength = 100;
            Data.Columns.Add("DP_STATUS", typeof(string)).MaxLength = 2;
            Data.Columns.Add("BLOCK_CODE", typeof(string)).MaxLength = 6;
            Data.Columns.Add("EVT_REG_SEQ", typeof(int));
            Data.Columns.Add("APPR_LEVEL", typeof(int));
            Data.Columns.Add("APPR_ACTION", typeof(string)).MaxLength = 1;
            Data.Columns.Add("APPR_USER_ID", typeof(string)).MaxLength = 10;
            Data.Columns.Add("APPR_STAMP", typeof(DateTime));
        }

        public override void Clean()
        {
            TimeSpan fxStart = timer.Elapsed;

            // This column is dropped because we are not using any images

            Data.Columns.Remove("2D_BC_IMAGE");

            foreach (DataRow row in Data.Rows)
            {
                if (row["ORG_CODE"].GetType().ToString() == "System.DBNull")
                    row["ORG_CODE"] = string.Empty;

                if (row["REG_SEQ"].GetType().ToString() == "System.DBNull")
                    row["REG_SEQ"] = string.Empty;
            }

            TimeSpan fxEnd = timer.Elapsed;

            CleanTime = Math.Round(fxEnd.TotalMilliseconds - fxStart.TotalMilliseconds, 3);
        }

        public override SqlCommand StoredProcedure(SqlConnection connection)
        {
            return new SqlCommand("CSP_SYNC_EVT_REGIS", connection);
        }
    }
}
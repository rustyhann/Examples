CREATE PROCEDURE CSP_SYNC_TRANSACTIONS

      @TableParam TVP_TRANSACTIONS READONLY

AS
BEGIN

	BEGIN TRY
		
		BEGIN TRANSACTION

			MERGE TRANSACTIONS WITH (TABLOCK) AS TARGET USING @TableParam AS SOURCE ON 
			
				TARGET.ORG_CODE           = SOURCE.ORG_CODE AND
				TARGET.EXT_ACCT_CODE      = SOURCE.EXT_ACCT_CODE AND 				
				TARGET.SEQ                = SOURCE.SEQ
		
			WHEN MATCHED AND (
		
				TARGET.TRANS_TYPE             != SOURCE.TRANS_TYPE OR
				TARGET.TRANS_SOURCE           != SOURCE.TRANS_SOURCE OR
				TARGET.TRANS_METHOD           != SOURCE.TRANS_METHOD OR
				TARGET.MEMO_TRANS             != SOURCE.MEMO_TRANS OR
				TARGET.AMT                    != SOURCE.AMT OR
				TARGET.OPEN_AMT               != SOURCE.OPEN_AMT OR
				TARGET.DISC_ALLOWED           != SOURCE.DISC_ALLOWED OR
				TARGET.DISC_TAKEN             != SOURCE.DISC_TAKEN OR
				TARGET.TRANS_DATE             != SOURCE.TRANS_DATE OR
				TARGET.DUE_DATE               != SOURCE.DUE_DATE OR
				TARGET.FISCAL_YR              != SOURCE.FISCAL_YR OR
				TARGET.FISCAL_PERIOD          != SOURCE.FISCAL_PERIOD OR
				TARGET.CLOSED_DATE            != SOURCE.CLOSED_DATE OR
				TARGET.EVT_ID                 != SOURCE.EVT_ID OR
				TARGET.FUNC_ID                != SOURCE.FUNC_ID OR
				TARGET.ORD_NBR                != SOURCE.ORD_NBR OR
				TARGET.STATEMENT_ID           != SOURCE.STATEMENT_ID OR
				TARGET.STATEMENT_DATE         != SOURCE.STATEMENT_DATE OR
				TARGET.REFERENCE              != SOURCE.REFERENCE OR
				TARGET.CC_CHECK               != SOURCE.CC_CHECK OR
				TARGET.CC_CONTROL             != SOURCE.CC_CONTROL OR
				TARGET.CC_EXP_DATE            != SOURCE.CC_EXP_DATE OR
				TARGET.CC_NAME                != SOURCE.CC_NAME OR
				TARGET.CC_AUTHORIZED          != SOURCE.CC_AUTHORIZED OR
				TARGET.REASON_CODE            != SOURCE.REASON_CODE OR
				TARGET.LOCKBOX_ID             != SOURCE.LOCKBOX_ID OR
				TARGET.REMARK                 != SOURCE.REMARK OR
				TARGET.LOCKBOX_DATE           != SOURCE.LOCKBOX_DATE OR
				TARGET.LOCKBOX_BATCH_DATE     != SOURCE.LOCKBOX_BATCH_DATE OR
				TARGET.BANK_CODE              != SOURCE.BANK_CODE OR
				TARGET.GL_DEBIT               != SOURCE.GL_DEBIT OR
				TARGET.GL_CREDIT              != SOURCE.GL_CREDIT OR
				TARGET.EXT_BATCH_ID           != SOURCE.EXT_BATCH_ID OR
				TARGET.INT_BATCH_ID           != SOURCE.INT_BATCH_ID OR
				TARGET.GL_POSTING_DATE        != SOURCE.GL_POSTING_DATE OR
				TARGET.GL_POSTED              != SOURCE.GL_POSTED OR
				TARGET.STATUS                 != SOURCE.STATUS OR
				TARGET.SETTLE_DATE            != SOURCE.SETTLE_DATE OR
				TARGET.STS_1                  != SOURCE.STS_1 OR
				TARGET.STS_2                  != SOURCE.STS_2 OR
				TARGET.ORD_LINE               != SOURCE.ORD_LINE OR
				TARGET.CONTACT                != SOURCE.CONTACT OR
				TARGET.RES_TYPE               != SOURCE.RES_TYPE OR
				TARGET.RES_CODE               != SOURCE.RES_CODE OR
				TARGET.DEL                    != SOURCE.DEL OR
				TARGET.CHG                    != SOURCE.CHG OR
				TARGET.ENT_DATE_ISO           != SOURCE.ENT_DATE_ISO OR
				TARGET.ENT_TIME_ISO           != SOURCE.ENT_TIME_ISO OR
				TARGET.ENT_USER_ID            != SOURCE.ENT_USER_ID OR
				TARGET.UPD_DATE_ISO           != SOURCE.UPD_DATE_ISO OR
				TARGET.UPD_TIME_ISO           != SOURCE.UPD_TIME_ISO OR
				TARGET.UPD_USER_ID            != SOURCE.UPD_USER_ID OR
				TARGET.TRANS_CLASS            != SOURCE.TRANS_CLASS OR
				TARGET.INVOICE                != SOURCE.INVOICE OR
				TARGET.FC_AMT                 != SOURCE.FC_AMT OR
				TARGET.FC_CODE                != SOURCE.FC_CODE OR
				TARGET.FC_OPEN_AMT            != SOURCE.FC_OPEN_AMT OR
				TARGET.FCA_SEQ                != SOURCE.FCA_SEQ OR
				TARGET.INTERNAL               != SOURCE.INTERNAL OR
				TARGET.APPLIED_SEQ            != SOURCE.APPLIED_SEQ OR
				TARGET.APPLIED_TO_SEQ         != SOURCE.APPLIED_TO_SEQ OR
				TARGET.APPLIED_AMT            != SOURCE.APPLIED_AMT OR
				TARGET.APPLIED_TO_AMT         != SOURCE.APPLIED_TO_AMT OR
				TARGET.APPLIED_DATE           != SOURCE.APPLIED_DATE OR
				TARGET.APPLIED_USER_ID        != SOURCE.APPLIED_USER_ID OR
				TARGET.APPLIED_TO_OPEN        != SOURCE.APPLIED_TO_OPEN OR
				TARGET.RECONCILED             != SOURCE.RECONCILED OR
				TARGET.FC_ADJ                 != SOURCE.FC_ADJ OR
				TARGET.FC_ADJ_AMT             != SOURCE.FC_ADJ_AMT OR
				TARGET.PAID_AMT               != SOURCE.PAID_AMT OR
				TARGET.PAID_CURRENCY          != SOURCE.PAID_CURRENCY OR
				TARGET.FCO_AMT                != SOURCE.FCO_AMT OR
				TARGET.LC_ADJ_AMT             != SOURCE.LC_ADJ_AMT OR
				TARGET.NAME                   != SOURCE.NAME OR
				TARGET.ADDR1                  != SOURCE.ADDR1 OR
				TARGET.ADDR2                  != SOURCE.ADDR2 OR
				TARGET.ADDR3                  != SOURCE.ADDR3 OR
				TARGET.CITY                   != SOURCE.CITY OR
				TARGET.STATE                  != SOURCE.STATE OR
				TARGET.POSTAL_CODE            != SOURCE.POSTAL_CODE OR
				TARGET.COUNTRY_CODE           != SOURCE.COUNTRY_CODE OR
				TARGET.AUTHORIZED             != SOURCE.AUTHORIZED OR
				TARGET.TR_AMT                 != SOURCE.TR_AMT OR
				TARGET.PAY_PLAN_ID            != SOURCE.PAY_PLAN_ID OR
				TARGET.GL_SOURCE              != SOURCE.GL_SOURCE OR
				TARGET.ENTRY_NBR              != SOURCE.ENTRY_NBR OR
				TARGET.CONTROL_SEQ            != SOURCE.CONTROL_SEQ OR
				TARGET.INT_CHG_STS            != SOURCE.INT_CHG_STS OR
				TARGET.INT_ACC_STS            != SOURCE.INT_ACC_STS OR
				TARGET.ORIG_CC_CONTROL        != SOURCE.ORIG_CC_CONTROL OR
				TARGET.FIRST_NAME             != SOURCE.FIRST_NAME OR
				TARGET.LAST_NAME              != SOURCE.LAST_NAME OR
				TARGET.ORD_DEPT               != SOURCE.ORD_DEPT OR
				TARGET.DELINQUENT_DATE        != SOURCE.DELINQUENT_DATE OR
				TARGET.FINANCE_CHARGE         != SOURCE.FINANCE_CHARGE OR
				TARGET.LAST_FINANCE_DATE      != SOURCE.LAST_FINANCE_DATE OR
				TARGET.FINANCE_CHARGE_EST     != SOURCE.FINANCE_CHARGE_EST OR
				TARGET.LATE_NOTICE_DATE       != SOURCE.LATE_NOTICE_DATE OR
				TARGET.PP_SCHED_CODE          != SOURCE.PP_SCHED_CODE OR
				TARGET.TRANS_IND              != SOURCE.TRANS_IND OR
				TARGET.CC_ID_FIELD            != SOURCE.CC_ID_FIELD OR
				TARGET.GRP_SEQ                != SOURCE.GRP_SEQ OR
				TARGET.GRP_TSM                != SOURCE.GRP_TSM OR
				TARGET.GRP_STS                != SOURCE.GRP_STS OR
				TARGET.TSM                    != SOURCE.TSM OR
				TARGET.FYP                    != SOURCE.FYP OR
				TARGET.GL_FYP                 != SOURCE.GL_FYP OR
				TARGET.GRP_DATE               != SOURCE.GRP_DATE OR
				TARGET.FROM_ACCOUNT           != SOURCE.FROM_ACCOUNT OR
				TARGET.TO_ACCOUNT             != SOURCE.TO_ACCOUNT OR
				TARGET.USER_REFERENCE         != SOURCE.USER_REFERENCE OR
				TARGET.CC_EXP_DATE_ENC        != SOURCE.CC_EXP_DATE_ENC OR
				TARGET.CC_NBR_ENC             != SOURCE.CC_NBR_ENC OR
				TARGET.TOTAL_AMT              != SOURCE.TOTAL_AMT OR
				TARGET.TOTAL_FC_AMT           != SOURCE.TOTAL_FC_AMT OR
				TARGET.TOTAL_INDIC            != SOURCE.TOTAL_INDIC OR
				TARGET.REF_INVOICE            != SOURCE.REF_INVOICE OR
				TARGET.REVERSE_SEQ            != SOURCE.REVERSE_SEQ OR
				TARGET.VOUCHER                != SOURCE.VOUCHER OR
				TARGET.CB_DEPOSIT_SEQ         != SOURCE.CB_DEPOSIT_SEQ OR
				TARGET.TRANS_PRINT            != SOURCE.TRANS_PRINT OR
				TARGET.BANK_AUTH_CODE         != SOURCE.BANK_AUTH_CODE OR
				TARGET.USER_REF_NBR1          != SOURCE.USER_REF_NBR1 OR
				TARGET.USER_REF_NBR2          != SOURCE.USER_REF_NBR2 OR
				TARGET.CARD_TYPE              != SOURCE.CARD_TYPE OR
				TARGET.CARD_ISSUE_NBR_ENC     != SOURCE.CARD_ISSUE_NBR_ENC OR
				TARGET.CARD_START_MONTH_ENC   != SOURCE.CARD_START_MONTH_ENC OR
				TARGET.CARD_START_YEAR_ENC    != SOURCE.CARD_START_YEAR_ENC OR
				TARGET.LOCKBOX_BATCH          != SOURCE.LOCKBOX_BATCH OR
				TARGET.LOCKBOX_SEQ            != SOURCE.LOCKBOX_SEQ OR
				TARGET.CC_TOKEN               != SOURCE.CC_TOKEN OR
				TARGET.CC_SWIPE               != SOURCE.CC_SWIPE OR
				TARGET.AR_CONTROL             != SOURCE.AR_CONTROL OR
				TARGET.TRANSIT_NBR            != SOURCE.TRANSIT_NBR OR
				TARGET.ADJ_RCD_TYPE           != SOURCE.ADJ_RCD_TYPE OR
				TARGET.MAIN_SEQ               != SOURCE.MAIN_SEQ OR
				TARGET.TRANS_INFO_SEQ         != SOURCE.TRANS_INFO_SEQ OR
				TARGET.BILL_PROFILE_TOKEN_ENC != SOURCE.BILL_PROFILE_TOKEN_ENC)

			THEN UPDATE SET 

				TRANS_TYPE             = SOURCE.TRANS_TYPE,
				TRANS_SOURCE           = SOURCE.TRANS_SOURCE,
				TRANS_METHOD           = SOURCE.TRANS_METHOD,
				MEMO_TRANS             = SOURCE.MEMO_TRANS,
				AMT                    = SOURCE.AMT,
				OPEN_AMT               = SOURCE.OPEN_AMT,
				DISC_ALLOWED           = SOURCE.DISC_ALLOWED,
				DISC_TAKEN             = SOURCE.DISC_TAKEN,
				TRANS_DATE             = SOURCE.TRANS_DATE,
				DUE_DATE               = SOURCE.DUE_DATE,
				FISCAL_YR              = SOURCE.FISCAL_YR,
				FISCAL_PERIOD          = SOURCE.FISCAL_PERIOD,
				CLOSED_DATE            = SOURCE.CLOSED_DATE,
				EVT_ID                 = SOURCE.EVT_ID,
				FUNC_ID                = SOURCE.FUNC_ID,
				ORD_NBR                = SOURCE.ORD_NBR,
				STATEMENT_ID           = SOURCE.STATEMENT_ID,
				STATEMENT_DATE         = SOURCE.STATEMENT_DATE,
				REFERENCE              = SOURCE.REFERENCE,
				CC_CHECK               = SOURCE.CC_CHECK,
				CC_CONTROL             = SOURCE.CC_CONTROL,
				CC_EXP_DATE            = SOURCE.CC_EXP_DATE,
				CC_NAME                = SOURCE.CC_NAME,
				CC_AUTHORIZED          = SOURCE.CC_AUTHORIZED,
				REASON_CODE            = SOURCE.REASON_CODE,
				LOCKBOX_ID             = SOURCE.LOCKBOX_ID,
				REMARK                 = SOURCE.REMARK,
				LOCKBOX_DATE           = SOURCE.LOCKBOX_DATE,
				LOCKBOX_BATCH_DATE     = SOURCE.LOCKBOX_BATCH_DATE,
				BANK_CODE              = SOURCE.BANK_CODE,
				GL_DEBIT               = SOURCE.GL_DEBIT,
				GL_CREDIT              = SOURCE.GL_CREDIT,
				EXT_BATCH_ID           = SOURCE.EXT_BATCH_ID,
				INT_BATCH_ID           = SOURCE.INT_BATCH_ID,
				GL_POSTING_DATE        = SOURCE.GL_POSTING_DATE,
				GL_POSTED              = SOURCE.GL_POSTED,
				STATUS                 = SOURCE.STATUS,
				SETTLE_DATE            = SOURCE.SETTLE_DATE,
				STS_1                  = SOURCE.STS_1,
				STS_2                  = SOURCE.STS_2,
				ORD_LINE               = SOURCE.ORD_LINE,
				CONTACT                = SOURCE.CONTACT,
				RES_TYPE               = SOURCE.RES_TYPE,
				RES_CODE               = SOURCE.RES_CODE,
				DEL                    = SOURCE.DEL,
				CHG                    = SOURCE.CHG,
				ENT_DATE_ISO           = SOURCE.ENT_DATE_ISO,
				ENT_TIME_ISO           = SOURCE.ENT_TIME_ISO,
				ENT_USER_ID            = SOURCE.ENT_USER_ID,
				UPD_DATE_ISO           = SOURCE.UPD_DATE_ISO,
				UPD_TIME_ISO           = SOURCE.UPD_TIME_ISO,
				UPD_USER_ID            = SOURCE.UPD_USER_ID,
				TRANS_CLASS            = SOURCE.TRANS_CLASS,
				INVOICE                = SOURCE.INVOICE,
				FC_AMT                 = SOURCE.FC_AMT,
				FC_CODE                = SOURCE.FC_CODE,
				FC_OPEN_AMT            = SOURCE.FC_OPEN_AMT,
				FCA_SEQ                = SOURCE.FCA_SEQ,
				INTERNAL               = SOURCE.INTERNAL,
				APPLIED_SEQ            = SOURCE.APPLIED_SEQ,
				APPLIED_TO_SEQ         = SOURCE.APPLIED_TO_SEQ,
				APPLIED_AMT            = SOURCE.APPLIED_AMT,
				APPLIED_TO_AMT         = SOURCE.APPLIED_TO_AMT,
				APPLIED_DATE           = SOURCE.APPLIED_DATE,
				APPLIED_USER_ID        = SOURCE.APPLIED_USER_ID,
				APPLIED_TO_OPEN        = SOURCE.APPLIED_TO_OPEN,
				RECONCILED             = SOURCE.RECONCILED,
				FC_ADJ                 = SOURCE.FC_ADJ,
				FC_ADJ_AMT             = SOURCE.FC_ADJ_AMT,
				PAID_AMT               = SOURCE.PAID_AMT,
				PAID_CURRENCY          = SOURCE.PAID_CURRENCY,
				FCO_AMT                = SOURCE.FCO_AMT,
				LC_ADJ_AMT             = SOURCE.LC_ADJ_AMT,
				NAME                   = SOURCE.NAME,
				ADDR1                  = SOURCE.ADDR1,
				ADDR2                  = SOURCE.ADDR2,
				ADDR3                  = SOURCE.ADDR3,
				CITY                   = SOURCE.CITY,
				STATE                  = SOURCE.STATE,
				POSTAL_CODE            = SOURCE.POSTAL_CODE,
				COUNTRY_CODE           = SOURCE.COUNTRY_CODE,
				AUTHORIZED             = SOURCE.AUTHORIZED,
				TR_AMT                 = SOURCE.TR_AMT,
				PAY_PLAN_ID            = SOURCE.PAY_PLAN_ID,
				GL_SOURCE              = SOURCE.GL_SOURCE,
				ENTRY_NBR              = SOURCE.ENTRY_NBR,
				CONTROL_SEQ            = SOURCE.CONTROL_SEQ,
				INT_CHG_STS            = SOURCE.INT_CHG_STS,
				INT_ACC_STS            = SOURCE.INT_ACC_STS,
				ORIG_CC_CONTROL        = SOURCE.ORIG_CC_CONTROL,
				FIRST_NAME             = SOURCE.FIRST_NAME,
				LAST_NAME              = SOURCE.LAST_NAME,
				ORD_DEPT               = SOURCE.ORD_DEPT,
				DELINQUENT_DATE        = SOURCE.DELINQUENT_DATE,
				FINANCE_CHARGE         = SOURCE.FINANCE_CHARGE,
				LAST_FINANCE_DATE      = SOURCE.LAST_FINANCE_DATE,
				FINANCE_CHARGE_EST     = SOURCE.FINANCE_CHARGE_EST,
				LATE_NOTICE_DATE       = SOURCE.LATE_NOTICE_DATE,
				PP_SCHED_CODE          = SOURCE.PP_SCHED_CODE,
				TRANS_IND              = SOURCE.TRANS_IND,
				CC_ID_FIELD            = SOURCE.CC_ID_FIELD,
				GRP_SEQ                = SOURCE.GRP_SEQ,
				GRP_TSM                = SOURCE.GRP_TSM,
				GRP_STS                = SOURCE.GRP_STS,
				TSM                    = SOURCE.TSM,
				FYP                    = SOURCE.FYP,
				GL_FYP                 = SOURCE.GL_FYP,
				GRP_DATE               = SOURCE.GRP_DATE,
				FROM_ACCOUNT           = SOURCE.FROM_ACCOUNT,
				TO_ACCOUNT             = SOURCE.TO_ACCOUNT,
				USER_REFERENCE         = SOURCE.USER_REFERENCE,
				CC_EXP_DATE_ENC        = SOURCE.CC_EXP_DATE_ENC,
				CC_NBR_ENC             = SOURCE.CC_NBR_ENC,
				TOTAL_AMT              = SOURCE.TOTAL_AMT,
				TOTAL_FC_AMT           = SOURCE.TOTAL_FC_AMT,
				TOTAL_INDIC            = SOURCE.TOTAL_INDIC,
				REF_INVOICE            = SOURCE.REF_INVOICE,
				REVERSE_SEQ            = SOURCE.REVERSE_SEQ,
				VOUCHER                = SOURCE.VOUCHER,
				CB_DEPOSIT_SEQ         = SOURCE.CB_DEPOSIT_SEQ,
				TRANS_PRINT            = SOURCE.TRANS_PRINT,
				BANK_AUTH_CODE         = SOURCE.BANK_AUTH_CODE,
				USER_REF_NBR1          = SOURCE.USER_REF_NBR1,
				USER_REF_NBR2          = SOURCE.USER_REF_NBR2,
				CARD_TYPE              = SOURCE.CARD_TYPE,
				CARD_ISSUE_NBR_ENC     = SOURCE.CARD_ISSUE_NBR_ENC,
				CARD_START_MONTH_ENC   = SOURCE.CARD_START_MONTH_ENC,
				CARD_START_YEAR_ENC    = SOURCE.CARD_START_YEAR_ENC,
				LOCKBOX_BATCH          = SOURCE.LOCKBOX_BATCH,
				LOCKBOX_SEQ            = SOURCE.LOCKBOX_SEQ,
				CC_TOKEN               = SOURCE.CC_TOKEN,
				CC_SWIPE               = SOURCE.CC_SWIPE,
				AR_CONTROL             = SOURCE.AR_CONTROL,
				TRANSIT_NBR            = SOURCE.TRANSIT_NBR,
				ADJ_RCD_TYPE           = SOURCE.ADJ_RCD_TYPE,
				MAIN_SEQ               = SOURCE.MAIN_SEQ,
				TRANS_INFO_SEQ         = SOURCE.TRANS_INFO_SEQ,
				BILL_PROFILE_TOKEN_ENC = SOURCE.BILL_PROFILE_TOKEN_ENC

			WHEN NOT MATCHED BY TARGET THEN INSERT (

				ORG_CODE,
				EXT_ACCT_CODE,
				SEQ,
				TRANS_SOURCE,
				TRANS_TYPE,
				TRANS_METHOD,
				MEMO_TRANS,
				AMT,
				OPEN_AMT,
				DISC_ALLOWED,
				DISC_TAKEN,
				TRANS_DATE,
				DUE_DATE,
				FISCAL_YR,
				FISCAL_PERIOD,
				CLOSED_DATE,
				EVT_ID,
				FUNC_ID,
				ORD_NBR,
				STATEMENT_ID,
				STATEMENT_DATE,
				REFERENCE,
				CC_CHECK,
				CC_CONTROL,
				CC_EXP_DATE,
				CC_NAME,
				CC_AUTHORIZED,
				REASON_CODE,
				LOCKBOX_ID,
				REMARK,
				LOCKBOX_DATE,
				LOCKBOX_BATCH_DATE,
				BANK_CODE,
				GL_DEBIT,
				GL_CREDIT,
				EXT_BATCH_ID,
				INT_BATCH_ID,
				GL_POSTING_DATE,
				GL_POSTED,
				STATUS,
				SETTLE_DATE,
				STS_1,
				STS_2,
				ORD_LINE,
				CONTACT,
				RES_TYPE,
				RES_CODE,
				DEL,
				CHG,
				ENT_DATE_ISO,
				ENT_TIME_ISO,
				ENT_USER_ID,
				UPD_DATE_ISO,
				UPD_TIME_ISO,
				UPD_USER_ID,
				TRANS_CLASS,
				INVOICE,
				FC_AMT,
				FC_CODE,
				FC_OPEN_AMT,
				FCA_SEQ,
				INTERNAL,
				APPLIED_SEQ,
				APPLIED_TO_SEQ,
				APPLIED_AMT,
				APPLIED_TO_AMT,
				APPLIED_DATE,
				APPLIED_USER_ID,
				APPLIED_TO_OPEN,
				RECONCILED,
				FC_ADJ,
				FC_ADJ_AMT,
				PAID_AMT,
				PAID_CURRENCY,
				FCO_AMT,
				LC_ADJ_AMT,
				NAME,
				ADDR1,
				ADDR2,
				ADDR3,
				CITY,
				STATE,
				POSTAL_CODE,
				COUNTRY_CODE,
				AUTHORIZED,
				TR_AMT,
				PAY_PLAN_ID,
				GL_SOURCE,
				ENTRY_NBR,
				CONTROL_SEQ,
				INT_CHG_STS,
				INT_ACC_STS,
				ORIG_CC_CONTROL,
				FIRST_NAME,
				LAST_NAME,
				ORD_DEPT,
				DELINQUENT_DATE,
				FINANCE_CHARGE,
				LAST_FINANCE_DATE,
				FINANCE_CHARGE_EST,
				LATE_NOTICE_DATE,
				PP_SCHED_CODE,
				TRANS_IND,
				CC_ID_FIELD,
				GRP_SEQ,
				GRP_TSM,
				GRP_STS,
				TSM,
				FYP,
				GL_FYP,
				GRP_DATE,
				FROM_ACCOUNT,
				TO_ACCOUNT,
				USER_REFERENCE,
				CC_EXP_DATE_ENC,
				CC_NBR_ENC,
				TOTAL_AMT,
				TOTAL_FC_AMT,
				TOTAL_INDIC,
				REF_INVOICE,
				REVERSE_SEQ,
				VOUCHER,
				CB_DEPOSIT_SEQ,
				TRANS_PRINT,
				BANK_AUTH_CODE,
				USER_REF_NBR1,
				USER_REF_NBR2,
				CARD_TYPE,
				CARD_ISSUE_NBR_ENC,
				CARD_START_MONTH_ENC,
				CARD_START_YEAR_ENC,
				LOCKBOX_BATCH,
				LOCKBOX_SEQ,
				CC_TOKEN,
				CC_SWIPE,
				AR_CONTROL,
				TRANSIT_NBR,
				ADJ_RCD_TYPE,
				MAIN_SEQ,
				TRANS_INFO_SEQ,
				BILL_PROFILE_TOKEN_ENC )

			VALUES (

				SOURCE.ORG_CODE,
				SOURCE.EXT_ACCT_CODE,
				SOURCE.SEQ,
				SOURCE.TRANS_SOURCE,
				SOURCE.TRANS_TYPE,
				SOURCE.TRANS_METHOD,
				SOURCE.MEMO_TRANS,
				SOURCE.AMT,
				SOURCE.OPEN_AMT,
				SOURCE.DISC_ALLOWED,
				SOURCE.DISC_TAKEN,
				SOURCE.TRANS_DATE,
				SOURCE.DUE_DATE,
				SOURCE.FISCAL_YR,
				SOURCE.FISCAL_PERIOD,
				SOURCE.CLOSED_DATE,
				SOURCE.EVT_ID,
				SOURCE.FUNC_ID,
				SOURCE.ORD_NBR,
				SOURCE.STATEMENT_ID,
				SOURCE.STATEMENT_DATE,
				SOURCE.REFERENCE,
				SOURCE.CC_CHECK,
				SOURCE.CC_CONTROL,
				SOURCE.CC_EXP_DATE,
				SOURCE.CC_NAME,
				SOURCE.CC_AUTHORIZED,
				SOURCE.REASON_CODE,
				SOURCE.LOCKBOX_ID,
				SOURCE.REMARK,
				SOURCE.LOCKBOX_DATE,
				SOURCE.LOCKBOX_BATCH_DATE,
				SOURCE.BANK_CODE,
				SOURCE.GL_DEBIT,
				SOURCE.GL_CREDIT,
				SOURCE.EXT_BATCH_ID,
				SOURCE.INT_BATCH_ID,
				SOURCE.GL_POSTING_DATE,
				SOURCE.GL_POSTED,
				SOURCE.STATUS,
				SOURCE.SETTLE_DATE,
				SOURCE.STS_1,
				SOURCE.STS_2,
				SOURCE.ORD_LINE,
				SOURCE.CONTACT,
				SOURCE.RES_TYPE,
				SOURCE.RES_CODE,
				SOURCE.DEL,
				SOURCE.CHG,
				SOURCE.ENT_DATE_ISO,
				SOURCE.ENT_TIME_ISO,
				SOURCE.ENT_USER_ID,
				SOURCE.UPD_DATE_ISO,
				SOURCE.UPD_TIME_ISO,
				SOURCE.UPD_USER_ID,
				SOURCE.TRANS_CLASS,
				SOURCE.INVOICE,
				SOURCE.FC_AMT,
				SOURCE.FC_CODE,
				SOURCE.FC_OPEN_AMT,
				SOURCE.FCA_SEQ,
				SOURCE.INTERNAL,
				SOURCE.APPLIED_SEQ,
				SOURCE.APPLIED_TO_SEQ,
				SOURCE.APPLIED_AMT,
				SOURCE.APPLIED_TO_AMT,
				SOURCE.APPLIED_DATE,
				SOURCE.APPLIED_USER_ID,
				SOURCE.APPLIED_TO_OPEN,
				SOURCE.RECONCILED,
				SOURCE.FC_ADJ,
				SOURCE.FC_ADJ_AMT,
				SOURCE.PAID_AMT,
				SOURCE.PAID_CURRENCY,
				SOURCE.FCO_AMT,
				SOURCE.LC_ADJ_AMT,
				SOURCE.NAME,
				SOURCE.ADDR1,
				SOURCE.ADDR2,
				SOURCE.ADDR3,
				SOURCE.CITY,
				SOURCE.STATE,
				SOURCE.POSTAL_CODE,
				SOURCE.COUNTRY_CODE,
				SOURCE.AUTHORIZED,
				SOURCE.TR_AMT,
				SOURCE.PAY_PLAN_ID,
				SOURCE.GL_SOURCE,
				SOURCE.ENTRY_NBR,
				SOURCE.CONTROL_SEQ,
				SOURCE.INT_CHG_STS,
				SOURCE.INT_ACC_STS,
				SOURCE.ORIG_CC_CONTROL,
				SOURCE.FIRST_NAME,
				SOURCE.LAST_NAME,
				SOURCE.ORD_DEPT,
				SOURCE.DELINQUENT_DATE,
				SOURCE.FINANCE_CHARGE,
				SOURCE.LAST_FINANCE_DATE,
				SOURCE.FINANCE_CHARGE_EST,
				SOURCE.LATE_NOTICE_DATE,
				SOURCE.PP_SCHED_CODE,
				SOURCE.TRANS_IND,
				SOURCE.CC_ID_FIELD,
				SOURCE.GRP_SEQ,
				SOURCE.GRP_TSM,
				SOURCE.GRP_STS,
				SOURCE.TSM,
				SOURCE.FYP,
				SOURCE.GL_FYP,
				SOURCE.GRP_DATE,
				SOURCE.FROM_ACCOUNT,
				SOURCE.TO_ACCOUNT,
				SOURCE.USER_REFERENCE,
				SOURCE.CC_EXP_DATE_ENC,
				SOURCE.CC_NBR_ENC,
				SOURCE.TOTAL_AMT,
				SOURCE.TOTAL_FC_AMT,
				SOURCE.TOTAL_INDIC,
				SOURCE.REF_INVOICE,
				SOURCE.REVERSE_SEQ,
				SOURCE.VOUCHER,
				SOURCE.CB_DEPOSIT_SEQ,
				SOURCE.TRANS_PRINT,
				SOURCE.BANK_AUTH_CODE,
				SOURCE.USER_REF_NBR1,
				SOURCE.USER_REF_NBR2,
				SOURCE.CARD_TYPE,
				SOURCE.CARD_ISSUE_NBR_ENC,
				SOURCE.CARD_START_MONTH_ENC,
				SOURCE.CARD_START_YEAR_ENC,
				SOURCE.LOCKBOX_BATCH,
				SOURCE.LOCKBOX_SEQ,
				SOURCE.CC_TOKEN,
				SOURCE.CC_SWIPE,
				SOURCE.AR_CONTROL,
				SOURCE.TRANSIT_NBR,
				SOURCE.ADJ_RCD_TYPE,
				SOURCE.MAIN_SEQ,
				SOURCE.TRANS_INFO_SEQ,
				SOURCE.BILL_PROFILE_TOKEN_ENC )
			
			WHEN NOT MATCHED BY SOURCE

				THEN DELETE

			OPTION (LOOP JOIN);
		
		COMMIT TRANSACTION;

	END TRY
	
	BEGIN CATCH

		ROLLBACK TRANSACTION;
		
		THROW;

	END CATCH;

END;
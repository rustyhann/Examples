CREATE PROCEDURE CSP_SYNC_EVT_REGIS

      @TableParam TVP_EVT_REGIS READONLY

AS
BEGIN

	BEGIN TRY

		BEGIN TRANSACTION

			MERGE EVT_REGIS WITH (TABLOCK) AS TARGET USING @TableParam AS SOURCE ON

				TARGET.ORG_CODE = SOURCE.ORG_CODE AND
				TARGET.REG_SEQ = SOURCE.REG_SEQ

			WHEN MATCHED AND (
				TARGET.EVT_ID != SOURCE.EVT_ID OR
				TARGET.FUNC_ID != SOURCE.FUNC_ID OR
				TARGET.REG_CONTACT != SOURCE.REG_CONTACT OR
				TARGET.STATUS != SOURCE.STATUS OR
				TARGET.PRT_STATUS != SOURCE.PRT_STATUS OR
				TARGET.CANCEL_DATE_ISO != SOURCE.CANCEL_DATE_ISO OR
				TARGET.CANCEL_TIME != SOURCE.CANCEL_TIME OR
				TARGET.CANCEL_USER_ID != SOURCE.CANCEL_USER_ID OR
				TARGET.CANCEL_BY != SOURCE.CANCEL_BY OR
				TARGET.CANCEL_REASON != SOURCE.CANCEL_REASON OR
				TARGET.ORD_LINE != SOURCE.ORD_LINE OR
				TARGET.STATUS_2 != SOURCE.STATUS_2 OR
				TARGET.REG_ACCT != SOURCE.REG_ACCT OR
				TARGET.STATUS_AT_PRINT != SOURCE.STATUS_AT_PRINT OR
				TARGET.RM_NBR != SOURCE.RM_NBR OR
				TARGET.ARR_DATE != SOURCE.ARR_DATE OR
				TARGET.ARR_TIME != SOURCE.ARR_TIME OR
				TARGET.ARR_VIA != SOURCE.ARR_VIA OR
				TARGET.ARR_LOC != SOURCE.ARR_LOC OR
				TARGET.ARR_PICKUP_TIME != SOURCE.ARR_PICKUP_TIME OR
				TARGET.ARR_PICKUP_DATE != SOURCE.ARR_PICKUP_DATE OR
				TARGET.ARR_PICKUP_LOC != SOURCE.ARR_PICKUP_LOC OR
				TARGET.ARR_TRANSPORTATION != SOURCE.ARR_TRANSPORTATION OR
				TARGET.DEP_DATE != SOURCE.DEP_DATE OR
				TARGET.DEP_TIME != SOURCE.DEP_TIME OR
				TARGET.DEP_VIA != SOURCE.DEP_VIA OR
				TARGET.DEP_LOCATION != SOURCE.DEP_LOCATION OR
				TARGET.DEP_PICKUP_DATE != SOURCE.DEP_PICKUP_DATE OR
				TARGET.DEP_PICKUP_TIME != SOURCE.DEP_PICKUP_TIME OR
				TARGET.DEP_PICKUP_LOC != SOURCE.DEP_PICKUP_LOC OR
				TARGET.DEP_TRANSPORTATION != SOURCE.DEP_TRANSPORTATION OR
				TARGET.LOCAL_TRANSPORTATION != SOURCE.LOCAL_TRANSPORTATION OR
				TARGET.FILL_092 != SOURCE.FILL_092 OR
				TARGET.FILL_1X != SOURCE.FILL_1X OR
				TARGET.FILL_1X2 != SOURCE.FILL_1X2 OR
				TARGET.FILL_1X3 != SOURCE.FILL_1X3 OR
				TARGET.FILL_20X != SOURCE.FILL_20X OR
				TARGET.FILL_20X2 != SOURCE.FILL_20X2 OR
				TARGET.FILL_20X3 != SOURCE.FILL_20X3 OR
				TARGET.FILL_6X != SOURCE.FILL_6X OR
				TARGET.FILL_6X2 != SOURCE.FILL_6X2 OR
				TARGET.FILL_6X4 != SOURCE.FILL_6X4 OR
				TARGET.FILL_6X5 != SOURCE.FILL_6X5 OR
				TARGET.FILL_10X != SOURCE.FILL_10X OR
				TARGET.FILL_072 != SOURCE.FILL_072 OR
				TARGET.FILL_30X != SOURCE.FILL_30X OR
				TARGET.USER_PROFILE != SOURCE.USER_PROFILE OR
				TARGET.ENT_DATE_ISO != SOURCE.ENT_DATE_ISO OR
				TARGET.ENT_TIME_ISO != SOURCE.ENT_TIME_ISO OR
				TARGET.ENT_USER_ID != SOURCE.ENT_USER_ID OR
				TARGET.UPD_DATE_ISO != SOURCE.UPD_DATE_ISO OR
				TARGET.UPD_TIME_ISO != SOURCE.UPD_TIME_ISO OR
				TARGET.UPD_USER_ID != SOURCE.UPD_USER_ID OR
				TARGET.ACCUM_EVT_ID != SOURCE.ACCUM_EVT_ID OR
				TARGET.ACCUM_FUNC_ID != SOURCE.ACCUM_FUNC_ID OR
				TARGET.ACCUM_PHASE != SOURCE.ACCUM_PHASE OR
				TARGET.ACCUM_RES_SEQ != SOURCE.ACCUM_RES_SEQ OR
				TARGET.DEL_MARK != SOURCE.DEL_MARK OR
				TARGET.USER_8X1 != SOURCE.USER_8X1 OR
				TARGET.USER_8X2 != SOURCE.USER_8X2 OR
				TARGET.USER_8X3 != SOURCE.USER_8X3 OR
				TARGET.USER_10X != SOURCE.USER_10X OR
				TARGET.ORD_NBR != SOURCE.ORD_NBR OR
				TARGET.ORD_TYPE != SOURCE.ORD_TYPE OR
				TARGET.ORD_ACCT != SOURCE.ORD_ACCT OR
				TARGET.PRI_ACCT != SOURCE.PRI_ACCT OR
				TARGET.SEC_ACCT != SOURCE.SEC_ACCT OR
				TARGET.PRT_CONF != SOURCE.PRT_CONF OR
				TARGET.CO_NAME != SOURCE.CO_NAME OR
				TARGET.CHKIN_STAMP != SOURCE.CHKIN_STAMP OR
				TARGET.CHKIN_USER != SOURCE.CHKIN_USER OR
				TARGET.REG_TYPE != SOURCE.REG_TYPE OR
				TARGET.AMT_01 != SOURCE.AMT_01 OR
				TARGET.AMT_02 != SOURCE.AMT_02 OR
				TARGET.AMT_03 != SOURCE.AMT_03 OR
				TARGET.AMT_04 != SOURCE.AMT_04 OR
				TARGET.AMT_05 != SOURCE.AMT_05 OR
				TARGET.AMT_06 != SOURCE.AMT_06 OR
				TARGET.AMT_07 != SOURCE.AMT_07 OR
				TARGET.AMT_08 != SOURCE.AMT_08 OR
				TARGET.AMT_09 != SOURCE.AMT_09 OR
				TARGET.AMT_10 != SOURCE.AMT_10 OR
				TARGET.AMT_11 != SOURCE.AMT_11 OR
				TARGET.AMT_12 != SOURCE.AMT_12 OR
				TARGET.AMT_13 != SOURCE.AMT_13 OR
				TARGET.AMT_14 != SOURCE.AMT_14 OR
				TARGET.AMT_15 != SOURCE.AMT_15 OR
				TARGET.AMT_16 != SOURCE.AMT_16 OR
				TARGET.AMT_17 != SOURCE.AMT_17 OR
				TARGET.AMT_18 != SOURCE.AMT_18 OR
				TARGET.AMT_19 != SOURCE.AMT_19 OR
				TARGET.AMT_20 != SOURCE.AMT_20 OR
				TARGET.AMT_21 != SOURCE.AMT_21 OR
				TARGET.AMT_22 != SOURCE.AMT_22 OR
				TARGET.AMT_23 != SOURCE.AMT_23 OR
				TARGET.AMT_24 != SOURCE.AMT_24 OR
				TARGET.AMT_25 != SOURCE.AMT_25 OR
				TARGET.AMT_26 != SOURCE.AMT_26 OR
				TARGET.AMT_27 != SOURCE.AMT_27 OR
				TARGET.AMT_28 != SOURCE.AMT_28 OR
				TARGET.AMT_29 != SOURCE.AMT_29 OR
				TARGET.AMT_30 != SOURCE.AMT_30 OR
				TARGET.DTS_01 != SOURCE.DTS_01 OR
				TARGET.DTS_02 != SOURCE.DTS_02 OR
				TARGET.DTS_03 != SOURCE.DTS_03 OR
				TARGET.DTS_04 != SOURCE.DTS_04 OR
				TARGET.DTS_05 != SOURCE.DTS_05 OR
				TARGET.DTS_06 != SOURCE.DTS_06 OR
				TARGET.DTS_07 != SOURCE.DTS_07 OR
				TARGET.DTS_08 != SOURCE.DTS_08 OR
				TARGET.DTS_09 != SOURCE.DTS_09 OR
				TARGET.DTS_10 != SOURCE.DTS_10 OR
				TARGET.DTS_11 != SOURCE.DTS_11 OR
				TARGET.DTS_12 != SOURCE.DTS_12 OR
				TARGET.DTS_13 != SOURCE.DTS_13 OR
				TARGET.DTS_14 != SOURCE.DTS_14 OR
				TARGET.DTS_15 != SOURCE.DTS_15 OR
				TARGET.DTS_16 != SOURCE.DTS_16 OR
				TARGET.DTS_17 != SOURCE.DTS_17 OR
				TARGET.DTS_18 != SOURCE.DTS_18 OR
				TARGET.DTS_19 != SOURCE.DTS_19 OR
				TARGET.DTS_20 != SOURCE.DTS_20 OR
				TARGET.TXT_01 != SOURCE.TXT_01 OR
				TARGET.TXT_02 != SOURCE.TXT_02 OR
				TARGET.TXT_03 != SOURCE.TXT_03 OR
				TARGET.TXT_04 != SOURCE.TXT_04 OR
				TARGET.TXT_05 != SOURCE.TXT_05 OR
				TARGET.TXT_06 != SOURCE.TXT_06 OR
				TARGET.TXT_07 != SOURCE.TXT_07 OR
				TARGET.TXT_08 != SOURCE.TXT_08 OR
				TARGET.TXT_09 != SOURCE.TXT_09 OR
				TARGET.TXT_10 != SOURCE.TXT_10 OR
				TARGET.TXT_11 != SOURCE.TXT_11 OR
				TARGET.TXT_12 != SOURCE.TXT_12 OR
				TARGET.TXT_13 != SOURCE.TXT_13 OR
				TARGET.TXT_14 != SOURCE.TXT_14 OR
				TARGET.TXT_15 != SOURCE.TXT_15 OR
				TARGET.TXT_16 != SOURCE.TXT_16 OR
				TARGET.TXT_17 != SOURCE.TXT_17 OR
				TARGET.TXT_18 != SOURCE.TXT_18 OR
				TARGET.TXT_19 != SOURCE.TXT_19 OR
				TARGET.TXT_20 != SOURCE.TXT_20 OR
				TARGET.TXT_21 != SOURCE.TXT_21 OR
				TARGET.TXT_22 != SOURCE.TXT_22 OR
				TARGET.TXT_23 != SOURCE.TXT_23 OR
				TARGET.TXT_24 != SOURCE.TXT_24 OR
				TARGET.TXT_25 != SOURCE.TXT_25 OR
				TARGET.TXT_26 != SOURCE.TXT_26 OR
				TARGET.TXT_27 != SOURCE.TXT_27 OR
				TARGET.TXT_28 != SOURCE.TXT_28 OR
				TARGET.TXT_29 != SOURCE.TXT_29 OR
				TARGET.TXT_30 != SOURCE.TXT_30 OR
				TARGET.TXT_31 != SOURCE.TXT_31 OR
				TARGET.TXT_32 != SOURCE.TXT_32 OR
				TARGET.TXT_33 != SOURCE.TXT_33 OR
				TARGET.TXT_34 != SOURCE.TXT_34 OR
				TARGET.TXT_35 != SOURCE.TXT_35 OR
				TARGET.TXT_36 != SOURCE.TXT_36 OR
				TARGET.TXT_37 != SOURCE.TXT_37 OR
				TARGET.TXT_38 != SOURCE.TXT_38 OR
				TARGET.TXT_39 != SOURCE.TXT_39 OR
				TARGET.TXT_40 != SOURCE.TXT_40 OR
				TARGET.TXT_41 != SOURCE.TXT_41 OR
				TARGET.TXT_42 != SOURCE.TXT_42 OR
				TARGET.TXT_43 != SOURCE.TXT_43 OR
				TARGET.TXT_44 != SOURCE.TXT_44 OR
				TARGET.TXT_45 != SOURCE.TXT_45 OR
				TARGET.TXT_46 != SOURCE.TXT_46 OR
				TARGET.TXT_47 != SOURCE.TXT_47 OR
				TARGET.TXT_48 != SOURCE.TXT_48 OR
				TARGET.TXT_49 != SOURCE.TXT_49 OR
				TARGET.TXT_50 != SOURCE.TXT_50 OR
				TARGET.ISSUE_CLASS != SOURCE.ISSUE_CLASS OR
				TARGET.ISSUE_TYPE != SOURCE.ISSUE_TYPE OR
				TARGET.MSTR_REG_ACCT_CODE != SOURCE.MSTR_REG_ACCT_CODE OR
				TARGET.PU_NEEDED != SOURCE.PU_NEEDED OR
				TARGET.PU_DATE != SOURCE.PU_DATE OR
				TARGET.PU_TIME != SOURCE.PU_TIME OR
				TARGET.PU_LOC_FROM != SOURCE.PU_LOC_FROM OR
				TARGET.PU_LOC_TO != SOURCE.PU_LOC_TO OR
				TARGET.PU_REFERENCE != SOURCE.PU_REFERENCE OR
				TARGET.DO_NEEDED != SOURCE.DO_NEEDED OR
				TARGET.DO_DATE != SOURCE.DO_DATE OR
				TARGET.DO_TIME != SOURCE.DO_TIME OR
				TARGET.DO_LOC_FROM != SOURCE.DO_LOC_FROM OR
				TARGET.DO_LOC_TO != SOURCE.DO_LOC_TO OR
				TARGET.DO_REFERENCE != SOURCE.DO_REFERENCE OR
				TARGET.ROOM_SHARING != SOURCE.ROOM_SHARING OR
				TARGET.PREF_ROOMMATE != SOURCE.PREF_ROOMMATE OR
				TARGET.ROOMMATE_ACCT != SOURCE.ROOMMATE_ACCT OR
				TARGET.AR_MODE != SOURCE.AR_MODE OR
				TARGET.AR_DATE != SOURCE.AR_DATE OR
				TARGET.AR_TIME != SOURCE.AR_TIME OR
				TARGET.AR_LOC_FROM != SOURCE.AR_LOC_FROM OR
				TARGET.AR_LOC_TO != SOURCE.AR_LOC_TO OR
				TARGET.AR_REFERENCE != SOURCE.AR_REFERENCE OR
				TARGET.AR_TRANS_NEED != SOURCE.AR_TRANS_NEED OR
				TARGET.AR_TRANS_MODE != SOURCE.AR_TRANS_MODE OR
				TARGET.AR_STATUS != SOURCE.AR_STATUS OR
				TARGET.DP_MODE != SOURCE.DP_MODE OR
				TARGET.DP_DATE != SOURCE.DP_DATE OR
				TARGET.DP_TIME != SOURCE.DP_TIME OR
				TARGET.DP_LOC_FROM != SOURCE.DP_LOC_FROM OR
				TARGET.DP_LOC_TO != SOURCE.DP_LOC_TO OR
				TARGET.DP_REFERENCE != SOURCE.DP_REFERENCE OR
				TARGET.DP_TRANS_NEED != SOURCE.DP_TRANS_NEED OR
				TARGET.DP_TRANS_MODE != SOURCE.DP_TRANS_MODE OR
				TARGET.DP_STATUS != SOURCE.DP_STATUS OR
				TARGET.BLOCK_CODE != SOURCE.BLOCK_CODE OR
				TARGET.EVT_REG_SEQ != SOURCE.EVT_REG_SEQ OR
				TARGET.APPR_LEVEL != SOURCE.APPR_LEVEL OR
				TARGET.APPR_ACTION != SOURCE.APPR_ACTION OR
				TARGET.APPR_USER_ID != SOURCE.APPR_USER_ID OR
				TARGET.APPR_STAMP != SOURCE.APPR_STAMP )

			THEN UPDATE SET

				TARGET.EVT_ID = SOURCE.EVT_ID,
				TARGET.FUNC_ID = SOURCE.FUNC_ID,
				TARGET.REG_CONTACT = SOURCE.REG_CONTACT,
				TARGET.STATUS = SOURCE.STATUS,
				TARGET.PRT_STATUS = SOURCE.PRT_STATUS,
				TARGET.CANCEL_DATE_ISO = SOURCE.CANCEL_DATE_ISO,
				TARGET.CANCEL_TIME = SOURCE.CANCEL_TIME,
				TARGET.CANCEL_USER_ID = SOURCE.CANCEL_USER_ID,
				TARGET.CANCEL_BY = SOURCE.CANCEL_BY,
				TARGET.CANCEL_REASON = SOURCE.CANCEL_REASON,
				TARGET.ORD_LINE = SOURCE.ORD_LINE,
				TARGET.STATUS_2 = SOURCE.STATUS_2,
				TARGET.REG_ACCT = SOURCE.REG_ACCT,
				TARGET.STATUS_AT_PRINT = SOURCE.STATUS_AT_PRINT,
				TARGET.RM_NBR = SOURCE.RM_NBR,
				TARGET.ARR_DATE = SOURCE.ARR_DATE,
				TARGET.ARR_TIME = SOURCE.ARR_TIME,
				TARGET.ARR_VIA = SOURCE.ARR_VIA,
				TARGET.ARR_LOC = SOURCE.ARR_LOC,
				TARGET.ARR_PICKUP_TIME = SOURCE.ARR_PICKUP_TIME,
				TARGET.ARR_PICKUP_DATE = SOURCE.ARR_PICKUP_DATE,
				TARGET.ARR_PICKUP_LOC = SOURCE.ARR_PICKUP_LOC,
				TARGET.ARR_TRANSPORTATION = SOURCE.ARR_TRANSPORTATION,
				TARGET.DEP_DATE = SOURCE.DEP_DATE,
				TARGET.DEP_TIME = SOURCE.DEP_TIME,
				TARGET.DEP_VIA = SOURCE.DEP_VIA,
				TARGET.DEP_LOCATION = SOURCE.DEP_LOCATION,
				TARGET.DEP_PICKUP_DATE = SOURCE.DEP_PICKUP_DATE,
				TARGET.DEP_PICKUP_TIME = SOURCE.DEP_PICKUP_TIME,
				TARGET.DEP_PICKUP_LOC = SOURCE.DEP_PICKUP_LOC,
				TARGET.DEP_TRANSPORTATION = SOURCE.DEP_TRANSPORTATION,
				TARGET.LOCAL_TRANSPORTATION = SOURCE.LOCAL_TRANSPORTATION,
				TARGET.FILL_092 = SOURCE.FILL_092,
				TARGET.FILL_1X = SOURCE.FILL_1X,
				TARGET.FILL_1X2 = SOURCE.FILL_1X2,
				TARGET.FILL_1X3 = SOURCE.FILL_1X3,
				TARGET.FILL_20X = SOURCE.FILL_20X,
				TARGET.FILL_20X2 = SOURCE.FILL_20X2,
				TARGET.FILL_20X3 = SOURCE.FILL_20X3,
				TARGET.FILL_6X = SOURCE.FILL_6X,
				TARGET.FILL_6X2 = SOURCE.FILL_6X2,
				TARGET.FILL_6X4 = SOURCE.FILL_6X4,
				TARGET.FILL_6X5 = SOURCE.FILL_6X5,
				TARGET.FILL_10X = SOURCE.FILL_10X,
				TARGET.FILL_072 = SOURCE.FILL_072,
				TARGET.FILL_30X = SOURCE.FILL_30X,
				TARGET.USER_PROFILE = SOURCE.USER_PROFILE,
				TARGET.ENT_DATE_ISO = SOURCE.ENT_DATE_ISO,
				TARGET.ENT_TIME_ISO = SOURCE.ENT_TIME_ISO,
				TARGET.ENT_USER_ID = SOURCE.ENT_USER_ID,
				TARGET.UPD_DATE_ISO = SOURCE.UPD_DATE_ISO,
				TARGET.UPD_TIME_ISO = SOURCE.UPD_TIME_ISO,
				TARGET.UPD_USER_ID = SOURCE.UPD_USER_ID,
				TARGET.ACCUM_EVT_ID = SOURCE.ACCUM_EVT_ID,
				TARGET.ACCUM_FUNC_ID = SOURCE.ACCUM_FUNC_ID,
				TARGET.ACCUM_PHASE = SOURCE.ACCUM_PHASE,
				TARGET.ACCUM_RES_SEQ = SOURCE.ACCUM_RES_SEQ,
				TARGET.DEL_MARK = SOURCE.DEL_MARK,
				TARGET.USER_8X1 = SOURCE.USER_8X1,
				TARGET.USER_8X2 = SOURCE.USER_8X2,
				TARGET.USER_8X3 = SOURCE.USER_8X3,
				TARGET.USER_10X = SOURCE.USER_10X,
				TARGET.ORD_NBR = SOURCE.ORD_NBR,
				TARGET.ORD_TYPE = SOURCE.ORD_TYPE,
				TARGET.ORD_ACCT = SOURCE.ORD_ACCT,
				TARGET.PRI_ACCT = SOURCE.PRI_ACCT,
				TARGET.SEC_ACCT = SOURCE.SEC_ACCT,
				TARGET.PRT_CONF = SOURCE.PRT_CONF,
				TARGET.CO_NAME = SOURCE.CO_NAME,
				TARGET.CHKIN_STAMP = SOURCE.CHKIN_STAMP,
				TARGET.CHKIN_USER = SOURCE.CHKIN_USER,
				TARGET.REG_TYPE = SOURCE.REG_TYPE,
				TARGET.AMT_01 = SOURCE.AMT_01,
				TARGET.AMT_02 = SOURCE.AMT_02,
				TARGET.AMT_03 = SOURCE.AMT_03,
				TARGET.AMT_04 = SOURCE.AMT_04,
				TARGET.AMT_05 = SOURCE.AMT_05,
				TARGET.AMT_06 = SOURCE.AMT_06,
				TARGET.AMT_07 = SOURCE.AMT_07,
				TARGET.AMT_08 = SOURCE.AMT_08,
				TARGET.AMT_09 = SOURCE.AMT_09,
				TARGET.AMT_10 = SOURCE.AMT_10,
				TARGET.AMT_11 = SOURCE.AMT_11,
				TARGET.AMT_12 = SOURCE.AMT_12,
				TARGET.AMT_13 = SOURCE.AMT_13,
				TARGET.AMT_14 = SOURCE.AMT_14,
				TARGET.AMT_15 = SOURCE.AMT_15,
				TARGET.AMT_16 = SOURCE.AMT_16,
				TARGET.AMT_17 = SOURCE.AMT_17,
				TARGET.AMT_18 = SOURCE.AMT_18,
				TARGET.AMT_19 = SOURCE.AMT_19,
				TARGET.AMT_20 = SOURCE.AMT_20,
				TARGET.AMT_21 = SOURCE.AMT_21,
				TARGET.AMT_22 = SOURCE.AMT_22,
				TARGET.AMT_23 = SOURCE.AMT_23,
				TARGET.AMT_24 = SOURCE.AMT_24,
				TARGET.AMT_25 = SOURCE.AMT_25,
				TARGET.AMT_26 = SOURCE.AMT_26,
				TARGET.AMT_27 = SOURCE.AMT_27,
				TARGET.AMT_28 = SOURCE.AMT_28,
				TARGET.AMT_29 = SOURCE.AMT_29,
				TARGET.AMT_30 = SOURCE.AMT_30,
				TARGET.DTS_01 = SOURCE.DTS_01,
				TARGET.DTS_02 = SOURCE.DTS_02,
				TARGET.DTS_03 = SOURCE.DTS_03,
				TARGET.DTS_04 = SOURCE.DTS_04,
				TARGET.DTS_05 = SOURCE.DTS_05,
				TARGET.DTS_06 = SOURCE.DTS_06,
				TARGET.DTS_07 = SOURCE.DTS_07,
				TARGET.DTS_08 = SOURCE.DTS_08,
				TARGET.DTS_09 = SOURCE.DTS_09,
				TARGET.DTS_10 = SOURCE.DTS_10,
				TARGET.DTS_11 = SOURCE.DTS_11,
				TARGET.DTS_12 = SOURCE.DTS_12,
				TARGET.DTS_13 = SOURCE.DTS_13,
				TARGET.DTS_14 = SOURCE.DTS_14,
				TARGET.DTS_15 = SOURCE.DTS_15,
				TARGET.DTS_16 = SOURCE.DTS_16,
				TARGET.DTS_17 = SOURCE.DTS_17,
				TARGET.DTS_18 = SOURCE.DTS_18,
				TARGET.DTS_19 = SOURCE.DTS_19,
				TARGET.DTS_20 = SOURCE.DTS_20,
				TARGET.TXT_01 = SOURCE.TXT_01,
				TARGET.TXT_02 = SOURCE.TXT_02,
				TARGET.TXT_03 = SOURCE.TXT_03,
				TARGET.TXT_04 = SOURCE.TXT_04,
				TARGET.TXT_05 = SOURCE.TXT_05,
				TARGET.TXT_06 = SOURCE.TXT_06,
				TARGET.TXT_07 = SOURCE.TXT_07,
				TARGET.TXT_08 = SOURCE.TXT_08,
				TARGET.TXT_09 = SOURCE.TXT_09,
				TARGET.TXT_10 = SOURCE.TXT_10,
				TARGET.TXT_11 = SOURCE.TXT_11,
				TARGET.TXT_12 = SOURCE.TXT_12,
				TARGET.TXT_13 = SOURCE.TXT_13,
				TARGET.TXT_14 = SOURCE.TXT_14,
				TARGET.TXT_15 = SOURCE.TXT_15,
				TARGET.TXT_16 = SOURCE.TXT_16,
				TARGET.TXT_17 = SOURCE.TXT_17,
				TARGET.TXT_18 = SOURCE.TXT_18,
				TARGET.TXT_19 = SOURCE.TXT_19,
				TARGET.TXT_20 = SOURCE.TXT_20,
				TARGET.TXT_21 = SOURCE.TXT_21,
				TARGET.TXT_22 = SOURCE.TXT_22,
				TARGET.TXT_23 = SOURCE.TXT_23,
				TARGET.TXT_24 = SOURCE.TXT_24,
				TARGET.TXT_25 = SOURCE.TXT_25,
				TARGET.TXT_26 = SOURCE.TXT_26,
				TARGET.TXT_27 = SOURCE.TXT_27,
				TARGET.TXT_28 = SOURCE.TXT_28,
				TARGET.TXT_29 = SOURCE.TXT_29,
				TARGET.TXT_30 = SOURCE.TXT_30,
				TARGET.TXT_31 = SOURCE.TXT_31,
				TARGET.TXT_32 = SOURCE.TXT_32,
				TARGET.TXT_33 = SOURCE.TXT_33,
				TARGET.TXT_34 = SOURCE.TXT_34,
				TARGET.TXT_35 = SOURCE.TXT_35,
				TARGET.TXT_36 = SOURCE.TXT_36,
				TARGET.TXT_37 = SOURCE.TXT_37,
				TARGET.TXT_38 = SOURCE.TXT_38,
				TARGET.TXT_39 = SOURCE.TXT_39,
				TARGET.TXT_40 = SOURCE.TXT_40,
				TARGET.TXT_41 = SOURCE.TXT_41,
				TARGET.TXT_42 = SOURCE.TXT_42,
				TARGET.TXT_43 = SOURCE.TXT_43,
				TARGET.TXT_44 = SOURCE.TXT_44,
				TARGET.TXT_45 = SOURCE.TXT_45,
				TARGET.TXT_46 = SOURCE.TXT_46,
				TARGET.TXT_47 = SOURCE.TXT_47,
				TARGET.TXT_48 = SOURCE.TXT_48,
				TARGET.TXT_49 = SOURCE.TXT_49,
				TARGET.TXT_50 = SOURCE.TXT_50,
				TARGET.ISSUE_CLASS = SOURCE.ISSUE_CLASS,
				TARGET.ISSUE_TYPE = SOURCE.ISSUE_TYPE,
				TARGET.MSTR_REG_ACCT_CODE = SOURCE.MSTR_REG_ACCT_CODE,
				TARGET.PU_NEEDED = SOURCE.PU_NEEDED,
				TARGET.PU_DATE = SOURCE.PU_DATE,
				TARGET.PU_TIME = SOURCE.PU_TIME,
				TARGET.PU_LOC_FROM = SOURCE.PU_LOC_FROM,
				TARGET.PU_LOC_TO = SOURCE.PU_LOC_TO,
				TARGET.PU_REFERENCE = SOURCE.PU_REFERENCE,
				TARGET.DO_NEEDED = SOURCE.DO_NEEDED,
				TARGET.DO_DATE = SOURCE.DO_DATE,
				TARGET.DO_TIME = SOURCE.DO_TIME,
				TARGET.DO_LOC_FROM = SOURCE.DO_LOC_FROM,
				TARGET.DO_LOC_TO = SOURCE.DO_LOC_TO,
				TARGET.DO_REFERENCE = SOURCE.DO_REFERENCE,
				TARGET.ROOM_SHARING = SOURCE.ROOM_SHARING,
				TARGET.PREF_ROOMMATE = SOURCE.PREF_ROOMMATE,
				TARGET.ROOMMATE_ACCT = SOURCE.ROOMMATE_ACCT,
				TARGET.AR_MODE = SOURCE.AR_MODE,
				TARGET.AR_DATE = SOURCE.AR_DATE,
				TARGET.AR_TIME = SOURCE.AR_TIME,
				TARGET.AR_LOC_FROM = SOURCE.AR_LOC_FROM,
				TARGET.AR_LOC_TO = SOURCE.AR_LOC_TO,
				TARGET.AR_REFERENCE = SOURCE.AR_REFERENCE,
				TARGET.AR_TRANS_NEED = SOURCE.AR_TRANS_NEED,
				TARGET.AR_TRANS_MODE = SOURCE.AR_TRANS_MODE,
				TARGET.AR_STATUS = SOURCE.AR_STATUS,
				TARGET.DP_MODE = SOURCE.DP_MODE,
				TARGET.DP_DATE = SOURCE.DP_DATE,
				TARGET.DP_TIME = SOURCE.DP_TIME,
				TARGET.DP_LOC_FROM = SOURCE.DP_LOC_FROM,
				TARGET.DP_LOC_TO = SOURCE.DP_LOC_TO,
				TARGET.DP_REFERENCE = SOURCE.DP_REFERENCE,
				TARGET.DP_TRANS_NEED = SOURCE.DP_TRANS_NEED,
				TARGET.DP_TRANS_MODE = SOURCE.DP_TRANS_MODE,
				TARGET.DP_STATUS = SOURCE.DP_STATUS,
				TARGET.BLOCK_CODE = SOURCE.BLOCK_CODE,
				TARGET.EVT_REG_SEQ = SOURCE.EVT_REG_SEQ,
				TARGET.APPR_LEVEL = SOURCE.APPR_LEVEL,
				TARGET.APPR_ACTION = SOURCE.APPR_ACTION,
				TARGET.APPR_USER_ID = SOURCE.APPR_USER_ID,
				TARGET.APPR_STAMP = SOURCE.APPR_STAMP

			WHEN NOT MATCHED BY TARGET THEN INSERT (

				ORG_CODE,
				REG_SEQ,
				EVT_ID,
				FUNC_ID,
				REG_CONTACT,
				STATUS,
				PRT_STATUS,
				CANCEL_DATE_ISO,
				CANCEL_TIME,
				CANCEL_USER_ID,
				CANCEL_BY,
				CANCEL_REASON,
				ORD_LINE,
				STATUS_2,
				REG_ACCT,
				STATUS_AT_PRINT,
				RM_NBR,
				ARR_DATE,
				ARR_TIME,
				ARR_VIA,
				ARR_LOC,
				ARR_PICKUP_TIME,
				ARR_PICKUP_DATE,
				ARR_PICKUP_LOC,
				ARR_TRANSPORTATION,
				DEP_DATE,
				DEP_TIME,
				DEP_VIA,
				DEP_LOCATION,
				DEP_PICKUP_DATE,
				DEP_PICKUP_TIME,
				DEP_PICKUP_LOC,
				DEP_TRANSPORTATION,
				LOCAL_TRANSPORTATION,
				FILL_092,
				FILL_1X,
				FILL_1X2,
				FILL_1X3,
				FILL_20X,
				FILL_20X2,
				FILL_20X3,
				FILL_6X,
				FILL_6X2,
				FILL_6X4,
				FILL_6X5,
				FILL_10X,
				FILL_072,
				FILL_30X,
				USER_PROFILE,
				ENT_DATE_ISO,
				ENT_TIME_ISO,
				ENT_USER_ID,
				UPD_DATE_ISO,
				UPD_TIME_ISO,
				UPD_USER_ID,
				ACCUM_EVT_ID,
				ACCUM_FUNC_ID,
				ACCUM_PHASE,
				ACCUM_RES_SEQ,
				DEL_MARK,
				USER_8X1,
				USER_8X2,
				USER_8X3,
				USER_10X,
				ORD_NBR,
				ORD_TYPE,
				ORD_ACCT,
				PRI_ACCT,
				SEC_ACCT,
				PRT_CONF,
				CO_NAME,
				CHKIN_STAMP,
				CHKIN_USER,
				REG_TYPE,
				AMT_01,
				AMT_02,
				AMT_03,
				AMT_04,
				AMT_05,
				AMT_06,
				AMT_07,
				AMT_08,
				AMT_09,
				AMT_10,
				AMT_11,
				AMT_12,
				AMT_13,
				AMT_14,
				AMT_15,
				AMT_16,
				AMT_17,
				AMT_18,
				AMT_19,
				AMT_20,
				AMT_21,
				AMT_22,
				AMT_23,
				AMT_24,
				AMT_25,
				AMT_26,
				AMT_27,
				AMT_28,
				AMT_29,
				AMT_30,
				DTS_01,
				DTS_02,
				DTS_03,
				DTS_04,
				DTS_05,
				DTS_06,
				DTS_07,
				DTS_08,
				DTS_09,
				DTS_10,
				DTS_11,
				DTS_12,
				DTS_13,
				DTS_14,
				DTS_15,
				DTS_16,
				DTS_17,
				DTS_18,
				DTS_19,
				DTS_20,
				TXT_01,
				TXT_02,
				TXT_03,
				TXT_04,
				TXT_05,
				TXT_06,
				TXT_07,
				TXT_08,
				TXT_09,
				TXT_10,
				TXT_11,
				TXT_12,
				TXT_13,
				TXT_14,
				TXT_15,
				TXT_16,
				TXT_17,
				TXT_18,
				TXT_19,
				TXT_20,
				TXT_21,
				TXT_22,
				TXT_23,
				TXT_24,
				TXT_25,
				TXT_26,
				TXT_27,
				TXT_28,
				TXT_29,
				TXT_30,
				TXT_31,
				TXT_32,
				TXT_33,
				TXT_34,
				TXT_35,
				TXT_36,
				TXT_37,
				TXT_38,
				TXT_39,
				TXT_40,
				TXT_41,
				TXT_42,
				TXT_43,
				TXT_44,
				TXT_45,
				TXT_46,
				TXT_47,
				TXT_48,
				TXT_49,
				TXT_50,
				ISSUE_CLASS,
				ISSUE_TYPE,
				MSTR_REG_ACCT_CODE,
				PU_NEEDED,
				PU_DATE,
				PU_TIME,
				PU_LOC_FROM,
				PU_LOC_TO,
				PU_REFERENCE,
				DO_NEEDED,
				DO_DATE,
				DO_TIME,
				DO_LOC_FROM,
				DO_LOC_TO,
				DO_REFERENCE,
				ROOM_SHARING,
				PREF_ROOMMATE,
				ROOMMATE_ACCT,
				AR_MODE,
				AR_DATE,
				AR_TIME,
				AR_LOC_FROM,
				AR_LOC_TO,
				AR_REFERENCE,
				AR_TRANS_NEED,
				AR_TRANS_MODE,
				AR_STATUS,
				DP_MODE,
				DP_DATE,
				DP_TIME,
				DP_LOC_FROM,
				DP_LOC_TO,
				DP_REFERENCE,
				DP_TRANS_NEED,
				DP_TRANS_MODE,
				DP_STATUS,
				BLOCK_CODE,
				EVT_REG_SEQ,
				APPR_LEVEL,
				APPR_ACTION,
				APPR_USER_ID,
				APPR_STAMP )

			VALUES (
				SOURCE.ORG_CODE,
				SOURCE.REG_SEQ,
				SOURCE.EVT_ID,
				SOURCE.FUNC_ID,
				SOURCE.REG_CONTACT,
				SOURCE.STATUS,
				SOURCE.PRT_STATUS,
				SOURCE.CANCEL_DATE_ISO,
				SOURCE.CANCEL_TIME,
				SOURCE.CANCEL_USER_ID,
				SOURCE.CANCEL_BY,
				SOURCE.CANCEL_REASON,
				SOURCE.ORD_LINE,
				SOURCE.STATUS_2,
				SOURCE.REG_ACCT,
				SOURCE.STATUS_AT_PRINT,
				SOURCE.RM_NBR,
				SOURCE.ARR_DATE,
				SOURCE.ARR_TIME,
				SOURCE.ARR_VIA,
				SOURCE.ARR_LOC,
				SOURCE.ARR_PICKUP_TIME,
				SOURCE.ARR_PICKUP_DATE,
				SOURCE.ARR_PICKUP_LOC,
				SOURCE.ARR_TRANSPORTATION,
				SOURCE.DEP_DATE,
				SOURCE.DEP_TIME,
				SOURCE.DEP_VIA,
				SOURCE.DEP_LOCATION,
				SOURCE.DEP_PICKUP_DATE,
				SOURCE.DEP_PICKUP_TIME,
				SOURCE.DEP_PICKUP_LOC,
				SOURCE.DEP_TRANSPORTATION,
				SOURCE.LOCAL_TRANSPORTATION,
				SOURCE.FILL_092,
				SOURCE.FILL_1X,
				SOURCE.FILL_1X2,
				SOURCE.FILL_1X3,
				SOURCE.FILL_20X,
				SOURCE.FILL_20X2,
				SOURCE.FILL_20X3,
				SOURCE.FILL_6X,
				SOURCE.FILL_6X2,
				SOURCE.FILL_6X4,
				SOURCE.FILL_6X5,
				SOURCE.FILL_10X,
				SOURCE.FILL_072,
				SOURCE.FILL_30X,
				SOURCE.USER_PROFILE,
				SOURCE.ENT_DATE_ISO,
				SOURCE.ENT_TIME_ISO,
				SOURCE.ENT_USER_ID,
				SOURCE.UPD_DATE_ISO,
				SOURCE.UPD_TIME_ISO,
				SOURCE.UPD_USER_ID,
				SOURCE.ACCUM_EVT_ID,
				SOURCE.ACCUM_FUNC_ID,
				SOURCE.ACCUM_PHASE,
				SOURCE.ACCUM_RES_SEQ,
				SOURCE.DEL_MARK,
				SOURCE.USER_8X1,
				SOURCE.USER_8X2,
				SOURCE.USER_8X3,
				SOURCE.USER_10X,
				SOURCE.ORD_NBR,
				SOURCE.ORD_TYPE,
				SOURCE.ORD_ACCT,
				SOURCE.PRI_ACCT,
				SOURCE.SEC_ACCT,
				SOURCE.PRT_CONF,
				SOURCE.CO_NAME,
				SOURCE.CHKIN_STAMP,
				SOURCE.CHKIN_USER,
				SOURCE.REG_TYPE,
				SOURCE.AMT_01,
				SOURCE.AMT_02,
				SOURCE.AMT_03,
				SOURCE.AMT_04,
				SOURCE.AMT_05,
				SOURCE.AMT_06,
				SOURCE.AMT_07,
				SOURCE.AMT_08,
				SOURCE.AMT_09,
				SOURCE.AMT_10,
				SOURCE.AMT_11,
				SOURCE.AMT_12,
				SOURCE.AMT_13,
				SOURCE.AMT_14,
				SOURCE.AMT_15,
				SOURCE.AMT_16,
				SOURCE.AMT_17,
				SOURCE.AMT_18,
				SOURCE.AMT_19,
				SOURCE.AMT_20,
				SOURCE.AMT_21,
				SOURCE.AMT_22,
				SOURCE.AMT_23,
				SOURCE.AMT_24,
				SOURCE.AMT_25,
				SOURCE.AMT_26,
				SOURCE.AMT_27,
				SOURCE.AMT_28,
				SOURCE.AMT_29,
				SOURCE.AMT_30,
				SOURCE.DTS_01,
				SOURCE.DTS_02,
				SOURCE.DTS_03,
				SOURCE.DTS_04,
				SOURCE.DTS_05,
				SOURCE.DTS_06,
				SOURCE.DTS_07,
				SOURCE.DTS_08,
				SOURCE.DTS_09,
				SOURCE.DTS_10,
				SOURCE.DTS_11,
				SOURCE.DTS_12,
				SOURCE.DTS_13,
				SOURCE.DTS_14,
				SOURCE.DTS_15,
				SOURCE.DTS_16,
				SOURCE.DTS_17,
				SOURCE.DTS_18,
				SOURCE.DTS_19,
				SOURCE.DTS_20,
				SOURCE.TXT_01,
				SOURCE.TXT_02,
				SOURCE.TXT_03,
				SOURCE.TXT_04,
				SOURCE.TXT_05,
				SOURCE.TXT_06,
				SOURCE.TXT_07,
				SOURCE.TXT_08,
				SOURCE.TXT_09,
				SOURCE.TXT_10,
				SOURCE.TXT_11,
				SOURCE.TXT_12,
				SOURCE.TXT_13,
				SOURCE.TXT_14,
				SOURCE.TXT_15,
				SOURCE.TXT_16,
				SOURCE.TXT_17,
				SOURCE.TXT_18,
				SOURCE.TXT_19,
				SOURCE.TXT_20,
				SOURCE.TXT_21,
				SOURCE.TXT_22,
				SOURCE.TXT_23,
				SOURCE.TXT_24,
				SOURCE.TXT_25,
				SOURCE.TXT_26,
				SOURCE.TXT_27,
				SOURCE.TXT_28,
				SOURCE.TXT_29,
				SOURCE.TXT_30,
				SOURCE.TXT_31,
				SOURCE.TXT_32,
				SOURCE.TXT_33,
				SOURCE.TXT_34,
				SOURCE.TXT_35,
				SOURCE.TXT_36,
				SOURCE.TXT_37,
				SOURCE.TXT_38,
				SOURCE.TXT_39,
				SOURCE.TXT_40,
				SOURCE.TXT_41,
				SOURCE.TXT_42,
				SOURCE.TXT_43,
				SOURCE.TXT_44,
				SOURCE.TXT_45,
				SOURCE.TXT_46,
				SOURCE.TXT_47,
				SOURCE.TXT_48,
				SOURCE.TXT_49,
				SOURCE.TXT_50,
				SOURCE.ISSUE_CLASS,
				SOURCE.ISSUE_TYPE,
				SOURCE.MSTR_REG_ACCT_CODE,
				SOURCE.PU_NEEDED,
				SOURCE.PU_DATE,
				SOURCE.PU_TIME,
				SOURCE.PU_LOC_FROM,
				SOURCE.PU_LOC_TO,
				SOURCE.PU_REFERENCE,
				SOURCE.DO_NEEDED,
				SOURCE.DO_DATE,
				SOURCE.DO_TIME,
				SOURCE.DO_LOC_FROM,
				SOURCE.DO_LOC_TO,
				SOURCE.DO_REFERENCE,
				SOURCE.ROOM_SHARING,
				SOURCE.PREF_ROOMMATE,
				SOURCE.ROOMMATE_ACCT,
				SOURCE.AR_MODE,
				SOURCE.AR_DATE,
				SOURCE.AR_TIME,
				SOURCE.AR_LOC_FROM,
				SOURCE.AR_LOC_TO,
				SOURCE.AR_REFERENCE,
				SOURCE.AR_TRANS_NEED,
				SOURCE.AR_TRANS_MODE,
				SOURCE.AR_STATUS,
				SOURCE.DP_MODE,
				SOURCE.DP_DATE,
				SOURCE.DP_TIME,
				SOURCE.DP_LOC_FROM,
				SOURCE.DP_LOC_TO,
				SOURCE.DP_REFERENCE,
				SOURCE.DP_TRANS_NEED,
				SOURCE.DP_TRANS_MODE,
				SOURCE.DP_STATUS,
				SOURCE.BLOCK_CODE,
				SOURCE.EVT_REG_SEQ,
				SOURCE.APPR_LEVEL,
				SOURCE.APPR_ACTION,
				SOURCE.APPR_USER_ID,
				SOURCE.APPR_STAMP )

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
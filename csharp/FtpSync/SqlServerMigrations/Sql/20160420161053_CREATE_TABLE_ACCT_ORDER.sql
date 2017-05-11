CREATE TABLE [dbo].[ACCT_ORDER]
(
	[ORG_CODE] [nvarchar](2) NOT NULL,
	[ORD_NBR] [int] NOT NULL,
	[SO_SEARCH] [nvarchar](9) NULL,
	[EVT_ID] [int] NULL
		CONSTRAINT [DF_ACCT_ORDER_EVT_ID] DEFAULT (0),
	[ORD_TYPE] [nvarchar](2) NULL,
	[FUNC_ID] [int] NULL,
	[EVT_SEARCH] [nvarchar](7) NULL,
	[FUNC_SEARCH] [nvarchar](7) NULL,
	[ORD_FORM] [nvarchar](2) NULL,
	[ORD_DATE] [datetime] NULL,
	[ORD_STS] [nchar](1) NULL,
	[PRT_STS] [nchar](1) NULL,
	[MET_NOTIFY] [nvarchar](4) NULL,
	[CANCEL_DATE] [datetime] NULL,
	[CANCEL_USER] [nvarchar](10) NULL,
	[CANCEL_BY] [nvarchar](30) NULL,
	[CANCEL_REASON] [nvarchar](2) NULL,
	[PO_NBR] [nvarchar](150) NULL,
	[PRICE_LIST] [nvarchar](10) NULL,
	[PRICE_COLUMN] [nchar](1) NULL,
	[ARR_DATE] [datetime] NULL,
	[ARR_TIME] [datetime] NULL,
	[DEP_DATE] [datetime] NULL,
	[DEP_TIME] [datetime] NULL,
	[BLOCK_CDE] [nvarchar](6) NULL,
	[PROP_CODE] [nvarchar](8) NULL,
	[RM_TYPE] [nvarchar](2) NULL,
	[RM_PRICE_CDE] [nchar](1) NULL,
	[NBR_RMS] [int] NULL,
	[COMP_DATE] [datetime] NULL,
	[COMP_TIME] [datetime] NULL,
	[COMP_USER] [nvarchar](10) NULL,
	[RES_FUNC_ID] [int] NULL,
	[RES_PHASE] [nchar](1) NULL,
	[RES_SEQ] [int] NULL,
	[NBR_PERS] [int] NULL,
	[ACCT_ISSUE] [int] NULL,
	[BATCH] [nvarchar](10) NULL,
	[ORD_ACCT] [nvarchar](8) NULL,
	[ORD_CONTACT] [nvarchar](8) NULL,
	[BILL_TO_CUST] [nvarchar](8) NULL,
	[BILL_TO_CONT] [nvarchar](8) NULL,
	[ORD_TOT] [numeric](11, 2) NULL
		CONSTRAINT [DF_ACCT_ORDER_ORD_TOT] DEFAULT (0),
	[ORD_TAX] [numeric](11, 2) NULL
		CONSTRAINT [DF_ACCT_ORDER_ORD_TAX] DEFAULT (0),
	[ORD_DUE] [numeric](11, 2) NULL
		CONSTRAINT [DF_ACCT_ORDER_ORD_DUE] DEFAULT (0),
	[ACT_TOTAL] [numeric](11, 2) NULL
		CONSTRAINT [DF_ACCT_ORDER_ACT_TOTAL] DEFAULT (0),
	[ACT_TAX] [numeric](11, 2) NULL
		CONSTRAINT [DF_ACCT_ORDER_ACT_TAX] DEFAULT (0),
	[ACT_DUE] [numeric](11, 2) NULL
		CONSTRAINT [DF_ACCT_ORDER_ACT_DUE] DEFAULT (0),
	[ACT_PAYMENTS] [numeric](11, 2) NULL
		CONSTRAINT [DF_ACCT_ORDER_ACT_PAYMENTS] DEFAULT (0),
	[ACT_CREDITS] [numeric](11, 2) NULL
		CONSTRAINT [DF_ACCT_ORDER_ACT_CREDITS] DEFAULT (0),
	[ORD_CREDITS] [numeric](11, 2) NULL
		CONSTRAINT [DF_ACCT_ORDER_ORD_CREDITS] DEFAULT (0),
	[COMMENT] [nvarchar](60) NULL,
	[ACT_INACT] [nchar](1) NULL,
	[PRT_FLAG] [nchar](1) NULL,
	[AMT_DUE_IND] [nchar](1) NULL,
	[SETUP_ID] [nvarchar](8) NULL,
	[BOOTH_NBR] [nvarchar](max) NULL,
	[ORD_DESC] [nvarchar](40) NULL,
	[ORD_SPACE] [nvarchar](6) NULL,
	[ORD_STS_1] [nchar](1) NULL,
	[ORD_STS_2] [nchar](1) NULL,
	[INTERNAL] [nchar](1) NULL,
	[ENT_DATE_ISO] [datetime] NULL,
	[ENT_USER_ID] [nvarchar](10) NULL,
	[UPD_DATE_ISO] [datetime] NULL,
	[UPD_USER_ID] [nvarchar](10) NULL,
	[DEL_MARK] [nchar](1) NULL,
	[XTRA_ACCT] [nvarchar](8) NULL,
	[USER_8X] [nvarchar](8) NULL,
	[USER_10X] [nvarchar](10) NULL,
	[USER_DATE] [datetime] NULL,
	[ORDER_DESIG] [nchar](1) NULL,
	[ORDER_TERMS] [nvarchar](2) NULL,
	[SHIP_METHOD] [nvarchar](3) NULL,
	[USER_6X] [nvarchar](6) NULL,
	[USER_8X2] [nvarchar](8) NULL,
	[USER_10X2] [nvarchar](10) NULL,
	[SO_PRT] [nchar](1) NULL,
	[PARENT_FUNC] [int] NULL,
	[REQ_CUST] [nvarchar](8) NULL,
	[SO_USER_SEQ] [nvarchar](4) NULL,
	[SO_FUNC_SEQ] [int] NULL,
	[SHIP_DOC_ID] [nvarchar](40) NULL,
	[SETUP_QTY] [numeric](7, 2) NULL,
	[SO_ACT_INACT] [nchar](1) NULL,
	[SHORT_NOTE] [nvarchar](60) NULL,
	[SO_STATUS] [nvarchar](2) NULL,
	[USER_8X1] [nvarchar](8) NULL,
	[USER_8X3] [nvarchar](8) NULL,
	[CONF_ALL_REGIS] [nchar](1) NULL,
	[REQ_CONTACT] [nvarchar](8) NULL,
	[BILL_CYCLE] [nchar](1) NULL,
	[DUES_CYCLE] [nchar](1) NULL,
	[RENEWAL_DATE] [datetime] NULL,
	[CYCLE_DATE] [datetime] NULL,
	[BKG_ORDER] [nchar](1) NULL,
	[TRANS_SOURCE] [nvarchar](2) NULL,
	[INVOICE] [int] NULL
		CONSTRAINT [DF_ACCT_ORDER_INVOICE] DEFAULT (0),
	[ORD_SIGN] [nchar](1) NULL,
	[ORD_DAYS] [int] NULL,
	[TEMPLATE] [nchar](1) NULL,
	[WO_CLOSED] [nchar](1) NULL,
	[WO_DUE_DATE] [datetime] NULL,
	[WO_RUSH] [nchar](1) NULL,
	[CURRENCY] [nvarchar](3) NULL
		CONSTRAINT [DF_ACCT_ORDER_CURRENCY] DEFAULT ('***'),
	[FC_ORD_TOT] [numeric](11, 2) NULL
		CONSTRAINT [DF_ACCT_ORDER_FC_ORD_TOT] DEFAULT (0),
	[FC_ORD_TAX] [numeric](11, 2) NULL
		CONSTRAINT [DF_ACCT_ORDER_FC_ORD_TAX] DEFAULT (0),
	[FC_ORD_DUE] [numeric](11, 2) NULL
		CONSTRAINT [DF_ACCT_ORDER_FC_ORD_DUE] DEFAULT (0),
	[FC_ACT_TOT] [numeric](11, 2) NULL
		CONSTRAINT [DF_ACCT_ORDER_FC_ACT_TOT] DEFAULT (0),
	[FC_ACT_DUE] [numeric](11, 2) NULL
		CONSTRAINT [DF_ACCT_ORDER_FC_ACT_DUE] DEFAULT (0),
	[FC_ACT_PAYMENTS] [numeric](11, 2) NULL
		CONSTRAINT [DF_ACCT_ORDER_FC_ACT_PAYMENTS] DEFAULT (0),
	[FC_ACT_CREDITS] [numeric](11, 2) NULL
		CONSTRAINT [DF_ACCT_ORDER_FC_ACT_CREDITS] DEFAULT (0),
	[FC_ORD_CREDITS] [numeric](11, 2) NULL
		CONSTRAINT [DF_ACCT_ORDER_FC_ORD_CREDITS] DEFAULT (0),
	[FC_ACT_TAX] [numeric](11, 2) NULL
		CONSTRAINT [DF_ACCT_ORDER_FC_ACT_TAX] DEFAULT (0),
	[WO_TIME_OFFSET] [nvarchar](1) NULL,
	[WO_SIGN] [nvarchar](1) NULL,
	[WO_DAYS] [int] NULL,
	[WO_END_STAMP] [datetime] NULL,
	[PL_CURRENCY] [nvarchar](3) NULL,
	[TR_CURRENCY] [nvarchar](3) NULL,
	[TRLC_RATE] [numeric](12, 5) NULL,
	[TRFC_RATE] [numeric](12, 5) NULL,
	[TRPL_RATE] [numeric](12, 5) NULL,
	[TAXABLE] [nchar](1) NULL,
	[TR_ORD_TOT] [numeric](13, 4) NULL,
	[TR_ORD_TAX] [numeric](13, 4) NULL,
	[TR_ORD_CREDITS] [numeric](13, 4) NULL,
	[TR_ORD_DUE] [numeric](13, 4) NULL,
	[TR_ACT_TOT] [numeric](13, 4) NULL,
	[TR_ACT_TAX] [numeric](13, 4) NULL,
	[TR_ACT_CREDITS] [numeric](13, 4) NULL,
	[TR_ACT_DUE] [numeric](13, 4) NULL,
	[TR_ACT_PAYMENTS] [numeric](13, 4) NULL,
	[PL_ORD_TOT] [numeric](13, 4) NULL,
	[PL_ORD_TAX] [numeric](13, 4) NULL,
	[PL_ORD_CREDITS] [numeric](13, 4) NULL,
	[PL_ORD_DUE] [numeric](13, 4) NULL,
	[PL_ACT_TOT] [numeric](13, 4) NULL,
	[PL_ACT_TAX] [numeric](13, 4) NULL,
	[PL_ACT_CREDITS] [numeric](13, 4) NULL,
	[PL_ACT_DUE] [numeric](13, 4) NULL,
	[PL_ACT_PAYMENTS] [numeric](13, 4) NULL,
	[ASSIGNMENT_NAME] [nvarchar](150) NULL,
	[PAY_PLAN_ID] [int] NULL,
	[PP_SCHED_CODE] [nvarchar](3) NULL,
	[NEW_STS] [nvarchar](2) NULL,
	[REPRINT] [nvarchar](1) NULL,
	[CONFIG_CODE] [nvarchar](12) NULL,
	[NG_ORD_CONTACT] [nvarchar](8) NULL,
	[NG_BTO_CONTACT] [nvarchar](8) NULL,
	[NG_REQ_CONTACT] [nvarchar](8) NULL,
	[ORD_ACCT_REP] [nvarchar](8) NULL,
	[ASGN_TOT_SIZE] [numeric](9, 2) NULL,
	[ASGN_OPEN_SIDES] [int] NULL,
	[ASGN_LENGTH] [numeric](9, 2) NULL,
	[ASGN_WIDTH] [numeric](9, 2) NULL,
	[PROMO_CODE] [nvarchar](20) NULL,
	[TAX_DETAIL] [nvarchar](1) NULL,
	[ALL_PRT] [nvarchar](1) NULL,
	[MULTI_ORG_ACCT] [nvarchar](20) NULL,
	[ALT_ASSIGN_NAME_1] [nvarchar](150) NULL,
	[ALT_ASSIGN_NAME_2] [nvarchar](150) NULL,
	[USER_REFERENCE] [nvarchar](30) NULL,
	[ORD_COST_TOTAL] [numeric](13, 4) NULL,
	[ACT_COST_TOTAL] [numeric](13, 4) NULL,
	[REF_INV_NBR] [int] NULL,
	[SHIPTO_ACCT] [nvarchar](8) NULL,
	[SHIPTO_CONT] [nvarchar](8) NULL,
	[ALT_ASSIGN_NAME_3] [nvarchar](150) NULL,
	[ALT_ASSIGN_NAME_4] [nvarchar](150) NULL,
	[ALT_ASSIGN_NAME_5] [nvarchar](150) NULL,
	[ASGN_TOT_DISP_SIZE] [numeric](13, 2) NULL,
	[CONTRACT_SEQ] [int] NULL,
	[ORD_GLACCT] [nvarchar](30) NULL,
	[NEAR_EXHIB] [nvarchar](255) NULL,
	[AWAY_EXHIB] [nvarchar](255) NULL,
	[COMPETITORS] [nvarchar](255) NULL,
	[PREF_ASSIGN] [nvarchar](255) NULL,
	[EXHIB_POINTS] [int] NULL,
	[EXHIB_MI] [datetime] NULL,
	[PAVILION] [nvarchar](255) NULL,
	[EXHIB_TXT_01] [nvarchar](255) NULL,
	[EXHIB_TXT_02] [nvarchar](255) NULL,
	[EXHIB_TXT_03] [nvarchar](255) NULL,
	[EXHIB_NBR_01] [numeric](13, 2) NULL,
	[EXHIB_NBR_02] [numeric](13, 2) NULL,
	[EXHIB_NBR_03] [numeric](13, 2) NULL,
	[EXHIB_DTM_01] [datetime] NULL,
	[EXHIB_DTM_02] [datetime] NULL,
	[EXHIB_DTM_03] [datetime] NULL,
	[OCCURRENCE] [int] NULL,
	[ORD_FIXED] [nvarchar](1) NULL,
	[ORD_REV_TRANS] [nvarchar](1) NULL,
	[COMM_ORDER] [nvarchar](1) NULL,
	[ORD_ADDR_SEQ] [int] NULL,
	[BILLTO_ADDR_SEQ] [int] NULL,
	[REQ_ADDR_SEQ] [int] NULL,
	[SHIPTO_ADDR_SEQ] [int] NULL,
	[OCCURENCE] [int] NULL,
	[MAIN_EXHIB_ORDER] [int] NULL,
	[PRJ_ID] [nvarchar](10) NULL,
	[ACCT_DESIG] [nvarchar](1) NULL,
	[GEN] [nvarchar](1) NULL,
	[TAX_DATE] [datetime] NULL,
	[AR_CONTROL] [nvarchar](10) NULL,
	[EXHIBITOR_ID] [int] NULL,
	[ENT_APP_TYPE] [int] NULL,
	[CUST_PAY_INFO] [nvarchar](255) NULL,
	[CUST_PAY_TYPE] [int] NULL,
	[DIVISION] [nvarchar](6) NULL,
	[EXHIB_ORD_NBR] [int] NULL,
	[BOOTH_ORDER] [nvarchar](1) NULL,
	[ORD_CAT_SEQ] [int] NULL,
	CONSTRAINT [PK_ACCT_ORDER] PRIMARY KEY CLUSTERED 
	(
		[ORD_NBR] ASC,
		[ORG_CODE] ASC
	)
);
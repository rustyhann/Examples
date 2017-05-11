CREATE TYPE [dbo].[TVP_EVENT_MASTER] AS TABLE
(
	[ORG_CODE] [nvarchar](2) NOT NULL,
	[EVT_ID] [int] NOT NULL,
	[EVT_SEARCH] [nvarchar](12) NULL,
	[EVT_DESC] [nvarchar](150) NULL,
	[EVT_DESIGNATION] [nchar](1) NOT NULL,
	[CONFIDENTIAL] [nchar](1) NOT NULL,
	[START_DATE] [int] NOT NULL,
	[END_DATE] [int] NOT NULL,
	[MI_DATE] [int] NOT NULL,
	[MO_DATE] [int] NOT NULL,
	[DECISION_DATE] [int] NOT NULL,
	[BOX_OFFICE] [nchar](1) NOT NULL,
	[INSUR_REQ] [nchar](1) NOT NULL,
	[INSUR_REC] [nchar](1) NOT NULL,
	[CONTRACT_STS] [nchar](1) NOT NULL,
	[CONTRACT_ID] [nvarchar](12) NOT NULL,
	[CM_FILE_NBR] [int] NOT NULL,
	[MTG_NBR] [int] NOT NULL,
	[MTG_START_DATE] [int] NOT NULL,
	[GROUP_NAME] [nvarchar](36) NOT NULL,
	[EST_REVENUE] [int] NOT NULL,
	[PLN_REVENUE] [int] NOT NULL,
	[ACT_REVENUE] [int] NOT NULL,
	[EST_ATTEND] [int] NOT NULL,
	[PLN_ATTEND] [int] NOT NULL,
	[ACT_ATTEND] [int] NOT NULL,
	[EST_COST] [int] NOT NULL,
	[PLN_COST] [int] NOT NULL,
	[ACT_COST] [int] NOT NULL,
	[BOOKED_BY] [nvarchar](25) NOT NULL,
	[BOOKING_TYPE] [nchar](1) NOT NULL,
	[PUBLIC_YN] [nchar](1) NOT NULL,
	[ON_SITE_OFFICE] [nvarchar](6) NOT NULL,
	[ON_SITE_PHONE] [nvarchar](25) NULL,
	[DURATION_CODE] [nvarchar](6) NOT NULL,
	[PRICE_LIST] [nvarchar](10) NOT NULL,
	[BKG_BOOK_DATE] [int] NOT NULL,
	[BKG_CHG_DATE] [int] NOT NULL,
	[BKG_CNCL_DATE] [int] NOT NULL,
	[EVT_CATEGORY] [nvarchar](5) NULL,
	[EVT_CLASS] [nvarchar](5) NULL,
	[EVT_TYPE] [nvarchar](5) NULL,
	[EVT_RANK] [nchar](1) NOT NULL,
	[EVT_STATUS] [nvarchar](2) NOT NULL,
	[SLSPER] [nvarchar](8) NULL,
	[COORD_1] [nvarchar](8) NULL,
	[COORD_2] [nvarchar](8) NULL,
	[CUST_NBR] [nvarchar](8) NULL,
	[CUST_SUB_NBR] [nvarchar](2) NOT NULL,
	[CUST_PO] [nvarchar](12) NOT NULL,
	[CUST_CNTCT_NAME] [nvarchar](30) NOT NULL,
	[CUST_PHONE] [nvarchar](12) NOT NULL,
	[UPD_DATE] [int] NOT NULL,
	[UPD_TIME] [int] NOT NULL,
	[UPD_USER_ID] [nvarchar](10) NOT NULL,
	[LAST_BILLED_DATE] [int] NOT NULL,
	[SLSPER_ORG] [nvarchar](2) NOT NULL,
	[CUST_ORG] [nvarchar](2) NOT NULL,
	[COORD1_ORG] [nvarchar](2) NOT NULL,
	[ECON_IMPACT_AMT] [int] NOT NULL,
	[RETAIN_PCT] [int] NOT NULL,
	[CONFLICT_STS] [nchar](1) NOT NULL,
	[EVT_CODE_1] [nvarchar](4) NOT NULL,
	[EVT_CODE_2] [nvarchar](4) NOT NULL,
	[DESC_1] [nvarchar](25) NOT NULL,
	[EVT_USR_CODE_1] [nvarchar](6) NOT NULL,
	[EVT_USR_ID] [nvarchar](10) NOT NULL,
	[SEQ_NBR] [int] NOT NULL,
	[EVT_GL] [nvarchar](9) NULL,
	[ADV_OFFSET] [nvarchar](1) NULL,
	[ADV_DAYS] [int] NULL,
	[BADGE_FMT] [nvarchar](2) NULL,
	[MAJ_GROUP] [nvarchar](4) NULL,
	[MIN_GROUP] [nvarchar](6) NULL,
	[ANCHOR_VENUE] [nvarchar](6) NULL,
	[EVT_GLACCT] [nvarchar](30) NULL,
	[BDG_VOIDS] [int] NULL,
	[CANCEL_STAMP] [datetime] NULL,
	[CANCEL_USER_ID] [nvarchar](10) NULL,
	[CANCEL_REASON] [nvarchar](2) NULL,
	[ORD_ATT_INDIC] [nvarchar](5) NULL,
	[ACT_ATT_INDIC] [nvarchar](5) NULL,
	[RVS_REVENUE] [int] NULL,
	[RVS_COST] [int] NULL,
	[RVS_ATTEND] [int] NULL,
	[RVS_OTHER] [numeric](9, 2) NULL,
	[FOR_ATT_INDIC] [nvarchar](5) NULL,
	[RVS_ATT_INDIC] [nvarchar](5) NULL,
	[CAD_NAME] [nvarchar](20) NULL,
	[SENSITIVITY] [nvarchar](1) NULL,
	[CANCEL_APPL] [nvarchar](2) NULL,
	[ALT_EVT_DESC] [nvarchar](150) NULL,
	[ALT_LEGAL_NAME] [nvarchar](255) NULL,
	[BKG_ENT_STAMP] [datetime] NULL,
	[BKG_ENT_USER] [nvarchar](10) NULL,
	[BKG_CHG_STAMP] [datetime] NULL,
	[BKG_CHG_USER] [nvarchar](10) NULL,
	[EVT_COORD3] [nvarchar](8) NULL,
	[EVT_COORD4] [nvarchar](8) NULL,
	[WEB_ADDRESS] [nvarchar](255) NULL,
	[MASTER_EVT] [int] NULL,
	[PREV_EVT] [int] NULL,
	[ALT_EVT_DESC2] [nvarchar](150) NULL,
	[ALT_LEGAL_NAME2] [nvarchar](255) NULL,
	[NG_EVT_CONTACT] [nvarchar](8) NULL,
	[NG_BILLTO_CONTACT] [nvarchar](8) NULL,
	[GLAA_CODE_01] [nvarchar](15) NULL,
	[GLAA_CODE_02] [nvarchar](15) NULL,
	[GLAA_CODE_03] [nvarchar](15) NULL,
	[GLAA_CODE_04] [nvarchar](15) NULL,
	[GLAA_CODE_05] [nvarchar](15) NULL,
	[GLAA_CODE_06] [nvarchar](15) NULL,
	[GLAA_CODE_07] [nvarchar](15) NULL,
	[GLAA_CODE_08] [nvarchar](15) NULL,
	[GLAA_CODE_09] [nvarchar](15) NULL,
	[USE_GL_SUBS] [nvarchar](1) NULL,
	[GLAA_OPER] [nvarchar](2) NULL,
	[UPD_STAMP] [datetime] NULL,
	[ENT_STAMP] [datetime] NULL,
	[RVS_ATT_SYNC] [nvarchar](1) NULL,
	[ORD_ATT_SYNC] [nvarchar](1) NULL,
	[ACT_ATT_SYNC] [nvarchar](1) NULL,
	[HSG_STDATE] [datetime] NULL,
	[HSG_ENDATE] [datetime] NULL,
	[HSG_CUTOFF] [datetime] NULL,
	[HSG_OFFICE] [nvarchar](8) NULL,
	[HSG_HQ_HOTEL] [nvarchar](8) NULL,
	[HSG_FLAG] [nvarchar](1) NULL,
	[MI_OFFSET_HRS] [decimal](7, 2) NULL,
	[ST_OFFSET_HRS] [decimal](7, 2) NULL,
	[EN_OFFSET_HRS] [decimal](7, 2) NULL,
	[MO_OFFSET_HRS] [decimal](7, 2) NULL,
	[BADGE_XML] [nvarchar](4000) NULL,
	[REG_PAY_SCHED] [nvarchar](3) NULL,
	[REG_PRLIST] [nvarchar](10) NULL,
	[MULTI_ORG_ACCT] [nvarchar](20) NULL,
	[ALT_EVT] [int] NULL,
	[REG_ADV_CUTOFF] [datetime] NULL,
	[REG_STD_CUTOFF] [datetime] NULL,
	[REGST_ISS_CLS] [nvarchar](1) NULL,
	[REGST_ISS_TYP] [nvarchar](2) NULL,
	[REG_ADV_OFFSET] [nvarchar](1) NULL,
	[REG_ADV_DAYS] [int] NULL,
	[REG_STD_OFFSET] [nvarchar](1) NULL,
	[REG_STD_DAYS] [int] NULL,
	[EVT_IN_DATE] [datetime] NULL,
	[EVT_IN_TIME] [datetime] NULL,
	[EVT_START_DATE] [datetime] NULL,
	[EVT_START_TIME] [datetime] NULL,
	[EVT_END_DATE] [datetime] NULL,
	[EVT_END_TIME] [datetime] NULL,
	[EVT_OUT_DATE] [datetime] NULL,
	[EVT_OUT_TIME] [datetime] NULL,
	[RELEASE_DATE] [datetime] NULL,
	[ADV_CUTOFF_DATE] [datetime] NULL,
	[EVT_ABBREV_NAME] [nvarchar](20) NULL,
	[EVT_LEGAL_NAME] [nvarchar](255) NULL,
	[EVT_INDICATOR] [nvarchar](2) NULL,
	[SO_ISSUE_CLASS] [nvarchar](1) NULL,
	[SO_ISSUE_TYPE] [nvarchar](2) NULL,
	[RG_ISSUE_CLASS] [nvarchar](1) NULL,
	[RG_ISSUE_TYPE] [nvarchar](2) NULL,
	[EVT_NOTE_1] [nvarchar](150) NULL,
	[EVT_NOTE_2] [nvarchar](150) NULL,
	[PROF_MI_SIGN] [nvarchar](1) NULL,
	[PROF_ST_SIGN] [nvarchar](1) NULL,
	[PROF_EN_SIGN] [nvarchar](1) NULL,
	[PROF_MO_SIGN] [nvarchar](1) NULL,
	[PROF_TIME_OFFSET] [nvarchar](1) NULL,
	[EVT_RELEASE_INDIC] [nvarchar](1) NULL,
	[PROF_MI_DAYS] [decimal](9, 2) NULL,
	[PROF_ST_DAYS] [decimal](9, 2) NULL,
	[PROF_EN_DAYS] [decimal](9, 2) NULL,
	[PROF_MO_DAYS] [decimal](9, 2) NULL,
	[BILLTO_ACCT] [nvarchar](8) NULL,
	[EVENT_DAYS] [decimal](6, 2) NULL,
	[EVT_LOGO] [varbinary](max) NULL,
	[MAX_TOPIC_LVL] [int] NULL,
	[EST_OTHER] [numeric](9, 2) NULL,
	[PLN_OTHER] [numeric](9, 2) NULL,
	[ACT_OTHER] [numeric](9, 2) NULL,
	[ALT_EVT_DESC3] [nvarchar](150) NULL,
	[ALT_EVT_DESC4] [nvarchar](150) NULL,
	[ALT_EVT_DESC5] [nvarchar](150) NULL,
	[ALT_LEGAL_NAME3] [nvarchar](255) NULL,
	[ALT_LEGAL_NAME4] [nvarchar](255) NULL,
	[ALT_LEGAL_NAME5] [nvarchar](255) NULL,
	[STD_CUTOFF_DATE] [datetime] NULL,
	[STD_OFFSET] [nvarchar](1) NULL,
	[STD_DAYS] [int] NULL,
	[DATE_FMT] [nvarchar](3) NULL,
	[TIME_FMT] [nvarchar](3) NULL,
	[RES_FMT] [nvarchar](3) NULL,
	[DECISION_DATE_ISO] [datetime] NULL,
	[CONFL_ORD_STS] [nvarchar](2) NULL,
	[EXH_PROD_SYNC] [nvarchar](1) NULL,
	[LOST_TO_VAL] [nvarchar](20) NULL,
	[UNSCHED_FLAG] [nvarchar](1) NULL,
	[DEF_PAY_SCHED] [nvarchar](3) NULL,
	[FIRM_DATE] [datetime] NULL,
	[ASSET_CODE] [nvarchar](12) NULL,
	[REQ_ACCT_CODE] [nvarchar](8) NULL,
	[REQ_CNTCT_CODE] [nvarchar](8) NULL,
	[FN_ISSUE_CLASS] [nvarchar](1) NULL,
	[FN_ISSUE_TYPE] [nvarchar](2) NULL,
	[REG_PICKUP_TYPE] [nvarchar](3) NULL,
	[REG_PU_STDATE] [datetime] NULL,
	[REG_PU_ENDATE] [datetime] NULL,
	[ALLOW_ROOMMATE] [nvarchar](1) NULL,
	[ENABLE_TRAVEL] [nvarchar](1) NULL,
	[ORD_ISS_CLASS] [nvarchar](1) NULL,
	[ORD_ISS_TYPE] [nvarchar](2) NULL,
	[PURGE_IND] [nvarchar](3) NULL,
	[PURGE_VALIDATE] [datetime] NULL,
	[PURGE_STAMP] [datetime] NULL,
	[PURGE_USER_ID] [nvarchar](10) NULL,
	[AVG_DAILY_RATE] [int] NULL,
	[SPACE_GUEST_RATIO] [int] NULL,
	[PEAK_NBR_RMS] [int] NULL,
	[BOOKED_AREA] [int] NULL,
	[TRAVEL_TYPE] [nvarchar](6) NULL,
	[VAL_ASSIGN_AREA] [nchar](1) NULL,
	[VAL_ASSIGN_DIM] [nchar](1) NULL,
	[VAL_ASSIGN_DIM_INT] [nchar](1) NULL,
	[VAL_ASSIGN_OS] [nchar](1) NULL,
	[VAL_ASSIGN_FR] [nchar](1) NULL,
	[PURGE_VAL_USER_ID] [nvarchar](10) NULL,
	[PRJ_ID] [nvarchar](10) NULL,
	[ACCT_DESIG] [nvarchar](1) NULL,
	[PROMPT_PROMO_CODE] [nvarchar](1) NULL,
	[ECON_IMPACT] [numeric](15, 2) NULL,
	[PORTAL_ID] [int] NULL,
	[TAX_SCHEME] [nvarchar](12) NULL,
	[UNIQUE_ID] [int] NOT NULL,
	[SOCIAL_NETWORK_1] [nvarchar](255) NULL,
	[SOCIAL_NETWORK_2] [nvarchar](255) NULL,
	[SOCIAL_NETWORK_3] [nvarchar](255) NULL,
	[OUTLOOK_MEETING] [nvarchar](1) NULL,
	[CC_AUTH_CFG] [int] NULL,
	[EVAL_ISS_TYPE] [varchar](2) NULL,
	[EXH_ISSUE_CLASS] [nvarchar](1) NULL,
	[EXH_ISSUE_TYPE] [nvarchar](2) NULL,
	[EXHIB_REG_RULE_TYPE] [int] NULL,
	[LINKED_FUNCS] [nvarchar](1) NULL,
	[ENABLE_REG_APPR] [nvarchar](1) NULL,
	PRIMARY KEY CLUSTERED 
	(
		[EVT_ID] ASC,
		[ORG_CODE] ASC
	)
);
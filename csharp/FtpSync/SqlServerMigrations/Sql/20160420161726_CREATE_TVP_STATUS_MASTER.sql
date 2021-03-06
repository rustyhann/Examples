CREATE TYPE [dbo].[TVP_STATUS_MASTER] AS TABLE
(
	[STATUS_CODE] [nvarchar](2) NOT NULL,
	[STATUS_DESC] [nvarchar](40) NOT NULL,
	[EVT_FUNC_EFB] [nchar](1) NOT NULL,
	[USR_DEFN_STS] [nchar](1) NOT NULL,
	[ABBR_STS_DESC] [nvarchar](5) NOT NULL,
	[MKT_CTL] [nchar](1) NOT NULL,
	[MKT_SPL] [nchar](1) NOT NULL,
	[PHASE_CTL] [nchar](1) NOT NULL,
	[USR_STS_3] [nchar](1) NOT NULL,
	[USR_STS_4] [nchar](1) NOT NULL,
	[USR_STS_5] [nchar](1) NOT NULL,
	[USR_STS_6] [nchar](1) NOT NULL,
	[USR_STS_7] [nchar](1) NOT NULL,
	[USR_DEFN_LDESC] [nvarchar](15) NOT NULL,
	[STS_COLOR] [int] NULL,
	[JOB_FUNC_JFB] [nchar](1) NULL,
	[DEL] [nvarchar](1) NULL,
	[CHG] [nvarchar](1) NULL,
	[DEL_FOCUS] [nvarchar](1) NULL,
	[TXT_COLOR] [int] NULL,
	[ALLOW_BLOCKS] [nvarchar](1) NULL,
	[LOST_FLAG] [nvarchar](1) NULL,
	[PROP_CALC] [nvarchar](1) NULL,
	PRIMARY KEY CLUSTERED ([STATUS_CODE] ASC)
);
CREATE TYPE [dbo].[TVP_EVT_CLASS] AS TABLE
(
	[ORG_CODE] [nvarchar](2) NOT NULL,
	[EVT_CLASS] [nvarchar](5) NOT NULL,
	[EVT_CLS_DESC] [nvarchar](60) NULL,
	[SCOPE] [nchar](1) NULL,
	[DEL] [nvarchar](1) NULL,
	[CHG] [nvarchar](1) NULL,
	[DEL_FOCUS] [nvarchar](1) NULL,
	[RETIRE] [nvarchar](1) NULL,
	[UPD_STAMP] [datetime] NULL,
	[UPD_USER_ID] [nvarchar](10) NULL,
	[ENT_STAMP] [datetime] NULL,
	[ENT_USER_ID] [nvarchar](10) NULL,
	[SEQUENCE] [nvarchar](6) NULL,
	[EVT_CLS_DESC_ALT1] [nvarchar](60) NULL,
	[EVT_CLS_DESC_ALT2] [nvarchar](60) NULL,
	[EVT_CLS_DESC_ALT3] [nvarchar](60) NULL,
	[EVT_CLS_DESC_ALT4] [nvarchar](60) NULL,
	[EVT_CLS_DESC_ALT5] [nvarchar](60) NULL,
	PRIMARY KEY CLUSTERED 
	(
		[ORG_CODE] ASC,
		[EVT_CLASS] ASC
	)
);
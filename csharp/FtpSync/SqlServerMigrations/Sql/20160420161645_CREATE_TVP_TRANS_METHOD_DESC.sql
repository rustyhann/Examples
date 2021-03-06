CREATE TYPE [dbo].[TVP_TRANS_METHOD_DESC] AS TABLE
(
	[TRANS_METHOD] [nvarchar](3) NOT NULL,
	[DESC] [nvarchar](20) NULL,
	[DEL] [nchar](1) NULL,
	[DEL_FOCUS] [nchar](1) NULL,
	[UPD_STAMP] [datetime] NULL,
	[UPD_USER_ID] [nvarchar](10) NULL,
	[STATUS] [nchar](1) NULL,
	[ENT_STAMP] [datetime] NULL,
	[ENT_USER_ID] [nvarchar](10) NULL,
	[CHG] [nchar](1) NULL,
	[CARD_TYPE] [nvarchar](4) NULL,
	PRIMARY KEY CLUSTERED ([TRANS_METHOD] ASC)
);

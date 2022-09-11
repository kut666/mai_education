USE [Vedomost10]
GO

/****** Object:  Table [dbo].[RightTable]    Script Date: 03.06.2021 16:45:34 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[RightTable](
	[RCode] [smallint] IDENTITY(1,2) NOT NULL,
	[City] [nchar](10) NULL,
	[Key2] [smallint] NULL
) ON [PRIMARY]
GO



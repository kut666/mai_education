USE [Vedomost10]
GO

/****** Object:  Table [dbo].[LeftTable]    Script Date: 03.06.2021 16:44:32 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[LeftTable](
	[LCode] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [nchar](10) NULL,
	[Key2] [smallint] NULL,
	[Key3] [smallint] NULL
) ON [PRIMARY]
GO



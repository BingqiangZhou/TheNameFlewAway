USE [Training]
GO

/****** Object:  Table [dbo].[User]    Script Date: 10/29/2018 11:34:40 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(100000,1) NOT NULL,
	[name] [nvarchar](16) NULL,
	[phone] [nvarchar](13) NULL,
	[password] [nvarchar](16) NULL,
	[status] [tinyint] NULL,
 CONSTRAINT [PK_User_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO



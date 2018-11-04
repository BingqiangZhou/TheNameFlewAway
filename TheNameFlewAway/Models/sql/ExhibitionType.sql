/*
 Navicat Premium Data Transfer

 Source Server         : SQLSERVER_REMOTE
 Source Server Type    : SQL Server
 Source Server Version : 11002100
 Source Host           : bingqiangzhou.cn:1433
 Source Catalog        : Training
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 11002100
 File Encoding         : 65001

 Date: 04/11/2018 15:17:20
*/


-- ----------------------------
-- Table structure for ExhibitionType
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ExhibitionType]') AND type IN ('U'))
	DROP TABLE [dbo].[ExhibitionType]
GO

CREATE TABLE [dbo].[ExhibitionType] (
  [id] int  IDENTITY(100000,1) NOT NULL,
  [name] nvarchar(16) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[ExhibitionType] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ExhibitionType
-- ----------------------------
SET IDENTITY_INSERT [dbo].[ExhibitionType] ON
GO

INSERT INTO [dbo].[ExhibitionType] ([id], [name]) VALUES (N'100000', N'课程设计')
GO

INSERT INTO [dbo].[ExhibitionType] ([id], [name]) VALUES (N'100001', N'项目实训')
GO

INSERT INTO [dbo].[ExhibitionType] ([id], [name]) VALUES (N'100002', N'大赛作品')
GO

SET IDENTITY_INSERT [dbo].[ExhibitionType] OFF
GO


-- ----------------------------
-- Primary Key structure for table ExhibitionType
-- ----------------------------
ALTER TABLE [dbo].[ExhibitionType] ADD CONSTRAINT [PK__Exhibiti__3213E83F385F4362] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


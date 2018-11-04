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

 Date: 04/11/2018 15:19:20
*/


-- ----------------------------
-- Table structure for User
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[User]') AND type IN ('U'))
	DROP TABLE [dbo].[User]
GO

CREATE TABLE [dbo].[User] (
  [id] int  IDENTITY(100000,1) NOT NULL,
  [name] nvarchar(16) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [phone] nvarchar(13) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [password] nvarchar(16) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [status] tinyint  NULL
)
GO

ALTER TABLE [dbo].[User] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of User
-- ----------------------------
SET IDENTITY_INSERT [dbo].[User] ON
GO

INSERT INTO [dbo].[User] ([id], [name], [phone], [password], [status]) VALUES (N'100000', N'zhou', N'123', N'123', N'1')
GO

INSERT INTO [dbo].[User] ([id], [name], [phone], [password], [status]) VALUES (N'100005', N'2', N'2', N'2', N'0')
GO

INSERT INTO [dbo].[User] ([id], [name], [phone], [password], [status]) VALUES (N'100006', N'3', N'3', N'3', N'0')
GO

INSERT INTO [dbo].[User] ([id], [name], [phone], [password], [status]) VALUES (N'100007', N'豆豆', N'12', N'1', N'0')
GO

INSERT INTO [dbo].[User] ([id], [name], [phone], [password], [status]) VALUES (N'100008', N'1', N'1', N'1', N'0')
GO

INSERT INTO [dbo].[User] ([id], [name], [phone], [password], [status]) VALUES (N'100009', N'5', N'5', N'5', N'0')
GO

INSERT INTO [dbo].[User] ([id], [name], [phone], [password], [status]) VALUES (N'100010', N'123', N'11111', N'11111', N'0')
GO

SET IDENTITY_INSERT [dbo].[User] OFF
GO


-- ----------------------------
-- Primary Key structure for table User
-- ----------------------------
ALTER TABLE [dbo].[User] ADD CONSTRAINT [PK_User_1] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


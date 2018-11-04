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

 Date: 04/11/2018 15:16:56
*/


-- ----------------------------
-- Table structure for AdvanceKonwledgeAndResource
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[AdvanceKonwledgeAndResource]') AND type IN ('U'))
	DROP TABLE [dbo].[AdvanceKonwledgeAndResource]
GO

CREATE TABLE [dbo].[AdvanceKonwledgeAndResource] (
  [id] int  NOT NULL,
  [resourceid] int  NOT NULL
)
GO

ALTER TABLE [dbo].[AdvanceKonwledgeAndResource] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of AdvanceKonwledgeAndResource
-- ----------------------------
INSERT INTO [dbo].[AdvanceKonwledgeAndResource]  VALUES (N'1', N'100000')
GO

INSERT INTO [dbo].[AdvanceKonwledgeAndResource]  VALUES (N'1', N'100001')
GO

INSERT INTO [dbo].[AdvanceKonwledgeAndResource]  VALUES (N'1', N'100002')
GO

INSERT INTO [dbo].[AdvanceKonwledgeAndResource]  VALUES (N'1', N'100003')
GO

INSERT INTO [dbo].[AdvanceKonwledgeAndResource]  VALUES (N'1', N'100004')
GO

INSERT INTO [dbo].[AdvanceKonwledgeAndResource]  VALUES (N'1', N'100005')
GO

INSERT INTO [dbo].[AdvanceKonwledgeAndResource]  VALUES (N'1', N'100006')
GO


-- ----------------------------
-- Primary Key structure for table AdvanceKonwledgeAndResource
-- ----------------------------
ALTER TABLE [dbo].[AdvanceKonwledgeAndResource] ADD CONSTRAINT [PK__AdvanceK__8F9B7EAC79C6CB06] PRIMARY KEY CLUSTERED ([id], [resourceid])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


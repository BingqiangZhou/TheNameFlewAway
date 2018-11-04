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

 Date: 04/11/2018 15:15:37
*/


-- ----------------------------
-- Table structure for AdvanceKnowledge
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[AdvanceKnowledge]') AND type IN ('U'))
	DROP TABLE [dbo].[AdvanceKnowledge]
GO

CREATE TABLE [dbo].[AdvanceKnowledge] (
  [id] int  IDENTITY(1,1) NOT NULL,
  [key] nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [imageaddress] nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [description] nvarchar(128) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [context] nvarchar(2000) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[AdvanceKnowledge] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of AdvanceKnowledge
-- ----------------------------
SET IDENTITY_INSERT [dbo].[AdvanceKnowledge] ON
GO

INSERT INTO [dbo].[AdvanceKnowledge] ([id], [key], [imageaddress], [description], [context]) VALUES (N'1', N'Java 数据结构', NULL, N'Java工具包提供了强大的数据结构。', N'在Java中的数据结构主要包括以下几种接口和类：

枚举（Enumeration）
位集合（BitSet）
向量（Vector）
栈（Stack）
字典（Dictionary）
哈希表（Hashtable）
属性（Properties）')
GO

SET IDENTITY_INSERT [dbo].[AdvanceKnowledge] OFF
GO


-- ----------------------------
-- Primary Key structure for table AdvanceKnowledge
-- ----------------------------
ALTER TABLE [dbo].[AdvanceKnowledge] ADD CONSTRAINT [PK__AdvanceK__3213E83FB19269AF] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


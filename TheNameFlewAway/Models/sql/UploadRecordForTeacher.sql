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

 Date: 04/11/2018 15:19:06
*/


-- ----------------------------
-- Table structure for UploadRecordForTeacher
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[UploadRecordForTeacher]') AND type IN ('U'))
	DROP TABLE [dbo].[UploadRecordForTeacher]
GO

CREATE TABLE [dbo].[UploadRecordForTeacher] (
  [sourceId] int  NOT NULL,
  [userId] int  NOT NULL
)
GO

ALTER TABLE [dbo].[UploadRecordForTeacher] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Primary Key structure for table UploadRecordForTeacher
-- ----------------------------
ALTER TABLE [dbo].[UploadRecordForTeacher] ADD CONSTRAINT [PK_UploadRecord] PRIMARY KEY CLUSTERED ([sourceId], [userId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


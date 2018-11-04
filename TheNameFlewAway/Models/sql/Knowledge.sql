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

 Date: 04/11/2018 15:18:23
*/


-- ----------------------------
-- Table structure for Knowledge
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Knowledge]') AND type IN ('U'))
	DROP TABLE [dbo].[Knowledge]
GO

CREATE TABLE [dbo].[Knowledge] (
  [id] int  IDENTITY(100000,1) NOT NULL,
  [image] nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [key] nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [resourceAddress] nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [description] nvarchar(128) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [context] nvarchar(2000) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Knowledge] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Knowledge
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Knowledge] ON
GO

INSERT INTO [dbo].[Knowledge] ([id], [image], [key], [resourceAddress], [description], [context]) VALUES (N'100001', NULL, N'java关键字', N'Resource.txt', N'关键词是其含义由编程语言定义的词', N'abstract class    extends implements null      strictfp     true
assert   const    false   import     package   super        try
boolean  continue final   instanceof private   switch       void
break    default  finally int        protected synchronized volatile
byte     do       float   interface  public    this         while
case     double   for     long       return    throw
catch    else     goto    native     short     throws
char     enum     if      new        static    transient')
GO

INSERT INTO [dbo].[Knowledge] ([id], [image], [key], [resourceAddress], [description], [context]) VALUES (N'100002', NULL, N'Java变量', N'Resource.txt', N'变量由标识符，类型和可选的初始化程序定义', N'在Java中，必须先声明所有变量，然后才能使用它们。变量声明的基本形式如下所示：

type identifier [ = value][, identifier [= value] ...] ;
变量定义有三个部分：

类型可以是int或float。
identifier是变量的名称。
初始化包括等号和值。
要声明指定类型的多个变量，请使用逗号分隔的列表。
int a, b, c; // declares three ints, a, b, and c.
int d = 3, e, f = 5; // declares three more ints, initializing d and f.')
GO

SET IDENTITY_INSERT [dbo].[Knowledge] OFF
GO


-- ----------------------------
-- Primary Key structure for table Knowledge
-- ----------------------------
ALTER TABLE [dbo].[Knowledge] ADD CONSTRAINT [PK_Knowledge] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


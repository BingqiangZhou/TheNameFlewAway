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

 Date: 04/11/2018 15:17:48
*/


-- ----------------------------
-- Table structure for ExpandKnowledge
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[ExpandKnowledge]') AND type IN ('U'))
	DROP TABLE [dbo].[ExpandKnowledge]
GO

CREATE TABLE [dbo].[ExpandKnowledge] (
  [id] int  IDENTITY(100000,1) NOT NULL,
  [key] nvarchar(16) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [description] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [url] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[ExpandKnowledge] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of ExpandKnowledge
-- ----------------------------
SET IDENTITY_INSERT [dbo].[ExpandKnowledge] ON
GO

INSERT INTO [dbo].[ExpandKnowledge] ([id], [key], [description], [url]) VALUES (N'100000', N'Java教程', N'Java是一门面向对象的编程语言,所以Java并不是最容易入手的开发语言,根据这个特性,本教程精心编排,优先讲解了面向对象编程的基本概念,再讲解Java基础知识,最后再介绍Java的继承,封装,多态等面向对象的特性,以求用易懂的方式,最精简的语句,最充实的内容,向读者介绍Java。', N'https://www.w3cschool.cn/java/')
GO

INSERT INTO [dbo].[ExpandKnowledge] ([id], [key], [description], [url]) VALUES (N'100001', N'Eclipse教程', N'Eclipse 是一个开放源代码的、基于 Java 的可扩展开发平台。本教程详细介绍了Eclipse的安装、使用、设置方法，学完后，你可以轻松使用 Eclipse搭建开发语言的集成开发环境。', N'https://www.w3cschool.cn/eclipse/')
GO

INSERT INTO [dbo].[ExpandKnowledge] ([id], [key], [description], [url]) VALUES (N'100002', N'Servlet教程', N'运行在 Web 服务器或应用服务器上的程序。', N'https://www.w3cschool.cn/servlet/')
GO

INSERT INTO [dbo].[ExpandKnowledge] ([id], [key], [description], [url]) VALUES (N'100003', N'JSP教程', N'JSP教程主要提供JSP基础知识以及部分常用的JSP进阶知识，大家在学习JSP之前，需要具备一定的HTML及Java基础。', N'https://www.w3cschool.cn/jsp/')
GO

INSERT INTO [dbo].[ExpandKnowledge] ([id], [key], [description], [url]) VALUES (N'100004', N'Spring 教程', N'本教程是为需要详细了解 Spring 框架的体系结构和实际应用的 Java 程序员设计的。本教程将带你达到中级的专业知识水平，而你可以将自己提升至更高层次的专业知识水平。', N'https://www.w3cschool.cn/wkspring/')
GO

INSERT INTO [dbo].[ExpandKnowledge] ([id], [key], [description], [url]) VALUES (N'100005', N'Hibernate 教程', N'Hibernate 是一个高性能的对象关系型持久化存储和查询的服务，其遵循开源的 GNU Lesser General Public License (LGPL) 而且可以免费下载。这个教程将指导你如何以简单的方式使用 Hibernate 来开发基于数据库的 Web 应用程序。', N'https://www.w3cschool.cn/hibernate/')
GO

SET IDENTITY_INSERT [dbo].[ExpandKnowledge] OFF
GO


-- ----------------------------
-- Primary Key structure for table ExpandKnowledge
-- ----------------------------
ALTER TABLE [dbo].[ExpandKnowledge] ADD CONSTRAINT [PK__ExpandKn__3213E83F2B050609] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


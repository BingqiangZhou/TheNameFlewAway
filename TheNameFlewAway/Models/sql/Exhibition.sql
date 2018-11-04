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

 Date: 04/11/2018 15:17:09
*/


-- ----------------------------
-- Table structure for Exhibition
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Exhibition]') AND type IN ('U'))
	DROP TABLE [dbo].[Exhibition]
GO

CREATE TABLE [dbo].[Exhibition] (
  [id] int  IDENTITY(100000,1) NOT NULL,
  [author] nvarchar(16) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [description] nvarchar(1024) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [showimage] nvarchar(128) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [coverimage] nvarchar(128) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [typeid] int  NULL,
  [resourceaddress] nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [name] nvarchar(16) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[Exhibition] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Exhibition
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Exhibition] ON
GO

INSERT INTO [dbo].[Exhibition] ([id], [author], [description], [showimage], [coverimage], [typeid], [resourceaddress], [name]) VALUES (N'100000', N'张三', N'游戏规则：
按 <- 或 A 键 控制军舰向左按 -> 或 D 键 控制军舰向右按空格键扔炸弹
本游戏为Java awt 和 swing组件模拟的休闲小游戏《潜艇大战》。玩家通过操作军舰向水下的鱼雷扔炸弹水下潜艇向上发射鱼雷，此版本加入了一些UI处理，比较流畅。', N'http://www.java1234.com/uploads/allimg/131202/1-1312020Z315314.jpg', N'http://www.java1234.com/uploads/allimg/131202/1-1312020Z300562.jpg', N'100001', N'Swing实现潜艇大战源码下载.zip', N'Java实现潜艇大战游戏')
GO

INSERT INTO [dbo].[Exhibition] ([id], [author], [description], [showimage], [coverimage], [typeid], [resourceaddress], [name]) VALUES (N'100001', N'赵四', N'Jsp+Ajax技术实现', N'http://www.java1234.com/uploads/allimg/130811/1-130Q1140006164.jpg', N'http://www.java1234.com/uploads/allimg/130811/1-130Q11359511X.jpg', N'100000', N'Web聊天室系统源码.zip', N'Jsp在线聊天室系统')
GO

INSERT INTO [dbo].[Exhibition] ([id], [author], [description], [showimage], [coverimage], [typeid], [resourceaddress], [name]) VALUES (N'100002', N'王五', N'按鼠标选择要旋转的魔方的面，按D顺时针旋转，按S逆时针旋转。', N'http://www.java1234.com/uploads/allimg/151104/1-15110414164IY.jpg', N'http://www.java1234.com/uploads/allimg/151104/1-151104141620127.jpg', N'100002', N'1.rar', N'4阶魔方')
GO

SET IDENTITY_INSERT [dbo].[Exhibition] OFF
GO


-- ----------------------------
-- Primary Key structure for table Exhibition
-- ----------------------------
ALTER TABLE [dbo].[Exhibition] ADD CONSTRAINT [PK__Exhibiti__3213E83F3AF61765] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


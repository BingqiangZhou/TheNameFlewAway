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

 Date: 04/11/2018 15:18:42
*/


-- ----------------------------
-- Table structure for Resource
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[Resource]') AND type IN ('U'))
	DROP TABLE [dbo].[Resource]
GO

CREATE TABLE [dbo].[Resource] (
  [id] int  IDENTITY(100000,1) NOT NULL,
  [name] nvarchar(128) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [description] nvarchar(1000) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [address] nvarchar(128) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL,
  [typeid] int  NULL,
  [time] datetime  NULL
)
GO

ALTER TABLE [dbo].[Resource] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of Resource
-- ----------------------------
SET IDENTITY_INSERT [dbo].[Resource] ON
GO

INSERT INTO [dbo].[Resource] ([id], [name], [description], [address], [typeid], [time]) VALUES (N'100000', N'枚举（Enumeration）', N'枚举（Enumeration）接口虽然它本身不属于数据结构,但它在其他数据结构的范畴里应用很广。 枚举（The Enumeration）接口定义了一种从数据结构中取回连续元素的方式。

例如，枚举定义了一个叫nextElement 的方法，该方法用来得到一个包含多元素的数据结构的下一个元素。

关于枚举接口的更多信息，请参见枚举（Enumeration）。', N'https://www.w3cschool.cn/java/java-enumeration-interface.html', NULL, NULL)
GO

INSERT INTO [dbo].[Resource] ([id], [name], [description], [address], [typeid], [time]) VALUES (N'100001', N'位集合（BitSet）', N'位集合类实现了一组可以单独设置和清除的位或标志。

该类在处理一组布尔值的时候非常有用，你只需要给每个值赋值一"位"，然后对位进行适当的设置或清除，就可以对布尔值进行操作了。

关于该类的更多信息，请参见位集合（BitSet）。', N'https://www.w3cschool.cn/java/java-bitset-class.html', NULL, NULL)
GO

INSERT INTO [dbo].[Resource] ([id], [name], [description], [address], [typeid], [time]) VALUES (N'100002', N'向量（Vector）', N'向量（Vector）类和传统数组非常相似，但是Vector的大小能根据需要动态的变化。

和数组一样，Vector对象的元素也能通过索引访问。

使用Vector类最主要的好处就是在创建对象的时候不必给对象指定大小，它的大小会根据需要动态的变化。

关于该类的更多信息，请参见向量(Vector)

', N'https://www.w3cschool.cn/java/java-vector-class.html', NULL, NULL)
GO

INSERT INTO [dbo].[Resource] ([id], [name], [description], [address], [typeid], [time]) VALUES (N'100003', N'栈（Stack）', N'栈（Stack）实现了一个后进先出（LIFO）的数据结构。

你可以把栈理解为对象的垂直分布的栈，当你添加一个新元素时，就将新元素放在其他元素的顶部。

当你从栈中取元素的时候，就从栈顶取一个元素。换句话说，最后进栈的元素最先被取出。

关于该类的更多信息，请参见栈（Stack）。', N'https://www.w3cschool.cn/java/java-stack-class.html', NULL, NULL)
GO

INSERT INTO [dbo].[Resource] ([id], [name], [description], [address], [typeid], [time]) VALUES (N'100004', N'字典（Dictionary）', N'字典（Dictionary） 类是一个抽象类，它定义了键映射到值的数据结构。

当你想要通过特定的键而不是整数索引来访问数据的时候，这时候应该使用Dictionary。

由于Dictionary类是抽象类，所以它只提供了键映射到值的数据结构，而没有提供特定的实现。

关于该类的更多信息，请参见字典（ Dictionary）。

', N'https://www.w3cschool.cn/java/java-dictionary-class.html', NULL, NULL)
GO

INSERT INTO [dbo].[Resource] ([id], [name], [description], [address], [typeid], [time]) VALUES (N'100005', N'哈希表（Hashtable）', N'Hashtable类提供了一种在用户定义键结构的基础上来组织数据的手段。

例如，在地址列表的哈希表中，你可以根据邮政编码作为键来存储和排序数据，而不是通过人的名字。

哈希表键的具体含义完全取决于哈希表的使用情景和它包含的数据。

关于该类的更多信息，请参见哈希表（HashTable）。', N'https://www.w3cschool.cn/java/java-hashTable-class.html', NULL, NULL)
GO

INSERT INTO [dbo].[Resource] ([id], [name], [description], [address], [typeid], [time]) VALUES (N'100006', N'属性（Properties）', N'Properties 继承于 Hashtable.Properties 类表示了一个持久的属性集.属性列表中每个键及其对应值都是一个字符串。

Properties 类被许多Java类使用。例如，在获取环境变量时它就作为System.getProperties()方法的返回值。

关于该类的更多信息，请参见属性（Properties）。', N'https://www.w3cschool.cn/java/java-properties-class.html', NULL, NULL)
GO

INSERT INTO [dbo].[Resource] ([id], [name], [description], [address], [typeid], [time]) VALUES (N'100007', N'JavaWeb从入门到精通', N'JavaWeb从入门到精通', N'JavaWeb从入门到精通.pdf', N'100002', N'2018-11-05 14:11:37.000')
GO

INSERT INTO [dbo].[Resource] ([id], [name], [description], [address], [typeid], [time]) VALUES (N'100008', N'Java 帮助中心', N'可以找到有关您在下载 Java 并在计算机上使用时所遇到问题的解决方案。我们跟踪最常报告的问题和错误代码，并在此部分中提供这些问题的答案。', N'https://www.java.com/zh_CN/download/help/', N'100001', N'2018-11-05 14:14:18.000')
GO

INSERT INTO [dbo].[Resource] ([id], [name], [description], [address], [typeid], [time]) VALUES (N'100009', N'JDK安装包', N'jdk-10.0.1_windows-x64', N'jdk-10.0.1_windows-x64_bin.exe', N'100000', N'2018-11-05 14:18:13.000')
GO

SET IDENTITY_INSERT [dbo].[Resource] OFF
GO


-- ----------------------------
-- Primary Key structure for table Resource
-- ----------------------------
ALTER TABLE [dbo].[Resource] ADD CONSTRAINT [PK__Resource__3213E83F777042C3] PRIMARY KEY CLUSTERED ([id])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


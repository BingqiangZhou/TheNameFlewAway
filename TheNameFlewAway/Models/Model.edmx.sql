
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/02/2018 21:57:41
-- Generated from EDMX file: E:\C#\ASP\Training\TheNameFlewAway\TheNameFlewAway\Models\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Training];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AdvanceKnowledge]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdvanceKnowledge];
GO
IF OBJECT_ID(N'[dbo].[AdvanceKonwledgeAndResource]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AdvanceKonwledgeAndResource];
GO
IF OBJECT_ID(N'[dbo].[Exhibition]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Exhibition];
GO
IF OBJECT_ID(N'[dbo].[ExhibitionType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExhibitionType];
GO
IF OBJECT_ID(N'[dbo].[ExpandKnowledge]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExpandKnowledge];
GO
IF OBJECT_ID(N'[dbo].[Instance]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Instance];
GO
IF OBJECT_ID(N'[dbo].[Knowledge]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Knowledge];
GO
IF OBJECT_ID(N'[dbo].[Resource]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Resource];
GO
IF OBJECT_ID(N'[dbo].[ResourceType]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ResourceType];
GO
IF OBJECT_ID(N'[dbo].[UploadRecordForTeacher]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UploadRecordForTeacher];
GO
IF OBJECT_ID(N'[dbo].[User]', 'U') IS NOT NULL
    DROP TABLE [dbo].[User];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AdvanceKnowledges'
CREATE TABLE [dbo].[AdvanceKnowledges] (
    [id] int IDENTITY(1,1) NOT NULL,
    [key] nvarchar(32)  NOT NULL,
    [imageaddress] nvarchar(32)  NULL,
    [description] nvarchar(128)  NULL,
    [context] nvarchar(2000)  NULL
);
GO

-- Creating table 'AdvanceKonwledgeAndResources'
CREATE TABLE [dbo].[AdvanceKonwledgeAndResources] (
    [id] int  NOT NULL,
    [resourceid] int  NOT NULL
);
GO

-- Creating table 'Exhibitions'
CREATE TABLE [dbo].[Exhibitions] (
    [id] int IDENTITY(1,1) NOT NULL,
    [author] nvarchar(16)  NULL,
    [description] nvarchar(1024)  NULL,
    [showimage] nvarchar(32)  NULL,
    [coverimage] nvarchar(32)  NULL,
    [typeid] int  NULL,
    [resourceaddress] nvarchar(32)  NULL
);
GO

-- Creating table 'ExhibitionTypes'
CREATE TABLE [dbo].[ExhibitionTypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(16)  NULL
);
GO

-- Creating table 'ExpandKnowledges'
CREATE TABLE [dbo].[ExpandKnowledges] (
    [id] int IDENTITY(1,1) NOT NULL,
    [key] nvarchar(16)  NULL,
    [description] nvarchar(255)  NULL,
    [url] nvarchar(255)  NULL
);
GO

-- Creating table 'Instances'
CREATE TABLE [dbo].[Instances] (
    [id] int IDENTITY(1,1) NOT NULL,
    [resourceAddress] nvarchar(32)  NULL,
    [key] nvarchar(16)  NULL,
    [image] nvarchar(32)  NULL,
    [title] nvarchar(128)  NULL,
    [code] nvarchar(2000)  NULL,
    [context] nvarchar(2000)  NULL,
    [result] nvarchar(1000)  NULL
);
GO

-- Creating table 'Knowledges'
CREATE TABLE [dbo].[Knowledges] (
    [id] int IDENTITY(1,1) NOT NULL,
    [image] nvarchar(32)  NULL,
    [key] nvarchar(32)  NOT NULL,
    [resourceAddress] nvarchar(32)  NULL,
    [description] nvarchar(128)  NULL,
    [context] nvarchar(2000)  NULL
);
GO

-- Creating table 'Resources'
CREATE TABLE [dbo].[Resources] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(16)  NULL,
    [description] nvarchar(256)  NULL,
    [address] nvarchar(32)  NULL,
    [typeid] int  NULL,
    [time] datetime  NULL
);
GO

-- Creating table 'ResourceTypes'
CREATE TABLE [dbo].[ResourceTypes] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(16)  NULL
);
GO

-- Creating table 'UploadRecordForTeachers'
CREATE TABLE [dbo].[UploadRecordForTeachers] (
    [sourceId] int  NOT NULL,
    [userId] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [id] int IDENTITY(1,1) NOT NULL,
    [name] nvarchar(16)  NULL,
    [phone] nvarchar(13)  NULL,
    [password] nvarchar(16)  NULL,
    [status] tinyint  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [id] in table 'AdvanceKnowledges'
ALTER TABLE [dbo].[AdvanceKnowledges]
ADD CONSTRAINT [PK_AdvanceKnowledges]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id], [resourceid] in table 'AdvanceKonwledgeAndResources'
ALTER TABLE [dbo].[AdvanceKonwledgeAndResources]
ADD CONSTRAINT [PK_AdvanceKonwledgeAndResources]
    PRIMARY KEY CLUSTERED ([id], [resourceid] ASC);
GO

-- Creating primary key on [id] in table 'Exhibitions'
ALTER TABLE [dbo].[Exhibitions]
ADD CONSTRAINT [PK_Exhibitions]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ExhibitionTypes'
ALTER TABLE [dbo].[ExhibitionTypes]
ADD CONSTRAINT [PK_ExhibitionTypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ExpandKnowledges'
ALTER TABLE [dbo].[ExpandKnowledges]
ADD CONSTRAINT [PK_ExpandKnowledges]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Instances'
ALTER TABLE [dbo].[Instances]
ADD CONSTRAINT [PK_Instances]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Knowledges'
ALTER TABLE [dbo].[Knowledges]
ADD CONSTRAINT [PK_Knowledges]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'Resources'
ALTER TABLE [dbo].[Resources]
ADD CONSTRAINT [PK_Resources]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [id] in table 'ResourceTypes'
ALTER TABLE [dbo].[ResourceTypes]
ADD CONSTRAINT [PK_ResourceTypes]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- Creating primary key on [sourceId], [userId] in table 'UploadRecordForTeachers'
ALTER TABLE [dbo].[UploadRecordForTeachers]
ADD CONSTRAINT [PK_UploadRecordForTeachers]
    PRIMARY KEY CLUSTERED ([sourceId], [userId] ASC);
GO

-- Creating primary key on [id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------
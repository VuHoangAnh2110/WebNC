/*
 Navicat Premium Dump SQL

 Source Server         : local_sql_server
 Source Server Type    : SQL Server
 Source Server Version : 16001000 (16.00.1000)
 Source Host           : DESKTOP-SHLIJ6C:1433
 Source Catalog        : ProductDB
 Source Schema         : dbo

 Target Server Type    : SQL Server
 Target Server Version : 16001000 (16.00.1000)
 File Encoding         : 65001

 Date: 19/03/2025 16:41:05
*/


-- ----------------------------
-- Table structure for __EFMigrationsHistory
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[__EFMigrationsHistory]') AND type IN ('U'))
	DROP TABLE [dbo].[__EFMigrationsHistory]
GO

CREATE TABLE [dbo].[__EFMigrationsHistory] (
  [MigrationId] nvarchar(150) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [ProductVersion] nvarchar(32) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[__EFMigrationsHistory] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of __EFMigrationsHistory
-- ----------------------------
INSERT INTO [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20250224022445_ProductDBSetup', N'9.0.2')
GO


-- ----------------------------
-- Table structure for tblMembers
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblMembers]') AND type IN ('U'))
	DROP TABLE [dbo].[tblMembers]
GO

CREATE TABLE [dbo].[tblMembers] (
  [MemberName] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [Matkhau] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[tblMembers] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblMembers
-- ----------------------------
INSERT INTO [dbo].[tblMembers] ([MemberName], [Matkhau]) VALUES (N'admin', N'admin123')
GO

INSERT INTO [dbo].[tblMembers] ([MemberName], [Matkhau]) VALUES (N'UserNameTest', N'123456')
GO

INSERT INTO [dbo].[tblMembers] ([MemberName], [Matkhau]) VALUES (N'vhanh', N'123456')
GO


-- ----------------------------
-- Table structure for tblNhanxet
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblNhanxet]') AND type IN ('U'))
	DROP TABLE [dbo].[tblNhanxet]
GO

CREATE TABLE [dbo].[tblNhanxet] (
  [PK_iNhanxetID] int  IDENTITY(1,1) NOT NULL,
  [sNoidung] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [tThoigianGhinhan] datetime DEFAULT getdate() NOT NULL,
  [FK_iProductID] int  NOT NULL,
  [FK_MemberName] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL
)
GO

ALTER TABLE [dbo].[tblNhanxet] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblNhanxet
-- ----------------------------
SET IDENTITY_INSERT [dbo].[tblNhanxet] ON
GO

INSERT INTO [dbo].[tblNhanxet] ([PK_iNhanxetID], [sNoidung], [tThoigianGhinhan], [FK_iProductID], [FK_MemberName]) VALUES (N'15', N'alo', N'2025-03-13 11:30:38.243', N'4', N'UserNameTest')
GO

INSERT INTO [dbo].[tblNhanxet] ([PK_iNhanxetID], [sNoidung], [tThoigianGhinhan], [FK_iProductID], [FK_MemberName]) VALUES (N'16', N'xin cháo tôi là ớn lạnh :)))', N'2025-03-13 15:07:39.260', N'4', N'admin')
GO

INSERT INTO [dbo].[tblNhanxet] ([PK_iNhanxetID], [sNoidung], [tThoigianGhinhan], [FK_iProductID], [FK_MemberName]) VALUES (N'17', N'á đù bạn là ớn lạnh á :))) 
ahihi', N'2025-03-13 15:08:36.887', N'4', N'vhanh')
GO

SET IDENTITY_INSERT [dbo].[tblNhanxet] OFF
GO


-- ----------------------------
-- Table structure for tblProducts
-- ----------------------------
IF EXISTS (SELECT * FROM sys.all_objects WHERE object_id = OBJECT_ID(N'[dbo].[tblProducts]') AND type IN ('U'))
	DROP TABLE [dbo].[tblProducts]
GO

CREATE TABLE [dbo].[tblProducts] (
  [ProductID] int  IDENTITY(1,1) NOT NULL,
  [ProductName] nvarchar(255) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [ImageURL] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NOT NULL,
  [ProductPrice] decimal(18,2)  NOT NULL,
  [Description] nvarchar(max) COLLATE SQL_Latin1_General_CP1_CI_AS  NULL
)
GO

ALTER TABLE [dbo].[tblProducts] SET (LOCK_ESCALATION = TABLE)
GO


-- ----------------------------
-- Records of tblProducts
-- ----------------------------
SET IDENTITY_INSERT [dbo].[tblProducts] ON
GO

INSERT INTO [dbo].[tblProducts] ([ProductID], [ProductName], [ImageURL], [ProductPrice], [Description]) VALUES (N'4', N'chuối ', N'https://th.bing.com/th/id/OIP.In8krhXUxeN7fHfGBKsQEwHaHa?rs=1&pid=ImgDetMain', N'185111.00', N'chuối xanh')
GO

SET IDENTITY_INSERT [dbo].[tblProducts] OFF
GO


-- ----------------------------
-- Primary Key structure for table __EFMigrationsHistory
-- ----------------------------
ALTER TABLE [dbo].[__EFMigrationsHistory] ADD CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED ([MigrationId])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Uniques structure for table tblMembers
-- ----------------------------
ALTER TABLE [dbo].[tblMembers] ADD CONSTRAINT [UQ__tblMembe__BE50FDEF2C12D7E5] UNIQUE NONCLUSTERED ([MemberName] ASC)
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Primary Key structure for table tblMembers
-- ----------------------------
ALTER TABLE [dbo].[tblMembers] ADD CONSTRAINT [PK_tblMembers] PRIMARY KEY CLUSTERED ([MemberName])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tblNhanxet
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tblNhanxet]', RESEED, 17)
GO


-- ----------------------------
-- Primary Key structure for table tblNhanxet
-- ----------------------------
ALTER TABLE [dbo].[tblNhanxet] ADD CONSTRAINT [PK_tblNhanxet] PRIMARY KEY CLUSTERED ([PK_iNhanxetID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Auto increment value for tblProducts
-- ----------------------------
DBCC CHECKIDENT ('[dbo].[tblProducts]', RESEED, 1001)
GO


-- ----------------------------
-- Indexes structure for table tblProducts
-- ----------------------------
CREATE UNIQUE NONCLUSTERED INDEX [IX_tblProducts_ProductName]
ON [dbo].[tblProducts] (
  [ProductName] ASC
)
GO


-- ----------------------------
-- Primary Key structure for table tblProducts
-- ----------------------------
ALTER TABLE [dbo].[tblProducts] ADD CONSTRAINT [PK_tblProducts] PRIMARY KEY CLUSTERED ([ProductID])
WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON)  
ON [PRIMARY]
GO


-- ----------------------------
-- Foreign Keys structure for table tblNhanxet
-- ----------------------------
ALTER TABLE [dbo].[tblNhanxet] ADD CONSTRAINT [FK_tblNhanxet_Product] FOREIGN KEY ([FK_iProductID]) REFERENCES [dbo].[tblProducts] ([ProductID]) ON DELETE CASCADE ON UPDATE CASCADE
GO

ALTER TABLE [dbo].[tblNhanxet] ADD CONSTRAINT [FK_tblNhanxet_Member] FOREIGN KEY ([FK_MemberName]) REFERENCES [dbo].[tblMembers] ([MemberName]) ON DELETE CASCADE ON UPDATE CASCADE
GO


USE [master]
GO
/****** Object:  Database [OrderManagementDb]    Script Date: 20.02.2023 21:55:09 ******/
CREATE DATABASE [OrderManagementDb]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'OrderManagementDb', FILENAME = N'C:\Users\Furkan\OrderManagementDb.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'OrderManagementDb_log', FILENAME = N'C:\Users\Furkan\OrderManagementDb_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [OrderManagementDb] SET COMPATIBILITY_LEVEL = 130
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [OrderManagementDb].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [OrderManagementDb] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [OrderManagementDb] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [OrderManagementDb] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [OrderManagementDb] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [OrderManagementDb] SET ARITHABORT OFF 
GO
ALTER DATABASE [OrderManagementDb] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [OrderManagementDb] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [OrderManagementDb] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [OrderManagementDb] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [OrderManagementDb] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [OrderManagementDb] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [OrderManagementDb] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [OrderManagementDb] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [OrderManagementDb] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [OrderManagementDb] SET  ENABLE_BROKER 
GO
ALTER DATABASE [OrderManagementDb] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [OrderManagementDb] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [OrderManagementDb] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [OrderManagementDb] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [OrderManagementDb] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [OrderManagementDb] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [OrderManagementDb] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [OrderManagementDb] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [OrderManagementDb] SET  MULTI_USER 
GO
ALTER DATABASE [OrderManagementDb] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [OrderManagementDb] SET DB_CHAINING OFF 
GO
ALTER DATABASE [OrderManagementDb] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [OrderManagementDb] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [OrderManagementDb] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [OrderManagementDb] SET QUERY_STORE = OFF
GO
USE [OrderManagementDb]
GO
ALTER DATABASE SCOPED CONFIGURATION SET LEGACY_CARDINALITY_ESTIMATION = OFF;
GO
ALTER DATABASE SCOPED CONFIGURATION SET MAXDOP = 0;
GO
ALTER DATABASE SCOPED CONFIGURATION SET PARAMETER_SNIFFING = ON;
GO
ALTER DATABASE SCOPED CONFIGURATION SET QUERY_OPTIMIZER_HOTFIXES = OFF;
GO
USE [OrderManagementDb]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 20.02.2023 21:55:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Companies]    Script Date: 20.02.2023 21:55:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Companies](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyName] [nvarchar](25) NOT NULL,
	[IsApproved] [bit] NULL,
	[OrderStartTime] [smalldatetime] NOT NULL,
	[OrderFinishTime] [smalldatetime] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Companies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Orders]    Script Date: 20.02.2023 21:55:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Orders](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ProductId] [int] NOT NULL,
	[OrdererName] [nvarchar](25) NOT NULL,
	[OrderDate] [smalldatetime] NOT NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Orders] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 20.02.2023 21:55:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[ProductName] [nvarchar](25) NOT NULL,
	[Stock] [int] NOT NULL,
	[Price] [money] NULL,
	[CreatedDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230220170528_mg_1', N'7.0.3')
GO
/****** Object:  Index [IX_Orders_CompanyId]    Script Date: 20.02.2023 21:55:10 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_CompanyId] ON [dbo].[Orders]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Orders_ProductId]    Script Date: 20.02.2023 21:55:10 ******/
CREATE NONCLUSTERED INDEX [IX_Orders_ProductId] ON [dbo].[Orders]
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [IX_Products_CompanyId]    Script Date: 20.02.2023 21:55:10 ******/
CREATE NONCLUSTERED INDEX [IX_Products_CompanyId] ON [dbo].[Products]
(
	[CompanyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Companies] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsApproved]
GO
ALTER TABLE [dbo].[Companies] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (getdate()) FOR [OrderDate]
GO
ALTER TABLE [dbo].[Orders] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Products] ADD  DEFAULT (getdate()) FOR [CreatedDate]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Companies_CompanyId]
GO
ALTER TABLE [dbo].[Orders]  WITH CHECK ADD  CONSTRAINT [FK_Orders_Products_ProductId] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Orders] CHECK CONSTRAINT [FK_Orders_Products_ProductId]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_Companies_CompanyId] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[Companies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_Companies_CompanyId]
GO
USE [master]
GO
ALTER DATABASE [OrderManagementDb] SET  READ_WRITE 
GO

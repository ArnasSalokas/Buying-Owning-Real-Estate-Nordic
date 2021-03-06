USE [master]
GO
/****** Object:  Database [Municipalities]    Script Date: 7/25/2021 12:38:56 PM ******/
CREATE DATABASE [Municipalities]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Municipalities', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Municipalities.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Municipalities_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Municipalities_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
ALTER DATABASE [Municipalities] SET COMPATIBILITY_LEVEL = 140
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Municipalities].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Municipalities] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Municipalities] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Municipalities] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Municipalities] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Municipalities] SET ARITHABORT OFF 
GO
ALTER DATABASE [Municipalities] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Municipalities] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Municipalities] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Municipalities] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Municipalities] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Municipalities] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Municipalities] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Municipalities] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Municipalities] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Municipalities] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Municipalities] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Municipalities] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Municipalities] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Municipalities] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Municipalities] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Municipalities] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Municipalities] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Municipalities] SET RECOVERY FULL 
GO
ALTER DATABASE [Municipalities] SET  MULTI_USER 
GO
ALTER DATABASE [Municipalities] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Municipalities] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Municipalities] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Municipalities] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Municipalities] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Municipalities', N'ON'
GO
ALTER DATABASE [Municipalities] SET QUERY_STORE = OFF
GO
USE [Municipalities]
GO
/****** Object:  Table [dbo].[MunicipalityTaxes]    Script Date: 7/25/2021 12:38:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MunicipalityTaxes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Municipality] [varchar](255) NOT NULL,
	[TaxRate] [decimal](18, 4) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[Period] [int] NOT NULL,
	[LastUpdated] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[MunicipalityTaxes] ON 

INSERT [dbo].[MunicipalityTaxes] ([Id], [Municipality], [TaxRate], [StartDate], [EndDate], [Period], [LastUpdated]) VALUES (1, N'copenhagen', CAST(0.4000 AS Decimal(18, 4)), CAST(N'2020-11-04' AS Date), CAST(N'2020-11-04' AS Date), 1, CAST(N'2021-07-25T12:18:02.823' AS DateTime))
INSERT [dbo].[MunicipalityTaxes] ([Id], [Municipality], [TaxRate], [StartDate], [EndDate], [Period], [LastUpdated]) VALUES (2, N'copenhagen', CAST(0.5000 AS Decimal(18, 4)), CAST(N'2020-11-04' AS Date), CAST(N'2020-11-10' AS Date), 2, CAST(N'2021-07-25T12:18:08.913' AS DateTime))
INSERT [dbo].[MunicipalityTaxes] ([Id], [Municipality], [TaxRate], [StartDate], [EndDate], [Period], [LastUpdated]) VALUES (3, N'copenhagen', CAST(0.6000 AS Decimal(18, 4)), CAST(N'2020-11-01' AS Date), CAST(N'2020-11-30' AS Date), 3, CAST(N'2021-07-25T12:18:14.650' AS DateTime))
INSERT [dbo].[MunicipalityTaxes] ([Id], [Municipality], [TaxRate], [StartDate], [EndDate], [Period], [LastUpdated]) VALUES (4, N'copenhagen', CAST(0.7000 AS Decimal(18, 4)), CAST(N'2020-01-01' AS Date), CAST(N'2020-12-31' AS Date), 4, CAST(N'2021-07-25T12:18:22.327' AS DateTime))
INSERT [dbo].[MunicipalityTaxes] ([Id], [Municipality], [TaxRate], [StartDate], [EndDate], [Period], [LastUpdated]) VALUES (5, N'copenhagen', CAST(0.9000 AS Decimal(18, 4)), CAST(N'2020-11-06' AS Date), CAST(N'2020-11-12' AS Date), 2, CAST(N'2021-07-25T12:18:44.620' AS DateTime))
INSERT [dbo].[MunicipalityTaxes] ([Id], [Municipality], [TaxRate], [StartDate], [EndDate], [Period], [LastUpdated]) VALUES (6, N'kaunas', CAST(1.9000 AS Decimal(18, 4)), CAST(N'2020-11-06' AS Date), CAST(N'2020-11-06' AS Date), 1, CAST(N'2021-07-25T12:18:59.657' AS DateTime))
INSERT [dbo].[MunicipalityTaxes] ([Id], [Municipality], [TaxRate], [StartDate], [EndDate], [Period], [LastUpdated]) VALUES (7, N'kaunas', CAST(2.9000 AS Decimal(18, 4)), CAST(N'2020-11-04' AS Date), CAST(N'2020-11-04' AS Date), 1, CAST(N'2021-07-25T12:19:28.663' AS DateTime))
INSERT [dbo].[MunicipalityTaxes] ([Id], [Municipality], [TaxRate], [StartDate], [EndDate], [Period], [LastUpdated]) VALUES (8, N'kaunas', CAST(3.9000 AS Decimal(18, 4)), CAST(N'2020-11-04' AS Date), CAST(N'2020-11-10' AS Date), 2, CAST(N'2021-07-25T12:19:58.923' AS DateTime))
INSERT [dbo].[MunicipalityTaxes] ([Id], [Municipality], [TaxRate], [StartDate], [EndDate], [Period], [LastUpdated]) VALUES (9, N'kaunas', CAST(4.9000 AS Decimal(18, 4)), CAST(N'2020-11-01' AS Date), CAST(N'2020-11-30' AS Date), 3, CAST(N'2021-07-25T12:20:14.287' AS DateTime))
INSERT [dbo].[MunicipalityTaxes] ([Id], [Municipality], [TaxRate], [StartDate], [EndDate], [Period], [LastUpdated]) VALUES (10, N'kaunas', CAST(6.9000 AS Decimal(18, 4)), CAST(N'2020-01-01' AS Date), CAST(N'2020-12-31' AS Date), 4, CAST(N'2021-07-25T12:20:19.683' AS DateTime))
SET IDENTITY_INSERT [dbo].[MunicipalityTaxes] OFF
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Municipa__E78A829A3300B063]    Script Date: 7/25/2021 12:38:56 PM ******/
ALTER TABLE [dbo].[MunicipalityTaxes] ADD UNIQUE NONCLUSTERED 
(
	[Municipality] ASC,
	[StartDate] ASC,
	[EndDate] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
USE [master]
GO
ALTER DATABASE [Municipalities] SET  READ_WRITE 
GO

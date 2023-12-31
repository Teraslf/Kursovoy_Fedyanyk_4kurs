USE [master]
GO
/****** Object:  Database [StrahovanieDB]    Script Date: 02.05.2023 19:16:41 ******/
CREATE DATABASE [StrahovanieDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'StrahovanieDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\StrahovanieDB.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'StrahovanieDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\StrahovanieDB_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [StrahovanieDB] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [StrahovanieDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [StrahovanieDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [StrahovanieDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [StrahovanieDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [StrahovanieDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [StrahovanieDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [StrahovanieDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [StrahovanieDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [StrahovanieDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [StrahovanieDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [StrahovanieDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [StrahovanieDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [StrahovanieDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [StrahovanieDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [StrahovanieDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [StrahovanieDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [StrahovanieDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [StrahovanieDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [StrahovanieDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [StrahovanieDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [StrahovanieDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [StrahovanieDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [StrahovanieDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [StrahovanieDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [StrahovanieDB] SET  MULTI_USER 
GO
ALTER DATABASE [StrahovanieDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [StrahovanieDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [StrahovanieDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [StrahovanieDB] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [StrahovanieDB] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [StrahovanieDB] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [StrahovanieDB] SET QUERY_STORE = OFF
GO
USE [StrahovanieDB]
GO
/****** Object:  Table [dbo].[ContractAndClient]    Script Date: 02.05.2023 19:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ContractAndClient](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[MiddleName] [nvarchar](50) NOT NULL,
	[Number] [nvarchar](50) NOT NULL,
	[Insurance] [nvarchar](50) NOT NULL,
	[DateFirts] [date] NOT NULL,
	[Tern] [date] NOT NULL,
	[IncurancePayment] [nvarchar](50) NOT NULL,
	[GosNumber] [nvarchar](50) NOT NULL,
	[NameCar] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_ContractAndClient] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 02.05.2023 19:16:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Position] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[ContractAndClient] ON 

INSERT [dbo].[ContractAndClient] ([id], [FirstName], [Name], [MiddleName], [Number], [Insurance], [DateFirts], [Tern], [IncurancePayment], [GosNumber], [NameCar]) VALUES (6, N'Иконников', N'Артем', N'Олегович', N'79121444996', N'ОСАГО', CAST(N'2023-05-02' AS Date), CAST(N'2023-05-24' AS Date), N'21500.00', N'е666ее', N'BMW')
SET IDENTITY_INSERT [dbo].[ContractAndClient] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 

INSERT [dbo].[User] ([id], [Login], [Password], [Position]) VALUES (1, N'admin', N'admin', N'Administrator')
INSERT [dbo].[User] ([id], [Login], [Password], [Position]) VALUES (2, N'danil', N'123', N'User')
INSERT [dbo].[User] ([id], [Login], [Password], [Position]) VALUES (1003, N'maksim', N'123', N'Programmist')
INSERT [dbo].[User] ([id], [Login], [Password], [Position]) VALUES (1004, N'artem', N'123', N'Programmist')
SET IDENTITY_INSERT [dbo].[User] OFF
GO
USE [master]
GO
ALTER DATABASE [StrahovanieDB] SET  READ_WRITE 
GO

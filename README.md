# NestedGridView
Nested GridView with CRUD functions.
This is the database in Sql Server for this project. Database is called "Biblioteka". To run this database open Sql Server Managment Studio(My version is 2012), if you have Windows Authentication choose Windows or Sql Server Authentication if you have one, click Connect and after create a new database with right select of mouse with the name "Biblioteka".After creating "Biblioteka" right click choose New Query and then copy this code and after click Execute! in the bar menu . Code, copy it all :
USE [master]
GO
/****** Object:  Database [Biblioteka]    Script Date: 6/12/2019 7:25:54 PM ******/
CREATE DATABASE [Biblioteka]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Biblioteka', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Biblioteka.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Biblioteka_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Biblioteka_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Biblioteka] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Biblioteka].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Biblioteka] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Biblioteka] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Biblioteka] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Biblioteka] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Biblioteka] SET ARITHABORT OFF 
GO
ALTER DATABASE [Biblioteka] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Biblioteka] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Biblioteka] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Biblioteka] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Biblioteka] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Biblioteka] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Biblioteka] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Biblioteka] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Biblioteka] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Biblioteka] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Biblioteka] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Biblioteka] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Biblioteka] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Biblioteka] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Biblioteka] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Biblioteka] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Biblioteka] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Biblioteka] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Biblioteka] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Biblioteka] SET  MULTI_USER 
GO
ALTER DATABASE [Biblioteka] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Biblioteka] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Biblioteka] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Biblioteka] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Biblioteka]
GO
/****** Object:  Table [dbo].[libri]    Script Date: 6/12/2019 7:25:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[libri](
	[LiberID] [int] IDENTITY(1,1) NOT NULL,
	[Titulli i Librit] [varchar](50) NULL,
	[Lloji] [varchar](50) NULL,
	[Nr i faqeve] [varchar](50) NULL,
	[Viti i botimit] [varchar](50) NULL,
	[Gjendja e librit] [varchar](50) NULL,
	[ISBN  e librit] [varchar](50) NULL,
	[Data e marre] [varchar](50) NULL,
	[LexuesiID] [int] NULL,
	[Autori] [varchar](50) NULL,
 CONSTRAINT [PK_libri1] PRIMARY KEY CLUSTERED 
(
	[LiberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[personi]    Script Date: 6/12/2019 7:25:55 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[personi](
	[LexuesiID] [int] IDENTITY(1,3) NOT NULL,
	[Emri] [varchar](50) NULL,
	[Mbiemri] [varchar](50) NULL,
	[Celulari] [varchar](50) NULL,
	[Emaili] [varchar](50) NULL,
	[Data e dorezimit] [date] NULL,
 CONSTRAINT [PK_libri] PRIMARY KEY CLUSTERED 
(
	[LexuesiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[libri] ON 

INSERT [dbo].[libri] ([LiberID], [Titulli i Librit], [Lloji], [Nr i faqeve], [Viti i botimit], [Gjendja e librit], [ISBN  e librit], [Data e marre], [LexuesiID], [Autori]) VALUES (1010, N'Keshtjella', N'roman', N'300', N'1987', N'i vjeter', N'1012101547', N'7/5/2018', 3007, N'ismail kadare')
INSERT [dbo].[libri] ([LiberID], [Titulli i Librit], [Lloji], [Nr i faqeve], [Viti i botimit], [Gjendja e librit], [ISBN  e librit], [Data e marre], [LexuesiID], [Autori]) VALUES (1012, N'novelat e qytetit te veriut', N'roman', N'190', N'1924', N'i vjeter', N'1098587', N'1/2/2014', 3043, N'migjeni')
INSERT [dbo].[libri] ([LiberID], [Titulli i Librit], [Lloji], [Nr i faqeve], [Viti i botimit], [Gjendja e librit], [ISBN  e librit], [Data e marre], [LexuesiID], [Autori]) VALUES (1013, N'jjjjjjjj', N'ggg', N'gggg', N'hhhh', N'hhghgghg', N'hhghhh', N'1/1/1990', 3007, N'vggggg')
SET IDENTITY_INSERT [dbo].[libri] OFF
SET IDENTITY_INSERT [dbo].[personi] ON 

INSERT [dbo].[personi] ([LexuesiID], [Emri], [Mbiemri], [Celulari], [Emaili], [Data e dorezimit]) VALUES (3007, N'barjam', N'', N'', N'', CAST(0x5B950A00 AS Date))
INSERT [dbo].[personi] ([LexuesiID], [Emri], [Mbiemri], [Celulari], [Emaili], [Data e dorezimit]) VALUES (3040, N'Endri1', N'Zylali1', N'0000072', N'endri@gmail.com', CAST(0xFF3F0B00 AS Date))
INSERT [dbo].[personi] ([LexuesiID], [Emri], [Mbiemri], [Celulari], [Emaili], [Data e dorezimit]) VALUES (3043, N'test1', N'test2', N'0252558', N'tets@gmail.com', CAST(0x6E390B00 AS Date))
INSERT [dbo].[personi] ([LexuesiID], [Emri], [Mbiemri], [Celulari], [Emaili], [Data e dorezimit]) VALUES (3046, N'test', N'test', N'123', N'w@w', CAST(0x79390B00 AS Date))
SET IDENTITY_INSERT [dbo].[personi] OFF
ALTER TABLE [dbo].[libri]  WITH CHECK ADD  CONSTRAINT [FK_Libri_Personi] FOREIGN KEY([LexuesiID])
REFERENCES [dbo].[personi] ([LexuesiID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[libri] CHECK CONSTRAINT [FK_Libri_Personi]
GO
USE [master]
GO
ALTER DATABASE [Biblioteka] SET  READ_WRITE 
GO

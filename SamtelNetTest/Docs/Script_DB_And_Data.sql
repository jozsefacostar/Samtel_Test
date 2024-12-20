USE [master]
GO
/****** Object:  Database [TestSamtelNET]    Script Date: 28/11/2024 1:25:41 p. m. ******/
CREATE DATABASE [TestSamtelNET]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'TestSamtelNET', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TestSamtelNET.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'TestSamtelNET_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\TestSamtelNET_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [TestSamtelNET] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [TestSamtelNET].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [TestSamtelNET] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [TestSamtelNET] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [TestSamtelNET] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [TestSamtelNET] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [TestSamtelNET] SET ARITHABORT OFF 
GO
ALTER DATABASE [TestSamtelNET] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [TestSamtelNET] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [TestSamtelNET] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [TestSamtelNET] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [TestSamtelNET] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [TestSamtelNET] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [TestSamtelNET] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [TestSamtelNET] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [TestSamtelNET] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [TestSamtelNET] SET  DISABLE_BROKER 
GO
ALTER DATABASE [TestSamtelNET] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [TestSamtelNET] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [TestSamtelNET] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [TestSamtelNET] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [TestSamtelNET] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [TestSamtelNET] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [TestSamtelNET] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [TestSamtelNET] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [TestSamtelNET] SET  MULTI_USER 
GO
ALTER DATABASE [TestSamtelNET] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [TestSamtelNET] SET DB_CHAINING OFF 
GO
ALTER DATABASE [TestSamtelNET] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [TestSamtelNET] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [TestSamtelNET] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [TestSamtelNET] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [TestSamtelNET] SET QUERY_STORE = OFF
GO
USE [TestSamtelNET]
GO
/****** Object:  Table [dbo].[Areas]    Script Date: 28/11/2024 1:25:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Areas](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nchar](100) NOT NULL,
	[Code] [nchar](10) NOT NULL,
	[Active] [tinyint] NOT NULL,
 CONSTRAINT [PK_Areas] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 28/11/2024 1:25:41 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nchar](50) NOT NULL,
	[LastName] [nchar](50) NOT NULL,
	[Address] [nchar](200) NOT NULL,
	[Birthday] [date] NOT NULL,
	[Area] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[Areas] ([Id], [Name], [Code], [Active]) VALUES (N'1bca209f-6ef4-40b9-8686-325c80027b30', N'TECNOLOGIA                                                                                          ', N'S         ', 1)
INSERT [dbo].[Areas] ([Id], [Name], [Code], [Active]) VALUES (N'42e399d4-0c30-455e-93f1-7a42d471387e', N'NOMINA                                                                                              ', N'NOMI      ', 1)
INSERT [dbo].[Areas] ([Id], [Name], [Code], [Active]) VALUES (N'61f42775-2ff9-4455-ba80-81a9ae84e773', N'FACTURACIÓN                                                                                         ', N'FACT      ', 1)
INSERT [dbo].[Areas] ([Id], [Name], [Code], [Active]) VALUES (N'5319767d-a8ad-4148-b944-bef81e1648c4', N'BODEGA                                                                                              ', N'BODE      ', 1)
INSERT [dbo].[Areas] ([Id], [Name], [Code], [Active]) VALUES (N'b55f5b1d-1d60-4359-86a5-c4c8a589eba8', N'LOGISITICA                                                                                          ', N'LOGI      ', 1)
INSERT [dbo].[Areas] ([Id], [Name], [Code], [Active]) VALUES (N'a79775ab-0c90-44b4-9fce-fc4f6abe0ea0', N'SERVICIO AL CLIENTE                                                                                 ', N'SERV      ', 1)
GO
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Address], [Birthday], [Area]) VALUES (N'a145e4e0-fcec-49fb-a2da-16a38e097ded', N'EDWIN                                             ', N'ACOSTA                                            ', N'SINCELEJO                                                                                                                                                                                               ', CAST(N'1993-08-09' AS Date), N'b55f5b1d-1d60-4359-86a5-c4c8a589eba8')
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Address], [Birthday], [Area]) VALUES (N'66ea5472-84ba-4e48-b482-487cf79c71c7', N'JOZSEF                                            ', N'ACOSTA                                            ', N'SABANETA                                                                                                                                                                                                ', CAST(N'1990-08-02' AS Date), N'5319767d-a8ad-4148-b944-bef81e1648c4')
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Address], [Birthday], [Area]) VALUES (N'756735df-0600-4995-ab79-6fb0507c8d8e', N'LUISA                                             ', N'MADRID                                            ', N'CRA 32 CLL 45                                                                                                                                                                                           ', CAST(N'2024-12-05' AS Date), NULL)
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Address], [Birthday], [Area]) VALUES (N'3f4dc578-45fa-4ebd-81f4-a9e94363faaa', N'LUIS                                              ', N'MONTIEL                                           ', N'CRA 56 CLL 45 SUR                                                                                                                                                                                       ', CAST(N'1993-03-03' AS Date), NULL)
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Address], [Birthday], [Area]) VALUES (N'cbff437e-8ac4-4ece-9d4b-bfa758879c0b', N'GUSTAVO                                           ', N'PETRO                                             ', N'ARATCATACA                                                                                                                                                                                              ', CAST(N'1998-08-08' AS Date), N'61f42775-2ff9-4455-ba80-81a9ae84e773')
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Address], [Birthday], [Area]) VALUES (N'1a21fa73-babf-4c98-b59f-c6911b4297f1', N'PRUEBA                                            ', N' MAS                                              ', N'NOSE                                                                                                                                                                                                    ', CAST(N'1968-02-02' AS Date), NULL)
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Address], [Birthday], [Area]) VALUES (N'd33bb846-57cc-400e-9a19-cc9775802027', N'LEIDY                                             ', N'PETRO                                             ', N'CRA 54 CLL 78                                                                                                                                                                                           ', CAST(N'2002-02-02' AS Date), N'b55f5b1d-1d60-4359-86a5-c4c8a589eba8')
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Address], [Birthday], [Area]) VALUES (N'55331be2-a514-4958-867d-e98cc7a064b5', N'SOFIA                                             ', N'ÑAMES                                             ', N'NOSE                                                                                                                                                                                                    ', CAST(N'0001-01-01' AS Date), NULL)
GO
/****** Object:  Index [IX_Users]    Script Date: 28/11/2024 1:25:41 p. m. ******/
CREATE NONCLUSTERED INDEX [IX_Users] ON [dbo].[Users]
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Users]  WITH CHECK ADD  CONSTRAINT [FK_Users_Areas] FOREIGN KEY([Area])
REFERENCES [dbo].[Areas] ([Id])
GO
ALTER TABLE [dbo].[Users] CHECK CONSTRAINT [FK_Users_Areas]
GO
USE [master]
GO
ALTER DATABASE [TestSamtelNET] SET  READ_WRITE 
GO

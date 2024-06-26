USE [master]
GO
/****** Object:  Database [Телефонный справочник]    Script Date: 15.05.2024 11:43:45 ******/
CREATE DATABASE [Телефонный справочник]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Телефонный справочник', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Телефонный справочник.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Телефонный справочник_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.SQLEXPRESS\MSSQL\DATA\Телефонный справочник_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Телефонный справочник] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Телефонный справочник].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Телефонный справочник] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Телефонный справочник] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Телефонный справочник] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Телефонный справочник] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Телефонный справочник] SET ARITHABORT OFF 
GO
ALTER DATABASE [Телефонный справочник] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Телефонный справочник] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Телефонный справочник] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Телефонный справочник] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Телефонный справочник] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Телефонный справочник] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Телефонный справочник] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Телефонный справочник] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Телефонный справочник] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Телефонный справочник] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Телефонный справочник] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Телефонный справочник] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Телефонный справочник] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Телефонный справочник] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Телефонный справочник] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Телефонный справочник] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Телефонный справочник] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Телефонный справочник] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Телефонный справочник] SET  MULTI_USER 
GO
ALTER DATABASE [Телефонный справочник] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Телефонный справочник] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Телефонный справочник] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Телефонный справочник] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [Телефонный справочник]
GO
/****** Object:  Table [dbo].[Группа_контактов]    Script Date: 15.05.2024 11:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Группа_контактов](
	[ID] [int] NOT NULL,
	[Название_группы] [nvarchar](50) NULL,
 CONSTRAINT [PK_Группа_контактов] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Контакт]    Script Date: 15.05.2024 11:43:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Контакт](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Фамилия] [nvarchar](50) NULL,
	[Имя] [nvarchar](50) NULL,
	[Отчество] [nvarchar](50) NULL,
	[Номер_Телефона] [nvarchar](50) NULL,
	[E_mail] [nvarchar](50) NULL,
	[Дата_Рождения] [datetime] NULL,
	[Компания] [int] NULL,
	[Должность] [nvarchar](50) NULL,
	[Фотография] [varbinary](max) NULL,
	[ID_Группа_контактов] [int] NULL,
 CONSTRAINT [PK_Контакт] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Контакт_Группа_контактов]    Script Date: 15.05.2024 11:43:46 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Контакт_Группа_контактов] ON [dbo].[Контакт]
(
	[ID_Группа_контактов] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Контакт]  WITH CHECK ADD  CONSTRAINT [FK_Контакт_Группа_контактов] FOREIGN KEY([ID_Группа_контактов])
REFERENCES [dbo].[Группа_контактов] ([ID])
GO
ALTER TABLE [dbo].[Контакт] CHECK CONSTRAINT [FK_Контакт_Группа_контактов]
GO
USE [master]
GO
ALTER DATABASE [Телефонный справочник] SET  READ_WRITE 
GO

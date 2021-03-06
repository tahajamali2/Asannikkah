USE [master]
GO
/****** Object:  Database [Asannikkah]    Script Date: 2/23/2017 1:09:04 AM ******/
CREATE DATABASE [Asannikkah]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Asannikkah', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Asannikkah.mdf' , SIZE = 3264KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Asannikkah_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\Asannikkah_log.ldf' , SIZE = 816KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Asannikkah] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Asannikkah].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Asannikkah] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Asannikkah] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Asannikkah] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Asannikkah] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Asannikkah] SET ARITHABORT OFF 
GO
ALTER DATABASE [Asannikkah] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Asannikkah] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Asannikkah] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Asannikkah] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Asannikkah] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Asannikkah] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Asannikkah] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Asannikkah] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Asannikkah] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Asannikkah] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Asannikkah] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Asannikkah] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Asannikkah] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Asannikkah] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Asannikkah] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Asannikkah] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Asannikkah] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Asannikkah] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Asannikkah] SET  MULTI_USER 
GO
ALTER DATABASE [Asannikkah] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Asannikkah] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Asannikkah] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Asannikkah] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Asannikkah] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Asannikkah]
GO
/****** Object:  UserDefinedTableType [dbo].[Caterer_Type]    Script Date: 2/23/2017 1:09:04 AM ******/
CREATE TYPE [dbo].[Caterer_Type] AS TABLE(
	[Caterer_ID] [int] NULL,
	[Caterer_Name] [varchar](max) NULL,
	[Username] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
	[Email] [varchar](max) NULL,
	[Country] [varchar](max) NULL,
	[City] [varchar](max) NULL,
	[Buffet_PH] [varchar](max) NULL,
	[Speciality] [varchar](max) NULL,
	[Office_Contact] [varchar](max) NULL,
	[Office_Hours_From] [varchar](max) NULL,
	[Office_Hours_To] [varchar](max) NULL,
	[Website_Url] [varchar](max) NULL,
	[Facebook_Page] [varchar](max) NULL,
	[Longitude] [varchar](max) NULL,
	[Latitude] [varchar](max) NULL,
	[Img1] [varchar](max) NULL,
	[Img2] [varchar](max) NULL,
	[Img3] [varchar](max) NULL,
	[Img4] [varchar](max) NULL,
	[Img5] [varchar](max) NULL,
	[Isactive] [bit] NULL,
	[IsAdminAproved] [bit] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Email_Verification_Type]    Script Date: 2/23/2017 1:09:05 AM ******/
CREATE TYPE [dbo].[Email_Verification_Type] AS TABLE(
	[EmailVerificationID] [int] NULL,
	[VerficationCode] [varchar](max) NULL,
	[ExpiryDate] [datetime] NULL,
	[MemberId] [int] NULL,
	[Isused] [bit] NULL,
	[ProfileType] [varchar](max) NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Hall_Type]    Script Date: 2/23/2017 1:09:05 AM ******/
CREATE TYPE [dbo].[Hall_Type] AS TABLE(
	[Hall_ID] [int] NULL,
	[Hall_Name] [varchar](max) NULL,
	[Username] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
	[Email] [varchar](max) NULL,
	[Country] [varchar](max) NULL,
	[City] [varchar](max) NULL,
	[Capacity] [varchar](max) NULL,
	[Amount] [varchar](max) NULL,
	[Type] [varchar](max) NULL,
	[Office_Contact] [varchar](max) NULL,
	[Office_Hours_From] [varchar](max) NULL,
	[Office_Hours_To] [varchar](max) NULL,
	[Website_Url] [varchar](max) NULL,
	[Facebook_Page] [varchar](max) NULL,
	[Longitude] [varchar](max) NULL,
	[Latitude] [varchar](max) NULL,
	[Img1] [varchar](max) NULL,
	[Img2] [varchar](max) NULL,
	[Img3] [varchar](max) NULL,
	[Img4] [varchar](max) NULL,
	[Img5] [varchar](max) NULL,
	[Isactive] [bit] NULL,
	[IsAdminAproved] [bit] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[Member_Basic_Type]    Script Date: 2/23/2017 1:09:05 AM ******/
CREATE TYPE [dbo].[Member_Basic_Type] AS TABLE(
	[MemberID] [int] NULL,
	[Username] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
	[FirstName] [varchar](max) NULL,
	[LastName] [varchar](max) NULL,
	[Email] [varchar](max) NULL,
	[DOB] [date] NULL,
	[Gender] [varchar](6) NULL,
	[Country] [varchar](max) NULL,
	[City] [varchar](max) NULL,
	[Isactive] [bit] NULL,
	[IsAdminAproved] [bit] NULL
)
GO
/****** Object:  UserDefinedTableType [dbo].[PasswordRecovery_Type]    Script Date: 2/23/2017 1:09:05 AM ******/
CREATE TYPE [dbo].[PasswordRecovery_Type] AS TABLE(
	[PasswordRecoveryID] [int] NULL,
	[RecoveryCode] [varchar](max) NULL,
	[ExpiryDate] [datetime] NULL,
	[MemberId] [int] NULL,
	[Isused] [bit] NULL,
	[ProfileType] [varchar](20) NULL
)
GO
/****** Object:  Table [dbo].[Caterer_TB]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Caterer_TB](
	[Caterer_ID] [int] IDENTITY(1,1) NOT NULL,
	[Caterer_Name] [varchar](max) NULL,
	[Username] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
	[Email] [varchar](max) NULL,
	[Country] [varchar](max) NULL,
	[City] [varchar](max) NULL,
	[Buffet_PH] [varchar](max) NULL,
	[Speciality] [varchar](max) NULL,
	[Office_Contact] [varchar](max) NULL,
	[Office_Hours_From] [varchar](max) NULL,
	[Office_Hours_To] [varchar](max) NULL,
	[Website_Url] [varchar](max) NULL,
	[Facebook_Page] [varchar](max) NULL,
	[Longitude] [varchar](max) NULL,
	[Latitude] [varchar](max) NULL,
	[Img1] [varchar](max) NULL,
	[Img2] [varchar](max) NULL,
	[Img3] [varchar](max) NULL,
	[Img4] [varchar](max) NULL,
	[Img5] [varchar](max) NULL,
	[Isactive] [bit] NULL,
	[IsAdminAproved] [bit] NULL,
 CONSTRAINT [PK_Caterer_TB] PRIMARY KEY CLUSTERED 
(
	[Caterer_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CatererFeedback_TB]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CatererFeedback_TB](
	[CatererFeedbackId] [int] IDENTITY(1,1) NOT NULL,
	[Rating] [decimal](9, 2) NULL,
	[Feedback] [varchar](max) NULL,
	[MemberId] [int] NULL,
	[FeedbackDate] [date] NULL,
	[Caterer_Id] [int] NULL,
 CONSTRAINT [PK_CatererFeedback_TB] PRIMARY KEY CLUSTERED 
(
	[CatererFeedbackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CatererImageUpdate_TB]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CatererImageUpdate_TB](
	[C_ImageUpdate_Id] [int] NOT NULL,
	[C_ImgPath] [varchar](max) NULL,
	[C_Isapprove] [bit] NULL,
	[C_Position] [varchar](20) NULL,
	[C_UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_CatererImageUpdate_TB] PRIMARY KEY CLUSTERED 
(
	[C_ImageUpdate_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CatererUpdateLog_TB]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CatererUpdateLog_TB](
	[C_Updatelog_Id] [int] IDENTITY(1,1) NOT NULL,
	[Log_Description] [text] NULL,
	[Caterer_Id] [int] NULL,
	[UpdatedDate] [datetime] NULL,
 CONSTRAINT [PK_CatererUpdateLog_TB] PRIMARY KEY CLUSTERED 
(
	[C_Updatelog_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Email_Verification_TB]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Email_Verification_TB](
	[EmailVerificationID] [int] IDENTITY(1,1) NOT NULL,
	[VerficationCode] [varchar](max) NULL,
	[ExpiryDate] [datetime] NULL,
	[MemberId] [int] NULL,
	[Isused] [bit] NULL,
	[ProfileType] [varchar](max) NULL,
 CONSTRAINT [PK_Email_Verification_TB] PRIMARY KEY CLUSTERED 
(
	[EmailVerificationID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Hall_TB]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Hall_TB](
	[Hall_ID] [int] IDENTITY(1,1) NOT NULL,
	[Hall_Name] [varchar](max) NULL,
	[Username] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
	[Email] [varchar](max) NULL,
	[Country] [varchar](max) NULL,
	[City] [varchar](max) NULL,
	[Capacity] [varchar](max) NULL,
	[Amount] [varchar](max) NULL,
	[Type] [varchar](max) NULL,
	[Office_Contact] [varchar](max) NULL,
	[Office_Hours_From] [varchar](max) NULL,
	[Office_Hours_To] [varchar](max) NULL,
	[Website_Url] [varchar](max) NULL,
	[Facebook_Page] [varchar](max) NULL,
	[Longitude] [varchar](max) NULL,
	[Latitude] [varchar](max) NULL,
	[Img1] [varchar](max) NULL,
	[Img2] [varchar](max) NULL,
	[Img3] [varchar](max) NULL,
	[Img4] [varchar](max) NULL,
	[Img5] [varchar](max) NULL,
	[Isactive] [bit] NULL,
	[IsAdminAproved] [bit] NULL,
 CONSTRAINT [PK_Hall_TB] PRIMARY KEY CLUSTERED 
(
	[Hall_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HallFeedback_TB]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HallFeedback_TB](
	[HallFeedbackId] [int] IDENTITY(1,1) NOT NULL,
	[Rating] [decimal](9, 2) NULL,
	[Feedback] [varchar](max) NULL,
	[MemberId] [int] NULL,
	[FeedbackDate] [date] NULL,
	[Hall_Id] [int] NULL,
 CONSTRAINT [PK_HallFeedback_TB] PRIMARY KEY CLUSTERED 
(
	[HallFeedbackId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HallImageUpdate_TB]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[HallImageUpdate_TB](
	[H_ImageUpdate_Id] [int] IDENTITY(1,1) NOT NULL,
	[H_ImgPath] [varchar](max) NULL,
	[H_Isaprove] [bit] NULL,
	[H_Position] [varchar](20) NULL,
	[H_UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_HallImageUpdate_TB] PRIMARY KEY CLUSTERED 
(
	[H_ImageUpdate_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HallUpdateLog_TB]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HallUpdateLog_TB](
	[H_Updatelog_Id] [int] NOT NULL,
	[Log_Description] [text] NULL,
	[Hall_Id] [int] NULL,
	[UpdateDate] [datetime] NULL,
 CONSTRAINT [PK_HallUpdateLog_TB] PRIMARY KEY CLUSTERED 
(
	[H_Updatelog_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Member_Basic_TB]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Member_Basic_TB](
	[MemberID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](max) NULL,
	[Password] [varchar](max) NULL,
	[FirstName] [varchar](max) NULL,
	[LastName] [varchar](max) NULL,
	[Email] [varchar](max) NULL,
	[DOB] [date] NULL,
	[Gender] [varchar](6) NULL,
	[Country] [varchar](max) NULL,
	[City] [varchar](max) NULL,
	[Isactive] [bit] NULL,
	[IsAdminAproved] [bit] NULL,
 CONSTRAINT [PK_Member_Basic] PRIMARY KEY CLUSTERED 
(
	[MemberID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PasswordRecovery_TB]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PasswordRecovery_TB](
	[PasswordRecoveryID] [int] IDENTITY(1,1) NOT NULL,
	[RecoveryCode] [varchar](max) NULL,
	[ExpiryDate] [datetime] NULL,
	[MemberId] [int] NULL,
	[Isused] [bit] NULL,
	[ProfileType] [varchar](20) NULL,
 CONSTRAINT [PK_PasswordRecovery_TB] PRIMARY KEY CLUSTERED 
(
	[PasswordRecoveryID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[All_Account_VW]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[All_Account_VW] AS

Select CONVERT(varchar(MAX),MemberID)+'-M' AS ID,FirstName+' '+LastName AS Name,Username,[Password],Email ,'M' As ProfileType,IsActive,IsAdminAproved,
'/Content/images/user-icon.png' as Img,Country,City
 from Member_Basic_TB 
 Union
 Select CONVERT(varchar(MAX),Hall_ID)+'-H' AS ID,Hall_Name AS Name,Username,[Password],Email,'H' As ProfileType,IsActive,IsAdminAproved,
 CASE WHEN Img1 IS NULL THEN '/Content/images/hall-icon.png' else '/Content/UploadedData/HallImages/' +Img1 end as Img,Country,City
 from Hall_TB
 Union
  Select CONVERT(varchar(MAX),Caterer_ID)+'-C' AS ID,Caterer_Name AS Name,Username,[Password],Email,'C' As ProfileType,IsActive,IsAdminAproved,
   CASE WHEN Img1 IS NULL THEN '/Content/images/caterer-icon.png' else '/Content/UploadedData/CatererImages/' +Img1 end as Img,Country,City
   from Caterer_TB
GO
/****** Object:  View [dbo].[Caterer_VW]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Caterer_VW] as SELECT * FROM Caterer_TB
GO
/****** Object:  View [dbo].[Email_Verification_VW]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
 CREATE VIEW [dbo].[Email_Verification_VW] as SELECT * FROM Email_Verification_TB
GO
/****** Object:  View [dbo].[Hall_VW]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Hall_VW] as SELECT * FROM Hall_TB
GO
/****** Object:  View [dbo].[Member_Basic_VW]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[Member_Basic_VW] as SELECT * FROM Member_Basic_TB
GO
/****** Object:  View [dbo].[PasswordRecovery_VW]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PasswordRecovery_VW] as SELECT * FROM PasswordRecovery_TB
GO
/****** Object:  StoredProcedure [dbo].[AddCaterer_SP]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[AddCaterer_SP]
@Cat_TVP Caterer_Type READONLY
AS INSERT INTO Caterer_TB([Caterer_Name],[Username],[Password],[Email],[Country],[City],[Buffet_PH],[Speciality],[Office_Contact],[Office_Hours_From],[Office_Hours_To],[Website_Url],[Facebook_Page],[Longitude],[Latitude],[Img1],[Img2],[Img3],[Img4],[Img5],[Isactive],[IsAdminAproved])
 SELECT [Caterer_Name],[Username],[Password],[Email],[Country],[City],[Buffet_PH],[Speciality],[Office_Contact],[Office_Hours_From],[Office_Hours_To],[Website_Url],[Facebook_Page],[Longitude],[Latitude],[Img1],[Img2],[Img3],[Img4],[Img5],[Isactive],[IsAdminAproved] FROM @Cat_TVP;
GO
/****** Object:  StoredProcedure [dbo].[AddCatererRating_SP]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddCatererRating_SP] 
@Rating decimal(9,2) = 0.0,
@Feedback varchar(max) = '',
@MemberId int =-1,
@CatererId int = -1

AS
BEGIN
IF (select count(*) from CatererFeedback_TB where MemberId=@MemberId and Caterer_Id=@CatererId) > 0
BEGIN
Update CatererFeedback_TB SET Rating=@Rating,Feedback=@Feedback,FeedbackDate=GETDATE() where MemberId=@MemberId and Caterer_Id=@CatererId
END
ELSE
BEGIN
INSERT INTO CatererFeedback_TB Values(@Rating,@Feedback,@MemberId,GETDATE(),@CatererId)
END
END
GO
/****** Object:  StoredProcedure [dbo].[AddEmail_Verification_SP]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[AddEmail_Verification_SP]
@Ema_TVP Email_Verification_Type READONLY
AS INSERT INTO Email_Verification_TB([VerficationCode],[ExpiryDate],[MemberId],[Isused],[ProfileType])
 SELECT [VerficationCode],[ExpiryDate],[MemberId],[Isused],[ProfileType] FROM @Ema_TVP;
GO
/****** Object:  StoredProcedure [dbo].[AddHall_SP]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[AddHall_SP]
@Hal_TVP Hall_Type READONLY
AS INSERT INTO Hall_TB([Hall_Name],[Username],[Password],[Email],[Country],[City],[Capacity],[Amount],[Type],[Office_Contact],[Office_Hours_From],[Office_Hours_To],[Website_Url],[Facebook_Page],[Longitude],[Latitude],[Img1],[Img2],[Img3],[Img4],[Img5],[Isactive],[IsAdminAproved])
 SELECT [Hall_Name],[Username],[Password],[Email],[Country],[City],[Capacity],[Amount],[Type],[Office_Contact],[Office_Hours_From],[Office_Hours_To],[Website_Url],[Facebook_Page],[Longitude],[Latitude],[Img1],[Img2],[Img3],[Img4],[Img5],[Isactive],[IsAdminAproved] FROM @Hal_TVP;
GO
/****** Object:  StoredProcedure [dbo].[AddHallRating_SP]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddHallRating_SP] 
@Rating decimal(9,2) = 0.0,
@Feedback varchar(max) = '',
@MemberId int =-1,
@HallId int = -1

AS
BEGIN
IF (select count(*) from HallFeedback_TB where MemberId=@MemberId and Hall_Id=@HallId) > 0
BEGIN
Update HallFeedback_TB SET Rating=@Rating,Feedback=@Feedback,FeedbackDate=GETDATE() where MemberId=@MemberId and Hall_Id=@HallId
END
ELSE
BEGIN
INSERT INTO HallFeedback_TB Values(@Rating,@Feedback,@MemberId,GETDATE(),@HallId)
END
END

GO
/****** Object:  StoredProcedure [dbo].[AddMember_Basic_SP]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[AddMember_Basic_SP]
@Mem_TVP Member_Basic_Type READONLY
AS INSERT INTO Member_Basic_TB([Username],[Password],[FirstName],[LastName],[Email],[DOB],[Gender],[Country],[City],[Isactive],[IsAdminAproved])
 SELECT [Username],[Password],[FirstName],[LastName],[Email],[DOB],[Gender],[Country],[City],[Isactive],[IsAdminAproved] FROM @Mem_TVP;
GO
/****** Object:  StoredProcedure [dbo].[AddPasswordRecovery_SP]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[AddPasswordRecovery_SP]
@Pas_TVP PasswordRecovery_Type READONLY
AS INSERT INTO PasswordRecovery_TB([RecoveryCode],[ExpiryDate],[MemberId],[Isused],[ProfileType])
 SELECT [RecoveryCode],[ExpiryDate],[MemberId],[Isused],[ProfileType] FROM @Pas_TVP;
GO
/****** Object:  StoredProcedure [dbo].[DeleteCaterer_SP]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[DeleteCaterer_SP]
@Cat_TVP Caterer_Type READONLY
AS
DELETE FROM Caterer_TB WHERE Caterer_ID IN (SELECT Caterer_ID FROM @Cat_TVP);
GO
/****** Object:  StoredProcedure [dbo].[DeleteEmail_Verification_SP]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[DeleteEmail_Verification_SP]
@Ema_TVP Email_Verification_Type READONLY
AS
DELETE FROM Email_Verification_TB WHERE EmailVerificationID IN (SELECT EmailVerificationID FROM @Ema_TVP);
GO
/****** Object:  StoredProcedure [dbo].[DeleteHall_SP]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[DeleteHall_SP]
@Hal_TVP Hall_Type READONLY
AS
DELETE FROM Hall_TB WHERE Hall_ID IN (SELECT Hall_ID FROM @Hal_TVP);
GO
/****** Object:  StoredProcedure [dbo].[DeleteMember_Basic_SP]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[DeleteMember_Basic_SP]
@Mem_TVP Member_Basic_Type READONLY
AS
DELETE FROM Member_Basic_TB WHERE MemberID IN (SELECT MemberID FROM @Mem_TVP);
GO
/****** Object:  StoredProcedure [dbo].[DeletePasswordRecovery_SP]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[DeletePasswordRecovery_SP]
@Pas_TVP PasswordRecovery_Type READONLY
AS
DELETE FROM PasswordRecovery_TB WHERE PasswordRecoveryID IN (SELECT PasswordRecoveryID FROM @Pas_TVP);
GO
/****** Object:  StoredProcedure [dbo].[GetCatererLists]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetCatererLists] 
@Country varchar(max) = '-1',
@City varchar(max) = '-1',
@IsFilter bit = 0,
@Page int=1

AS
BEGIN
Declare @CountryFilter varchar(max);
Declare @CityFilter varchar(max);
Declare @IsFiltertx varchar(max);
Declare @Isand varchar(max) = '';
Declare @FilterQuery varchar(max);
Declare @Query varchar(max);

IF @Country!='-1'
BEGIN
SET @CountryFilter = 'Country='''+@Country+''' ';
SET @Isand = ' and ';
END
else
BEGIN
SET @CountryFilter = '';
END;

IF @City!='-1'
BEGIN
SET @CityFilter = @Isand+' City='''+@City+''' ';
SET @Isand = ' and ';
END
ELSE
BEGIN
SET @CityFilter = '';
END;

IF @Isand!=''
BEGIN
SET @FilterQuery = ' WHERE '+@CountryFilter+@CityFilter+'';
END
ELSE
BEGIN
SET @FilterQuery = '';
END;

IF @IsFilter=1
BEGIN
SET @Query = 'SELECT Caterer_ID ID,Caterer_Name Name,Buffet_PH,ISNULL(Office_Contact,''Not Available'') Contact,Email,ISNULL(Office_Hours_From,'''')+'' To ''+ISNULL(Office_Hours_To,'''') as Office_Hours,Country,City,CASE WHEN Longitude IS NULL THEN '''' ELSE Longitude END AS [Longitude],
CASE WHEN Latitude IS NULL THEN '''' ELSE Latitude END AS [Latitude],
CASE WHEN Img1 IS NULL THEN ''/Content/images/caterer-icon.png'' ELSE ''/Content/UploadedData/CatererImages/''+Img1 END AS Img,
CASE WHEN (select SUM(Rating)/CAST(Count(*) as decimal(18,0)) as [AVG] from CatererFeedback_TB
where Caterer_Id=cat.Caterer_ID) IS NULL THEN 0.000000 ELSE (select SUM(Rating)/CAST(Count(*) as decimal(18,0)) as [AVG] from CatererFeedback_TB
where Caterer_Id=cat.Caterer_ID) END AS [Rating]
 FROM Caterer_TB cat'+@FilterQuery+'
 order by [Rating] desc,Buffet_PH desc
 OFFSET '+CAST(((@Page-1)*5) AS VARCHAR(40))+' ROWS
 FETCH NEXT 5 ROWS ONLY 
 '

exec(@Query);

SET @Query = 'SELECT CEILING((Count(*)/CAST(5 AS DECIMAL(9,2)))) AS Pages,'+CAST(@Page AS VARCHAR(max))+' AS CurrentPage
 FROM Caterer_TB '+@FilterQuery

 exec(@Query);

--Select * from ALL_Account_VW
END

ELSE
BEGIN

SET @Query='
select * into #raw3 from
(
SELECT ROW_NUMBER() over(order by Caterer_ID) as [row], Caterer_ID ID,Caterer_Name Name,Buffet_PH,Office_Contact Contact,Email,ISNULL(Office_Hours_From,'''')+'' To ''+ISNULL(Office_Hours_To,'''') as Office_Hours,Country,City,CASE WHEN Longitude IS NULL THEN '''' ELSE Longitude END AS [Longitude],
CASE WHEN Latitude IS NULL THEN '''' ELSE Latitude END AS [Latitude],
CASE WHEN Img1 IS NULL THEN ''/Content/images/caterer-icon.png'' ELSE ''/Content/UploadedData/CatererImages/''+Img1 END AS Img,
CASE WHEN (select SUM(Rating)/CAST(Count(*) as decimal(18,0)) as [AVG] from CatererFeedback_TB
where Caterer_Id=cat.Caterer_ID) IS NULL THEN 0.000000 ELSE (select SUM(Rating)/CAST(Count(*) as decimal(18,0)) as [AVG] from CatererFeedback_TB
where Caterer_Id=cat.Caterer_ID) END AS [Rating]
 FROM Caterer_TB cat Where Country='''+@Country+''' and City='''+@City+'''
 ) as ac
 select * into #raw4 from (
 select  * from #raw3
 union
 SELECT ISNULL((select max([row]) from [#raw3]),0) + ROW_NUMBER() over(order by Caterer_ID) as [row],Caterer_ID ID,Caterer_Name Name,Buffet_PH,Office_Contact Contact,Email,ISNULL(Office_Hours_From,'''')+'' To ''+ISNULL(Office_Hours_To,'''') as Office_Hours,Country,City,CASE WHEN Longitude IS NULL THEN '''' ELSE Longitude END AS [Longitude],
CASE WHEN Latitude IS NULL THEN '''' ELSE Latitude END AS [Latitude],
CASE WHEN Img1 IS NULL THEN ''/Content/images/caterer-icon.png'' ELSE ''/Content/UploadedData/CatererImages/''+Img1 END AS Img,
CASE WHEN (select SUM(Rating)/CAST(Count(*) as decimal(18,0)) as [AVG] from CatererFeedback_TB
where Caterer_Id=cat.Caterer_ID) IS NULL THEN 0.000000 ELSE (select SUM(Rating)/CAST(Count(*) as decimal(18,0)) as [AVG] 
from CatererFeedback_TB
where Caterer_Id=cat.Caterer_ID) END AS [Rating] 
 FROM Caterer_TB cat Where Country='''+@Country+''' and City!='''+@City+''') as ab
 --select * from #raw
 select * into #raw5 from (
 select * from #raw4
 Union
  SELECT ISNULL((select max([row]) from #raw4),0) + ROW_NUMBER() over(order by Caterer_ID) as [row], Caterer_ID ID,Caterer_Name Name,Buffet_PH,Office_Contact Contact,Email,ISNULL(Office_Hours_From,'''')+'' To ''+ISNULL(Office_Hours_To,'''') as Office_Hours,Country,City,CASE WHEN Longitude IS NULL THEN '''' ELSE Longitude END AS [Longitude],
CASE WHEN Latitude IS NULL THEN '''' ELSE Latitude END AS [Latitude],
CASE WHEN Img1 IS NULL THEN ''/Content/images/caterer-icon.png'' ELSE ''/Content/UploadedData/CatererImages/''+Img1 END AS Img,
CASE WHEN (select SUM(Rating)/CAST(Count(*) as decimal(18,0)) as [AVG] from CatererFeedback_TB
where Caterer_Id=cat.Caterer_ID) IS NULL THEN 0.000000 ELSE (select SUM(Rating)/CAST(Count(*) as decimal(18,0)) as [AVG] from CatererFeedback_TB
where Caterer_Id=cat.Caterer_ID) END AS [Rating]
 FROM Caterer_TB cat Where Country!='''+@Country+''' and City!='''+@City+'''
 ) as bc
 

 select ID,Name,Buffet_PH,ISNULL(Contact,''Not Available'') Contact,Email,CASE WHEN Office_Hours='' To '' THEN ''Not Available'' ELSE Office_Hours END AS [Office_Hours],Country,City,Longitude,Latitude,Img,Rating from #raw5
 order by [row]
 OFFSET '+CAST(((@Page-1)*5) AS VARCHAR(40))+' ROWS
 FETCH NEXT 5 ROWS ONLY
 
  select CEILING((Count(*)/CAST(5 AS DECIMAL(9,2)))) AS Pages,'+CAST(@Page AS VARCHAR(max))+' AS CurrentPage
 from #raw5

 drop table #raw3
 drop table #raw4
 drop table #raw5
 '

 exec(@Query);

END
END
GO
/****** Object:  StoredProcedure [dbo].[GetHallLists]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetHallLists] 
@Country varchar(max) = '-1',
@City varchar(max) = '-1',
@Capacity int = -1,
@Type varchar(max) = '-1',
@IsFilter bit = 0,
@Page int=1

AS
BEGIN
Declare @CountryFilter varchar(max);
Declare @CityFilter varchar(max);
Declare @CapacityFilter varchar(max);
Declare @TypeFilter varchar(max);
Declare @IsFiltertx varchar(max);
Declare @Isand varchar(max) = '';
Declare @FilterQuery varchar(max);
Declare @Query varchar(max);

IF @Country!='-1'
BEGIN
SET @CountryFilter = 'Country='''+@Country+''' ';
SET @Isand = ' and ';
END
else
BEGIN
SET @CountryFilter = '';
END;

IF @City!='-1'
BEGIN
SET @CityFilter = @Isand+' City='''+@City+''' ';
SET @Isand = ' and ';
END
ELSE
BEGIN
SET @CityFilter = '';
END;

IF @Capacity!=-1
BEGIN
SET @CapacityFilter = @Isand+' Capacity >= '+CAST(@Capacity AS varchar(40))+' ';
SET @Isand = ' and ';
END
ELSE
BEGIN
SET @CapacityFilter = '';
END;


IF @Type!='-1'
BEGIN
SET @TypeFilter = @Isand+' Type='''+@Type+''' ';
SET @Isand = ' and ';
END
ELSE
BEGIN
SET @TypeFilter = '';
END;


IF @Isand!=''
BEGIN
SET @FilterQuery = ' WHERE '+@CountryFilter+@CityFilter+@CapacityFilter+@TypeFilter+'';
END
ELSE
BEGIN
SET @FilterQuery = '';
END;

IF @IsFilter=1
BEGIN
SET @Query = 'SELECT Hall_ID ID,Hall_Name Name,Email,Capacity,Amount,ISNULL(Office_Contact,''Not Available'') Contact,Type,Country,City,CASE WHEN Longitude IS NULL THEN '''' ELSE Longitude END AS [Longitude],
CASE WHEN Latitude IS NULL THEN '''' ELSE Latitude END AS [Latitude],
CASE WHEN Img1 IS NULL THEN ''/Content/images/hall-icon.png'' ELSE ''/Content/UploadedData/HallImages/''+Img1 END AS Img,
CASE WHEN (select SUM(Rating)/CAST(Count(*) as decimal(18,0)) as [AVG] from HallFeedback_TB
where Hall_Id=hal.Hall_ID) IS NULL THEN 0.000000 ELSE (select SUM(Rating)/CAST(Count(*) as decimal(18,0)) as [AVG] from HallFeedback_TB
where Hall_Id=hal.Hall_ID) END AS [Rating]
 FROM Hall_TB hal'+@FilterQuery+'
 order by [Rating] desc,Amount desc
 OFFSET '+CAST(((@Page-1)*5) AS VARCHAR(40))+' ROWS
 FETCH NEXT 5 ROWS ONLY 
 '

exec(@Query);

SET @Query = 'SELECT CASE WHEN CEILING((Count(*)/CAST(5 AS DECIMAL(9,2)))) = 0 THEN 1 ELSE CEILING((Count(*)/CAST(5 AS DECIMAL(9,2)))) END AS Pages,'+CAST(@Page AS VARCHAR(max))+' AS CurrentPage
 FROM Hall_TB '+@FilterQuery

 exec(@Query);

--Select * from ALL_Account_VW
END

ELSE
BEGIN

SET @Query='
select * into #raw0 from
(
SELECT ROW_NUMBER() over(order by Hall_ID) as [row], Hall_ID ID,Hall_Name Name,Email,Capacity,Amount,Office_Contact Contact,Type,Country,City,CASE WHEN Longitude IS NULL THEN '''' ELSE Longitude END AS [Longitude],
CASE WHEN Latitude IS NULL THEN '''' ELSE Latitude END AS [Latitude],
CASE WHEN Img1 IS NULL THEN ''/Content/images/hall-icon.png'' ELSE ''/Content/UploadedData/HallImages/''+Img1 END AS Img,
CASE WHEN (select SUM(Rating)/CAST(Count(*) as decimal(18,0)) as [AVG] from HallFeedback_TB
where Hall_Id=hal.Hall_ID) IS NULL THEN 0.000000 ELSE (select SUM(Rating)/CAST(Count(*) as decimal(18,0)) as [AVG] from HallFeedback_TB
where Hall_Id=hal.Hall_ID) END AS [Rating]
 FROM Hall_TB hal Where Country='''+@Country+''' and City='''+@City+'''
 ) as ac
 select * into #raw from (
 select  * from #raw0
 union
 SELECT ISNULL((select max([row]) from [#raw0]),0) + ROW_NUMBER() over(order by Hall_ID) [row],Hall_ID ID,Hall_Name Name,Email,Capacity,Amount,Office_Contact Contact,Type,Country,City,CASE WHEN Longitude IS NULL THEN '''' ELSE Longitude END AS [Longitude],
CASE WHEN Latitude IS NULL THEN '''' ELSE Latitude END AS [Latitude],
CASE WHEN Img1 IS NULL THEN ''/Content/images/hall-icon.png'' ELSE ''/Content/UploadedData/HallImages/''+Img1 END AS Img,
CASE WHEN (select SUM(Rating)/CAST(Count(*) as decimal(18,0)) as [AVG] from HallFeedback_TB
where Hall_Id=hal.Hall_ID) IS NULL THEN 0.000000 ELSE (select SUM(Rating)/CAST(Count(*) as decimal(18,0)) as [AVG] 
from HallFeedback_TB
where Hall_Id=hal.Hall_ID) END AS [Rating] 
 FROM Hall_TB hal Where Country='''+@Country+''' and City!='''+@City+''') as ab
 --select * from #raw
 select * into #raw2 from (
 select * from #raw
 Union
  SELECT ISNULL((select max([row]) from #raw),0) + ROW_NUMBER() over(order by Hall_ID) [row], Hall_ID ID,Hall_Name Name,Email,Capacity,Amount,Office_Contact Contact,Type,Country,City,CASE WHEN Longitude IS NULL THEN '''' ELSE Longitude END AS [Longitude],
CASE WHEN Latitude IS NULL THEN '''' ELSE Latitude END AS [Latitude],
CASE WHEN Img1 IS NULL THEN ''/Content/images/hall-icon.png'' ELSE ''/Content/UploadedData/HallImages/''+Img1 END AS Img,
CASE WHEN (select SUM(Rating)/CAST(Count(*) as decimal(18,0)) as [AVG] from HallFeedback_TB
where Hall_Id=hal.Hall_ID) IS NULL THEN 0.000000 ELSE (select SUM(Rating)/CAST(Count(*) as decimal(18,0)) as [AVG] from HallFeedback_TB
where Hall_Id=hal.Hall_ID) END AS [Rating]
 FROM Hall_TB hal Where Country!='''+@Country+''' and City!='''+@City+'''
 ) as bc
 

 select [row],ID,Name,Email,Capacity,Amount,ISNULL(Contact,''Not Available'') Contact,Type,Country,City,Longitude,Latitude,Img,Rating
 from #raw2
  order by ID
  OFFSET '+CAST(((@Page-1)*5) AS VARCHAR(40))+' ROWS
 FETCH NEXT 5 ROWS ONLY 

 
  select CASE WHEN CEILING((Count(*)/CAST(5 AS DECIMAL(9,2)))) = 0 THEN 1 ELSE CEILING((Count(*)/CAST(5 AS DECIMAL(9,2)))) END AS Pages,'+CAST(@Page AS VARCHAR(max))+' AS CurrentPage
 from #raw2

 drop table #raw0
 drop table #raw
 drop table #raw2
 '

 exec(@Query);

END
END
GO
/****** Object:  StoredProcedure [dbo].[UpdateCaterer_SP]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[UpdateCaterer_SP]
@Cat_TVP Caterer_Type READONLY
AS
Update Caterer_TB SET[Caterer_Name] = i.[Caterer_Name],
[Username] = i.[Username],
[Password] = i.[Password],
[Email] = i.[Email],
[Country] = i.[Country],
[City] = i.[City],
[Buffet_PH] = i.[Buffet_PH],
[Speciality] = i.[Speciality],
[Office_Contact] = i.[Office_Contact],
[Office_Hours_From] = i.[Office_Hours_From],
[Office_Hours_To] = i.[Office_Hours_To],
[Website_Url] = i.[Website_Url],
[Facebook_Page] = i.[Facebook_Page],
[Longitude] = i.[Longitude],
[Latitude] = i.[Latitude],
[Img1] = i.[Img1],
[Img2] = i.[Img2],
[Img3] = i.[Img3],
[Img4] = i.[Img4],
[Img5] = i.[Img5],
[Isactive] = i.[Isactive],
[IsAdminAproved] = i.[IsAdminAproved]
FROM (SELECT * FROM @Cat_TVP) i
WHERE Caterer_TB.Caterer_ID = i.Caterer_ID;
GO
/****** Object:  StoredProcedure [dbo].[UpdateEmail_Verification_SP]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[UpdateEmail_Verification_SP]
@Ema_TVP Email_Verification_Type READONLY
AS
Update Email_Verification_TB SET[VerficationCode] = i.[VerficationCode],
[ExpiryDate] = i.[ExpiryDate],
[MemberId] = i.[MemberId],
[Isused] = i.[Isused],
[ProfileType] = i.[ProfileType]
FROM (SELECT * FROM @Ema_TVP) i
WHERE Email_Verification_TB.EmailVerificationID = i.EmailVerificationID;
GO
/****** Object:  StoredProcedure [dbo].[UpdateHall_SP]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[UpdateHall_SP]
@Hal_TVP Hall_Type READONLY
AS
Update Hall_TB SET[Hall_Name] = i.[Hall_Name],
[Username] = i.[Username],
[Password] = i.[Password],
[Email] = i.[Email],
[Country] = i.[Country],
[City] = i.[City],
[Capacity] = i.[Capacity],
[Amount] = i.[Amount],
[Type] = i.[Type],
[Office_Contact] = i.[Office_Contact],
[Office_Hours_From] = i.[Office_Hours_From],
[Office_Hours_To] = i.[Office_Hours_To],
[Website_Url] = i.[Website_Url],
[Facebook_Page] = i.[Facebook_Page],
[Longitude] = i.[Longitude],
[Latitude] = i.[Latitude],
[Img1] = i.[Img1],
[Img2] = i.[Img2],
[Img3] = i.[Img3],
[Img4] = i.[Img4],
[Img5] = i.[Img5],
[Isactive] = i.[Isactive],
[IsAdminAproved] = i.[IsAdminAproved]
FROM (SELECT * FROM @Hal_TVP) i
WHERE Hall_TB.Hall_ID = i.Hall_ID;
GO
/****** Object:  StoredProcedure [dbo].[UpdateMember_Basic_SP]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[UpdateMember_Basic_SP]
@Mem_TVP Member_Basic_Type READONLY
AS
Update Member_Basic_TB SET[Username] = i.[Username],
[Password] = i.[Password],
[FirstName] = i.[FirstName],
[LastName] = i.[LastName],
[Email] = i.[Email],
[DOB] = i.[DOB],
[Gender] = i.[Gender],
[Country] = i.[Country],
[City] = i.[City],
[Isactive] = i.[Isactive],
[IsAdminAproved] = i.[IsAdminAproved]
FROM (SELECT * FROM @Mem_TVP) i
WHERE Member_Basic_TB.MemberID = i.MemberID;
GO
/****** Object:  StoredProcedure [dbo].[UpdatePasswordRecovery_SP]    Script Date: 2/23/2017 1:09:05 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE  PROCEDURE [dbo].[UpdatePasswordRecovery_SP]
@Pas_TVP PasswordRecovery_Type READONLY
AS
Update PasswordRecovery_TB SET[RecoveryCode] = i.[RecoveryCode],
[ExpiryDate] = i.[ExpiryDate],
[MemberId] = i.[MemberId],
[Isused] = i.[Isused],
[ProfileType] = i.[ProfileType]
FROM (SELECT * FROM @Pas_TVP) i
WHERE PasswordRecovery_TB.PasswordRecoveryID = i.PasswordRecoveryID;
GO
USE [master]
GO
ALTER DATABASE [Asannikkah] SET  READ_WRITE 
GO

USE [master]
GO
/****** Object:  Database [HealthPlanDatabase]    Script Date: 8/21/2015 6:53:02 PM ******/
CREATE DATABASE [HealthPlanDatabase]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HealthPlanDatabaseTest', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\HealthPlanDatabaseTest.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HealthPlanDatabaseTest_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\HealthPlanDatabaseTest_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HealthPlanDatabase] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HealthPlanDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HealthPlanDatabase] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HealthPlanDatabase] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HealthPlanDatabase] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HealthPlanDatabase] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HealthPlanDatabase] SET ARITHABORT OFF 
GO
ALTER DATABASE [HealthPlanDatabase] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [HealthPlanDatabase] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [HealthPlanDatabase] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HealthPlanDatabase] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HealthPlanDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HealthPlanDatabase] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HealthPlanDatabase] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HealthPlanDatabase] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HealthPlanDatabase] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HealthPlanDatabase] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HealthPlanDatabase] SET  DISABLE_BROKER 
GO
ALTER DATABASE [HealthPlanDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HealthPlanDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HealthPlanDatabase] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HealthPlanDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HealthPlanDatabase] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HealthPlanDatabase] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HealthPlanDatabase] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HealthPlanDatabase] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HealthPlanDatabase] SET  MULTI_USER 
GO
ALTER DATABASE [HealthPlanDatabase] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HealthPlanDatabase] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HealthPlanDatabase] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HealthPlanDatabase] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [HealthPlanDatabase]
GO
/****** Object:  Table [dbo].[Deductible]    Script Date: 8/21/2015 6:53:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deductible](
	[DeductibleId] [int] IDENTITY(1,1) NOT NULL,
	[HealthPlanId] [int] NOT NULL,
	[DeductibleCode] [nchar](10) NULL,
	[IndividualDedAmt] [decimal](18, 0) NULL,
	[FamilyDedAmt] [decimal](18, 0) NULL,
	[MaxDeductibleAmountPerIndividual] [decimal](18, 0) NULL,
	[ServicesCoveredBeforeDeductibleMetBool] [bit] NULL,
	[DeductibleIncdInOutOfPcktBool] [bit] NULL,
	[AnnualLimitsPlanBool] [bit] NULL,
	[AnnualPremium] [decimal](18, 0) NULL,
	[CoinsuranceUpper] [decimal](18, 0) NULL,
	[CoinsuranceLower] [decimal](18, 0) NULL,
	[AnnualLimitHigher] [decimal](18, 0) NULL,
	[AnnualLimitLower] [decimal](18, 0) NULL,
	[TotalEstimatedCost] [decimal](18, 0) NULL,
 CONSTRAINT [PK_Deductible_1] PRIMARY KEY CLUSTERED 
(
	[DeductibleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HealthPlan]    Script Date: 8/21/2015 6:53:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HealthPlan](
	[HealthPlanId] [int] IDENTITY(1,1) NOT NULL,
	[HealthPlanCode] [nchar](10) NULL,
	[HealthPlanDescription] [nvarchar](50) NULL,
	[PCPrequiredBool] [bit] NULL,
	[PCPNetworkBool] [bit] NULL,
 CONSTRAINT [PK_HealthPlan] PRIMARY KEY CLUSTERED 
(
	[HealthPlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[LoginUser]    Script Date: 8/21/2015 6:53:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[LoginUser](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[FullName] [nchar](10) NULL,
	[Username] [nchar](10) NOT NULL,
	[Password] [nchar](10) NOT NULL,
 CONSTRAINT [PK_LoginUser] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MajorMedical]    Script Date: 8/21/2015 6:53:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MajorMedical](
	[MajorMedicalId] [int] IDENTITY(1,1) NOT NULL,
	[MajorMedicalProvideListBool] [bit] NULL,
	[MajorMedicalDescription] [nvarchar](max) NULL,
	[HealthPlanId] [int] NULL,
 CONSTRAINT [PK_MajorMedical] PRIMARY KEY CLUSTERED 
(
	[MajorMedicalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Organization]    Script Date: 8/21/2015 6:53:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[OrganizationId] [int] IDENTITY(1,1) NOT NULL,
	[OrganizationCode] [nchar](10) NOT NULL,
	[OrganizationName] [nvarchar](50) NULL,
	[OrganizationDescription] [nvarchar](50) NULL,
	[OrganizationPhoneNumber] [nvarchar](10) NULL,
	[OrganizationEmailAddress] [nvarchar](50) NULL,
	[OrganizationAddress] [nvarchar](50) NULL,
	[OrganizationCity] [nvarchar](50) NULL,
	[OrganizationState] [nvarchar](50) NULL,
	[OrganizationZip] [nvarchar](50) NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[OrganizationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PreventiveCare]    Script Date: 8/21/2015 6:53:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreventiveCare](
	[PreventiveCareId] [int] IDENTITY(1,1) NOT NULL,
	[PhysicalExamLimit] [decimal](18, 0) NULL,
	[RoutinePediatricCareLimit] [decimal](18, 0) NULL,
	[ImmunizationLimit] [decimal](18, 0) NULL,
	[HealthPlanId] [int] NULL,
 CONSTRAINT [PK_PreventiveCare] PRIMARY KEY CLUSTERED 
(
	[PreventiveCareId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Deductible]  WITH CHECK ADD  CONSTRAINT [FK_Deductible_HealthPlan] FOREIGN KEY([HealthPlanId])
REFERENCES [dbo].[HealthPlan] ([HealthPlanId])
GO
ALTER TABLE [dbo].[Deductible] CHECK CONSTRAINT [FK_Deductible_HealthPlan]
GO
ALTER TABLE [dbo].[MajorMedical]  WITH CHECK ADD  CONSTRAINT [FK_MajorMedical_HealthPlan] FOREIGN KEY([HealthPlanId])
REFERENCES [dbo].[HealthPlan] ([HealthPlanId])
GO
ALTER TABLE [dbo].[MajorMedical] CHECK CONSTRAINT [FK_MajorMedical_HealthPlan]
GO
ALTER TABLE [dbo].[PreventiveCare]  WITH CHECK ADD  CONSTRAINT [FK_PreventiveCare_HealthPlan] FOREIGN KEY([HealthPlanId])
REFERENCES [dbo].[HealthPlan] ([HealthPlanId])
GO
ALTER TABLE [dbo].[PreventiveCare] CHECK CONSTRAINT [FK_PreventiveCare_HealthPlan]
GO
USE [master]
GO
ALTER DATABASE [HealthPlanDatabase] SET  READ_WRITE 
GO

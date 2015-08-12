USE [master]
GO
/****** Object:  Database [HealthPlanDB]    Script Date: 8/11/2015 10:25:42 PM ******/
CREATE DATABASE [HealthPlanDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'HealthPlan', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\HealthPlan.mdf' , SIZE = 3136KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'HealthPlan_log', FILENAME = N'c:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\HealthPlan_log.ldf' , SIZE = 832KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [HealthPlanDB] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [HealthPlanDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [HealthPlanDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [HealthPlanDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [HealthPlanDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [HealthPlanDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [HealthPlanDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [HealthPlanDB] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [HealthPlanDB] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [HealthPlanDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [HealthPlanDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [HealthPlanDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [HealthPlanDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [HealthPlanDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [HealthPlanDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [HealthPlanDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [HealthPlanDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [HealthPlanDB] SET  ENABLE_BROKER 
GO
ALTER DATABASE [HealthPlanDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [HealthPlanDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [HealthPlanDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [HealthPlanDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [HealthPlanDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [HealthPlanDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [HealthPlanDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [HealthPlanDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [HealthPlanDB] SET  MULTI_USER 
GO
ALTER DATABASE [HealthPlanDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [HealthPlanDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [HealthPlanDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [HealthPlanDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [HealthPlanDB]
GO
/****** Object:  Table [dbo].[Deductible]    Script Date: 8/11/2015 10:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Deductible](
	[DeductibleId] [nchar](10) NOT NULL,
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
 CONSTRAINT [PK_Deductible] PRIMARY KEY CLUSTERED 
(
	[DeductibleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[HealthPlan]    Script Date: 8/11/2015 10:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HealthPlan](
	[HealthPlanId] [int] IDENTITY(1,1) NOT NULL,
	[HealthPlanCode] [nchar](10) NULL,
	[HealthPlanDescription] [nvarchar](50) NULL,
	[DeductibleId] [nchar](10) NULL,
	[PreventiveCareId] [nchar](10) NULL,
	[MajorMedicalId] [nchar](10) NULL,
	[PCPrequiredBool] [bit] NULL,
	[PCPNetworkBool] [bit] NULL,
 CONSTRAINT [PK_HealthPlan] PRIMARY KEY CLUSTERED 
(
	[HealthPlanId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MajorMedical]    Script Date: 8/11/2015 10:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MajorMedical](
	[MajorMedicalId] [nchar](10) NOT NULL,
	[MajorMedicalProvideListBool] [bit] NULL,
	[MajorMedicalDescription] [nvarchar](max) NULL,
 CONSTRAINT [PK_MajorMedical] PRIMARY KEY CLUSTERED 
(
	[MajorMedicalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Organization]    Script Date: 8/11/2015 10:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Organization](
	[Organization Id] [nchar](10) NOT NULL,
	[OrganizationName] [nchar](10) NULL,
	[OrganizationDescription] [nvarchar](50) NULL,
	[OrganizationPhoneNumber] [nchar](10) NULL,
	[OrganizationAddressId] [nchar](10) NULL,
 CONSTRAINT [PK_Organization] PRIMARY KEY CLUSTERED 
(
	[Organization Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PreventiveCare]    Script Date: 8/11/2015 10:25:42 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreventiveCare](
	[PreventiveCareId] [nchar](10) NOT NULL,
	[PhysicalExamLimit] [decimal](18, 0) NULL,
	[RoutinePediatricCareLimit] [decimal](18, 0) NULL,
	[ImmunizationLimit] [decimal](18, 0) NULL,
 CONSTRAINT [PK_PreventiveCare] PRIMARY KEY CLUSTERED 
(
	[PreventiveCareId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[HealthPlan]  WITH CHECK ADD  CONSTRAINT [FK_HealthPlan_DedId] FOREIGN KEY([DeductibleId])
REFERENCES [dbo].[Deductible] ([DeductibleId])
GO
ALTER TABLE [dbo].[HealthPlan] CHECK CONSTRAINT [FK_HealthPlan_DedId]
GO
ALTER TABLE [dbo].[HealthPlan]  WITH CHECK ADD  CONSTRAINT [FK_HealthPlan_MajorMedicalId] FOREIGN KEY([MajorMedicalId])
REFERENCES [dbo].[MajorMedical] ([MajorMedicalId])
GO
ALTER TABLE [dbo].[HealthPlan] CHECK CONSTRAINT [FK_HealthPlan_MajorMedicalId]
GO
ALTER TABLE [dbo].[HealthPlan]  WITH CHECK ADD  CONSTRAINT [FK_HealthPlan_PreventiveCare] FOREIGN KEY([PreventiveCareId])
REFERENCES [dbo].[PreventiveCare] ([PreventiveCareId])
GO
ALTER TABLE [dbo].[HealthPlan] CHECK CONSTRAINT [FK_HealthPlan_PreventiveCare]
GO
USE [master]
GO
ALTER DATABASE [HealthPlanDB] SET  READ_WRITE 
GO

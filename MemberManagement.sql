USE [master]
GO
/****** Object:  Database [MemberManagement]    Script Date: 8/13/2015 10:08:06 PM ******/
CREATE DATABASE [MemberManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MemberManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\MemberManagement.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'MemberManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\MemberManagement_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [MemberManagement] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MemberManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MemberManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MemberManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MemberManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MemberManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MemberManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [MemberManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MemberManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MemberManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MemberManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MemberManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MemberManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MemberManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MemberManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MemberManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MemberManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MemberManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MemberManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MemberManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MemberManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MemberManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MemberManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MemberManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MemberManagement] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MemberManagement] SET  MULTI_USER 
GO
ALTER DATABASE [MemberManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MemberManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MemberManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MemberManagement] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [MemberManagement] SET DELAYED_DURABILITY = DISABLED 
GO
USE [MemberManagement]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 8/13/2015 10:08:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [nchar](10) NOT NULL,
	[Address_Street1] [nvarchar](50) NULL,
	[Address_Street2] [nchar](10) NULL,
	[Address_City] [nchar](10) NULL,
	[Address_State] [nchar](10) NULL,
	[Address_Zip] [nchar](10) NULL,
	[Address_Country] [nchar](10) NULL,
	[Address_Email] [nchar](10) NULL,
	[Address_Home_Phone] [nchar](10) NULL,
	[Address_Work_Phone] [nchar](10) NULL,
	[Address_Cell_phone] [nchar](10) NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Coverage]    Script Date: 8/13/2015 10:08:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Coverage](
	[CoverageId] [nchar](10) NOT NULL,
	[CoverageCode] [nchar](10) NULL,
	[CoverageDescription] [nvarchar](50) NULL,
 CONSTRAINT [PK_Coverage] PRIMARY KEY CLUSTERED 
(
	[CoverageId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Employee]    Script Date: 8/13/2015 10:08:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Employee](
	[EmployeeId] [nchar](10) NOT NULL,
	[Employee_First_Name] [nvarchar](50) NULL,
	[Employee_Last_Name] [nvarchar](50) NULL,
	[Employee_Middle_Name] [nchar](10) NULL,
	[Employee_SSN] [nchar](10) NULL,
	[Employee_DOB] [datetime2](7) NULL,
	[Eomployee_Gender] [nchar](10) NULL,
	[Employee_Address_Id] [nchar](10) NULL,
	[Marital_Status_id] [nchar](10) NULL,
	[Coverage_Id] [nchar](10) NULL,
	[Primary_Care_Id] [nchar](10) NULL,
	[PCP] [nchar](10) NULL,
 CONSTRAINT [PK_Employee] PRIMARY KEY CLUSTERED 
(
	[EmployeeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[EmployeePolicy]    Script Date: 8/13/2015 10:08:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[EmployeePolicy](
	[EmployeePolicyId] [nchar](10) NOT NULL,
	[EmployeeId] [nchar](10) NULL,
	[EnrollmentTypeId] [nchar](10) NULL,
	[HealthPlanId] [nchar](10) NULL,
	[OrganizationId] [nchar](10) NULL,
	[DateOfHire] [datetime] NULL,
	[QualifyingEventDate] [datetime] NULL,
	[EffectiveDateOfCoverage] [datetime] NULL,
 CONSTRAINT [PK_EmployeePolicy] PRIMARY KEY CLUSTERED 
(
	[EmployeePolicyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Enrollment]    Script Date: 8/13/2015 10:08:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Enrollment](
	[EnrollmentTypeId] [nchar](10) NOT NULL,
	[EnrollmentTypeCode] [nchar](10) NULL,
	[EnrollmentTypeDescription] [nvarchar](max) NULL,
	[EnrollmentType] [nchar](10) NULL,
 CONSTRAINT [PK_Enrollment] PRIMARY KEY CLUSTERED 
(
	[EnrollmentTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GroupPolicyDetails]    Script Date: 8/13/2015 10:08:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GroupPolicyDetails](
	[GroupPolicyId] [nchar](10) NOT NULL,
	[GroupNumber] [nchar](10) NULL,
	[GroupDetails] [nchar](10) NULL,
	[OrganizationId] [nchar](10) NULL,
 CONSTRAINT [PK_GroupPolicyDetails] PRIMARY KEY CLUSTERED 
(
	[GroupPolicyId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[MaritalStatus]    Script Date: 8/13/2015 10:08:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MaritalStatus](
	[MaritalStatusId] [nchar](10) NOT NULL,
	[MaritalStatusCode] [nchar](10) NULL,
	[MaritalStatusDescription] [nvarchar](50) NULL,
 CONSTRAINT [PK_MaritalStatus] PRIMARY KEY CLUSTERED 
(
	[MaritalStatusId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PrimaryCareProvider]    Script Date: 8/13/2015 10:08:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PrimaryCareProvider](
	[PrimaryCareProviderId] [nchar](10) NOT NULL,
	[PrimaryCareProviderFirstName] [nchar](10) NULL,
	[PrimaryCareProviderLastName] [nchar](10) NULL,
	[PrimaryCareProviderAddressId] [nchar](10) NULL,
 CONSTRAINT [PK_PrimaryCareProvider] PRIMARY KEY CLUSTERED 
(
	[PrimaryCareProviderId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Coverage] FOREIGN KEY([Coverage_Id])
REFERENCES [dbo].[Coverage] ([CoverageId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Coverage]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Employee] FOREIGN KEY([Employee_Address_Id])
REFERENCES [dbo].[Address] ([AddressId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Employee]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_Marital] FOREIGN KEY([Marital_Status_id])
REFERENCES [dbo].[MaritalStatus] ([MaritalStatusId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_Marital]
GO
ALTER TABLE [dbo].[Employee]  WITH CHECK ADD  CONSTRAINT [FK_Employee_PrimaryCare] FOREIGN KEY([Primary_Care_Id])
REFERENCES [dbo].[PrimaryCareProvider] ([PrimaryCareProviderId])
GO
ALTER TABLE [dbo].[Employee] CHECK CONSTRAINT [FK_Employee_PrimaryCare]
GO
ALTER TABLE [dbo].[EmployeePolicy]  WITH CHECK ADD  CONSTRAINT [FK_EmployeePolicy_Employee] FOREIGN KEY([EmployeeId])
REFERENCES [dbo].[Employee] ([EmployeeId])
GO
ALTER TABLE [dbo].[EmployeePolicy] CHECK CONSTRAINT [FK_EmployeePolicy_Employee]
GO
ALTER TABLE [dbo].[EmployeePolicy]  WITH CHECK ADD  CONSTRAINT [FK_EmployeePolicy_EnrollementTypeId] FOREIGN KEY([EnrollmentTypeId])
REFERENCES [dbo].[Enrollment] ([EnrollmentTypeId])
GO
ALTER TABLE [dbo].[EmployeePolicy] CHECK CONSTRAINT [FK_EmployeePolicy_EnrollementTypeId]
GO
ALTER TABLE [dbo].[PrimaryCareProvider]  WITH CHECK ADD  CONSTRAINT [FK_PrimaryCareProvider_Address] FOREIGN KEY([PrimaryCareProviderAddressId])
REFERENCES [dbo].[Address] ([AddressId])
GO
ALTER TABLE [dbo].[PrimaryCareProvider] CHECK CONSTRAINT [FK_PrimaryCareProvider_Address]
GO
USE [master]
GO
ALTER DATABASE [MemberManagement] SET  READ_WRITE 
GO

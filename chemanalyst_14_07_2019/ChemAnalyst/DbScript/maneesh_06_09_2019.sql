USE [ChemAnalyst]
GO
/****** Object:  Table [dbo].[SA_User]    Script Date: 6/9/2019 7:16:16 PM ******/
DROP TABLE [dbo].[SA_User]
GO
/****** Object:  Table [dbo].[SA_Slider]    Script Date: 6/9/2019 7:16:16 PM ******/
DROP TABLE [dbo].[SA_Slider]
GO
/****** Object:  Table [dbo].[SA_RoleWiseAccess]    Script Date: 6/9/2019 7:16:16 PM ******/
DROP TABLE [dbo].[SA_RoleWiseAccess]
GO
/****** Object:  Table [dbo].[SA_Role]    Script Date: 6/9/2019 7:16:16 PM ******/
DROP TABLE [dbo].[SA_Role]
GO
/****** Object:  Table [dbo].[SA_Quote]    Script Date: 6/9/2019 7:16:16 PM ******/
DROP TABLE [dbo].[SA_Quote]
GO
/****** Object:  Table [dbo].[SA_Product]    Script Date: 6/9/2019 7:16:16 PM ******/
DROP TABLE [dbo].[SA_Product]
GO
/****** Object:  Table [dbo].[SA_PageList]    Script Date: 6/9/2019 7:16:16 PM ******/
DROP TABLE [dbo].[SA_PageList]
GO
/****** Object:  Table [dbo].[SA_News]    Script Date: 6/9/2019 7:16:16 PM ******/
DROP TABLE [dbo].[SA_News]
GO
/****** Object:  Table [dbo].[SA_Job]    Script Date: 6/9/2019 7:16:16 PM ******/
DROP TABLE [dbo].[SA_Job]
GO
/****** Object:  Table [dbo].[SA_Industry]    Script Date: 6/9/2019 7:16:16 PM ******/
DROP TABLE [dbo].[SA_Industry]
GO
/****** Object:  Table [dbo].[SA_Deals]    Script Date: 6/9/2019 7:16:16 PM ******/
DROP TABLE [dbo].[SA_Deals]
GO
/****** Object:  Table [dbo].[SA_CMS]    Script Date: 6/9/2019 7:16:16 PM ******/
DROP TABLE [dbo].[SA_CMS]
GO
/****** Object:  Table [dbo].[SA_ChemPriceYearly]    Script Date: 6/9/2019 7:16:16 PM ******/
DROP TABLE [dbo].[SA_ChemPriceYearly]
GO
/****** Object:  Table [dbo].[SA_ChemPriceQuarterly]    Script Date: 6/9/2019 7:16:16 PM ******/
DROP TABLE [dbo].[SA_ChemPriceQuarterly]
GO
/****** Object:  Table [dbo].[SA_ChemPriceMonthly]    Script Date: 6/9/2019 7:16:16 PM ******/
DROP TABLE [dbo].[SA_ChemPriceMonthly]
GO
/****** Object:  Table [dbo].[SA_Category]    Script Date: 6/9/2019 7:16:16 PM ******/
DROP TABLE [dbo].[SA_Category]
GO
/****** Object:  Table [dbo].[SA_Advisory]    Script Date: 6/9/2019 7:16:16 PM ******/
DROP TABLE [dbo].[SA_Advisory]
GO
/****** Object:  Table [dbo].[SA_Advisory]    Script Date: 6/9/2019 7:16:16 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SA_Advisory](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[AdvisoryName] [varchar](50) NULL,
	[AdvisoryDiscription] [varchar](500) NULL,
	[AdvisoryImg] [varchar](500) NULL,
	[Meta] [varchar](50) NULL,
	[MetaDiscription] [varchar](500) NULL,
	[status] [int] NULL,
	[CreatedTime] [datetime] NULL,
 CONSTRAINT [PK_SA_Advisory] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SA_Category]    Script Date: 6/9/2019 7:16:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SA_Category](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CategoryName] [varchar](50) NULL,
	[CategoryDiscription] [varchar](500) NULL,
	[Meta] [varchar](50) NULL,
	[MetaDiscription] [varchar](500) NULL,
	[status] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[CategoryImg] [varchar](50) NULL,
 CONSTRAINT [PK_SA_Category] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SA_ChemPriceMonthly]    Script Date: 6/9/2019 7:16:17 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SA_ChemPriceMonthly](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Product] [int] NULL,
	[ProductVariant] [varchar](50) NULL,
	[year] [varchar](50) NULL,
	[Month] [varchar](50) NULL,
	[count] [decimal](18, 2) NULL,
	[Discription] [varchar](500) NULL,
 CONSTRAINT [PK_SA_ChemPriceMonthly] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SA_ChemPriceQuarterly]    Script Date: 6/9/2019 7:16:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SA_ChemPriceQuarterly](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Product] [int] NULL,
	[ProductVariant] [varchar](500) NULL,
	[year] [varchar](50) NULL,
	[Quarter] [varchar](50) NULL,
	[count] [decimal](18, 2) NULL,
	[Discription] [varchar](500) NULL,
 CONSTRAINT [PK_SA_ChemPriceQuarterly] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SA_ChemPriceYearly]    Script Date: 6/9/2019 7:16:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SA_ChemPriceYearly](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Product] [int] NULL,
	[ProductVariant] [varchar](500) NULL,
	[year] [varchar](50) NULL,
	[count] [decimal](18, 2) NULL,
	[Discription] [varchar](5000) NULL,
 CONSTRAINT [PK_SA_ChemPriceYearly] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SA_CMS]    Script Date: 6/9/2019 7:16:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SA_CMS](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[CMSName] [varchar](50) NULL,
	[CMSDiscription] [varchar](500) NULL,
	[Meta] [varchar](50) NULL,
	[MetaDiscription] [varchar](500) NULL,
	[status] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[CMSImg] [varchar](50) NULL,
	[Product] [int] NULL,
 CONSTRAINT [PK_SA_CMS] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SA_Deals]    Script Date: 6/9/2019 7:16:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SA_Deals](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[DealsName] [varchar](50) NULL,
	[DealsDiscription] [varchar](500) NULL,
	[Meta] [varchar](50) NULL,
	[MetaDiscription] [varchar](500) NULL,
	[status] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[DealsImg] [varchar](50) NULL,
	[Product] [int] NULL,
 CONSTRAINT [PK_SA_Deals] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SA_Industry]    Script Date: 6/9/2019 7:16:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SA_Industry](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Description] [varchar](500) NULL,
	[Meta] [varchar](50) NULL,
	[MetaDescription] [varchar](500) NULL,
	[status] [int] NULL,
	[CreatedTime] [datetime] NULL,
 CONSTRAINT [PK_SA_Industry] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SA_Job]    Script Date: 6/9/2019 7:16:18 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SA_Job](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[JobName] [varchar](50) NULL,
	[JobDiscription] [varchar](500) NULL,
	[Meta] [varchar](50) NULL,
	[MetaDiscription] [varchar](500) NULL,
	[status] [int] NULL,
	[CreatedTime] [datetime] NULL,
 CONSTRAINT [PK_SA_Job] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SA_News]    Script Date: 6/9/2019 7:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SA_News](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[NewsName] [varchar](50) NULL,
	[NewsDiscription] [varchar](500) NULL,
	[Meta] [varchar](50) NULL,
	[MetaDiscription] [varchar](500) NULL,
	[status] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[NewsImg] [varchar](50) NULL,
	[Product] [int] NULL,
 CONSTRAINT [PK_SA_News] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SA_PageList]    Script Date: 6/9/2019 7:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SA_PageList](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[PageDiscription] [varchar](500) NULL,
 CONSTRAINT [PK_SA_PageList] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SA_Product]    Script Date: 6/9/2019 7:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SA_Product](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [varchar](50) NULL,
	[ProductDiscription] [varchar](500) NULL,
	[Meta] [varchar](50) NULL,
	[MetaDiscription] [varchar](500) NULL,
	[status] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[ProductImg] [varchar](50) NULL,
	[Category] [int] NULL,
 CONSTRAINT [PK_SA_Product] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SA_Quote]    Script Date: 6/9/2019 7:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SA_Quote](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[QuoteName] [varchar](50) NULL,
	[QuoteDiscription] [varchar](500) NULL,
	[QuoteBy] [varchar](500) NULL,
	[QuoteDes] [varchar](500) NULL,
	[Meta] [varchar](50) NULL,
	[MetaDiscription] [varchar](500) NULL,
	[status] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[QuoteImg] [varchar](50) NULL,
 CONSTRAINT [PK_SA_Quote] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SA_Role]    Script Date: 6/9/2019 7:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SA_Role](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Role] [varchar](50) NULL,
	[RoleDiscription] [varchar](500) NULL,
	[CreatedTime] [datetime] NULL,
 CONSTRAINT [PK_SA_Role] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SA_RoleWiseAccess]    Script Date: 6/9/2019 7:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SA_RoleWiseAccess](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [int] NOT NULL,
	[Pageid] [int] NULL,
	[PageDiscription] [varchar](500) NULL,
	[access] [bit] NULL,
	[CreatedTime] [datetime] NULL,
 CONSTRAINT [PK_SA_RoleWiseAccess] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SA_Slider]    Script Date: 6/9/2019 7:16:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SA_Slider](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Title] [varchar](50) NULL,
	[Discription] [varchar](500) NULL,
	[Category] [varchar](500) NULL,
	[Meta] [varchar](50) NULL,
	[MetaDiscription] [varchar](500) NULL,
	[status] [int] NULL,
	[CreatedTime] [datetime] NULL,
	[Img] [varchar](50) NULL,
 CONSTRAINT [PK_SA_Slider] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SA_User]    Script Date: 6/9/2019 7:16:20 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SA_User](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[Fname] [varchar](50) NULL,
	[Lname] [varchar](50) NULL,
	[Email] [varchar](50) NOT NULL,
	[Phone] [varchar](50) NULL,
	[UserPassword] [varchar](500) NULL,
	[Gender] [varchar](50) NULL,
	[ProfileImage] [varchar](50) NULL,
	[Role] [varchar](50) NULL,
 CONSTRAINT [PK_SA_User_1] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[SA_Category] ON 

INSERT [dbo].[SA_Category] ([id], [CategoryName], [CategoryDiscription], [Meta], [MetaDiscription], [status], [CreatedTime], [CategoryImg]) VALUES (6, N'FeedStock', N'FeedStock Category', N'FeedStock', N'FeedStock', NULL, CAST(N'2019-06-03T23:42:01.310' AS DateTime), N'I.jpeg')
SET IDENTITY_INSERT [dbo].[SA_Category] OFF
SET IDENTITY_INSERT [dbo].[SA_ChemPriceMonthly] ON 

INSERT [dbo].[SA_ChemPriceMonthly] ([id], [Product], [ProductVariant], [year], [Month], [count], [Discription]) VALUES (1, 5, N'Sulphur', N'2019', N'January', CAST(200.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceMonthly] ([id], [Product], [ProductVariant], [year], [Month], [count], [Discription]) VALUES (2, 5, N'Sulphur1', N'2019', N'January', CAST(250.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceMonthly] ([id], [Product], [ProductVariant], [year], [Month], [count], [Discription]) VALUES (3, 5, N'Sulphur', N'2019', N'Febuary', CAST(350.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceMonthly] ([id], [Product], [ProductVariant], [year], [Month], [count], [Discription]) VALUES (4, 5, N'Sulphur1', N'2019', N'Febuary', CAST(500.00 AS Decimal(18, 2)), NULL)
SET IDENTITY_INSERT [dbo].[SA_ChemPriceMonthly] OFF
SET IDENTITY_INSERT [dbo].[SA_ChemPriceQuarterly] ON 

INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (1, 5, N'Blown Film Grade ', N'2019', N'Q1', CAST(1000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (2, 5, N'Blown Film Grade ', N'2019', N'Q2', CAST(1010.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (3, 5, N'Blown Film Grade ', N'2019', N'Q3', CAST(1030.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (4, 5, N'Blown Film Grade ', N'2019', N'Q4', CAST(1230.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (5, 5, N'Blown Film Grade ', N'2004', N'Q1', CAST(1540.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (6, 5, N'Blown Film Grade ', N'2004', N'Q2', CAST(1790.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (7, 5, N'Blown Film Grade ', N'2004', N'Q3', CAST(1830.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (8, 5, N'Blown Film Grade ', N'2004', N'Q4', CAST(2280.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (9, 5, N'Extrusion Coating', N'2019', N'Q1', CAST(11030.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (10, 5, N'Extrusion Coating', N'2019', N'Q2', CAST(11030.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (11, 5, N'Extrusion Coating', N'2019', N'Q3', CAST(11230.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (12, 5, N'Extrusion Coating', N'2019', N'Q4', CAST(11540.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (13, 5, N'Extrusion Coating', N'2004', N'Q1', CAST(11790.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (14, 5, N'Extrusion Coating', N'2004', N'Q2', CAST(11830.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (15, 5, N'Extrusion Coating', N'2004', N'Q3', CAST(12280.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (16, 5, N'Extrusion Coating', N'2004', N'Q4', CAST(12630.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (17, 5, N'High Film Grade', N'2019', N'Q1', CAST(7000.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (18, 5, N'High Film Grade', N'2019', N'Q2', CAST(9030.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (19, 5, N'High Film Grade', N'2019', N'Q3', CAST(9930.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (20, 5, N'High Film Grade', N'2019', N'Q4', CAST(19930.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (21, 5, N'High Film Grade', N'2004', N'Q1', CAST(15540.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (22, 5, N'High Film Grade', N'2004', N'Q2', CAST(17790.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (23, 5, N'High Film Grade', N'2004', N'Q3', CAST(18830.00 AS Decimal(18, 2)), NULL)
INSERT [dbo].[SA_ChemPriceQuarterly] ([id], [Product], [ProductVariant], [year], [Quarter], [count], [Discription]) VALUES (24, 5, N'High Film Grade', N'2004', N'Q4', CAST(19280.00 AS Decimal(18, 2)), NULL)
SET IDENTITY_INSERT [dbo].[SA_ChemPriceQuarterly] OFF
SET IDENTITY_INSERT [dbo].[SA_ChemPriceYearly] ON 

INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (1, 5, N'Blown Film Grade ', N'2000', CAST(1000.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (2, 5, N'Blown Film Grade ', N'2001', CAST(1010.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (3, 5, N'Blown Film Grade ', N'2002', CAST(1030.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (4, 5, N'Blown Film Grade ', N'2003', CAST(1230.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (5, 5, N'Blown Film Grade ', N'2004', CAST(1540.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (6, 5, N'Blown Film Grade ', N'2005', CAST(1790.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (7, 5, N'Blown Film Grade ', N'2006', CAST(1830.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (8, 5, N'Blown Film Grade ', N'2007', CAST(2280.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (9, 5, N'Blown Film Grade ', N'2008', CAST(2630.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (10, 5, N'Blown Film Grade ', N'2009', CAST(2830.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (11, 5, N'Blown Film Grade ', N'2010', CAST(2930.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (12, 5, N'Blown Film Grade ', N'2011', CAST(3030.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (13, 5, N'Blown Film Grade ', N'2012', CAST(3160.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (14, 5, N'Blown Film Grade ', N'2013', CAST(4430.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (15, 5, N'Blown Film Grade ', N'2014', CAST(5970.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (16, 5, N'Blown Film Grade ', N'2015', CAST(6230.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (17, 5, N'Blown Film Grade ', N'2016', CAST(7360.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (18, 5, N'Blown Film Grade ', N'2017', CAST(8830.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (19, 5, N'Blown Film Grade ', N'2018', CAST(9000.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (20, 5, N'Blown Film Grade ', N'2019', CAST(8000.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (21, 5, N'Extrusion Coating', N'2000', CAST(11030.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (22, 5, N'Extrusion Coating', N'2001', CAST(11030.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (23, 5, N'Extrusion Coating', N'2002', CAST(11230.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (24, 5, N'Extrusion Coating', N'2003', CAST(11540.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (25, 5, N'Extrusion Coating', N'2004', CAST(11790.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (26, 5, N'Extrusion Coating', N'2005', CAST(11830.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (27, 5, N'Extrusion Coating', N'2006', CAST(12280.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (28, 5, N'Extrusion Coating', N'2007', CAST(12630.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (29, 5, N'Extrusion Coating', N'2008', CAST(12830.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (30, 5, N'Extrusion Coating', N'2009', CAST(12930.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (31, 5, N'Extrusion Coating', N'2010', CAST(13030.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (32, 5, N'Extrusion Coating', N'2011', CAST(13160.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (33, 5, N'Extrusion Coating', N'2012', CAST(14430.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (34, 5, N'Extrusion Coating', N'2013', CAST(15970.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (35, 5, N'Extrusion Coating', N'2014', CAST(16230.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (36, 5, N'Extrusion Coating', N'2015', CAST(17360.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (37, 5, N'Extrusion Coating', N'2016', CAST(18930.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (38, 5, N'Extrusion Coating', N'2017', CAST(19000.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (39, 5, N'Extrusion Coating', N'2018', CAST(20000.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (40, 5, N'Extrusion Coating', N'2019', CAST(1950.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (41, 5, N'High Film Grade', N'2000', CAST(7000.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (42, 5, N'High Film Grade', N'2001', CAST(9030.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (43, 5, N'High Film Grade', N'2002', CAST(9930.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (44, 5, N'High Film Grade', N'2003', CAST(19930.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (45, 5, N'High Film Grade', N'2004', CAST(15540.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (46, 5, N'High Film Grade', N'2005', CAST(17790.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (47, 5, N'High Film Grade', N'2006', CAST(18830.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (48, 5, N'High Film Grade', N'2007', CAST(19280.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (49, 5, N'High Film Grade', N'2008', CAST(21630.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (50, 5, N'High Film Grade', N'2009', CAST(22830.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (51, 5, N'High Film Grade', N'2010', CAST(23930.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (52, 5, N'High Film Grade', N'2011', CAST(24030.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (53, 5, N'High Film Grade', N'2012', CAST(25160.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (54, 5, N'High Film Grade', N'2013', CAST(26430.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (55, 5, N'High Film Grade', N'2014', CAST(27970.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (56, 5, N'High Film Grade', N'2015', CAST(28230.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (57, 5, N'High Film Grade', N'2016', CAST(29360.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (58, 5, N'High Film Grade', N'2017', CAST(30930.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (59, 5, N'High Film Grade', N'2018', CAST(31000.00 AS Decimal(18, 2)), N'year wise discription')
INSERT [dbo].[SA_ChemPriceYearly] ([id], [Product], [ProductVariant], [year], [count], [Discription]) VALUES (60, 5, N'High Film Grade', N'2019', CAST(32000.00 AS Decimal(18, 2)), N'year wise discription')
SET IDENTITY_INSERT [dbo].[SA_ChemPriceYearly] OFF
SET IDENTITY_INSERT [dbo].[SA_CMS] ON 

INSERT [dbo].[SA_CMS] ([id], [CMSName], [CMSDiscription], [Meta], [MetaDiscription], [status], [CreatedTime], [CMSImg], [Product]) VALUES (2, N'EXPERT', N'EXPERT', N'TEST', N'test', NULL, CAST(N'2019-05-26T16:03:16.700' AS DateTime), N'WIN_20181216_12_59_53_Pro.jpg', 4)
SET IDENTITY_INSERT [dbo].[SA_CMS] OFF
SET IDENTITY_INSERT [dbo].[SA_Deals] ON 

INSERT [dbo].[SA_Deals] ([id], [DealsName], [DealsDiscription], [Meta], [MetaDiscription], [status], [CreatedTime], [DealsImg], [Product]) VALUES (2, N'deasl', N'deals', N'deals', N'deals', NULL, CAST(N'2019-06-03T23:53:17.297' AS DateTime), NULL, 5)
SET IDENTITY_INSERT [dbo].[SA_Deals] OFF
SET IDENTITY_INSERT [dbo].[SA_News] ON 

INSERT [dbo].[SA_News] ([id], [NewsName], [NewsDiscription], [Meta], [MetaDiscription], [status], [CreatedTime], [NewsImg], [Product]) VALUES (2, N'test', N'12343', N'NHFHVH', N'MJBJGKB', NULL, CAST(N'2019-05-26T15:16:10.733' AS DateTime), N'WIN_20181216_12_59_53_Pro.jpg', NULL)
INSERT [dbo].[SA_News] ([id], [NewsName], [NewsDiscription], [Meta], [MetaDiscription], [status], [CreatedTime], [NewsImg], [Product]) VALUES (3, N'test2', N'new new added', N'we', N'sadcv', NULL, CAST(N'2019-06-06T00:49:42.403' AS DateTime), N'Screenshot (1).png', 5)
SET IDENTITY_INSERT [dbo].[SA_News] OFF
SET IDENTITY_INSERT [dbo].[SA_PageList] ON 

INSERT [dbo].[SA_PageList] ([id], [PageDiscription]) VALUES (1, N'Chemical Pricing')
INSERT [dbo].[SA_PageList] ([id], [PageDiscription]) VALUES (2, N'Market Analysis')
INSERT [dbo].[SA_PageList] ([id], [PageDiscription]) VALUES (3, N'Company Profile')
INSERT [dbo].[SA_PageList] ([id], [PageDiscription]) VALUES (4, N'Industry Reports')
INSERT [dbo].[SA_PageList] ([id], [PageDiscription]) VALUES (5, N'News')
INSERT [dbo].[SA_PageList] ([id], [PageDiscription]) VALUES (6, N'Deals')
INSERT [dbo].[SA_PageList] ([id], [PageDiscription]) VALUES (7, N'Subscription Management')
SET IDENTITY_INSERT [dbo].[SA_PageList] OFF
SET IDENTITY_INSERT [dbo].[SA_Product] ON 

INSERT [dbo].[SA_Product] ([id], [ProductName], [ProductDiscription], [Meta], [MetaDiscription], [status], [CreatedTime], [ProductImg], [Category]) VALUES (5, N'Sulpher', N'Sulpher actegory', N'Sulpher', N'Sulpher', NULL, CAST(N'2019-06-03T23:43:23.010' AS DateTime), N'I.jpeg', 6)
SET IDENTITY_INSERT [dbo].[SA_Product] OFF
SET IDENTITY_INSERT [dbo].[SA_Role] ON 

INSERT [dbo].[SA_Role] ([id], [Role], [RoleDiscription], [CreatedTime]) VALUES (8, N'Admin', N'Admin345', CAST(N'2019-05-24T19:42:16.610' AS DateTime))
INSERT [dbo].[SA_Role] ([id], [Role], [RoleDiscription], [CreatedTime]) VALUES (9, N'sales', N'sales123', CAST(N'2019-06-03T23:50:30.670' AS DateTime))
SET IDENTITY_INSERT [dbo].[SA_Role] OFF
SET IDENTITY_INSERT [dbo].[SA_RoleWiseAccess] ON 

INSERT [dbo].[SA_RoleWiseAccess] ([id], [RoleId], [Pageid], [PageDiscription], [access], [CreatedTime]) VALUES (21, 9, 1, N'Chemical Pricing', 1, CAST(N'2019-06-09T18:54:38.603' AS DateTime))
SET IDENTITY_INSERT [dbo].[SA_RoleWiseAccess] OFF
SET IDENTITY_INSERT [dbo].[SA_User] ON 

INSERT [dbo].[SA_User] ([id], [Fname], [Lname], [Email], [Phone], [UserPassword], [Gender], [ProfileImage], [Role]) VALUES (5, N'Maneesh', N'Kumar', N'manishnishad15@gmail.com', N'8287230716', N'asd', N'Male', N'WIN_20181216_12_59_53_Pro.jpg', N'Admin')
INSERT [dbo].[SA_User] ([id], [Fname], [Lname], [Email], [Phone], [UserPassword], [Gender], [ProfileImage], [Role]) VALUES (6, N'Maneesh', N'Kumar', N'manishnishad15@gmail.com', N'8287230716', NULL, N'Male', NULL, N'Admin')
INSERT [dbo].[SA_User] ([id], [Fname], [Lname], [Email], [Phone], [UserPassword], [Gender], [ProfileImage], [Role]) VALUES (7, N'PAyal', N'Avi', N'manishnishad15@gmail.com', N'8287230716', N'maneesh', N'Male', N'I.jpeg', N'sales')
INSERT [dbo].[SA_User] ([id], [Fname], [Lname], [Email], [Phone], [UserPassword], [Gender], [ProfileImage], [Role]) VALUES (8, N'aVI', N'Nishad', N'manishnishad15@gmail.com', N'8287230716', NULL, N'Male', NULL, N'Admin')
INSERT [dbo].[SA_User] ([id], [Fname], [Lname], [Email], [Phone], [UserPassword], [Gender], [ProfileImage], [Role]) VALUES (9, N'jhgfvvh', N'mjbh', N'kjjhuijh@fgf.g', N'897756565', N'jhg', NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[SA_User] OFF

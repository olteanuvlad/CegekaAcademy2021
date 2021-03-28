USE [CarDealership]
GO

/****** Object:  Table [dbo].[Brands]    Script Date: 28.03.2021 17:54:01 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Brands](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [CarDealership]
GO

/****** Object:  Table [dbo].[Models]    Script Date: 28.03.2021 17:54:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Models](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Brand_Id] [int] NOT NULL,
	[Base_Price] [int] NOT NULL,
 CONSTRAINT [PK_Models] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Models]  WITH CHECK ADD  CONSTRAINT [FK_Models_Brands] FOREIGN KEY([Brand_Id])
REFERENCES [dbo].[Brands] ([Id])
GO

ALTER TABLE [dbo].[Models] CHECK CONSTRAINT [FK_Models_Brands]
GO

USE [CarDealership]
GO

/****** Object:  Table [dbo].[PossibleFeatures]    Script Date: 28.03.2021 17:54:39 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[PossibleFeatures](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Model_Id] [int] NOT NULL,
	[Package_Name] [nvarchar](100) NULL,
	[Engine_Size_CC] [int] NULL,
	[Fuel] [nvarchar](50) NULL,
	[Transmission] [nvarchar](50) NULL,
	[Gearbox] [nvarchar](50) NULL,
	[HorsePower] [int] NULL,
	[Price] [int] NULL,
 CONSTRAINT [PK_PossibleFeatures] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[PossibleFeatures]  WITH CHECK ADD  CONSTRAINT [FK_PossibleFeatures_Models] FOREIGN KEY([Model_Id])
REFERENCES [dbo].[Models] ([Id])
GO

ALTER TABLE [dbo].[PossibleFeatures] CHECK CONSTRAINT [FK_PossibleFeatures_Models]
GO

USE [CarDealership]
GO

/****** Object:  Table [dbo].[Inventory]    Script Date: 28.03.2021 17:55:03 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Inventory](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Model_Id] [int] NOT NULL,
	[Actual_Features_Id] [int] NOT NULL,
	[Manufacture_Date] [datetime] NOT NULL,
 CONSTRAINT [PK_Inventory] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_Models] FOREIGN KEY([Model_Id])
REFERENCES [dbo].[Models] ([Id])
GO

ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_Models]
GO

ALTER TABLE [dbo].[Inventory]  WITH CHECK ADD  CONSTRAINT [FK_Inventory_PossibleFeatures] FOREIGN KEY([Actual_Features_Id])
REFERENCES [dbo].[PossibleFeatures] ([Id])
GO

ALTER TABLE [dbo].[Inventory] CHECK CONSTRAINT [FK_Inventory_PossibleFeatures]
GO

USE [CarDealership]
GO

/****** Object:  Table [dbo].[Customers]    Script Date: 28.03.2021 17:55:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](100) NOT NULL,
	[Lastname] [nvarchar](100) NOT NULL,
 CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [CarDealership]
GO

/****** Object:  Table [dbo].[CustomerBuys]    Script Date: 28.03.2021 17:55:47 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CustomerBuys](
	[Customer_Id] [int] NOT NULL,
	[Inventory_Id] [int] NOT NULL,
	[Date] [datetime] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CustomerBuys]  WITH CHECK ADD  CONSTRAINT [FK_CustomerBuys_Customers] FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[Customers] ([Id])
GO

ALTER TABLE [dbo].[CustomerBuys] CHECK CONSTRAINT [FK_CustomerBuys_Customers]
GO

ALTER TABLE [dbo].[CustomerBuys]  WITH CHECK ADD  CONSTRAINT [FK_CustomerBuys_Inventory] FOREIGN KEY([Inventory_Id])
REFERENCES [dbo].[Inventory] ([Id])
GO

ALTER TABLE [dbo].[CustomerBuys] CHECK CONSTRAINT [FK_CustomerBuys_Inventory]
GO

USE [CarDealership]
GO

/****** Object:  Table [dbo].[CustomerInterests]    Script Date: 28.03.2021 17:56:13 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CustomerInterests](
	[Customer_Id] [int] NOT NULL,
	[Model_Id] [int] NOT NULL,
	[Date] [datetime] NOT NULL
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[CustomerInterests]  WITH CHECK ADD  CONSTRAINT [FK_CustomerInterests_Customers] FOREIGN KEY([Customer_Id])
REFERENCES [dbo].[Customers] ([Id])
GO

ALTER TABLE [dbo].[CustomerInterests] CHECK CONSTRAINT [FK_CustomerInterests_Customers]
GO

ALTER TABLE [dbo].[CustomerInterests]  WITH CHECK ADD  CONSTRAINT [FK_CustomerInterests_Models] FOREIGN KEY([Model_Id])
REFERENCES [dbo].[Models] ([Id])
GO

ALTER TABLE [dbo].[CustomerInterests] CHECK CONSTRAINT [FK_CustomerInterests_Models]
GO


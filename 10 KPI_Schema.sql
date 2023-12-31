--CREATE DATABASE [dwekpis]
--GO

--USE [dwekpis]
--GO

/****** Object:  Table [dbo].[Dim_Products]    Script Date: 03/02/2009 15:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_Products](
	[Item_No] [nvarchar](30) NOT NULL,
	[Category] [nvarchar](20) NOT NULL,
 CONSTRAINT [PK_Dim_Products] PRIMARY KEY CLUSTERED 
(
	[Item_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dim_PayTerms]    Script Date: 03/02/2009 15:54:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_PayTerms](
	[Pay_Terms] [nvarchar](6) NOT NULL,
	[Description] [nvarchar](80) NOT NULL,
 CONSTRAINT [PK_Dim_PayTerms] PRIMARY KEY CLUSTERED 
(
	[Pay_Terms] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_DaysInInventory]    Script Date: 03/02/2009 15:54:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_DaysInInventory](
	[Dates] [datetime] NOT NULL,
	[Value on Hand] [decimal](20, 4) NOT NULL,
	[Upcoming COS] [decimal](20, 4) NOT NULL,
	[User Defined Period] [decimal](5, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_InventoryTurns]    Script Date: 03/02/2009 15:54:33 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_InventoryTurns](
	[Period_StartDate] [datetime] NOT NULL,
	[COGS] [decimal](20, 4) NOT NULL,
	[Inventory] [decimal](20, 4) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_NetAccountsReceivable]    Script Date: 03/02/2009 15:54:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_NetAccountsReceivable](
	[Transaction_Date] [datetime] NOT NULL,
	[NumReceiptDays] [decimal](20, 4) NOT NULL,
	[AR_Settled_Amt] [decimal](12, 2) NOT NULL,
	[NumPaidDays] [decimal](20, 4) NOT NULL,
	[AP_Settled_Amt] [decimal](12, 2) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_PurchasePriceVariance]    Script Date: 03/02/2009 15:54:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_PurchasePriceVariance](
	[Dates] [datetime] NOT NULL,
	[Buyer] [nvarchar](8) NOT NULL,
	[Item_No] [nvarchar](30) NOT NULL,
	[Purchase_Price] [decimal](20, 4) NOT NULL,
	[Unit_Price] [decimal](20, 4) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_SalesOrderOnHand]    Script Date: 03/02/2009 15:54:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_SalesOrderOnHand](
	[OpenSaleAmount] [decimal](20, 4) NOT NULL,
	[Customer_No] [nvarchar](8) NOT NULL,
	[Item_No] [nvarchar](30) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_DaysCompletionEarlyAndLate]    Script Date: 03/02/2009 15:54:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_DaysCompletionEarlyAndLate](
	[Dates] [datetime] NOT NULL,
	[Item_No] [nvarchar](30) NOT NULL,
	[Work_Centre] [nvarchar](10) NOT NULL,
	[NumDaysEarly] [decimal](18, 0) NOT NULL,
	[NumOrdersEarly] [decimal](18, 0) NOT NULL,
	[NumDaysLate] [decimal](18, 0) NOT NULL,
	[NumOrdersLate] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_ProfitabilityGP]    Script Date: 03/02/2009 15:54:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_ProfitabilityGP](
	[Period_Date] [datetime] NOT NULL,
	[Sales_Amount] [decimal](20, 4) NOT NULL,
	[Cost_of_Goods_Sold] [decimal](20, 4) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dim_Item]    Script Date: 03/02/2009 15:54:09 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_Item](
	[Item_No] [nvarchar](30) NOT NULL,
	[Item_Description] [nvarchar](60) NOT NULL,
	[Item_Group] [nvarchar](10) NOT NULL,
	[ItemGroup_Description] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Dim_Item] PRIMARY KEY CLUSTERED 
(
	[Item_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_DaysReceiptEarlyAndLate]    Script Date: 03/02/2009 15:54:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_DaysReceiptEarlyAndLate](
	[Dates] [datetime] NOT NULL,
	[Item_No] [nvarchar](30) NOT NULL,
	[Vendor_No] [nvarchar](8) NOT NULL,
	[Buyer] [nvarchar](6) NOT NULL,
	[NumDaysEarly] [decimal](18, 0) NOT NULL,
	[NumReceiptEarly] [decimal](18, 0) NOT NULL,
	[NumDaysLate] [decimal](18, 0) NOT NULL,
	[NumReceiptLate] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_DaysShipmentEarlyAndLate]    Script Date: 03/02/2009 15:54:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_DaysShipmentEarlyAndLate](
	[Dates] [datetime] NOT NULL,
	[Item_No] [nvarchar](30) NOT NULL,
	[Customer_No] [nvarchar](8) NOT NULL,
	[Salesman] [nvarchar](6) NOT NULL,
	[NumDaysEarly] [decimal](18, 0) NOT NULL,
	[NumShipmentEarly] [decimal](18, 0) NOT NULL,
	[NumDaysLate] [decimal](18, 0) NOT NULL,
	[NumShipmentLate] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_SalesToNetWorkingCapital]    Script Date: 03/02/2009 15:54:56 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_SalesToNetWorkingCapital](
	[Dates] [datetime] NOT NULL,
	[Sales_Amt] [decimal](20, 4) NOT NULL,
	[Working_Capital] [decimal](20, 4) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_OrderAvailability]    Script Date: 03/02/2009 15:54:36 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_OrderAvailability](
	[Due_Date] [datetime] NOT NULL,
	[Item_No] [nvarchar](30) NOT NULL,
	[Customer_No] [nvarchar](8) NOT NULL,
	[Salesman] [nvarchar](6) NOT NULL,
	[NumTotalShipment] [decimal](10, 0) NOT NULL,
	[NumAvailableShipment] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_OrderLeadTime]    Script Date: 03/02/2009 15:54:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_OrderLeadTime](
	[Order_Date] [datetime] NOT NULL,
	[Item_No] [nvarchar](30) NOT NULL,
	[QtyLeadTime] [decimal](18, 0) NOT NULL,
	[OrderQuantity] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_OrderReliability]    Script Date: 03/02/2009 15:54:40 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_OrderReliability](
	[Schedule_Date] [datetime] NOT NULL,
	[Item_No] [nvarchar](30) NOT NULL,
	[Customer_No] [nvarchar](8) NOT NULL,
	[Salesman] [nvarchar](6) NOT NULL,
	[NumTotalShipment] [decimal](10, 0) NOT NULL,
	[NumOnTimeShipment] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_ProductionReliability]    Script Date: 03/02/2009 15:54:44 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_ProductionReliability](
	[Dates] [datetime] NOT NULL,
	[Item_No] [nvarchar](30) NOT NULL,
	[Customer_No] [nvarchar](8) NOT NULL,
	[Work_Centre] [nvarchar](10) NOT NULL,
	[Category] [nvarchar](10) NOT NULL,
	[NumWorkOrder] [decimal](18, 0) NOT NULL,
	[NumOnTimeWorkOrder] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_ProductionYield]    Script Date: 03/02/2009 15:54:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_ProductionYield](
	[Item_No] [nvarchar](30) NOT NULL,
	[Dates] [datetime] NOT NULL,
	[Product_Lots] [decimal](20, 4) NOT NULL,
	[Material_Lots] [decimal](20, 4) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_ProfitabilityPM]    Script Date: 03/02/2009 15:54:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_ProfitabilityPM](
	[Shipment_Date] [datetime] NOT NULL,
	[Item_No] [nvarchar](30) NOT NULL,
	[Customer_No] [nvarchar](8) NOT NULL,
	[Salesman] [nvarchar](6) NOT NULL,
	[Pay_Terms] [nvarchar](6) NOT NULL,
	[ProfitMargin] [decimal](20, 4) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_PurchasePartsReliability]    Script Date: 03/02/2009 15:54:49 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_PurchasePartsReliability](
	[Schedule_Date] [datetime] NOT NULL,
	[Item_No] [nvarchar](30) NOT NULL,
	[Vendor_No] [nvarchar](8) NOT NULL,
	[Buyer] [nvarchar](6) NOT NULL,
	[NumTotalReceipt] [decimal](10, 0) NOT NULL,
	[NumOnTimeReceipt] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_QuotationHitRate]    Script Date: 03/02/2009 15:54:53 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_QuotationHitRate](
	[Ref_No] [nvarchar](16) NOT NULL,
	[Issue_Date] [datetime] NULL,
	[Customer_No] [nvarchar](8) NULL,
	[Salesman] [nvarchar](6) NULL,
	[Item_No] [nvarchar](30) NOT NULL,
	[Quote_Price] [decimal](16, 2) NULL,
	[IsOrdered] [int] NULL,
 CONSTRAINT [PK__Fact_QuotationHi__03F0984C] PRIMARY KEY CLUSTERED 
(
	[Ref_No] ASC,
	[Item_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dim_AnalysisCode]    Script Date: 03/02/2009 15:54:02 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_AnalysisCode](
	[Category] [nvarchar](30) NOT NULL,
	[Analysis_Code] [nvarchar](30) NOT NULL,
	[Description] [nvarchar](40) NOT NULL,
	[Category_Description] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Dim_AnalysisCode] PRIMARY KEY CLUSTERED 
(
	[Category] ASC,
	[Analysis_Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dim_Vendor]    Script Date: 03/02/2009 15:54:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_Vendor](
	[Vendor_No] [nvarchar](8) NOT NULL,
	[Vendor_Name] [nvarchar](50) NOT NULL,
	[Vendor_Group] [nvarchar](6) NOT NULL,
	[VendGroup_Description] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Dim_Vendor] PRIMARY KEY CLUSTERED 
(
	[Vendor_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_ShipmentValue]    Script Date: 03/02/2009 15:54:57 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_ShipmentValue](
	[Shipment_Date] [datetime] NOT NULL,
	[Customer_No] [nvarchar](8) NOT NULL,
	[Salesman] [nvarchar](6) NOT NULL,
	[Item_No] [nvarchar](30) NOT NULL,
	[Anlys3] [nvarchar](30) NOT NULL,
	[ShipmentValue] [decimal](20, 4) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dim_Calendar]    Script Date: 03/02/2009 15:54:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_Calendar](
	[Dates] [datetime] NOT NULL,
	[Years] [smallint] NOT NULL,
	[Quarters] [smallint] NOT NULL,
	[Months] [smallint] NOT NULL,
	[Weeks] [smallint] NOT NULL,
	[Days] [smallint] NOT NULL,
 CONSTRAINT [PK_Dim_Calendar] PRIMARY KEY CLUSTERED 
(
	[Dates] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dim_Fiscal]    Script Date: 03/02/2009 15:54:08 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_Fiscal](
	[Dates] [datetime] NOT NULL,
	[Fiscal_Period] [nvarchar](7) NOT NULL,
	[Fiscal_Year] [smallint] NOT NULL,
	[Fiscal_Quarter] [smallint] NOT NULL,
	[Fiscal_Month] [smallint] NOT NULL,
 CONSTRAINT [PK_Dim_Fiscal] PRIMARY KEY CLUSTERED 
(
	[Dates] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dim_Account]    Script Date: 03/02/2009 15:54:00 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_Account](
	[Acct_No] [nvarchar](8) NOT NULL,
	[Acct_Name] [nvarchar](50) NOT NULL,
	[Type] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Dim_Account] PRIMARY KEY CLUSTERED 
(
	[Acct_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_AccountSummary]    Script Date: 03/02/2009 15:54:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_AccountSummary](
	[Date] [datetime] NOT NULL,
	[Acct_No] [nvarchar](8) NOT NULL,
	[Amount] [decimal](16, 2) NOT NULL,
	[Anlys1] [nvarchar](30) NULL,
	[Anlys2] [nvarchar](30) NULL,
	[Anlys3] [nvarchar](30) NULL,
	[Anlys4] [nvarchar](30) NULL,
	[Anlys5] [nvarchar](30) NULL,
	[Anlys6] [nvarchar](30) NULL,
	[Anlys7] [nvarchar](30) NULL,
	[Anlys8] [nvarchar](30) NULL,
	[Anlys9] [nvarchar](30) NULL,
	[Anlys10] [nvarchar](30) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dim_Buyer]    Script Date: 03/02/2009 15:54:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_Buyer](
	[Buyer] [nvarchar](6) NOT NULL,
	[Buyer_Name] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Dim_Buyer] PRIMARY KEY CLUSTERED 
(
	[Buyer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dim_Customer]    Script Date: 03/02/2009 15:54:06 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_Customer](
	[Customer_No] [nvarchar](8) NOT NULL,
	[Customer_Name] [nvarchar](50) NOT NULL,
	[Customer_Group] [nvarchar](6) NOT NULL,
	[CustGroup_Description] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Dim_Customer] PRIMARY KEY CLUSTERED 
(
	[Customer_No] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dim_JobCategory]    Script Date: 03/02/2009 15:54:10 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_JobCategory](
	[Category] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Dim_JobCategory] PRIMARY KEY CLUSTERED 
(
	[Category] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dim_Operation]    Script Date: 03/02/2009 15:54:11 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_Operation](
	[Op_Code] [nvarchar](8) NOT NULL,
	[Description] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Dim_Operation] PRIMARY KEY CLUSTERED 
(
	[Op_Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dim_Parameter]    Script Date: 03/02/2009 15:54:12 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_Parameter](
	[Parameter_Name] [nvarchar](50) NOT NULL,
	[Parameter_Value] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Dim_Parameter] PRIMARY KEY CLUSTERED 
(
	[Parameter_Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dim_Planner]    Script Date: 03/02/2009 15:54:14 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_Planner](
	[Planner] [nvarchar](10) NOT NULL,
	[Name] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Dim_Planner] PRIMARY KEY CLUSTERED 
(
	[Planner] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dim_Salesman]    Script Date: 03/02/2009 15:54:15 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_Salesman](
	[Salesman] [nvarchar](6) NOT NULL,
	[Salesman_Name] [nvarchar](40) NOT NULL,
 CONSTRAINT [PK_Dim_Salesman] PRIMARY KEY CLUSTERED 
(
	[Salesman] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Dim_WorkCentre]    Script Date: 03/02/2009 15:54:18 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Dim_WorkCentre](
	[Work_Centre] [nvarchar](10) NOT NULL,
	[Description] [nvarchar](30) NOT NULL,
 CONSTRAINT [PK_Dim_WorkCentre] PRIMARY KEY CLUSTERED 
(
	[Work_Centre] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_DaysDebtors]    Script Date: 03/02/2009 15:54:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_DaysDebtors](
	[Customer_No] [nvarchar](8) NOT NULL,
	[Dates] [datetime] NOT NULL,
	[Sales_Amt] [decimal](20, 4) NOT NULL,
	[AR_Balance] [decimal](20, 4) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_DeliveryInFull]    Script Date: 03/02/2009 15:54:32 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_DeliveryInFull](
	[Customer_No] [nvarchar](8) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Total Quantity] [decimal](20, 4) NULL,
	[Quantity in Full] [decimal](20, 4) NULL,
	[Total Value] [decimal](20, 4) NULL,
	[Value in Full] [decimal](20, 4) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_OrderChangeFrequency]    Script Date: 03/02/2009 15:54:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_OrderChangeFrequency](
	[NumOrdersAmendment] [decimal](18, 0) NOT NULL,
	[NumTotalOrders] [decimal](18, 0) NOT NULL,
	[Order_Date] [datetime] NOT NULL,
	[Customer_No] [nvarchar](8) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Fact_ProductionEfficiency]    Script Date: 03/02/2009 15:54:42 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Fact_ProductionEfficiency](
	[Tran_Date] [datetime] NOT NULL,
	[Work_Centre] [nvarchar](10) NOT NULL,
	[OP_Code] [nvarchar](8) NOT NULL,
	[ActualLabourHrs] [decimal](18, 0) NOT NULL,
	[StandardLabourHrs] [decimal](18, 0) NOT NULL
) ON [PRIMARY]
GO

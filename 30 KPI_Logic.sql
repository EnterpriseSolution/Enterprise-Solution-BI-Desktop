if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_AnalysisCodeMaster]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_AnalysisCodeMaster]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_BuyerMaster]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_BuyerMaster]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_CalendarMaster]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_CalendarMaster]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_CustomerMaster]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_CustomerMaster]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_DaysCompletionEarlyAndLate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_DaysCompletionEarlyAndLate]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_DaysDebtors]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_DaysDebtors]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_DaysInInventory]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_DaysInInventory]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_DaysReceiptEarlyAndLate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_DaysReceiptEarlyAndLate]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_DaysShipmentEarlyAndLate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_DaysShipmentEarlyAndLate]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_DeliveryInFull]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_DeliveryInFull]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_FiscalMaster]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_FiscalMaster]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_InventoryTurns]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_InventoryTurns]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_ItemMaster]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_ItemMaster]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_JobCategoryMaster]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_JobCategoryMaster]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_NetAccountsReceivable]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_NetAccountsReceivable]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_OperationMaster]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_OperationMaster]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_OrderAvailability]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_OrderAvailability]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_OrderChangeFrequency]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_OrderChangeFrequency]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_OrderLeadTime]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_OrderLeadTime]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_OrderReliability]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_OrderReliability]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_PayTermsMaster]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_PayTermsMaster]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_PlannerMaster]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_PlannerMaster]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_ProductionEfficiency]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_ProductionEfficiency]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_ProductionReliability]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_ProductionReliability]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_ProductionYield]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_ProductionYield]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_ProductsMaster]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_ProductsMaster]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_ProfitabilityGP]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_ProfitabilityGP]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_ProfitabilityPM]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_ProfitabilityPM]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_PurchasePartsReliability]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_PurchasePartsReliability]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_PurchasePriceVariance]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_PurchasePriceVariance]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_SalesOrderOnHand]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_SalesOrderOnHand]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_SalesToNetWorkingCapital]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_SalesToNetWorkingCapital]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_SalesmanMaster]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_SalesmanMaster]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_ShipmentValue]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_ShipmentValue]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_VendorMaster]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_VendorMaster]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_WorkCentreMaster]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_WorkCentreMaster]
GO

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_QuotationHitRate]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_QuotationHitRate]
GO 

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_AccountMaster]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_AccountMaster]
GO 

if exists (Select * From dbo.sysobjects Where id = object_id(N'[dbo].[sp_BI_AccountSummary]') and OBJECTPROPERTY(id, N'IsProcedure') = 1)
drop procedure [dbo].[sp_BI_AccountSummary]
GO 

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_AnalysisCodeMaster
As
	Set NoCount On   

	-- UPDATE
	UPDATE
		[dbo].[Dim_AnalysisCode] With(TABLOCK)
	SET
		[Category] = C.[Category], [Description] = C.[Description]
	From
		[dbo].[Dim_AnalysisCode] E 
		Inner Join [GBANCO] C On C.[Category] = E.[Category] And C.[Analysis_Code] = E.[Analysis_Code]
		Inner Join [GBANTL] T On T.[Category] = C.[Category]
	Where
		E.[Category] != C.[Category] OR
		E.[Description] != C.[Description] OR
		E.[Category_Description] != T.[Description]

	--INSERT new record
	INSERT
		[dbo].[Dim_AnalysisCode] With(TABLOCK)
	Select
		C.[Category], C.[Analysis_Code], C.[Description], T.[Description]
	From
		[GBANTL] T
		Inner Join [GBANCO] C On T.[Category] = C.[Category]
	Where
		C.[Category] + C.[Analysis_code] Not In (Select [Category] + [Analysis_Code] From [dbo].[Dim_AnalysisCode])
	Order By
		C.[Analysis_Code], C.[Category]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_BuyerMaster
As
	Set NoCount On

	-- UPDATE
	UPDATE
		[dbo].[Dim_Buyer] With(TABLOCK)
	SET
		[Buyer_Name] = C.[Buyer_Name]
	From
		[dbo].[Dim_Buyer] E
		Inner Join [PUBUYR] C On C.[Buyer_Code] = E.[Buyer]
	Where
		E.[Buyer_name] != C.[Buyer_name]

	--INSERT new record
	INSERT
		[dbo].[Dim_Buyer] With(TABLOCK)
	Select
		[Buyer_Code], [Buyer_name]
	From
		[PUBUYR]
	Where
		[Buyer_code] Not In (Select [Buyer_code] From [dbo].[Dim_Buyer])
	Order By
		[Buyer_code]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_CalendarMaster
As 
	Set NoCount On

	Declare @Dates datetime
	Declare @Years smallint
	Declare @Quarters smallint  
	Declare @MonthsCode smallint
	Declare @Weeks smallint
	Declare @Days smallint
	Declare @Start_Date datetime
	Declare @End_Date datetime

	/*****************************/
	/* Calendar Master Dimension */
	/*****************************/
	Truncate Table [dbo].[Dim_Calendar]
  
	Declare Date_Cursor Cursor Fast_Forward Read_Only For
		Select
			[Start_date], [End_date]
		From
			[GBPERD]
		Order By
			[Start_date], [End_date]

	Open Date_Cursor
	Fetch Next From Date_Cursor Into @Start_Date, @End_Date

	While @@Fetch_status = 0
	Begin
		Set @Dates = @Start_Date
		Set @Days = DatePart (dd, @Start_Date)
		Set @MonthsCode = DatePart (mm, @Start_Date)
		Set @Years = DatePart (yy, @Start_Date)	

		While @Dates <= @End_date
		Begin
			Set @Quarters = DatePart(quarter, @Dates)		
			Set @Weeks = DatePart(week, @Dates)
			Set @Days = DatePart(day, @Dates)

			Insert
				[dbo].[Dim_Calendar] With(TABLOCK)
			Values
				(@Dates, @Years, @Quarters, @MonthsCode, @Weeks, @Days)

			Set @Dates = @Dates + 1
		End

		Fetch Next From Date_Cursor Into @Start_Date, @End_Date
	End

	Close Date_Cursor
	Deallocate Date_Cursor
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_CustomerMaster
As

	Set NoCount On 

	-- UPDATE
	UPDATE
		[dbo].[Dim_Customer] With(TABLOCK)
	SET
		[Customer_Name] = C.[Customer_Name],
		[Customer_Group] = C.[Customer_Group],
		[CustGroup_Description] = G.[Description]
	From
		[dbo].[Dim_Customer] E
		Inner Join [GBCUST] C On C.[Customer_No] = E.[Customer_No]
		Inner Join [GBCGRP] G On G.[Customer_Group] = E.[Customer_Group]
	Where
		E.[Customer_Name] != C.[Customer_Name] OR
		E.[Customer_Group] != C.[Customer_Group] OR
		E.[CustGroup_Description] != G.[Description]

	--INSERT new record
	INSERT
		[dbo].[Dim_Customer] With(TABLOCK) 
	Select
		C.[Customer_No], C.[Customer_Name], C.[Customer_Group], G.[Description]
	From
		[GBCUST] C	Inner Join [GBCGRP] G On G.[Customer_Group] = C.[Customer_Group]
	Where
		C.[Customer_No] Not In (Select [Customer_No] From [dbo].[Dim_Customer])
	Order By
		C.[Customer_No]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_DaysCompletionEarlyAndLate
As
	Set NoCount On

	/************************************************/
	/* Fact Table in Days Completion Early and Late */
	/************************************************/
	Truncate Table [dbo].[Fact_DaysCompletionEarlyAndLate]

	Insert [dbo].[Fact_DaysCompletionEarlyAndLate] With(TABLOCK) 
	Select
		D.[Due_Date] as Dates, D.[Item_No], [Work_Centre],
		Sum(Case When [Completed_Date] < D.[Due_Date] and D.[No_Of_Lots] <= (IsNull([Lots_Previous],0) + [Lots_This]) then convert(int, D.[Due_Date]) - convert(int, [Completed_Date]) Else  0 end) as NumDaysEarly,
		Sum(Case When [Completed_Date] < D.[Due_Date] and D.[No_Of_Lots] <= (IsNull([Lots_Previous],0) + [Lots_This]) then 1 Else   0 end) as NumOrdersEarly,
		Sum(Case When [Completed_Date] > D.[Due_Date] and D.[No_Of_Lots] <= (IsNull([Lots_Previous],0) + [Lots_This]) then convert(int, [Completed_Date]) - convert(int, D.[Due_Date]) Else  0 end) as NumDaysLate,
		Sum(Case When [Completed_Date] > D.[Due_Date] and D.[No_Of_Lots] <= (IsNull([Lots_Previous],0) + [Lots_This]) then 1 Else   0 end) as NumOrdersLate
	From
		[PRJOBD] D
		Inner Join [PRCOMH] H On D.[Job_No] = [H].[Job_No] and D.[Batch_No] = H.[Batch_No]
		--Inner Join [dbo].[Dim_Fiscal] E On E.Dates = D.[Due_Date]
	Where
		H.[Posted] = 'Y' And
		H.[Final] = 'Y' And
		IsNull([Work_Centre], '') != ''
	Group By
		D.[Due_Date], D.[Item_No], [Work_Centre]
	Order By
		D.[Due_Date], D.[Item_No], [Work_Centre]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_DaysDebtors
As

	/************************************************/
	/*												*/
	/* Fact Table in Days Debtors					*/
	/*												*/
	/* Logic :										*/
	/*    Get Invoice (Sales) Amt and A/R Balance	*/	
	/************************************************/

	-- Clear Fact Table
	Truncate Table [dbo].[Fact_DaysDebtors]

	-- Insert Into fact table
	Insert
		[dbo].[Fact_DaysDebtors] With(TABLOCK) 
	-- Get Invoice (Sales) Amt and A/R Balance
	Select
		L.[Customer_No],
		P.[Start_Date] as Dates,
		IsNull(L.[Local_Invo_Amt],0) as Sales_Amt,
		IsNull(L.[Local_Bal_End],0) as AR_Balance
	From
		[GBPERD] P
		Inner Join [ARLEDG] L On P.[Period] = L.[Period]
		--Inner Join [dbo].[Dim_Fiscal] DF On DF.[Dates] = P.[Start_Date]
		Inner Join [dbo].[Dim_Customer] DC On DC.[Customer_No] = L.[Customer_No]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_DaysInInventory
As

	/***********************************************/
	/* Fact Table in Days in Inventory */
	/***********************************************/

	Declare @udperiod decimal(4,0)

    -- Clear Fact Table
    Truncate Table [dbo].[Fact_DaysInInventory]

    -- Get user-defined period
    Select
		@udperiod = convert(int, Parameter_Value)
    From
        [dbo].[Dim_Parameter]
    Where
       Parameter_Name ='Days In Inventory'

    -- Get Ending Inventory value On hand
    Select
        P.[Start_Date],
        Sum(IsNull(L.[Qty_Beg],0) *
        IsNull(
        Case I.[Average_Cost]
            When '' then
				0.00
            Else
				cast(I.[Average_Cost] as decimal(20,4))
        end, 0)
        ) as cost
    Into #balance
    From
        [ICLEDG] L
		Inner Join [GBPERD] P On L.[Period] = P.[Period]
        Inner Join [GBITEM] I On L.[Item_No] = I.[Item_No]		
		--Inner Join [dbo].[Dim_Fiscal] DF On df.Dates = P.[Start_Date]
		Inner Join [dbo].[Dim_Item] DI On DI.[Item_No] = I.[Item_No]
    Group By
        P.[Start_Date]

    -- Get upcoming shipment cost of goods sold value
    Select
        P.[Start_Date],
        Sum(IsNull(T.[Qty],0) *
        IsNull(
        Case I.[Average_Cost]
            When '' then 0.00
            Else  cast(I.[Average_Cost] as decimal(20,4))
        end, 0)
        ) as cost
    Into #coming
    From
        [SLORDH] H,
        [SLORDD] D,
        [SLORDT] T,
        [GBPERD] P,
        [GBITEM] I
    Where
        D.[Item_No] = I.[Item_No] and
        H.[Order_No] = T.[Order_No] and
        D.[Order_No] = T.[Order_No] and
        D.[Line_No] = T.[Line_No] and
        H.[Posted] = 'Y' and
        T.[Sched_Date] between P.[Start_Date] and (P.[Start_Date] + @udperiod)
    Group By
        P.[Start_Date]

    -- Consolidate data and insert Into fact
    Insert
		[dbo].[Fact_DaysInInventory] With(TABLOCK) 
	Select
       B.[Start_Date] as Period_Start,
       IsNull(B.cost,0) as On_Hand_Bal,
       IsNull(C.cost,0) as Coming_Ship,
       IsNull(cast(@udperiod as int),0) as Period_In_Days
	From
        #balance B Left Join #coming C On B.[Start_Date] = C.[Start_Date]
    Order By
		B.[Start_Date]

    Drop Table #coming
    Drop Table #balance
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_DaysReceiptEarlyAndLate
As

	Set NoCount On

	/*********************************************/
	/* Fact Table in Days Receipt Early and Late */
	/*********************************************/
	Truncate Table [dbo].[Fact_DaysReceiptEarlyAndLate]

	Insert
		[dbo].[Fact_DaysReceiptEarlyAndLate] With(TABLOCK) 
	Select
		T.[Sched_Date], T.[Item_No], D.[Vendor_No], H.[Buyer],
		Sum(Case When T.[Sched_Date] > [Received_Date] and D.[Qty_Balance] <= D.[Qty_Received] then convert(int, T.[Sched_Date]) - convert(int, [Received_Date]) Else  0 end) as NumDaysEarly,
		Sum(Case When T.[Sched_Date] > [Received_Date] and D.[Qty_Balance] <= D.[Qty_Received] then 1 Else  0 end) as NumReceiptEarly,
		Sum(Case When T.[Sched_Date] < [Received_Date] and D.[Qty_Balance] <= D.[Qty_Received] then convert(int, [Received_Date]) - convert(int, T.[Sched_Date]) Else  0 end) as NumDaysLate,
		Sum(Case When T.[Sched_Date] < [Received_Date] and D.[Qty_Balance] <= D.[Qty_Received] then 1 Else  0 end) as NumReceiptLate
	From
		[PUORDH] H
		Inner Join [PUORDT] T On H.[Order_No] = T.[Order_No]
		Inner Join [PUGRND] D On T.[Order_No] = D.[Order_No] and T.[Line_No] = D.[Line_No]
		Inner Join [dbo].[Dim_Vendor] DV On DV.[Vendor_No] = D.[Vendor_No]
	Where
		H.[Posted] = 'Y' and 
		D.[Posted] = 'Y' and 
		T.[Sched_Date] <> [Received_Date]
	Group By
		T.[Sched_Date], T.[Item_No], D.[Vendor_No], H.[Buyer]
	Order By
		T.[Sched_Date], T.[Item_No], D.[Vendor_No], H.[Buyer]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_DaysShipmentEarlyAndLate
As

	Set NoCount On

	/**********************************************/
	/* Fact Table in Days Shpiment Early and Late */
	/**********************************************/

	Truncate Table [dbo].[Fact_DaysShipmentEarlyAndLate]

	Insert
		[dbo].[Fact_DaysShipmentEarlyAndLate] With(TABLOCK) 
	Select
		T.[Sched_Date], T.[Item_No], D.[Customer_No], H.[Salesman],
		Sum(Case When T.[Sched_Date] > shipment_date and D.[Qty_Balance] <= D.[Qty_Shipped] then convert(int, T.[Sched_Date]) - convert(int, D.[Shipment_Date]) Else  0 end) as NumDaysEarly,
		Sum(Case When T.[Sched_Date] > shipment_date and D.[Qty_Balance] <= D.[Qty_Shipped] then 1 Else  0 end) as NumShipmentEarly,
		Sum(Case When T.[Sched_Date] < shipment_date and D.[Qty_Balance] <= D.[Qty_Shipped] then convert(int, D.[Shipment_Date]) - convert(int, T.[Sched_Date]) Else  0 end) as NumDaysLate,
		Sum(Case When T.[Sched_Date] < shipment_date and D.[Qty_Balance] <= D.[Qty_Shipped] then 1 Else  0 end) as NumShipmentLate
	From
		[SLORDH] H
		Inner Join [SLORDT] T On H.[Order_No] = T.[Order_No]
		Inner Join [SLSHPD] D On T.[Order_No] = D.[Order_No] And T.[Line_No] = D.[Line_No]
		Inner Join [dbo].[Dim_Item] DI On T.[Item_No] = DI.[Item_No]
		Inner Join [dbo].[Dim_Customer] DC On H.[Customer_No] = DC.[Customer_No]
	Where
		H.[Posted] = 'Y' and 
		D.[Posted] = 'Y' and 
		T.[Sched_Date] <> D.[Shipment_Date]
	Group By
		T.[Sched_Date], T.[Item_No], D.[Customer_No], H.[Salesman]
	Order By
		T.[Sched_Date], T.[Item_No], D.[Customer_No], H.[Salesman]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_DeliveryInFull
As

	Set NoCount On

	/**********************************/
	/* Fact Table in Delivery in Full */
	/**********************************/

	Truncate Table [dbo].[Fact_DeliveryInFull]

	Insert
		[dbo].[Fact_DeliveryInFull] With(TABLOCK)
    Select
        [Customer_No],
        [Sched_Date],
        Sum([Qty]) as [Total Quantity],
        Sum([Qty_In_Full]) as [Quantity in Full],
        Sum([Amt]) as [Total Value],
        Sum([Amt_In_Full]) as [Value in Full]
	From
		(Select
			H.[Customer_No],
			T.[Sched_Date],
			IsNull(T.[Qty], 0) as Qty,
			case
				When IsNull(T.[Qty],0) <= IsNull(T.[Qty_Shipped], 0) then
					IsNull(T.[Qty],0)
				Else 
					0
			end as Qty_In_Full,
			IsNull((D.[Price_Amt] - IsNull(D.[Ldisc_Amt],0)) * T.[Qty] / D.[Qty],0) as Amt,
			case
				When IsNull(T.[Qty],0) <= IsNull(T.[Qty_Shipped], 0) then
					IsNull((D.[Price_Amt] - IsNull(D.[Ldisc_Amt],0)) * T.[Qty] / D.[Qty],0)
				Else 
					0
			end as Amt_In_Full
		From
			[SLORDH] H
			Inner Join [SLORDD] D On H.[Order_No] = D.[Order_No]
			Inner Join [SLORDT] T On D.[Order_No] = T.[Order_No] and D.[Line_No] = T.[Line_No]
			Inner Join [dbo].[Dim_Customer] DC On DC.[Customer_No] = H.[Customer_No]
		Where
			H.[Posted] = 'Y' and
			IsNull(D.[Qty],0) > 0
		) TempTable
    Group By
		[Customer_No], [Sched_Date]
    Order By
		[Customer_No], [Sched_Date]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_FiscalMaster
As

	Declare @RealDates datetime
	Declare @Start_Date datetime   
	Declare @End_Date datetime
	Declare @Years smallint
	Declare @Months smallint
	Declare @Days smallint
	Declare @MonthsCode smallint 
	Declare @Fiscal_Period nvarchar (7)  	
	Declare @Fiscal_Year smallint
	Declare @Fiscal_Month smallint	
	Declare @Fiscal_Quarter smallint

	/***************************/
	/* Fiscal Master Dimension */
	/***************************/

	Declare Fiscal_Cursor Cursor Fast_Forward Read_Only For
		Select
			[Start_Date], [End_Date], [Fiscal_Year], [Period_No], [Period]
		From
			[GBPERD]
		Order By
			[Start_Date], [End_Date]

	Truncate table [dbo].[Dim_Fiscal]

	Open Fiscal_Cursor
	Fetch Next From Fiscal_Cursor Into @Start_Date, @End_Date, @Fiscal_Year, @Fiscal_Month, @Fiscal_Period
	While @@Fetch_status = 0
	Begin
		Set @RealDates = @Start_Date
		Set @Days = DatePart (dd, @Start_Date)
		Set @Months = DatePart (mm, @Start_Date)
		Set @Years = DatePart (yy, @Start_Date)		
		Set @MonthsCode = @Fiscal_Month

		While @RealDates <= @End_date
		Begin
			Set @Fiscal_Month = @MonthsCode
			Set @Fiscal_Quarter =
				Case @MonthsCode		
					When '1' Then 1
					When '2' Then 1
					When '3' Then 1
					
					When '4' Then 2
					When '5' Then 2
					When '6' Then 2
					
					When '7' Then 3
					When '8' Then 3
					When '9' Then 3
					
					When '10' Then 4
					When '11' Then 4
					When '12' Then 4
					Else  '0'
				End			

			Insert
				[dbo].[Dim_Fiscal] With(TABLOCK)
			Values
				(@RealDates, @Fiscal_Period,  @Fiscal_Year, @Fiscal_Quarter, @Fiscal_Month)

			Set @RealDates = @RealDates + 1
		End

		Fetch Next From Fiscal_Cursor Into @Start_Date, @End_Date, @Fiscal_Year, @Fiscal_Month, @Fiscal_Period   
	End

	Close Fiscal_Cursor
	Deallocate Fiscal_Cursor
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_InventoryTurns
As

	Set NoCount On

	/*********************************/
	/* Fact Table in Inventory Turns */
	/*********************************/

	Truncate Table [dbo].[Fact_InventoryTurns]

	Declare @COGS_Start nvarchar(50)
	Declare @COGS_End nvarchar(50)
	Declare @Inventory_Start nvarchar(50)
	Declare @Inventory_End nvarchar(50)

	Select @COGS_Start = [Parameter_Value] From [dbo].[Dim_Parameter] Where [Parameter_Name] ='COGS A/C Start'
	Select @COGS_End = [Parameter_Value] From [dbo].[Dim_Parameter] Where [Parameter_Name] ='COGS A/C End'
	Select @Inventory_Start = [Parameter_Value] From [dbo].[Dim_Parameter] Where [Parameter_Name] ='Inventory A/C Start'
	Select @Inventory_End = [Parameter_Value] From [dbo].[Dim_Parameter] Where [Parameter_Name] ='Inventory A/C End'

	Insert
		Into [dbo].[Fact_InventoryTurns] With(TABLOCK)
	Select
		[Start_Date] as Period_StartDate,
		Sum(Case When L.[Acct_No] between @COGS_Start and @COGS_End
			then (IsNull(L.[Total_Debit],0) - IsNull(D.[Ledger_Debit],0) - IsNull(L.[Total_Credit],0) + IsNull(D.[Ledger_Credit],0))
			Else  0 end) as COGS_Balance,
		Sum(Case When L.[Acct_No] between @Inventory_Start and @Inventory_End
			then (Case When L.[Bal_End_Sign] = 'Debit' then IsNull(L.[Bal_End],0) Else  IsNull(L.[Bal_End],0)*-1 end) Else  0 end) as Inventory_Balance
	From
		[GLLEDG] L
		Left Outer Join [GBPERD] P On L.[Period] = P.[Period]
		Left Outer Join [GLVOUD] D On L.[Period] = D.[Period] and L.acct_no = D.[Acct_No]
	Where
		D.[Voucher_Type] = 'CLOSE' And		
		(L.[Acct_No] between @Inventory_Start and @Inventory_End or L.[Acct_No] between @COGS_Start and @COGS_End)		
	Group By
		[Start_Date]
	Order By
		[Start_Date]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_ItemMaster
As
	Set NoCount On

	-- UPDATE
	UPDATE
		[dbo].[Dim_Item] With(TABLOCK)
	SET
		[Item_Description] = I.[Description], [ItemGroup_Description] = G.[Description]
	From
		[dbo].[Dim_Item] E
		Inner Join [GBITEM] I On I.[Item_No] = E.[Item_No]
		Inner Join GBIGRP G On G.[Item_Group] = E.[Item_Group]
	Where
		E.[Item_Description] != I.[Description] OR E.[ItemGroup_Description] != G.[Description]

	--INSERT new record
	INSERT
		[dbo].[Dim_Item] With(TABLOCK)
	Select
		I.[Item_No], I.[Description], I.[Item_Group], G.[Description]
	From
		[GBITEM] I
		Inner Join [GBIGRP] G On G.[Item_Group] = I.[Item_Group]
	Where
		I.[Item_No] Not In (Select [Item_No] From [dbo].[Dim_Item])
	Order By
		[I].[Item_No]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_JobCategoryMaster 
As

	Set NoCount On

	-- UPDATE
	UPDATE
		[dbo].[Dim_JobCategory] With(TABLOCK)
	SET
		[Description] = C.[Description]
	From
		[dbo].[Dim_JobCategory] E
		Inner Join [GBJCAT] C On C.[Category] = E.[Category]
	Where
		e.[Description] != C.[Description] 

	--INSERT new record
	INSERT
		[dbo].[Dim_JobCategory] With(TABLOCK)
	Select
		[Category], [Description]
	From
		[GBJCAT]
	Where
		[Category] Not In (Select [Category] From [dbo].[Dim_JobCategory])
	Order By
		[Category]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_NetAccountsReceivable
As
	Set NoCount On

	/****************************************/
	/* Fact Table in Net Account Receivable */
	/****************************************/

	Truncate table [dbo].[Fact_NetAccountsReceivable]

	/*
	Insert
		[dbo].[Fact_NetAccountsReceivable] With(TABLOCK)
	Select
		[ARPAYH].[Receipt_Date] as Transaction_Date,
		(Sum([ARPAYD].[Settled_Amt] * Convert(int, ([ARPAYH].[Receipt_Date] - [ARPAYD].[Invoice_Date])) + 1)) as NumReceiptDays,
		Sum([ARPAYD].[Settled_Amt]) as AR_Settled_Amt,
		(Sum([APPAYD].[Settled_Amt] * Convert(int, ([APPAYH].[Paid_Date] - [APPAYD].[Invoice_Date])) + 1)) as NumPaidDays,
		Sum([APPAYD].[Settled_Amt]) as AP_Settled_Amt
	From
		[ARPAYH], [ARPAYD], [APPAYH], [APPAYD]
	Where
		[ARPAYH].[Receipt_No] = [ARPAYD].[Receipt_No] and [ARPAYH].[Receipt_Date] Is Not Null and [ARPAYD].[Invoice_Date] is not null and IsNull([ARPAYD].[Settled_Amt], 0) > 0
		[ARPAYH].[Receipt_Date] = [APPAYH].[Paid_Date] and [APPAYH].[Ref_No] = [APPAYD].[Ref_No] and [APPAYD].[Invoice_Date] is not null and IsNull([APPAYD].[Settled_Amt], 0) > 0
	Group By
		[ARPAYH].[Receipt_Date]
	Order By
		[ARPAYH].[Receipt_Date]
	*/

	Insert
		[dbo].[Fact_NetAccountsReceivable] With(TABLOCK)
	Select
		[ARPAYH].[Receipt_Date] as Transaction_Date,
		(Sum([ARPAYD].[Settled_Amt] * Convert(int, ([ARPAYH].[Receipt_Date] - [ARPAYD].[Invoice_Date])) + 1)) as NumReceiptDays,
		Sum([ARPAYD].[Settled_Amt]) as AR_Settled_Amt,
		0 as NumPaidDays,
		0 as AP_Settled_Amt
	From
		[ARPAYH]
		Inner Join [ARPAYD] On [ARPAYH].[Receipt_No] = [ARPAYD].[Receipt_No]
	Where
		[ARPAYH].[Posted] = 'Y' And
		[ARPAYD].[Invoice_Date] Is Not Null And
		IsNull([ARPAYD].[Settled_Amt], 0) > 0
	Group By
		[ARPAYH].[Receipt_Date]
	Order By
		[ARPAYH].[Receipt_Date]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_OperationMaster
As

	Set NoCount On

	-- UPDATE
	UPDATE
		[dbo].[Dim_Operation] With(TABLOCK)
	SET
		[Description] = O.[Description]
	From
		[dbo].[Dim_Operation] E
		Inner Join [GBOPER] O On O.[OP_Code] = E.[OP_Code]
	Where
		E.[Description] != O.[Description] 

	--INSERT new record
	INSERT
		[dbo].[Dim_Operation] With(TABLOCK)
	Select
		[OP_Code], [Description]
	From
		[GBOPER]
	Where
		[OP_Code] Not In (Select [OP_Code] from [dbo].[Dim_Operation])
	Order By
		[OP_Code]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_OrderAvailability
As

	Set NoCount On

	/***************************************/
	/* Fact Table in Order Availability */
	/**************************************/ 
	Truncate table [dbo].[Fact_OrderAvailability]

	Select
		A.[Order_No], A.[Line_No], A.[Due_Date], Sum(IsNull(B.[Qty],0)) as Qty
	Into #temp
	From
		[SLORDT] A Inner Join [SLORDT] B On A.[Order_No] = B.[Order_No] and A.[Line_No] = B.[Line_No]
	Where		
		A.[Posted] = 'Y' And
		B.[Posted] = 'Y' And
		A.[Due_Date] >= B.[Due_Date]
	Group By
		A.[Order_No], A.[Line_No], A.[Due_Date]
	Order By
		A.[Order_No], A.[Line_No], A.[Due_Date]

	Select
		T.[Order_No], T.[Line_No], T.[Due_Date], Max(Case When [Shipment_Date] <=T.[Due_Date] then [Shipment_Date] Else 0 end) as [Shipment_Date],
		Max(IsNull(T.[Qty],0)) as [Sched_Qty], Sum(Case When [Shipment_Date] <= T.[Due_Date] then IsNull(D.[Qty_Shipped],0) Else 0 end) as [Qty_Shipped]
	Into #source
	From
		[SLSHPD] D Inner Join #temp T On D.[Order_No] = T.[Order_No] and D.[Line_No] = T.[Line_No]
	Where
		D.[Posted] = 'Y'
	Group By
		T.[Order_No], T.[Line_No], T.[Due_Date]
	Order By
		T.[Order_No], T.[Line_No], T.[Due_Date]

	Insert
		[dbo].[Fact_OrderAvailability] With(TABLOCK)
	Select
		S.[Due_Date], D.[Item_No], H.[Customer_No], H.[Salesman], Count(S.[Due_Date]) as NumShipment,
		Sum(Case When S.[Shipment_Date] is not null and S.[Qty_Shipped] >= S.[Sched_Qty] then 1 Else 0 end) as NumAvailableShipment
	From
		[SLORDH] H
		Inner Join #source S On S.[Order_No] = H.[Order_No]
		Inner Join [SLSHPD] D On S.[Order_No] = D.[Order_No] and S.[Line_No] = D.[Line_No]
		Inner Join [dbo].[Dim_Item] DI On D.[Item_No] = DI.[Item_No]
		Inner Join [dbo].[Dim_Customer] DC On H.[Customer_No] = DC.[Customer_No]
	Where
		H.[Posted] = 'Y'
	Group By
		S.[Due_Date], D.[Item_No], H.[Customer_No], salesman
	Order By
		S.[Due_Date], D.[Item_No], H.[Customer_No], salesman

	Drop Table #temp, #source
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

CREATE Procedure sp_BI_OrderChangeFrequency
As
    Set NoCount On

	/*****************************************/
	/* Fact Table in Order Change Frequency  */
	/*****************************************/
	Truncate table [dbo].[Fact_OrderChangeFrequency]

	Insert
		[dbo].[Fact_OrderChangeFrequency] With(TABLOCK)
	Select
		Sum(IsNull(NumOrdersAmendment,0)) as NumOrdersAmendment,
		Sum(IsNull(NumTotalOrders,0)) as NumTotalOrders,
		[Order_date],
		[Customer_No]
	From
		(
		/* Get Amendments */
		Select
			Count(H.[Order_No]) as NumOrdersAmendment,
			0 as NumTotalOrders,
			H.[Amend_Date] as Order_Date,
			H.[Customer_No] as Customer_No
		From
			[SLAMDH] H
			Inner Join [dbo].[Dim_Customer] DC On DC.[Customer_No] = H.[Customer_No]
		Where
			H.[Posted] = 'Y'
		Group By
			H.[Amend_Date], H.[Customer_No]
		Union
		/* Get Sales Orders */
		Select
			0 as NumOrdersAmendment,
			Count(H.[Order_No]) as NumTotalOrders,
			H.[Order_Date] as Order_Date,
			H.[Customer_No] as Customer_No
		From
			[SLORDH] H
			Inner Join [dbo].[Dim_Customer] DC On DC.[Customer_No] = H.[Customer_No]
		Where
			H.[Posted] = 'Y'
		Group By
			H.[Order_Date], H.[Customer_No]
		 ) as Temp_Table
	Group By
		[Order_Date], [Customer_No]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_OrderLeadTime
As

	Set NoCount On

	/***************************************/
	/* Fact Table in Order Lead Time */
	/**************************************/
	Truncate Table [dbo].[Fact_OrderLeadTime]

	Insert
		[dbo].[Fact_OrderLeadTime] With(TABLOCK)
	Select
		[Order_Date], D.[Item_No],
		Sum(D.[Qty_Shipped] * Convert(int, ([Shipment_Date] - [Order_Date]))) as QtyLeadTime,
		Sum(D.[Qty_Shipped]) as OrderQuantity
	From
		[SLORDH] H
		Inner Join [SLSHPD] D On H.[Order_No] = D.[Order_No]
		Inner Join [dbo].[Dim_Item] DI On DI.[Item_No] = D.[Item_No]
	Where
		IsNull([Qty_Shipped], 0) > 0 And
		[Shipment_Date] Is Not Null		
	Group By
		[Order_Date], D.[Item_No]
	Order By
		[Order_Date], D.[Item_No]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_OrderReliability
As

	Set NoCount On

	/**************************************/
	/* Fact Table in Order Reliability */
	/**************************************/
	Truncate table [dbo].[Fact_OrderReliability]

	Select
		A.[Order_No], A.[Line_No], A.[Sched_Date], Sum(IsNull(B.[Qty],0)) as qty
	Into #temp
	From
		[SLORDT] A Inner Join [SLORDT] B On A.[Order_No] = B.[Order_No] and A.[Line_No] = B.[Line_No]
	Where
		A.Posted = 'Y' And
		B.Posted = 'Y' And
		A.[Sched_Date] >= B.[Sched_Date]
	Group By
		A.[Order_No], A.[Line_No], A.[Sched_Date]
	Order By
		A.[Order_No], A.[Line_No], A.[Sched_Date]

	Select
		T.[Order_No], T.[Line_No], T.[Sched_Date], Max(Case When [Shipment_Date] <=T.[Sched_Date] then [Shipment_Date] Else 0 end) as Shipment_Date,
		Max(IsNull(T.[Qty],0)) as Sched_Qty, Sum(Case When [Shipment_Date] <= T.[Sched_Date] then D.[Qty_Shipped] Else 0 end) as Qty_Shipped
	Into #source
	From
		[SLSHPD] D Inner Join #temp T On D.[Order_No] = T.[Order_No] and D.[Line_No] = T.[Line_No]
	Where
		D.[Posted] = 'Y'
	Group By
		T.[Order_No], T.[Line_No], T.[Sched_Date]
	Order By
		T.[Order_No], T.[Line_No], T.[Sched_Date]

	Insert
		[dbo].[Fact_OrderReliability] With(TABLOCK)
	Select
		S.[Sched_Date], D.[Item_No], H.[Customer_No], H.[Salesman], Count(S.[Sched_Date]) as NumShipment,
		Sum(Case When S.[Shipment_Date] is not null and IsNull(S.[Qty_Shipped],0) >= IsNull(S.[Sched_Qty],0) then 1 Else 0 end) as NumOnTimeShipment  
	From
		[SLORDH] H
		Inner Join #source S On S.[Order_No] = H.[Order_No]		
		Inner Join [SLSHPD] D On S.[Order_No] = D.[Order_No] and S.[Line_No] = D.[Line_No]	
		Inner Join [dbo].[Dim_Item] DI On D.[Item_No] = DI.[Item_No]
	Where
		H.[Posted] = 'Y' And
		D.[Posted] = 'Y'		 
	Group By
		S.[Sched_Date], D.[Item_No], H.[Customer_No], H.[Salesman]
	Order By
		S.[Sched_Date], D.[Item_No], H.[Customer_No], H.[Salesman]

	Drop Table #temp, #source
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_PayTermsMaster
As
	Set NoCount On

	-- UPDATE
	UPDATE
		[dbo].[Dim_PayTerms] With(TABLOCK)
	SET
		[Description] = T.[Description]
	From
		[dbo].[Dim_PayTerms] E
		Inner Join [GBTERM] T On T.Pay_Terms = E.Pay_Terms
	Where
		E.[Description] != T.[Description] 

	--INSERT new record
	INSERT
		[dbo].[Dim_PayTerms] With(TABLOCK)
	Select
		[Pay_Terms], [Description]
	From
		[GBTERM]
	Where
		[Pay_Terms] Not In (Select [Pay_Terms] From [dbo].[Dim_PayTerms])
	Order By
		[Pay_Terms]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_PlannerMaster
As

	Set NoCount On

	-- UPDATE
	UPDATE
		[dbo].[Dim_Planner] With(TABLOCK)
	SET
		[Name] = P.[Name]
	From
		[dbo].[Dim_Planner] E
		Inner Join [GBPLAN] P On P.Planner = E.Planner
	Where
		E.[Name] != P.[Name] 

	--INSERT new record
	INSERT
		[dbo].[Dim_Planner] With(TABLOCK)
	Select
		[Planner], [Name]
	From
		[GBPLAN]
	Where
		[Planner] Not In (Select [Planner] From [dbo].[Dim_Planner])
	Order By
		[Planner]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_ProductionEfficiency
As

	Set NoCount On

	/********************************************/
	/* Fact Table in Production Efficiency */
	/********************************************/

	Truncate table [dbo].[Fact_ProductionEfficiency]

	Insert
		[dbo].[Fact_ProductionEfficiency] With(TABLOCK)
	Select
		[Tran_Date],
		H.[Work_Centre],
		H.[OP_Code],
		Sum(IsNull([Labor_Hr],0)) as ActualLabourHrs,
		Sum(Hrs_Per_Lot1 * No_Of_Lots) as StandardLabourHrs
	From
		[PRCOMH] H
		Inner Join [PRJOBR] R On H.[Job_No] = R.[Job_No] and H.[Step_No] = R.[Step_No]
	Where
		H.[Posted] = 'Y' and
		[Labor_Hr] is not null and
		[Hrs_Per_Lot1] is not null and
		[No_Of_Lots] is not null
	Group By
		[Tran_Date], H.[Work_Centre], H.[OP_Code]
	Order By
		[Tran_Date], H.[Work_Centre], H.[OP_Code]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_ProductionReliability
As

	Set NoCount On

	/********************************************/
	/* Fact Table in Production Reliability */
	/********************************************/
	Truncate table [dbo].[Fact_ProductionReliability]

	Insert
		[dbo].[Fact_ProductionReliability] With(TABLOCK)
	Select
		D.[Due_Date] as Dates,
		D.[Item_No],
		S.[Customer_No],
		C.[Work_Centre],
		H.[Job_Category] as Category,
		Count(D.[Due_Date]) as NumWorkOrder,
		Sum(Case When C.[Completed_Date] <= D.[Due_Date] and D.[No_Of_Lots] <= (IsNull(C.[Lots_Previous],0) + C.[Lots_This]) then 1 Else 0 end) as NumOnTimeWorkOrder
	From
		[PRJOBH] H
		Inner Join [SLORDH] S On H.[Source_Ref_No] = S.[Order_No] 
		Inner Join [PRJOBD] D On H.[Job_No] = D.[Job_No]
		Inner Join [PRCOMH] C On D.[Job_No] = C.[Job_No] and D.[Batch_No] = C.[Batch_No]
		Inner Join [dbo].[Dim_Item] DI On D.[Item_No] = DI.[Item_No]
		Inner Join [dbo].[Dim_Customer] DC On DC.[Customer_No] = S.[Customer_No]
	Where
		H.[Posted] = 'Y' and
		S.[Posted] = 'Y' and
		C.[Posted] = 'Y' and
		C.[Final] = 'Y' and
		IsNull(C.[Work_Centre], '') != '' and
		IsNull(H.[Job_Category], '') != ''
	Group By
		D.[Due_Date], D.[Item_No], S.[Customer_No], C.[Work_Centre], H.[Job_Category]
	Order By
		D.[Due_Date], D.[Item_No], S.[Customer_No], C.[Work_Centre], H.[Job_Category]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_ProductionYield
As

	/***************************************************************************/
	--
	--  Insert Data Into Fact Production Yield
	--
	--  Logic :
	--    - Get Finished Jobs
	--    - Get product recieved (primary product only) of above jobs
	--    - Get material kit issue of above jobs
	--    - Summarize above to Item_no & Dates and represent measures in lots
	--
	/***************************************************************************/

	Set NoCount On

	Truncate table [dbo].[Fact_ProductionYield]

	-- Get jobs finished jobs and it correspond prod receives (in lots)
	Select
		JH.[Job_No],
		JH.[Item_No],
		Max(PH.[Tran_Date]) as Date,
		Cast(Sum(PD.[Qty_Finished] / JH.[Prod_Lot_Size]) as decimal(20,6)) as Product_Lots
	Into #Jobs
	From
		[PRJOBH] JH
		Inner Join [PRCOMH] PH On JH.[Job_No] = PH.[Job_No]
		Inner Join [PRCOMD] PD On PH.[Ref_No] = PD.[Ref_No] and JH.[Item_No] = PD.[Item_No]
		Inner Join [dbo].[Dim_Item] DI On JH.[Item_No] = DI.[Item_No]
	Where			
		JH.[Posted]='Y' and		
		JH.[Finished] = 'Y' and
		PH.[Posted]='Y'
	Group By
		JH.[Job_No],
		JH.[Item_No],
		JH.[Prod_Lot_Size]
	Order By
		JH.[Job_No]

	-- Insert Into fact table
	Insert 
		[dbo].[Fact_ProductionYield] With(TABLOCK)
	-- Summarize fact Into [Item_No] & [Date]s
	Select
		[Item_No],
		[Date] as [Dates],
		Sum([Product_Lots]) as [Product_Lots],
		Sum([Material_Lots]) as [Material_Lots]
	From
		(
		-- Get Material Kit Issues (in lots)
		Select
			J.[Item_No],
			J.[Date],
			J.[Product_Lots],
			Sum(IsNull(I.[Lots_Issued],0)) as [Material_Lots]
		From
			#jobs J Inner Join [ICMOVH] I On I.[Job_No] = J.[Job_No]
		Where
			I.[Posted] = 'Y' and		
			I.tran_type = 'MTIS'
		Group By
			J.[Item_No],
			J.[Date],
			J.[Product_Lots]
		) Temp_Table
	Group By
		[Item_No],
		[Date]

	-- Drop temp table
	Drop Table #jobs

GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_ProductsMaster
As

	/************************************************************/
	--
	-- Create dimension for Produced Finished Goods and Sub-assemblies
	--
	-- Logic :
	--    - Get all items produced associated according to BOM
	--    - Get all items that not a child of a BOM as 'Finished Goods'
	--    - Get the rest a 'Sub-assemblies'
	--
	/************************************************************/
    
	Set NoCount On

	Truncate Table [dbo].[Dim_Products]

	Insert
		[dbo].[Dim_Products] With(TABLOCK)
	Select Distinct
		P.[Part_Item_No] as Item_No,
		'Sub-assemblies' as Category
	From
		[PRSBOM] B
		Inner Join [PRPART] P On B.[Assm_Item_No] = P.[Part_Item_No]
	Where
		B.[Assm_Item_No] Not In (Select [Item_No] from [dbo].[Dim_Products])

	Insert
		[dbo].[Dim_Products] With(TABLOCK)
	Select Distinct
		[Assm_Item_No],
		'Finished Goods' as Category
	From
		[PRSBOM]
	Where
		[Assm_Item_No] Not In (Select Item_No From [dbo].[Dim_Products])
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_ProfitabilityGP
As

	Set NoCount On

	/***********************************************/
	/* Fact Table in Profitability Gross Profit */
	/***********************************************/

	Truncate Table [dbo].[Fact_ProfitabilityGP]

	Declare @Sales_Start varchar(50)
	Declare @Sales_End varchar(50)
	Declare @COGS_Start varchar(50)
	Declare @COGS_End varchar(50)

	Select @COGS_Start = [Parameter_Value] From [dbo].[Dim_Parameter] Where [Parameter_Name]='COGS A/C Start'
	Select @COGS_End = [Parameter_Value] From [dbo].[Dim_Parameter] Where [Parameter_Name]='COGS A/C End'
	Select @Sales_Start = [Parameter_Value] From [dbo].[Dim_Parameter] Where [Parameter_Name]='Sales A/C Start'
	Select @Sales_End = [Parameter_Value] From [dbo].[Dim_Parameter] Where [Parameter_Name]='Sales A/C End'

	Insert 
		[dbo].[Fact_ProfitabilityGP] With(TABLOCK)
	Select
		[Start_Date] as Period_Date,
		Sum(Case When L.[Acct_No] between @Sales_Start and @Sales_End
			then (IsNull(L.[Total_Credit],0) - IsNull(D.[Ledger_Credit],0) - IsNull(L.[Total_Debit],0) + IsNull(D.[Ledger_Debit],0))
			Else  0 end) as Sales_Balance,
		Sum(Case When L.[Acct_No] between @COGS_Start and @COGS_End
			then (IsNull(L.[Total_Debit],0) - IsNull(D.[Ledger_Debit],0) - IsNull(L.[Total_Credit],0) + IsNull(D.[Ledger_Credit],0))
			Else  0 end) as COGS_Balance
	From
		[GLLEDG] L
		Left Outer Join [GBPERD] P On L.[Period] = P.[Period]
		Left Outer Join [GLVOUD] D On L.[Period] = D.[Period] and L.[Acct_No] = D.[Acct_No]
	Where
		D.[Voucher_Type] ='CLOSE' And
		(L.[Acct_No] between @Sales_Start and @Sales_End or L.[Acct_No] between @COGS_Start and @COGS_End)
	Group By
		[Start_Date]
	Order By
		[Start_Date]

GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_ProfitabilityPM
As

	Set NoCount On

	/***********************************************/
	/* Fact Table in Profitability Profit Margin*/
	/***********************************************/

	Truncate Table [dbo].[Fact_ProfitabilityPM]

	Insert 
		[dbo].[Fact_ProfitabilityPM] With(TABLOCK)
	Select
		H.[Order_Date], D.[Item_No], H.[Customer_No], H.[Salesman], H.[Pay_Terms], (Sum((D.[Price_Amt] - IsNull(D.[Ldisc_Amt],0)) - I.[Std_Cost] * D.[Qty]) / Sum(D.[Price_Amt])) as ProfitMargin
	From
		[SLORDH] H
		Inner Join [SLORDD] D On H.[Order_No] = D.[Order_No]
		Inner Join [GBITEM] I On D.[Item_No] = I.[Item_No]
		Inner Join [dbo].[Dim_Item] DI On I.[Item_No] = DI.[Item_No]
	Where
		IsNull(D.[Price_Amt],0) > 0 and 
		I.[Std_Cost] is not null and
		D.[Qty] is not null
	Group By
		H.[Order_Date], D.[Item_No], H.[Customer_No], H.[Salesman], H.[Pay_Terms]
	Order By
		H.[Order_Date], D.[Item_No], H.[Customer_No]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_PurchasePartsReliability
As

	Set NoCount On

	/**************************************************/
	/* Fact Table in Purchase Parts Reliability */
	/*************************************************/

	Truncate table [dbo].[Fact_PurchasePartsReliability]

	Select
		A.[Order_No], A.[Line_No], A.[Sched_Date], Sum(IsNull(B.[Qty],0)) as qty
	Into #temp
	From
		[PUORDT] A
		Inner Join [PUORDT] B On A.[Order_No] = B.[Order_No] and A.[Line_No] = B.[Line_No]
	Where
		A.Posted = 'Y' and 
		B.Posted = 'Y' and
		A.[Sched_Date] >= B.[Sched_Date]
	Group By
		A.[Order_No], A.[Line_No], A.[Sched_Date]
	Order By
		A.[Order_No], A.[Line_No], A.[Sched_Date]

	Select
		T.[Order_No],
		T.[Line_No],
		T.[Sched_Date],
		Max(Case When [Received_Date] <=T.[Sched_Date] then [Received_Date] Else 0 end) as [Received_Date],
		Max(IsNull(T.[Qty],0)) as Sched_Qty,
		Sum(Case When [Received_Date] <= T.[Sched_Date] then IsNull(D.[Qty_Received],0) Else 0 end) as Qty_Received
	Into #source
	From
		[#temp] T		
		Inner Join [PUGRND] D On D.[Order_No] = T.[Order_No] and D.[Line_No] = T.[Line_No]
	Where
		D.Posted = 'Y'
	Group By
		T.[Order_No], T.[Line_No], T.[Sched_Date]
	Order By
		T.[Order_No], T.[Line_No], T.[Sched_Date]

	Insert
		[dbo].[Fact_PurchasePartsReliability] With(TABLOCK)
	Select
		S.[Sched_Date],
		D.[Item_No],
		H.[Vendor_No],
		H.[Buyer],
		Count(S.[Sched_Date]) as NumReceipt,
		Sum(Case When S.[Received_Date] is not null and IsNull(S.[Qty_Received], 0) >= IsNull(S.Sched_Qty, 0) then 1 Else 0 end) as NumOnTimeReceipt
	From
		[#source] S
		Inner Join [PUGRND] D On S.[Order_No] = D.[Order_No] and S.[Line_No] = D.[Line_No] 		
		Inner Join [PUORDH] H On S.[Order_No] = H.[Order_No]		
	Where
		H.[Posted] = 'Y' and
		D.[Posted] = 'Y'
	Group By
		S.[Sched_Date], D.[Item_No], H.[Vendor_No], buyer
	Order By
		S.[Sched_Date], D.[Item_No], H.[Vendor_No], buyer

	Drop Table #temp, #source

GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_PurchasePriceVariance
As

	/************************************************/
	--
	-- Fact Table in Purchase Price Variance
	--
	-- Logic :
	--    Get Purchase Price From Purchase
	--    Get Standard Cost From Item Master
	--
	/***********************************************/
	-- Clear Fact Table
	Truncate Table [dbo].[Fact_PurchasePriceVariance]

	-- Insert Into fact table
	Insert
		[dbo].[Fact_PurchasePriceVariance] With(TABLOCK)
	-- Get P.O. Price and Standard Cost
	Select
		H.[Order_Date] as Aates,
		H.[Buyer],
		D.[Item_No],
		Cast(
			(IsNull(D.[Price_Amt],0) - IsNull(D.[Ldisc_Amt],0))
			/ IsNull(D.[Qty],0) / IsNull(D.Lot_Size,0) as decimal(20,4)
			) as Purchase_Price,
		IsNull(I.Std_Cost,0) as Standard_Cost
	From
		[PUORDH] H
		Inner Join [PUORDD] D On D.[Order_No] = H.[Order_No]
		Inner Join [GBITEM] I On D.[Item_No] = I.[Item_No]
		Inner Join [dbo].[Dim_Item] DI On I.[Item_No] = DI.[Item_No] 
	Where
		H.[Posted] = 'Y' and
		IsNull(D.[Qty],0) > 0 and
		IsNull(D.[Price_Amt],0) > 0		
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_SalesOrderOnHand
As

	Set NoCount On

	/*********************************************/
	/* Fact Table in Sales Order On Hand  */
	/*********************************************/

	Truncate Table [dbo].[Fact_SalesOrderOnHand]

	Insert
		[dbo].[Fact_SalesOrderOnHand] With(TABLOCK)
	Select
		Sum((IsNull(D.[Qty],0) - IsNull(D.[Qty_Shipped],0)) * ((IsNull(D.Price_Amt,0) - IsNull(D.[Ldisc_Amt],0)) / D.[Qty])) as OpenSaleAmount,
		H.[Customer_No],
		D.[Item_No]
	From
		[SLORDH] H
		Inner Join [SLORDD] D On H.[Order_No] = D.[Order_No]
		Inner Join [dbo].[Dim_Item] DI On D.[Item_No] = DI.[Item_No]
		Inner Join [dbo].[Dim_Customer] DC On H.[Customer_No] = DC.[Customer_No]
	Where
		H.[Posted] = 'Y' and
		IsNull(D.[Qty],0) > 0 and
		IsNull(D.[Qty],0) > IsNull(D.[Qty_Shipped],0) and
		D.[Price_Amt] is not null
	Group By
		H.[Customer_No], D.[Item_No]

GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_SalesToNetWorkingCapital
As

	/************************************************/
	--
	-- Fact Table in Sales to Net Working Capital
	--
	-- Logic :
	--   Get Sales From ledger
	--   Get Working Capital
	--
	/***********************************************/

	Declare @sales_fr char(8)
	Declare @sales_to char(8)
	Declare @cur_asset_fr char(8)
	Declare @cur_asset_to char(8)
	Declare @cur_liab_fr char(8)
	Declare @cur_liab_to char(8)

	-- Clear Fact Table
	Truncate Table [dbo].[Fact_SalesToNetWorkingCapital]

	-- Get Sales Accounts
	Select @sales_fr = [Parameter_Value] From [dbo].[Dim_Parameter]
		Where [Parameter_Name] ='Sales A/C Start'
	Select @sales_to = [Parameter_Value] From [dbo].[Dim_Parameter]
		Where [Parameter_Name] ='Sales A/C End'

	-- Get Current Assets Accounts
	Select @cur_asset_fr = [Parameter_Value] From [dbo].[Dim_Parameter]
		Where [Parameter_Name] ='Current Asset A/C Start'
	Select @cur_asset_to = [Parameter_Value] From [dbo].[Dim_Parameter]
		Where [Parameter_Name] ='Current Asset A/C End'

	-- Get Current Liabilities Accounts
	Select @cur_liab_fr = [Parameter_Value] From [dbo].[Dim_Parameter]
		Where [Parameter_Name] ='Current Liabilities A/C Start'
	Select @cur_liab_to = [Parameter_Value] From [dbo].[Dim_Parameter]
		Where [Parameter_Name] ='Current Liabilities A/C End'

	-- Create Temp Table
	Create table #temp (
		period			nvarchar(7),
		sales			decimal(20,4),
		working_capital	decimal(20,4))

	-- Get Sales Amount
	Insert Into
		#temp
	Select
		L.[Period],
		Sum(
			- IsNull(L.[Total_Debit],0)
			+ IsNull(L.[Total_Credit],0)
			+ IsNull(D.[Ledger_Debit],0)
			- IsNull(D.[Ledger_Credit],0)
		) as Sales_Amt,
		0 as Placeholder
	From
		 [GLLEDG] L
		 Left outer join [GLVOUD] D On L.[Period] = D.[Period] and L.[Acct_No] = D.[Acct_No]
	Where
		D.[Voucher_Type] = 'CLOSE' and
		L.[Acct_No] between @sales_fr and @sales_to
	Group By
		L.[Period]

	-- Get Net Working Capital
	Insert Into
		#temp
	Select
		L.[Period],
		0 as Placeholder,
		Sum(
		Case L.[Bal_End_Sign]
			   When 'Credit' then
					IsNull(-L.[Bal_End],0)
			   Else 
					IsNull(L.[Bal_End],0)
			   end
		)  as Working_Capital
	From
		[GLLEDG] L
	Where
		L.[Acct_No] between @cur_asset_fr and @cur_asset_to or
		L.[Acct_No] between @cur_liab_fr and @cur_liab_to
	Group By
		L.[Period]

	-- Consolidate and Insert Into Fact table
	Insert 
		[dbo].[Fact_SalesToNetWorkingCapital] With(TABLOCK)
	Select
		P.[Start_Date],
		Sum(T.[Sales]) as Sales_Amt,
		Sum(T.[Working_Capital]) as Working_Capital
	From
		[#temp] T
		Inner join [GBPERD] P On T.[Period] = P.[Period]
	Group By
		P.[Start_Date]

	Drop Table #temp

GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_SalesmanMaster
As
	Set NoCount On

	-- UPDATE
	UPDATE
		[dbo].[Dim_Salesman] With(TABLOCK)
	SET
		[Salesman_Name] = S.[Salesman_Name]
	From
		[dbo].[Dim_Salesman] E
		Inner Join [SLSMAN] S On S.[Salesman] = E.[Salesman]
	Where
		E.[Salesman_Name] != S.[Salesman_Name]

	--INSERT new record
	INSERT
		[dbo].[Dim_Salesman] With(TABLOCK)
	Select
		[Salesman], [Salesman_Name]
	From
		[SLSMAN]
	Where
		[Salesman] Not In (Select [Salesman] from [dbo].[Dim_Salesman])
	Order By
		[Salesman]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_ShipmentValue
As

	Set NoCount On

	/**************************************/
	/* Fact Table in Shipment Value */
	/**************************************/

	Truncate Table [dbo].[Fact_ShipmentValue]

	Insert
		[dbo].[Fact_ShipmentValue] With(TABLOCK)
	Select
		D.[Shipment_Date],
		D.[Customer_No],
		H.[Salesman],
		D.[Item_No],
		IsNull(D.[Anlys3], ''),
		Sum([Price_Amt] - IsNull(D.[Ldisc_Amt],0)) as ShipmentValue
	From
		[SLORDH] H
		Inner Join [SLSHPD] D On H.[Order_No] = D.[Order_No]
		Inner Join [dbo].[Dim_Customer] DC On DC.[Customer_No] = D.[Customer_No] 
		Inner Join [dbo].[Dim_Item] DI On DI.[Item_No] = D.[Item_No]
	Where
		H.[Posted] = 'Y' and
		D.[Posted] = 'Y' and
		D.[Price_Amt] is not null
	Group By
		D.[Shipment_Date], D.[Customer_No], H.[Salesman], D.[Item_No], D.[Anlys3]
	Order By
		D.[Shipment_Date], D.[Customer_No], H.[Salesman], D.[Item_No]

GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_VendorMaster
As

	Set NoCount On

	-- UPDATE
	UPDATE
		[dbo].[Dim_Vendor] With(TABLOCK)
	SET
		[Vendor_Name] = V.[Vendor_Name],
		[Vendor_Group] = V.[Vendor_Group],
		[VendGroup_Description] = G.[Description]
	From
		[dbo].[Dim_Vendor] E
		Inner Join [GBVEND] V On V.[Vendor_No] = E.[Vendor_No]
		Inner Join [GBVGRP] G On V.[Vendor_Group] = G.[Vendor_Group]
	Where
		E.[Vendor_Name] != V.[Vendor_Name] Or
		E.[Vendor_Group] != V.[Vendor_Group] Or
		E.[VendGroup_Description] != G.[Description]			

	--INSERT new record
	INSERT
		[dbo].[Dim_Vendor] With(TABLOCK)
	Select
		V.[Vendor_No], V.[Vendor_Name], V.[Vendor_Group], G.[Description]
	From
		[GBVEND] V
		Inner Join [GBVGRP] G On V.[Vendor_Group] = G.[Vendor_Group]
	Where
		V.[Vendor_No] Not In (Select [Vendor_No] from [dbo].[Dim_Vendor])
	Order By
		V.[Vendor_No]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_WorkCentreMaster
As

	Set NoCount On

	-- UPDATE
	UPDATE
		[dbo].[Dim_WorkCentre] With(TABLOCK)
	SET
		[Description] = W.[Description]
	From
		[dbo].[Dim_WorkCentre] E
		Inner Join [GBWCTR] W On E.[Work_Centre] = W.[Work_Centre]
	Where
		E.[Description] != W.[Description] 

	--INSERT new record
	INSERT
		[dbo].[Dim_WorkCentre] With(TABLOCK)
	Select
		[Work_Centre], [Description]
	From
		[GBWCTR]
	Where
		[Work_Centre] Not In (Select [Work_Centre] from [dbo].[Dim_WorkCentre])
	Order By
		[Work_Centre]

GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO


SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_QuotationHitRate
As

	Set NoCount On

	Truncate Table [dbo].[Fact_QuotationHitRate]

	Select Distinct
		QD.[Ref_No], QD.[Item_No], QH.[Issue_Date], QH.[Customer_No], QH.[Salesman], IsNull(QD.[Net_Item_Amt],0) as Net_Item_Amt,
		IsOrder = 
		Case When SH.[Quo_Ref_No] Is Null then 0
		Else  
			Case When SD.[Item_No] Is Null then 0
			Else  1 end
		end
	Into
		#QuotationSalesOrder
	From
		[SLQUOD] QD
		Inner Join [SLQUOH] QH On QH.[Ref_No] = QD.[Ref_No]
		LEFT JOIN [SLORDH] SH On SH.[Quo_Ref_No] = QH.[Ref_No]
		LEFT JOIN [SLORDD] SD On SD.[Order_No] = SH.[Order_No] AND SD.[Item_No] = QD.[Item_No]
	Where
		SH.[Posted] = 'Y'

	Select
		[Ref_No], QSO.[Item_No], [Issue_date], [Customer_No], [Salesman], Sum(IsNull(Net_Item_Amt,0)) AS 'Net_Item_Amt', IsOrder 
	Into
		#QuotationSalesOrderGROUP
	From
		#QuotationSalesOrder QSO
		LEFT JOIN [dbo].[Dim_Item] DI On DI.[Item_No] = QSO.[Item_No]
	Where
		DI.[Item_No] is NULL
	Group By
		[Ref_No], QSO.[Item_No], Issue_date, [Customer_No], [Salesman], [IsOrder]

	Insert
		[dbo].[Fact_QuotationHitRate] With(TABLOCK)
	Select 
		[Ref_No], [Item_No], [Issue_Date], [Customer_No], [Salesman], [Net_Item_Amt], [IsOrder]
	From
		#QuotationSalesOrderGROUP
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_AccountMaster
As

	Set NoCount On

	-- UPDATE
	UPDATE
		[dbo].[Dim_Account] With(TABLOCK)
	SET
		[Acct_Name] = A.[Acct_Name],
		[Type] = Case When A.[Type_BS] = 'Y' then 'Balance Sheet' When A.[Type_PL] = 'Y' then 'Profit and Loss' else '' end
	From
		[dbo].[Dim_Account] E
		Inner Join [GBACCT] A On A.[Acct_No] = E.[Acct_No]
	Where
		E.[Acct_Name] != A.[Acct_Name] Or
		E.[Type] != Case When A.[Type_BS] = 'Y' then 'Balance Sheet' When A.[Type_PL] = 'Y' then 'Profit and Loss' else '' end

	--INSERT new record
	INSERT
		[dbo].[Dim_Account] With(TABLOCK)
	Select
		[Acct_No],
		[Acct_Name],
		Case When [Type_BS] = 'Y' then 'Balance Sheet' When [Type_PL] = 'Y' then 'Profit and Loss' else '' end as Type
	From
		[GBACCT]
	Where
		[Acct_No] Not In (Select [Acct_No] from [dbo].[Dim_Account])
	Order By
		[Acct_No]
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO

Create Procedure sp_BI_AccountSummary
As

	Set NoCount On

	Truncate Table [dbo].[Fact_AccountSummary]

	--INSERT new record
	INSERT
		[dbo].[Fact_AccountSummary] With(TABLOCK)
	Select
		H.[Voucher_Date],
		D.[Acct_No],
		Case
			When D.[Sign] = 'Debit' then
				D.[Ledger_Amt]
			Else
				D.[Ledger_Amt] * -1
		End as Amount,
		IsNull(D.[Anlys3], ''),
		IsNull(D.[Anlys4], ''),
		IsNull(D.[Anlys5], ''),
		IsNull(D.[Anlys6], ''),
		IsNull(D.[Anlys15], ''),
		IsNull(D.[Anlys16], ''),
		IsNull(D.[Anlys17], ''),
		IsNull(D.[Anlys18], ''),
		IsNull(D.[Anlys19], ''),
		IsNull(D.[Anlys20], '')			
	From
		[GLVOUH] H
		Inner Join [GLVOUD] D On H.[Voucher_No] = D.[Voucher_No] And H.[Voucher_Type] = D.[Voucher_Type]
		Inner Join [dbo].[Dim_Account] A On D.[Acct_No] = A.[Acct_No]		
		Inner Join [dbo].[Dim_Fiscal] F On H.[Voucher_Date] = F.[Dates]
	Where
		H.[Posted] = 'Y' and
		H.[Voucher_Type] != 'CLOSE' and
		IsNull(D.[Ledger_Amt], 0) != 0
	Order By
		H.[Voucher_Date], D.[Acct_No]

	Update
		[dbo].[Fact_AccountSummary] With(TABLOCK)
	Set
		[Amount] = IsNull([Amount], 0) * -1
	Where
		IsNull([Amount], 0) < 0
GO

SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
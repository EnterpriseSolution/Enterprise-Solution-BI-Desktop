/*
SELECT   ROUTINE_SCHEMA,   ROUTINE_NAME FROM INFORMATION_SCHEMA.ROUTINES
WHERE ROUTINE_TYPE = 'PROCEDURE'


DECLARE @table_schema NVARCHAR(20)
DECLARE @table_name NVARCHAR(200)

DECLARE MY_CURSOR CURSOR  
LOCAL STATIC READ_ONLY FORWARD_ONLY
FOR  SELECT   ROUTINE_SCHEMA,ROUTINE_NAME FROM INFORMATION_SCHEMA.ROUTINES WHERE ROUTINE_TYPE = 'PROCEDURE'

OPEN MY_CURSOR
FETCH NEXT FROM MY_CURSOR INTO @table_schema,@table_name
WHILE @@FETCH_STATUS = 0
BEGIN    
   PRINT 'EXEC ' +  @table_schema +'.' +  @table_name
   FETCH NEXT FROM MY_CURSOR INTO @table_schema,@table_name
END
CLOSE MY_CURSOR
DEALLOCATE MY_CURSOR

*/

EXEC dbo.sp_BI_BuyerMaster
EXEC dbo.sp_BI_CalendarMaster
EXEC dbo.sp_BI_CustomerMaster
EXEC dbo.sp_BI_DaysCompletionEarlyAndLate
EXEC dbo.sp_BI_DaysDebtors
EXEC dbo.sp_BI_DaysInInventory
EXEC dbo.sp_BI_DaysReceiptEarlyAndLate
EXEC dbo.sp_BI_DaysShipmentEarlyAndLate
EXEC dbo.sp_BI_DeliveryInFull
EXEC dbo.sp_BI_FiscalMaster
EXEC dbo.sp_BI_InventoryTurns
EXEC dbo.sp_BI_ItemMaster
EXEC dbo.sp_BI_JobCategoryMaster
EXEC dbo.sp_BI_NetAccountsReceivable
EXEC dbo.sp_BI_OperationMaster
EXEC dbo.sp_BI_OrderAvailability
EXEC dbo.sp_BI_OrderChangeFrequency
EXEC dbo.sp_BI_OrderLeadTime
EXEC dbo.sp_BI_OrderReliability
EXEC dbo.sp_BI_PayTermsMaster
EXEC dbo.sp_BI_PlannerMaster
EXEC dbo.sp_BI_ProductionEfficiency
EXEC dbo.sp_BI_ProductionReliability
EXEC dbo.sp_BI_ProductionYield
EXEC dbo.sp_BI_ProductsMaster
EXEC dbo.sp_BI_ProfitabilityGP
EXEC dbo.sp_BI_ProfitabilityPM
EXEC dbo.sp_BI_PurchasePartsReliability
EXEC dbo.sp_BI_PurchasePriceVariance
EXEC dbo.sp_BI_SalesOrderOnHand
EXEC dbo.sp_BI_SalesToNetWorkingCapital
EXEC dbo.sp_BI_SalesmanMaster
EXEC dbo.sp_BI_ShipmentValue
EXEC dbo.sp_BI_VendorMaster
EXEC dbo.sp_BI_WorkCentreMaster
EXEC dbo.sp_BI_QuotationHitRate
EXEC dbo.sp_BI_AccountMaster
EXEC dbo.sp_BI_AccountSummary
EXEC dbo.sp_BI_AnalysisCodeMaster


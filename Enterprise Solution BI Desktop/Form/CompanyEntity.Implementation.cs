using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnterpriseSolutionBIDesktop
{
    public partial class CompanyEntity
    {
        public bool FIFO { get; set; }
        public bool Lot { get; set; }
        public bool Serial { get; set; }
        public bool LotforLot { get; set; }
        public bool OrderMultipleLotforLot { get; set; }
        public bool PeriodicRequirements { get; set; }
        public bool FixedQtyPerPeriod { get; set; }
        public bool ReorderPoint { get; set; }
        public bool StandardStockedItemItem { get; set; }
        public bool StandardAssortmentItem { get; set; }
        public bool ConfigurableAssortmentItem { get; set; }
        public bool NonStockedItem  { get; set; }
        public bool MoldMaster { get; set; }
        public bool MoldBOM { get; set; }
        public bool OperationsStandard { get; set; }
        public bool WorkCentreStandard { get; set; }
        public bool RoutingStandards { get; set; }
        public bool BlanketOrder { get; set; }
        public bool SalesOrderMRPExclude { get; set; }
        public bool PurchaseOrderMRPExclude { get; set; }
        public bool Workflow { get; set; }
        public bool CycleCount { get; set; }
        public bool AcceptableQualityLimit { get; set; }
        public bool PurchaseInspection { get; set; }
        public bool ProductionInspection { get; set; }
        public bool PriceCode { get; set; }
        public bool Quotation { get; set; }
        public bool StandardAssortmentSO { get; set; }
        public bool ConfigurableAssortmentSO { get; set; }

        public bool JobOrder { get; set; }
        public bool AssemblyType { get; set; }
        public bool JobOrderFromSO { get; set; }
        public bool JobOrderFromMRP { get; set; }
        public bool PurchaseOrderfromMRP { get; set; }
        public bool MaterialKitIssue { get; set; }
        public bool MaterialSparesIssue { get; set; }
        public bool MaterialsReturn { get; set; }
        public bool ProjectOrder { get; set; }
        public bool MRPRun { get; set; }
        public bool MPS { get; set; }
        public bool SalesReservation { get; set; }
        public bool JobReservation { get; set; }
        public bool AssortmentReservation { get; set; }
        public bool FinishedGoods { get; set; }
        public bool MaterialsTransfer { get; set; }
        public bool MaterialConsumption { get; set; }

        public bool Voucher { get; set; }
        public bool VendorInvoice { get; set; }
        public bool CustomerInvoice { get; set; }
        public bool BalanceSheetLayout { get; set; }
        public bool ProfitLossLayout { get; set; }
        public bool PurchaseDeposit { get; set; }
        public bool SalesDeposit { get; set; }
    }
}

using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Inventories
{
    public class Inventory
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public Inventory(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
            this.WarehouseJournals();

            this.WarehouseLedgers();
        }

        private void WarehouseJournals()
        {
            string queryString = " @LocationID int, @WarehouseID int, @FromDate DateTime, @ToDate DateTime " + "\r\n"; //Filter by @LocalWarehouseID to make this stored procedure run faster, but it may be removed without any effect the algorithm

            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       DECLARE     @LocalLocationID int, @LocalWarehouseID int , @LocalFromDate DateTime, @LocalToDate DateTime " + "\r\n";
            queryString = queryString + "       SET         @LocalLocationID = @LocationID      SET         @LocalWarehouseID = @WarehouseID " + "\r\n";
            queryString = queryString + "       SET         @LocalFromDate = @FromDate          SET         @LocalToDate = @ToDate " + "\r\n";

            queryString = queryString + "       IF         (@LocalLocationID > 0 AND @LocalWarehouseID > 0) " + "\r\n";
            queryString = queryString + "                   " + this.WarehouseJournalBUILD(true, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           IF         (@LocalLocationID > 0 AND @LocalWarehouseID <= 0) " + "\r\n";
            queryString = queryString + "                       " + this.WarehouseJournalBUILD(true, false) + "\r\n";
            queryString = queryString + "           ELSE " + "\r\n";
            queryString = queryString + "               IF         (@LocalLocationID <= 0 AND @LocalWarehouseID > 0) " + "\r\n";
            queryString = queryString + "                           " + this.WarehouseJournalBUILD(false, true) + "\r\n";
            queryString = queryString + "               ELSE " + "\r\n";
            queryString = queryString + "                           " + this.WarehouseJournalBUILD(false, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("WarehouseJournals", queryString);

        }


        private string WarehouseJournalBUILD(bool isLocationID, bool isWarehouseID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      WarehouseJournalDetails.LocationID, Locations.Name AS LocationName, WarehouseJournalDetails.WarehouseID, Warehouses.Name AS WarehouseName, WarehouseJournalDetails.BinLocationID, BinLocations.Code AS BinLocationCode, WarehouseJournalDetails.BatchEntryDate, " + "\r\n";
            queryString = queryString + "                   CommodityCategories.CommodityCategoryID, CommodityCategories.Name AS CommodityCategoryName, Commodities.CommodityID, Commodities.Code, Commodities.Name, Commodities.Unit, Commodities.PackageSize, ISNULL(Pallets.Code, ISNULL(Cartons.Code, ISNULL(Packs.Code, ''))) AS Barcode, CASE WHEN NOT WarehouseJournalDetails.PalletID IS NULL THEN N'Pallet' WHEN NOT WarehouseJournalDetails.CartonID IS NULL THEN N'Carton'  WHEN NOT WarehouseJournalDetails.PackID IS NULL THEN N'Pack' ELSE '' END AS BarcodeUnit, " + "\r\n";
            queryString = queryString + "                   WarehouseJournalDetails.GoodsReceiptDetailID, WarehouseJournalDetails.EntryDate, ISNULL('Production: ' + ' ' + Pickups.Reference, ISNULL('From: ' + ' ' + SourceWarehouses.Name + ', ' + GoodsIssues.VoucherCodes, ISNULL(WarehouseAdjustmentTypes.Name  + ' ' + WarehouseAdjustments.AdjustmentJobs, ''))) AS LineReferences, " + "\r\n";

            queryString = queryString + "                   WarehouseJournalDetails.QuantityBegin, WarehouseJournalDetails.QuantityReceiptPickup, WarehouseJournalDetails.QuantityReceiptPurchasing, WarehouseJournalDetails.QuantityReceiptTransfer, WarehouseJournalDetails.QuantityReceiptReturn, WarehouseJournalDetails.QuantityReceiptAdjustment, WarehouseJournalDetails.QuantityReceiptPickup + WarehouseJournalDetails.QuantityReceiptPurchasing + WarehouseJournalDetails.QuantityReceiptTransfer + WarehouseJournalDetails.QuantityReceiptReturn + WarehouseJournalDetails.QuantityReceiptAdjustment AS QuantityReceipt, " + "\r\n";
            queryString = queryString + "                   WarehouseJournalDetails.QuantityIssueSelling, WarehouseJournalDetails.QuantityIssueTransfer, WarehouseJournalDetails.QuantityIssueAdjustment, WarehouseJournalDetails.QuantityIssueSelling + WarehouseJournalDetails.QuantityIssueTransfer + WarehouseJournalDetails.QuantityIssueAdjustment AS QuantityIssue, " + "\r\n";
            queryString = queryString + "                   WarehouseJournalDetails.QuantityBegin + WarehouseJournalDetails.QuantityReceiptPickup + WarehouseJournalDetails.QuantityReceiptPurchasing + WarehouseJournalDetails.QuantityReceiptTransfer + WarehouseJournalDetails.QuantityReceiptReturn + WarehouseJournalDetails.QuantityReceiptAdjustment - WarehouseJournalDetails.QuantityIssueSelling - WarehouseJournalDetails.QuantityIssueTransfer - WarehouseJournalDetails.QuantityIssueAdjustment AS QuantityEnd, " + "\r\n";
            queryString = queryString + "                   WarehouseJournalDetails.QuantityOnPurchasing, WarehouseJournalDetails.QuantityOnPickup, WarehouseJournalDetails.QuantityOnTransit, " + "\r\n";
            queryString = queryString + "                   WarehouseJournalDetails.MovementMIN, WarehouseJournalDetails.MovementMAX, WarehouseJournalDetails.MovementAVG " + "\r\n";


            queryString = queryString + "       FROM       (" + "\r\n";

            //--BEGIN-INPUT-OUTPUT-END.END
            queryString = queryString + "                   SELECT  GoodsReceiptDetails.EntryDate, GoodsReceiptDetails.GoodsReceiptDetailID, GoodsReceiptDetails.CommodityID, GoodsReceiptDetails.BatchEntryDate, GoodsReceiptDetails.LocationID, GoodsReceiptDetails.WarehouseID, GoodsReceiptDetails.BinLocationID, GoodsReceiptDetails.PickupID, GoodsReceiptDetails.GoodsIssueID, GoodsReceiptDetails.WarehouseAdjustmentID, GoodsReceiptDetails.PackID, GoodsReceiptDetails.CartonID, GoodsReceiptDetails.PalletID, " + "\r\n";
            queryString = queryString + "                           GoodsReceiptDetailUnionMasters.QuantityBegin, GoodsReceiptDetailUnionMasters.QuantityReceiptPickup, GoodsReceiptDetailUnionMasters.QuantityReceiptPurchasing, GoodsReceiptDetailUnionMasters.QuantityReceiptTransfer, GoodsReceiptDetailUnionMasters.QuantityReceiptReturn, GoodsReceiptDetailUnionMasters.QuantityReceiptAdjustment, GoodsReceiptDetailUnionMasters.QuantityIssueSelling, GoodsReceiptDetailUnionMasters.QuantityIssueTransfer, GoodsReceiptDetailUnionMasters.QuantityIssueAdjustment, 0 AS QuantityOnPurchasing, 0 AS QuantityOnPickup, 0 AS QuantityOnTransit, GoodsReceiptDetailUnionMasters.MovementMIN, GoodsReceiptDetailUnionMasters.MovementMAX, GoodsReceiptDetailUnionMasters.MovementAVG " + "\r\n";


            queryString = queryString + "                   FROM   (" + "\r\n";
            queryString = queryString + "                           SELECT  GoodsReceiptDetailUnions.GoodsReceiptDetailID, " + "\r\n";
            queryString = queryString + "                                   SUM(QuantityBegin) AS QuantityBegin, SUM(QuantityReceiptPickup) AS QuantityReceiptPickup, SUM(QuantityReceiptPurchasing) AS QuantityReceiptPurchasing, SUM(QuantityReceiptTransfer) AS QuantityReceiptTransfer, SUM(QuantityReceiptReturn) AS QuantityReceiptReturn, SUM(QuantityReceiptAdjustment) AS QuantityReceiptAdjustment, " + "\r\n";
            queryString = queryString + "                                   SUM(QuantityIssueSelling) AS QuantityIssueSelling, SUM(QuantityIssueTransfer) AS QuantityIssueTransfer, SUM(QuantityIssueAdjustment) AS QuantityIssueAdjustment, " + "\r\n";
            queryString = queryString + "                                   MIN(MovementDate) AS MovementMIN, MAX(MovementDate) AS MovementMAX, SUM((QuantityIssueSelling + QuantityIssueTransfer + QuantityIssueAdjustment) * MovementDate) / SUM(QuantityIssueSelling + QuantityIssueTransfer + QuantityIssueAdjustment) AS MovementAVG " + "\r\n";
            queryString = queryString + "                           FROM    (" + "\r\n";


            //1.BEGINING
            //  BEGINING.GoodsReceipts
            queryString = queryString + "                                   SELECT      GoodsReceiptDetails.GoodsReceiptDetailID, ROUND(GoodsReceiptDetails.Quantity - GoodsReceiptDetails.QuantityIssue, " + (int)GlobalEnums.rndQuantity + ") AS QuantityBegin, 0 AS QuantityReceiptPickup, 0 AS QuantityReceiptPurchasing, 0 AS QuantityReceiptTransfer, 0 AS QuantityReceiptReturn, 0 AS QuantityReceiptAdjustment, 0 AS QuantityIssueSelling, 0 AS QuantityIssueTransfer, 0 AS QuantityIssueAdjustment, NULL AS MovementDate " + "\r\n";
            queryString = queryString + "                                   FROM        GoodsReceiptDetails " + "\r\n";
            queryString = queryString + "                                   WHERE       GoodsReceiptDetails.EntryDate < @LocalFromDate AND GoodsReceiptDetails.Quantity > GoodsReceiptDetails.QuantityIssue " + (isLocationID ? " AND GoodsReceiptDetails.LocationID = @LocalLocationID" : "") + (isWarehouseID ? " AND GoodsReceiptDetails.WarehouseID = @LocalWarehouseID" : "") + "\r\n";

            queryString = queryString + "                                   UNION ALL " + "\r\n";
            //  BEGINING.UNDO (CAC CAU SQL CHO GoodsIssues, WarehouseAdjustments LA HOAN TOAN GIONG NHAU. LUU Y T/H DAT BIET: WarehouseAdjustments.Quantity < 0)
            //  BEGINING.UNDO.GoodsIssues
            queryString = queryString + "                                   SELECT      GoodsReceiptDetails.GoodsReceiptDetailID, GoodsIssueDetails.Quantity AS QuantityBegin, 0 AS QuantityReceiptPickup, 0 AS QuantityReceiptPurchasing, 0 AS QuantityReceiptTransfer, 0 AS QuantityReceiptReturn, 0 AS QuantityReceiptAdjustment, 0 AS QuantityIssueSelling, 0 AS QuantityIssueTransfer, 0 AS QuantityIssueAdjustment, NULL AS MovementDate " + "\r\n";
            queryString = queryString + "                                   FROM        GoodsReceiptDetails INNER JOIN " + "\r\n";
            queryString = queryString + "                                               GoodsIssueDetails ON GoodsReceiptDetails.GoodsReceiptDetailID = GoodsIssueDetails.GoodsReceiptDetailID AND GoodsReceiptDetails.EntryDate < @LocalFromDate AND GoodsIssueDetails.EntryDate >= @LocalFromDate " + (isLocationID ? " AND GoodsReceiptDetails.LocationID = @LocalLocationID " : "") + (isWarehouseID ? " AND GoodsReceiptDetails.WarehouseID = @LocalWarehouseID" : "") + "\r\n";

            queryString = queryString + "                                   UNION ALL " + "\r\n";
            //  BEGINING.UNDO.WarehouseAdjustments
            queryString = queryString + "                                   SELECT      GoodsReceiptDetails.GoodsReceiptDetailID, -WarehouseAdjustmentDetails.Quantity AS QuantityBegin, 0 AS QuantityReceiptPickup, 0 AS QuantityReceiptPurchasing, 0 AS QuantityReceiptTransfer, 0 AS QuantityReceiptReturn, 0 AS QuantityReceiptAdjustment, 0 AS QuantityIssueSelling, 0 AS QuantityIssueTransfer, 0 AS QuantityIssueAdjustment, NULL AS MovementDate " + "\r\n";
            queryString = queryString + "                                   FROM        GoodsReceiptDetails INNER JOIN " + "\r\n";
            queryString = queryString + "                                               WarehouseAdjustmentDetails ON GoodsReceiptDetails.GoodsReceiptDetailID = WarehouseAdjustmentDetails.GoodsReceiptDetailID AND GoodsReceiptDetails.EntryDate < @LocalFromDate AND WarehouseAdjustmentDetails.EntryDate >= @LocalFromDate AND WarehouseAdjustmentDetails.Quantity < 0 " + (isLocationID ? " AND GoodsReceiptDetails.LocationID = @LocalLocationID " : "") + (isWarehouseID ? " AND GoodsReceiptDetails.WarehouseID = @LocalWarehouseID" : "") + "\r\n";



            //2.INTPUT
            queryString = queryString + "                                   UNION ALL " + "\r\n";
            queryString = queryString + "                                   SELECT      GoodsReceiptDetails.GoodsReceiptDetailID, 0 AS QuantityBegin, " + "\r\n";
            queryString = queryString + "                                               CASE WHEN GoodsReceiptDetails.GoodsReceiptTypeID = " + (int)GlobalEnums.GoodsReceiptTypeID.Pickup + " THEN GoodsReceiptDetails.Quantity ELSE 0 END AS QuantityReceiptPickup, " + "\r\n";
            queryString = queryString + "                                               CASE WHEN GoodsReceiptDetails.GoodsReceiptTypeID = " + (int)GlobalEnums.GoodsReceiptTypeID.PurchaseInvoice + " THEN GoodsReceiptDetails.Quantity ELSE 0 END AS QuantityReceiptPurchasing, " + "\r\n";
            queryString = queryString + "                                               CASE WHEN GoodsReceiptDetails.GoodsReceiptTypeID = " + (int)GlobalEnums.GoodsReceiptTypeID.GoodsIssueTransfer + " THEN GoodsReceiptDetails.Quantity ELSE 0 END AS QuantityReceiptTransfer, " + "\r\n";
            queryString = queryString + "                                               CASE WHEN GoodsReceiptDetails.GoodsReceiptTypeID = " + (int)GlobalEnums.GoodsReceiptTypeID.SalesReturn + " THEN GoodsReceiptDetails.Quantity ELSE 0 END AS QuantityReceiptReturn, " + "\r\n";
            queryString = queryString + "                                               CASE WHEN GoodsReceiptDetails.GoodsReceiptTypeID = " + (int)GlobalEnums.GoodsReceiptTypeID.WarehouseAdjustments + " THEN GoodsReceiptDetails.Quantity ELSE 0 END AS QuantityReceiptAdjustment, " + "\r\n";
            queryString = queryString + "                                               0 AS QuantityIssueSelling, 0 AS QuantityIssueTransfer, 0 AS QuantityIssueAdjustment, NULL AS MovementDate " + "\r\n";
            queryString = queryString + "                                   FROM        GoodsReceiptDetails " + "\r\n";
            queryString = queryString + "                                   WHERE       GoodsReceiptDetails.EntryDate >= @LocalFromDate AND GoodsReceiptDetails.EntryDate <= @LocalToDate " + (isLocationID ? " AND GoodsReceiptDetails.LocationID = @LocalLocationID " : "") + (isWarehouseID ? " AND GoodsReceiptDetails.WarehouseID = @LocalWarehouseID" : "") + "\r\n";



            //3.OUTPUT (CAC CAU SQL CHO GoodsIssues, WarehouseAdjustments LA HOAN TOAN GIONG NHAU. LUU Y T/H DAT BIET: WarehouseAdjustments.Quantity < 0)
            queryString = queryString + "                                   UNION ALL " + "\r\n";
            //GoodsIssueDetails + "\r\n";
            queryString = queryString + "                                   SELECT      GoodsIssueDetails.GoodsReceiptDetailID, 0 AS QuantityBegin, 0 AS QuantityReceiptPickup, 0 AS QuantityReceiptPurchasing, 0 AS QuantityReceiptTransfer, 0 AS QuantityReceiptReturn, 0 AS QuantityReceiptAdjustment, CASE WHEN DeliveryAdviceDetailID IS NULL THEN 0 ELSE GoodsIssueDetails.Quantity END AS QuantityIssueSelling, CASE WHEN TransferOrderDetailID IS NULL THEN 0 ELSE GoodsIssueDetails.Quantity END AS QuantityIssueTransfer, 0 AS QuantityIssueAdjustment, 0 AS MovementDate " + "\r\n"; //DATEDIFF(DAY, GoodsReceiptDetails.EntryDate, GoodsIssueDetails.EntryDate) AS MovementDate
            queryString = queryString + "                                   FROM        GoodsIssueDetails " + "\r\n";
            queryString = queryString + "                                   WHERE       GoodsIssueDetails.EntryDate >= @LocalFromDate AND GoodsIssueDetails.EntryDate <= @LocalToDate " + (isLocationID ? " AND GoodsIssueDetails.LocationID = @LocalLocationID " : "") + (isWarehouseID ? " AND GoodsIssueDetails.WarehouseID = @LocalWarehouseID" : "") + "\r\n";

            queryString = queryString + "                                   UNION ALL " + "\r\n";
            //WarehouseAdjustmentDetails
            queryString = queryString + "                                   SELECT      WarehouseAdjustmentDetails.GoodsReceiptDetailID, 0 AS QuantityBegin, 0 AS QuantityReceiptPickup, 0 AS QuantityReceiptPurchasing, 0 AS QuantityReceiptTransfer, 0 AS QuantityReceiptReturn, 0 AS QuantityReceiptAdjustment, 0 AS QuantityIssueSelling, 0 AS QuantityIssueTransfer, -WarehouseAdjustmentDetails.Quantity AS QuantityIssueAdjustment, 0 AS MovementDate " + "\r\n"; //DATEDIFF(DAY, GoodsReceiptDetails.EntryDate, WarehouseAdjustmentDetails.EntryDate) AS MovementDate
            queryString = queryString + "                                   FROM        WarehouseAdjustmentDetails " + "\r\n";
            queryString = queryString + "                                   WHERE       WarehouseAdjustmentDetails.EntryDate >= @LocalFromDate AND WarehouseAdjustmentDetails.EntryDate <= @LocalToDate AND WarehouseAdjustmentDetails.Quantity < 0 " + (isLocationID ? " AND WarehouseAdjustmentDetails.LocationID = @LocalLocationID " : "") + (isWarehouseID ? " AND WarehouseAdjustmentDetails.WarehouseID = @LocalWarehouseID" : "") + "\r\n";



            queryString = queryString + "                                   ) AS GoodsReceiptDetailUnions " + "\r\n";
            queryString = queryString + "                           GROUP BY GoodsReceiptDetailUnions.GoodsReceiptDetailID " + "\r\n";
            queryString = queryString + "                           ) AS GoodsReceiptDetailUnionMasters INNER JOIN " + "\r\n";
            queryString = queryString + "                           GoodsReceiptDetails ON GoodsReceiptDetailUnionMasters.GoodsReceiptDetailID = GoodsReceiptDetails.GoodsReceiptDetailID " + "\r\n";

            //--BEGIN-INPUT-OUTPUT-END.END

            queryString = queryString + "                   UNION ALL " + "\r\n";
            //--ON INPUT.BEGIN (CAC CAU SQL DUNG CHO EWHInputVoucherTypeID.EInvoice, EWHInputVoucherTypeID.EReturn, EWHInputVoucherTypeID.EWHTransfer, EWHInputVoucherTypeID.EWHAdjust, EWHInputVoucherTypeID.EWHAssemblyMaster, EWHInputVoucherTypeID.EWHAssemblyDetail LA HOAN TOAN GIONG NHAU)
            //EWHInputVoucherTypeID.EInvoice
            queryString = queryString + "                   SELECT  NULL AS EntryDate, NULL AS GoodsReceiptDetailID, PickupDetails.CommodityID, PickupDetails.BatchEntryDate, PickupDetails.LocationID, NULL AS WarehouseID, NULL AS BinLocationID, NULL AS PickupID, NULL AS GoodsIssueID, NULL AS WarehouseAdjustmentID, PickupDetails.PackID, PickupDetails.CartonID, PickupDetails.PalletID, " + "\r\n";
            queryString = queryString + "                           0 AS QuantityBegin, 0 AS QuantityReceiptPickup, 0 AS QuantityReceiptPurchasing, 0 AS QuantityReceiptTransfer, 0 AS QuantityReceiptReturn, 0 AS QuantityReceiptAdjustment, 0 AS QuantityIssueSelling, 0 AS QuantityIssueTransfer, 0 AS QuantityIssueAdjustment, 0 AS QuantityOnPurchasing, (PickupDetails.Quantity - PickupDetails.QuantityReceipt) AS QuantityOnPickup, 0 AS QuantityOnTransit, 0 AS MovementMIN, 0 AS MovementMAX, 0 AS MovementAVG " + "\r\n";
            queryString = queryString + "                   FROM    PickupDetails " + "\r\n";
            queryString = queryString + "                   WHERE   PickupDetails.EntryDate <= @LocalToDate AND PickupDetails.Quantity > PickupDetails.QuantityReceipt " + (isLocationID || isWarehouseID ? " AND PickupDetails.LocationID = @LocalLocationID" : "") + "\r\n";

            queryString = queryString + "                   UNION ALL " + "\r\n";

            queryString = queryString + "                   SELECT  NULL AS EntryDate, NULL AS GoodsReceiptDetailID, GoodsReceiptDetails.CommodityID, GoodsReceiptDetails.BatchEntryDate, GoodsReceiptDetails.LocationID, NULL AS WarehouseID, NULL AS BinLocationID, NULL AS PickupID, NULL AS GoodsIssueID, NULL AS WarehouseAdjustmentID, GoodsReceiptDetails.PackID, GoodsReceiptDetails.CartonID, GoodsReceiptDetails.PalletID, " + "\r\n";
            queryString = queryString + "                           0 AS QuantityBegin, 0 AS QuantityReceiptPickup, 0 AS QuantityReceiptPurchasing, 0 AS QuantityReceiptTransfer, 0 AS QuantityReceiptReturn, 0 AS QuantityReceiptAdjustment, 0 AS QuantityIssueSelling, 0 AS QuantityIssueTransfer, 0 AS QuantityIssueAdjustment, 0 AS QuantityOnPurchasing, GoodsReceiptDetails.Quantity AS QuantityOnPickup, 0 AS QuantityOnTransit, 0 AS MovementMIN, 0 AS MovementMAX, 0 AS MovementAVG " + "\r\n";
            queryString = queryString + "                   FROM    Pickups INNER JOIN " + "\r\n";
            queryString = queryString + "                           GoodsReceiptDetails ON Pickups.PickupID = GoodsReceiptDetails.PickupID AND Pickups.EntryDate <= @LocalToDate AND GoodsReceiptDetails.EntryDate > @LocalToDate " + (isLocationID || isWarehouseID ? " AND GoodsReceiptDetails.LocationID = @LocalLocationID" : "") + "\r\n";

            queryString = queryString + "                   UNION ALL " + "\r\n";
            //EWHInputVoucherTypeID.EWHTransfer
            queryString = queryString + "                   SELECT  NULL AS EntryDate, NULL AS GoodsReceiptDetailID, GoodsIssueTransferDetails.CommodityID, GoodsIssueTransferDetails.BatchEntryDate, GoodsIssueTransferDetails.LocationID, NULL AS WarehouseID, NULL AS BinLocationID, NULL AS PickupID, NULL AS GoodsIssueID, NULL AS WarehouseAdjustmentID, GoodsIssueTransferDetails.PackID, GoodsIssueTransferDetails.CartonID, GoodsIssueTransferDetails.PalletID, " + "\r\n";
            queryString = queryString + "                           0 AS QuantityBegin, 0 AS QuantityReceiptPickup, 0 AS QuantityReceiptPurchasing, 0 AS QuantityReceiptTransfer, 0 AS QuantityReceiptReturn, 0 AS QuantityReceiptAdjustment, 0 AS QuantityIssueSelling, 0 AS QuantityIssueTransfer, 0 AS QuantityIssueAdjustment, 0 AS QuantityOnPurchasing, 0 AS QuantityOnPickup, (GoodsIssueTransferDetails.Quantity - GoodsIssueTransferDetails.QuantityReceipt) AS QuantityOnTransit, 0 AS MovementMIN, 0 AS MovementMAX, 0 AS MovementAVG " + "\r\n";
            queryString = queryString + "                   FROM    GoodsIssues INNER JOIN " + "\r\n";
            queryString = queryString + "                           GoodsIssueTransferDetails ON GoodsIssues.GoodsIssueID = GoodsIssueTransferDetails.GoodsIssueID AND GoodsIssueTransferDetails.EntryDate <= @LocalToDate AND GoodsIssueTransferDetails.Quantity > GoodsIssueTransferDetails.QuantityReceipt " + (isLocationID || isWarehouseID ? " AND GoodsIssueTransferDetails.LocationID = @LocalLocationID" : "") + "\r\n";

            queryString = queryString + "                   UNION ALL " + "\r\n";

            queryString = queryString + "                   SELECT  NULL AS EntryDate, NULL AS GoodsReceiptDetailID, GoodsReceiptDetails.CommodityID, GoodsReceiptDetails.BatchEntryDate, GoodsReceiptDetails.LocationID, NULL AS WarehouseID, NULL AS BinLocationID, NULL AS PickupID, NULL AS GoodsIssueID, NULL AS WarehouseAdjustmentID, GoodsReceiptDetails.PackID, GoodsReceiptDetails.CartonID, GoodsReceiptDetails.PalletID, " + "\r\n";
            queryString = queryString + "                           0 AS QuantityBegin, 0 AS QuantityReceiptPickup, 0 AS QuantityReceiptPurchasing, 0 AS QuantityReceiptTransfer, 0 AS QuantityReceiptReturn, 0 AS QuantityReceiptAdjustment, 0 AS QuantityIssueSelling, 0 AS QuantityIssueTransfer, 0 AS QuantityIssueAdjustment, 0 AS QuantityOnPurchasing, 0 AS QuantityOnPickup, GoodsReceiptDetails.Quantity AS QuantityOnTransit, 0 AS MovementMIN, 0 AS MovementMAX, 0 AS MovementAVG " + "\r\n";
            queryString = queryString + "                   FROM    GoodsIssues INNER JOIN " + "\r\n";
            queryString = queryString + "                           GoodsReceiptDetails ON GoodsIssues.GoodsIssueID = GoodsReceiptDetails.GoodsIssueID AND GoodsIssues.EntryDate <= @LocalToDate AND GoodsReceiptDetails.EntryDate > @LocalToDate " + (isLocationID || isWarehouseID ? " AND GoodsReceiptDetails.LocationID = @LocalLocationID" : "") + "\r\n";
            //--ON INPUT.END

            queryString = queryString + "                   ) AS WarehouseJournalDetails " + "\r\n";

            queryString = queryString + "                   INNER JOIN Commodities ON WarehouseJournalDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN CommodityCategories ON Commodities.CommodityCategoryID = CommodityCategories.CommodityCategoryID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Locations ON WarehouseJournalDetails.LocationID = Locations.LocationID " + "\r\n";

            queryString = queryString + "                   LEFT JOIN Warehouses ON WarehouseJournalDetails.WarehouseID = Warehouses.WarehouseID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN BinLocations ON WarehouseJournalDetails.BinLocationID = BinLocations.BinLocationID " + "\r\n";

            queryString = queryString + "                   LEFT JOIN Pickups ON WarehouseJournalDetails.PickupID = Pickups.PickupID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN GoodsIssues ON WarehouseJournalDetails.GoodsIssueID = GoodsIssues.GoodsIssueID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Warehouses SourceWarehouses ON GoodsIssues.WarehouseID = SourceWarehouses.WarehouseID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN WarehouseAdjustments ON WarehouseJournalDetails.WarehouseAdjustmentID = WarehouseAdjustments.WarehouseAdjustmentID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN WarehouseAdjustmentTypes ON WarehouseAdjustments.WarehouseAdjustmentTypeID = WarehouseAdjustmentTypes.WarehouseAdjustmentTypeID " + "\r\n";

            queryString = queryString + "                   LEFT JOIN Packs ON WarehouseJournalDetails.PackID = Packs.PackID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Cartons ON WarehouseJournalDetails.CartonID = Cartons.CartonID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Pallets ON WarehouseJournalDetails.PalletID = Pallets.PalletID " + "\r\n";


            queryString = queryString + "    END " + "\r\n";

            return queryString;

        }



        private string BUILDHeader(bool localParameter, bool quantityVersusVolume)
        {
            string queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime, @LocationIDs varchar(3999), @WarehouseIDs varchar(3999), @CommodityCategoryIDs varchar(3999), @CommodityTypeIDs varchar(3999), @CommodityIDs varchar(3999), @GoodsIssueTypeIDs varchar(3999), @CustomerCategoryIDs varchar(3999), @CustomerIDs varchar(3999), @LocationReceiptIDs varchar(3999), @WarehouseReceiptIDs varchar(3999), @TeamIDs varchar(3999), @EmployeeIDs varchar(3999), @WarehouseAdjustmentTypeIDs varchar(3999) " + (quantityVersusVolume ? ", @DateVersusMonth int, @QuantityVersusVolume int, @SalesVersusPromotion int" : "") + "\r\n";

            //queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "       SET NOCOUNT ON; " + "\r\n";

            if (localParameter)
            {
                queryString = queryString + "       DECLARE     @LocalUserID Int, @LocalFromDate DateTime, @LocalToDate DateTime, @LocalLocationIDs varchar(3999), @LocalWarehouseIDs varchar(3999), @LocalCommodityCategoryIDs varchar(3999), @LocalCommodityTypeIDs varchar(3999), @LocalCommodityIDs varchar(3999), @LocalGoodsIssueTypeIDs varchar(3999), @LocalCustomerCategoryIDs varchar(3999), @LocalCustomerIDs varchar(3999), @LocalLocationReceiptIDs varchar(3999), @LocalWarehouseReceiptIDs varchar(3999), @LocalTeamIDs varchar(3999), @LocalEmployeeIDs varchar(3999), @LocalWarehouseAdjustmentTypeIDs varchar(3999) " + (quantityVersusVolume ? ", @LocalDateVersusMonth int, @LocalQuantityVersusVolume int, @LocalSalesVersusPromotion int" : "") + "\r\n";

                queryString = queryString + "       SET         @LocalUserID = @UserID                                              SET @LocalFromDate = @FromDate                          SET @LocalToDate = @ToDate " + "\r\n";
                queryString = queryString + "       SET         @LocalLocationIDs = @LocationIDs                                    SET @LocalWarehouseIDs = @WarehouseIDs                  " + "\r\n";
                queryString = queryString + "       SET         @LocalCommodityCategoryIDs = @CommodityCategoryIDs                  SET @LocalCommodityIDs = @CommodityIDs                  " + "\r\n";
                queryString = queryString + "       SET         @LocalCommodityTypeIDs = @CommodityTypeIDs                          SET @LocalGoodsIssueTypeIDs = @GoodsIssueTypeIDs " + "\r\n";
                queryString = queryString + "       SET         @LocalCustomerCategoryIDs = @CustomerCategoryIDs                    SET @LocalCustomerIDs = @CustomerIDs" + "\r\n";
                queryString = queryString + "       SET         @LocalLocationReceiptIDs = @LocationReceiptIDs                      SET @LocalWarehouseReceiptIDs = @WarehouseReceiptIDs " + "\r\n";
                queryString = queryString + "       SET         @LocalTeamIDs = @TeamIDs                                            SET @LocalEmployeeIDs = @EmployeeIDs " + "\r\n";
                queryString = queryString + "       SET         @LocalWarehouseAdjustmentTypeIDs = @WarehouseAdjustmentTypeIDs" + (quantityVersusVolume ? " SET @LocalDateVersusMonth = @DateVersusMonth   SET @LocalQuantityVersusVolume = @QuantityVersusVolume       SET @LocalSalesVersusPromotion = @SalesVersusPromotion" : "") + "\r\n";
            }

            return queryString;
        }

        private string BUILDParameter(bool localParameter)
        {
            return " @" + (localParameter ? "Local" : "") + "UserID, @" + (localParameter ? "Local" : "") + "FromDate, @" + (localParameter ? "Local" : "") + "ToDate, @" + (localParameter ? "Local" : "") + "LocationIDs, @" + (localParameter ? "Local" : "") + "WarehouseIDs, @" + (localParameter ? "Local" : "") + "CommodityCategoryIDs, @" + (localParameter ? "Local" : "") + "CommodityTypeIDs, @" + (localParameter ? "Local" : "") + "CommodityIDs, @" + (localParameter ? "Local" : "") + "GoodsIssueTypeIDs, @" + (localParameter ? "Local" : "") + "CustomerCategoryIDs, @" + (localParameter ? "Local" : "") + "CustomerIDs, @" + (localParameter ? "Local" : "") + "LocationReceiptIDs, @" + (localParameter ? "Local" : "") + "WarehouseReceiptIDs, @" + (localParameter ? "Local" : "") + "TeamIDs, @" + (localParameter ? "Local" : "") + "EmployeeIDs, @" + (localParameter ? "Local" : "") + "WarehouseAdjustmentTypeIDs ";
        }

        /// <summary>
        /// Group by Month: GROUP BY dateadd(month, datediff(month, 0, SomeDate),0)   <-- Recommended
        /// This technique will "round" your date to the first day of the month; thus, if you GROUP on those dates, you are grouping on months.  
        /// This is nice because it combines the year and month together into one column for easy sorting and comparing and joining, if necessary.  
        /// It also keeps your data as a true DATETIME value so that you can format it any way you'd like at your client.
        /// 
        /// Grouping by Other Time Periods
        /// Grouping on Years, Weeks or Quarters follows the same basic idea:  simply "round" your DateTime to the resolution that you need, and group on either the resulting DateTime value or by the number of units since the base date.  
        /// For example, to group by quarter, you can write:
        /// GROUP BY dateadd(quarter, datediff(quarter, 0, SomeDate),0)
        /// That returns the starting date of each quarter; for example, 10/12/2007 will return 9/1/2007.  To get the ending date of the quarter, you can use:
        /// dateadd(quarter, datediff(quarter, 0, SomeDate) + 1, 0) -1
        /// As with months, you could just group on the number of quarters since the "base date" as well:
        /// GROUP BY datediff(quarter,0,SomeDate)
        /// Overall, the exact same concepts apply.
        /// 
        /// Summary
        /// The method to choose for any situation ultimately depends on what you need, 
        /// but remember:  Keep it short and simple in T-SQL, and always do all of your formatting at your presentation layer where it belongs.
        /// </summary>

        private void WarehouseLedgers()
        {
            this.WarehouseLedger06();
            this.WarehouseLedger08();

            string queryString = this.BUILDHeader(false, false) + this.BUILDGoodsIssue() + "\r\n";
            this.totalSmartCodingEntities.CreateStoredProcedure("WHLS", queryString);


            queryString = this.BUILDHeader(true, true);
            queryString = queryString + "       DECLARE     @WarehouseLedgers TABLE (PrimaryID int NOT NULL, PrimaryDetailID int NOT NULL, EntryDate datetime NOT NULL, Reference nvarchar(10) NULL, LocationName nvarchar(50) NOT NULL, WarehouseName nvarchar(60) NOT NULL, CommodityID int NOT NULL, Code nvarchar(50) NOT NULL, Name nvarchar(200) NOT NULL, PackageSize nvarchar(60) NULL, CommodityCategoryName nvarchar(100) NOT NULL, CommodityTypeName nvarchar(100) NOT NULL, IsPromotion bit NOT NULL, Quantity decimal(18, 2) NOT NULL, LineVolume decimal(18, 2) NOT NULL, LineForeignCode nvarchar(50) NOT NULL, LineForeignName nvarchar(100) NOT NULL, LineReferences nvarchar(110) NULL, CustomerCategoryName nvarchar(100) NULL, TeamName nvarchar(100) NULL, SalespersonName nvarchar(50) NULL) " + "\r\n";
            queryString = queryString + "       INSERT INTO @WarehouseLedgers         EXEC WHLS " + this.BUILDParameter(true) + "\r\n";

            string queryMaster = "              SELECT      PrimaryID, PrimaryDetailID, EntryDate, CASE @LocalDateVersusMonth WHEN 0 THEN CONVERT(Date, EntryDate) ELSE DATEADD(Month, DateDiff(Month, 0, EntryDate), 0) END AS GroupDate, Reference, LocationName, WarehouseName, CommodityID, Code, Name, PackageSize, CommodityCategoryName, CommodityTypeName, IsPromotion, Quantity, LineVolume, CASE @LocalQuantityVersusVolume WHEN 0 THEN Quantity ELSE LineVolume END AS LineValue, LineForeignCode, LineForeignName, LineReferences, CustomerCategoryName, TeamName, SalespersonName " + "\r\n";
            queryMaster = queryMaster + "       FROM        @WarehouseLedgers " + "\r\n";

            queryString = queryString + "       IF         (@LocalSalesVersusPromotion IS NULL OR @LocalSalesVersusPromotion < 0) " + "\r\n";
            queryString = queryString + "                   " + queryMaster + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + queryMaster + "\r\n" + " WHERE IsPromotion = @LocalSalesVersusPromotion";

            this.totalSmartCodingEntities.CreateStoredProcedure("WarehouseLedgers", queryString);

        }

        private string BUILDGoodsIssue()
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@LocationIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.BUILDLocation(true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.BUILDLocation(false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string BUILDLocation(bool isLocationID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@WarehouseIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.BUILDWarehouse(isLocationID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.BUILDWarehouse(isLocationID, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string BUILDWarehouse(bool isLocationID, bool isWarehouseID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@CommodityCategoryIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.BUILDCommodityCategory(isLocationID, isWarehouseID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.BUILDCommodityCategory(isLocationID, isWarehouseID, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string BUILDCommodityCategory(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@CommodityIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.BUILDCommodity(isLocationID, isWarehouseID, isCommodityCategoryID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.BUILDCommodity(isLocationID, isWarehouseID, isCommodityCategoryID, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string BUILDCommodity(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@CommodityTypeIDs <> '') " + "\r\n";
            queryString = queryString + "                   EXEC WHL06" + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isCommodityCategoryID.ToString().Substring(0, 1) + isCommodityID.ToString().Substring(0, 1) + true.ToString().Substring(0, 1) + this.BUILDParameter(false) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   EXEC WHL06" + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isCommodityCategoryID.ToString().Substring(0, 1) + isCommodityID.ToString().Substring(0, 1) + false.ToString().Substring(0, 1) + this.BUILDParameter(false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }


        private void WarehouseLedger06()
        {
            bool[] boolArray = new bool[2] { true, false };
            foreach (bool isLocationID in boolArray)
            {
                foreach (bool isWarehouseID in boolArray)
                {
                    foreach (bool isCommodityCategoryID in boolArray)
                    {
                        foreach (bool isCommodityID in boolArray)
                        {
                            foreach (bool isCommodityTypeID in boolArray)
                            {
                                this.totalSmartCodingEntities.CreateStoredProcedure("WHL06" + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isCommodityCategoryID.ToString().Substring(0, 1) + isCommodityID.ToString().Substring(0, 1) + isCommodityTypeID.ToString().Substring(0, 1), this.BUILDHeader(false, false) + this.BUILDCommodityType(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID));
                            }
                        }
                    }
                }
            }
        }


        private string BUILDCommodityType(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID)
        {
            string queryString = "";

            //DeliveryAdvice        TransferOrder       WarehouseAdjustment
            //0	                    0	                1		(CASE 2) WarehouseAdjustments
            //0	                    1	                1		(CASE 3) CombineSelectedAlls
            //1	                    0	                1		(CASE 3) CombineSelectedAlls
            //1	                    1	                1		(CASE 1) ALL

            //0	                    0	                0		(CASE 1) ALL
            //1	                    0	                0		(CASE 5) SelectedGoodsIssues
            //0	                    1	                0		(CASE 5) SelectedGoodsIssues
            //1	                    1	                0		(CASE 4) GoodsIssues


            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF  (@GoodsIssueTypeIDs IS NULL OR @GoodsIssueTypeIDs = '' OR (@GoodsIssueTypeIDs LIKE '%" + (int)GlobalEnums.GoodsIssueTypeID.DeliveryAdvice + "%' AND @GoodsIssueTypeIDs LIKE '%" + (int)GlobalEnums.GoodsIssueTypeID.TransferOrder + "%' AND @GoodsIssueTypeIDs LIKE '%" + (int)GlobalEnums.GoodsIssueTypeID.WarehouseAdjustment + "%')) " + "\r\n";
            queryString = queryString + "               " + this.BUILDGoodsIssueType(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY.Alls) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";

            queryString = queryString + "               IF      (@GoodsIssueTypeIDs = '" + (int)GlobalEnums.GoodsIssueTypeID.WarehouseAdjustment + "') " + "\r\n";
            queryString = queryString + "                           " + this.BUILDGoodsIssueType(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY.WarehouseAdjustments) + "\r\n";
            queryString = queryString + "               ELSE " + "\r\n";
            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       IF  (@GoodsIssueTypeIDs LIKE '%" + (int)GlobalEnums.GoodsIssueTypeID.WarehouseAdjustment + "%') " + "\r\n";
            queryString = queryString + "                           " + this.BUILDGoodsIssueType(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY.CombineSelectedAlls) + "\r\n";
            queryString = queryString + "                       ELSE " + "\r\n";
            queryString = queryString + "                           BEGIN " + "\r\n";
            queryString = queryString + "                               IF  (@GoodsIssueTypeIDs LIKE '%" + (int)GlobalEnums.GoodsIssueTypeID.DeliveryAdvice + "%' AND @GoodsIssueTypeIDs LIKE '%" + (int)GlobalEnums.GoodsIssueTypeID.TransferOrder + "%') " + "\r\n";
            queryString = queryString + "                                   " + this.BUILDGoodsIssueType(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY.GoodsIssues) + "\r\n";
            queryString = queryString + "                               ELSE " + "\r\n";
            queryString = queryString + "                                   " + this.BUILDGoodsIssueType(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY.SelectedGoodsIssues) + "\r\n";
            queryString = queryString + "                           END " + "\r\n";

            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "           END " + "\r\n";
            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string BUILDGoodsIssueType(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY goodsIssueTypeID_REPORTONLY)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@CustomerCategoryIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.BUILDCustomerCategory(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, goodsIssueTypeID_REPORTONLY, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.BUILDCustomerCategory(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, goodsIssueTypeID_REPORTONLY, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string BUILDCustomerCategory(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY goodsIssueTypeID_REPORTONLY, bool isCustomerCategoryID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@LocationReceiptIDs <> '') " + "\r\n";
            queryString = queryString + "                   EXEC WHL08" + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isCommodityCategoryID.ToString().Substring(0, 1) + isCommodityID.ToString().Substring(0, 1) + isCommodityTypeID.ToString().Substring(0, 1) + goodsIssueTypeID_REPORTONLY.ToString().Substring(0, 1) + isCustomerCategoryID.ToString().Substring(0, 1) + true.ToString().Substring(0, 1) + this.BUILDParameter(false) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   EXEC WHL08" + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isCommodityCategoryID.ToString().Substring(0, 1) + isCommodityID.ToString().Substring(0, 1) + isCommodityTypeID.ToString().Substring(0, 1) + goodsIssueTypeID_REPORTONLY.ToString().Substring(0, 1) + isCustomerCategoryID.ToString().Substring(0, 1) + false.ToString().Substring(0, 1) + this.BUILDParameter(false) + "\r\n";
            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private void WarehouseLedger08()
        {
            bool[] boolArray = new bool[2] { true, false };
            foreach (bool isLocationID in boolArray)
            {
                foreach (bool isWarehouseID in boolArray)
                {
                    foreach (bool isCommodityCategoryID in boolArray)
                    {
                        foreach (bool isCommodityID in boolArray)
                        {
                            foreach (bool isCommodityTypeID in boolArray)
                            {
                                foreach (GlobalEnums.GoodsIssueTypeID_REPORTONLY goodsIssueTypeID_REPORTONLY in Enum.GetValues(typeof(GlobalEnums.GoodsIssueTypeID_REPORTONLY)))
                                {
                                    foreach (bool isCustomerCategoryID in boolArray)
                                    {
                                        foreach (bool isLocationReceiptID in boolArray)
                                        {
                                            this.totalSmartCodingEntities.CreateStoredProcedure("WHL08" + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isCommodityCategoryID.ToString().Substring(0, 1) + isCommodityID.ToString().Substring(0, 1) + isCommodityTypeID.ToString().Substring(0, 1) + goodsIssueTypeID_REPORTONLY.ToString().Substring(0, 1) + isCustomerCategoryID.ToString().Substring(0, 1) + isLocationReceiptID.ToString().Substring(0, 1), this.BUILDHeader(false, false) + this.BUILDLocationReceipt(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, goodsIssueTypeID_REPORTONLY, isCustomerCategoryID, isLocationReceiptID));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        private string BUILDLocationReceipt(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY goodsIssueTypeID_REPORTONLY, bool isCustomerCategoryID, bool isLocationReceiptID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@CustomerIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.BUILDCustomer(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, goodsIssueTypeID_REPORTONLY, isCustomerCategoryID, isLocationReceiptID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.BUILDCustomer(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, goodsIssueTypeID_REPORTONLY, isCustomerCategoryID, isLocationReceiptID, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string BUILDCustomer(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY goodsIssueTypeID_REPORTONLY, bool isCustomerCategoryID, bool isLocationReceiptID, bool isCustomerID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@WarehouseReceiptIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.BUILDWarehouseReceipt(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, goodsIssueTypeID_REPORTONLY, isCustomerCategoryID, isLocationReceiptID, isCustomerID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.BUILDWarehouseReceipt(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, goodsIssueTypeID_REPORTONLY, isCustomerCategoryID, isLocationReceiptID, isCustomerID, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string BUILDWarehouseReceipt(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY goodsIssueTypeID_REPORTONLY, bool isCustomerCategoryID, bool isLocationReceiptID, bool isCustomerID, bool isWarehouseReceiptID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@TeamIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.BUILDTeam(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, goodsIssueTypeID_REPORTONLY, isCustomerCategoryID, isLocationReceiptID, isCustomerID, isWarehouseReceiptID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.BUILDTeam(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, goodsIssueTypeID_REPORTONLY, isCustomerCategoryID, isLocationReceiptID, isCustomerID, isWarehouseReceiptID, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string BUILDTeam(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY goodsIssueTypeID_REPORTONLY, bool isCustomerCategoryID, bool isLocationReceiptID, bool isCustomerID, bool isWarehouseReceiptID, bool isTeamID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@EmployeeIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.BUILDEmployee(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, goodsIssueTypeID_REPORTONLY, isCustomerCategoryID, isLocationReceiptID, isCustomerID, isWarehouseReceiptID, isTeamID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.BUILDEmployee(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, goodsIssueTypeID_REPORTONLY, isCustomerCategoryID, isLocationReceiptID, isCustomerID, isWarehouseReceiptID, isTeamID, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string BUILDEmployee(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY goodsIssueTypeID_REPORTONLY, bool isCustomerCategoryID, bool isLocationReceiptID, bool isCustomerID, bool isWarehouseReceiptID, bool isTeamID, bool isEmployeeID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@WarehouseAdjustmentTypeIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.WarehouseLedgerBUILD(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, goodsIssueTypeID_REPORTONLY, isCustomerCategoryID, isLocationReceiptID, isCustomerID, isWarehouseReceiptID, isTeamID, isEmployeeID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.WarehouseLedgerBUILD(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, goodsIssueTypeID_REPORTONLY, isCustomerCategoryID, isLocationReceiptID, isCustomerID, isWarehouseReceiptID, isTeamID, isEmployeeID, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }



        private string WarehouseLedgerBUILD(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY goodsIssueTypeID_REPORTONLY, bool isCustomerCategoryID, bool isLocationReceiptID, bool isCustomerID, bool isWarehouseReceiptID, bool isTeamID, bool isEmployeeID, bool isWarehouseAdjustmentTypeID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            if (goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.Alls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.CombineSelectedAlls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.GoodsIssues || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.SelectedGoodsIssues)
            { //isGoodsIssueTypeID IS true WHEN goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.CombineSelectedAlls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.SelectedGoodsIssues
                queryString = queryString + "                   " + this.WarehouseLedgerBUILDTable(GlobalEnums.NmvnTaskID.GoodsIssue, "GoodsIssueDetails", "GoodsIssueID", "GoodsIssueDetailID", isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityTypeID, isCommodityID, goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.CombineSelectedAlls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.SelectedGoodsIssues) + "\r\n";

                queryString = queryString + "                   " + (isCustomerCategoryID || isCustomerID ? "INNER" : "LEFT") + "        JOIN Customers ON " + (isCustomerCategoryID || isCustomerID ? "(" + (isCustomerCategoryID ? "Customers.CustomerCategoryID IN (SELECT Id FROM dbo.SplitToIntList (@CustomerCategoryIDs))" : "") + (isCustomerCategoryID && isCustomerID ? " OR " : "") + (isCustomerID ? "Customers.CustomerID IN (SELECT Id FROM dbo.SplitToIntList (@CustomerIDs)) " : "") + ") AND " : "") + " GoodsIssueDetails.CustomerID = Customers.CustomerID " + "\r\n";
                queryString = queryString + "                   " + (isCustomerCategoryID || isCustomerID ? "INNER" : "LEFT") + "        JOIN CustomerCategories ON Customers.CustomerCategoryID = CustomerCategories.CustomerCategoryID " + "\r\n";

                queryString = queryString + "                   " + (isTeamID || isEmployeeID ? "INNER" : "LEFT") + "                    JOIN Employees ON " + (isTeamID || isEmployeeID ? "(" + (isTeamID ? "Employees.TeamID IN (SELECT Id FROM dbo.SplitToIntList (@TeamIDs))" : "") + (isTeamID && isEmployeeID ? " OR " : "") + (isEmployeeID ? "Employees.EmployeeID IN (SELECT Id FROM dbo.SplitToIntList (@EmployeeIDs)) " : "") + ") AND " : "") + " GoodsIssueDetails.SalespersonID = Employees.EmployeeID " + "\r\n";
                queryString = queryString + "                   " + (isTeamID || isEmployeeID ? "INNER" : "LEFT") + "                    JOIN Teams ON Employees.TeamID = Teams.TeamID " + "\r\n";

                queryString = queryString + "                   " + (isLocationReceiptID || isWarehouseReceiptID ? "INNER" : "LEFT") + " JOIN Locations AS LocationReceipts ON " + (isLocationReceiptID || isWarehouseReceiptID ? "(" + (isLocationReceiptID ? "GoodsIssueDetails.LocationReceiptID IN (SELECT Id FROM dbo.SplitToIntList (@LocationReceiptIDs)) " : "") + (isLocationReceiptID && isWarehouseReceiptID ? " OR " : "") + (isWarehouseReceiptID ? "GoodsIssueDetails.WarehouseReceiptID IN (SELECT Id FROM dbo.SplitToIntList (@WarehouseReceiptIDs)) " : "") + ") AND " : "") + " GoodsIssueDetails.LocationReceiptID = LocationReceipts.LocationID " + "\r\n";
                queryString = queryString + "                   " + (isLocationReceiptID || isWarehouseReceiptID ? "INNER" : "LEFT") + " JOIN Warehouses AS WarehouseReceipts ON GoodsIssueDetails.WarehouseReceiptID = WarehouseReceipts.WarehouseID " + "\r\n";
            }

            if (goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.Alls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.CombineSelectedAlls)
                queryString = queryString + "                   UNION ALL " + "\r\n";

            if (goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.Alls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.CombineSelectedAlls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.WarehouseAdjustments)
            { //isGoodsIssueTypeID IS ALWAYS false
                queryString = queryString + "                   " + this.WarehouseLedgerBUILDTable(GlobalEnums.NmvnTaskID.WarehouseAdjustment, "WarehouseAdjustmentDetails", "WarehouseAdjustmentID", "WarehouseAdjustmentDetailID", isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityTypeID, isCommodityID, false) + "\r\n";

                queryString = queryString + "                   INNER JOIN WarehouseAdjustmentTypes ON " + (isWarehouseAdjustmentTypeID ? "WarehouseAdjustmentDetails.WarehouseAdjustmentTypeID IN (SELECT Id FROM dbo.SplitToIntList (@WarehouseAdjustmentTypeIDs)) AND " : "") + " WarehouseAdjustmentDetails.WarehouseAdjustmentTypeID = WarehouseAdjustmentTypes.WarehouseAdjustmentTypeID " + "\r\n";
            }

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }


        private string WarehouseLedgerBUILDTable(GlobalEnums.NmvnTaskID nmvnTaskID, string tableName, string primaryKey, string primaryDetailKey, bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityTypeID, bool isCommodityID, bool isGoodsIssueTypeID)
        {
            string queryString = "";

            queryString = queryString + "       SELECT      " + tableName + "." + primaryKey + " AS PrimaryID, " + tableName + "." + primaryDetailKey + " AS PrimaryDetailID, " + tableName + ".EntryDate, " + tableName + ".Reference, Locations.Name AS LocationName, Warehouses.Name AS WarehouseName, " + "\r\n";
            queryString = queryString + "                   Commodities.CommodityID, Commodities.Code, Commodities.Name, Commodities.PackageSize, CommodityCategories.Name AS CommodityCategoryName, CommodityTypes.Name AS CommodityTypeName, CAST(0 AS bit) AS IsPromotion, " + (nmvnTaskID == GlobalEnums.NmvnTaskID.WarehouseAdjustment ? "-" : "") + tableName + ".Quantity, " + (nmvnTaskID == GlobalEnums.NmvnTaskID.WarehouseAdjustment ? "-" : "") + tableName + ".LineVolume, " + "\r\n";
            if (nmvnTaskID == GlobalEnums.NmvnTaskID.GoodsIssue)
                queryString = queryString + "               ISNULL(Customers.Code, LocationReceipts.Name) AS LineForeignCode, ISNULL(Customers.Name, WarehouseReceipts.Name) AS LineForeignName, GoodsIssueDetails.VoucherCodes AS LineReferences, CustomerCategories.Name AS CustomerCategoryName, Teams.Name AS TeamName, Employees.Name AS SalespersonName " + "\r\n";
            if (nmvnTaskID == GlobalEnums.NmvnTaskID.WarehouseAdjustment)
                queryString = queryString + "               WarehouseAdjustmentTypes.Code AS LineForeignCode, WarehouseAdjustmentTypes.Name AS LineForeignName, WarehouseAdjustmentDetails.Reference + ' ' + WarehouseAdjustmentDetails.AdjustmentJobs AS LineReferences, NULL AS CustomerCategoryName, NULL AS TeamName, NULL AS SalespersonName " + "\r\n";


            queryString = queryString + "       FROM        " + tableName + " " + "\r\n";

            queryString = queryString + "                   INNER JOIN Locations ON " + (nmvnTaskID == GlobalEnums.NmvnTaskID.WarehouseAdjustment ? tableName + ".Quantity < 0 AND " : "") + tableName + ".EntryDate >= @FromDate AND " + tableName + ".EntryDate <= @ToDate AND " + tableName + ".OrganizationalUnitID IN (SELECT OrganizationalUnitID FROM AccessControls WHERE UserID = @UserID AND NMVNTaskID = " + (int)nmvnTaskID + " AND AccessControls.AccessLevel > 0) AND " + (isGoodsIssueTypeID ? tableName + ".GoodsIssueTypeID IN (SELECT Id FROM dbo.SplitToIntList (@GoodsIssueTypeIDs)) AND " : "") + (isLocationID || isWarehouseID ? "(" + (isLocationID ? "" + tableName + ".LocationID IN (SELECT Id FROM dbo.SplitToIntList (@LocationIDs)) " : "") + (isLocationID && isWarehouseID ? " OR " : "") + (isWarehouseID ? "" + tableName + ".WarehouseID IN (SELECT Id FROM dbo.SplitToIntList (@WarehouseIDs)) " : "") + ") AND " : "") + " " + tableName + ".LocationID = Locations.LocationID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Warehouses ON " + tableName + ".WarehouseID = Warehouses.WarehouseID " + "\r\n";

            queryString = queryString + "                   INNER JOIN Commodities ON " + (isCommodityCategoryID || isCommodityID ? "(" + (isCommodityCategoryID ? "Commodities.CommodityCategoryID IN (SELECT Id FROM dbo.SplitToIntList (@CommodityCategoryIDs))" : "") + (isCommodityCategoryID && isCommodityID ? " OR " : "") + (isCommodityID ? "Commodities.CommodityID IN (SELECT Id FROM dbo.SplitToIntList (@CommodityIDs)) " : "") + ") AND " : "") + " " + tableName + ".CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN CommodityCategories ON " + " Commodities.CommodityCategoryID = CommodityCategories.CommodityCategoryID " + "\r\n";

            queryString = queryString + "                   INNER JOIN CommodityTypes ON " + (isCommodityTypeID ? "Commodities.CommodityTypeID IN (SELECT Id FROM dbo.SplitToIntList (@CommodityTypeIDs)) AND " : "") + " Commodities.CommodityTypeID = CommodityTypes.CommodityTypeID " + "\r\n";

            return queryString;
        }

    }
}

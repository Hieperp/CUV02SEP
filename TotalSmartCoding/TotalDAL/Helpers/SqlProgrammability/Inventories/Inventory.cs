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

            this.GoodsIssueJournals();
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



        private string BUILDHeader()
        {
            string queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime, @LocationIDs varchar(3999), @WarehouseIDs varchar(3999), @CommodityCategoryIDs varchar(3999), @CommodityTypeIDs varchar(3999), @CommodityIDs varchar(3999), @GoodsIssueTypeIDs varchar(3999), @CustomerCategoryIDs varchar(3999), @CustomerIDs varchar(3999), @LocationReceiptIDs varchar(3999), @WarehouseReceiptIDs varchar(3999), @TeamIDs varchar(3999), @EmployeeIDs varchar(3999), @WarehouseAdjustmentTypeIDs varchar(3999) " + "\r\n";

            //queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "       SET NOCOUNT ON; " + "\r\n";

            queryString = queryString + "       DECLARE     @LocalUserID Int, @LocalFromDate DateTime, @LocalToDate DateTime, @LocalLocationIDs varchar(3999), @LocalWarehouseIDs varchar(3999), @LocalCommodityCategoryIDs varchar(3999), @LocalCommodityTypeIDs varchar(3999), @LocalCommodityIDs varchar(3999), @LocalGoodsIssueTypeIDs varchar(3999), @LocalCustomerCategoryIDs varchar(3999), @LocalCustomerIDs varchar(3999), @LocalLocationReceiptIDs varchar(3999), @LocalWarehouseReceiptIDs varchar(3999), @LocalTeamIDs varchar(3999), @LocalEmployeeIDs varchar(3999), @LocalWarehouseAdjustmentTypeIDs varchar(3999) " + "\r\n";

            queryString = queryString + "       SET         @LocalUserID = @UserID                                              SET @LocalFromDate = @FromDate                          SET @LocalToDate = @ToDate " + "\r\n";
            queryString = queryString + "       SET         @LocalLocationIDs = @LocationIDs                                    SET @LocalWarehouseIDs = @WarehouseIDs                  " + "\r\n";
            queryString = queryString + "       SET         @LocalCommodityCategoryIDs = @CommodityCategoryIDs                  SET @LocalCommodityIDs = @CommodityIDs                  " + "\r\n";
            queryString = queryString + "       SET         @LocalCommodityTypeIDs = @CommodityTypeIDs                          SET @LocalGoodsIssueTypeIDs = @GoodsIssueTypeIDs " + "\r\n";
            queryString = queryString + "       SET         @LocalCustomerCategoryIDs = @CustomerCategoryIDs                    SET @LocalCustomerIDs = @CustomerIDs" + "\r\n";
            queryString = queryString + "       SET         @LocalLocationReceiptIDs = @LocationReceiptIDs                      SET @LocalWarehouseReceiptIDs = @WarehouseReceiptIDs " + "\r\n";
            queryString = queryString + "       SET         @LocalTeamIDs = @TeamIDs                                            SET @LocalEmployeeIDs = @EmployeeIDs " + "\r\n";
            queryString = queryString + "       SET         @LocalWarehouseAdjustmentTypeIDs = @WarehouseAdjustmentTypeIDs" + "\r\n";

            return queryString;
        }

        private string BUILDParameter()
        {
            return " @UserID, @FromDate, @ToDate, @LocationIDs, @WarehouseIDs, @CommodityCategoryIDs, @CommodityTypeIDs, @CommodityIDs, @GoodsIssueTypeIDs, @CustomerCategoryIDs, @CustomerIDs, @LocationReceiptIDs, @WarehouseReceiptIDs, @TeamIDs, @EmployeeIDs, @WarehouseAdjustmentTypeIDs ";
        }

        private void GoodsIssueJournals()
        {
            this.GoodsIssueJournal08();

            string queryString = this.BUILDHeader() + this.BUILDGoodsIssue() + "\r\n";
            this.totalSmartCodingEntities.CreateStoredProcedure("GoodsIssueJournals", queryString);
        }

        private string BUILDGoodsIssue()
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@LocalLocationIDs <> '') " + "\r\n";
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

            queryString = queryString + "       IF         (@LocalWarehouseIDs <> '') " + "\r\n";
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

            queryString = queryString + "       IF         (@LocalCommodityCategoryIDs <> '') " + "\r\n";
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

            queryString = queryString + "       IF         (@LocalCommodityIDs <> '') " + "\r\n";
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

            queryString = queryString + "       IF         (@LocalCommodityTypeIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.BUILDCommodityType(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.BUILDCommodityType(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
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

            queryString = queryString + "       IF  (@LocalGoodsIssueTypeIDs IS NULL OR @LocalGoodsIssueTypeIDs = '' OR (@LocalGoodsIssueTypeIDs LIKE '%" + (int)GlobalEnums.GoodsIssueTypeID.DeliveryAdvice + "%' AND @LocalGoodsIssueTypeIDs LIKE '%" + (int)GlobalEnums.GoodsIssueTypeID.TransferOrder + "%' AND @LocalGoodsIssueTypeIDs LIKE '%" + (int)GlobalEnums.GoodsIssueTypeID.WarehouseAdjustment + "%')) " + "\r\n";
            queryString = queryString + "               " + this.BUILDGoodsIssueType(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY.Alls) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";

            queryString = queryString + "               IF      (@LocalGoodsIssueTypeIDs = '" + (int)GlobalEnums.GoodsIssueTypeID.WarehouseAdjustment + "') " + "\r\n";
            queryString = queryString + "                           " + this.BUILDGoodsIssueType(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY.WarehouseAdjustments) + "\r\n";
            queryString = queryString + "               ELSE " + "\r\n";
            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       IF  (@LocalGoodsIssueTypeIDs LIKE '%" + (int)GlobalEnums.GoodsIssueTypeID.WarehouseAdjustment + "%') " + "\r\n";
            queryString = queryString + "                           " + this.BUILDGoodsIssueType(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY.CombineSelectedAlls) + "\r\n";
            queryString = queryString + "                       ELSE " + "\r\n";
            queryString = queryString + "                           BEGIN " + "\r\n";
            queryString = queryString + "                               IF  (@LocalGoodsIssueTypeIDs LIKE '%" + (int)GlobalEnums.GoodsIssueTypeID.DeliveryAdvice + "%' AND @LocalGoodsIssueTypeIDs LIKE '%" + (int)GlobalEnums.GoodsIssueTypeID.TransferOrder + "%') " + "\r\n";
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

            queryString = queryString + "       IF         (@LocalCustomerCategoryIDs <> '') " + "\r\n";
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

            queryString = queryString + "       IF         (@LocalLocationReceiptIDs <> '') " + "\r\n";
            queryString = queryString + "                   EXEC GIJ08" + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isCommodityCategoryID.ToString().Substring(0, 1) + isCommodityID.ToString().Substring(0, 1) + isCommodityTypeID.ToString().Substring(0, 1) + goodsIssueTypeID_REPORTONLY.ToString().Substring(0, 1) + isCustomerCategoryID.ToString().Substring(0, 1) + true.ToString().Substring(0, 1) + this.BUILDParameter() + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   EXEC GIJ08" + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isCommodityCategoryID.ToString().Substring(0, 1) + isCommodityID.ToString().Substring(0, 1) + isCommodityTypeID.ToString().Substring(0, 1) + goodsIssueTypeID_REPORTONLY.ToString().Substring(0, 1) + isCustomerCategoryID.ToString().Substring(0, 1) + false.ToString().Substring(0, 1) + this.BUILDParameter() + "\r\n";
            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private void GoodsIssueJournal08()
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
                                            this.totalSmartCodingEntities.CreateStoredProcedure("GIJ08" + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isCommodityCategoryID.ToString().Substring(0, 1) + isCommodityID.ToString().Substring(0, 1) + isCommodityTypeID.ToString().Substring(0, 1) + goodsIssueTypeID_REPORTONLY.ToString().Substring(0, 1) + isCustomerCategoryID.ToString().Substring(0, 1) + isLocationReceiptID.ToString().Substring(0, 1), this.BUILDHeader() + this.BUILDLocationReceipt(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, goodsIssueTypeID_REPORTONLY, isCustomerCategoryID, isLocationReceiptID));
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

            queryString = queryString + "       IF         (@LocalCustomerIDs <> '') " + "\r\n";
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

            queryString = queryString + "       IF         (@LocalWarehouseReceiptIDs <> '') " + "\r\n";
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

            queryString = queryString + "       IF         (@LocalTeamIDs <> '') " + "\r\n";
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

            queryString = queryString + "       IF         (@LocalEmployeeIDs <> '') " + "\r\n";
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

            queryString = queryString + "       IF         (@LocalWarehouseAdjustmentTypeIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.GoodsIssueJournalBUILD(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, goodsIssueTypeID_REPORTONLY, isCustomerCategoryID, isLocationReceiptID, isCustomerID, isWarehouseReceiptID, isTeamID, isEmployeeID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.GoodsIssueJournalBUILD(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, goodsIssueTypeID_REPORTONLY, isCustomerCategoryID, isLocationReceiptID, isCustomerID, isWarehouseReceiptID, isTeamID, isEmployeeID, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }



        private string GoodsIssueJournalBUILD(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY goodsIssueTypeID_REPORTONLY, bool isCustomerCategoryID, bool isLocationReceiptID, bool isCustomerID, bool isWarehouseReceiptID, bool isTeamID, bool isEmployeeID, bool isWarehouseAdjustmentTypeID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            if (goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.Alls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.CombineSelectedAlls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.GoodsIssues || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.SelectedGoodsIssues)
            { //isGoodsIssueTypeID IS true WHEN goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.CombineSelectedAlls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.SelectedGoodsIssues
                queryString = queryString + "                   " + this.GoodsIssueJournalBUILDTable(GlobalEnums.NmvnTaskID.GoodsIssue, "GoodsIssueDetails", "GoodsIssueID", "GoodsIssueDetailID", isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityTypeID, isCommodityID, goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.CombineSelectedAlls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.SelectedGoodsIssues) + "\r\n";

                queryString = queryString + "                   " + (isCustomerCategoryID || isCustomerID ? "INNER" : "LEFT") + "       JOIN Customers ON " + (isCustomerCategoryID || isCustomerID ? "(" + (isCustomerCategoryID ? "Customers.CustomerCategoryID IN (SELECT Id FROM dbo.SplitToIntList (@LocalCustomerCategoryIDs))" : "") + (isCustomerCategoryID && isCustomerID ? " OR " : "") + (isCustomerID ? "Customers.CustomerID IN (SELECT Id FROM dbo.SplitToIntList (@LocalCustomerIDs)) " : "") + ") AND " : "") + " GoodsIssueDetails.CustomerID = Customers.CustomerID " + "\r\n";

                queryString = queryString + "                   " + (isTeamID || isEmployeeID ? "INNER" : "LEFT") + "                   JOIN Employees ON " + (isTeamID || isEmployeeID ? "(" + (isTeamID ? "Employees.TeamID IN (SELECT Id FROM dbo.SplitToIntList (@LocalTeamIDs))" : "") + (isTeamID && isEmployeeID ? " OR " : "") + (isEmployeeID ? "Employees.EmployeeID IN (SELECT Id FROM dbo.SplitToIntList (@LocalEmployeeIDs)) " : "") + ") AND " : "") + " GoodsIssueDetails.SalespersonID = Employees.EmployeeID " + "\r\n";

                queryString = queryString + "                   " + (isLocationReceiptID || isWarehouseReceiptID ? "INNER" : "LEFT") + " JOIN Locations AS LocationReceipts ON " + (isLocationReceiptID || isWarehouseReceiptID ? "(" + (isLocationReceiptID ? "GoodsIssueDetails.LocationReceiptID IN (SELECT Id FROM dbo.SplitToIntList (@LocalLocationReceiptIDs)) " : "") + (isLocationReceiptID && isWarehouseReceiptID ? " OR " : "") + (isWarehouseReceiptID ? "GoodsIssueDetails.WarehouseReceiptID IN (SELECT Id FROM dbo.SplitToIntList (@LocalWarehouseReceiptIDs)) " : "") + ") AND " : "") + " GoodsIssueDetails.LocationReceiptID = LocationReceipts.LocationID " + "\r\n";

                queryString = queryString + "                   LEFT JOIN Teams ON Employees.TeamID = Teams.TeamID " + "\r\n"; //NEEDED?
                queryString = queryString + "                   LEFT JOIN Warehouses AS WarehouseReceipts ON GoodsIssueDetails.WarehouseReceiptID = WarehouseReceipts.WarehouseID " + "\r\n"; //NEEDED?
                queryString = queryString + "                   LEFT JOIN CustomerCategories ON Customers.CustomerCategoryID = CustomerCategories.CustomerCategoryID " + "\r\n"; //NEEDED?
            }

            if (goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.Alls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.CombineSelectedAlls)
                queryString = queryString + "                   UNION ALL " + "\r\n";

            if (goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.Alls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.CombineSelectedAlls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.WarehouseAdjustments)
            { //isGoodsIssueTypeID IS ALWAYS false
                queryString = queryString + "                   " + this.GoodsIssueJournalBUILDTable(GlobalEnums.NmvnTaskID.WarehouseAdjustment, "WarehouseAdjustmentDetails", "WarehouseAdjustmentID", "WarehouseAdjustmentDetailID", isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityTypeID, isCommodityID, false) + "\r\n";

                queryString = queryString + "                   INNER JOIN WarehouseAdjustmentTypes ON " + (isWarehouseAdjustmentTypeID ? "WarehouseAdjustmentDetails.WarehouseAdjustmentTypeID IN (SELECT Id FROM dbo.SplitToIntList (@LocalWarehouseAdjustmentTypeIDs)) AND " : "") + " WarehouseAdjustmentDetails.WarehouseAdjustmentTypeID = WarehouseAdjustmentTypes.WarehouseAdjustmentTypeID " + "\r\n";
            }

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }


        private string GoodsIssueJournalBUILDTable(GlobalEnums.NmvnTaskID nmvnTaskID, string tableName, string primaryKey, string primaryDetailKey, bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityTypeID, bool isCommodityID, bool isGoodsIssueTypeID)
        {
            string queryString = "";

            queryString = queryString + "       SELECT      " + tableName + "." + primaryKey + " AS PrimaryKey, " + tableName + "." + primaryDetailKey + " AS PrimaryDetailKey, " + tableName + ".EntryDate, " + "\r\n";
            queryString = queryString + "                   Commodities.CommodityID, Commodities.Code, Commodities.Name, " + tableName + ".Quantity, " + tableName + ".LineVolume " + "\r\n";

            queryString = queryString + "       FROM        " + tableName + " " + "\r\n";

            queryString = queryString + "                   INNER JOIN Locations ON " + tableName + ".EntryDate >= @LocalFromDate AND " + tableName + ".EntryDate <= @LocalToDate AND " + tableName + ".OrganizationalUnitID IN (SELECT OrganizationalUnitID FROM AccessControls WHERE UserID = @LocalUserID AND NMVNTaskID = " + (int)nmvnTaskID + " AND AccessControls.AccessLevel > 0) AND " + (isGoodsIssueTypeID ? tableName + ".GoodsIssueTypeID IN (SELECT Id FROM dbo.SplitToIntList (@LocalGoodsIssueTypeIDs)) AND " : "") + (isLocationID || isWarehouseID ? "(" + (isLocationID ? "" + tableName + ".LocationID IN (SELECT Id FROM dbo.SplitToIntList (@LocalLocationIDs)) " : "") + (isLocationID && isWarehouseID ? " OR " : "") + (isWarehouseID ? "" + tableName + ".WarehouseID IN (SELECT Id FROM dbo.SplitToIntList (@LocalWarehouseIDs)) " : "") + ") AND " : "") + " " + tableName + ".LocationID = Locations.LocationID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Warehouses ON " + tableName + ".WarehouseID = Warehouses.WarehouseID " + "\r\n";

            queryString = queryString + "                   INNER JOIN Commodities ON " + (isCommodityCategoryID || isCommodityID ? "(" + (isCommodityCategoryID ? "Commodities.CommodityCategoryID IN (SELECT Id FROM dbo.SplitToIntList (@LocalCommodityCategoryIDs))" : "") + (isCommodityCategoryID && isCommodityID ? " OR " : "") + (isCommodityID ? "Commodities.CommodityID IN (SELECT Id FROM dbo.SplitToIntList (@LocalCommodityIDs)) " : "") + ") AND " : "") + " " + tableName + ".CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN CommodityCategories ON " + " Commodities.CommodityCategoryID = CommodityCategories.CommodityCategoryID " + "\r\n";

            queryString = queryString + "                   INNER JOIN CommodityTypes ON " + (isCommodityTypeID ? "Commodities.CommodityTypeID IN (SELECT Id FROM dbo.SplitToIntList (@LocalCommodityTypeIDs)) AND " : "") + " Commodities.CommodityTypeID = CommodityTypes.CommodityTypeID " + "\r\n";

            return queryString;
        }

    }
}

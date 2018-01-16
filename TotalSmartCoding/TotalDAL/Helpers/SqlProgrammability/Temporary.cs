using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability
{
    public class Temporary
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public Temporary(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
        }


        #region Backup for WarehouseJournal

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



        #endregion Backup for WarehouseJournal


        #region Backup for GetPendingDeliveryAdviceDetails, GetPendingTransferOrderDetails
        //????By Transfer Order? By Warehouse Issue, receipt   =>> WarehouseID, WarehouseReceiptID

        private bool alwaysTrue = true;
        //HERE: WE ALWAYS AND ONLY CALL GetPendingDeliveryAdviceDetails AFTER SAVE SUCCESSFUL
        //AT GoodsIssues VIEWS: WE DON'T ALLOW TO USE CURRENT RESULT FROM GetPendingDeliveryAdviceDetails IF THE LAST SAVE IS NOT SUCCESSFULLY. WHEN SAVE SUCCESSFUL, THE GetPendingDeliveryAdviceDetails IS CALL IMMEDIATELY
        //SO => HERE: WE DON'T CARE BOTH: @DeliveryAdviceDetailIDs AND BuildSQLEdit
        private void GetPendingDeliveryAdviceDetails()
        {
            string queryString;

            queryString = " @LocationID Int, @GoodsIssueID Int, @DeliveryAdviceID Int, @CustomerID Int, @DeliveryAdviceDetailIDs varchar(3999), @IsReadonly bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "   BEGIN " + "\r\n";

            queryString = queryString + "       IF  (@DeliveryAdviceID <> 0) " + "\r\n";
            queryString = queryString + "           " + this.BuildSQLDeliveryAdvice(true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           " + this.BuildSQLDeliveryAdvice(false) + "\r\n";

            queryString = queryString + "   END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetPendingDeliveryAdviceDetails", queryString);
        }

        private string BuildSQLDeliveryAdvice(bool isDeliveryAdviceID)
        {
            string queryString = "";
            if (this.alwaysTrue)
                queryString = queryString + "           " + this.BuildSQLDeliveryAdviceDeliveryAdviceDetailIDs(isDeliveryAdviceID, false) + "\r\n";
            else
            {
                queryString = queryString + "   BEGIN " + "\r\n";
                queryString = queryString + "       IF  (@DeliveryAdviceDetailIDs <> '') " + "\r\n";
                queryString = queryString + "           " + this.BuildSQLDeliveryAdviceDeliveryAdviceDetailIDs(isDeliveryAdviceID, true) + "\r\n";
                queryString = queryString + "       ELSE " + "\r\n";
                queryString = queryString + "           " + this.BuildSQLDeliveryAdviceDeliveryAdviceDetailIDs(isDeliveryAdviceID, false) + "\r\n";
                queryString = queryString + "   END " + "\r\n";
            }
            return queryString;
        }

        private string BuildSQLDeliveryAdviceDeliveryAdviceDetailIDs(bool isDeliveryAdviceID, bool isDeliveryAdviceDetailIDs)
        {
            string queryString = "";
            queryString = queryString + "   BEGIN " + "\r\n";

            if (this.alwaysTrue)
            {
                queryString = queryString + "               BEGIN " + "\r\n";
                queryString = queryString + "                   " + this.BuildSQLNew(isDeliveryAdviceID, isDeliveryAdviceDetailIDs) + "\r\n";
                queryString = queryString + "                   ORDER BY DeliveryAdviceDetails.EntryDate, DeliveryAdviceDetails.DeliveryAdviceID, DeliveryAdviceDetails.DeliveryAdviceDetailID " + "\r\n";
                queryString = queryString + "               END " + "\r\n";
            }
            else
            {
                queryString = queryString + "       IF (@GoodsIssueID <= 0) " + "\r\n";
                queryString = queryString + "               BEGIN " + "\r\n";
                queryString = queryString + "                   " + this.BuildSQLNew(isDeliveryAdviceID, isDeliveryAdviceDetailIDs) + "\r\n";
                queryString = queryString + "                   ORDER BY DeliveryAdviceDetails.EntryDate, DeliveryAdviceDetails.DeliveryAdviceID, DeliveryAdviceDetails.DeliveryAdviceDetailID " + "\r\n";
                queryString = queryString + "               END " + "\r\n";
                queryString = queryString + "       ELSE " + "\r\n";

                queryString = queryString + "               IF (@IsReadonly = 1) " + "\r\n";
                queryString = queryString + "                   BEGIN " + "\r\n";
                queryString = queryString + "                       " + this.BuildSQLEdit(isDeliveryAdviceID, isDeliveryAdviceDetailIDs) + "\r\n";
                queryString = queryString + "                       ORDER BY DeliveryAdviceDetails.EntryDate, DeliveryAdviceDetails.DeliveryAdviceID, DeliveryAdviceDetails.DeliveryAdviceDetailID " + "\r\n";
                queryString = queryString + "                   END " + "\r\n";

                queryString = queryString + "               ELSE " + "\r\n"; //FULL SELECT FOR EDIT MODE

                queryString = queryString + "                   BEGIN " + "\r\n";
                queryString = queryString + "                       " + this.BuildSQLNew(isDeliveryAdviceID, isDeliveryAdviceDetailIDs) + " WHERE DeliveryAdviceDetails.DeliveryAdviceDetailID NOT IN (SELECT DeliveryAdviceDetailID FROM GoodsIssueDetails WHERE GoodsIssueID = @GoodsIssueID) " + "\r\n";
                queryString = queryString + "                       UNION ALL " + "\r\n";
                queryString = queryString + "                       " + this.BuildSQLEdit(isDeliveryAdviceID, isDeliveryAdviceDetailIDs) + "\r\n";
                queryString = queryString + "                       ORDER BY DeliveryAdviceDetails.EntryDate, DeliveryAdviceDetails.DeliveryAdviceID, DeliveryAdviceDetails.DeliveryAdviceDetailID " + "\r\n";
                queryString = queryString + "                   END " + "\r\n";
            }

            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        private string BuildSQLNew(bool isDeliveryAdviceID, bool isDeliveryAdviceDetailIDs)
        {
            string queryString = "";

            queryString = queryString + "       SELECT      DeliveryAdviceDetails.LocationID, DeliveryAdviceDetails.DeliveryAdviceID, DeliveryAdviceDetails.DeliveryAdviceDetailID, DeliveryAdviceDetails.Reference AS DeliveryAdviceReference, DeliveryAdviceDetails.EntryDate AS DeliveryAdviceEntryDate, " + "\r\n";
            queryString = queryString + "                   Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.PackageSize, Commodities.Volume, Commodities.PackageVolume, DeliveryAdviceDetails.BatchID, Batches.Code AS BatchCode, " + "\r\n";
            queryString = queryString + "                   ROUND(DeliveryAdviceDetails.Quantity - DeliveryAdviceDetails.QuantityIssue,  " + (int)GlobalEnums.rndQuantity + ") AS QuantityRemains, CAST(0 AS decimal(18, 2)) AS Quantity, ROUND(DeliveryAdviceDetails.LineVolume - DeliveryAdviceDetails.LineVolumeIssue,  " + (int)GlobalEnums.rndVolume + ") AS LineVolumeRemains, CAST(0 AS decimal(18, 2)) AS LineVolume, DeliveryAdviceDetails.Remarks, CAST(0 AS bit) AS IsSelected " + "\r\n";

            queryString = queryString + "       FROM        DeliveryAdviceDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON " + (isDeliveryAdviceID ? " DeliveryAdviceDetails.DeliveryAdviceID = @DeliveryAdviceID " : "DeliveryAdviceDetails.LocationID = @LocationID AND DeliveryAdviceDetails.CustomerID = @CustomerID ") + " AND DeliveryAdviceDetails.Approved = 1 AND ROUND(DeliveryAdviceDetails.Quantity - DeliveryAdviceDetails.QuantityIssue, " + (int)GlobalEnums.rndQuantity + ") > 0 AND DeliveryAdviceDetails.CommodityID = Commodities.CommodityID" + (isDeliveryAdviceDetailIDs ? " AND DeliveryAdviceDetails.DeliveryAdviceDetailID NOT IN (SELECT Id FROM dbo.SplitToIntList (@DeliveryAdviceDetailIDs))" : "") + "\r\n";
            queryString = queryString + "                   LEFT JOIN Batches ON DeliveryAdviceDetails.BatchID = Batches.BatchID " + "\r\n";
            return queryString;
        }

        private string BuildSQLEdit(bool isDeliveryAdviceID, bool isDeliveryAdviceDetailIDs)
        {
            string queryString = "";

            queryString = queryString + "       SELECT      DeliveryAdviceDetails.LocationID, DeliveryAdviceDetails.DeliveryAdviceID, DeliveryAdviceDetails.DeliveryAdviceDetailID, DeliveryAdviceDetails.Reference AS DeliveryAdviceReference, DeliveryAdviceDetails.EntryDate AS DeliveryAdviceEntryDate, " + "\r\n";
            queryString = queryString + "                   Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.PackageSize, Commodities.Volume, Commodities.PackageVolume, DeliveryAdviceDetails.BatchID, Batches.Code AS BatchCode, " + "\r\n";
            queryString = queryString + "                   ROUND(DeliveryAdviceDetails.Quantity - DeliveryAdviceDetails.QuantityIssue + GoodsIssueDetails.Quantity,  " + (int)GlobalEnums.rndQuantity + ") AS QuantityRemains, CAST(0 AS decimal(18, 2)) AS Quantity, ROUND(DeliveryAdviceDetails.LineVolume - DeliveryAdviceDetails.LineVolumeIssue + GoodsIssueDetails.LineVolume,  " + (int)GlobalEnums.rndVolume + ") AS LineVolumeRemains, CAST(0 AS decimal(18, 2)) AS LineVolume, DeliveryAdviceDetails.Remarks, CAST(0 AS bit) AS IsSelected " + "\r\n";

            queryString = queryString + "       FROM        DeliveryAdviceDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN GoodsIssueDetails ON GoodsIssueDetails.GoodsIssueID = @GoodsIssueID AND DeliveryAdviceDetails.DeliveryAdviceDetailID = GoodsIssueDetails.DeliveryAdviceDetailID" + (isDeliveryAdviceDetailIDs ? " AND DeliveryAdviceDetails.DeliveryAdviceDetailID NOT IN (SELECT Id FROM dbo.SplitToIntList (@DeliveryAdviceDetailIDs))" : "") + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON DeliveryAdviceDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Batches ON DeliveryAdviceDetails.BatchID = Batches.BatchID " + "\r\n";

            return queryString;
        }

        #endregion Backup for GetPendingDeliveryAdviceDetails, GetPendingTransferOrderDetails





        #region Backup for GoodsReceipts

        private void GetPendingPickups()
        {
            string queryString = " @LocationID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       SELECT          Pickups.PickupID, Pickups.Reference AS PickupReference, Pickups.EntryDate AS PickupEntryDate, Pickups.WarehouseID, Warehouses.Code AS WarehouseCode, Warehouses.Name AS WarehouseName, " + (int)GlobalEnums.GoodsReceiptTypeID.Pickup + " AS GoodsReceiptTypeID, (SELECT TOP 1 Name FROM GoodsReceiptTypes WHERE GoodsReceiptTypeID = " + (int)GlobalEnums.GoodsReceiptTypeID.Pickup + ") AS GoodsReceiptTypeName, Pickups.Description, Pickups.Remarks " + "\r\n";
            queryString = queryString + "       FROM            Pickups " + "\r\n";
            queryString = queryString + "                       INNER JOIN Warehouses ON Pickups.PickupID IN (SELECT PickupID FROM PickupDetails WHERE LocationID = @LocationID AND Approved = 1 AND ROUND(Quantity - QuantityReceipt, " + (int)GlobalEnums.rndQuantity + ") > 0) AND Pickups.WarehouseID = Warehouses.WarehouseID " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetPendingPickups", queryString);
        }

        private void GetPendingPickupWarehouses()
        {
            string queryString = " @LocationID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       SELECT          Warehouses.WarehouseID, Warehouses.Code AS WarehouseCode, Warehouses.Name AS WarehouseName, " + (int)GlobalEnums.GoodsReceiptTypeID.Pickup + " AS GoodsReceiptTypeID, (SELECT TOP 1 Name FROM GoodsReceiptTypes WHERE GoodsReceiptTypeID = " + (int)GlobalEnums.GoodsReceiptTypeID.Pickup + ") AS GoodsReceiptTypeName " + "\r\n";
            queryString = queryString + "       FROM           (SELECT DISTINCT WarehouseID FROM PickupDetails WHERE LocationID = @LocationID AND Approved = 1 AND ROUND(Quantity - QuantityReceipt, " + (int)GlobalEnums.rndQuantity + ") > 0) WarehousePENDING " + "\r\n";
            queryString = queryString + "                       INNER JOIN Warehouses ON WarehousePENDING.WarehouseID = Warehouses.WarehouseID " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetPendingPickupWarehouses", queryString);
        }



        private void GetPendingPickupDetails()
        {
            string queryString;

            queryString = " @LocationID Int, @GoodsReceiptID Int, @PickupID Int, @WarehouseID Int, @PickupDetailIDs varchar(3999), @IsReadonly bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "   BEGIN " + "\r\n";

            queryString = queryString + "       IF  (@PickupID <> 0) " + "\r\n";
            queryString = queryString + "           " + this.BuildSQLPickup(true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           " + this.BuildSQLPickup(false) + "\r\n";

            queryString = queryString + "   END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetPendingPickupDetails", queryString);
        }

        private string BuildSQLPickup(bool isPickupID)
        {
            string queryString = "";
            queryString = queryString + "   BEGIN " + "\r\n";
            queryString = queryString + "       IF  (@PickupDetailIDs <> '') " + "\r\n";
            queryString = queryString + "           " + this.BuildSQLPickupPickupDetailIDs(isPickupID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           " + this.BuildSQLPickupPickupDetailIDs(isPickupID, false) + "\r\n";
            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        private string BuildSQLPickupPickupDetailIDs(bool isPickupID, bool isPickupDetailIDs)
        {
            string queryString = "";
            queryString = queryString + "   BEGIN " + "\r\n";

            queryString = queryString + "       IF (@GoodsReceiptID <= 0) " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   " + this.BuildSQLPickupNew(isPickupID, isPickupDetailIDs) + "\r\n";
            queryString = queryString + "                   ORDER BY PickupDetails.EntryDate, PickupDetails.PickupID, PickupDetails.PickupDetailID " + "\r\n";
            queryString = queryString + "               END " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";

            queryString = queryString + "               IF (@IsReadonly = 1) " + "\r\n";
            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       " + this.BuildSQLPickupEdit(isPickupID, isPickupDetailIDs) + "\r\n";
            queryString = queryString + "                       ORDER BY PickupDetails.EntryDate, PickupDetails.PickupID, PickupDetails.PickupDetailID " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "               ELSE " + "\r\n"; //FULL SELECT FOR EDIT MODE

            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       " + this.BuildSQLPickupNew(isPickupID, isPickupDetailIDs) + " WHERE PickupDetails.PickupDetailID NOT IN (SELECT PickupDetailID FROM GoodsReceiptDetails WHERE GoodsReceiptID = @GoodsReceiptID) " + "\r\n";
            queryString = queryString + "                       UNION ALL " + "\r\n";
            queryString = queryString + "                       " + this.BuildSQLPickupEdit(isPickupID, isPickupDetailIDs) + "\r\n";
            queryString = queryString + "                       ORDER BY PickupDetails.EntryDate, PickupDetails.PickupID, PickupDetails.PickupDetailID " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        private string BuildSQLPickupNew(bool isPickupID, bool isPickupDetailIDs)
        {
            string queryString = "";

            queryString = queryString + "       SELECT      PickupDetails.PickupID, PickupDetails.PickupDetailID, PickupDetails.Reference AS PickupReference, PickupDetails.EntryDate AS PickupEntryDate, " + "\r\n";
            queryString = queryString + "                   Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, PickupDetails.BatchID, PickupDetails.BatchEntryDate, PickupDetails.BinLocationID, BinLocations.Code AS BinLocationCode, PickupDetails.PackID, Packs.Code AS PackCode, PickupDetails.CartonID, Cartons.Code AS CartonCode, PickupDetails.PalletID, Pallets.Code AS PalletCode, " + "\r\n";
            queryString = queryString + "                   ROUND(PickupDetails.Quantity - PickupDetails.QuantityReceipt,  " + (int)GlobalEnums.rndQuantity + ") AS QuantityRemains, CAST(0 AS decimal(18, 2)) AS Quantity, ROUND(PickupDetails.LineVolume - PickupDetails.LineVolumeReceipt,  " + (int)GlobalEnums.rndVolume + ") AS LineVolumeRemains, PickupDetails.LineVolume, PickupDetails.PackCounts, PickupDetails.CartonCounts, PickupDetails.PalletCounts, PickupDetails.Remarks, CAST(1 AS bit) AS IsSelected " + "\r\n";

            queryString = queryString + "       FROM        PickupDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON " + (isPickupID ? " PickupDetails.PickupID = @PickupID " : "PickupDetails.LocationID = @LocationID AND PickupDetails.WarehouseID = @WarehouseID ") + " AND PickupDetails.Approved = 1 AND ROUND(PickupDetails.Quantity - PickupDetails.QuantityReceipt, " + (int)GlobalEnums.rndQuantity + ") > 0 AND PickupDetails.CommodityID = Commodities.CommodityID " + (isPickupDetailIDs ? " AND PickupDetails.PickupDetailID NOT IN (SELECT Id FROM dbo.SplitToIntList (@PickupDetailIDs))" : "") + "\r\n";
            queryString = queryString + "                   INNER JOIN BinLocations ON PickupDetails.BinLocationID = BinLocations.BinLocationID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Packs ON PickupDetails.PackID = Packs.PackID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Cartons ON PickupDetails.CartonID = Cartons.CartonID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Pallets ON PickupDetails.PalletID = Pallets.PalletID " + "\r\n";

            return queryString;
        }

        private string BuildSQLPickupEdit(bool isPickupID, bool isPickupDetailIDs)
        {
            string queryString = "";

            queryString = queryString + "       SELECT      PickupDetails.PickupID, PickupDetails.PickupDetailID, PickupDetails.Reference AS PickupReference, PickupDetails.EntryDate AS PickupEntryDate, " + "\r\n";
            queryString = queryString + "                   Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, PickupDetails.BatchID, PickupDetails.BatchEntryDate, PickupDetails.BinLocationID, BinLocations.Code AS BinLocationCode, PickupDetails.PackID, Packs.Code AS PackCode, PickupDetails.CartonID, Cartons.Code AS CartonCode, PickupDetails.PalletID, Pallets.Code AS PalletCode, " + "\r\n";
            queryString = queryString + "                   ROUND(PickupDetails.Quantity - PickupDetails.QuantityReceipt + GoodsReceiptDetails.Quantity,  " + (int)GlobalEnums.rndQuantity + ") AS QuantityRemains, CAST(0 AS decimal(18, 2)) AS Quantity, ROUND(PickupDetails.LineVolume - PickupDetails.LineVolumeReceipt + GoodsReceiptDetails.LineVolume,  " + (int)GlobalEnums.rndVolume + ") AS LineVolumeRemains, PickupDetails.LineVolume, PickupDetails.PackCounts, PickupDetails.CartonCounts, PickupDetails.PalletCounts, PickupDetails.Remarks, CAST(1 AS bit) AS IsSelected " + "\r\n";

            queryString = queryString + "       FROM        PickupDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN GoodsReceiptDetails ON GoodsReceiptDetails.GoodsReceiptID = @GoodsReceiptID AND PickupDetails.PickupDetailID = GoodsReceiptDetails.PickupDetailID" + (isPickupDetailIDs ? " AND PickupDetails.PickupDetailID NOT IN (SELECT Id FROM dbo.SplitToIntList (@PickupDetailIDs))" : "") + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON PickupDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN BinLocations ON PickupDetails.BinLocationID = BinLocations.BinLocationID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Packs ON PickupDetails.PackID = Packs.PackID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Cartons ON PickupDetails.CartonID = Cartons.CartonID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Pallets ON PickupDetails.PalletID = Pallets.PalletID " + "\r\n";

            return queryString;
        }



        #region WarehouseAdjustment

        private void GetPendingWarehouseAdjustmentDetails()
        {
            string queryString;

            queryString = " @LocationID Int, @GoodsReceiptID Int, @WarehouseAdjustmentID Int, @WarehouseID Int, @WarehouseAdjustmentDetailIDs varchar(3999), @IsReadonly bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "   BEGIN " + "\r\n";

            queryString = queryString + "       IF  (@WarehouseAdjustmentID <> 0) " + "\r\n";
            queryString = queryString + "           " + this.BuildSQLWarehouseAdjustment(true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           " + this.BuildSQLWarehouseAdjustment(false) + "\r\n";

            queryString = queryString + "   END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetPendingWarehouseAdjustmentDetails", queryString);
        }

        private string BuildSQLWarehouseAdjustment(bool isWarehouseAdjustmentID)
        {
            string queryString = "";
            queryString = queryString + "   BEGIN " + "\r\n";
            queryString = queryString + "       IF  (@WarehouseAdjustmentDetailIDs <> '') " + "\r\n";
            queryString = queryString + "           " + this.BuildSQLWarehouseAdjustmentWarehouseAdjustmentDetailIDs(isWarehouseAdjustmentID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           " + this.BuildSQLWarehouseAdjustmentWarehouseAdjustmentDetailIDs(isWarehouseAdjustmentID, false) + "\r\n";
            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        private string BuildSQLWarehouseAdjustmentWarehouseAdjustmentDetailIDs(bool isWarehouseAdjustmentID, bool isWarehouseAdjustmentDetailIDs)
        {
            string queryString = "";
            queryString = queryString + "   BEGIN " + "\r\n";

            queryString = queryString + "       IF (@GoodsReceiptID <= 0) " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   " + this.BuildSQLWarehouseAdjustmentNew(isWarehouseAdjustmentID, isWarehouseAdjustmentDetailIDs) + "\r\n";
            queryString = queryString + "                   ORDER BY WarehouseAdjustmentDetails.EntryDate, WarehouseAdjustmentDetails.WarehouseAdjustmentID, WarehouseAdjustmentDetails.WarehouseAdjustmentDetailID " + "\r\n";
            queryString = queryString + "               END " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";

            queryString = queryString + "               IF (@IsReadonly = 1) " + "\r\n";
            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       " + this.BuildSQLWarehouseAdjustmentEdit(isWarehouseAdjustmentID, isWarehouseAdjustmentDetailIDs) + "\r\n";
            queryString = queryString + "                       ORDER BY WarehouseAdjustmentDetails.EntryDate, WarehouseAdjustmentDetails.WarehouseAdjustmentID, WarehouseAdjustmentDetails.WarehouseAdjustmentDetailID " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "               ELSE " + "\r\n"; //FULL SELECT FOR EDIT MODE

            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       " + this.BuildSQLWarehouseAdjustmentNew(isWarehouseAdjustmentID, isWarehouseAdjustmentDetailIDs) + " WHERE WarehouseAdjustmentDetails.WarehouseAdjustmentDetailID NOT IN (SELECT WarehouseAdjustmentDetailID FROM GoodsReceiptDetails WHERE GoodsReceiptID = @GoodsReceiptID) " + "\r\n";
            queryString = queryString + "                       UNION ALL " + "\r\n";
            queryString = queryString + "                       " + this.BuildSQLWarehouseAdjustmentEdit(isWarehouseAdjustmentID, isWarehouseAdjustmentDetailIDs) + "\r\n";
            queryString = queryString + "                       ORDER BY WarehouseAdjustmentDetails.EntryDate, WarehouseAdjustmentDetails.WarehouseAdjustmentID, WarehouseAdjustmentDetails.WarehouseAdjustmentDetailID " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        private string BuildSQLWarehouseAdjustmentNew(bool isWarehouseAdjustmentID, bool isWarehouseAdjustmentDetailIDs)
        {
            string queryString = "";

            queryString = queryString + "       SELECT      WarehouseAdjustmentDetails.WarehouseAdjustmentID, WarehouseAdjustmentDetails.WarehouseAdjustmentDetailID, WarehouseAdjustmentDetails.Reference AS WarehouseAdjustmentReference, WarehouseAdjustmentDetails.EntryDate AS WarehouseAdjustmentEntryDate, " + "\r\n";
            queryString = queryString + "                   Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, WarehouseAdjustmentDetails.BatchID, WarehouseAdjustmentDetails.BatchEntryDate, WarehouseAdjustmentDetails.BinLocationID, BinLocations.Code AS BinLocationCode, WarehouseAdjustmentDetails.PackID, Packs.Code AS PackCode, WarehouseAdjustmentDetails.CartonID, Cartons.Code AS CartonCode, WarehouseAdjustmentDetails.PalletID, Pallets.Code AS PalletCode, " + "\r\n";
            queryString = queryString + "                   ROUND(WarehouseAdjustmentDetails.Quantity - WarehouseAdjustmentDetails.QuantityReceipt,  " + (int)GlobalEnums.rndQuantity + ") AS QuantityRemains, CAST(0 AS decimal(18, 2)) AS Quantity, ROUND(WarehouseAdjustmentDetails.LineVolume - WarehouseAdjustmentDetails.LineVolumeReceipt,  " + (int)GlobalEnums.rndVolume + ") AS LineVolumeRemains, WarehouseAdjustmentDetails.LineVolume, WarehouseAdjustmentDetails.PackCounts, WarehouseAdjustmentDetails.CartonCounts, WarehouseAdjustmentDetails.PalletCounts, WarehouseAdjustmentDetails.Remarks, CAST(1 AS bit) AS IsSelected " + "\r\n";

            queryString = queryString + "       FROM        WarehouseAdjustmentDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON " + (isWarehouseAdjustmentID ? " WarehouseAdjustmentDetails.WarehouseAdjustmentID = @WarehouseAdjustmentID " : "WarehouseAdjustmentDetails.LocationID = @LocationID AND WarehouseAdjustmentDetails.WarehouseID = @WarehouseID ") + " AND WarehouseAdjustmentDetails.Quantity > 0 AND ROUND(WarehouseAdjustmentDetails.Quantity - WarehouseAdjustmentDetails.QuantityReceipt, " + (int)GlobalEnums.rndQuantity + ") > 0 AND WarehouseAdjustmentDetails.CommodityID = Commodities.CommodityID " + (isWarehouseAdjustmentDetailIDs ? " AND WarehouseAdjustmentDetails.WarehouseAdjustmentDetailID NOT IN (SELECT Id FROM dbo.SplitToIntList (@WarehouseAdjustmentDetailIDs))" : "") + "\r\n";
            queryString = queryString + "                   INNER JOIN BinLocations ON WarehouseAdjustmentDetails.BinLocationID = BinLocations.BinLocationID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Packs ON WarehouseAdjustmentDetails.PackID = Packs.PackID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Cartons ON WarehouseAdjustmentDetails.CartonID = Cartons.CartonID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Pallets ON WarehouseAdjustmentDetails.PalletID = Pallets.PalletID " + "\r\n";

            return queryString;
        }

        private string BuildSQLWarehouseAdjustmentEdit(bool isWarehouseAdjustmentID, bool isWarehouseAdjustmentDetailIDs)
        {
            string queryString = "";

            queryString = queryString + "       SELECT      WarehouseAdjustmentDetails.WarehouseAdjustmentID, WarehouseAdjustmentDetails.WarehouseAdjustmentDetailID, WarehouseAdjustmentDetails.Reference AS WarehouseAdjustmentReference, WarehouseAdjustmentDetails.EntryDate AS WarehouseAdjustmentEntryDate, " + "\r\n";
            queryString = queryString + "                   Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, WarehouseAdjustmentDetails.BatchID, WarehouseAdjustmentDetails.BatchEntryDate, WarehouseAdjustmentDetails.BinLocationID, BinLocations.Code AS BinLocationCode, WarehouseAdjustmentDetails.PackID, Packs.Code AS PackCode, WarehouseAdjustmentDetails.CartonID, Cartons.Code AS CartonCode, WarehouseAdjustmentDetails.PalletID, Pallets.Code AS PalletCode, " + "\r\n";
            queryString = queryString + "                   ROUND(WarehouseAdjustmentDetails.Quantity - WarehouseAdjustmentDetails.QuantityReceipt + GoodsReceiptDetails.Quantity,  " + (int)GlobalEnums.rndQuantity + ") AS QuantityRemains, CAST(0 AS decimal(18, 2)) AS Quantity, ROUND(WarehouseAdjustmentDetails.LineVolume - WarehouseAdjustmentDetails.LineVolumeReceipt + GoodsReceiptDetails.LineVolume,  " + (int)GlobalEnums.rndVolume + ") AS LineVolumeRemains, WarehouseAdjustmentDetails.LineVolume, WarehouseAdjustmentDetails.PackCounts, WarehouseAdjustmentDetails.CartonCounts, WarehouseAdjustmentDetails.PalletCounts, WarehouseAdjustmentDetails.Remarks, CAST(1 AS bit) AS IsSelected " + "\r\n";

            queryString = queryString + "       FROM        WarehouseAdjustmentDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN GoodsReceiptDetails ON GoodsReceiptDetails.GoodsReceiptID = @GoodsReceiptID AND WarehouseAdjustmentDetails.WarehouseAdjustmentDetailID = GoodsReceiptDetails.WarehouseAdjustmentDetailID" + (isWarehouseAdjustmentDetailIDs ? " AND WarehouseAdjustmentDetails.WarehouseAdjustmentDetailID NOT IN (SELECT Id FROM dbo.SplitToIntList (@WarehouseAdjustmentDetailIDs))" : "") + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON WarehouseAdjustmentDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN BinLocations ON WarehouseAdjustmentDetails.BinLocationID = BinLocations.BinLocationID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Packs ON WarehouseAdjustmentDetails.PackID = Packs.PackID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Cartons ON WarehouseAdjustmentDetails.CartonID = Cartons.CartonID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Pallets ON WarehouseAdjustmentDetails.PalletID = Pallets.PalletID " + "\r\n";

            return queryString;
        }
        
        #endregion WarehouseAdjustment

        #endregion Y




    }

}

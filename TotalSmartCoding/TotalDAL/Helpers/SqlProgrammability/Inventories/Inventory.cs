﻿using System;
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
            //this.WarehouseJournals();
            //this.WarehouseForecasts();

            this.WarehouseLedgers();
        }



        //private void ABC()
        //{
        //    string queryString;

        //    queryString = " @FromDate DateTime, @ToDate DateTime " + "\r\n";
        //    queryString = queryString + " WITH ENCRYPTION " + "\r\n";
        //    queryString = queryString + " AS " + "\r\n";
        //    queryString = queryString + "    BEGIN " + "\r\n";

        //    queryString = queryString + "       IF (@FromDate) " + "\r\n";
        //    queryString = queryString + "       FROM        GoodsReceipts " + "\r\n";
        //    queryString = queryString + "                   INNER JOIN Locations ON GoodsReceipts.EntryDate >= @FromDate AND GoodsReceipts.EntryDate <= @ToDate AND GoodsReceipts.OrganizationalUnitID IN (SELECT OrganizationalUnitID FROM AccessControls WHERE UserID = @UserID AND NMVNTaskID = " + (int)TotalBase.Enums.GlobalEnums.NmvnTaskID.GoodsReceipt + " AND AccessControls.AccessLevel > 0) AND Locations.LocationID = GoodsReceipts.LocationID " + "\r\n";
        //    queryString = queryString + "                   INNER JOIN Warehouses ON GoodsReceipts.WarehouseID = Warehouses.WarehouseID " + "\r\n";
        //    queryString = queryString + "                   INNER JOIN GoodsReceiptTypes ON GoodsReceipts.GoodsReceiptTypeID = GoodsReceiptTypes.GoodsReceiptTypeID " + "\r\n";

        //    queryString = queryString + "    END " + "\r\n";

        //    this.totalSmartCodingEntities.CreateStoredProcedure("ABC", queryString);
        //}





        #region WarehouseJournals

        #region  DEFINE Switch Query

        private string DEFINEHeader(bool localParameter, int pendingForecast)
        {//pendingForecast: 0, 1: 
            string queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime, @QuantityVersusVolume int " + (pendingForecast == 0 || pendingForecast == 1 ? "" : ", @WithPending bit, @WithForecast bit") + ", @LocationIDs varchar(3999), @WarehouseIDs varchar(3999), @CommodityCategoryIDs varchar(3999), @CommodityTypeIDs varchar(3999), @CommodityIDs varchar(3999) " + "\r\n";

            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "       SET NOCOUNT ON; " + "\r\n";

            if (localParameter)
            {
                queryString = queryString + "       DECLARE     @LocalUserID Int, @LocalFromDate DateTime, @LocalToDate DateTime, @LocalQuantityVersusVolume int " + (pendingForecast == 0 || pendingForecast == 1 ? "" : ", @LocalWithPending bit, @LocalWithForecast bit") + ", @LocalLocationIDs varchar(3999), @LocalWarehouseIDs varchar(3999), @LocalCommodityCategoryIDs varchar(3999), @LocalCommodityTypeIDs varchar(3999), @LocalCommodityIDs varchar(3999) " + "\r\n";

                queryString = queryString + "       SET         @LocalUserID = @UserID                                              SET @LocalFromDate = @FromDate                          SET @LocalToDate = @ToDate  " + "\r\n";

                queryString = queryString + "       SET         @LocalQuantityVersusVolume = @QuantityVersusVolume                  " + (pendingForecast == 0 || pendingForecast == 1 ? "" : "SET @LocalWithPending = @WithPending                    SET @LocalWithForecast = @WithForecast ") + "\r\n";

                queryString = queryString + "       SET         @LocalLocationIDs = @LocationIDs                                    SET @LocalWarehouseIDs = @WarehouseIDs                  " + "\r\n";
                queryString = queryString + "       SET         @LocalCommodityCategoryIDs = @CommodityCategoryIDs                  SET @LocalCommodityTypeIDs = @CommodityTypeIDs          SET @LocalCommodityIDs = @CommodityIDs              " + "\r\n";
            }

            return queryString;
        }

        private string DEFINEParameter(bool localParameter, int pendingForecast)
        {
            return " @" + (localParameter ? "Local" : "") + "UserID, @" + (localParameter ? "Local" : "") + "FromDate, @" + (localParameter ? "Local" : "") + "ToDate, @" + (localParameter ? "Local" : "") + "QuantityVersusVolume " + (pendingForecast == 0 ? ", 0, 0" : (pendingForecast == 1 ? ", 1, 1" : ", @" + (localParameter ? "Local" : "") + "WithPending, @" + (localParameter ? "Local" : "") + "WithForecast")) + ", @" + (localParameter ? "Local" : "") + "LocationIDs, @" + (localParameter ? "Local" : "") + "WarehouseIDs, @" + (localParameter ? "Local" : "") + "CommodityCategoryIDs, @" + (localParameter ? "Local" : "") + "CommodityTypeIDs, @" + (localParameter ? "Local" : "") + "CommodityIDs ";
        }

        private void WarehouseForecasts()
        {
            string queryString = this.DEFINEHeader(true, 1);
            queryString = queryString + "       DECLARE     @WarehouseForecasts TABLE (LocationID int NOT NULL, LocationName nvarchar(50) NOT NULL, WarehouseID int NULL, WarehouseName nvarchar(60) NULL, BinLocationID int NULL, BinLocationCode nvarchar(50) NULL, BatchEntryDate datetime NULL, CommodityCategoryID int NOT NULL, CommodityCategoryName nvarchar(100) NOT NULL, CommodityID int NOT NULL, Code nvarchar(50) NOT NULL, Name nvarchar(200) NOT NULL, Unit nvarchar(10) NULL, PackageSize nvarchar(60) NULL, Barcode nvarchar(50) NULL, BarcodeUnit nvarchar(20) NULL, GoodsReceiptDetailID	int NULL, EntryDate	datetime NULL, LineReferences nvarchar(100) NULL, ValueBegin decimal(18, 2) NOT NULL, ValueReceiptPickup decimal(18, 2) NOT NULL, ValueReceiptPurchasing decimal(18, 2) NOT NULL, ValueReceiptTransfer decimal(18, 2) NOT NULL, ValueReceiptReturn decimal(18, 2) NOT NULL, ValueReceiptAdjustment decimal(18, 2) NOT NULL, ValueReceipt decimal(18, 2) NOT NULL, ValueIssueSelling decimal(18, 2) NOT NULL, ValueIssueTransfer decimal(18, 2) NOT NULL, ValueIssueProduction decimal(18, 2) NOT NULL, ValueIssueAdjustment decimal(18, 2) NOT NULL, ValueIssue decimal(18, 2) NOT NULL, ValueEnd decimal(18, 2) NOT NULL, ValueOnPurchasing decimal(18, 2) NOT NULL, ValueOnPickup decimal(18, 2) NOT NULL, ValueOnTransit decimal(18, 2) NOT NULL, ValuePendingOrder decimal(18, 2) NOT NULL, ValuePendingAdvice decimal(18, 2) NOT NULL, ValueForecasts decimal(18, 2) NOT NULL, ValueM1Forecasts decimal(18, 2) NOT NULL, ValueM2Forecasts decimal(18, 2) NOT NULL, ValueM3Forecasts decimal(18, 2) NOT NULL, MovementMIN decimal(18, 2) NOT NULL, MovementMAX decimal(18, 2) NOT NULL, MovementAVG decimal(18, 2) NOT NULL) " + "\r\n";
            queryString = queryString + "       INSERT INTO @WarehouseForecasts         EXEC WarehouseJournals " + this.DEFINEParameter(true, 1) + "\r\n";

            queryString = queryString + "       DECLARE     @M1Firstdate Datetime = DATEADD(MONTH, 1, DATEFROMPARTS (YEAR(@ToDate), MONTH(@ToDate), 1))     DECLARE @M3Lastdate Datetime = DATEADD(DAY, -1, DATEADD(MONTH, 3, @M1Firstdate))            DECLARE @M1M3Datediff Int = DATEDIFF(DAY, @M1Firstdate, @M3Lastdate) + 1 " + "\r\n";

            queryString = queryString + "       SELECT      LocationID, LocationName, WarehouseID, WarehouseName, BinLocationID, BinLocationCode, BatchEntryDate, CommodityCategoryID, CommodityCategoryName, CommodityID, Code, Name, Unit, PackageSize, Barcode, BarcodeUnit, GoodsReceiptDetailID, EntryDate, LineReferences, ValueBegin, ValueReceiptPickup, ValueReceiptPurchasing, ValueReceiptTransfer, ValueReceiptReturn, ValueReceiptAdjustment, ValueReceipt, ValueIssueSelling, ValueIssueTransfer, ValueIssueProduction, ValueIssueAdjustment, ValueIssue, ValueEnd, ValueOnPurchasing, ValueOnPickup, ValueOnTransit, ValuePendingOrder, ValuePendingAdvice, ValueForecasts, ValueM1Forecasts, ValueM2Forecasts, ValueM3Forecasts, MovementMIN, MovementMAX, MovementAVG,  " + "\r\n";
            queryString = queryString + "                   (ValueOnPurchasing + ValueOnPickup + ValueOnTransit) AS ValueOnReceipt, (ValueEnd + ValueOnPurchasing + ValueOnPickup + ValueOnTransit) AS ValueInventory, (ValuePendingOrder + ValuePendingAdvice) AS ValueReserve, (ValueEnd + ValueOnPurchasing + ValueOnPickup + ValueOnTransit) - (ValuePendingOrder + ValuePendingAdvice) AS ValueStock, ValueEnd - (ValuePendingOrder + ValuePendingAdvice) AS ValueAvailable, CASE WHEN ValueM1Forecasts + ValueM2Forecasts + ValueM3Forecasts <> 0 THEN (  ((ValueEnd + ValueOnPurchasing + ValueOnPickup + ValueOnTransit) - (ValuePendingOrder + ValuePendingAdvice))/ ((ValueM1Forecasts + ValueM2Forecasts + ValueM3Forecasts) / @M1M3Datediff)  )  ELSE 0 END AS DIOH3M " + "\r\n"; //[OnHand = ValueEnd] [ValueOnReceipt = ValueOnPurchasing + ValueOnPickup + ValueOnTransit] [ValueInventory = ValueEnd + ValueOnReceipt] [ValueStock = ValueInventory - ValueReserve] [ValueAvailable =  ValueEnd - ValueReserve] [DIOH3M = ValueStock / ((ValueM1Forecasts + ValueM2Forecasts + ValueM3Forecasts)/ 90)]
            queryString = queryString + "       FROM        @WarehouseForecasts " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("WarehouseForecasts", queryString);
        }

        private void WarehouseJournals()
        {
            this.WarehouseJournal02();

            string queryString = this.DEFINEHeader(true, 9) + this.DEFINEQuantityVersusVolume() + "\r\n";
            this.totalSmartCodingEntities.CreateStoredProcedure("WarehouseJournals", queryString);
        }

        private string DEFINEQuantityVersusVolume()
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF (@LocalFromDate > @LocalToDate) " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               DECLARE     @msg NVARCHAR(300) = N'Chọn sai ngày. Vui lòng kiểm tra lại trước khi tiếp tục.' ; " + "\r\n";
            queryString = queryString + "               THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";


            queryString = queryString + "       IF         (@LocalQuantityVersusVolume = 0) " + "\r\n";
            queryString = queryString + "                   " + this.DEFINELocation(true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.DEFINELocation(false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string DEFINELocation(bool isQuantityVersusVolume)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@LocalLocationIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.DEFINEWarehouse(isQuantityVersusVolume, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.DEFINEWarehouse(isQuantityVersusVolume, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string DEFINEWarehouse(bool isQuantityVersusVolume, bool isLocationID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@LocalWarehouseIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.DEFINEPending(isQuantityVersusVolume, isLocationID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.DEFINEPending(isQuantityVersusVolume, isLocationID, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }


        private string DEFINEPending(bool isQuantityVersusVolume, bool isLocationID, bool isWarehouseID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@LocalWithPending = 1) " + "\r\n";
            queryString = queryString + "                   " + this.DEFINEForecast(isQuantityVersusVolume, isLocationID, isWarehouseID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.DEFINEForecast(isQuantityVersusVolume, isLocationID, isWarehouseID, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string DEFINEForecast(bool isQuantityVersusVolume, bool isLocationID, bool isWarehouseID, bool isPending)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@LocalWithForecast = 1) " + "\r\n";
            queryString = queryString + "                   EXEC WarehouseJournal02" + isQuantityVersusVolume.ToString().Substring(0, 1) + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isPending.ToString().Substring(0, 1) + true.ToString().Substring(0, 1) + this.DEFINEParameter(false, 9) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   EXEC WarehouseJournal02" + isQuantityVersusVolume.ToString().Substring(0, 1) + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isPending.ToString().Substring(0, 1) + false.ToString().Substring(0, 1) + this.DEFINEParameter(false, 9) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private void WarehouseJournal02()
        {
            bool[] boolArray = new bool[2] { true, false };

            foreach (bool isQuantityVersusVolume in boolArray)
            {
                foreach (bool isLocationID in boolArray)
                {
                    foreach (bool isWarehouseID in boolArray)
                    {
                        foreach (bool isPending in boolArray)
                        {
                            foreach (bool isForecast in boolArray)
                            {
                                this.totalSmartCodingEntities.CreateStoredProcedure("WarehouseJournal02" + isQuantityVersusVolume.ToString().Substring(0, 1) + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isPending.ToString().Substring(0, 1) + isForecast.ToString().Substring(0, 1), this.DEFINEHeader(false, 9) + this.DEFINECommodityCategory(isQuantityVersusVolume, isLocationID, isWarehouseID, isPending, isForecast));
                            }
                        }
                    }
                }
            }
        }

        private string DEFINECommodityCategory(bool isQuantityVersusVolume, bool isLocationID, bool isWarehouseID, bool isPending, bool isForecast)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@CommodityCategoryIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.DEFINECommodity(isQuantityVersusVolume, isLocationID, isWarehouseID, isPending, isForecast, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.DEFINECommodity(isQuantityVersusVolume, isLocationID, isWarehouseID, isPending, isForecast, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string DEFINECommodity(bool isQuantityVersusVolume, bool isLocationID, bool isWarehouseID, bool isPending, bool isForecast, bool isCommodityCategoryID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@CommodityIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.DEFINECommodityType(isQuantityVersusVolume, isLocationID, isWarehouseID, isPending, isForecast, isCommodityCategoryID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.DEFINECommodityType(isQuantityVersusVolume, isLocationID, isWarehouseID, isPending, isForecast, isCommodityCategoryID, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string DEFINECommodityType(bool isQuantityVersusVolume, bool isLocationID, bool isWarehouseID, bool isPending, bool isForecast, bool isCommodityCategoryID, bool isCommodityID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@CommodityTypeIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.DEFINESameFromToDate(isQuantityVersusVolume, isLocationID, isWarehouseID, isPending, isForecast, isCommodityCategoryID, isCommodityID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.DEFINESameFromToDate(isQuantityVersusVolume, isLocationID, isWarehouseID, isPending, isForecast, isCommodityCategoryID, isCommodityID, false) + "\r\n";


            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }


        private string DEFINESameFromToDate(bool isQuantityVersusVolume, bool isLocationID, bool isWarehouseID, bool isPending, bool isForecast, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@FromDate = @ToDate) " + "\r\n";
            queryString = queryString + "                   " + this.DEFINEWarehouseJournal(isQuantityVersusVolume, isLocationID, isWarehouseID, isPending, isForecast, isCommodityCategoryID, isCommodityID, isCommodityTypeID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.DEFINEWarehouseJournal(isQuantityVersusVolume, isLocationID, isWarehouseID, isPending, isForecast, isCommodityCategoryID, isCommodityID, isCommodityTypeID, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }


        #endregion DEFINE Switch Query

        #region Actual DEFINE WarehouseJournal

        private string DEFINEWarehouseJournal(bool isQ, bool isLocationID, bool isWarehouseID, bool isPending, bool isForecast, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID, bool isSameFromToDate)
        {
            //WHEN isSameFromToDate == TRUE => WE SHOULD GET THE Begin IS THE END OF @FromDate (THIS IS THE SAME THE END OF @ToDate - THE ENDING VALUE ===> ValueBegin = ValueEnd). IN THIS CASE: WE DON'T GET THE Input, ALSO DON'T GET THE Output
            //PLEASE LOOK AT isSameFromToDate TO SEE WHAT DIFFERENT IS!!!
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      WarehouseJournalDetails.LocationID, Locations.Name AS LocationName, WarehouseJournalDetails.WarehouseID, Warehouses.Name AS WarehouseName, WarehouseJournalDetails.BinLocationID, BinLocations.Code AS BinLocationCode, WarehouseJournalDetails.BatchEntryDate, " + "\r\n";
            queryString = queryString + "                   CommodityCategories.CommodityCategoryID, CommodityCategories.Name AS CommodityCategoryName, Commodities.CommodityID, Commodities.Code, Commodities.Name, Commodities.Unit, Commodities.PackageSize, ISNULL(Pallets.Code, ISNULL(Cartons.Code, ISNULL(Packs.Code, ''))) AS Barcode, CASE WHEN NOT WarehouseJournalDetails.PalletID IS NULL THEN N'Pallet' WHEN NOT WarehouseJournalDetails.CartonID IS NULL THEN N'Carton'  WHEN NOT WarehouseJournalDetails.PackID IS NULL THEN N'Pack' ELSE '' END AS BarcodeUnit, " + "\r\n";
            queryString = queryString + "                   WarehouseJournalDetails.GoodsReceiptDetailID, WarehouseJournalDetails.EntryDate, ISNULL('Production: ' + ' ' + Pickups.Reference, ISNULL('From: ' + ' ' + SourceWarehouses.Name + ', ' + GoodsIssues.VoucherCodes, ISNULL(WarehouseAdjustmentTypes.Name  + ' ' + WarehouseAdjustments.AdjustmentJobs, ''))) AS LineReferences, " + "\r\n";

            queryString = queryString + "                   WarehouseJournalDetails." + Quantity(isQ) + "Begin AS ValueBegin, WarehouseJournalDetails." + Quantity(isQ) + "ReceiptPickup AS ValueReceiptPickup, WarehouseJournalDetails." + Quantity(isQ) + "ReceiptPurchasing AS ValueReceiptPurchasing, WarehouseJournalDetails." + Quantity(isQ) + "ReceiptTransfer AS ValueReceiptTransfer, WarehouseJournalDetails." + Quantity(isQ) + "ReceiptReturn AS ValueReceiptReturn, WarehouseJournalDetails." + Quantity(isQ) + "ReceiptAdjustment AS ValueReceiptAdjustment, WarehouseJournalDetails." + Quantity(isQ) + "ReceiptPickup + WarehouseJournalDetails." + Quantity(isQ) + "ReceiptPurchasing + WarehouseJournalDetails." + Quantity(isQ) + "ReceiptTransfer + WarehouseJournalDetails." + Quantity(isQ) + "ReceiptReturn + WarehouseJournalDetails." + Quantity(isQ) + "ReceiptAdjustment AS ValueReceipt, " + "\r\n";
            queryString = queryString + "                   WarehouseJournalDetails." + Quantity(isQ) + "IssueSelling AS ValueIssueSelling, WarehouseJournalDetails." + Quantity(isQ) + "IssueTransfer AS ValueIssueTransfer, WarehouseJournalDetails." + Quantity(isQ) + "IssueProduction AS ValueIssueProduction, WarehouseJournalDetails." + Quantity(isQ) + "IssueAdjustment AS ValueIssueAdjustment, WarehouseJournalDetails." + Quantity(isQ) + "IssueSelling + WarehouseJournalDetails." + Quantity(isQ) + "IssueTransfer + WarehouseJournalDetails." + Quantity(isQ) + "IssueProduction + WarehouseJournalDetails." + Quantity(isQ) + "IssueAdjustment AS ValueIssue, " + "\r\n";
            queryString = queryString + "                   WarehouseJournalDetails." + Quantity(isQ) + "Begin + WarehouseJournalDetails." + Quantity(isQ) + "ReceiptPickup + WarehouseJournalDetails." + Quantity(isQ) + "ReceiptPurchasing + WarehouseJournalDetails." + Quantity(isQ) + "ReceiptTransfer + WarehouseJournalDetails." + Quantity(isQ) + "ReceiptReturn + WarehouseJournalDetails." + Quantity(isQ) + "ReceiptAdjustment - WarehouseJournalDetails." + Quantity(isQ) + "IssueSelling - WarehouseJournalDetails." + Quantity(isQ) + "IssueTransfer - WarehouseJournalDetails." + Quantity(isQ) + "IssueProduction - WarehouseJournalDetails." + Quantity(isQ) + "IssueAdjustment AS ValueEnd, " + "\r\n";
            queryString = queryString + "                   WarehouseJournalDetails." + Quantity(isQ) + "OnPurchasing AS ValueOnPurchasing, WarehouseJournalDetails." + Quantity(isQ) + "OnPickup AS ValueOnPickup, WarehouseJournalDetails." + Quantity(isQ) + "OnTransit AS ValueOnTransit, " + "\r\n";

            queryString = queryString + "                   WarehouseJournalDetails." + Quantity(isQ) + "PendingOrder AS ValuePendingOrder, WarehouseJournalDetails." + Quantity(isQ) + "PendingAdvice AS ValuePendingAdvice, WarehouseJournalDetails." + Quantity(isQ) + "Forecasts AS ValueForecasts, WarehouseJournalDetails." + Quantity(isQ) + "M1Forecasts AS ValueM1Forecasts, WarehouseJournalDetails." + Quantity(isQ) + "M2Forecasts AS ValueM2Forecasts, WarehouseJournalDetails." + Quantity(isQ) + "M3Forecasts AS ValueM3Forecasts, " + "\r\n";

            queryString = queryString + "                   WarehouseJournalDetails.MovementMIN, WarehouseJournalDetails.MovementMAX, WarehouseJournalDetails.MovementAVG " + "\r\n";


            queryString = queryString + "       FROM       (" + "\r\n";

            //--BEGIN-INPUT-OUTPUT-END.END
            queryString = queryString + "                   SELECT  GoodsReceiptDetails.EntryDate, GoodsReceiptDetails.GoodsReceiptDetailID, GoodsReceiptDetails.CommodityID, GoodsReceiptDetails.BatchEntryDate, GoodsReceiptDetails.LocationID, GoodsReceiptDetails.WarehouseID, GoodsReceiptDetails.BinLocationID, GoodsReceiptDetails.PickupID, GoodsReceiptDetails.GoodsIssueID, GoodsReceiptDetails.WarehouseAdjustmentID, GoodsReceiptDetails.PackID, GoodsReceiptDetails.CartonID, GoodsReceiptDetails.PalletID, " + "\r\n";
            queryString = queryString + "                           GoodsReceiptDetailUnionMasters." + Quantity(isQ) + "Begin, GoodsReceiptDetailUnionMasters." + Quantity(isQ) + "ReceiptPickup, GoodsReceiptDetailUnionMasters." + Quantity(isQ) + "ReceiptPurchasing, GoodsReceiptDetailUnionMasters." + Quantity(isQ) + "ReceiptTransfer, GoodsReceiptDetailUnionMasters." + Quantity(isQ) + "ReceiptReturn, GoodsReceiptDetailUnionMasters." + Quantity(isQ) + "ReceiptAdjustment, GoodsReceiptDetailUnionMasters." + Quantity(isQ) + "IssueSelling, GoodsReceiptDetailUnionMasters." + Quantity(isQ) + "IssueTransfer, GoodsReceiptDetailUnionMasters." + Quantity(isQ) + "IssueProduction, GoodsReceiptDetailUnionMasters." + Quantity(isQ) + "IssueAdjustment, 0 AS " + Quantity(isQ) + "OnPurchasing, 0 AS " + Quantity(isQ) + "OnPickup, 0 AS " + Quantity(isQ) + "OnTransit, 0 AS " + Quantity(isQ) + "PendingOrder, 0 AS " + Quantity(isQ) + "PendingAdvice, 0 AS " + Quantity(isQ) + "Forecasts, 0 AS " + Quantity(isQ) + "M1Forecasts, 0 AS " + Quantity(isQ) + "M2Forecasts, 0 AS " + Quantity(isQ) + "M3Forecasts, GoodsReceiptDetailUnionMasters.MovementMIN, GoodsReceiptDetailUnionMasters.MovementMAX, GoodsReceiptDetailUnionMasters.MovementAVG " + "\r\n";


            queryString = queryString + "                   FROM   (" + "\r\n";
            queryString = queryString + "                           SELECT  GoodsReceiptDetailUnions.GoodsReceiptDetailID, " + "\r\n";
            queryString = queryString + "                                   SUM(" + Quantity(isQ) + "Begin) AS " + Quantity(isQ) + "Begin, SUM(" + Quantity(isQ) + "ReceiptPickup) AS " + Quantity(isQ) + "ReceiptPickup, SUM(" + Quantity(isQ) + "ReceiptPurchasing) AS " + Quantity(isQ) + "ReceiptPurchasing, SUM(" + Quantity(isQ) + "ReceiptTransfer) AS " + Quantity(isQ) + "ReceiptTransfer, SUM(" + Quantity(isQ) + "ReceiptReturn) AS " + Quantity(isQ) + "ReceiptReturn, SUM(" + Quantity(isQ) + "ReceiptAdjustment) AS " + Quantity(isQ) + "ReceiptAdjustment, " + "\r\n";
            queryString = queryString + "                                   SUM(" + Quantity(isQ) + "IssueSelling) AS " + Quantity(isQ) + "IssueSelling, SUM(" + Quantity(isQ) + "IssueTransfer) AS " + Quantity(isQ) + "IssueTransfer, SUM(" + Quantity(isQ) + "IssueProduction) AS " + Quantity(isQ) + "IssueProduction, SUM(" + Quantity(isQ) + "IssueAdjustment) AS " + Quantity(isQ) + "IssueAdjustment, " + "\r\n";
            queryString = queryString + "                                   MIN(MovementDate) AS MovementMIN, MAX(MovementDate) AS MovementMAX, 0 AS MovementAVG " + "\r\n"; //SUM((" + Quantity(isQuantityVersusVolume) + "IssueSelling + " + Quantity(isQuantityVersusVolume) + "IssueTransfer + " + Quantity(isQuantityVersusVolume) + "IssueProduction + " + Quantity(isQuantityVersusVolume) + "IssueAdjustment) * MovementDate) / SUM(" + Quantity(isQuantityVersusVolume) + "IssueSelling + " + Quantity(isQuantityVersusVolume) + "IssueTransfer + " + Quantity(isQuantityVersusVolume) + "IssueProduction + " + Quantity(isQuantityVersusVolume) + "IssueAdjustment)  AS MovementAVG
            queryString = queryString + "                           FROM    (" + "\r\n";


            //1.BEGINING
            //  BEGINING.GoodsReceipts
            queryString = queryString + "                                   SELECT      GoodsReceiptDetails.GoodsReceiptDetailID, ROUND(GoodsReceiptDetails." + Quantity(isQ) + " - GoodsReceiptDetails." + Quantity(isQ) + "Issue, " + (int)GlobalEnums.rndQuantity + ") AS " + Quantity(isQ) + "Begin, 0 AS " + Quantity(isQ) + "ReceiptPickup, 0 AS " + Quantity(isQ) + "ReceiptPurchasing, 0 AS " + Quantity(isQ) + "ReceiptTransfer, 0 AS " + Quantity(isQ) + "ReceiptReturn, 0 AS " + Quantity(isQ) + "ReceiptAdjustment, 0 AS " + Quantity(isQ) + "IssueSelling, 0 AS " + Quantity(isQ) + "IssueTransfer, 0 AS " + Quantity(isQ) + "IssueProduction, 0 AS " + Quantity(isQ) + "IssueAdjustment, 0 AS MovementDate " + "\r\n"; //NULL AS MovementDate
            queryString = queryString + "                                   FROM        GoodsReceiptDetails " + "\r\n";
            queryString = queryString + "                                   WHERE       GoodsReceiptDetails.EntryDate " + (!isSameFromToDate ? "<" : "<=") + " @FromDate AND GoodsReceiptDetails." + Quantity(isQ) + " > GoodsReceiptDetails." + Quantity(isQ) + "Issue " + this.DEFINEFilterLW(isLocationID, isWarehouseID, "GoodsReceiptDetails") + "\r\n";

            queryString = queryString + "                                   UNION ALL " + "\r\n";
            //  BEGINING.UNDO (CAC CAU SQL CHO GoodsIssues, WarehouseAdjustments LA HOAN TOAN GIONG NHAU. LUU Y T/H DAT BIET: WarehouseAdjustments." + Quantity(isQuantityVersusVolume) + " < 0)
            //  BEGINING.UNDO.GoodsIssues
            queryString = queryString + "                                   SELECT      GoodsReceiptDetails.GoodsReceiptDetailID, GoodsIssueDetails." + Quantity(isQ) + " AS " + Quantity(isQ) + "Begin, 0 AS " + Quantity(isQ) + "ReceiptPickup, 0 AS " + Quantity(isQ) + "ReceiptPurchasing, 0 AS " + Quantity(isQ) + "ReceiptTransfer, 0 AS " + Quantity(isQ) + "ReceiptReturn, 0 AS " + Quantity(isQ) + "ReceiptAdjustment, 0 AS " + Quantity(isQ) + "IssueSelling, 0 AS " + Quantity(isQ) + "IssueTransfer, 0 AS " + Quantity(isQ) + "IssueProduction, 0 AS " + Quantity(isQ) + "IssueAdjustment, 0 AS MovementDate " + "\r\n"; //NULL AS MovementDate
            queryString = queryString + "                                   FROM        GoodsReceiptDetails INNER JOIN " + "\r\n";
            queryString = queryString + "                                               GoodsIssueDetails ON GoodsReceiptDetails.GoodsReceiptDetailID = GoodsIssueDetails.GoodsReceiptDetailID AND GoodsReceiptDetails.EntryDate " + (!isSameFromToDate ? "<" : "<=") + " @FromDate AND GoodsIssueDetails.EntryDate " + (!isSameFromToDate ? ">=" : ">") + " @FromDate " + this.DEFINEFilterLW(isLocationID, isWarehouseID, "GoodsReceiptDetails") + "\r\n";

            queryString = queryString + "                                   UNION ALL " + "\r\n";
            //  BEGINING.UNDO.WarehouseAdjustments
            queryString = queryString + "                                   SELECT      GoodsReceiptDetails.GoodsReceiptDetailID, -WarehouseAdjustmentDetails." + Quantity(isQ) + " AS " + Quantity(isQ) + "Begin, 0 AS " + Quantity(isQ) + "ReceiptPickup, 0 AS " + Quantity(isQ) + "ReceiptPurchasing, 0 AS " + Quantity(isQ) + "ReceiptTransfer, 0 AS " + Quantity(isQ) + "ReceiptReturn, 0 AS " + Quantity(isQ) + "ReceiptAdjustment, 0 AS " + Quantity(isQ) + "IssueSelling, 0 AS " + Quantity(isQ) + "IssueTransfer, 0 AS " + Quantity(isQ) + "IssueProduction, 0 AS " + Quantity(isQ) + "IssueAdjustment, 0 AS MovementDate " + "\r\n"; //NULL AS MovementDate
            queryString = queryString + "                                   FROM        GoodsReceiptDetails INNER JOIN " + "\r\n";
            queryString = queryString + "                                               WarehouseAdjustmentDetails ON GoodsReceiptDetails.GoodsReceiptDetailID = WarehouseAdjustmentDetails.GoodsReceiptDetailID AND GoodsReceiptDetails.EntryDate " + (!isSameFromToDate ? "<" : "<=") + " @FromDate AND WarehouseAdjustmentDetails.EntryDate " + (!isSameFromToDate ? ">=" : ">") + " @FromDate AND WarehouseAdjustmentDetails." + Quantity(isQ) + " < 0 " + this.DEFINEFilterLW(isLocationID, isWarehouseID, "GoodsReceiptDetails") + "\r\n";



            if (!isSameFromToDate)
            {
                //2.INTPUT
                queryString = queryString + "                               UNION ALL " + "\r\n";
                queryString = queryString + "                               SELECT      GoodsReceiptDetails.GoodsReceiptDetailID, 0 AS " + Quantity(isQ) + "Begin, " + "\r\n";
                queryString = queryString + "                                           CASE WHEN GoodsReceiptDetails.GoodsReceiptTypeID = " + (int)GlobalEnums.GoodsReceiptTypeID.Pickup + " THEN GoodsReceiptDetails." + Quantity(isQ) + " ELSE 0 END AS " + Quantity(isQ) + "ReceiptPickup, " + "\r\n";
                queryString = queryString + "                                           CASE WHEN GoodsReceiptDetails.GoodsReceiptTypeID = " + (int)GlobalEnums.GoodsReceiptTypeID.PurchaseInvoice + " THEN GoodsReceiptDetails." + Quantity(isQ) + " ELSE 0 END AS " + Quantity(isQ) + "ReceiptPurchasing, " + "\r\n";
                queryString = queryString + "                                           CASE WHEN GoodsReceiptDetails.GoodsReceiptTypeID = " + (int)GlobalEnums.GoodsReceiptTypeID.GoodsIssueTransfer + " THEN GoodsReceiptDetails." + Quantity(isQ) + " ELSE 0 END AS " + Quantity(isQ) + "ReceiptTransfer, " + "\r\n";
                queryString = queryString + "                                           CASE WHEN GoodsReceiptDetails.GoodsReceiptTypeID = " + (int)GlobalEnums.GoodsReceiptTypeID.SalesReturn + " THEN GoodsReceiptDetails." + Quantity(isQ) + " ELSE 0 END AS " + Quantity(isQ) + "ReceiptReturn, " + "\r\n";
                queryString = queryString + "                                           CASE WHEN GoodsReceiptDetails.GoodsReceiptTypeID = " + (int)GlobalEnums.GoodsReceiptTypeID.WarehouseAdjustments + " THEN GoodsReceiptDetails." + Quantity(isQ) + " ELSE 0 END AS " + Quantity(isQ) + "ReceiptAdjustment, " + "\r\n";
                queryString = queryString + "                                           0 AS " + Quantity(isQ) + "IssueSelling, 0 AS " + Quantity(isQ) + "IssueTransfer, 0 AS " + Quantity(isQ) + "IssueProduction, 0 AS " + Quantity(isQ) + "IssueAdjustment, 0 AS MovementDate " + "\r\n"; //NULL AS MovementDate
                queryString = queryString + "                               FROM        GoodsReceiptDetails " + "\r\n";
                queryString = queryString + "                               WHERE       GoodsReceiptDetails.EntryDate >= @FromDate AND GoodsReceiptDetails.EntryDate <= @ToDate  " + this.DEFINEFilterLW(isLocationID, isWarehouseID, "GoodsReceiptDetails") + "\r\n";



                //3.OUTPUT (CAC CAU SQL CHO GoodsIssues, WarehouseAdjustments LA HOAN TOAN GIONG NHAU. LUU Y T/H DAT BIET: WarehouseAdjustments." + Quantity(isQuantityVersusVolume) + " < 0)
                queryString = queryString + "                               UNION ALL " + "\r\n";
                //GoodsIssueDetails + "\r\n";
                queryString = queryString + "                               SELECT      GoodsIssueDetails.GoodsReceiptDetailID, 0 AS " + Quantity(isQ) + "Begin, 0 AS " + Quantity(isQ) + "ReceiptPickup, 0 AS " + Quantity(isQ) + "ReceiptPurchasing, 0 AS " + Quantity(isQ) + "ReceiptTransfer, 0 AS " + Quantity(isQ) + "ReceiptReturn, 0 AS " + Quantity(isQ) + "ReceiptAdjustment, CASE WHEN DeliveryAdviceDetailID IS NULL THEN 0 ELSE GoodsIssueDetails." + Quantity(isQ) + " END AS " + Quantity(isQ) + "IssueSelling, CASE WHEN TransferOrderDetailID IS NULL THEN 0 ELSE GoodsIssueDetails." + Quantity(isQ) + " END AS " + Quantity(isQ) + "IssueTransfer, 0 AS " + Quantity(isQ) + "IssueProduction, 0 AS " + Quantity(isQ) + "IssueAdjustment, 0 AS MovementDate " + "\r\n"; //DATEDIFF(DAY, GoodsReceiptDetails.EntryDate, GoodsIssueDetails.EntryDate) AS MovementDate
                queryString = queryString + "                               FROM        GoodsIssueDetails " + "\r\n";
                queryString = queryString + "                               WHERE       GoodsIssueDetails.EntryDate >= @FromDate AND GoodsIssueDetails.EntryDate <= @ToDate  " + this.DEFINEFilterLW(isLocationID, isWarehouseID, "GoodsIssueDetails") + "\r\n";

                queryString = queryString + "                               UNION ALL " + "\r\n";
                //WarehouseAdjustmentDetails
                queryString = queryString + "                               SELECT      WarehouseAdjustmentDetails.GoodsReceiptDetailID, 0 AS " + Quantity(isQ) + "Begin, 0 AS " + Quantity(isQ) + "ReceiptPickup, 0 AS " + Quantity(isQ) + "ReceiptPurchasing, 0 AS " + Quantity(isQ) + "ReceiptTransfer, 0 AS " + Quantity(isQ) + "ReceiptReturn, 0 AS " + Quantity(isQ) + "ReceiptAdjustment, 0 AS " + Quantity(isQ) + "IssueSelling, 0 AS " + Quantity(isQ) + "IssueTransfer, CASE WHEN WarehouseAdjustmentTypeID = " + (int)GlobalEnums.WarehouseAdjustmentTypeID.ReturnToProduction + " THEN -WarehouseAdjustmentDetails." + Quantity(isQ) + " ELSE 0 END AS " + Quantity(isQ) + "IssueProduction, CASE WHEN WarehouseAdjustmentTypeID <> " + (int)GlobalEnums.WarehouseAdjustmentTypeID.ReturnToProduction + " THEN -WarehouseAdjustmentDetails." + Quantity(isQ) + " ELSE 0 END AS " + Quantity(isQ) + "IssueAdjustment, 0 AS MovementDate " + "\r\n"; //DATEDIFF(DAY, GoodsReceiptDetails.EntryDate, WarehouseAdjustmentDetails.EntryDate) AS MovementDate
                queryString = queryString + "                               FROM        WarehouseAdjustmentDetails " + "\r\n";
                queryString = queryString + "                               WHERE       WarehouseAdjustmentDetails.EntryDate >= @FromDate AND WarehouseAdjustmentDetails.EntryDate <= @ToDate  AND WarehouseAdjustmentDetails." + Quantity(isQ) + " < 0 " + this.DEFINEFilterLW(isLocationID, isWarehouseID, "WarehouseAdjustmentDetails") + "\r\n";
            }

            queryString = queryString + "                                   ) AS GoodsReceiptDetailUnions " + "\r\n";
            queryString = queryString + "                           GROUP BY GoodsReceiptDetailUnions.GoodsReceiptDetailID " + "\r\n";
            queryString = queryString + "                           ) AS GoodsReceiptDetailUnionMasters INNER JOIN " + "\r\n";
            queryString = queryString + "                           GoodsReceiptDetails ON GoodsReceiptDetailUnionMasters.GoodsReceiptDetailID = GoodsReceiptDetails.GoodsReceiptDetailID " + "\r\n";

            //--BEGIN-INPUT-OUTPUT-END.END

            queryString = queryString + "                   UNION ALL " + "\r\n";
            //--ON INPUT.BEGIN (CAC CAU SQL DUNG CHO EWHInputVoucherTypeID.EInvoice, EWHInputVoucherTypeID.EReturn, EWHInputVoucherTypeID.EWHTransfer, EWHInputVoucherTypeID.EWHAdjust, EWHInputVoucherTypeID.EWHAssemblyMaster, EWHInputVoucherTypeID.EWHAssemblyDetail LA HOAN TOAN GIONG NHAU)
            //EWHInputVoucherTypeID.EInvoice
            queryString = queryString + "                   SELECT  NULL AS EntryDate, NULL AS GoodsReceiptDetailID, PickupDetails.CommodityID, PickupDetails.BatchEntryDate, PickupDetails.LocationID, NULL AS WarehouseID, NULL AS BinLocationID, NULL AS PickupID, NULL AS GoodsIssueID, NULL AS WarehouseAdjustmentID, PickupDetails.PackID, PickupDetails.CartonID, PickupDetails.PalletID, " + "\r\n";
            queryString = queryString + "                           0 AS " + Quantity(isQ) + "Begin, 0 AS " + Quantity(isQ) + "ReceiptPickup, 0 AS " + Quantity(isQ) + "ReceiptPurchasing, 0 AS " + Quantity(isQ) + "ReceiptTransfer, 0 AS " + Quantity(isQ) + "ReceiptReturn, 0 AS " + Quantity(isQ) + "ReceiptAdjustment, 0 AS " + Quantity(isQ) + "IssueSelling, 0 AS " + Quantity(isQ) + "IssueTransfer, 0 AS " + Quantity(isQ) + "IssueProduction, 0 AS " + Quantity(isQ) + "IssueAdjustment, 0 AS " + Quantity(isQ) + "OnPurchasing, (PickupDetails." + Quantity(isQ) + " - PickupDetails." + Quantity(isQ) + "Receipt) AS " + Quantity(isQ) + "OnPickup, 0 AS " + Quantity(isQ) + "OnTransit, 0 AS " + Quantity(isQ) + "PendingOrder, 0 AS " + Quantity(isQ) + "PendingAdvice, 0 AS " + Quantity(isQ) + "Forecasts, 0 AS " + Quantity(isQ) + "M1Forecasts, 0 AS " + Quantity(isQ) + "M2Forecasts, 0 AS " + Quantity(isQ) + "M3Forecasts, 0 AS MovementMIN, 0 AS MovementMAX, 0 AS MovementAVG " + "\r\n";
            queryString = queryString + "                   FROM    PickupDetails " + "\r\n";
            queryString = queryString + "                   WHERE   PickupDetails.EntryDate <= @ToDate  AND PickupDetails." + Quantity(isQ) + " > PickupDetails." + Quantity(isQ) + "Receipt " + this.DEFINEFilterLW(isLocationID, isWarehouseID, "PickupDetails") + "\r\n";

            queryString = queryString + "                   UNION ALL " + "\r\n";

            queryString = queryString + "                   SELECT  NULL AS EntryDate, NULL AS GoodsReceiptDetailID, GoodsReceiptDetails.CommodityID, GoodsReceiptDetails.BatchEntryDate, GoodsReceiptDetails.LocationID, NULL AS WarehouseID, NULL AS BinLocationID, NULL AS PickupID, NULL AS GoodsIssueID, NULL AS WarehouseAdjustmentID, GoodsReceiptDetails.PackID, GoodsReceiptDetails.CartonID, GoodsReceiptDetails.PalletID, " + "\r\n";
            queryString = queryString + "                           0 AS " + Quantity(isQ) + "Begin, 0 AS " + Quantity(isQ) + "ReceiptPickup, 0 AS " + Quantity(isQ) + "ReceiptPurchasing, 0 AS " + Quantity(isQ) + "ReceiptTransfer, 0 AS " + Quantity(isQ) + "ReceiptReturn, 0 AS " + Quantity(isQ) + "ReceiptAdjustment, 0 AS " + Quantity(isQ) + "IssueSelling, 0 AS " + Quantity(isQ) + "IssueTransfer, 0 AS " + Quantity(isQ) + "IssueProduction, 0 AS " + Quantity(isQ) + "IssueAdjustment, 0 AS " + Quantity(isQ) + "OnPurchasing, GoodsReceiptDetails." + Quantity(isQ) + " AS " + Quantity(isQ) + "OnPickup, 0 AS " + Quantity(isQ) + "OnTransit, 0 AS " + Quantity(isQ) + "PendingOrder, 0 AS " + Quantity(isQ) + "PendingAdvice, 0 AS " + Quantity(isQ) + "Forecasts, 0 AS " + Quantity(isQ) + "M1Forecasts, 0 AS " + Quantity(isQ) + "M2Forecasts, 0 AS " + Quantity(isQ) + "M3Forecasts, 0 AS MovementMIN, 0 AS MovementMAX, 0 AS MovementAVG " + "\r\n";
            queryString = queryString + "                   FROM    Pickups INNER JOIN " + "\r\n";
            queryString = queryString + "                           GoodsReceiptDetails ON Pickups.PickupID = GoodsReceiptDetails.PickupID AND Pickups.EntryDate <= @ToDate  AND GoodsReceiptDetails.EntryDate > @ToDate  " + this.DEFINEFilterLW(isLocationID, isWarehouseID, "GoodsReceiptDetails") + "\r\n";

            queryString = queryString + "                   UNION ALL " + "\r\n";
            //EWHInputVoucherTypeID.EWHTransfer
            queryString = queryString + "                   SELECT  NULL AS EntryDate, NULL AS GoodsReceiptDetailID, GoodsIssueTransferDetails.CommodityID, GoodsIssueTransferDetails.BatchEntryDate, GoodsIssueTransferDetails.LocationID, NULL AS WarehouseID, NULL AS BinLocationID, NULL AS PickupID, NULL AS GoodsIssueID, NULL AS WarehouseAdjustmentID, GoodsIssueTransferDetails.PackID, GoodsIssueTransferDetails.CartonID, GoodsIssueTransferDetails.PalletID, " + "\r\n";
            queryString = queryString + "                           0 AS " + Quantity(isQ) + "Begin, 0 AS " + Quantity(isQ) + "ReceiptPickup, 0 AS " + Quantity(isQ) + "ReceiptPurchasing, 0 AS " + Quantity(isQ) + "ReceiptTransfer, 0 AS " + Quantity(isQ) + "ReceiptReturn, 0 AS " + Quantity(isQ) + "ReceiptAdjustment, 0 AS " + Quantity(isQ) + "IssueSelling, 0 AS " + Quantity(isQ) + "IssueTransfer, 0 AS " + Quantity(isQ) + "IssueProduction, 0 AS " + Quantity(isQ) + "IssueAdjustment, 0 AS " + Quantity(isQ) + "OnPurchasing, 0 AS " + Quantity(isQ) + "OnPickup, (GoodsIssueTransferDetails." + Quantity(isQ) + " - GoodsIssueTransferDetails." + Quantity(isQ) + "Receipt) AS " + Quantity(isQ) + "OnTransit, 0 AS " + Quantity(isQ) + "PendingOrder, 0 AS " + Quantity(isQ) + "PendingAdvice, 0 AS " + Quantity(isQ) + "Forecasts, 0 AS " + Quantity(isQ) + "M1Forecasts, 0 AS " + Quantity(isQ) + "M2Forecasts, 0 AS " + Quantity(isQ) + "M3Forecasts, 0 AS MovementMIN, 0 AS MovementMAX, 0 AS MovementAVG " + "\r\n";
            queryString = queryString + "                   FROM    GoodsIssueTransferDetails " + "\r\n";
            queryString = queryString + "                   WHERE   GoodsIssueTransferDetails.EntryDate <= @ToDate  AND GoodsIssueTransferDetails." + Quantity(isQ) + " > GoodsIssueTransferDetails." + Quantity(isQ) + "Receipt " + this.DEFINEFilterLW(isLocationID, isWarehouseID, "GoodsIssueTransferDetails", null, "WarehouseReceiptID") + "\r\n";

            queryString = queryString + "                   UNION ALL " + "\r\n";

            queryString = queryString + "                   SELECT  NULL AS EntryDate, NULL AS GoodsReceiptDetailID, GoodsReceiptDetails.CommodityID, GoodsReceiptDetails.BatchEntryDate, GoodsReceiptDetails.LocationID, NULL AS WarehouseID, NULL AS BinLocationID, NULL AS PickupID, NULL AS GoodsIssueID, NULL AS WarehouseAdjustmentID, GoodsReceiptDetails.PackID, GoodsReceiptDetails.CartonID, GoodsReceiptDetails.PalletID, " + "\r\n";
            queryString = queryString + "                           0 AS " + Quantity(isQ) + "Begin, 0 AS " + Quantity(isQ) + "ReceiptPickup, 0 AS " + Quantity(isQ) + "ReceiptPurchasing, 0 AS " + Quantity(isQ) + "ReceiptTransfer, 0 AS " + Quantity(isQ) + "ReceiptReturn, 0 AS " + Quantity(isQ) + "ReceiptAdjustment, 0 AS " + Quantity(isQ) + "IssueSelling, 0 AS " + Quantity(isQ) + "IssueTransfer, 0 AS " + Quantity(isQ) + "IssueProduction, 0 AS " + Quantity(isQ) + "IssueAdjustment, 0 AS " + Quantity(isQ) + "OnPurchasing, 0 AS " + Quantity(isQ) + "OnPickup, GoodsReceiptDetails." + Quantity(isQ) + " AS " + Quantity(isQ) + "OnTransit, 0 AS " + Quantity(isQ) + "PendingOrder, 0 AS " + Quantity(isQ) + "PendingAdvice, 0 AS " + Quantity(isQ) + "Forecasts, 0 AS " + Quantity(isQ) + "M1Forecasts, 0 AS " + Quantity(isQ) + "M2Forecasts, 0 AS " + Quantity(isQ) + "M3Forecasts, 0 AS MovementMIN, 0 AS MovementMAX, 0 AS MovementAVG " + "\r\n";
            queryString = queryString + "                   FROM    GoodsIssues INNER JOIN " + "\r\n";
            queryString = queryString + "                           GoodsReceiptDetails ON GoodsIssues.GoodsIssueID = GoodsReceiptDetails.GoodsIssueID AND GoodsIssues.EntryDate <= @ToDate  AND GoodsReceiptDetails.EntryDate > @ToDate  " + this.DEFINEFilterLW(isLocationID, isWarehouseID, "GoodsReceiptDetails") + "\r\n";
            //--ON INPUT.END




            if (isPending)
            {
                //--PENDING SALESORDER.BEGIN
                queryString = queryString + "               UNION ALL " + "\r\n";
                queryString = queryString + "               SELECT  NULL AS EntryDate, NULL AS GoodsReceiptDetailID, SalesOrderDetails.CommodityID, NULL AS BatchEntryDate, SalesOrderDetails.LocationID, NULL AS WarehouseID, NULL AS BinLocationID, NULL AS PickupID, NULL AS GoodsIssueID, NULL AS WarehouseAdjustmentID, NULL AS PackID, NULL AS CartonID, NULL AS PalletID, " + "\r\n";
                queryString = queryString + "                       0 AS " + Quantity(isQ) + "Begin, 0 AS " + Quantity(isQ) + "ReceiptPickup, 0 AS " + Quantity(isQ) + "ReceiptPurchasing, 0 AS " + Quantity(isQ) + "ReceiptTransfer, 0 AS " + Quantity(isQ) + "ReceiptReturn, 0 AS " + Quantity(isQ) + "ReceiptAdjustment, 0 AS " + Quantity(isQ) + "IssueSelling, 0 AS " + Quantity(isQ) + "IssueTransfer, 0 AS " + Quantity(isQ) + "IssueProduction, 0 AS " + Quantity(isQ) + "IssueAdjustment, 0 AS " + Quantity(isQ) + "OnPurchasing, 0 AS " + Quantity(isQ) + "OnPickup, 0 AS " + Quantity(isQ) + "OnTransit, (SalesOrderDetails." + Quantity(isQ) + " - SalesOrderDetails." + Quantity(isQ) + "Advice) AS " + Quantity(isQ) + "PendingOrder, 0 AS " + Quantity(isQ) + "PendingAdvice, 0 AS " + Quantity(isQ) + "Forecasts, 0 AS " + Quantity(isQ) + "M1Forecasts, 0 AS " + Quantity(isQ) + "M2Forecasts, 0 AS " + Quantity(isQ) + "M3Forecasts, 0 AS MovementMIN, 0 AS MovementMAX, 0 AS MovementAVG " + "\r\n";
                queryString = queryString + "               FROM    SalesOrderDetails " + "\r\n";
                queryString = queryString + "               WHERE   SalesOrderDetails.EntryDate <= @ToDate  AND SalesOrderDetails." + Quantity(isQ) + " > SalesOrderDetails." + Quantity(isQ) + "Advice" + this.DEFINEFilterLW(true, false, "SalesOrderDetails") + "\r\n";

                queryString = queryString + "               UNION ALL " + "\r\n";
                queryString = queryString + "               SELECT  NULL AS EntryDate, NULL AS GoodsReceiptDetailID, DeliveryAdviceDetails.CommodityID, NULL AS BatchEntryDate, DeliveryAdviceDetails.LocationID, NULL AS WarehouseID, NULL AS BinLocationID, NULL AS PickupID, NULL AS GoodsIssueID, NULL AS WarehouseAdjustmentID, NULL AS PackID, NULL AS CartonID, NULL AS PalletID, " + "\r\n";
                queryString = queryString + "                       0 AS " + Quantity(isQ) + "Begin, 0 AS " + Quantity(isQ) + "ReceiptPickup, 0 AS " + Quantity(isQ) + "ReceiptPurchasing, 0 AS " + Quantity(isQ) + "ReceiptTransfer, 0 AS " + Quantity(isQ) + "ReceiptReturn, 0 AS " + Quantity(isQ) + "ReceiptAdjustment, 0 AS " + Quantity(isQ) + "IssueSelling, 0 AS " + Quantity(isQ) + "IssueTransfer, 0 AS " + Quantity(isQ) + "IssueProduction, 0 AS " + Quantity(isQ) + "IssueAdjustment, 0 AS " + Quantity(isQ) + "OnPurchasing, 0 AS " + Quantity(isQ) + "OnPickup, 0 AS " + Quantity(isQ) + "OnTransit, DeliveryAdviceDetails." + Quantity(isQ) + " AS " + Quantity(isQ) + "PendingOrder, 0 AS " + Quantity(isQ) + "PendingAdvice, 0 AS " + Quantity(isQ) + "Forecasts, 0 AS " + Quantity(isQ) + "M1Forecasts, 0 AS " + Quantity(isQ) + "M2Forecasts, 0 AS " + Quantity(isQ) + "M3Forecasts, 0 AS MovementMIN, 0 AS MovementMAX, 0 AS MovementAVG " + "\r\n";
                queryString = queryString + "               FROM    SalesOrders INNER JOIN " + "\r\n";
                queryString = queryString + "                       DeliveryAdviceDetails ON SalesOrders.SalesOrderID = DeliveryAdviceDetails.SalesOrderID AND SalesOrders.EntryDate <= @ToDate  AND DeliveryAdviceDetails.EntryDate > @ToDate  " + this.DEFINEFilterLW(true, false, "DeliveryAdviceDetails") + "\r\n";
                //--PENDING SALESORDER.END



                //--PENDING DELIVERYADVICE.BEGIN
                queryString = queryString + "               UNION ALL " + "\r\n";
                queryString = queryString + "               SELECT  NULL AS EntryDate, NULL AS GoodsReceiptDetailID, DeliveryAdviceDetails.CommodityID, NULL AS BatchEntryDate, DeliveryAdviceDetails.LocationID, NULL AS WarehouseID, NULL AS BinLocationID, NULL AS PickupID, NULL AS GoodsIssueID, NULL AS WarehouseAdjustmentID, NULL AS PackID, NULL AS CartonID, NULL AS PalletID, " + "\r\n";
                queryString = queryString + "                       0 AS " + Quantity(isQ) + "Begin, 0 AS " + Quantity(isQ) + "ReceiptPickup, 0 AS " + Quantity(isQ) + "ReceiptPurchasing, 0 AS " + Quantity(isQ) + "ReceiptTransfer, 0 AS " + Quantity(isQ) + "ReceiptReturn, 0 AS " + Quantity(isQ) + "ReceiptAdjustment, 0 AS " + Quantity(isQ) + "IssueSelling, 0 AS " + Quantity(isQ) + "IssueTransfer, 0 AS " + Quantity(isQ) + "IssueProduction, 0 AS " + Quantity(isQ) + "IssueAdjustment, 0 AS " + Quantity(isQ) + "OnPurchasing, 0 AS " + Quantity(isQ) + "OnPickup, 0 AS " + Quantity(isQ) + "OnTransit, 0 AS " + Quantity(isQ) + "PendingOrder, (DeliveryAdviceDetails." + Quantity(isQ) + " - DeliveryAdviceDetails." + Quantity(isQ) + "Issue) AS " + Quantity(isQ) + "PendingAdvice, 0 AS " + Quantity(isQ) + "Forecasts, 0 AS " + Quantity(isQ) + "M1Forecasts, 0 AS " + Quantity(isQ) + "M2Forecasts, 0 AS " + Quantity(isQ) + "M3Forecasts, 0 AS MovementMIN, 0 AS MovementMAX, 0 AS MovementAVG " + "\r\n";
                queryString = queryString + "               FROM    DeliveryAdviceDetails " + "\r\n";
                queryString = queryString + "               WHERE   DeliveryAdviceDetails.EntryDate <= @ToDate  AND DeliveryAdviceDetails." + Quantity(isQ) + " > DeliveryAdviceDetails." + Quantity(isQ) + "Issue" + this.DEFINEFilterLW(true, false, "DeliveryAdviceDetails") + "\r\n";

                queryString = queryString + "               UNION ALL " + "\r\n";
                queryString = queryString + "               SELECT  NULL AS EntryDate, NULL AS GoodsReceiptDetailID, GoodsIssueDetails.CommodityID, NULL AS BatchEntryDate, GoodsIssueDetails.LocationID, NULL AS WarehouseID, NULL AS BinLocationID, NULL AS PickupID, NULL AS GoodsIssueID, NULL AS WarehouseAdjustmentID, NULL AS PackID, NULL AS CartonID, NULL AS PalletID, " + "\r\n";
                queryString = queryString + "                       0 AS " + Quantity(isQ) + "Begin, 0 AS " + Quantity(isQ) + "ReceiptPickup, 0 AS " + Quantity(isQ) + "ReceiptPurchasing, 0 AS " + Quantity(isQ) + "ReceiptTransfer, 0 AS " + Quantity(isQ) + "ReceiptReturn, 0 AS " + Quantity(isQ) + "ReceiptAdjustment, 0 AS " + Quantity(isQ) + "IssueSelling, 0 AS " + Quantity(isQ) + "IssueTransfer, 0 AS " + Quantity(isQ) + "IssueProduction, 0 AS " + Quantity(isQ) + "IssueAdjustment, 0 AS " + Quantity(isQ) + "OnPurchasing, 0 AS " + Quantity(isQ) + "OnPickup, 0 AS " + Quantity(isQ) + "OnTransit, 0 AS " + Quantity(isQ) + "PendingOrder, GoodsIssueDetails." + Quantity(isQ) + " AS " + Quantity(isQ) + "PendingAdvice, 0 AS " + Quantity(isQ) + "Forecasts, 0 AS " + Quantity(isQ) + "M1Forecasts, 0 AS " + Quantity(isQ) + "M2Forecasts, 0 AS " + Quantity(isQ) + "M3Forecasts, 0 AS MovementMIN, 0 AS MovementMAX, 0 AS MovementAVG " + "\r\n";
                queryString = queryString + "               FROM    DeliveryAdvices INNER JOIN " + "\r\n";
                queryString = queryString + "                       GoodsIssueDetails ON DeliveryAdvices.DeliveryAdviceID = GoodsIssueDetails.DeliveryAdviceID AND DeliveryAdvices.EntryDate <= @ToDate  AND GoodsIssueDetails.EntryDate > @ToDate  " + this.DEFINEFilterLW(true, false, "GoodsIssueDetails") + "\r\n";
                //--PENDING DELIVERYADVICE.END
            }


            if (isForecast)
            {
                //--FORECAST.BEGIN
                queryString = queryString + "               UNION ALL " + "\r\n";
                queryString = queryString + "               SELECT  NULL AS EntryDate, NULL AS GoodsReceiptDetailID, ForecastDetails.CommodityID, NULL AS BatchEntryDate, ForecastDetails.ForecastLocationID AS LocationID, NULL AS WarehouseID, NULL AS BinLocationID, NULL AS PickupID, NULL AS GoodsIssueID, NULL AS WarehouseAdjustmentID, NULL AS PackID, NULL AS CartonID, NULL AS PalletID, " + "\r\n";
                queryString = queryString + "                       0 AS " + Quantity(isQ) + "Begin, 0 AS " + Quantity(isQ) + "ReceiptPickup, 0 AS " + Quantity(isQ) + "ReceiptPurchasing, 0 AS " + Quantity(isQ) + "ReceiptTransfer, 0 AS " + Quantity(isQ) + "ReceiptReturn, 0 AS " + Quantity(isQ) + "ReceiptAdjustment, 0 AS " + Quantity(isQ) + "IssueSelling, 0 AS " + Quantity(isQ) + "IssueTransfer, 0 AS " + Quantity(isQ) + "IssueProduction, 0 AS " + Quantity(isQ) + "IssueAdjustment, 0 AS " + Quantity(isQ) + "OnPurchasing, 0 AS " + Quantity(isQ) + "OnPickup, 0 AS " + Quantity(isQ) + "OnTransit, 0 AS " + Quantity(isQ) + "PendingOrder, 0 AS " + Quantity(isQ) + "PendingAdvice, ForecastDetails." + Quantity(isQ) + " AS " + Quantity(isQ) + "Forecasts, ForecastDetails." + Quantity(isQ) + "M1 AS " + Quantity(isQ) + "M1Forecasts, ForecastDetails." + Quantity(isQ) + "M2 AS " + Quantity(isQ) + "M2Forecasts, ForecastDetails." + Quantity(isQ) + "M3 AS " + Quantity(isQ) + "M3Forecasts, 0 AS MovementMIN, 0 AS MovementMAX, 0 AS MovementAVG " + "\r\n";
                queryString = queryString + "               FROM    ForecastDetails " + "\r\n";
                queryString = queryString + "               WHERE   ForecastDetails.EntryDate = DATEFROMPARTS (YEAR(@ToDate), MONTH(@ToDate), 1) " + this.DEFINEFilterLW(true, false, "ForecastDetails", "ForecastLocationID") + "\r\n";
                //--FORECAST.END
            }



            queryString = queryString + "                   ) AS WarehouseJournalDetails " + "\r\n";

            queryString = queryString + "                   INNER JOIN Commodities ON " + (isCommodityCategoryID || isCommodityID ? "(" + (isCommodityCategoryID ? "Commodities.CommodityCategoryID IN (SELECT Id FROM dbo.SplitToIntList (@CommodityCategoryIDs))" : "") + (isCommodityCategoryID && isCommodityID ? " OR " : "") + (isCommodityID ? "Commodities.CommodityID IN (SELECT Id FROM dbo.SplitToIntList (@CommodityIDs)) " : "") + ") AND " : "") + " WarehouseJournalDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN CommodityCategories ON Commodities.CommodityCategoryID = CommodityCategories.CommodityCategoryID " + "\r\n";

            queryString = queryString + "                   INNER JOIN CommodityTypes ON " + (isCommodityTypeID ? "Commodities.CommodityTypeID IN (SELECT Id FROM dbo.SplitToIntList (@CommodityTypeIDs)) AND " : "") + " Commodities.CommodityTypeID = CommodityTypes.CommodityTypeID " + "\r\n";
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
        private string DEFINEFilterLW(bool isLocationID, bool isWarehouseID, string tableName)
        {
            return this.DEFINEFilterLW(isLocationID, isWarehouseID, tableName, null, null);
        }

        private string DEFINEFilterLW(bool isLocationID, bool isWarehouseID, string tableName, string locationID)
        {
            return this.DEFINEFilterLW(isLocationID, isWarehouseID, tableName, locationID, null);
        }

        private string DEFINEFilterLW(bool isLocationID, bool isWarehouseID, string tableName, string locationID, string warehouseID)
        {
            string x = (isLocationID || isWarehouseID ? " AND (" + (isLocationID ? "" + tableName + "." + (locationID == null ? "LocationID" : locationID) + " IN (SELECT Id FROM dbo.SplitToIntList (@LocationIDs)) " : "") + (isLocationID && isWarehouseID ? " OR " : "") + (isWarehouseID ? "" + tableName + "." + (warehouseID == null ? "WarehouseID" : warehouseID) + " IN (SELECT Id FROM dbo.SplitToIntList (@WarehouseIDs)) " : "") + ") " : "");
            return x;
        }

        private string Quantity(bool isQuantityVersusVolume)
        {
            return (isQuantityVersusVolume ? "Quantity" : "LineVolume");
        }

        #endregion Actual DEFINE WarehouseJournal

        #endregion WarehouseJournals




        #region WarehouseLedgers
        private string BUILDHeader(bool localParameter, bool quantityVersusVolume)
        {
            string queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime, @IssueVersusReceipt int, @LocationIDs varchar(3999), @WarehouseIDs varchar(3999), @CommodityCategoryIDs varchar(3999), @CommodityTypeIDs varchar(3999), @CommodityIDs varchar(3999), @GoodsIssueTypeIDs varchar(3999), @CustomerCategoryIDs varchar(3999), @CustomerIDs varchar(3999), @LocationReceiptIDs varchar(3999), @WarehouseReceiptIDs varchar(3999), @TeamIDs varchar(3999), @EmployeeIDs varchar(3999), @WarehouseAdjustmentTypeIDs varchar(3999), @GoodsReceiptTypeIDs varchar(3999), @SupplierCategoryIDs varchar(3999), @SupplierIDs varchar(3999), @LocationIssueIDs varchar(3999), @WarehouseIssueIDs varchar(3999) " + (quantityVersusVolume ? ", @DateVersusMonth int, @QuantityVersusVolume int, @SalesVersusPromotion int" : "") + "\r\n";



            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "       SET NOCOUNT ON; " + "\r\n";

            if (localParameter)
            {
                queryString = queryString + "       DECLARE     @LocalUserID Int, @LocalFromDate DateTime, @LocalToDate DateTime, @LocalIssueVersusReceipt int, @LocalLocationIDs varchar(3999), @LocalWarehouseIDs varchar(3999), @LocalCommodityCategoryIDs varchar(3999), @LocalCommodityTypeIDs varchar(3999), @LocalCommodityIDs varchar(3999), @LocalGoodsIssueTypeIDs varchar(3999), @LocalCustomerCategoryIDs varchar(3999), @LocalCustomerIDs varchar(3999), @LocalLocationReceiptIDs varchar(3999), @LocalWarehouseReceiptIDs varchar(3999), @LocalTeamIDs varchar(3999), @LocalEmployeeIDs varchar(3999), @LocalWarehouseAdjustmentTypeIDs varchar(3999), @LocalGoodsReceiptTypeIDs varchar(3999), @LocalSupplierCategoryIDs varchar(3999), @LocalSupplierIDs varchar(3999), @LocalLocationIssueIDs varchar(3999), @LocalWarehouseIssueIDs varchar(3999) " + (quantityVersusVolume ? ", @LocalDateVersusMonth int, @LocalQuantityVersusVolume int, @LocalSalesVersusPromotion int" : "") + "\r\n";

                queryString = queryString + "       SET         @LocalUserID = @UserID                                              SET @LocalFromDate = @FromDate                          SET @LocalToDate = @ToDate          SET @LocalIssueVersusReceipt = @IssueVersusReceipt " + "\r\n";
                queryString = queryString + "       SET         @LocalLocationIDs = @LocationIDs                                    SET @LocalWarehouseIDs = @WarehouseIDs                  " + "\r\n";
                queryString = queryString + "       SET         @LocalCommodityCategoryIDs = @CommodityCategoryIDs                  SET @LocalCommodityIDs = @CommodityIDs                  " + "\r\n";
                queryString = queryString + "       SET         @LocalCommodityTypeIDs = @CommodityTypeIDs                          SET @LocalGoodsIssueTypeIDs = @GoodsIssueTypeIDs " + "\r\n";
                queryString = queryString + "       SET         @LocalCustomerCategoryIDs = @CustomerCategoryIDs                    SET @LocalCustomerIDs = @CustomerIDs" + "\r\n";
                queryString = queryString + "       SET         @LocalLocationReceiptIDs = @LocationReceiptIDs                      SET @LocalWarehouseReceiptIDs = @WarehouseReceiptIDs " + "\r\n";
                queryString = queryString + "       SET         @LocalTeamIDs = @TeamIDs                                            SET @LocalEmployeeIDs = @EmployeeIDs " + "\r\n";
                queryString = queryString + "       SET         @LocalWarehouseAdjustmentTypeIDs = @WarehouseAdjustmentTypeIDs" + "\r\n";

                queryString = queryString + "       SET         @LocalGoodsReceiptTypeIDs = @GoodsReceiptTypeIDs" + "\r\n";
                queryString = queryString + "       SET         @LocalSupplierCategoryIDs = @SupplierCategoryIDs                    SET @LocalSupplierIDs = @SupplierIDs " + "\r\n";
                queryString = queryString + "       SET         @LocalLocationIssueIDs = @LocationIssueIDs                          SET @LocalWarehouseIssueIDs = @WarehouseIssueIDs " + "\r\n";


                queryString = queryString + (quantityVersusVolume ? " SET @LocalDateVersusMonth = @DateVersusMonth   SET @LocalQuantityVersusVolume = @QuantityVersusVolume       SET @LocalSalesVersusPromotion = @SalesVersusPromotion" : "") + "\r\n";
            }

            return queryString;
        }

        private string BUILDParameter(bool localParameter)
        {
            return " @" + (localParameter ? "Local" : "") + "UserID, @" + (localParameter ? "Local" : "") + "FromDate, @" + (localParameter ? "Local" : "") + "ToDate, @" + (localParameter ? "Local" : "") + "IssueVersusReceipt, @" + (localParameter ? "Local" : "") + "LocationIDs, @" + (localParameter ? "Local" : "") + "WarehouseIDs, @" + (localParameter ? "Local" : "") + "CommodityCategoryIDs, @" + (localParameter ? "Local" : "") + "CommodityTypeIDs, @" + (localParameter ? "Local" : "") + "CommodityIDs, @" + (localParameter ? "Local" : "") + "GoodsIssueTypeIDs, @" + (localParameter ? "Local" : "") + "CustomerCategoryIDs, @" + (localParameter ? "Local" : "") + "CustomerIDs, @" + (localParameter ? "Local" : "") + "LocationReceiptIDs, @" + (localParameter ? "Local" : "") + "WarehouseReceiptIDs, @" + (localParameter ? "Local" : "") + "TeamIDs, @" + (localParameter ? "Local" : "") + "EmployeeIDs, @" + (localParameter ? "Local" : "") + "WarehouseAdjustmentTypeIDs, @" + (localParameter ? "Local" : "") + "GoodsReceiptTypeIDs, @" + (localParameter ? "Local" : "") + "SupplierCategoryIDs, @" + (localParameter ? "Local" : "") + "SupplierIDs, @" + (localParameter ? "Local" : "") + "LocationIssueIDs, @" + (localParameter ? "Local" : "") + "WarehouseIssueIDs ";
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
            this.WarehouseLedgerIssue08();
            this.WarehouseLedgerReceipt08();

            this.WarehouseLedger06();

            string queryString = this.BUILDHeader(false, false) + this.BUILDGoodsIssue() + "\r\n";
            this.totalSmartCodingEntities.CreateStoredProcedure("WHLS", queryString);


            queryString = this.BUILDHeader(true, true);
            queryString = queryString + "       DECLARE     @WarehouseLedgers TABLE (PrimaryID int NOT NULL, PrimaryDetailID int NOT NULL, EntryDate datetime NOT NULL, Reference nvarchar(10) NULL, LocationName nvarchar(50) NOT NULL, WarehouseName nvarchar(60) NOT NULL, Barcode nvarchar(50) NULL, CommodityID int NOT NULL, Code nvarchar(50) NOT NULL, Name nvarchar(200) NOT NULL, PackageSize nvarchar(60) NULL, CommodityCategoryName nvarchar(100) NOT NULL, CommodityTypeName nvarchar(100) NOT NULL, IsPromotion bit NOT NULL, Quantity decimal(18, 2) NOT NULL, LineVolume decimal(18, 2) NOT NULL, JournalTypeID Int NOT NULL, JournalTypeName nvarchar(50) NOT NULL, LineForeignCode nvarchar(50) NULL, LineForeignName nvarchar(100) NULL, LineReferences nvarchar(110) NULL, CustomerCategoryName nvarchar(100) NULL, TeamName nvarchar(100) NULL, SalespersonName nvarchar(50) NULL) " + "\r\n";
            queryString = queryString + "       INSERT INTO @WarehouseLedgers         EXEC WHLS " + this.BUILDParameter(true) + "\r\n";

            string queryMaster = "              SELECT      PrimaryID, PrimaryDetailID, EntryDate, CASE @LocalDateVersusMonth WHEN 0 THEN CONVERT(Date, EntryDate) ELSE DATEADD(Month, DateDiff(Month, 0, EntryDate), 0) END AS GroupDate, Reference, LocationName, WarehouseName, Barcode, CommodityID, Code, Name, PackageSize, CommodityCategoryName, CommodityTypeName, IsPromotion, Quantity, LineVolume, CASE @LocalQuantityVersusVolume WHEN 0 THEN Quantity ELSE LineVolume END AS LineValue, JournalTypeID, JournalTypeName, LineForeignCode, LineForeignName, LineReferences, CustomerCategoryName, TeamName, SalespersonName " + "\r\n";
            queryMaster = queryMaster + "       FROM        @WarehouseLedgers " + "\r\n";

            queryString = queryString + "       IF         (@LocalSalesVersusPromotion IS NULL OR @LocalSalesVersusPromotion < 0) " + "\r\n";
            queryString = queryString + "                   " + queryMaster + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + queryMaster + "\r\n" + " WHERE IsPromotion = @LocalSalesVersusPromotion";

            this.totalSmartCodingEntities.CreateStoredProcedure("WarehouseLedgers", queryString);







            queryString = this.BUILDHeader(true, true);
            queryString = queryString + "       DECLARE     @WarehouseLedgerCombos  TABLE (ISSUEPrimaryID int NULL, ISSUEPrimaryDetailID int NULL, ISSUEEntryDate datetime NULL, ISSUEReference nvarchar(10) NULL, ISSUELocationName nvarchar(50) NULL, ISSUEWarehouseName nvarchar(60) NULL, ISSUEBarcode nvarchar(50) NULL, ISSUECommodityID int NULL, ISSUECode nvarchar(50) NULL, ISSUEName nvarchar(200) NULL, ISSUEPackageSize nvarchar(60) NULL, ISSUECommodityCategoryName nvarchar(100) NULL, ISSUECommodityTypeName nvarchar(100) NULL, ISSUEIsPromotion bit NULL, ISSUEQuantity decimal(18, 2) NULL, ISSUELineVolume decimal(18, 2) NULL, ISSUEJournalTypeID Int NULL, ISSUEJournalTypeName nvarchar(50) NULL, ISSUELineForeignCode nvarchar(50) NULL, ISSUELineForeignName nvarchar(100) NULL, ISSUELineReferences nvarchar(110) NULL, ISSUECustomerCategoryName nvarchar(100) NULL, ISSUETeamName nvarchar(100) NULL, ISSUESalespersonName nvarchar(50) NULL, RECEIPTPrimaryID int NULL, RECEIPTPrimaryDetailID int NULL, RECEIPTEntryDate datetime NULL, RECEIPTReference nvarchar(10) NULL, RECEIPTLocationName nvarchar(50) NULL, RECEIPTWarehouseName nvarchar(60) NULL, RECEIPTBarcode nvarchar(50) NULL, RECEIPTCommodityID int NULL, RECEIPTCode nvarchar(50) NULL, RECEIPTName nvarchar(200) NULL, RECEIPTPackageSize nvarchar(60) NULL, RECEIPTCommodityCategoryName nvarchar(100) NULL, RECEIPTCommodityTypeName nvarchar(100) NULL, RECEIPTIsPromotion bit NULL, RECEIPTQuantity decimal(18, 2) NULL, RECEIPTLineVolume decimal(18, 2) NULL, RECEIPTJournalTypeID Int NULL, RECEIPTJournalTypeName nvarchar(50) NULL, RECEIPTLineForeignCode nvarchar(50) NULL, RECEIPTLineForeignName nvarchar(100) NULL, RECEIPTLineReferences nvarchar(110) NULL, RECEIPTCustomerCategoryName nvarchar(100) NULL, RECEIPTTeamName nvarchar(100) NULL, RECEIPTSalespersonName nvarchar(50) NULL) " + "\r\n";
            queryString = queryString + "       INSERT INTO @WarehouseLedgerCombos  (ISSUEPrimaryID, ISSUEPrimaryDetailID, ISSUEEntryDate, ISSUEReference, ISSUELocationName, ISSUEWarehouseName, ISSUEBarcode, ISSUECommodityID, ISSUECode, ISSUEName, ISSUEPackageSize, ISSUECommodityCategoryName, ISSUECommodityTypeName, ISSUEIsPromotion, ISSUEQuantity, ISSUELineVolume, ISSUEJournalTypeID, ISSUEJournalTypeName, ISSUELineForeignCode, ISSUELineForeignName, ISSUELineReferences, ISSUECustomerCategoryName, ISSUETeamName, ISSUESalespersonName) EXEC WHLS " + this.BUILDParameter(true).Replace("@LocalIssueVersusReceipt", "0") + "\r\n";
            queryString = queryString + "       INSERT INTO @WarehouseLedgerCombos  (RECEIPTPrimaryID, RECEIPTPrimaryDetailID, RECEIPTEntryDate, RECEIPTReference, RECEIPTLocationName, RECEIPTWarehouseName, RECEIPTBarcode, RECEIPTCommodityID, RECEIPTCode, RECEIPTName, RECEIPTPackageSize, RECEIPTCommodityCategoryName, RECEIPTCommodityTypeName, RECEIPTIsPromotion, RECEIPTQuantity, RECEIPTLineVolume, RECEIPTJournalTypeID, RECEIPTJournalTypeName, RECEIPTLineForeignCode, RECEIPTLineForeignName, RECEIPTLineReferences, RECEIPTCustomerCategoryName, RECEIPTTeamName, RECEIPTSalespersonName) EXEC WHLS " + this.BUILDParameter(true).Replace("@LocalIssueVersusReceipt", "1") + "\r\n";


            queryString = queryString + "       SELECT      CASE WHEN NOT ISSUEPrimaryID IS NULL THEN 0 ELSE 1 END AS IssueVersusReceipt, " + "\r\n";
            queryString = queryString + "                   ISSUEPrimaryID, ISSUEPrimaryDetailID, ISSUEEntryDate, ISSUEReference, ISSUELocationName, ISSUEWarehouseName, ISSUEBarcode, ISSUECommodityID, ISSUECode, ISSUEName, ISSUEPackageSize, ISSUECommodityCategoryName, ISSUECommodityTypeName, ISSUEIsPromotion, ISSUEQuantity, ISSUELineVolume, ISSUEJournalTypeID, ISSUEJournalTypeName, ISSUELineForeignCode, ISSUELineForeignName, ISSUELineReferences, ISSUECustomerCategoryName, ISSUETeamName, ISSUESalespersonName " + "\r\n";

            queryString = queryString + "           FROM @WarehouseLedgerCombos " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("WarehouseLedgerCombos", queryString);

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
            queryString = queryString + "                   " + this.BUILDCommodityType(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.BUILDCommodityType(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, false) + "\r\n";


            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string BUILDCommodityType(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@IssueVersusReceipt = 0) " + "\r\n";
            queryString = queryString + "                   EXEC WHLIssue06" + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isCommodityCategoryID.ToString().Substring(0, 1) + isCommodityID.ToString().Substring(0, 1) + isCommodityTypeID.ToString().Substring(0, 1) + this.BUILDParameter(false) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   EXEC WHLReceipt06" + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isCommodityCategoryID.ToString().Substring(0, 1) + isCommodityID.ToString().Substring(0, 1) + isCommodityTypeID.ToString().Substring(0, 1) + this.BUILDParameter(false) + "\r\n";

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
                                this.totalSmartCodingEntities.CreateStoredProcedure("WHLIssue06" + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isCommodityCategoryID.ToString().Substring(0, 1) + isCommodityID.ToString().Substring(0, 1) + isCommodityTypeID.ToString().Substring(0, 1), this.BUILDHeader(false, false) + this.WHLIssue06(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID));
                                this.totalSmartCodingEntities.CreateStoredProcedure("WHLReceipt06" + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isCommodityCategoryID.ToString().Substring(0, 1) + isCommodityID.ToString().Substring(0, 1) + isCommodityTypeID.ToString().Substring(0, 1), this.BUILDHeader(false, false) + this.WHLReceipt06(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID));
                            }
                        }
                    }
                }
            }
        }

        private string WHLIssue06(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID)
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
            queryString = queryString + "                   EXEC WHLIssue08" + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isCommodityCategoryID.ToString().Substring(0, 1) + isCommodityID.ToString().Substring(0, 1) + isCommodityTypeID.ToString().Substring(0, 1) + goodsIssueTypeID_REPORTONLY.ToString().Substring(0, 1) + isCustomerCategoryID.ToString().Substring(0, 1) + true.ToString().Substring(0, 1) + this.BUILDParameter(false) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   EXEC WHLIssue08" + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isCommodityCategoryID.ToString().Substring(0, 1) + isCommodityID.ToString().Substring(0, 1) + isCommodityTypeID.ToString().Substring(0, 1) + goodsIssueTypeID_REPORTONLY.ToString().Substring(0, 1) + isCustomerCategoryID.ToString().Substring(0, 1) + false.ToString().Substring(0, 1) + this.BUILDParameter(false) + "\r\n";
            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private void WarehouseLedgerIssue08()
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
                                            this.totalSmartCodingEntities.CreateStoredProcedure("WHLIssue08" + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isCommodityCategoryID.ToString().Substring(0, 1) + isCommodityID.ToString().Substring(0, 1) + isCommodityTypeID.ToString().Substring(0, 1) + goodsIssueTypeID_REPORTONLY.ToString().Substring(0, 1) + isCustomerCategoryID.ToString().Substring(0, 1) + isLocationReceiptID.ToString().Substring(0, 1), this.BUILDHeader(false, false) + this.BUILDLocationReceipt(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, goodsIssueTypeID_REPORTONLY, isCustomerCategoryID, isLocationReceiptID));
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
            queryString = queryString + "                   " + this.WarehouseLedgerBUILD(true, isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, goodsIssueTypeID_REPORTONLY, isCustomerCategoryID, isLocationReceiptID, isCustomerID, isWarehouseReceiptID, isTeamID, isEmployeeID, true, false, false, false, false, false) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.WarehouseLedgerBUILD(true, isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, goodsIssueTypeID_REPORTONLY, isCustomerCategoryID, isLocationReceiptID, isCustomerID, isWarehouseReceiptID, isTeamID, isEmployeeID, false, false, false, false, false, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }



        private string WarehouseLedgerBUILD(bool isIssueVersusReceipt, bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY goodsIssueTypeID_REPORTONLY, bool isCustomerCategoryID, bool isLocationReceiptID, bool isCustomerID, bool isWarehouseReceiptID, bool isTeamID, bool isEmployeeID, bool isWarehouseAdjustmentTypeID, bool isGoodsReceiptTypeID, bool isSupplierCategoryID, bool isLocationIssueID, bool isSupplierID, bool isWarehouseIssueID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            if (!isIssueVersusReceipt || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.Alls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.CombineSelectedAlls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.GoodsIssues || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.SelectedGoodsIssues)
            { //isGoodsIssueTypeID IS true WHEN goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.CombineSelectedAlls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.SelectedGoodsIssues
                queryString = queryString + "                   " + this.WarehouseLedgerBUILDTable((isIssueVersusReceipt ? GlobalEnums.NmvnTaskID.GoodsIssue : GlobalEnums.NmvnTaskID.GoodsReceipt), (isIssueVersusReceipt ? "GoodsIssueDetails" : "GoodsReceiptDetails"), (isIssueVersusReceipt ? "GoodsIssueID" : "GoodsReceiptID"), (isIssueVersusReceipt ? "GoodsIssueDetailID" : "GoodsReceiptDetailID"), isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityTypeID, isCommodityID, goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.CombineSelectedAlls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.SelectedGoodsIssues, isGoodsReceiptTypeID) + "\r\n";

                if (isIssueVersusReceipt)
                {
                    queryString = queryString + "                   " + (isCustomerCategoryID || isCustomerID ? "INNER" : "LEFT") + "        JOIN Customers ON " + (isCustomerCategoryID || isCustomerID ? "(" + (isCustomerCategoryID ? "Customers.CustomerCategoryID IN (SELECT Id FROM dbo.SplitToIntList (@CustomerCategoryIDs))" : "") + (isCustomerCategoryID && isCustomerID ? " OR " : "") + (isCustomerID ? "Customers.CustomerID IN (SELECT Id FROM dbo.SplitToIntList (@CustomerIDs)) " : "") + ") AND " : "") + " GoodsIssueDetails.CustomerID = Customers.CustomerID " + "\r\n";
                    queryString = queryString + "                   " + (isCustomerCategoryID || isCustomerID ? "INNER" : "LEFT") + "        JOIN CustomerCategories ON Customers.CustomerCategoryID = CustomerCategories.CustomerCategoryID " + "\r\n";

                    queryString = queryString + "                   " + (isTeamID || isEmployeeID ? "INNER" : "LEFT") + "                    JOIN Employees ON " + (isTeamID || isEmployeeID ? "(" + (isTeamID ? "Employees.TeamID IN (SELECT Id FROM dbo.SplitToIntList (@TeamIDs))" : "") + (isTeamID && isEmployeeID ? " OR " : "") + (isEmployeeID ? "Employees.EmployeeID IN (SELECT Id FROM dbo.SplitToIntList (@EmployeeIDs)) " : "") + ") AND " : "") + " GoodsIssueDetails.SalespersonID = Employees.EmployeeID " + "\r\n";
                    queryString = queryString + "                   " + (isTeamID || isEmployeeID ? "INNER" : "LEFT") + "                    JOIN Teams ON Employees.TeamID = Teams.TeamID " + "\r\n";

                    queryString = queryString + "                   " + (isLocationReceiptID || isWarehouseReceiptID ? "INNER" : "LEFT") + " JOIN Locations AS LocationReceipts ON " + (isLocationReceiptID || isWarehouseReceiptID ? "(" + (isLocationReceiptID ? "GoodsIssueDetails.LocationReceiptID IN (SELECT Id FROM dbo.SplitToIntList (@LocationReceiptIDs)) " : "") + (isLocationReceiptID && isWarehouseReceiptID ? " OR " : "") + (isWarehouseReceiptID ? "GoodsIssueDetails.WarehouseReceiptID IN (SELECT Id FROM dbo.SplitToIntList (@WarehouseReceiptIDs)) " : "") + ") AND " : "") + " GoodsIssueDetails.LocationReceiptID = LocationReceipts.LocationID " + "\r\n";
                    queryString = queryString + "                   " + (isLocationReceiptID || isWarehouseReceiptID ? "INNER" : "LEFT") + " JOIN Warehouses AS WarehouseReceipts ON GoodsIssueDetails.WarehouseReceiptID = WarehouseReceipts.WarehouseID " + "\r\n";
                }
                else
                {
                    queryString = queryString + "                   " + (isSupplierCategoryID || isSupplierID ? "INNER" : "LEFT") + "        JOIN Customers Suppliers ON " + (isSupplierCategoryID || isSupplierID ? "(" + (isSupplierCategoryID ? "Suppliers.CustomerCategoryID IN (SELECT Id FROM dbo.SplitToIntList (@SupplierCategoryIDs))" : "") + (isSupplierCategoryID && isSupplierID ? " OR " : "") + (isSupplierID ? "Suppliers.CustomerID IN (SELECT Id FROM dbo.SplitToIntList (@SupplierIDs)) " : "") + ") AND " : "") + " GoodsReceiptDetails.SupplierID = Suppliers.CustomerID " + "\r\n";
                    queryString = queryString + "                   " + (isSupplierCategoryID || isSupplierID ? "INNER" : "LEFT") + "        JOIN CustomerCategories SupplierCategories ON Suppliers.CustomerCategoryID = SupplierCategories.CustomerCategoryID " + "\r\n";

                    queryString = queryString + "                   " + (isLocationIssueID || isWarehouseIssueID ? "INNER" : "LEFT") + "     JOIN Locations AS LocationIssues ON " + (isLocationIssueID || isWarehouseIssueID ? "(" + (isLocationIssueID ? "GoodsReceiptDetails.LocationIssueID IN (SELECT Id FROM dbo.SplitToIntList (@LocationIssueIDs)) " : "") + (isLocationIssueID && isWarehouseIssueID ? " OR " : "") + (isWarehouseIssueID ? "GoodsReceiptDetails.WarehouseIssueID IN (SELECT Id FROM dbo.SplitToIntList (@WarehouseIssueIDs)) " : "") + ") AND " : "") + " GoodsReceiptDetails.LocationIssueID = LocationIssues.LocationID " + "\r\n";
                    queryString = queryString + "                   " + (isLocationIssueID || isWarehouseIssueID ? "INNER" : "LEFT") + "     JOIN Warehouses AS WarehouseIssues ON GoodsReceiptDetails.WarehouseIssueID = WarehouseIssues.WarehouseID " + "\r\n";

                    queryString = queryString + "                   " + (isWarehouseAdjustmentTypeID ? "INNER" : "LEFT") + "                 JOIN WarehouseAdjustmentTypes ON " + (isWarehouseAdjustmentTypeID ? "GoodsReceiptDetails.WarehouseAdjustmentTypeID IN (SELECT Id FROM dbo.SplitToIntList (@WarehouseAdjustmentTypeIDs)) AND " : "") + " GoodsReceiptDetails.WarehouseAdjustmentTypeID = WarehouseAdjustmentTypes.WarehouseAdjustmentTypeID " + "\r\n";
                }
            }

            if (isIssueVersusReceipt && (goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.Alls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.CombineSelectedAlls))
                queryString = queryString + "                   UNION ALL " + "\r\n";

            if (isIssueVersusReceipt && (goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.Alls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.CombineSelectedAlls || goodsIssueTypeID_REPORTONLY == GlobalEnums.GoodsIssueTypeID_REPORTONLY.WarehouseAdjustments))
            { //isGoodsIssueTypeID IS ALWAYS false
                queryString = queryString + "                   " + this.WarehouseLedgerBUILDTable(GlobalEnums.NmvnTaskID.WarehouseAdjustment, "WarehouseAdjustmentDetails", "WarehouseAdjustmentID", "WarehouseAdjustmentDetailID", isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityTypeID, isCommodityID, false, false) + "\r\n";

                queryString = queryString + "                   INNER JOIN WarehouseAdjustmentTypes ON " + (isWarehouseAdjustmentTypeID ? "WarehouseAdjustmentDetails.WarehouseAdjustmentTypeID IN (SELECT Id FROM dbo.SplitToIntList (@WarehouseAdjustmentTypeIDs)) AND " : "") + " WarehouseAdjustmentDetails.WarehouseAdjustmentTypeID = WarehouseAdjustmentTypes.WarehouseAdjustmentTypeID " + "\r\n";
            }

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }


        private string WarehouseLedgerBUILDTable(GlobalEnums.NmvnTaskID nmvnTaskID, string tableName, string primaryKey, string primaryDetailKey, bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityTypeID, bool isCommodityID, bool isGoodsIssueTypeID, bool isGoodsReceiptTypeID)
        {
            string queryString = "";

            queryString = queryString + "       SELECT      " + tableName + "." + primaryKey + " AS PrimaryID, " + tableName + "." + primaryDetailKey + " AS PrimaryDetailID, " + tableName + ".EntryDate, " + tableName + ".Reference, Locations.Name AS LocationName, Warehouses.Name AS WarehouseName, ISNULL(Pallets.Code, Cartons.Code) AS Barcode, " + "\r\n";
            queryString = queryString + "                   Commodities.CommodityID, Commodities.Code, Commodities.Name, Commodities.PackageSize, CommodityCategories.Name AS CommodityCategoryName, CommodityTypes.Name AS CommodityTypeName, CAST(0 AS bit) AS IsPromotion, " + (nmvnTaskID == GlobalEnums.NmvnTaskID.WarehouseAdjustment ? "-" : "") + tableName + ".Quantity, " + (nmvnTaskID == GlobalEnums.NmvnTaskID.WarehouseAdjustment ? "-" : "") + tableName + ".LineVolume, " + "\r\n";
            if (nmvnTaskID == GlobalEnums.NmvnTaskID.GoodsIssue)
                queryString = queryString + "               GoodsIssueDetails.GoodsIssueTypeID AS JournalTypeID, GoodsIssueTypes.Name AS JournalTypeName,                   ISNULL(Customers.Code, LocationReceipts.Name) AS LineForeignCode, ISNULL(Customers.Name, WarehouseReceipts.Name) AS LineForeignName, GoodsIssueDetails.VoucherCodes AS LineReferences, CustomerCategories.Name AS CustomerCategoryName, Teams.Name AS TeamName, Employees.Name AS SalespersonName " + "\r\n";


            if (nmvnTaskID == GlobalEnums.NmvnTaskID.GoodsReceipt)
                queryString = queryString + "               CASE WHEN GoodsReceiptDetails.GoodsReceiptTypeID <> " + (int)GlobalEnums.GoodsReceiptTypeID.WarehouseAdjustments + " THEN GoodsReceiptDetails.GoodsReceiptTypeID ELSE 9000 + GoodsReceiptDetails.WarehouseAdjustmentTypeID END AS JournalTypeID, CASE WHEN GoodsReceiptDetails.GoodsReceiptTypeID <> " + (int)GlobalEnums.GoodsReceiptTypeID.WarehouseAdjustments + " THEN GoodsReceiptTypes.Name ELSE WarehouseAdjustmentTypes.Name END AS JournalTypeName,                   ISNULL(Suppliers.Code, LocationIssues.Name) AS LineForeignCode, ISNULL(Suppliers.Name, WarehouseIssues.Name) AS LineForeignName, GoodsReceiptDetails.PrimaryReferences AS LineReferences, SupplierCategories.Name AS CustomerCategoryName, NULL AS TeamName, NULL AS SalespersonName " + "\r\n";


            if (nmvnTaskID == GlobalEnums.NmvnTaskID.WarehouseAdjustment)
                queryString = queryString + "               9000 + WarehouseAdjustmentDetails.WarehouseAdjustmentTypeID AS JournalTypeID, WarehouseAdjustmentTypes.Name AS JournalTypeName,                   WarehouseAdjustmentTypes.Code AS LineForeignCode, WarehouseAdjustmentTypes.Name AS LineForeignName, WarehouseAdjustmentDetails.Reference + ' ' + WarehouseAdjustmentDetails.AdjustmentJobs AS LineReferences, NULL AS CustomerCategoryName, NULL AS TeamName, NULL AS SalespersonName " + "\r\n";


            queryString = queryString + "       FROM        " + tableName + " " + "\r\n";

            queryString = queryString + "                   INNER JOIN Locations ON " + (nmvnTaskID == GlobalEnums.NmvnTaskID.WarehouseAdjustment ? tableName + ".Quantity < 0 AND " : "") + tableName + ".EntryDate >= @FromDate AND " + tableName + ".EntryDate <= @ToDate AND " + tableName + ".OrganizationalUnitID IN (SELECT OrganizationalUnitID FROM AccessControls WHERE UserID = @UserID AND NMVNTaskID = " + (int)nmvnTaskID + " AND AccessControls.AccessLevel > 0) AND " + (isGoodsIssueTypeID ? tableName + ".GoodsIssueTypeID IN (SELECT Id FROM dbo.SplitToIntList (@GoodsIssueTypeIDs)) AND " : "") + (isGoodsReceiptTypeID ? tableName + ".GoodsReceiptTypeID IN (SELECT Id FROM dbo.SplitToIntList (@GoodsReceiptTypeIDs)) AND " : "") + (isLocationID || isWarehouseID ? "(" + (isLocationID ? "" + tableName + ".LocationID IN (SELECT Id FROM dbo.SplitToIntList (@LocationIDs)) " : "") + (isLocationID && isWarehouseID ? " OR " : "") + (isWarehouseID ? "" + tableName + ".WarehouseID IN (SELECT Id FROM dbo.SplitToIntList (@WarehouseIDs)) " : "") + ") AND " : "") + " " + tableName + ".LocationID = Locations.LocationID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Warehouses ON " + tableName + ".WarehouseID = Warehouses.WarehouseID " + "\r\n";

            queryString = queryString + "                   INNER JOIN Commodities ON " + (isCommodityCategoryID || isCommodityID ? "(" + (isCommodityCategoryID ? "Commodities.CommodityCategoryID IN (SELECT Id FROM dbo.SplitToIntList (@CommodityCategoryIDs))" : "") + (isCommodityCategoryID && isCommodityID ? " OR " : "") + (isCommodityID ? "Commodities.CommodityID IN (SELECT Id FROM dbo.SplitToIntList (@CommodityIDs)) " : "") + ") AND " : "") + " " + tableName + ".CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN CommodityCategories ON " + " Commodities.CommodityCategoryID = CommodityCategories.CommodityCategoryID " + "\r\n";

            queryString = queryString + "                   INNER JOIN CommodityTypes ON " + (isCommodityTypeID ? "Commodities.CommodityTypeID IN (SELECT Id FROM dbo.SplitToIntList (@CommodityTypeIDs)) AND " : "") + " Commodities.CommodityTypeID = CommodityTypes.CommodityTypeID " + "\r\n";


            if (nmvnTaskID == GlobalEnums.NmvnTaskID.GoodsIssue)
                queryString = queryString + "               INNER JOIN GoodsIssueTypes ON GoodsIssueDetails.GoodsIssueTypeID = GoodsIssueTypes.GoodsIssueTypeID " + "\r\n";
            if (nmvnTaskID == GlobalEnums.NmvnTaskID.GoodsReceipt)
                queryString = queryString + "               INNER JOIN GoodsReceiptTypes ON GoodsReceiptDetails.GoodsReceiptTypeID = GoodsReceiptTypes.GoodsReceiptTypeID " + "\r\n";


            queryString = queryString + "                   LEFT JOIN Pallets ON " + tableName + ".PalletID = Pallets.PalletID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Cartons ON " + tableName + ".CartonID = Cartons.CartonID " + "\r\n";

            return queryString;
        }





        private string WHLReceipt06(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@GoodsReceiptTypeIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.BUILDGoodsReceiptType(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.BUILDGoodsReceiptType(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string BUILDGoodsReceiptType(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID, bool isGoodsReceiptTypeID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@SupplierCategoryIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.BUILDSupplierCategory(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, isGoodsReceiptTypeID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.BUILDSupplierCategory(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, isGoodsReceiptTypeID, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string BUILDSupplierCategory(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID, bool isGoodsReceiptTypeID, bool isSupplierCategoryID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@LocationIssueIDs <> '') " + "\r\n";
            queryString = queryString + "                   EXEC WHLReceipt08" + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isCommodityCategoryID.ToString().Substring(0, 1) + isCommodityID.ToString().Substring(0, 1) + isCommodityTypeID.ToString().Substring(0, 1) + isGoodsReceiptTypeID.ToString().Substring(0, 1) + isSupplierCategoryID.ToString().Substring(0, 1) + true.ToString().Substring(0, 1) + this.BUILDParameter(false) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   EXEC WHLReceipt08" + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isCommodityCategoryID.ToString().Substring(0, 1) + isCommodityID.ToString().Substring(0, 1) + isCommodityTypeID.ToString().Substring(0, 1) + isGoodsReceiptTypeID.ToString().Substring(0, 1) + isSupplierCategoryID.ToString().Substring(0, 1) + false.ToString().Substring(0, 1) + this.BUILDParameter(false) + "\r\n";
            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private void WarehouseLedgerReceipt08()
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
                                foreach (bool isGoodsReceiptTypeID in boolArray)
                                {
                                    foreach (bool isSupplierCategoryID in boolArray)
                                    {
                                        foreach (bool isLocationIssueID in boolArray)
                                        {
                                            this.totalSmartCodingEntities.CreateStoredProcedure("WHLReceipt08" + isLocationID.ToString().Substring(0, 1) + isWarehouseID.ToString().Substring(0, 1) + isCommodityCategoryID.ToString().Substring(0, 1) + isCommodityID.ToString().Substring(0, 1) + isCommodityTypeID.ToString().Substring(0, 1) + isGoodsReceiptTypeID.ToString().Substring(0, 1) + isSupplierCategoryID.ToString().Substring(0, 1) + isLocationIssueID.ToString().Substring(0, 1), this.BUILDHeader(false, false) + this.BUILDLocationIssue(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, isGoodsReceiptTypeID, isSupplierCategoryID, isLocationIssueID));
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }


        private string BUILDLocationIssue(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID, bool isGoodsReceiptTypeID, bool isSupplierCategoryID, bool isLocationIssueID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@SupplierIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.BUILDSupplier(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, isGoodsReceiptTypeID, isSupplierCategoryID, isLocationIssueID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.BUILDSupplier(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, isGoodsReceiptTypeID, isSupplierCategoryID, isLocationIssueID, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string BUILDSupplier(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID, bool isGoodsReceiptTypeID, bool isSupplierCategoryID, bool isLocationIssueID, bool isSupplierID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@WarehouseIssueIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.BUILDWarehouseIssue(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, isGoodsReceiptTypeID, isSupplierCategoryID, isLocationIssueID, isSupplierID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.BUILDWarehouseIssue(isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, isGoodsReceiptTypeID, isSupplierCategoryID, isLocationIssueID, isSupplierID, false) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }

        private string BUILDWarehouseIssue(bool isLocationID, bool isWarehouseID, bool isCommodityCategoryID, bool isCommodityID, bool isCommodityTypeID, bool isGoodsReceiptTypeID, bool isSupplierCategoryID, bool isLocationIssueID, bool isSupplierID, bool isWarehouseIssueID)
        {
            string queryString = "";

            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF         (@WarehouseAdjustmentTypeIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.WarehouseLedgerBUILD(false, isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY.Alls, false, false, false, false, false, false, true, isGoodsReceiptTypeID, isSupplierCategoryID, isLocationIssueID, isSupplierID, isWarehouseIssueID) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "                   " + this.WarehouseLedgerBUILD(false, isLocationID, isWarehouseID, isCommodityCategoryID, isCommodityID, isCommodityTypeID, GlobalEnums.GoodsIssueTypeID_REPORTONLY.Alls, false, false, false, false, false, false, false, isGoodsReceiptTypeID, isSupplierCategoryID, isLocationIssueID, isSupplierID, isWarehouseIssueID) + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            return queryString;
        }
        #endregion WarehouseLedgers
    }
}

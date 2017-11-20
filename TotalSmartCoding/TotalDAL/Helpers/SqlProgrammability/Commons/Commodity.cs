﻿using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

using TotalDAL.Helpers.SqlProgrammability.Sales;

namespace TotalDAL.Helpers.SqlProgrammability.Commons
{
    public class Commodity
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public Commodity(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
            this.GetCommodityIndexes();

            //this.CommodityEditable(); 
            //this.CommoditySaveRelative();

            this.GetCommodityBases();
            this.SearchCommodities();

            this.SearchBarcodes();
        }


        private void GetCommodityIndexes()
        {
            string queryString;

            queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      Commodities.CommodityID, Commodities.Code, Commodities.Name " + "\r\n";
            queryString = queryString + "       FROM        Commodities " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetCommodityIndexes", queryString);
        }


        private void CommoditySaveRelative()
        {
            string queryString = " @EntityID int, @SaveRelativeOption int " + "\r\n"; //SaveRelativeOption: 1: Update, -1:Undo
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF (@SaveRelativeOption = 1) " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";

            queryString = queryString + "               INSERT INTO CommodityWarehouses (CommodityID, WarehouseID, WarehouseTaskID, EntryDate, Remarks, InActive) " + "\r\n";
            queryString = queryString + "               SELECT      CommodityID, 46 AS WarehouseID, " + (int)GlobalEnums.NmvnTaskID.SalesOrder + " AS WarehouseTaskID, GETDATE(), '', 0 FROM Commodities WHERE CommodityID = @EntityID " + "\r\n";

            queryString = queryString + "               INSERT INTO CommodityWarehouses (CommodityID, WarehouseID, WarehouseTaskID, EntryDate, Remarks, InActive) " + "\r\n";
            queryString = queryString + "               SELECT      Commodities.CommodityID, Warehouses.WarehouseID, " + (int)GlobalEnums.NmvnTaskID.DeliveryAdvice + " AS WarehouseTaskID, GETDATE(), '', 0 FROM Commodities INNER JOIN Warehouses ON Commodities.CommodityID = @EntityID AND Commodities.CommodityCategoryID NOT IN (4, 5, 7, 9, 10, 11, 12) AND Commodities.CommodityCategoryID = Warehouses.WarehouseCategoryID " + "\r\n";

            queryString = queryString + "               INSERT INTO CommodityWarehouses (CommodityID, WarehouseID, WarehouseTaskID, EntryDate, Remarks, InActive) " + "\r\n";
            queryString = queryString + "               SELECT      CommodityID, 82 AS WarehouseID, " + (int)GlobalEnums.NmvnTaskID.DeliveryAdvice + " AS WarehouseTaskID, GETDATE(), '', 0 FROM Commodities WHERE CommodityID = @EntityID AND CommodityCategoryID IN (4, 5, 7, 9, 10, 11, 12) " + "\r\n";

            queryString = queryString + "           END " + "\r\n";

            queryString = queryString + "       ELSE " + "\r\n"; //(@SaveRelativeOption = -1) 
            queryString = queryString + "           DELETE      CommodityWarehouses WHERE CommodityID = @EntityID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("CommoditySaveRelative", queryString);
        }


        private void CommodityEditable()
        {
            string[] queryArray = new string[0];

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = CommodityID FROM Commodities WHERE CommodityID = @EntityID AND (InActive = 1 OR InActivePartial = 1)"; //Don't allow approve after void
            //queryArray[1] = " SELECT TOP 1 @FoundEntity = CommodityID FROM GoodsIssueDetails WHERE CommodityID = @EntityID ";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("CommodityEditable", queryArray);
        }


        private void GetCommodityBases()
        {
            string queryString;

            queryString = " " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      CommodityID, Code, Name, Unit, APICode, Volume, PackageSize, PackageVolume, FillingLineIDs " + "\r\n";
            queryString = queryString + "       FROM        Commodities " + "\r\n";
            queryString = queryString + "       WHERE       InActive = 0 " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetCommodityBases", queryString);
        }

        private void SearchCommodities()
        {
            string queryString;

            //THIS SearchCommodities NOW IS USED BY Add new item in SALES ORDER, and new TRANSFER ORDER. 
            //IT ALSO MAY BE USED BY Add new item in DELIVERY ADVICE. BUT, AT CURRENT: We only convert from SALES ORDER to DELIVERY ADVICE
            queryString = " @CommodityID int, @LocationID int, @BatchID int, @DeliveryAdviceID int, @TransferOrderID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       DECLARE     @SearchCommodities TABLE (LocationID int NOT NULL, BatchID int NULL, CommodityID int NOT NULL, Code nvarchar(50) NOT NULL, Name nvarchar(200) NOT NULL, CommodityCategoryID int NOT NULL, CommodityTypeID int NOT NULL, Unit nvarchar(10) NULL, PackageSize nvarchar(60) NULL, Volume decimal(18, 3) NOT NULL, PackageVolume decimal(18, 3) NOT NULL) " + "\r\n";
            queryString = queryString + "                   " + GenerateSQLCommoditiesAvailable.BuildSQL("@SalesOrderDetails", false, false, true, false, false, true, false) + "\r\n";

            queryString = queryString + "       INSERT INTO @SearchCommodities SELECT @LocationID, @BatchID, CommodityID, Code, Name, CommodityCategoryID, CommodityTypeID, Unit, PackageSize, Volume, PackageVolume FROM Commodities WHERE CommodityID = @CommodityID " + "\r\n";
            
            queryString = queryString + "       IF (@BatchID > 0) " + "\r\n";
            queryString = queryString + "           " + this.BuildSQLSearchCommodities(true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           " + this.BuildSQLSearchCommodities(false) + "\r\n";

            queryString = queryString + "       SELECT      SearchCommodities.LocationID, SearchCommodities.BatchID, SearchCommodities.CommodityID, SearchCommodities.Code, SearchCommodities.Name, SearchCommodities.CommodityCategoryID, SearchCommodities.CommodityTypeID, SearchCommodities.Unit, SearchCommodities.PackageSize, SearchCommodities.Volume, SearchCommodities.PackageVolume, " + "\r\n";
            queryString = queryString + "                   ISNULL(CommoditiesAvailable.QuantityAvailable, 0) AS QuantityAvailable, ISNULL(CommoditiesAvailable.LineVolumeAvailable, 0) AS LineVolumeAvailable, ISNULL(CommoditiesAvailableByBatches.QuantityAvailable, 0) AS QuantityBatchAvailable, ISNULL(CommoditiesAvailableByBatches.LineVolumeAvailable, 0) AS LineVolumeBatchAvailable " + "\r\n";

            queryString = queryString + "       FROM        @SearchCommodities SearchCommodities " + "\r\n";
            queryString = queryString + "                   LEFT JOIN (SELECT CommodityID, SUM(QuantityAvailable) AS QuantityAvailable, SUM(LineVolumeAvailable) AS LineVolumeAvailable FROM @CommoditiesAvailable GROUP BY CommodityID) CommoditiesAvailable ON SearchCommodities.CommodityID = CommoditiesAvailable.CommodityID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN (SELECT CommodityID, BatchID, SUM(QuantityAvailable) AS QuantityAvailable, SUM(LineVolumeAvailable) AS LineVolumeAvailable FROM @CommoditiesAvailableByBatches GROUP BY CommodityID, BatchID) CommoditiesAvailableByBatches ON SearchCommodities.BatchID = CommoditiesAvailableByBatches.BatchID AND SearchCommodities.CommodityID = CommoditiesAvailableByBatches.CommodityID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("SearchCommodities", queryString);
        }

        private string BuildSQLSearchCommodities(bool byBatchID)
        {
            string queryString = "";
            queryString = queryString + "   BEGIN " + "\r\n";

            queryString = queryString + "       IF (@DeliveryAdviceID > 0) " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   " + GenerateSQLCommoditiesAvailable.BuildSQL("@SearchCommodities", true, false, false, true, true, byBatchID, false) + "\r\n";
            queryString = queryString + "               END " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           IF (@TransferOrderID > 0) " + "\r\n";
            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       " + GenerateSQLCommoditiesAvailable.BuildSQL("@SearchCommodities", false, true, false, true, true, byBatchID, false) + "\r\n";
            queryString = queryString + "                   END " + "\r\n";
            queryString = queryString + "           ELSE " + "\r\n";
            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       " + GenerateSQLCommoditiesAvailable.BuildSQL("@SearchCommodities", false, false, false, true, false, byBatchID, false) + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }


        private void SearchBarcodes()
        {
            string queryString;

            queryString = " @Barcode varchar(50) " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       DECLARE     @PackID int, @CartonID int, @PalletID int, @PackCode varchar(50), @CartonCode varchar(50), @PalletCode varchar(50) " + "\r\n";
            queryString = queryString + "       DECLARE     @BarcodeResults TABLE (LocationID int NOT NULL, CommodityID int NOT NULL, PackID int NULL, CartonID int NULL, PalletID int NULL, EntryDate datetime NOT NULL, Quantity decimal(18, 3) NOT NULL, LineVolume decimal(18, 3) NOT NULL, Description nvarchar(100) NULL) " + "\r\n";

            queryString = queryString + "       IF LEN(@Barcode) > 10 " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            

            //FIND ID
            queryString = queryString + "               IF SUBSTRING (@Barcode, 7, 1 ) = 'B' " + "\r\n";
            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       SELECT TOP 1 @PackID = PackID, @CartonID = CartonID, @PackCode = Code FROM Packs WHERE Code = @Barcode " + "\r\n";
            queryString = queryString + "                       IF NOT @CartonID IS NULL " + "\r\n";
            queryString = queryString + "                           SELECT TOP 1 @PalletID = PalletID, @CartonCode = Code FROM Cartons WHERE CartonID = @CartonID " + "\r\n";
            queryString = queryString + "                       IF NOT @PalletID IS NULL " + "\r\n";
            queryString = queryString + "                           SELECT TOP 1 @PalletCode = Code FROM Pallets WHERE PalletID = @PalletID " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "               IF SUBSTRING (@Barcode, 7, 1 ) = 'C' " + "\r\n";
            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       SELECT TOP 1 @CartonID = CartonID, @PalletID = PalletID, @CartonCode = Code FROM Cartons WHERE Code = @Barcode " + "\r\n";
            queryString = queryString + "                       IF NOT @PalletID IS NULL " + "\r\n";
            queryString = queryString + "                           SELECT TOP 1 @PalletCode = Code FROM Pallets WHERE PalletID = @PalletID " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "               IF SUBSTRING (@Barcode, 7, 1 ) = 'P' " + "\r\n";
            queryString = queryString + "                       SELECT TOP 1 @PalletID = PalletID, @PalletCode = Code FROM Pallets WHERE Code = @Barcode " + "\r\n";


            //GET TRANSACTION
            queryString = queryString + "               IF (NOT @PackID IS NULL) OR (NOT @CartonID IS NULL) OR (NOT @PalletID IS NULL) " + "\r\n";
            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       IF (NOT @PackID IS NULL) " + "\r\n";
            queryString = queryString + "                           INSERT INTO @BarcodeResults SELECT LocationID, CommodityID, PackID, NULL AS CartonID, NULL AS PalletID, EntryDate, 0 AS Quantity, 0 AS LineVolume, 'Production' FROM Packs WHERE PackID = @PackID " + "\r\n";
            queryString = queryString + "                       IF (NOT @CartonID IS NULL) " + "\r\n";
            queryString = queryString + "                           INSERT INTO @BarcodeResults SELECT LocationID, CommodityID, NULL AS PackID, CartonID, NULL AS PalletID, EntryDate, Quantity, LineVolume, 'Production' FROM Cartons WHERE CartonID = @CartonID " + "\r\n";
            queryString = queryString + "                       IF (NOT @PalletID IS NULL) " + "\r\n";
            queryString = queryString + "                           INSERT INTO @BarcodeResults SELECT LocationID, CommodityID, NULL AS PackID, NULL AS CartonID, PalletID, EntryDate, Quantity, LineVolume, 'Production' FROM Pallets WHERE PalletID = @PalletID " + "\r\n";

            queryString = queryString + "                       INSERT INTO @BarcodeResults SELECT LocationID, CommodityID, PackID, CartonID, PalletID, EntryDate, Quantity, LineVolume, 'Pickup' FROM PickupDetails WHERE PackID = @PackID OR CartonID = @CartonID OR PalletID = @PalletID " + "\r\n";
            queryString = queryString + "                       INSERT INTO @BarcodeResults SELECT LocationID, CommodityID, PackID, CartonID, PalletID, EntryDate, Quantity, LineVolume, 'Receipt from ' +  GoodsReceiptTypes.Name FROM GoodsReceiptDetails INNER JOIN GoodsReceiptTypes ON GoodsReceiptDetails.GoodsReceiptTypeID = GoodsReceiptTypes.GoodsReceiptTypeID WHERE PackID = @PackID OR CartonID = @CartonID OR PalletID = @PalletID " + "\r\n";
            queryString = queryString + "                       INSERT INTO @BarcodeResults SELECT LocationID, CommodityID, PackID, CartonID, PalletID, EntryDate, Quantity, LineVolume, 'Issue for ' +  GoodsIssueTypes.Name FROM GoodsIssueDetails INNER JOIN GoodsIssueTypes ON GoodsIssueDetails.GoodsIssueTypeID = GoodsIssueTypes.GoodsIssueTypeID WHERE PackID = @PackID OR CartonID = @CartonID OR PalletID = @PalletID " + "\r\n";
            queryString = queryString + "                       INSERT INTO @BarcodeResults SELECT LocationID, CommodityID, PackID, CartonID, PalletID, EntryDate, Quantity, LineVolume, WarehouseAdjustmentTypes.Name FROM WarehouseAdjustmentDetails INNER JOIN WarehouseAdjustmentTypes ON WarehouseAdjustmentDetails.WarehouseAdjustmentTypeID = WarehouseAdjustmentTypes.WarehouseAdjustmentTypeID WHERE PackID = @PackID OR CartonID = @CartonID OR PalletID = @PalletID " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "           END " + "\r\n";

            //RETURN RESULT
            queryString = queryString + "       SELECT      BarcodeResults.EntryDate, Locations.Name AS LocationName, Commodities.CommodityID, Commodities.Code, Commodities.Name, Commodities.PackageSize, Commodities.Volume, BarcodeResults.Quantity, BarcodeResults.LineVolume, " + "\r\n";
            queryString = queryString + "                   PackID, CASE WHEN NOT PackID IS NULL THEN @PackCode ELSE NULL END AS PackCode, CartonID, CASE WHEN NOT CartonID IS NULL THEN @CartonCode ELSE NULL END AS CartonCode, PalletID, CASE WHEN NOT PalletID IS NULL THEN @PalletCode ELSE NULL END AS PalletCode, BarcodeResults.Description " + "\r\n";
            queryString = queryString + "       FROM        @BarcodeResults BarcodeResults " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON BarcodeResults.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Locations ON BarcodeResults.LocationID = Locations.LocationID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("SearchBarcodes", queryString);
        }

    }
}

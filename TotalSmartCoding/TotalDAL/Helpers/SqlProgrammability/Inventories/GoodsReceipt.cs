using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Inventories
{
    public class GoodsReceipt
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public GoodsReceipt(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
            this.GetGoodsReceiptIndexes();


            this.GetGoodsReceiptViewDetails();

            this.GetPendingPickupWarehouses();
            this.GetPendingPickups();
            this.GetPendingPickupDetails();
            this.GetPendingWarehouseAdjustmentDetails();
            this.GetGoodsReceiptIDofWarehouseAdjustment();

            this.GoodsReceiptSaveRelative();
            this.GoodsReceiptPostSaveValidate();

            this.GoodsReceiptApproved();
            this.GoodsReceiptEditable();

            this.GoodsReceiptToggleApproved();

            this.GoodsReceiptInitReference();


            this.GetGoodsReceiptDetailAvailables();
        }


        private void GetGoodsReceiptIndexes()
        {
            string queryString;

            queryString = " @AspUserID nvarchar(128), @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      GoodsReceipts.GoodsReceiptID, CAST(GoodsReceipts.EntryDate AS DATE) AS EntryDate, GoodsReceipts.Reference, GoodsReceiptTypes.Code AS GoodsReceiptTypeCode, GoodsReceipts.PickupReferences, Locations.Code AS LocationCode, Warehouses.Name AS WarehouseName, GoodsReceipts.Description, GoodsReceipts.TotalQuantity, GoodsReceipts.TotalLineVolume, GoodsReceipts.Approved " + "\r\n";
            queryString = queryString + "       FROM        GoodsReceipts " + "\r\n";
            queryString = queryString + "                   INNER JOIN Locations ON GoodsReceipts.EntryDate >= @FromDate AND GoodsReceipts.EntryDate <= @ToDate AND GoodsReceipts.OrganizationalUnitID IN (SELECT AccessControls.OrganizationalUnitID FROM AccessControls INNER JOIN AspNetUsers ON AccessControls.UserID = AspNetUsers.UserID WHERE AspNetUsers.Id = @AspUserID AND AccessControls.NMVNTaskID = " + (int)TotalBase.Enums.GlobalEnums.NmvnTaskID.GoodsReceipt + " AND AccessControls.AccessLevel > 0) AND Locations.LocationID = GoodsReceipts.LocationID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Warehouses ON GoodsReceipts.WarehouseID = Warehouses.WarehouseID " + "\r\n";
            queryString = queryString + "                   INNER JOIN GoodsReceiptTypes ON GoodsReceipts.GoodsReceiptTypeID = GoodsReceiptTypes.GoodsReceiptTypeID " + "\r\n";
            queryString = queryString + "       " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetGoodsReceiptIndexes", queryString);
        }


        #region X


        private void GetGoodsReceiptViewDetails()
        {
            string queryString;

            queryString = " @GoodsReceiptID Int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      GoodsReceiptDetails.GoodsReceiptDetailID, GoodsReceiptDetails.GoodsReceiptID, GoodsReceiptDetails.PickupID, GoodsReceiptDetails.PickupDetailID, PickupDetails.Reference AS PickupReference, PickupDetails.EntryDate AS PickupEntryDate, " + "\r\n";
            queryString = queryString + "                   Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, GoodsReceiptDetails.BatchID, GoodsReceiptDetails.BatchEntryDate, GoodsReceiptDetails.BinLocationID, BinLocations.Code AS BinLocationCode, " + "\r\n";
            queryString = queryString + "                   GoodsReceiptDetails.PackID, Packs.Code AS PackCode, GoodsReceiptDetails.CartonID, Cartons.Code AS CartonCode, GoodsReceiptDetails.PalletID, Pallets.Code AS PalletCode, " + "\r\n";
            queryString = queryString + "                   GoodsReceiptDetails.Quantity, GoodsReceiptDetails.PackCounts, GoodsReceiptDetails.CartonCounts, GoodsReceiptDetails.PalletCounts, GoodsReceiptDetails.LineVolume, GoodsReceiptDetails.Remarks " + "\r\n";
            queryString = queryString + "       FROM        GoodsReceiptDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON GoodsReceiptDetails.GoodsReceiptID = @GoodsReceiptID AND GoodsReceiptDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN BinLocations ON GoodsReceiptDetails.BinLocationID = BinLocations.BinLocationID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN PickupDetails ON GoodsReceiptDetails.PickupDetailID = PickupDetails.PickupDetailID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Packs ON GoodsReceiptDetails.PackID = Packs.PackID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Cartons ON GoodsReceiptDetails.CartonID = Cartons.CartonID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Pallets ON GoodsReceiptDetails.PalletID = Pallets.PalletID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetGoodsReceiptViewDetails", queryString);
        }





        #region Y

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
            queryString = queryString + "                   " + this.BuildSQLNew(isPickupID, isPickupDetailIDs) + "\r\n";
            queryString = queryString + "                   ORDER BY PickupDetails.EntryDate, PickupDetails.PickupID, PickupDetails.PickupDetailID " + "\r\n";
            queryString = queryString + "               END " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";

            queryString = queryString + "               IF (@IsReadonly = 1) " + "\r\n";
            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       " + this.BuildSQLEdit(isPickupID, isPickupDetailIDs) + "\r\n";
            queryString = queryString + "                       ORDER BY PickupDetails.EntryDate, PickupDetails.PickupID, PickupDetails.PickupDetailID " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "               ELSE " + "\r\n"; //FULL SELECT FOR EDIT MODE

            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       " + this.BuildSQLNew(isPickupID, isPickupDetailIDs) + " WHERE PickupDetails.PickupDetailID NOT IN (SELECT PickupDetailID FROM GoodsReceiptDetails WHERE GoodsReceiptID = @GoodsReceiptID) " + "\r\n";
            queryString = queryString + "                       UNION ALL " + "\r\n";
            queryString = queryString + "                       " + this.BuildSQLEdit(isPickupID, isPickupDetailIDs) + "\r\n";
            queryString = queryString + "                       ORDER BY PickupDetails.EntryDate, PickupDetails.PickupID, PickupDetails.PickupDetailID " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        private string BuildSQLNew(bool isPickupID, bool isPickupDetailIDs)
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

        private string BuildSQLEdit(bool isPickupID, bool isPickupDetailIDs)
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


        private void GetGoodsReceiptIDofWarehouseAdjustment()
        {
            string queryString;

            queryString = " @WarehouseAdjustmentID Int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "   SELECT TOP 1 GoodsReceiptID FROM GoodsReceipts WHERE WarehouseAdjustmentID = @WarehouseAdjustmentID " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetGoodsReceiptIDofWarehouseAdjustment", queryString);
        }

        #endregion WarehouseAdjustment

        #endregion Y




        private void GoodsReceiptSaveRelative()
        {
            string queryString = " @EntityID int, @SaveRelativeOption int " + "\r\n"; //SaveRelativeOption: 1: Update, -1:Undo
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       BEGIN " + "\r\n";

            queryString = queryString + "           IF (@SaveRelativeOption = 1) ";
            queryString = queryString + "               BEGIN ";
            queryString = queryString + "                   UPDATE          GoodsReceiptDetails " + "\r\n";
            queryString = queryString + "                   SET             GoodsReceiptDetails.Reference = GoodsReceipts.Reference " + "\r\n";
            queryString = queryString + "                   FROM            GoodsReceipts INNER JOIN GoodsReceiptDetails ON GoodsReceipts.GoodsReceiptID = @EntityID AND GoodsReceipts.GoodsReceiptID = GoodsReceiptDetails.GoodsReceiptID " + "\r\n";
            queryString = queryString + "               END ";

            queryString = queryString + "           DECLARE @HasPickup bit, @WarehouseAdjustmentID int, @AffectedROWCOUNT int ";
            queryString = queryString + "           SELECT @HasPickup = HasPickup, @WarehouseAdjustmentID = WarehouseAdjustmentID FROM GoodsReceipts WHERE GoodsReceiptID = @EntityID ";
            queryString = queryString + "           IF (@HasPickup = 1 OR NOT @WarehouseAdjustmentID IS NULL) " + "\r\n";
            queryString = queryString + "               BEGIN  " + "\r\n";

            queryString = queryString + "                   IF (@HasPickup = 1) " + "\r\n";
            queryString = queryString + "                       BEGIN  " + "\r\n";
            queryString = queryString + "                           UPDATE          PickupDetails " + "\r\n";
            queryString = queryString + "                           SET             PickupDetails.QuantityReceipt = ROUND(PickupDetails.QuantityReceipt + GoodsReceiptDetails.Quantity * @SaveRelativeOption, " + (int)GlobalEnums.rndQuantity + "), PickupDetails.LineVolumeReceipt = ROUND(PickupDetails.LineVolumeReceipt + GoodsReceiptDetails.LineVolume * @SaveRelativeOption, " + (int)GlobalEnums.rndVolume + ") " + "\r\n";
            queryString = queryString + "                           FROM            GoodsReceiptDetails " + "\r\n";
            queryString = queryString + "                                           INNER JOIN PickupDetails ON PickupDetails.Approved = 1 AND GoodsReceiptDetails.GoodsReceiptID = @EntityID AND GoodsReceiptDetails.PickupDetailID = PickupDetails.PickupDetailID " + "\r\n";
            queryString = queryString + "                           SET @AffectedROWCOUNT = @@ROWCOUNT " + "\r\n";
            queryString = queryString + "                       END " + "\r\n";

            queryString = queryString + "                   IF (NOT @WarehouseAdjustmentID IS NULL) " + "\r\n"; //HERE: THIS WILL BE CORRECT: WHEN ONLY 1 GoodsReceipts FOR A WarehouseAdjustments
            queryString = queryString + "                       BEGIN  " + "\r\n";
            queryString = queryString + "                           UPDATE          WarehouseAdjustmentDetails " + "\r\n";
            queryString = queryString + "                           SET             WarehouseAdjustmentDetails.QuantityReceipt = ROUND(WarehouseAdjustmentDetails.QuantityReceipt + GoodsReceiptDetails.Quantity * @SaveRelativeOption, " + (int)GlobalEnums.rndQuantity + "), WarehouseAdjustmentDetails.LineVolumeReceipt = ROUND(WarehouseAdjustmentDetails.LineVolumeReceipt + GoodsReceiptDetails.LineVolume * @SaveRelativeOption, " + (int)GlobalEnums.rndVolume + ") " + "\r\n";
            queryString = queryString + "                           FROM            GoodsReceiptDetails " + "\r\n";
            queryString = queryString + "                                           INNER JOIN WarehouseAdjustmentDetails ON WarehouseAdjustmentDetails.Quantity > 0 AND GoodsReceiptDetails.GoodsReceiptID = @EntityID AND GoodsReceiptDetails.WarehouseAdjustmentDetailID = WarehouseAdjustmentDetails.WarehouseAdjustmentDetailID " + "\r\n";
            queryString = queryString + "                           SET @AffectedROWCOUNT = @@ROWCOUNT " + "\r\n";
            //------------------------------------------------------SHOULD UPDATE GoodsReceiptID, GoodsReceiptDetailID BACK TO WarehouseAdjustmentDetails FOR GoodsReceipts OF WarehouseAdjustmentDetails? THE ANSWER: WE CAN DO IT HERE, BUT IT BREAK THE RELATIONSHIP (cyclic redundancy relationship: GoodsReceiptDetails => WarehouseAdjustmentDetails => THUS: WE SHOULD NOT MAKE ANOTHER RELATIONSHIP FROM WarehouseAdjustmentDetails => GoodsReceiptDetails ) => SO: SHOULD NOT!!!
            queryString = queryString + "                       END " + "\r\n";

            queryString = queryString + "                   IF @AffectedROWCOUNT <> (SELECT COUNT(*) FROM GoodsReceiptDetails WHERE GoodsReceiptID = @EntityID) " + "\r\n";
            queryString = queryString + "                       BEGIN " + "\r\n";
            queryString = queryString + "                           DECLARE     @msg NVARCHAR(300) = N'Phiếu giao hàng đã hủy, hoặc chưa duyệt' ; " + "\r\n";
            queryString = queryString + "                           THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "                       END " + "\r\n";

            queryString = queryString + "               END  " + "\r\n";

            queryString = queryString + "       END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GoodsReceiptSaveRelative", queryString);
        }

        private void GoodsReceiptPostSaveValidate()
        {
            string[] queryArray = new string[2];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = N'Ngày giao hàng: ' + CAST(Pickups.EntryDate AS nvarchar) FROM GoodsReceiptDetails INNER JOIN Pickups ON GoodsReceiptDetails.GoodsReceiptID = @EntityID AND GoodsReceiptDetails.PickupID = Pickups.PickupID AND GoodsReceiptDetails.EntryDate < Pickups.EntryDate ";
            queryArray[1] = " SELECT TOP 1 @FoundEntity = N'Số lượng nhập kho vượt quá số lượng giao: ' + CAST(ROUND(Quantity - QuantityReceipt, " + (int)GlobalEnums.rndQuantity + ") AS nvarchar) FROM PickupDetails WHERE (ROUND(Quantity - QuantityReceipt, " + (int)GlobalEnums.rndQuantity + ") < 0) ";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("GoodsReceiptPostSaveValidate", queryArray);
        }




        private void GoodsReceiptApproved()
        {
            string[] queryArray = new string[1];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = GoodsReceiptID FROM GoodsReceipts WHERE GoodsReceiptID = @EntityID AND Approved = 1";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("GoodsReceiptApproved", queryArray);
        }


        private void GoodsReceiptEditable()
        {
            string[] queryArray = new string[2]; //IMPORTANT: THESE QUERIES SHOULD BE COPIED TO WarehouseAdjustmentEditable

            queryArray[0] = " SELECT TOP 1 @FoundEntity = GoodsReceiptID FROM GoodsIssueDetails WHERE GoodsReceiptID = @EntityID ";
            queryArray[1] = " SELECT TOP 1 @FoundEntity = GoodsReceiptID FROM WarehouseAdjustmentDetails WHERE GoodsReceiptID = @EntityID ";
            //queryArray[2] = FOR TRANSFER??

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("GoodsReceiptEditable", queryArray);
        }

        private void GoodsReceiptToggleApproved()
        {
            string queryString = " @EntityID int, @Approved bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       UPDATE      GoodsReceipts  SET Approved = @Approved, ApprovedDate = GetDate() WHERE GoodsReceiptID = @EntityID AND Approved = ~@Approved" + "\r\n";

            queryString = queryString + "       IF @@ROWCOUNT = 1 " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               UPDATE          GoodsReceiptDetails  SET Approved = @Approved WHERE GoodsReceiptID = @EntityID ; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               DECLARE     @msg NVARCHAR(300) = N'Dữ liệu không tồn tại hoặc đã ' + iif(@Approved = 0, 'hủy', '')  + ' duyệt' ; " + "\r\n";
            queryString = queryString + "               THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GoodsReceiptToggleApproved", queryString);
        }

        private void GoodsReceiptInitReference()
        {
            SimpleInitReference simpleInitReference = new SimpleInitReference("GoodsReceipts", "GoodsReceiptID", "Reference", ModelSettingManager.ReferenceLength, ModelSettingManager.ReferencePrefix(GlobalEnums.NmvnTaskID.GoodsReceipt));
            this.totalSmartCodingEntities.CreateTrigger("GoodsReceiptInitReference", simpleInitReference.CreateQuery());
        }



        private void GetGoodsReceiptDetailAvailables()
        {
            string queryString = " @LocationID Int, @WarehouseID Int, @CommodityID Int, @CommodityIDs varchar(3999), @BatchID Int, @GoodsReceiptDetailIDs varchar(3999) " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "   BEGIN " + "\r\n";

            queryString = queryString + "       IF  (@WarehouseID <> 0) " + "\r\n";
            queryString = queryString + "           " + this.AvailableBuildSQLWarehouse(true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           " + this.AvailableBuildSQLWarehouse(false) + "\r\n";

            queryString = queryString + "   END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetGoodsReceiptDetailAvailables", queryString);
        }

        private string AvailableBuildSQLWarehouse(bool isWarehouseID)
        {
            string queryString = "";
            queryString = queryString + "   BEGIN " + "\r\n";

            queryString = queryString + "       IF  (@CommodityID <> 0) " + "\r\n";
            queryString = queryString + "           " + this.AvailableBuildSQLCommmodity(isWarehouseID, true, false) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               IF  (@CommodityIDs <> '') " + "\r\n";
            queryString = queryString + "                   " + this.AvailableBuildSQLCommmodity(isWarehouseID, false, true) + "\r\n";
            queryString = queryString + "               ELSE " + "\r\n";
            queryString = queryString + "                   " + this.AvailableBuildSQLCommmodity(isWarehouseID, false, false) + "\r\n";
            queryString = queryString + "           END " + "\r\n";
            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        private string AvailableBuildSQLCommmodity(bool isWarehouseID, bool isCommodityID, bool isCommodityIDs)
        {
            string queryString = "";
            queryString = queryString + "   BEGIN " + "\r\n";
            queryString = queryString + "       IF  (NOT @BatchID IS NULL) " + "\r\n";
            queryString = queryString + "           " + this.AvailableBuildSQLCommmodityBatch(isWarehouseID, isCommodityID, isCommodityIDs, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           " + this.AvailableBuildSQLCommmodityBatch(isWarehouseID, isCommodityID, isCommodityIDs, false) + "\r\n";
            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        private string AvailableBuildSQLCommmodityBatch(bool isWarehouseID, bool isCommodityID, bool isCommodityIDs, bool isBatchID)
        {
            string queryString = "";
            queryString = queryString + "   BEGIN " + "\r\n";
            queryString = queryString + "       IF  (@GoodsReceiptDetailIDs <> '') " + "\r\n";
            queryString = queryString + "           " + this.AvailableBuildSQLGoodsReceiptDetailIDs(isWarehouseID, isCommodityID, isCommodityIDs, isBatchID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           " + this.AvailableBuildSQLGoodsReceiptDetailIDs(isWarehouseID, isCommodityID, isCommodityIDs, isBatchID, false) + "\r\n";
            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        private string AvailableBuildSQLGoodsReceiptDetailIDs(bool isWarehouseID, bool isCommodityID, bool isCommodityIDs, bool isBatchID, bool isGoodsReceiptDetailIDs)
        {
            string queryString = "";
            queryString = queryString + "   BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      GoodsReceiptDetails.GoodsReceiptID, GoodsReceiptDetails.GoodsReceiptDetailID, GoodsReceiptDetails.Reference AS GoodsReceiptReference, GoodsReceiptDetails.EntryDate AS GoodsReceiptEntryDate, GoodsReceiptDetails.BatchID, GoodsReceiptDetails.BatchEntryDate, GoodsReceiptDetails.WarehouseID, Warehouses.Code AS WarehouseCode, Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.PackageSize, Commodities.Volume, Commodities.PackageVolume, GoodsReceiptDetails.BinLocationID, BinLocations.Code AS BinLocationCode, GoodsReceiptDetails.PackID, Packs.Code AS PackCode, GoodsReceiptDetails.CartonID, Cartons.Code AS CartonCode, GoodsReceiptDetails.PalletID, Pallets.Code AS PalletCode, GoodsReceiptDetails.Remarks, " + "\r\n";
            queryString = queryString + "                   GoodsReceiptDetails.PackCounts, GoodsReceiptDetails.CartonCounts, GoodsReceiptDetails.PalletCounts, ROUND(GoodsReceiptDetails.Quantity - GoodsReceiptDetails.QuantityIssue, " + GlobalEnums.rndQuantity + ") AS QuantityAvailable, ROUND(GoodsReceiptDetails.LineVolume - GoodsReceiptDetails.LineVolumeIssue, " + GlobalEnums.rndVolume + ") AS LineVolumeAvailable, CAST(0 AS bit) AS IsSelected " + "\r\n";

            queryString = queryString + "       FROM        GoodsReceiptDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN Warehouses ON ROUND(GoodsReceiptDetails.Quantity - GoodsReceiptDetails.QuantityIssue, " + GlobalEnums.rndQuantity + ") > 0 AND GoodsReceiptDetails.LocationID = @LocationID " + (isWarehouseID ? " AND GoodsReceiptDetails.WarehouseID = @WarehouseID" : "") + (isCommodityID ? " AND GoodsReceiptDetails.CommodityID = @CommodityID" : "") + (isCommodityIDs ? " AND GoodsReceiptDetails.CommodityID NOT IN (SELECT Id FROM dbo.SplitToIntList (@CommodityIDs))" : "") + " AND GoodsReceiptDetails.Approved = 1 AND Warehouses.Issuable = 1 AND GoodsReceiptDetails.WarehouseID = Warehouses.WarehouseID " + (isBatchID ? " AND GoodsReceiptDetails.BatchID = @BatchID" : "") + (isGoodsReceiptDetailIDs ? " AND GoodsReceiptDetails.GoodsReceiptDetailID NOT IN (SELECT Id FROM dbo.SplitToIntList (@GoodsReceiptDetailIDs))" : "") + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON GoodsReceiptDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN BinLocations ON GoodsReceiptDetails.BinLocationID = BinLocations.BinLocationID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Packs ON GoodsReceiptDetails.PackID = Packs.PackID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Cartons ON GoodsReceiptDetails.CartonID = Cartons.CartonID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Pallets ON GoodsReceiptDetails.PalletID = Pallets.PalletID " + "\r\n";

            queryString = queryString + "       ORDER BY    GoodsReceiptDetails.BatchEntryDate, GoodsReceiptDetails.GoodsReceiptDetailID, BinLocations.Code " + "\r\n";

            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        #endregion
    }
}

using System;
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

    }
}

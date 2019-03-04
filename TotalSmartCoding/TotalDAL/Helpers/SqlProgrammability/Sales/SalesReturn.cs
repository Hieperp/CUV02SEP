using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Sales
{
    public class SalesReturn
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public SalesReturn(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
            this.GetSalesReturnIndexes();

            this.GetSalesReturnViewDetails();

            //THIS BELOW STORED PROCEDURES: ALLOW TO RETURN BY A SPECIFIC GOODSISSUES
            //BUT NOW, AT THE VIEW LAYER: WE ONLY IMPLEMENT FOR RETURN BY DATE RANGE ONLY
            this.GetSalesReturnPendingGoodsIssues();
            this.GetSalesReturnPendingGoodsIssueDetails();

            this.SalesReturnSaveRelative();
            this.SalesReturnPostSaveValidate();

            this.SalesReturnApproved();
            this.SalesReturnEditable();

            this.SalesReturnToggleApproved();

            this.SalesReturnInitReference();
        }


        private void GetSalesReturnIndexes()
        {
            string queryString;

            queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      SalesReturns.SalesReturnID, CAST(SalesReturns.EntryDate AS DATE) AS EntryDate, SalesReturns.Reference, SalesReturns.VoucherCode, SalesReturns.VoucherDate, SalesReturns.GoodsIssueReferences, Locations.Code AS LocationCode, Customers.Code AS CustomerCode, Customers.Name AS CustomerName, SalesReturns.Description, SalesReturns.TotalQuantity, SalesReturns.TotalLineVolume, SalesReturns.Approved " + "\r\n";
            queryString = queryString + "       FROM        SalesReturns " + "\r\n";
            queryString = queryString + "                   INNER JOIN Locations ON SalesReturns.EntryDate >= @FromDate AND SalesReturns.EntryDate <= @ToDate AND SalesReturns.OrganizationalUnitID IN (SELECT OrganizationalUnitID FROM AccessControls WHERE UserID = @UserID AND NMVNTaskID = " + (int)TotalBase.Enums.GlobalEnums.NmvnTaskID.SalesReturns + " AND AccessControls.AccessLevel > 0) AND Locations.LocationID = SalesReturns.LocationID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Customers ON SalesReturns.CustomerID = Customers.CustomerID " + "\r\n";
            queryString = queryString + "       " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetSalesReturnIndexes", queryString);
        }

        #region X


        private void GetSalesReturnViewDetails()
        {
            string queryString;

            queryString = " @SalesReturnID Int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      SalesReturnDetails.SalesReturnDetailID, SalesReturnDetails.SalesReturnID, SalesReturnDetails.GoodsIssueID, SalesReturnDetails.GoodsIssueDetailID, GoodsIssues.Reference AS GoodsIssueReference, GoodsIssues.EntryDate AS GoodsIssueEntryDate, GoodsIssues.VoucherCodes, " + "\r\n";
            queryString = queryString + "                   Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, SalesReturnDetails.BatchID, SalesReturnDetails.BatchEntryDate, " + "\r\n";
            queryString = queryString + "                   SalesReturnDetails.PackID, Packs.Code AS PackCode, SalesReturnDetails.CartonID, Cartons.Code AS CartonCode, SalesReturnDetails.PalletID, Pallets.Code AS PalletCode, " + "\r\n";
            queryString = queryString + "                   SalesReturnDetails.PackCounts, SalesReturnDetails.CartonCounts, SalesReturnDetails.PalletCounts, SalesReturnDetails.Quantity, SalesReturnDetails.LineVolume, SalesReturnDetails.Remarks " + "\r\n";

            queryString = queryString + "       FROM        SalesReturnDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON SalesReturnDetails.SalesReturnID = @SalesReturnID AND SalesReturnDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN GoodsIssues ON SalesReturnDetails.GoodsIssueID = GoodsIssues.GoodsIssueID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Packs ON SalesReturnDetails.PackID = Packs.PackID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Cartons ON SalesReturnDetails.CartonID = Cartons.CartonID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Pallets ON SalesReturnDetails.PalletID = Pallets.PalletID " + "\r\n";
            queryString = queryString + "       ORDER BY    SalesReturnDetails.SalesReturnDetailID DESC " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetSalesReturnViewDetails", queryString);
        }





        #region Y

        private void GetSalesReturnPendingGoodsIssues()
        {
            string queryString = " @LocationID int, @CustomerID int, @ReceiverID int, @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       SET             @ToDate = DATEADD (hour, 23, DATEADD (minute, 59, DATEADD (second, 59, @ToDate))) " + "\r\n";

            queryString = queryString + "       SELECT          GoodsIssues.GoodsIssueID, GoodsIssues.Reference AS GoodsIssueReference, GoodsIssues.EntryDate AS GoodsIssueEntryDate, GoodsIssues.PrimaryReferences, GoodsIssues.VoucherCodes, GoodsIssues.Vehicle, GoodsIssues.VehicleDriver, GoodsIssues.Description, GoodsIssues.Remarks " + "\r\n";
            queryString = queryString + "       FROM            GoodsIssues " + "\r\n";
            queryString = queryString + "       WHERE           LocationID = @LocationID AND CustomerID = @CustomerID AND ReceiverID = @ReceiverID AND EntryDate >= @FromDate AND EntryDate <= @ToDate AND Approved = 1 " + "\r\n";
            queryString = queryString + "       ORDER BY        EntryDate DESC " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetSalesReturnPendingGoodsIssues", queryString);
        }


        private void GetSalesReturnPendingGoodsIssueDetails()
        {
            string queryString;

            queryString = " @LocationID Int, @SalesReturnID Int, @GoodsIssueID Int, @CustomerID Int, @ReceiverID Int, @FromDate DateTime, @ToDate DateTime, @CartonIDs varchar(3999), @PalletIDs varchar(3999) " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "   BEGIN " + "\r\n";
            queryString = queryString + "       SET         @ToDate = DATEADD (hour, 23, DATEADD (minute, 59, DATEADD (second, 59, @ToDate))) " + "\r\n";
            queryString = queryString + "       DECLARE     @GoodsIssueDetails TABLE (GoodsIssueDetailID int NOT NULL, GoodsIssueID int NOT NULL, Reference nvarchar(10) NULL, EntryDate datetime NOT NULL, VoucherCodes nvarchar(100) NULL, CommodityID int NOT NULL, BatchID int NOT NULL, BatchEntryDate date NOT NULL, PackID int NULL, CartonID int NULL, PalletID int NULL, Quantity decimal(18, 2) NOT NULL, LineVolume decimal(18, 2) NOT NULL) " + "\r\n";

            queryString = queryString + "       IF  (NOT @GoodsIssueID IS NULL AND @GoodsIssueID <> 0) " + "\r\n";
            queryString = queryString + "           " + this.BuildSQL(true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           " + this.BuildSQL(false) + "\r\n";


            queryString = queryString + "       IF  (@CartonIDs = '' AND @PalletIDs = '') " + "\r\n";
            queryString = queryString + "           " + this.BuildSQL(false, false) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "               IF  (@CartonIDs <> '' AND @PalletIDs = '') " + "\r\n";
            queryString = queryString + "                   " + this.BuildSQL(true, false) + "\r\n";
            queryString = queryString + "               ELSE " + "\r\n";
            queryString = queryString + "                   IF  (@CartonIDs = '' AND @PalletIDs <> '') " + "\r\n";
            queryString = queryString + "                       " + this.BuildSQL(false, true) + "\r\n";
            queryString = queryString + "                   ELSE " + "\r\n";
            queryString = queryString + "                       " + this.BuildSQL(true, true) + "\r\n";

            queryString = queryString + "   END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetSalesReturnPendingGoodsIssueDetails", queryString);
        }

        private string BuildSQL(bool isGoodsIssueID)
        {
            string queryString = "";
            queryString = queryString + "       INSERT INTO @GoodsIssueDetails (GoodsIssueID, GoodsIssueDetailID, Reference, EntryDate, VoucherCodes, CommodityID, BatchID, BatchEntryDate, PackID, CartonID, PalletID, Quantity, LineVolume) " + "\r\n";
            queryString = queryString + "       SELECT      GoodsIssueDetails.GoodsIssueID, GoodsIssueDetails.GoodsIssueDetailID, GoodsIssues.Reference, GoodsIssueDetails.EntryDate, GoodsIssues.VoucherCodes, GoodsIssueDetails.CommodityID, GoodsIssueDetails.BatchID, GoodsIssueDetails.BatchEntryDate, GoodsIssueDetails.PackID, GoodsIssueDetails.CartonID, GoodsIssueDetails.PalletID, GoodsIssueDetails.Quantity, GoodsIssueDetails.LineVolume " + "\r\n";
            queryString = queryString + "       FROM        GoodsIssueDetails INNER JOIN GoodsIssues ON " + (isGoodsIssueID ? " GoodsIssueDetails.GoodsIssueID = @GoodsIssueID " : "GoodsIssueDetails.LocationID = @LocationID AND GoodsIssueDetails.CustomerID = @CustomerID AND GoodsIssueDetails.ReceiverID = @ReceiverID AND GoodsIssueDetails.EntryDate >= @FromDate AND GoodsIssueDetails.EntryDate <= @ToDate ") + " AND GoodsIssueDetails.Approved = 1 AND GoodsIssueDetails.GoodsIssueID = GoodsIssues.GoodsIssueID " + "\r\n";
            
            return queryString;
        }

        private string BuildSQL(bool isPalletIDs, bool isCartonIDs)
        {
            string queryString = "";

            queryString = queryString + "       SELECT      GoodsIssueCollections.GoodsIssueID, GoodsIssueCollections.GoodsIssueDetailID, GoodsIssueCollections.GoodsIssueReference, GoodsIssueCollections.GoodsIssueEntryDate, GoodsIssueCollections.VoucherCodes, Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.CommodityTypeID, GoodsIssueCollections.BatchID, GoodsIssueCollections.BatchEntryDate, " + "\r\n";
            queryString = queryString + "                   GoodsIssueCollections.PackID, GoodsIssueCollections.PackCode, GoodsIssueCollections.CartonID, GoodsIssueCollections.CartonCode, GoodsIssueCollections.PalletID, GoodsIssueCollections.PalletCode, GoodsIssueCollections.PackCounts, GoodsIssueCollections.CartonCounts, GoodsIssueCollections.PalletCounts, GoodsIssueCollections.Quantity, GoodsIssueCollections.LineVolume, CAST(0 AS bit) AS IsSelected " + "\r\n";

            queryString = queryString + "       FROM       (SELECT      GoodsIssueDetails.GoodsIssueID, GoodsIssueDetails.GoodsIssueDetailID, GoodsIssueDetails.Reference AS GoodsIssueReference, GoodsIssueDetails.EntryDate AS GoodsIssueEntryDate, GoodsIssueDetails.VoucherCodes, GoodsIssueDetails.CommodityID, GoodsIssueDetails.BatchID, GoodsIssueDetails.BatchEntryDate, CAST(NULL AS int) AS PackID, CAST(NULL AS varchar(50)) AS PackCode, Cartons.CartonID, Cartons.Code AS CartonCode, NULL AS PalletID, NULL AS PalletCode, Cartons.PackCounts, 1 AS CartonCounts, 0 AS PalletCounts, Cartons.Quantity, Cartons.LineVolume " + "\r\n";
            queryString = queryString + "                   FROM        @GoodsIssueDetails GoodsIssueDetails INNER JOIN Cartons ON GoodsIssueDetails.CartonID NOT IN (SELECT CartonID FROM SalesReturnDetails WHERE SalesReturnID <> @SalesReturnID AND NOT CartonID IS NULL) AND GoodsIssueDetails.CartonID = Cartons.CartonID " + (isCartonIDs ? " AND GoodsIssueDetails.CartonID NOT IN (SELECT Id FROM dbo.SplitToIntList (@CartonIDs))" : "") + "\r\n";
            queryString = queryString + "                   UNION ALL " + "\r\n";
            queryString = queryString + "                   SELECT      GoodsIssueDetails.GoodsIssueID, GoodsIssueDetails.GoodsIssueDetailID, GoodsIssueDetails.Reference AS GoodsIssueReference, GoodsIssueDetails.EntryDate AS GoodsIssueEntryDate, GoodsIssueDetails.VoucherCodes, GoodsIssueDetails.CommodityID, GoodsIssueDetails.BatchID, GoodsIssueDetails.BatchEntryDate, CAST(NULL AS int) AS PackID, CAST(NULL AS varchar(50)) AS PackCode, Cartons.CartonID, Cartons.Code AS CartonCode, NULL AS PalletID, NULL AS PalletCode, Cartons.PackCounts, 1 AS CartonCounts, 0 AS PalletCounts, Cartons.Quantity, Cartons.LineVolume " + "\r\n";
            queryString = queryString + "                   FROM        @GoodsIssueDetails GoodsIssueDetails INNER JOIN Cartons ON Cartons.CartonID NOT IN (SELECT CartonID FROM SalesReturnDetails WHERE SalesReturnID <> @SalesReturnID AND NOT CartonID IS NULL) AND GoodsIssueDetails.PalletID = Cartons.PalletID " + (isCartonIDs ? " AND Cartons.CartonID NOT IN (SELECT Id FROM dbo.SplitToIntList (@CartonIDs))" : "") + "\r\n";
            queryString = queryString + "                   UNION ALL " + "\r\n";
            queryString = queryString + "                   SELECT      GoodsIssueDetails.GoodsIssueID, GoodsIssueDetails.GoodsIssueDetailID, GoodsIssueDetails.Reference AS GoodsIssueReference, GoodsIssueDetails.EntryDate AS GoodsIssueEntryDate, GoodsIssueDetails.VoucherCodes, GoodsIssueDetails.CommodityID, GoodsIssueDetails.BatchID, GoodsIssueDetails.BatchEntryDate, CAST(NULL AS int) AS PackID, CAST(NULL AS varchar(50)) AS PackCode, NULL AS CartonID, NULL AS CartonCode, Pallets.PalletID, Pallets.Code AS PalletCode, Pallets.PackCounts, Pallets.CartonCounts, 1 AS PalletCounts, Pallets.Quantity, Pallets.LineVolume " + "\r\n";
            queryString = queryString + "                   FROM        @GoodsIssueDetails GoodsIssueDetails INNER JOIN Pallets ON NOT GoodsIssueDetails.PalletID IS NULL AND GoodsIssueDetails.PalletID NOT IN (SELECT DISTINCT PalletID FROM Cartons WHERE NOT PalletID IS NULL) AND GoodsIssueDetails.PalletID NOT IN (SELECT PalletID FROM SalesReturnDetails WHERE SalesReturnID <> @SalesReturnID AND NOT PalletID IS NULL) AND GoodsIssueDetails.PalletID = Pallets.PalletID" + (isPalletIDs ? " AND GoodsIssueDetails.PalletID NOT IN (SELECT Id FROM dbo.SplitToIntList (@PalletIDs))" : "") + "\r\n";
            queryString = queryString + "                  )GoodsIssueCollections " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON GoodsIssueCollections.CommodityID = Commodities.CommodityID " + "\r\n";

            queryString = queryString + "       ORDER BY    GoodsIssueCollections.GoodsIssueEntryDate " + "\r\n";

            return queryString;
        }

        #endregion Y




        private void SalesReturnSaveRelative()
        {
            string queryString = " @EntityID int, @SaveRelativeOption int " + "\r\n"; //SaveRelativeOption: 1: Update, -1:Undo
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("SalesReturnSaveRelative", queryString);
        }

        private void SalesReturnPostSaveValidate()
        {
            string[] queryArray = new string[1];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = N'Ngày xuất kho: ' + CAST(GoodsIssues.EntryDate AS nvarchar) FROM SalesReturnDetails INNER JOIN GoodsIssues ON SalesReturnDetails.SalesReturnID = @EntityID AND SalesReturnDetails.GoodsIssueID = GoodsIssues.GoodsIssueID AND SalesReturnDetails.EntryDate < GoodsIssues.EntryDate ";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("SalesReturnPostSaveValidate", queryArray);
        }




        private void SalesReturnApproved()
        {
            string[] queryArray = new string[1];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = SalesReturnID FROM SalesReturns WHERE SalesReturnID = @EntityID AND Approved = 1";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("SalesReturnApproved", queryArray);
        }


        private void SalesReturnEditable()
        {
            string[] queryArray = new string[1];

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = SalesReturnID FROM GoodsReceiptDetails WHERE SalesReturnID = @EntityID ";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("SalesReturnEditable", queryArray);
        }
        
        private void SalesReturnToggleApproved()
        {
            string queryString = " @EntityID int, @Approved bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       UPDATE      SalesReturns  SET Approved = @Approved, ApprovedDate = GetDate() WHERE SalesReturnID = @EntityID AND Approved = ~@Approved" + "\r\n";

            queryString = queryString + "       IF @@ROWCOUNT = 1 " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               UPDATE          SalesReturnDetails  SET Approved = @Approved WHERE SalesReturnID = @EntityID ; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               DECLARE     @msg NVARCHAR(300) = N'Dữ liệu không tồn tại hoặc đã ' + iif(@Approved = 0, 'hủy', '')  + ' duyệt' ; " + "\r\n";
            queryString = queryString + "               THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("SalesReturnToggleApproved", queryString);
        }

        private void SalesReturnInitReference()
        {
            SimpleInitReference simpleInitReference = new SimpleInitReference("SalesReturns", "SalesReturnID", "Reference", ModelSettingManager.ReferenceLength, ModelSettingManager.ReferencePrefix(GlobalEnums.NmvnTaskID.SalesReturns));
            this.totalSmartCodingEntities.CreateTrigger("SalesReturnInitReference", simpleInitReference.CreateQuery());
        }


        #endregion
    }
}

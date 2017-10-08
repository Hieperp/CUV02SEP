using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Inventories
{
    public class GoodsIssue
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public GoodsIssue(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
            this.GetGoodsIssueIndexes();


            this.GetGoodsIssueViewDetails();

            this.GetPendingDeliveryAdviceCustomers();
            this.GetPendingDeliveryAdvices();
            this.GetPendingDeliveryAdviceDetails();

            this.GoodsIssueSaveRelative();
            this.GoodsIssuePostSaveValidate();

            this.GoodsIssueApproved();
            this.GoodsIssueEditable();

            this.GoodsIssueToggleApproved();

            this.GoodsIssueInitReference();
        }


        private void GetGoodsIssueIndexes()
        {
            string queryString;

            queryString = " @AspUserID nvarchar(128), @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      GoodsIssues.GoodsIssueID, CAST(GoodsIssues.EntryDate AS DATE) AS EntryDate, GoodsIssues.Reference, GoodsIssues.DeliveryAdviceReferences, Locations.Code AS LocationCode, Customers.Code AS CustomerCode, Customers.Name AS CustomerName, GoodsIssues.TotalQuantity, GoodsIssues.TotalLineVolume, GoodsIssues.Approved " + "\r\n";
            queryString = queryString + "       FROM        GoodsIssues " + "\r\n";
            queryString = queryString + "                   INNER JOIN Locations ON GoodsIssues.EntryDate >= @FromDate AND GoodsIssues.EntryDate <= @ToDate AND GoodsIssues.OrganizationalUnitID IN (SELECT AccessControls.OrganizationalUnitID FROM AccessControls INNER JOIN AspNetUsers ON AccessControls.UserID = AspNetUsers.UserID WHERE AspNetUsers.Id = @AspUserID AND AccessControls.NMVNTaskID = " + (int)TotalBase.Enums.GlobalEnums.NmvnTaskID.GoodsIssue + " AND AccessControls.AccessLevel > 0) AND Locations.LocationID = GoodsIssues.LocationID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Customers ON GoodsIssues.CustomerID = Customers.CustomerID " + "\r\n";
            queryString = queryString + "       " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetGoodsIssueIndexes", queryString);
        }


        #region X


        private void GetGoodsIssueViewDetails()
        {
            string queryString;

            queryString = " @GoodsIssueID Int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      GoodsIssueDetails.GoodsIssueDetailID, GoodsIssueDetails.GoodsIssueID, GoodsIssueDetails.DeliveryAdviceID, GoodsIssueDetails.DeliveryAdviceDetailID, DeliveryAdviceDetails.Reference AS DeliveryAdviceReference, DeliveryAdviceDetails.EntryDate AS DeliveryAdviceEntryDate, GoodsIssueDetails.GoodsReceiptID, GoodsIssueDetails.GoodsReceiptDetailID, GoodsReceiptDetails.BatchEntryDate, GoodsReceiptDetails.Reference AS GoodsReceiptReference, GoodsReceiptDetails.EntryDate AS GoodsReceiptEntryDate," + "\r\n";
            queryString = queryString + "                   Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, BinLocations.BinLocationID, BinLocations.Code AS BinLocationCode, " + "\r\n";
            queryString = queryString + "                   GoodsReceiptDetails.PackID, Packs.Code AS PackCode, GoodsReceiptDetails.CartonID, Cartons.Code AS CartonCode, GoodsReceiptDetails.PalletID, Pallets.Code AS PalletCode, GoodsReceiptDetails.PackCounts, GoodsReceiptDetails.CartonCounts, GoodsReceiptDetails.PalletCounts, " + "\r\n";
            queryString = queryString + "                   ROUND(GoodsReceiptDetails.Quantity - GoodsReceiptDetails.QuantityIssue + GoodsIssueDetails.Quantity, " + (int)GlobalEnums.rndQuantity + ") AS QuantityAvailable, ROUND(GoodsReceiptDetails.LineVolume - GoodsReceiptDetails.LineVolumeIssue + GoodsIssueDetails.LineVolume, " + (int)GlobalEnums.rndVolume + ") AS LineVolumeAvailable, ROUND(DeliveryAdviceDetails.Quantity - DeliveryAdviceDetails.QuantityIssue + GoodsIssueDetails.Quantity, " + (int)GlobalEnums.rndQuantity + ") AS QuantityRemains, ROUND(DeliveryAdviceDetails.LineVolume - DeliveryAdviceDetails.LineVolumeIssue + GoodsIssueDetails.LineVolume, " + (int)GlobalEnums.rndVolume + ") AS LineVolumeRemains, GoodsIssueDetails.Quantity, GoodsIssueDetails.LineVolume, GoodsIssueDetails.Remarks " + "\r\n";
            queryString = queryString + "       FROM        GoodsIssueDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON GoodsIssueDetails.GoodsIssueID = @GoodsIssueID AND GoodsIssueDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   INNER JOIN GoodsReceiptDetails ON GoodsIssueDetails.GoodsReceiptDetailID = GoodsReceiptDetails.GoodsReceiptDetailID " + "\r\n";
            queryString = queryString + "                   INNER JOIN DeliveryAdviceDetails ON GoodsIssueDetails.DeliveryAdviceDetailID = DeliveryAdviceDetails.DeliveryAdviceDetailID " + "\r\n";
            queryString = queryString + "                   INNER JOIN BinLocations ON GoodsReceiptDetails.BinLocationID = BinLocations.BinLocationID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Pallets ON GoodsReceiptDetails.PalletID = Pallets.PalletID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Packs ON GoodsReceiptDetails.PackID = Packs.PackID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Cartons ON GoodsReceiptDetails.CartonID = Cartons.CartonID " + "\r\n";
            queryString = queryString + "       ORDER BY    GoodsIssueDetails.GoodsIssueDetailID DESC " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetGoodsIssueViewDetails", queryString);
        }





        #region Y

        private void GetPendingDeliveryAdvices()
        {
            string queryString = " @LocationID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       SELECT          DeliveryAdvices.DeliveryAdviceID, DeliveryAdvices.Reference AS DeliveryAdviceReference, DeliveryAdvices.EntryDate AS DeliveryAdviceEntryDate, DeliveryAdvices.SalesOrderReferences, DeliveryAdvices.VoucherCode, DeliveryAdvices.CustomerID, Customers.Code AS CustomerCode, Customers.Name AS CustomerName, DeliveryAdvices.Description, DeliveryAdvices.Remarks " + "\r\n";
            queryString = queryString + "       FROM            DeliveryAdvices " + "\r\n";
            queryString = queryString + "                       INNER JOIN Customers ON DeliveryAdvices.DeliveryAdviceID IN (SELECT DeliveryAdviceID FROM DeliveryAdviceDetails WHERE LocationID = @LocationID AND Approved = 1 AND ROUND(Quantity - QuantityIssue, " + (int)GlobalEnums.rndQuantity + ") > 0) AND DeliveryAdvices.CustomerID = Customers.CustomerID " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetPendingDeliveryAdvices", queryString);
        }

        private void GetPendingDeliveryAdviceCustomers()
        {
            string queryString = " @LocationID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       SELECT          Customers.CustomerID, Customers.Code AS CustomerCode, Customers.Name AS CustomerName " + "\r\n";
            queryString = queryString + "       FROM           (SELECT DISTINCT CustomerID FROM DeliveryAdviceDetails WHERE LocationID = @LocationID AND Approved = 1 AND ROUND(Quantity - QuantityIssue, " + (int)GlobalEnums.rndQuantity + ") > 0) CustomerPENDING " + "\r\n";
            queryString = queryString + "                       INNER JOIN Customers ON CustomerPENDING.CustomerID = Customers.CustomerID " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetPendingDeliveryAdviceCustomers", queryString);
        }


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
            queryString = queryString + "                   Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.PackageSize, Commodities.Volume, Commodities.PackageVolume, " + "\r\n";
            queryString = queryString + "                   ROUND(DeliveryAdviceDetails.Quantity - DeliveryAdviceDetails.QuantityIssue,  " + (int)GlobalEnums.rndQuantity + ") AS QuantityRemains, CAST(0 AS decimal(18, 2)) AS Quantity, ROUND(DeliveryAdviceDetails.LineVolume - DeliveryAdviceDetails.LineVolumeIssue,  " + (int)GlobalEnums.rndVolume + ") AS LineVolumeRemains, CAST(0 AS decimal(18, 2)) AS LineVolume, DeliveryAdviceDetails.Remarks, CAST(0 AS bit) AS IsSelected " + "\r\n";

            queryString = queryString + "       FROM        DeliveryAdviceDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON " + (isDeliveryAdviceID ? " DeliveryAdviceDetails.DeliveryAdviceID = @DeliveryAdviceID " : "DeliveryAdviceDetails.LocationID = @LocationID AND DeliveryAdviceDetails.CustomerID = @CustomerID ") + " AND DeliveryAdviceDetails.Approved = 1 AND ROUND(DeliveryAdviceDetails.Quantity - DeliveryAdviceDetails.QuantityIssue, " + (int)GlobalEnums.rndQuantity + ") > 0 AND DeliveryAdviceDetails.CommodityID = Commodities.CommodityID" + (isDeliveryAdviceDetailIDs ? " AND DeliveryAdviceDetails.DeliveryAdviceDetailID NOT IN (SELECT Id FROM dbo.SplitToIntList (@DeliveryAdviceDetailIDs))" : "") + "\r\n";

            return queryString;
        }

        private string BuildSQLEdit(bool isDeliveryAdviceID, bool isDeliveryAdviceDetailIDs)
        {
            string queryString = "";

            queryString = queryString + "       SELECT      DeliveryAdviceDetails.LocationID, DeliveryAdviceDetails.DeliveryAdviceID, DeliveryAdviceDetails.DeliveryAdviceDetailID, DeliveryAdviceDetails.Reference AS DeliveryAdviceReference, DeliveryAdviceDetails.EntryDate AS DeliveryAdviceEntryDate, " + "\r\n";
            queryString = queryString + "                   Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.PackageSize, Commodities.Volume, Commodities.PackageVolume, " + "\r\n";
            queryString = queryString + "                   ROUND(DeliveryAdviceDetails.Quantity - DeliveryAdviceDetails.QuantityIssue + GoodsIssueDetails.Quantity,  " + (int)GlobalEnums.rndQuantity + ") AS QuantityRemains, CAST(0 AS decimal(18, 2)) AS Quantity, ROUND(DeliveryAdviceDetails.LineVolume - DeliveryAdviceDetails.LineVolumeIssue + GoodsIssueDetails.LineVolume,  " + (int)GlobalEnums.rndVolume + ") AS LineVolumeRemains, CAST(0 AS decimal(18, 2)) AS LineVolume, DeliveryAdviceDetails.Remarks, CAST(0 AS bit) AS IsSelected " + "\r\n";

            queryString = queryString + "       FROM        DeliveryAdviceDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN GoodsIssueDetails ON GoodsIssueDetails.GoodsIssueID = @GoodsIssueID AND DeliveryAdviceDetails.DeliveryAdviceDetailID = GoodsIssueDetails.DeliveryAdviceDetailID" + (isDeliveryAdviceDetailIDs ? " AND DeliveryAdviceDetails.DeliveryAdviceDetailID NOT IN (SELECT Id FROM dbo.SplitToIntList (@DeliveryAdviceDetailIDs))" : "") + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON DeliveryAdviceDetails.CommodityID = Commodities.CommodityID " + "\r\n";

            return queryString;
        }

        #endregion Y




        private void GoodsIssueSaveRelative()
        {
            string queryString = " @EntityID int, @SaveRelativeOption int " + "\r\n"; //SaveRelativeOption: 1: Update, -1:Undo
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            //queryString = queryString + "   IF (SELECT HasDeliveryAdvice FROM GoodsIssues WHERE GoodsIssueID = @EntityID) = 1 " + "\r\n";
            queryString = queryString + "       BEGIN " + "\r\n";

            queryString = queryString + "           IF (@SaveRelativeOption = 1) ";
            queryString = queryString + "               BEGIN ";
            queryString = queryString + "                   UPDATE          GoodsIssueDetails " + "\r\n";
            queryString = queryString + "                   SET             GoodsIssueDetails.Reference = GoodsIssues.Reference " + "\r\n";
            queryString = queryString + "                   FROM            GoodsIssues INNER JOIN GoodsIssueDetails ON GoodsIssues.GoodsIssueID = @EntityID AND GoodsIssues.GoodsIssueID = GoodsIssueDetails.GoodsIssueID " + "\r\n";
            queryString = queryString + "               END ";

            queryString = queryString + "           UPDATE          DeliveryAdviceDetails" + "\r\n";
            queryString = queryString + "           SET             DeliveryAdviceDetails.QuantityIssue = ROUND(DeliveryAdviceDetails.QuantityIssue + GoodsIssueDetails.Quantity * @SaveRelativeOption, " + (int)GlobalEnums.rndQuantity + "), DeliveryAdviceDetails.LineVolumeIssue = ROUND(DeliveryAdviceDetails.LineVolumeIssue + GoodsIssueDetails.LineVolume * @SaveRelativeOption, " + (int)GlobalEnums.rndVolume + ") " + "\r\n";
            queryString = queryString + "           FROM            (SELECT DeliveryAdviceDetailID, SUM(Quantity) AS Quantity, SUM(LineVolume) AS LineVolume FROM GoodsIssueDetails WHERE GoodsIssueID = @EntityID AND DeliveryAdviceDetailID IS NOT NULL GROUP BY DeliveryAdviceDetailID) GoodsIssueDetails " + "\r\n";
            queryString = queryString + "                           INNER JOIN DeliveryAdviceDetails ON GoodsIssueDetails.DeliveryAdviceDetailID = DeliveryAdviceDetails.DeliveryAdviceDetailID" + "\r\n";

            queryString = queryString + "           UPDATE          GoodsReceiptDetails" + "\r\n";
            queryString = queryString + "           SET             GoodsReceiptDetails.QuantityIssue = ROUND(GoodsReceiptDetails.QuantityIssue + GoodsIssueDetails.Quantity * @SaveRelativeOption, " + (int)GlobalEnums.rndQuantity + "), GoodsReceiptDetails.LineVolumeIssue = ROUND(GoodsReceiptDetails.LineVolumeIssue + GoodsIssueDetails.LineVolume * @SaveRelativeOption, " + (int)GlobalEnums.rndVolume + ") " + "\r\n";
            queryString = queryString + "           FROM            (SELECT GoodsReceiptDetailID, SUM(Quantity) AS Quantity, SUM(LineVolume) AS LineVolume FROM GoodsIssueDetails WHERE GoodsIssueID = @EntityID GROUP BY GoodsReceiptDetailID) GoodsIssueDetails " + "\r\n";
            queryString = queryString + "                           INNER JOIN GoodsReceiptDetails ON GoodsIssueDetails.GoodsReceiptDetailID = GoodsReceiptDetails.GoodsReceiptDetailID" + "\r\n";

            queryString = queryString + "           IF @@ROWCOUNT > (SELECT COUNT(*) FROM GoodsIssueDetails WHERE GoodsIssueID = @EntityID) " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DECLARE     @msg NVARCHAR(300) = N'Phiếu giao hàng đã hủy, hoặc chưa duyệt' ; " + "\r\n";
            queryString = queryString + "                   THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "               END " + "\r\n";
            queryString = queryString + "       END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GoodsIssueSaveRelative", queryString);
        }

        private void GoodsIssuePostSaveValidate()
        {
            string[] queryArray = new string[3];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = N'Ngày đề nghị giao hàng: ' + CAST(DeliveryAdvices.EntryDate AS nvarchar) FROM GoodsIssueDetails INNER JOIN DeliveryAdvices ON GoodsIssueDetails.GoodsIssueID = @EntityID AND GoodsIssueDetails.DeliveryAdviceID = DeliveryAdvices.DeliveryAdviceID AND GoodsIssueDetails.EntryDate < DeliveryAdvices.EntryDate ";
            queryArray[1] = " SELECT TOP 1 @FoundEntity = N'Đề nghị giao hàng chưa duyệt hoặc số lượng xuất kho vượt quá số lượng đề nghị: ' + CAST(ROUND(Quantity - QuantityIssue, " + (int)GlobalEnums.rndQuantity + ") AS nvarchar) + N' Hoặc khối lượng: ' + CAST(ROUND(LineVolume - LineVolumeIssue, " + (int)GlobalEnums.rndVolume + ") AS nvarchar) FROM DeliveryAdviceDetails WHERE (Approved = 0 AND (QuantityIssue > 0 OR LineVolumeIssue > 0)) OR (ROUND(Quantity - QuantityIssue, " + (int)GlobalEnums.rndQuantity + ") < 0) OR (ROUND(LineVolume - LineVolumeIssue, " + (int)GlobalEnums.rndVolume + ") < 0) ";
            queryArray[2] = " SELECT TOP 1 @FoundEntity = N'Phiếu nhập kho chưa duyệt hoặc số lượng xuất kho vượt quá số lượng tồn kho: ' + CAST(ROUND(Quantity - QuantityIssue, " + (int)GlobalEnums.rndQuantity + ") AS nvarchar) + N' Hoặc khối lượng: ' + CAST(ROUND(LineVolume - LineVolumeIssue, " + (int)GlobalEnums.rndVolume + ") AS nvarchar) FROM GoodsReceiptDetails WHERE (Approved = 0 AND (QuantityIssue > 0 OR LineVolumeIssue > 0)) OR (ROUND(Quantity - QuantityIssue, " + (int)GlobalEnums.rndQuantity + ") < 0) OR (ROUND(LineVolume - LineVolumeIssue, " + (int)GlobalEnums.rndVolume + ") < 0) ";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("GoodsIssuePostSaveValidate", queryArray);
        }




        private void GoodsIssueApproved()
        {
            string[] queryArray = new string[1];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = GoodsIssueID FROM GoodsIssues WHERE GoodsIssueID = @EntityID AND Approved = 1";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("GoodsIssueApproved", queryArray);
        }


        private void GoodsIssueEditable()
        {
            string[] queryArray = new string[0];

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = GoodsIssueID FROM GoodsIssues WHERE GoodsIssueID = @EntityID AND (InActive = 1 OR InActivePartial = 1)"; //Don't allow approve after void
            //queryArray[1] = " SELECT TOP 1 @FoundEntity = GoodsIssueID FROM GoodsIssueDetails WHERE GoodsIssueID = @EntityID ";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("GoodsIssueEditable", queryArray);
        }

        private void GoodsIssueToggleApproved()
        {
            string queryString = " @EntityID int, @Approved bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       UPDATE      GoodsIssues  SET Approved = @Approved, ApprovedDate = GetDate() WHERE GoodsIssueID = @EntityID AND Approved = ~@Approved" + "\r\n";

            queryString = queryString + "       IF @@ROWCOUNT = 1 " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               UPDATE          GoodsIssueDetails  SET Approved = @Approved WHERE GoodsIssueID = @EntityID ; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               DECLARE     @msg NVARCHAR(300) = N'Dữ liệu không tồn tại hoặc đã ' + iif(@Approved = 0, 'hủy', '')  + ' duyệt' ; " + "\r\n";
            queryString = queryString + "               THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GoodsIssueToggleApproved", queryString);
        }

        private void GoodsIssueInitReference()
        {
            SimpleInitReference simpleInitReference = new SimpleInitReference("GoodsIssues", "GoodsIssueID", "Reference", ModelSettingManager.ReferenceLength, ModelSettingManager.ReferencePrefix(GlobalEnums.NmvnTaskID.GoodsIssue));
            this.totalSmartCodingEntities.CreateTrigger("GoodsIssueInitReference", simpleInitReference.CreateQuery());
        }


        #endregion
    }
}

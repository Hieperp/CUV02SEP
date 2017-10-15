﻿using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Sales
{
    public class DeliveryAdvice
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public DeliveryAdvice(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
            this.GetDeliveryAdviceIndexes();


            this.GetDeliveryAdviceViewDetails();

            this.GetPendingSalesOrders();
            this.GetPendingSalesOrderCustomers();
            this.GetPendingSalesOrderDetails();

            this.DeliveryAdviceSaveRelative();
            this.DeliveryAdvicePostSaveValidate();

            this.DeliveryAdviceApproved();
            this.DeliveryAdviceEditable();

            this.DeliveryAdviceToggleApproved();

            this.DeliveryAdviceInitReference();

            this.GetBatchAvailables();
        }


        private void GetDeliveryAdviceIndexes()
        {
            string queryString;

            queryString = " @AspUserID nvarchar(128), @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      DeliveryAdvices.DeliveryAdviceID, CAST(DeliveryAdvices.EntryDate AS DATE) AS EntryDate, DeliveryAdvices.Reference, DeliveryAdvices.SalesOrderReferences, Locations.Code AS LocationCode, Customers.Code AS CustomerCode, Customers.Name AS CustomerName, DeliveryAdvices.Description, DeliveryAdvices.TotalQuantity, DeliveryAdvices.TotalLineVolume, DeliveryAdvices.Approved " + "\r\n";
            queryString = queryString + "       FROM        DeliveryAdvices " + "\r\n";
            queryString = queryString + "                   INNER JOIN Locations ON DeliveryAdvices.EntryDate >= @FromDate AND DeliveryAdvices.EntryDate <= @ToDate AND DeliveryAdvices.OrganizationalUnitID IN (SELECT AccessControls.OrganizationalUnitID FROM AccessControls INNER JOIN AspNetUsers ON AccessControls.UserID = AspNetUsers.UserID WHERE AspNetUsers.Id = @AspUserID AND AccessControls.NMVNTaskID = " + (int)TotalBase.Enums.GlobalEnums.NmvnTaskID.DeliveryAdvice + " AND AccessControls.AccessLevel > 0) AND Locations.LocationID = DeliveryAdvices.LocationID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Customers ON DeliveryAdvices.CustomerID = Customers.CustomerID " + "\r\n";
            queryString = queryString + "       " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetDeliveryAdviceIndexes", queryString);
        }


        #region X


        private void GetDeliveryAdviceViewDetails()
        {
            string queryString;

            queryString = " @DeliveryAdviceID Int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       DECLARE     @DeliveryAdviceDetails TABLE (DeliveryAdviceID int NOT NULL, DeliveryAdviceDetailID int NOT NULL, SalesOrderID int NULL, SalesOrderDetailID int NULL, EntryDate datetime NOT NULL, LocationID int NOT NULL, CommodityID int NOT NULL, BatchID int NULL, Quantity decimal(18, 2) NOT NULL, LineVolume decimal(18, 2) NOT NULL, QuantityIssue decimal(18, 2) NOT NULL, LineVolumeIssue decimal(18, 2) NOT NULL, Remarks nvarchar(100) NULL) " + "\r\n";
            queryString = queryString + "       INSERT INTO @DeliveryAdviceDetails (DeliveryAdviceID, DeliveryAdviceDetailID, SalesOrderID, SalesOrderDetailID, EntryDate, LocationID, CommodityID, BatchID, Quantity, LineVolume, QuantityIssue, LineVolumeIssue, Remarks) SELECT DeliveryAdviceID, DeliveryAdviceDetailID, SalesOrderID, SalesOrderDetailID, EntryDate, LocationID, CommodityID, BatchID, Quantity, LineVolume, QuantityIssue, LineVolumeIssue, Remarks FROM DeliveryAdviceDetails WHERE DeliveryAdviceID = @DeliveryAdviceID " + "\r\n";

            queryString = queryString + "                   " + this.BuildSQLCommoditiesAvailable("@DeliveryAdviceDetails", true, true, true, true, false) + "\r\n";

            queryString = queryString + "       SELECT      DeliveryAdviceDetails.DeliveryAdviceDetailID, DeliveryAdviceDetails.DeliveryAdviceID, DeliveryAdviceDetails.SalesOrderID, DeliveryAdviceDetails.SalesOrderDetailID, SalesOrderDetails.Reference AS SalesOrderReference, SalesOrderDetails.EntryDate AS SalesOrderEntryDate, SalesOrderDetails.VoucherCode, Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.Unit, Commodities.PackageSize, Commodities.Volume, Commodities.PackageVolume, DeliveryAdviceDetails.BatchID, Batches.Code AS BatchCode, " + "\r\n";
            queryString = queryString + "                   ISNULL(CommoditiesAvailable.QuantityAvailable, 0) AS QuantityAvailable, ISNULL(CommoditiesAvailable.LineVolumeAvailable, 0) AS LineVolumeAvailable, ISNULL(CommoditiesAvailableByBatches.QuantityAvailable, 0) AS QuantityBatchAvailable, ISNULL(CommoditiesAvailableByBatches.LineVolumeAvailable, 0) AS LineVolumeBatchAvailable, ROUND(ISNULL(SalesOrderDetails.Quantity - SalesOrderDetails.QuantityAdvice, 0) + DeliveryAdviceDetails.Quantity, " + (int)GlobalEnums.rndQuantity + ") AS QuantityRemains, ROUND(ISNULL(SalesOrderDetails.LineVolume - SalesOrderDetails.LineVolumeAdvice, 0) + DeliveryAdviceDetails.LineVolume, " + (int)GlobalEnums.rndVolume + ") AS LineVolumeRemains, DeliveryAdviceDetails.Quantity, DeliveryAdviceDetails.LineVolume, DeliveryAdviceDetails.QuantityIssue, DeliveryAdviceDetails.LineVolumeIssue, DeliveryAdviceDetails.Remarks " + "\r\n";
            queryString = queryString + "       FROM        @DeliveryAdviceDetails DeliveryAdviceDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON DeliveryAdviceDetails.CommodityID = Commodities.CommodityID" + "\r\n";
            queryString = queryString + "                   LEFT JOIN Batches ON DeliveryAdviceDetails.BatchID = Batches.BatchID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN SalesOrderDetails ON DeliveryAdviceDetails.SalesOrderDetailID = SalesOrderDetails.SalesOrderDetailID " + "\r\n";

            queryString = queryString + "                   LEFT JOIN (SELECT CommodityID, SUM(QuantityAvailable) AS QuantityAvailable, SUM(LineVolumeAvailable) AS LineVolumeAvailable FROM @CommoditiesAvailable GROUP BY CommodityID) CommoditiesAvailable ON DeliveryAdviceDetails.CommodityID = CommoditiesAvailable.CommodityID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN (SELECT CommodityID, BatchID, SUM(QuantityAvailable) AS QuantityAvailable, SUM(LineVolumeAvailable) AS LineVolumeAvailable FROM @CommoditiesAvailableByBatches GROUP BY CommodityID, BatchID) CommoditiesAvailableByBatches ON DeliveryAdviceDetails.BatchID = CommoditiesAvailableByBatches.BatchID AND DeliveryAdviceDetails.CommodityID = CommoditiesAvailableByBatches.CommodityID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetDeliveryAdviceViewDetails", queryString);
        }





        #region Y

        private void GetPendingSalesOrders()
        {
            string queryString = " @LocationID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       SELECT          SalesOrders.SalesOrderID, SalesOrders.Reference AS SalesOrderReference, SalesOrders.EntryDate AS SalesOrderEntryDate, SalesOrders.VoucherCode, SalesOrders.CustomerID, Customers.Code AS CustomerCode, Customers.Name AS CustomerName, SalesOrders.ContactInfo, SalesOrders.ShippingAddress, SalesOrders.SalespersonID, SalesOrders.Description, SalesOrders.Remarks " + "\r\n";
            queryString = queryString + "       FROM            SalesOrders " + "\r\n";
            queryString = queryString + "                       INNER JOIN Customers ON SalesOrders.SalesOrderID IN (SELECT SalesOrderID FROM SalesOrderDetails WHERE LocationID = @LocationID AND Approved = 1 AND ROUND(Quantity - QuantityAdvice, " + (int)GlobalEnums.rndQuantity + ") > 0) AND SalesOrders.CustomerID = Customers.CustomerID " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetPendingSalesOrders", queryString);
        }

        private void GetPendingSalesOrderCustomers()
        {
            string queryString = " @LocationID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       SELECT          Customers.CustomerID, Customers.Code AS CustomerCode, Customers.Name AS CustomerName, CustomerPENDING.ContactInfo, CustomerPENDING.ShippingAddress, CustomerPENDING.SalespersonID " + "\r\n";
            queryString = queryString + "       FROM           (SELECT CustomerID, MIN(ContactInfo) AS ContactInfo, MIN(ShippingAddress) AS ShippingAddress, MIN(SalespersonID) AS SalespersonID FROM SalesOrders WHERE SalesOrderID IN (SELECT DISTINCT SalesOrderID FROM SalesOrderDetails WHERE LocationID = @LocationID AND Approved = 1 AND ROUND(Quantity - QuantityAdvice, " + (int)GlobalEnums.rndQuantity + ") > 0) GROUP BY CustomerID) CustomerPENDING " + "\r\n";
            queryString = queryString + "                       INNER JOIN Customers ON CustomerPENDING.CustomerID = Customers.CustomerID " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetPendingSalesOrderCustomers", queryString);
        }



        private void GetPendingSalesOrderDetails()
        {
            string queryString;

            queryString = " @LocationID Int, @DeliveryAdviceID Int, @SalesOrderID Int, @CustomerID Int, @SalesOrderDetailIDs varchar(3999), @IsReadonly bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "   BEGIN " + "\r\n";

            queryString = queryString + "       DECLARE     @SalesOrderDetails TABLE (IsNewOrEdit bit NOT NULL, SalesOrderID int NOT NULL, SalesOrderDetailID int NOT NULL, EntryDate datetime NOT NULL, Reference nvarchar(10) NULL, VoucherCode nvarchar(60) NULL, LocationID int NOT NULL, CommodityID int NOT NULL, QuantityRemains decimal(18, 2) NOT NULL, LineVolumeRemains decimal(18, 2) NOT NULL, Remarks nvarchar(100) NULL) " + "\r\n";
            queryString = queryString + "                   " + this.BuildSQLCommoditiesAvailable("@SalesOrderDetails", true, false, false, false, false) + "\r\n";

            queryString = queryString + "       IF  (@SalesOrderID <> 0) " + "\r\n";
            queryString = queryString + "           " + this.BuildSQLSalesOrder(true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           " + this.BuildSQLSalesOrder(false) + "\r\n";

            queryString = queryString + "   END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetPendingSalesOrderDetails", queryString);
        }

        private string BuildSQLSalesOrder(bool isSalesOrderID)
        {
            string queryString = "";
            queryString = queryString + "   BEGIN " + "\r\n";
            queryString = queryString + "       IF  (@SalesOrderDetailIDs <> '') " + "\r\n";
            queryString = queryString + "           " + this.BuildSQLSalesOrderSalesOrderDetailIDs(isSalesOrderID, true) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           " + this.BuildSQLSalesOrderSalesOrderDetailIDs(isSalesOrderID, false) + "\r\n";
            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        private string BuildSQLSalesOrderSalesOrderDetailIDs(bool isSalesOrderID, bool isSalesOrderDetailIDs)
        {
            string queryString = "";
            queryString = queryString + "   BEGIN " + "\r\n";

            queryString = queryString + "       IF (@DeliveryAdviceID <= 0) " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   " + this.BuildSQLPendingAvailable(isSalesOrderID, isSalesOrderDetailIDs, true, false) + "\r\n";
            queryString = queryString + "                   " + this.BuildSQLNew(isSalesOrderID, isSalesOrderDetailIDs) + "\r\n";
            queryString = queryString + "                   ORDER BY SalesOrderDetails.EntryDate, SalesOrderDetails.SalesOrderID, SalesOrderDetails.SalesOrderDetailID " + "\r\n";
            queryString = queryString + "               END " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";

            queryString = queryString + "               IF (@IsReadonly = 1) " + "\r\n";
            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       " + this.BuildSQLPendingAvailable(isSalesOrderID, isSalesOrderDetailIDs, false, true) + "\r\n";
            queryString = queryString + "                       " + this.BuildSQLEdit(isSalesOrderID, isSalesOrderDetailIDs) + "\r\n";
            queryString = queryString + "                       ORDER BY SalesOrderDetails.EntryDate, SalesOrderDetails.SalesOrderID, SalesOrderDetails.SalesOrderDetailID " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "               ELSE " + "\r\n"; //FULL SELECT FOR EDIT MODE

            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       " + this.BuildSQLPendingAvailable(isSalesOrderID, isSalesOrderDetailIDs, true, true) + "\r\n";
            queryString = queryString + "                       " + this.BuildSQLNew(isSalesOrderID, isSalesOrderDetailIDs) + "\r\n";
            queryString = queryString + "                       UNION ALL " + "\r\n";
            queryString = queryString + "                       " + this.BuildSQLEdit(isSalesOrderID, isSalesOrderDetailIDs) + "\r\n";
            queryString = queryString + "                       ORDER BY SalesOrderDetails.EntryDate, SalesOrderDetails.SalesOrderID, SalesOrderDetails.SalesOrderDetailID " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        private string BuildSQLPendingAvailable(bool isSalesOrderID, bool isSalesOrderDetailIDs, bool sqlNew, bool sqlEdit)
        {
            string queryString = "";

            if (sqlNew)
            {
                queryString = queryString + "       INSERT INTO @SalesOrderDetails (IsNewOrEdit, SalesOrderID, SalesOrderDetailID, EntryDate, Reference, VoucherCode, LocationID, CommodityID, QuantityRemains, LineVolumeRemains, Remarks) " + "\r\n";
                queryString = queryString + "       SELECT      1 AS IsNewOrEdit, SalesOrderID, SalesOrderDetailID, EntryDate, Reference, VoucherCode, LocationID, CommodityID, ROUND(Quantity - QuantityAdvice,  " + (int)GlobalEnums.rndQuantity + ") AS QuantityRemains, ROUND(LineVolume - LineVolumeAdvice, " + (int)GlobalEnums.rndVolume + ") AS LineVolumeRemains, Remarks " + "\r\n";
                queryString = queryString + "       FROM        SalesOrderDetails " + "\r\n";
                queryString = queryString + "       WHERE       " + (isSalesOrderID ? " SalesOrderID = @SalesOrderID " : "LocationID = @LocationID AND CustomerID = @CustomerID ") + " AND Approved = 1 AND ROUND(Quantity - QuantityAdvice, " + (int)GlobalEnums.rndQuantity + ") > 0 " + (isSalesOrderDetailIDs ? " AND SalesOrderDetailID NOT IN (SELECT Id FROM dbo.SplitToIntList (@SalesOrderDetailIDs))" : "") + (sqlNew && sqlEdit ? " AND SalesOrderDetailID NOT IN (SELECT SalesOrderDetailID FROM DeliveryAdviceDetails WHERE DeliveryAdviceID = @DeliveryAdviceID) " : "") + "\r\n";
            }

            if (sqlEdit)
            {
                queryString = queryString + "       INSERT INTO @SalesOrderDetails (IsNewOrEdit, SalesOrderID, SalesOrderDetailID, EntryDate, Reference, VoucherCode, LocationID, CommodityID, QuantityRemains, LineVolumeRemains, Remarks) " + "\r\n";
                queryString = queryString + "       SELECT      0 AS IsNewOrEdit, SalesOrderDetails.SalesOrderID, SalesOrderDetails.SalesOrderDetailID, SalesOrderDetails.EntryDate, SalesOrderDetails.Reference, SalesOrderDetails.VoucherCode, SalesOrderDetails.LocationID, SalesOrderDetails.CommodityID, ROUND(SalesOrderDetails.Quantity - SalesOrderDetails.QuantityAdvice + DeliveryAdviceDetails.Quantity, " + (int)GlobalEnums.rndQuantity + ") AS QuantityRemains, ROUND(SalesOrderDetails.LineVolume - SalesOrderDetails.LineVolumeAdvice + DeliveryAdviceDetails.LineVolume, " + (int)GlobalEnums.rndVolume + ") AS LineVolumeRemains, SalesOrderDetails.Remarks " + "\r\n";
                queryString = queryString + "       FROM        SalesOrderDetails " + "\r\n";
                queryString = queryString + "                   INNER JOIN DeliveryAdviceDetails ON DeliveryAdviceDetails.DeliveryAdviceID = @DeliveryAdviceID AND SalesOrderDetails.SalesOrderDetailID = DeliveryAdviceDetails.SalesOrderDetailID" + (isSalesOrderDetailIDs ? " AND SalesOrderDetails.SalesOrderDetailID NOT IN (SELECT Id FROM dbo.SplitToIntList (@SalesOrderDetailIDs))" : "") + "\r\n";
            }

            queryString = queryString + "                       " + this.BuildSQLCommoditiesAvailable("@SalesOrderDetails", false, true, sqlEdit, false, false) + "\r\n";

            return queryString;
        }

        /// <summary>
        /// NOTES: BE CAREFULL WITH parameters: searchTable, declareTableAvailable, getAvailable, sqlEdit, byBatchID 
        /// byBatchID = TRUE: ONLY WHEN: GetDeliveryAdviceViewDetails AND GetBatchAvailables
        /// getAllBatch = TRUE: ONLY WHEN: GetBatchAvailables. SEE THE CODING FOR MORE DETAIL
        /// </summary>
        /// <param name="searchTable"></param>
        /// <param name="declareTableAvailable"></param>
        /// <param name="getAvailable"></param>
        /// <param name="sqlEdit"></param>
        /// <param name="byBatchID"></param>
        /// <returns></returns>
        private string BuildSQLCommoditiesAvailable(string searchTable, bool declareTableAvailable, bool getAvailable, bool sqlEdit, bool byBatchID, bool getAllBatch)
        {
            string queryString = "";

            if (declareTableAvailable)
            {
                queryString = queryString + "           DECLARE     @CommoditiesAvailable TABLE (LocationID int NOT NULL, CommodityID int NOT NULL, QuantityAvailable decimal(18, 2) NOT NULL, LineVolumeAvailable decimal(18, 2) NOT NULL) " + "\r\n";
                if (byBatchID)
                    queryString = queryString + "       DECLARE     @CommoditiesAvailableByBatches TABLE (LocationID int NOT NULL, CommodityID int NOT NULL, BatchID int NULL, QuantityAvailable decimal(18, 2) NOT NULL, LineVolumeAvailable decimal(18, 2) NOT NULL) " + "\r\n";
            }
            if (getAvailable)
            {
                queryString = queryString + "           INSERT INTO @CommoditiesAvailable (LocationID, CommodityID, QuantityAvailable, LineVolumeAvailable) " + "\r\n";
                queryString = queryString + "           SELECT      LocationID, CommodityID, SUM(Quantity - QuantityIssue) AS QuantityAvailable, SUM(LineVolume - LineVolumeIssue) AS LineVolumeAvailable FROM GoodsReceiptDetails WHERE Approved = 1 AND ROUND(Quantity - QuantityIssue, " + (int)GlobalEnums.rndQuantity + ") > 0 AND LocationID = (SELECT TOP 1 LocationID FROM " + searchTable + ") AND CommodityID IN (SELECT DISTINCT CommodityID FROM " + searchTable + ") GROUP BY LocationID, CommodityID " + "\r\n";

                queryString = queryString + "           INSERT INTO @CommoditiesAvailable (LocationID, CommodityID, QuantityAvailable, LineVolumeAvailable) " + "\r\n";
                queryString = queryString + "           SELECT      LocationID, CommodityID, SUM(-Quantity + QuantityIssue) AS QuantityAvailable, SUM(-LineVolume + LineVolumeIssue) AS LineVolumeAvailable FROM DeliveryAdviceDetails WHERE ROUND(Quantity - QuantityIssue, " + (int)GlobalEnums.rndQuantity + ") > 0 " + (sqlEdit ? " AND DeliveryAdviceID <> @DeliveryAdviceID" : "") + " GROUP BY LocationID, CommodityID " + "\r\n";

                if (byBatchID)
                {
                    if (!getAllBatch)
                    {
                        queryString = queryString + "   IF (NOT(SELECT TOP 1 BatchID FROM " + searchTable + " WHERE NOT BatchID IS NULL) IS NULL) " + "\r\n";
                        queryString = queryString + "       BEGIN " + "\r\n";
                    }
                    queryString = queryString + "               INSERT INTO @CommoditiesAvailableByBatches (LocationID, CommodityID, BatchID, QuantityAvailable, LineVolumeAvailable) " + "\r\n";
                    queryString = queryString + "               SELECT      LocationID, CommodityID, BatchID, SUM(Quantity - QuantityIssue) AS QuantityAvailable, SUM(LineVolume - LineVolumeIssue) AS LineVolumeAvailable FROM GoodsReceiptDetails WHERE Approved = 1 AND ROUND(Quantity - QuantityIssue, " + (int)GlobalEnums.rndQuantity + ") > 0 AND LocationID = (SELECT TOP 1 LocationID FROM " + searchTable + ") AND CommodityID IN (SELECT DISTINCT CommodityID FROM " + searchTable + ") GROUP BY LocationID, CommodityID, BatchID " + "\r\n";

                    queryString = queryString + "               INSERT INTO @CommoditiesAvailableByBatches (LocationID, CommodityID, BatchID, QuantityAvailable, LineVolumeAvailable) " + "\r\n";
                    queryString = queryString + "               SELECT      LocationID, CommodityID, BatchID, SUM(-Quantity + QuantityIssue) AS QuantityAvailable, SUM(-LineVolume + LineVolumeIssue) AS LineVolumeAvailable FROM DeliveryAdviceDetails WHERE ROUND(Quantity - QuantityIssue, " + (int)GlobalEnums.rndQuantity + ") > 0 " + (sqlEdit ? " AND DeliveryAdviceID <> @DeliveryAdviceID" : "") + " AND NOT BatchID IS NULL GROUP BY LocationID, CommodityID, BatchID " + "\r\n";
                    if (!getAllBatch)
                    {
                        queryString = queryString + "       END " + "\r\n";
                    }
                }

                if (sqlEdit)
                {
                    queryString = queryString + "       INSERT INTO @CommoditiesAvailable (LocationID, CommodityID, QuantityAvailable, LineVolumeAvailable) " + "\r\n";
                    queryString = queryString + "       SELECT      LocationID, CommodityID, SUM(QuantityIssue) AS QuantityAvailable, SUM(LineVolumeIssue) AS LineVolumeAvailable FROM DeliveryAdviceDetails WHERE QuantityIssue > 0 AND DeliveryAdviceID = @DeliveryAdviceID GROUP BY LocationID, CommodityID " + "\r\n";
                    if (byBatchID)
                    {
                        if (!getAllBatch)
                        {
                            queryString = queryString + "   IF (NOT(SELECT TOP 1 BatchID FROM " + searchTable + " WHERE NOT BatchID IS NULL) IS NULL) " + "\r\n";
                            queryString = queryString + "       BEGIN " + "\r\n";
                        }
                        queryString = queryString + "               INSERT INTO @CommoditiesAvailableByBatches (LocationID, CommodityID, BatchID, QuantityAvailable, LineVolumeAvailable) " + "\r\n";
                        queryString = queryString + "               SELECT      LocationID, CommodityID, BatchID, SUM(QuantityIssue) AS QuantityAvailable, SUM(LineVolumeIssue) AS LineVolumeAvailable FROM DeliveryAdviceDetails WHERE QuantityIssue > 0 AND DeliveryAdviceID = @DeliveryAdviceID AND NOT BatchID IS NULL GROUP BY LocationID, CommodityID, BatchID " + "\r\n";
                        if (!getAllBatch)
                        {
                            queryString = queryString + "       END " + "\r\n";
                        }
                    }
                }
            }

            return queryString;
        }

        private string BuildSQLNew(bool isSalesOrderID, bool isSalesOrderDetailIDs)
        {
            string queryString = "";

            queryString = queryString + "       SELECT      SalesOrderDetails.SalesOrderID, SalesOrderDetails.SalesOrderDetailID, SalesOrderDetails.Reference AS SalesOrderReference, SalesOrderDetails.EntryDate AS SalesOrderEntryDate, SalesOrderDetails.VoucherCode AS SalesOrderVoucherCode, " + "\r\n";
            queryString = queryString + "                   Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.PackageSize, Commodities.Volume, Commodities.PackageVolume, " + "\r\n";
            queryString = queryString + "                   ISNULL(CommoditiesAvailable.QuantityAvailable, 0) AS QuantityAvailable, ISNULL(CommoditiesAvailable.LineVolumeAvailable, 0) AS LineVolumeAvailable, SalesOrderDetails.QuantityRemains, CAST(0 AS decimal(18, 2)) AS Quantity, SalesOrderDetails.LineVolumeRemains, CAST(0 AS decimal(18, 2)) AS LineVolume, SalesOrderDetails.Remarks, CAST(1 AS bit) AS IsSelected " + "\r\n";

            queryString = queryString + "       FROM        @SalesOrderDetails SalesOrderDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON SalesOrderDetails.IsNewOrEdit = 1 AND SalesOrderDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN (SELECT CommodityID, SUM(QuantityAvailable) AS QuantityAvailable, SUM(LineVolumeAvailable) AS LineVolumeAvailable FROM @CommoditiesAvailable GROUP BY CommodityID) CommoditiesAvailable ON SalesOrderDetails.CommodityID = CommoditiesAvailable.CommodityID " + "\r\n";

            return queryString;
        }

        private string BuildSQLEdit(bool isSalesOrderID, bool isSalesOrderDetailIDs)
        {
            string queryString = "";

            queryString = queryString + "       SELECT      SalesOrderDetails.SalesOrderID, SalesOrderDetails.SalesOrderDetailID, SalesOrderDetails.Reference AS SalesOrderReference, SalesOrderDetails.EntryDate AS SalesOrderEntryDate, SalesOrderDetails.VoucherCode AS SalesOrderVoucherCode, " + "\r\n";
            queryString = queryString + "                   Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.PackageSize, Commodities.Volume, Commodities.PackageVolume, " + "\r\n";
            queryString = queryString + "                   ISNULL(CommoditiesAvailable.QuantityAvailable, 0) AS QuantityAvailable, ISNULL(CommoditiesAvailable.LineVolumeAvailable, 0) AS LineVolumeAvailable, SalesOrderDetails.QuantityRemains, CAST(0 AS decimal(18, 2)) AS Quantity, SalesOrderDetails.LineVolumeRemains, CAST(0 AS decimal(18, 2)) AS LineVolume, SalesOrderDetails.Remarks, CAST(1 AS bit) AS IsSelected " + "\r\n";

            queryString = queryString + "       FROM        @SalesOrderDetails SalesOrderDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON SalesOrderDetails.IsNewOrEdit = 0 AND SalesOrderDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN (SELECT CommodityID, SUM(QuantityAvailable) AS QuantityAvailable, SUM(LineVolumeAvailable) AS LineVolumeAvailable FROM @CommoditiesAvailable GROUP BY CommodityID) CommoditiesAvailable ON SalesOrderDetails.CommodityID = CommoditiesAvailable.CommodityID " + "\r\n";

            return queryString;
        }


        private void GetBatchAvailables()
        {
            string queryString;

            queryString = " @LocationID Int, @DeliveryAdviceID Int, @CommodityID Int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       DECLARE     @SearchTable TABLE (LocationID int NOT NULL, CommodityID int NOT NULL) " + "\r\n";
            queryString = queryString + "       INSERT INTO @SearchTable (LocationID, CommodityID) VALUES(@LocationID, @CommodityID) " + "\r\n";

            queryString = queryString + "                   " + this.BuildSQLCommoditiesAvailable("@SearchTable", true, true, true, true, true) + "\r\n";

            queryString = queryString + "       SELECT      CommoditiesAvailableByBatches.BatchID, Batches.EntryDate, Batches.Code, CommoditiesAvailableByBatches.QuantityAvailable, CommoditiesAvailableByBatches.LineVolumeAvailable " + "\r\n";
            queryString = queryString + "       FROM       (SELECT BatchID, SUM(QuantityAvailable) AS QuantityAvailable, SUM(LineVolumeAvailable) AS LineVolumeAvailable FROM @CommoditiesAvailableByBatches GROUP BY BatchID) CommoditiesAvailableByBatches " + "\r\n";
            queryString = queryString + "                   INNER JOIN Batches ON CommoditiesAvailableByBatches.BatchID = Batches.BatchID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetBatchAvailables", queryString);
        }
        #endregion Y




        private void DeliveryAdviceSaveRelative()
        {
            string queryString = " @EntityID int, @SaveRelativeOption int " + "\r\n"; //SaveRelativeOption: 1: Update, -1:Undo
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            //queryString = queryString + "   IF (SELECT HasSalesOrder FROM DeliveryAdvices WHERE DeliveryAdviceID = @EntityID) = 1 " + "\r\n";
            queryString = queryString + "       BEGIN " + "\r\n";

            queryString = queryString + "           IF (@SaveRelativeOption = 1) ";
            queryString = queryString + "               BEGIN ";
            queryString = queryString + "                   UPDATE          DeliveryAdviceDetails " + "\r\n";
            queryString = queryString + "                   SET             DeliveryAdviceDetails.Reference = DeliveryAdvices.Reference " + "\r\n";
            queryString = queryString + "                   FROM            DeliveryAdvices INNER JOIN DeliveryAdviceDetails ON DeliveryAdvices.DeliveryAdviceID = @EntityID AND DeliveryAdvices.DeliveryAdviceID = DeliveryAdviceDetails.DeliveryAdviceID " + "\r\n";
            queryString = queryString + "               END ";

            queryString = queryString + "           UPDATE          SalesOrderDetails " + "\r\n";
            queryString = queryString + "           SET             SalesOrderDetails.QuantityAdvice = ROUND(SalesOrderDetails.QuantityAdvice + DeliveryAdviceDetails.Quantity * @SaveRelativeOption, " + (int)GlobalEnums.rndQuantity + "), SalesOrderDetails.LineVolumeAdvice = ROUND(SalesOrderDetails.LineVolumeAdvice + DeliveryAdviceDetails.LineVolume * @SaveRelativeOption, " + (int)GlobalEnums.rndVolume + ")  " + "\r\n";
            queryString = queryString + "           FROM            DeliveryAdviceDetails " + "\r\n";
            queryString = queryString + "                           INNER JOIN SalesOrderDetails ON SalesOrderDetails.Approved = 1 AND DeliveryAdviceDetails.DeliveryAdviceID = @EntityID AND DeliveryAdviceDetails.SalesOrderDetailID = SalesOrderDetails.SalesOrderDetailID " + "\r\n";

            queryString = queryString + "           IF @@ROWCOUNT <> (SELECT COUNT(*) FROM DeliveryAdviceDetails WHERE DeliveryAdviceID = @EntityID) " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DECLARE     @msg NVARCHAR(300) = N'Phiếu giao hàng đã hủy, hoặc chưa duyệt' ; " + "\r\n";
            queryString = queryString + "                   THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "               END " + "\r\n";
            queryString = queryString + "       END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("DeliveryAdviceSaveRelative", queryString);
        }

        private void DeliveryAdvicePostSaveValidate()
        {
            string[] queryArray = new string[2];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = N'Ngày đề nghị giao hàng: ' + CAST(SalesOrders.EntryDate AS nvarchar) FROM DeliveryAdviceDetails INNER JOIN SalesOrders ON DeliveryAdviceDetails.DeliveryAdviceID = @EntityID AND DeliveryAdviceDetails.SalesOrderID = SalesOrders.SalesOrderID AND DeliveryAdviceDetails.EntryDate < SalesOrders.EntryDate ";
            queryArray[1] = " SELECT TOP 1 @FoundEntity = N'Số lượng đề nghị giao vượt quá số lượng đặt hàng: ' + CAST(ROUND(Quantity - QuantityAdvice, " + (int)GlobalEnums.rndQuantity + ") AS nvarchar) + N' Hoặc khối lượng: ' + CAST(ROUND(LineVolume - LineVolumeAdvice, " + (int)GlobalEnums.rndVolume + ") AS nvarchar) FROM SalesOrderDetails WHERE (ROUND(Quantity - QuantityAdvice, " + (int)GlobalEnums.rndQuantity + ") < 0) OR (ROUND(LineVolume - LineVolumeAdvice, " + (int)GlobalEnums.rndVolume + ") < 0)";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("DeliveryAdvicePostSaveValidate", queryArray);
        }




        private void DeliveryAdviceApproved()
        {
            string[] queryArray = new string[1];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = DeliveryAdviceID FROM DeliveryAdvices WHERE DeliveryAdviceID = @EntityID AND Approved = 1";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("DeliveryAdviceApproved", queryArray);
        }


        private void DeliveryAdviceEditable()
        {
            string[] queryArray = new string[2];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = DeliveryAdviceID FROM DeliveryAdvices WHERE DeliveryAdviceID = @EntityID AND (InActive = 1 OR InActivePartial = 1)"; //Don't allow approve after void
            queryArray[1] = " SELECT TOP 1 @FoundEntity = DeliveryAdviceID FROM GoodsIssueDetails WHERE DeliveryAdviceID = @EntityID ";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("DeliveryAdviceEditable", queryArray);
        }

        private void DeliveryAdviceToggleApproved()
        {
            string queryString = " @EntityID int, @Approved bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       UPDATE      DeliveryAdvices  SET Approved = @Approved, ApprovedDate = GetDate() WHERE DeliveryAdviceID = @EntityID AND Approved = ~@Approved" + "\r\n";

            queryString = queryString + "       IF @@ROWCOUNT = 1 " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               UPDATE          DeliveryAdviceDetails  SET Approved = @Approved WHERE DeliveryAdviceID = @EntityID ; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               DECLARE     @msg NVARCHAR(300) = N'Dữ liệu không tồn tại hoặc đã ' + iif(@Approved = 0, 'hủy', '')  + ' duyệt' ; " + "\r\n";
            queryString = queryString + "               THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "           END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("DeliveryAdviceToggleApproved", queryString);
        }

        private void DeliveryAdviceInitReference()
        {
            SimpleInitReference simpleInitReference = new SimpleInitReference("DeliveryAdvices", "DeliveryAdviceID", "Reference", ModelSettingManager.ReferenceLength, ModelSettingManager.ReferencePrefix(GlobalEnums.NmvnTaskID.DeliveryAdvice));
            this.totalSmartCodingEntities.CreateTrigger("DeliveryAdviceInitReference", simpleInitReference.CreateQuery());
        }


        #endregion
    }
}

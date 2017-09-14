using System;
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
        }


        private void GetDeliveryAdviceIndexes()
        {
            string queryString;

            queryString = " @AspUserID nvarchar(128), @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      DeliveryAdvices.DeliveryAdviceID, CAST(DeliveryAdvices.EntryDate AS DATE) AS EntryDate, DeliveryAdvices.Reference, DeliveryAdvices.SalesOrderReferences, Locations.Code AS LocationCode, Customers.Name AS CustomerName, DeliveryAdvices.Description, DeliveryAdvices.TotalQuantity, DeliveryAdvices.TotalLineVolume, DeliveryAdvices.Approved " + "\r\n";
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

            queryString = queryString + "       SELECT      DeliveryAdviceDetails.DeliveryAdviceDetailID, DeliveryAdviceDetails.DeliveryAdviceID, DeliveryAdviceDetails.SalesOrderID, DeliveryAdviceDetails.SalesOrderDetailID, SalesOrders.Reference AS SalesOrderReference, SalesOrders.EntryDate AS SalesOrderEntryDate, " + "\r\n";
            queryString = queryString + "                   Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, " + "\r\n";
            queryString = queryString + "                   DeliveryAdviceDetails.Quantity, DeliveryAdviceDetails.LineVolume, DeliveryAdviceDetails.Remarks " + "\r\n";
            queryString = queryString + "       FROM        DeliveryAdviceDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON DeliveryAdviceDetails.DeliveryAdviceID = @DeliveryAdviceID AND DeliveryAdviceDetails.CommodityID = Commodities.CommodityID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN SalesOrderDetails ON DeliveryAdviceDetails.SalesOrderDetailID = SalesOrderDetails.SalesOrderDetailID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN SalesOrders ON DeliveryAdviceDetails.SalesOrderID = SalesOrders.SalesOrderID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetDeliveryAdviceViewDetails", queryString);
        }





        #region Y

        private void GetPendingSalesOrders()
        {
            string queryString = " @LocationID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       SELECT          SalesOrders.SalesOrderID, SalesOrders.Reference AS SalesOrderReference, SalesOrders.EntryDate AS SalesOrderEntryDate, SalesOrders.CustomerID, Customers.Code AS CustomerCode, Customers.Name AS CustomerName, SalesOrders.Description, SalesOrders.Remarks " + "\r\n";
            queryString = queryString + "       FROM            SalesOrders " + "\r\n";
            queryString = queryString + "                       INNER JOIN Customers ON SalesOrders.SalesOrderID IN (SELECT SalesOrderID FROM SalesOrderDetails WHERE LocationID = @LocationID AND Approved = 1 AND ROUND(Quantity - QuantityAdvice, " + (int)GlobalEnums.rndQuantity + ") > 0) AND SalesOrders.CustomerID = Customers.CustomerID " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetPendingSalesOrders", queryString);
        }

        private void GetPendingSalesOrderCustomers()
        {
            string queryString = " @LocationID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       SELECT          Customers.CustomerID, Customers.Code AS CustomerCode, Customers.Name AS CustomerName " + "\r\n";
            queryString = queryString + "       FROM           (SELECT DISTINCT CustomerID FROM SalesOrderDetails WHERE LocationID = @LocationID AND Approved = 1 AND ROUND(Quantity - QuantityAdvice, " + (int)GlobalEnums.rndQuantity + ") > 0) CustomerPENDING " + "\r\n";
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
            queryString = queryString + "                   " + this.BuildSQLNew(isSalesOrderID, isSalesOrderDetailIDs) + "\r\n";
            queryString = queryString + "                   ORDER BY SalesOrders.EntryDate, SalesOrders.SalesOrderID, SalesOrderDetails.SalesOrderDetailID " + "\r\n";
            queryString = queryString + "               END " + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";

            queryString = queryString + "               IF (@IsReadonly = 1) " + "\r\n";
            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       " + this.BuildSQLEdit(isSalesOrderID, isSalesOrderDetailIDs) + "\r\n";
            queryString = queryString + "                       ORDER BY SalesOrders.EntryDate, SalesOrders.SalesOrderID, SalesOrderDetails.SalesOrderDetailID " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "               ELSE " + "\r\n"; //FULL SELECT FOR EDIT MODE

            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       " + this.BuildSQLNew(isSalesOrderID, isSalesOrderDetailIDs) + " WHERE SalesOrderDetails.SalesOrderDetailID NOT IN (SELECT SalesOrderDetailID FROM DeliveryAdviceDetails WHERE DeliveryAdviceID = @DeliveryAdviceID) " + "\r\n";
            queryString = queryString + "                       UNION ALL " + "\r\n";
            queryString = queryString + "                       " + this.BuildSQLEdit(isSalesOrderID, isSalesOrderDetailIDs) + "\r\n";
            queryString = queryString + "                       ORDER BY SalesOrders.EntryDate, SalesOrders.SalesOrderID, SalesOrderDetails.SalesOrderDetailID " + "\r\n";
            queryString = queryString + "                   END " + "\r\n";

            queryString = queryString + "   END " + "\r\n";

            return queryString;
        }

        private string BuildSQLNew(bool isSalesOrderID, bool isSalesOrderDetailIDs)
        {
            string queryString = "";

            queryString = queryString + "       SELECT      SalesOrders.SalesOrderID, SalesOrderDetails.SalesOrderDetailID, SalesOrders.Reference AS SalesOrderReference, SalesOrders.EntryDate AS SalesOrderEntryDate, " + "\r\n";
            queryString = queryString + "                   Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.PackageSize, Commodities.Volume, Commodities.PackageVolume, " + "\r\n";
            queryString = queryString + "                   ROUND(SalesOrderDetails.Quantity - SalesOrderDetails.QuantityAdvice,  " + (int)GlobalEnums.rndQuantity + ") AS QuantityRemains, CAST(0 AS decimal(18, 2)) AS Quantity, " + "\r\n";
            queryString = queryString + "                   ROUND(SalesOrderDetails.LineVolume - SalesOrderDetails.LineVolumeAdvice,  " + (int)GlobalEnums.rndVolume + ") AS LineVolumeRemains, CAST(0 AS decimal(18, 2)) AS LineVolume, SalesOrders.Description, SalesOrderDetails.Remarks, CAST(1 AS bit) AS IsSelected " + "\r\n";

            queryString = queryString + "       FROM        SalesOrders " + "\r\n";
            queryString = queryString + "                   INNER JOIN SalesOrderDetails ON " + (isSalesOrderID ? " SalesOrders.SalesOrderID = @SalesOrderID " : "SalesOrders.LocationID = @LocationID AND SalesOrders.CustomerID = @CustomerID ") + " AND SalesOrderDetails.Approved = 1 AND ROUND(SalesOrderDetails.Quantity - SalesOrderDetails.QuantityAdvice, " + (int)GlobalEnums.rndQuantity + ") > 0 AND SalesOrders.SalesOrderID = SalesOrderDetails.SalesOrderID" + (isSalesOrderDetailIDs ? " AND SalesOrderDetails.SalesOrderDetailID NOT IN (SELECT Id FROM dbo.SplitToIntList (@SalesOrderDetailIDs))" : "") + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON SalesOrderDetails.CommodityID = Commodities.CommodityID " + "\r\n";

            return queryString;
        }

        private string BuildSQLEdit(bool isSalesOrderID, bool isSalesOrderDetailIDs)
        {
            string queryString = "";

            queryString = queryString + "       SELECT      SalesOrders.SalesOrderID, SalesOrderDetails.SalesOrderDetailID, SalesOrders.Reference AS SalesOrderReference, SalesOrders.EntryDate AS SalesOrderEntryDate, " + "\r\n";
            queryString = queryString + "                   Commodities.CommodityID, Commodities.Code AS CommodityCode, Commodities.Name AS CommodityName, Commodities.PackageSize, Commodities.Volume, Commodities.PackageVolume, " + "\r\n";
            queryString = queryString + "                   ROUND(SalesOrderDetails.Quantity - SalesOrderDetails.QuantityAdvice + DeliveryAdviceDetails.Quantity,  " + (int)GlobalEnums.rndQuantity + ") AS QuantityRemains, CAST(0 AS decimal(18, 2)) AS Quantity, " + "\r\n";
            queryString = queryString + "                   ROUND(SalesOrderDetails.LineVolume - SalesOrderDetails.LineVolumeAdvice + DeliveryAdviceDetails.LineVolume,  " + (int)GlobalEnums.rndVolume + ") AS LineVolumeRemains, CAST(0 AS decimal(18, 2)) AS LineVolume, SalesOrders.Description, SalesOrderDetails.Remarks, CAST(1 AS bit) AS IsSelected " + "\r\n";

            queryString = queryString + "       FROM        SalesOrderDetails " + "\r\n";
            queryString = queryString + "                   INNER JOIN DeliveryAdviceDetails ON DeliveryAdviceDetails.DeliveryAdviceID = @DeliveryAdviceID AND SalesOrderDetails.SalesOrderDetailID = DeliveryAdviceDetails.SalesOrderDetailID" + (isSalesOrderDetailIDs ? " AND SalesOrderDetails.SalesOrderDetailID NOT IN (SELECT Id FROM dbo.SplitToIntList (@SalesOrderDetailIDs))" : "") + "\r\n";
            queryString = queryString + "                   INNER JOIN SalesOrders ON SalesOrderDetails.SalesOrderID = SalesOrders.SalesOrderID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Commodities ON SalesOrderDetails.CommodityID = Commodities.CommodityID " + "\r\n";

            return queryString;
        }

        #endregion Y




        private void DeliveryAdviceSaveRelative()
        {
            string queryString = " @EntityID int, @SaveRelativeOption int " + "\r\n"; //SaveRelativeOption: 1: Update, -1:Undo
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            //queryString = queryString + "   IF (SELECT HasSalesOrder FROM DeliveryAdvices WHERE DeliveryAdviceID = @EntityID) = 1 " + "\r\n";
            queryString = queryString + "       BEGIN " + "\r\n";
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
            queryArray[1] = " SELECT TOP 1 @FoundEntity = N'Số lượng đề nghị giao vượt quá số lượng đặt hàng: ' + CAST(ROUND(Quantity - QuantityAdvice, " + (int)GlobalEnums.rndQuantity + ") AS nvarchar) + ' Hoặc khối lượng: ' + CAST(ROUND(LineVolume - LineVolumeAdvice, " + (int)GlobalEnums.rndVolume + ") AS nvarchar) FROM SalesOrderDetails WHERE (ROUND(Quantity - QuantityAdvice, " + (int)GlobalEnums.rndQuantity + ") < 0) OR (ROUND(LineVolume - LineVolumeAdvice, " + (int)GlobalEnums.rndVolume + ") < 0)";
            
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
            string[] queryArray = new string[0];

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = DeliveryAdviceID FROM DeliveryAdvices WHERE DeliveryAdviceID = @EntityID AND (InActive = 1 OR InActivePartial = 1)"; //Don't allow approve after void
            //queryArray[1] = " SELECT TOP 1 @FoundEntity = DeliveryAdviceID FROM GoodsIssueDetails WHERE DeliveryAdviceID = @EntityID ";

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

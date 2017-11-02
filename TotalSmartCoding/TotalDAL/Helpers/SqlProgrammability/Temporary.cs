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
    }




}

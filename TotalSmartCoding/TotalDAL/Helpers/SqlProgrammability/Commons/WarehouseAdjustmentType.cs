using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Commons
{
    public class WarehouseAdjustmentType
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public WarehouseAdjustmentType(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
            this.GetWarehouseAdjustmentTypeIndexes();

            //this.WarehouseAdjustmentTypeEditable(); 
            //this.WarehouseAdjustmentTypeSaveRelative();

            this.GetWarehouseAdjustmentTypeBases();
        }


        private void GetWarehouseAdjustmentTypeIndexes()
        {
            string queryString;

            queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      WarehouseAdjustmentTypes.WarehouseAdjustmentTypeID, WarehouseAdjustmentTypes.Code, WarehouseAdjustmentTypes.Name " + "\r\n";
            queryString = queryString + "       FROM        WarehouseAdjustmentTypes " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetWarehouseAdjustmentTypeIndexes", queryString);
        }


        private void WarehouseAdjustmentTypeSaveRelative()
        {
            string queryString = " @EntityID int, @SaveRelativeOption int " + "\r\n"; //SaveRelativeOption: 1: Update, -1:Undo
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF (@SaveRelativeOption = 1) " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";

            queryString = queryString + "               INSERT INTO WarehouseAdjustmentTypeWarehouseAdjustmentTypes (WarehouseAdjustmentTypeID, WarehouseAdjustmentTypeID, WarehouseAdjustmentTypeTaskID, EntryDate, Remarks, InActive) " + "\r\n";
            queryString = queryString + "               SELECT      WarehouseAdjustmentTypeID, 46 AS WarehouseAdjustmentTypeID, " + (int)GlobalEnums.NmvnTaskID.SalesOrder + " AS WarehouseAdjustmentTypeTaskID, GETDATE(), '', 0 FROM WarehouseAdjustmentTypes WHERE WarehouseAdjustmentTypeID = @EntityID " + "\r\n";

            queryString = queryString + "               INSERT INTO WarehouseAdjustmentTypeWarehouseAdjustmentTypes (WarehouseAdjustmentTypeID, WarehouseAdjustmentTypeID, WarehouseAdjustmentTypeTaskID, EntryDate, Remarks, InActive) " + "\r\n";
            queryString = queryString + "               SELECT      WarehouseAdjustmentTypes.WarehouseAdjustmentTypeID, WarehouseAdjustmentTypes.WarehouseAdjustmentTypeID, " + (int)GlobalEnums.NmvnTaskID.DeliveryAdvice + " AS WarehouseAdjustmentTypeTaskID, GETDATE(), '', 0 FROM WarehouseAdjustmentTypes INNER JOIN WarehouseAdjustmentTypes ON WarehouseAdjustmentTypes.WarehouseAdjustmentTypeID = @EntityID AND WarehouseAdjustmentTypes.WarehouseAdjustmentTypeCategoryID NOT IN (4, 5, 7, 9, 10, 11, 12) AND WarehouseAdjustmentTypes.WarehouseAdjustmentTypeCategoryID = WarehouseAdjustmentTypes.WarehouseAdjustmentTypeCategoryID " + "\r\n";

            queryString = queryString + "               INSERT INTO WarehouseAdjustmentTypeWarehouseAdjustmentTypes (WarehouseAdjustmentTypeID, WarehouseAdjustmentTypeID, WarehouseAdjustmentTypeTaskID, EntryDate, Remarks, InActive) " + "\r\n";
            queryString = queryString + "               SELECT      WarehouseAdjustmentTypeID, 82 AS WarehouseAdjustmentTypeID, " + (int)GlobalEnums.NmvnTaskID.DeliveryAdvice + " AS WarehouseAdjustmentTypeTaskID, GETDATE(), '', 0 FROM WarehouseAdjustmentTypes WHERE WarehouseAdjustmentTypeID = @EntityID AND WarehouseAdjustmentTypeCategoryID IN (4, 5, 7, 9, 10, 11, 12) " + "\r\n";

            queryString = queryString + "           END " + "\r\n";

            queryString = queryString + "       ELSE " + "\r\n"; //(@SaveRelativeOption = -1) 
            queryString = queryString + "           DELETE      WarehouseAdjustmentTypeWarehouseAdjustmentTypes WHERE WarehouseAdjustmentTypeID = @EntityID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("WarehouseAdjustmentTypeSaveRelative", queryString);
        }


        private void WarehouseAdjustmentTypeEditable()
        {
            string[] queryArray = new string[0];

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = WarehouseAdjustmentTypeID FROM WarehouseAdjustmentTypes WHERE WarehouseAdjustmentTypeID = @EntityID AND (InActive = 1 OR InActivePartial = 1)"; //Don't allow approve after void
            //queryArray[1] = " SELECT TOP 1 @FoundEntity = WarehouseAdjustmentTypeID FROM GoodsIssueDetails WHERE WarehouseAdjustmentTypeID = @EntityID ";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("WarehouseAdjustmentTypeEditable", queryArray);
        }


        private void GetWarehouseAdjustmentTypeBases()
        {
            string queryString;

            queryString = " " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      WarehouseAdjustmentTypeID, Code, Name " + "\r\n";
            queryString = queryString + "       FROM        WarehouseAdjustmentTypes " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetWarehouseAdjustmentTypeBases", queryString);
        }

    }
}

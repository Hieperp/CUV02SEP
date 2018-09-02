using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Generals
{
    public class UserControl
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public UserControl(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
            this.GetUserControlIndexes();

            //this.UserControlEditable();

            //this.UserControlAdd();
            //this.UserControlRemove();


            this.GetUserControlGroups();
            this.GetUserControlAvailableGroups();
        }

        private void GetUserControlIndexes()
        {
            string queryString;

            queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      MIN(UserID) AS UserID, SecurityIdentifier, UserName, N'Chevron Vietnam' AS UserControlType " + "\r\n";
            queryString = queryString + "       FROM        Users " + "\r\n";
            queryString = queryString + "       GROUP BY    SecurityIdentifier, UserName " + "\r\n";
            queryString = queryString + "       ORDER BY    UserName " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetUserControlIndexes", queryString);
        }

        
        private void UserControlEditable()
        {
            string[] queryArray = new string[9];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = UserID FROM BinLocations WHERE UserID = @EntityID ";
            queryArray[1] = " SELECT TOP 1 @FoundEntity = UserID FROM SalesOrders WHERE UserID = @EntityID ";
            queryArray[2] = " SELECT TOP 1 @FoundEntity = UserID FROM DeliveryAdvices WHERE UserID = @EntityID ";
            queryArray[3] = " SELECT TOP 1 @FoundEntity = UserID FROM TransferOrders WHERE UserID = @EntityID ";
            queryArray[4] = " SELECT TOP 1 @FoundEntity = UserID FROM GoodsIssues WHERE UserID = @EntityID ";
            queryArray[5] = " SELECT TOP 1 @FoundEntity = UserID FROM Pickups WHERE UserID = @EntityID ";
            queryArray[6] = " SELECT TOP 1 @FoundEntity = UserID FROM GoodsReceipts WHERE UserID = @EntityID ";
            queryArray[7] = " SELECT TOP 1 @FoundEntity = UserID FROM WarehouseAdjustments WHERE UserID = @EntityID ";
            queryArray[8] = " SELECT TOP 1 @FoundEntity = UserID FROM Forecasts WHERE UserID = @EntityID ";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("UserControlEditable", queryArray);
        }


        private void UserControlAdd()
        {
            string queryString = " @Code nvarchar(60), @Name nvarchar(100), @Description nvarchar(100) " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "       BEGIN " + "\r\n";

            queryString = queryString + "           IF (SELECT COUNT(UserControlID) FROM UserControls WHERE Code = @Code OR Name = @Name) <= 0 " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DECLARE         @UserControlID Int" + "\r\n";
            queryString = queryString + "                   INSERT INTO     UserControls (Code, Name, Description, Remarks) VALUES (@Code, @Name, @Description, NULL); " + "\r\n";
            queryString = queryString + "                   SELECT          @UserControlID = SCOPE_IDENTITY(); " + "\r\n";

            queryString = queryString + "                   INSERT INTO     UserControlControls (UserControlID, ModuleDetailID, LocationID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, InActive) " + "\r\n";
            queryString = queryString + "                   SELECT          @UserControlID, ModuleDetails.ModuleDetailID, Locations.LocationID, 0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, 0 AS ShowDiscount, 0 AS InActive " + "\r\n";
            queryString = queryString + "                   FROM            ModuleDetails CROSS JOIN Locations " + "\r\n";
            queryString = queryString + "                   WHERE           ModuleDetails.ControlTypeID <> 0 OR (ModuleDetails.ControlTypeID = 0 AND Locations.LocationID = 1); " + "\r\n";

            queryString = queryString + "               END " + "\r\n";

            queryString = queryString + "           ELSE " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DECLARE     @msg NVARCHAR(300) = N'Thêm mới trùng tên.' ; " + "\r\n";
            queryString = queryString + "                   THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "               END " + "\r\n";

            queryString = queryString + "       END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("UserControlAdd", queryString);
        }


        private void UserControlRemove()
        {
            string queryString = " @UserControlID int, @Code nvarchar(256)" + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "       BEGIN " + "\r\n";

            queryString = queryString + "           DECLARE     @FoundEntitys TABLE (FoundEntity int NULL) " + "\r\n";
            queryString = queryString + "           INSERT INTO @FoundEntitys EXEC UserControlEditable @UserControlID " + "\r\n";

            queryString = queryString + "           IF (SELECT COUNT(*) FROM @FoundEntitys WHERE NOT FoundEntity IS NULL) <= 0 " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DELETE FROM     UserControlControls WHERE UserControlID = @UserControlID " + "\r\n";
            queryString = queryString + "                   DELETE FROM     UserControlDetails WHERE UserControlID = @UserControlID " + "\r\n";
            queryString = queryString + "                   DELETE FROM     UserControls WHERE UserControlID = @UserControlID " + "\r\n";
            queryString = queryString + "               END " + "\r\n";

            queryString = queryString + "           ELSE " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DECLARE     @msg NVARCHAR(300) = N'Không thể xóa ' + @Code + '. Vui lòng remove user trước khi xóa group.' ; " + "\r\n";
            queryString = queryString + "                   THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "               END " + "\r\n";

            queryString = queryString + "       END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("UserControlRemove", queryString);
        }

        

        private void GetUserControlGroups()
        {
            string queryString;

            queryString = " @SecurityIdentifier nvarchar(256) " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      UserGroupDetails.UserGroupDetailID, UserGroupDetails.UserGroupID, UserGroups.Code AS UserGroupCode, UserGroups.Name AS UserGroupName, N'Chevron Vietnam' AS GroupType " + "\r\n";
            queryString = queryString + "       FROM        UserGroupDetails INNER JOIN UserGroups ON UserGroupDetails.SecurityIdentifier = @SecurityIdentifier AND UserGroupDetails.UserGroupID = UserGroups.UserGroupID " + "\r\n";
            queryString = queryString + "       ORDER BY    UserGroupDetails.UserGroupDetailID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetUserControlGroups", queryString);
        }

        private void GetUserControlAvailableGroups()
        {
            string queryString = " @SecurityIdentifier nvarchar(256) " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "       BEGIN " + "\r\n";
            queryString = queryString + "           SELECT  UserGroupID, Code, Name, Description, N'Chevron Vietnam' AS UserGroup FROM UserGroups WHERE UserGroupID NOT IN (SELECT UserGroupID FROM UserGroupDetails WHERE SecurityIdentifier = @SecurityIdentifier) ORDER BY Code, Name " + "\r\n";
            queryString = queryString + "       END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetUserControlAvailableGroups", queryString);
        }

    }
}

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

            this.UserControlEditable();

            this.UserControlRegister();
            


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

            queryString = queryString + "       UPDATE Users SET IsDatabaseAdmin = 1 WHERE SecurityIdentifier IN (SELECT SecurityIdentifier FROM Users WHERE IsDatabaseAdmin = 1) " + "\r\n";

            queryString = queryString + "       SELECT      MIN(UserID) AS UserID, SecurityIdentifier, UserName, IsDatabaseAdmin, N'Chevron Vietnam' AS UserControlType " + "\r\n";
            queryString = queryString + "       FROM        Users " + "\r\n";
            queryString = queryString + "       GROUP BY    SecurityIdentifier, UserName, IsDatabaseAdmin " + "\r\n";
            queryString = queryString + "       ORDER BY    UserName " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetUserControlIndexes", queryString);
        }


        private void UserControlEditable()
        {
            string[] queryArray = new string[9];

            string queryString = "              DECLARE @SecurityIdentifier nvarchar(256) " + "\r\n";
            queryString = queryString + "       SELECT TOP 1 @SecurityIdentifier = SecurityIdentifier FROM Users WHERE UserID = @EntityID " + "\r\n";

            queryArray[0] = " SELECT TOP 1 @FoundEntity = UserID FROM BinLocations WHERE UserID IN (SELECT UserID FROM Users WHERE SecurityIdentifier = @SecurityIdentifier) ";
            queryArray[1] = " SELECT TOP 1 @FoundEntity = UserID FROM SalesOrders WHERE UserID IN (SELECT UserID FROM Users WHERE SecurityIdentifier = @SecurityIdentifier) ";
            queryArray[2] = " SELECT TOP 1 @FoundEntity = UserID FROM DeliveryAdvices WHERE UserID IN (SELECT UserID FROM Users WHERE SecurityIdentifier = @SecurityIdentifier) ";
            queryArray[3] = " SELECT TOP 1 @FoundEntity = UserID FROM TransferOrders WHERE UserID IN (SELECT UserID FROM Users WHERE SecurityIdentifier = @SecurityIdentifier) ";
            queryArray[4] = " SELECT TOP 1 @FoundEntity = UserID FROM GoodsIssues WHERE UserID IN (SELECT UserID FROM Users WHERE SecurityIdentifier = @SecurityIdentifier) ";
            queryArray[5] = " SELECT TOP 1 @FoundEntity = UserID FROM Pickups WHERE UserID IN (SELECT UserID FROM Users WHERE SecurityIdentifier = @SecurityIdentifier) ";
            queryArray[6] = " SELECT TOP 1 @FoundEntity = UserID FROM GoodsReceipts WHERE UserID IN (SELECT UserID FROM Users WHERE SecurityIdentifier = @SecurityIdentifier) ";
            queryArray[7] = " SELECT TOP 1 @FoundEntity = UserID FROM WarehouseAdjustments WHERE UserID IN (SELECT UserID FROM Users WHERE SecurityIdentifier = @SecurityIdentifier) ";
            queryArray[8] = " SELECT TOP 1 @FoundEntity = UserID FROM Forecasts WHERE UserID IN (SELECT UserID FROM Users WHERE SecurityIdentifier = @SecurityIdentifier) ";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("UserControlEditable", queryArray, queryString);
        }


        private void UserControlRegister()
        {
            string queryString = " @FirstName nvarchar(60), @LastName nvarchar(60), @UserName nvarchar(256), @SecurityIdentifier nvarchar(256) " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       BEGIN " + "\r\n";
           
            queryString = queryString + "           IF (SELECT COUNT(UserID) FROM Users WHERE SecurityIdentifier = @SecurityIdentifier) <= 0 " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";

            queryString = queryString + "                   DECLARE @LocationID int, @OrganizationalUnitID int " + "\r\n";

            queryString = queryString + "                   DECLARE Action_Cursor CURSOR FOR SELECT LocationID, MIN(OrganizationalUnitID) AS OrganizationalUnitID FROM OrganizationalUnits GROUP BY LocationID OPEN Action_Cursor; " + "\r\n";
            queryString = queryString + "                   FETCH NEXT FROM Action_Cursor INTO @LocationID, @OrganizationalUnitID; " + "\r\n";
            queryString = queryString + "                   WHILE @@FETCH_STATUS = 0 " + "\r\n";
            queryString = queryString + "                       BEGIN " + "\r\n";

            queryString = queryString + "                           EXEC UserRegister @LocationID, @OrganizationalUnitID, @FirstName, @LastName, @UserName, @SecurityIdentifier, 0, 0, 0 " + "\r\n";
            
            queryString = queryString + "                           FETCH NEXT FROM Action_Cursor INTO @LocationID, @OrganizationalUnitID; " + "\r\n";

            queryString = queryString + "                       END" + "\r\n";
            queryString = queryString + "                   CLOSE Action_Cursor; " + "\r\n";
            queryString = queryString + "                   DEALLOCATE Action_Cursor " + "\r\n";

            queryString = queryString + "               END " + "\r\n";

            queryString = queryString + "           ELSE " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DECLARE     @msg NVARCHAR(300) = N'Đăng ký trùng user (UserControl)' ; " + "\r\n";
            queryString = queryString + "                   THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "               END " + "\r\n";

            queryString = queryString + "       END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("UserControlRegister", queryString);
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
            queryString = queryString + "           SELECT  UserGroupID, Code AS GroupCode, Name AS GroupName, Description, N'Chevron Vietnam' AS UserGroup FROM UserGroups WHERE UserGroupID NOT IN (SELECT UserGroupID FROM UserGroupDetails WHERE SecurityIdentifier = @SecurityIdentifier) ORDER BY Code, Name " + "\r\n";
            queryString = queryString + "       END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetUserControlAvailableGroups", queryString);
        }

    }
}

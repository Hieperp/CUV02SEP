using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Generals
{
    public class UserGroupControl
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public UserGroupControl(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
            //this.GetUserIndexes();            

            //this.GetActiveUsers();
            
            //this.UserEditable();
            
            //this.UserToggleVoid();

            this.GetUserGroupControls();
            this.SaveUserGroupControls();

            //this.GetUserTrees();
        }


        private void GetUserIndexes()
        {
            string queryString;

            queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime, @ActiveOption int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      Users.UserID, Users.FirstName, Users.LastName, Users.UserName, Users.SecurityIdentifier, Users.IsDatabaseAdmin, UserGroups.Name AS UserGroupName, UserGroups.LocationID, Locations.Name AS LocationName, UserGroupUsers.InActive " + "\r\n";
            queryString = queryString + "       FROM        Users " + "\r\n";
            queryString = queryString + "                   INNER JOIN UserGroupUsers ON Users.UserID = UserGroupUsers.UserID AND (@ActiveOption = " + (int)GlobalEnums.ActiveOption.Both + " OR Users.InActive = @ActiveOption) " + "\r\n";
            queryString = queryString + "                   INNER JOIN UserGroups ON UserGroupUsers.UserGroupID = UserGroups.UserGroupID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Locations ON UserGroups.LocationID = Locations.LocationID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetUserIndexes", queryString);
        }

        private void GetActiveUsers()
        {
            string queryString;

            queryString = " @SecurityIdentifier nvarchar(256) " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      Users.UserID, Users.FirstName, Users.LastName, Users.UserName, Users.SecurityIdentifier, Users.IsDatabaseAdmin, Users.UserGroupID, UserGroups.Name AS UserGroupName, UserGroups.LocationID, Locations.Name AS LocationName " + "\r\n";
            queryString = queryString + "       FROM        Users " + "\r\n";
            queryString = queryString + "                   INNER JOIN UserGroups ON Users.SecurityIdentifier = @SecurityIdentifier AND Users.InActive = 0 AND Users.UserGroupID = UserGroups.UserGroupID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Locations ON UserGroups.LocationID = Locations.LocationID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetActiveUsers", queryString);
        }

        private void UserEditable()
        {
            string[] queryArray = new string[8];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = UserID FROM BinLocations WHERE UserID = @EntityID ";
            queryArray[1] = " SELECT TOP 1 @FoundEntity = UserID FROM SalesOrders WHERE UserID = @EntityID ";
            queryArray[2] = " SELECT TOP 1 @FoundEntity = UserID FROM DeliveryAdvices WHERE UserID = @EntityID ";
            queryArray[3] = " SELECT TOP 1 @FoundEntity = UserID FROM TransferOrders WHERE UserID = @EntityID ";
            queryArray[4] = " SELECT TOP 1 @FoundEntity = UserID FROM GoodsIssues WHERE UserID = @EntityID ";
            queryArray[5] = " SELECT TOP 1 @FoundEntity = UserID FROM Pickups WHERE UserID = @EntityID ";
            queryArray[6] = " SELECT TOP 1 @FoundEntity = UserID FROM GoodsReceipts WHERE UserID = @EntityID ";
            queryArray[7] = " SELECT TOP 1 @FoundEntity = UserID FROM WarehouseAdjustments WHERE UserID = @EntityID ";


            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("UserEditable", queryArray);
        }

        

        private void UserToggleVoid()
        {
            string queryString = " @EntityID int, @InActive bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       UPDATE      Users                       SET InActive = @InActive                            WHERE UserID = @EntityID AND InActive = ~@InActive" + "\r\n";
            queryString = queryString + "       UPDATE      UserGroupControls              SET InActive = @InActive                            WHERE UserID = @EntityID AND InActive = ~@InActive" + "\r\n";
            queryString = queryString + "       UPDATE      UserGroupUsers     SET InActive = @InActive, InActiveDate = GetDate()  WHERE UserID = @EntityID AND InActive = ~@InActive" + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("UserToggleVoid", queryString);
        }

        private void GetUserGroupControls()
        {
            string queryString;

            queryString = " @UserGroupID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      UserGroupControls.UserGroupControlID, Modules.ModuleID, IIF(ModuleDetails.Controller <> N'#', ModuleDetails.Controller, Modules.Code) AS ModuleName, ModuleDetails.ModuleDetailID, ModuleDetails.Name AS ModuleDetailName, UserGroupControls.LocationID, IIF(ModuleDetails.ControlTypeID = 0, N'', Locations.Name) AS LocationName, UserGroupControls.AccessLevel, UserGroupControls.ApprovalPermitted, UserGroupControls.UnApprovalPermitted, UserGroupControls.VoidablePermitted, UserGroupControls.UnVoidablePermitted, UserGroupControls.ShowDiscount " + "\r\n";
            queryString = queryString + "       FROM        UserGroupControls INNER JOIN ModuleDetails ON UserGroupControls.UserGroupID = @UserGroupID AND UserGroupControls.ModuleDetailID = ModuleDetails.ModuleDetailID INNER JOIN Modules ON ModuleDetails.ModuleID = Modules.ModuleID INNER JOIN Locations ON UserGroupControls.LocationID = Locations.LocationID " + "\r\n";
            queryString = queryString + "       ORDER BY    Modules.Name, ModuleName, ModuleDetails.SerialID, Locations.LocationID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetUserGroupControls", queryString);
        }

        private void SaveUserGroupControls()
        {
            string queryString = " @UserGroupControlID int, @AccessLevel Int, @ApprovalPermitted bit, @UnApprovalPermitted bit, @VoidablePermitted bit, @UnVoidablePermitted bit, @ShowDiscount bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       BEGIN " + "\r\n";

            queryString = queryString + "           UPDATE          UserGroupControls " + "\r\n";
            queryString = queryString + "           SET             AccessLevel = @AccessLevel, ApprovalPermitted = @ApprovalPermitted, UnApprovalPermitted = @UnApprovalPermitted, VoidablePermitted = @VoidablePermitted, UnVoidablePermitted = @UnVoidablePermitted, ShowDiscount = @ShowDiscount " + "\r\n";
            queryString = queryString + "           WHERE           UserGroupControlID = @UserGroupControlID " + "\r\n";

            queryString = queryString + "           IF @@ROWCOUNT <> 1 " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DECLARE     @msg NVARCHAR(300) = N'Unknow error: Save User Access Controls. Please exit then open and try again.' ; " + "\r\n";
            queryString = queryString + "                   THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "               END " + "\r\n";
            queryString = queryString + "       END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("SaveUserGroupControls", queryString);
        }


        private void GetUserTrees()
        {
            string queryString;

            queryString = " @ActiveOption int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      " + GlobalEnums.RootNode + " + LocationID AS NodeID, 0 AS ParentNodeID, LocationID AS PrimaryID, NULL AS AncestorID, Code, Name, 'LocationID' AS ParameterName, CAST(0 AS bit) AS Selected " + "\r\n";
            queryString = queryString + "       FROM        Locations " + "\r\n";

            queryString = queryString + "       UNION ALL " + "\r\n";
            queryString = queryString + "       SELECT      " + GlobalEnums.AncestorNode + " + UserGroupID AS NodeID, " + GlobalEnums.RootNode + " + LocationID AS ParentNodeID, UserGroupID AS PrimaryID, LocationID AS AncestorID, Code, Name, 'UserGroupID' AS ParameterName, CAST(0 AS bit) AS Selected " + "\r\n";
            queryString = queryString + "       FROM        UserGroups " + "\r\n";
            queryString = queryString + "       UNION ALL " + "\r\n";
            queryString = queryString + "       SELECT      UserID AS NodeID, " + GlobalEnums.AncestorNode + " + UserGroupID AS ParentNodeID, UserID AS PrimaryID, UserGroupID AS AncestorID, SecurityIdentifier AS Code, UserName AS Name, 'UserID' AS ParameterName, InActive AS Selected " + "\r\n";
            queryString = queryString + "       FROM        Users " + "\r\n";
            queryString = queryString + "       WHERE       (@ActiveOption = " + (int)GlobalEnums.ActiveOption.Both + " OR Users.InActive = @ActiveOption) " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetUserTrees", queryString);
        }
    }
}

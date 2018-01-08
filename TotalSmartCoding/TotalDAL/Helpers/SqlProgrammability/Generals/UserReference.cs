using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Generals
{
    public class UserReference
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public UserReference(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
            this.GetUserIndexes();
            this.GetOrganizationalUnitIndexes();

            this.GetActiveUsers();
            
            this.UserEditable();
            this.UserRegister();
            this.UserUnregister();

            this.GetUserAccessControls();
            this.SaveUserAccessControls();

            this.GetUserTrees();
        }


        private void GetUserIndexes()
        {
            string queryString;

            queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime, @ActiveOption int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      Users.UserID, Users.FirstName, Users.LastName, Users.UserName, Users.SecurityIdentifier, Users.IsDatabaseAdmin, OrganizationalUnits.Name AS OrganizationalUnitName, OrganizationalUnits.LocationID, Locations.Name AS LocationName, OrganizationalUnitUsers.InActive " + "\r\n";
            queryString = queryString + "       FROM        Users " + "\r\n";
            queryString = queryString + "                   INNER JOIN OrganizationalUnitUsers ON Users.UserID = OrganizationalUnitUsers.UserID AND (@ActiveOption = " + (int)GlobalEnums.ActiveOption.Both + " OR Users.InActive = @ActiveOption) " + "\r\n";
            queryString = queryString + "                   INNER JOIN OrganizationalUnits ON OrganizationalUnitUsers.OrganizationalUnitID = OrganizationalUnits.OrganizationalUnitID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Locations ON OrganizationalUnits.LocationID = Locations.LocationID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetUserIndexes", queryString);
        }

        private void GetOrganizationalUnitIndexes()
        {
            string queryString;

            queryString = " " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      OrganizationalUnits.OrganizationalUnitID, OrganizationalUnits.Name AS OrganizationalUnitName, OrganizationalUnits.LocationID, Locations.Name AS LocationName, Locations.Name + '\\' + OrganizationalUnits.Name AS LocationOrganizationalUnitName " + "\r\n";
            queryString = queryString + "       FROM        Locations INNER JOIN OrganizationalUnits ON Locations.LocationID = OrganizationalUnits.LocationID " + "\r\n";
            queryString = queryString + "       ORDER BY    Locations.Name, OrganizationalUnits.Name " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetOrganizationalUnitIndexes", queryString);
        }

        private void GetActiveUsers()
        {
            string queryString;

            queryString = " @SecurityIdentifier nvarchar(256) " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      Users.UserID, Users.FirstName, Users.LastName, Users.UserName, Users.SecurityIdentifier, Users.IsDatabaseAdmin, Users.OrganizationalUnitID, OrganizationalUnits.Name AS OrganizationalUnitName, OrganizationalUnits.LocationID, Locations.Name AS LocationName " + "\r\n";
            queryString = queryString + "       FROM        Users " + "\r\n";
            queryString = queryString + "                   INNER JOIN OrganizationalUnits ON Users.SecurityIdentifier = @SecurityIdentifier AND Users.InActive = 0 AND Users.OrganizationalUnitID = OrganizationalUnits.OrganizationalUnitID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Locations ON OrganizationalUnits.LocationID = Locations.LocationID " + "\r\n";

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

        private void UserRegister()
        {
            string queryString = " @LocationID int, @OrganizationalUnitID int, @FirstName nvarchar(60), @LastName nvarchar(60), @UserName nvarchar(256), @SecurityIdentifier nvarchar(256) " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            //LUU Y RAT QUAN TRONG - VERY IMPORTANT
            //AT NOW: OrganizationalUnitUsers KHONG CON PHU HOP NUA, TUY NHIEN, VAN PHAI DUY TRI VI KHONG CO THOI GIAN MODIFY
            //YEU CAU LUC NAY LA: LAM SAO DAM BAO Users(UserID, OrganizationalUnitID) VA OrganizationalUnitUsers(OrganizationalUnitID, UserID) PHAI MATCH 1-1
            //DO DO: KHI ADD, REMOVE, EDIT, INACTIVE, ... PHAI DAM BAO YEU CAU NAY THI MOI THU SE OK
            queryString = queryString + "       BEGIN " + "\r\n";

            queryString = queryString + "           IF (SELECT COUNT(Users.UserID) FROM Users INNER JOIN OrganizationalUnits ON Users.OrganizationalUnitID = OrganizationalUnits.OrganizationalUnitID WHERE InActive = 0 AND OrganizationalUnits.LocationID = @LocationID AND Users.SecurityIdentifier = @SecurityIdentifier) <= 0 " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DECLARE         @UserID Int" + "\r\n";
            queryString = queryString + "                   INSERT INTO     Users (OrganizationalUnitID, FirstName, LastName, UserName, SecurityIdentifier, IsDatabaseAdmin, InActive) VALUES (@OrganizationalUnitID, @FirstName, @LastName, @UserName, @SecurityIdentifier, 0, 0); " + "\r\n";
            queryString = queryString + "                   SELECT          @UserID = SCOPE_IDENTITY(); " + "\r\n";
            queryString = queryString + "                   INSERT INTO     OrganizationalUnitUsers (OrganizationalUnitID, UserID, InActive) VALUES (@OrganizationalUnitID, @UserID, 0); " + "\r\n";

            queryString = queryString + "                   INSERT INTO     AccessControls (UserID, NMVNTaskID, OrganizationalUnitID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount) " + "\r\n";
            queryString = queryString + "                   SELECT          @UserID, ModuleDetails.ModuleDetailID, OrganizationalUnits.OrganizationalUnitID, 0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, 0 AS ShowDiscount " + "\r\n";
            queryString = queryString + "                   FROM            ModuleDetails CROSS JOIN OrganizationalUnits" + "\r\n";
            queryString = queryString + "                   WHERE           ModuleDetails.InActive = 0; " + "\r\n";
            queryString = queryString + "               END " + "\r\n";

            queryString = queryString + "           ELSE " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DECLARE     @msg NVARCHAR(300) = N'Đăng ký user trùng location.' ; " + "\r\n";
            queryString = queryString + "                   THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "               END " + "\r\n";

            queryString = queryString + "       END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("UserRegister", queryString);
        }

        private void UserUnregister()
        {
            string queryString = " @UserID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "       BEGIN " + "\r\n";

            queryString = queryString + "           DECLARE     @FoundEntitys TABLE (FoundEntity int NULL) " + "\r\n";
            queryString = queryString + "           INSERT INTO @FoundEntitys EXEC UserEditable @UserID " + "\r\n";

            queryString = queryString + "           IF (SELECT COUNT(*) FROM @FoundEntitys WHERE NOT FoundEntity IS NULL) <= 0 " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DELETE FROM     AccessControls WHERE UserID = @UserID " + "\r\n";
            queryString = queryString + "                   DELETE FROM     OrganizationalUnitUsers WHERE UserID = @UserID " + "\r\n";
            queryString = queryString + "                   DELETE FROM     Users WHERE UserID = @UserID " + "\r\n";
            queryString = queryString + "               END " + "\r\n";

            queryString = queryString + "           ELSE " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DECLARE     @msg NVARCHAR(300) = N'Không thể hủy đăng ký user tại location, vì user đã có dữ liệu tại location này. \r\nVui lòng Inactive để thay vì unregister.' ; " + "\r\n";
            queryString = queryString + "                   THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "               END " + "\r\n";

            queryString = queryString + "       END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("UserUnregister", queryString);
        }

        private void GetUserAccessControls()
        {
            string queryString;

            queryString = " @UserID int, @NMVNTaskID int" + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      AccessControls.AccessControlID, OrganizationalUnits.LocationID, Locations.Name AS LocationName, OrganizationalUnits.Name AS OrganizationalUnitName, AccessControls.OrganizationalUnitID, AccessControls.AccessLevel, AccessControls.ApprovalPermitted, AccessControls.UnApprovalPermitted, AccessControls.VoidablePermitted, AccessControls.UnVoidablePermitted, AccessControls.ShowDiscount " + "\r\n";
            queryString = queryString + "       FROM        AccessControls INNER JOIN OrganizationalUnits ON AccessControls.OrganizationalUnitID = OrganizationalUnits.OrganizationalUnitID INNER JOIN Locations ON OrganizationalUnits.LocationID = Locations.LocationID " + "\r\n";
            queryString = queryString + "       WHERE       AccessControls.UserID = @UserID AND AccessControls.NMVNTaskID = @NMVNTaskID " + "\r\n";
            queryString = queryString + "       ORDER BY    Locations.Name, OrganizationalUnits.Name " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetUserAccessControls", queryString);
        }

        private void SaveUserAccessControls()
        {
            string queryString = " @AccessControlID int, @AccessLevel Int, @ApprovalPermitted bit, @UnApprovalPermitted bit, @VoidablePermitted bit, @UnVoidablePermitted bit, @ShowDiscount bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       BEGIN " + "\r\n";

            queryString = queryString + "           UPDATE          AccessControls " + "\r\n";
            queryString = queryString + "           SET             AccessLevel = @AccessLevel, ApprovalPermitted = @ApprovalPermitted, UnApprovalPermitted = @UnApprovalPermitted, VoidablePermitted = @VoidablePermitted, UnVoidablePermitted = @UnVoidablePermitted, ShowDiscount = @ShowDiscount " + "\r\n";
            queryString = queryString + "           WHERE           AccessControlID = @AccessControlID " + "\r\n";

            queryString = queryString + "           IF @@ROWCOUNT <> 1 " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DECLARE     @msg NVARCHAR(300) = N'Unknow error: SaveUserAccessControls. Please exit then open and try again.' ; " + "\r\n";
            queryString = queryString + "                   THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "               END " + "\r\n";
            queryString = queryString + "       END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("SaveUserAccessControls", queryString);
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
            queryString = queryString + "       SELECT      " + GlobalEnums.AncestorNode + " + OrganizationalUnitID AS NodeID, " + GlobalEnums.RootNode + " + LocationID AS ParentNodeID, OrganizationalUnitID AS PrimaryID, LocationID AS AncestorID, Code, Name, 'OrganizationalUnitID' AS ParameterName, CAST(0 AS bit) AS Selected " + "\r\n";
            queryString = queryString + "       FROM        OrganizationalUnits " + "\r\n";
            queryString = queryString + "       UNION ALL " + "\r\n";
            queryString = queryString + "       SELECT      UserID AS NodeID, " + GlobalEnums.AncestorNode + " + OrganizationalUnitID AS ParentNodeID, UserID AS PrimaryID, OrganizationalUnitID AS AncestorID, SecurityIdentifier AS Code, UserName AS Name, 'UserID' AS ParameterName, InActive AS Selected " + "\r\n";
            queryString = queryString + "       FROM        Users " + "\r\n";
            queryString = queryString + "       WHERE       (@ActiveOption = " + (int)GlobalEnums.ActiveOption.Both + " OR Users.InActive = @ActiveOption) " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetUserTrees", queryString);
        }
    }
}

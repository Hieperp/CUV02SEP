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
            //this.UserRegister();
            //this.UserUnregister();
            //this.UserToggleVoid();

            this.GetUserGroupControls();
            //this.SaveUserGroupControls();

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

        private void UserRegister()
        {
            string queryString = " @LocationID int, @UserGroupID int, @FirstName nvarchar(60), @LastName nvarchar(60), @UserName nvarchar(256), @SecurityIdentifier nvarchar(256), @SameOUAccessLevel int, @SameLocationAccessLevel int, @OtherOUAccessLevel int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            //LUU Y RAT QUAN TRONG - VERY IMPORTANT
            //AT NOW: UserGroupUsers KHONG CON PHU HOP NUA, TUY NHIEN, VAN PHAI DUY TRI VI KHONG CO THOI GIAN MODIFY
            //YEU CAU LUC NAY LA: LAM SAO DAM BAO Users(UserID, UserGroupID) VA UserGroupUsers(UserGroupID, UserID) PHAI MATCH 1-1
            //DO DO: KHI ADD, REMOVE, EDIT, INACTIVE, ... PHAI DAM BAO YEU CAU NAY THI MOI THU SE OK
            queryString = queryString + "       BEGIN " + "\r\n";

            //---08/JAN/2018: HIỆN TẠI KHÔNG CHO PHÉP ĐĂNG KÝ TRÙNG USER-LOCATION
            //--->TUY NHIÊN, HOÀN TOÀN CÓ THỂ CẢI TIẾN CHỔ NÀY, CHO PHÉP ĐĂNG KÝ TRÙNG CHO NEW USER-LOCATION NẾU: Users.InActive = 0 AND 
            //--->KHI ĐÓ: UserToggleVoid: CẦN PHẢI XEM XÉT LẠI --> NHẰM ĐẢM BẢO RẰNG: NẾU ĐÃ CÓ 1 InActive THÌ SẼ KHÔNG THỂ ENABLE CÙNG 1 USER-LOCATION
            //--->TỨC LÀ: CÓ THỂ CẢI TIẾN --> CHO PHÉP TRÙNG USER-LOCATION, TUY NHIÊN: PHẢI ĐẢM BẢO CHỈ CÓ 1 USER-LOCATION LÀ InActive = 0
            //--->NHU CẦU ĐĂMG KÝ TRÙNG USER-LOCATION LÀ CÓ: NÓ GIẢI QUYẾT VẤN ĐỀ CẤP LẠI UserGroups CHO USER TRONG CÙNG LOCATION (VÍ DỤ: CẦN CHIA UserGroups => DO ĐÓ: PHẢI ĐĂNG KÝ LẠI USER-LOCATION CHO MỘT UserGroups KHÁC)
            queryString = queryString + "           IF (SELECT COUNT(Users.UserID) FROM Users INNER JOIN UserGroups ON Users.UserGroupID = UserGroups.UserGroupID WHERE UserGroups.LocationID = @LocationID AND Users.SecurityIdentifier = @SecurityIdentifier) <= 0 " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DECLARE         @UserID Int" + "\r\n";
            queryString = queryString + "                   INSERT INTO     Users (UserGroupID, FirstName, LastName, UserName, SecurityIdentifier, IsDatabaseAdmin, InActive) VALUES (@UserGroupID, @FirstName, @LastName, @UserName, @SecurityIdentifier, 0, 0); " + "\r\n";
            queryString = queryString + "                   SELECT          @UserID = SCOPE_IDENTITY(); " + "\r\n";
            queryString = queryString + "                   INSERT INTO     UserGroupUsers (UserGroupID, UserID, InActive, InActiveDate) VALUES (@UserGroupID, @UserID, 0, NULL); " + "\r\n";

            queryString = queryString + "                   INSERT INTO     UserGroupControls (UserID, NMVNTaskID, UserGroupID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, InActive) " + "\r\n";
            queryString = queryString + "                   SELECT          @UserID, ModuleDetails.ModuleDetailID, UserGroups.UserGroupID, CASE WHEN UserGroups.UserGroupID = @UserGroupID THEN @SameOUAccessLevel WHEN UserGroups.LocationID = @LocationID THEN @SameLocationAccessLevel ELSE @OtherOUAccessLevel END AS AccessLevel, CASE WHEN UserGroups.UserGroupID = @UserGroupID AND @SameOUAccessLevel = " + (int)GlobalEnums.AccessLevel.Editable + " THEN 1 ELSE 0 END AS ApprovalPermitted, CASE WHEN UserGroups.UserGroupID = @UserGroupID AND @SameOUAccessLevel = " + (int)GlobalEnums.AccessLevel.Editable + " THEN 1 ELSE 0 END AS UnApprovalPermitted, CASE WHEN UserGroups.UserGroupID = @UserGroupID AND @SameOUAccessLevel = " + (int)GlobalEnums.AccessLevel.Editable + " THEN 1 ELSE 0 END AS VoidablePermitted, CASE WHEN UserGroups.UserGroupID = @UserGroupID AND @SameOUAccessLevel = " + (int)GlobalEnums.AccessLevel.Editable + " THEN 1 ELSE 0 END AS UnVoidablePermitted, 0 AS ShowDiscount, 0 AS InActive " + "\r\n";
            queryString = queryString + "                   FROM            ModuleDetails CROSS JOIN UserGroups" + "\r\n";
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
            string queryString = " @UserID int, @UserName nvarchar(256), @UserGroupName nvarchar(256)" + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "       BEGIN " + "\r\n";

            queryString = queryString + "           DECLARE     @FoundEntitys TABLE (FoundEntity int NULL) " + "\r\n";
            queryString = queryString + "           INSERT INTO @FoundEntitys EXEC UserEditable @UserID " + "\r\n";

            queryString = queryString + "           IF (SELECT COUNT(*) FROM @FoundEntitys WHERE NOT FoundEntity IS NULL) <= 0 " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DELETE FROM     UserGroupControls WHERE UserID = @UserID " + "\r\n";
            queryString = queryString + "                   DELETE FROM     UserGroupUsers WHERE UserID = @UserID " + "\r\n";
            queryString = queryString + "                   DELETE FROM     Users WHERE UserID = @UserID " + "\r\n";
            queryString = queryString + "               END " + "\r\n";

            queryString = queryString + "           ELSE " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DECLARE     @msg NVARCHAR(300) = N'Không thể hủy đăng ký ' + @UserName + N' tại ' + @UserGroupName + N', do ' + @UserName + N' hiện đang có dữ liệu tại ' + @UserGroupName + N'\r\n\r\n\r\nVui lòng Inactive để dừng đăng ký và sử dụng ' + @UserName + N' tại ' + @UserGroupName + '.' ; " + "\r\n";
            queryString = queryString + "                   THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "               END " + "\r\n";

            queryString = queryString + "       END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("UserUnregister", queryString);
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

            queryString = " @UserGroupID int, @NMVNTaskID int" + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      UserGroupControls.UserGroupControlID, Modules.ModuleID, Modules.Name AS ModuleName, ModuleDetails.ModuleDetailID, ModuleDetails.Name AS ModuleDetailName, UserGroupControls.LocationID, Locations.Name AS LocationName, UserGroupControls.AccessLevel, UserGroupControls.ApprovalPermitted, UserGroupControls.UnApprovalPermitted, UserGroupControls.VoidablePermitted, UserGroupControls.UnVoidablePermitted, UserGroupControls.ShowDiscount " + "\r\n";
            queryString = queryString + "       FROM        UserGroupControls INNER JOIN ModuleDetails ON UserGroupControls.UserGroupID = @UserGroupID AND UserGroupControls.ModuleDetailID = ModuleDetails.ModuleDetailID INNER JOIN Modules ON ModuleDetails.ModuleID = Modules.ModuleID INNER JOIN Locations ON UserGroupControls.LocationID = Locations.LocationID " + "\r\n";
            queryString = queryString + "       ORDER BY    Modules.Name, ModuleDetails.Name, Locations.Name " + "\r\n";

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

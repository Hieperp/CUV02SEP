using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Generals
{
    public class UserGroup
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public UserGroup(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
            this.GetUserGroupIndexes();

            this.UserGroupEditable();

            this.UserGroupAdd();
            this.UserGroupRemove();
        }

        private void GetUserGroupIndexes()
        {
            string queryString;

            queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      UserGroupID, Code, Name, Description, Remarks, N'Chevron Vietnam' AS UserGroupType " + "\r\n";
            queryString = queryString + "       FROM        UserGroups " + "\r\n";
            queryString = queryString + "       ORDER BY    Code " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetUserGroupIndexes", queryString);
        }

        private void UserGroupEditable()
        {
            string[] queryArray = new string[0];

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = UserGroupID FROM Users WHERE UserGroupID = @EntityID ";
        
            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("UserGroupEditable", queryArray);
        }


        private void UserGroupAdd()
        {
            string queryString = " @Code nvarchar(60), @Name nvarchar(100), @Description nvarchar(100) " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "       BEGIN " + "\r\n";

            queryString = queryString + "           IF (SELECT COUNT(UserGroupID) FROM UserGroups WHERE Code = @Code OR Name = @Name) <= 0 " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DECLARE         @UserGroupID Int" + "\r\n";
            queryString = queryString + "                   INSERT INTO     UserGroups (Code, Name, Description, Remarks) VALUES (@Code, @Name, @Description, NULL); " + "\r\n";
            queryString = queryString + "                   SELECT          @UserGroupID = SCOPE_IDENTITY(); " + "\r\n";

            queryString = queryString + "                   INSERT INTO     UserGroupControls (UserGroupID, ModuleDetailID, LocationID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, InActive) " + "\r\n";
            queryString = queryString + "                   SELECT          @UserGroupID, ModuleDetails.ModuleDetailID, Locations.LocationID, 0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, 0 AS ShowDiscount, 0 AS InActive " + "\r\n";
            queryString = queryString + "                   FROM            ModuleDetails CROSS JOIN Locations " + "\r\n";
            queryString = queryString + "                   WHERE           ModuleDetails.ControlTypeID <> 0 OR (ModuleDetails.ControlTypeID = 0 AND Locations.LocationID = 1); " + "\r\n";

            queryString = queryString + "               END " + "\r\n";

            queryString = queryString + "           ELSE " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DECLARE     @msg NVARCHAR(300) = N'Thêm mới trùng tên.' ; " + "\r\n";
            queryString = queryString + "                   THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "               END " + "\r\n";

            queryString = queryString + "       END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("UserGroupAdd", queryString);
        }


        private void UserGroupRemove()
        {
            string queryString = " @UserGroupID int, @Code nvarchar(256)" + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "       BEGIN " + "\r\n";

            queryString = queryString + "           DECLARE     @FoundEntitys TABLE (FoundEntity int NULL) " + "\r\n";
            queryString = queryString + "           INSERT INTO @FoundEntitys EXEC UserGroupEditable @UserGroupID " + "\r\n";

            queryString = queryString + "           IF (SELECT COUNT(*) FROM @FoundEntitys WHERE NOT FoundEntity IS NULL) <= 0 " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DELETE FROM     UserGroupControls WHERE UserGroupID = @UserGroupID " + "\r\n";
            queryString = queryString + "                   DELETE FROM     UserGroups WHERE UserGroupID = @UserGroupID " + "\r\n";
            queryString = queryString + "               END " + "\r\n";

            queryString = queryString + "           ELSE " + "\r\n";
            queryString = queryString + "               BEGIN " + "\r\n";
            queryString = queryString + "                   DECLARE     @msg NVARCHAR(300) = N'Không thể xóa ' + @Code + '.' ; " + "\r\n";
            queryString = queryString + "                   THROW       61001,  @msg, 1; " + "\r\n";
            queryString = queryString + "               END " + "\r\n";

            queryString = queryString + "       END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("UserGroupRemove", queryString);
        }


    }
}

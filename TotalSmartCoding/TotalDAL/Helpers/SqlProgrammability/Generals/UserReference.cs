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
            this.GetUserAccessControls();
            this.SaveUserAccessControls();
        }


        private void GetUserIndexes()
        {
            string queryString;

            queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      UserID, FirstName, LastName, UserName, IsDatabaseAdmin " + "\r\n";
            queryString = queryString + "       FROM        Users " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetUserIndexes", queryString);
        }

        private void GetUserAccessControls()
        {
            string queryString;

            queryString = " @UserID int, @NMVNTaskID int" + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";
           
            queryString = queryString + "       SELECT      AccessControls.AccessControlID, Locations.Name AS LocationName, OrganizationalUnits.Name AS OrganizationalUnitName, AccessControls.OrganizationalUnitID, AccessControls.AccessLevel, AccessControls.ApprovalPermitted, AccessControls.UnApprovalPermitted, AccessControls.VoidablePermitted, AccessControls.UnVoidablePermitted, AccessControls.ShowDiscount " + "\r\n";
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

    }
}

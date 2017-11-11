﻿using System;
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

            this.UserAdd();
            this.UserRemove();

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

            queryString = queryString + "       SELECT      Users.UserID, Users.FirstName, Users.LastName, Users.UserName, Users.SecurityIdentifier, Users.IsDatabaseAdmin, OrganizationalUnits.Name AS OrganizationalUnitName, Locations.Name AS LocationName " + "\r\n";
            queryString = queryString + "       FROM        Users " + "\r\n";
            queryString = queryString + "                   INNER JOIN OrganizationalUnitUsers ON Users.UserID = OrganizationalUnitUsers.UserID AND OrganizationalUnitUsers.InActive = 0 " + "\r\n";
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

            queryString = queryString + "       SELECT      OrganizationalUnits.OrganizationalUnitID, OrganizationalUnits.Name AS OrganizationalUnitName, Locations.Name AS LocationName, Locations.Name + '\\' + OrganizationalUnits.Name AS LocationOrganizationalUnitName " + "\r\n";
            queryString = queryString + "       FROM        Locations INNER JOIN OrganizationalUnits ON Locations.LocationID = OrganizationalUnits.LocationID " + "\r\n";
            queryString = queryString + "       ORDER BY    Locations.Name, OrganizationalUnits.Name " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetOrganizationalUnitIndexes", queryString);
        }

        private void UserAdd()
        {
            string queryString = " @OrganizationalUnitID int, @FirstName nvarchar(60), @LastName nvarchar(60), @UserName nvarchar(256), @SecurityIdentifier nvarchar(256) " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            queryString = queryString + "       BEGIN " + "\r\n";

            queryString = queryString + "           DECLARE         @UserID Int" + "\r\n";
            queryString = queryString + "           INSERT INTO     Users (FirstName, LastName, UserName, SecurityIdentifier, IsDatabaseAdmin) VALUES (@FirstName, @LastName, @UserName, @SecurityIdentifier, 0) " + "\r\n";
            queryString = queryString + "           SELECT          @UserID = SCOPE_IDENTITY() " + "\r\n";
            queryString = queryString + "           INSERT INTO     OrganizationalUnitUsers (OrganizationalUnitID, UserID, InActive) VALUES (@OrganizationalUnitID, @UserID, 0) " + "\r\n";

            queryString = queryString + "           INSERT INTO     AccessControls (UserID, NMVNTaskID, OrganizationalUnitID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount) " + "\r\n";
            queryString = queryString + "           SELECT          @UserID, ModuleDetails.ModuleDetailID, OrganizationalUnits.OrganizationalUnitID, 0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, 0 AS ShowDiscount " + "\r\n";
            queryString = queryString + "           FROM            ModuleDetails CROSS JOIN OrganizationalUnits" + "\r\n";
            queryString = queryString + "           WHERE           ModuleDetails.InActive = 0 " + "\r\n";

            queryString = queryString + "       END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("UserAdd", queryString);
        }

        private void UserRemove()
        {
            string queryString = " @UserID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "       BEGIN " + "\r\n";

            queryString = queryString + "           DELETE FROM     AccessControls WHERE UserID = @UserID " + "\r\n";
            queryString = queryString + "           DELETE FROM     OrganizationalUnitUsers WHERE UserID = @UserID " + "\r\n";
            queryString = queryString + "           DELETE FROM     Users WHERE UserID = @UserID " + "\r\n";

            queryString = queryString + "       END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("UserRemove", queryString);
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

﻿using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Commons
{
    public class Employee
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public Employee(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
            this.GetEmployeeIndexes();

            this.EmployeeEditable();
            this.EmployeeSaveRelative();

            this.GetEmployeeBases();
            this.GetEmployeeTrees();
        }


        private void GetEmployeeIndexes()
        {
            string queryString;

            queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      Employees.EmployeeID, Employees.Code, Employees.Name, Employees.Title, Teams.Code AS TeamCode, Locations.Code AS LocationCode, Employees.Birthday, Employees.Telephone, Employees.Address, Employees.Remarks " + "\r\n";
            queryString = queryString + "       FROM        Employees " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Locations ON Employees.LocationID = Locations.LocationID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN Teams ON Employees.TeamID = Teams.TeamID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetEmployeeIndexes", queryString);
        }


        private void EmployeeSaveRelative()
        {
            string queryString = " @EntityID int, @SaveRelativeOption int " + "\r\n"; //SaveRelativeOption: 1: Update, -1:Undo
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("EmployeeSaveRelative", queryString);
        }


        private void EmployeeEditable()
        {
            string[] queryArray = new string[16];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = SalespersonID FROM Customers WHERE SalespersonID = @EntityID "; 
            queryArray[1] = " SELECT TOP 1 @FoundEntity = ForkliftDriverID FROM DeliveryAdvices WHERE ForkliftDriverID = @EntityID "; 
            queryArray[2] = " SELECT TOP 1 @FoundEntity = SalespersonID FROM DeliveryAdvices WHERE SalespersonID = @EntityID "; 
            queryArray[3] = " SELECT TOP 1 @FoundEntity = StorekeeperID FROM DeliveryAdvices WHERE StorekeeperID = @EntityID "; 
            queryArray[4] = " SELECT TOP 1 @FoundEntity = ForkliftDriverID FROM GoodsIssues WHERE ForkliftDriverID = @EntityID "; 
            queryArray[5] = " SELECT TOP 1 @FoundEntity = StorekeeperID FROM GoodsIssues WHERE StorekeeperID = @EntityID "; 
            queryArray[6] = " SELECT TOP 1 @FoundEntity = ForkliftDriverID FROM GoodsReceipts WHERE ForkliftDriverID = @EntityID "; 
            queryArray[7] = " SELECT TOP 1 @FoundEntity = StorekeeperID FROM GoodsReceipts WHERE StorekeeperID = @EntityID "; 
            queryArray[8] = " SELECT TOP 1 @FoundEntity = ForkliftDriverID FROM Pickups WHERE ForkliftDriverID = @EntityID "; 
            queryArray[9] = " SELECT TOP 1 @FoundEntity = StorekeeperID FROM Pickups WHERE StorekeeperID = @EntityID "; 
            queryArray[10] = " SELECT TOP 1 @FoundEntity = SalespersonID FROM SalesOrders WHERE SalespersonID = @EntityID "; 
            queryArray[11] = " SELECT TOP 1 @FoundEntity = ForkliftDriverID FROM TransferOrders WHERE ForkliftDriverID = @EntityID "; 
            queryArray[12] = " SELECT TOP 1 @FoundEntity = StorekeeperID FROM TransferOrders WHERE StorekeeperID = @EntityID "; 
            queryArray[13] = " SELECT TOP 1 @FoundEntity = StorekeeperID FROM WarehouseAdjustments WHERE StorekeeperID = @EntityID "; 
            queryArray[14] = " SELECT TOP 1 @FoundEntity = SalespersonID FROM DeliveryAdviceDetails WHERE SalespersonID = @EntityID ";
            queryArray[15] = " SELECT TOP 1 @FoundEntity = SalespersonID FROM GoodsIssueDetails WHERE SalespersonID = @EntityID "; 

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("EmployeeEditable", queryArray);
        }


        private void GetEmployeeBases()
        {
            string queryString;

            queryString = " @UserID Int, @NMVNTaskID Int, @RoleID Int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      EmployeeID, Code, Name, TeamID " + "\r\n";
            queryString = queryString + "       FROM        Employees WHERE EmployeeID IN (SELECT EmployeeID FROM EmployeeLocations WHERE LocationID IN (SELECT DISTINCT OrganizationalUnits.LocationID FROM AccessControls INNER JOIN OrganizationalUnits ON AccessControls.OrganizationalUnitID = OrganizationalUnits.OrganizationalUnitID WHERE AccessControls.UserID = @UserID AND AccessControls.NMVNTaskID = @NMVNTaskID AND AccessControls.AccessLevel > 0)) AND EmployeeID IN (SELECT EmployeeID FROM EmployeeRoles WHERE RoleID = @RoleID) " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetEmployeeBases", queryString);
        }

        private void GetEmployeeTrees()
        {
            string queryString;

            queryString = " " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      " + GlobalEnums.RootNode + " AS NodeID, 0 AS ParentNodeID, NULL AS PrimaryID, NULL AS AncestorID, '[All]' AS Code, NULL AS Name, NULL AS ParameterName, CAST(1 AS bit) AS Selected " + "\r\n";
            queryString = queryString + "       UNION ALL " + "\r\n";
            queryString = queryString + "       SELECT      " + GlobalEnums.AncestorNode + " + TeamID AS NodeID, " + GlobalEnums.RootNode + " AS ParentNodeID, TeamID AS PrimaryID, NULL AS AncestorID, Name AS Code, NULL AS Name, 'TeamID' AS ParameterName, CAST(0 AS bit) AS Selected " + "\r\n";
            queryString = queryString + "       FROM        Teams " + "\r\n";
            queryString = queryString + "       UNION ALL " + "\r\n";
            queryString = queryString + "       SELECT      EmployeeID AS NodeID, " + GlobalEnums.AncestorNode + " + TeamID AS ParentNodeID, EmployeeID AS PrimaryID, TeamID AS AncestorID, Name AS Code, Name, 'EmployeeID' AS ParameterName, CAST(0 AS bit) AS Selected " + "\r\n";
            queryString = queryString + "       FROM        Employees " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetEmployeeTrees", queryString);
        }

    }
}

using System;
using System.Text;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

namespace TotalDAL.Helpers.SqlProgrammability.Commons
{
    public class Customer
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public Customer(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        public void RestoreProcedure()
        {
            this.GetCustomerIndexes();

            this.CustomerEditable();
            this.CustomerDeletable();
            this.CustomerSaveRelative();

            this.GetCustomerBases();
            this.GetCustomerTrees();

            this.CheckCustomerReceiverID();
        }


        private void GetCustomerIndexes()
        {
            string queryString;

            queryString = " @UserID Int, @FromDate DateTime, @ToDate DateTime, @IsCustomers bit " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      Customers.CustomerID, Customers.Code AS CustomerCode, Customers.Name AS CustomerName, Customers.OfficialName AS CustomerOfficialName, Customers.ContactInfo, Customers.BillingAddress, EntireTerritories.TerritoryID, EntireTerritories.EntireName AS EntireTerritoryEntireName, Employees.EmployeeID, Employees.Name AS SalespersonName, Parents.Code AS ParentCode, IIF(@IsCustomers = 1, Employees.Name, ISNULL(Parents.Code + ' [' + Parents.Name + ']', N'[NO PARENT]')) AS CustomerGroup, Customers.InActive " + "\r\n";
            queryString = queryString + "       FROM        Customers " + "\r\n";
            queryString = queryString + "                   INNER JOIN EntireTerritories ON (Customers.IsCustomer = @IsCustomers OR Customers.IsReceiver = ~@IsCustomers) AND Customers.TerritoryID = EntireTerritories.TerritoryID " + "\r\n";
            queryString = queryString + "                   INNER JOIN Employees ON Customers.SalespersonID = Employees.EmployeeID " + "\r\n";
            queryString = queryString + "                   LEFT JOIN  Customers AS Parents ON Customers.ParentID = Parents.CustomerID " + "\r\n";
            queryString = queryString + "       WHERE      (SELECT TOP 1 OrganizationalUnitID FROM AccessControls WHERE UserID = @UserID AND NMVNTaskID = " + (int)TotalBase.Enums.GlobalEnums.NmvnTaskID.Customers + " AND AccessControls.AccessLevel > 0) > 0 " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetCustomerIndexes", queryString);
        }


        private void CustomerSaveRelative()
        {
            string queryString = " @EntityID int, @SaveRelativeOption int " + "\r\n"; //SaveRelativeOption: 1: Update, -1:Undo
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("CustomerSaveRelative", queryString);
        }


        private void CustomerEditable()
        {
            string[] queryArray = new string[0];

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("CustomerEditable", queryArray);
        }

        private void CustomerDeletable()
        {
            string[] queryArray = new string[3];

            queryArray[0] = " SELECT TOP 1 @FoundEntity = CustomerID FROM Customers WHERE ParentID = @EntityID ";
            queryArray[1] = " SELECT TOP 1 @FoundEntity = CustomerID FROM SalesReturns WHERE CustomerID = @EntityID ";
            queryArray[2] = " SELECT TOP 1 @FoundEntity = CustomerID FROM DeliveryAdvices WHERE CustomerID = @EntityID ";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("CustomerDeletable", queryArray);
        }

        private void GetCustomerBases()
        {
            string queryString;

            queryString = " @IsCustomer bit, @IsReceiver bit, @ParentID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF ((@IsCustomer = 1 AND @IsReceiver = 1) OR (@IsCustomer = 0 AND @IsReceiver = 0)) " + "\r\n";
            queryString = queryString + "           " + this.GetCustomerBaseSQL(0, false) + "\r\n";
            queryString = queryString + "       ELSE " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";
            queryString = queryString + "               IF (@IsCustomer = 1) " + "\r\n";
            queryString = queryString + "                   " + this.GetCustomerBaseSQL(1, false) + "\r\n";
            queryString = queryString + "               ELSE " + "\r\n";
            queryString = queryString + "                   BEGIN " + "\r\n";
            queryString = queryString + "                       IF (@ParentID IS NULL) " + "\r\n";
            queryString = queryString + "                           " + this.GetCustomerBaseSQL(2, false) + "\r\n";
            queryString = queryString + "                       ELSE " + "\r\n";
            queryString = queryString + "                           " + this.GetCustomerBaseSQL(2, true) + "\r\n";
            queryString = queryString + "                   END " + "\r\n";
            queryString = queryString + "           END " + "\r\n";
            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetCustomerBases", queryString);
        }

        private string GetCustomerBaseSQL(int customerVSReceiver, bool byParentID)
        { //customerVSReceiver: ALL, 1, 2
            string queryString = "";

            queryString = queryString + "       SELECT      CustomerID, Code, Name, ContactInfo, SalespersonID, CASE WHEN ShippingAddress <> '' THEN ShippingAddress ELSE BillingAddress END AS ShippingAddress " + "\r\n";
            queryString = queryString + "       FROM        Customers " + "\r\n";
            if (customerVSReceiver != 0)
                queryString = queryString + "   WHERE       " + (customerVSReceiver == 1 ? "IsCustomer = 1" : ("IsReceiver = 1" + (byParentID ? " AND ParentID = @ParentID" : ""))) + "\r\n";

            return queryString;
        }

        private void GetCustomerTrees()
        {
            string queryString;

            queryString = " " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      " + GlobalEnums.RootNode + " AS NodeID, 0 AS ParentNodeID, NULL AS PrimaryID, NULL AS AncestorID, '[All]' AS Code, NULL AS Name, NULL AS ParameterName, CAST(1 AS bit) AS Selected " + "\r\n";
            queryString = queryString + "       UNION ALL " + "\r\n";
            queryString = queryString + "       SELECT      " + GlobalEnums.AncestorNode + " + CustomerCategoryID AS NodeID, " + GlobalEnums.RootNode + " AS ParentNodeID, CustomerCategoryID AS PrimaryID, NULL AS AncestorID, Name AS Code, NULL AS Name, 'CustomerCategoryID' AS ParameterName, CAST(0 AS bit) AS Selected " + "\r\n";
            queryString = queryString + "       FROM        CustomerCategories " + "\r\n";
            queryString = queryString + "       UNION ALL " + "\r\n";
            queryString = queryString + "       SELECT      CustomerID AS NodeID, " + GlobalEnums.AncestorNode + " + CustomerCategoryID AS ParentNodeID, CustomerID AS PrimaryID, CustomerCategoryID AS AncestorID, Code, Name, 'CustomerID' AS ParameterName, CAST(0 AS bit) AS Selected " + "\r\n";
            queryString = queryString + "       FROM        Customers " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetCustomerTrees", queryString);
        }


        private void CheckCustomerReceiverID()
        {
            string queryString;

            queryString = " @CustomerID int, @ReceiverID int " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";
            queryString = queryString + "       SELECT      MIN(CustomerID) AS CustomerID FROM Customers WHERE CustomerID = @ReceiverID AND ParentID = @CustomerID " + "\r\n";
            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("CheckCustomerReceiverID", queryString);
        }
    }
}

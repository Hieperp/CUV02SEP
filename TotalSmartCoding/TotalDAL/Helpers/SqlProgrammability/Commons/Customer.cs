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

            //this.CustomerEditable(); 
            //this.CustomerSaveRelative();

            this.GetCustomerBases();
        }


        private void GetCustomerIndexes()
        {
            string queryString;

            queryString = " @AspUserID nvarchar(128), @FromDate DateTime, @ToDate DateTime " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      Customers.CustomerID, Customers.Code, Customers.Name " + "\r\n";
            queryString = queryString + "       FROM        Customers " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetCustomerIndexes", queryString);
        }


        private void CustomerSaveRelative()
        {
            string queryString = " @EntityID int, @SaveRelativeOption int " + "\r\n"; //SaveRelativeOption: 1: Update, -1:Undo
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       IF (@SaveRelativeOption = 1) " + "\r\n";
            queryString = queryString + "           BEGIN " + "\r\n";

            queryString = queryString + "               INSERT INTO CustomerWarehouses (CustomerID, WarehouseID, WarehouseTaskID, EntryDate, Remarks, InActive) " + "\r\n";
            queryString = queryString + "               SELECT      CustomerID, 46 AS WarehouseID, " + (int)GlobalEnums.NmvnTaskID.SalesOrder + " AS WarehouseTaskID, GETDATE(), '', 0 FROM Customers WHERE CustomerID = @EntityID " + "\r\n";

            queryString = queryString + "               INSERT INTO CustomerWarehouses (CustomerID, WarehouseID, WarehouseTaskID, EntryDate, Remarks, InActive) " + "\r\n";
            queryString = queryString + "               SELECT      Customers.CustomerID, Warehouses.WarehouseID, " + (int)GlobalEnums.NmvnTaskID.DeliveryAdvice + " AS WarehouseTaskID, GETDATE(), '', 0 FROM Customers INNER JOIN Warehouses ON Customers.CustomerID = @EntityID AND Customers.CustomerCategoryID NOT IN (4, 5, 7, 9, 10, 11, 12) AND Customers.CustomerCategoryID = Warehouses.WarehouseCategoryID " + "\r\n";

            queryString = queryString + "               INSERT INTO CustomerWarehouses (CustomerID, WarehouseID, WarehouseTaskID, EntryDate, Remarks, InActive) " + "\r\n";
            queryString = queryString + "               SELECT      CustomerID, 82 AS WarehouseID, " + (int)GlobalEnums.NmvnTaskID.DeliveryAdvice + " AS WarehouseTaskID, GETDATE(), '', 0 FROM Customers WHERE CustomerID = @EntityID AND CustomerCategoryID IN (4, 5, 7, 9, 10, 11, 12) " + "\r\n";

            queryString = queryString + "           END " + "\r\n";

            queryString = queryString + "       ELSE " + "\r\n"; //(@SaveRelativeOption = -1) 
            queryString = queryString + "           DELETE      CustomerWarehouses WHERE CustomerID = @EntityID " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("CustomerSaveRelative", queryString);
        }


        private void CustomerEditable()
        {
            string[] queryArray = new string[0];

            //queryArray[0] = " SELECT TOP 1 @FoundEntity = CustomerID FROM Customers WHERE CustomerID = @EntityID AND (InActive = 1 OR InActivePartial = 1)"; //Don't allow approve after void
            //queryArray[1] = " SELECT TOP 1 @FoundEntity = CustomerID FROM GoodsIssueDetails WHERE CustomerID = @EntityID ";

            this.totalSmartCodingEntities.CreateProcedureToCheckExisting("CustomerEditable", queryArray);
        }


        private void GetCustomerBases()
        {
            string queryString;

            queryString = " " + "\r\n";
            queryString = queryString + " WITH ENCRYPTION " + "\r\n";
            queryString = queryString + " AS " + "\r\n";
            queryString = queryString + "    BEGIN " + "\r\n";

            queryString = queryString + "       SELECT      CustomerID, Code, Name, ContactInfo, SalespersonID, ShippingAddress " + "\r\n";
            queryString = queryString + "       FROM        Customers " + "\r\n";

            queryString = queryString + "    END " + "\r\n";

            this.totalSmartCodingEntities.CreateStoredProcedure("GetCustomerBases", queryString);
        }

    }
}

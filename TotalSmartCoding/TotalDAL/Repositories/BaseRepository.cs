using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Core.Objects;
using System.Collections.Generic;

using TotalBase;
using TotalBase.Enums;
using TotalDAL.Helpers;
using TotalModel.Models;
using TotalCore.Repositories;


namespace TotalDAL.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        private readonly TotalSmartCodingEntities totalSmartCodingEntities;

        public BaseRepository(TotalSmartCodingEntities totalSmartCodingEntities)
        {
            this.RepositoryBag = new Dictionary<string, object>();
            this.totalSmartCodingEntities = totalSmartCodingEntities;
        }

        private ObjectContext TotalBikePortalsObjectContext
        {
            get { return ((IObjectContextAdapter)this.totalSmartCodingEntities).ObjectContext; }
        }

        public TotalSmartCodingEntities TotalSmartCodingEntities { get { return this.totalSmartCodingEntities; } }


        public bool AutoUpdates(bool restoreProcedures)
        {
            this.UpdateDatabases(restoreProcedures);

            if (restoreProcedures || this.GetStoredID(GlobalVariables.ConfigID) < GlobalVariables.MaxConfigVersionID())
            {
                if (!restoreProcedures)
                {

                }

                this.RestoreProcedures();
            }

            return this.GetStoredID(GlobalVariables.ConfigID) == GlobalVariables.MaxConfigVersionID();
        }

        public void UpdateDatabases(bool restoreProcedures)
        {
            if (restoreProcedures)
            {
                this.totalSmartCodingEntities.ColumnAdd("Configs", "StoredID", "int", "0", true);
            }

            this.totalSmartCodingEntities.ColumnAdd("Batches", "AutoBarcode", "bit", "0", true);
            this.totalSmartCodingEntities.ColumnAdd("Batches", "FinalCartonNo", "nvarchar(10)", "000001", true);




            #region EmployeeLocationIDs & Roles
            this.totalSmartCodingEntities.ColumnAdd("Employees", "InActive", "bit", "0", true);
            if (!this.totalSmartCodingEntities.ColumnExists("Employees", "EmployeeRoleIDs"))
            {
                this.totalSmartCodingEntities.ColumnAdd("Employees", "EmployeeRoleIDs", "nvarchar(100)", "", false);
                this.totalSmartCodingEntities.ColumnAdd("Employees", "EmployeeLocationIDs", "nvarchar(100)", "", false);

                this.totalSmartCodingEntities.ColumnDrop("Employees", "Birthday");
                this.totalSmartCodingEntities.ColumnAdd("Employees", "Birthday", "date", "01/01/1900", true);

                this.ExecuteStoreCommand(@" DECLARE @EmployeeID Int  

                                            DECLARE Action_Cursor CURSOR FOR SELECT EmployeeID FROM Employees OPEN Action_Cursor;
                                            FETCH NEXT FROM Action_Cursor INTO @EmployeeID;

                                            WHILE @@FETCH_STATUS = 0
                                            BEGIN

                                               UPDATE Employees SET EmployeeLocationIDs = STUFF((SELECT ',' + CAST(LocationID AS varchar)  FROM (SELECT DISTINCT LocationID FROM EmployeeLocations WHERE EmployeeID = @EmployeeID) DistinctLocationIDs FOR XML PATH('')) ,1,1,'') WHERE EmployeeID = @EmployeeID

                                               UPDATE Employees SET EmployeeRoleIDs = STUFF((SELECT ',' + CAST(RoleID AS varchar)  FROM (SELECT DISTINCT RoleID FROM EmployeeRoles WHERE EmployeeID = @EmployeeID) DistinctRoleIDs FOR XML PATH('')) ,1,1,'') WHERE EmployeeID = @EmployeeID

                                               FETCH NEXT FROM Action_Cursor  INTO @EmployeeID;
                                            END

                                            CLOSE Action_Cursor;
                                            DEALLOCATE Action_Cursor; ", new ObjectParameter[] { });

            }
            #endregion EmployeeLocationIDs & Roles


            #region REMOVE FirstName, LastName
            //if (this.totalSmartCodingEntities.ColumnExists("Users", "FirstName"))
            //{
            //    this.totalSmartCodingEntities.ColumnDrop("Users", "FirstName");
            //    this.totalSmartCodingEntities.ColumnDrop("Users", "LastName");
            //}
            #endregion REMOVE FirstName, LastName

        }


        private bool RestoreProcedures()
        {
            this.CreateStoredProcedure();

            //SET LASTEST VERSION AFTER RESTORE SUCCESSFULL
            this.ExecuteStoreCommand("UPDATE Configs SET StoredID = " + GlobalVariables.MaxConfigVersionID() + " WHERE StoredID < " + GlobalVariables.MaxConfigVersionID(), new ObjectParameter[] { });

            return true;
        }


        private void CreateStoredProcedure()
        {
            //return;

            Helpers.SqlProgrammability.Productions.Batch batch = new Helpers.SqlProgrammability.Productions.Batch(totalSmartCodingEntities);
            batch.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.Employee employee = new Helpers.SqlProgrammability.Commons.Employee(totalSmartCodingEntities);
            employee.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.Team team = new Helpers.SqlProgrammability.Commons.Team(totalSmartCodingEntities);
            team.RestoreProcedure();

            return;
            return;

            Helpers.SqlProgrammability.Sales.Forecast forecast = new Helpers.SqlProgrammability.Sales.Forecast(totalSmartCodingEntities);
            forecast.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.Commodity commodity = new Helpers.SqlProgrammability.Commons.Commodity(totalSmartCodingEntities);
            commodity.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.CommoditySetting commoditySetting = new Helpers.SqlProgrammability.Commons.CommoditySetting(totalSmartCodingEntities);
            commoditySetting.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Inventories.WarehouseAdjustment warehouseAdjustment = new Helpers.SqlProgrammability.Inventories.WarehouseAdjustment(totalSmartCodingEntities);
            warehouseAdjustment.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.WarehouseAdjustmentType warehouseAdjustmentType = new Helpers.SqlProgrammability.Commons.WarehouseAdjustmentType(totalSmartCodingEntities);
            warehouseAdjustmentType.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Inventories.GoodsIssue goodsIssue = new Helpers.SqlProgrammability.Inventories.GoodsIssue(totalSmartCodingEntities);
            goodsIssue.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Sales.DeliveryAdvice deliveryAdvice = new Helpers.SqlProgrammability.Sales.DeliveryAdvice(totalSmartCodingEntities);
            deliveryAdvice.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Inventories.GoodsReceipt goodsReceipt = new Helpers.SqlProgrammability.Inventories.GoodsReceipt(totalSmartCodingEntities);
            goodsReceipt.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.Warehouse warehouse = new Helpers.SqlProgrammability.Commons.Warehouse(totalSmartCodingEntities);
            warehouse.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.Location location = new Helpers.SqlProgrammability.Commons.Location(totalSmartCodingEntities);
            location.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Inventories.Inventory inventory = new Helpers.SqlProgrammability.Inventories.Inventory(totalSmartCodingEntities);
            inventory.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Generals.OleDb oleDb = new Helpers.SqlProgrammability.Generals.OleDb(totalSmartCodingEntities);
            oleDb.RestoreProcedure();



            

            //return;
            Helpers.SqlProgrammability.Commons.CommodityType commodityType = new Helpers.SqlProgrammability.Commons.CommodityType(totalSmartCodingEntities);
            commodityType.RestoreProcedure();

            

            
            







            //return;

            Helpers.SqlProgrammability.Commons.Customer customer = new Helpers.SqlProgrammability.Commons.Customer(totalSmartCodingEntities);
            customer.RestoreProcedure();



            //return;

            Helpers.SqlProgrammability.Generals.Report report = new Helpers.SqlProgrammability.Generals.Report(totalSmartCodingEntities);
            report.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.CommodityCategory commodityCategory = new Helpers.SqlProgrammability.Commons.CommodityCategory(totalSmartCodingEntities);
            commodityCategory.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.BinLocation binLocation = new Helpers.SqlProgrammability.Commons.BinLocation(totalSmartCodingEntities);
            binLocation.RestoreProcedure();













            //return;

            Helpers.SqlProgrammability.Inventories.Pickup pickup = new Helpers.SqlProgrammability.Inventories.Pickup(totalSmartCodingEntities);
            pickup.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Sales.SalesOrder salesOrder = new Helpers.SqlProgrammability.Sales.SalesOrder(totalSmartCodingEntities);
            salesOrder.RestoreProcedure();




            //return;

            Helpers.SqlProgrammability.Sales.TransferOrder transferOrder = new Helpers.SqlProgrammability.Sales.TransferOrder(totalSmartCodingEntities);
            transferOrder.RestoreProcedure();

            


            //return;

            Helpers.SqlProgrammability.Commons.TransferOrderType transferOrderType = new Helpers.SqlProgrammability.Commons.TransferOrderType(totalSmartCodingEntities);
            transferOrderType.RestoreProcedure();









            //return;

            Helpers.SqlProgrammability.Generals.Module module = new Helpers.SqlProgrammability.Generals.Module(totalSmartCodingEntities);
            module.RestoreProcedure();


            //return;

            Helpers.SqlProgrammability.Commons.CustomerCategory customerCategory = new Helpers.SqlProgrammability.Commons.CustomerCategory(totalSmartCodingEntities);
            customerCategory.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.CustomerType customerType = new Helpers.SqlProgrammability.Commons.CustomerType(totalSmartCodingEntities);
            customerType.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.Territory territory = new Helpers.SqlProgrammability.Commons.Territory(totalSmartCodingEntities);
            territory.RestoreProcedure();


            


            //return;

            Helpers.SqlProgrammability.Generals.OrganizationalUnit organizationalUnit = new Helpers.SqlProgrammability.Generals.OrganizationalUnit(totalSmartCodingEntities);
            organizationalUnit.RestoreProcedure();


            //return;

            Helpers.SqlProgrammability.Generals.UserReference userReference = new Helpers.SqlProgrammability.Generals.UserReference(totalSmartCodingEntities);
            userReference.RestoreProcedure();


            //return;

            Helpers.SqlProgrammability.Commons.AccessControl accessControl = new Helpers.SqlProgrammability.Commons.AccessControl(totalSmartCodingEntities);
            accessControl.RestoreProcedure();


            //return;

            Helpers.SqlProgrammability.Commons.FillingLine fillingLine = new Helpers.SqlProgrammability.Commons.FillingLine(totalSmartCodingEntities);
            fillingLine.RestoreProcedure();


            return;

            Helpers.SqlProgrammability.Productions.Pack pack = new Helpers.SqlProgrammability.Productions.Pack(totalSmartCodingEntities);
            pack.RestoreProcedure();


            return;

            Helpers.SqlProgrammability.Productions.Carton carton = new Helpers.SqlProgrammability.Productions.Carton(totalSmartCodingEntities);
            carton.RestoreProcedure();

            return;

            Helpers.SqlProgrammability.Productions.Pallet pallet = new Helpers.SqlProgrammability.Productions.Pallet(totalSmartCodingEntities);
            pallet.RestoreProcedure();


        }

        private void InitReports()
        {
            string reportTabPageIDs = ((int)GlobalEnums.ReportTabPageID.TabPageWarehouses).ToString() + "," + ((int)GlobalEnums.ReportTabPageID.TabPageCommodities).ToString();

            this.ExecuteStoreCommand("DELETE FROM Reports", new ObjectParameter[] { });

            string optionBoxIDs = GlobalEnums.OBx(GlobalEnums.OptionBoxID.ToDate) + GlobalEnums.OBx(GlobalEnums.OptionBoxID.QuantityVersusVolume);
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.PivotStockDIOH3M + ", " + (int)GlobalEnums.ReportID.PivotStockDIOH3M + ", 8, '1.INVENTORY REPORTS', N'Pivot Stock with DIOH 3M', N'WarehouseForecastPivots', N'" + reportTabPageIDs + "', N'" + optionBoxIDs + "', " + (int)GlobalEnums.ReportTypeID.WarehouseForecast + ", 50, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.PivotStockDRP + ", " + (int)GlobalEnums.ReportID.PivotStockDRP + ", 8, '1.INVENTORY REPORTS', N'Pivot Stock for DRP Planning', N'WarehouseForecastPivots', N'" + reportTabPageIDs + "', N'" + optionBoxIDs + "', " + (int)GlobalEnums.ReportTypeID.WarehouseForecast + ", 60, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.PivotStockDIOH3MAndDRP + ", " + (int)GlobalEnums.ReportID.PivotStockDIOH3MAndDRP + ", 8, '1.INVENTORY REPORTS', N'Pivot Stock for DRP Planning & DIOH 3M', N'WarehouseForecastPivots', N'" + reportTabPageIDs + "', N'" + optionBoxIDs + "', " + (int)GlobalEnums.ReportTypeID.WarehouseForecast + ", 80, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.CurrentWarehouse + ", " + (int)GlobalEnums.ReportID.CurrentWarehouse + ", 8, '1.INVENTORY REPORTS', N'Current Warehouse', N'WarehouseForecasts', N'" + reportTabPageIDs + "', N'" + optionBoxIDs + GlobalEnums.OBx(GlobalEnums.OptionBoxID.ForecastFilters) + "', " + (int)GlobalEnums.ReportTypeID.WarehouseForecast + ", 1, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.SaleAndProduction + ", " + (int)GlobalEnums.ReportID.SaleAndProduction + ", 8, '1.INVENTORY REPORTS', N'Sales and Production', N'InventoryAccumulation', N'" + reportTabPageIDs + "', N'" + optionBoxIDs + "', " + (int)GlobalEnums.ReportTypeID.WarehouseForecast + ", 10, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.OldAndSlowMoving + ", " + (int)GlobalEnums.ReportID.OldAndSlowMoving + ", 8, '1.INVENTORY REPORTS', N'Old & Slow Moving Items', N'WarehouseForecastPivots', N'" + reportTabPageIDs + "', N'" + optionBoxIDs + GlobalEnums.OBx(GlobalEnums.OptionBoxID.SlowMoving) + "', " + (int)GlobalEnums.ReportTypeID.WarehouseForecast + ", 30, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.WarehouseJournal + ", " + (int)GlobalEnums.ReportID.WarehouseJournal + ", 8, '1.INVENTORY REPORTS', N'Summary Warehouse Report', N'WarehouseJournals', N'" + reportTabPageIDs + "', N'" + optionBoxIDs + GlobalEnums.OBx(GlobalEnums.OptionBoxID.FromDate) + GlobalEnums.OBx(GlobalEnums.OptionBoxID.SummaryVersusDetail) + "', " + (int)GlobalEnums.ReportTypeID.WarehouseJournal + ", 20, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });

            optionBoxIDs = GlobalEnums.OBx(GlobalEnums.OptionBoxID.FromDate) + GlobalEnums.OBx(GlobalEnums.OptionBoxID.ToDate) + GlobalEnums.OBx(GlobalEnums.OptionBoxID.SummaryVersusDetail);
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.GoodsReceiptJournal + ", " + (int)GlobalEnums.ReportID.GoodsReceiptJournal + ", 1, '2.GOODS RECEIPT JOURNALS', N'Goods receipt journals', N'WarehouseLedgers', N'" + reportTabPageIDs + "', N'" + optionBoxIDs + "', " + (int)GlobalEnums.ReportTypeID.GoodsReceiptJournal + ", 1, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.ProductionReceiptJournal + ", " + (int)GlobalEnums.ReportID.ProductionReceiptJournal + ", 1, '2.GOODS RECEIPT JOURNALS', N'Goods receipt from production journals', N'WarehouseLedgers', N'" + reportTabPageIDs + "', N'" + optionBoxIDs + "', " + (int)GlobalEnums.ReportTypeID.GoodsReceiptJournal + ", 2, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.TransferReceiptJournal + ", " + (int)GlobalEnums.ReportID.TransferReceiptJournal + ", 1, '2.GOODS RECEIPT JOURNALS', N'Goods receipt from stock transfer journals', N'WarehouseLedgers', N'" + reportTabPageIDs + "," + ((int)GlobalEnums.ReportTabPageID.TabPageWarehouseIssues).ToString() + "', N'" + optionBoxIDs + "', " + (int)GlobalEnums.ReportTypeID.GoodsReceiptJournal + ", 3, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.AdjustmentReceiptJournal + ", " + (int)GlobalEnums.ReportID.AdjustmentReceiptJournal + ", 1, '2.GOODS RECEIPT JOURNALS', N'Other goods receipt journals', N'WarehouseLedgers', N'" + reportTabPageIDs + "," + ((int)GlobalEnums.ReportTabPageID.TabPageWarehouseAdjustmentTypes).ToString() + "', N'" + optionBoxIDs + "', " + (int)GlobalEnums.ReportTypeID.GoodsReceiptJournal + ", 4, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });

            optionBoxIDs = GlobalEnums.OBx(GlobalEnums.OptionBoxID.FromDate) + GlobalEnums.OBx(GlobalEnums.OptionBoxID.ToDate) + GlobalEnums.OBx(GlobalEnums.OptionBoxID.QuantityVersusVolume) + GlobalEnums.OBx(GlobalEnums.OptionBoxID.DateVersusMonth);
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.GoodsReceiptPivot + ", " + (int)GlobalEnums.ReportID.GoodsReceiptPivot + ", 1, '3.GOODS RECEIPT PIVOT REPORTS', N'Goods receipt pivot report', N'WarehouseLedgerPivots', N'" + reportTabPageIDs + "', N'" + optionBoxIDs + "', " + (int)GlobalEnums.ReportTypeID.GoodsReceiptPivot + ", 1, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.ProductionReceiptPivot + ", " + (int)GlobalEnums.ReportID.ProductionReceiptPivot + ", 1, '3.GOODS RECEIPT PIVOT REPORTS', N'Goods receipt from production pivot report', N'WarehouseLedgerPivots', N'" + reportTabPageIDs + "', N'" + optionBoxIDs + "', " + (int)GlobalEnums.ReportTypeID.GoodsReceiptPivot + ", 2, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.TransferReceiptPivot + ", " + (int)GlobalEnums.ReportID.TransferReceiptPivot + ", 1, '3.GOODS RECEIPT PIVOT REPORTS', N'Goods receipt from stock transfer pivot report', N'WarehouseLedgerPivots', N'" + reportTabPageIDs + "," + ((int)GlobalEnums.ReportTabPageID.TabPageWarehouseIssues).ToString() + "', N'" + optionBoxIDs + "', " + (int)GlobalEnums.ReportTypeID.GoodsReceiptPivot + ", 3, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.AdjustmentReceiptPivot + ", " + (int)GlobalEnums.ReportID.AdjustmentReceiptPivot + ", 1, '3.GOODS RECEIPT PIVOT REPORTS', N'Other goods receipt pivot report', N'WarehouseLedgerPivots', N'" + reportTabPageIDs + "," + ((int)GlobalEnums.ReportTabPageID.TabPageWarehouseAdjustmentTypes).ToString() + "', N'" + optionBoxIDs + "', " + (int)GlobalEnums.ReportTypeID.GoodsReceiptPivot + ", 4, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });

            optionBoxIDs = GlobalEnums.OBx(GlobalEnums.OptionBoxID.FromDate) + GlobalEnums.OBx(GlobalEnums.OptionBoxID.ToDate) + GlobalEnums.OBx(GlobalEnums.OptionBoxID.SummaryVersusDetail);
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.GoodsIssueJournal + ", " + (int)GlobalEnums.ReportID.GoodsIssueJournal + ", 10, '4.GOODS ISSUE JOURNALS', N'Goods issue journals', N'WarehouseLedgers', N'" + reportTabPageIDs + "', N'" + optionBoxIDs + "', " + (int)GlobalEnums.ReportTypeID.GoodsIssueJournal + ", 11, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.SalesIssueJournal + ", " + (int)GlobalEnums.ReportID.SalesIssueJournal + ", 10, '4.GOODS ISSUE JOURNALS', N'Goods issue for sales journals', N'WarehouseLedgers', N'" + reportTabPageIDs + "," + ((int)GlobalEnums.ReportTabPageID.TabPageCustomers).ToString() + "', N'" + optionBoxIDs + GlobalEnums.OBx(GlobalEnums.OptionBoxID.SalesVersusPromotion) + "', " + (int)GlobalEnums.ReportTypeID.GoodsIssueJournal + ", 12, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.TransferIssueJournal + ", " + (int)GlobalEnums.ReportID.TransferIssueJournal + ", 10, '4.GOODS ISSUE JOURNALS', N'Goods issue for stock transfer journals', N'WarehouseLedgers', N'" + reportTabPageIDs + "," + ((int)GlobalEnums.ReportTabPageID.TabPageWarehouseReceipts).ToString() + "', N'" + optionBoxIDs + "', " + (int)GlobalEnums.ReportTypeID.GoodsIssueJournal + ", 13, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.AdjustmentIssueJournal + ", " + (int)GlobalEnums.ReportID.AdjustmentIssueJournal + ", 10, '4.GOODS ISSUE JOURNALS', N'Other goods issue journals', N'WarehouseLedgers', N'" + reportTabPageIDs + "," + ((int)GlobalEnums.ReportTabPageID.TabPageWarehouseAdjustmentTypes).ToString() + "', N'" + optionBoxIDs + "', " + (int)GlobalEnums.ReportTypeID.GoodsIssueJournal + ", 14, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });

            optionBoxIDs = GlobalEnums.OBx(GlobalEnums.OptionBoxID.FromDate) + GlobalEnums.OBx(GlobalEnums.OptionBoxID.ToDate) + GlobalEnums.OBx(GlobalEnums.OptionBoxID.QuantityVersusVolume);
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.GoodsIssuePivot + ", " + (int)GlobalEnums.ReportID.GoodsIssuePivot + ", 10, '5.GOODS ISSUE PIVOT REPORTS', N'Goods issue pivot report', N'WarehouseLedgerPivots', N'" + reportTabPageIDs + "', N'" + optionBoxIDs + GlobalEnums.OBx(GlobalEnums.OptionBoxID.DateVersusMonth) + "', " + (int)GlobalEnums.ReportTypeID.GoodsIssuePivot + ", 11, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.SalesIssuePivot + ", " + (int)GlobalEnums.ReportID.SalesIssuePivot + ", 10, '5.GOODS ISSUE PIVOT REPORTS', N'Goods issue for sales pivot report', N'WarehouseLedgerPivots', N'" + reportTabPageIDs + "," + ((int)GlobalEnums.ReportTabPageID.TabPageCustomers).ToString() + "', N'" + optionBoxIDs + GlobalEnums.OBx(GlobalEnums.OptionBoxID.DateVersusMonth) + GlobalEnums.OBx(GlobalEnums.OptionBoxID.SalesVersusPromotion) + "', " + (int)GlobalEnums.ReportTypeID.GoodsIssuePivot + ", 12, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.SalesIssuePivotbyCustomers + ", " + (int)GlobalEnums.ReportID.SalesIssuePivotbyCustomers + ", 10, '5.GOODS ISSUE PIVOT REPORTS', N'Goods issue for sales pivot by customers', N'WarehouseLedgerPivotCustomers', N'" + reportTabPageIDs + "," + ((int)GlobalEnums.ReportTabPageID.TabPageCustomers).ToString() + "', N'" + optionBoxIDs + GlobalEnums.OBx(GlobalEnums.OptionBoxID.SalesVersusPromotion) + "', " + (int)GlobalEnums.ReportTypeID.GoodsIssuePivot + ", 12, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.TransferIssuePivot + ", " + (int)GlobalEnums.ReportID.TransferIssuePivot + ", 10, '5.GOODS ISSUE PIVOT REPORTS', N'Goods issue for stock transfer pivot report', N'WarehouseLedgerPivots', N'" + reportTabPageIDs + "," + ((int)GlobalEnums.ReportTabPageID.TabPageWarehouseReceipts).ToString() + "', N'" + optionBoxIDs + GlobalEnums.OBx(GlobalEnums.OptionBoxID.DateVersusMonth) + "', " + (int)GlobalEnums.ReportTypeID.GoodsIssuePivot + ", 13, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.AdjustmentIssuePivot + ", " + (int)GlobalEnums.ReportID.AdjustmentIssuePivot + ", 10, '5.GOODS ISSUE PIVOT REPORTS', N'Other goods issue pivot report', N'WarehouseLedgerPivots', N'" + reportTabPageIDs + "," + ((int)GlobalEnums.ReportTabPageID.TabPageWarehouseAdjustmentTypes).ToString() + "', N'" + optionBoxIDs + GlobalEnums.OBx(GlobalEnums.OptionBoxID.DateVersusMonth) + "', " + (int)GlobalEnums.ReportTypeID.GoodsIssuePivot + ", 14, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
        }


        #region Backup for update log


        private void InitCommoditySettings()
        {

            #region CommoditySettings
            this.ExecuteStoreCommand(@" SET IDENTITY_INSERT CommoditySettings ON                                                              
                                        
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (3, Getdate(), N'Z00003', 3, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (4, Getdate(), N'Z00004', 4, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (5, Getdate(), N'Z00005', 5, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (14, Getdate(), N'Z00014', 14, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (15, Getdate(), N'Z00015', 15, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (17, Getdate(), N'Z00017', 17, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (19, Getdate(), N'Z00019', 19, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (23, Getdate(), N'Z00023', 23, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (24, Getdate(), N'Z00024', 24, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (26, Getdate(), N'Z00026', 26, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (31, Getdate(), N'Z00031', 31, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (32, Getdate(), N'Z00032', 32, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (37, Getdate(), N'Z00037', 37, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (49, Getdate(), N'Z00049', 49, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (51, Getdate(), N'Z00051', 51, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (52, Getdate(), N'Z00052', 52, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (56, Getdate(), N'Z00056', 56, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (58, Getdate(), N'Z00058', 58, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (63, Getdate(), N'Z00063', 63, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (65, Getdate(), N'Z00065', 65, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (66, Getdate(), N'Z00066', 66, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (68, Getdate(), N'Z00068', 68, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (69, Getdate(), N'Z00069', 69, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (70, Getdate(), N'Z00070', 70, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (71, Getdate(), N'Z00071', 71, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (73, Getdate(), N'Z00073', 73, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (74, Getdate(), N'Z00074', 74, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (76, Getdate(), N'Z00076', 76, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (77, Getdate(), N'Z00077', 77, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (79, Getdate(), N'Z00079', 79, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (80, Getdate(), N'Z00080', 80, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (82, Getdate(), N'Z00082', 82, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (83, Getdate(), N'Z00083', 83, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (84, Getdate(), N'Z00084', 84, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (86, Getdate(), N'Z00086', 86, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (87, Getdate(), N'Z00087', 87, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (88, Getdate(), N'Z00088', 88, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (89, Getdate(), N'Z00089', 89, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (90, Getdate(), N'Z00090', 90, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (91, Getdate(), N'Z00091', 91, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (93, Getdate(), N'Z00093', 93, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (94, Getdate(), N'Z00094', 94, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (99, Getdate(), N'Z00099', 99, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (101, Getdate(), N'Z00101', 101, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (103, Getdate(), N'Z00103', 103, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (105, Getdate(), N'Z00105', 105, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (106, Getdate(), N'Z00106', 106, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (107, Getdate(), N'Z00107', 107, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (108, Getdate(), N'Z00108', 108, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (109, Getdate(), N'Z00109', 109, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (113, Getdate(), N'Z00113', 113, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (119, Getdate(), N'Z00119', 119, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (127, Getdate(), N'Z00127', 127, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (131, Getdate(), N'Z00131', 131, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (132, Getdate(), N'Z00132', 132, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (133, Getdate(), N'Z00133', 133, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (134, Getdate(), N'Z00134', 134, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (135, Getdate(), N'Z00135', 135, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (137, Getdate(), N'Z00137', 137, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (138, Getdate(), N'Z00138', 138, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (139, Getdate(), N'Z00139', 139, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (142, Getdate(), N'Z00142', 142, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (143, Getdate(), N'Z00143', 143, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (144, Getdate(), N'Z00144', 144, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (145, Getdate(), N'Z00145', 145, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (149, Getdate(), N'Z00149', 149, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (151, Getdate(), N'Z00151', 151, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (152, Getdate(), N'Z00152', 152, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (153, Getdate(), N'Z00153', 153, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (155, Getdate(), N'Z00155', 155, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (157, Getdate(), N'Z00157', 157, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (162, Getdate(), N'Z00162', 162, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (163, Getdate(), N'Z00163', 163, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (164, Getdate(), N'Z00164', 164, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (166, Getdate(), N'Z00166', 166, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (167, Getdate(), N'Z00167', 167, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (170, Getdate(), N'Z00170', 170, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (172, Getdate(), N'Z00172', 172, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (173, Getdate(), N'Z00173', 173, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (174, Getdate(), N'Z00174', 174, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (175, Getdate(), N'Z00175', 175, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (178, Getdate(), N'Z00178', 178, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (180, Getdate(), N'Z00180', 180, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (182, Getdate(), N'Z00182', 182, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (183, Getdate(), N'Z00183', 183, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (184, Getdate(), N'Z00184', 184, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (185, Getdate(), N'Z00185', 185, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (188, Getdate(), N'Z00188', 188, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (189, Getdate(), N'Z00189', 189, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (193, Getdate(), N'Z00193', 193, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (195, Getdate(), N'Z00195', 195, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (196, Getdate(), N'Z00196', 196, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (198, Getdate(), N'Z00198', 198, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (199, Getdate(), N'Z00199', 199, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (200, Getdate(), N'Z00200', 200, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (201, Getdate(), N'Z00201', 201, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (202, Getdate(), N'Z00202', 202, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (205, Getdate(), N'Z00205', 205, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (206, Getdate(), N'Z00206', 206, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (207, Getdate(), N'Z00207', 207, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (209, Getdate(), N'Z00209', 209, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (210, Getdate(), N'Z00210', 210, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (212, Getdate(), N'Z00212', 212, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (219, Getdate(), N'Z00219', 219, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (220, Getdate(), N'Z00220', 220, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (224, Getdate(), N'Z00224', 224, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (225, Getdate(), N'Z00225', 225, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (226, Getdate(), N'Z00226', 226, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (229, Getdate(), N'Z00229', 229, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (233, Getdate(), N'Z00233', 233, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (235, Getdate(), N'Z00235', 235, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (236, Getdate(), N'Z00236', 236, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (238, Getdate(), N'Z00238', 238, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (239, Getdate(), N'Z00239', 239, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (241, Getdate(), N'Z00241', 241, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (242, Getdate(), N'Z00242', 242, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (244, Getdate(), N'Z00244', 244, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (245, Getdate(), N'Z00245', 245, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (246, Getdate(), N'Z00246', 246, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (247, Getdate(), N'Z00247', 247, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (248, Getdate(), N'Z00248', 248, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (249, Getdate(), N'Z00249', 249, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (250, Getdate(), N'Z00250', 250, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (251, Getdate(), N'Z00251', 251, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (252, Getdate(), N'Z00252', 252, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (253, Getdate(), N'Z00253', 253, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (256, Getdate(), N'Z00256', 256, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (260, Getdate(), N'Z00260', 260, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (262, Getdate(), N'Z00262', 262, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (266, Getdate(), N'Z00266', 266, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (267, Getdate(), N'Z00267', 267, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (268, Getdate(), N'Z00268', 268, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (269, Getdate(), N'Z00269', 269, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (273, Getdate(), N'Z00273', 273, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (275, Getdate(), N'Z00275', 275, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (276, Getdate(), N'Z00276', 276, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (277, Getdate(), N'Z00277', 277, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (278, Getdate(), N'Z00278', 278, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (281, Getdate(), N'Z00281', 281, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (282, Getdate(), N'Z00282', 282, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (283, Getdate(), N'Z00283', 283, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (285, Getdate(), N'Z00285', 285, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (287, Getdate(), N'Z00287', 287, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (288, Getdate(), N'Z00288', 288, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (289, Getdate(), N'Z00289', 289, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (290, Getdate(), N'Z00290', 290, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (291, Getdate(), N'Z00291', 291, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (292, Getdate(), N'Z00292', 292, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (293, Getdate(), N'Z00293', 293, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (296, Getdate(), N'Z00296', 296, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (297, Getdate(), N'Z00297', 297, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (298, Getdate(), N'Z00298', 298, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (299, Getdate(), N'Z00299', 299, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (300, Getdate(), N'Z00300', 300, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (301, Getdate(), N'Z00301', 301, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (302, Getdate(), N'Z00302', 302, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (303, Getdate(), N'Z00303', 303, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (307, Getdate(), N'Z00307', 307, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (309, Getdate(), N'Z00309', 309, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (310, Getdate(), N'Z00310', 310, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (311, Getdate(), N'Z00311', 311, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (312, Getdate(), N'Z00312', 312, 1, Getdate(), Getdate(), 0, Getdate())
                                            INSERT INTO CommoditySettings (CommoditySettingID, EntryDate, Reference, CommodityID, LocationID, CreatedDate, EditedDate, Approved, ApprovedDate)   VALUES (316, Getdate(), N'Z00316', 316, 1, Getdate(), Getdate(), 0, Getdate())


                                        SET IDENTITY_INSERT CommoditySettings OFF ", new ObjectParameter[] { });
            #endregion CommoditySettings


            #region CommoditySettingDetails
            this.ExecuteStoreCommand(@" SET IDENTITY_INSERT CommoditySettings ON                                                              
                                     
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (275, 275, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (99, 99, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (108, 108, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (87, 87, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (90, 90, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (93, 93, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (101, 101, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (91, 91, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (276, 276, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (103, 103, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (88, 88, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (107, 107, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (273, 273, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (277, 277, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (83, 83, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (113, 113, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (94, 94, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (84, 84, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (109, 109, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (80, 80, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (79, 79, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (106, 106, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (278, 278, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (89, 89, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (105, 105, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (82, 82, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (86, 86, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (135, 135, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (137, 137, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (139, 139, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (145, 145, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (157, 157, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (133, 133, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (138, 138, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (143, 143, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (134, 134, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (142, 142, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (149, 149, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (144, 144, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (164, 164, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (167, 167, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (151, 151, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (180, 180, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (166, 166, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (163, 163, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (175, 175, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (131, 131, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (132, 132, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (170, 170, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (178, 178, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (173, 173, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (174, 174, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (172, 172, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (196, 196, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (195, 195, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (247, 247, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (245, 245, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (189, 189, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (4, 4, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (292, 292, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (5, 5, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (266, 266, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (262, 262, 1, 1, 8, 12, 12)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (242, 242, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (193, 193, 1, 1, 8, 10, 10)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (205, 205, 1, 1, 8, 29, 15)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (15, 15, 1, 1, 8, 8, 10)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (207, 207, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (209, 209, 1, 1, 8, 29, 15)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (291, 291, 1, 1, 8, 8, 10)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (3, 3, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (17, 17, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (246, 246, 1, 1, 8, 29, 15)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (206, 206, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (26, 26, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (212, 212, 1, 1, 88, 88, 90)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (260, 260, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (244, 244, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (241, 241, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (253, 253, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (267, 267, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (23, 23, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (268, 268, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (285, 285, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (312, 312, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (283, 283, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (52, 52, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (51, 51, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (282, 282, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (281, 281, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (155, 155, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (77, 77, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (74, 74, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (65, 65, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (70, 70, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (69, 69, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (66, 66, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (71, 71, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (68, 68, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (76, 76, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (73, 73, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (301, 301, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (300, 300, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (302, 302, 1, 1, 8, 10, 10)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (235, 235, 1, 1, 8, 8, 10)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (233, 233, 1, 1, 8, 8, 10)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (127, 127, 1, 1, 4, 8, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (311, 311, 1, 1, 8, 8, 10)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (297, 297, 1, 1, 2, 4, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (298, 298, 1, 1, 8, 10, 10)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (303, 303, 1, 1, 8, 12, 12)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (299, 299, 1, 1, 15, 36, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (307, 307, 1, 1, 8, 8, 10)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (309, 309, 1, 1, 8, 8, 10)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (310, 310, 1, 1, 8, 8, 10)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (238, 238, 1, 1, 8, 8, 10)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (239, 239, 1, 1, 8, 8, 10)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (236, 236, 1, 1, 8, 8, 10)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (56, 56, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (58, 58, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (183, 183, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (152, 152, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (37, 37, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (185, 185, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (182, 182, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (153, 153, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (184, 184, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (162, 162, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (269, 269, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (251, 251, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (252, 252, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (32, 32, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (49, 49, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (250, 250, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (256, 256, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (249, 249, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (248, 248, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (31, 31, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (200, 200, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (226, 226, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (198, 198, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (225, 225, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (219, 219, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (119, 119, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (224, 224, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (202, 202, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (220, 220, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (199, 199, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (201, 201, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (293, 293, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (288, 288, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (290, 290, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (63, 63, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (188, 188, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (14, 14, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (289, 289, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (229, 229, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (316, 316, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (296, 296, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (287, 287, 1, 1, 7, 14, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (275, 275, 1, 2, 2, 4, 3)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (99, 99, 1, 2, 3, 5, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (108, 108, 1, 2, 3, 5, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (87, 87, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (90, 90, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (93, 93, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (101, 101, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (91, 91, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (276, 276, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (103, 103, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (88, 88, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (107, 107, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (273, 273, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (277, 277, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (83, 83, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (113, 113, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (94, 94, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (84, 84, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (109, 109, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (80, 80, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (79, 79, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (106, 106, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (278, 278, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (89, 89, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (105, 105, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (82, 82, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (86, 86, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (135, 135, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (137, 137, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (139, 139, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (145, 145, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (157, 157, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (133, 133, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (138, 138, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (143, 143, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (134, 134, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (142, 142, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (149, 149, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (144, 144, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (164, 164, 1, 2, 2, 4, 3)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (167, 167, 1, 2, 2, 4, 3)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (151, 151, 1, 2, 2, 4, 3)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (180, 180, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (166, 166, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (163, 163, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (175, 175, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (131, 131, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (132, 132, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (170, 170, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (178, 178, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (173, 173, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (174, 174, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (172, 172, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (196, 196, 1, 2, 2, 4, 3)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (195, 195, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (247, 247, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (245, 245, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (189, 189, 1, 2, 5, 9, 8)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (4, 4, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (292, 292, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (5, 5, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (266, 266, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (262, 262, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (242, 242, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (193, 193, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (205, 205, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (207, 207, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (209, 209, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (3, 3, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (17, 17, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (246, 246, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (206, 206, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (26, 26, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (260, 260, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (244, 244, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (241, 241, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (253, 253, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (267, 267, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (23, 23, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (268, 268, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (285, 285, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (312, 312, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (283, 283, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (52, 52, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (51, 51, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (282, 282, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (281, 281, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (155, 155, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (77, 77, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (74, 74, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (65, 65, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (70, 70, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (69, 69, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (66, 66, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (71, 71, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (68, 68, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (76, 76, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (73, 73, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (301, 301, 1, 2, 2, 4, 3)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (300, 300, 1, 2, 3, 5, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (302, 302, 1, 2, 3, 5, 4)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (127, 127, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (297, 297, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (298, 298, 1, 2, 5, 7, 6)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (303, 303, 1, 2, 10, 14, 13)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (299, 299, 1, 2, 13, 21, 20)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (56, 56, 1, 2, 20, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (58, 58, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (183, 183, 1, 2, 20, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (152, 152, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (37, 37, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (185, 185, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (182, 182, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (153, 153, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (184, 184, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (162, 162, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (269, 269, 1, 2, 20, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (251, 251, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (252, 252, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (32, 32, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (49, 49, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (250, 250, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (256, 256, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (249, 249, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (248, 248, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (31, 31, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (200, 200, 1, 2, 20, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (226, 226, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (198, 198, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (225, 225, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (219, 219, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (119, 119, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (224, 224, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (202, 202, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (220, 220, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (199, 199, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (201, 201, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (293, 293, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (288, 288, 1, 2, 20, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (290, 290, 1, 2, 20, 24, 23)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (63, 63, 1, 2, 20, 24, 23)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (188, 188, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (14, 14, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (289, 289, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (229, 229, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (316, 316, 1, 2, 20, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (296, 296, 1, 2, 15, 23, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (287, 287, 1, 2, 30, 38, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (275, 275, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (99, 99, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (108, 108, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (87, 87, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (90, 90, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (93, 93, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (101, 101, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (91, 91, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (276, 276, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (103, 103, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (88, 88, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (107, 107, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (277, 277, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (94, 94, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (109, 109, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (278, 278, 1, 4, 15, 33, 30)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (89, 89, 1, 4, 23, 41, 38)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (82, 82, 1, 4, 23, 41, 38)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (135, 135, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (137, 137, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (139, 139, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (145, 145, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (157, 157, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (164, 164, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (167, 167, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (151, 151, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (180, 180, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (166, 166, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (163, 163, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (175, 175, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (131, 131, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (132, 132, 1, 4, 15, 33, 30)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (178, 178, 1, 4, 15, 33, 30)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (173, 173, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (172, 172, 1, 4, 23, 41, 38)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (196, 196, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (195, 195, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (245, 245, 1, 4, 15, 33, 30)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (3, 3, 1, 4, 23, 41, 38)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (52, 52, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (155, 155, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (77, 77, 1, 4, 15, 33, 30)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (74, 74, 1, 4, 15, 33, 30)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (65, 65, 1, 4, 15, 33, 30)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (69, 69, 1, 4, 15, 33, 30)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (66, 66, 1, 4, 15, 33, 30)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (71, 71, 1, 4, 15, 33, 30)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (68, 68, 1, 4, 12, 30, 27)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (76, 76, 1, 4, 23, 41, 38)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (73, 73, 1, 4, 23, 41, 38)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (58, 58, 1, 4, 20, 38, 35)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (183, 183, 1, 4, 20, 38, 35)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (152, 152, 1, 4, 20, 38, 35)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (185, 185, 1, 4, 20, 38, 35)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (182, 182, 1, 4, 20, 38, 35)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (200, 200, 1, 4, 20, 38, 35)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (226, 226, 1, 4, 20, 38, 35)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (198, 198, 1, 4, 20, 38, 35)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (225, 225, 1, 4, 20, 38, 35)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (288, 288, 1, 4, 20, 38, 35)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (290, 290, 1, 4, 20, 38, 35)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (63, 63, 1, 4, 20, 38, 35)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (188, 188, 1, 4, 20, 38, 35)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (287, 287, 1, 4, 20, 38, 35)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (275, 275, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (99, 99, 1, 3, 7, 16, 11)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (108, 108, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (87, 87, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (90, 90, 1, 3, 8, 17, 12)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (93, 93, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (101, 101, 1, 3, 7, 16, 11)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (91, 91, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (276, 276, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (103, 103, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (88, 88, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (107, 107, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (273, 273, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (277, 277, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (83, 83, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (113, 113, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (94, 94, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (84, 84, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (109, 109, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (80, 80, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (79, 79, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (106, 106, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (278, 278, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (89, 89, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (105, 105, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (82, 82, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (86, 86, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (135, 135, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (137, 137, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (139, 139, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (145, 145, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (157, 157, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (133, 133, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (138, 138, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (143, 143, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (134, 134, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (142, 142, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (149, 149, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (144, 144, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (164, 164, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (167, 167, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (151, 151, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (180, 180, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (166, 166, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (163, 163, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (175, 175, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (131, 131, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (132, 132, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (170, 170, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (178, 178, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (173, 173, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (174, 174, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (172, 172, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (196, 196, 1, 3, 8, 17, 12)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (195, 195, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (247, 247, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (245, 245, 1, 3, 12, 21, 16)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (189, 189, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (4, 4, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (292, 292, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (5, 5, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (266, 266, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (262, 262, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (242, 242, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (193, 193, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (205, 205, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (207, 207, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (209, 209, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (3, 3, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (17, 17, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (246, 246, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (206, 206, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (26, 26, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (260, 260, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (244, 244, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (241, 241, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (253, 253, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (267, 267, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (23, 23, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (268, 268, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (210, 210, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (24, 24, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (19, 19, 1, 3, 15, 15, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (285, 285, 1, 3, 16, 25, 20)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (312, 312, 1, 3, 12, 21, 16)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (283, 283, 1, 3, 16, 25, 20)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (52, 52, 1, 3, 16, 25, 20)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (51, 51, 1, 3, 16, 25, 20)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (282, 282, 1, 3, 16, 25, 20)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (281, 281, 1, 3, 16, 25, 20)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (155, 155, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (77, 77, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (74, 74, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (65, 65, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (70, 70, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (69, 69, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (66, 66, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (71, 71, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (68, 68, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (76, 76, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (73, 73, 1, 3, 30, 39, 34)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (301, 301, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (300, 300, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (302, 302, 1, 3, 10, 19, 14)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (127, 127, 1, 3, 15, 24, 19)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (297, 297, 1, 3, 21, 30, 25)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (298, 298, 1, 3, 21, 30, 25)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (303, 303, 1, 3, 21, 30, 25)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (299, 299, 1, 3, 21, 30, 25)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (56, 56, 1, 3, 15, 27, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (58, 58, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (183, 183, 1, 3, 15, 27, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (152, 152, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (37, 37, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (185, 185, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (182, 182, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (153, 153, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (184, 184, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (162, 162, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (269, 269, 1, 3, 15, 27, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (251, 251, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (252, 252, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (32, 32, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (49, 49, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (250, 250, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (256, 256, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (249, 249, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (248, 248, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (31, 31, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (200, 200, 1, 3, 15, 27, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (226, 226, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (198, 198, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (225, 225, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (219, 219, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (119, 119, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (224, 224, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (202, 202, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (220, 220, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (199, 199, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (201, 201, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (293, 293, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (288, 288, 1, 3, 15, 27, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (290, 290, 1, 3, 15, 27, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (63, 63, 1, 3, 15, 27, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (188, 188, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (14, 14, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (289, 289, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (229, 229, 1, 3, 30, 42, 37)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (316, 316, 1, 3, 15, 27, 22)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (296, 296, 1, 3, 21, 33, 28)
                                        INSERT INTO CommoditySettingDetails (CommoditySettingID, CommodityID, LocationID, SettingLocationID, LowDSI, HighDSI, AlertDSI)   VALUES (287, 287, 1, 3, 30, 42, 37)
   

                                        SET IDENTITY_INSERT CommoditySettings OFF ", new ObjectParameter[] { });
            #endregion CommoditySettingDetails
        }


        private void UpdateBackup()
        {

            #region Forecasts
            if (this.totalSmartCodingEntities.ColumnExists("Forecasts", "SalespersonID"))
            {
                this.totalSmartCodingEntities.ColumnDrop("Forecasts", "SalespersonID");

                this.ExecuteStoreCommand("ALTER TABLE Forecasts WITH CHECK ADD CONSTRAINT FK_Forecasts_Locations FOREIGN KEY(LocationID) REFERENCES dbo.Locations (LocationID)", new ObjectParameter[] { });
                this.ExecuteStoreCommand("ALTER TABLE Forecasts CHECK CONSTRAINT FK_Forecasts_Locations", new ObjectParameter[] { });

                this.ExecuteStoreCommand("ALTER TABLE Forecasts WITH CHECK ADD CONSTRAINT FK_Forecasts_ForecastLocations FOREIGN KEY(ForecastLocationID) REFERENCES dbo.Locations (LocationID)", new ObjectParameter[] { });
                this.ExecuteStoreCommand("ALTER TABLE Forecasts CHECK CONSTRAINT FK_Forecasts_ForecastLocations", new ObjectParameter[] { });
            }
            #endregion Forecasts

            #region Report

            if (!this.totalSmartCodingEntities.ColumnExists("Reports", "OptionBoxIDs"))
            {
                this.totalSmartCodingEntities.ColumnAdd("Reports", "OptionBoxIDs", "nvarchar(100)", "", false);

                this.ExecuteStoreCommand("UPDATE  GoodsIssueTypes SET Code = IIF(GoodsIssueTypeID  = 1, N'Sales', N'Transfer')", new ObjectParameter[] { });
                this.ExecuteStoreCommand("UPDATE  GoodsIssueTypes SET Name = Code", new ObjectParameter[] { });
                this.ExecuteStoreCommand("UPDATE  GoodsReceiptTypes SET Name = Code", new ObjectParameter[] { });
                this.ExecuteStoreCommand("UPDATE  WarehouseAdjustmentTypes SET Code = IIF(WarehouseAdjustmentTypeID = 1, N'Unpack pallet', IIF(WarehouseAdjustmentTypeID = 10, N'Change bin', IIF(WarehouseAdjustmentTypeID = 20, N'Hold/ un-hold', IIF(WarehouseAdjustmentTypeID = 30, N'To production', N'Lost, broken, ...' ))))", new ObjectParameter[] { });
                this.ExecuteStoreCommand("UPDATE  WarehouseAdjustmentTypes SET Name = Code", new ObjectParameter[] { });

                this.InitReports();

                this.ExecuteStoreCommand("UPDATE Modules SET Code = N'Warehouse Management', Name = N'2.Warehouse Management' WHERE ModuleID = 6 ", new ObjectParameter[] { });

                this.ExecuteStoreCommand("UPDATE ModuleDetails SET Controller = N'WAREHOUSE RESOURCES' WHERE ModuleDetailID IN (" + (int)GlobalEnums.NmvnTaskID.Commodity + "," + (int)GlobalEnums.NmvnTaskID.BinLocation + "," + (int)GlobalEnums.NmvnTaskID.Warehouse + ") ", new ObjectParameter[] { });
                this.ExecuteStoreCommand("UPDATE ModuleDetails SET Controller = N'CUSTOMER MANAGEMENT' WHERE ModuleDetailID IN (" + (int)GlobalEnums.NmvnTaskID.Employee + "," + (int)GlobalEnums.NmvnTaskID.Customer + "," + (int)GlobalEnums.NmvnTaskID.Territory + ") ", new ObjectParameter[] { });

                this.ExecuteStoreCommand("UPDATE ModuleDetails SET Controller = N'LOGISTICS ADMIN', ModuleID = 6 WHERE ModuleDetailID IN (" + (int)GlobalEnums.NmvnTaskID.SalesOrder + "," + (int)GlobalEnums.NmvnTaskID.DeliveryAdvice + "," + (int)GlobalEnums.NmvnTaskID.TransferOrder + ") ", new ObjectParameter[] { });
                this.ExecuteStoreCommand("UPDATE ModuleDetails SET Controller = N'WAREHOUSE CONTROLS', ModuleID = 6 WHERE ModuleDetailID IN (" + (int)GlobalEnums.NmvnTaskID.GoodsReceipt + "," + (int)GlobalEnums.NmvnTaskID.GoodsIssue + "," + (int)GlobalEnums.NmvnTaskID.WarehouseAdjustment + "," + (int)GlobalEnums.NmvnTaskID.GoodsReceiptDetailAvailable + ") ", new ObjectParameter[] { });

            }

            #endregion Report


            #region ColumnMappings
            if (!this.totalSmartCodingEntities.TableExists("ColumnMappings"))
            {
                this.ExecuteStoreCommand("UPDATE  WarehouseAdjustmentTypes SET Remarks = IIF(WarehouseAdjustmentTypeID = 1, N'XẢ PALLET/ UNPACK PALLET', IIF(WarehouseAdjustmentTypeID = 10, N'CHUYỂN VỊ TRÍ LƯU KHO/ CHANGE BIN LOCATION', IIF(WarehouseAdjustmentTypeID = 20, N'HOLD/ UN-HOLD', IIF(WarehouseAdjustmentTypeID = 30, N'XUẤT KHO TRẢ SẢN XUẤT/ RETURN TO PRODUCTION', N'XỬ LÝ HÀNG MẤT, BỂ VỠ,.../ LOST, BROKEN, ...' ))))", new ObjectParameter[] { });

                this.ExecuteStoreCommand(@"CREATE TABLE [dbo].[ColumnMappings](
	                                                [ColumnMappingID] [int] NOT NULL,
	                                                [MappingTaskID] [int] NOT NULL,
	                                                [ColumnID] [int] NOT NULL,
	                                                [ColumnName] [nvarchar](50) NOT NULL,
	                                                [ColumnDisplayName] [nvarchar](50) NOT NULL,
	                                                [ColumnMappingName] [nvarchar](50) NOT NULL,
	                                                [SerialID] [int] NOT NULL,
	                                                [OrderBy] [int] NULL,
	                                                [ImportedDate] [datetime] NOT NULL,
                                                 CONSTRAINT [PK_ColumnMappings] PRIMARY KEY CLUSTERED 
                                                (
	                                                [ColumnMappingID] ASC
                                                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
                                                 CONSTRAINT [IX_Unique_ColumnID] UNIQUE NONCLUSTERED 
                                                (
	                                                [MappingTaskID] ASC,
	                                                [ColumnID] ASC
                                                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
                                                 CONSTRAINT [IX_Unique_ColumnName] UNIQUE NONCLUSTERED 
                                                (
	                                                [MappingTaskID] ASC,
	                                                [ColumnName] ASC
                                                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                ) ON [PRIMARY]
                                                ", new ObjectParameter[] { });


                this.ExecuteStoreCommand(@" SET IDENTITY_INSERT CommoditySettings ON                                                              
                                        
                                            INSERT INTO ColumnMappings (ColumnMappingID, MappingTaskID, ColumnID, ColumnName, ColumnDisplayName, ColumnMappingName, SerialID, ImportedDate)   VALUES (1, 8076, 2, N'WarehouseCode', N'WH code', N'WH Code', 10, Getdate())
                                            INSERT INTO ColumnMappings (ColumnMappingID, MappingTaskID, ColumnID, ColumnName, ColumnDisplayName, ColumnMappingName, SerialID, ImportedDate)   VALUES (2, 8076, 6, N'CommodityCode', N'Product code', N'Product code', 20, Getdate())
                                            INSERT INTO ColumnMappings (ColumnMappingID, MappingTaskID, ColumnID, ColumnName, ColumnDisplayName, ColumnMappingName, SerialID, ImportedDate)   VALUES (3, 8076, 8, N'CurrentMonth', N'Current month', N'17-Oct', 30, Getdate())
                                            INSERT INTO ColumnMappings (ColumnMappingID, MappingTaskID, ColumnID, ColumnName, ColumnDisplayName, ColumnMappingName, SerialID, ImportedDate)   VALUES (4, 8076, 12, N'NextMonth', N'Next month', N'17-Nov', 60, Getdate())
                                            INSERT INTO ColumnMappings (ColumnMappingID, MappingTaskID, ColumnID, ColumnName, ColumnDisplayName, ColumnMappingName, SerialID, ImportedDate)   VALUES (5, 8076, 16, N'NextTwoMonth', N'Next two month', N'17-Dec', 70, Getdate())
                                            INSERT INTO ColumnMappings (ColumnMappingID, MappingTaskID, ColumnID, ColumnName, ColumnDisplayName, ColumnMappingName, SerialID, ImportedDate)   VALUES (6, 8076, 18, N'NextThreeMonth', N'Next three monnth', N'18-Jan', 80, Getdate())

                                            SET IDENTITY_INSERT CommoditySettings OFF ", new ObjectParameter[] { });

            }
            #endregion ColumnMappings

            

            #region CommoditySettings
            if (!this.totalSmartCodingEntities.TableExists("CommoditySettings") || !this.totalSmartCodingEntities.TableExists("CommoditySettingDetails"))
            {

                this.totalSmartCodingEntities.DropTable("CommoditySettingDetails");
                this.totalSmartCodingEntities.DropTable("CommoditySettings");

                this.ExecuteStoreCommand(@"CREATE TABLE [dbo].[CommoditySettings](
	                                                [CommoditySettingID] [int] IDENTITY(1,1) NOT NULL,
	                                                [EntryDate] [datetime] NOT NULL,
	                                                [Reference] [nvarchar](10) NULL,
	                                                [CommodityID] [int] NOT NULL,
	                                                [LocationID] [int] NOT NULL,
	                                                [Description] [nvarchar](100) NULL,
	                                                [Remarks] [nvarchar](100) NULL,
	                                                [CreatedDate] [datetime] NOT NULL,
	                                                [EditedDate] [datetime] NOT NULL,
	                                                [Approved] [bit] NOT NULL,
	                                                [ApprovedDate] [datetime] NULL,
                                                 CONSTRAINT [PK_CommodityPlots] PRIMARY KEY CLUSTERED 
                                                (
	                                                [CommoditySettingID] ASC
                                                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                ) ON [PRIMARY]
                                                
                                                ALTER TABLE [dbo].[CommoditySettings]  WITH CHECK ADD  CONSTRAINT [FK_CommoditySettings_Commodities] FOREIGN KEY([CommodityID])
                                                REFERENCES [dbo].[Commodities] ([CommodityID])                                                

                                                ALTER TABLE [dbo].[CommoditySettings] CHECK CONSTRAINT [FK_CommoditySettings_Commodities]
                                                ", new ObjectParameter[] { });

                this.ExecuteStoreCommand(@"CREATE TABLE [dbo].[CommoditySettingDetails](
	                                                [CommoditySettingDetailID] [int] IDENTITY(1,1) NOT NULL,
	                                                [CommoditySettingID] [int] NOT NULL,
	                                                [CommodityID] [int] NOT NULL,
	                                                [LocationID] [int] NOT NULL,
	                                                [SettingLocationID] [int] NOT NULL,
	                                                [LowDSI] [decimal](18, 3) NOT NULL,
	                                                [HighDSI] [decimal](18, 3) NOT NULL,
	                                                [AlertDSI] [decimal](18, 3) NOT NULL,
                                                 CONSTRAINT [PK_CommoditySettings] PRIMARY KEY CLUSTERED 
                                                (
	                                                [CommoditySettingDetailID] ASC
                                                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
                                                 CONSTRAINT [IX_CommoditySettings] UNIQUE NONCLUSTERED 
                                                (
	                                                [CommodityID] ASC,
	                                                [SettingLocationID] ASC
                                                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                ) ON [PRIMARY]

                                                ALTER TABLE [dbo].[CommoditySettingDetails]  WITH CHECK ADD  CONSTRAINT [FK_CommoditySettingDetails_Commodities] FOREIGN KEY([CommodityID])
                                                REFERENCES [dbo].[Commodities] ([CommodityID])

                                                ALTER TABLE [dbo].[CommoditySettingDetails] CHECK CONSTRAINT [FK_CommoditySettingDetails_Commodities]

                                                ALTER TABLE [dbo].[CommoditySettingDetails]  WITH CHECK ADD  CONSTRAINT [FK_CommoditySettingDetails_CommoditySettings] FOREIGN KEY([CommoditySettingID])
                                                REFERENCES [dbo].[CommoditySettings] ([CommoditySettingID])

                                                ALTER TABLE [dbo].[CommoditySettingDetails] CHECK CONSTRAINT [FK_CommoditySettingDetails_CommoditySettings]
                                                ", new ObjectParameter[] { });

                this.InitCommoditySettings();

            }
            #endregion CommoditySettings



            #region Forecasts
            this.totalSmartCodingEntities.ColumnAdd("Forecasts", "QuantityVersusVolume", "int", "0", true);
            var query = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Forecast + ";", new object[] { });
            int exists = query.Cast<int>().Single();
            if (exists == 0)
            {
                this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive) VALUES(" + (int)GlobalEnums.NmvnTaskID.Forecast + ", 6, N'Sales Forecast', N'Sales Forecast', '#', '#', N'LOGISTICS ADMIN', 1, 6, 1, 0) ", new ObjectParameter[] { });
                this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.Forecast + " AS NMVNTaskID, OrganizationalUnitID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls WHERE (NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.Commodity + ") AND (SELECT COUNT(*) FROM AccessControls WHERE NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.Forecast + ") = 0", new ObjectParameter[] { });

                //********************
                this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive) VALUES(" + (int)GlobalEnums.NmvnTaskID.CommoditySetting + ", 1, 'Low, High & Alert Settings', 'Low, High & Alert Settings', '#', '#', 'WAREHOUSE RESOURCES', 1, 12, 1, 0) ", new ObjectParameter[] { });
                this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.CommoditySetting + " AS NMVNTaskID, OrganizationalUnitID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls WHERE (NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.Commodity + ") AND (SELECT COUNT(*) FROM AccessControls WHERE NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.CommoditySetting + ") = 0", new ObjectParameter[] { });
                //********************
            }



            query = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.PendingOrder + ";", new object[] { });
            exists = query.Cast<int>().Single();
            if (exists == 0)
            {
                this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive) VALUES(" + (int)GlobalEnums.NmvnTaskID.PendingOrder + ", 6, N'Current Pending Orders', N'Current Pending Orders', '#', '#', N'LOGISTICS ADMIN', 1, 68, 1, 0) ", new ObjectParameter[] { });
                this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.PendingOrder + " AS NMVNTaskID, OrganizationalUnitID, 1 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls WHERE (NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.SalesOrder + ") AND (SELECT COUNT(*) FROM AccessControls WHERE NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.PendingOrder + ") = 0", new ObjectParameter[] { });
            }
            #endregion Forecasts



            #region VERSION 73: DATE: BEFORE TET HOLIDAY

            #region Add forecast table
            this.ExecuteStoreCommand(@"CREATE TABLE [dbo].[Forecasts](
	                                                    [ForecastID] [int] IDENTITY(1,1) NOT NULL,
	                                                    [EntryDate] [datetime] NOT NULL,
	                                                    [Reference] [nvarchar](10) NULL,
	                                                    [VoucherCode] [nvarchar](60) NULL,
	                                                    [ForecastLocationID] [int] NOT NULL,
	                                                    [SalespersonID] [int] NOT NULL,
	                                                    [UserID] [int] NOT NULL,
	                                                    [PreparedPersonID] [int] NOT NULL,
	                                                    [OrganizationalUnitID] [int] NOT NULL,
	                                                    [LocationID] [int] NOT NULL,
	                                                    [TotalQuantity] [decimal](18, 2) NOT NULL,
	                                                    [TotalLineVolume] [decimal](18, 2) NOT NULL,
	                                                    [TotalQuantityM1] [decimal](18, 2) NOT NULL,
	                                                    [TotalLineVolumeM1] [decimal](18, 2) NOT NULL,
	                                                    [TotalQuantityM2] [decimal](18, 2) NOT NULL,
	                                                    [TotalLineVolumeM2] [decimal](18, 2) NOT NULL,
	                                                    [TotalQuantityM3] [decimal](18, 2) NOT NULL,
	                                                    [TotalLineVolumeM3] [decimal](18, 2) NOT NULL,
	                                                    [Description] [nvarchar](100) NULL,
	                                                    [Remarks] [nvarchar](100) NULL,
	                                                    [CreatedDate] [datetime] NOT NULL,
	                                                    [EditedDate] [datetime] NOT NULL,
	                                                    [Approved] [bit] NOT NULL,
	                                                    [ApprovedDate] [datetime] NULL,
                                                     CONSTRAINT [PK_Forecasts] PRIMARY KEY CLUSTERED 
                                                    (
	                                                    [ForecastID] ASC
                                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                    ) ON [PRIMARY]                                                            
                                                ", new ObjectParameter[] { });


            this.ExecuteStoreCommand(@"CREATE TABLE [dbo].[ForecastDetails](
	                                                    [ForecastDetailID] [int] IDENTITY(1,1) NOT NULL,
	                                                    [ForecastID] [int] NOT NULL,
	                                                    [EntryDate] [datetime] NOT NULL,
	                                                    [Reference] [nvarchar](10) NULL,
	                                                    [VoucherCode] [nvarchar](60) NULL,
	                                                    [ForecastLocationID] [int] NOT NULL,
	                                                    [LocationID] [int] NOT NULL,
	                                                    [CommodityID] [int] NOT NULL,
	                                                    [Quantity] [decimal](18, 2) NOT NULL,
	                                                    [LineVolume] [decimal](18, 2) NOT NULL,
	                                                    [QuantityM1] [decimal](18, 2) NOT NULL,
	                                                    [LineVolumeM1] [decimal](18, 2) NOT NULL,
	                                                    [QuantityM2] [decimal](18, 2) NOT NULL,
	                                                    [LineVolumeM2] [decimal](18, 2) NOT NULL,
	                                                    [QuantityM3] [decimal](18, 2) NOT NULL,
	                                                    [LineVolumeM3] [decimal](18, 2) NOT NULL,
	                                                    [Remarks] [nvarchar](100) NULL,
	                                                    [Approved] [bit] NOT NULL,
                                                     CONSTRAINT [PK_ForecastDetails] PRIMARY KEY CLUSTERED 
                                                    (
	                                                    [ForecastDetailID] ASC
                                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                    ) ON [PRIMARY]


                                                    ALTER TABLE [dbo].[ForecastDetails]  WITH CHECK ADD  CONSTRAINT [FK_ForecastDetails_Forecasts] FOREIGN KEY([ForecastID])
                                                    REFERENCES [dbo].[Forecasts] ([ForecastID])


                                                    ALTER TABLE [dbo].[ForecastDetails] CHECK CONSTRAINT [FK_ForecastDetails_Forecasts]
                                                ", new ObjectParameter[] { });


            #endregion Add forecast table


            #region Add forecast table
            this.ExecuteStoreCommand(@"CREATE TABLE [dbo].[CommoditySettingDetails](
	                                                    [CommoditySettingID] [int] IDENTITY(1,1) NOT NULL,
	                                                    [CommodityID] [int] NOT NULL,
	                                                    [LocationID] [int] NOT NULL,
	                                                    [LowDSI] [decimal](18, 3) NOT NULL,
	                                                    [HighDSI] [decimal](18, 3) NOT NULL,
	                                                    [AlertDSI] [decimal](18, 3) NOT NULL,
                                                     CONSTRAINT [PK_CommoditySettingDetails] PRIMARY KEY CLUSTERED 
                                                    (
	                                                    [CommoditySettingID] ASC
                                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
                                                     CONSTRAINT [IX_CommoditySettingDetails] UNIQUE NONCLUSTERED 
                                                    (
	                                                    [CommodityID] ASC,
	                                                    [LocationID] ASC
                                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                    ) ON [PRIMARY]
                                                ", new ObjectParameter[] { });

            #endregion Add forecast table
            #endregion VERSION 73: DATE: BEFORE TET HOLIDAY


            #region VERSION 71 DATE: 10-O1-2018


            //if (!this.totalSmartCodingEntities.ColumnExists("A_Commodities", "InActive"))
            //{
            //    this.totalSmartCodingEntities.ColumnAdd("A_Commodities", "InActive", "bit", "0", true);


            //    this.ExecuteStoreCommand("UPDATE GoodsIssueDetails SET GoodsIssueDetails.BatchID = Batches.BatchID, GoodsIssueDetails.BatchEntryDate = Batches.EntryDate FROM GoodsIssueDetails INNER JOIN Pallets ON GoodsIssueDetails.BatchID = 0 AND GoodsIssueDetails.PalletID = Pallets.PalletID INNER JOIN Batches ON Pallets.BatchID = Batches.BatchID", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("UPDATE GoodsIssueTransferDetails SET GoodsIssueTransferDetails.BatchID = Batches.BatchID, GoodsIssueTransferDetails.BatchEntryDate = Batches.EntryDate FROM GoodsIssueTransferDetails INNER JOIN Pallets ON GoodsIssueTransferDetails.BatchID = 0 AND GoodsIssueTransferDetails.PalletID = Pallets.PalletID INNER JOIN Batches ON Pallets.BatchID = Batches.BatchID", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("UPDATE GoodsReceiptDetails SET GoodsReceiptDetails.BatchID = Batches.BatchID, GoodsReceiptDetails.BatchEntryDate = Batches.EntryDate FROM GoodsReceiptDetails INNER JOIN Pallets ON GoodsReceiptDetails.BatchID = 0 AND GoodsReceiptDetails.PalletID = Pallets.PalletID INNER JOIN Batches ON Pallets.BatchID = Batches.BatchID", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("UPDATE PickupDetails SET PickupDetails.BatchID = Batches.BatchID, PickupDetails.BatchEntryDate = Batches.EntryDate FROM PickupDetails INNER JOIN Pallets ON PickupDetails.BatchID = 0 AND PickupDetails.PalletID = Pallets.PalletID INNER JOIN Batches ON Pallets.BatchID = Batches.BatchID", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("UPDATE WarehouseAdjustmentDetails SET WarehouseAdjustmentDetails.BatchID = Batches.BatchID, WarehouseAdjustmentDetails.BatchEntryDate = Batches.EntryDate FROM WarehouseAdjustmentDetails INNER JOIN Pallets ON WarehouseAdjustmentDetails.BatchID = 0 AND WarehouseAdjustmentDetails.PalletID = Pallets.PalletID INNER JOIN Batches ON Pallets.BatchID = Batches.BatchID", new ObjectParameter[] { });


            //    this.ExecuteStoreCommand("UPDATE GoodsIssueDetails SET GoodsIssueDetails.BatchID = Batches.BatchID, GoodsIssueDetails.BatchEntryDate = Batches.EntryDate FROM GoodsIssueDetails INNER JOIN Cartons ON GoodsIssueDetails.BatchID = 0 AND GoodsIssueDetails.CartonID = Cartons.CartonID INNER JOIN Batches ON Cartons.BatchID = Batches.BatchID", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("UPDATE GoodsIssueTransferDetails SET GoodsIssueTransferDetails.BatchID = Batches.BatchID, GoodsIssueTransferDetails.BatchEntryDate = Batches.EntryDate FROM GoodsIssueTransferDetails INNER JOIN Cartons ON GoodsIssueTransferDetails.BatchID = 0 AND GoodsIssueTransferDetails.CartonID = Cartons.CartonID INNER JOIN Batches ON Cartons.BatchID = Batches.BatchID", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("UPDATE GoodsReceiptDetails SET GoodsReceiptDetails.BatchID = Batches.BatchID, GoodsReceiptDetails.BatchEntryDate = Batches.EntryDate FROM GoodsReceiptDetails INNER JOIN Cartons ON GoodsReceiptDetails.BatchID = 0 AND GoodsReceiptDetails.CartonID = Cartons.CartonID INNER JOIN Batches ON Cartons.BatchID = Batches.BatchID", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("UPDATE PickupDetails SET PickupDetails.BatchID = Batches.BatchID, PickupDetails.BatchEntryDate = Batches.EntryDate FROM PickupDetails INNER JOIN Cartons ON PickupDetails.BatchID = 0 AND PickupDetails.CartonID = Cartons.CartonID INNER JOIN Batches ON Cartons.BatchID = Batches.BatchID", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("UPDATE WarehouseAdjustmentDetails SET WarehouseAdjustmentDetails.BatchID = Batches.BatchID, WarehouseAdjustmentDetails.BatchEntryDate = Batches.EntryDate FROM WarehouseAdjustmentDetails INNER JOIN Cartons ON WarehouseAdjustmentDetails.BatchID = 0 AND WarehouseAdjustmentDetails.CartonID = Cartons.CartonID INNER JOIN Batches ON Cartons.BatchID = Batches.BatchID", new ObjectParameter[] { });
            //}


            //if (!this.totalSmartCodingEntities.ColumnExists("AccessControls", "InActive"))
            //{
            //    this.totalSmartCodingEntities.ColumnAdd("AccessControls", "InActive", "bit", "0", true);
            //    this.totalSmartCodingEntities.ColumnAdd("OrganizationalUnitUsers", "InActiveDate", "datetime", null, false);

            //    this.ExecuteStoreCommand("UPDATE Modules SET InActive = 1 WHERE ModuleID = 9", new ObjectParameter[] { });
            //}

            //            #region DELETE NOT USED OrganizationalUnitID, RESET ReadOnly TO AccessControls WHERE Users.LocationID <> AccessControls.LocationID
            //            this.ExecuteStoreCommand(@"IF (SELECT   COUNT(OrganizationalUnitID) FROM OrganizationalUnits) > 15
            //                                       BEGIN
            //                                            DELETE FROM AccessControls WHERE OrganizationalUnitID NOT IN (
            //                                                SELECT DISTINCT OrganizationalUnitID
            //                                                FROM (
            //                                                SELECT OrganizationalUnitID FROM BinLocations
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM DeliveryAdvices
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM GoodsIssueDetails
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM GoodsIssues
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM GoodsReceiptDetails
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM GoodsReceipts
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM OrganizationalUnitUsers
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM Pickups
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM SalesOrders
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM TransferOrders
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM Users
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM WarehouseAdjustmentDetails
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM WarehouseAdjustments
            //                                                ) AS UNIONOrganizationalUnitID)
            //
            //
            //                                            DELETE FROM OrganizationalUnits WHERE OrganizationalUnitID NOT IN (
            //                                                SELECT DISTINCT OrganizationalUnitID
            //                                                FROM (
            //                                                SELECT OrganizationalUnitID FROM BinLocations
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM DeliveryAdvices
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM GoodsIssueDetails
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM GoodsIssues
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM GoodsReceiptDetails
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM GoodsReceipts
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM OrganizationalUnitUsers
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM Pickups
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM SalesOrders
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM TransferOrders
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM Users
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM WarehouseAdjustmentDetails
            //                                                UNION ALL
            //                                                SELECT OrganizationalUnitID FROM WarehouseAdjustments
            //                                                ) AS UNIONOrganizationalUnitID)
            //
            //
            //                                            UPDATE  AccessControls
            //                                                SET     AccessControls.AccessLevel = CASE WHEN AccessControls.AccessLevel > 1 THEN 1 ELSE AccessControls.AccessLevel END, AccessControls.ApprovalPermitted = 0, AccessControls.UnApprovalPermitted = 0, AccessControls.VoidablePermitted = 0, AccessControls.UnVoidablePermitted = 0
            //                                                FROM    AccessControls INNER JOIN
            //                                                        OrganizationalUnits ON AccessControls.OrganizationalUnitID = OrganizationalUnits.OrganizationalUnitID INNER JOIN
            //                                                        Users ON AccessControls.UserID = Users.UserID INNER JOIN
            //                                                        OrganizationalUnits AS OrganizationalUnits_1 ON Users.OrganizationalUnitID = OrganizationalUnits_1.OrganizationalUnitID
            //                                                WHERE   OrganizationalUnits_1.LocationID <> OrganizationalUnits.LocationID
            //
            //
            //                                       END
            //                                ", new ObjectParameter[] { });

            //            #endregion DELETE NOT USED OrganizationalUnitID
            #endregion VERSION 71 DATE: 10-O1-2018


            #region VERSION 61 DATE: 01-O1-2018

            ////if (!this.totalSmartCodingEntities.TableExists("Teams"))
            ////{
            ////    this.ExecuteStoreCommand("CREATE TABLE [dbo].[Teams]([TeamID] [int] IDENTITY(1,1) NOT NULL, [Code] [nvarchar](100) NOT NULL, [Name] [nvarchar](500) NOT NULL, [Remarks] [nvarchar](100) NULL, CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED ([TeamID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]");

            ////    this.ExecuteStoreCommand("INSERT INTO Teams (Code, Name) VALUES ('Direct Sales North', 'Direct Sales North')", new ObjectParameter[] { });
            ////    this.ExecuteStoreCommand("INSERT INTO Teams (Code, Name) VALUES ('Direct Sales South', 'Direct Sales South')", new ObjectParameter[] { });
            ////    this.ExecuteStoreCommand("INSERT INTO Teams (Code, Name) VALUES ('Indirect Sales North', 'Indirect Sales North')", new ObjectParameter[] { });
            ////    this.ExecuteStoreCommand("INSERT INTO Teams (Code, Name) VALUES ('Indirect Sales South', 'Indirect Sales South')", new ObjectParameter[] { });

            ////    this.ExecuteStoreCommand("sp_rename 'Employees.EmployeeTypeID', 'TeamID', 'COLUMN'", new ObjectParameter[] { });
            ////    this.ExecuteStoreCommand("ALTER TABLE Employees ALTER COLUMN TeamID int NULL", new ObjectParameter[] { });

            ////    this.ExecuteStoreCommand("ALTER TABLE Employees WITH CHECK ADD CONSTRAINT FK_Employees_Teams FOREIGN KEY(TeamID) REFERENCES dbo.Teams (TeamID)", new ObjectParameter[] { });
            ////    this.ExecuteStoreCommand("ALTER TABLE Employees CHECK CONSTRAINT FK_Employees_Teams", new ObjectParameter[] { });

            ////    this.ExecuteStoreCommand("UPDATE Employees SET TeamID = NULL WHERE EmployeeID IN (SELECT EmployeeID FROM EmployeeRoles WHERE RoleID <> 3) ", new ObjectParameter[] { });
            ////}

            ////if (!this.totalSmartCodingEntities.ColumnExists("SalesOrders", "TeamID"))
            ////{
            ////    this.totalSmartCodingEntities.ColumnAdd("SalesOrders", "TeamID", "int", "1", true);
            ////    this.totalSmartCodingEntities.ColumnAdd("DeliveryAdvices", "TeamID", "int", "1", true);

            ////    this.ExecuteStoreCommand("ALTER TABLE SalesOrders WITH CHECK ADD CONSTRAINT FK_SalesOrders_Teams FOREIGN KEY(TeamID) REFERENCES dbo.Teams (TeamID)", new ObjectParameter[] { });
            ////    this.ExecuteStoreCommand("ALTER TABLE SalesOrders CHECK CONSTRAINT FK_SalesOrders_Teams", new ObjectParameter[] { });

            ////    this.ExecuteStoreCommand("ALTER TABLE DeliveryAdvices WITH CHECK ADD CONSTRAINT FK_DeliveryAdvices_Teams FOREIGN KEY(TeamID) REFERENCES dbo.Teams (TeamID)", new ObjectParameter[] { });
            ////    this.ExecuteStoreCommand("ALTER TABLE DeliveryAdvices CHECK CONSTRAINT FK_DeliveryAdvices_Teams", new ObjectParameter[] { });

            ////    this.ExecuteStoreCommand("UPDATE CommodityTypes SET Name = 'ABX' WHERE CommodityTypeID = 1", new ObjectParameter[] { });
            ////    this.ExecuteStoreCommand("UPDATE CommodityTypes SET Name = 'L' WHERE CommodityTypeID = 2", new ObjectParameter[] { });
            ////    this.ExecuteStoreCommand("UPDATE CommodityTypes SET Name = 'H' WHERE CommodityTypeID = 6", new ObjectParameter[] { });

            ////    this.ExecuteStoreCommand("UPDATE Commodities SET CommodityTypeID = 2 WHERE RIGHT(Code, 1) = 'L' ", new ObjectParameter[] { });
            ////    this.ExecuteStoreCommand("UPDATE Commodities SET CommodityTypeID = 6 WHERE RIGHT(Code, 1) = 'H' ", new ObjectParameter[] { });
            ////}

            ////if (!this.totalSmartCodingEntities.ColumnExists("Reports", "ReportTabPageIDs"))
            ////{
            ////    this.totalSmartCodingEntities.ColumnAdd("Reports", "ReportTabPageIDs", "nvarchar(100)", "", false);



            ////    this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive) VALUES(" + (int)GlobalEnums.NmvnTaskID.Report + ", 9, 'Reports', 'Reports', '#', '#', '#', 1, 10, 1, 0) ", new ObjectParameter[] { });
            ////    this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.Report + " AS NMVNTaskID, OrganizationalUnitID, 1 AS AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP FROM AccessControls WHERE (NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.Commodity + ") AND (SELECT COUNT(*) FROM AccessControls WHERE NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.Report + ") = 0", new ObjectParameter[] { });



            ////}

            ////if (!this.totalSmartCodingEntities.ColumnExists("GoodsIssueDetails", "LocationReceiptID"))
            ////{
            ////    this.totalSmartCodingEntities.ColumnAdd("GoodsIssueDetails", "LocationReceiptID", "int", null, false);
            ////    this.ExecuteStoreCommand("UPDATE GoodsIssueDetails SET LocationReceiptID = Warehouses.LocationID FROM GoodsIssueDetails INNER JOIN Warehouses ON GoodsIssueDetails.WarehouseReceiptID = Warehouses.WarehouseID ", new ObjectParameter[] { });

            ////    this.totalSmartCodingEntities.ColumnAdd("GoodsIssues", "LocationReceiptID", "int", null, false);
            ////    this.ExecuteStoreCommand("UPDATE GoodsIssues SET LocationReceiptID = Warehouses.LocationID FROM GoodsIssues INNER JOIN Warehouses ON GoodsIssues.WarehouseReceiptID = Warehouses.WarehouseID ", new ObjectParameter[] { });

            ////    this.ExecuteStoreCommand("ALTER TABLE [dbo].[GoodsIssues] DROP CONSTRAINT FK_GoodsIssues_WarehouseReceipts ", new ObjectParameter[] { });
            ////    this.ExecuteStoreCommand("ALTER TABLE [dbo].[GoodsIssues] DROP CONSTRAINT FK_GoodsIssues_Warehouses ", new ObjectParameter[] { });
            ////}

            ////if (!this.totalSmartCodingEntities.ColumnExists("DeliveryAdviceDetails", "SalespersonID"))
            ////{
            ////    this.totalSmartCodingEntities.ColumnAdd("DeliveryAdviceDetails", "SalespersonID", "int", "1", true);
            ////    this.ExecuteStoreCommand("UPDATE DeliveryAdviceDetails SET DeliveryAdviceDetails.SalespersonID = DeliveryAdvices.SalespersonID FROM DeliveryAdviceDetails INNER JOIN DeliveryAdvices ON DeliveryAdviceDetails.DeliveryAdviceID = DeliveryAdvices.DeliveryAdviceID ", new ObjectParameter[] { });

            ////    this.totalSmartCodingEntities.ColumnAdd("GoodsIssueDetails", "SalespersonID", "int", null, false);
            ////    this.ExecuteStoreCommand("UPDATE GoodsIssueDetails SET GoodsIssueDetails.SalespersonID = DeliveryAdviceDetails.SalespersonID FROM GoodsIssueDetails INNER JOIN DeliveryAdviceDetails ON GoodsIssueDetails.DeliveryAdviceDetailID = DeliveryAdviceDetails.DeliveryAdviceDetailID ", new ObjectParameter[] { });
            ////}

            ////if (!this.totalSmartCodingEntities.ColumnExists("GoodsIssueDetails", "OrganizationalUnitID"))
            ////{
            ////    this.totalSmartCodingEntities.ColumnAdd("GoodsIssueDetails", "OrganizationalUnitID", "int", "1", true);
            ////    this.ExecuteStoreCommand("UPDATE GoodsIssueDetails SET GoodsIssueDetails.OrganizationalUnitID = GoodsIssues.OrganizationalUnitID FROM GoodsIssueDetails INNER JOIN GoodsIssues ON GoodsIssueDetails.GoodsIssueID = GoodsIssues.GoodsIssueID ", new ObjectParameter[] { });
            ////}

            ////if (!this.totalSmartCodingEntities.ColumnExists("WarehouseAdjustmentDetails", "OrganizationalUnitID"))
            ////{
            ////    this.totalSmartCodingEntities.ColumnAdd("WarehouseAdjustmentDetails", "OrganizationalUnitID", "int", "1", true);
            ////    this.ExecuteStoreCommand("UPDATE WarehouseAdjustmentDetails SET WarehouseAdjustmentDetails.OrganizationalUnitID = WarehouseAdjustments.OrganizationalUnitID FROM WarehouseAdjustmentDetails INNER JOIN WarehouseAdjustments ON WarehouseAdjustmentDetails.WarehouseAdjustmentID = WarehouseAdjustments.WarehouseAdjustmentID ", new ObjectParameter[] { });

            ////    this.totalSmartCodingEntities.ColumnAdd("WarehouseAdjustmentDetails", "AdjustmentJobs", "nvarchar(100)", null, false);
            ////    this.ExecuteStoreCommand("UPDATE WarehouseAdjustmentDetails SET WarehouseAdjustmentDetails.AdjustmentJobs = WarehouseAdjustments.AdjustmentJobs FROM WarehouseAdjustmentDetails INNER JOIN WarehouseAdjustments ON WarehouseAdjustmentDetails.WarehouseAdjustmentID = WarehouseAdjustments.WarehouseAdjustmentID ", new ObjectParameter[] { });
            ////}

            ////if (!this.totalSmartCodingEntities.ColumnExists("GoodsIssueDetails", "VoucherCodes"))
            ////{
            ////    this.totalSmartCodingEntities.ColumnAdd("GoodsIssueDetails", "VoucherCodes", "nvarchar(100)", null, false);
            ////    this.ExecuteStoreCommand("UPDATE GoodsIssueDetails SET GoodsIssueDetails.VoucherCodes = GoodsIssues.VoucherCodes FROM GoodsIssueDetails INNER JOIN GoodsIssues ON GoodsIssueDetails.GoodsIssueID = GoodsIssues.GoodsIssueID ", new ObjectParameter[] { });

            ////    this.ExecuteStoreCommand("ALTER TABLE [dbo].[GoodsIssues]  WITH CHECK ADD  CONSTRAINT [FK_GoodsIssues_Warehouses] FOREIGN KEY([WarehouseID]) REFERENCES [dbo].[Warehouses] ([WarehouseID])", new ObjectParameter[] { });
            ////    this.ExecuteStoreCommand("ALTER TABLE [dbo].[GoodsIssues] CHECK CONSTRAINT [FK_GoodsIssues_Warehouses]", new ObjectParameter[] { });

            ////    this.ExecuteStoreCommand("ALTER TABLE [dbo].[GoodsIssues]  WITH CHECK ADD  CONSTRAINT [FK_GoodsIssues_Warehouses1] FOREIGN KEY([WarehouseReceiptID]) REFERENCES [dbo].[Warehouses] ([WarehouseID])", new ObjectParameter[] { });
            ////    this.ExecuteStoreCommand("ALTER TABLE [dbo].[GoodsIssues] CHECK CONSTRAINT [FK_GoodsIssues_Warehouses1]", new ObjectParameter[] { });
            ////}






            ////if (!this.totalSmartCodingEntities.ColumnExists("GoodsReceiptDetails", "OrganizationalUnitID"))
            ////{
            ////    this.totalSmartCodingEntities.ColumnAdd("GoodsReceiptDetails", "SupplierID", "int", null, false);

            ////    this.totalSmartCodingEntities.ColumnAdd("GoodsReceiptDetails", "WarehouseIssueID", "int", null, false);
            ////    this.ExecuteStoreCommand("UPDATE GoodsReceiptDetails SET GoodsReceiptDetails.WarehouseIssueID = GoodsIssueTransferDetails.WarehouseID FROM GoodsReceiptDetails INNER JOIN GoodsIssueTransferDetails ON GoodsReceiptDetails.GoodsIssueTransferDetailID = GoodsIssueTransferDetails.GoodsIssueTransferDetailID", new ObjectParameter[] { });

            ////    this.totalSmartCodingEntities.ColumnAdd("GoodsReceiptDetails", "LocationIssueID", "int", null, false);
            ////    this.ExecuteStoreCommand("UPDATE GoodsReceiptDetails SET LocationIssueID = Warehouses.LocationID FROM GoodsReceiptDetails INNER JOIN Warehouses ON GoodsReceiptDetails.WarehouseIssueID = Warehouses.WarehouseID ", new ObjectParameter[] { });

            ////    this.totalSmartCodingEntities.ColumnAdd("GoodsReceiptDetails", "OrganizationalUnitID", "int", "1", true);
            ////    this.ExecuteStoreCommand("UPDATE GoodsReceiptDetails SET GoodsReceiptDetails.OrganizationalUnitID = GoodsReceipts.OrganizationalUnitID FROM GoodsReceiptDetails INNER JOIN GoodsReceipts ON GoodsReceiptDetails.GoodsReceiptID = GoodsReceipts.GoodsReceiptID ", new ObjectParameter[] { });

            ////    this.totalSmartCodingEntities.ColumnAdd("GoodsReceiptDetails", "PrimaryReferences", "nvarchar(100)", null, false);
            ////    this.ExecuteStoreCommand("UPDATE GoodsReceiptDetails SET GoodsReceiptDetails.PrimaryReferences = GoodsReceipts.PrimaryReferences FROM GoodsReceiptDetails INNER JOIN GoodsReceipts ON GoodsReceiptDetails.GoodsReceiptID = GoodsReceipts.GoodsReceiptID ", new ObjectParameter[] { });

            ////    this.totalSmartCodingEntities.ColumnAdd("GoodsReceiptDetails", "WarehouseAdjustmentTypeID", "int", null, false);
            ////    this.ExecuteStoreCommand("UPDATE GoodsReceiptDetails SET GoodsReceiptDetails.WarehouseAdjustmentTypeID = WarehouseAdjustments.WarehouseAdjustmentTypeID FROM GoodsReceiptDetails INNER JOIN WarehouseAdjustments ON GoodsReceiptDetails.WarehouseAdjustmentID = WarehouseAdjustments.WarehouseAdjustmentID ", new ObjectParameter[] { });

            ////    this.totalSmartCodingEntities.ColumnAdd("GoodsIssueTransferDetails", "LocationIssueID", "int", "0", true);
            ////    this.ExecuteStoreCommand("UPDATE GoodsIssueTransferDetails SET GoodsIssueTransferDetails.LocationIssueID = GoodsIssueDetails.LocationID FROM GoodsIssueTransferDetails INNER JOIN GoodsIssueDetails ON GoodsIssueTransferDetails.GoodsIssueDetailID = GoodsIssueDetails.GoodsIssueDetailID ", new ObjectParameter[] { });
            ////}

            #endregion VERSION 61 DATE: 01-01-2018


            #region OLD
            //this.ExecuteStoreCommand("UPDATE AccessControls SET AccessLevel = 1, ApprovalPermitted = 0, UnApprovalPermitted = 0, VoidablePermitted = 0, UnVoidablePermitted = 0 WHERE NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.Commodity + " AND UserID <> 11 ", new ObjectParameter[] { }); //CHEVRONVN\Thanh Hai Tran [HAIPHONG\LOGISTICS 2]



            //if (!this.totalSmartCodingEntities.ColumnExists("GoodsReceipts", "ForkliftDriverID"))
            //{
            //    this.totalSmartCodingEntities.ColumnAdd("GoodsReceipts", "ForkliftDriverID", "int", "1", true);
            //    this.totalSmartCodingEntities.ColumnAdd("GoodsReceipts", "VehicleDriver", "nvarchar(100)", "", false);

            //    this.ExecuteStoreCommand("UPDATE GoodsReceipts SET ForkliftDriverID = StorekeeperID, VehicleDriver = NULL ", new ObjectParameter[] { });
            //}


            //this.totalSmartCodingEntities.ColumnAdd("SalesOrders", "VoidTypeID", "int", null, false);
            //this.totalSmartCodingEntities.ColumnAdd("SalesOrders", "InActive", "bit", "0", true);
            //this.totalSmartCodingEntities.ColumnAdd("SalesOrders", "InActivePartial", "bit", "0", true);
            //this.totalSmartCodingEntities.ColumnAdd("SalesOrders", "InActiveDate", "datetime", null, false);

            //this.totalSmartCodingEntities.ColumnAdd("SalesOrderDetails", "InActive", "bit", "0", true);
            //this.totalSmartCodingEntities.ColumnAdd("SalesOrderDetails", "InActivePartial", "bit", "0", true);
            //this.totalSmartCodingEntities.ColumnAdd("SalesOrderDetails", "InActiveDate", "datetime", null, false);

            //this.ExecuteStoreCommand("UPDATE ModuleDetails SET Code = N'Bin Locations', Name = N'Bin Locations' WHERE ModuleDetailID  = " + (int)GlobalEnums.NmvnTaskID.BinLocation, new ObjectParameter[] { });



            //if (!this.totalSmartCodingEntities.ColumnExists("BinLocations", "UserID"))
            //{
            //    this.totalSmartCodingEntities.ColumnAdd("BinLocations", "UserID", "int", "1", true);
            //    this.totalSmartCodingEntities.ColumnAdd("BinLocations", "PreparedPersonID", "int", "1", true);
            //    this.totalSmartCodingEntities.ColumnAdd("BinLocations", "OrganizationalUnitID", "int", "1", true);

            //    this.ExecuteStoreCommand("UPDATE BinLocations SET UserID = 11, PreparedPersonID = 11, OrganizationalUnitID = 5 WHERE LocationID = 1", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("UPDATE BinLocations SET UserID = 32, PreparedPersonID = 32, OrganizationalUnitID = 7 WHERE LocationID = 2", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("UPDATE BinLocations SET UserID = 33, PreparedPersonID = 33, OrganizationalUnitID = 16 WHERE LocationID = 3", new ObjectParameter[] { });



            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-28-1','104-28-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-28-2','104-28-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-29-1','104-29-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-29-2','104-29-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-30-1','104-30-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-30-2','104-30-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-31-1','104-31-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-31-2','104-31-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-32-1','104-32-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-32-2','104-32-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-33-1','104-33-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-33-2','104-33-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-34-1','104-34-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-34-2','104-34-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-35-1','104-35-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-35-2','104-35-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-36-1','104-36-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-36-2','104-36-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-37-1','104-37-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-37-2','104-37-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-38-1','104-38-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-38-2','104-38-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-25-1','104-25-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-23-2','104-23-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-24-1','104-24-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-24-2','104-24-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-23-1','104-23-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-26-1','104-26-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-25-2','104-25-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-26-2','104-26-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-27-1','104-27-1', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO BinLocations (Code, Name, LocationID, WarehouseID, ToiDa, TongSo, DeXuat, Remarks, InActive, UserID, PreparedPersonID, OrganizationalUnitID) VALUES ('104-27-2','104-27-2', 3, 3, -1, -1, -1, '', 0, 33, 33, 16)", new ObjectParameter[] { });
            //}



            //this.ExecuteStoreCommand("UPDATE      AccessControls SET                AccessLevel = 0, ApprovalPermitted = 0, UnApprovalPermitted = 0, VoidablePermitted = 0, UnVoidablePermitted = 0, ShowDiscount = 0 WHERE        (UserID = 33)", new ObjectParameter[] { });

            //this.ExecuteStoreCommand("UPDATE      AccessControls SET                AccessLevel = 1, ApprovalPermitted = 0, UnApprovalPermitted = 0, VoidablePermitted = 0, UnVoidablePermitted = 0, ShowDiscount = 0 WHERE        (OrganizationalUnitID IN                            (SELECT        OrganizationalUnitID                           FROM            OrganizationalUnits                               WHERE        (LocationID = (SELECT        OrganizationalUnits.LocationID FROM            Users INNER JOIN                          OrganizationalUnits ON Users.OrganizationalUnitID = OrganizationalUnits.OrganizationalUnitID WHERE        (Users.UserID = 33))))) AND (UserID = 33)", new ObjectParameter[] { });
            //this.ExecuteStoreCommand("UPDATE      AccessControls SET                AccessLevel = 2, ApprovalPermitted = 1, UnApprovalPermitted = 1, VoidablePermitted = 1, UnVoidablePermitted = 1, ShowDiscount = 0 WHERE        (OrganizationalUnitID IN                           (SELECT        OrganizationalUnitID                               FROM            OrganizationalUnits                              WHERE        (LocationID = (SELECT        OrganizationalUnits.LocationID FROM            Users INNER JOIN                          OrganizationalUnits ON Users.OrganizationalUnitID = OrganizationalUnits.OrganizationalUnitID WHERE        (Users.UserID = 33))))) AND (UserID = 33)   and OrganizationalUnitID = (SELECT    OrganizationalUnitID FROM            Users WHERE        (UserID = 33))", new ObjectParameter[] { });


            //return;

            //if (!this.totalSmartCodingEntities.TableExists("EmployeeRoles"))
            //{

            //    this.ExecuteStoreCommand("CREATE TABLE [dbo].[EmployeeRoles]([EmployeeRoleID] [int] IDENTITY(1,1) NOT NULL, [EmployeeID] [int] NOT NULL, [RoleID] [int] NOT NULL, [InActive] [bit] NOT NULL, CONSTRAINT [PK_EmployeeRoles] PRIMARY KEY CLUSTERED ([EmployeeRoleID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]");

            //    this.ExecuteStoreCommand("INSERT INTO EmployeeRoles (EmployeeID, RoleID, InActive) SELECT EmployeeID, 1, 0 FROM Employees WHERE EmployeeID = 1", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO EmployeeRoles (EmployeeID, RoleID, InActive) SELECT EmployeeID, 2, 0 FROM Employees WHERE EmployeeID = 1", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO EmployeeRoles (EmployeeID, RoleID, InActive) SELECT EmployeeID, 3, 0 FROM Employees WHERE EmployeeID = 1", new ObjectParameter[] { });

            //    this.ExecuteStoreCommand("INSERT INTO EmployeeRoles (EmployeeID, RoleID, InActive) SELECT EmployeeID, 2, 0 FROM Employees WHERE EmployeeID <> 1 AND (EmployeeID NOT IN(SELECT SalespersonID FROM Customers))", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO EmployeeRoles (EmployeeID, RoleID, InActive) SELECT EmployeeID, 3, 0 FROM Employees WHERE (EmployeeID IN(SELECT SalespersonID FROM Customers))", new ObjectParameter[] { });
            //}



            //if (!this.totalSmartCodingEntities.TableExists("EmployeeLocations"))
            //{

            //    this.ExecuteStoreCommand("CREATE TABLE [dbo].[EmployeeLocations]([EmployeeLocationID] [int] IDENTITY(1,1) NOT NULL, [EmployeeID] [int] NOT NULL, [LocationID] [int] NOT NULL, [InActive] [bit] NOT NULL, CONSTRAINT [PK_EmployeeLocations] PRIMARY KEY CLUSTERED ([EmployeeLocationID] ASC)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]");

            //    this.ExecuteStoreCommand("INSERT INTO EmployeeLocations (EmployeeID, LocationID, InActive) SELECT EmployeeID, LocationID, 0 FROM Employees WHERE EmployeeID <> 1 AND (EmployeeID NOT IN(SELECT SalespersonID FROM Customers))", new ObjectParameter[] { });

            //    this.ExecuteStoreCommand("INSERT INTO EmployeeLocations (EmployeeID, LocationID, InActive) SELECT EmployeeID, 1, 0 FROM Employees WHERE EmployeeID = 1 OR (EmployeeID IN(SELECT SalespersonID FROM Customers))", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO EmployeeLocations (EmployeeID, LocationID, InActive) SELECT EmployeeID, 2, 0 FROM Employees WHERE EmployeeID = 1 OR (EmployeeID IN(SELECT SalespersonID FROM Customers))", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO EmployeeLocations (EmployeeID, LocationID, InActive) SELECT EmployeeID, 3, 0 FROM Employees WHERE EmployeeID = 1 OR (EmployeeID IN(SELECT SalespersonID FROM Customers))", new ObjectParameter[] { });
            //}



            //var query = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT TOP (200) COUNT(EmployeeID) AS Expr1 FROM Employees;", new object[] { });
            //int exists = query.Cast<int>().Single();
            //if (exists == 29)
            //{
            //    this.ExecuteStoreCommand("INSERT INTO Employees (Code, Name, Title, EmployeeTypeID, LocationID) VALUES (N'EM0109', N'Ngô Thanh Hương', N'', 1, 2)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO Employees (Code, Name, Title, EmployeeTypeID, LocationID) VALUES (N'EM0110', N'Nguyễn Ngọc Trinh', N'', 1, 2)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO Employees (Code, Name, Title, EmployeeTypeID, LocationID) VALUES (N'EM0111', N'Khúc Văn Huế', N'', 1, 2)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO Employees (Code, Name, Title, EmployeeTypeID, LocationID) VALUES (N'EM0112', N'Đàm Thị Thu Hiền', N'', 1, 2)", new ObjectParameter[] { });

            //    this.ExecuteStoreCommand("INSERT INTO Employees (Code, Name, Title, EmployeeTypeID, LocationID) VALUES (N'EM0113', N'Le Thanh Nam', N'', 1, 3)", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("INSERT INTO Employees (Code, Name, Title, EmployeeTypeID, LocationID) VALUES (N'EM0114', N'Ngo Xuan Tho', N'', 1, 3)", new ObjectParameter[] { });


            //    this.ExecuteStoreCommand("UPDATE Locations SET OfficialName = N'260WH4' WHERE LocationID = 2", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("UPDATE Locations SET OfficialName = N'700WH4' WHERE LocationID = 3", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("UPDATE Locations SET OfficialName = N'500WH1' WHERE LocationID = 4", new ObjectParameter[] { });
            //}


            //query = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT TOP (200) COUNT(CommodityCategoryID) AS Expr1 FROM CommodityCategories;", new object[] { });
            //exists = query.Cast<int>().Single();
            //if (exists == 1)
            //{
            //    this.ExecuteStoreCommand("INSERT INTO CommodityCategories (Name) SELECT [Loại SP] FROM A_Commodities_ShortName GROUP BY [Loại SP] ORDER BY [Loại SP]", new ObjectParameter[] { });
            //    this.ExecuteStoreCommand("UPDATE CommodityCategories SET Name = N'Unknown' WHERE CommodityCategoryID = 2", new ObjectParameter[] { });

            //    this.ExecuteStoreCommand("UPDATE Commodities SET Commodities.CommodityCategoryID = CommodityCategories.CommodityCategoryID FROM            Commodities INNER JOIN                         A_Commodities_ShortName ON Commodities.Code = A_Commodities_ShortName.Code INNER JOIN                         CommodityCategories ON A_Commodities_ShortName.[Loại SP] = CommodityCategories.Name", new ObjectParameter[] { });
            //}




            //query = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT TOP (200) COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = 800001;", new object[] { });
            //exists = query.Cast<int>().Single();
            //if (exists == 0)
            //{
            //    this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive) VALUES(800001, 6, 'AvailableItems', 'Available Items', '#', '#', '#', 1, 60, 1, 0)", new ObjectParameter[] { });
            //}

            #endregion OLD
        }
        #endregion Backup for update log








































        #region Base Repository

        public int? GetStoredID(int configID)
        {
            return this.TotalSmartCodingEntities.GetStoredID(configID).Single();
        }

        public int? GetVersionID(int configID)
        {
            return this.TotalSmartCodingEntities.GetVersionID(configID).Single();
        }

        public bool VersionValidate(int configID, int configVersionID)
        {
            int? versionID = this.GetVersionID(configID);
            if (versionID == null || (int)versionID != configVersionID) throw new Exception("This program on your computer is not the latest version." + "\r\n" + "\r\n" + "Please exit and re-open your program again in order to update new version." + "\r\n" + "Contact your admin for more information. Thank you!" + "\r\n" + "\r\n" + "Phần mềm vừa được cập nhật phiên bản mới." + "\r\n" + "Vui lòng đóng và sau đó mở lại phần mềm để cập nhật phiên bản mới nhất. Cám ơn.");
            return true;
        }

        public int GetModuleID(GlobalEnums.NmvnTaskID nmvnTaskID)
        {
            var moduleDetail = this.totalSmartCodingEntities.ModuleDetails.Where(w => w.ModuleDetailID == (int)nmvnTaskID).FirstOrDefault();
            return moduleDetail != null ? moduleDetail.ModuleID : 0;
        }

        /// <summary>
        ///     Detect whether the context is dirty (i.e., there are changes in entities in memory that have
        ///     not yet been saved to the database).
        /// </summary>
        /// <param name="context">The database context to check.</param>
        /// <returns>True if dirty (unsaved changes); false otherwise.</returns>
        public bool IsDirty()
        {
            //Contract.Requires<ArgumentNullException>(context != null);

            // Query the change tracker entries for any adds, modifications, or deletes.
            IEnumerable<DbEntityEntry> res = from e in this.totalSmartCodingEntities.ChangeTracker.Entries()
                                             where e.State.HasFlag(EntityState.Added) ||
                                                 e.State.HasFlag(EntityState.Modified) ||
                                                 e.State.HasFlag(EntityState.Deleted)
                                             select e;

            var myTestOnly = res.ToList();

            if (res.Any())
                return true;

            return false;
        }


        public virtual ICollection<TElement> ExecuteFunction<TElement>(string functionName, params ObjectParameter[] parameters)
        {
            this.TotalBikePortalsObjectContext.CommandTimeout = 300;
            var objectResult = this.TotalBikePortalsObjectContext.ExecuteFunction<TElement>(functionName, parameters);

            return objectResult.ToList<TElement>();
        }

        public virtual int ExecuteFunction(string functionName, params ObjectParameter[] parameters)
        {
            this.TotalBikePortalsObjectContext.CommandTimeout = 300;
            return this.TotalBikePortalsObjectContext.ExecuteFunction(functionName, parameters);
        }

        public virtual int ExecuteStoreCommand(string commandText, params Object[] parameters)
        {
            this.TotalBikePortalsObjectContext.CommandTimeout = 300;
            return this.TotalBikePortalsObjectContext.ExecuteStoreCommand(commandText, parameters);
        }




        public T GetEntity<T>(bool proxyCreationEnabled, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (!proxyCreationEnabled) this.totalSmartCodingEntities.Configuration.ProxyCreationEnabled = false;


            IQueryable<T> result = this.totalSmartCodingEntities.Set<T>();

            if (includes != null && includes.Any())
                result = includes.Aggregate(result, (current, include) => current.Include(include));


            T entity = null;

            if (predicate != null)
                entity = result.FirstOrDefault(predicate);
            else
                entity = result.FirstOrDefault();


            if (!proxyCreationEnabled) this.totalSmartCodingEntities.Configuration.ProxyCreationEnabled = true;


            return entity;
        }


        public T GetEntity<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class
        {
            return this.GetEntity<T>(true, predicate, includes);
        }

        public T GetEntity<T>(bool proxyCreationEnabled, params Expression<Func<T, object>>[] includes) where T : class
        {
            return this.GetEntity<T>(proxyCreationEnabled, null, includes);
        }

        public T GetEntity<T>(params Expression<Func<T, object>>[] includes) where T : class
        {
            return this.GetEntity<T>(null, includes);
        }






        public ICollection<T> GetEntities<T>(bool proxyCreationEnabled, Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class
        {
            if (!proxyCreationEnabled) this.totalSmartCodingEntities.Configuration.ProxyCreationEnabled = false;


            IQueryable<T> result = this.totalSmartCodingEntities.Set<T>();

            if (includes != null && includes.Any())
                result = includes.Aggregate(result, (current, include) => current.Include(include));

            ICollection<T> entities = null;

            if (predicate != null)
                entities = result.Where(predicate).ToList();
            else
                entities = result.ToList();



            if (!proxyCreationEnabled) this.totalSmartCodingEntities.Configuration.ProxyCreationEnabled = true;

            return entities;

        }

        public ICollection<T> GetEntities<T>(Expression<Func<T, bool>> predicate, params Expression<Func<T, object>>[] includes) where T : class
        {
            return this.GetEntities<T>(true, predicate, includes);
        }

        public ICollection<T> GetEntities<T>(bool proxyCreationEnabled, params Expression<Func<T, object>>[] includes) where T : class
        {
            return this.GetEntities<T>(proxyCreationEnabled, null, includes);
        }

        public ICollection<T> GetEntities<T>(params Expression<Func<T, object>>[] includes) where T : class
        {
            return this.GetEntities<T>(null, includes);
        }


        public string RepositoryTag { get; set; }
        public Dictionary<string, object> RepositoryBag { get; set; }



        #endregion Base Repository


    }
}

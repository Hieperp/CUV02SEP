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
using TotalModel.Helpers;
using TotalModel.Models;
using TotalCore.Extensions;
using TotalCore.Repositories;
using TotalDAL.Repositories.Generals;


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

                this.ExecuteStoreCommand("EXEC SubmitUserAccessControls", new ObjectParameter[] { });
            }


            return this.GetStoredID(GlobalVariables.ConfigID) == GlobalVariables.MaxConfigVersionID();
        }

        public void UpdateDatabases(bool restoreProcedures)
        {
            if (restoreProcedures)
            {
                this.totalSmartCodingEntities.ColumnAdd("Configs", "StoredID", "int", "0", true);
            }

            //UPDATE VERSION: ADD UPDATE DATABASE HERE IF NEEDED
            #region ApplicationUsers
            if (!this.totalSmartCodingEntities.TableExists("ApplicationUsers"))
            {
                this.ExecuteStoreCommand(@"CREATE TABLE [dbo].[ApplicationUsers](
	                                                    [ApplicationUserID] [int] NOT NULL,
	                                                    [Name] [nvarchar](100) NOT NULL,
	                                                    [Password] [nvarchar](100) NOT NULL,
	                                                    [EditedDate] [datetime] NOT NULL,
                                                     CONSTRAINT [PK_ApplicationUsers] PRIMARY KEY CLUSTERED 
                                                    (
	                                                    [ApplicationUserID] ASC
                                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                    ) ON [PRIMARY]
                                                ", new ObjectParameter[] { });
            }
            #endregion ApplicationUsers

        }


        private bool RestoreProcedures()
        {
            //this.ExecuteStoreCommand("DELETE FROM ConfigLogs", new ObjectParameter[] { });
            //this.ExecuteStoreCommand("INSERT INTO ConfigLogs (EntryDate, ProcedureName, Remarks) SELECT GetDate(), N'START UPDATE OF VSERION " + +GlobalVariables.MaxConfigVersionID() + "', N'' ", new ObjectParameter[] { });

            this.CreateStoredProcedure();

            //SET LASTEST VERSION AFTER RESTORE SUCCESSFULL
            this.ExecuteStoreCommand("UPDATE Configs SET StoredID = " + GlobalVariables.MaxConfigVersionID() + ", VersionDate = GETDATE() WHERE StoredID < " + GlobalVariables.MaxConfigVersionID(), new ObjectParameter[] { });

            //this.ExecuteStoreCommand("INSERT INTO ConfigLogs (EntryDate, ProcedureName, Remarks) SELECT GetDate(), N'FINISH UPDATE OF VSERION " + +GlobalVariables.MaxConfigVersionID() + "', N'' ", new ObjectParameter[] { });

            return true;
        }


        private void CreateStoredProcedure()
        {
            //return;

            Helpers.SqlProgrammability.Commons.AccessControl accessControl = new Helpers.SqlProgrammability.Commons.AccessControl(totalSmartCodingEntities);
            accessControl.RestoreProcedure();

            return;

            Helpers.SqlProgrammability.Inventories.Inventory inventory = new Helpers.SqlProgrammability.Inventories.Inventory(totalSmartCodingEntities);
            inventory.RestoreProcedure();

            return;
            return;

            Helpers.SqlProgrammability.Commons.Employee employee = new Helpers.SqlProgrammability.Commons.Employee(totalSmartCodingEntities);
            employee.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.BinLocation binLocation = new Helpers.SqlProgrammability.Commons.BinLocation(totalSmartCodingEntities);
            binLocation.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.Commodity commodity = new Helpers.SqlProgrammability.Commons.Commodity(totalSmartCodingEntities);
            commodity.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.CommoditySetting commoditySetting = new Helpers.SqlProgrammability.Commons.CommoditySetting(totalSmartCodingEntities);
            commoditySetting.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.Customer customer = new Helpers.SqlProgrammability.Commons.Customer(totalSmartCodingEntities);
            customer.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Generals.Module module = new Helpers.SqlProgrammability.Generals.Module(totalSmartCodingEntities);
            module.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.Team team = new Helpers.SqlProgrammability.Commons.Team(totalSmartCodingEntities);
            team.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.CommodityCategory commodityCategory = new Helpers.SqlProgrammability.Commons.CommodityCategory(totalSmartCodingEntities);
            commodityCategory.RestoreProcedure();

            //return;
            Helpers.SqlProgrammability.Commons.CommodityType commodityType = new Helpers.SqlProgrammability.Commons.CommodityType(totalSmartCodingEntities);
            commodityType.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.Territory territory = new Helpers.SqlProgrammability.Commons.Territory(totalSmartCodingEntities);
            territory.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.CustomerCategory customerCategory = new Helpers.SqlProgrammability.Commons.CustomerCategory(totalSmartCodingEntities);
            customerCategory.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.CustomerType customerType = new Helpers.SqlProgrammability.Commons.CustomerType(totalSmartCodingEntities);
            customerType.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.FillingLine fillingLine = new Helpers.SqlProgrammability.Commons.FillingLine(totalSmartCodingEntities);
            fillingLine.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.Warehouse warehouse = new Helpers.SqlProgrammability.Commons.Warehouse(totalSmartCodingEntities);
            warehouse.RestoreProcedure();

            //return;
            //!!!!!!!!!!!!!!!!!!!!!!!!!ANY STORED CALL SubmitUserAccessControls: MUST BY RESTORE AFTER THIS!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            Helpers.SqlProgrammability.Generals.UserGroupControl userGroupControl = new Helpers.SqlProgrammability.Generals.UserGroupControl(totalSmartCodingEntities);
            userGroupControl.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Generals.UserReference userReference = new Helpers.SqlProgrammability.Generals.UserReference(totalSmartCodingEntities);
            userReference.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Generals.UserControl userControl = new Helpers.SqlProgrammability.Generals.UserControl(totalSmartCodingEntities);
            userControl.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Commons.SmartLog smartLog = new Helpers.SqlProgrammability.Commons.SmartLog(totalSmartCodingEntities);
            smartLog.RestoreProcedure();






            //return;

            Helpers.SqlProgrammability.Generals.UserGroup userGroup = new Helpers.SqlProgrammability.Generals.UserGroup(totalSmartCodingEntities);
            userGroup.RestoreProcedure();


            //return;

            Helpers.SqlProgrammability.Productions.Batch batch = new Helpers.SqlProgrammability.Productions.Batch(totalSmartCodingEntities);
            batch.RestoreProcedure();






            //return;
            Helpers.SqlProgrammability.Generals.Report report = new Helpers.SqlProgrammability.Generals.Report(totalSmartCodingEntities);
            report.RestoreProcedure();

            //return;

            Helpers.SqlProgrammability.Inventories.GoodsReceipt goodsReceipt = new Helpers.SqlProgrammability.Inventories.GoodsReceipt(totalSmartCodingEntities);
            goodsReceipt.RestoreProcedure();

            return;

            return;

            Helpers.SqlProgrammability.Commons.Location location = new Helpers.SqlProgrammability.Commons.Location(totalSmartCodingEntities);
            location.RestoreProcedure();





            //return;

            Helpers.SqlProgrammability.Generals.OrganizationalUnit organizationalUnit = new Helpers.SqlProgrammability.Generals.OrganizationalUnit(totalSmartCodingEntities);
            organizationalUnit.RestoreProcedure();










            return;
            return;

            Helpers.SqlProgrammability.Sales.Forecast forecast = new Helpers.SqlProgrammability.Sales.Forecast(totalSmartCodingEntities);
            forecast.RestoreProcedure();





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

            Helpers.SqlProgrammability.Generals.OleDb oleDb = new Helpers.SqlProgrammability.Generals.OleDb(totalSmartCodingEntities);
            oleDb.RestoreProcedure();








































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


        public void UpdateUserControls()
        {
            //CLEAR InActive
            this.ExecuteStoreCommand("UPDATE      Users                       SET InActive = 0, FirstName = N'', LastName = N'' ", new ObjectParameter[] { });
            this.ExecuteStoreCommand("UPDATE      AccessControls              SET InActive = 0", new ObjectParameter[] { });
            this.ExecuteStoreCommand("UPDATE      OrganizationalUnitUsers     SET InActive = 0, InActiveDate = GetDate()", new ObjectParameter[] { });

            //this.ExecuteStoreCommand("UPDATE      AccessControls              SET AccessLevel = 0, ApprovalPermitted = 0, UnApprovalPermitted = 0, VoidablePermitted = 0, UnVoidablePermitted = 0, ShowDiscount = 0 ", new ObjectParameter[] { });


            //ADD ALL LOCATION
            UserAPIRepository userAPIRepository = new UserAPIRepository(this.totalSmartCodingEntities);
            userAPIRepository.RepositoryBag["ActiveOption"] = (int)GlobalEnums.ActiveOption.Both;
            List<UserIndex> userIndexes = userAPIRepository.GetEntityIndexes<UserIndex>(ContextAttributes.User.UserID, GlobalEnums.GlobalOptionSetting.LowerFillterDate, GlobalEnums.GlobalOptionSetting.UpperFillterDate).ToList();


            List<Location> locations = this.TotalSmartCodingEntities.Locations.ToList();
            List<OrganizationalUnit> organizationalUnits = this.totalSmartCodingEntities.OrganizationalUnits.ToList();
            List<User> users = this.totalSmartCodingEntities.Users.GroupBy(x => x.SecurityIdentifier).Select(x => x.FirstOrDefault()).ToList();
            foreach (User user in users)
            {
                foreach (Location location in locations)
                {
                    UserIndex finduserIndex = userIndexes.Find(w => w.SecurityIdentifier == user.SecurityIdentifier && w.LocationID == location.LocationID);
                    if (finduserIndex == null)
                        userAPIRepository.UserRegister(location.LocationID, organizationalUnits.Where(w => w.LocationID == location.LocationID).FirstOrDefault().OrganizationalUnitID, user.FirstName, user.LastName, user.UserName, user.SecurityIdentifier, 0, 0, 0);
                }
            }


            this.ExecuteStoreCommand("UPDATE Users SET IsDatabaseAdmin = 1 WHERE SecurityIdentifier IN (SELECT SecurityIdentifier FROM Users WHERE IsDatabaseAdmin = 1) ", new ObjectParameter[] { });
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



            #region GlobalVariables.ConfigID = 85: CORRECT VOLUME FOR LINE 4LITTRES
            if (this.GetStoredID(GlobalVariables.ConfigID) < GlobalVariables.MaxConfigVersionID())
            {
                //////////GlobalVariables.ConfigID = 85
                //////////this.ExecuteStoreCommand("UPDATE Cartons SET Cartons.LineVolume = ROUND(Cartons.Quantity * Commodities.PackageVolume, 2) FROM Cartons INNER JOIN Commodities ON Cartons.CommodityID = Commodities.CommodityID WHERE Cartons.CommodityID IN (SELECT CommodityID FROM Batches WHERE FillingLineID >= 4)", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE Pallets SET Pallets.LineVolume = ROUND(Pallets.Quantity * Commodities.PackageVolume, 2) FROM Pallets INNER JOIN Commodities ON Pallets.CommodityID = Commodities.CommodityID WHERE Pallets.CommodityID IN (SELECT CommodityID FROM Batches WHERE FillingLineID >= 4)", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE Pallets SET Pallets.LineVolumePickup = ROUND(Pallets.QuantityPickup * Commodities.PackageVolume, 2) FROM Pallets INNER JOIN Commodities ON Pallets.CommodityID = Commodities.CommodityID WHERE Pallets.CommodityID IN (SELECT CommodityID FROM Batches WHERE FillingLineID >= 4)", new ObjectParameter[] { });

                //////////this.ExecuteStoreCommand("UPDATE DeliveryAdviceDetails SET DeliveryAdviceDetails.LineVolume = ROUND(DeliveryAdviceDetails.Quantity * Commodities.PackageVolume, 2) FROM DeliveryAdviceDetails INNER JOIN Commodities ON DeliveryAdviceDetails.CommodityID = Commodities.CommodityID WHERE DeliveryAdviceDetails.CommodityID IN (SELECT CommodityID FROM Batches WHERE FillingLineID >= 4)", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE GoodsIssueDetails SET GoodsIssueDetails.LineVolume = ROUND(GoodsIssueDetails.Quantity * Commodities.PackageVolume, 2) FROM GoodsIssueDetails INNER JOIN Commodities ON GoodsIssueDetails.CommodityID = Commodities.CommodityID WHERE GoodsIssueDetails.CommodityID IN (SELECT CommodityID FROM Batches WHERE FillingLineID >= 4)", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE GoodsIssueTransferDetails SET GoodsIssueTransferDetails.LineVolume = ROUND(GoodsIssueTransferDetails.Quantity * Commodities.PackageVolume, 2) FROM GoodsIssueTransferDetails INNER JOIN Commodities ON GoodsIssueTransferDetails.CommodityID = Commodities.CommodityID WHERE GoodsIssueTransferDetails.CommodityID IN (SELECT CommodityID FROM Batches WHERE FillingLineID >= 4)", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE GoodsReceiptDetails SET GoodsReceiptDetails.LineVolume = ROUND(GoodsReceiptDetails.Quantity * Commodities.PackageVolume, 2) FROM GoodsReceiptDetails INNER JOIN Commodities ON GoodsReceiptDetails.CommodityID = Commodities.CommodityID WHERE GoodsReceiptDetails.CommodityID IN (SELECT CommodityID FROM Batches WHERE FillingLineID >= 4)", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE PickupDetails SET PickupDetails.LineVolume = ROUND(PickupDetails.Quantity * Commodities.PackageVolume, 2) FROM PickupDetails INNER JOIN Commodities ON PickupDetails.CommodityID = Commodities.CommodityID WHERE PickupDetails.CommodityID IN (SELECT CommodityID FROM Batches WHERE FillingLineID >= 4)", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE SalesOrderDetails SET SalesOrderDetails.LineVolume = ROUND(SalesOrderDetails.Quantity * Commodities.PackageVolume, 2) FROM SalesOrderDetails INNER JOIN Commodities ON SalesOrderDetails.CommodityID = Commodities.CommodityID WHERE SalesOrderDetails.CommodityID IN (SELECT CommodityID FROM Batches WHERE FillingLineID >= 4)", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE TransferOrderDetails SET TransferOrderDetails.LineVolume = ROUND(TransferOrderDetails.Quantity * Commodities.PackageVolume, 2) FROM TransferOrderDetails INNER JOIN Commodities ON TransferOrderDetails.CommodityID = Commodities.CommodityID WHERE TransferOrderDetails.CommodityID IN (SELECT CommodityID FROM Batches WHERE FillingLineID >= 4)", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE WarehouseAdjustmentDetails SET WarehouseAdjustmentDetails.LineVolume = ROUND(WarehouseAdjustmentDetails.Quantity * Commodities.PackageVolume, 2) FROM WarehouseAdjustmentDetails INNER JOIN Commodities ON WarehouseAdjustmentDetails.CommodityID = Commodities.CommodityID WHERE WarehouseAdjustmentDetails.CommodityID IN (SELECT CommodityID FROM Batches WHERE FillingLineID >= 4)", new ObjectParameter[] { });

                //////////this.ExecuteStoreCommand("UPDATE DeliveryAdviceDetails SET DeliveryAdviceDetails.LineVolumeIssue = ROUND(DeliveryAdviceDetails.QuantityIssue * Commodities.PackageVolume, 2) FROM DeliveryAdviceDetails INNER JOIN Commodities ON DeliveryAdviceDetails.CommodityID = Commodities.CommodityID WHERE DeliveryAdviceDetails.CommodityID IN (SELECT CommodityID FROM Batches WHERE FillingLineID >= 4)", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE GoodsReceiptDetails SET GoodsReceiptDetails.LineVolumeIssue = ROUND(GoodsReceiptDetails.QuantityIssue * Commodities.PackageVolume, 2) FROM GoodsReceiptDetails INNER JOIN Commodities ON GoodsReceiptDetails.CommodityID = Commodities.CommodityID WHERE GoodsReceiptDetails.CommodityID IN (SELECT CommodityID FROM Batches WHERE FillingLineID >= 4)", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE GoodsIssueTransferDetails SET GoodsIssueTransferDetails.LineVolumeReceipt = ROUND(GoodsIssueTransferDetails.QuantityReceipt * Commodities.PackageVolume, 2) FROM GoodsIssueTransferDetails INNER JOIN Commodities ON GoodsIssueTransferDetails.CommodityID = Commodities.CommodityID WHERE GoodsIssueTransferDetails.CommodityID IN (SELECT CommodityID FROM Batches WHERE FillingLineID >= 4)", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE PickupDetails SET PickupDetails.LineVolumeReceipt = ROUND(PickupDetails.QuantityReceipt * Commodities.PackageVolume, 2) FROM PickupDetails INNER JOIN Commodities ON PickupDetails.CommodityID = Commodities.CommodityID WHERE PickupDetails.CommodityID IN (SELECT CommodityID FROM Batches WHERE FillingLineID >= 4)", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE SalesOrderDetails SET SalesOrderDetails.LineVolumeAdvice = ROUND(SalesOrderDetails.QuantityAdvice * Commodities.PackageVolume, 2) FROM SalesOrderDetails INNER JOIN Commodities ON SalesOrderDetails.CommodityID = Commodities.CommodityID WHERE SalesOrderDetails.CommodityID IN (SELECT CommodityID FROM Batches WHERE FillingLineID >= 4)", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE TransferOrderDetails SET TransferOrderDetails.LineVolumeIssue = ROUND(TransferOrderDetails.QuantityIssue * Commodities.PackageVolume, 2) FROM TransferOrderDetails INNER JOIN Commodities ON TransferOrderDetails.CommodityID = Commodities.CommodityID WHERE TransferOrderDetails.CommodityID IN (SELECT CommodityID FROM Batches WHERE FillingLineID >= 4)", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE WarehouseAdjustmentDetails SET WarehouseAdjustmentDetails.LineVolumeReceipt = ROUND(WarehouseAdjustmentDetails.QuantityReceipt * Commodities.PackageVolume, 2) FROM WarehouseAdjustmentDetails INNER JOIN Commodities ON WarehouseAdjustmentDetails.CommodityID = Commodities.CommodityID WHERE WarehouseAdjustmentDetails.CommodityID IN (SELECT CommodityID FROM Batches WHERE FillingLineID >= 4)", new ObjectParameter[] { });



                //////////this.ExecuteStoreCommand("UPDATE DeliveryAdvices SET TotalLineVolume = ROUND(DeliveryAdviceDetails_A.TotalLineVolume, 2) FROM DeliveryAdvices INNER JOIN (SELECT DeliveryAdviceID, SUM(LineVolume) AS TotalLineVolume FROM DeliveryAdviceDetails WHERE DeliveryAdviceID IN (SELECT DeliveryAdviceID FROM DeliveryAdviceDetails WHERE CommodityID IN (SELECT CommodityID FROM Batches WHERE (FillingLineID >= 4))) GROUP BY DeliveryAdviceID) AS DeliveryAdviceDetails_A ON DeliveryAdvices.DeliveryAdviceID = DeliveryAdviceDetails_A.DeliveryAdviceID", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE GoodsIssues SET TotalLineVolume = ROUND(GoodsIssueDetails_A.TotalLineVolume, 2) FROM GoodsIssues INNER JOIN (SELECT GoodsIssueID, SUM(LineVolume) AS TotalLineVolume FROM GoodsIssueDetails WHERE GoodsIssueID IN (SELECT GoodsIssueID FROM GoodsIssueDetails WHERE CommodityID IN (SELECT CommodityID FROM Batches WHERE (FillingLineID >= 4))) GROUP BY GoodsIssueID) AS GoodsIssueDetails_A ON GoodsIssues.GoodsIssueID = GoodsIssueDetails_A.GoodsIssueID", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE GoodsReceipts SET TotalLineVolume = ROUND(GoodsReceiptDetails_A.TotalLineVolume, 2) FROM GoodsReceipts INNER JOIN (SELECT GoodsReceiptID, SUM(LineVolume) AS TotalLineVolume FROM GoodsReceiptDetails WHERE GoodsReceiptID IN (SELECT GoodsReceiptID FROM GoodsReceiptDetails WHERE CommodityID IN (SELECT CommodityID FROM Batches WHERE (FillingLineID >= 4))) GROUP BY GoodsReceiptID) AS GoodsReceiptDetails_A ON GoodsReceipts.GoodsReceiptID = GoodsReceiptDetails_A.GoodsReceiptID", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE Pickups SET TotalLineVolume = ROUND(PickupDetails_A.TotalLineVolume, 2) FROM Pickups INNER JOIN (SELECT PickupID, SUM(LineVolume) AS TotalLineVolume FROM PickupDetails WHERE PickupID IN (SELECT PickupID FROM PickupDetails WHERE CommodityID IN (SELECT CommodityID FROM Batches WHERE (FillingLineID >= 4))) GROUP BY PickupID) AS PickupDetails_A ON Pickups.PickupID = PickupDetails_A.PickupID", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE SalesOrders SET TotalLineVolume = ROUND(SalesOrderDetails_A.TotalLineVolume, 2) FROM SalesOrders INNER JOIN (SELECT SalesOrderID, SUM(LineVolume) AS TotalLineVolume FROM SalesOrderDetails WHERE SalesOrderID IN (SELECT SalesOrderID FROM SalesOrderDetails WHERE CommodityID IN (SELECT CommodityID FROM Batches WHERE (FillingLineID >= 4))) GROUP BY SalesOrderID) AS SalesOrderDetails_A ON SalesOrders.SalesOrderID = SalesOrderDetails_A.SalesOrderID", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE TransferOrders SET TotalLineVolume = ROUND(TransferOrderDetails_A.TotalLineVolume, 2) FROM TransferOrders INNER JOIN (SELECT TransferOrderID, SUM(LineVolume) AS TotalLineVolume FROM TransferOrderDetails WHERE TransferOrderID IN (SELECT TransferOrderID FROM TransferOrderDetails WHERE CommodityID IN (SELECT CommodityID FROM Batches WHERE (FillingLineID >= 4))) GROUP BY TransferOrderID) AS TransferOrderDetails_A ON TransferOrders.TransferOrderID = TransferOrderDetails_A.TransferOrderID", new ObjectParameter[] { });
                //////////this.ExecuteStoreCommand("UPDATE WarehouseAdjustments SET TotalLineVolume = ROUND(WarehouseAdjustmentDetails_A.TotalLineVolume, 2) FROM WarehouseAdjustments INNER JOIN (SELECT WarehouseAdjustmentID, SUM(LineVolume) AS TotalLineVolume FROM WarehouseAdjustmentDetails WHERE WarehouseAdjustmentID IN (SELECT WarehouseAdjustmentID FROM WarehouseAdjustmentDetails WHERE CommodityID IN (SELECT CommodityID FROM Batches WHERE (FillingLineID >= 4))) GROUP BY WarehouseAdjustmentID) AS WarehouseAdjustmentDetails_A ON WarehouseAdjustments.WarehouseAdjustmentID = WarehouseAdjustmentDetails_A.WarehouseAdjustmentID", new ObjectParameter[] { });
            }
            #endregion GlobalVariables.ConfigID = 85: CORRECT VOLUME FOR LINE 4LITTRES


            #region FINAL06NOV2018
            if (!this.totalSmartCodingEntities.ColumnExists("Customers", "ParentID"))
            {
                this.totalSmartCodingEntities.ColumnAdd("Customers", "ParentID", "int", null, false);

                this.ExecuteStoreCommand(@"ALTER TABLE [dbo].[Customers]  WITH CHECK ADD  CONSTRAINT [FK_Customers_Customers] FOREIGN KEY([ParentID])
                                            REFERENCES [dbo].[Customers] ([CustomerID])                                      
                                            ", new ObjectParameter[] { });

                this.ExecuteStoreCommand(@"ALTER TABLE [dbo].[Customers] CHECK CONSTRAINT [FK_Customers_Customers]", new ObjectParameter[] { });





            }

            #region UPDATE ParentID
            if (!this.totalSmartCodingEntities.TableExists("A_Customer_Receivers"))
            {
                this.ExecuteStoreCommand(@"CREATE TABLE [dbo].[A_Customer_Receivers](
	                                                    [AutoID] [float] NOT NULL,
	                                                    [PID] [float] NULL,
	                                                    [CID] [float] NULL,
	                                                    [ParentID] [nvarchar](255) NULL,
	                                                    [CustomerID] [nvarchar](255) NULL,
                                                     CONSTRAINT [PK_A_Customer_Receivers] PRIMARY KEY CLUSTERED 
                                                    (
	                                                    [AutoID] ASC
                                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                    ) ON [PRIMARY]

                                                ", new ObjectParameter[] { });


                this.ExecuteStoreCommand(@"

                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (1, 7989701, 7990021, N'7989701', N'7990021')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (2, 7989701, 7990022, N'7989701', N'7990022')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (3, 7989701, 7990023, N'7989701', N'7990023')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (4, 7989701, 7990024, N'7989701', N'7990024')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (5, 7989701, 7990025, N'7989701', N'7990025')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (6, 7989701, 7990026, N'7989701', N'7990026')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (7, 7989701, 7990027, N'7989701', N'7990027')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (8, 7989701, 7990028, N'7989701', N'7990028')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (9, 7989701, 7990029, N'7989701', N'7990029')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (10, 7989701, 7990030, N'7989701', N'7990030')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (11, 7989701, 7990031, N'7989701', N'7990031')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (12, 7989701, 7990032, N'7989701', N'7990032')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (13, 7989701, 7990033, N'7989701', N'7990033')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (14, 7989701, 7990034, N'7989701', N'7990034')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (15, 7989701, 7990035, N'7989701', N'7990035')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (16, 7989701, 7990036, N'7989701', N'7990036')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (17, 7989701, 7990037, N'7989701', N'7990037')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (18, 7989701, 7990038, N'7989701', N'7990038')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (19, 7989701, 7990039, N'7989701', N'7990039')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (20, 7989701, 7990040, N'7989701', N'7990040')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (21, 7989701, 7990041, N'7989701', N'7990041')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (22, 7989701, 7990042, N'7989701', N'7990042')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (23, 7989701, 7990043, N'7989701', N'7990043')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (24, 7989701, 7990044, N'7989701', N'7990044')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (25, 7989701, 7990045, N'7989701', N'7990045')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (26, 7989701, 7990046, N'7989701', N'7990046')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (27, 7989701, 7990047, N'7989701', N'7990047')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (28, 7989701, 7990048, N'7989701', N'7990048')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (29, 7989701, 7990049, N'7989701', N'7990049')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (30, 7989701, 7990050, N'7989701', N'7990050')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (31, 7989701, 7990051, N'7989701', N'7990051')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (32, 7989701, 7990052, N'7989701', N'7990052')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (33, 7989701, 7990053, N'7989701', N'7990053')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (34, 7989701, 7990054, N'7989701', N'7990054')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (35, 7989701, 7990055, N'7989701', N'7990055')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (36, 7989701, 7990056, N'7989701', N'7990056')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (37, 7989701, 7990057, N'7989701', N'7990057')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (38, 7989701, 7990058, N'7989701', N'7990058')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (39, 7989701, 7990059, N'7989701', N'7990059')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (40, 7989701, 7990060, N'7989701', N'7990060')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (41, 7989701, 7990061, N'7989701', N'7990061')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (42, 7989701, 7990062, N'7989701', N'7990062')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (43, 7989701, 7990063, N'7989701', N'7990063')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (44, 7989701, 7990064, N'7989701', N'7990064')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (45, 7989701, 7990065, N'7989701', N'7990065')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (46, 7989701, 7990066, N'7989701', N'7990066')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (47, 7989701, 7990067, N'7989701', N'7990067')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (48, 7989701, 7990068, N'7989701', N'7990068')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (49, 7989701, 7990069, N'7989701', N'7990069')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (50, 7989701, 7990070, N'7989701', N'7990070')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (51, 7989701, 7990071, N'7989701', N'7990071')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (52, 7989701, 7990072, N'7989701', N'7990072')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (53, 7989701, 7990073, N'7989701', N'7990073')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (54, 7989701, 7990074, N'7989701', N'7990074')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (55, 7989738, 7990075, N'7989738', N'7990075')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (56, 7989738, 7990076, N'7989738', N'7990076')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (57, 7989738, 7990077, N'7989738', N'7990077')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (58, 7989738, 7990078, N'7989738', N'7990078')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (59, 7989738, 7990079, N'7989738', N'7990079')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (60, 7989760, 7990164, N'7989760', N'7990164')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (61, 7989760, 7990165, N'7989760', N'7990165')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (62, 7989760, 7990166, N'7989760', N'7990166')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (63, 7989760, 7990167, N'7989760', N'7990167')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (64, 7989760, 7990168, N'7989760', N'7990168')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (65, 7989760, 7990169, N'7989760', N'7990169')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (66, 7989760, 7990170, N'7989760', N'7990170')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (67, 7989760, 7990171, N'7989760', N'7990171')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (68, 7989760, 7990172, N'7989760', N'7990172')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (69, 7989760, 7990173, N'7989760', N'7990173')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (70, 7989760, 7990174, N'7989760', N'7990174')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (71, 7989760, 7990175, N'7989760', N'7990175')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (72, 7989760, 7990176, N'7989760', N'7990176')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (73, 7989760, 7990177, N'7989760', N'7990177')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (74, 7989760, 7990178, N'7989760', N'7990178')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (75, 7989760, 7990179, N'7989760', N'7990179')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (76, 7989760, 7990180, N'7989760', N'7990180')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (77, 7989760, 7990181, N'7989760', N'7990181')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (78, 7989760, 7990182, N'7989760', N'7990182')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (79, 7989760, 7990183, N'7989760', N'7990183')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (80, 7989725, 7990184, N'7989725', N'7990184')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (81, 7989725, 7990185, N'7989725', N'7990185')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (82, 7989717, 7990186, N'7989717', N'7990186')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (83, 7989717, 7990187, N'7989717', N'7990187')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (84, 7989717, 7990188, N'7989717', N'7990188')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (85, 7989717, 7990189, N'7989717', N'7990189')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (86, 7989717, 7990190, N'7989717', N'7990190')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (87, 7989717, 7990191, N'7989717', N'7990191')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (88, 7989717, 7990192, N'7989717', N'7990192')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (89, 7989717, 7990193, N'7989717', N'7990193')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (90, 7989717, 7990194, N'7989717', N'7990194')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (91, 7989704, 7990195, N'7989704', N'7990195')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (92, 7989704, 7990196, N'7989704', N'7990196')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (93, 7989704, 7990197, N'7989704', N'7990197')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (94, 7989717, 7990198, N'7989717', N'7990198')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (95, 7989717, 7990199, N'7989717', N'7990199')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (96, 7989717, 7990200, N'7989717', N'7990200')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (97, 7989717, 7990201, N'7989717', N'7990201')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (98, 7989717, 7990202, N'7989717', N'7990202')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (99, 7989717, 7990203, N'7989717', N'7990203')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (100, 7989776, 7990204, N'7989776', N'7990204')
                                            
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (101, 7989776, 7990205, N'7989776', N'7990205')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (102, 7989776, 7990206, N'7989776', N'7990206')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (103, 7989776, 7990207, N'7989776', N'7990207')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (104, 7989776, 7990208, N'7989776', N'7990208')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (105, 7989776, 7990209, N'7989776', N'7990209')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (106, 7989776, 7990210, N'7989776', N'7990210')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (107, 7989776, 7990211, N'7989776', N'7990211')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (108, 7989776, 7990212, N'7989776', N'7990212')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (109, 7989776, 7990213, N'7989776', N'7990213')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (110, 7989776, 7990214, N'7989776', N'7990214')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (111, 7989776, 7990215, N'7989776', N'7990215')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (112, 7989776, 7990216, N'7989776', N'7990216')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (113, 7989776, 7990217, N'7989776', N'7990217')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (114, 7989776, 7990218, N'7989776', N'7990218')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (115, 7989722, 7990219, N'7989722', N'7990219')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (116, 7989722, 7990220, N'7989722', N'7990220')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (117, 7989722, 7990221, N'7989722', N'7990221')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (118, 7989722, 7990222, N'7989722', N'7990222')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (119, 7989722, 7990223, N'7989722', N'7990223')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (120, 7989722, 7990224, N'7989722', N'7990224')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (121, 7989722, 7990225, N'7989722', N'7990225')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (122, 7989722, 7990226, N'7989722', N'7990226')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (123, 7989722, 7990227, N'7989722', N'7990227')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (124, 7989722, 7990228, N'7989722', N'7990228')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (125, 7989722, 7990229, N'7989722', N'7990229')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (126, 7989722, 7990230, N'7989722', N'7990230')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (127, 7989722, 7990231, N'7989722', N'7990231')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (128, 7989722, 7990232, N'7989722', N'7990232')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (129, 7989722, 7990233, N'7989722', N'7990233')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (130, 7989742, 7990234, N'7989742', N'7990234')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (131, 7989742, 7990235, N'7989742', N'7990235')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (132, 7989742, 7990236, N'7989742', N'7990236')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (133, 7989742, 7990237, N'7989742', N'7990237')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (134, 7989742, 7990238, N'7989742', N'7990238')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (135, 7989742, 7990239, N'7989742', N'7990239')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (136, 7989742, 7990240, N'7989742', N'7990240')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (137, 7989742, 7990241, N'7989742', N'7990241')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (138, 7989742, 7990242, N'7989742', N'7990242')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (139, 7989742, 7990243, N'7989742', N'7990243')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (140, 7989742, 7990244, N'7989742', N'7990244')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (141, 7989742, 7990245, N'7989742', N'7990245')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (142, 7989742, 7990246, N'7989742', N'7990246')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (143, 7989742, 7990247, N'7989742', N'7990247')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (144, 7989742, 7990248, N'7989742', N'7990248')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (145, 7989703, 7990249, N'7989703', N'7990249')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (146, 7989703, 7990250, N'7989703', N'7990250')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (147, 7989703, 7990251, N'7989703', N'7990251')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (148, 7989703, 7990252, N'7989703', N'7990252')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (149, 7989705, 7990253, N'7989705', N'7990253')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (150, 7989705, 7990254, N'7989705', N'7990254')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (151, 7989705, 7990255, N'7989705', N'7990255')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (152, 7989705, 7990256, N'7989705', N'7990256')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (153, 7989706, 7990257, N'7989706', N'7990257')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (154, 7989706, 7990258, N'7989706', N'7990258')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (155, 7989706, 7990259, N'7989706', N'7990259')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (156, 7989706, 7990260, N'7989706', N'7990260')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (157, 7989707, 7990261, N'7989707', N'7990261')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (158, 7989707, 7990262, N'7989707', N'7990262')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (159, 7989707, 7990263, N'7989707', N'7990263')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (160, 7989707, 7990264, N'7989707', N'7990264')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (161, 7989708, 7990265, N'7989708', N'7990265')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (162, 7989708, 7990266, N'7989708', N'7990266')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (163, 7989708, 7990267, N'7989708', N'7990267')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (164, 7989708, 7990268, N'7989708', N'7990268')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (165, 7989718, 7990269, N'7989718', N'7990269')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (166, 7989718, 7990270, N'7989718', N'7990270')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (167, 7989718, 7990271, N'7989718', N'7990271')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (168, 7989718, 7990272, N'7989718', N'7990272')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (169, 7989719, 7990273, N'7989719', N'7990273')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (170, 7989719, 7990274, N'7989719', N'7990274')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (171, 7989719, 7990275, N'7989719', N'7990275')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (172, 7989719, 7990276, N'7989719', N'7990276')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (173, 7989702, 7990277, N'7989702', N'7990277')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (174, 7989702, 7990278, N'7989702', N'7990278')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (175, 7989702, 7990279, N'7989702', N'7990279')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (176, 7989702, 7990280, N'7989702', N'7990280')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (177, 7989715, 7990281, N'7989715', N'7990281')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (178, 7989715, 7990282, N'7989715', N'7990282')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (179, 7989715, 7990283, N'7989715', N'7990283')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (180, 7989715, 7990284, N'7989715', N'7990284')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (181, 7989716, 7990285, N'7989716', N'7990285')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (182, 7989716, 7990286, N'7989716', N'7990286')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (183, 7989716, 7990287, N'7989716', N'7990287')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (184, 7989716, 7990288, N'7989716', N'7990288')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (185, 7989724, 7990289, N'7989724', N'7990289')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (186, 7989724, 7990290, N'7989724', N'7990290')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (187, 7989724, 7990291, N'7989724', N'7990291')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (188, 7989724, 7990292, N'7989724', N'7990292')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (189, 7989727, 7990293, N'7989727', N'7990293')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (190, 7989727, 7990294, N'7989727', N'7990294')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (191, 7989727, 7990295, N'7989727', N'7990295')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (192, 7989727, 7990296, N'7989727', N'7990296')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (193, 7989734, 7990297, N'7989734', N'7990297')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (194, 7989734, 7990298, N'7989734', N'7990298')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (195, 7989734, 7990299, N'7989734', N'7990299')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (196, 7989734, 7990300, N'7989734', N'7990300')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (197, 7989735, 7990301, N'7989735', N'7990301')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (198, 7989735, 7990302, N'7989735', N'7990302')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (199, 7989735, 7990303, N'7989735', N'7990303')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (200, 7989735, 7990304, N'7989735', N'7990304')
                                            
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (201, 7989736, 7990305, N'7989736', N'7990305')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (202, 7989736, 7990306, N'7989736', N'7990306')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (203, 7989736, 7990307, N'7989736', N'7990307')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (204, 7989736, 7990308, N'7989736', N'7990308')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (205, 7989737, 7990309, N'7989737', N'7990309')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (206, 7989737, 7990310, N'7989737', N'7990310')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (207, 7989737, 7990311, N'7989737', N'7990311')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (208, 7989737, 7990312, N'7989737', N'7990312')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (209, 7989739, 7990313, N'7989739', N'7990313')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (210, 7989739, 7990314, N'7989739', N'7990314')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (211, 7989739, 7990315, N'7989739', N'7990315')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (212, 7989739, 7990316, N'7989739', N'7990316')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (213, 7989741, 7990317, N'7989741', N'7990317')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (214, 7989741, 7990318, N'7989741', N'7990318')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (215, 7989741, 7990319, N'7989741', N'7990319')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (216, 7989741, 7990320, N'7989741', N'7990320')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (217, 7989743, 7990321, N'7989743', N'7990321')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (218, 7989743, 7990322, N'7989743', N'7990322')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (219, 7989743, 7990323, N'7989743', N'7990323')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (220, 7989743, 7990324, N'7989743', N'7990324')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (221, 7989744, 7990325, N'7989744', N'7990325')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (222, 7989744, 7990326, N'7989744', N'7990326')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (223, 7989744, 7990327, N'7989744', N'7990327')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (224, 7989744, 7990328, N'7989744', N'7990328')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (225, 7989745, 7990329, N'7989745', N'7990329')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (226, 7989745, 7990330, N'7989745', N'7990330')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (227, 7989745, 7990331, N'7989745', N'7990331')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (228, 7989745, 7990332, N'7989745', N'7990332')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (229, 7989746, 7990333, N'7989746', N'7990333')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (230, 7989746, 7990334, N'7989746', N'7990334')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (231, 7989746, 7990335, N'7989746', N'7990335')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (232, 7989746, 7990336, N'7989746', N'7990336')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (233, 7989747, 7990337, N'7989747', N'7990337')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (234, 7989747, 7990338, N'7989747', N'7990338')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (235, 7989747, 7990339, N'7989747', N'7990339')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (236, 7989747, 7990340, N'7989747', N'7990340')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (237, 7989748, 7990341, N'7989748', N'7990341')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (238, 7989748, 7990342, N'7989748', N'7990342')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (239, 7989748, 7990343, N'7989748', N'7990343')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (240, 7989748, 7990344, N'7989748', N'7990344')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (241, 7989749, 7990345, N'7989749', N'7990345')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (242, 7989749, 7990346, N'7989749', N'7990346')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (243, 7989749, 7990347, N'7989749', N'7990347')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (244, 7989749, 7990348, N'7989749', N'7990348')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (245, 7989750, 7990349, N'7989750', N'7990349')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (246, 7989750, 7990350, N'7989750', N'7990350')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (247, 7989750, 7990351, N'7989750', N'7990351')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (248, 7989750, 7990352, N'7989750', N'7990352')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (249, 7989751, 7990353, N'7989751', N'7990353')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (250, 7989751, 7990354, N'7989751', N'7990354')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (251, 7989751, 7990355, N'7989751', N'7990355')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (252, 7989751, 7990356, N'7989751', N'7990356')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (253, 7989752, 7990357, N'7989752', N'7990357')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (254, 7989752, 7990358, N'7989752', N'7990358')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (255, 7989752, 7990359, N'7989752', N'7990359')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (256, 7989752, 7990360, N'7989752', N'7990360')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (257, 7989754, 7990361, N'7989754', N'7990361')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (258, 7989754, 7990362, N'7989754', N'7990362')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (259, 7989754, 7990363, N'7989754', N'7990363')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (260, 7989754, 7990364, N'7989754', N'7990364')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (261, 7989755, 7990365, N'7989755', N'7990365')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (262, 7989755, 7990366, N'7989755', N'7990366')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (263, 7989755, 7990367, N'7989755', N'7990367')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (264, 7989755, 7990368, N'7989755', N'7990368')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (265, 7989756, 7990369, N'7989756', N'7990369')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (266, 7989756, 7990370, N'7989756', N'7990370')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (267, 7989756, 7990371, N'7989756', N'7990371')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (268, 7989756, 7990372, N'7989756', N'7990372')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (269, 7989757, 7990373, N'7989757', N'7990373')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (270, 7989757, 7990374, N'7989757', N'7990374')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (271, 7989757, 7990375, N'7989757', N'7990375')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (272, 7989757, 7990376, N'7989757', N'7990376')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (273, 7989758, 7990377, N'7989758', N'7990377')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (274, 7989758, 7990378, N'7989758', N'7990378')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (275, 7989758, 7990379, N'7989758', N'7990379')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (276, 7989758, 7990380, N'7989758', N'7990380')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (277, 7989759, 7990381, N'7989759', N'7990381')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (278, 7989759, 7990382, N'7989759', N'7990382')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (279, 7989759, 7990383, N'7989759', N'7990383')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (280, 7989759, 7990384, N'7989759', N'7990384')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (281, 7989761, 7990385, N'7989761', N'7990385')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (282, 7989761, 7990386, N'7989761', N'7990386')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (283, 7989761, 7990387, N'7989761', N'7990387')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (284, 7989761, 7990388, N'7989761', N'7990388')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (285, 7989762, 7990389, N'7989762', N'7990389')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (286, 7989762, 7990390, N'7989762', N'7990390')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (287, 7989762, 7990391, N'7989762', N'7990391')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (288, 7989762, 7990392, N'7989762', N'7990392')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (289, 7989763, 7990393, N'7989763', N'7990393')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (290, 7989763, 7990394, N'7989763', N'7990394')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (291, 7989763, 7990395, N'7989763', N'7990395')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (292, 7989763, 7990396, N'7989763', N'7990396')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (293, 7989764, 7990397, N'7989764', N'7990397')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (294, 7989764, 7990398, N'7989764', N'7990398')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (295, 7989764, 7990399, N'7989764', N'7990399')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (296, 7989764, 7990400, N'7989764', N'7990400')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (297, 7989766, 7990401, N'7989766', N'7990401')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (298, 7989766, 7990402, N'7989766', N'7990402')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (299, 7989766, 7990403, N'7989766', N'7990403')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (300, 7989766, 7990404, N'7989766', N'7990404')
                                            
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (301, 7989767, 7990405, N'7989767', N'7990405')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (302, 7989767, 7990406, N'7989767', N'7990406')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (303, 7989767, 7990407, N'7989767', N'7990407')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (304, 7989767, 7990408, N'7989767', N'7990408')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (305, 7989768, 7990409, N'7989768', N'7990409')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (306, 7989768, 7990410, N'7989768', N'7990410')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (307, 7989768, 7990411, N'7989768', N'7990411')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (308, 7989768, 7990412, N'7989768', N'7990412')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (309, 7989769, 7990413, N'7989769', N'7990413')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (310, 7989769, 7990414, N'7989769', N'7990414')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (311, 7989769, 7990415, N'7989769', N'7990415')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (312, 7989769, 7990416, N'7989769', N'7990416')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (313, 7989770, 7990417, N'7989770', N'7990417')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (314, 7989770, 7990418, N'7989770', N'7990418')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (315, 7989770, 7990419, N'7989770', N'7990419')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (316, 7989770, 7990420, N'7989770', N'7990420')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (317, 7990605, 7990618, N'7990605', N'7990618')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (318, 7990605, 7990619, N'7990605', N'7990619')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (319, 7990605, 7990620, N'7990605', N'7990620')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (320, 3246, 7990628, N'3246', N'7990628')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (321, 3246, 7990629, N'3246', N'7990629')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (322, 3246, 7990630, N'3246', N'7990630')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (323, 3246, 7990631, N'3246', N'7990631')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (324, 3246, 7990632, N'3246', N'7990632')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (325, 3246, 7990633, N'3246', N'7990633')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (326, 3246, 7990634, N'3246', N'7990634')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (327, 3246, 7990635, N'3246', N'7990635')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (328, 3246, 7990636, N'3246', N'7990636')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (329, 3246, 7990637, N'3246', N'7990637')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (330, 3246, 7990638, N'3246', N'7990638')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (331, 3246, 7990639, N'3246', N'7990639')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (332, 3246, 7990640, N'3246', N'7990640')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (333, 7989771, 7990641, N'7989771', N'7990641')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (334, 7989771, 7990642, N'7989771', N'7990642')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (335, 7989771, 7990643, N'7989771', N'7990643')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (336, 7989771, 7990644, N'7989771', N'7990644')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (337, 7989772, 7990645, N'7989772', N'7990645')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (338, 7989772, 7990646, N'7989772', N'7990646')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (339, 7989772, 7990647, N'7989772', N'7990647')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (340, 7989772, 7990648, N'7989772', N'7990648')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (341, 7989779, 7990649, N'7989779', N'7990649')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (342, 7989779, 7990650, N'7989779', N'7990650')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (343, 7989779, 7990651, N'7989779', N'7990651')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (344, 7989779, 7990652, N'7989779', N'7990652')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (345, 7989780, 7990653, N'7989780', N'7990653')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (346, 7989780, 7990654, N'7989780', N'7990654')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (347, 7989780, 7990655, N'7989780', N'7990655')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (348, 7989780, 7990656, N'7989780', N'7990656')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (349, 7989781, 7990657, N'7989781', N'7990657')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (350, 7989781, 7990658, N'7989781', N'7990658')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (351, 7989781, 7990659, N'7989781', N'7990659')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (352, 7989781, 7990660, N'7989781', N'7990660')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (353, 7989782, 7990661, N'7989782', N'7990661')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (354, 7989782, 7990662, N'7989782', N'7990662')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (355, 7989782, 7990663, N'7989782', N'7990663')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (356, 7989782, 7990664, N'7989782', N'7990664')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (357, 7989774, 7990665, N'7989774', N'7990665')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (358, 7989774, 7990666, N'7989774', N'7990666')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (359, 7989774, 7990667, N'7989774', N'7990667')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (360, 7989774, 7990668, N'7989774', N'7990668')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (361, 7989784, 7990669, N'7989784', N'7990669')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (362, 7989784, 7990670, N'7989784', N'7990670')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (363, 7989784, 7990671, N'7989784', N'7990671')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (364, 7989784, 7990672, N'7989784', N'7990672')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (365, 7990603, 7990673, N'7990603', N'7990673')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (366, 7990603, 7990674, N'7990603', N'7990674')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (367, 7990603, 7990675, N'7990603', N'7990675')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (368, 7990603, 7990676, N'7990603', N'7990676')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (369, 7990604, 7990677, N'7990604', N'7990677')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (370, 7990604, 7990678, N'7990604', N'7990678')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (371, 7990604, 7990679, N'7990604', N'7990679')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (372, 7990604, 7990680, N'7990604', N'7990680')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (373, 7989732, 7990681, N'7989732', N'7990681')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (374, 7989732, 7990682, N'7989732', N'7990682')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (375, 7989732, 7990683, N'7989732', N'7990683')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (376, 7989732, 7990684, N'7989732', N'7990684')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (377, 7990606, 7990685, N'7990606', N'7990685')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (378, 7990606, 7990686, N'7990606', N'7990686')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (379, 7990606, 7990687, N'7990606', N'7990687')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (380, 7990606, 7990688, N'7990606', N'7990688')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (381, 7989730, 7990689, N'7989730', N'7990689')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (382, 7989730, 7990690, N'7989730', N'7990690')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (383, 7989730, 7990691, N'7989730', N'7990691')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (384, 7989730, 7990692, N'7989730', N'7990692')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (385, 7989723, 7990693, N'7989723', N'7990693')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (386, 7989723, 7990694, N'7989723', N'7990694')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (387, 7989723, 7990695, N'7989723', N'7990695')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (388, 7989723, 7990696, N'7989723', N'7990696')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (389, 7989765, 7990697, N'7989765', N'7990697')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (390, 7989765, 7990698, N'7989765', N'7990698')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (391, 7989765, 7990699, N'7989765', N'7990699')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (392, 7989765, 7990700, N'7989765', N'7990700')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (393, 7989709, 7990701, N'7989709', N'7990701')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (394, 7989709, 7990702, N'7989709', N'7990702')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (395, 7989709, 7990703, N'7989709', N'7990703')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (396, 7989709, 7990704, N'7989709', N'7990704')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (397, 7989712, 7990705, N'7989712', N'7990705')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (398, 7989742, 7990706, N'7989742', N'7990706')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (399, 7989742, 7990707, N'7989742', N'7990707')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (400, 7989742, 7990708, N'7989742', N'7990708')
                                            
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (401, 7989742, 7990709, N'7989742', N'7990709')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (402, 7989742, 7990710, N'7989742', N'7990710')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (403, 7989742, 7990711, N'7989742', N'7990711')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (404, 7989742, 7990712, N'7989742', N'7990712')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (405, 7989712, 7990713, N'7989712', N'7990713')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (406, 7989712, 7990714, N'7989712', N'7990714')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (407, 7989712, 7990715, N'7989712', N'7990715')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (408, 7989714, 7990796, N'7989714', N'7990796')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (409, 7989714, 7990797, N'7989714', N'7990797')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (410, 7989714, 7990798, N'7989714', N'7990798')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (411, 7989714, 7990799, N'7989714', N'7990799')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (412, 7989710, 7990800, N'7989710', N'7990800')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (413, 7989710, 7990801, N'7989710', N'7990801')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (414, 7989710, 7990802, N'7989710', N'7990802')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (415, 7989710, 7990803, N'7989710', N'7990803')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (416, 7989700, 7990804, N'7989700', N'7990804')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (417, 7989700, 7990805, N'7989700', N'7990805')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (418, 7989700, 7990806, N'7989700', N'7990806')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (419, 7989700, 7990807, N'7989700', N'7990807')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (420, 7989711, 7990808, N'7989711', N'7990808')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (421, 7989711, 7990809, N'7989711', N'7990809')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (422, 7989711, 7990810, N'7989711', N'7990810')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (423, 7989711, 7990811, N'7989711', N'7990811')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (424, 7989733, 7990812, N'7989733', N'7990812')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (425, 7989733, 7990813, N'7989733', N'7990813')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (426, 7989733, 7990814, N'7989733', N'7990814')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (427, 7989733, 7990815, N'7989733', N'7990815')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (428, 7989720, 7990816, N'7989720', N'7990816')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (429, 7989720, 7990817, N'7989720', N'7990817')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (430, 7989720, 7990818, N'7989720', N'7990818')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (431, 7989720, 7990819, N'7989720', N'7990819')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (432, 7989720, 7990820, N'7989720', N'7990820')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (433, 7989713, 7990904, N'7989713', N'7990904')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (434, 7989713, 7990905, N'7989713', N'7990905')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (435, 7989713, 7990906, N'7989713', N'7990906')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (436, 7989713, 7990907, N'7989713', N'7990907')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (437, 7989713, 7990908, N'7989713', N'7990908')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (438, 7989713, 7990909, N'7989713', N'7990909')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (439, 7989753, 7990910, N'7989753', N'7990910')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (440, 7989753, 7990911, N'7989753', N'7990911')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (441, 7989753, 7990912, N'7989753', N'7990912')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (442, 7989753, 7990913, N'7989753', N'7990913')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (443, 7989753, 7990914, N'7989753', N'7990914')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (444, 7989753, 7990915, N'7989753', N'7990915')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (445, 7989717, 7990916, N'7989717', N'7990916')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (446, 7989717, 7990917, N'7989717', N'7990917')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (447, 7989717, 7990918, N'7989717', N'7990918')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (448, 7989717, 7990919, N'7989717', N'7990919')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (449, 7989717, 7990920, N'7989717', N'7990920')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (450, 7989717, 7990921, N'7989717', N'7990921')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (451, 7989717, 7990922, N'7989717', N'7990922')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (452, 7989717, 7990923, N'7989717', N'7990923')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (453, 7989717, 7990924, N'7989717', N'7990924')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (454, 7989717, 7990925, N'7989717', N'7990925')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (455, 7989717, 7990926, N'7989717', N'7990926')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (456, 7989717, 7990927, N'7989717', N'7990927')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (457, 7989717, 7990928, N'7989717', N'7990928')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (458, 7989721, 7990929, N'7989721', N'7990929')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (459, 7989721, 7990930, N'7989721', N'7990930')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (460, 7989721, 7990931, N'7989721', N'7990931')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (461, 7989721, 7990932, N'7989721', N'7990932')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (462, 7989721, 7990933, N'7989721', N'7990933')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (463, 7989722, 7990934, N'7989722', N'7990934')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (464, 7989722, 7990935, N'7989722', N'7990935')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (465, 7989722, 7990936, N'7989722', N'7990936')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (466, 7989722, 7990937, N'7989722', N'7990937')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (467, 7989722, 7990938, N'7989722', N'7990938')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (468, 7989722, 7990939, N'7989722', N'7990939')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (469, 7989722, 7990940, N'7989722', N'7990940')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (470, 7989722, 7990941, N'7989722', N'7990941')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (471, 7989722, 7990942, N'7989722', N'7990942')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (472, 7989726, 7990943, N'7989726', N'7990943')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (473, 7989726, 7990944, N'7989726', N'7990944')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (474, 7989726, 7990945, N'7989726', N'7990945')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (475, 7989726, 7990946, N'7989726', N'7990946')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (476, 7989729, 7990947, N'7989729', N'7990947')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (477, 7989729, 7990948, N'7989729', N'7990948')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (478, 7989729, 7990949, N'7989729', N'7990949')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (479, 7989729, 7990950, N'7989729', N'7990950')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (480, 7989729, 7990951, N'7989729', N'7990951')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (481, 7989731, 7990952, N'7989731', N'7990952')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (482, 7989731, 7990953, N'7989731', N'7990953')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (483, 7989731, 7990954, N'7989731', N'7990954')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (484, 7989731, 7990955, N'7989731', N'7990955')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (485, 7989773, 7990956, N'7989773', N'7990956')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (486, 7989773, 7990957, N'7989773', N'7990957')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (487, 7989773, 7990958, N'7989773', N'7990958')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (488, 7989773, 7990959, N'7989773', N'7990959')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (489, 7989773, 7990960, N'7989773', N'7990960')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (490, 7989776, 7990961, N'7989776', N'7990961')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (491, 7989776, 7990962, N'7989776', N'7990962')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (492, 7989776, 7990963, N'7989776', N'7990963')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (493, 7989776, 7990964, N'7989776', N'7990964')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (494, 7989776, 7990965, N'7989776', N'7990965')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (495, 7989776, 7990966, N'7989776', N'7990966')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (496, 7989776, 7990967, N'7989776', N'7990967')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (497, 7989776, 7990968, N'7989776', N'7990968')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (498, 7989776, 7990969, N'7989776', N'7990969')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (499, 7989778, 7990970, N'7989778', N'7990970')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (500, 7989778, 7990971, N'7989778', N'7990971')
                                            
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (501, 7989778, 7990972, N'7989778', N'7990972')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (502, 7989778, 7990973, N'7989778', N'7990973')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (503, 7989778, 7990974, N'7989778', N'7990974')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (504, 7989785, 7990975, N'7989785', N'7990975')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (505, 7989785, 7990976, N'7989785', N'7990976')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (506, 7989785, 7990977, N'7989785', N'7990977')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (507, 7989785, 7990978, N'7989785', N'7990978')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (508, 7989785, 7990979, N'7989785', N'7990979')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (509, 7989742, 7990980, N'7989742', N'7990980')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (510, 7989742, 7990981, N'7989742', N'7990981')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (511, 7989742, 7990982, N'7989742', N'7990982')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (512, 7989742, 7990983, N'7989742', N'7990983')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (513, 7989742, 7990984, N'7989742', N'7990984')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (514, 7989742, 7990985, N'7989742', N'7990985')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (515, 7989742, 7990986, N'7989742', N'7990986')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (516, 7989742, 7990987, N'7989742', N'7990987')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (517, 7989742, 7990988, N'7989742', N'7990988')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (518, 7989742, 7990989, N'7989742', N'7990989')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (519, 7989742, 7990990, N'7989742', N'7990990')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (520, 7989742, 7990991, N'7989742', N'7990991')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (521, 7989742, 7990992, N'7989742', N'7990992')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (522, 7989742, 7990993, N'7989742', N'7990993')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (523, 7989742, 7990994, N'7989742', N'7990994')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (524, 7989742, 7990995, N'7989742', N'7990995')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (525, 7990608, 7990996, N'7990608', N'7990996')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (526, 7990608, 7990997, N'7990608', N'7990997')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (527, 7990608, 7990998, N'7990608', N'7990998')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (528, 7990608, 7990999, N'7990608', N'7990999')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (529, 7990608, 7991000, N'7990608', N'7991000')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (530, 7990608, 7991001, N'7990608', N'7991001')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (531, 4550, 7991002, N'4550', N'7991002')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (532, 7989783, 7991003, N'7989783', N'7991003')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (533, 7989783, 7991004, N'7989783', N'7991004')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (534, 7990605, 7991005, N'7990605', N'7991005')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (535, 7989729, 7991006, N'7989729', N'7991006')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (536, 7990609, 7991007, N'7990609', N'7991007')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (537, 7990609, 7991008, N'7990609', N'7991008')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (538, 7990609, 7991009, N'7990609', N'7991009')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (539, 7990609, 7991010, N'7990609', N'7991010')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (540, 7989720, 7991011, N'7989720', N'7991011')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (541, 7990605, 7991012, N'7990605', N'7991012')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (542, 7990610, 7991013, N'7990610', N'7991013')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (543, 7990610, 7991014, N'7990610', N'7991014')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (544, 7990610, 7991015, N'7990610', N'7991015')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (545, 7990610, 7991016, N'7990610', N'7991016')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (546, 4171, 8120479, N'4171', N'8120479')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (547, 4189, 8120494, N'4189', N'8120494')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (548, 4550, 8120576, N'4550', N'8120576')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (549, 4566, 8120592, N'4566', N'8120592')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (550, 4569, 8120599, N'4569', N'8120599')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (551, 8410040, 8410045, N'8410040', N'8410045')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (552, 8410040, 8410046, N'8410040', N'8410046')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (553, 8410040, 8410047, N'8410040', N'8410047')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (554, 8410040, 8410048, N'8410040', N'8410048')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (555, 8410040, 8410049, N'8410040', N'8410049')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (556, 8410040, 8410050, N'8410040', N'8410050')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (557, 8410040, 8410051, N'8410040', N'8410051')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (558, 8410040, 8410052, N'8410040', N'8410052')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (559, 8410040, 8410053, N'8410040', N'8410053')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (560, 8410040, 8410054, N'8410040', N'8410054')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (561, 8410040, 8410055, N'8410040', N'8410055')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (562, 8410040, 8410056, N'8410040', N'8410056')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (563, 8410040, 8410057, N'8410040', N'8410057')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (564, 8410040, 8410058, N'8410040', N'8410058')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (565, 8410040, 8410059, N'8410040', N'8410059')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (566, 8410040, 8410060, N'8410040', N'8410060')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (567, 8410040, 8410061, N'8410040', N'8410061')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (568, 8410040, 8410062, N'8410040', N'8410062')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (569, 8410040, 8410063, N'8410040', N'8410063')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (570, 8410040, 8410064, N'8410040', N'8410064')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (571, 8410040, 8410065, N'8410040', N'8410065')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (572, 8410040, 8410066, N'8410040', N'8410066')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (573, 8410040, 8410067, N'8410040', N'8410067')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (574, 8410040, 8410068, N'8410040', N'8410068')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (575, 8410040, 8410069, N'8410040', N'8410069')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (576, 8410040, 8410070, N'8410040', N'8410070')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (577, 8410040, 8410071, N'8410040', N'8410071')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (578, 8410040, 8410072, N'8410040', N'8410072')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (579, 8410040, 8410524, N'8410040', N'8410524')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (580, 8410040, 8410073, N'8410040', N'8410073')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (581, 8410040, 8410074, N'8410040', N'8410074')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (582, 8410040, 8410075, N'8410040', N'8410075')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (583, 8410040, 8410076, N'8410040', N'8410076')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (584, 8410040, 8410077, N'8410040', N'8410077')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (585, 8410040, 8410078, N'8410040', N'8410078')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (586, 8410040, 8410079, N'8410040', N'8410079')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (587, 8410040, 8410080, N'8410040', N'8410080')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (588, 8410040, 8410081, N'8410040', N'8410081')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (589, 8410040, 8410082, N'8410040', N'8410082')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (590, 8410040, 8410083, N'8410040', N'8410083')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (591, 8410040, 8410084, N'8410040', N'8410084')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (592, 8410040, 8410085, N'8410040', N'8410085')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (593, 8410040, 8410086, N'8410040', N'8410086')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (594, 8410040, 8410087, N'8410040', N'8410087')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (595, 8410040, 8410088, N'8410040', N'8410088')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (596, 8410040, 8410089, N'8410040', N'8410089')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (597, 8410040, 8410090, N'8410040', N'8410090')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (598, 8410040, 8410091, N'8410040', N'8410091')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (599, 8410040, 8410092, N'8410040', N'8410092')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (600, 8410040, 8410093, N'8410040', N'8410093')
                                            
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (601, 8410040, 8410094, N'8410040', N'8410094')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (602, 8410040, 8410095, N'8410040', N'8410095')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (603, 8410040, 8410096, N'8410040', N'8410096')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (604, 8410040, 8410097, N'8410040', N'8410097')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (605, 8410040, 8410098, N'8410040', N'8410098')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (606, 8410040, 8410099, N'8410040', N'8410099')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (607, 8410040, 8410100, N'8410040', N'8410100')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (608, 8410040, 8410101, N'8410040', N'8410101')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (609, 8410040, 8410102, N'8410040', N'8410102')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (610, 8410040, 8410103, N'8410040', N'8410103')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (611, 8410040, 8410104, N'8410040', N'8410104')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (612, 8410040, 8410105, N'8410040', N'8410105')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (613, 8410040, 8410106, N'8410040', N'8410106')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (614, 8410040, 8410107, N'8410040', N'8410107')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (615, 8410040, 8410108, N'8410040', N'8410108')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (616, 8410040, 8410109, N'8410040', N'8410109')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (617, 8410040, 8410110, N'8410040', N'8410110')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (618, 8410040, 8410111, N'8410040', N'8410111')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (619, 8410040, 8410112, N'8410040', N'8410112')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (620, 8410040, 8410113, N'8410040', N'8410113')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (621, 8410040, 8410114, N'8410040', N'8410114')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (622, 8410040, 8410115, N'8410040', N'8410115')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (623, 8410040, 8410116, N'8410040', N'8410116')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (624, 8410040, 8410117, N'8410040', N'8410117')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (625, 8410040, 8410118, N'8410040', N'8410118')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (626, 8410040, 8410119, N'8410040', N'8410119')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (627, 8410040, 8410120, N'8410040', N'8410120')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (628, 8410040, 8410121, N'8410040', N'8410121')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (629, 8410040, 8410122, N'8410040', N'8410122')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (630, 8410040, 8410123, N'8410040', N'8410123')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (631, 8410040, 8410124, N'8410040', N'8410124')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (632, 8410040, 8410125, N'8410040', N'8410125')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (633, 8410040, 8410126, N'8410040', N'8410126')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (634, 8410040, 8410127, N'8410040', N'8410127')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (635, 8410040, 8410128, N'8410040', N'8410128')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (636, 8410040, 8410129, N'8410040', N'8410129')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (637, 8410040, 8410130, N'8410040', N'8410130')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (638, 8410040, 8410131, N'8410040', N'8410131')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (639, 8410040, 8410132, N'8410040', N'8410132')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (640, 8408517, 8408582, N'8408517', N'8408582')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (641, 8408517, 8408583, N'8408517', N'8408583')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (642, 8408517, 8408584, N'8408517', N'8408584')
                                            INSERT [dbo].[A_Customer_Receivers] ([AutoID], [PID], [CID], [ParentID], [CustomerID]) VALUES (643, 8408517, 8408585, N'8408517', N'8408585')

                                            
                                                ", new ObjectParameter[] { });


                this.ExecuteStoreCommand(@"
                                UPDATE Customers
                                SET Customers.ParentID = Parents.CustomerID
                                FROM            Customers INNER JOIN
                                                         A_Customer_Receivers ON Customers.IsReceiver = 1 AND Customers.Code = A_Customer_Receivers.CustomerID INNER JOIN
                                                         Customers AS Parents ON A_Customer_Receivers.ParentID = Parents.Code

                                                ", new ObjectParameter[] { });
            }
            #endregion UPDATE ParentID
            #endregion FINAL06NOV2018



            #region FINAL 29OCT2018
            this.totalSmartCodingEntities.ColumnAdd("Configs", "LegalNotice", "nvarchar(3999)", "", false);
            #endregion FINAL 29OCT2018
            #region FINAL 02NOV2018
            if (true)
            {
                var myQuery = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.BinLocations + " AND ControlTypeID = 0;", new object[] { });
                var myExists = myQuery.Cast<int>().Single();
                if (myExists == 1)
                {
                    this.ExecuteStoreCommand("DELETE FROM AccessControls WHERE NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.BinLocations, new ObjectParameter[] { });
                    this.ExecuteStoreCommand("DELETE FROM UserGroupControls WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.BinLocations, new ObjectParameter[] { });
                    this.ExecuteStoreCommand("DELETE FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.BinLocations, new ObjectParameter[] { });

                    this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive, ControlTypeID) VALUES(" + (int)GlobalEnums.NmvnTaskID.BinLocations + ", 1, 'Bin Locations', 'Bin Locations', '', '#', 'WAREHOUSE RESOURCES', 1, 22, 1, 0, 1) ", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID,   AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.BinLocations + " AS NMVNTaskID, OrganizationalUnitID, 0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls    WHERE (NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.SalesOrders + ") AND (SELECT COUNT(*) FROM AccessControls    WHERE NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.BinLocations + ") = 0", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO UserGroupControls (UserGroupID, ModuleDetailID, LocationID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserGroupID, " + (int)GlobalEnums.NmvnTaskID.BinLocations + " AS ModuleDetailID, LocationID,  0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM UserGroupControls WHERE (ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.SalesOrders + ") AND (SELECT COUNT(*) FROM UserGroupControls WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.BinLocations + ") = 0", new ObjectParameter[] { });
                }
            }
            #endregion FINAL 02NOV2018


            #region FINAL 19OCT2018
            if (this.totalSmartCodingEntities.ColumnExists("CommodityTypes", "Description"))
            {
                this.totalSmartCodingEntities.ColumnAdd("Batches", "AutoCarton", "bit", "0", true);

                this.totalSmartCodingEntities.ColumnAdd("Customers", "IsReceiver", "bit", "0", true);
                this.ExecuteStoreCommand("UPDATE Customers SET IsCustomer = 1, IsSupplier = 1", new ObjectParameter[] { });
                this.totalSmartCodingEntities.ColumnAdd("Customers", "Email", "nvarchar(100)", "", false);


                #region ADD NEW MODULE
                this.ExecuteStoreCommand("UPDATE ModuleDetails SET FullName = '' WHERE FullName = '#' ", new ObjectParameter[] { });


                this.ExecuteStoreCommand("UPDATE ModuleDetails SET SerialID = 6 WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Employees, new ObjectParameter[] { });
                var myQuery = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Teams + ";", new object[] { });
                int myExists = myQuery.Cast<int>().Single();
                if (myExists == 0)
                {
                    this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive, ControlTypeID) VALUES(" + (int)GlobalEnums.NmvnTaskID.Teams + ", 1, 'Sales Teams', 'Sales Teams', '', '#', 'CUSTOMER MANAGEMENT', 1, 8, 1, 0, 0) ", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID,   AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.Teams + " AS NMVNTaskID, OrganizationalUnitID, 0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls    WHERE (NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.Commodities + ") AND (SELECT COUNT(*) FROM AccessControls    WHERE NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.Teams + ") = 0", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO UserGroupControls (UserGroupID, ModuleDetailID, LocationID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserGroupID, " + (int)GlobalEnums.NmvnTaskID.Teams + " AS ModuleDetailID, LocationID,  0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM UserGroupControls WHERE (ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Commodities + ") AND (SELECT COUNT(*) FROM UserGroupControls WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Teams + ") = 0", new ObjectParameter[] { });
                }


                this.ExecuteStoreCommand("DELETE FROM AccessControls WHERE NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.Territories, new ObjectParameter[] { });
                this.ExecuteStoreCommand("DELETE FROM UserGroupControls WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Territories, new ObjectParameter[] { });
                this.ExecuteStoreCommand("DELETE FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Territories, new ObjectParameter[] { });
                myQuery = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Territories + ";", new object[] { });
                myExists = myQuery.Cast<int>().Single();
                if (myExists == 0)
                {
                    this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive, ControlTypeID) VALUES(" + (int)GlobalEnums.NmvnTaskID.Territories + ", 1, 'Territories', 'Territories', '', '#', 'CUSTOMER MANAGEMENT', 1, 27, 1, 0, 0) ", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID,   AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.Territories + " AS NMVNTaskID, OrganizationalUnitID, 0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls    WHERE (NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.Commodities + ") AND (SELECT COUNT(*) FROM AccessControls    WHERE NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.Territories + ") = 0", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO UserGroupControls (UserGroupID, ModuleDetailID, LocationID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserGroupID, " + (int)GlobalEnums.NmvnTaskID.Territories + " AS ModuleDetailID, LocationID,  0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM UserGroupControls WHERE (ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Commodities + ") AND (SELECT COUNT(*) FROM UserGroupControls WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Territories + ") = 0", new ObjectParameter[] { });
                }

                myQuery = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.CustomerTypes + ";", new object[] { });
                myExists = myQuery.Cast<int>().Single();
                if (myExists == 0)
                {
                    this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive, ControlTypeID) VALUES(" + (int)GlobalEnums.NmvnTaskID.CustomerTypes + ", 1, 'Customer Types', 'Customer Types', '', '#', 'CUSTOMER MANAGEMENT', 1, 30, 1, 0, 0) ", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID,   AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.CustomerTypes + " AS NMVNTaskID, OrganizationalUnitID, 0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls    WHERE (NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.Commodities + ") AND (SELECT COUNT(*) FROM AccessControls    WHERE NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.CustomerTypes + ") = 0", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO UserGroupControls (UserGroupID, ModuleDetailID, LocationID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserGroupID, " + (int)GlobalEnums.NmvnTaskID.CustomerTypes + " AS ModuleDetailID, LocationID,  0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM UserGroupControls WHERE (ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Commodities + ") AND (SELECT COUNT(*) FROM UserGroupControls WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.CustomerTypes + ") = 0", new ObjectParameter[] { });
                }

                myQuery = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.CustomerCategories + ";", new object[] { });
                myExists = myQuery.Cast<int>().Single();
                if (myExists == 0)
                {
                    this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive, ControlTypeID) VALUES(" + (int)GlobalEnums.NmvnTaskID.CustomerCategories + ", 1, 'Customer Categories', 'Customer Categories', '', '#', 'CUSTOMER MANAGEMENT', 1, 36, 1, 0, 0) ", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID,   AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.CustomerCategories + " AS NMVNTaskID, OrganizationalUnitID, 0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls    WHERE (NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.Commodities + ") AND (SELECT COUNT(*) FROM AccessControls    WHERE NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.CustomerCategories + ") = 0", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO UserGroupControls (UserGroupID, ModuleDetailID, LocationID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserGroupID, " + (int)GlobalEnums.NmvnTaskID.CustomerCategories + " AS ModuleDetailID, LocationID,  0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM UserGroupControls WHERE (ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Commodities + ") AND (SELECT COUNT(*) FROM UserGroupControls WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.CustomerCategories + ") = 0", new ObjectParameter[] { });
                }

                myQuery = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.CommodityTypes + ";", new object[] { });
                myExists = myQuery.Cast<int>().Single();
                if (myExists == 0)
                {
                    this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive, ControlTypeID) VALUES(" + (int)GlobalEnums.NmvnTaskID.CommodityTypes + ", 1, 'Item Types', 'Item Types', '', '#', 'WAREHOUSE RESOURCES', 1, 27, 1, 0, 0) ", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID,   AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.CommodityTypes + " AS NMVNTaskID, OrganizationalUnitID, 0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls    WHERE (NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.Commodities + ") AND (SELECT COUNT(*) FROM AccessControls    WHERE NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.CommodityTypes + ") = 0", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO UserGroupControls (UserGroupID, ModuleDetailID, LocationID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserGroupID, " + (int)GlobalEnums.NmvnTaskID.CommodityTypes + " AS ModuleDetailID, LocationID,  0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM UserGroupControls WHERE (ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Commodities + ") AND (SELECT COUNT(*) FROM UserGroupControls WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.CommodityTypes + ") = 0", new ObjectParameter[] { });
                }

                myQuery = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.CommodityCategories + ";", new object[] { });
                myExists = myQuery.Cast<int>().Single();
                if (myExists == 0)
                {
                    this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive, ControlTypeID) VALUES(" + (int)GlobalEnums.NmvnTaskID.CommodityCategories + ", 1, 'Item Categories', 'Item Categories', '', '#', 'WAREHOUSE RESOURCES', 1, 36, 1, 0, 0) ", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID,   AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.CommodityCategories + " AS NMVNTaskID, OrganizationalUnitID, 0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls    WHERE (NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.Commodities + ") AND (SELECT COUNT(*) FROM AccessControls    WHERE NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.CommodityCategories + ") = 0", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO UserGroupControls (UserGroupID, ModuleDetailID, LocationID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserGroupID, " + (int)GlobalEnums.NmvnTaskID.CommodityCategories + " AS ModuleDetailID, LocationID,  0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM UserGroupControls WHERE (ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Commodities + ") AND (SELECT COUNT(*) FROM UserGroupControls WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.CommodityCategories + ") = 0", new ObjectParameter[] { });
                }

                this.ExecuteStoreCommand("DELETE FROM AccessControls WHERE NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.Warehouses, new ObjectParameter[] { });
                this.ExecuteStoreCommand("DELETE FROM UserGroupControls WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Warehouses, new ObjectParameter[] { });
                this.ExecuteStoreCommand("DELETE FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Warehouses, new ObjectParameter[] { });
                myQuery = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Warehouses + ";", new object[] { });
                myExists = myQuery.Cast<int>().Single();
                if (myExists == 0)
                {
                    this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive, ControlTypeID) VALUES(" + (int)GlobalEnums.NmvnTaskID.Warehouses + ", 1, 'Warehouses', 'Warehouses', '', '#', 'WAREHOUSE RESOURCES', 1, 38, 1, 0, 0) ", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID,   AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.Warehouses + " AS NMVNTaskID, OrganizationalUnitID, 0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls    WHERE (NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.Commodities + ") AND (SELECT COUNT(*) FROM AccessControls    WHERE NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.Warehouses + ") = 0", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO UserGroupControls (UserGroupID, ModuleDetailID, LocationID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserGroupID, " + (int)GlobalEnums.NmvnTaskID.Warehouses + " AS ModuleDetailID, LocationID,  0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM UserGroupControls WHERE (ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Commodities + ") AND (SELECT COUNT(*) FROM UserGroupControls WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Warehouses + ") = 0", new ObjectParameter[] { });
                }

                #endregion ADD NEW MODULE



                #region ADD PRODUCTION MODULE
                myQuery = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.SmartCodingSmallpack + ";", new object[] { });
                myExists = myQuery.Cast<int>().Single();
                if (myExists == 0)
                {
                    this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive, ControlTypeID) VALUES(" + (int)GlobalEnums.NmvnTaskID.SmartCodingSmallpack + ", 108, 'Print & Scannings', 'Print & Scannings', '0,8 & 1 LITTRE', '#', '#', 1, 21, 1, 0, 0) ", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID,   AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.SmartCodingSmallpack + " AS NMVNTaskID, OrganizationalUnitID, 0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls    WHERE (NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.SmartCoding + ") AND (SELECT COUNT(*) FROM AccessControls    WHERE NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.SmartCodingSmallpack + ") = 0", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO UserGroupControls (UserGroupID, ModuleDetailID, LocationID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserGroupID, " + (int)GlobalEnums.NmvnTaskID.SmartCodingSmallpack + " AS ModuleDetailID, LocationID,  0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM UserGroupControls WHERE (ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.SmartCoding + ") AND (SELECT COUNT(*) FROM UserGroupControls WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.SmartCodingSmallpack + ") = 0", new ObjectParameter[] { });
                }

                myQuery = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.SmartCodingPail + ";", new object[] { });
                myExists = myQuery.Cast<int>().Single();
                if (myExists == 0)
                {
                    this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive, ControlTypeID) VALUES(" + (int)GlobalEnums.NmvnTaskID.SmartCodingPail + ", 108, 'Print & Scannings', 'Print & Scannings', 'PAIL 18-25L', '#', '#', 1, 22, 1, 0, 0) ", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID,   AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.SmartCodingPail + " AS NMVNTaskID, OrganizationalUnitID, 0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls    WHERE (NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.SmartCoding + ") AND (SELECT COUNT(*) FROM AccessControls    WHERE NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.SmartCodingPail + ") = 0", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO UserGroupControls (UserGroupID, ModuleDetailID, LocationID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserGroupID, " + (int)GlobalEnums.NmvnTaskID.SmartCodingPail + " AS ModuleDetailID, LocationID,  0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM UserGroupControls WHERE (ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.SmartCoding + ") AND (SELECT COUNT(*) FROM UserGroupControls WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.SmartCodingPail + ") = 0", new ObjectParameter[] { });
                }

                myQuery = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.SmartCodingDrum + ";", new object[] { });
                myExists = myQuery.Cast<int>().Single();
                if (myExists == 0)
                {
                    this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive, ControlTypeID) VALUES(" + (int)GlobalEnums.NmvnTaskID.SmartCodingDrum + ", 108, 'Print & Scannings', 'Print & Scannings', 'DRUM', '#', '#', 1, 23, 1, 0, 0) ", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID,   AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.SmartCodingDrum + " AS NMVNTaskID, OrganizationalUnitID, 0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls    WHERE (NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.SmartCoding + ") AND (SELECT COUNT(*) FROM AccessControls    WHERE NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.SmartCodingDrum + ") = 0", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO UserGroupControls (UserGroupID, ModuleDetailID, LocationID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserGroupID, " + (int)GlobalEnums.NmvnTaskID.SmartCodingDrum + " AS ModuleDetailID, LocationID,  0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM UserGroupControls WHERE (ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.SmartCoding + ") AND (SELECT COUNT(*) FROM UserGroupControls WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.SmartCodingDrum + ") = 0", new ObjectParameter[] { });
                }

                myQuery = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.SmartCodingMedium4L + ";", new object[] { });
                myExists = myQuery.Cast<int>().Single();
                if (myExists == 0)
                {
                    this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive, ControlTypeID) VALUES(" + (int)GlobalEnums.NmvnTaskID.SmartCodingMedium4L + ", 108, 'Print & Scannings', 'Print & Scannings', '4 LITTRES', '#', '#', 1, 24, 1, 0, 0) ", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID,   AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.SmartCodingMedium4L + " AS NMVNTaskID, OrganizationalUnitID, 0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls    WHERE (NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.SmartCoding + ") AND (SELECT COUNT(*) FROM AccessControls    WHERE NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.SmartCodingMedium4L + ") = 0", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO UserGroupControls (UserGroupID, ModuleDetailID, LocationID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserGroupID, " + (int)GlobalEnums.NmvnTaskID.SmartCodingMedium4L + " AS ModuleDetailID, LocationID,  0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM UserGroupControls WHERE (ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.SmartCoding + ") AND (SELECT COUNT(*) FROM UserGroupControls WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.SmartCodingMedium4L + ") = 0", new ObjectParameter[] { });
                }

                myQuery = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.SmartCodingImport + ";", new object[] { });
                myExists = myQuery.Cast<int>().Single();
                if (myExists == 0)
                {
                    this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive, ControlTypeID) VALUES(" + (int)GlobalEnums.NmvnTaskID.SmartCodingImport + ", 108, 'Print & Scannings', 'Print & Scannings', 'IMPORT', '#', '#', 1, 25, 1, 0, 0) ", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID,   AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.SmartCodingImport + " AS NMVNTaskID, OrganizationalUnitID, 0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls    WHERE (NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.SmartCoding + ") AND (SELECT COUNT(*) FROM AccessControls    WHERE NMVNTaskID =     " + (int)GlobalEnums.NmvnTaskID.SmartCodingImport + ") = 0", new ObjectParameter[] { });
                    this.ExecuteStoreCommand("INSERT INTO UserGroupControls (UserGroupID, ModuleDetailID, LocationID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserGroupID, " + (int)GlobalEnums.NmvnTaskID.SmartCodingImport + " AS ModuleDetailID, LocationID,  0 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM UserGroupControls WHERE (ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.SmartCoding + ") AND (SELECT COUNT(*) FROM UserGroupControls WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.SmartCodingImport + ") = 0", new ObjectParameter[] { });
                }

                #endregion ADD PRODUCTION MODULE

                #region CommodityTypes
                this.ExecuteStoreCommand(@"CREATE TABLE [dbo].[CommodityTypes_ABC](
	                                                    [CommodityTypeID] [int] NOT NULL,
	                                                    [Name] [nvarchar](100) NOT NULL,
	                                                    [AncestorID] [int] NULL,
	                                                    [Remarks] [nvarchar](100) NULL,
                                                     CONSTRAINT [PK_CommodityTypes_ABC] PRIMARY KEY CLUSTERED 
                                                    (
	                                                    [CommodityTypeID] ASC
                                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                    ) ON [PRIMARY]
                                                ", new ObjectParameter[] { });

                this.ExecuteStoreCommand(@"INSERT INTO CommodityTypes_ABC (CommodityTypeID, Name, AncestorID, Remarks) SELECT CommodityTypeID, Name, AncestorID, Remarks FROM CommodityTypes
                                                ", new ObjectParameter[] { });

                this.ExecuteStoreCommand(@"ALTER TABLE Commodities DROP CONSTRAINT FK_Commodities_CommodityTypes
                                                ", new ObjectParameter[] { });


                this.ExecuteStoreCommand(@"DROP TABLE CommodityTypes
                                                ", new ObjectParameter[] { });



                this.ExecuteStoreCommand(@"ALTER TABLE CustomerCategories ALTER COLUMN Remarks nvarchar(100)
                                                ", new ObjectParameter[] { });
                this.ExecuteStoreCommand(@"ALTER TABLE CustomerTypes ALTER COLUMN Remarks nvarchar(100)
                                                ", new ObjectParameter[] { });


                this.ExecuteStoreCommand(@"CREATE TABLE [dbo].[CommodityTypes](
	                                                [CommodityTypeID] [int] IDENTITY(1,1) NOT NULL,
	                                                [Name] [nvarchar](100) NOT NULL,
	                                                [AncestorID] [int] NULL,
	                                                [Remarks] [nvarchar](100) NULL,
                                                 CONSTRAINT [PK_CommodityTypes] PRIMARY KEY CLUSTERED 
                                                (
	                                                [CommodityTypeID] ASC
                                                )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                ) ON [PRIMARY]
                                                
                                                ALTER TABLE [dbo].[CommodityTypes]  WITH CHECK ADD  CONSTRAINT [FK_CommodityTypes_CommodityTypes] FOREIGN KEY([AncestorID])
                                                REFERENCES [dbo].[CommodityTypes] ([CommodityTypeID])                                                

                                                ALTER TABLE [dbo].[CommodityTypes] CHECK CONSTRAINT [FK_CommodityTypes_CommodityTypes]
                                                ", new ObjectParameter[] { });


                this.ExecuteStoreCommand("SET IDENTITY_INSERT CommodityTypes ON     INSERT INTO CommodityTypes (CommodityTypeID, Name, AncestorID, Remarks) SELECT CommodityTypeID, Name, AncestorID, Remarks FROM CommodityTypes_ABC      SET IDENTITY_INSERT CommodityTypes OFF ", new ObjectParameter[] { });


                this.ExecuteStoreCommand(@"ALTER TABLE [dbo].[Commodities]  WITH CHECK ADD  CONSTRAINT [FK_Commodities_CommodityTypes] FOREIGN KEY([CommodityTypeID])
                                                REFERENCES [dbo].[CommodityTypes] ([CommodityTypeID])                                                
                                                ", new ObjectParameter[] { });
                this.ExecuteStoreCommand(@"ALTER TABLE [dbo].[Commodities] CHECK CONSTRAINT [FK_Commodities_CommodityTypes]
                                                ", new ObjectParameter[] { });


                this.ExecuteStoreCommand(@"DROP TABLE CommodityTypes_ABC
                                                ", new ObjectParameter[] { });

                #endregion CommodityTypes

                this.ExecuteStoreCommand("DELETE FROM Territories WHERE TerritoryID NOT IN (SELECT TerritoryID FROM EntireTerritories)", new ObjectParameter[] { });
                this.ExecuteStoreCommand("UPDATE Territories SET Name = '##' WHERE TerritoryID = 7", new ObjectParameter[] { });
                this.ExecuteStoreCommand("UPDATE EntireTerritories SET Name = '##', EntireName = '##', Name1 = '##', Name2 = '##', Name3 = '##' WHERE TerritoryID = 7", new ObjectParameter[] { });
            }
            #endregion FINAL 19OCT2018



            #region DATALOGS
            if (!this.totalSmartCodingEntities.ColumnExists("Locations", "OnDataLogs"))
            {
                this.totalSmartCodingEntities.ColumnAdd("Locations", "OnDataLogs", "int", "0", true);
                this.totalSmartCodingEntities.ColumnAdd("Locations", "OnEventLogs", "int", "0", true);
            }


            if (!this.totalSmartCodingEntities.TableExists("DataLogs"))
            {
                this.ExecuteStoreCommand(@"CREATE TABLE [dbo].[DataLogs](
	                                                    [DataLogID] [bigint] IDENTITY(1,1) NOT NULL,
	                                                    [LocationID] [int] NULL,
	                                                    [EntryID] [int] NULL,
	                                                    [EntryDetailID] [int] NULL,
	                                                    [EntryDate] [datetime] NULL,
	                                                    [ModuleName] [nvarchar](80) NULL,
	                                                    [UserName] [nvarchar](80) NULL,
	                                                    [IPAddress] [nvarchar](60) NULL,
	                                                    [ActionType] [nvarchar](60) NULL,
	                                                    [EntityName] [nvarchar](60) NULL,
	                                                    [PropertyName] [nvarchar](60) NULL,
	                                                    [PropertyValue] [nvarchar](500) NULL,
                                                     CONSTRAINT [PK_DataLogs] PRIMARY KEY CLUSTERED 
                                                    (
	                                                    [DataLogID] ASC
                                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                    ) ON [PRIMARY]	                                                
                                                ", new ObjectParameter[] { });
            }
            if (!this.totalSmartCodingEntities.TableExists("EventLogs"))
            {
                this.ExecuteStoreCommand(@"CREATE TABLE [dbo].[EventLogs](
	                                                    [EventLogID] [bigint] IDENTITY(1,1) NOT NULL,
	                                                    [LocationID] [int] NULL,
	                                                    [EntryDate] [datetime] NULL,
	                                                    [UserName] [nvarchar](80) NULL,
	                                                    [IPAddress] [nvarchar](60) NULL,
	                                                    [ModuleName] [nvarchar](80) NULL,
	                                                    [ActionType] [nvarchar](60) NULL,
	                                                    [EntryID] [int] NULL,
	                                                    [Remarks] [nvarchar](200) NULL,
                                                     CONSTRAINT [PK_EventLogs] PRIMARY KEY CLUSTERED 
                                                    (
	                                                    [EventLogID] ASC
                                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                    ) ON [PRIMARY]	                                                
                                                ", new ObjectParameter[] { });
            }
            if (!this.totalSmartCodingEntities.TableExists("LastEventLogs"))
            {
                this.ExecuteStoreCommand(@"CREATE TABLE [dbo].[LastEventLogs](
	                                                    [LastEventLogID] [int] IDENTITY(1,1) NOT NULL,
	                                                    [EventLogID] [bigint] NOT NULL,
	                                                    [UserName] [nvarchar](80) NOT NULL,
                                                     CONSTRAINT [PK_LastEventLogs] PRIMARY KEY CLUSTERED 
                                                    (
	                                                    [LastEventLogID] ASC
                                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                    ) ON [PRIMARY]	                                                
                                                ", new ObjectParameter[] { });
            }

            #endregion

            #region ConfigLogs

            if (false && !this.totalSmartCodingEntities.TableExists("ConfigLogs"))
            {
                this.ExecuteStoreCommand(@"CREATE TABLE [dbo].[ConfigLogs](
	                                                    [ConfigLogID] [int] IDENTITY(1,1) NOT NULL,
	                                                    [EntryDate] [datetime] NOT NULL,
	                                                    [ProcedureName] [nvarchar](100) NOT NULL,
	                                                    [Remarks] [nvarchar](100) NOT NULL,
                                                     CONSTRAINT [PK_ConfigLogs] PRIMARY KEY CLUSTERED 
                                                    (
	                                                    [ConfigLogID] ASC
                                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                    ) ON [PRIMARY]	                                                
                                                ", new ObjectParameter[] { });
            }
            #endregion


            #region ADD NEW MODULE: NmvnTaskID.MonthEnd
            var query = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.MonthEnd + ";", new object[] { });
            int exists = query.Cast<int>().Single();
            if (exists == 0)
            {
                this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive, ControlTypeID) VALUES(" + (int)GlobalEnums.NmvnTaskID.MonthEnd + ", 1, 'Month-end Closing', 'Month-end Closing', '#', '#', 'CUSTOMER MANAGEMENT', 1, 68, 1, 0, 0) ", new ObjectParameter[] { });
                this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.MonthEnd + " AS NMVNTaskID, OrganizationalUnitID, 1 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls WHERE (NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.Commodities + ") AND (SELECT COUNT(*) FROM AccessControls WHERE NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.MonthEnd + ") = 0", new ObjectParameter[] { });
            }
            #endregion ADD NEW MODULE: NmvnTaskID.MonthEnd



            #region NEW PERMISSION

            //MUST CALL this.UpdateUserControls() BEFORE CALL this.RestoreProcedures(): BECAUSE: WE ADD SOME CODE TO REGISTER REPORT CONTROL IN UserRegister 
            //VERY IMPORTANT: WE CALL OLD VERSION OF UserRegister IN this.UpdateUserControls() [UserRegister WITHOUT REPORT CONTROL]
            if (!this.totalSmartCodingEntities.TableExists("UserGroupReports"))
            {
                #region
                this.ExecuteStoreCommand(@"CREATE TABLE [dbo].[UserGroupReports](
	                                                        [UserGroupReportID] [int] IDENTITY(1,1) NOT NULL,
	                                                        [UserGroupID] [int] NOT NULL,
	                                                        [ReportID] [int] NOT NULL,
	                                                        [Enabled] [bit] NOT NULL,
                                                         CONSTRAINT [PK_UserGroupReports] PRIMARY KEY CLUSTERED 
                                                        (
	                                                        [UserGroupReportID] ASC
                                                        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                        ) ON [PRIMARY]	                                                
                                                ", new ObjectParameter[] { });


                #endregion

                this.UpdateUserControls();
            }






            if (!this.totalSmartCodingEntities.TableExists("UserSalespersons"))
            {
                if (true)
                {
                    this.ExecuteStoreCommand(@"CREATE TABLE [dbo].[UserSalespersons](
	                                                        [UserSalespersonID] [int] IDENTITY(1,1) NOT NULL,	
	                                                        [SecurityIdentifier] [nvarchar](256) NOT NULL,
	                                                        [EmployeeID] [int] NOT NULL,
	                                                        [EntryDate] [datetime] NOT NULL,
                                                         CONSTRAINT [PK_UserSalespersons] PRIMARY KEY CLUSTERED 
                                                        (
	                                                        [UserSalespersonID] ASC
                                                        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
                                                         CONSTRAINT [IX_UserSalespersons] UNIQUE NONCLUSTERED 
                                                        (
	                                                        [SecurityIdentifier] ASC,
	                                                        [EmployeeID] ASC
                                                        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                        ) ON [PRIMARY]	                                                
                                                ", new ObjectParameter[] { });
                }
            }
            #endregion



            #region 4L
            var query4L = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(FillingLineID) AS Expr1 FROM FillingLines WHERE FillingLineID = " + (int)GlobalVariables.FillingLine.Medium4L + ";", new object[] { });
            int exist4Ls = query4L.Cast<int>().Single();
            if (exist4Ls == 0)
            {
                this.ExecuteStoreCommand("INSERT INTO Configs (ConfigID, VersionID, VersionDate, Remarks, StoredID) VALUES(" + (int)GlobalVariables.FillingLine.Medium4L + ", " + GlobalVariables.ConfigVersionID((int)GlobalVariables.FillingLine.Medium4L) + ", GetDate(), NULL, " + GlobalVariables.ConfigVersionID((int)GlobalVariables.FillingLine.Medium4L) + ") ", new ObjectParameter[] { });
                this.ExecuteStoreCommand("INSERT INTO Configs (ConfigID, VersionID, VersionDate, Remarks, StoredID) VALUES(" + (int)GlobalVariables.FillingLine.Import + ", " + GlobalVariables.ConfigVersionID((int)GlobalVariables.FillingLine.Import) + ", GetDate(), NULL, " + GlobalVariables.ConfigVersionID((int)GlobalVariables.FillingLine.Import) + ") ", new ObjectParameter[] { });

                this.ExecuteStoreCommand("INSERT INTO FillingLines (FillingLineID, Code, Name, NickName, HasPack, HasCarton, HasPallet, LocationID, LastLogonFillingLineID, PortName, ServerID, ServerName, DatabaseName, Remarks, PalletChanged, InActive) VALUES(" + (int)GlobalVariables.FillingLine.Medium4L + ", N'S2', N'4 LITTRES', N'S2', 0, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0) ", new ObjectParameter[] { });
                this.ExecuteStoreCommand("INSERT INTO FillingLines (FillingLineID, Code, Name, NickName, HasPack, HasCarton, HasPallet, LocationID, LastLogonFillingLineID, PortName, ServerID, ServerName, DatabaseName, Remarks, PalletChanged, InActive) VALUES(" + (int)GlobalVariables.FillingLine.Import + ", N'IP', N'IMPORT', N'IP', 0, 1, 1, 1, NULL, NULL, NULL, NULL, NULL, NULL, 0, 0) ", new ObjectParameter[] { });
                #region INIT IP ADDRESS
                foreach (GlobalVariables.FillingLine fillingLine in Enum.GetValues(typeof(GlobalVariables.FillingLine)))
                {
                    if (fillingLine == GlobalVariables.FillingLine.Medium4L || fillingLine == GlobalVariables.FillingLine.Import)
                    {
                        foreach (GlobalVariables.PrinterName printerName in Enum.GetValues(typeof(GlobalVariables.PrinterName)))
                        {
                            string ipAddress = GlobalVariables.IpAddress(fillingLine, printerName);
                            if (ipAddress != "" & ipAddress != "127.0.0.1")
                                this.ExecuteStoreCommand("INSERT INTO FillingLineDetails (FillingLineID, DeviceID, IPv4Byte1, IPv4Byte2, IPv4Byte3, IPv4Byte4) VALUES (" + (int)fillingLine + ", " + (int)printerName + ", " + ipAddress.Substring(0, ipAddress.IndexOf(".")) + ", " + ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(0, ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".")) + ", " + ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".") + 1).Substring(0, ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".") + 1).IndexOf(".")) + ", " + ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".") + 1).IndexOf(".") + 1) + ")", new ObjectParameter[] { });
                        }

                        foreach (GlobalVariables.ScannerName scannerName in Enum.GetValues(typeof(GlobalVariables.ScannerName)))
                        {
                            string ipAddress = GlobalVariables.IpAddress(fillingLine, scannerName);
                            if (ipAddress != "" & ipAddress != "127.0.0.1")
                                this.ExecuteStoreCommand("INSERT INTO FillingLineDetails (FillingLineID, DeviceID, IPv4Byte1, IPv4Byte2, IPv4Byte3, IPv4Byte4) VALUES (" + (int)fillingLine + ", " + ((int)GlobalVariables.ScannerName.Base + (int)scannerName) + ", " + ipAddress.Substring(0, ipAddress.IndexOf(".")) + ", " + ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(0, ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".")) + ", " + ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".") + 1).Substring(0, ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".") + 1).IndexOf(".")) + ", " + ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".") + 1).IndexOf(".") + 1) + ")", new ObjectParameter[] { });
                        }
                    }
                }
                #endregion INIT IP ADDRESS


                Helpers.SqlProgrammability.Inventories.GoodsReceipt goodsReceipt = new Helpers.SqlProgrammability.Inventories.GoodsReceipt(totalSmartCodingEntities);
                goodsReceipt.RestoreProcedure19JUL2018();

            }

            #endregion 4L



            #region Reports

            if (true)
            {
                //this.ExecuteStoreCommand("DELETE FROM Reports WHERE ReportID IN (" + (int)GlobalEnums.ReportID.DataLogJournals + "," + (int)GlobalEnums.ReportID.EventLogJournals + "," + (int)GlobalEnums.ReportID.LastEventLogJournals + ")", new ObjectParameter[] { });
                //string reportTabPageIDs = ((int)GlobalEnums.ReportTabPageID.TabPageWarehouses).ToString() + "," + ((int)GlobalEnums.ReportTabPageID.TabPageCommodities).ToString();
                //string optionBoxIDs = GlobalEnums.OBx(GlobalEnums.OptionBoxID.FromDate) + GlobalEnums.OBx(GlobalEnums.OptionBoxID.ToDate);
                //this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.DataLogJournals + ", " + (int)GlobalEnums.ReportID.DataLogJournals + ", 20, 'X.LOGS', N'Data Logs', N'DataLogJournals', N'" + reportTabPageIDs + "', N'" + optionBoxIDs + GlobalEnums.OBx(GlobalEnums.OptionBoxID.UserName) + "', " + (int)GlobalEnums.ReportTypeID.Logs + ", 11, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
                //this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.EventLogJournals + ", " + (int)GlobalEnums.ReportID.EventLogJournals + ", 20, 'X.LOGS', N'Event Logs', N'EventLogJournals', N'" + reportTabPageIDs + "', N'" + optionBoxIDs + GlobalEnums.OBx(GlobalEnums.OptionBoxID.UserName) + "', " + (int)GlobalEnums.ReportTypeID.Logs + ", 16, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
                //this.ExecuteStoreCommand("SET IDENTITY_INSERT Reports ON  INSERT INTO Reports (ReportID, ReportUniqueID, ReportGroupID, ReportGroupName, ReportName, ReportURL, ReportTabPageIDs, OptionBoxIDs, ReportTypeID, SerialID, Remarks) VALUES (" + (int)GlobalEnums.ReportID.LastEventLogJournals + ", " + (int)GlobalEnums.ReportID.LastEventLogJournals + ", 20, 'X.LOGS', N'Latest Event Logs', N'EventLogJournals', N'" + reportTabPageIDs + "', N'" + optionBoxIDs + "', " + (int)GlobalEnums.ReportTypeID.Logs + ", 18, N'')      SET IDENTITY_INSERT Reports OFF ", new ObjectParameter[] { });
            }
            #endregion Reports



            #region ApplicationRoles
            if (!this.totalSmartCodingEntities.TableExists("ApplicationRoles"))
            {
                this.ExecuteStoreCommand(@"CREATE TABLE [dbo].[ApplicationRoles](
	                                                    [ApplicationRoleID] [int] NOT NULL,
	                                                    [Name] [nvarchar](100) NOT NULL,
	                                                    [Password] [nvarchar](100) NOT NULL,
	                                                    [EditedDate] [datetime] NOT NULL,
                                                     CONSTRAINT [PK_ApplicationRoles] PRIMARY KEY CLUSTERED 
                                                    (
	                                                    [ApplicationRoleID] ASC
                                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                    ) ON [PRIMARY]
                                                ", new ObjectParameter[] { });

                this.ExecuteStoreCommand(@" UPDATE Locations SET LockedDate = CONVERT(DATETIME, '2017-10-31 23:59:59', 102), EditedDate = GETDATE() ", new ObjectParameter[] { });
            }
            #endregion ApplicationRoles


            #region UserGroups
            if (!this.totalSmartCodingEntities.TableExists("UserGroups"))
            {
                this.ExecuteStoreCommand(@"CREATE TABLE [dbo].[UserGroups](
	                                                    [UserGroupID] [int] IDENTITY(1,1) NOT NULL,
	                                                    [Code] [nvarchar](50) NOT NULL,
	                                                    [Name] [nvarchar](100) NOT NULL,
	                                                    [Description] [nvarchar](100) NULL,
	                                                    [Remarks] [nvarchar](100) NULL,
                                                     CONSTRAINT [PK_ControlGroups] PRIMARY KEY CLUSTERED 
                                                    (
	                                                    [UserGroupID] ASC
                                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                    ) ON [PRIMARY]	                                                
                                                ", new ObjectParameter[] { });

                this.ExecuteStoreCommand(@"	CREATE TABLE [dbo].[UserGroupDetails](
	                                                        [UserGroupDetailID] [int] IDENTITY(1,1) NOT NULL,
	                                                        [UserGroupID] [int] NOT NULL,
	                                                        [SecurityIdentifier] [nvarchar](256) NOT NULL,
	                                                        [EntryDate] [datetime] NOT NULL,
                                                         CONSTRAINT [PK_UserGroupDetails] PRIMARY KEY CLUSTERED 
                                                        (
	                                                        [UserGroupDetailID] ASC
                                                        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY],
                                                         CONSTRAINT [IX_UserGroupDetails] UNIQUE NONCLUSTERED 
                                                        (
	                                                        [UserGroupID] ASC,
	                                                        [SecurityIdentifier] ASC
                                                        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                        ) ON [PRIMARY]                                                
                                                ", new ObjectParameter[] { });

                this.ExecuteStoreCommand(@"	 CREATE TABLE [dbo].[UserGroupControls](
	                                                        [UserGroupControlID] [int] IDENTITY(1,1) NOT NULL,
	                                                        [UserGroupID] [int] NOT NULL,
	                                                        [ModuleDetailID] [int] NOT NULL,
	                                                        [LocationID] [int] NOT NULL,
	                                                        [AccessLevel] [int] NOT NULL,
	                                                        [ApprovalPermitted] [bit] NOT NULL,
	                                                        [UnApprovalPermitted] [bit] NOT NULL,
	                                                        [VoidablePermitted] [bit] NOT NULL,
	                                                        [UnVoidablePermitted] [bit] NOT NULL,
	                                                        [ShowDiscount] [bit] NOT NULL,
	                                                        [AccessLevelBACKUP] [int] NULL,
	                                                        [ApprovalPermittedBACKUP] [bit] NULL,
	                                                        [UnApprovalPermittedBACKUP] [bit] NULL,
	                                                        [InActive] [bit] NOT NULL,
                                                            CONSTRAINT [PK_PermissionControls] PRIMARY KEY CLUSTERED 
                                                        (
	                                                        [UserGroupControlID] ASC
                                                        )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                        ) ON [PRIMARY]


                                                        ALTER TABLE [dbo].[UserGroupControls]  WITH CHECK ADD  CONSTRAINT [FK_UserGroupControls_Locations] FOREIGN KEY([LocationID])
                                                        REFERENCES [dbo].[Locations] ([LocationID])


                                                        ALTER TABLE [dbo].[UserGroupControls] CHECK CONSTRAINT [FK_UserGroupControls_Locations]


                                                        ALTER TABLE [dbo].[UserGroupControls]  WITH CHECK ADD  CONSTRAINT [FK_UserGroupControls_ModuleDetails] FOREIGN KEY([ModuleDetailID])
                                                        REFERENCES [dbo].[ModuleDetails] ([ModuleDetailID])


                                                        ALTER TABLE [dbo].[UserGroupControls] CHECK CONSTRAINT [FK_UserGroupControls_ModuleDetails]


                                                        ALTER TABLE [dbo].[UserGroupControls]  WITH CHECK ADD  CONSTRAINT [FK_UserGroupControls_UserGroups] FOREIGN KEY([UserGroupID])
                                                        REFERENCES [dbo].[UserGroups] ([UserGroupID])


                                                        ALTER TABLE [dbo].[UserGroupControls] CHECK CONSTRAINT [FK_UserGroupControls_UserGroups]                                               
                                                ", new ObjectParameter[] { });

            }
            #endregion


            #region Devices
            if (!this.totalSmartCodingEntities.TableExists("Devices"))
            {
                this.ExecuteStoreCommand(@"CREATE TABLE [dbo].[Devices](
	                                                [DeviceID] [int] NOT NULL,
	                                                [Code] [nvarchar](60) NOT NULL,
	                                                [Name] [nvarchar](60) NOT NULL,
                                                 CONSTRAINT [PK_Devices] PRIMARY KEY CLUSTERED 
                                                    ([DeviceID] ASC
                                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                    ) ON [PRIMARY]	                                                
                                                ", new ObjectParameter[] { });


                this.ExecuteStoreCommand(@"                                                              
                                        
                                            INSERT INTO Devices (DeviceID, Code, Name)   VALUES (1, N'Digit Printer', N'Digit Printer')
                                            INSERT INTO Devices (DeviceID, Code, Name)   VALUES (2, N'2D Printer', N'2D Printer')
                                            INSERT INTO Devices (DeviceID, Code, Name)   VALUES (3, N'Carton/ Pail Printer', N'Carton/ Pail Printer')
                                            INSERT INTO Devices (DeviceID, Code, Name)   VALUES (100002, N'Matching Scanner', N'Matching Scanner')
                                            INSERT INTO Devices (DeviceID, Code, Name)   VALUES (100003, N'Carton/ Pail Scanner', N'Carton/ Pail Scanner')
                                            INSERT INTO Devices (DeviceID, Code, Name)   VALUES (100006, N'Label Scanner', N'Label Scanner')

                                             ", new ObjectParameter[] { });



                this.ExecuteStoreCommand(@" CREATE TABLE [dbo].[FillingLineDetails](
	                                                    [FillingLineDetailID] [int] IDENTITY(1,1) NOT NULL,
	                                                    [FillingLineID] [int] NOT NULL,
	                                                    [DeviceID] [int] NOT NULL,
	                                                    [IPv4Byte1] [int] NOT NULL,
	                                                    [IPv4Byte2] [int] NOT NULL,
	                                                    [IPv4Byte3] [int] NOT NULL,
	                                                    [IPv4Byte4] [int] NOT NULL,
                                                     CONSTRAINT [PK_FillingLineDetails] PRIMARY KEY CLUSTERED 
                                                    (
	                                                    [FillingLineDetailID] ASC
                                                    )WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
                                                    ) ON [PRIMARY]

                                                    ALTER TABLE [dbo].[FillingLineDetails]  WITH CHECK ADD  CONSTRAINT [FK_FillingLineDetails_Devices] FOREIGN KEY([DeviceID])
                                                    REFERENCES [dbo].[Devices] ([DeviceID])

                                                    ALTER TABLE [dbo].[FillingLineDetails] CHECK CONSTRAINT [FK_FillingLineDetails_Devices]

                                                    ALTER TABLE [dbo].[FillingLineDetails]  WITH CHECK ADD  CONSTRAINT [FK_FillingLineDetails_FillingLines] FOREIGN KEY([FillingLineID])
                                                    REFERENCES [dbo].[FillingLines] ([FillingLineID])

                                                    ALTER TABLE [dbo].[FillingLineDetails] CHECK CONSTRAINT [FK_FillingLineDetails_FillingLines]
                                                ", new ObjectParameter[] { });


                this.ExecuteStoreCommand(@" SET IDENTITY_INSERT FillingLineDetails ON                                                              
                                        
                                            INSERT INTO FillingLineDetails (FillingLineDetailID, FillingLineID, DeviceID, IPv4Byte1, IPv4Byte2, IPv4Byte3, IPv4Byte4) VALUES (1, 1, 1, 172, 21, 67, 157)
                                            INSERT INTO FillingLineDetails (FillingLineDetailID, FillingLineID, DeviceID, IPv4Byte1, IPv4Byte2, IPv4Byte3, IPv4Byte4) VALUES (2, 1, 2, 172, 21, 67, 158)
                                            INSERT INTO FillingLineDetails (FillingLineDetailID, FillingLineID, DeviceID, IPv4Byte1, IPv4Byte2, IPv4Byte3, IPv4Byte4) VALUES (3, 1, 3, 172, 21, 67, 159)
                                            INSERT INTO FillingLineDetails (FillingLineDetailID, FillingLineID, DeviceID, IPv4Byte1, IPv4Byte2, IPv4Byte3, IPv4Byte4) VALUES (4, 1, 100002, 172, 21, 67, 168)
                                            INSERT INTO FillingLineDetails (FillingLineDetailID, FillingLineID, DeviceID, IPv4Byte1, IPv4Byte2, IPv4Byte3, IPv4Byte4) VALUES (5, 1, 100003, 172, 21, 67, 169)
                                            INSERT INTO FillingLineDetails (FillingLineDetailID, FillingLineID, DeviceID, IPv4Byte1, IPv4Byte2, IPv4Byte3, IPv4Byte4) VALUES (6, 1, 100006, 172, 21, 67, 170)
                                            INSERT INTO FillingLineDetails (FillingLineDetailID, FillingLineID, DeviceID, IPv4Byte1, IPv4Byte2, IPv4Byte3, IPv4Byte4) VALUES (7, 2, 1, 172, 21, 67, 165)
                                            INSERT INTO FillingLineDetails (FillingLineDetailID, FillingLineID, DeviceID, IPv4Byte1, IPv4Byte2, IPv4Byte3, IPv4Byte4) VALUES (8, 2, 3, 172, 21, 67, 163)
                                            INSERT INTO FillingLineDetails (FillingLineDetailID, FillingLineID, DeviceID, IPv4Byte1, IPv4Byte2, IPv4Byte3, IPv4Byte4) VALUES (9, 2, 100003, 172, 21, 67, 172)
                                            INSERT INTO FillingLineDetails (FillingLineDetailID, FillingLineID, DeviceID, IPv4Byte1, IPv4Byte2, IPv4Byte3, IPv4Byte4) VALUES (10, 2, 100006, 172, 21, 67, 173)
                                            INSERT INTO FillingLineDetails (FillingLineDetailID, FillingLineID, DeviceID, IPv4Byte1, IPv4Byte2, IPv4Byte3, IPv4Byte4) VALUES (11, 3, 1, 172, 21, 67, 167)
                                            INSERT INTO FillingLineDetails (FillingLineDetailID, FillingLineID, DeviceID, IPv4Byte1, IPv4Byte2, IPv4Byte3, IPv4Byte4) VALUES (12, 3, 100006, 172, 21, 67, 175)

                                            SET IDENTITY_INSERT FillingLineDetails OFF ", new ObjectParameter[] { });

            }
            #endregion Devices


            #region

            if (!this.totalSmartCodingEntities.ColumnExists("ModuleDetails", "ControlTypeID"))
            {
                this.totalSmartCodingEntities.ColumnAdd("ModuleDetails", "ControlTypeID", "int", "0", true);
                this.ExecuteStoreCommand("UPDATE ModuleDetails SET ControlTypeID = 1 WHERE ModuleID = 6 ", new ObjectParameter[] { });
            }
            #endregion




            #region EmployeeLocationIDs & Roles
            this.totalSmartCodingEntities.ColumnAdd("Employees", "InActive", "bit", "0", true);
            if (!this.totalSmartCodingEntities.ColumnExists("Employees", "EmployeeRoleIDs"))
            {
                this.ExecuteStoreCommand("UPDATE ModuleDetails SET InActive = 1 WHERE ModuleDetailID IN (" + (int)GlobalEnums.NmvnTaskID.AvailableItems + ", " + (int)GlobalEnums.NmvnTaskID.PendingOrders + ") ", new ObjectParameter[] { });

                this.ExecuteStoreCommand("UPDATE Employees SET Title = N'#'", new ObjectParameter[] { });

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










            #region 01SEP2018
            query = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.FillingLine + ";", new object[] { });
            exists = query.Cast<int>().Single();
            if (exists == 0)
            {
                this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive) VALUES(" + (int)GlobalEnums.NmvnTaskID.FillingLine + ", 108, 'IP Settings', 'IP Settings', '#', '#', '#', 1, 68, 1, 0) ", new ObjectParameter[] { });
                this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.FillingLine + " AS NMVNTaskID, OrganizationalUnitID, 1 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls WHERE (NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.Commodities + ") AND (SELECT COUNT(*) FROM AccessControls WHERE NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.FillingLine + ") = 0", new ObjectParameter[] { });


                #region INIT IP ADDRESS
                //foreach (GlobalVariables.PrinterName printerName in Enum.GetValues(typeof(GlobalVariables.PrinterName)))
                //{
                //    string ipAddress = GlobalVariables.IpAddress(printerName);
                //    if (ipAddress != "" & ipAddress != "127.0.0.1")
                //        this.ExecuteStoreCommand("INSERT INTO FillingLineDetails (FillingLineID, DeviceID, IPv4Byte1, IPv4Byte2, IPv4Byte3, IPv4Byte4) VALUES (" + (int)GlobalVariables.FillingLineID + ", " + (int)printerName + ", " + ipAddress.Substring(0, ipAddress.IndexOf(".")) + ", " + ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(0, ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".")) + ", " + ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".") + 1).Substring(0, ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".") + 1).IndexOf(".")) + ", " + ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".") + 1).IndexOf(".") + 1) + ")", new ObjectParameter[] { });
                //}

                //foreach (GlobalVariables.ScannerName scannerName in Enum.GetValues(typeof(GlobalVariables.ScannerName)))
                //{
                //    string ipAddress = GlobalVariables.IpAddress(scannerName);
                //    if (ipAddress != "" & ipAddress != "127.0.0.1")
                //        this.ExecuteStoreCommand("INSERT INTO FillingLineDetails (FillingLineID, DeviceID, IPv4Byte1, IPv4Byte2, IPv4Byte3, IPv4Byte4) VALUES (" + (int)GlobalVariables.FillingLineID + ", " + ((int)GlobalVariables.ScannerName.Base + (int)scannerName) + ", " + ipAddress.Substring(0, ipAddress.IndexOf(".")) + ", " + ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(0, ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".")) + ", " + ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".") + 1).Substring(0, ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".") + 1).IndexOf(".")) + ", " + ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).Substring(ipAddress.Substring(ipAddress.IndexOf(".") + 1).IndexOf(".") + 1).IndexOf(".") + 1) + ")", new ObjectParameter[] { });
                //}
                #endregion INIT IP ADDRESS
            }




            this.totalSmartCodingEntities.ColumnAdd("Batches", "AutoBarcode", "bit", "0", true);
            this.totalSmartCodingEntities.ColumnAdd("Batches", "FinalCartonNo", "nvarchar(10)", "000001", true);


            #endregion 01SEP2018



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

                this.ExecuteStoreCommand("UPDATE ModuleDetails SET Controller = N'WAREHOUSE RESOURCES' WHERE ModuleDetailID IN (" + (int)GlobalEnums.NmvnTaskID.Commodities + "," + (int)GlobalEnums.NmvnTaskID.BinLocations + "," + (int)GlobalEnums.NmvnTaskID.Warehouses + ") ", new ObjectParameter[] { });
                this.ExecuteStoreCommand("UPDATE ModuleDetails SET Controller = N'CUSTOMER MANAGEMENT' WHERE ModuleDetailID IN (" + (int)GlobalEnums.NmvnTaskID.Employees + "," + (int)GlobalEnums.NmvnTaskID.Customers + "," + (int)GlobalEnums.NmvnTaskID.Territories + ") ", new ObjectParameter[] { });

                this.ExecuteStoreCommand("UPDATE ModuleDetails SET Controller = N'LOGISTICS ADMIN', ModuleID = 6 WHERE ModuleDetailID IN (" + (int)GlobalEnums.NmvnTaskID.SalesOrders + "," + (int)GlobalEnums.NmvnTaskID.DeliveryAdvices + "," + (int)GlobalEnums.NmvnTaskID.TransferOrders + ") ", new ObjectParameter[] { });
                this.ExecuteStoreCommand("UPDATE ModuleDetails SET Controller = N'WAREHOUSE CONTROLS', ModuleID = 6 WHERE ModuleDetailID IN (" + (int)GlobalEnums.NmvnTaskID.GoodsReceipts + "," + (int)GlobalEnums.NmvnTaskID.GoodsIssues + "," + (int)GlobalEnums.NmvnTaskID.WarehouseAdjustments + "," + (int)GlobalEnums.NmvnTaskID.AvailableItems + ") ", new ObjectParameter[] { });

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


                this.ExecuteStoreCommand(@" SET IDENTITY_INSERT ColumnMappings ON                                                              
                                        
                                            INSERT INTO ColumnMappings (ColumnMappingID, MappingTaskID, ColumnID, ColumnName, ColumnDisplayName, ColumnMappingName, SerialID, ImportedDate)   VALUES (1, 8076, 2, N'WarehouseCode', N'WH code', N'WH Code', 10, Getdate())
                                            INSERT INTO ColumnMappings (ColumnMappingID, MappingTaskID, ColumnID, ColumnName, ColumnDisplayName, ColumnMappingName, SerialID, ImportedDate)   VALUES (2, 8076, 6, N'CommodityCode', N'Product code', N'Product code', 20, Getdate())
                                            INSERT INTO ColumnMappings (ColumnMappingID, MappingTaskID, ColumnID, ColumnName, ColumnDisplayName, ColumnMappingName, SerialID, ImportedDate)   VALUES (3, 8076, 8, N'CurrentMonth', N'Current month', N'17-Oct', 30, Getdate())
                                            INSERT INTO ColumnMappings (ColumnMappingID, MappingTaskID, ColumnID, ColumnName, ColumnDisplayName, ColumnMappingName, SerialID, ImportedDate)   VALUES (4, 8076, 12, N'NextMonth', N'Next month', N'17-Nov', 60, Getdate())
                                            INSERT INTO ColumnMappings (ColumnMappingID, MappingTaskID, ColumnID, ColumnName, ColumnDisplayName, ColumnMappingName, SerialID, ImportedDate)   VALUES (5, 8076, 16, N'NextTwoMonth', N'Next two month', N'17-Dec', 70, Getdate())
                                            INSERT INTO ColumnMappings (ColumnMappingID, MappingTaskID, ColumnID, ColumnName, ColumnDisplayName, ColumnMappingName, SerialID, ImportedDate)   VALUES (6, 8076, 18, N'NextThreeMonth', N'Next three monnth', N'18-Jan', 80, Getdate())

                                            SET IDENTITY_INSERT ColumnMappings OFF ", new ObjectParameter[] { });

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
            query = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.Forecasts + ";", new object[] { });
            exists = query.Cast<int>().Single();
            if (exists == 0)
            {
                this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive) VALUES(" + (int)GlobalEnums.NmvnTaskID.Forecasts + ", 6, N'Sales Forecast', N'Sales Forecast', '#', '#', N'LOGISTICS ADMIN', 1, 6, 1, 0) ", new ObjectParameter[] { });
                this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.Forecasts + " AS NMVNTaskID, OrganizationalUnitID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls WHERE (NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.Commodities + ") AND (SELECT COUNT(*) FROM AccessControls WHERE NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.Forecasts + ") = 0", new ObjectParameter[] { });

                //********************
                this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive) VALUES(" + (int)GlobalEnums.NmvnTaskID.CommoditySettings + ", 1, 'Low, High & Alert Settings', 'Low, High & Alert Settings', '#', '#', 'WAREHOUSE RESOURCES', 1, 12, 1, 0) ", new ObjectParameter[] { });
                this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.CommoditySettings + " AS NMVNTaskID, OrganizationalUnitID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls WHERE (NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.Commodities + ") AND (SELECT COUNT(*) FROM AccessControls WHERE NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.CommoditySettings + ") = 0", new ObjectParameter[] { });
                //********************
            }



            query = this.totalSmartCodingEntities.Database.SqlQuery(typeof(int), "SELECT COUNT(ModuleDetailID) AS Expr1 FROM ModuleDetails WHERE ModuleDetailID = " + (int)GlobalEnums.NmvnTaskID.PendingOrders + ";", new object[] { });
            exists = query.Cast<int>().Single();
            if (exists == 0)
            {
                this.ExecuteStoreCommand("INSERT INTO ModuleDetails (ModuleDetailID, ModuleID, Code, Name, FullName, Actions, Controller, LastOpen, SerialID, ImageIndex, InActive) VALUES(" + (int)GlobalEnums.NmvnTaskID.PendingOrders + ", 6, N'Current Pending Orders', N'Current Pending Orders', '#', '#', N'LOGISTICS ADMIN', 1, 68, 1, 0) ", new ObjectParameter[] { });
                this.ExecuteStoreCommand("INSERT INTO AccessControls (UserID, NMVNTaskID, OrganizationalUnitID, AccessLevel, ApprovalPermitted, UnApprovalPermitted, VoidablePermitted, UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive) SELECT UserID, " + (int)GlobalEnums.NmvnTaskID.PendingOrders + " AS NMVNTaskID, OrganizationalUnitID, 1 AS AccessLevel, 0 AS ApprovalPermitted, 0 AS UnApprovalPermitted, 0 AS VoidablePermitted, 0 AS UnVoidablePermitted, ShowDiscount, AccessLevelBACKUP, ApprovalPermittedBACKUP, UnApprovalPermittedBACKUP, InActive FROM AccessControls WHERE (NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.SalesOrders + ") AND (SELECT COUNT(*) FROM AccessControls WHERE NMVNTaskID = " + (int)GlobalEnums.NmvnTaskID.PendingOrders + ") = 0", new ObjectParameter[] { });
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

        public void GetApplicationRoles()
        {
            IList<ApplicationRole> applicationRoles = this.TotalSmartCodingEntities.GetApplicationRoles(1).ToList();
            if (applicationRoles != null && applicationRoles.Count > 0)
            {
                if (applicationRoles[0].Name != null) ApplicationRoles.Name = SecurePassword.Decrypt(applicationRoles[0].Name);
                if (applicationRoles[0].Password != null) ApplicationRoles.Password = SecurePassword.Decrypt(applicationRoles[0].Password);
            }
        }

        public int UpdateApplicationRole(string name, string password)
        {
            return this.TotalSmartCodingEntities.UpdateApplicationRole(1, name, password);
        }

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

        public string GetLegalNotice()
        {
            return this.TotalSmartCodingEntities.GetLegalNotice().Single();
        }
        public int UpdateLegalNotice(string legalNotice)
        {
            return this.TotalSmartCodingEntities.UpdateLegalNotice(legalNotice);
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


        #region Smart Logs
        public string DataSource
        {
            get { return this.TotalSmartCodingEntities.Database.Connection.DataSource; } // + " [" + this.TotalSmartCodingEntities.Database.Connection.Database + "]"
        }

        public bool GetOnDataLogs()
        {
            int? onDataLogs = this.TotalSmartCodingEntities.GetOnDataLogs().Single();
            return (onDataLogs != null && onDataLogs == 1);
        }

        public bool GetOnEventLogs()
        {
            int? onDataLogs = this.TotalSmartCodingEntities.GetOnEventLogs().Single();
            return (onDataLogs != null && onDataLogs == 1);
        }

        public void AddDataLogs(int? entryID, int? entryDetailID, DateTime? entryDate, string moduleName, string actionType, string entityName, string propertyName, string propertyValue)
        {
            this.TotalSmartCodingEntities.AddDataLogs(ContextAttributes.User.LocationID, entryID, entryDetailID, entryDate, moduleName, ContextAttributes.User.UserName, ContextAttributes.LocalIPAddress, actionType, entityName, propertyName, propertyValue);
        }
        public void AddEventLogs(string moduleName, string actionType, int? entryID, string remarks)
        {
            this.TotalSmartCodingEntities.AddEventLogs(ContextAttributes.User.LocationID, DateTime.Now, ContextAttributes.User.UserName, ContextAttributes.LocalIPAddress, moduleName, actionType, entryID, remarks);
        }
        #endregion Smart Logs
    }
}

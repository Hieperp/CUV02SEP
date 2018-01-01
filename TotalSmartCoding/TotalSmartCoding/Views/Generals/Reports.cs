﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Ninject;


using TotalSmartCoding.Views.Mains;


using TotalSmartCoding.Libraries;
using TotalSmartCoding.Libraries.Helpers;

using TotalSmartCoding.Controllers.APIs.Inventories;
using TotalBase;
using TotalModel.Models;
using TotalSmartCoding.ViewModels.Helpers;
using TotalSmartCoding.ViewModels.Inventories;
using TotalSmartCoding.Controllers.APIs.Generals;
using TotalCore.Repositories.Commons;
using BrightIdeasSoftware;
using TotalBase.Enums;
using TotalCore.Repositories.Generals;
using TotalSmartCoding.Controllers.APIs.Commons;


namespace TotalSmartCoding.Views.Generals
{
    public partial class Reports : BaseView
    {
        private TabPage tabPageWarehouses;
        private TabPage tabPageCommodities;
        private TabPage tabPageCustomers;
        private TabPage tabPageWarehouseIssues;
        private TabPage tabPageWarehouseReceipts;
        private TabPage tabPageWarehouseAdjustmentTypes;
        private TabPage[] tabPages;
        private CustomTabControl customTabBatch;

        private ReportAPIs reportAPIs;

        private ReportIndex currentReportIndex;

        public Reports()
            : base()
        {
            InitializeComponent();

            this.toolstripChild = this.toolStripChildForm;
            this.fastListIndex = this.fastReportIndex;

            this.reportAPIs = new ReportAPIs(CommonNinject.Kernel.Get<IReportAPIRepository>());

            this.baseDTO = new GoodsReceiptDetailAvailableViewModel(); ;
        }

        protected override void InitializeTabControl()
        {
            try
            {
                base.InitializeTabControl();

                this.tabPageWarehouses = new TabPage("Locations"); this.tabPageWarehouses.Tag = (int)GlobalEnums.ReportTabPageID.TabPageWarehouses;
                this.tabPageCommodities = new TabPage("Commodities"); this.tabPageCommodities.Tag = (int)GlobalEnums.ReportTabPageID.TabPageCommodities;
                this.tabPageCustomers = new TabPage("Customers"); this.tabPageCustomers.Tag = (int)GlobalEnums.ReportTabPageID.TabPageCustomers;
                this.tabPageWarehouseIssues = new TabPage("Source Warehouses"); this.tabPageWarehouseIssues.Tag = (int)GlobalEnums.ReportTabPageID.TabPageWarehouseIssues;
                this.tabPageWarehouseReceipts = new TabPage("Destination Warehouses"); this.tabPageWarehouseReceipts.Tag = (int)GlobalEnums.ReportTabPageID.TabPageWarehouseReceipts;
                this.tabPageWarehouseAdjustmentTypes = new TabPage("Adjustment Types"); this.tabPageWarehouseAdjustmentTypes.Tag = (int)GlobalEnums.ReportTabPageID.TabPageWarehouseAdjustmentTypes;

                this.tabPages = new TabPage[] { this.tabPageWarehouses, this.tabPageCommodities, this.tabPageCustomers, this.tabPageWarehouseIssues, this.tabPageWarehouseReceipts, this.tabPageWarehouseAdjustmentTypes };

                this.customTabBatch = new CustomTabControl();
                this.customTabBatch.Font = this.treeWarehouseID.Font;
                this.customTabBatch.DisplayStyle = TabStyle.VisualStudio;
                this.customTabBatch.DisplayStyleProvider.ImageAlign = ContentAlignment.MiddleLeft;

                this.tabPageWarehouses.Controls.Add(this.treeWarehouseID);
                this.tabPageCommodities.Controls.Add(this.panelCommodities);
                this.tabPageCustomers.Controls.Add(this.panelCustomers);
                this.tabPageWarehouseIssues.Controls.Add(this.treeWarehouseIssueID);
                this.tabPageWarehouseReceipts.Controls.Add(this.treeWarehouseReceiptID);
                this.tabPageWarehouseAdjustmentTypes.Controls.Add(this.treeWarehouseAdjustmentTypeID);

                this.treeWarehouseID.Dock = DockStyle.Fill;
                this.panelCommodities.Dock = DockStyle.Fill;
                this.panelCustomers.Dock = DockStyle.Fill;
                this.treeWarehouseIssueID.Dock = DockStyle.Fill;
                this.treeWarehouseReceiptID.Dock = DockStyle.Fill;
                this.treeWarehouseAdjustmentTypeID.Dock = DockStyle.Fill;

                this.customTabBatch.Dock = DockStyle.Fill;
                this.panelCenter.Controls.Add(this.customTabBatch);
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        protected override void InitializeReadOnlyModeBinding()
        {
            base.InitializeReadOnlyModeBinding();
            this.dateTimexEntryDate.ReadOnly = false;
            this.dateTimexPicker1.ReadOnly = false;
        }
        private IList<WarehouseTree> warehouseTrees;
        private IList<CommodityTree> commodityTrees;
        private IList<CommodityTypeTree> commodityTypeTrees;
        private IList<CustomerTree> customerTrees;
        private IList<EmployeeTree> employeeTrees;
        private IList<WarehouseTree> warehouseIssueTrees;
        private IList<WarehouseTree> warehouseReceiptTrees;
        private IList<WarehouseAdjustmentTypeTree> warehouseAdjustmentTypeTrees;

        protected override void InitializeCommonControlBinding()
        {
            base.InitializeCommonControlBinding();

            this.treeWarehouseID.RootKeyValue = 0;
            this.treeCommodityID.RootKeyValue = 0;
            this.treeCommodityTypeID.RootKeyValue = 0;
            this.treeCustomerID.RootKeyValue = 0;
            this.treeEmployeeID.RootKeyValue = 0;
            this.treeWarehouseIssueID.RootKeyValue = 0;
            this.treeWarehouseReceiptID.RootKeyValue = 0;
            this.treeWarehouseAdjustmentTypeID.RootKeyValue = 0;

            WarehouseAPIs warehouseAPIs = new WarehouseAPIs(CommonNinject.Kernel.Get<IWarehouseAPIRepository>());
            this.warehouseTrees = warehouseAPIs.GetWarehouseTrees();
            this.treeWarehouseID.DataSource = new BindingSource(this.warehouseTrees, "");

            this.warehouseIssueTrees = warehouseAPIs.GetWarehouseTrees();
            this.treeWarehouseIssueID.DataSource = new BindingSource(this.warehouseIssueTrees, "");

            this.warehouseReceiptTrees = warehouseAPIs.GetWarehouseTrees();
            this.treeWarehouseReceiptID.DataSource = new BindingSource(this.warehouseReceiptTrees, "");

            WarehouseAdjustmentTypeAPIs warehouseAdjustmentTypeAPIs = new WarehouseAdjustmentTypeAPIs(CommonNinject.Kernel.Get<IWarehouseAdjustmentTypeAPIRepository>());
            this.warehouseAdjustmentTypeTrees = warehouseAdjustmentTypeAPIs.GetWarehouseAdjustmentTypeTrees();
            this.treeWarehouseAdjustmentTypeID.DataSource = new BindingSource(this.warehouseAdjustmentTypeTrees, "");

            CommodityAPIs commodityAPIs = new CommodityAPIs(CommonNinject.Kernel.Get<ICommodityAPIRepository>());
            this.commodityTrees = commodityAPIs.GetCommodityTrees();
            this.treeCommodityID.DataSource = new BindingSource(this.commodityTrees, "");

            CommodityTypeAPIs commodityTypeAPIs = new CommodityTypeAPIs(CommonNinject.Kernel.Get<ICommodityTypeAPIRepository>());
            this.commodityTypeTrees = commodityTypeAPIs.GetCommodityTypeTrees();
            this.treeCommodityTypeID.DataSource = new BindingSource(this.commodityTypeTrees, "");

            CustomerAPIs customerAPIs = new CustomerAPIs(CommonNinject.Kernel.Get<ICustomerAPIRepository>());
            this.customerTrees = customerAPIs.GetCustomerTrees();
            this.treeCustomerID.DataSource = new BindingSource(this.customerTrees, "");

            EmployeeAPIs employeeAPIs = new EmployeeAPIs(CommonNinject.Kernel.Get<IEmployeeAPIRepository>());
            this.employeeTrees = employeeAPIs.GetEmployeeTrees();
            this.treeEmployeeID.DataSource = new BindingSource(this.employeeTrees, "");

            this.comboQuantityVersusVolume.ComboBox.Items.AddRange(new string[] { "By quantity", "By volume" });
            this.comboQuantityVersusVolume.ComboBox.SelectedIndex = 1;

            this.comboDateVersusMonth.ComboBox.Items.AddRange(new string[] { "Daily summary", "Monthly summary" });
            this.comboDateVersusMonth.ComboBox.SelectedIndex = 1;

            this.comboSalesVersusPromotion.ComboBox.Items.AddRange(new string[] { "Both sales & promotions", "Sales only", "Promotions only" });
            this.comboSalesVersusPromotion.ComboBox.SelectedIndex = 0;

            this.fastReportIndex.AboutToCreateGroups += fastReportIndex_AboutToCreateGroups;
            this.fastReportIndex.ShowGroups = true;
            //this.olvApproved.Renderer = new MappedImageRenderer(new Object[] { 1, Resources.Placeholder16, 2, Resources.Void_16 });
        }

        private void fastReportIndex_AboutToCreateGroups(object sender, CreateGroupsEventArgs e)
        {
            if (e.Groups != null && e.Groups.Count > 0)
            {
                foreach (OLVGroup olvGroup in e.Groups)
                {
                    olvGroup.TitleImage = "Analytics";
                    olvGroup.Subtitle = "Count: " + olvGroup.Contents.Count.ToString() + " Report(s)";
                }
            }
        }

        public override void Loading()
        {
            this.fastReportIndex.SetObjects(this.reportAPIs.GetReportIndexes());

            base.Loading();
        }

        protected override void DoAfterLoad()
        {
            base.DoAfterLoad();
            this.fastReportIndex.Sort(this.olvReportGroupName, SortOrder.Descending);

            if (this.treeWarehouseID.GetModelObject(0) != null) { this.treeWarehouseID.Expand(this.treeWarehouseID.GetModelObject(0)); if (this.treeWarehouseID.Items.Count >= 2) this.treeWarehouseID.SelectedIndex = 1; }
            if (this.treeCommodityID.GetModelObject(0) != null) { this.treeCommodityID.Expand(this.treeCommodityID.GetModelObject(0)); if (this.treeCommodityID.Items.Count >= 2) this.treeCommodityID.SelectedIndex = 1; }
            if (this.treeCommodityTypeID.GetModelObject(0) != null) { this.treeCommodityTypeID.Expand(this.treeCommodityTypeID.GetModelObject(0)); if (this.treeCommodityTypeID.Items.Count >= 2) this.treeCommodityTypeID.SelectedIndex = 1; }
            if (this.treeCustomerID.GetModelObject(0) != null) { this.treeCustomerID.Expand(this.treeCustomerID.GetModelObject(0)); if (this.treeCustomerID.Items.Count >= 2) this.treeCustomerID.SelectedIndex = 1; }
            if (this.treeEmployeeID.GetModelObject(0) != null) { this.treeEmployeeID.Expand(this.treeEmployeeID.GetModelObject(0)); if (this.treeEmployeeID.Items.Count >= 2) this.treeEmployeeID.SelectedIndex = 1; }
            if (this.treeWarehouseIssueID.GetModelObject(0) != null) { this.treeWarehouseIssueID.Expand(this.treeWarehouseIssueID.GetModelObject(0)); if (this.treeWarehouseIssueID.Items.Count >= 2) this.treeWarehouseIssueID.SelectedIndex = 1; }
            if (this.treeWarehouseReceiptID.GetModelObject(0) != null) { this.treeWarehouseReceiptID.Expand(this.treeWarehouseReceiptID.GetModelObject(0)); if (this.treeWarehouseReceiptID.Items.Count >= 2) this.treeWarehouseReceiptID.SelectedIndex = 1; }
            if (this.treeWarehouseAdjustmentTypeID.GetModelObject(0) != null) { this.treeWarehouseAdjustmentTypeID.Expand(this.treeWarehouseAdjustmentTypeID.GetModelObject(0)); if (this.treeWarehouseAdjustmentTypeID.Items.Count >= 2) this.treeWarehouseAdjustmentTypeID.SelectedIndex = 1; }
        }


        #region CONTEXTUAL LOAD TAB PAGE: TAB FOR FILTER
        protected override void invokeEdit(int? id)
        {
            try
            {
                //base.invokeEdit(id);
                if (this.fastReportIndex.SelectedObject != null)
                {
                    ReportIndex reportIndex = (ReportIndex)this.fastReportIndex.SelectedObject;
                    if (reportIndex != null)
                    {
                        this.currentReportIndex = reportIndex;
                        this.reloadTabPages();

                        this.comboQuantityVersusVolume.Visible = this.currentReportIndex.ReportTypeID == (int)GlobalEnums.ReportTypeID.GoodsReceiptPivot || this.currentReportIndex.ReportTypeID == (int)GlobalEnums.ReportTypeID.GoodsIssuePivot; this.buttonQuantityVersusVolume.Visible = this.comboQuantityVersusVolume.Visible;
                        this.comboDateVersusMonth.Visible = this.currentReportIndex.ReportTypeID == (int)GlobalEnums.ReportTypeID.GoodsReceiptPivot || this.currentReportIndex.ReportTypeID == (int)GlobalEnums.ReportTypeID.GoodsIssuePivot; this.buttonDateVersusMonth.Visible = this.comboDateVersusMonth.Visible;
                        this.comboSalesVersusPromotion.Visible = this.currentReportIndex.ReportUniqueID == (int)GlobalEnums.ReportUniqueID.SalesIssuePivot; this.buttonSalesVersusPromotion.Visible = this.comboSalesVersusPromotion.Visible;
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void reloadTabPages()
        {
            try
            {
                this.customTabBatch.SuspendLayout();
                this.clearTabPages();
                foreach (TabPage tabpage in this.tabPages)
                {
                    if (this.currentReportIndex.ReportTabPageIDs.IndexOf(tabpage.Tag.ToString()) != -1 && !this.customTabBatch.TabPages.Contains(tabpage))
                        this.customTabBatch.TabPages.Add(tabpage);
                }
                if (this.customTabBatch.TabPages.Contains(this.tabPageCommodities)) this.customTabBatch.SelectedTab = this.tabPageCommodities;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
            finally
            {
                this.customTabBatch.ResumeLayout();
            }
        }

        private void clearTabPages()
        {
            try
            {
                foreach (TabPage tabpage in this.customTabBatch.TabPages)
                {
                    if (this.currentReportIndex.ReportTabPageIDs.IndexOf(tabpage.Tag.ToString()) == -1)
                    {//CALL CollapseAll() TO PREVENT UNKNOW ERROR!!! //IF WE DON'T COLLAPSE ALL THE TREE, IT WIL RAISE ERROR WHEN WE CALL CLEAR OR REMOVE TABPAGES
                        if (tabpage.Equals(this.tabPageWarehouses))
                        { this.treeWarehouseID.CollapseAll(); }
                        if (tabpage.Equals(this.tabPageCommodities))
                        { this.treeCommodityID.CollapseAll(); this.treeCommodityTypeID.CollapseAll(); }
                        if (tabpage.Equals(this.tabPageCustomers))
                        { this.treeEmployeeID.CollapseAll(); this.treeCustomerID.CollapseAll(); }
                        if (tabpage.Equals(this.tabPageWarehouseIssues))
                        { this.treeWarehouseIssueID.CollapseAll(); }
                        if (tabpage.Equals(this.tabPageWarehouseReceipts))
                        { this.treeWarehouseReceiptID.CollapseAll(); }
                        if (tabpage.Equals(this.tabPageWarehouseAdjustmentTypes))
                        { this.treeWarehouseAdjustmentTypeID.CollapseAll(); }

                        this.customTabBatch.TabPages.Remove(tabpage);
                    }
                }
            }
            catch (Exception exception)
            { //EVENT WHEN ERROR OCCUR, WE IGNORE IT
                int i = 1;
                //ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }
        #endregion CONTEXTUAL LOAD TAB PAGE: TAB FOR FILTER


        public override void ApplyFilter(string filterTexts)
        {
            OLVHelpers.ApplyFilters(this.treeWarehouseID, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            OLVHelpers.ApplyFilters(this.treeCommodityID, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            OLVHelpers.ApplyFilters(this.treeCommodityTypeID, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            OLVHelpers.ApplyFilters(this.treeCustomerID, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            OLVHelpers.ApplyFilters(this.treeEmployeeID, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            OLVHelpers.ApplyFilters(this.treeWarehouseIssueID, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            OLVHelpers.ApplyFilters(this.treeWarehouseReceiptID, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            OLVHelpers.ApplyFilters(this.treeWarehouseAdjustmentTypeID, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
        }


        protected override PrintViewModel InitPrintViewModel()
        {
            PrintViewModel printViewModel = base.InitPrintViewModel();
            printViewModel.ReportPath = "GoodsIssuePivot";

            FilterParameter locationID = new FilterParameter("LocationID");
            FilterParameter warehouseID = new FilterParameter("WarehouseID");

            this.GetFilterParameters(this.warehouseTrees.Cast<IFilterTree>(), new FilterParameter[] { locationID, warehouseID });


            printViewModel.ReportParameters.Add(new Microsoft.Reporting.WinForms.ReportParameter("LocationIDs", locationID.PrimaryIDs));
            //printViewModel.ReportParameters.Add(new Microsoft.Reporting.WinForms.ReportParameter("LocationCode", this.comboLocationID.Text));
            return printViewModel;
        }


        private void GetFilterParameters(IEnumerable<IFilterTree> filterTrees, FilterParameter[] filterParameters)
        {
            if (filterTrees.Count() > 0 && filterParameters.Count() > 0)
            {
                IList<IFilterTree> selectedFilterTrees = filterTrees.Where(w => w.Selected == true).ToList();
                if (selectedFilterTrees.Count > 0)
                {
                    if (selectedFilterTrees.Where(w => w.NodeID == GlobalEnums.RootNode).FirstOrDefault() != null) return;

                    IList<IFilterTree> effectedFilterTrees = null;
                    foreach (FilterParameter filterParameter in filterParameters)
                    {//WE SHOULD SET THE ORDER OF ELEMENT IN filterParameters BY THE HIERARCHY STRUCTURE. THIS IS VERY IMPORTANNT: FOR EXCAMPLE: filterParameters[0] = LocationID, filterParameters[1] = WarehouseID
                        IEnumerable<IFilterTree> enumerableFilterTree = selectedFilterTrees.Where(w => w.ParameterName == filterParameter.ParameterName);
                        if (effectedFilterTrees != null)
                        {//BY THE ORDER OF THE HIERARCHY STRUCTURE, WE CAN USE THE QUERY BELLOW TO EXCLUSIVE (ORMIT) THE CHILD THAT ITS ANCESTORID EXIST IN THE PARENT LIST
                            List<int?> ancestorIDs = effectedFilterTrees.Select(n => n.PrimaryID).ToList();
                            enumerableFilterTree = enumerableFilterTree.Where(w => !ancestorIDs.Contains(w.AncestorID));
                        }
                        effectedFilterTrees = enumerableFilterTree.ToList();

                        filterParameter.PrimaryIDs = string.Join(",", effectedFilterTrees.Select(s => s.PrimaryID));
                        filterParameter.Codes = string.Join(",", effectedFilterTrees.Select(s => s.Code));
                        filterParameter.Names = string.Join(",", effectedFilterTrees.Select(s => s.Name));
                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FilterParameter locationID = new FilterParameter("LocationID");
            FilterParameter warehouseID = new FilterParameter("WarehouseID");

            this.GetFilterParameters(this.warehouseTrees.Cast<IFilterTree>(), new FilterParameter[] { locationID, warehouseID });

            string i = locationID.PrimaryIDs + warehouseID.PrimaryIDs;
        }

        private void panelCenter_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

    }

    public class FilterParameter
    {
        public string PrimaryIDs { get; set; }

        public string Codes { get; set; }
        public string Names { get; set; }

        public string ParameterName { get; set; }
        public FilterParameter(string parameterName) { this.ParameterName = parameterName; }
    }
}

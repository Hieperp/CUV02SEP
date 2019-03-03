using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BrightIdeasSoftware;

using TotalBase.Enums;
using TotalModel.Models;
using TotalDTO.Sales;
using TotalSmartCoding.Controllers.APIs.Sales;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.ViewModels.Sales;
using TotalSmartCoding.Views.Mains;
using TotalDTO.Helpers.Interfaces;


namespace TotalSmartCoding.Views.Sales.SalesReturns
{
    public partial class WizardDetail : Form
    {
        private SalesReturnAPIs salesReturnAPIs;
        private SalesReturnViewModel salesReturnViewModel;
        private CustomTabControl customTabBatch;

        private Binding beginingDateBinding;
        private Binding endingDateBinding;

        private DateTime lowerFillterDate;
        public DateTime LowerFillterDate
        {
            get { return this.lowerFillterDate; }
            set { if (this.lowerFillterDate != value) { this.lowerFillterDate = value; this.WizardDetail_Load(this, new EventArgs()); } }
        }

        private DateTime upperFillterDate;
        public DateTime UpperFillterDate
        {
            get { return this.upperFillterDate; }
            set { if (this.upperFillterDate != value) { this.upperFillterDate = value; this.WizardDetail_Load(this, new EventArgs()); } }
        }

        public WizardDetail(SalesReturnAPIs salesReturnAPIs, SalesReturnViewModel salesReturnViewModel)
        {
            InitializeComponent();

            this.customTabBatch = new CustomTabControl();

            this.customTabBatch.Font = this.fastPendingPallets.Font;
            this.customTabBatch.DisplayStyle = TabStyle.VisualStudio;
            this.customTabBatch.DisplayStyleProvider.ImageAlign = ContentAlignment.MiddleLeft;

            this.customTabBatch.TabPages.Add("tabPendingPallets", "Pending pallets");
            this.customTabBatch.TabPages.Add("tabPendingCartons", "Pending cartons");
            this.customTabBatch.TabPages[0].Controls.Add(this.fastPendingPallets);
            this.customTabBatch.TabPages[1].Controls.Add(this.fastPendingCartons);


            this.customTabBatch.Dock = DockStyle.Fill;
            this.fastPendingPallets.Dock = DockStyle.Fill;
            this.fastPendingCartons.Dock = DockStyle.Fill;
            this.panelMaster.Controls.Add(this.customTabBatch);


            this.salesReturnAPIs = salesReturnAPIs;
            this.salesReturnViewModel = salesReturnViewModel;

            this.lowerFillterDate = DateTime.Today.AddDays(-1); this.upperFillterDate = DateTime.Today;
            this.beginingDateBinding = this.dateTimexLowerFillterDate.DataBindings.Add("Value", this, "LowerFillterDate", true, DataSourceUpdateMode.OnPropertyChanged);
            this.endingDateBinding = this.dateTimexUpperFillterDate.DataBindings.Add("Value", this, "UpperFillterDate", true, DataSourceUpdateMode.OnPropertyChanged);

            this.beginingDateBinding.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.endingDateBinding.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
        }


        private void WizardDetail_Load(object sender, EventArgs e)
        {
            try
            {
                List<SalesReturnPendingGoodsIssueDetail> pendingGoodsIssueDetails = null;
                pendingGoodsIssueDetails = this.salesReturnAPIs.GetPendingGoodsIssueDetails(this.salesReturnViewModel.LocationID, this.salesReturnViewModel.SalesReturnID, this.salesReturnViewModel.GoodsIssueID, this.salesReturnViewModel.CustomerID, this.salesReturnViewModel.ReceiverID, this.LowerFillterDate, this.UpperFillterDate, string.Join(",", this.salesReturnViewModel.ViewDetails.Select(d => d.CartonID)), string.Join(",", this.salesReturnViewModel.ViewDetails.Select(d => d.PalletID)));

                if (pendingGoodsIssueDetails != null)
                {
                    this.fastPendingPallets.SetObjects(pendingGoodsIssueDetails.Where(w => w.PalletID != null));
                    this.fastPendingCartons.SetObjects(pendingGoodsIssueDetails.Where(w => w.CartonID != null));
                }

                this.ShowRowCount(true, true);
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        protected void CommonControl_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (sender.Equals(this.beginingDateBinding) || sender.Equals(this.endingDateBinding))
            {
            }
        }

        private void buttonAddESC_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (sender.Equals(this.buttonAdd) || sender.Equals(this.buttonAddExit))
            //    {
            //        FastObjectListView fastPendingList = this.customTabBatch.SelectedIndex == 0 ? this.fastPendingPallets : (this.customTabBatch.SelectedIndex == 1 ? this.fastPendingCartons : null);

            //        if (fastPendingList != null)
            //        {
            //            if (fastPendingList.CheckedObjects.Count > 0)
            //            {
            //                IEnumerable<IPendingforSalesReturnDetail> pendingforSalesReturnDetails = fastPendingList.CheckedObjects.Cast<IPendingforSalesReturnDetail>();
            //                if (pendingforSalesReturnDetails.Where(w => w.BinLocationID <= 0).FirstOrDefault() != null) throw new Exception("Vui lòng chọn Bin Location.");

            //                this.salesReturnViewModel.ViewDetails.RaiseListChangedEvents = false;
            //                foreach (IPendingforSalesReturnDetail pendingforSalesReturnDetail in pendingforSalesReturnDetails)
            //                {
            //                    SalesReturnDetailDTO salesReturnDetailDTO = new SalesReturnDetailDTO()
            //                    {
            //                        SalesReturnID = this.salesReturnViewModel.SalesReturnID,

            //                        PickupID = pendingforSalesReturnDetail.PickupID > 0 ? pendingforSalesReturnDetail.PickupID : (int?)null,
            //                        PickupDetailID = pendingforSalesReturnDetail.PickupDetailID > 0 ? pendingforSalesReturnDetail.PickupDetailID : (int?)null,
            //                        PickupReference = pendingforSalesReturnDetail.PrimaryReference,
            //                        PickupEntryDate = pendingforSalesReturnDetail.PickupID > 0 ? pendingforSalesReturnDetail.PrimaryEntryDate : (DateTime?)null,

            //                        GoodsIssueID = pendingforSalesReturnDetail.GoodsIssueID > 0 ? pendingforSalesReturnDetail.GoodsIssueID : (int?)null,
            //                        GoodsIssueTransferDetailID = pendingforSalesReturnDetail.GoodsIssueTransferDetailID > 0 ? pendingforSalesReturnDetail.GoodsIssueTransferDetailID : (int?)null,
            //                        GoodsIssueReference = pendingforSalesReturnDetail.PrimaryReference,
            //                        GoodsIssueEntryDate = pendingforSalesReturnDetail.GoodsIssueID > 0 ? pendingforSalesReturnDetail.PrimaryEntryDate : (DateTime?)null,

            //                        LocationIssueID = pendingforSalesReturnDetail.LocationIssueID,
            //                        WarehouseIssueID = pendingforSalesReturnDetail.WarehouseIssueID,

            //                        BatchID = pendingforSalesReturnDetail.BatchID,
            //                        BatchEntryDate = pendingforSalesReturnDetail.BatchEntryDate,

            //                        BinLocationID = pendingforSalesReturnDetail.BinLocationID,
            //                        BinLocationCode = pendingforSalesReturnDetail.BinLocationCode,

            //                        CommodityID = pendingforSalesReturnDetail.CommodityID,
            //                        CommodityCode = pendingforSalesReturnDetail.CommodityCode,
            //                        CommodityName = pendingforSalesReturnDetail.CommodityName,

            //                        Quantity = (decimal)pendingforSalesReturnDetail.QuantityRemains,
            //                        LineVolume = (decimal)pendingforSalesReturnDetail.LineVolumeRemains,


            //                        PackID = pendingforSalesReturnDetail.PackID,
            //                        PackCode = pendingforSalesReturnDetail.PackCode,
            //                        CartonID = pendingforSalesReturnDetail.CartonID,
            //                        CartonCode = pendingforSalesReturnDetail.CartonCode,
            //                        PalletID = pendingforSalesReturnDetail.PalletID,
            //                        PalletCode = pendingforSalesReturnDetail.PalletCode,

            //                        PackCounts = pendingforSalesReturnDetail.PackCounts,
            //                        CartonCounts = pendingforSalesReturnDetail.CartonCounts,
            //                        PalletCounts = pendingforSalesReturnDetail.PalletCounts
            //                    };
            //                    this.salesReturnViewModel.ViewDetails.Add(salesReturnDetailDTO);
            //                }
            //                this.salesReturnViewModel.ViewDetails.RaiseListChangedEvents = true;
            //                this.salesReturnViewModel.ViewDetails.ResetBindings();
            //            }
            //        }


            //        if (sender.Equals(this.buttonAddExit))
            //            this.DialogResult = DialogResult.OK;
            //        else
            //            this.WizardDetail_Load(this, new EventArgs());
            //    }

            //    if (sender.Equals(this.buttonESC))
            //        this.DialogResult = DialogResult.Cancel;


            //}
            //catch (Exception exception)
            //{
            //    ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            //}
        }

        private void textexFilters_TextChanged(object sender, EventArgs e)
        {
            try
            {
                OLVHelpers.ApplyFilters(this.fastPendingPallets, this.textexFilters.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
                OLVHelpers.ApplyFilters(this.fastPendingCartons, this.textexFilters.Text.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

                this.ShowRowCount(true, true);
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void buttonClearFilters_Click(object sender, EventArgs e)
        {
            this.textexFilters.Text = "";
        }

        private void ShowRowCount(bool showPalletCount, bool showCartonCount)
        {
            //if (showPalletCount)
            //{
            //    decimal? totalQuantityRemains = this.fastPendingPallets.FilteredObjects.Cast<IPendingforSalesReturnDetail>().Select(o => o.QuantityRemains).Sum();
            //    decimal? totalLineVolumeRemains = this.fastPendingPallets.FilteredObjects.Cast<IPendingforSalesReturnDetail>().Select(o => o.LineVolumeRemains).Sum();
            //    this.customTabBatch.TabPages[0].Text = "Pending " + this.fastPendingPallets.GetItemCount().ToString("N0") + " pallet" + (this.fastPendingPallets.GetItemCount() > 1 ? "s" : "") + ", Quantity: " + (totalQuantityRemains != null ? ((decimal)totalQuantityRemains).ToString("N0") : "0") + ", Volume: " + (totalLineVolumeRemains != null ? ((decimal)totalLineVolumeRemains).ToString("N0") : "0") + "       ";
            //}
            //if (showCartonCount)
            //{
            //    decimal? totalQuantityRemains = this.fastPendingCartons.FilteredObjects.Cast<IPendingforSalesReturnDetail>().Select(o => o.QuantityRemains).Sum();
            //    decimal? totalLineVolumeRemains = this.fastPendingCartons.FilteredObjects.Cast<IPendingforSalesReturnDetail>().Select(o => o.LineVolumeRemains).Sum();
            //    this.customTabBatch.TabPages[1].Text = "Pending " + this.fastPendingCartons.GetItemCount().ToString("N0") + " carton" + (this.fastPendingCartons.GetItemCount() > 1 ? "s" : "") + ", Quantity: " + (totalQuantityRemains != null ? ((decimal)totalQuantityRemains).ToString("N0") : "0") + ", Volume: " + (totalLineVolumeRemains != null ? ((decimal)totalLineVolumeRemains).ToString("N0") : "0") + "       ";
            //}
        }
    }
}

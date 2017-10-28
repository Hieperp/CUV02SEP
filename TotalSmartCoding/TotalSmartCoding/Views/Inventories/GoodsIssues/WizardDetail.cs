using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BrightIdeasSoftware;

using Ninject;

using TotalModel.Models;
using TotalCore.Repositories.Inventories;
using TotalDTO.Inventories;
using TotalSmartCoding.Libraries;
using TotalSmartCoding.Controllers.APIs.Inventories;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.ViewModels.Inventories;
using TotalBase;


namespace TotalSmartCoding.Views.Inventories.GoodsIssues
{
    public partial class WizardDetail : Form, IToolstripMerge, IToolstripTablet
    {
        private CustomTabControl customTabBatch;
        public virtual ToolStrip toolstripChild { get; protected set; }

        private GoodsIssueViewModel goodsIssueViewModel;
        private PendingDeliveryAdviceDetail pendingDeliveryAdviceDetail;
        private PendingTransferOrderDetail pendingTransferOrderDetail;

        private bool UsingPack = false; //NOW AT CHEVRON: WE DON'T ALLOW ISSUE BY PACK 

        public WizardDetail(GoodsIssueViewModel goodsIssueViewModel, PendingDeliveryAdviceDetail pendingDeliveryAdviceDetail, PendingTransferOrderDetail pendingTransferOrderDetail)
        {
            InitializeComponent();

            if (!this.UsingPack) { this.fastAvailablePacks.Dock = DockStyle.None; this.fastAvailablePacks.Visible = false; }

            this.toolstripChild = this.toolStrip1;
            this.customTabBatch = new CustomTabControl();

            this.customTabBatch.Font = this.fastAvailablePallets.Font;
            this.customTabBatch.DisplayStyle = TabStyle.VisualStudio;
            this.customTabBatch.DisplayStyleProvider.ImageAlign = ContentAlignment.MiddleLeft;

            this.customTabBatch.TabPages.Add("tabPendingPallets", "Pending pallets");
            this.customTabBatch.TabPages.Add("tabPendingCartons", "Pending cartons");
            if (this.UsingPack) this.customTabBatch.TabPages.Add("tabPendingPacks", "Pending packs");
            this.customTabBatch.TabPages[0].Controls.Add(this.fastAvailablePallets);
            this.customTabBatch.TabPages[1].Controls.Add(this.fastAvailableCartons);
            if (this.UsingPack) this.customTabBatch.TabPages[2].Controls.Add(this.fastAvailablePacks);


            this.customTabBatch.Dock = DockStyle.Fill;
            this.fastAvailablePallets.Dock = DockStyle.Fill;
            this.fastAvailableCartons.Dock = DockStyle.Fill;
            if (this.UsingPack) this.fastAvailablePacks.Dock = DockStyle.Fill;
            this.panelMaster.Controls.Add(this.customTabBatch);

            if (GlobalVariables.ConfigID == (int)GlobalVariables.FillingLine.GoodsIssue) ViewHelpers.SetFont(this, new Font("Calibri", 11), new Font("Calibri", 11), new Font("Calibri", 11));

            this.goodsIssueViewModel = goodsIssueViewModel;
            this.pendingDeliveryAdviceDetail = pendingDeliveryAdviceDetail;
            this.pendingTransferOrderDetail = pendingTransferOrderDetail;
        }

        private void WizardDetail_Load(object sender, EventArgs e)
        {
            try
            {
                GoodsReceiptAPIs goodsReceiptAPIs = new GoodsReceiptAPIs(CommonNinject.Kernel.Get<IGoodsReceiptAPIRepository>());

                List<GoodsReceiptDetailAvailable> goodsReceiptDetailAvailables = goodsReceiptAPIs.GetGoodsReceiptDetailAvailables(this.pendingDeliveryAdviceDetail != null ? this.pendingDeliveryAdviceDetail.LocationID : this.pendingTransferOrderDetail.LocationID, this.pendingDeliveryAdviceDetail != null ? this.pendingDeliveryAdviceDetail.CommodityID : this.pendingTransferOrderDetail.CommodityID, this.pendingDeliveryAdviceDetail != null ? this.pendingDeliveryAdviceDetail.BatchID : this.pendingTransferOrderDetail.BatchID, string.Join(",", this.goodsIssueViewModel.ViewDetails.Select(d => d.GoodsReceiptDetailID)));

                this.fastAvailablePallets.SetObjects(goodsReceiptDetailAvailables.Where(w => w.PalletID != null));
                this.fastAvailableCartons.SetObjects(goodsReceiptDetailAvailables.Where(w => w.CartonID != null));
                if (this.UsingPack) this.fastAvailablePacks.SetObjects(goodsReceiptDetailAvailables.Where(w => w.PackID != null));

                this.ShowRowCount();
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        public void ApplyFilter(string filterTexts)
        {
            this.fastAvailablePallets.CheckedObjects = null;
            this.fastAvailableCartons.CheckedObjects = null;
            if (this.UsingPack) this.fastAvailablePacks.CheckedObjects = null;

            this.fastAvailablePallets.SelectedObject = null;
            this.fastAvailableCartons.SelectedObject = null;
            if (this.UsingPack) this.fastAvailablePacks.SelectedObject = null;

            OLVHelpers.ApplyFilters(this.fastAvailablePallets, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            OLVHelpers.ApplyFilters(this.fastAvailableCartons, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            if (this.UsingPack) OLVHelpers.ApplyFilters(this.fastAvailablePacks, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

            this.ShowRowCount();
        }

        private void ShowRowCount()
        {
            this.customTabBatch.TabPages[0].Text = "Pending " + this.fastAvailablePallets.GetItemCount().ToString("N0") + " pallet" + (this.fastAvailablePallets.GetItemCount() > 1 ? "s      " : "      ");
            this.customTabBatch.TabPages[1].Text = "Pending " + this.fastAvailableCartons.GetItemCount().ToString("N0") + " carton" + (this.fastAvailableCartons.GetItemCount() > 1 ? "s      " : "      ");
            if (this.UsingPack) this.customTabBatch.TabPages[2].Text = "Pending " + this.fastAvailablePacks.GetItemCount().ToString("N0") + " pack" + (this.fastAvailablePacks.GetItemCount() > 1 ? "s      " : "      ");
        }


        private void fastAvailableGoodsReceiptDetails_SelectedIndexChanged(object sender, EventArgs e)
        {
            FastObjectListView fastAvailableGoodsReceiptDetails = (FastObjectListView)sender;
            if (fastAvailableGoodsReceiptDetails != null && fastAvailableGoodsReceiptDetails.SelectedObject != null)
            {//CLEAR ALL CHECKED OBJECTS => THEN CHECK THE CURRENT SELECTED ROW
                GoodsReceiptDetailAvailable goodsReceiptDetailAvailable = (GoodsReceiptDetailAvailable)fastAvailableGoodsReceiptDetails.SelectedObject;
                if (goodsReceiptDetailAvailable != null) { fastAvailableGoodsReceiptDetails.CheckedObjects = null; fastAvailableGoodsReceiptDetails.CheckObject(goodsReceiptDetailAvailable); }
            }
        }

        private void fastAvailableGoodsReceiptDetails_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (this.fastAvailablePallets.CheckedObjects != null && this.fastAvailablePallets.CheckedObjects.Count > 0) this.buttonAddExit.Enabled = true; else this.buttonAddExit.Enabled = false;
            if (!this.buttonAddExit.Enabled && this.fastAvailableCartons.CheckedObjects != null && this.fastAvailableCartons.CheckedObjects.Count > 0) this.buttonAddExit.Enabled = true;
            if (this.UsingPack) if (!this.buttonAddExit.Enabled && this.fastAvailablePacks.CheckedObjects != null && this.fastAvailablePacks.CheckedObjects.Count > 0) this.buttonAddExit.Enabled = true;
        }

        private void buttonAddESC_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(this.buttonAddExit))
                {
                    FastObjectListView fastAvailableGoodsReceiptDetails = this.customTabBatch.SelectedIndex == 0 ? this.fastAvailablePallets : (this.customTabBatch.SelectedIndex == 1 ? this.fastAvailableCartons : this.customTabBatch.SelectedIndex == 2 ? this.fastAvailablePacks : null);

                    if (fastAvailableGoodsReceiptDetails != null)
                    {
                        if (fastAvailableGoodsReceiptDetails.CheckedObjects.Count > 0)
                        {
                            this.goodsIssueViewModel.ViewDetails.RaiseListChangedEvents = false;
                            foreach (var checkedObjects in fastAvailableGoodsReceiptDetails.CheckedObjects)
                            {
                                GoodsReceiptDetailAvailable goodsReceiptDetailAvailable = (GoodsReceiptDetailAvailable)checkedObjects;
                                GoodsIssueDetailDTO goodsIssueDetailDTO = new GoodsIssueDetailDTO()
                                {
                                    GoodsIssueID = this.goodsIssueViewModel.GoodsIssueID,

                                    DeliveryAdviceID = this.pendingDeliveryAdviceDetail != null ? this.pendingDeliveryAdviceDetail.DeliveryAdviceID : (int?)null,
                                    DeliveryAdviceDetailID = this.pendingDeliveryAdviceDetail != null ? this.pendingDeliveryAdviceDetail.DeliveryAdviceDetailID : (int?)null,
                                    DeliveryAdviceReference = this.pendingDeliveryAdviceDetail != null ? this.pendingDeliveryAdviceDetail.PrimaryReference : null,
                                    DeliveryAdviceEntryDate = this.pendingDeliveryAdviceDetail != null ? this.pendingDeliveryAdviceDetail.PrimaryEntryDate : (DateTime?)null,

                                    TransferOrderID = this.pendingTransferOrderDetail != null ? this.pendingTransferOrderDetail.TransferOrderID : (int?)null,
                                    TransferOrderDetailID = this.pendingTransferOrderDetail != null ? this.pendingTransferOrderDetail.TransferOrderDetailID : (int?)null,
                                    TransferOrderReference = this.pendingTransferOrderDetail != null ? this.pendingTransferOrderDetail.PrimaryReference : null,
                                    TransferOrderEntryDate = this.pendingTransferOrderDetail != null ? this.pendingTransferOrderDetail.PrimaryEntryDate : (DateTime?)null,

                                    CommodityID = goodsReceiptDetailAvailable.CommodityID,
                                    CommodityCode = goodsReceiptDetailAvailable.CommodityCode,
                                    CommodityName = goodsReceiptDetailAvailable.CommodityName,

                                    PackageSize = goodsReceiptDetailAvailable.PackageSize,

                                    Volume = goodsReceiptDetailAvailable.Volume,
                                    PackageVolume = goodsReceiptDetailAvailable.PackageVolume,

                                    GoodsReceiptID = goodsReceiptDetailAvailable.GoodsReceiptID,
                                    GoodsReceiptDetailID = goodsReceiptDetailAvailable.GoodsReceiptDetailID,

                                    GoodsReceiptReference = goodsReceiptDetailAvailable.GoodsReceiptReference,
                                    GoodsReceiptEntryDate = goodsReceiptDetailAvailable.GoodsReceiptEntryDate,

                                    BatchEntryDate = goodsReceiptDetailAvailable.BatchEntryDate,

                                    BinLocationID = goodsReceiptDetailAvailable.BinLocationID,
                                    BinLocationCode = goodsReceiptDetailAvailable.BinLocationCode,

                                    WarehouseID = goodsReceiptDetailAvailable.WarehouseID,
                                    WarehouseCode = goodsReceiptDetailAvailable.WarehouseCode,

                                    PackID = goodsReceiptDetailAvailable.PackID,
                                    PackCode = goodsReceiptDetailAvailable.PackCode,
                                    CartonID = goodsReceiptDetailAvailable.CartonID,
                                    CartonCode = goodsReceiptDetailAvailable.CartonCode,
                                    PalletID = goodsReceiptDetailAvailable.PalletID,
                                    PalletCode = goodsReceiptDetailAvailable.PalletCode,

                                    PackCounts = goodsReceiptDetailAvailable.PackCounts,
                                    CartonCounts = goodsReceiptDetailAvailable.CartonCounts,
                                    PalletCounts = goodsReceiptDetailAvailable.PalletCounts,

                                    QuantityAvailable = (decimal)goodsReceiptDetailAvailable.QuantityAvailable,
                                    LineVolumeAvailable = (decimal)goodsReceiptDetailAvailable.LineVolumeAvailable,

                                    QuantityRemains = (decimal)(this.pendingDeliveryAdviceDetail != null ? this.pendingDeliveryAdviceDetail.QuantityRemains : this.pendingTransferOrderDetail.QuantityRemains),
                                    LineVolumeRemains = (decimal)(this.pendingDeliveryAdviceDetail != null ? this.pendingDeliveryAdviceDetail.LineVolumeRemains : this.pendingTransferOrderDetail.LineVolumeRemains),

                                    Quantity = (decimal)goodsReceiptDetailAvailable.QuantityAvailable, //SHOULD: Quantity = QuantityAvailable (ALSO: LineVolume = LineVolumeAvailable): BECAUSE: WE ISSUE BY WHOLE UNIT OF PALLET/ OR CARTON/ OR PACK
                                    LineVolume = (decimal)goodsReceiptDetailAvailable.LineVolumeAvailable //IF Quantity > QuantityRemains (OR LineVolume > LineVolumeRemains) => THE GoodsIssueDetailDTO WILL BREAK THE ValidationRule => CAN NOT SAVE => USER MUST SELECT OTHER APPROPRIATE UNIT OF PALLET/ OR CARTON/ OR PACK WHICH MATCH THE Quantity/ LineVolume                                
                                };
                                this.goodsIssueViewModel.ViewDetails.Insert(0, goodsIssueDetailDTO);
                            }
                            this.goodsIssueViewModel.ViewDetails.RaiseListChangedEvents = true;
                            this.goodsIssueViewModel.ViewDetails.ResetBindings();
                        }
                    }

                    this.MdiParent.DialogResult = DialogResult.OK;
                }

                if (sender.Equals(this.buttonESC))
                    this.MdiParent.DialogResult = DialogResult.Cancel;

            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

    }
}

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


namespace TotalSmartCoding.Views.Inventories.GoodsIssues
{
    public partial class WizardDetail : Form, IToolstripMerge, IToolstripTablet
    {
        private CustomTabControl customTabBatch;
        public virtual ToolStrip toolstripChild { get; protected set; }

        private GoodsIssueViewModel goodsIssueViewModel;
        private PendingDeliveryAdviceDetail pendingDeliveryAdviceDetail;
        
        public WizardDetail(GoodsIssueViewModel goodsIssueViewModel, PendingDeliveryAdviceDetail pendingDeliveryAdviceDetail)
        {
            InitializeComponent();

            this.toolstripChild = this.toolStrip1;
            this.customTabBatch = new CustomTabControl();

            this.customTabBatch.Font = this.fastPendingPallets.Font;
            this.customTabBatch.DisplayStyle = TabStyle.VisualStudio;
            this.customTabBatch.DisplayStyleProvider.ImageAlign = ContentAlignment.MiddleLeft;

            this.customTabBatch.TabPages.Add("tabPendingPallets", "Pending pallets");
            this.customTabBatch.TabPages.Add("tabPendingCartons", "Pending cartons");
            this.customTabBatch.TabPages.Add("tabPendingPacks", "Pending packs");
            this.customTabBatch.TabPages[0].Controls.Add(this.fastPendingPallets);
            this.customTabBatch.TabPages[1].Controls.Add(this.fastPendingCartons);
            this.customTabBatch.TabPages[2].Controls.Add(this.fastPendingPacks);


            this.customTabBatch.Dock = DockStyle.Fill;
            this.fastPendingPallets.Dock = DockStyle.Fill;
            this.fastPendingCartons.Dock = DockStyle.Fill;
            this.fastPendingPacks.Dock = DockStyle.Fill;
            this.panelMaster.Controls.Add(this.customTabBatch);


            this.goodsIssueViewModel = goodsIssueViewModel;
            this.pendingDeliveryAdviceDetail = pendingDeliveryAdviceDetail;
        }


        private void WizardDetail_Load(object sender, EventArgs e)
        {
            try
            {
                GoodsReceiptAPIs goodsReceiptAPIs = new GoodsReceiptAPIs(CommonNinject.Kernel.Get<IGoodsReceiptAPIRepository>());

                List<GoodsReceiptDetailAvailable> goodsReceiptDetailAvailables = goodsReceiptAPIs.GetGoodsReceiptDetailAvailables(this.pendingDeliveryAdviceDetail.LocationID, this.pendingDeliveryAdviceDetail.CommodityID, string.Join(",", this.goodsIssueViewModel.ViewDetails.Select(d => d.GoodsReceiptDetailID)));

                this.fastPendingPallets.SetObjects(goodsReceiptDetailAvailables.Where(w => w.PalletID != null));
                this.fastPendingCartons.SetObjects(goodsReceiptDetailAvailables.Where(w => w.CartonID != null));
                this.fastPendingPacks.SetObjects(goodsReceiptDetailAvailables.Where(w => w.PackID != null));

                this.customTabBatch.TabPages[0].Text = "Pending " + this.fastPendingPallets.GetItemCount().ToString("N0") + " pallet" + (this.fastPendingPallets.GetItemCount() > 1 ? "s      " : "      ");
                this.customTabBatch.TabPages[1].Text = "Pending " + this.fastPendingCartons.GetItemCount().ToString("N0") + " carton" + (this.fastPendingCartons.GetItemCount() > 1 ? "s      " : "      ");
                this.customTabBatch.TabPages[2].Text = "Pending " + this.fastPendingPacks.GetItemCount().ToString("N0") + " pack" + (this.fastPendingPacks.GetItemCount() > 1 ? "s      " : "      ");
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        public void ApplyFilter(string filterTexts)
        {
            OLVHelpers.ApplyFilters(this.fastPendingPallets, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            OLVHelpers.ApplyFilters(this.fastPendingCartons, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            OLVHelpers.ApplyFilters(this.fastPendingPacks, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
        }

        private void buttonAddESC_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(this.buttonAddExit))
                {
                    FastObjectListView fastPendingList = this.customTabBatch.SelectedIndex == 0 ? this.fastPendingPallets : (this.customTabBatch.SelectedIndex == 1 ? this.fastPendingCartons : this.customTabBatch.SelectedIndex == 2 ? this.fastPendingPacks : null);

                    if (fastPendingList != null)
                    {
                        foreach (var checkedObjects in fastPendingList.CheckedObjects)
                        {
                            GoodsReceiptDetailAvailable goodsReceiptDetailAvailable = (GoodsReceiptDetailAvailable)checkedObjects;
                            GoodsIssueDetailDTO goodsIssueDetailDTO = new GoodsIssueDetailDTO()
                            {
                                GoodsIssueID = this.goodsIssueViewModel.GoodsIssueID,

                                DeliveryAdviceID = this.pendingDeliveryAdviceDetail.DeliveryAdviceID,
                                DeliveryAdviceDetailID = this.pendingDeliveryAdviceDetail.DeliveryAdviceDetailID,
                                DeliveryAdviceReference = this.pendingDeliveryAdviceDetail.DeliveryAdviceReference,
                                DeliveryAdviceEntryDate = this.pendingDeliveryAdviceDetail.DeliveryAdviceEntryDate,

                                CommodityID = this.pendingDeliveryAdviceDetail.CommodityID,
                                CommodityCode = this.pendingDeliveryAdviceDetail.CommodityCode,
                                CommodityName = this.pendingDeliveryAdviceDetail.CommodityName,

                                PackageSize = this.pendingDeliveryAdviceDetail.PackageSize,

                                Volume = this.pendingDeliveryAdviceDetail.Volume,
                                PackageVolume = this.pendingDeliveryAdviceDetail.PackageVolume,

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

                                QuantityRemains = (decimal)this.pendingDeliveryAdviceDetail.QuantityRemains,
                                LineVolumeRemains = (decimal)this.pendingDeliveryAdviceDetail.LineVolumeRemains,

                                Quantity = (decimal)goodsReceiptDetailAvailable.QuantityAvailable, //SHOULD: Quantity = QuantityAvailable (ALSO: LineVolume = LineVolumeAvailable): BECAUSE: WE ISSUE BY WHOLE UNIT OF PALLET/ OR CARTON/ OR PACK
                                LineVolume = (decimal)goodsReceiptDetailAvailable.LineVolumeAvailable //IF Quantity > QuantityRemains (OR LineVolume > LineVolumeRemains) => THE GoodsIssueDetailDTO WILL BREAK THE ValidationRule => CAN NOT SAVE => USER MUST SELECT OTHER APPROPRIATE UNIT OF PALLET/ OR CARTON/ OR PACK WHICH MATCH THE Quantity/ LineVolume                                
                            };
                            this.goodsIssueViewModel.ViewDetails.Add(goodsIssueDetailDTO);
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

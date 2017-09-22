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
    public partial class WizardDetail : Form
    {
        private GoodsIssueViewModel goodsIssueViewModel;
        private PendingDeliveryAdviceDetail pendingDeliveryAdviceDetail;
        private CustomTabControl customTabBatch;
        public WizardDetail(GoodsIssueViewModel goodsIssueViewModel, PendingDeliveryAdviceDetail pendingDeliveryAdviceDetail)
        {
            InitializeComponent();

            this.customTabBatch = new CustomTabControl();
            //this.customTabBatch.ImageList = this.imageListTabControl;

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


        private void buttonAddESC_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(this.buttonAdd) || sender.Equals(this.buttonAddExit))
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

                                CommodityID = goodsReceiptDetailAvailable.CommodityID,
                                CommodityCode = goodsReceiptDetailAvailable.CommodityCode,
                                CommodityName = goodsReceiptDetailAvailable.CommodityName,

                                GoodsReceiptID = goodsReceiptDetailAvailable.GoodsReceiptID,
                                GoodsReceiptDetailID = goodsReceiptDetailAvailable.GoodsReceiptDetailID,

                                BinLocationID = goodsReceiptDetailAvailable.BinLocationID,
                                BinLocationCode = goodsReceiptDetailAvailable.BinLocationCode,

                                WarehouseID = goodsReceiptDetailAvailable.WarehouseID,
                                WarehouseCode = goodsReceiptDetailAvailable.WarehouseCode,

                                Quantity = goodsReceiptDetailAvailable.QuantityAvailable,
                                LineVolume = goodsReceiptDetailAvailable.LineVolumeAvailable,

                                PackID = goodsReceiptDetailAvailable.PackID,
                                PackCode = goodsReceiptDetailAvailable.PackCode,
                                CartonID = goodsReceiptDetailAvailable.CartonID,
                                CartonCode = goodsReceiptDetailAvailable.CartonCode,
                                PalletID = goodsReceiptDetailAvailable.PalletID,
                                PalletCode = goodsReceiptDetailAvailable.PalletCode
                            };
                            this.goodsIssueViewModel.ViewDetails.Add(goodsIssueDetailDTO);
                        }
                    }


                    if (sender.Equals(this.buttonAddExit))
                        this.DialogResult = DialogResult.OK;
                    else
                        this.WizardDetail_Load(this, new EventArgs());
                }

                if (sender.Equals(this.buttonESC))
                    this.DialogResult = DialogResult.Cancel;


            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }
    }
}

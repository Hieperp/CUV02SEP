using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BrightIdeasSoftware;

using TotalBase.Enums;
using TotalModel.Models;
using TotalDTO.Inventories;
using TotalSmartCoding.Controllers.APIs.Inventories;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.ViewModels.Inventories;


namespace TotalSmartCoding.Views.Inventories.GoodsReceipts
{
    public partial class WizardDetail : Form
    {
        private GoodsReceiptAPIs goodsReceiptAPIs;
        private GoodsReceiptViewModel goodsReceiptViewModel;
        private CustomTabControl customTabBatch;
        public WizardDetail(GoodsReceiptAPIs goodsReceiptAPIs, GoodsReceiptViewModel goodsReceiptViewModel)
        {
            InitializeComponent();

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


            this.goodsReceiptAPIs = goodsReceiptAPIs;
            this.goodsReceiptViewModel = goodsReceiptViewModel;
        }


        private void WizardDetail_Load(object sender, EventArgs e)
        {
            try
            {
                List<PendingPickupDetail> pendingPickupDetails = null;
                List<PendingGoodsIssueTransferDetail> pendingGoodsIssueTransferDetails = null;

                if (this.goodsReceiptViewModel.GoodsReceiptTypeID == (int)GlobalEnums.GoodsReceiptTypeID.Pickup)
                    pendingPickupDetails = this.goodsReceiptAPIs.GetPendingPickupDetails(this.goodsReceiptViewModel.LocationID, this.goodsReceiptViewModel.GoodsReceiptID, this.goodsReceiptViewModel.PickupID, this.goodsReceiptViewModel.WarehouseID, string.Join(",", this.goodsReceiptViewModel.ViewDetails.Select(d => d.PickupDetailID)), false);
                if (this.goodsReceiptViewModel.GoodsReceiptTypeID == (int)GlobalEnums.GoodsReceiptTypeID.GoodsIssueTransfer)
                    pendingGoodsIssueTransferDetails = this.goodsReceiptAPIs.GetPendingGoodsIssueTransferDetails(this.goodsReceiptViewModel.LocationID, this.goodsReceiptViewModel.GoodsReceiptID, this.goodsReceiptViewModel.GoodsIssueID, this.goodsReceiptViewModel.WarehouseID, string.Join(",", this.goodsReceiptViewModel.ViewDetails.Select(d => d.GoodsIssueTransferDetailID)), false);

                if (pendingPickupDetails != null)
                {
                    this.fastPendingPallets.SetObjects(pendingPickupDetails.Where(w => w.PalletID != null));
                    this.fastPendingCartons.SetObjects(pendingPickupDetails.Where(w => w.CartonID != null));
                    this.fastPendingPacks.SetObjects(pendingPickupDetails.Where(w => w.PackID != null));
                }

                if (pendingGoodsIssueTransferDetails != null)
                {
                    this.fastPendingPallets.SetObjects(pendingGoodsIssueTransferDetails.Where(w => w.PalletID != null));
                    this.fastPendingCartons.SetObjects(pendingGoodsIssueTransferDetails.Where(w => w.CartonID != null));
                    this.fastPendingPacks.SetObjects(pendingGoodsIssueTransferDetails.Where(w => w.PackID != null));
                }

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
                        if (fastPendingList.CheckedObjects.Count > 0)
                        {
                            this.goodsReceiptViewModel.ViewDetails.RaiseListChangedEvents = false;
                            foreach (var checkedObjects in fastPendingList.CheckedObjects)
                            {
                                IPendingforGoodsReceiptDetail pendingforGoodsReceiptDetail = (IPendingforGoodsReceiptDetail)checkedObjects;
                                GoodsReceiptDetailDTO goodsReceiptDetailDTO = new GoodsReceiptDetailDTO()
                                {
                                    GoodsReceiptID = this.goodsReceiptViewModel.GoodsReceiptID,

                                    PickupID = pendingforGoodsReceiptDetail.PickupID,
                                    PickupDetailID = pendingforGoodsReceiptDetail.PickupDetailID,
                                    PickupReference = pendingforGoodsReceiptDetail.PrimaryReference,
                                    PickupEntryDate = pendingforGoodsReceiptDetail.PrimaryEntryDate,

                                    BatchID = pendingforGoodsReceiptDetail.BatchID,
                                    BatchEntryDate = pendingforGoodsReceiptDetail.BatchEntryDate,

                                    BinLocationID = pendingforGoodsReceiptDetail.BinLocationID,
                                    BinLocationCode = pendingforGoodsReceiptDetail.BinLocationCode,

                                    CommodityID = pendingforGoodsReceiptDetail.CommodityID,
                                    CommodityCode = pendingforGoodsReceiptDetail.CommodityCode,
                                    CommodityName = pendingforGoodsReceiptDetail.CommodityName,

                                    Quantity = (decimal)pendingforGoodsReceiptDetail.QuantityRemains,
                                    LineVolume = (decimal)pendingforGoodsReceiptDetail.LineVolumeRemains,


                                    PackID = pendingforGoodsReceiptDetail.PackID,
                                    PackCode = pendingforGoodsReceiptDetail.PackCode,
                                    CartonID = pendingforGoodsReceiptDetail.CartonID,
                                    CartonCode = pendingforGoodsReceiptDetail.CartonCode,
                                    PalletID = pendingforGoodsReceiptDetail.PalletID,
                                    PalletCode = pendingforGoodsReceiptDetail.PalletCode,

                                    PackCounts = pendingforGoodsReceiptDetail.PackCounts,
                                    CartonCounts = pendingforGoodsReceiptDetail.CartonCounts,
                                    PalletCounts = pendingforGoodsReceiptDetail.PalletCounts
                                };
                                this.goodsReceiptViewModel.ViewDetails.Add(goodsReceiptDetailDTO);
                            }
                            this.goodsReceiptViewModel.ViewDetails.RaiseListChangedEvents = true;
                            this.goodsReceiptViewModel.ViewDetails.ResetBindings();
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

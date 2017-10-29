using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BrightIdeasSoftware;

using Ninject;

using TotalBase;
using TotalModel.Models;
using TotalCore.Repositories.Productions;
using TotalCore.Repositories.Inventories;
using TotalDTO.Inventories;
using TotalSmartCoding.Libraries;
using TotalSmartCoding.Controllers.APIs.Productions;
using TotalSmartCoding.Controllers.APIs.Inventories;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.ViewModels.Inventories;


namespace TotalSmartCoding.Views.Inventories.WarehouseAdjustments
{
    public partial class WizardUnpack : Form
    {
        private WarehouseAdjustmentViewModel warehouseAdjustmentViewModel;
        private CustomTabControl customTabBatch;

        private CartonAPIs cartonAPIs;
        private List<Carton> availableCartons;

        public WizardUnpack(WarehouseAdjustmentViewModel warehouseAdjustmentViewModel)
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


            this.warehouseAdjustmentViewModel = warehouseAdjustmentViewModel;
            this.cartonAPIs = new CartonAPIs(CommonNinject.Kernel.Get<ICartonRepository>());
            this.availableCartons = new List<Carton>();
        }


        private void WizardDetail_Load(object sender, EventArgs e)
        {
            try
            {
                GoodsReceiptAPIs goodsReceiptAPIs = new GoodsReceiptAPIs(CommonNinject.Kernel.Get<IGoodsReceiptAPIRepository>());

                List<GoodsReceiptDetailAvailable> goodsReceiptDetailAvailables = goodsReceiptAPIs.GetGoodsReceiptDetailAvailables(this.warehouseAdjustmentViewModel.LocationID, this.warehouseAdjustmentViewModel.WarehouseID, null, null, null, string.Join(",", this.warehouseAdjustmentViewModel.ViewDetails.Select(d => d.GoodsReceiptDetailID)));

                this.fastPendingPallets.SetObjects(goodsReceiptDetailAvailables.Where(w => w.PalletID != null));
                this.fastPendingCartons.SetObjects(this.availableCartons);

                this.customTabBatch.TabPages[0].Text = "Pending " + this.fastPendingPallets.GetItemCount().ToString("N0") + " pallet" + (this.fastPendingPallets.GetItemCount() > 1 ? "s      " : "      ");
                //this.customTabBatch.TabPages[1].Text = "Pending " + this.fastPendingCartons.GetItemCount().ToString("N0") + " carton" + (this.fastPendingCartons.GetItemCount() > 1 ? "s      " : "      ");
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
                        this.warehouseAdjustmentViewModel.ViewDetails.RaiseListChangedEvents = false;
                        foreach (var checkedObjects in fastPendingList.CheckedObjects)
                        {
                            GoodsReceiptDetailAvailable goodsReceiptDetailAvailable = (GoodsReceiptDetailAvailable)checkedObjects;
                            WarehouseAdjustmentDetailDTO warehouseAdjustmentDetailDTO = this.newWarehouseAdjustmentDetailDTO(goodsReceiptDetailAvailable.CommodityID, goodsReceiptDetailAvailable.CommodityCode, goodsReceiptDetailAvailable.CommodityName, goodsReceiptDetailAvailable.PackageSize, goodsReceiptDetailAvailable.Volume, goodsReceiptDetailAvailable.PackageVolume, goodsReceiptDetailAvailable.GoodsReceiptID, goodsReceiptDetailAvailable.GoodsReceiptDetailID, goodsReceiptDetailAvailable.GoodsReceiptReference, goodsReceiptDetailAvailable.GoodsReceiptEntryDate, goodsReceiptDetailAvailable.BatchID, goodsReceiptDetailAvailable.BatchEntryDate, goodsReceiptDetailAvailable.BinLocationID, goodsReceiptDetailAvailable.BinLocationCode, goodsReceiptDetailAvailable.WarehouseID, goodsReceiptDetailAvailable.WarehouseCode, goodsReceiptDetailAvailable.PackID, goodsReceiptDetailAvailable.PackCode, goodsReceiptDetailAvailable.CartonID, goodsReceiptDetailAvailable.CartonCode, goodsReceiptDetailAvailable.PalletID, goodsReceiptDetailAvailable.PalletCode, goodsReceiptDetailAvailable.PackCounts, goodsReceiptDetailAvailable.CartonCounts, goodsReceiptDetailAvailable.PalletCounts, (decimal)goodsReceiptDetailAvailable.QuantityAvailable, (decimal)goodsReceiptDetailAvailable.LineVolumeAvailable, -(decimal)goodsReceiptDetailAvailable.QuantityAvailable, -(decimal)goodsReceiptDetailAvailable.LineVolumeAvailable);
                            this.warehouseAdjustmentViewModel.ViewDetails.Add(warehouseAdjustmentDetailDTO);

                            foreach (Carton carton in this.availableCartons.Where(w => w.PalletID == goodsReceiptDetailAvailable.PalletID))
                            {
                                warehouseAdjustmentDetailDTO = this.newWarehouseAdjustmentDetailDTO(goodsReceiptDetailAvailable.CommodityID, goodsReceiptDetailAvailable.CommodityCode, goodsReceiptDetailAvailable.CommodityName, goodsReceiptDetailAvailable.PackageSize, goodsReceiptDetailAvailable.Volume, goodsReceiptDetailAvailable.PackageVolume, null, null, null, null, goodsReceiptDetailAvailable.BatchID, goodsReceiptDetailAvailable.BatchEntryDate, goodsReceiptDetailAvailable.BinLocationID, goodsReceiptDetailAvailable.BinLocationCode, goodsReceiptDetailAvailable.WarehouseID, goodsReceiptDetailAvailable.WarehouseCode, null, null, carton.CartonID, carton.Code, null, null, carton.PackCounts, 1, 0, 0, 0, 1, carton.LineVolume);
                                this.warehouseAdjustmentViewModel.ViewDetails.Add(warehouseAdjustmentDetailDTO);
                            }
                        }
                        this.warehouseAdjustmentViewModel.ViewDetails.RaiseListChangedEvents = true;
                        this.warehouseAdjustmentViewModel.ViewDetails.ResetBindings();
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

        private WarehouseAdjustmentDetailDTO newWarehouseAdjustmentDetailDTO(int commodityID, string commodityCode, string commodityName, string packageSize, decimal volume, decimal packageVolume, int? goodsReceiptID, int? goodsReceiptDetailID, string goodsReceiptReference, DateTime? goodsReceiptEntryDate, int? batchID, DateTime? batchEntryDate, int binLocationID, string binLocationCode, int warehouseID, string warehouseCode, int? packID, string packCode, int? cartonID, string cartonCode, int? palletID, string palletCode, int packCounts, int cartonCounts, int palletCounts, decimal quantityAvailable, decimal lineVolumeAvailable, decimal quantity, decimal lineVolume)
        {
            WarehouseAdjustmentDetailDTO warehouseAdjustmentDetailDTO = new WarehouseAdjustmentDetailDTO()
            {
                WarehouseAdjustmentID = this.warehouseAdjustmentViewModel.WarehouseAdjustmentID,

                CommodityID = commodityID,
                CommodityCode = commodityCode,
                CommodityName = commodityName,

                PackageSize = packageSize,

                Volume = volume,
                PackageVolume = packageVolume,

                GoodsReceiptID = goodsReceiptID,
                GoodsReceiptDetailID = goodsReceiptDetailID,

                GoodsReceiptReference = goodsReceiptReference,
                GoodsReceiptEntryDate = goodsReceiptEntryDate,

                BatchID = batchID,
                BatchEntryDate = batchEntryDate,

                BinLocationID = binLocationID,
                BinLocationCode = binLocationCode,

                WarehouseID = warehouseID,
                WarehouseCode = warehouseCode,

                PackID = packID,
                PackCode = packCode,
                CartonID = cartonID,
                CartonCode = cartonCode,
                PalletID = palletID,
                PalletCode = palletCode,

                PackCounts = packCounts,
                CartonCounts = cartonCounts,
                PalletCounts = palletCounts,

                QuantityAvailable = quantityAvailable,
                LineVolumeAvailable = lineVolumeAvailable,

                Quantity = quantity,
                LineVolume = lineVolume
            };
            return warehouseAdjustmentDetailDTO;
        }

        private void fastPendingPallets_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            OLVListItem olvListItem = this.fastPendingPallets.Items[e.Item.Index] as OLVListItem;
            GoodsReceiptDetailAvailable goodsReceiptDetailAvailable = olvListItem.RowObject as GoodsReceiptDetailAvailable;

            if (olvListItem.Checked)
            {
                IList<Carton> cartons = this.cartonAPIs.GetCartons(GlobalVariables.FillingLine.None, null, goodsReceiptDetailAvailable.PalletID);
                this.availableCartons.AddRange(cartons);
                this.fastPendingCartons.SetObjects(this.availableCartons);
            }
            else
                this.availableCartons.RemoveAll(x => x.PalletID == goodsReceiptDetailAvailable.PalletID);

            this.fastPendingCartons.SetObjects(this.availableCartons);
        }

        private void fastObjectListView_ItemsChanged(object sender, ItemsChangedEventArgs e)
        {
            if (sender.Equals(this.fastPendingCartons))
                this.customTabBatch.TabPages[1].Text = "Pending " + this.fastPendingCartons.GetItemCount().ToString("N0") + " carton" + (this.fastPendingCartons.GetItemCount() > 1 ? "s      " : "      ");
        }
    }
}

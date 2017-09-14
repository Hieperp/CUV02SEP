using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BrightIdeasSoftware;

using TotalModel.Models;
using TotalDTO.Sales;
using TotalSmartCoding.Controllers.APIs.Sales;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.ViewModels.Sales;


namespace TotalSmartCoding.Views.Sales.DeliveryAdvices
{
    public partial class WizardDetail : Form
    {
        private DeliveryAdviceAPIs deliveryAdviceAPIs;
        private DeliveryAdviceViewModel deliveryAdviceViewModel;
        private CustomTabControl customTabBatch;
        public WizardDetail(DeliveryAdviceAPIs deliveryAdviceAPIs, DeliveryAdviceViewModel deliveryAdviceViewModel)
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


            this.deliveryAdviceAPIs = deliveryAdviceAPIs;
            this.deliveryAdviceViewModel = deliveryAdviceViewModel;
        }


        private void WizardDetail_Load(object sender, EventArgs e)
        {
            try
            {
                List<PendingSalesOrderDetail> pendingSalesOrderDetails = this.deliveryAdviceAPIs.GetPendingSalesOrderDetails(this.deliveryAdviceViewModel.LocationID, this.deliveryAdviceViewModel.DeliveryAdviceID, this.deliveryAdviceViewModel.SalesOrderID, this.deliveryAdviceViewModel.CustomerID, string.Join(",", this.deliveryAdviceViewModel.ViewDetails.Select(d => d.SalesOrderDetailID)), false);

                //this.fastPendingPallets.SetObjects(pendingSalesOrderDetails.Where(w => w.PalletID != null));
                //this.fastPendingCartons.SetObjects(pendingSalesOrderDetails.Where(w => w.CartonID != null));
                //this.fastPendingPacks.SetObjects(pendingSalesOrderDetails.Where(w => w.PackID != null));

                this.customTabBatch.TabPages[0].Text = "Pending " + this.fastPendingPallets.GetItemCount().ToString("N0") + " pallet" + (this.fastPendingPacks.GetItemCount() > 1 ? "s      " : "      ");
                this.customTabBatch.TabPages[1].Text = "Pending " + this.fastPendingCartons.GetItemCount().ToString("N0") + " carton" + (this.fastPendingPacks.GetItemCount() > 1 ? "s      " : "      ");
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
                            PendingSalesOrderDetail pendingSalesOrderDetail = (PendingSalesOrderDetail)checkedObjects;
                            DeliveryAdviceDetailDTO deliveryAdviceDetailDTO = new DeliveryAdviceDetailDTO()
                            {
                                DeliveryAdviceID = this.deliveryAdviceViewModel.DeliveryAdviceID,

                                SalesOrderID = pendingSalesOrderDetail.SalesOrderID,
                                SalesOrderDetailID = pendingSalesOrderDetail.SalesOrderDetailID,
                                SalesOrderReference = pendingSalesOrderDetail.SalesOrderReference,
                                SalesOrderEntryDate = pendingSalesOrderDetail.SalesOrderEntryDate,

                                CommodityID = pendingSalesOrderDetail.CommodityID,
                                CommodityCode = pendingSalesOrderDetail.CommodityCode,
                                CommodityName = pendingSalesOrderDetail.CommodityName,

                                PackageSize = pendingSalesOrderDetail.PackageSize,

                                Volume = pendingSalesOrderDetail.Volume,
                                PackageVolume = pendingSalesOrderDetail.PackageVolume,

                                Quantity = (decimal)pendingSalesOrderDetail.QuantityRemains,
                                LineVolume = (decimal)pendingSalesOrderDetail.LineVolumeRemains
                            };
                            this.deliveryAdviceViewModel.ViewDetails.Add(deliveryAdviceDetailDTO);
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

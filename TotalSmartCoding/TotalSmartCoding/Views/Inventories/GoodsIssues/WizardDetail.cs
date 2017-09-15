using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using BrightIdeasSoftware;

using TotalModel.Models;
using TotalDTO.Inventories;
using TotalSmartCoding.Controllers.APIs.Inventories;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.ViewModels.Inventories;


namespace TotalSmartCoding.Views.Inventories.GoodsIssues
{
    public partial class WizardDetail : Form
    {
        private GoodsIssueAPIs goodsIssueAPIs;
        private GoodsIssueViewModel goodsIssueViewModel;
        private CustomTabControl customTabBatch;
        public WizardDetail(GoodsIssueAPIs goodsIssueAPIs, GoodsIssueViewModel goodsIssueViewModel)
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


            this.goodsIssueAPIs = goodsIssueAPIs;
            this.goodsIssueViewModel = goodsIssueViewModel;
        }


        private void WizardDetail_Load(object sender, EventArgs e)
        {
            try
            {
                List<PendingDeliveryAdviceDetail> pendingDeliveryAdviceDetails = this.goodsIssueAPIs.GetPendingDeliveryAdviceDetails(this.goodsIssueViewModel.LocationID, this.goodsIssueViewModel.GoodsIssueID, this.goodsIssueViewModel.DeliveryAdviceID, this.goodsIssueViewModel.CustomerID, string.Join(",", this.goodsIssueViewModel.ViewDetails.Select(d => d.DeliveryAdviceDetailID)), false);

                this.fastPendingPallets.SetObjects(pendingDeliveryAdviceDetails);
                //this.fastPendingPallets.SetObjects(pendingDeliveryAdviceDetails.Where(w => w.PalletID != null));
                //this.fastPendingCartons.SetObjects(pendingDeliveryAdviceDetails.Where(w => w.CartonID != null));
                //this.fastPendingPacks.SetObjects(pendingDeliveryAdviceDetails.Where(w => w.PackID != null));

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
                            PendingDeliveryAdviceDetail pendingDeliveryAdviceDetail = (PendingDeliveryAdviceDetail)checkedObjects;
                            GoodsIssueDetailDTO goodsIssueDetailDTO = new GoodsIssueDetailDTO()
                            {
                                GoodsIssueID = this.goodsIssueViewModel.GoodsIssueID,

                                DeliveryAdviceID = pendingDeliveryAdviceDetail.DeliveryAdviceID,
                                DeliveryAdviceDetailID = pendingDeliveryAdviceDetail.DeliveryAdviceDetailID,
                                DeliveryAdviceReference = pendingDeliveryAdviceDetail.DeliveryAdviceReference,
                                DeliveryAdviceEntryDate = pendingDeliveryAdviceDetail.DeliveryAdviceEntryDate,

                                //BinLocationID = pendingDeliveryAdviceDetail.BinLocationID,
                                //BinLocationCode = pendingDeliveryAdviceDetail.BinLocationCode,

                                CommodityID = pendingDeliveryAdviceDetail.CommodityID,
                                CommodityCode = pendingDeliveryAdviceDetail.CommodityCode,
                                CommodityName = pendingDeliveryAdviceDetail.CommodityName,

                                Quantity = (decimal)pendingDeliveryAdviceDetail.QuantityRemains,
                                //Volume = pendingDeliveryAdviceDetail.Volume,
                                

                                //PackID = pendingDeliveryAdviceDetail.PackID,
                                //PackCode = pendingDeliveryAdviceDetail.PackCode,
                                //CartonID = pendingDeliveryAdviceDetail.CartonID,
                                //CartonCode = pendingDeliveryAdviceDetail.CartonCode,
                                //PalletID = pendingDeliveryAdviceDetail.PalletID,
                                //PalletCode = pendingDeliveryAdviceDetail.PalletCode,
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

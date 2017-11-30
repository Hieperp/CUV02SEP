using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Ninject;


using TotalSmartCoding.Views.Mains;


using TotalSmartCoding.Libraries;
using TotalSmartCoding.Libraries.Helpers;

using TotalCore.Repositories.Inventories;
using TotalSmartCoding.Controllers.APIs.Inventories;
using TotalBase;
using TotalModel.Models;
using TotalSmartCoding.ViewModels.Helpers;


namespace TotalSmartCoding.Views.Inventories.GoodsReceipts
{
    public partial class GoodsReceiptDetailAvailables : BaseView
    {
        private CustomTabControl customTabBatch;

        private GoodsReceiptAPIs goodsReceiptAPIs;

        public GoodsReceiptDetailAvailables()
            : base()
        {
            InitializeComponent();

            this.toolstripChild = this.toolStripChildForm;

            this.goodsReceiptAPIs = new GoodsReceiptAPIs(CommonNinject.Kernel.Get<IGoodsReceiptAPIRepository>());
        }

        protected override void InitializeTabControl()
        {
            try
            {
                base.InitializeTabControl();

                this.customTabBatch = new CustomTabControl();

                this.customTabBatch.Font = this.fastAvailablePallets.Font;
                this.customTabBatch.DisplayStyle = TabStyle.VisualStudio;
                this.customTabBatch.DisplayStyleProvider.ImageAlign = ContentAlignment.MiddleLeft;

                this.customTabBatch.TabPages.Add("tabPendingPallets", "Pending pallets");
                this.customTabBatch.TabPages.Add("tabPendingCartons", "Pending cartons");
                this.customTabBatch.TabPages[0].Controls.Add(this.fastAvailablePallets);
                this.customTabBatch.TabPages[1].Controls.Add(this.fastAvailableCartons);


                this.customTabBatch.Dock = DockStyle.Fill;
                this.fastAvailablePallets.Dock = DockStyle.Fill;
                this.fastAvailableCartons.Dock = DockStyle.Fill;
                this.Controls.Add(this.customTabBatch);
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        public override void Loading()
        {
            List<GoodsReceiptDetailAvailable> goodsReceiptDetailAvailables = goodsReceiptAPIs.GetGoodsReceiptDetailAvailables(ContextAttributes.User.LocationID, null, null, null, null, null, false);

            this.fastAvailablePallets.SetObjects(goodsReceiptDetailAvailables.Where(w => w.PalletID != null));
            this.fastAvailableCartons.SetObjects(goodsReceiptDetailAvailables.Where(w => w.CartonID != null));

            this.ShowRowCount();
        }

        public override void ApplyFilter(string filterTexts)
        {
            OLVHelpers.ApplyFilters(this.fastAvailablePallets, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            OLVHelpers.ApplyFilters(this.fastAvailableCartons, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

            this.ShowRowCount();
        }

        private void ShowRowCount()
        {
            decimal? totalQuantityAvailables = this.fastAvailablePallets.FilteredObjects.Cast<GoodsReceiptDetailAvailable>().Select(o => o.QuantityAvailable).Sum();
            decimal? totalLineVolumeAvailables = this.fastAvailablePallets.FilteredObjects.Cast<GoodsReceiptDetailAvailable>().Select(o => o.LineVolumeAvailable).Sum();
            this.customTabBatch.TabPages[0].Text = "Available " + this.fastAvailablePallets.GetItemCount().ToString("N0") + " pallet" + (this.fastAvailablePallets.GetItemCount() > 1 ? "s" : "") + ", Total quantity: " + (totalQuantityAvailables != null ? ((decimal)totalQuantityAvailables).ToString("N0") : "0") + ", Total volume: " + (totalLineVolumeAvailables != null ? ((decimal)totalLineVolumeAvailables).ToString("N2") : "0") + "       ";

            totalQuantityAvailables = this.fastAvailableCartons.FilteredObjects.Cast<GoodsReceiptDetailAvailable>().Select(o => o.QuantityAvailable).Sum();
            totalLineVolumeAvailables = this.fastAvailableCartons.FilteredObjects.Cast<GoodsReceiptDetailAvailable>().Select(o => o.LineVolumeAvailable).Sum();
            this.customTabBatch.TabPages[1].Text = "Available " + this.fastAvailableCartons.GetItemCount().ToString("N0") + " carton" + (this.fastAvailableCartons.GetItemCount() > 1 ? "s" : "") + ", Total quantity: " + (totalQuantityAvailables != null ? ((decimal)totalQuantityAvailables).ToString("N0") : "0") + ", Total volume: " + (totalLineVolumeAvailables != null ? ((decimal)totalLineVolumeAvailables).ToString("N2") : "0") + "       ";
        }

        private void buttonWarehouseJournals_Click(object sender, EventArgs e)
        {
            try
            {
                PrintViewModel printViewModel = new PrintViewModel();
                printViewModel.ReportPath = "WarehouseJournals";
                printViewModel.ReportParameters.Add(new Microsoft.Reporting.WinForms.ReportParameter("LocationID", ContextAttributes.User.LocationID.ToString()));

                SsrsViewer ssrsViewer = new SsrsViewer(printViewModel);
                ssrsViewer.Show();
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }
    }
}

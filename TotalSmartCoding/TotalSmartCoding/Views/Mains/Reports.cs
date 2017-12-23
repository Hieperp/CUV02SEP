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
using TotalSmartCoding.ViewModels.Inventories;
using TotalSmartCoding.Controllers.APIs.Commons;
using TotalCore.Repositories.Commons;
using BrightIdeasSoftware;


namespace TotalSmartCoding.Views.Mains
{
    public partial class Reports : BaseView
    {
        private CustomTabControl customTabBatch;

        private GoodsReceiptAPIs goodsReceiptAPIs;

        public Reports()
            : base()
        {
            InitializeComponent();

            this.toolstripChild = this.toolStripChildForm;

            this.goodsReceiptAPIs = new GoodsReceiptAPIs(CommonNinject.Kernel.Get<IGoodsReceiptAPIRepository>());

            this.baseDTO = new GoodsReceiptDetailAvailableViewModel(); ;
        }

        protected override void InitializeTabControl()
        {
            try
            {
                base.InitializeTabControl();

                this.customTabBatch = new CustomTabControl();

                this.customTabBatch.Font = this.treeWarehouseID.Font;
                this.customTabBatch.DisplayStyle = TabStyle.VisualStudio;
                this.customTabBatch.DisplayStyleProvider.ImageAlign = ContentAlignment.MiddleLeft;

                this.customTabBatch.TabPages.Add("tabPendingPallets", "Pending pallets");
                this.customTabBatch.TabPages.Add("tabPendingCartons", "Pending cartons");
                this.customTabBatch.TabPages[0].Controls.Add(this.treeWarehouseID);
                this.customTabBatch.TabPages[1].Controls.Add(this.treeCommodityID);


                this.customTabBatch.Dock = DockStyle.Fill;
                this.treeWarehouseID.Dock = DockStyle.Fill;
                this.treeCommodityID.Dock = DockStyle.Fill;
                this.Controls.Add(this.customTabBatch);
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        Binding bindingLocationID;

        protected override void InitializeCommonControlBinding()
        {
            base.InitializeCommonControlBinding();

            this.LocationID = ContextAttributes.User.LocationID;
            LocationAPIs locationAPIs = new LocationAPIs(CommonNinject.Kernel.Get<ILocationAPIRepository>());

            this.comboLocationID.ComboBox.DataSource = locationAPIs.GetLocationBases();
            this.comboLocationID.ComboBox.DisplayMember = CommonExpressions.PropertyName<LocationBase>(p => p.Name);
            this.comboLocationID.ComboBox.ValueMember = CommonExpressions.PropertyName<LocationBase>(p => p.LocationID);
            this.bindingLocationID = this.comboLocationID.ComboBox.DataBindings.Add("SelectedValue", this, "LocationID", true, DataSourceUpdateMode.OnPropertyChanged);

            this.bindingLocationID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
        }

       

        private int locationID;
        public int LocationID
        {
            get { return this.locationID; }
            set
            {
                if (this.locationID != value)
                {
                    this.locationID = value;
                    if (this.locationID > 0)
                    {
                        List<GoodsReceiptDetailAvailable> goodsReceiptDetailAvailables = goodsReceiptAPIs.GetGoodsReceiptDetailAvailables(this.LocationID, null, null, null, null, null, false);

                        this.treeWarehouseID.SetObjects(goodsReceiptDetailAvailables.Where(w => w.PalletID != null));
                        this.treeCommodityID.SetObjects(goodsReceiptDetailAvailables.Where(w => w.CartonID != null));
                    }
                }
            }
        }

        public override void ApplyFilter(string filterTexts)
        {
            OLVHelpers.ApplyFilters(this.treeWarehouseID, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            OLVHelpers.ApplyFilters(this.treeCommodityID, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
        }

        protected override PrintViewModel InitPrintViewModel()
        {
            PrintViewModel printViewModel = base.InitPrintViewModel();
            printViewModel.ReportPath = "AvailableItems";
            printViewModel.ReportParameters.Add(new Microsoft.Reporting.WinForms.ReportParameter("LocationID", this.LocationID.ToString()));
            printViewModel.ReportParameters.Add(new Microsoft.Reporting.WinForms.ReportParameter("LocationCode", this.comboLocationID.Text));
            return printViewModel;
        }

        private void buttonWarehouseJournals_Click(object sender, EventArgs e)
        {
            try
            {
                PrintViewModel printViewModel = new PrintViewModel();
                printViewModel.ReportPath = "WarehouseJournals";
                printViewModel.ReportParameters.Add(new Microsoft.Reporting.WinForms.ReportParameter("LocationID", this.LocationID.ToString()));

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

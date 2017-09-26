using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Ninject;



using TotalSmartCoding.Views.Mains;



using TotalBase.Enums;
using TotalSmartCoding.Libraries;
using TotalSmartCoding.Libraries.Helpers;

using TotalSmartCoding.Controllers.Inventories;
using TotalCore.Repositories.Inventories;
using TotalSmartCoding.Controllers.APIs.Inventories;
using TotalCore.Services.Inventories;
using TotalSmartCoding.ViewModels.Inventories;

namespace TotalSmartCoding.Views.Inventories.GoodsReceipts
{
    public partial class GoodsReceipts : BaseView
    {
        private CustomTabControl customTabLeft;
        private CustomTabControl customTabCenter;

        private GoodsReceiptAPIs goodsReceiptAPIs;
        private GoodsReceiptViewModel goodsReceiptViewModel { get; set; }

        public GoodsReceipts()
            : base()
        {
            InitializeComponent();


            this.toolstripChild = this.toolStripChildForm;
            this.fastListIndex = this.fastGoodsReceiptIndex;

            this.goodsReceiptAPIs = new GoodsReceiptAPIs(CommonNinject.Kernel.Get<IGoodsReceiptAPIRepository>());

            this.goodsReceiptViewModel = CommonNinject.Kernel.Get<GoodsReceiptViewModel>();
            this.goodsReceiptViewModel.PropertyChanged += new PropertyChangedEventHandler(ModelDTO_PropertyChanged);
            this.baseDTO = this.goodsReceiptViewModel;
        }

        protected override void InitializeTabControl()
        {
            try
            {
                base.InitializeTabControl();

                this.customTabLeft = new CustomTabControl();
                this.customTabLeft.DisplayStyle = TabStyle.VisualStudio;

                this.customTabLeft.TabPages.Add("tabLeftAA", "Receipts   ");
                this.customTabLeft.TabPages[0].BackColor = this.panelLeft.BackColor;
                this.customTabLeft.TabPages[0].Padding = new Padding(10, 0, 0, 0);
                this.customTabLeft.TabPages[0].Controls.Add(this.layoutLeft);

                this.customTabLeft.Dock = DockStyle.Fill;
                this.panelLeft.Controls.Add(this.customTabLeft);

                this.layoutLeft.ColumnStyles[this.layoutLeft.ColumnCount - 1].SizeType = SizeType.Absolute; this.layoutLeft.ColumnStyles[this.layoutLeft.ColumnCount - 1].Width = 10;


                this.customTabCenter = new CustomTabControl();
                this.customTabCenter.DisplayStyle = TabStyle.VisualStudio;

                this.customTabCenter.TabPages.Add("tabCenterAA", "Pallets   ");
                this.customTabCenter.TabPages.Add("tabCenterBB", "Cartons   ");
                //this.customTabCenter.TabPages[0].BackColor = this.panelCenter.BackColor;
                //this.customTabCenter.TabPages[0].Padding = new Padding(10, 0, 0, 0);
                this.customTabCenter.TabPages[0].Controls.Add(this.gridexPalletDetails);
                this.customTabCenter.TabPages[1].Controls.Add(this.gridexCartonDetails);
                this.gridexPalletDetails.Dock = DockStyle.Fill;
                this.gridexCartonDetails.Dock = DockStyle.Fill;

                this.customTabCenter.Dock = DockStyle.Fill;
                this.panelCenter.Controls.Add(this.customTabCenter);

                
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        Binding bindingEntryDate;
        Binding bindingReference;

        protected override void InitializeCommonControlBinding()
        {
            base.InitializeCommonControlBinding();

            this.bindingReference = this.textexReference.DataBindings.Add("Text", this.goodsReceiptViewModel, "Reference", true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingEntryDate = this.dateTimexEntryDate.DataBindings.Add("Value", this.goodsReceiptViewModel, "EntryDate", true);


            this.bindingReference.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingEntryDate.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);





            
            this.tableLayoutPanelExtend.ColumnStyles[this.tableLayoutPanelExtend.ColumnCount - 1].SizeType = SizeType.Absolute; this.tableLayoutPanelExtend.ColumnStyles[this.tableLayoutPanelExtend.ColumnCount - 1].Width = 10;
        }

        protected override void InitializeDataGridBinding()
        {
            this.gridexPalletDetails.AutoGenerateColumns = false;
            this.gridexPalletDetails.DataSource = this.goodsReceiptViewModel.ViewDetails;
            this.gridexCartonDetails.DataSource = this.goodsReceiptViewModel.PalletDetails;

            //StackedHeaderDecorator stackedHeaderDecorator = new StackedHeaderDecorator(this.dataGridViewDetails);
        }

        protected override Controllers.BaseController myController
        {
            get { return new GoodsReceiptController(CommonNinject.Kernel.Get<IGoodsReceiptService>(), this.goodsReceiptViewModel); }
        }

        public override void Loading()
        {
            this.fastGoodsReceiptIndex.SetObjects(this.goodsReceiptAPIs.GetGoodsReceiptIndexes());
            base.Loading();
        }

        protected override DialogResult wizardMaster()
        {
            WizardMaster wizardMaster = new WizardMaster(this.goodsReceiptAPIs, this.goodsReceiptViewModel);
            return wizardMaster.ShowDialog();
        }

        protected override void wizardDetail()
        {
            base.wizardDetail();
            WizardDetail wizardDetail = new WizardDetail(this.goodsReceiptAPIs, this.goodsReceiptViewModel);
            wizardDetail.ShowDialog();
        }

        private void naviGroupDetails_HeaderMouseClick(object sender, MouseEventArgs e)
        {
            this.toolStripNaviGroupDetails.Visible = this.naviGroupDetails.Expanded;
        }

        private void toolStripButtonShowDetailsExtend_Click(object sender, EventArgs e)
        {
            this.naviGroup1.Expanded = !this.naviGroup1.Expanded;
            this.naviGroup1.Padding = new Padding(0, 0, 0, 0);
            //this.toolStripButtonShowDetailsExtend.Image = this.naviGroup1.Expanded ? ResourceIcon.Chevron_Collapse.ToBitmap() : ResourceIcon.Chevron_Expand.ToBitmap();
        }



    }
}

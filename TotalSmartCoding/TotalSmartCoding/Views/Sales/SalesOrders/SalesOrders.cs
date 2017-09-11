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

using TotalSmartCoding.Controllers.Sales;
using TotalCore.Repositories.Sales;
using TotalSmartCoding.Controllers.APIs.Sales;
using TotalCore.Services.Sales;
using TotalSmartCoding.ViewModels.Sales;
using TotalSmartCoding.Controllers.APIs.Commons;
using TotalCore.Repositories.Commons;
using TotalBase;
using TotalModel.Models;
using TotalDTO.Sales;

namespace TotalSmartCoding.Views.Sales.SalesOrders
{
    public partial class SalesOrders : BaseView
    {
        private SalesOrderAPIs goodsReceiptAPIs;        
        private SalesOrderViewModel goodsReceiptViewModel { get; set; }

        public SalesOrders()
            : base()
        {
            InitializeComponent();


            this.toolstripChild = this.toolStripChildForm;
            this.fastListIndex = this.fastSalesOrderIndex;

            this.goodsReceiptAPIs = new SalesOrderAPIs(CommonNinject.Kernel.Get<ISalesOrderAPIRepository>());            

            this.goodsReceiptViewModel = CommonNinject.Kernel.Get<SalesOrderViewModel>();
            this.goodsReceiptViewModel.PropertyChanged += new PropertyChangedEventHandler(ModelDTO_PropertyChanged);
            this.baseDTO = this.goodsReceiptViewModel;
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






            this.naviGroupDetails.DataBindings.Add("ExpandedHeight", this.numericUpDownSizingDetail, "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownSizingDetail.Minimum = this.naviGroupDetails.HeaderHeight * 2;
            this.numericUpDownSizingDetail.Maximum = this.naviGroupDetails.Height + this.fastSalesOrderIndex.Height;

            this.tableLayoutPanelMaster.ColumnStyles[this.tableLayoutPanelMaster.ColumnCount - 1].SizeType = SizeType.Absolute; this.tableLayoutPanelMaster.ColumnStyles[this.tableLayoutPanelMaster.ColumnCount - 1].Width = 10;
            this.tableLayoutPanelExtend.ColumnStyles[this.tableLayoutPanelExtend.ColumnCount - 1].SizeType = SizeType.Absolute; this.tableLayoutPanelExtend.ColumnStyles[this.tableLayoutPanelExtend.ColumnCount - 1].Width = 10;
        }

        protected override void InitializeDataGridBinding()
        {
            this.gridexViewDetails.AutoGenerateColumns = false;
            this.gridexViewDetails.DataSource = this.goodsReceiptViewModel.ViewDetails;

            this.goodsReceiptViewModel.ViewDetails.ListChanged += ViewDetails_ListChanged;

            this.gridexViewDetails.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.gridexViewDetails_EditingControlShowing);

            //StackedHeaderDecorator stackedHeaderDecorator = new StackedHeaderDecorator(this.dataGridViewDetails);


            DataGridViewComboBoxColumn comboBoxColumn;
            CommodityAPIs commodityAPIs = new CommodityAPIs(CommonNinject.Kernel.Get<ICommodityAPIRepository>());

            comboBoxColumn = (DataGridViewComboBoxColumn)this.gridexViewDetails.Columns[CommonExpressions.PropertyName<SalesOrderDetailDTO>(p => p.CommodityID)];
            comboBoxColumn.DataSource = commodityAPIs.GetCommodityBases(true);
            comboBoxColumn.DisplayMember = CommonExpressions.PropertyName<CommodityBase>(p => p.Code);
            comboBoxColumn.ValueMember = CommonExpressions.PropertyName<CommodityBase>(p => p.CommodityID);
        }

        private void ViewDetails_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (this.EditableMode && e.PropertyDescriptor != null && e.NewIndex >= 0 && e.NewIndex < this.goodsReceiptViewModel.ViewDetails.Count)
            {
                SalesOrderDetailDTO salesOrderDetailDTO = this.goodsReceiptViewModel.ViewDetails[e.NewIndex];
                if (salesOrderDetailDTO != null)
                    this.CalculateQuantityDetailDTO(salesOrderDetailDTO, e.PropertyDescriptor.Name);
            }
        }

        protected override Controllers.BaseController myController
        {
            get { return new SalesOrderController(CommonNinject.Kernel.Get<ISalesOrderService>(), this.goodsReceiptViewModel); }
        }

        public override void Loading()
        {
            this.fastSalesOrderIndex.SetObjects(this.goodsReceiptAPIs.GetSalesOrderIndexes());
            base.Loading();
        }


        //protected override DialogResult wizardMaster()
        //{
        //    WizardMaster wizardMaster = new WizardMaster(this.goodsReceiptAPIs, this.goodsReceiptViewModel);
        //    return wizardMaster.ShowDialog();
        //}

        //protected override void wizardDetail()
        //{
        //    base.wizardDetail();
        //    WizardDetail wizardDetail = new WizardDetail(this.goodsReceiptAPIs, this.goodsReceiptViewModel);
        //    wizardDetail.ShowDialog();
        //}



    }
}

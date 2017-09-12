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
        private SalesOrderViewModel salesOrderViewModel { get; set; }

        public SalesOrders()
            : base()
        {
            InitializeComponent();


            this.toolstripChild = this.toolStripChildForm;
            this.fastListIndex = this.fastSalesOrderIndex;

            this.goodsReceiptAPIs = new SalesOrderAPIs(CommonNinject.Kernel.Get<ISalesOrderAPIRepository>());

            this.salesOrderViewModel = CommonNinject.Kernel.Get<SalesOrderViewModel>();
            this.salesOrderViewModel.PropertyChanged += new PropertyChangedEventHandler(ModelDTO_PropertyChanged);
            this.baseDTO = this.salesOrderViewModel;
        }

        Binding bindingEntryDate;
        Binding bindingReference;

        Binding bindingCustomerID;
        Binding bindingSalespersonID;

        protected override void InitializeCommonControlBinding()
        {
            base.InitializeCommonControlBinding();

            this.bindingReference = this.textexReference.DataBindings.Add("Text", this.salesOrderViewModel, "Reference", true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingEntryDate = this.dateTimexEntryDate.DataBindings.Add("Value", this.salesOrderViewModel, "EntryDate", true);

            CustomerAPIs customerAPIs = new CustomerAPIs(CommonNinject.Kernel.Get<ICustomerAPIRepository>());

            this.combexCustomerID.DataSource = customerAPIs.GetCustomerBases();
            this.combexCustomerID.DisplayMember = CommonExpressions.PropertyName<CustomerBase>(p => p.Name);
            this.combexCustomerID.ValueMember = CommonExpressions.PropertyName<CustomerBase>(p => p.CustomerID);
            this.bindingCustomerID = this.combexCustomerID.DataBindings.Add("SelectedValue", this.salesOrderViewModel, CommonExpressions.PropertyName<SalesOrderViewModel>(p => p.CustomerID), true, DataSourceUpdateMode.OnPropertyChanged);


            EmployeeAPIs employeeAPIs = new EmployeeAPIs(CommonNinject.Kernel.Get<IEmployeeAPIRepository>());

            this.combexSalespersonID.DataSource = employeeAPIs.GetEmployeeBases();
            this.combexSalespersonID.DisplayMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.Name);
            this.combexSalespersonID.ValueMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.EmployeeID);
            this.bindingSalespersonID = this.combexSalespersonID.DataBindings.Add("SelectedValue", this.salesOrderViewModel, CommonExpressions.PropertyName<SalesOrderViewModel>(p => p.SalespersonID), true, DataSourceUpdateMode.OnPropertyChanged);


            this.bindingReference.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingEntryDate.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

            this.bindingCustomerID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingSalespersonID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

            this.naviGroupDetails.DataBindings.Add("ExpandedHeight", this.numericUpDownSizingDetail, "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownSizingDetail.Minimum = this.naviGroupDetails.HeaderHeight * 2;
            this.numericUpDownSizingDetail.Maximum = this.naviGroupDetails.Height + this.fastSalesOrderIndex.Height;

            this.tableLayoutPanelMaster.ColumnStyles[this.tableLayoutPanelMaster.ColumnCount - 1].SizeType = SizeType.Absolute; this.tableLayoutPanelMaster.ColumnStyles[this.tableLayoutPanelMaster.ColumnCount - 1].Width = 10;
            this.tableLayoutPanelExtend.ColumnStyles[this.tableLayoutPanelExtend.ColumnCount - 1].SizeType = SizeType.Absolute; this.tableLayoutPanelExtend.ColumnStyles[this.tableLayoutPanelExtend.ColumnCount - 1].Width = 10;
        }

        protected override void InitializeDataGridBinding()
        {
            this.gridexViewDetails.AutoGenerateColumns = false;
            this.gridexViewDetails.DataSource = this.salesOrderViewModel.ViewDetails;

            this.salesOrderViewModel.ViewDetails.ListChanged += ViewDetails_ListChanged;

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
            if (this.EditableMode && e.PropertyDescriptor != null && e.NewIndex >= 0 && e.NewIndex < this.salesOrderViewModel.ViewDetails.Count)
            {
                SalesOrderDetailDTO salesOrderDetailDTO = this.salesOrderViewModel.ViewDetails[e.NewIndex];
                if (salesOrderDetailDTO != null)
                    this.CalculateQuantityDetailDTO(salesOrderDetailDTO, e.PropertyDescriptor.Name);
            }
        }

        protected override Controllers.BaseController myController
        {
            get { return new SalesOrderController(CommonNinject.Kernel.Get<ISalesOrderService>(), this.salesOrderViewModel); }
        }

        public override void Loading()
        {
            this.fastSalesOrderIndex.SetObjects(this.goodsReceiptAPIs.GetSalesOrderIndexes());
            base.Loading();
        }

        private void gridexViewDetails_ReadOnlyChanged(object sender, EventArgs e)
        {
            string columnName = CommonExpressions.PropertyName<SalesOrderDetailDTO>(p => p.CommodityName);
            this.gridexViewDetails.Columns[columnName].ReadOnly = true;
            columnName = CommonExpressions.PropertyName<SalesOrderDetailDTO>(p => p.PackageSize);
            this.gridexViewDetails.Columns[columnName].ReadOnly = true;
            columnName = CommonExpressions.PropertyName<SalesOrderDetailDTO>(p => p.PackageVolume);
            this.gridexViewDetails.Columns[columnName].ReadOnly = true;
        }
    }
}

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

namespace TotalSmartCoding.Views.Inventories.WarehouseAdjustments
{
    public partial class WarehouseAdjustmentsXYZ : BaseView
    {
        private WarehouseAdjustmentAPIs warehouseAdjustmentAPIs;
        private WarehouseAdjustmentViewModel warehouseAdjustmentViewModel { get; set; }

        public WarehouseAdjustmentsXYZ()
            : base()
        {
            InitializeComponent();


            this.toolstripChild = this.toolStripChildForm;
            this.fastListIndex = this.fastWarehouseAdjustmentIndex;

            this.warehouseAdjustmentAPIs = new WarehouseAdjustmentAPIs(CommonNinject.Kernel.Get<IWarehouseAdjustmentAPIRepository>());

            this.warehouseAdjustmentViewModel = CommonNinject.Kernel.Get<WarehouseAdjustmentViewModel>();
            this.warehouseAdjustmentViewModel.PropertyChanged += new PropertyChangedEventHandler(ModelDTO_PropertyChanged);
            this.baseDTO = this.warehouseAdjustmentViewModel;
        }

        Binding bindingEntryDate;
        Binding bindingReference;

        protected override void InitializeCommonControlBinding()
        {
            base.InitializeCommonControlBinding();

            this.bindingReference = this.textexReference.DataBindings.Add("Text", this.warehouseAdjustmentViewModel, "Reference", true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingEntryDate = this.dateTimexEntryDate.DataBindings.Add("Value", this.warehouseAdjustmentViewModel, "EntryDate", true);


            this.bindingReference.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingEntryDate.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);






            this.naviGroupDetails.DataBindings.Add("ExpandedHeight", this.numericUpDownSizingDetail, "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownSizingDetail.Minimum = this.naviGroupDetails.HeaderHeight * 2;
            this.numericUpDownSizingDetail.Maximum = this.naviGroupDetails.Height + this.fastWarehouseAdjustmentIndex.Height;

            this.tableLayoutPanelMaster.ColumnStyles[this.tableLayoutPanelMaster.ColumnCount - 1].SizeType = SizeType.Absolute; this.tableLayoutPanelMaster.ColumnStyles[this.tableLayoutPanelMaster.ColumnCount - 1].Width = 10;
            this.tableLayoutPanelExtend.ColumnStyles[this.tableLayoutPanelExtend.ColumnCount - 1].SizeType = SizeType.Absolute; this.tableLayoutPanelExtend.ColumnStyles[this.tableLayoutPanelExtend.ColumnCount - 1].Width = 10;
        }

        protected override void InitializeDataGridBinding()
        {
            this.gridexViewDetails.AutoGenerateColumns = false;
            this.gridexViewDetails.DataSource = this.warehouseAdjustmentViewModel.PalletDetails;
            this.dataGridexView1.DataSource = this.warehouseAdjustmentViewModel.CartonDetails;

            //StackedHeaderDecorator stackedHeaderDecorator = new StackedHeaderDecorator(this.dataGridViewDetails);
        }

        protected override Controllers.BaseController myController
        {
            get { return new WarehouseAdjustmentController(CommonNinject.Kernel.Get<IWarehouseAdjustmentService>(), this.warehouseAdjustmentViewModel); }
        }

        public override void Loading()
        {
            this.fastWarehouseAdjustmentIndex.SetObjects(this.warehouseAdjustmentAPIs.GetWarehouseAdjustmentIndexes());
            base.Loading();
        }

        protected override DialogResult wizardMaster()
        {
            WizardMaster wizardMaster = new WizardMaster(this.warehouseAdjustmentViewModel);
            DialogResult dialogResult = wizardMaster.ShowDialog();

            wizardMaster.Dispose();
            return dialogResult;
        }

        protected override void wizardDetail()
        {
            base.wizardDetail();
            WizardDetail wizardDetail = new WizardDetail(this.warehouseAdjustmentViewModel);

            wizardDetail.ShowDialog();
            wizardDetail.Dispose();
        }



    }
}

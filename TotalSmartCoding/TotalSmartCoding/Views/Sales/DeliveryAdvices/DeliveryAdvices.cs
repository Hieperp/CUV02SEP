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

namespace TotalSmartCoding.Views.Sales.DeliveryAdvices
{
    public partial class DeliveryAdvices : BaseView
    {
        private DeliveryAdviceAPIs deliveryAdviceAPIs;
        private DeliveryAdviceViewModel deliveryAdviceViewModel { get; set; }

        public DeliveryAdvices()
            : base()
        {
            InitializeComponent();


            this.toolstripChild = this.toolStripChildForm;
            this.fastListIndex = this.fastDeliveryAdviceIndex;

            this.deliveryAdviceAPIs = new DeliveryAdviceAPIs(CommonNinject.Kernel.Get<IDeliveryAdviceAPIRepository>());

            this.deliveryAdviceViewModel = CommonNinject.Kernel.Get<DeliveryAdviceViewModel>();
            this.deliveryAdviceViewModel.PropertyChanged += new PropertyChangedEventHandler(ModelDTO_PropertyChanged);
            this.baseDTO = this.deliveryAdviceViewModel;
        }

        Binding bindingEntryDate;
        Binding bindingReference;

        protected override void InitializeCommonControlBinding()
        {
            base.InitializeCommonControlBinding();

            this.bindingReference = this.textexReference.DataBindings.Add("Text", this.deliveryAdviceViewModel, "Reference", true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingEntryDate = this.dateTimexEntryDate.DataBindings.Add("Value", this.deliveryAdviceViewModel, "EntryDate", true);


            this.bindingReference.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingEntryDate.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);






            this.naviGroupDetails.DataBindings.Add("ExpandedHeight", this.numericUpDownSizingDetail, "Value", true, DataSourceUpdateMode.OnPropertyChanged);
            this.numericUpDownSizingDetail.Minimum = this.naviGroupDetails.HeaderHeight * 2;
            this.numericUpDownSizingDetail.Maximum = this.naviGroupDetails.Height + this.fastDeliveryAdviceIndex.Height;

            this.tableLayoutPanelMaster.ColumnStyles[this.tableLayoutPanelMaster.ColumnCount - 1].SizeType = SizeType.Absolute; this.tableLayoutPanelMaster.ColumnStyles[this.tableLayoutPanelMaster.ColumnCount - 1].Width = 10;
            this.tableLayoutPanelExtend.ColumnStyles[this.tableLayoutPanelExtend.ColumnCount - 1].SizeType = SizeType.Absolute; this.tableLayoutPanelExtend.ColumnStyles[this.tableLayoutPanelExtend.ColumnCount - 1].Width = 10;
        }

        protected override void InitializeDataGridBinding()
        {
            this.gridexViewDetails.AutoGenerateColumns = false;
            this.gridexViewDetails.DataSource = this.deliveryAdviceViewModel.ViewDetails;

            //StackedHeaderDecorator stackedHeaderDecorator = new StackedHeaderDecorator(this.dataGridViewDetails);
        }

        protected override Controllers.BaseController myController
        {
            get { return new DeliveryAdviceController(CommonNinject.Kernel.Get<IDeliveryAdviceService>(), this.deliveryAdviceViewModel); }
        }

        public override void Loading()
        {
            this.fastDeliveryAdviceIndex.SetObjects(this.deliveryAdviceAPIs.GetDeliveryAdviceIndexes());
            base.Loading();
        }

        protected override DialogResult wizardMaster()
        {
            WizardMaster wizardMaster = new WizardMaster(this.deliveryAdviceAPIs, this.deliveryAdviceViewModel);
            return wizardMaster.ShowDialog();
        }

        protected override void wizardDetail()
        {
            base.wizardDetail();
            WizardDetail wizardDetail = new WizardDetail(this.deliveryAdviceAPIs, this.deliveryAdviceViewModel);
            wizardDetail.ShowDialog();
        }



    }
}

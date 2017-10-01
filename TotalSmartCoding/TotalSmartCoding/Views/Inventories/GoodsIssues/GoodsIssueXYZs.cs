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
using TotalBase;
using TotalDTO.Inventories;
using TotalModel.Models;

namespace TotalSmartCoding.Views.Inventories.GoodsIssues
{
    public partial class GoodsIssueXYZs : BaseView
    {
        private GoodsIssueAPIs goodsIssueAPIs;
        private GoodsIssueViewModel goodsIssueViewModel { get; set; }

        public GoodsIssueXYZs()
            : base()
        {
            InitializeComponent();


            this.toolstripChild = this.toolStripChildForm;
            this.fastListIndex = this.fastGoodsIssueIndex;

            this.goodsIssueAPIs = new GoodsIssueAPIs(CommonNinject.Kernel.Get<IGoodsIssueAPIRepository>());

            this.goodsIssueViewModel = CommonNinject.Kernel.Get<GoodsIssueViewModel>();
            this.goodsIssueViewModel.PropertyChanged += new PropertyChangedEventHandler(ModelDTO_PropertyChanged);
            this.baseDTO = this.goodsIssueViewModel;
        }

        Binding bindingEntryDate;
        Binding bindingReference;

        protected override void InitializeCommonControlBinding()
        {
            base.InitializeCommonControlBinding();

            this.bindingReference = this.textexReference.DataBindings.Add("Text", this.goodsIssueViewModel, "Reference", true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingEntryDate = this.dateTimexEntryDate.DataBindings.Add("Value", this.goodsIssueViewModel, "EntryDate", true);


            this.bindingReference.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingEntryDate.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

            this.goodsIssueViewModel.PropertyChanged += goodsIssueViewModel_PropertyChanged;

            this.tableLayoutMaster.ColumnStyles[this.tableLayoutMaster.ColumnCount - 1].SizeType = SizeType.Absolute; this.tableLayoutMaster.ColumnStyles[this.tableLayoutMaster.ColumnCount - 1].Width = 10;
        }

        private void goodsIssueViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName != null && (e.PropertyName == CommonExpressions.PropertyName<GoodsIssueDTO>(p => p.GoodsIssueID) || e.PropertyName == CommonExpressions.PropertyName<GoodsIssueDTO>(p => p.DeliveryAdviceID) || e.PropertyName == CommonExpressions.PropertyName<GoodsIssueDTO>(p => p.CustomerID))) //this.EditableMode && 
                this.getPendingItems();
        }

        protected override void InitializeDataGridBinding()
        {
            this.gridexViewDetails.AutoGenerateColumns = false;
            this.gridexViewDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.gridexViewDetails.DataSource = this.goodsIssueViewModel.ViewDetails;
            this.dataGridexView1.DataSource = this.goodsIssueViewModel.PalletDetails;

            //StackedHeaderDecorator stackedHeaderDecorator = new StackedHeaderDecorator(this.dataGridViewDetails);
        }

        protected override Controllers.BaseController myController
        {
            get { return new GoodsIssueController(CommonNinject.Kernel.Get<IGoodsIssueService>(), this.goodsIssueViewModel); }
        }

        public override void Loading()
        {
            this.fastGoodsIssueIndex.SetObjects(this.goodsIssueAPIs.GetGoodsIssueIndexes());
            base.Loading();
        }

        private void getPendingItems() //THIS MAY ALSO LOAD PENDING PALLET/ CARTON/ PACK
        {
            try
            {
                this.fastPendingDeliveryAdviceDetails.SetObjects(this.goodsIssueAPIs.GetPendingDeliveryAdviceDetails(this.goodsIssueViewModel.LocationID, this.goodsIssueViewModel.GoodsIssueID, this.goodsIssueViewModel.DeliveryAdviceID, this.goodsIssueViewModel.CustomerID, string.Join(",", this.goodsIssueViewModel.ViewDetails.Select(d => d.DeliveryAdviceDetailID)), false));
                this.naviPendingDeliveryAdviceDetails.Text = "Pending " + this.fastPendingDeliveryAdviceDetails.GetItemCount().ToString("N0") + " item" + (this.fastPendingDeliveryAdviceDetails.GetItemCount() > 1 ? "s      " : "      ");
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        protected override DialogResult wizardMaster()
        {
            WizardMaster wizardMaster = new WizardMaster(this.goodsIssueAPIs, this.goodsIssueViewModel);
            return wizardMaster.ShowDialog();
        }

        //protected override void wizardDetail()
        //{
        //    base.wizardDetail();
        //    WizardDetail wizardDetail = new WizardDetail(this.goodsIssueAPIs, this.goodsIssueViewModel);
        //    wizardDetail.ShowDialog();
        //}

        private void fastPendingDeliveryAdviceDetails_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.EditableMode && this.goodsIssueViewModel.Editable)
                {
                    PendingDeliveryAdviceDetail pendingDeliveryAdviceDetail = (PendingDeliveryAdviceDetail)this.fastPendingDeliveryAdviceDetails.SelectedObject;
                    if (pendingDeliveryAdviceDetail != null)
                    {
                        WizardDetail wizardDetail = new WizardDetail(this.goodsIssueViewModel, pendingDeliveryAdviceDetail);
                        if (wizardDetail.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            getPendingItems();
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }



    }
}

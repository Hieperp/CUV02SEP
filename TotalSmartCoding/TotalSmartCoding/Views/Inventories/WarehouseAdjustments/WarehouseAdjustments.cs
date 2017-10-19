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
using TotalSmartCoding.Properties;
using TotalSmartCoding.Libraries;
using TotalSmartCoding.Libraries.Helpers;

using TotalSmartCoding.Controllers.Inventories;
using TotalCore.Repositories.Inventories;
using TotalSmartCoding.Controllers.APIs.Inventories;
using TotalCore.Services.Inventories;
using TotalSmartCoding.ViewModels.Inventories;
using TotalSmartCoding.Controllers.APIs.Commons;
using TotalCore.Repositories.Commons;
using TotalBase;
using TotalModel.Models;
using TotalDTO.Inventories;
using BrightIdeasSoftware;
using TotalSmartCoding.Libraries.StackedHeaders;


namespace TotalSmartCoding.Views.Inventories.WarehouseAdjustments
{
    public partial class WarehouseAdjustments : BaseView
    {
        private CustomTabControl customTabLeft;
        private CustomTabControl customTabCenter;
        //private CustomTabControl customTabCenter;
        //private CustomTabControl customTabCenter;

        private WarehouseAdjustmentAPIs warehouseAdjustmentAPIs;
        private WarehouseAdjustmentViewModel warehouseAdjustmentViewModel { get; set; }

        public WarehouseAdjustments()
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

        protected override void InitializeTabControl()
        {
            try
            {
                base.InitializeTabControl();

                #region TabLeft
                this.customTabLeft = new CustomTabControl();
                this.customTabLeft.DisplayStyle = TabStyle.VisualStudio;

                this.customTabLeft.TabPages.Add("tabLeftAA", "Warehouse Adjustment ");
                this.customTabLeft.TabPages[0].BackColor = this.panelLeft.BackColor;
                this.customTabLeft.TabPages[0].Padding = new Padding(15, 0, 0, 0);
                this.customTabLeft.TabPages[0].Controls.Add(this.layoutLeft);

                this.customTabLeft.Dock = DockStyle.Fill;
                this.panelLeft.Controls.Add(this.customTabLeft);

                this.layoutLeft.ColumnStyles[this.layoutLeft.ColumnCount - 1].SizeType = SizeType.Absolute; this.layoutLeft.ColumnStyles[this.layoutLeft.ColumnCount - 1].Width = 15;
                #endregion TabLeft

                #region TabCenter
                this.customTabCenter = new CustomTabControl();
                this.customTabCenter.DisplayStyle = TabStyle.VisualStudio;

                this.customTabCenter.TabPages.Add("tabCenterAA", "Pallets                  ");
                this.customTabCenter.TabPages.Add("tabCenterBB", "Cartons                  ");
                this.customTabCenter.TabPages.Add("tabCenterBB", "Description            ");
                this.customTabCenter.TabPages.Add("tabCenterBB", "Remarks                    ");

                this.customTabCenter.TabPages[0].Controls.Add(this.gridexPalletDetails);
                this.customTabCenter.TabPages[0].Controls.Add(this.toolStripPallet);
                this.customTabCenter.TabPages[1].Controls.Add(this.gridexCartonDetails);
                this.customTabCenter.TabPages[1].Controls.Add(this.toolStripCarton);
                this.customTabCenter.TabPages[2].Controls.Add(this.textexDescription);
                this.customTabCenter.TabPages[3].Controls.Add(this.textexRemarks);
                this.customTabCenter.TabPages[2].Padding = new Padding(30, 30, 30, 30);
                this.customTabCenter.TabPages[3].Padding = new Padding(30, 30, 30, 30);
                this.customTabCenter.TabPages[0].BackColor = this.panelCenter.BackColor;
                this.customTabCenter.TabPages[1].BackColor = this.panelCenter.BackColor;
                this.toolStripPallet.Dock = DockStyle.Left;
                this.gridexPalletDetails.Dock = DockStyle.Fill;
                this.toolStripCarton.Dock = DockStyle.Left;
                this.gridexCartonDetails.Dock = DockStyle.Fill;
                this.textexDescription.Dock = DockStyle.Fill;
                this.textexRemarks.Dock = DockStyle.Fill;

                this.customTabCenter.Dock = DockStyle.Fill;
                this.panelCenter.Controls.Add(this.customTabCenter);
                #endregion TabCenter

                this.tableLayoutPanelExtend.ColumnStyles[this.tableLayoutPanelExtend.ColumnCount - 1].SizeType = SizeType.Absolute; this.tableLayoutPanelExtend.ColumnStyles[this.tableLayoutPanelExtend.ColumnCount - 1].Width = 15;

                this.buttonExpandTop.Visible = this.naviGroupTop.Tag.ToString() == "Expandable";
                this.buttonExpandTop_Click(this.buttonExpandTop, new EventArgs());

            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        Binding bindingEntryDate;
        Binding bindingReference;
        Binding bindingWarehouseName;
        Binding bindingDescription;
        Binding bindingRemarks;
        Binding bindingCaption;

        Binding bindingStorekeeperID;

        protected override void InitializeCommonControlBinding()
        {
            base.InitializeCommonControlBinding();

            this.bindingEntryDate = this.dateTimexEntryDate.DataBindings.Add("Value", this.warehouseAdjustmentViewModel, CommonExpressions.PropertyName<WarehouseAdjustmentDTO>(p => p.EntryDate), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingReference = this.textexReference.DataBindings.Add("Text", this.warehouseAdjustmentViewModel, CommonExpressions.PropertyName<WarehouseAdjustmentDTO>(p => p.Reference), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingWarehouseName = this.textexWarehouseName.DataBindings.Add("Text", this.warehouseAdjustmentViewModel, CommonExpressions.PropertyName<WarehouseAdjustmentDTO>(p => p.WarehouseName), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingDescription = this.textexDescription.DataBindings.Add("Text", this.warehouseAdjustmentViewModel, CommonExpressions.PropertyName<WarehouseAdjustmentDTO>(p => p.Description), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingRemarks = this.textexRemarks.DataBindings.Add("Text", this.warehouseAdjustmentViewModel, CommonExpressions.PropertyName<WarehouseAdjustmentDTO>(p => p.Remarks), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingCaption = this.labelCaption.DataBindings.Add("Text", this.warehouseAdjustmentViewModel, CommonExpressions.PropertyName<WarehouseAdjustmentDTO>(p => p.Caption));

            EmployeeAPIs employeeAPIs = new EmployeeAPIs(CommonNinject.Kernel.Get<IEmployeeAPIRepository>());

            this.combexStorekeeperID.DataSource = employeeAPIs.GetEmployeeBases();
            this.combexStorekeeperID.DisplayMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.Name);
            this.combexStorekeeperID.ValueMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.EmployeeID);
            this.bindingStorekeeperID = this.combexStorekeeperID.DataBindings.Add("SelectedValue", this.warehouseAdjustmentViewModel, CommonExpressions.PropertyName<WarehouseAdjustmentViewModel>(p => p.StorekeeperID), true, DataSourceUpdateMode.OnPropertyChanged);

            this.bindingEntryDate.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingReference.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingWarehouseName.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingDescription.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingRemarks.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingCaption.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

            this.bindingStorekeeperID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.fastWarehouseAdjustmentIndex.AboutToCreateGroups += fastWarehouseAdjustmentIndex_AboutToCreateGroups;

            this.fastWarehouseAdjustmentIndex.ShowGroups = true;
            this.olvApproved.Renderer = new MappedImageRenderer(new Object[] { false, Resources.Placeholder16 });
            this.naviGroupDetails.ExpandedHeight = this.naviGroupDetails.Size.Height;
        }

        private void fastWarehouseAdjustmentIndex_AboutToCreateGroups(object sender, CreateGroupsEventArgs e)
        {
            if (e.Groups != null && e.Groups.Count > 0)
            {
                foreach (OLVGroup olvGroup in e.Groups)
                {
                    olvGroup.TitleImage = "Storage32";
                    olvGroup.Subtitle = "List count: " + olvGroup.Contents.Count.ToString();
                }
            }
        }

        protected override void InitializeDataGridBinding()
        {
            this.gridexPalletDetails.AutoGenerateColumns = false;
            this.gridexCartonDetails.AutoGenerateColumns = false;
            this.gridexPalletDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.gridexCartonDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.gridexPalletDetails.DataSource = this.warehouseAdjustmentViewModel.PalletDetails;
            this.gridexCartonDetails.DataSource = this.warehouseAdjustmentViewModel.CartonDetails;

            this.warehouseAdjustmentViewModel.ViewDetails.ListChanged += ViewDetails_ListChanged;

            StackedHeaderDecorator stackedHeaderDecoratorPallet = new StackedHeaderDecorator(this.gridexPalletDetails);
            StackedHeaderDecorator stackedHeaderDecoratorCarton = new StackedHeaderDecorator(this.gridexCartonDetails);
        }

        private void ViewDetails_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.Reset)
            {
                this.customTabCenter.TabPages[0].Text = "Pallets [" + this.warehouseAdjustmentViewModel.PalletDetails.Count.ToString("N0") + " item(s)]             ";
                this.customTabCenter.TabPages[1].Text = "Cartons [" + this.warehouseAdjustmentViewModel.CartonDetails.Count.ToString("N0") + " item(s)]             ";

                //this.gridexPalletDetails.Columns["Pallet" + CommonExpressions.PropertyName<WarehouseAdjustmentDetailDTO>(p => p.PickupReference)].Visible = this.warehouseAdjustmentViewModel.PickupID == null;
                //this.gridexPalletDetails.Columns["Pallet" + CommonExpressions.PropertyName<WarehouseAdjustmentDetailDTO>(p => p.PickupEntryDate)].Visible = this.warehouseAdjustmentViewModel.PickupID == null;

                //this.gridexCartonDetails.Columns["Carton" + CommonExpressions.PropertyName<WarehouseAdjustmentDetailDTO>(p => p.PickupReference)].Visible = this.warehouseAdjustmentViewModel.PickupID == null;
                //this.gridexCartonDetails.Columns["Carton" + CommonExpressions.PropertyName<WarehouseAdjustmentDetailDTO>(p => p.PickupEntryDate)].Visible = this.warehouseAdjustmentViewModel.PickupID == null;
            }
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

        protected override void DoAfterLoad()
        {
            base.DoAfterLoad();
            this.fastWarehouseAdjustmentIndex.Sort(this.olvEntryDate, SortOrder.Descending);
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

        private void buttonAddDetails_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.EditableMode)
                    this.wizardDetail();
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void naviGroupDetails_HeaderMouseClick(object sender, MouseEventArgs e)
        {
            this.toolStripNaviGroup.Visible = this.naviGroupDetails.Expanded;
        }

        private void buttonExpandTop_Click(object sender, EventArgs e)
        {            
            if (this.naviGroupTop.Tag.ToString() == "Expandable" || this.naviGroupTop.Expanded)
            {
                this.naviGroupTop.Expanded = !this.naviGroupTop.Expanded;
                this.naviGroupTop.Padding = new Padding(0, 0, 0, 0);
                this.buttonExpandTop.Image = this.naviGroupTop.Expanded ? Resources.chevron : Resources.chevron_expand;
            }
        }
    }
}

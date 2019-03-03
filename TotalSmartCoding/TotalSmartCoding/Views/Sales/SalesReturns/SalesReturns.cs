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
using BrightIdeasSoftware;
using TotalSmartCoding.Libraries.StackedHeaders;


namespace TotalSmartCoding.Views.Sales.SalesReturns
{
    public partial class SalesReturns : BaseView
    {
        private CustomTabControl customTabLeft;
        private CustomTabControl customTabCenter;

        private CustomerAPIs customerAPIs;
        private SalesReturnAPIs salesReturnAPIs;
        private SalesReturnViewModel salesReturnViewModel { get; set; }

        public SalesReturns()
            : base()
        {
            InitializeComponent();


            this.toolstripChild = this.toolStripChildForm;
            this.fastListIndex = this.fastSalesReturnIndex;

            this.salesReturnAPIs = new SalesReturnAPIs(CommonNinject.Kernel.Get<ISalesReturnAPIRepository>());

            this.salesReturnViewModel = CommonNinject.Kernel.Get<SalesReturnViewModel>();
            this.salesReturnViewModel.PropertyChanged += new PropertyChangedEventHandler(ModelDTO_PropertyChanged);
            this.baseDTO = this.salesReturnViewModel;
        }

        protected override void InitializeTabControl()
        {
            try
            {
                base.InitializeTabControl();

                #region TabLeft
                this.customTabLeft = new CustomTabControl();
                this.customTabLeft.DisplayStyle = TabStyle.VisualStudio;

                this.customTabLeft.TabPages.Add("tabLeftAA", "Sales Order  ");
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

                this.customTabCenter.TabPages.Add("tabCenterAA", "Order Lines            ");
                this.customTabCenter.TabPages.Add("tabCenterBB", "Description            ");
                this.customTabCenter.TabPages.Add("tabCenterBB", "Remarks                    ");

                this.customTabCenter.TabPages[0].Controls.Add(this.gridexViewDetails);
                this.customTabCenter.TabPages[1].Controls.Add(this.textexDescription);
                this.customTabCenter.TabPages[2].Controls.Add(this.textexRemarks);
                this.customTabCenter.TabPages[1].Padding = new Padding(30, 30, 30, 30);
                this.customTabCenter.TabPages[2].Padding = new Padding(30, 30, 30, 30);
                this.customTabCenter.TabPages[0].BackColor = this.panelCenter.BackColor;
                this.gridexViewDetails.Dock = DockStyle.Fill;
                this.textexDescription.Dock = DockStyle.Fill;
                this.textexRemarks.Dock = DockStyle.Fill;

                this.customTabCenter.Dock = DockStyle.Fill;
                this.panelCenter.Controls.Add(this.customTabCenter);
                #endregion TabCenter

                this.layoutTop.ColumnStyles[this.layoutTop.ColumnCount - 1].SizeType = SizeType.Absolute; this.layoutTop.ColumnStyles[this.layoutTop.ColumnCount - 1].Width = 15;

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
        Binding bindingVoucherCode;
        Binding bindingDeliveryDate;
        Binding bindingDescription;
        Binding bindingRemarks;
        Binding bindingCaption;

        Binding bindingCustomerID;
        Binding bindingReceiverID;
        Binding bindingSalespersonID;

        protected override void InitializeCommonControlBinding()
        {
            base.InitializeCommonControlBinding();

            this.bindingEntryDate = this.dateTimexEntryDate.DataBindings.Add("Value", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnDTO>(p => p.EntryDate), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingReference = this.textexReference.DataBindings.Add("Text", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnDTO>(p => p.Reference), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingVoucherCode = this.textexVoucherCode.DataBindings.Add("Text", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnDTO>(p => p.VoucherCode), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingDeliveryDate = this.dateTimexVoucherDate.DataBindings.Add("Value", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnDTO>(p => p.VoucherDate), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingDescription = this.textexDescription.DataBindings.Add("Text", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnDTO>(p => p.Description), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingRemarks = this.textexRemarks.DataBindings.Add("Text", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnDTO>(p => p.Remarks), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingCaption = this.labelCaption.DataBindings.Add("Text", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnDTO>(p => p.Caption));

            this.customerAPIs = new CustomerAPIs(CommonNinject.Kernel.Get<ICustomerAPIRepository>());
            this.combexCustomerID.DataSource = this.customerAPIs.GetCustomerBases();
            this.combexCustomerID.DisplayMember = CommonExpressions.PropertyName<CustomerBase>(p => p.Name);
            this.combexCustomerID.ValueMember = CommonExpressions.PropertyName<CustomerBase>(p => p.CustomerID);
            this.bindingCustomerID = this.combexCustomerID.DataBindings.Add("SelectedValue", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnViewModel>(p => p.CustomerID), true, DataSourceUpdateMode.OnPropertyChanged);

            CustomerAPIs receiverAPIs = new CustomerAPIs(CommonNinject.Kernel.Get<ICustomerAPIRepository>());
            this.combexReceiverID.DataSource = receiverAPIs.GetCustomerBases();
            this.combexReceiverID.DisplayMember = CommonExpressions.PropertyName<CustomerBase>(p => p.Name);
            this.combexReceiverID.ValueMember = CommonExpressions.PropertyName<CustomerBase>(p => p.CustomerID);
            this.bindingReceiverID = this.combexReceiverID.DataBindings.Add("SelectedValue", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnViewModel>(p => p.ReceiverID), true, DataSourceUpdateMode.OnPropertyChanged);

            EmployeeAPIs employeeAPIs = new EmployeeAPIs(CommonNinject.Kernel.Get<IEmployeeAPIRepository>());

            this.combexSalespersonID.DataSource = employeeAPIs.GetEmployeeBases(ContextAttributes.User.UserID, (int)this.salesReturnViewModel.NMVNTaskID, (int)GlobalEnums.RoleID.Saleperson);
            this.combexSalespersonID.DisplayMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.Name);
            this.combexSalespersonID.ValueMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.EmployeeID);
            this.bindingSalespersonID = this.combexSalespersonID.DataBindings.Add("SelectedValue", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnViewModel>(p => p.SalespersonID), true, DataSourceUpdateMode.OnPropertyChanged);

            this.bindingEntryDate.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingReference.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingVoucherCode.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingDeliveryDate.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingDescription.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingRemarks.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingCaption.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

            this.bindingCustomerID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingReceiverID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingSalespersonID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.fastSalesReturnIndex.AboutToCreateGroups += fastSalesReturnIndex_AboutToCreateGroups;

            this.fastSalesReturnIndex.ShowGroups = true;
            this.olvApproved.Renderer = new MappedImageRenderer(new Object[] { 1, Resources.Placeholder16, 2, Resources.Void_16 });
            this.naviGroupDetails.ExpandedHeight = this.naviGroupDetails.Size.Height;
        }

        protected override void CommonControl_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            base.CommonControl_BindingComplete(sender, e);
            if (this.EditableMode)
            {
                if (sender.Equals(this.bindingSalespersonID) && this.combexSalespersonID.SelectedItem != null)
                {
                    EmployeeBase customerBase = (EmployeeBase)this.combexSalespersonID.SelectedItem;
                    this.salesReturnViewModel.TeamID = customerBase.TeamID;
                }
                if (sender.Equals(this.bindingCustomerID) && this.combexCustomerID.SelectedItem != null)
                {
                    CustomerBase customerBase = (CustomerBase)this.combexCustomerID.SelectedItem;
                    this.salesReturnViewModel.CustomerName = customerBase.Name;
                }
                if (sender.Equals(this.bindingReceiverID) && this.combexReceiverID.SelectedItem != null)
                {
                    CustomerBase receiverBase = (CustomerBase)this.combexReceiverID.SelectedItem;
                    this.salesReturnViewModel.ReceiverName = receiverBase.Name;
                }
            }
        }

        private void fastSalesReturnIndex_AboutToCreateGroups(object sender, CreateGroupsEventArgs e)
        {
            if (e.Groups != null && e.Groups.Count > 0)
            {
                foreach (OLVGroup olvGroup in e.Groups)
                {
                    olvGroup.TitleImage = "Sign_Order_32";
                    olvGroup.Subtitle = "Count: " + olvGroup.Contents.Count.ToString() + " Order(s)";
                }
            }
        }

        private BindingSource bindingSourceViewDetails = new BindingSource();

        protected override void InitializeDataGridBinding()
        {
            base.InitializeDataGridBinding();
            this.InitializeDataGridReadonlyColumns(this.gridexViewDetails);

            this.gridexViewDetails.AutoGenerateColumns = false;
            this.gridexViewDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.bindingSourceViewDetails.DataSource = this.salesReturnViewModel.ViewDetails;
            this.gridexViewDetails.DataSource = this.bindingSourceViewDetails;

            this.bindingSourceViewDetails.AddingNew += bindingSourceViewDetails_AddingNew;
            this.salesReturnViewModel.ViewDetails.ListChanged += ViewDetails_ListChanged;
            this.gridexViewDetails.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dataGridViewDetails_EditingControlShowing);
            this.gridexViewDetails.ReadOnlyChanged += new System.EventHandler(this.dataGrid_ReadOnlyChanged);

            DataGridViewComboBoxColumn comboBoxColumn;
            CommodityAPIs commodityAPIs = new CommodityAPIs(CommonNinject.Kernel.Get<ICommodityAPIRepository>());

            comboBoxColumn = (DataGridViewComboBoxColumn)this.gridexViewDetails.Columns[CommonExpressions.PropertyName<SalesReturnDetailDTO>(p => p.CommodityID)];
            comboBoxColumn.DataSource = commodityAPIs.GetCommodityBases(true);
            comboBoxColumn.DisplayMember = CommonExpressions.PropertyName<CommodityBase>(p => p.Code);
            comboBoxColumn.ValueMember = CommonExpressions.PropertyName<CommodityBase>(p => p.CommodityID);

            StackedHeaderDecorator stackedHeaderDecorator = new StackedHeaderDecorator(this.gridexViewDetails);
        }

        private void bindingSourceViewDetails_AddingNew(object sender, AddingNewEventArgs e)
        {   //ONLY WHEN USING COMBOBOX TO ADD NEW ROW TO datagridview => WE SHOULD USE BindingSource => THEN WE HANDLE AN EVENT HANDLER FOR AddingNew EVENT
            //In this form, the datagridview using a combobox for add new item => add new row to the datagridview
            //If user cancel the combobox => the datagridview will not cancel new adding row (event no new row added???)
            //This will raise error when user move the cursor to the new row (means: the datagridview will add new row again!!!)
            //I find an workarround to handle this error from this https://stackoverflow.com/questions/2359124/datagridview-throwing-invalidoperationexception-operation-is-not-valid-whe
            //The following code: will remove current pending new row => in order add another new row again
            if (this.gridexViewDetails.Rows.Count == this.bindingSourceViewDetails.Count)
                this.bindingSourceViewDetails.RemoveAt(this.bindingSourceViewDetails.Count - 1);
            //-----------The following is explanation from internet (the link above): The reason it works is because on a DataGridView where AllowUserToAddRows is true, it adds an empty row at the end of its rows which if bound to a list creates a null element at the end of your list. Your code removes that element and then the AddNew in the BindingList will trigger the DataGridView to add it again. 
            //This code bypass the error, BUT NOT SOLVE THE PROBLEM COMPLETELY. SO: WE SHOULD ADVICE USER NOT CANCEL THE COMBOBOX => INSTEAD: CANCEL THE ROW AFTER SELECT THE COMBOBOX
        }

        private void ViewDetails_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.Reset)
                this.customTabCenter.TabPages[0].Text = "Order Lines [" + this.salesReturnViewModel.ViewDetails.Count.ToString("N0") + " item(s)]             ";

            if (this.EditableMode && e.PropertyDescriptor != null && e.NewIndex >= 0 && e.NewIndex < this.salesReturnViewModel.ViewDetails.Count)
            {
                SalesReturnDetailDTO salesReturnDetailDTO = this.salesReturnViewModel.ViewDetails[e.NewIndex];
                if (salesReturnDetailDTO != null)
                    this.CalculateQuantityDetailDTO(salesReturnDetailDTO, e.PropertyDescriptor.Name, null, null);
            }
        }

        protected override Controllers.BaseController myController
        {
            get { return new SalesReturnController(CommonNinject.Kernel.Get<ISalesReturnService>(), this.salesReturnViewModel); }
        }

        public override void Loading()
        {
            this.fastSalesReturnIndex.SetObjects(this.salesReturnAPIs.GetSalesReturnIndexes());

            base.Loading();
        }

        protected override void DoAfterLoad()
        {
            base.DoAfterLoad();
            this.fastSalesReturnIndex.Sort(this.olvEntryDate, SortOrder.Descending);
        }

        protected override DialogResult wizardMaster()
        {
            DialogResult dialogResult;
            WizardMaster wizardMaster = new WizardMaster(this.salesReturnViewModel);

            do
            {
                dialogResult = wizardMaster.ShowDialog();
                if (dialogResult != DialogResult.OK || this.customerAPIs.CheckCustomerReceiverID(this.salesReturnViewModel.CustomerID, this.salesReturnViewModel.ReceiverID) > 0)
                    break;
                else
                    CustomMsgBox.Show(this, "Vui lòng chọn đúng receiver.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            } while (true);

            wizardMaster.Dispose();
            return dialogResult;
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

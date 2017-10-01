using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;

using Ninject;

using TotalBase;
using TotalModel.Models;
using TotalCore.Repositories.Commons;
using TotalSmartCoding.Controllers.APIs.Commons;
using TotalSmartCoding.Controllers.APIs.Sales;
using TotalSmartCoding.Libraries;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.ViewModels.Sales;


namespace TotalSmartCoding.Views.Sales.SalesOrders
{
    public partial class WizardMaster : Form
    {
        private SalesOrderViewModel salesOrderViewModel;

        Binding bindingCustomerID;
        Binding bindingStorekeeperID;

        Binding bindingVoucherCode;
        Binding bindingDeliveryDate;
        Binding bindingContactInfo;
        Binding bindingShippingAddress;
        Binding bindingRemarks;

        public WizardMaster(SalesOrderViewModel salesOrderViewModel)
        {
            InitializeComponent();

            this.salesOrderViewModel = salesOrderViewModel;
        }

        private void WizardMaster_Load(object sender, EventArgs e)
        {
            try
            {
                this.salesOrderViewModel.PropertyChanged += salesOrderDetailDTO_PropertyChanged;

                CustomerAPIs customerAPIs = new CustomerAPIs(CommonNinject.Kernel.Get<ICustomerAPIRepository>());

                this.combexCustomerID.DataSource = customerAPIs.GetCustomerBases();
                this.combexCustomerID.DisplayMember = CommonExpressions.PropertyName<CustomerBase>(p => p.Name);
                this.combexCustomerID.ValueMember = CommonExpressions.PropertyName<CustomerBase>(p => p.CustomerID);
                this.bindingCustomerID = this.combexCustomerID.DataBindings.Add("SelectedValue", this.salesOrderViewModel, CommonExpressions.PropertyName<SalesOrderViewModel>(p => p.CustomerID), true, DataSourceUpdateMode.OnPropertyChanged);

                EmployeeAPIs employeeAPIs = new EmployeeAPIs(CommonNinject.Kernel.Get<IEmployeeAPIRepository>());

                this.combexSalespersonID.DataSource = employeeAPIs.GetEmployeeBases();
                this.combexSalespersonID.DisplayMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.Name);
                this.combexSalespersonID.ValueMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.EmployeeID);
                this.bindingStorekeeperID = this.combexSalespersonID.DataBindings.Add("SelectedValue", this.salesOrderViewModel, CommonExpressions.PropertyName<SalesOrderViewModel>(p => p.SalespersonID), true, DataSourceUpdateMode.OnPropertyChanged);

                this.bindingVoucherCode = this.textexVoucherCode.DataBindings.Add("Text", this.salesOrderViewModel, CommonExpressions.PropertyName<SalesOrderViewModel>(p => p.VoucherCode), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingDeliveryDate = this.dateTimexDeliveryDate.DataBindings.Add("Value", this.salesOrderViewModel, CommonExpressions.PropertyName<SalesOrderViewModel>(p => p.DeliveryDate), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingContactInfo = this.textexContactInfo.DataBindings.Add("Text", this.salesOrderViewModel, CommonExpressions.PropertyName<SalesOrderViewModel>(p => p.ContactInfo), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingShippingAddress = this.textexShippingAddress.DataBindings.Add("Text", this.salesOrderViewModel, CommonExpressions.PropertyName<SalesOrderViewModel>(p => p.ShippingAddress), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingRemarks = this.textexRemarks.DataBindings.Add("Text", this.salesOrderViewModel, CommonExpressions.PropertyName<SalesOrderViewModel>(p => p.Remarks), true, DataSourceUpdateMode.OnPropertyChanged);

                this.bindingCustomerID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingStorekeeperID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

                this.bindingVoucherCode.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingDeliveryDate.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingContactInfo.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingShippingAddress.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingRemarks.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

                this.errorProviderMaster.DataSource = this.salesOrderViewModel;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void salesOrderDetailDTO_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.buttonOK.Enabled = this.salesOrderViewModel.IsValid;
        }

        private void CommonControl_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState == BindingCompleteState.Exception) { ExceptionHandlers.ShowExceptionMessageBox(this, e.ErrorText); e.Cancel = true; }
            if (sender.Equals(this.bindingCustomerID))
            {
                if (this.combexCustomerID.SelectedItem != null)
                {
                    CustomerBase customerBase = (CustomerBase)this.combexCustomerID.SelectedItem;
                    this.salesOrderViewModel.CustomerName = customerBase.Name;
                    this.salesOrderViewModel.ContactInfo = customerBase.ContactInfo;
                    this.salesOrderViewModel.ShippingAddress = customerBase.ShippingAddress;
                    this.salesOrderViewModel.SalespersonID = customerBase.SalespersonID;
                }
            }
        }

        private void buttonOKESC_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(this.buttonOK))
                {
                    if (this.salesOrderViewModel.CustomerID != null && this.salesOrderViewModel.SalespersonID != null)
                    this.DialogResult = DialogResult.OK;
                    else
                        CustomMsgBox.Show(this, "Vui lòng chọn khách hàng, nhân viên kinh doanh.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                }

                if (sender.Equals(this.buttonESC))
                    this.DialogResult = DialogResult.Cancel;


            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }
    }
}

using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

using Ninject;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;
using TotalCore.Repositories.Commons;
using TotalSmartCoding.Controllers.APIs.Commons;
using TotalSmartCoding.Controllers.APIs.Sales;
using TotalSmartCoding.Libraries;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.ViewModels.Sales;
using TotalSmartCoding.Views.Commons.Customers;


namespace TotalSmartCoding.Views.Sales.SalesReturns
{
    public partial class WizardMaster : Form
    {
        private SalesReturnViewModel salesReturnViewModel;

        Binding bindingCustomerID;
        Binding bindingReceiverID;
        Binding bindingSalespersonID;

        Binding bindingVoucherCode;
        Binding bindingEntryDate;
        Binding bindingVoucherDate;
        Binding bindingCustomerName;
        Binding bindingReceiverName;
        Binding bindingReceiverTemp;
        Binding bindingRemarks;

        public WizardMaster(SalesReturnViewModel salesReturnViewModel)
        {
            InitializeComponent();

            try
            {
                this.salesReturnViewModel = salesReturnViewModel;


                this.salesReturnViewModel.PropertyChanged += salesReturnDetailDTO_PropertyChanged;

                CustomerAPIs customerAPIs = new CustomerAPIs(CommonNinject.Kernel.Get<ICustomerAPIRepository>());

                this.combexCustomerID.DataSource = customerAPIs.GetCustomerBases(true, false, null);
                this.combexCustomerID.DisplayMember = CommonExpressions.PropertyName<CustomerBase>(p => p.Code);
                this.combexCustomerID.ValueMember = CommonExpressions.PropertyName<CustomerBase>(p => p.CustomerID);
                this.bindingCustomerID = this.combexCustomerID.DataBindings.Add("SelectedValue", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnViewModel>(p => p.CustomerID), true, DataSourceUpdateMode.OnPropertyChanged);

                CustomerAPIs receiverAPIs = new CustomerAPIs(CommonNinject.Kernel.Get<ICustomerAPIRepository>());
                this.combexReceiverID.DataSource = receiverAPIs.GetCustomerBases(false, true, null);
                this.combexReceiverID.DisplayMember = CommonExpressions.PropertyName<CustomerBase>(p => p.Code);
                this.combexReceiverID.ValueMember = CommonExpressions.PropertyName<CustomerBase>(p => p.CustomerID);
                this.bindingReceiverID = this.combexReceiverID.DataBindings.Add("SelectedValue", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnViewModel>(p => p.ReceiverID), true, DataSourceUpdateMode.OnPropertyChanged);

                EmployeeAPIs employeeAPIs = new EmployeeAPIs(CommonNinject.Kernel.Get<IEmployeeAPIRepository>());

                this.combexSalespersonID.DataSource = employeeAPIs.GetEmployeeBases(ContextAttributes.User.UserID, (int)this.salesReturnViewModel.NMVNTaskID, (int)GlobalEnums.RoleID.Saleperson);
                this.combexSalespersonID.DisplayMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.Name);
                this.combexSalespersonID.ValueMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.EmployeeID);
                this.bindingSalespersonID = this.combexSalespersonID.DataBindings.Add("SelectedValue", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnViewModel>(p => p.SalespersonID), true, DataSourceUpdateMode.OnPropertyChanged);

                this.bindingVoucherCode = this.textexVoucherCode.DataBindings.Add("Text", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnViewModel>(p => p.VoucherCode), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingEntryDate = this.dateTimexEntryDate.DataBindings.Add("Value", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnViewModel>(p => p.EntryDate), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingVoucherDate = this.dateTimexVoucherDate.DataBindings.Add("Value", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnViewModel>(p => p.VoucherDate), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingCustomerName = this.textexCustomerName.DataBindings.Add("Text", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnViewModel>(p => p.CustomerName), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingReceiverName = this.textexReceiverName.DataBindings.Add("Text", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnViewModel>(p => p.ReceiverName), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingReceiverTemp = this.textexReceiverTemp.DataBindings.Add("Text", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnViewModel>(p => p.ReceiverTemp), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingRemarks = this.textexRemarks.DataBindings.Add("Text", this.salesReturnViewModel, CommonExpressions.PropertyName<SalesReturnViewModel>(p => p.Remarks), true, DataSourceUpdateMode.OnPropertyChanged);

                this.bindingCustomerID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingReceiverID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingSalespersonID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

                this.bindingVoucherCode.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingEntryDate.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingVoucherDate.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingCustomerName.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingReceiverName.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingReceiverTemp.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingRemarks.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

                this.errorProviderMaster.DataSource = this.salesReturnViewModel;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void salesReturnDetailDTO_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.buttonOK.Enabled = this.salesReturnViewModel.IsValid;
        }

        private void CommonControl_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState == BindingCompleteState.Exception) { ExceptionHandlers.ShowExceptionMessageBox(this, e.ErrorText); e.Cancel = true; }
            if (sender.Equals(this.bindingSalespersonID) && this.combexSalespersonID.SelectedItem != null)
            {
                EmployeeBase customerBase = (EmployeeBase)this.combexSalespersonID.SelectedItem;
                this.salesReturnViewModel.TeamID = customerBase.TeamID;
            }
            if (sender.Equals(this.bindingCustomerID) && this.combexCustomerID.SelectedItem != null)
            {
                CustomerBase customerBase = (CustomerBase)this.combexCustomerID.SelectedItem;
                this.salesReturnViewModel.CustomerName = customerBase.Name;
                this.salesReturnViewModel.SalespersonID = customerBase.SalespersonID;
                //this.salesReturnViewModel.ReceiverID = customerBase.CustomerID;
            }
            if (sender.Equals(this.bindingReceiverID) && this.combexReceiverID.SelectedItem != null)
            {
                CustomerBase customerBase = (CustomerBase)this.combexReceiverID.SelectedItem;
                this.salesReturnViewModel.ReceiverName = customerBase.Name;
            }
        }

        private void combexCustomerReceiverID_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.Enter) || e.KeyCode == Keys.Insert)
            {

                List<CustomerBase> customerBases;
                if (sender.Equals(this.combexCustomerID))
                    customerBases = this.combexCustomerID.DataSource as List<CustomerBase>;
                else
                {
                    CustomerAPIs receiverAPIs = new CustomerAPIs(CommonNinject.Kernel.Get<ICustomerAPIRepository>());
                    customerBases = receiverAPIs.GetCustomerBases(false, true, this.salesReturnViewModel.CustomerID) as List<CustomerBase>;
                }

                CustomerPopup wizardDetail = new CustomerPopup(customerBases);
                if (wizardDetail.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (sender.Equals(this.combexCustomerID))
                        this.salesReturnViewModel.CustomerID = wizardDetail.CustomerBase.CustomerID;
                    if (sender.Equals(this.combexReceiverID))
                        this.salesReturnViewModel.ReceiverID = wizardDetail.CustomerBase.CustomerID;
                }
                wizardDetail.Dispose();
            }
        }

        private DateTime? lastClick;
        private void combexCustomerReceiverID_MouseClick(object sender, MouseEventArgs e)
        {
            if (lastClick == null)
                lastClick = DateTime.Now;
            else
            {
                TimeSpan Current = DateTime.Now - (DateTime)lastClick; lastClick = DateTime.Now;
                TimeSpan DblClickSpan = TimeSpan.FromMilliseconds(SystemInformation.DoubleClickTime);

                if (Current.TotalMilliseconds <= DblClickSpan.TotalMilliseconds)
                    this.combexCustomerReceiverID_KeyDown(sender, new KeyEventArgs(Keys.Insert));
            }
        }

        private void textexReceiverTemp_TextChanged(object sender, EventArgs e)
        {
            try
            {
                this.salesReturnViewModel.ReceiverTemp = this.textexReceiverTemp.Text;
                this.combexReceiverID.Text = this.textexReceiverTemp.Text;
                //this.textexReceiverTemp.Text = this.combexReceiverID.Text;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void textexReceiverTemp_DoubleClick(object sender, EventArgs e)
        {
            this.combexCustomerReceiverID_KeyDown(this.combexReceiverID, new KeyEventArgs(Keys.Insert));
            this.textexReceiverTemp.Text = this.combexReceiverID.Text;
        }

        private void textexReceiverTemp_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Control && e.KeyCode == Keys.Enter) || e.KeyCode == Keys.Insert)
                this.textexReceiverTemp_DoubleClick(sender, new EventArgs());
        }

        private void buttonOKESC_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(this.buttonOK))
                {
                    if (this.salesReturnViewModel.CustomerID != null && this.salesReturnViewModel.ReceiverID != null && this.salesReturnViewModel.SalespersonID != null)
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

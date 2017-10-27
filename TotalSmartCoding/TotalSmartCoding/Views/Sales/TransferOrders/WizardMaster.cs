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


namespace TotalSmartCoding.Views.Sales.TransferOrders
{
    public partial class WizardMaster : Form
    {
        private TransferOrderViewModel transferOrderViewModel;

        Binding bindingWarehouseID;
        Binding bindingWarehouseReceiptID;
        Binding bindingStorekeeperID;

        Binding bindingVoucherCode;
        Binding bindingEntryDate;
        Binding bindingDeliveryDate;
        Binding bindingTransferJobs;
        Binding bindingRemarks;

        public WizardMaster(TransferOrderViewModel transferOrderViewModel)
        {
            InitializeComponent();

            this.transferOrderViewModel = transferOrderViewModel;
        }

        private void WizardMaster_Load(object sender, EventArgs e)
        {
            try
            {
                this.transferOrderViewModel.PropertyChanged += transferOrderDetailDTO_PropertyChanged;

                WarehouseAPIs warehouseAPIs = new WarehouseAPIs(CommonNinject.Kernel.Get<IWarehouseAPIRepository>());

                this.combexWarehouseID.DataSource = warehouseAPIs.GetWarehouseBases();
                this.combexWarehouseID.DisplayMember = CommonExpressions.PropertyName<WarehouseBase>(p => p.Name);
                this.combexWarehouseID.ValueMember = CommonExpressions.PropertyName<WarehouseBase>(p => p.WarehouseID);
                this.bindingWarehouseID = this.combexWarehouseID.DataBindings.Add("SelectedValue", this.transferOrderViewModel, CommonExpressions.PropertyName<TransferOrderViewModel>(p => p.WarehouseID), true, DataSourceUpdateMode.OnPropertyChanged);

                this.combexWarehouseReceiptID.DataSource = warehouseAPIs.GetWarehouseBases();
                this.combexWarehouseReceiptID.DisplayMember = CommonExpressions.PropertyName<WarehouseBase>(p => p.Name);
                this.combexWarehouseReceiptID.ValueMember = CommonExpressions.PropertyName<WarehouseBase>(p => p.WarehouseID);
                this.bindingWarehouseReceiptID = this.combexWarehouseReceiptID.DataBindings.Add("SelectedValue", this.transferOrderViewModel, CommonExpressions.PropertyName<TransferOrderViewModel>(p => p.WarehouseReceiptID), true, DataSourceUpdateMode.OnPropertyChanged);

                EmployeeAPIs employeeAPIs = new EmployeeAPIs(CommonNinject.Kernel.Get<IEmployeeAPIRepository>());

                this.combexSalespersonID.DataSource = employeeAPIs.GetEmployeeBases();
                this.combexSalespersonID.DisplayMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.Name);
                this.combexSalespersonID.ValueMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.EmployeeID);
                this.bindingStorekeeperID = this.combexSalespersonID.DataBindings.Add("SelectedValue", this.transferOrderViewModel, CommonExpressions.PropertyName<TransferOrderViewModel>(p => p.SalespersonID), true, DataSourceUpdateMode.OnPropertyChanged);

                this.bindingVoucherCode = this.textexVoucherCode.DataBindings.Add("Text", this.transferOrderViewModel, CommonExpressions.PropertyName<TransferOrderViewModel>(p => p.VoucherCode), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingEntryDate = this.dateTimexEntryDate.DataBindings.Add("Value", this.transferOrderViewModel, CommonExpressions.PropertyName<TransferOrderViewModel>(p => p.EntryDate), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingDeliveryDate = this.dateTimexDeliveryDate.DataBindings.Add("Value", this.transferOrderViewModel, CommonExpressions.PropertyName<TransferOrderViewModel>(p => p.DeliveryDate), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingTransferJobs = this.textexTransferJobs.DataBindings.Add("Text", this.transferOrderViewModel, CommonExpressions.PropertyName<TransferOrderViewModel>(p => p.TransferJobs), true, DataSourceUpdateMode.OnPropertyChanged);
                this.bindingRemarks = this.textexRemarks.DataBindings.Add("Text", this.transferOrderViewModel, CommonExpressions.PropertyName<TransferOrderViewModel>(p => p.Remarks), true, DataSourceUpdateMode.OnPropertyChanged);

                this.bindingWarehouseID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingWarehouseReceiptID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingStorekeeperID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

                this.bindingVoucherCode.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingEntryDate.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingDeliveryDate.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingTransferJobs.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
                this.bindingRemarks.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

                this.errorProviderMaster.DataSource = this.transferOrderViewModel;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void transferOrderDetailDTO_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.buttonOK.Enabled = this.transferOrderViewModel.IsValid;
        }

        private void CommonControl_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            if (e.BindingCompleteState == BindingCompleteState.Exception) { ExceptionHandlers.ShowExceptionMessageBox(this, e.ErrorText); e.Cancel = true; }
            if (sender.Equals(this.bindingWarehouseID))
            {
                if (this.combexWarehouseID.SelectedItem != null)
                {
                    WarehouseBase warehouseBase = (WarehouseBase)this.combexWarehouseID.SelectedItem;
                    this.transferOrderViewModel.WarehouseName = warehouseBase.Name;
                }
            }
            if (sender.Equals(this.bindingWarehouseReceiptID))
            {
                if (this.combexWarehouseReceiptID.SelectedItem != null)
                {
                    WarehouseBase warehouseBase = (WarehouseBase)this.combexWarehouseReceiptID.SelectedItem;
                    this.transferOrderViewModel.WarehouseReceiptName = warehouseBase.Name;
                }
            }
        }

        private void buttonOKESC_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(this.buttonOK))
                {
                    if (this.transferOrderViewModel.WarehouseID != null && this.transferOrderViewModel.WarehouseReceiptID != null && this.transferOrderViewModel.SalespersonID != null)
                    this.DialogResult = DialogResult.OK;
                    else
                        CustomMsgBox.Show(this, "Vui lòng chọn kho xuất, kho nhập, và nhân viên đề nghị chuyển kho.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
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

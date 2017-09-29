﻿using System;
using System.Drawing;
using System.Windows.Forms;

using TotalModel.Models;
using TotalSmartCoding.Controllers.APIs.Sales;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.ViewModels.Sales;

namespace TotalSmartCoding.Views.Sales.DeliveryAdvices
{
    public partial class WizardMaster : Form
    {
        private DeliveryAdviceAPIs deliveryAdviceAPIs;
        private DeliveryAdviceViewModel deliveryAdviceViewModel;
        private CustomTabControl customTabBatch;
        public WizardMaster(DeliveryAdviceAPIs deliveryAdviceAPIs, DeliveryAdviceViewModel deliveryAdviceViewModel)
        {
            InitializeComponent();

            this.customTabBatch = new CustomTabControl();
            //this.customTabBatch.ImageList = this.imageListTabControl;

            this.customTabBatch.Font = this.fastPendingSalesOrders.Font;
            this.customTabBatch.DisplayStyle = TabStyle.VisualStudio;
            this.customTabBatch.DisplayStyleProvider.ImageAlign = ContentAlignment.MiddleLeft;

            this.customTabBatch.TabPages.Add("tabPendingSalesOrders", "Advice by Sales Orders ");
            this.customTabBatch.TabPages.Add("tabPendingSalesOrderCustomers", "Advice by Customers    ");
            this.customTabBatch.TabPages.Add("tabNewDeliveryAdvice", "Advice without Sales Order ");
            this.customTabBatch.TabPages[0].Controls.Add(this.fastPendingSalesOrders);
            this.customTabBatch.TabPages[1].Controls.Add(this.fastPendingSalesOrderCustomers);


            this.customTabBatch.Dock = DockStyle.Fill;
            this.fastPendingSalesOrders.Dock = DockStyle.Fill;
            this.fastPendingSalesOrderCustomers.Dock = DockStyle.Fill;
            this.panelMaster.Controls.Add(this.customTabBatch);


            this.deliveryAdviceAPIs = deliveryAdviceAPIs;
            this.deliveryAdviceViewModel = deliveryAdviceViewModel;
        }


        private void Wizard_Load(object sender, EventArgs e)
        {
            try
            {
                this.fastPendingSalesOrders.SetObjects(this.deliveryAdviceAPIs.GetPendingSalesOrders(this.deliveryAdviceViewModel.LocationID));
                this.fastPendingSalesOrderCustomers.SetObjects(this.deliveryAdviceAPIs.GetPendingSalesOrderCustomers(this.deliveryAdviceViewModel.LocationID));

            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }


        private void buttonOKESC_Click(object sender, EventArgs e)
        {
            try
            {
                if (sender.Equals(this.buttonOK))
                {
                    this.deliveryAdviceViewModel.HasSalesOrder = true;

                    bool nextOK = false;
                    if (this.customTabBatch.SelectedIndex == 0)
                    {
                        PendingSalesOrder pendingSalesOrder = (PendingSalesOrder)this.fastPendingSalesOrders.SelectedObject;
                        if (pendingSalesOrder != null) {                            
                            this.deliveryAdviceViewModel.SalesOrderID = pendingSalesOrder.SalesOrderID;
                            this.deliveryAdviceViewModel.SalesOrderReferences = pendingSalesOrder.SalesOrderReference;
                            this.deliveryAdviceViewModel.VoucherCode = pendingSalesOrder.VoucherCode;

                            this.deliveryAdviceViewModel.CustomerID = pendingSalesOrder.CustomerID;
                            this.deliveryAdviceViewModel.CustomerName = pendingSalesOrder.CustomerName;
                            this.deliveryAdviceViewModel.ContactInfo = pendingSalesOrder.ContactInfo;
                            this.deliveryAdviceViewModel.ShippingAddress = pendingSalesOrder.ShippingAddress;
                            
                            this.deliveryAdviceViewModel.SalespersonID = pendingSalesOrder.SalespersonID;
                            nextOK = true;
                        }
                    }
                    if (this.customTabBatch.SelectedIndex == 1)
                    {
                        PendingSalesOrderCustomer pendingSalesOrderCustomer = (PendingSalesOrderCustomer)this.fastPendingSalesOrderCustomers.SelectedObject;
                        if (pendingSalesOrderCustomer != null)
                        {
                            this.deliveryAdviceViewModel.CustomerID = pendingSalesOrderCustomer.CustomerID;
                            this.deliveryAdviceViewModel.CustomerName = pendingSalesOrderCustomer.CustomerName;
                            this.deliveryAdviceViewModel.ContactInfo = pendingSalesOrderCustomer.ContactInfo;
                            this.deliveryAdviceViewModel.ShippingAddress = pendingSalesOrderCustomer.ShippingAddress;

                            this.deliveryAdviceViewModel.SalespersonID = pendingSalesOrderCustomer.SalespersonID;
                            nextOK = true;
                        }
                    }

                    if (nextOK)
                        this.DialogResult = DialogResult.OK;
                    else
                        CustomMsgBox.Show(this, "Vui lòng chọn phiếu giao thành phẩm sau đóng gói, hoặc kho nhận hàng.", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);                    
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

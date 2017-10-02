using System;
using System.Drawing;
using System.Windows.Forms;

using TotalModel.Models;
using TotalSmartCoding.Controllers.APIs.Inventories;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.ViewModels.Inventories;

namespace TotalSmartCoding.Views.Inventories.GoodsIssues
{
    public partial class WizardMaster : Form
    {
        private GoodsIssueAPIs goodsIssueAPIs;
        private GoodsIssueViewModel goodsIssueViewModel;
        private CustomTabControl customTabBatch;
        public WizardMaster(GoodsIssueAPIs goodsIssueAPIs, GoodsIssueViewModel goodsIssueViewModel)
        {
            InitializeComponent();

            this.customTabBatch = new CustomTabControl();
            //this.customTabBatch.ImageList = this.imageListTabControl;

            this.customTabBatch.Font = this.fastPendingDeliveryAdvices.Font;
            this.customTabBatch.DisplayStyle = TabStyle.VisualStudio;
            this.customTabBatch.DisplayStyleProvider.ImageAlign = ContentAlignment.MiddleLeft;

            this.customTabBatch.TabPages.Add("tabPendingDeliveryAdvices", "Issue by Delivery Advice        ");
            this.customTabBatch.TabPages.Add("tabPendingDeliveryAdviceCustomers", "Issue by Customer      ");
            this.customTabBatch.TabPages.Add("tabPendingDeliveryAdvices", "Transfer Issue              ");
            this.customTabBatch.TabPages[0].Controls.Add(this.fastPendingDeliveryAdvices);
            this.customTabBatch.TabPages[1].Controls.Add(this.fastPendingDeliveryAdviceCustomers);


            this.customTabBatch.Dock = DockStyle.Fill;
            this.fastPendingDeliveryAdvices.Dock = DockStyle.Fill;
            this.fastPendingDeliveryAdviceCustomers.Dock = DockStyle.Fill;
            this.panelMaster.Controls.Add(this.customTabBatch);


            this.goodsIssueAPIs = goodsIssueAPIs;
            this.goodsIssueViewModel = goodsIssueViewModel;
        }


        private void Wizard_Load(object sender, EventArgs e)
        {
            try
            {
                this.fastPendingDeliveryAdvices.SetObjects(this.goodsIssueAPIs.GetPendingDeliveryAdvices(this.goodsIssueViewModel.LocationID));
                this.fastPendingDeliveryAdviceCustomers.SetObjects(this.goodsIssueAPIs.GetPendingDeliveryAdviceCustomers(this.goodsIssueViewModel.LocationID));

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
                    bool nextOK = false;
                    if (this.customTabBatch.SelectedIndex == 0)
                    {
                        PendingDeliveryAdvice pendingDeliveryAdvice = (PendingDeliveryAdvice)this.fastPendingDeliveryAdvices.SelectedObject;
                        if (pendingDeliveryAdvice != null) {                            
                            this.goodsIssueViewModel.DeliveryAdviceID = pendingDeliveryAdvice.DeliveryAdviceID;
                            this.goodsIssueViewModel.DeliveryAdviceReferences = pendingDeliveryAdvice.DeliveryAdviceReference;
                            this.goodsIssueViewModel.CustomerID = pendingDeliveryAdvice.CustomerID;
                            this.goodsIssueViewModel.CustomerName = pendingDeliveryAdvice.CustomerName;
                            nextOK = true;
                        }
                    }
                    if (this.customTabBatch.SelectedIndex == 1)
                    {
                        PendingDeliveryAdviceCustomer pendingDeliveryAdviceCustomer = (PendingDeliveryAdviceCustomer)this.fastPendingDeliveryAdviceCustomers.SelectedObject;
                        if (pendingDeliveryAdviceCustomer != null)
                        {
                            this.goodsIssueViewModel.CustomerID = pendingDeliveryAdviceCustomer.CustomerID;
                            this.goodsIssueViewModel.CustomerName = pendingDeliveryAdviceCustomer.CustomerName;
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

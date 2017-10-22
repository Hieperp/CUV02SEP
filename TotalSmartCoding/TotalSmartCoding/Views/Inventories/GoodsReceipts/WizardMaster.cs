using System;
using System.Drawing;
using System.Windows.Forms;
using TotalModel.Models;
using TotalSmartCoding.Controllers.APIs.Inventories;
using TotalSmartCoding.Libraries.Helpers;
using TotalSmartCoding.ViewModels.Inventories;

namespace TotalSmartCoding.Views.Inventories.GoodsReceipts
{
    public partial class WizardMaster : Form
    {
        private GoodsReceiptAPIs goodsReceiptAPIs;
        private GoodsReceiptViewModel goodsReceiptViewModel;
        private CustomTabControl customTabMain;
        public WizardMaster(GoodsReceiptAPIs goodsReceiptAPIs, GoodsReceiptViewModel goodsReceiptViewModel)
        {
            InitializeComponent();

            this.customTabMain = new CustomTabControl();

            this.customTabMain.Font = this.fastPendingPickups.Font;
            this.customTabMain.DisplayStyle = TabStyle.VisualStudio;
            this.customTabMain.DisplayStyleProvider.ImageAlign = ContentAlignment.MiddleLeft;

            this.customTabMain.TabPages.Add("tabPendingPickups", "Receipt by pickup       ");
            this.customTabMain.TabPages.Add("tabPendingPickupWarehouses", "Receipt by warehouse   ");
            this.customTabMain.TabPages.Add("tabPendingTransfers", "Transfer Receipt     ");
            this.customTabMain.TabPages.Add("tabPendingPurchases", "Purchase Invoice     ");
            this.customTabMain.TabPages.Add("tabPendingPurchases", "Sales Return     ");
            this.customTabMain.TabPages[0].Controls.Add(this.fastPendingPickups);
            this.customTabMain.TabPages[1].Controls.Add(this.fastPendingPickupWarehouses);


            this.customTabMain.Dock = DockStyle.Fill;
            this.fastPendingPickups.Dock = DockStyle.Fill;
            this.fastPendingPickupWarehouses.Dock = DockStyle.Fill;
            this.panelMaster.Controls.Add(this.customTabMain);


            this.goodsReceiptAPIs = goodsReceiptAPIs;
            this.goodsReceiptViewModel = goodsReceiptViewModel;
        }


        private void Wizard_Load(object sender, EventArgs e)
        {
            try
            {
                this.fastPendingPickups.SetObjects(this.goodsReceiptAPIs.GetPendingPickups(this.goodsReceiptViewModel.LocationID));
                this.fastPendingPickupWarehouses.SetObjects(this.goodsReceiptAPIs.GetPendingPickupWarehouses(this.goodsReceiptViewModel.LocationID));

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
                    this.goodsReceiptViewModel.HasPickup = true;

                    bool nextOK = false;
                    if (this.customTabMain.SelectedIndex == 0)
                    {
                        PendingPickup pendingPickup = (PendingPickup)this.fastPendingPickups.SelectedObject;
                        if (pendingPickup != null) {                            
                            this.goodsReceiptViewModel.PickupID = pendingPickup.PickupID;
                            this.goodsReceiptViewModel.PickupReference = pendingPickup.PickupReference;
                            
                            this.goodsReceiptViewModel.GoodsReceiptTypeID = pendingPickup.GoodsReceiptTypeID;
                            this.goodsReceiptViewModel.GoodsReceiptTypeName = pendingPickup.GoodsReceiptTypeName;
                            this.goodsReceiptViewModel.WarehouseID = pendingPickup.WarehouseID;
                            this.goodsReceiptViewModel.WarehouseName = pendingPickup.WarehouseName;
                            nextOK = true;
                        }
                    }
                    if (this.customTabMain.SelectedIndex == 1)
                    {
                        PendingPickupWarehouse pendingPickupWarehouse = (PendingPickupWarehouse)this.fastPendingPickupWarehouses.SelectedObject;
                        if (pendingPickupWarehouse != null)
                        {
                            this.goodsReceiptViewModel.GoodsReceiptTypeID = pendingPickupWarehouse.GoodsReceiptTypeID;
                            this.goodsReceiptViewModel.GoodsReceiptTypeName = pendingPickupWarehouse.GoodsReceiptTypeName;
                            this.goodsReceiptViewModel.WarehouseID = pendingPickupWarehouse.WarehouseID;
                            this.goodsReceiptViewModel.WarehouseName = pendingPickupWarehouse.WarehouseName;
                            nextOK = true;
                        }
                    }

                    if (nextOK)
                        this.DialogResult = DialogResult.OK;
                    else
                        CustomMsgBox.Show(this, "Vui lòng chọn phiếu giao thành phẩm sau đóng gói, hoặc kho nhận.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Stop);                    
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

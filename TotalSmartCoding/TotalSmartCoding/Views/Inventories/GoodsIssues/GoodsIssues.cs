using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BrightIdeasSoftware;

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
using TotalSmartCoding.Controllers.APIs.Commons;
using TotalCore.Repositories.Commons;
using TotalBase;
using TotalModel.Models;
using TotalSmartCoding.Properties;
using TotalDTO.Inventories;

namespace TotalSmartCoding.Views.Inventories.GoodsIssues
{
    public partial class GoodsIssues : BaseView
    {
        private CustomTabControl customTabCenter;

        private GoodsIssueAPIs goodsIssueAPIs;
        private GoodsIssueViewModel goodsIssueViewModel { get; set; }

        private System.Timers.Timer timerLoadPending;
        private delegate void timerLoadCallback();

        public GoodsIssues()
            : base()
        {
            InitializeComponent();

            this.toolstripChild = this.toolStripChildForm;
            this.fastListIndex = this.fastGoodsIssueIndex;

            this.goodsIssueAPIs = new GoodsIssueAPIs(CommonNinject.Kernel.Get<IGoodsIssueAPIRepository>());

            this.goodsIssueViewModel = CommonNinject.Kernel.Get<GoodsIssueViewModel>();
            this.goodsIssueViewModel.PropertyChanged += new PropertyChangedEventHandler(ModelDTO_PropertyChanged);
            this.baseDTO = this.goodsIssueViewModel;

            this.timerLoadPending = new System.Timers.Timer(10000);
            this.timerLoadPending.Elapsed += new System.Timers.ElapsedEventHandler(timerLoadPending_Elapsed);
            this.timerLoadPending.Enabled = true;
        }

        private void Pickups_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.timerLoadPending.Enabled = false;
        }

        protected override void InitializeTabControl()
        {
            try
            {
                base.InitializeTabControl();

                this.naviIndex.Bands[0].ClientArea.Controls.Add(this.fastGoodsIssueIndex);

                this.customTabCenter = new CustomTabControl();
                this.customTabCenter.DisplayStyle = TabStyle.VisualStudio;

                this.customTabCenter.TabPages.Add("tabDetailPallets", "Pallet Details        ");
                this.customTabCenter.TabPages.Add("tabDetailPallets", "Carton Details        ");
                this.customTabCenter.TabPages.Add("tabDescription", "Description         ");
                this.customTabCenter.TabPages.Add("tabRemarks", "Remarks                 ");
                this.customTabCenter.TabPages[0].Controls.Add(this.gridexPalletDetails);
                this.customTabCenter.TabPages[1].Controls.Add(this.gridexCartonDetails);
                this.customTabCenter.TabPages[2].Controls.Add(this.textexDescription);
                this.customTabCenter.TabPages[3].Controls.Add(this.textexRemarks);

                this.customTabCenter.TabPages[2].Padding = new Padding(30, 30, 30, 30);
                this.customTabCenter.TabPages[3].Padding = new Padding(30, 30, 30, 30);

                this.customTabCenter.Dock = DockStyle.Fill;
                this.gridexPalletDetails.Dock = DockStyle.Fill;
                this.gridexCartonDetails.Dock = DockStyle.Fill;
                this.textexDescription.Dock = DockStyle.Fill;
                this.textexRemarks.Dock = DockStyle.Fill;
                this.panelMaster.Controls.Add(this.customTabCenter);

                this.naviDetails.ExpandedHeight = this.naviDetails.HeaderHeight + this.textexTotalPalletCounts.Size.Height + this.textexTotalQuantity.Size.Height + this.textexTotalLineVolume.Size.Height + 5 + 4 * 10 + 6;
                this.naviDetails.Expanded = false;

                this.labelCaption.Left = 78; this.labelCaption.Top = 12;
                if (GlobalVariables.ConfigID == (int)GlobalVariables.FillingLine.GoodsIssue) { ViewHelpers.SetFont(this, new Font("Calibri", 11), new Font("Calibri", 11), new Font("Calibri", 11)); ViewHelpers.SetFont(this.MdiParent, new Font("Calibri", 11), new Font("Calibri", 11), new Font("Calibri", 11)); }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }



        Binding bindingEntryDate;
        Binding bindingVehicle;
        Binding bindingCaption;
        Binding bindingDescription;
        Binding bindingRemarks;

        Binding bindingTotalCartonCounts;
        Binding bindingTotalPalletCounts;
        Binding bindingTotalQuantity;
        Binding bindingTotalLineVolume;

        Binding bindingForkliftDriverID;
        Binding bindingStorekeeperID;

        protected override void InitializeCommonControlBinding()
        {
            base.InitializeCommonControlBinding();

            this.bindingCaption = this.labelCaption.DataBindings.Add("Text", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.Caption));

            this.bindingEntryDate = this.dateTimexEntryDate.DataBindings.Add("Value", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.EntryDate), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingVehicle = this.textexVehicle.DataBindings.Add("Text", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.Vehicle), true, DataSourceUpdateMode.OnPropertyChanged);

            this.bindingDescription = this.textexDescription.DataBindings.Add("Text", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.Description), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingRemarks = this.textexRemarks.DataBindings.Add("Text", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.Remarks), true, DataSourceUpdateMode.OnPropertyChanged);

            this.bindingTotalCartonCounts = this.textexTotalCartonCounts.DataBindings.Add("Text", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.TotalCartonCounts), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingTotalPalletCounts = this.textexTotalPalletCounts.DataBindings.Add("Text", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.TotalPalletCounts), true, DataSourceUpdateMode.OnValidation, 0, GlobalEnums.formatQuantity);
            this.bindingTotalQuantity = this.textexTotalQuantity.DataBindings.Add("Text", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.TotalQuantity), true, DataSourceUpdateMode.OnValidation, 0, GlobalEnums.formatQuantity);
            this.bindingTotalLineVolume = this.textexTotalLineVolume.DataBindings.Add("Text", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.TotalLineVolume), true, DataSourceUpdateMode.OnValidation, 0, GlobalEnums.formatVolume);


            EmployeeAPIs employeeAPIs = new EmployeeAPIs(CommonNinject.Kernel.Get<IEmployeeAPIRepository>());

            this.combexForkliftDriverID.DataSource = employeeAPIs.GetEmployeeBases();
            this.combexForkliftDriverID.DisplayMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.Name);
            this.combexForkliftDriverID.ValueMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.EmployeeID);
            this.bindingForkliftDriverID = this.combexForkliftDriverID.DataBindings.Add("SelectedValue", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.ForkliftDriverID), true, DataSourceUpdateMode.OnPropertyChanged);


            this.combexStorekeeperID.DataSource = employeeAPIs.GetEmployeeBases();
            this.combexStorekeeperID.DisplayMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.Name);
            this.combexStorekeeperID.ValueMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.EmployeeID);
            this.bindingStorekeeperID = this.combexStorekeeperID.DataBindings.Add("SelectedValue", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.StorekeeperID), true, DataSourceUpdateMode.OnPropertyChanged);


            this.bindingEntryDate.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingVehicle.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingCaption.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingDescription.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingRemarks.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

            this.bindingTotalCartonCounts.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingTotalPalletCounts.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingTotalQuantity.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingTotalLineVolume.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

            //this.bindingForkliftDriverID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingStorekeeperID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.fastGoodsIssueIndex.AboutToCreateGroups += fastGoodsIssueIndex_AboutToCreateGroups;

            this.fastGoodsIssueIndex.ShowGroups = true;
            this.olvApproved.Renderer = new MappedImageRenderer(new Object[] { false, Resources.Placeholder16 });

            this.tableLayoutMaster.ColumnStyles[this.tableLayoutMaster.ColumnCount - 1].SizeType = SizeType.Absolute; this.tableLayoutMaster.ColumnStyles[this.tableLayoutMaster.ColumnCount - 1].Width = 10;
        }

        private void fastGoodsIssueIndex_AboutToCreateGroups(object sender, CreateGroupsEventArgs e)
        {
            if (e.Groups != null && e.Groups.Count > 0)
            {
                foreach (OLVGroup olvGroup in e.Groups)
                {
                    olvGroup.TitleImage = "Forklift_Yellow-32";
                    olvGroup.Subtitle = "List count: " + olvGroup.Contents.Count.ToString();
                    if ((DateTime)olvGroup.Key != DateTime.Today) olvGroup.Collapsed = true;
                }
            }
        }

        protected override void InitializeDataGridBinding()
        {
            this.gridexPalletDetails.AutoGenerateColumns = false;
            this.gridexCartonDetails.AutoGenerateColumns = false;
            this.gridexPalletDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.gridexCartonDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.gridexPalletDetails.DataSource = this.goodsIssueViewModel.PalletDetails;
            this.gridexCartonDetails.DataSource = this.goodsIssueViewModel.CartonDetails;

            this.goodsIssueViewModel.ViewDetails.ListChanged += ViewDetails_ListChanged;
        }

        private void ViewDetails_ListChanged(object sender, ListChangedEventArgs e)
        {
            if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.Reset)
            {
                this.customTabCenter.TabPages[0].Text = "Pallet Details [" + this.goodsIssueViewModel.PalletDetails.Count.ToString("N0") + " item(s)]             ";
                this.customTabCenter.TabPages[1].Text = "Carton Details [" + this.goodsIssueViewModel.CartonDetails.Count.ToString("N0") + " item(s)]             ";

                this.gridexPalletDetails.Columns["Pallet" + CommonExpressions.PropertyName<GoodsIssueDetailDTO>(p => p.DeliveryAdviceReference)].Visible = this.goodsIssueViewModel.DeliveryAdviceID == null;
                this.gridexCartonDetails.Columns["Carton" + CommonExpressions.PropertyName<GoodsIssueDetailDTO>(p => p.DeliveryAdviceReference)].Visible = this.goodsIssueViewModel.DeliveryAdviceID == null;
            }
        }


        protected override Controllers.BaseController myController
        {
            get { return new GoodsIssueController(CommonNinject.Kernel.Get<IGoodsIssueService>(), this.goodsIssueViewModel); }
        }

        public override void Loading()
        {
            this.fastGoodsIssueIndex.SetObjects(this.goodsIssueAPIs.GetGoodsIssueIndexes());
            this.fastGoodsIssueIndex.Sort(this.olvEntryDate, SortOrder.Descending);

            base.Loading();
        }

        protected override void invokeEdit(int? id)
        {
            base.invokeEdit(id);
            this.getPendingItems();
        }

        public override void Save(bool escapeAfterSave)
        {
            base.Save(escapeAfterSave);
            this.getPendingItems();
        }

        private void getPendingItems()
        {
            try
            {
                if (this.goodsIssueViewModel.GoodsIssueTypeID == (int)GlobalEnums.GoodsIssueTypeID.DeliveryAdvice)
                {
                    this.olvDeliveryAdviceReference.IsVisible = false;
                    this.fastPendingDeliveryAdviceDetails.SetObjects(this.goodsIssueAPIs.GetPendingDeliveryAdviceDetails(this.goodsIssueViewModel.LocationID, this.goodsIssueViewModel.GoodsIssueID, this.goodsIssueViewModel.DeliveryAdviceID, this.goodsIssueViewModel.CustomerID, string.Join(",", this.goodsIssueViewModel.ViewDetails.Select(d => d.DeliveryAdviceDetailID)), false));
                }
                if (this.goodsIssueViewModel.GoodsIssueTypeID == (int)GlobalEnums.GoodsIssueTypeID.TransferOrder)
                {
                    this.olvTransferOrderReference.IsVisible = false;
                    this.fastPendingDeliveryAdviceDetails.SetObjects(this.goodsIssueAPIs.GetPendingTransferOrderDetails(this.goodsIssueViewModel.LocationID, this.goodsIssueViewModel.GoodsIssueID, this.goodsIssueViewModel.WarehouseID, this.goodsIssueViewModel.TransferOrderID, this.goodsIssueViewModel.WarehouseReceiptID, string.Join(",", this.goodsIssueViewModel.ViewDetails.Select(d => d.TransferOrderDetailID)), false));
                }
                //this.naviPendingItems.Text = "Pending " + this.fastPendingDeliveryAdviceDetails.GetItemCount().ToString("N0") + " row" + (this.fastPendingDeliveryAdviceDetails.GetItemCount() > 1 ? "s" : "");
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        protected override DialogResult wizardMaster()
        {
            WizardMaster wizardMaster = new WizardMaster(this.goodsIssueAPIs, this.goodsIssueViewModel);
            DialogResult dialogResult = wizardMaster.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK) this.Save(false);

            wizardMaster.Dispose();
            return dialogResult;
        }

        private void fastPendingPallets_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.EditableMode && this.goodsIssueViewModel.Editable && this.goodsIssueViewModel.IsValid && !this.goodsIssueViewModel.IsDirty)
                {
                    PendingDeliveryAdviceDetail pendingDeliveryAdviceDetail = this.fastPendingDeliveryAdviceDetails.SelectedObject as PendingDeliveryAdviceDetail;
                    PendingTransferOrderDetail pendingTransferOrderDetail = this.fastPendingDeliveryAdviceDetails.SelectedObject as PendingTransferOrderDetail;

                    if (pendingDeliveryAdviceDetail != null || pendingTransferOrderDetail != null)
                    {
                        WizardDetail wizardDetail = new WizardDetail(this.goodsIssueViewModel, pendingDeliveryAdviceDetail, pendingTransferOrderDetail);
                        TabletMDI tabletMDI = new TabletMDI(wizardDetail);
                        if (tabletMDI.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                            this.Save(false);

                        wizardDetail.Dispose(); tabletMDI.Dispose();
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void gridexViewDetails_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
            try
            {
                if (this.goodsIssueViewModel.IsDirty && this.goodsIssueViewModel.IsValid) this.Save(false);
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void timerLoadPending_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            try
            {
                timerLoadCallback loadPendingItemsCallback = new timerLoadCallback(getPendingItems);
                this.Invoke(loadPendingItemsCallback);
            }
            catch { }
        }





    }
}

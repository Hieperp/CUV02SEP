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
                this.setFont(new Font("Niagara Engraved", 16), new Font("Calibri", 13), new Font("Niagara Engraved", 16));

                this.customTabCenter.DisplayStyle = TabStyle.VisualStudio;

                this.customTabCenter.TabPages.Add("tabDetailPallets", "GoodsIssue pallet list                    ");
                this.customTabCenter.TabPages.Add("tabDescription", "Description                    ");
                this.customTabCenter.TabPages.Add("tabRemarks", "Remarks                    ");
                this.customTabCenter.TabPages[0].Controls.Add(this.gridexPalletDetails);
                this.customTabCenter.TabPages[1].Controls.Add(this.textexDescription);
                this.customTabCenter.TabPages[2].Controls.Add(this.textexRemarks);

                this.customTabCenter.TabPages[1].Padding = new Padding(30, 30, 30, 30);
                this.customTabCenter.TabPages[2].Padding = new Padding(30, 30, 30, 30);

                this.customTabCenter.Dock = DockStyle.Fill;
                this.gridexPalletDetails.Dock = DockStyle.Fill;
                this.textexDescription.Dock = DockStyle.Fill;
                this.textexRemarks.Dock = DockStyle.Fill;
                this.panelMaster.Controls.Add(this.customTabCenter);

                this.naviDetails.ExpandedHeight = this.naviDetails.HeaderHeight + this.textexTotalPalletCounts.Size.Height + this.textexTotalQuantity.Size.Height + this.textexTotalLineVolume.Size.Height + 5 + 4 * 10 + 6;
                this.naviDetails.Expanded = false;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }


        private void setFont(Font titleFont, Font font, Font toolbarFont)
        {
            this.customTabCenter.Font = titleFont;
            this.naviDetails.Font = titleFont;
            this.olvCommodityCode.HeaderFont = titleFont;
            this.olvGoodsIssueIndexReference.HeaderFont = titleFont;
            this.labelFillingLineName.Left = 78;
            this.labelFillingLineName.Top = 14;

            List<Control> controls = ViewHelpers.GetAllControls(this);
            foreach (Control control in controls)
            {
                if (control is Label) control.Font = titleFont;
                else if (control is TextBox || control is ComboBox || control is DateTimePicker) control.Font = font;
                else if (control is FastObjectListView) control.Font = font;
                else if (control is DataGridView)
                {
                    DataGridView dataGridView = control as DataGridView;
                    dataGridView.ColumnHeadersDefaultCellStyle.Font = titleFont;
                    dataGridView.RowsDefaultCellStyle.Font = font;
                }
            }


            List<Control> parentControls = ViewHelpers.GetAllControls(this.MdiParent);
            foreach (Control parentControl in parentControls)
            {
                if (parentControl is ToolStrip)
                {
                    foreach (ToolStripItem item in ((ToolStrip)parentControl).Items)
                    {
                        if (item is ToolStripLabel || item is ToolStripTextBox || item is ToolStripComboBox || item is ToolStripButton)
                            item.Font = toolbarFont;
                    }
                }
            }



        }



        Binding bindingEntryDate;
        Binding bindingReference;
        Binding bindingFillingLineName;
        Binding bindingWarehouseCode;
        Binding bindingDescription;
        Binding bindingRemarks;

        Binding bindingTotalPalletCounts;
        Binding bindingTotalQuantity;
        Binding bindingTotalLineVolume;

        Binding bindingForkliftDriverID;
        Binding bindingStorekeeperID;

        protected override void InitializeCommonControlBinding()
        {
            base.InitializeCommonControlBinding();

            this.bindingFillingLineName = this.labelFillingLineName.DataBindings.Add("Text", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.Caption));

            this.bindingEntryDate = this.dateTimexEntryDate.DataBindings.Add("Value", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.EntryDate), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingReference = this.textexReference.DataBindings.Add("Text", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.Reference), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingWarehouseCode = this.textexWarehouseCode.DataBindings.Add("Text", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.CustomerName), true, DataSourceUpdateMode.OnPropertyChanged);

            this.bindingDescription = this.textexDescription.DataBindings.Add("Text", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.Description), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingRemarks = this.textexRemarks.DataBindings.Add("Text", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.Remarks), true, DataSourceUpdateMode.OnPropertyChanged);

            this.bindingTotalPalletCounts = this.textexTotalPalletCounts.DataBindings.Add("Text", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.TotalPalletCounts), true, DataSourceUpdateMode.OnValidation, 0, GlobalEnums.formatQuantity);
            this.bindingTotalQuantity = this.textexTotalQuantity.DataBindings.Add("Text", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.TotalQuantity), true, DataSourceUpdateMode.OnValidation, 0, GlobalEnums.formatQuantity);
            this.bindingTotalLineVolume = this.textexTotalLineVolume.DataBindings.Add("Text", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.TotalLineVolume), true, DataSourceUpdateMode.OnValidation, 0, GlobalEnums.formatVolume);


            EmployeeAPIs employeeAPIs = new EmployeeAPIs(CommonNinject.Kernel.Get<IEmployeeAPIRepository>());

            //this.combexForkliftDriverID.DataSource = employeeAPIs.GetEmployeeBases();
            //this.combexForkliftDriverID.DisplayMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.Name);
            //this.combexForkliftDriverID.ValueMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.EmployeeID);
            //this.bindingForkliftDriverID = this.combexForkliftDriverID.DataBindings.Add("SelectedValue", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.ForkliftDriverID), true, DataSourceUpdateMode.OnPropertyChanged);


            this.combexStorekeeperID.DataSource = employeeAPIs.GetEmployeeBases();
            this.combexStorekeeperID.DisplayMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.Name);
            this.combexStorekeeperID.ValueMember = CommonExpressions.PropertyName<EmployeeBase>(p => p.EmployeeID);
            this.bindingStorekeeperID = this.combexStorekeeperID.DataBindings.Add("SelectedValue", this.goodsIssueViewModel, CommonExpressions.PropertyName<GoodsIssueViewModel>(p => p.StorekeeperID), true, DataSourceUpdateMode.OnPropertyChanged);


            this.bindingEntryDate.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingReference.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingFillingLineName.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingWarehouseCode.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingDescription.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingRemarks.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

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
                    olvGroup.TitleImage = "Forklift";
                    olvGroup.Subtitle = "List count: " + olvGroup.Contents.Count.ToString();
                    if ((DateTime)olvGroup.Key != DateTime.Today) olvGroup.Collapsed = true;
                }
            }
        }

        protected override void InitializeDataGridBinding()
        {
            this.gridexPalletDetails.AutoGenerateColumns = false;
            this.gridexPalletDetails.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.gridexPalletDetails.DataSource = this.goodsIssueViewModel.ViewDetails;

            //StackedHeaderDecorator stackedHeaderDecorator = new StackedHeaderDecorator(this.dataGridViewDetails);
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

        private void getPendingItems() //THIS MAY ALSO LOAD PENDING PALLET/ CARTON/ PACK
        {
            try
            {
                this.fastPendingDeliveryAdviceDetails.SetObjects(this.goodsIssueAPIs.GetPendingDeliveryAdviceDetails(this.goodsIssueViewModel.LocationID, this.goodsIssueViewModel.GoodsIssueID, this.goodsIssueViewModel.DeliveryAdviceID, this.goodsIssueViewModel.CustomerID, string.Join(",", this.goodsIssueViewModel.ViewDetails.Select(d => d.DeliveryAdviceDetailID)), false));
                //this.naviPendingDeliveryAdviceDetails.Text = "Pending " + this.fastPendingDeliveryAdviceDetails.GetItemCount().ToString("N0") + " item" + (this.fastPendingDeliveryAdviceDetails.GetItemCount() > 1 ? "s      " : "      ");
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }

            //////try
            //////{
            //////    this.fastPendingDeliveryAdviceDetails.SetObjects(this.goodsIssueAPIs.GetPendingPallets(this.goodsIssueViewModel.LocationID, this.goodsIssueViewModel.FillingLineID, this.goodsIssueViewModel.GoodsIssueID, string.Join(",", this.goodsIssueViewModel.ViewDetails.Where(w => w.PalletID != null).Select(d => d.PalletID)), false));
            //////    this.olvPendingPalletCode.Text = "Line " + this.goodsIssueViewModel.FillingLineNickName + "   -   Pending " + this.fastPendingDeliveryAdviceDetails.GetItemCount().ToString("N0") + " pallet" + (this.fastPendingDeliveryAdviceDetails.GetItemCount() > 1 ? "s" : "");
            //////}
            //////catch (Exception exception)
            //////{
            //////    ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            //////}
        }

        protected override DialogResult wizardMaster()
        {
            WizardMaster wizardMaster = new WizardMaster(this.goodsIssueAPIs, this.goodsIssueViewModel);
            DialogResult dialogResult = wizardMaster.ShowDialog();
            if (dialogResult == System.Windows.Forms.DialogResult.OK) this.Save(false);
            return dialogResult;
        }

        private void fastPendingPallets_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (this.EditableMode && this.goodsIssueViewModel.Editable && this.goodsIssueViewModel.IsValid && !this.goodsIssueViewModel.IsDirty)
                {
                    PendingDeliveryAdviceDetail pendingDeliveryAdviceDetail = (PendingDeliveryAdviceDetail)this.fastPendingDeliveryAdviceDetails.SelectedObject;
                    if (pendingDeliveryAdviceDetail != null)
                    {
                        WizardDetail wizardDetail = new WizardDetail(this.goodsIssueViewModel, pendingDeliveryAdviceDetail);
                        if (wizardDetail.ShowDialog() == System.Windows.Forms.DialogResult.OK) this.Save(false);
                    }
                }
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private void gridexPalletDetails_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
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

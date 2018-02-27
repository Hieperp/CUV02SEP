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
using TotalSmartCoding.Controllers.APIs.Generals;
using TotalCore.Repositories.Generals;
using TotalModel.Helpers;


namespace TotalSmartCoding.Views.Sales.Forecasts
{
    public partial class Forecasts : BaseView
    {
        private CustomTabControl customTabLeft;
        private CustomTabControl customTabCenter;

        private ForecastAPIs forecastAPIs;
        private ForecastViewModel forecastViewModel { get; set; }

        public Forecasts()
            : base()
        {
            InitializeComponent();


            this.toolstripChild = this.toolStripChildForm;
            this.fastListIndex = this.fastForecastIndex;

            this.forecastAPIs = new ForecastAPIs(CommonNinject.Kernel.Get<IForecastAPIRepository>());

            this.forecastViewModel = CommonNinject.Kernel.Get<ForecastViewModel>();
            this.forecastViewModel.PropertyChanged += new PropertyChangedEventHandler(ModelDTO_PropertyChanged);
            this.baseDTO = this.forecastViewModel;
        }

        protected override void InitializeTabControl()
        {
            try
            {
                base.InitializeTabControl();

                #region TabLeft
                this.customTabLeft = new CustomTabControl();
                this.customTabLeft.DisplayStyle = TabStyle.VisualStudio;

                this.customTabLeft.TabPages.Add("tabLeftAA", "Sales Forecast  ");
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

                this.customTabCenter.TabPages.Add("tabCenterAA", "Forecast Lines            ");
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
        Binding bindingDescription;
        Binding bindingRemarks;
        Binding bindingCaption;

        Binding bindingForecastLocationID;

        protected override void InitializeCommonControlBinding()
        {
            base.InitializeCommonControlBinding();

            this.bindingEntryDate = this.dateTimexEntryDate.DataBindings.Add("Value", this.forecastViewModel, CommonExpressions.PropertyName<ForecastDTO>(p => p.EntryDate), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingReference = this.textexReference.DataBindings.Add("Text", this.forecastViewModel, CommonExpressions.PropertyName<ForecastDTO>(p => p.Reference), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingVoucherCode = this.textexVoucherCode.DataBindings.Add("Text", this.forecastViewModel, CommonExpressions.PropertyName<ForecastDTO>(p => p.VoucherCode), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingDescription = this.textexDescription.DataBindings.Add("Text", this.forecastViewModel, CommonExpressions.PropertyName<ForecastDTO>(p => p.Description), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingRemarks = this.textexRemarks.DataBindings.Add("Text", this.forecastViewModel, CommonExpressions.PropertyName<ForecastDTO>(p => p.Remarks), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingCaption = this.labelCaption.DataBindings.Add("Text", this.forecastViewModel, CommonExpressions.PropertyName<ForecastDTO>(p => p.Caption));

            LocationAPIs locationAPIs = new LocationAPIs(CommonNinject.Kernel.Get<ILocationAPIRepository>());
            this.combexForecastLocationID.DataSource = locationAPIs.GetLocationBases();
            this.combexForecastLocationID.DisplayMember = CommonExpressions.PropertyName<LocationBase>(p => p.Name);
            this.combexForecastLocationID.ValueMember = CommonExpressions.PropertyName<LocationBase>(p => p.LocationID);
            this.bindingForecastLocationID = this.combexForecastLocationID.DataBindings.Add("SelectedValue", this.forecastViewModel, CommonExpressions.PropertyName<ForecastViewModel>(p => p.ForecastLocationID), true, DataSourceUpdateMode.OnPropertyChanged);


            this.bindingEntryDate.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingReference.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingVoucherCode.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingDescription.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingRemarks.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingCaption.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

            this.bindingForecastLocationID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

            this.fastForecastIndex.AboutToCreateGroups += fastForecastIndex_AboutToCreateGroups;

            this.fastForecastIndex.ShowGroups = true;
            this.naviGroupDetails.ExpandedHeight = this.naviGroupDetails.Size.Height;
        }

        protected override void CommonControl_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            base.CommonControl_BindingComplete(sender, e);
            if (this.EditableMode)
            {
                if (sender.Equals(this.bindingForecastLocationID) && this.combexForecastLocationID.SelectedItem != null)
                {
                    LocationBase locationBase = (LocationBase)this.combexForecastLocationID.SelectedItem;
                    this.forecastViewModel.ForecastLocationName = locationBase.Name;
                }
            }
        }

        private void fastForecastIndex_AboutToCreateGroups(object sender, CreateGroupsEventArgs e)
        {
            if (e.Groups != null && e.Groups.Count > 0)
            {
                foreach (OLVGroup olvGroup in e.Groups)
                {
                    olvGroup.TitleImage = "pay-per-click";
                    olvGroup.Subtitle = "Count: " + olvGroup.Contents.Count.ToString() + " Forecast(s)";
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

            this.bindingSourceViewDetails.DataSource = this.forecastViewModel.ViewDetails;
            this.gridexViewDetails.DataSource = this.bindingSourceViewDetails;

            this.bindingSourceViewDetails.AddingNew += bindingSourceViewDetails_AddingNew;
            this.forecastViewModel.ViewDetails.ListChanged += ViewDetails_ListChanged;
            this.gridexViewDetails.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(this.dataGridViewDetails_EditingControlShowing);
            this.gridexViewDetails.ReadOnlyChanged += new System.EventHandler(this.dataGrid_ReadOnlyChanged);

            DataGridViewComboBoxColumn comboBoxColumn;
            CommodityAPIs commodityAPIs = new CommodityAPIs(CommonNinject.Kernel.Get<ICommodityAPIRepository>());

            comboBoxColumn = (DataGridViewComboBoxColumn)this.gridexViewDetails.Columns[CommonExpressions.PropertyName<ForecastDetailDTO>(p => p.CommodityID)];
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
                this.customTabCenter.TabPages[0].Text = "Forecast Lines [" + this.forecastViewModel.ViewDetails.Count.ToString("N0") + " item(s)]             ";

            if (this.EditableMode && e.PropertyDescriptor != null && e.NewIndex >= 0 && e.NewIndex < this.forecastViewModel.ViewDetails.Count)
            {
                ForecastDetailDTO forecastDetailDTO = this.forecastViewModel.ViewDetails[e.NewIndex];
                if (forecastDetailDTO != null)
                    this.CalculateDetailDTO(forecastDetailDTO, e.PropertyDescriptor.Name);
            }
        }


        #region Helper Method
        private void CalculateDetailDTO(ForecastDetailDTO forecastDetailDTO, string propertyName)
        {
            if (propertyName == CommonExpressions.PropertyName<ForecastDetailDTO>(p => p.CommodityID))
            {
                CommodityAPIs commodityAPIs = new CommodityAPIs(CommonNinject.Kernel.Get<ICommodityAPIRepository>()); //WE MUST USE ContextAttributes.User.LocationID, INSTEAD OF quantityDetailDTO.LocationID, BECAUSE AT FIRST quantityDetailDTO.LocationID = 0. WHEN SAVE: GenericService.PreSaveRoutines WILL UPDATE DTO.LocationID = ContextAttributes.User.LocationID. SEE GenericService.PreSaveRoutines FOR MORE INFORMATION!!!
                IList<SearchCommodity> searchCommodities = commodityAPIs.SearchCommodities(forecastDetailDTO.CommodityID, ContextAttributes.User.LocationID, null, null, null);
                if (searchCommodities.Count > 0)
                {
                    forecastDetailDTO.CommodityCode = searchCommodities[0].Code;
                    forecastDetailDTO.CommodityName = searchCommodities[0].Name;
                    forecastDetailDTO.CommodityCategoryName = searchCommodities[0].CommodityCategoryName;
                }
            }
        }
        #endregion Helper Method

        protected override Controllers.BaseController myController
        {
            get { return new ForecastController(CommonNinject.Kernel.Get<IForecastService>(), this.forecastViewModel); }
        }

        public override void Loading()
        {
            this.fastForecastIndex.SetObjects(this.forecastAPIs.GetForecastIndexes());

            base.Loading();
        }

        protected override void DoAfterLoad()
        {
            base.DoAfterLoad();
            this.fastForecastIndex.Sort(this.olvEntryDate, SortOrder.Descending);
        }

        protected override void invokeEdit(int? id)
        {
            base.invokeEdit(id);

            bool byQuantity = this.forecastViewModel.QuantityVersusVolume == 0;
            this.gridexViewDetails.Columns[CommonExpressions.PropertyName<ForecastDetailDTO>(p => p.TotalQuantity)].Visible = byQuantity;
            this.gridexViewDetails.Columns[CommonExpressions.PropertyName<ForecastDetailDTO>(p => p.TotalLineVolume)].Visible = !byQuantity;

            this.gridexViewDetails.Columns[CommonExpressions.PropertyName<ForecastDetailDTO>(p => p.Quantity)].Visible = byQuantity;
            this.gridexViewDetails.Columns[CommonExpressions.PropertyName<ForecastDetailDTO>(p => p.LineVolume)].Visible = !byQuantity;
            this.gridexViewDetails.Columns[CommonExpressions.PropertyName<ForecastDetailDTO>(p => p.QuantityM1)].Visible = byQuantity;
            this.gridexViewDetails.Columns[CommonExpressions.PropertyName<ForecastDetailDTO>(p => p.LineVolumeM1)].Visible = !byQuantity;
            this.gridexViewDetails.Columns[CommonExpressions.PropertyName<ForecastDetailDTO>(p => p.QuantityM2)].Visible = byQuantity;
            this.gridexViewDetails.Columns[CommonExpressions.PropertyName<ForecastDetailDTO>(p => p.LineVolumeM2)].Visible = !byQuantity;
            this.gridexViewDetails.Columns[CommonExpressions.PropertyName<ForecastDetailDTO>(p => p.QuantityM3)].Visible = byQuantity;
            this.gridexViewDetails.Columns[CommonExpressions.PropertyName<ForecastDetailDTO>(p => p.LineVolumeM3)].Visible = !byQuantity;
        }

        public override void Import()
        {
            this.ImportExcel(GlobalEnums.MappingTaskID.Forecast);
        }

        protected override void DoImportExcel(string fileName)
        {
            base.DoImportExcel(fileName);
            this.ImportExcel(fileName);
            this.Loading();
        }

        protected override DialogResult wizardMaster()
        {
            WizardMaster wizardMaster = new WizardMaster(this.forecastViewModel);
            DialogResult dialogResult = wizardMaster.ShowDialog();

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


        #region Import Excel

        public bool ImportExcel(string fileName)
        {
            try
            {
                OleDbAPIs oleDbAPIs = new OleDbAPIs(CommonNinject.Kernel.Get<IOleDbAPIRepository>(), GlobalEnums.MappingTaskID.Forecast);

                //CommodityViewModel commodityViewModel = CommonNinject.Kernel.Get<CommodityViewModel>();
                //CommodityController commodityController = new CommodityController(CommonNinject.Kernel.Get<ICommodityService>(), commodityViewModel);


                //int intValue; decimal decimalValue; DateTime dateTimeValue;
                //ExceptionTable exceptionTable = new ExceptionTable(new string[2, 2] { { "ExceptionCategory", "System.String" }, { "Description", "System.String" } });

                ////////////TimeSpan timeout = TimeSpan.FromMinutes(90);
                ////////////using (TransactionScope transactionScope = new TransactionScope(TransactionScopeOption.Required, timeout))
                ////////////{
                ////////////if (!this.Editable(this.)) throw new System.ArgumentException("Import", "Permission conflict");


                //DataTable excelDataTable = oleDbAPIs.OpenExcelSheet(fileName);
                //if (excelDataTable != null && excelDataTable.Rows.Count > 0)
                //{
                //    foreach (DataRow excelDataRow in excelDataTable.Rows)
                //    {
                //        exceptionTable.ClearDirty();

                //        string code = excelDataRow["Code"].ToString().Trim();
                //        if (code.Length < 5) code = new String('0', 5 - code.Length) + code;

                //        BatchMasterBase batchMasterBase = this.batchMasterAPIs.GetBatchMasterBase(code);

                //        if (batchMasterBase == null)
                //        {
                //            this.batchMasterController.Create();

                //            this.batchMasterViewModel.EntryDate = new DateTime(2000, 1, 1);
                //            this.batchMasterViewModel.Code = code;


                //            if (DateTime.TryParse(excelDataRow["PlannedDate"].ToString(), out dateTimeValue)) this.batchMasterViewModel.PlannedDate = dateTimeValue; else exceptionTable.AddException(new string[] { "Lỗi cột dữ liệu Plan start date", "Batch: " + code + ": " + excelDataRow["PlannedDate"].ToString() });
                //            if (decimal.TryParse(excelDataRow["PlannedQuantity"].ToString(), out decimalValue)) this.batchMasterViewModel.PlannedQuantity = decimalValue; else exceptionTable.AddException(new string[] { "Lỗi cột dữ liệu SL Kế hoạch", "Batch: " + code + ": " + excelDataRow["PlannedQuantity"].ToString() });

                //            CommodityBase commodityBase = this.commodityAPIs.GetCommodityBase(excelDataRow["CommodityCode"].ToString());
                //            if (commodityBase != null) this.batchMasterViewModel.CommodityID = commodityBase.CommodityID;
                //            else
                //            {
                //                commodityController.Create();

                //                commodityViewModel.Code = excelDataRow["CommodityCode"].ToString();
                //                commodityViewModel.APICode = excelDataRow["CommodityAPICode"].ToString().Replace("'", "");
                //                commodityViewModel.CartonCode = excelDataRow["CommodityCartonCode"].ToString().Replace("'", "");
                //                commodityViewModel.Name = excelDataRow["CommodityName"].ToString();
                //                commodityViewModel.OfficialName = excelDataRow["CommodityName"].ToString();

                //                commodityViewModel.CommodityCategoryID = 2;
                //                commodityViewModel.FillingLineIDs = "1,2";

                //                if (decimal.TryParse(excelDataRow["Volume"].ToString(), out decimalValue)) commodityViewModel.Volume = decimalValue / 1000; else exceptionTable.AddException(new string[] { "Lỗi cột dữ liệu Trọng lượng", "Batch: " + code + ": " + excelDataRow["Volume"].ToString() });
                //                if (int.TryParse(excelDataRow["PackPerCarton"].ToString(), out intValue)) commodityViewModel.PackPerCarton = intValue; else exceptionTable.AddException(new string[] { "Lỗi cột dữ liệu QC thùng", "Batch: " + code + ": " + excelDataRow["PackPerCarton"].ToString() });
                //                if (int.TryParse(excelDataRow["CartonPerPallet"].ToString(), out intValue)) commodityViewModel.CartonPerPallet = intValue / commodityViewModel.PackPerCarton; else exceptionTable.AddException(new string[] { "Lỗi cột dữ liệu QC pallet", "Batch: " + code + ": " + excelDataRow["CartonPerPallet"].ToString() });

                //                commodityViewModel.PackageSize = commodityViewModel.PackPerCarton.ToString("N0") + "x" + commodityViewModel.Volume.ToString("N2") + "kg";

                //                if (int.TryParse(excelDataRow["Shelflife"].ToString(), out intValue)) commodityViewModel.Shelflife = intValue; else exceptionTable.AddException(new string[] { "Lỗi cột dữ liệu Expiration months", "Batch: " + code + ": " + excelDataRow["Shelflife"].ToString() });

                //                if (!commodityViewModel.IsValid) exceptionTable.AddException(new string[] { "Lỗi dữ liệu sản phẩm không hợp lệ", excelDataRow["CommodityCode"].ToString() + ": " + commodityViewModel.Error });
                //                else
                //                    if (commodityViewModel.IsDirty)
                //                        if (commodityController.Save())
                //                            this.batchMasterViewModel.CommodityID = commodityViewModel.CommodityID;
                //                        else
                //                            exceptionTable.AddException(new string[] { "Lỗi lưu dữ liệu [thêm sản phẩm mới]", excelDataRow["CommodityCode"].ToString() + commodityController.BaseService.ServiceTag });
                //            }


                //            BatchStatusBase batchStatusBase = this.batchStatusAPIs.GetBatchStatusBase(excelDataRow["BatchStatusCode"].ToString());
                //            if (batchStatusBase != null) this.batchMasterViewModel.BatchStatusID = batchStatusBase.BatchStatusID; else exceptionTable.AddException(new string[] { "Lỗi cột dữ liệu Trạng thái", "Batch: " + code + ": " + excelDataRow["BatchStatusCode"].ToString() });


                //            if (!this.batchMasterViewModel.IsValid) exceptionTable.AddException(new string[] { "Lỗi dữ liệu Batch không hợp lệ", "Batch: " + code + ": " + this.batchMasterViewModel.Error }); ;
                //            if (!exceptionTable.IsDirty)
                //                if (this.batchMasterViewModel.IsDirty && !this.batchMasterController.Save())
                //                    exceptionTable.AddException(new string[] { "Lỗi lưu dữ liệu [thêm batch mới]", code + this.batchMasterController.BaseService.ServiceTag });
                //        }
                //        else
                //            exceptionTable.AddException(new string[] { "Batch không được import, do đã tồn tại trên hệ thống", "Batch: " + code });
                //    }
                //}

                //if (exceptionTable.Table.Rows.Count <= 0)
                return true;
                //else
                //    throw new CustomException("Lỗi import file excel. Vui lòng xem danh sách đính kèm. Click vào từng nội dung để xem chi tiết.", exceptionTable.Table);

            }
            catch (System.Exception exception)
            {
                throw exception;
            }
        }


        #endregion Import Excel

    }
}

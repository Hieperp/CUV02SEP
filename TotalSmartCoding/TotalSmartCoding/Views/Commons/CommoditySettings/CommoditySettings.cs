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

using TotalSmartCoding.Controllers.Commons;
using TotalCore.Repositories.Commons;
using TotalSmartCoding.Controllers.APIs.Commons;
using TotalCore.Services.Commons;
using TotalSmartCoding.ViewModels.Commons;
using TotalBase;
using TotalModel.Models;
using TotalDTO.Commons;
using BrightIdeasSoftware;
using TotalSmartCoding.Libraries.StackedHeaders;


namespace TotalSmartCoding.Views.Commons.CommoditySettings
{
    public partial class CommoditySettings : BaseView
    {
        private CustomTabControl customTabCenter;

        private CommoditySettingAPIs commoditySettingAPIs;
        private CommoditySettingViewModel commoditySettingViewModel { get; set; }

        public CommoditySettings()
            : base()
        {
            InitializeComponent();

            this.toolstripChild = this.toolStripChildForm;
            this.fastListIndex = this.fastCommoditySettingIndex;

            this.commoditySettingAPIs = new CommoditySettingAPIs(CommonNinject.Kernel.Get<ICommoditySettingAPIRepository>());

            this.commoditySettingViewModel = CommonNinject.Kernel.Get<CommoditySettingViewModel>();
            this.commoditySettingViewModel.PropertyChanged += new PropertyChangedEventHandler(ModelDTO_PropertyChanged);
            this.baseDTO = this.commoditySettingViewModel;
        }

        protected override void InitializeTabControl()
        {
            try
            {
                base.InitializeTabControl();

                #region TabCenter
                this.customTabCenter = new CustomTabControl();
                this.customTabCenter.DisplayStyle = TabStyle.VisualStudio;
                this.customTabCenter.Font = this.panelCenter.Font;

                this.customTabCenter.TabPages.Add("tabCenterAA", "Low, High & Alert Details          ");

                this.customTabCenter.TabPages[0].Controls.Add(this.layoutTop);
                this.customTabCenter.TabPages[0].Controls.Add(this.layoutRight);
                this.customTabCenter.TabPages[0].BackColor = this.panelCenter.BackColor;
                this.layoutTop.Dock = DockStyle.Top;
                this.layoutRight.Dock = DockStyle.Fill;

                this.panelCenter.Controls.Add(this.customTabCenter);
                this.customTabCenter.Dock = DockStyle.Fill;
                #endregion TabCenter

                this.layoutTop.ColumnStyles[this.layoutTop.ColumnCount - 1].SizeType = SizeType.Absolute; this.layoutTop.ColumnStyles[this.layoutTop.ColumnCount - 1].Width = 15;
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        Binding bindingCommodityID;
        Binding bindingCommodityName;
        Binding bindingCommodityCategoryName;

        Binding bindingPackageSize;
        Binding bindingPackageVolume;

        Binding bindingRemarks;

        protected override void InitializeCommonControlBinding()
        {
            base.InitializeCommonControlBinding();

            CommodityAPIs commodityAPIs = new CommodityAPIs(CommonNinject.Kernel.Get<ICommodityAPIRepository>());
            this.combexCommodityID.DataSource = commodityAPIs.GetCommodityBases();
            this.combexCommodityID.DisplayMember = CommonExpressions.PropertyName<CommodityBase>(p => p.Name);
            this.combexCommodityID.ValueMember = CommonExpressions.PropertyName<CommodityBase>(p => p.CommodityID);
            this.bindingCommodityID = this.combexCommodityID.DataBindings.Add("SelectedValue", this.commoditySettingViewModel, CommonExpressions.PropertyName<CommoditySettingDTO>(p => p.CommodityID), true, DataSourceUpdateMode.OnPropertyChanged);

            this.bindingCommodityName = this.textexCommodityName.DataBindings.Add("Text", this.commoditySettingViewModel, CommonExpressions.PropertyName<CommoditySettingDTO>(p => p.CommodityName), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingCommodityCategoryName = this.textexCommodityCategoryName.DataBindings.Add("Text", this.commoditySettingViewModel, CommonExpressions.PropertyName<CommoditySettingDTO>(p => p.CommodityCategoryName), true, DataSourceUpdateMode.OnPropertyChanged);

            this.bindingPackageSize = this.textexPackageSize.DataBindings.Add("Text", this.commoditySettingViewModel, CommonExpressions.PropertyName<CommoditySettingDTO>(p => p.PackageSize), true, DataSourceUpdateMode.OnPropertyChanged);
            this.bindingPackageVolume = this.numericPackageVolume.DataBindings.Add("Value", this.commoditySettingViewModel, CommonExpressions.PropertyName<CommoditySettingDTO>(p => p.PackageVolume), true, DataSourceUpdateMode.OnPropertyChanged);

            this.bindingRemarks = this.textexRemarks.DataBindings.Add("Text", this.commoditySettingViewModel, CommonExpressions.PropertyName<CommoditySettingDTO>(p => p.Remarks), true, DataSourceUpdateMode.OnPropertyChanged);

            this.bindingCommodityID.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

            this.bindingCommodityName.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingCommodityCategoryName.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

            this.bindingPackageSize.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);
            this.bindingPackageVolume.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

            this.bindingRemarks.BindingComplete += new BindingCompleteEventHandler(CommonControl_BindingComplete);

            this.fastCommoditySettingIndex.AboutToCreateGroups += fastCommoditySettingIndex_AboutToCreateGroups;

            this.fastCommoditySettingIndex.ShowGroups = true;
        }

        protected override void CommonControl_BindingComplete(object sender, BindingCompleteEventArgs e)
        {
            base.CommonControl_BindingComplete(sender, e);
            
            if (sender.Equals(this.bindingCommodityID) && this.combexCommodityID.SelectedItem != null)
            {
                CommodityBase commodityBase = (CommodityBase)this.combexCommodityID.SelectedItem;
                this.commoditySettingViewModel.CommodityName = commodityBase.Name;
                this.commoditySettingViewModel.CommodityCategoryName = commodityBase.CommodityCategoryName;
                this.commoditySettingViewModel.PackageSize = commodityBase.PackageSize;
                this.commoditySettingViewModel.PackageVolume = commodityBase.PackageVolume;
            }
        }

        private void fastCommoditySettingIndex_AboutToCreateGroups(object sender, CreateGroupsEventArgs e)
        {
            if (e.Groups != null && e.Groups.Count > 0)
            {
                foreach (OLVGroup olvGroup in e.Groups)
                {
                    olvGroup.TitleImage = "price-tag-32";
                    olvGroup.Subtitle = "Count: " + olvGroup.Contents.Count.ToString() + " Item(s)";
                }
            }
        }

        protected override Controllers.BaseController myController
        {
            get { return new CommoditySettingController(CommonNinject.Kernel.Get<ICommoditySettingService>(), this.commoditySettingViewModel); }
        }

        public override void Loading()
        {
            this.fastCommoditySettingIndex.SetObjects(this.commoditySettingAPIs.GetCommoditySettingIndexes());

            base.Loading();
        }

        protected override void DoAfterLoad()
        {
            base.DoAfterLoad();
            this.fastCommoditySettingIndex.Sort(this.olvCommodityCategoryName, SortOrder.Descending);
        }
    }
}

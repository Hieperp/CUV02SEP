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

using TotalSmartCoding.Controllers.Inventories;
using TotalCore.Repositories.Inventories;
using TotalSmartCoding.Controllers.APIs.Inventories;
using TotalCore.Services.Inventories;
using TotalSmartCoding.ViewModels.Inventories;
using TotalSmartCoding.Controllers.APIs.Commons;
using TotalCore.Repositories.Commons;
using TotalBase;
using TotalModel.Models;
using TotalDTO.Inventories;
using BrightIdeasSoftware;
using TotalSmartCoding.Libraries.StackedHeaders;


namespace TotalSmartCoding.Views.Inventories.GoodsReceipts
{
    public partial class GoodsReceiptDetailAvailables : BaseView
    {
        private CustomTabControl customTabBatch;

        private GoodsReceiptAPIs goodsReceiptAPIs;
        private GoodsReceiptDetailAvailableDTO goodsReceiptDetailAvailableDTO { get; set; }

        public GoodsReceiptDetailAvailables()
            : base()
        {
            InitializeComponent();


            this.toolstripChild = this.toolStripChildForm;

            this.goodsReceiptAPIs = new GoodsReceiptAPIs(CommonNinject.Kernel.Get<IGoodsReceiptAPIRepository>());

            this.goodsReceiptDetailAvailableDTO = CommonNinject.Kernel.Get<GoodsReceiptDetailAvailableDTO>();
            this.goodsReceiptDetailAvailableDTO.PropertyChanged += new PropertyChangedEventHandler(ModelDTO_PropertyChanged);
            this.baseDTO = this.goodsReceiptDetailAvailableDTO;
        }


        protected override void InitializeTabControl()
        {
            try
            {
                base.InitializeTabControl();

                this.customTabBatch = new CustomTabControl();

                this.customTabBatch.Font = this.fastAvailablePallets.Font;
                this.customTabBatch.DisplayStyle = TabStyle.VisualStudio;
                this.customTabBatch.DisplayStyleProvider.ImageAlign = ContentAlignment.MiddleLeft;

                this.customTabBatch.TabPages.Add("tabPendingPallets", "Pending pallets");
                this.customTabBatch.TabPages.Add("tabPendingCartons", "Pending cartons");
                this.customTabBatch.TabPages[0].Controls.Add(this.fastAvailablePallets);
                this.customTabBatch.TabPages[1].Controls.Add(this.fastAvailableCartons);


                this.customTabBatch.Dock = DockStyle.Fill;
                this.fastAvailablePallets.Dock = DockStyle.Fill;
                this.fastAvailableCartons.Dock = DockStyle.Fill;
                this.panelMaster.Controls.Add(this.customTabBatch);

            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }


        protected override void InitializeCommonControlBinding()
        {
            base.InitializeCommonControlBinding();

            //this.fastGoodsReceiptIndex.AboutToCreateGroups += fastGoodsReceiptIndex_AboutToCreateGroups;

            //this.fastGoodsReceiptIndex.ShowGroups = true;
            //this.olvApproved.Renderer = new MappedImageRenderer(new Object[] { false, Resources.Placeholder16 });
        }

        private void fastGoodsReceiptIndex_AboutToCreateGroups(object sender, CreateGroupsEventArgs e)
        {
            if (e.Groups != null && e.Groups.Count > 0)
            {
                foreach (OLVGroup olvGroup in e.Groups)
                {
                    olvGroup.TitleImage = "Storage32";
                    olvGroup.Subtitle = "List count: " + olvGroup.Contents.Count.ToString();
                }
            }
        }


        public override void Loading()
        {
            List<GoodsReceiptDetailAvailable> goodsReceiptDetailAvailables = goodsReceiptAPIs.GetGoodsReceiptDetailAvailables(ContextAttributes.User.LocationID, null, null, null, null, null, false);

            this.fastAvailablePallets.SetObjects(goodsReceiptDetailAvailables.Where(w => w.PalletID != null));
            this.fastAvailableCartons.SetObjects(goodsReceiptDetailAvailables.Where(w => w.CartonID != null));

            this.ShowRowCount();
        }

        protected override void DoAfterLoad()
        {
            base.DoAfterLoad();
            //this.fastGoodsReceiptIndex.Sort(this.olvEntryDate, SortOrder.Descending);
        }

        public override void ApplyFilter(string filterTexts)
        {
            OLVHelpers.ApplyFilters(this.fastAvailablePallets, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            OLVHelpers.ApplyFilters(this.fastAvailableCartons, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));

            this.ShowRowCount();
        }

        private void ShowRowCount()
        {
            this.customTabBatch.TabPages[0].Text = "Pending " + this.fastAvailablePallets.GetItemCount().ToString("N0") + " pallet" + (this.fastAvailablePallets.GetItemCount() > 1 ? "s      " : "      ");
            this.customTabBatch.TabPages[1].Text = "Pending " + this.fastAvailableCartons.GetItemCount().ToString("N0") + " carton" + (this.fastAvailableCartons.GetItemCount() > 1 ? "s      " : "      ");
        }
    }
}

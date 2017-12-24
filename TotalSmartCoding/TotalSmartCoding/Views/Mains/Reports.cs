using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Ninject;


using TotalSmartCoding.Views.Mains;


using TotalSmartCoding.Libraries;
using TotalSmartCoding.Libraries.Helpers;

using TotalCore.Repositories.Inventories;
using TotalSmartCoding.Controllers.APIs.Inventories;
using TotalBase;
using TotalModel.Models;
using TotalSmartCoding.ViewModels.Helpers;
using TotalSmartCoding.ViewModels.Inventories;
using TotalSmartCoding.Controllers.APIs.Commons;
using TotalCore.Repositories.Commons;
using BrightIdeasSoftware;
using TotalBase.Enums;


namespace TotalSmartCoding.Views.Mains
{
    public partial class Reports : BaseView
    {
        private CustomTabControl customTabBatch;

        public Reports()
            : base()
        {
            InitializeComponent();

            this.toolstripChild = this.toolStripChildForm;

            this.baseDTO = new GoodsReceiptDetailAvailableViewModel(); ;
        }

        protected override void InitializeTabControl()
        {
            try
            {
                base.InitializeTabControl();

                this.customTabBatch = new CustomTabControl();

                this.customTabBatch.Font = this.treeWarehouseID.Font;
                this.customTabBatch.DisplayStyle = TabStyle.VisualStudio;
                this.customTabBatch.DisplayStyleProvider.ImageAlign = ContentAlignment.MiddleLeft;

                this.customTabBatch.TabPages.Add("tabPendingPallets", "Pending pallets");
                this.customTabBatch.TabPages.Add("tabPendingCartons", "Pending cartons");
                this.customTabBatch.TabPages[0].Controls.Add(this.treeWarehouseID);
                this.customTabBatch.TabPages[1].Controls.Add(this.treeCommodityID);


                this.customTabBatch.Dock = DockStyle.Fill;
                this.treeWarehouseID.Dock = DockStyle.Fill;
                this.treeCommodityID.Dock = DockStyle.Fill;
                this.Controls.Add(this.customTabBatch);
            }
            catch (Exception exception)
            {
                ExceptionHandlers.ShowExceptionMessageBox(this, exception);
            }
        }

        private IList<WarehouseTree> warehouseTrees;
        private IList<CommodityTree> commodityTrees;

        protected override void InitializeCommonControlBinding()
        {
            base.InitializeCommonControlBinding();

            this.treeWarehouseID.RootKeyValue = 0;
            this.treeCommodityID.RootKeyValue = 0;

            WarehouseAPIs warehouseAPIs = new WarehouseAPIs(CommonNinject.Kernel.Get<IWarehouseAPIRepository>());
            this.warehouseTrees = warehouseAPIs.GetWarehouseTrees();
            this.treeWarehouseID.DataSource = new BindingSource(this.warehouseTrees, "");

            CommodityAPIs commodityAPIs = new CommodityAPIs(CommonNinject.Kernel.Get<ICommodityAPIRepository>());
            this.commodityTrees = commodityAPIs.GetCommodityTrees();
            this.treeCommodityID.DataSource = new BindingSource(this.commodityTrees, "");

            if (this.treeWarehouseID.GetModelObject(0) != null) this.treeWarehouseID.Expand(this.treeWarehouseID.GetModelObject(0));
            if (this.treeCommodityID.GetModelObject(0) != null) this.treeCommodityID.Expand(this.treeCommodityID.GetModelObject(0));
        }

        public override void ApplyFilter(string filterTexts)
        {
            IList<WarehouseTree> warehouseTreesx = this.warehouseTrees;
            OLVHelpers.ApplyFilters(this.treeWarehouseID, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
            OLVHelpers.ApplyFilters(this.treeCommodityID, filterTexts.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries));
        }





        private void GetFilterParameters(IEnumerable<IFilterTree> filterTrees, FilterParameter[] filterParameters)
        {
            if (filterTrees.Count() > 0 && filterParameters.Count() > 0)
            {
                IList<IFilterTree> selectedFilterTrees = filterTrees.Where(w => w.Selected == true).ToList();
                if (selectedFilterTrees.Count > 0)
                {
                    if (selectedFilterTrees.Where(w => w.NodeID == GlobalEnums.RootNode).FirstOrDefault() != null) return;

                    IList<IFilterTree> effectedFilterTrees = null;
                    foreach (FilterParameter filterParameter in filterParameters)
                    {//WE SHOULD SET THE ORDER OF ELEMENT IN filterParameters BY THE HIERARCHY STRUCTURE. THIS IS VERY IMPORTANNT: FOR EXCAMPLE: filterParameters[0] = LocationID, filterParameters[1] = WarehouseID
                        IEnumerable<IFilterTree> enumerableFilterTree = selectedFilterTrees.Where(w => w.ParameterName == filterParameter.ParameterName);
                        if (effectedFilterTrees != null)
                        {//BY THE ORDER OF THE HIERARCHY STRUCTURE, WE CAN USE THE QUERY BELLOW TO EXCLUSIVE (ORMIT) THE CHILD THAT ITS ANCESTORID EXIST IN THE PARENT LIST
                            List<int?> ancestorIDs = effectedFilterTrees.Select(n => n.PrimaryID).ToList();
                            enumerableFilterTree = enumerableFilterTree.Where(w => !ancestorIDs.Contains(w.AncestorID));
                        }
                        effectedFilterTrees = enumerableFilterTree.ToList();

                        filterParameter.PrimaryIDs = string.Join(",", effectedFilterTrees.Select(s => s.PrimaryID));
                        filterParameter.Codes = string.Join(",", effectedFilterTrees.Select(s => s.Code));
                        filterParameter.Names = string.Join(",", effectedFilterTrees.Select(s => s.Name));
                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FilterParameter locationID = new FilterParameter("LocationID");
            FilterParameter warehouseID = new FilterParameter("WarehouseID");

            this.GetFilterParameters(this.warehouseTrees.Cast<IFilterTree>(), new FilterParameter[] { locationID, warehouseID });

            string i = locationID.PrimaryIDs + warehouseID.PrimaryIDs;
        }
    }

    public class FilterParameter
    {
        public string PrimaryIDs { get; set; }
        
        public string Codes { get; set; }
        public string Names { get; set; }

        public string ParameterName { get; set; }
        public FilterParameter(string parameterName) { this.ParameterName = parameterName; }
    }
}

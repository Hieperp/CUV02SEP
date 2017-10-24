using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Equin.ApplicationFramework;

using TotalModel;
using TotalBase.Enums;
using TotalDTO.Helpers;
using TotalDTO.Commons;
using TotalModel.Helpers;
using TotalBase;

namespace TotalDTO.Inventories
{
    public class GoodsIssuePrimitiveDTO : QuantityDTO<GoodsIssueDetailDTO>, IPrimitiveEntity, IPrimitiveDTO
    {
        public override GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.GoodsIssue; } }

        public override int GetID() { return this.GoodsIssueID; }
        public void SetID(int id) { this.GoodsIssueID = id; }

        private int goodsIssueID;
        [DefaultValue(0)]
        public int GoodsIssueID
        {
            get { return this.goodsIssueID; }
            set { ApplyPropertyChange<GoodsIssuePrimitiveDTO, int>(ref this.goodsIssueID, o => o.GoodsIssueID, value); }
        }


        private Nullable<int> deliveryAdviceID;
        [DefaultValue(null)]
        public Nullable<int> DeliveryAdviceID
        {
            get { return this.deliveryAdviceID; }
            set { ApplyPropertyChange<GoodsIssuePrimitiveDTO, Nullable<int>>(ref this.deliveryAdviceID, o => o.DeliveryAdviceID, value); }
        }
        [DefaultValue(null)]
        public Nullable<DateTime> DeliveryAdviceEntryDate { get; set; }
        [DefaultValue(null)]
        public string DeliveryAdviceReference { get; set; }
        [DefaultValue(null)]
        public string DeliveryAdviceReferences { get; set; }



        private Nullable<int> transferOrderID;
        [DefaultValue(null)]
        public Nullable<int> TransferOrderID
        {
            get { return this.transferOrderID; }
            set { ApplyPropertyChange<GoodsIssuePrimitiveDTO, Nullable<int>>(ref this.transferOrderID, o => o.TransferOrderID, value); }
        }
        [DefaultValue(null)]
        public Nullable<DateTime> TransferOrderEntryDate { get; set; }
        [DefaultValue(null)]
        public string TransferOrderReference { get; set; }


        private Nullable<int> customerID;
        [DefaultValue(null)]
        public Nullable<int> CustomerID
        {
            get { return this.customerID; }
            set { ApplyPropertyChange<GoodsIssuePrimitiveDTO, Nullable<int>>(ref this.customerID, o => o.CustomerID, value); }
        }
        private string customerName;
        [DefaultValue(null)]
        public string CustomerName
        {
            get { return this.customerName; }
            set { ApplyPropertyChange<GoodsIssueDTO, string>(ref this.customerName, o => o.CustomerName, value); }
        }


        private Nullable<int> warehouseID;
        [DefaultValue(null)]
        public Nullable<int> WarehouseID
        {
            get { return this.warehouseID; }
            set { ApplyPropertyChange<GoodsIssuePrimitiveDTO, Nullable<int>>(ref this.warehouseID, o => o.WarehouseID, value); }
        }
        private string warehouseName;
        [DefaultValue(null)]
        public string WarehouseName
        {
            get { return this.warehouseName; }
            set { ApplyPropertyChange<GoodsIssueDTO, string>(ref this.warehouseName, o => o.WarehouseName, value); }
        }

        private Nullable<int> warehouseReceiptID;
        [DefaultValue(null)]
        public Nullable<int> WarehouseReceiptID
        {
            get { return this.warehouseReceiptID; }
            set { ApplyPropertyChange<GoodsIssuePrimitiveDTO, Nullable<int>>(ref this.warehouseReceiptID, o => o.WarehouseReceiptID, value); }
        }
        private string warehouseReceiptName;
        [DefaultValue(null)]
        public string WarehouseReceiptName
        {
            get { return this.warehouseReceiptName; }
            set { ApplyPropertyChange<GoodsIssueDTO, string>(ref this.warehouseReceiptName, o => o.WarehouseReceiptName, value); }
        }


        private Nullable<int> forkliftDriverID;
        //[DefaultValue(null)]
        public Nullable<int> ForkliftDriverID
        {
            get { return this.forkliftDriverID; }
            set { ApplyPropertyChange<PickupPrimitiveDTO, Nullable<int>>(ref this.forkliftDriverID, o => o.ForkliftDriverID, value); }
        }

        private int storekeeperID;
        //[DefaultValue(null)]
        public int StorekeeperID
        {
            get { return this.storekeeperID; }
            set { ApplyPropertyChange<GoodsIssuePrimitiveDTO, int>(ref this.storekeeperID, o => o.StorekeeperID, value); }
        }

        private string vehicle;
        [DefaultValue(null)]
        public string Vehicle
        {
            get { return this.vehicle; }
            set { ApplyPropertyChange<GoodsIssuePrimitiveDTO, string>(ref this.vehicle, o => o.Vehicle, value); }
        }

        public override int PreparedPersonID { get { return 1; } }

        public override string Caption
        {
            get { return "D.A: " + (this.DeliveryAdviceID != null ? this.DeliveryAdviceReference + ", on " + this.DeliveryAdviceEntryDate.ToString() : this.DeliveryAdviceReferences) + ", " + (this.CustomerName != null ? "Customer: " + this.CustomerName.Substring(0, this.CustomerName.Length > 26 ? 25 : this.CustomerName.Length) + ", " : "") + "Issue: " + (this.Reference != null ? this.Reference : "...") + "             Total Quantity: " + this.TotalQuantity.ToString() + ",    Total Volume: " + this.TotalLineVolume.ToString("N2"); }
        }

        public override void PerformPresaveRule()
        {
            base.PerformPresaveRule();

            string deliveryAdviceReferences = "";
            this.DtoDetails().ToList().ForEach(e => { e.CustomerID = this.CustomerID; e.WarehouseReceiptID = this.WarehouseReceiptID; if (deliveryAdviceReferences.IndexOf(e.DeliveryAdviceReference) < 0) deliveryAdviceReferences = deliveryAdviceReferences + (deliveryAdviceReferences != "" ? ", " : "") + e.DeliveryAdviceReference; });
            this.DeliveryAdviceReferences = deliveryAdviceReferences;
        }

        protected override List<ValidationRule> CreateRules()
        {
            List<ValidationRule> validationRules = base.CreateRules();
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<GoodsIssuePrimitiveDTO>(p => p.CustomerID), "Vui lòng chọn khách hàng.", delegate { return (this.CustomerID != null && this.CustomerID > 0); }));
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<GoodsIssuePrimitiveDTO>(p => p.ForkliftDriverID), "Vui lòng chọn tài xếxyz123.", delegate { return (this.ForkliftDriverID != null && this.ForkliftDriverID > 0); }));
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<GoodsIssuePrimitiveDTO>(p => p.StorekeeperID), "Vui lòng chọn nhân viên kho.", delegate { return (this.StorekeeperID != null && this.StorekeeperID > 0); }));

            return validationRules;
        }
    }

    public class GoodsIssueDTO : GoodsIssuePrimitiveDTO, IBaseDetailEntity<GoodsIssueDetailDTO>
    {
        public GoodsIssueDTO()
        {
            this.GoodsIssueViewDetails = new BindingList<GoodsIssueDetailDTO>();






            this.PackDetails = new BindingListView<GoodsIssueDetailDTO>(this.GoodsIssueViewDetails);
            this.CartonDetails = new BindingListView<GoodsIssueDetailDTO>(this.GoodsIssueViewDetails);
            this.PalletDetails = new BindingListView<GoodsIssueDetailDTO>(this.GoodsIssueViewDetails);

            this.PackDetails.ApplyFilter(f => f.PackID != null);
            this.CartonDetails.ApplyFilter(f => f.CartonID != null);
            this.PalletDetails.ApplyFilter(f => f.PalletID != null);
        }


        public BindingList<GoodsIssueDetailDTO> GoodsIssueViewDetails { get; set; }
        public BindingList<GoodsIssueDetailDTO> ViewDetails { get { return this.GoodsIssueViewDetails; } set { this.GoodsIssueViewDetails = value; } }

        public ICollection<GoodsIssueDetailDTO> GetDetails() { return this.GoodsIssueViewDetails; }

        protected override IEnumerable<GoodsIssueDetailDTO> DtoDetails() { return this.GoodsIssueViewDetails; }






        public BindingListView<GoodsIssueDetailDTO> PackDetails { get; private set; }
        public BindingListView<GoodsIssueDetailDTO> CartonDetails { get; private set; }
        public BindingListView<GoodsIssueDetailDTO> PalletDetails { get; private set; }
    }

}

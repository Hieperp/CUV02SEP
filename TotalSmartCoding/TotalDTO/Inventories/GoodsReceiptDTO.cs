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
    public class GoodsReceiptPrimitiveDTO : QuantityDTO<GoodsReceiptDetailDTO>, IPrimitiveEntity, IPrimitiveDTO
    {
        public override GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.GoodsReceipt; } }

        public override int GetID() { return this.GoodsReceiptID; }
        public void SetID(int id) { this.GoodsReceiptID = id; }

        private int goodsReceiptID;
        [DefaultValue(0)]
        public int GoodsReceiptID
        {
            get { return this.goodsReceiptID; }
            set { ApplyPropertyChange<GoodsReceiptPrimitiveDTO, int>(ref this.goodsReceiptID, o => o.GoodsReceiptID, value); }
        }

        private int goodsReceiptTypeID;
        [DefaultValue(null)]
        public int GoodsReceiptTypeID
        {
            get { return this.goodsReceiptTypeID; }
            set { ApplyPropertyChange<GoodsReceiptPrimitiveDTO, int>(ref this.goodsReceiptTypeID, o => o.GoodsReceiptTypeID, value); }
        }
        private string goodsReceiptTypeName;
        [DefaultValue("")]
        public string GoodsReceiptTypeName
        {
            get { return this.goodsReceiptTypeName; }
            set { ApplyPropertyChange<GoodsReceiptDTO, string>(ref this.goodsReceiptTypeName, o => o.GoodsReceiptTypeName, value); }
        }



        private Nullable<int> pickupID;
        [DefaultValue(null)]
        public Nullable<int> PickupID
        {
            get { return this.pickupID; }
            set { ApplyPropertyChange<GoodsReceiptPrimitiveDTO, Nullable<int>>(ref this.pickupID, o => o.PickupID, value); }
        }
        public string PickupReferences { get; set; }


        public bool HasPickup { get; set; }

        private int warehouseID;
        [DefaultValue(null)]
        public int WarehouseID
        {
            get { return this.warehouseID; }
            set { ApplyPropertyChange<GoodsReceiptPrimitiveDTO, int>(ref this.warehouseID, o => o.WarehouseID, value); }
        }
        private string warehouseName;
        [DefaultValue("")]
        public string WarehouseName
        {
            get { return this.warehouseName; }
            set { ApplyPropertyChange<GoodsReceiptDTO, string>(ref this.warehouseName, o => o.WarehouseName, value); }
        }


        private int storekeeperID;
        //[DefaultValue(null)]
        public int StorekeeperID
        {
            get { return this.storekeeperID; }
            set { ApplyPropertyChange<GoodsReceiptPrimitiveDTO, int>(ref this.storekeeperID, o => o.StorekeeperID, value); }
        }


        public override int PreparedPersonID { get { return 1; } }


        public override string Caption
        {
            get { return this.GoodsReceiptTypeName + ", " + this.WarehouseName + ", " + this.EntryDate.ToString() + "             Pallet count: " + this.TotalPalletCounts.ToString() + ",    Quantity: " + this.TotalQuantity.ToString() + ",    Volume: " + this.TotalLineVolume.ToString("N2"); }
        }

        public override void PerformPresaveRule()
        {
            base.PerformPresaveRule();

            string pickupReferences = "";
            this.DtoDetails().ToList().ForEach(e => { e.WarehouseID = this.WarehouseID; if (this.HasPickup && pickupReferences.IndexOf(e.PickupReference) < 0) pickupReferences = pickupReferences + (pickupReferences != "" ? ", " : "") + e.PickupReference; });
            this.PickupReferences = pickupReferences;
        }
    }

    public class GoodsReceiptDTO : GoodsReceiptPrimitiveDTO, IBaseDetailEntity<GoodsReceiptDetailDTO>
    {
        public GoodsReceiptDTO()
        {
            this.GoodsReceiptViewDetails = new BindingList<GoodsReceiptDetailDTO>();
            





            this.PackDetails = new BindingListView<GoodsReceiptDetailDTO>(this.GoodsReceiptViewDetails);
            this.CartonDetails = new BindingListView<GoodsReceiptDetailDTO>(this.GoodsReceiptViewDetails);
            this.PalletDetails = new BindingListView<GoodsReceiptDetailDTO>(this.GoodsReceiptViewDetails);

            this.PackDetails.ApplyFilter(f => f.PackID != null);
            this.CartonDetails.ApplyFilter(f => f.CartonID != null);
            this.PalletDetails.ApplyFilter(f => f.PalletID != null);
        }


        public BindingList<GoodsReceiptDetailDTO> GoodsReceiptViewDetails { get; set; }
        public BindingList<GoodsReceiptDetailDTO> ViewDetails { get { return this.GoodsReceiptViewDetails; } set { this.GoodsReceiptViewDetails = value; } }

        public ICollection<GoodsReceiptDetailDTO> GetDetails() { return this.GoodsReceiptViewDetails; }

        protected override IEnumerable<GoodsReceiptDetailDTO> DtoDetails() { return this.GoodsReceiptViewDetails; }






        public BindingListView<GoodsReceiptDetailDTO> PackDetails { get; private set; }
        public BindingListView<GoodsReceiptDetailDTO> CartonDetails { get; private set; }
        public BindingListView<GoodsReceiptDetailDTO> PalletDetails { get; private set; }



        protected override List<ValidationRule> CreateRules()
        {
            List<ValidationRule> validationRules = base.CreateRules();
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<PickupDTO>(p => p.WarehouseID), "Vui lòng chọn kho.", delegate { return (this.WarehouseID != null && this.WarehouseID > 0); }));
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<PickupDTO>(p => p.StorekeeperID), "Vui lòng chọn nhân viên kho.", delegate { return (this.StorekeeperID != null && this.StorekeeperID > 0); }));

            return validationRules;

        }
    }

}

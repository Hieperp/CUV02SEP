﻿using System;
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
    public class WarehouseAdjustmentPrimitiveDTO : QuantityDTO<WarehouseAdjustmentDetailDTO>, IPrimitiveEntity, IPrimitiveDTO
    {
        public override GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.WarehouseAdjustment; } }

        public override int GetID() { return this.WarehouseAdjustmentID; }
        public void SetID(int id) { this.WarehouseAdjustmentID = id; }

        private int warehouseAdjustmentID;
        [DefaultValue(0)]
        public int WarehouseAdjustmentID
        {
            get { return this.warehouseAdjustmentID; }
            set { ApplyPropertyChange<WarehouseAdjustmentPrimitiveDTO, int>(ref this.warehouseAdjustmentID, o => o.WarehouseAdjustmentID, value); }
        }




        private int warehouseID;
        [DefaultValue(null)]
        public int WarehouseID
        {
            get { return this.warehouseID; }
            set { ApplyPropertyChange<GoodsReceiptPrimitiveDTO, int>(ref this.warehouseID, o => o.WarehouseID, value); }
        }
        private string warehouseName;
        [DefaultValue(null)]
        public string WarehouseName
        {
            get { return this.warehouseName; }
            set { ApplyPropertyChange<GoodsReceiptDTO, string>(ref this.warehouseName, o => o.WarehouseName, value); }
        }


        private int warehouseAdjustmentTypeID;
        [DefaultValue(null)]
        public int WarehouseAdjustmentTypeID
        {
            get { return this.warehouseAdjustmentTypeID; }
            set { ApplyPropertyChange<WarehouseAdjustmentPrimitiveDTO, int>(ref this.warehouseAdjustmentTypeID, o => o.WarehouseAdjustmentTypeID, value); }
        }
        private string warehouseAdjustmentTypeName;
        [DefaultValue(null)]
        public string WarehouseAdjustmentTypeName
        {
            get { return this.warehouseAdjustmentTypeName; }
            set { ApplyPropertyChange<WarehouseAdjustmentDTO, string>(ref this.warehouseAdjustmentTypeName, o => o.WarehouseAdjustmentTypeName, value); }
        }


        private int storekeeperID;
        [DefaultValue(1)]
        public int StorekeeperID
        {
            get { return this.storekeeperID; }
            set { ApplyPropertyChange<WarehouseAdjustmentPrimitiveDTO, int>(ref this.storekeeperID, o => o.StorekeeperID, value); }
        }


        public override int PreparedPersonID { get { return 1; } }

        public override void PerformPresaveRule()
        {
            base.PerformPresaveRule();

            this.DtoDetails().ToList().ForEach(e => { e.WarehouseID = this.WarehouseID; e.WarehouseAdjustmentTypeID = this.WarehouseAdjustmentTypeID; });
        }

        protected override List<ValidationRule> CreateRules()
        {
            List<ValidationRule> validationRules = base.CreateRules();
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<WarehouseAdjustmentPrimitiveDTO>(p => p.WarehouseID), "Vui lòng chọn kho.", delegate { return (this.WarehouseID != null && this.WarehouseID > 0); }));
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<WarehouseAdjustmentPrimitiveDTO>(p => p.WarehouseAdjustmentTypeID), "Vui lòng chọn tài xế.", delegate { return (this.WarehouseAdjustmentTypeID != null && this.WarehouseAdjustmentTypeID > 0); }));
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<WarehouseAdjustmentPrimitiveDTO>(p => p.StorekeeperID), "Vui lòng chọn nhân viên kho.", delegate { return (this.StorekeeperID != null && this.StorekeeperID > 0); }));

            return validationRules;

        }

    }

    public class WarehouseAdjustmentDTO : WarehouseAdjustmentPrimitiveDTO, IBaseDetailEntity<WarehouseAdjustmentDetailDTO>
    {
        public WarehouseAdjustmentDTO()
        {
            this.WarehouseAdjustmentViewDetails = new BindingList<WarehouseAdjustmentDetailDTO>();






            this.PackDetails = new BindingListView<WarehouseAdjustmentDetailDTO>(this.WarehouseAdjustmentViewDetails);
            this.CartonDetails = new BindingListView<WarehouseAdjustmentDetailDTO>(this.WarehouseAdjustmentViewDetails);
            this.PalletDetails = new BindingListView<WarehouseAdjustmentDetailDTO>(this.WarehouseAdjustmentViewDetails);

            this.PackDetails.ApplyFilter(f => f.PackID != null);
            this.CartonDetails.ApplyFilter(f => f.CartonID != null);
            this.PalletDetails.ApplyFilter(f => f.PalletID != null);
        }


        public BindingList<WarehouseAdjustmentDetailDTO> WarehouseAdjustmentViewDetails { get; set; }
        public BindingList<WarehouseAdjustmentDetailDTO> ViewDetails { get { return this.WarehouseAdjustmentViewDetails; } set { this.WarehouseAdjustmentViewDetails = value; } }

        public ICollection<WarehouseAdjustmentDetailDTO> GetDetails() { return this.WarehouseAdjustmentViewDetails; }

        protected override IEnumerable<WarehouseAdjustmentDetailDTO> DtoDetails() { return this.WarehouseAdjustmentViewDetails; }






        public BindingListView<WarehouseAdjustmentDetailDTO> PackDetails { get; private set; }
        public BindingListView<WarehouseAdjustmentDetailDTO> CartonDetails { get; private set; }
        public BindingListView<WarehouseAdjustmentDetailDTO> PalletDetails { get; private set; }

    }

}

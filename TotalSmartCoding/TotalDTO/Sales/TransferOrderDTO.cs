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

namespace TotalDTO.Sales
{
    public class TransferOrderPrimitiveDTO : QuantityDTO<TransferOrderDetailDTO>, IPrimitiveEntity, IPrimitiveDTO
    {
        public override GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.TransferOrder; } }

        public TransferOrderPrimitiveDTO() { this.DeliveryDate = DateTime.Now; }

        public override void Init()
        {
            base.Init();
            this.DeliveryDate = DateTime.Now;
        }

        public override int GetID() { return this.TransferOrderID; }
        public void SetID(int id) { this.TransferOrderID = id; }

        private int salesOrderID;
        [DefaultValue(0)]
        public int TransferOrderID
        {
            get { return this.salesOrderID; }
            set { ApplyPropertyChange<TransferOrderPrimitiveDTO, int>(ref this.salesOrderID, o => o.TransferOrderID, value); }
        }

        private Nullable<int> warehouseID;
        [DefaultValue(null)]
        public Nullable<int> WarehouseID
        {
            get { return this.warehouseID; }
            set { ApplyPropertyChange<TransferOrderPrimitiveDTO, Nullable<int>>(ref this.warehouseID, o => o.WarehouseID, value); }
        }
        private string warehouseName;
        [DefaultValue(null)]
        public string WarehouseName
        {
            get { return this.warehouseName; }
            set { ApplyPropertyChange<TransferOrderDTO, string>(ref this.warehouseName, o => o.WarehouseName, value, false); }
        }

        private Nullable<int> warehouseReceiptID;
        [DefaultValue(null)]
        public Nullable<int> WarehouseReceiptID
        {
            get { return this.warehouseReceiptID; }
            set { ApplyPropertyChange<TransferOrderPrimitiveDTO, Nullable<int>>(ref this.warehouseReceiptID, o => o.WarehouseReceiptID, value); }
        }
        private string warehouseReceiptName;
        [DefaultValue(null)]
        public string WarehouseReceiptName
        {
            get { return this.warehouseReceiptName; }
            set { ApplyPropertyChange<TransferOrderDTO, string>(ref this.warehouseReceiptName, o => o.WarehouseReceiptName, value, false); }
        }

        private string transferJobs;
        [DefaultValue(null)]
        public string TransferJobs
        {
            get { return this.transferJobs; }
            set { ApplyPropertyChange<TransferOrderDTO, string>(ref this.transferJobs, o => o.TransferJobs, value); }
        }

        private string voucherCode;
        [DefaultValue(null)]
        public string VoucherCode
        {
            get { return this.voucherCode; }
            set { ApplyPropertyChange<TransferOrderDTO, string>(ref this.voucherCode, o => o.VoucherCode, value); }
        }

        private Nullable<DateTime> deliveryDate;
        public Nullable<DateTime> DeliveryDate
        {
            get { return this.deliveryDate; }
            set { ApplyPropertyChange<TransferOrderPrimitiveDTO, Nullable<DateTime>>(ref this.deliveryDate, o => o.DeliveryDate, value); }
        }

        private Nullable<int> salespersonID;
        [DefaultValue(null)]
        public Nullable<int> SalespersonID
        {
            get { return this.salespersonID; }
            set { ApplyPropertyChange<TransferOrderPrimitiveDTO, Nullable<int>>(ref this.salespersonID, o => o.SalespersonID, value); }
        }

        

        public override string Caption
        {
            get { return (this.WarehouseName != null ? "From: " : "") + this.WarehouseName + (this.WarehouseName != null ? " to: " : "") + this.WarehouseReceiptName + (this.TransferJobs != null && this.TransferJobs != "" ? ", for jobs: " : "") + this.TransferJobs + (this.VoucherCode != null && this.VoucherCode != "" ? ", voucher: " : "") + this.VoucherCode + "             Total Quantity: " + this.TotalQuantity.ToString("N0") + ",    Total Volume: " + this.TotalLineVolume.ToString("N2"); }
        }

        public override void PerformPresaveRule()
        {
            base.PerformPresaveRule();

            this.DtoDetails().ToList().ForEach(e => { e.WarehouseID = this.WarehouseID; e.WarehouseReceiptID = this.WarehouseReceiptID; });
        }
    }

    public class TransferOrderDTO : TransferOrderPrimitiveDTO, IBaseDetailEntity<TransferOrderDetailDTO>
    {
        public TransferOrderDTO()
        {
            this.TransferOrderViewDetails = new BindingList<TransferOrderDetailDTO>();
        }


        public BindingList<TransferOrderDetailDTO> TransferOrderViewDetails { get; set; }
        public BindingList<TransferOrderDetailDTO> ViewDetails { get { return this.TransferOrderViewDetails; } set { this.TransferOrderViewDetails = value; } }

        public ICollection<TransferOrderDetailDTO> GetDetails() { return this.TransferOrderViewDetails; }

        protected override IEnumerable<TransferOrderDetailDTO> DtoDetails() { return this.TransferOrderViewDetails; }





        public bool HasOptionBatches
        {
            get { return this.DtoDetails().Where(w => w.BatchID != null).Count() > 0; }
        }

        protected override List<ValidationRule> CreateRules()
        {
            List<ValidationRule> validationRules = base.CreateRules();
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<TransferOrderDTO>(p => p.WarehouseID), "Vui lòng chọn kho xuất.", delegate { return (this.WarehouseID != null && this.WarehouseID > 0); }));
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<TransferOrderDTO>(p => p.WarehouseReceiptID), "Vui lòng chọn kho nhập.", delegate { return (this.WarehouseReceiptID != null && this.WarehouseReceiptID > 0); }));
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<TransferOrderDTO>(p => p.SalespersonID), "Vui lòng chọn người yêu cầu chuyển kho.", delegate { return (this.SalespersonID != null && this.SalespersonID > 0); }));

            return validationRules;
        }
    }

}

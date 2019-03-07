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

namespace TotalDTO.Sales
{
    public class SalesReturnPrimitiveDTO : QuantityDTO<SalesReturnDetailDTO>, IPrimitiveEntity, IPrimitiveDTO
    {
        public override GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.SalesReturns; } }

        public SalesReturnPrimitiveDTO() { this.Initialize(); }

        public override void Init()
        {
            base.Init();
            this.Initialize();
        }

        private void Initialize() { this.VoucherDate = DateTime.Now; }

        public override int GetID() { return this.SalesReturnID; }
        public void SetID(int id) { this.SalesReturnID = id; }

        private int salesReturnID;
        [DefaultValue(0)]
        public int SalesReturnID
        {
            get { return this.salesReturnID; }
            set { ApplyPropertyChange<SalesReturnPrimitiveDTO, int>(ref this.salesReturnID, o => o.SalesReturnID, value); }
        }

        private Nullable<int> goodsIssueID;
        [DefaultValue(null)]
        public Nullable<int> GoodsIssueID
        {
            get { return this.goodsIssueID; }
            set { ApplyPropertyChange<SalesReturnPrimitiveDTO, Nullable<int>>(ref this.goodsIssueID, o => o.GoodsIssueID, value); }
        }
        [DefaultValue(null)]
        public Nullable<DateTime> GoodsIssueEntryDate { get; set; }
        [DefaultValue(null)]
        public string GoodsIssueReference { get; set; }
        [DefaultValue(null)]
        public string GoodsIssueReferences { get; set; }

        private string voucherCode;
        [DefaultValue(null)]
        public string VoucherCode
        {
            get { return this.voucherCode; }
            set { ApplyPropertyChange<SalesReturnPrimitiveDTO, string>(ref this.voucherCode, o => o.VoucherCode, value); }
        }

        private Nullable<DateTime> voucherDate;
        public Nullable<DateTime> VoucherDate
        {
            get { return this.voucherDate; }
            set { ApplyPropertyChange<SalesReturnPrimitiveDTO, Nullable<DateTime>>(ref this.voucherDate, o => o.VoucherDate, value); }
        }

        private Nullable<int> customerID;
        [DefaultValue(null)]
        public Nullable<int> CustomerID
        {
            get { return this.customerID; }
            set { ApplyPropertyChange<SalesReturnPrimitiveDTO, Nullable<int>>(ref this.customerID, o => o.CustomerID, value); }
        }
        private string customerName;
        [DefaultValue(null)]
        public string CustomerName
        {
            get { return this.customerName; }
            set { ApplyPropertyChange<SalesReturnPrimitiveDTO, string>(ref this.customerName, o => o.CustomerName, value, false); }
        }


        private Nullable<int> receiverID;
        [DefaultValue(null)]
        public Nullable<int> ReceiverID
        {
            get { return this.receiverID; }
            set { ApplyPropertyChange<SalesReturnPrimitiveDTO, Nullable<int>>(ref this.receiverID, o => o.ReceiverID, value); }
        }
        private string receiverName;
        [DefaultValue(null)]
        public string ReceiverName
        {
            get { return this.receiverName; }
            set { ApplyPropertyChange<SalesReturnPrimitiveDTO, string>(ref this.receiverName, o => o.ReceiverName, value, false); }
        }

        private string receiverTemp;
        [DefaultValue(null)]
        public string ReceiverTemp
        {
            get { return this.receiverTemp; }
            set { ApplyPropertyChange<SalesOrderDTO, string>(ref this.receiverTemp, o => o.ReceiverTemp, value, false); }
        }

        private int salespersonID;
        [DefaultValue(null)]
        public int SalespersonID
        {
            get { return this.salespersonID; }
            set { ApplyPropertyChange<SalesReturnPrimitiveDTO, int>(ref this.salespersonID, o => o.SalespersonID, value); }
        }

        private Nullable<int> teamID;
        [DefaultValue(null)]
        public Nullable<int> TeamID
        {
            get { return this.teamID; }
            set { ApplyPropertyChange<SalesOrderPrimitiveDTO, Nullable<int>>(ref this.teamID, o => o.TeamID, value); }
        }

        private Nullable<int> warehouseID;
        [DefaultValue(null)]
        public Nullable<int> WarehouseID
        {
            get { return this.warehouseID; }
            set { ApplyPropertyChange<SalesReturnPrimitiveDTO, Nullable<int>>(ref this.warehouseID, o => o.WarehouseID, value); }
        }
        private string warehouseName;
        [DefaultValue(null)]
        public string WarehouseName
        {
            get { return this.warehouseName; }
            set { ApplyPropertyChange<SalesReturnPrimitiveDTO, string>(ref this.warehouseName, o => o.WarehouseName, value, false); }
        }

        public override string Caption
        {
            get { return this.VoucherCode + (this.GoodsIssueID != null ? this.GoodsIssueReference : this.GoodsIssueReferences) + ", " + (this.CustomerName != null ? "Customer: " + this.CustomerName.Substring(0, this.CustomerName.Length > 16 ? 15 : this.CustomerName.Length) : "") + "             Total Quantity: " + this.TotalQuantity.ToString("N0") + ",    Total Volume: " + this.TotalLineVolume.ToString("N2"); }
        }

        public override void PerformPresaveRule()
        {
            base.PerformPresaveRule();

            string goodsIssueReferences = ""; //string voucherCodes = "";
            this.DtoDetails().ToList().ForEach(e => { e.OrganizationalUnitID = this.OrganizationalUnitID; e.CustomerID = (int)this.CustomerID; e.ReceiverID = (int)this.ReceiverID; if (goodsIssueReferences.IndexOf(e.GoodsIssueReference) < 0) goodsIssueReferences = goodsIssueReferences + (goodsIssueReferences != "" ? ", " : "") + e.GoodsIssueReference; });
            this.GoodsIssueReferences = goodsIssueReferences; //this.VoucherCodes = voucherCodes;
        }

        protected override List<ValidationRule> CreateRules()
        {
            List<ValidationRule> validationRules = base.CreateRules();
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<SalesReturnPrimitiveDTO>(p => p.CustomerID), "Vui lòng chọn khách hàng.", delegate { return (this.CustomerID != null && this.CustomerID > 0); }));
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<SalesReturnPrimitiveDTO>(p => p.ReceiverTemp), "Vui lòng chọn đơn vị nhận hàng.", delegate { return (this.ReceiverID != null && this.ReceiverID > 0); }));
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<SalesReturnPrimitiveDTO>(p => p.SalespersonID), "Vui lòng chọn người lập.", delegate { return (this.SalespersonID != null && this.SalespersonID > 0); }));
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<SalesReturnPrimitiveDTO>(p => p.TeamID), "Vui lòng chọn người lập.", delegate { return (this.TeamID != null && this.TeamID > 0); }));
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<SalesReturnPrimitiveDTO>(p => p.WarehouseID), "Vui lòng chọn kho.", delegate { return (this.WarehouseID != null && this.WarehouseID > 0); }));

            return validationRules;
        }
    }

    public class SalesReturnDTO : SalesReturnPrimitiveDTO, IBaseDetailEntity<SalesReturnDetailDTO>
    {
        public SalesReturnDTO()
        {
            this.SalesReturnViewDetails = new BindingList<SalesReturnDetailDTO>();






            this.PackDetails = new BindingListView<SalesReturnDetailDTO>(this.SalesReturnViewDetails);
            this.CartonDetails = new BindingListView<SalesReturnDetailDTO>(this.SalesReturnViewDetails);
            this.PalletDetails = new BindingListView<SalesReturnDetailDTO>(this.SalesReturnViewDetails);

            this.PackDetails.ApplyFilter(f => f.PackID != null);
            this.CartonDetails.ApplyFilter(f => f.CartonID != null);
            this.PalletDetails.ApplyFilter(f => f.PalletID != null);
        }


        public BindingList<SalesReturnDetailDTO> SalesReturnViewDetails { get; set; }
        public BindingList<SalesReturnDetailDTO> ViewDetails { get { return this.SalesReturnViewDetails; } set { this.SalesReturnViewDetails = value; } }

        public ICollection<SalesReturnDetailDTO> GetDetails() { return this.SalesReturnViewDetails; }

        protected override IEnumerable<SalesReturnDetailDTO> DtoDetails() { return this.SalesReturnViewDetails; }






        public BindingListView<SalesReturnDetailDTO> PackDetails { get; private set; }
        public BindingListView<SalesReturnDetailDTO> CartonDetails { get; private set; }
        public BindingListView<SalesReturnDetailDTO> PalletDetails { get; private set; }
    }

}

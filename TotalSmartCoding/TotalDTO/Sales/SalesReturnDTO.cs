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

        private Nullable<DateTime> deliveryDate;
        public Nullable<DateTime> DeliveryDate
        {
            get { return this.deliveryDate; }
            set { ApplyPropertyChange<SalesReturnPrimitiveDTO, Nullable<DateTime>>(ref this.deliveryDate, o => o.DeliveryDate, value); }
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
            set { ApplyPropertyChange<SalesReturnPrimitiveDTO, string>(ref this.customerName, o => o.CustomerName, value); }
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
            set { ApplyPropertyChange<SalesReturnPrimitiveDTO, string>(ref this.receiverName, o => o.ReceiverName, value); }
        }

        private int salespersonID;
        [DefaultValue(null)]
        public int SalespersonID
        {
            get { return this.salespersonID; }
            set { ApplyPropertyChange<SalesReturnPrimitiveDTO, int>(ref this.salespersonID, o => o.SalespersonID, value); }
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
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<SalesReturnPrimitiveDTO>(p => p.ReceiverID), "Vui lòng chọn đơn vị nhận hàng.", delegate { return (this.ReceiverID != null && this.ReceiverID > 0); }));
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<SalesReturnPrimitiveDTO>(p => p.SalespersonID), "Vui lòng chọn người lập.", delegate { return (this.SalespersonID != null && this.SalespersonID > 0); }));

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

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
    public class SalesOrderPrimitiveDTO : QuantityDTO<SalesOrderDetailDTO>, IPrimitiveEntity, IPrimitiveDTO
    {
        public override GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.SalesOrder; } }

        public override int GetID() { return this.SalesOrderID; }
        public void SetID(int id) { this.SalesOrderID = id; }

        private int salesOrderID;
        [DefaultValue(0)]
        public int SalesOrderID
        {
            get { return this.salesOrderID; }
            set { ApplyPropertyChange<SalesOrderPrimitiveDTO, int>(ref this.salesOrderID, o => o.SalesOrderID, value); }
        }


        private Nullable<int> customerID;
        [DefaultValue(null)]
        public Nullable<int> CustomerID
        {
            get { return this.customerID; }
            set { ApplyPropertyChange<SalesOrderPrimitiveDTO, Nullable<int>>(ref this.customerID, o => o.CustomerID, value); }
        }
        private string customerName;
        [DefaultValue("")]
        public string CustomerName
        {
            get { return this.customerName; }
            set { ApplyPropertyChange<SalesOrderDTO, string>(ref this.customerName, o => o.CustomerName, value, false); }
        }



        private Nullable<int> salespersonID;
        [DefaultValue(null)]
        public Nullable<int> SalespersonID
        {
            get { return this.salespersonID; }
            set { ApplyPropertyChange<SalesOrderPrimitiveDTO, Nullable<int>>(ref this.salespersonID, o => o.SalespersonID, value); }
        }

        public override int PreparedPersonID { get { return 1; } }


        public override void PerformPresaveRule()
        {
            base.PerformPresaveRule();

            this.DtoDetails().ToList().ForEach(e => { e.CustomerID = this.CustomerID; });
        }
    }

    public class SalesOrderDTO : SalesOrderPrimitiveDTO, IBaseDetailEntity<SalesOrderDetailDTO>
    {
        public SalesOrderDTO()
        {
            this.SalesOrderViewDetails = new BindingList<SalesOrderDetailDTO>();
        }


        public BindingList<SalesOrderDetailDTO> SalesOrderViewDetails { get; set; }
        public BindingList<SalesOrderDetailDTO> ViewDetails { get { return this.SalesOrderViewDetails; } set { this.SalesOrderViewDetails = value; } }

        public ICollection<SalesOrderDetailDTO> GetDetails() { return this.SalesOrderViewDetails; }

        protected override IEnumerable<SalesOrderDetailDTO> DtoDetails() { return this.SalesOrderViewDetails; }






        protected override List<ValidationRule> CreateRules()
        {
            List<ValidationRule> validationRules = base.CreateRules();
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<SalesOrderDTO>(p => p.CustomerID), "Vui lòng chọn khách hàng.", delegate { return (this.CustomerID != null && this.CustomerID > 0); }));
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<SalesOrderDTO>(p => p.SalespersonID), "Vui lòng chọn nhân viên phụ trách khách hàng.", delegate { return (this.SalespersonID != null && this.SalespersonID > 0); }));

            return validationRules;

        }
    }

}

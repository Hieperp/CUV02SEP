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

namespace TotalDTO.Sales
{
    public class DeliveryAdvicePrimitiveDTO : QuantityDTO<DeliveryAdviceDetailDTO>, IPrimitiveEntity, IPrimitiveDTO
    {
        public override GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.DeliveryAdvice; } }

        public override int GetID() { return this.DeliveryAdviceID; }
        public void SetID(int id) { this.DeliveryAdviceID = id; }

        private int deliveryAdviceID;
        [DefaultValue(0)]
        public int DeliveryAdviceID
        {
            get { return this.deliveryAdviceID; }
            set { ApplyPropertyChange<DeliveryAdvicePrimitiveDTO, int>(ref this.deliveryAdviceID, o => o.DeliveryAdviceID, value); }
        }




        private Nullable<int> salesOrderID;
        [DefaultValue(null)]
        public Nullable<int> SalesOrderID
        {
            get { return this.salesOrderID; }
            set { ApplyPropertyChange<DeliveryAdvicePrimitiveDTO, Nullable<int>>(ref this.salesOrderID, o => o.SalesOrderID, value); }
        }
        public string SalesOrderReferences { get; set; }


        public bool HasSalesOrder { get; set; }

        private int customerID;
        [DefaultValue(null)]
        public int CustomerID
        {
            get { return this.customerID; }
            set { ApplyPropertyChange<DeliveryAdvicePrimitiveDTO, int>(ref this.customerID, o => o.CustomerID, value); }
        }
        private string customerName;
        [DefaultValue("")]
        public string CustomerName
        {
            get { return this.customerName; }
            set { ApplyPropertyChange<DeliveryAdviceDTO, string>(ref this.customerName, o => o.CustomerName, value); }
        }


        private int salesPersonID;
        [DefaultValue(1)]
        public int SalesPersonID
        {
            get { return this.salesPersonID; }
            set { ApplyPropertyChange<DeliveryAdvicePrimitiveDTO, int>(ref this.salesPersonID, o => o.SalesPersonID, value); }
        }


        public override int PreparedPersonID { get { return 1; } }

        public override void PerformPresaveRule()
        {
            base.PerformPresaveRule();

            string salesOrderReferences = "";
            this.DtoDetails().ToList().ForEach(e => { e.CustomerID = this.CustomerID; if (this.HasSalesOrder && salesOrderReferences.IndexOf(e.SalesOrderReference) < 0) salesOrderReferences = salesOrderReferences + (salesOrderReferences != "" ? ", " : "") + e.SalesOrderReference; });
            this.SalesOrderReferences = salesOrderReferences;
        }
    }

    public class DeliveryAdviceDTO : DeliveryAdvicePrimitiveDTO, IBaseDetailEntity<DeliveryAdviceDetailDTO>
    {
        public DeliveryAdviceDTO()
        {
            this.DeliveryAdviceViewDetails = new BindingList<DeliveryAdviceDetailDTO>();
        }


        public BindingList<DeliveryAdviceDetailDTO> DeliveryAdviceViewDetails { get; set; }
        public BindingList<DeliveryAdviceDetailDTO> ViewDetails { get { return this.DeliveryAdviceViewDetails; } set { this.DeliveryAdviceViewDetails = value; } }

        public ICollection<DeliveryAdviceDetailDTO> GetDetails() { return this.DeliveryAdviceViewDetails; }

        protected override IEnumerable<DeliveryAdviceDetailDTO> DtoDetails() { return this.DeliveryAdviceViewDetails; }
    }

}

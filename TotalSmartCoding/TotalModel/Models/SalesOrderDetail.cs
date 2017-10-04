//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TotalModel.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class SalesOrderDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesOrderDetail()
        {
            this.DeliveryAdviceDetails = new HashSet<DeliveryAdviceDetail>();
        }
    
        public int SalesOrderDetailID { get; set; }
        public int SalesOrderID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Reference { get; set; }
        public int CustomerID { get; set; }
        public int LocationID { get; set; }
        public int CommodityID { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityAdvice { get; set; }
        public decimal LineVolume { get; set; }
        public decimal LineVolumeAdvice { get; set; }
        public string Remarks { get; set; }
        public bool Approved { get; set; }
        public string VoucherCode { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryAdviceDetail> DeliveryAdviceDetails { get; set; }
        public virtual SalesOrder SalesOrder { get; set; }
        public virtual Commodity Commodity { get; set; }
    }
}

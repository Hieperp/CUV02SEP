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
    
    public partial class DeliveryAdviceDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DeliveryAdviceDetail()
        {
            this.GoodsIssueDetails = new HashSet<GoodsIssueDetail>();
        }
    
        public int DeliveryAdviceDetailID { get; set; }
        public int DeliveryAdviceID { get; set; }
        public Nullable<int> SalesOrderDetailID { get; set; }
        public Nullable<int> SalesOrderID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public int LocationID { get; set; }
        public int CustomerID { get; set; }
        public int CommodityID { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityIssue { get; set; }
        public decimal LineVolume { get; set; }
        public decimal LineVolumeIssue { get; set; }
        public string Remarks { get; set; }
        public bool Approved { get; set; }
        public string Reference { get; set; }
        public bool InActive { get; set; }
        public bool InActivePartial { get; set; }
        public Nullable<System.DateTime> InActivePartialDate { get; set; }
        public Nullable<int> BatchID { get; set; }
        public int ReceiverID { get; set; }
    
        public virtual SalesOrderDetail SalesOrderDetail { get; set; }
        public virtual DeliveryAdvice DeliveryAdvice { get; set; }
        public virtual Commodity Commodity { get; set; }
        public virtual Batch Batch { get; set; }
        public virtual Customer Customer { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsIssueDetail> GoodsIssueDetails { get; set; }
        public virtual Customer Customer1 { get; set; }
    }
}

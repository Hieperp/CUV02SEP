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
    
    public partial class GoodsIssue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoodsIssue()
        {
            this.GoodsIssueDetails = new HashSet<GoodsIssueDetail>();
        }
    
        public int GoodsIssueID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Reference { get; set; }
        public Nullable<int> DeliveryAdviceID { get; set; }
        public Nullable<int> TransferOrderID { get; set; }
        public string DeliveryAdviceReferences { get; set; }
        public Nullable<int> CustomerID { get; set; }
        public int ForkliftDriverID { get; set; }
        public int StorekeeperID { get; set; }
        public int UserID { get; set; }
        public int PreparedPersonID { get; set; }
        public int OrganizationalUnitID { get; set; }
        public int LocationID { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalLineVolume { get; set; }
        public string Vehicle { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime EditedDate { get; set; }
        public bool Approved { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
        public Nullable<int> WarehouseID { get; set; }
        public Nullable<int> WarehouseReceiptID { get; set; }
        public int GoodsIssueTypeID { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual DeliveryAdvice DeliveryAdvice { get; set; }
        public virtual Location Location { get; set; }
        public virtual TransferOrder TransferOrder { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual Warehouse Warehouse1 { get; set; }
        public virtual GoodsIssueType GoodsIssueType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsIssueDetail> GoodsIssueDetails { get; set; }
    }
}

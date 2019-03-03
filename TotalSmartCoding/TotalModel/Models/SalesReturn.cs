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
    
    public partial class SalesReturn
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SalesReturn()
        {
            this.SalesReturnDetails = new HashSet<SalesReturnDetail>();
        }
    
        public int SalesReturnID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Reference { get; set; }
        public string VoucherCode { get; set; }
        public Nullable<System.DateTime> VoucherDate { get; set; }
        public Nullable<int> GoodsIssueID { get; set; }
        public string GoodsIssueReferences { get; set; }
        public int CustomerID { get; set; }
        public int ReceiverID { get; set; }
        public int SalespersonID { get; set; }
        public int TeamID { get; set; }
        public int UserID { get; set; }
        public int PreparedPersonID { get; set; }
        public int OrganizationalUnitID { get; set; }
        public int LocationID { get; set; }
        public int TotalPackCounts { get; set; }
        public int TotalCartonCounts { get; set; }
        public int TotalPalletCounts { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalLineVolume { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime EditedDate { get; set; }
        public bool Approved { get; set; }
        public Nullable<System.DateTime> ApprovedDate { get; set; }
    
        public virtual Customer Customer { get; set; }
        public virtual Customer Customer1 { get; set; }
        public virtual GoodsIssue GoodsIssue { get; set; }
        public virtual Location Location { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesReturnDetail> SalesReturnDetails { get; set; }
        public virtual Team Team { get; set; }
    }
}

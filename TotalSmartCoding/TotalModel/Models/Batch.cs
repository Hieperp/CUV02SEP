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
    
    public partial class Batch
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Batch()
        {
            this.DeliveryAdviceDetails = new HashSet<DeliveryAdviceDetail>();
            this.SalesReturnDetails = new HashSet<SalesReturnDetail>();
        }
    
        public int BatchID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Reference { get; set; }
        public string Code { get; set; }
        public int FillingLineID { get; set; }
        public int CommodityID { get; set; }
        public int LocationID { get; set; }
        public string NextPackNo { get; set; }
        public string NextCartonNo { get; set; }
        public string NextPalletNo { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime EditedDate { get; set; }
        public bool IsDefault { get; set; }
        public bool InActive { get; set; }
        public Nullable<System.DateTime> InActiveDate { get; set; }
        public bool AutoBarcode { get; set; }
        public string FinalCartonNo { get; set; }
        public bool AutoCarton { get; set; }
    
        public virtual Commodity Commodity { get; set; }
        public virtual FillingLine FillingLine { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryAdviceDetail> DeliveryAdviceDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesReturnDetail> SalesReturnDetails { get; set; }
    }
}

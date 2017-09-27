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
    
    public partial class Pickup
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Pickup()
        {
            this.GoodsReceipts = new HashSet<GoodsReceipt>();
            this.PickupDetails = new HashSet<PickupDetail>();
        }
    
        public int PickupID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Reference { get; set; }
        public int FillingLineID { get; set; }
        public int WarehouseID { get; set; }
        public int ForkliftDriverID { get; set; }
        public int StorekeeperID { get; set; }
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
    
        public virtual FillingLine FillingLine { get; set; }
        public virtual Location Location { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsReceipt> GoodsReceipts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PickupDetail> PickupDetails { get; set; }
    }
}

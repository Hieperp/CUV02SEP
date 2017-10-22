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
    
    public partial class Warehouse
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Warehouse()
        {
            this.Pickups = new HashSet<Pickup>();
            this.GoodsReceiptDetails = new HashSet<GoodsReceiptDetail>();
            this.GoodsReceipts = new HashSet<GoodsReceipt>();
            this.PickupDetails = new HashSet<PickupDetail>();
            this.BinLocations = new HashSet<BinLocation>();
            this.WarehouseAdjustmentDetails = new HashSet<WarehouseAdjustmentDetail>();
            this.WarehouseAdjustments = new HashSet<WarehouseAdjustment>();
        }
    
        public int WarehouseID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public int WarehouseCategoryID { get; set; }
        public int LocationID { get; set; }
        public bool Bookable { get; set; }
        public bool Issuable { get; set; }
        public bool IsDefault { get; set; }
        public string Remarks { get; set; }
    
        public virtual Location Location { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pickup> Pickups { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsReceiptDetail> GoodsReceiptDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsReceipt> GoodsReceipts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PickupDetail> PickupDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<BinLocation> BinLocations { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseAdjustmentDetail> WarehouseAdjustmentDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseAdjustment> WarehouseAdjustments { get; set; }
    }
}

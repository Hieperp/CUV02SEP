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
    
    public partial class GoodsReceipt
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoodsReceipt()
        {
            this.GoodsReceiptDetails = new HashSet<GoodsReceiptDetail>();
        }
    
        public int GoodsReceiptID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Reference { get; set; }
        public int GoodsReceiptTypeID { get; set; }
        public Nullable<int> PickupID { get; set; }
        public Nullable<int> GoodsIssueID { get; set; }
        public Nullable<int> WarehouseAdjustmentID { get; set; }
        public string PrimaryReferences { get; set; }
        public int WarehouseID { get; set; }
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
        public int ForkliftDriverID { get; set; }
        public string VehicleDriver { get; set; }
        public Nullable<int> SalesReturnID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsReceiptDetail> GoodsReceiptDetails { get; set; }
        public virtual GoodsReceiptType GoodsReceiptType { get; set; }
        public virtual Pickup Pickup { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual Location Location { get; set; }
        public virtual WarehouseAdjustment WarehouseAdjustment { get; set; }
        public virtual SalesReturn SalesReturn { get; set; }
    }
}

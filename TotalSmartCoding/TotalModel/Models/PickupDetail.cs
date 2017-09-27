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
    
    public partial class PickupDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PickupDetail()
        {
            this.GoodsReceiptDetails = new HashSet<GoodsReceiptDetail>();
        }
    
        public int PickupDetailID { get; set; }
        public int PickupID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Reference { get; set; }
        public int LocationID { get; set; }
        public int WarehouseID { get; set; }
        public int BinLocationID { get; set; }
        public int CommodityID { get; set; }
        public int BatchID { get; set; }
        public System.DateTime BatchEntryDate { get; set; }
        public Nullable<int> PackID { get; set; }
        public Nullable<int> CartonID { get; set; }
        public Nullable<int> PalletID { get; set; }
        public int PackCounts { get; set; }
        public int CartonCounts { get; set; }
        public int PalletCounts { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityReceipt { get; set; }
        public decimal LineVolume { get; set; }
        public decimal LineVolumeReceipt { get; set; }
        public string Remarks { get; set; }
        public bool Approved { get; set; }
    
        public virtual BinLocation BinLocation { get; set; }
        public virtual Carton Carton { get; set; }
        public virtual Commodity Commodity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsReceiptDetail> GoodsReceiptDetails { get; set; }
        public virtual Pack Pack { get; set; }
        public virtual Pallet Pallet { get; set; }
        public virtual Pickup Pickup { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}

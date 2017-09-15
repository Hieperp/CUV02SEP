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
    
    public partial class GoodsReceiptDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoodsReceiptDetail()
        {
            this.GoodsIssueDetails = new HashSet<GoodsIssueDetail>();
        }
    
        public int GoodsReceiptDetailID { get; set; }
        public int GoodsReceiptID { get; set; }
        public Nullable<int> PickupDetailID { get; set; }
        public Nullable<int> PickupID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public int LocationID { get; set; }
        public int WarehouseID { get; set; }
        public int BinLocationID { get; set; }
        public int CommodityID { get; set; }
        public Nullable<int> PackID { get; set; }
        public Nullable<int> CartonID { get; set; }
        public Nullable<int> PalletID { get; set; }
        public decimal Quantity { get; set; }
        public decimal QuantityIssue { get; set; }
        public decimal Volume { get; set; }
        public decimal VolumeIssue { get; set; }
        public string Remarks { get; set; }
        public bool Approved { get; set; }
        public int PackCounts { get; set; }
        public int CartonCounts { get; set; }
        public int PalletCounts { get; set; }
    
        public virtual BinLocation BinLocation { get; set; }
        public virtual GoodsReceipt GoodsReceipt { get; set; }
        public virtual PickupDetail PickupDetail { get; set; }
        public virtual Warehouse Warehouse { get; set; }
        public virtual Carton Carton { get; set; }
        public virtual Pack Pack { get; set; }
        public virtual Pallet Pallet { get; set; }
        public virtual Commodity Commodity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsIssueDetail> GoodsIssueDetails { get; set; }
    }
}

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
    
    public partial class Commodity
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Commodity()
        {
            this.Cartons = new HashSet<Carton>();
            this.DeliveryAdviceDetails = new HashSet<DeliveryAdviceDetail>();
            this.GoodsIssueDetails = new HashSet<GoodsIssueDetail>();
            this.Packs = new HashSet<Pack>();
            this.Pallets = new HashSet<Pallet>();
            this.PickupDetails = new HashSet<PickupDetail>();
            this.SalesOrderDetails = new HashSet<SalesOrderDetail>();
            this.Batches = new HashSet<Batch>();
            this.WarehouseAdjustmentDetails = new HashSet<WarehouseAdjustmentDetail>();
            this.GoodsReceiptDetails = new HashSet<GoodsReceiptDetail>();
        }
    
        public int CommodityID { get; set; }
        public string Code { get; set; }
        public string OfficialCode { get; set; }
        public string Name { get; set; }
        public string OfficialName { get; set; }
        public int CommodityCategoryID { get; set; }
        public int CommodityTypeID { get; set; }
        public string Unit { get; set; }
        public string PackageSize { get; set; }
        public string Origin { get; set; }
        public string APICode { get; set; }
        public string FillingLineIDs { get; set; }
        public decimal Volume { get; set; }
        public decimal Weight { get; set; }
        public int PackPerCarton { get; set; }
        public int CartonPerPallet { get; set; }
        public decimal PackageVolume { get; set; }
        public int Shelflife { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> Discontinue { get; set; }
        public Nullable<bool> InActive { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Carton> Cartons { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DeliveryAdviceDetail> DeliveryAdviceDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsIssueDetail> GoodsIssueDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pack> Packs { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pallet> Pallets { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PickupDetail> PickupDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Batch> Batches { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<WarehouseAdjustmentDetail> WarehouseAdjustmentDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsReceiptDetail> GoodsReceiptDetails { get; set; }
    }
}

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
    
    public partial class PendingDeliveryAdviceDetail
    {
        public int DeliveryAdviceID { get; set; }
        public int DeliveryAdviceDetailID { get; set; }
        public string DeliveryAdviceReference { get; set; }
        public System.DateTime DeliveryAdviceEntryDate { get; set; }
        public int CommodityID { get; set; }
        public string CommodityCode { get; set; }
        public string CommodityName { get; set; }
        public Nullable<decimal> QuantityRemains { get; set; }
        public Nullable<decimal> Quantity { get; set; }
        public Nullable<decimal> LineVolumeRemains { get; set; }
        public Nullable<decimal> LineVolume { get; set; }
        public string Remarks { get; set; }
        public Nullable<bool> IsSelected { get; set; }
        public int LocationID { get; set; }
        public string PackageSize { get; set; }
        public decimal Volume { get; set; }
        public decimal PackageVolume { get; set; }
        public Nullable<int> BatchID { get; set; }
        public string BatchCode { get; set; }
    }
}

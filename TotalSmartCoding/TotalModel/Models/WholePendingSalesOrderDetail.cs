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
    
    public partial class WholePendingSalesOrderDetail
    {
        public int SalesOrderID { get; set; }
        public int SalesOrderDetailID { get; set; }
        public string SalesOrderReference { get; set; }
        public System.DateTime SalesOrderEntryDate { get; set; }
        public string SalesOrderVoucherCode { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public int CommodityID { get; set; }
        public string CommodityCode { get; set; }
        public string CommodityName { get; set; }
        public string PackageSize { get; set; }
        public decimal Volume { get; set; }
        public decimal PackageVolume { get; set; }
        public decimal OriginalQuantity { get; set; }
        public decimal OriginalLineVolume { get; set; }
        public Nullable<decimal> QuantityRemains { get; set; }
        public Nullable<decimal> LineVolumeRemains { get; set; }
        public string Remarks { get; set; }
        public bool Approved { get; set; }
    }
}

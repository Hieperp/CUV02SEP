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
    
    public partial class DeliveryAdviceViewDetail
    {
        public int DeliveryAdviceDetailID { get; set; }
        public int DeliveryAdviceID { get; set; }
        public Nullable<int> SalesOrderID { get; set; }
        public Nullable<int> SalesOrderDetailID { get; set; }
        public string SalesOrderReference { get; set; }
        public Nullable<System.DateTime> SalesOrderEntryDate { get; set; }
        public int CommodityID { get; set; }
        public string CommodityCode { get; set; }
        public string CommodityName { get; set; }
        public decimal Quantity { get; set; }
        public decimal LineVolume { get; set; }
        public string Remarks { get; set; }
    }
}
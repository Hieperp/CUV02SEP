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
    
    public partial class ForecastViewDetail
    {
        public int ForecastID { get; set; }
        public int ForecastDetailID { get; set; }
        public int CommodityID { get; set; }
        public decimal Quantity { get; set; }
        public decimal LineVolume { get; set; }
        public decimal QuantityM1 { get; set; }
        public decimal LineVolumeM1 { get; set; }
        public decimal QuantityM2 { get; set; }
        public decimal LineVolumeM2 { get; set; }
        public decimal QuantityM3 { get; set; }
        public decimal LineVolumeM3 { get; set; }
        public string Remarks { get; set; }
        public string CommodityCode { get; set; }
        public string CommodityName { get; set; }
        public string CommodityCategoryName { get; set; }
    }
}

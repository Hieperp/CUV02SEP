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
    
    public partial class ForecastIndex
    {
        public int ForecastID { get; set; }
        public Nullable<System.DateTime> EntryDate { get; set; }
        public string Reference { get; set; }
        public string VoucherCode { get; set; }
        public string LocationCode { get; set; }
        public decimal TotalQuantity { get; set; }
        public decimal TotalLineVolume { get; set; }
        public decimal TotalQuantityM1 { get; set; }
        public decimal TotalLineVolumeM1 { get; set; }
        public decimal TotalQuantityM2 { get; set; }
        public decimal TotalLineVolumeM2 { get; set; }
        public decimal TotalQuantityM3 { get; set; }
        public decimal TotalLineVolumeM3 { get; set; }
        public string Description { get; set; }
        public int QuantityVersusVolume { get; set; }
    }
}

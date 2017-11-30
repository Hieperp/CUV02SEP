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
    
    public partial class GoodsReceiptDetailAvailable
    {
        public int WarehouseID { get; set; }
        public string WarehouseCode { get; set; }
        public int BinLocationID { get; set; }
        public string BinLocationCode { get; set; }
        public string Remarks { get; set; }
        public Nullable<decimal> QuantityAvailable { get; set; }
        public Nullable<decimal> LineVolumeAvailable { get; set; }
        public bool IsSelected { get; set; }
        public Nullable<int> PackID { get; set; }
        public string PackCode { get; set; }
        public Nullable<int> CartonID { get; set; }
        public string CartonCode { get; set; }
        public Nullable<int> PalletID { get; set; }
        public string PalletCode { get; set; }
        public int GoodsReceiptID { get; set; }
        public int GoodsReceiptDetailID { get; set; }
        public int CommodityID { get; set; }
        public string CommodityCode { get; set; }
        public string CommodityName { get; set; }
        public System.DateTime BatchEntryDate { get; set; }
        public string GoodsReceiptReference { get; set; }
        public System.DateTime GoodsReceiptEntryDate { get; set; }
        public int PackCounts { get; set; }
        public int CartonCounts { get; set; }
        public int PalletCounts { get; set; }
        public int BatchID { get; set; }
        public string PackageSize { get; set; }
        public decimal Volume { get; set; }
        public decimal PackageVolume { get; set; }
        public string LineReferences { get; set; }
        public string BatchCode { get; set; }
    }
}

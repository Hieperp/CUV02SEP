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
    
    public partial class GoodsIssueViewDetail
    {
        public int GoodsIssueDetailID { get; set; }
        public int GoodsIssueID { get; set; }
        public int DeliveryAdviceID { get; set; }
        public int DeliveryAdviceDetailID { get; set; }
        public string DeliveryAdviceReference { get; set; }
        public System.DateTime DeliveryAdviceEntryDate { get; set; }
        public int GoodsReceiptID { get; set; }
        public int GoodsReceiptDetailID { get; set; }
        public string GoodsReceiptReference { get; set; }
        public System.DateTime GoodsReceiptEntryDate { get; set; }
        public int CommodityID { get; set; }
        public string CommodityCode { get; set; }
        public string CommodityName { get; set; }
        public int BinLocationID { get; set; }
        public string BinLocationCode { get; set; }
        public Nullable<int> PackID { get; set; }
        public string PackCode { get; set; }
        public Nullable<int> CartonID { get; set; }
        public string CartonCode { get; set; }
        public Nullable<int> PalletID { get; set; }
        public string PalletCode { get; set; }
        public decimal Quantity { get; set; }
        public decimal LineVolume { get; set; }
        public string Remarks { get; set; }
    }
}
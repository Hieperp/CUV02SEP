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
    
    public partial class SalesReturnDetail
    {
        public int SalesReturnDetailID { get; set; }
        public int SalesReturnID { get; set; }
        public System.DateTime EntryDate { get; set; }
        public string Reference { get; set; }
        public int CustomerID { get; set; }
        public int ReceiverID { get; set; }
        public int GoodsIssueID { get; set; }
        public int GoodsIssueDetailID { get; set; }
        public int SalespersonID { get; set; }
        public int LocationID { get; set; }
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
    }
}

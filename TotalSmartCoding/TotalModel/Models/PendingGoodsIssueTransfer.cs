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
    
    public partial class PendingGoodsIssueTransfer
    {
        public int GoodsIssueID { get; set; }
        public int WarehouseID { get; set; }
        public string WarehouseCode { get; set; }
        public string WarehouseName { get; set; }
        public int GoodsReceiptTypeID { get; set; }
        public string GoodsReceiptTypeName { get; set; }
        public string Description { get; set; }
        public string Remarks { get; set; }
        public string PrimaryReference { get; set; }
        public System.DateTime PrimaryEntryDate { get; set; }
        public string VoucherCodes { get; set; }
        public string SourceWarehouseName { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

using TotalModel;
using TotalDTO.Helpers;
using System.Collections.Generic;
using TotalModel.Helpers;
using TotalBase;

namespace TotalDTO.Sales
{
    public class SalesReturnDetailDTO : QuantityDetailDTO, IPrimitiveEntity
    {
        public int GetID() { return this.SalesReturnDetailID; }
       
        public int SalesReturnDetailID { get; set; }
        public int SalesReturnID { get; set; }

        public int WarehouseID { get; set; }
        public int SalespersonID { get; set; }

        public int CustomerID { get; set; }
        public int ReceiverID { get; set; }

        public int GoodsIssueID { get; set; }
        public int GoodsIssueDetailID { get; set; }
        public string GoodsIssueReference { get; set; }
        public DateTime GoodsIssueEntryDate { get; set; }

        public int BatchID { get; set; }
        public DateTime BatchEntryDate { get; set; }

        public Nullable<int> PackID { get; set; }
        public string PackCode { get; set; }

        public Nullable<int> CartonID { get; set; }
        public string CartonCode { get; set; }

        public Nullable<int> PalletID { get; set; }
        public string PalletCode { get; set; }
    }
}

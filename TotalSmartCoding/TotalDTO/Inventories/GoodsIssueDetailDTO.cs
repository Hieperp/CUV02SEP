using System;
using System.ComponentModel.DataAnnotations;

using TotalModel;
using TotalDTO.Helpers;

namespace TotalDTO.Inventories
{
    public class GoodsIssueDetailDTO : QuantityDetailDTO, IPrimitiveEntity
    {
        public int GetID() { return this.GoodsIssueDetailID; }

        //IMPORTANT: IMPLEMENT PropertyChanged!!!!
        //NOW: AFTER ADD GoodsIssueDetailDTO TO COLLECTION, WE DON'T CHANGE THESE PROPERTIES FROM BINDING DataGridView ALSO FROM BACKEND GoodsIssueDetailDTO OBJECT. SO: WE DON'T IMPLEMENT PropertyChanged FOR THESE PROPERTIES
        //LATER: IF WE RECEIPT FORM OTHER SOURCE THAN FROM PICKUP ONLY, WE SHOULD CONSIDER THIS => AND IMPLEMENT PropertyChanged FOR THESE PROPERTIES WHEN NECCESSARY


        public int GoodsIssueDetailID { get; set; }
        public int GoodsIssueID { get; set; }

        public Nullable<int> DeliveryAdviceID { get; set; }
        public Nullable<int> DeliveryAdviceDetailID { get; set; }

        public string DeliveryAdviceReference { get; set; }
        public Nullable<System.DateTime> DeliveryAdviceEntryDate { get; set; }

        public int CustomerID { get; set; }

        public int GoodsReceiptID { get; set; }
        public int GoodsReceiptDetailID { get; set; }

        public int WarehouseID { get; set; }
        public string WarehouseCode { get; set; }

        public int BinLocationID { get; set; }
        public string BinLocationCode { get; set; }

        public Nullable<int> PackID { get; set; }
        public string PackCode { get; set; }

        public Nullable<int> CartonID { get; set; }
        public string CartonCode { get; set; }

        public Nullable<int> PalletID { get; set; }
        public string PalletCode { get; set; }
    }





}

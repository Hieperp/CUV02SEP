using System;
using System.ComponentModel.DataAnnotations;

using TotalModel;
using TotalDTO.Helpers;

namespace TotalDTO.Inventories
{
    public class GoodsReceiptDetailDTO : QuantityDetailDTO, IPrimitiveEntity
    {
        public int GetID() { return this.GoodsReceiptDetailID; }

        //IMPORTANT: IMPLEMENT PropertyChanged!!!!
        //NOW: AFTER ADD GoodsReceiptDetailDTO TO COLLECTION, WE DON'T CHANGE THESE PROPERTIES FROM BINDING DataGridView ALSO FROM BACKEND GoodsReceiptDetailDTO OBJECT. SO: WE DON'T IMPLEMENT PropertyChanged FOR THESE PROPERTIES
        //LATER: IF WE RECEIPT FORM OTHER SOURCE THAN FROM PICKUP ONLY, WE SHOULD CONSIDER THIS => AND IMPLEMENT PropertyChanged FOR THESE PROPERTIES WHEN NECCESSARY
        

        public int GoodsReceiptDetailID { get; set; }
        public int GoodsReceiptID { get; set; }

        public Nullable<int> PickupID { get; set; }
        public Nullable<int> PickupDetailID { get; set; }

        public string PickupReference { get; set; }
        public Nullable<System.DateTime> PickupEntryDate { get; set; }

        public Nullable<int> WarehouseAdjustmentID { get; set; }
        public Nullable<int> WarehouseAdjustmentDetailID { get; set; }

        public string WarehouseAdjustmentReference { get; set; }
        public Nullable<System.DateTime> WarehouseAdjustmentEntryDate { get; set; }

        public Nullable<int> BatchID { get; set; }
        public Nullable<System.DateTime> BatchEntryDate { get; set; }

        public int WarehouseID { get; set; }
        
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

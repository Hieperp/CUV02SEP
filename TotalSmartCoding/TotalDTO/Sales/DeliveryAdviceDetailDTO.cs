using System;
using System.ComponentModel.DataAnnotations;

using TotalModel;
using TotalDTO.Helpers;

namespace TotalDTO.Sales
{
    public class DeliveryAdviceDetailDTO : QuantityDetailDTO, IPrimitiveEntity
    {
        public int GetID() { return this.DeliveryAdviceDetailID; }

        //IMPORTANT: IMPLEMENT PropertyChanged!!!!
        //NOW: AFTER ADD DeliveryAdviceDetailDTO TO COLLECTION, WE DON'T CHANGE THESE PROPERTIES FROM BINDING DataGridView ALSO FROM BACKEND DeliveryAdviceDetailDTO OBJECT. SO: WE DON'T IMPLEMENT PropertyChanged FOR THESE PROPERTIES
        //LATER: IF WE RECEIPT FORM OTHER SOURCE THAN FROM PICKUP ONLY, WE SHOULD CONSIDER THIS => AND IMPLEMENT PropertyChanged FOR THESE PROPERTIES WHEN NECCESSARY


        public int DeliveryAdviceDetailID { get; set; }
        public int DeliveryAdviceID { get; set; }

        public Nullable<int> SalesOrderID { get; set; }
        public Nullable<int> SalesOrderDetailID { get; set; }

        public string SalesOrderReference { get; set; }
        public Nullable<System.DateTime> SalesOrderEntryDate { get; set; }
        public string SalesOrderVoucherCode { get; set; }

        public int CustomerID { get; set; }
    }





}

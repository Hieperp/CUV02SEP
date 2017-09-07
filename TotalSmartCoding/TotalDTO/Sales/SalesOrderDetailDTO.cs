using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using TotalBase;
using TotalModel;
using TotalDTO.Helpers;
using TotalModel.Helpers;


namespace TotalDTO.Sales
{
    public class SalesOrderDetailDTO : QuantityDetailDTO, IPrimitiveEntity
    {
        public int GetID() { return this.SalesOrderDetailID; }

        public int SalesOrderDetailID { get; set; }
        public int SalesOrderID { get; set; }

        public Nullable<int> CustomerID { get; set; }
    }
}

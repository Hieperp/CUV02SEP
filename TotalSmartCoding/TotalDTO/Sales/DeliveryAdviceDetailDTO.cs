using System;
using System.ComponentModel.DataAnnotations;

using TotalModel;
using TotalDTO.Helpers;
using System.Collections.Generic;
using TotalModel.Helpers;
using TotalBase;

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


        public Nullable<int> BatchID { get; set; }
        public string BatchCode { get; set; }


        public string VoucherCode { get; set; }
        public int CustomerID { get; set; }

        public decimal QuantityIssue { get; set; }
        public decimal LineVolumeIssue { get; set; }

        protected override List<ValidationRule> CreateRules()
        {
            List<ValidationRule> validationRules = base.CreateRules();
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<DeliveryAdviceDetailDTO>(p => p.DeliveryAdviceDetailID), "Số lượng xuất không được lớn hơn số lượng tồn.", delegate { return (this.Quantity <= this.QuantityAvailable && this.Quantity <= this.QuantityRemains && this.LineVolume <= this.LineVolumeAvailable && this.LineVolume <= this.LineVolumeRemains); }));

            return validationRules;
        }
    }





}

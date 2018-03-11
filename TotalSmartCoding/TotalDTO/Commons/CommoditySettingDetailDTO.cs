using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using TotalBase;
using TotalBase.Enums;
using TotalModel;
using TotalModel.Helpers;

namespace TotalDTO.Commons
{
    public class CommoditySettingDetailDTO : BaseModel, IBaseModel, IPrimitiveEntity
    {
        public int GetID() { return this.CommoditySettingDetailID; }

        public int CommoditySettingDetailID { get; set; }
        public int CommoditySettingID { get; set; }

        public Nullable<int> CommodityID { get; set; }



        private int locationID;
        [DefaultValue(null)]
        public int LocationID
        {
            get { return this.locationID; }
            set { ApplyPropertyChange<CommoditySettingDetailDTO, int>(ref this.locationID, o => o.LocationID, value); }
        }

        private string locationCode;
        [DefaultValue(null)]
        public virtual string LocationCode
        {
            get { return this.locationCode; }
            set { ApplyPropertyChange<CommoditySettingDetailDTO, string>(ref this.locationCode, o => o.LocationCode, value); }
        }



        private decimal lowDSI;
        [DefaultValue(0)]
        [Range(0, 99999999999, ErrorMessage = "Số lượng không hợp lệ")]
        public virtual decimal LowDSI
        {
            get { return this.lowDSI; }
            set { ApplyPropertyChange<CommoditySettingDetailDTO, decimal>(ref this.lowDSI, o => o.LowDSI, Math.Round(value, (int)GlobalEnums.rndQuantity)); this.NotifyPropertyChanged("TotalLowDSI"); }
        }

        private decimal highDSI;
        [DefaultValue(0)]
        [Range(0, 99999999999, ErrorMessage = "Số lượng không hợp lệ")]
        public virtual decimal HighDSI
        {
            get { return this.highDSI; }
            set { ApplyPropertyChange<CommoditySettingDetailDTO, decimal>(ref this.highDSI, o => o.HighDSI, Math.Round(value, (int)GlobalEnums.rndQuantity)); this.NotifyPropertyChanged("TotalLowDSI"); }
        }

        private decimal alertDSI;
        [DefaultValue(0)]
        [Range(0, 99999999999, ErrorMessage = "Số lượng không hợp lệ")]
        public virtual decimal AlertDSI
        {
            get { return this.alertDSI; }
            set { ApplyPropertyChange<CommoditySettingDetailDTO, decimal>(ref this.alertDSI, o => o.AlertDSI, Math.Round(value, (int)GlobalEnums.rndQuantity)); this.NotifyPropertyChanged("TotalLowDSI"); }
        }

        protected override List<ValidationRule> CreateRules()
        {
            List<ValidationRule> validationRules = base.CreateRules();
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<CommoditySettingDetailDTO>(p => p.LocationID), "Vui lòng chọn chi nhánh.", delegate { return (this.LocationID > 0); }));

            return validationRules;

        }
    }
}
using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using TotalBase;
using TotalBase.Enums;
using TotalModel;
using TotalModel.Helpers;
using TotalDTO.Helpers;
using TotalDTO.Commons;

namespace TotalDTO.Commons
{
    public class CommoditySettingPrimitiveDTO : BaseWithDetailDTO<CommoditySettingDetailDTO>, IPrimitiveEntity, IPrimitiveDTO
    {
        public override GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.CommoditySetting; } }

        public override int GetID() { return this.CommoditySettingID; }
        public void SetID(int id) { this.CommoditySettingID = id; }

        private int commoditySettingID;
        [DefaultValue(0)]
        public int CommoditySettingID
        {
            get { return this.commoditySettingID; }
            set { ApplyPropertyChange<CommoditySettingPrimitiveDTO, int>(ref this.commoditySettingID, o => o.CommoditySettingID, value); }
        }

        private Nullable<int> commodityID;
        [DefaultValue(null)]
        public Nullable<int> CommodityID
        {
            get { return this.commodityID; }
            set { ApplyPropertyChange<CommoditySettingPrimitiveDTO, Nullable<int>>(ref this.commodityID, o => o.CommodityID, value); }
        }
        private string commodityName;
        [DefaultValue(null)]
        public string CommodityName
        {
            get { return this.commodityName; }
            set { ApplyPropertyChange<CommoditySettingDTO, string>(ref this.commodityName, o => o.CommodityName, value, false); }
        }

        private string commodityCategoryName;
        [DefaultValue(null)]
        public string CommodityCategoryName
        {
            get { return this.commodityCategoryName; }
            set { ApplyPropertyChange<CommoditySettingDTO, string>(ref this.commodityCategoryName, o => o.CommodityCategoryName, value, false); }
        }


        private string packageSize;
        [DefaultValue(null)]
        public string PackageSize
        {
            get { return this.packageSize; }
            set { ApplyPropertyChange<CommodityPrimitiveDTO, string>(ref this.packageSize, o => o.PackageSize, value); }
        }

        private decimal packageVolume;
        //[DefaultValue(0.0)]
        [Range(1, 99999999999, ErrorMessage = "Volume không hợp lệ")]
        public virtual decimal PackageVolume
        {
            get { return this.packageVolume; }
            set { ApplyPropertyChange<CommodityPrimitiveDTO, decimal>(ref this.packageVolume, o => o.PackageVolume, Math.Round(value, (int)GlobalEnums.rndVolume)); }
        }

        public override void PerformPresaveRule()
        {
            base.PerformPresaveRule();

            this.DtoDetails().ToList().ForEach(e => { e.CommodityID = this.CommodityID; });
        }

        protected override List<ValidationRule> CreateRules()
        {
            List<ValidationRule> validationRules = base.CreateRules();
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<CommoditySettingPrimitiveDTO>(p => p.CommodityID), "Vui lòng chọn mặt hàng.", delegate { return (this.CommodityID != null && this.CommodityID > 0); }));

            return validationRules;
        }
    }


    public class CommoditySettingDTO : CommoditySettingPrimitiveDTO, IBaseDetailEntity<CommoditySettingDetailDTO>
    {
        public CommoditySettingDTO()
        {
            this.CommoditySettingViewDetails = new BindingList<CommoditySettingDetailDTO>();
        }


        public BindingList<CommoditySettingDetailDTO> CommoditySettingViewDetails { get; set; }
        public BindingList<CommoditySettingDetailDTO> ViewDetails { get { return this.CommoditySettingViewDetails; } set { this.CommoditySettingViewDetails = value; } }

        public ICollection<CommoditySettingDetailDTO> GetDetails() { return this.CommoditySettingViewDetails; }

        protected override IEnumerable<CommoditySettingDetailDTO> DtoDetails() { return this.CommoditySettingViewDetails; }
    }
}

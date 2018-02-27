﻿using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using Equin.ApplicationFramework;

using TotalBase;
using TotalBase.Enums;
using TotalModel;
using TotalModel.Helpers;
using TotalDTO.Helpers;
using TotalDTO.Commons;

namespace TotalDTO.Sales
{
    public class ForecastPrimitiveDTO : BaseWithDetailDTO<ForecastDetailDTO>, IPrimitiveEntity, IPrimitiveDTO
    {
        public override GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.Forecast; } }

        public ForecastPrimitiveDTO() { this.Initialize(); }

        public override void Init()
        {
            base.Init();
            this.Initialize();
        }

        private void Initialize() { } //this.DeliveryDate = DateTime.Now; 

        public override int GetID() { return this.ForecastID; }
        public void SetID(int id) { this.ForecastID = id; }

        private int forecastID;
        [DefaultValue(0)]
        public int ForecastID
        {
            get { return this.forecastID; }
            set { ApplyPropertyChange<ForecastPrimitiveDTO, int>(ref this.forecastID, o => o.ForecastID, value); }
        }


        private string voucherCode;
        [DefaultValue(null)]
        public string VoucherCode
        {
            get { return this.voucherCode; }
            set { ApplyPropertyChange<ForecastDTO, string>(ref this.voucherCode, o => o.VoucherCode, value); }
        }


        private Nullable<int> forecastLocationID;
        [DefaultValue(null)]
        public Nullable<int> ForecastLocationID
        {
            get { return this.forecastLocationID; }
            set { ApplyPropertyChange<ForecastPrimitiveDTO, Nullable<int>>(ref this.forecastLocationID, o => o.ForecastLocationID, value); }
        }
        private string forecastLocationName;
        [DefaultValue(null)]
        public string ForecastLocationName
        {
            get { return this.forecastLocationName; }
            set { ApplyPropertyChange<ForecastDTO, string>(ref this.forecastLocationName, o => o.ForecastLocationName, value, false); }
        }



        public virtual decimal TotalQuantity { get { return this.DtoDetails().Select(o => o.Quantity).Sum(); } }
        public virtual decimal TotalLineVolume { get { return this.DtoDetails().Select(o => o.LineVolume).Sum(); } }

        public virtual decimal TotalQuantityM1 { get { return this.DtoDetails().Select(o => o.QuantityM1).Sum(); } }
        public virtual decimal TotalLineVolumeM1 { get { return this.DtoDetails().Select(o => o.LineVolumeM1).Sum(); } }

        public virtual decimal TotalQuantityM2 { get { return this.DtoDetails().Select(o => o.QuantityM2).Sum(); } }
        public virtual decimal TotalLineVolumeM2 { get { return this.DtoDetails().Select(o => o.LineVolumeM2).Sum(); } }

        public virtual decimal TotalQuantityM3 { get { return this.DtoDetails().Select(o => o.QuantityM3).Sum(); } }
        public virtual decimal TotalLineVolumeM3 { get { return this.DtoDetails().Select(o => o.LineVolumeM3).Sum(); } }

        public virtual decimal TotalTotalQuantity { get { return this.DtoDetails().Select(o => o.TotalQuantity).Sum(); } }
        public virtual decimal TotalTotalLineVolume { get { return this.DtoDetails().Select(o => o.TotalLineVolume).Sum(); } }

        
        public override string Caption
        {
            get { return this.ForecastLocationName + ", Entry Date: " + this.EntryDate.ToString() + "             Total Forecast: " + this.TotalTotalLineVolume.ToString("N2") + ",             Current Month: " + this.TotalLineVolume.ToString("N2") + ",             Next Month: " + this.TotalLineVolumeM1.ToString("N2") + ",             Next Two Month: " + this.TotalLineVolumeM2.ToString("N2") + ",             Next Three Month: " + this.TotalLineVolumeM3.ToString("N2"); }
        }

        public override void PerformPresaveRule()
        {
            base.PerformPresaveRule();

            this.DtoDetails().ToList().ForEach(e => { e.ForecastLocationID = this.ForecastLocationID; e.VoucherCode = this.VoucherCode; });
        }

        protected override List<ValidationRule> CreateRules()
        {
            List<ValidationRule> validationRules = base.CreateRules();
            validationRules.Add(new SimpleValidationRule(CommonExpressions.PropertyName<ForecastPrimitiveDTO>(p => p.ForecastLocationID), "Vui lòng chọn Location.", delegate { return (this.ForecastLocationID != null && this.ForecastLocationID > 0); }));

            return validationRules;
        }

    }

    
    public class ForecastDTO : ForecastPrimitiveDTO, IBaseDetailEntity<ForecastDetailDTO>
    {
        public ForecastDTO()
        {
            this.ForecastViewDetails = new BindingList<ForecastDetailDTO>();
        }


        public BindingList<ForecastDetailDTO> ForecastViewDetails { get; set; }
        public BindingList<ForecastDetailDTO> ViewDetails { get { return this.ForecastViewDetails; } set { this.ForecastViewDetails = value; } }

        public ICollection<ForecastDetailDTO> GetDetails() { return this.ForecastViewDetails; }

        protected override IEnumerable<ForecastDetailDTO> DtoDetails() { return this.ForecastViewDetails; }
    }
}

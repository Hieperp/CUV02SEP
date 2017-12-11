using System;
using System.Text;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

using TotalModel;
using TotalBase.Enums;

namespace TotalDTO.Commons
{
    public class CommodityPrimitiveDTO : BaseDTO, IPrimitiveEntity, IPrimitiveDTO
    {
        public override GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.Commodity; } }

        public override int GetID() { return this.CommodityID; }
        public void SetID(int id) { this.CommodityID = id; }

        public int CommodityID { get; set; }

        private string code;
        [DefaultValue(null)]
        public string Code
        {
            get { return this.code; }
            set { ApplyPropertyChange<CommodityPrimitiveDTO, string>(ref this.code, o => o.Code, value); }
        }

        private string officialCode;
        [DefaultValue(null)]
        public string OfficialCode
        {
            get { return this.officialCode; }
            set { ApplyPropertyChange<CommodityPrimitiveDTO, string>(ref this.officialCode, o => o.OfficialCode, value); }
        }

        private string name;
        [DefaultValue(null)]
        public string Name
        {
            get { return this.name; }
            set { ApplyPropertyChange<CommodityPrimitiveDTO, string>(ref this.name, o => o.Name, value); }
        }

        private string officialName;
        [DefaultValue(null)]
        public string OfficialName
        {
            get { return this.officialName; }
            set { ApplyPropertyChange<CommodityPrimitiveDTO, string>(ref this.officialName, o => o.OfficialName, value); }
        }

        private Nullable<int> commodityTypeID;
        [DefaultValue(null)]
        public Nullable<int> CommodityTypeID
        {
            get { return this.commodityTypeID; }
            set { ApplyPropertyChange<CommodityPrimitiveDTO, Nullable<int>>(ref this.commodityTypeID, o => o.CommodityTypeID, value); }
        }

        private Nullable<int> commodityCategoryID;
        [DefaultValue(null)]
        public Nullable<int> CommodityCategoryID
        {
            get { return this.commodityCategoryID; }
            set { ApplyPropertyChange<CommodityPrimitiveDTO, Nullable<int>>(ref this.commodityCategoryID, o => o.CommodityCategoryID, value); }
        }


        private string unit;
        [DefaultValue(null)]
        public string Unit
        {
            get { return this.unit; }
            set { ApplyPropertyChange<CommodityPrimitiveDTO, string>(ref this.unit, o => o.Unit, value); }
        }

        private string packageSize;
        [DefaultValue(null)]
        public string PackageSize
        {
            get { return this.packageSize; }
            set { ApplyPropertyChange<CommodityPrimitiveDTO, string>(ref this.packageSize, o => o.PackageSize, value); }
        }

        private string origin;
        [DefaultValue(null)]
        public string Origin
        {
            get { return this.origin; }
            set { ApplyPropertyChange<CommodityPrimitiveDTO, string>(ref this.origin, o => o.Origin, value); }
        }

        private string apiCode;
        [DefaultValue(null)]
        public string APICode
        {
            get { return this.apiCode; }
            set { ApplyPropertyChange<CommodityPrimitiveDTO, string>(ref this.apiCode, o => o.APICode, value); }
        }

        private string fillingLineIDs;
        [DefaultValue(null)]
        public string FillingLineIDs
        {
            get { return this.fillingLineIDs; }
            set { ApplyPropertyChange<CommodityPrimitiveDTO, string>(ref this.fillingLineIDs, o => o.FillingLineIDs, value); }
        }

        private decimal volume;
        [DefaultValue(0)]
        [Range(1, 99999999999, ErrorMessage = "Volume không hợp lệ")]
        public virtual decimal Volume
        {
            get { return this.volume; }
            set { ApplyPropertyChange<CommodityPrimitiveDTO, decimal>(ref this.volume, o => o.Volume, Math.Round(value, (int)GlobalEnums.rndVolume)); }
        }

        private decimal packageVolume;
        [DefaultValue(0)]
        [Range(1, 99999999999, ErrorMessage = "PackageVolume không hợp lệ")]
        public virtual decimal PackageVolume
        {
            get { return this.packageVolume; }
            set { ApplyPropertyChange<CommodityPrimitiveDTO, decimal>(ref this.packageVolume, o => o.PackageVolume, Math.Round(value, (int)GlobalEnums.rndVolume)); }
        }

        private decimal weight;
        [DefaultValue(0)]
        [Range(1, 99999999999, ErrorMessage = "Weight không hợp lệ")]
        public virtual decimal Weight
        {
            get { return this.weight; }
            set { ApplyPropertyChange<CommodityPrimitiveDTO, decimal>(ref this.weight, o => o.Weight, Math.Round(value, (int)GlobalEnums.rndWeight)); }
        }


        private int packPerCarton;
        [DefaultValue(0)]
        [Range(1, 99999999999, ErrorMessage = "Pack per carton không hợp lệ")]
        public virtual int PackPerCarton
        {
            get { return this.packPerCarton; }
            set { ApplyPropertyChange<CommodityPrimitiveDTO, int>(ref this.packPerCarton, o => o.PackPerCarton, value); }
        }

        private int cartonPerPallet;
        [DefaultValue(0)]
        [Range(1, 99999999999, ErrorMessage = "Carton per pallet không hợp lệ")]
        public virtual int CartonPerPallet
        {
            get { return this.cartonPerPallet; }
            set { ApplyPropertyChange<CommodityPrimitiveDTO, int>(ref this.cartonPerPallet, o => o.CartonPerPallet, value); }
        }


        private int shelflife;
        [DefaultValue(0)]
        [Range(1, 99999999999, ErrorMessage = "Shelflife không hợp lệ")]
        public virtual int Shelflife
        {
            get { return this.shelflife; }
            set { ApplyPropertyChange<CommodityPrimitiveDTO, int>(ref this.shelflife, o => o.Shelflife, value); }
        }

        public Nullable<bool> Discontinue { get; set; }
    }

    public class CommodityDTO : CommodityPrimitiveDTO
    {
    }
}

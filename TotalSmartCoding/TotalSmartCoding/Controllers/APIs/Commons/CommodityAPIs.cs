using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;


using TotalBase.Enums;
using TotalModel.Models;

using TotalDTO.Inventories;

using TotalCore.Repositories.Commons;
using TotalBase;

namespace TotalSmartCoding.Controllers.APIs.Commons
{
    public class CommodityAPIs
    {
        private readonly ICommodityAPIRepository commodityAPIRepository;

        public CommodityAPIs(ICommodityAPIRepository commodityAPIRepository)
        {
            this.commodityAPIRepository = commodityAPIRepository;
        }


        public ICollection<CommodityIndex> GetCommodityIndexes()
        {
            return this.commodityAPIRepository.GetEntityIndexes<CommodityIndex>(ContextAttributes.User.UserID, ContextAttributes.FromDate, ContextAttributes.ToDate).ToList();
        }

        public IList<CommodityBase> GetCommodityBases()
        {
            return this.GetCommodityBases(false);
        }

        public IList<CommodityBase> GetCommodityBases(bool withNullRow)
        {
            return this.commodityAPIRepository.GetCommodityBases(withNullRow);
        }

        public IList<Commodity> SearchCommodities(int? commodityID)
        {
            return this.commodityAPIRepository.SearchCommodities(commodityID);
        }
    }
}

using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

using TotalDTO.Inventories;
using TotalCore.Repositories.Commons;

namespace TotalSmartCoding.Controllers.APIs.Commons
{
    public class LocationAPIs
    {
        private readonly ILocationAPIRepository locationAPIRepository;

        public LocationAPIs(ILocationAPIRepository locationAPIRepository)
        {
            this.locationAPIRepository = locationAPIRepository;
        }


        public ICollection<LocationIndex> GetLocationIndexes()
        {
            return this.locationAPIRepository.GetEntityIndexes<LocationIndex>(ContextAttributes.User.UserID, GlobalEnums.GlobalOptionSetting.LowerFillterDate, GlobalEnums.GlobalOptionSetting.UpperFillterDate).ToList();
        }
        
        public IList<LocationBase> GetLocationBases()
        {
            return this.GetLocationBases(false);
        }

        public IList<LocationBase> GetLocationBases(bool withNullRow)
        {
            return this.locationAPIRepository.GetLocationBases(withNullRow);
        }

    }
}

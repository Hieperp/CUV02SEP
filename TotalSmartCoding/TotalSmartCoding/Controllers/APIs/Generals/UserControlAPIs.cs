using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

using TotalCore.Repositories.Generals;

namespace TotalSmartCoding.Controllers.APIs.Generals
{
    public class UserControlAPIs
    {
        private readonly IUserControlAPIRepository userControlAPIRepository;

        public UserControlAPIs(IUserControlAPIRepository userControlAPIRepository)
        {
            this.userControlAPIRepository = userControlAPIRepository;
        }


        public ICollection<UserControlIndex> GetUserControlIndexes()
        {
            return this.userControlAPIRepository.GetEntityIndexes<UserControlIndex>(ContextAttributes.User.UserID, GlobalEnums.GlobalOptionSetting.LowerFillterDate, GlobalEnums.GlobalOptionSetting.UpperFillterDate).ToList();
        }

        public IList<UserControlGroup> GetUserControlGroups(string securityIdentifier)
        {
            return this.userControlAPIRepository.GetUserControlGroups(securityIdentifier);
        }

        public IList<UserControlAvailableGroup> GetUserControlAvailableGroups(string securityIdentifier)
        {
            return this.userControlAPIRepository.GetUserControlAvailableGroups(securityIdentifier);
        }

    }
}

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
    public class UserGroupAPIs
    {
        private readonly IUserGroupAPIRepository userGroupAPIRepository;

        public UserGroupAPIs(IUserGroupAPIRepository userGroupAPIRepository)
        {
            this.userGroupAPIRepository = userGroupAPIRepository;
        }


        public ICollection<UserGroupIndex> GetUserGroupIndexes()
        {
            return this.userGroupAPIRepository.GetEntityIndexes<UserGroupIndex>(ContextAttributes.User.UserID, GlobalEnums.GlobalOptionSetting.LowerFillterDate, GlobalEnums.GlobalOptionSetting.UpperFillterDate).ToList();
        }

        public int UserGroupAdd(string code, string name, string description)
        {
            return this.userGroupAPIRepository.UserGroupAdd(code, name, description);
        }

        public int UserGroupRemove(int? userGroupID, string code)
        {
            return this.userGroupAPIRepository.UserGroupRemove(userGroupID, code);
        }

        public IList<UserGroupControl> GetUserGroupControls(int? userGroupID)
        {
            return this.userGroupAPIRepository.GetUserGroupControls(userGroupID);
        }

    }
}
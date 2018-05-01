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

        public int UserGroupAddMember(int? userGroupID, string securityIdentifier)
        {
            return this.userGroupAPIRepository.UserGroupAddMember(userGroupID, securityIdentifier);
        }

        public int UserGroupRemoveMember(int? userGroupDetailID)
        {
            return this.userGroupAPIRepository.UserGroupRemoveMember(userGroupDetailID);
        }

        public IList<UserGroupAvailableMember> GetUserGroupAvailableMembers(int? userGroupID)
        {
            return this.userGroupAPIRepository.GetUserGroupAvailableMembers(userGroupID).ToList();
        }

        public IList<UserGroupMember> GetUserGroupMembers(int? userGroupID)
        {
            return this.userGroupAPIRepository.GetUserGroupMembers(userGroupID);
        }

        public IList<UserGroupControl> GetUserGroupControls(int? userGroupID)
        {
            return this.userGroupAPIRepository.GetUserGroupControls(userGroupID);
        }

        public int SaveUserGroupControls(int? userGroupControlID, int? accessLevel, bool? approvalPermitted, bool? unApprovalPermitted, bool? voidablePermitted, bool? unVoidablePermitted, bool? showDiscount)
        {
            return this.userGroupAPIRepository.SaveUserGroupControls(userGroupControlID, accessLevel, approvalPermitted, unApprovalPermitted, voidablePermitted, unVoidablePermitted, showDiscount);
        }

    }
}
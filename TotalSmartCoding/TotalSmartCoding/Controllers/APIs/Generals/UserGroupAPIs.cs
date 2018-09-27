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
            int userGroupID = this.userGroupAPIRepository.UserGroupAdd(code, name, description);

            this.AddDataLogs("Add new group", userGroupID, code, name, description);

            return userGroupID;
        }

        public int UserGroupRemove(int userGroupID, string code, string name, string description)
        {
            int affectedRows = this.userGroupAPIRepository.UserGroupRemove(userGroupID, code);

            this.AddDataLogs("Delete group", userGroupID, code, name, description);

            return affectedRows;
        }

        public int UserGroupAddMember(int userGroupID, string userGroupcode, string securityIdentifier, string userName)
        {
            int userGroupDetailID = this.userGroupAPIRepository.UserGroupAddMember(userGroupID, securityIdentifier);

            this.AddDataLogs("Add new member", userGroupDetailID, userGroupcode, userName);

            return userGroupDetailID;
        }

        public int UserGroupRemoveMember(int userGroupDetailID, string userGroupcode, string userName)
        {
            int affectedRows = this.userGroupAPIRepository.UserGroupRemoveMember(userGroupDetailID);

            this.AddDataLogs("Remove member", userGroupDetailID, userGroupcode, userName);

            return affectedRows;
        }

        public IList<UserGroupAvailableMember> GetUserGroupAvailableMembers(int? userGroupID)
        {
            return this.userGroupAPIRepository.GetUserGroupAvailableMembers(userGroupID);
        }

        public IList<UserGroupMember> GetUserGroupMembers(int? userGroupID)
        {
            return this.userGroupAPIRepository.GetUserGroupMembers(userGroupID);
        }

        public IList<UserGroupControl> GetUserGroupControls(int? userGroupID)
        {
            return this.userGroupAPIRepository.GetUserGroupControls(userGroupID);
        }

        public IList<UserGroupReport> GetUserGroupReports(int? userGroupID)
        {
            return this.userGroupAPIRepository.GetUserGroupReports(userGroupID);
        }

        public int SaveUserGroupControls(int? userGroupControlID, int? accessLevel, bool? approvalPermitted, bool? unApprovalPermitted, bool? voidablePermitted, bool? unVoidablePermitted, bool? showDiscount)
        {
            return this.userGroupAPIRepository.SaveUserGroupControls(userGroupControlID, accessLevel, approvalPermitted, unApprovalPermitted, voidablePermitted, unVoidablePermitted, showDiscount);
        }

        public int SaveUserGroupReports(int? userGroupReportID, bool? enabled)
        {
            return this.userGroupAPIRepository.SaveUserGroupReports(userGroupReportID, enabled);
        }


        private void AddDataLogs(string actionType, int userGroupID, string code, string name, string description)
        {
            if (!this.userGroupAPIRepository.GetOnDataLogs()) return;// DO NOTHING

            DateTime entryDate = DateTime.Now;

            this.userGroupAPIRepository.AddDataLogs(userGroupID, null, entryDate, "UserControls", actionType, "UserGroup", "UserGroupID", userGroupID.ToString());
            this.userGroupAPIRepository.AddDataLogs(userGroupID, null, entryDate, "UserControls", actionType, "UserGroup", "Code", code);
            this.userGroupAPIRepository.AddDataLogs(userGroupID, null, entryDate, "UserControls", actionType, "UserGroup", "Name", name);
            this.userGroupAPIRepository.AddDataLogs(userGroupID, null, entryDate, "UserControls", actionType, "UserGroup", "Description", description);
        }

        private void AddDataLogs(string actionType, int userGroupDetailID, string userGroupCode, string userName)
        {
            if (!this.userGroupAPIRepository.GetOnDataLogs()) return;// DO NOTHING

            DateTime entryDate = DateTime.Now;

            this.userGroupAPIRepository.AddDataLogs(userGroupDetailID, null, entryDate, "UserControls", actionType, "UserGroupDetail", "GroupCode", userGroupCode);
            this.userGroupAPIRepository.AddDataLogs(userGroupDetailID, null, entryDate, "UserControls", actionType, "UserGroupDetail", "UserName", userName);
        }
    }
}
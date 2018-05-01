using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Generals
{
    public interface IUserGroupRepository : IGenericRepository<UserGroup>
    {
    }

    public interface IUserGroupAPIRepository : IGenericAPIRepository
    {
        int UserGroupAdd(string code, string name, string description);
        int UserGroupRemove(int? userGroupID, string code);

        int UserGroupAddMember(int? userGroupID, string securityIdentifier);
        int UserGroupRemoveMember(int? userGroupID, string securityIdentifier);

        IList<UserGroupAvailableMember> GetUserGroupAvailableMembers(int? userGroupID);

        IList<UserGroupMember> GetUserGroupMembers(int? userGroupID);

        IList<UserGroupControl> GetUserGroupControls(int? userGroupID);
        int SaveUserGroupControls(int? userGroupControlID, int? accessLevel, bool? approvalPermitted, bool? unApprovalPermitted, bool? voidablePermitted, bool? unVoidablePermitted, bool? showDiscount);
    }

}

using System.Linq;
using System.Collections.Generic;

using TotalModel.Models;
using TotalCore.Repositories.Generals;

namespace TotalDAL.Repositories.Generals
{
    public class UserGroupRepository : GenericRepository<UserGroup>, IUserGroupRepository
    {
        public UserGroupRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities, "UserGroupEditable")
        {
        }
    }





    public class UserGroupAPIRepository : GenericAPIRepository, IUserGroupAPIRepository
    {
        public UserGroupAPIRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities, "GetUserGroupIndexes")
        {
        }

        public int UserGroupAdd(string code, string name, string description)
        {
            return this.TotalSmartCodingEntities.UserGroupAdd(code, name, description);
        }

        public int UserGroupRemove(int? userGroupID, string code)
        {
            return this.TotalSmartCodingEntities.UserGroupRemove(userGroupID, code);
        }

        public IList<UserGroupControl> GetUserGroupControls(int? userGroupID)
        {
            return this.TotalSmartCodingEntities.GetUserGroupControls(userGroupID).ToList();
        }

        public int SaveUserGroupControls(int? userGroupControlID, int? accessLevel, bool? approvalPermitted, bool? unApprovalPermitted, bool? voidablePermitted, bool? unVoidablePermitted, bool? showDiscount)
        {
            return this.TotalSmartCodingEntities.SaveUserGroupControls(userGroupControlID, accessLevel, approvalPermitted, unApprovalPermitted, voidablePermitted, unVoidablePermitted, showDiscount);
        }

    }
}

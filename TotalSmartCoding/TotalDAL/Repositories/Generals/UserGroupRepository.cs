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
    }
}

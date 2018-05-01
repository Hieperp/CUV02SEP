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

        IList<UserGroupControl> GetUserGroupControls(int? userGroupID);
    }

}

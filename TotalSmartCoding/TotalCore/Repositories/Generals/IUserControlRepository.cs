using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Generals
{
    public interface IUserControlAPIRepository : IGenericAPIRepository
    {
        IList<UserControlGroup> GetUserControlGroups(string securityIdentifier);
        IList<UserControlAvailableGroup> GetUserControlAvailableGroups(string securityIdentifier);


        int UpdateUserName(string securityIdentifier, string userName);
    }
}

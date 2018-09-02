using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Generals
{
    public interface IUserControlAPIRepository : IGenericAPIRepository
    {


        IList<UserControlGroup> GetUserControlGroups(string securityIdentifier);
    }
}

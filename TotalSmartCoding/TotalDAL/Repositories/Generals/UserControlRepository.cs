using System.Linq;
using System.Collections.Generic;

using TotalModel.Models;
using TotalCore.Repositories.Generals;

namespace TotalDAL.Repositories.Generals
{
    public class UserControlAPIRepository : GenericAPIRepository, IUserControlAPIRepository
    {
        public UserControlAPIRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities, "GetUserControlIndexes")
        {
        }

        public IList<UserControlGroup> GetUserControlGroups(string securityIdentifier)
        {
            return this.TotalSmartCodingEntities.GetUserControlGroups(securityIdentifier).ToList();
        }

        public IList<UserControlAvailableGroup> GetUserControlAvailableGroups(string securityIdentifier)
        {
            return this.TotalSmartCodingEntities.GetUserControlAvailableGroups(securityIdentifier).ToList();
        }
        
    }
}

using System.Linq;
using System.Collections.Generic;

using TotalModel.Models;
using TotalCore.Repositories.Generals;

namespace TotalDAL.Repositories.Generals
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities)
        {
        }
    }





    public class UserAPIRepository : GenericAPIRepository, IUserAPIRepository
    {
        public UserAPIRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities, "GetUserIndexes")
        {
        }
    }
}

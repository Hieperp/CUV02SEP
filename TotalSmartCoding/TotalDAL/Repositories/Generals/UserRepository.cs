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

        public IList<OrganizationalUnitIndex> GetOrganizationalUnitIndexes()
        {
            return this.TotalSmartCodingEntities.GetOrganizationalUnitIndexes().ToList();
        }

        public IList<UserAccessControl> GetUserAccessControls(int? userID, int? nmvnTaskID)
        {
            return this.TotalSmartCodingEntities.GetUserAccessControls(userID, nmvnTaskID).ToList();
        }

        public int UserAdd(int? organizationalUnitID, string firstName, string lastName, string userName, string skypeName)
        {
            return this.TotalSmartCodingEntities.UserAdd(organizationalUnitID, firstName, lastName, userName, skypeName);
        }

        public int UserRemove(int? userID)
        {
            return this.TotalSmartCodingEntities.UserRemove(userID);
        }

        public int SaveUserAccessControls(int? accessControlID, int? accessLevel, bool? approvalPermitted, bool? unApprovalPermitted, bool? voidablePermitted, bool? unVoidablePermitted, bool? showDiscount)
        {
            return this.TotalSmartCodingEntities.SaveUserAccessControls(accessControlID, accessLevel, approvalPermitted, unApprovalPermitted, voidablePermitted, unVoidablePermitted, showDiscount);
        }
    }
}

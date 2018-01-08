using System;
using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;

using TotalModel.Models;
using TotalCore.Repositories.Generals;
using TotalBase.Enums;

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

        protected override ObjectParameter[] GetEntityIndexParameters(int userID, DateTime fromDate, DateTime toDate)
        {
            ObjectParameter[] baseParameters = base.GetEntityIndexParameters(userID, fromDate, toDate);

            return new ObjectParameter[] { baseParameters[0], baseParameters[1], baseParameters[2], new ObjectParameter("ActiveOption", (int)(this.RepositoryBag["ActiveOption"] != null ? this.RepositoryBag["ActiveOption"] : GlobalEnums.ActiveOption.Both)) };
        }

        public List<UserTree> GetUserTrees(int? activeOption)
        {
            return this.TotalSmartCodingEntities.GetUserTrees(activeOption).ToList();
        }

        public IList<OrganizationalUnitIndex> GetOrganizationalUnitIndexes()
        {
            return this.TotalSmartCodingEntities.GetOrganizationalUnitIndexes().ToList();
        }

        public IList<ActiveUser> GetActiveUsers(string securityIdentifier)
        {
            return this.TotalSmartCodingEntities.GetActiveUsers(securityIdentifier).ToList();
        }

        public IList<UserAccessControl> GetUserAccessControls(int? userID, int? nmvnTaskID)
        {
            return this.TotalSmartCodingEntities.GetUserAccessControls(userID, nmvnTaskID).ToList();
        }

        public int UserRegister(int? locationID, int? organizationalUnitID, string firstName, string lastName, string userName, string securityIdentifier)
        {
            return this.TotalSmartCodingEntities.UserRegister(locationID, organizationalUnitID, firstName, lastName, userName, securityIdentifier);
        }

        public int UserUnregister(int? userID)
        {
            return this.TotalSmartCodingEntities.UserUnregister(userID);
        }

        public int SaveUserAccessControls(int? accessControlID, int? accessLevel, bool? approvalPermitted, bool? unApprovalPermitted, bool? voidablePermitted, bool? unVoidablePermitted, bool? showDiscount)
        {
            return this.TotalSmartCodingEntities.SaveUserAccessControls(accessControlID, accessLevel, approvalPermitted, unApprovalPermitted, voidablePermitted, unVoidablePermitted, showDiscount);
        }
    }
}

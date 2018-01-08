using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Generals
{
    public interface IUserRepository
    {

    }

    public interface IUserAPIRepository : IGenericAPIRepository
    {
        List<UserTree> GetUserTrees(int? activeOption);
        IList<OrganizationalUnitIndex> GetOrganizationalUnitIndexes();

        IList<ActiveUser> GetActiveUsers(string securityIdentifier);

        IList<UserAccessControl> GetUserAccessControls(int? userID, int? nmvnTaskID);

        int UserRegister(int? locationID, int? organizationalUnitID, string firstName, string lastName, string userName, string securityIdentifier);
        int UserUnregister(int? userID, string userName, string organizationalUnitName);
        int SaveUserAccessControls(int? accessControlID, int? accessLevel, bool? approvalPermitted, bool? unApprovalPermitted, bool? voidablePermitted, bool? unVoidablePermitted, bool? showDiscount);
    }
}

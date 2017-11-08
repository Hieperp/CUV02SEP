using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Generals
{
    public interface IUserRepository
    {

    }

    public interface IUserAPIRepository : IGenericAPIRepository
    {
        IList<OrganizationalUnitIndex> GetOrganizationalUnitIndexes();

        IList<UserAccessControl> GetUserAccessControls(int? userID, int? nmvnTaskID);

        int UserRemove(int? userID);
        int UserAdd(int? organizationalUnitID, string firstName, string lastName, string userName, string skypeName);
        int SaveUserAccessControls(int? accessControlID, int? accessLevel, bool? approvalPermitted, bool? unApprovalPermitted, bool? voidablePermitted, bool? unVoidablePermitted, bool? showDiscount);
    }
}

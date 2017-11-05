using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Generals
{
    public interface IUserRepository
    {

    }

    public interface IUserAPIRepository : IGenericAPIRepository
    {
        IList<UserAccessControl> GetUserAccessControls(int? userID, int? nmvnTaskID);
        int SaveUserAccessControls(int? accessControlID, int? accessLevel, bool? approvalPermitted, bool? unApprovalPermitted, bool? voidablePermitted, bool? unVoidablePermitted, bool? showDiscount);
    }
}

﻿using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Generals
{
    public interface IUserControlRepository : IGenericRepository<User>
    {
    }

    public interface IUserControlAPIRepository : IGenericAPIRepository
    {
        IList<UserControlGroup> GetUserControlGroups(string securityIdentifier);
        IList<UserControlAvailableGroup> GetUserControlAvailableGroups(string securityIdentifier);

        int UserControlRegister(string firstName, string lastName, string userName, string securityIdentifier);
        int UserControlUnregister(int? userID);
        int UserControlToggleVoid(int? userID, bool? inActive);

        int UpdateUserName(string securityIdentifier, string userName);
    }
}

﻿using System.Linq;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;

using TotalModel.Models;
using TotalCore.Repositories.Generals;

namespace TotalDAL.Repositories.Generals
{
    public class UserControlRepository : GenericRepository<User>, IUserControlRepository
    {
        public UserControlRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities, "UserControlEditable")
        {
        }
    }

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

        public IList<UserControlSalesperson> GetUserControlSalespersons(string securityIdentifier)
        {
            return this.TotalSmartCodingEntities.GetUserControlSalespersons(securityIdentifier).ToList();
        }

        public IList<UserControlAvailableSalesperson> GetUserControlAvailableSalespersons(string securityIdentifier)
        {
            return this.TotalSmartCodingEntities.GetUserControlAvailableSalespersons(securityIdentifier).ToList();
        }

        public int UserControlAddSalesperson(string securityIdentifier, int? employeeID)
        {
            return (int)this.TotalSmartCodingEntities.UserControlAddSalesperson(securityIdentifier, employeeID).FirstOrDefault();
        }
        public int UserControlRemoveSalesperson(int? userSalespersonID)
        {
            return this.TotalSmartCodingEntities.UserControlRemoveSalesperson(userSalespersonID);
        }




        
        public int UserControlRegister(string firstName, string lastName, string userName, string securityIdentifier)
        {
            return this.TotalSmartCodingEntities.UserControlRegister(firstName, lastName, userName, securityIdentifier);
        }

        public int UserControlUnregister(int? userID)
        {
            return this.TotalSmartCodingEntities.UserControlUnregister(userID);
        }

        public int UserControlToggleVoid(int? userID, bool? inActive)
        {
            return this.TotalSmartCodingEntities.UserControlToggleVoid(userID, inActive);
        }


        public int UpdateUserName(string securityIdentifier, string userName)
        {
            return this.ExecuteStoreCommand(@" UPDATE Users SET UserName =  N'" + userName + "' WHERE SecurityIdentifier = N'" + securityIdentifier + "'", new ObjectParameter[] { });
        }

        public int UpdateOnDataLogs(int onDataLogs)
        {
            return this.TotalSmartCodingEntities.UpdateOnDataLogs(onDataLogs);
        }
        public int UpdateOnEventLogs(int onEventLogs)
        {
            return this.TotalSmartCodingEntities.UpdateOnEventLogs(onEventLogs);
        }
    }
}

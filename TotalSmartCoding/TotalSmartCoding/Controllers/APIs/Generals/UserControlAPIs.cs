using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;

using TotalCore.Repositories.Generals;

namespace TotalSmartCoding.Controllers.APIs.Generals
{
    public class UserControlAPIs
    {
        private readonly IUserControlAPIRepository userControlAPIRepository;

        public UserControlAPIs(IUserControlAPIRepository userControlAPIRepository)
        {
            this.userControlAPIRepository = userControlAPIRepository;
        }


        public List<UserControlIndex> GetUserControlIndexes()
        {
            return this.userControlAPIRepository.GetEntityIndexes<UserControlIndex>(ContextAttributes.User.UserID, GlobalEnums.GlobalOptionSetting.LowerFillterDate, GlobalEnums.GlobalOptionSetting.UpperFillterDate).ToList();
        }

        public IList<UserControlGroup> GetUserControlGroups(string securityIdentifier)
        {
            return this.userControlAPIRepository.GetUserControlGroups(securityIdentifier);
        }

        public IList<UserControlAvailableGroup> GetUserControlAvailableGroups(string securityIdentifier)
        {
            return this.userControlAPIRepository.GetUserControlAvailableGroups(securityIdentifier);
        }

        public IList<UserControlSalesperson> GetUserControlSalespersons(string securityIdentifier)
        {
            return this.userControlAPIRepository.GetUserControlSalespersons(securityIdentifier);
        }

        public IList<UserControlAvailableSalesperson> GetUserControlAvailableSalespersons(string securityIdentifier)
        {
            return this.userControlAPIRepository.GetUserControlAvailableSalespersons(securityIdentifier);
        }

        public int UserControlAddSalesperson(string securityIdentifier, int? employeeID)
        {
            return this.userControlAPIRepository.UserControlAddSalesperson(securityIdentifier, employeeID);
        }
        public int UserControlRemoveSalesperson(int? userSalespersonID)
        {
            return this.userControlAPIRepository.UserControlRemoveSalesperson(userSalespersonID);
        }




        
        public int UserControlRegister(string firstName, string lastName, string userName, string securityIdentifier)
        {
            return this.userControlAPIRepository.UserControlRegister(firstName, lastName, userName, securityIdentifier);
        }

        public int UserControlUnregister(int? userID)
        {
            return this.userControlAPIRepository.UserControlUnregister(userID);
        }

        public int UserControlToggleVoid(int? userID, bool? inActive)
        {
            return this.userControlAPIRepository.UserControlToggleVoid(userID, inActive);
        }




        public int UpdateUserName(string securityIdentifier, string userName)
        {
            return this.userControlAPIRepository.UpdateUserName(securityIdentifier, userName);
        }
    }
}

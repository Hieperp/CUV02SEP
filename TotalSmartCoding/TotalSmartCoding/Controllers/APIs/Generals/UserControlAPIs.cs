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

        public int UserControlAddSalesperson(string userName, string securityIdentifier, int employeeID, string employeeName)
        {
            int userSalespersonID = this.userControlAPIRepository.UserControlAddSalesperson(securityIdentifier, employeeID);

            this.AddDataLogs("Add salesperson to user's filterings", userSalespersonID, userName, securityIdentifier, employeeID, employeeName);

            return userSalespersonID;
        }
        public int UserControlRemoveSalesperson(int userSalespersonID, string userName, string securityIdentifier, int employeeID, string employeeName)
        {
            int affectedRows = this.userControlAPIRepository.UserControlRemoveSalesperson(userSalespersonID);

            this.AddDataLogs("Remove salesperson from user's filterings", userSalespersonID, userName, securityIdentifier, employeeID, employeeName);

            return affectedRows;
        }





        public int UserControlRegister(string firstName, string lastName, string userName, string securityIdentifier)
        {
            int affectedRows = this.userControlAPIRepository.UserControlRegister(firstName, lastName, userName, securityIdentifier);

            this.AddDataLogs("Register new user", userName, securityIdentifier, null);

            return affectedRows;
        }

        public int UserControlUnregister(int? userID, string userName, string securityIdentifier)
        {
            int affectedRows = this.userControlAPIRepository.UserControlUnregister(userID);

            this.AddDataLogs("Deregister new user", userName, securityIdentifier, null);

            return affectedRows;
        }

        public int UserControlToggleVoid(int? userID, string userName, string securityIdentifier, bool inActive)
        {
            int affectedRows = this.userControlAPIRepository.UserControlToggleVoid(userID, inActive);

            this.AddDataLogs("Set user active status", userName, securityIdentifier, inActive ? "Inactive" : "Active");

            return affectedRows;
        }




        public int UpdateUserName(string securityIdentifier, string userName)
        {
            return this.userControlAPIRepository.UpdateUserName(securityIdentifier, userName);
        }

        public int UpdateOnDataLogs(int onDataLogs)
        {
            return this.userControlAPIRepository.UpdateOnDataLogs(onDataLogs);
        }

        public int UpdateOnEventLogs(int onEventLogs)
        {
            return this.userControlAPIRepository.UpdateOnEventLogs(onEventLogs);
        }





        private void AddDataLogs(string actionType, string userName, string securityIdentifier, string activeStatus)
        {
            if (!this.userControlAPIRepository.GetOnDataLogs()) return;// DO NOTHING

            DateTime entryDate = DateTime.Now;

            this.userControlAPIRepository.AddDataLogs(null, null, entryDate, "UserControls", actionType, "User", "UserName", userName);
            this.userControlAPIRepository.AddDataLogs(null, null, entryDate, "UserControls", actionType, "User", "SecurityIdentifier", securityIdentifier);

            if (activeStatus != null)
                this.userControlAPIRepository.AddDataLogs(null, null, entryDate, "UserControls", actionType, "User", "ActiveStatus", activeStatus);
        }

        private void AddDataLogs(string actionType, int userSalespersonID, string userName, string securityIdentifier, int employeeID, string employeeName)
        {
            if (!this.userControlAPIRepository.GetOnDataLogs()) return;// DO NOTHING

            DateTime entryDate = DateTime.Now;

            this.userControlAPIRepository.AddDataLogs(userSalespersonID, null, entryDate, "UserControls", actionType, "UserSalesperson", "UserName", userName);
            this.userControlAPIRepository.AddDataLogs(userSalespersonID, null, entryDate, "UserControls", actionType, "UserSalesperson", "SecurityIdentifier", securityIdentifier);
            this.userControlAPIRepository.AddDataLogs(userSalespersonID, null, entryDate, "UserControls", actionType, "UserSalesperson", "EmployeeID", employeeID.ToString());
            this.userControlAPIRepository.AddDataLogs(userSalespersonID, null, entryDate, "UserControls", actionType, "UserSalesperson", "EmployeeName", employeeName);
        }
    }
}

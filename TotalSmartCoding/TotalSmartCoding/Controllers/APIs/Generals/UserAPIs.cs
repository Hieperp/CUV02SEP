﻿using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;


using TotalBase.Enums;
using TotalModel.Models;

using TotalDTO.Inventories;

using TotalCore.Repositories.Generals;
using TotalBase;

namespace TotalSmartCoding.Controllers.APIs.Generals
{
    public class UserAPIs
    {
        private readonly IUserAPIRepository userAPIRepository;

        public UserAPIs(IUserAPIRepository userAPIRepository)
        {
            this.userAPIRepository = userAPIRepository;
        }


        public ICollection<UserIndex> GetUserIndexes()
        {
            return this.userAPIRepository.GetEntityIndexes<UserIndex>(ContextAttributes.User.UserID, ContextAttributes.FromDate, ContextAttributes.ToDate).ToList();
        }

        public IList<OrganizationalUnitIndex> GetOrganizationalUnitIndexes()
        {
            return this.userAPIRepository.GetOrganizationalUnitIndexes().ToList();
        }

        public IList<UserAccessControl> GetUserAccessControls(int? userID, int? nmvnTaskID)
        {
            return this.userAPIRepository.GetUserAccessControls(userID, nmvnTaskID).ToList();
        }

        public int UserAdd(int? organizationalUnitID, string firstName, string lastName, string userName, string skypeName)
        {
            return this.userAPIRepository.UserAdd(organizationalUnitID, firstName, lastName, userName, skypeName);
        }

        public int UserRemove(int? userID)
        {
            return this.userAPIRepository.UserRemove(userID);
        }

        public int SaveUserAccessControls(int? accessControlID, int? accessLevel, bool? approvalPermitted, bool? unApprovalPermitted, bool? voidablePermitted, bool? unVoidablePermitted, bool? showDiscount)
        {
            return this.userAPIRepository.SaveUserAccessControls(accessControlID, accessLevel, approvalPermitted, unApprovalPermitted, voidablePermitted, unVoidablePermitted, showDiscount);
        }
    }
}

using System;
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
    }
}

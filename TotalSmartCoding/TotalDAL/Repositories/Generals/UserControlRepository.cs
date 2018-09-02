﻿using System.Linq;
using System.Collections.Generic;

using TotalModel.Models;
using TotalCore.Repositories.Generals;

namespace TotalDAL.Repositories.Generals
{
    public class UserControlAPIRepository : GenericAPIRepository, IUserControlAPIRepository
    {
        public UserControlAPIRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities, "GetUserControlIndexes")
        {
        }
    }
}

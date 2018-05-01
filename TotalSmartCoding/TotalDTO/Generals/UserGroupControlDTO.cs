﻿using TotalModel.Helpers;

namespace TotalDTO.Generals
{
    public class UserGroupControlDTO : AccessControlDTO
    {
        public int UserGroupControlID { get; set; }
        public int ModuleID { get; set; }
        public string ModuleName { get; set; }
        public int ModuleDetailID { get; set; }
        public string ModuleDetailName { get; set; }
        public int LocationID { get; set; }
        public string LocationName { get; set; }
    }
}

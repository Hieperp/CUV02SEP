﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TotalBase
{
    public class UserInformation
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int OrganizationalUnitID { get; set; }
        public DateTime UserDate { get; set; }

        public UserInformation() : this(-1, -1, "", DateTime.MinValue) { }

        public UserInformation(int userID, int organizationalUnitID, string userName, DateTime userDate)
        {
            this.UserID = userID;
            this.OrganizationalUnitID = organizationalUnitID;
            this.UserName = userName;
            this.UserDate = userDate;
        }
    }
}

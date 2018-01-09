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
    public class OrganizationalUnitAPIs
    {
        private readonly IOrganizationalUnitAPIRepository organizationalUnitAPIRepository;

        public OrganizationalUnitAPIs(IOrganizationalUnitAPIRepository organizationalUnitAPIRepository)
        {
            this.organizationalUnitAPIRepository = organizationalUnitAPIRepository;
        }


        public ICollection<OrganizationalUnitIndex> GetOrganizationalUnitIndexes()
        {
            return this.organizationalUnitAPIRepository.GetEntityIndexes<OrganizationalUnitIndex>(ContextAttributes.User.UserID, ContextAttributes.FromDate, ContextAttributes.ToDate).ToList();
        }
    }
}
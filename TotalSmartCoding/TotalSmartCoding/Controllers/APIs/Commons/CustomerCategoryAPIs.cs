using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;


using TotalBase.Enums;
using TotalModel.Models;

using TotalDTO.Inventories;

using TotalCore.Repositories.Commons;
using TotalBase;

namespace TotalSmartCoding.Controllers.APIs.Commons
{
    public class CustomerCategoryAPIs
    {
        private readonly ICustomerCategoryAPIRepository customerCategoryAPIRepository;

        public CustomerCategoryAPIs(ICustomerCategoryAPIRepository customerCategoryAPIRepository)
        {
            this.customerCategoryAPIRepository = customerCategoryAPIRepository;
        }


        public ICollection<CustomerCategoryIndex> GetCustomerCategoryIndexes()
        {
            return this.customerCategoryAPIRepository.GetEntityIndexes<CustomerCategoryIndex>(ContextAttributes.AspUserID, ContextAttributes.FromDate, ContextAttributes.ToDate).ToList();
        }

        public IList<CustomerCategoryBase> GetCustomerCategoryBases()
        {
            return this.customerCategoryAPIRepository.GetCustomerCategoryBases();
        }

    }
}

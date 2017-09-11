using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Commons
{
    public interface ICustomerRepository
    {

    }

    public interface ICustomerAPIRepository : IGenericAPIRepository
    {
        IList<CustomerBase> GetCustomerBases();
    }
}

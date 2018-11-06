using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Commons
{
    public interface ICustomerRepository : IGenericRepository<Customer>
    {
    }

    public interface ICustomerAPIRepository : IGenericAPIRepository
    {
        IList<CustomerBase> GetCustomerBases(bool isCustomer, bool isReceiver, int? parentID);
        IList<CustomerTree> GetCustomerTrees();

        int? CheckCustomerReceiverID(int? customerID, int? receiverID);
    }
}


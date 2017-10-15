using System.Collections.Generic;

using TotalBase;
using TotalModel.Models;
using TotalCore.Repositories.Sales;

namespace TotalSmartCoding.Controllers.APIs.Sales
{
    public class DeliveryAdviceAPIs
    {
        private readonly IDeliveryAdviceAPIRepository deliveryAdviceAPIRepository;

        public DeliveryAdviceAPIs(IDeliveryAdviceAPIRepository deliveryAdviceAPIRepository)
        {
            this.deliveryAdviceAPIRepository = deliveryAdviceAPIRepository;
        }


        public ICollection<DeliveryAdviceIndex> GetDeliveryAdviceIndexes()
        {
            return this.deliveryAdviceAPIRepository.GetEntityIndexes<DeliveryAdviceIndex>(ContextAttributes.AspUserID, ContextAttributes.FromDate, ContextAttributes.ToDate);
        }

        public List<PendingSalesOrder> GetPendingSalesOrders(int? locationID)
        {
            return this.deliveryAdviceAPIRepository.GetPendingSalesOrders(locationID);
        }


        public List<PendingSalesOrderCustomer> GetPendingSalesOrderCustomers(int? locationID)
        {
            return this.deliveryAdviceAPIRepository.GetPendingSalesOrderCustomers(locationID);
        }

        public List<PendingSalesOrderDetail> GetPendingSalesOrderDetails(int? locationID, int? deliveryAdviceID, int? salesOrderID, int? customerID, string salesOrderDetailIDs, bool isReadonly)
        {
            return this.deliveryAdviceAPIRepository.GetPendingSalesOrderDetails(locationID, deliveryAdviceID, salesOrderID, customerID, salesOrderDetailIDs, isReadonly);
        }

        public IList<BatchAvailable> GetBatchAvailables(int? locationID, int? deliveryAdviceID, int? commodityID, bool withNullRow)
        {
            return this.deliveryAdviceAPIRepository.GetBatchAvailables(locationID, deliveryAdviceID, commodityID, withNullRow);
        }

    }
}

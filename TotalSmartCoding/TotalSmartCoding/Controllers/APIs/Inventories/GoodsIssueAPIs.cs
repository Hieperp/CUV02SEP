using System.Collections.Generic;

using TotalBase;
using TotalModel.Models;
using TotalCore.Repositories.Inventories;

namespace TotalSmartCoding.Controllers.APIs.Inventories
{
    public class GoodsIssueAPIs
    {
        private readonly IGoodsIssueAPIRepository goodsIssueAPIRepository;

        public GoodsIssueAPIs(IGoodsIssueAPIRepository goodsIssueAPIRepository)
        {
            this.goodsIssueAPIRepository = goodsIssueAPIRepository;
        }


        public ICollection<GoodsIssueIndex> GetGoodsIssueIndexes()
        {
            return this.goodsIssueAPIRepository.GetEntityIndexes<GoodsIssueIndex>(ContextAttributes.AspUserID, ContextAttributes.FromDate, ContextAttributes.ToDate);
        }

        public List<PendingDeliveryAdvice> GetPendingDeliveryAdvices(int? locationID)
        {
            return this.goodsIssueAPIRepository.GetPendingDeliveryAdvices(locationID);
        }


        public List<PendingDeliveryAdviceCustomer> GetPendingDeliveryAdviceCustomers(int? locationID)
        {
            return this.goodsIssueAPIRepository.GetPendingDeliveryAdviceCustomers(locationID);
        }

        public List<PendingDeliveryAdviceDetail> GetPendingDeliveryAdviceDetails(int? locationID, int? goodsIssueID, int? deliveryAdviceID, int? customerID, string deliveryAdviceDetailIDs, bool isReadonly)
        {
            return this.goodsIssueAPIRepository.GetPendingDeliveryAdviceDetails(locationID, goodsIssueID, deliveryAdviceID, customerID, deliveryAdviceDetailIDs, isReadonly);
        }
    }
}

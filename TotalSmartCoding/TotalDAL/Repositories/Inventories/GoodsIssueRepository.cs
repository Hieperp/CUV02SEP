using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using TotalBase.Enums;
using TotalModel.Models;
using TotalCore.Repositories.Inventories;

namespace TotalDAL.Repositories.Inventories
{
    public class GoodsIssueRepository : GenericWithDetailRepository<GoodsIssue, GoodsIssueDetail>, IGoodsIssueRepository
    {
        public GoodsIssueRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities, "GoodsIssueEditable", "GoodsIssueApproved")
        {
        }
    }








    public class GoodsIssueAPIRepository : GenericAPIRepository, IGoodsIssueAPIRepository
    {
        public GoodsIssueAPIRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities, "GetGoodsIssueIndexes")
        {
        }

        public List<PendingDeliveryAdvice> GetPendingDeliveryAdvices(int? locationID)
        {
            return base.TotalSmartCodingEntities.GetPendingDeliveryAdvices(locationID).ToList();
        }

        public List<PendingDeliveryAdviceCustomer> GetPendingDeliveryAdviceCustomers(int? locationID)
        {
            return base.TotalSmartCodingEntities.GetPendingDeliveryAdviceCustomers(locationID).ToList();
        }

        public List<PendingDeliveryAdviceDetail> GetPendingDeliveryAdviceDetails(int? locationID, int? goodsIssueID, int? deliveryAdviceID, int? customerID, string deliveryAdviceDetailIDs, bool isReadonly)
        {
            return base.TotalSmartCodingEntities.GetPendingDeliveryAdviceDetails(locationID, goodsIssueID, deliveryAdviceID, customerID, deliveryAdviceDetailIDs, isReadonly).ToList();
        }


        public List<PendingTransferOrder> GetPendingTransferOrders(int? locationID)
        {
            return base.TotalSmartCodingEntities.GetPendingTransferOrders(locationID).ToList();
        }

        public List<PendingTransferOrderWarehouse> GetPendingTransferOrderWarehouses(int? locationID)
        {
            return base.TotalSmartCodingEntities.GetPendingTransferOrderWarehouses(locationID).ToList();
        }
    }


}

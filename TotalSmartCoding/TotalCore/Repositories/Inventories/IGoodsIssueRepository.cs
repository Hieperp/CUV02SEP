﻿using System;
using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Inventories
{
    public interface IGoodsIssueRepository : IGenericWithDetailRepository<GoodsIssue, GoodsIssueDetail>
    {
    }

    public interface IGoodsIssueAPIRepository : IGenericAPIRepository
    {
        List<PendingDeliveryAdvice> GetPendingDeliveryAdvices(int? locationID);
        List<PendingDeliveryAdviceCustomer> GetPendingDeliveryAdviceCustomers(int? locationID);
        List<PendingDeliveryAdviceDetail> GetPendingDeliveryAdviceDetails(int? locationID, int? goodsIssueID, int? deliveryAdviceID, int? customerID, string deliveryAdviceDetailIDs, bool isReadonly);
    }

}


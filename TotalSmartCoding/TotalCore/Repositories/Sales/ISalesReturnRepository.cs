using System;
using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Sales
{
    public interface ISalesReturnRepository : IGenericWithDetailRepository<SalesReturn, SalesReturnDetail>
    {
    }

    public interface ISalesReturnAPIRepository : IGenericAPIRepository
    {
        List<SalesReturnPendingGoodsIssue> GetGoodsIssues(int? locationID, int? customerID, int? receiverID, DateTime? fromDate, DateTime? toDate);
        List<SalesReturnPendingGoodsIssueDetail> GetPendingGoodsIssueDetails(int? locationID, int? salesReturnID, int? goodsIssueID, int? customerID, int? receiverID, DateTime? fromDate, DateTime? toDate, string cartonIDs, string palletIDs);
    }

}



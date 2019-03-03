using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using TotalBase.Enums;
using TotalModel.Models;
using TotalCore.Repositories.Sales;

namespace TotalDAL.Repositories.Sales
{
    public class SalesReturnRepository : GenericWithDetailRepository<SalesReturn, SalesReturnDetail>, ISalesReturnRepository
    {
        public SalesReturnRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities, "SalesReturnEditable", "SalesReturnApproved")
        {
        }
    }








    public class SalesReturnAPIRepository : GenericAPIRepository, ISalesReturnAPIRepository
    {
        public SalesReturnAPIRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities, "GetSalesReturnIndexes")
        {
        }

        public List<SalesReturnPendingGoodsIssue> GetGoodsIssues(int? locationID, int? customerID, int? receiverID, DateTime? fromDate, DateTime? toDate)
        {
            return base.TotalSmartCodingEntities.GetSalesReturnPendingGoodsIssues(locationID, customerID, receiverID, fromDate, toDate).ToList();
        }

        public List<SalesReturnPendingGoodsIssueDetail> GetPendingGoodsIssueDetails(int? locationID, int? salesReturnID, int? goodsIssueID, int? customerID, int? receiverID, DateTime? fromDate, DateTime? toDate, string cartonIDs, string palletIDs)
        {
            return base.TotalSmartCodingEntities.GetSalesReturnPendingGoodsIssueDetails(locationID, salesReturnID, goodsIssueID, customerID, receiverID, fromDate, toDate, cartonIDs, palletIDs).ToList();
        }
    }


}


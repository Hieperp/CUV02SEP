using System;
using System.Collections.Generic;

using TotalBase;
using TotalBase.Enums;
using TotalModel.Models;
using TotalCore.Repositories.Sales;

namespace TotalSmartCoding.Controllers.APIs.Sales
{
    public class SalesReturnAPIs
    {
        private readonly ISalesReturnAPIRepository salesReturnAPIRepository;

        public SalesReturnAPIs(ISalesReturnAPIRepository salesReturnAPIRepository)
        {
            this.salesReturnAPIRepository = salesReturnAPIRepository;
        }


        public ICollection<SalesReturnIndex> GetSalesReturnIndexes()
        {
            return this.salesReturnAPIRepository.GetEntityIndexes<SalesReturnIndex>(ContextAttributes.User.UserID, GlobalEnums.GlobalOptionSetting.LowerFillterDate, GlobalEnums.GlobalOptionSetting.UpperFillterDate);
        }

        public List<SalesReturnPendingGoodsIssueDetail> GetPendingGoodsIssueDetails(int? locationID, int? salesReturnID, int? goodsIssueID, int? customerID, int? receiverID, DateTime? fromDate, DateTime? toDate, string cartonIDs, string palletIDs)
        {
            return this.salesReturnAPIRepository.GetPendingGoodsIssueDetails(locationID, salesReturnID, goodsIssueID, customerID, receiverID, fromDate, toDate, cartonIDs, palletIDs);
        }
    }
}

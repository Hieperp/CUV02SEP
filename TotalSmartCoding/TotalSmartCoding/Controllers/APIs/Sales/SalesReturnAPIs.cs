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
    }
}

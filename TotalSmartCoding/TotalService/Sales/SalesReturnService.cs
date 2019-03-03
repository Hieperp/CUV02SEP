using System.Collections.Generic;
using System.Data.Entity.Core.Objects;

using TotalModel.Models;
using TotalDTO.Sales;
using TotalCore.Repositories.Sales;
using TotalCore.Services.Sales;

namespace TotalService.Sales
{
    public class SalesReturnService : GenericWithViewDetailService<SalesReturn, SalesReturnDetail, SalesReturnViewDetail, SalesReturnDTO, SalesReturnPrimitiveDTO, SalesReturnDetailDTO>, ISalesReturnService
    {
        public SalesReturnService(ISalesReturnRepository salesReturnRepository)
            : base(salesReturnRepository, "SalesReturnPostSaveValidate", "SalesReturnSaveRelative", "SalesReturnToggleApproved", null, null, "GetSalesReturnViewDetails")
        {
        }

        public override ICollection<SalesReturnViewDetail> GetViewDetails(int salesReturnID)
        {
            ObjectParameter[] parameters = new ObjectParameter[] { new ObjectParameter("SalesReturnID", salesReturnID) };
            return this.GetViewDetails(parameters);
        }
    }
}

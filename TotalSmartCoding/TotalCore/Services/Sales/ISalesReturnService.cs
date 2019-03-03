using TotalModel.Models;

using TotalDTO.Sales;

namespace TotalCore.Services.Sales
{
    public interface ISalesReturnService : IGenericWithViewDetailService<SalesReturn, SalesReturnDetail, SalesReturnViewDetail, SalesReturnDTO, SalesReturnPrimitiveDTO, SalesReturnDetailDTO>
    {
    }
}

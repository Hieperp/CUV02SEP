using TotalModel.Models;
using TotalDTO.Sales;

using TotalCore.Services.Sales;
using TotalSmartCoding.ViewModels.Sales;

namespace TotalSmartCoding.Controllers.Sales
{
    public class SalesReturnController : GenericViewDetailController<SalesReturn, SalesReturnDetail, SalesReturnViewDetail, SalesReturnDTO, SalesReturnPrimitiveDTO, SalesReturnDetailDTO, SalesReturnViewModel>
    {
        public SalesReturnController(ISalesReturnService salesReturnService, SalesReturnViewModel salesReturnViewModel)
            : base(salesReturnService, salesReturnViewModel)
        {
        }
    }
}

using TotalDTO;
using TotalDTO.Inventories;
using TotalSmartCoding.ViewModels.Helpers;

namespace TotalSmartCoding.ViewModels.Inventories
{
    public class GoodsReceiptViewModel : GoodsReceiptDTO, IViewDetailViewModel<GoodsReceiptDetailDTO>
    {
    }

    public class GoodsReceiptDetailAvailableViewModel : BaseDTO
    {
        public override bool DataInputable { get { return false; } }
    }
}

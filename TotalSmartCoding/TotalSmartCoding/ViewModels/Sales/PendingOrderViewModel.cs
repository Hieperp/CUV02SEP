using TotalBase.Enums;
using TotalDTO;
using TotalDTO.Inventories;
using TotalSmartCoding.ViewModels.Helpers;

namespace TotalSmartCoding.ViewModels.Sales
{
    public class PendingOrderViewModel : BaseDTO
    {
        public override GlobalEnums.NmvnTaskID NMVNTaskID { get { return GlobalEnums.NmvnTaskID.PendingOrders; } }

        public override bool AllowDataInput { get { return false; } }
    }
}

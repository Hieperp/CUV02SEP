using System;
using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Inventories
{
    public interface IWarehouseAdjustmentRepository : IGenericWithDetailRepository<WarehouseAdjustment, WarehouseAdjustmentDetail>
    {
        List<PendingWarehouseAdjustmentDetail> GetPendingWarehouseAdjustmentDetails(int? locationID, int? goodsReceiptID, int? warehouseAdjustmentID, int? warehouseID, string warehouseAdjustmentDetailIDs, bool isReadonly);
    }

    public interface IWarehouseAdjustmentAPIRepository : IGenericAPIRepository
    {
    }

}


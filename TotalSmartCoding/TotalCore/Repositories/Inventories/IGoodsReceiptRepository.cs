using System;
using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Inventories
{
    public interface IGoodsReceiptRepository : IGenericWithDetailRepository<GoodsReceipt, GoodsReceiptDetail>
    {
    }

    public interface IGoodsReceiptAPIRepository : IGenericAPIRepository
    {
        List<PendingPickup> GetPendingPickups(int? locationID);
        List<PendingPickupWarehouse> GetPendingPickupWarehouses(int? locationID);
        
        List<PendingPickupDetail> GetPendingPickupDetails(int? locationID, int? goodsReceiptID, int? pickupID, int? warehouseID, string pickupDetailIDs, bool isReadonly);
        List<PendingWarehouseAdjustmentDetail> GetPendingWarehouseAdjustmentDetails(int? locationID, int? goodsReceiptID, int? warehouseAdjustmentID, int? warehouseID, string warehouseAdjustmentDetailIDs, bool isReadonly);

        List<GoodsReceiptDetailAvailable> GetGoodsReceiptDetailAvailables(int? locationID, int? commodityID, int? batchID, string goodsReceiptDetailIDs);
    }

}


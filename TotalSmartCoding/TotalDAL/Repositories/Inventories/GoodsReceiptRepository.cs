using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;

using TotalBase.Enums;
using TotalModel.Models;
using TotalCore.Repositories.Inventories;

namespace TotalDAL.Repositories.Inventories
{
    public class GoodsReceiptRepository : GenericWithDetailRepository<GoodsReceipt, GoodsReceiptDetail>, IGoodsReceiptRepository
    {
        public GoodsReceiptRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities, "GoodsReceiptEditable", "GoodsReceiptApproved")
        {
        }
    }








    public class GoodsReceiptAPIRepository : GenericAPIRepository, IGoodsReceiptAPIRepository
    {
        public GoodsReceiptAPIRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities, "GetGoodsReceiptIndexes")
        {
        }

        public List<PendingPickup> GetPendingPickups(int? locationID)
        {
            return base.TotalSmartCodingEntities.GetPendingPickups(locationID).ToList();
        }

        public List<PendingPickupWarehouse> GetPendingPickupWarehouses(int? locationID)
        {
            return base.TotalSmartCodingEntities.GetPendingPickupWarehouses(locationID).ToList();
        }

        public List<PendingPickupDetail> GetPendingPickupDetails(int? locationID, int? goodsReceiptID, int? pickupID, int? warehouseID, string pickupDetailIDs, bool isReadonly)
        {
            return base.TotalSmartCodingEntities.GetPendingPickupDetails(locationID, goodsReceiptID, pickupID, warehouseID, pickupDetailIDs, isReadonly).ToList();
        }

        public List<PendingWarehouseAdjustmentDetail> GetPendingWarehouseAdjustmentDetails(int? locationID, int? goodsReceiptID, int? warehouseAdjustmentID, int? warehouseID, string warehouseAdjustmentDetailIDs, bool isReadonly)
        {
            return base.TotalSmartCodingEntities.GetPendingWarehouseAdjustmentDetails(locationID, goodsReceiptID, warehouseAdjustmentID, warehouseID, warehouseAdjustmentDetailIDs, isReadonly).ToList();
        }

        public int? GetGoodsReceiptIDofWarehouseAdjustment(int? warehouseAdjustmentID)
        {
            return base.TotalSmartCodingEntities.GetGoodsReceiptIDofWarehouseAdjustment(warehouseAdjustmentID).FirstOrDefault();
        }

        public List<GoodsReceiptDetailAvailable> GetGoodsReceiptDetailAvailables(int? locationID, int? warehouseID, int? commodityID, string commodityIDs, int? batchID, string goodsReceiptDetailIDs)
        {
            return base.TotalSmartCodingEntities.GetGoodsReceiptDetailAvailables(locationID, warehouseID, commodityID, commodityIDs, batchID, goodsReceiptDetailIDs).ToList();
        }
    }


}

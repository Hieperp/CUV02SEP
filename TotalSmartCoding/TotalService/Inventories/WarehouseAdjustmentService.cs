using System.Collections.Generic;
using System.Data.Entity.Core.Objects;

using TotalModel.Models;
using TotalDTO.Inventories;
using TotalCore.Repositories.Inventories;
using TotalCore.Services.Inventories;

namespace TotalService.Inventories
{
    public class WarehouseAdjustmentService : GenericWithViewDetailService<WarehouseAdjustment, WarehouseAdjustmentDetail, WarehouseAdjustmentViewDetail, WarehouseAdjustmentDTO, WarehouseAdjustmentPrimitiveDTO, WarehouseAdjustmentDetailDTO>, IWarehouseAdjustmentService
    {
        private readonly IGoodsReceiptAPIRepository goodsReceiptAPIRepository;
        private readonly IGoodsReceiptService goodsReceiptService;

        public WarehouseAdjustmentService(IWarehouseAdjustmentRepository warehouseAdjustmentRepository, IGoodsReceiptAPIRepository goodsReceiptAPIRepository, IGoodsReceiptService goodsReceiptService)
            : base(warehouseAdjustmentRepository, "WarehouseAdjustmentPostSaveValidate", "WarehouseAdjustmentSaveRelative", "WarehouseAdjustmentToggleApproved", null, null, "GetWarehouseAdjustmentViewDetails")
        {
            this.goodsReceiptAPIRepository = goodsReceiptAPIRepository;
            this.goodsReceiptService = goodsReceiptService;
        }

        public override ICollection<WarehouseAdjustmentViewDetail> GetViewDetails(int warehouseAdjustmentID)
        {
            ObjectParameter[] parameters = new ObjectParameter[] { new ObjectParameter("WarehouseAdjustmentID", warehouseAdjustmentID) };
            return this.GetViewDetails(parameters);
        }

        protected override WarehouseAdjustment SaveMe(WarehouseAdjustmentDTO warehouseAdjustmentDTO)
        {
            WarehouseAdjustment warehouseAdjustment = base.SaveMe(warehouseAdjustmentDTO);

            if (true) //Has Adjust +
            {
                GoodsReceiptDTO goodsReceiptDTO = new GoodsReceiptDTO();

                goodsReceiptDTO.EntryDate = warehouseAdjustmentDTO.EntryDate;
                goodsReceiptDTO.WarehouseID = warehouseAdjustmentDTO.WarehouseID;

                goodsReceiptDTO.StorekeeperID = warehouseAdjustmentDTO.StorekeeperID;

                goodsReceiptDTO.PreparedPersonID = warehouseAdjustmentDTO.PreparedPersonID;
                goodsReceiptDTO.ApproverID = warehouseAdjustmentDTO.ApproverID;

                goodsReceiptDTO.Description = warehouseAdjustmentDTO.Description;
                goodsReceiptDTO.Remarks = warehouseAdjustmentDTO.Remarks;

                List<PendingWarehouseAdjustmentDetail> pendingWarehouseAdjustmentDetails = this.goodsReceiptAPIRepository.GetPendingWarehouseAdjustmentDetails(warehouseAdjustment.LocationID, null, warehouseAdjustment.WarehouseAdjustmentID, warehouseAdjustment.WarehouseID, null, false);
                foreach (PendingWarehouseAdjustmentDetail pendingWarehouseAdjustmentDetail in pendingWarehouseAdjustmentDetails)
                {
                    GoodsReceiptDetailDTO goodsReceiptDetailDTO = new GoodsReceiptDetailDTO()
                    {
                        GoodsReceiptID = goodsReceiptDTO.GoodsReceiptID,

                        WarehouseAdjustmentID = pendingWarehouseAdjustmentDetail.WarehouseAdjustmentID,
                        WarehouseAdjustmentDetailID = pendingWarehouseAdjustmentDetail.WarehouseAdjustmentDetailID,
                        WarehouseAdjustmentReference = pendingWarehouseAdjustmentDetail.WarehouseAdjustmentReference,
                        WarehouseAdjustmentEntryDate = pendingWarehouseAdjustmentDetail.WarehouseAdjustmentEntryDate,

                        BatchID = pendingWarehouseAdjustmentDetail.BatchID,
                        BatchEntryDate = pendingWarehouseAdjustmentDetail.BatchEntryDate,

                        BinLocationID = pendingWarehouseAdjustmentDetail.BinLocationID,
                        BinLocationCode = pendingWarehouseAdjustmentDetail.BinLocationCode,

                        CommodityID = pendingWarehouseAdjustmentDetail.CommodityID,
                        CommodityCode = pendingWarehouseAdjustmentDetail.CommodityCode,
                        CommodityName = pendingWarehouseAdjustmentDetail.CommodityName,

                        Quantity = (decimal)pendingWarehouseAdjustmentDetail.QuantityRemains,
                        LineVolume = (decimal)pendingWarehouseAdjustmentDetail.LineVolumeRemains,

                        PackID = pendingWarehouseAdjustmentDetail.PackID,
                        PackCode = pendingWarehouseAdjustmentDetail.PackCode,
                        CartonID = pendingWarehouseAdjustmentDetail.CartonID,
                        CartonCode = pendingWarehouseAdjustmentDetail.CartonCode,
                        PalletID = pendingWarehouseAdjustmentDetail.PalletID,
                        PalletCode = pendingWarehouseAdjustmentDetail.PalletCode,

                        PackCounts = pendingWarehouseAdjustmentDetail.PackCounts,
                        CartonCounts = pendingWarehouseAdjustmentDetail.CartonCounts,
                        PalletCounts = pendingWarehouseAdjustmentDetail.PalletCounts
                    };
                    goodsReceiptDTO.ViewDetails.Add(goodsReceiptDetailDTO);
                }

                this.goodsReceiptService.UserID = this.UserID; //THE BaseService.UserID IS AUTOMATICALLY SET BY CustomControllerAttribute OF CONTROLLER, ONLY WHEN BaseService IS INITIALIZED BY CONTROLLER. BUT HERE, THE this.goodsReceiptService IS INITIALIZED BY VehiclesInvoiceService => SO SHOULD SET goodsReceiptService.UserID = this.UserID
                this.goodsReceiptService.Save(goodsReceiptDTO, true);
            }

            return warehouseAdjustment;
        }
    }
}

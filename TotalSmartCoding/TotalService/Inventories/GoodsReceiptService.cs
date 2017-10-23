using System.Collections.Generic;
using System.Data.Entity.Core.Objects;

using TotalModel.Models;
using TotalDTO.Inventories;
using TotalCore.Repositories.Inventories;
using TotalCore.Services.Inventories;

namespace TotalService.Inventories
{
    public class GoodsReceiptService : GenericWithViewDetailService<GoodsReceipt, GoodsReceiptDetail, GoodsReceiptViewDetail, GoodsReceiptDTO, GoodsReceiptPrimitiveDTO, GoodsReceiptDetailDTO>, IGoodsReceiptService
    {
        public GoodsReceiptService(IGoodsReceiptRepository goodsReceiptRepository)
            : base(goodsReceiptRepository, "GoodsReceiptPostSaveValidate", "GoodsReceiptSaveRelative", "GoodsReceiptToggleApproved", null, null, "GetGoodsReceiptViewDetails")
        {
        }

        public new bool Save(GoodsReceiptDTO dto, bool useExistingTransaction)
        {
            return base.Save(dto, useExistingTransaction);
        }

        public new bool Delete(int id, bool useExistingTransaction)
        {
            return base.Delete(id, useExistingTransaction);
        }

        public override ICollection<GoodsReceiptViewDetail> GetViewDetails(int goodsReceiptID)
        {
            ObjectParameter[] parameters = new ObjectParameter[] { new ObjectParameter("GoodsReceiptID", goodsReceiptID) };
            return this.GetViewDetails(parameters);
        }
    }
}

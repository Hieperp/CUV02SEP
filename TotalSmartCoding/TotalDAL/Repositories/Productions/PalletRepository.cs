using System.Linq;
using System.Collections.Generic;

using TotalBase;
using TotalModel.Models;
using TotalCore.Repositories.Productions;

namespace TotalDAL.Repositories.Productions
{
    public class PalletRepository : GenericRepository<Pallet>, IPalletRepository
    {
        public PalletRepository(TotalSmartCodingEntities totalSmartCodingEntities)
            : base(totalSmartCodingEntities)
        {
        }


        public IList<Pallet> GetPallets(GlobalVariables.FillingLine fillingLineID, string entryStatusIDs)
        {
            return this.TotalSmartCodingEntities.GetPallets((int)fillingLineID, entryStatusIDs).ToList();
        }

        public void UpdateEntryStatus(string palletIDs, GlobalVariables.BarcodeStatus barcodeStatus)
        {
            this.TotalSmartCodingEntities.PalletUpdateEntryStatus(palletIDs, (int)barcodeStatus);
        }
    }
}

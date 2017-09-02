using System.Collections.Generic;

using TotalBase;
using TotalModel.Models;

namespace TotalCore.Repositories.Productions
{
    public interface IPalletRepository : IGenericRepository<Pallet>
    {
        IList<Pallet> GetPallets(GlobalVariables.FillingLine fillingLineID, string entryStatusIDs);

        void UpdateEntryStatus(string cartonIDs, GlobalVariables.BarcodeStatus barcodeStatus);
    }
}

using System.Collections.Generic;

using TotalBase;
using TotalModel.Models;
using TotalDTO.Productions;

namespace TotalCore.Services.Productions
{
    public interface IPalletService : IGenericService<Pallet, PalletDTO, PalletPrimitiveDTO>
    {
        IList<Pallet> GetPallets(GlobalVariables.FillingLine fillingLineID, string entryStatusIDs);
    }
}

using TotalModel.Models;
using TotalDTO.Commons;
using TotalCore.Repositories.Commons;
using TotalCore.Services.Commons;

namespace TotalService.Commons
{
    public class BinLocationService : GenericService<BinLocation, BinLocationDTO, BinLocationPrimitiveDTO>, IBinLocationService
    {
        public BinLocationService(IBinLocationRepository customerRepository)
            : base(customerRepository, "BinLocationPostSaveValidate", "BinLocationSaveRelative")
        {
        }
    }
}

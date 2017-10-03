using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Generals
{
    public interface IModuleRepository
    {

    }

    public interface IModuleAPIRepository : IGenericAPIRepository
    {
        IList<ModuleViewDetail> GetModuleViewDetails(int? moduleID);
    }
}

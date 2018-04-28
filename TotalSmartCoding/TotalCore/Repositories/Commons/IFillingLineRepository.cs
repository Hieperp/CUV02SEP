using System.Collections.Generic;

using TotalModel.Models;

namespace TotalCore.Repositories.Commons
{
    public interface IFillingLineRepository : IGenericWithDetailRepository<FillingLine, FillingLineDetail>
    {
    }

    public interface IFillingLineAPIRepository : IGenericAPIRepository
    {
        IList<FillingLineBase> GetFillingLineBases();
    }
}

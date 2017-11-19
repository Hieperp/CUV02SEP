using System;

namespace TotalDTO.Helpers.Interfaces
{
    public interface IBatchQuantityDetailDTO : IAvailableQuantityDetailDTO 
    {
        Nullable<int> BatchID { get; set; }

        string BatchCode { get; set; }
        DateTime? BatchEntryDate { get; set; }
     
        decimal QuantityBatchAvailable { get; set; }
        decimal LineVolumeBatchAvailable  { get; set; }
    }
}

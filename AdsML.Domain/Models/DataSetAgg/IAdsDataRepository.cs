using AdsML.Domain.Models.Common;

namespace AdsML.Domain.Models.DataSetAgg;

public interface IAdsDataRepository
{
    public Task<OperationResult> GetAll();
    public Task<OperationResult> Add(AdsData command);
}

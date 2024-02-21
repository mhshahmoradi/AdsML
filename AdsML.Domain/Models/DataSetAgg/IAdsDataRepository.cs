using AdsML.Domain.Models.Common;

namespace AdsML.Domain.Models.DataSetAgg;

public interface IAdsDataRepository
{
    public Task<ICollection<AdsData>> GetAll(CancellationToken cancellationToken);
    public Task<OperationResult> Add(AdsData command, CancellationToken cancellationToken);
}

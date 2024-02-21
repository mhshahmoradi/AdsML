using AdsML.Domain.Models.Common;
using AdsML.Domain.Models.DataSetAgg;
using Microsoft.EntityFrameworkCore;
using Shared;
using Shared.Infrastructure;

namespace AdsML.Infrastructure.EFCore.Repositories;

public class AdsDataRepository(AdsMLContext dbContext,
    IUnitOfWork unitOfWork)
    : IAdsDataRepository
{
    private readonly AdsMLContext _context = dbContext;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    public async Task<OperationResult> Add(AdsData command, CancellationToken cancellationToken)
    {
        try
        {
            await _unitOfWork.BeginTran(cancellationToken);
            _context.Add(command);
            await _unitOfWork.CommitTran(cancellationToken);
            return OperationResult.Succeeded();
        }
        catch (Exception)
        {
            await _unitOfWork.Rollback(cancellationToken);
            return OperationResult.Failed(ApplicationMessages.OperationFailed);
        }
        
    }

    public async Task<ICollection<AdsData>> GetAll(CancellationToken cancellationToken)
    {
        return await _context.AdsData.ToListAsync(cancellationToken);
    }
}

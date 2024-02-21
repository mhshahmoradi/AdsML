using AdsML.Infrastructure.EFCore;

namespace Shared.Infrastructure;

public class UnitOfWork(AdsMLContext dbContext) : IUnitOfWork
{
    private readonly AdsMLContext _dbContext = dbContext;
    public async Task BeginTran(CancellationToken cancellationToken)
    {
       await _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }

    public async Task CommitTran(CancellationToken cancellationToken)
    {
        await _dbContext.Database.CommitTransactionAsync(cancellationToken);
    }

    public async Task Rollback(CancellationToken cancellationToken)
    {
        await _dbContext.Database.RollbackTransactionAsync(cancellationToken);
    }
}

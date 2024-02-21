
using Microsoft.EntityFrameworkCore;

namespace Shared.Infrastructure;

public class UnitOfWork(DbContext dbContext) : IUnitOfWork
{
    private readonly DbContext _dbContext = dbContext;
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

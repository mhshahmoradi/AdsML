namespace Shared.Infrastructure;

public interface IUnitOfWork
{
    Task BeginTran(CancellationToken cancellationToken);
    Task CommitTran(CancellationToken cancellationToken);
    Task Rollback(CancellationToken cancellationToken);
}

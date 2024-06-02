using ClinicApp2.Context;

namespace ClinicApp2.Repositories;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    Task CommitAsync(CancellationToken cancellationToken);
    public ClinicDbContext GetDbContext();
}
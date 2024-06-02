using ClinicApp.Context;

namespace ClinicApp.Repositories;

public interface IUnitOfWork : IDisposable, IAsyncDisposable
{
    Task CommitAsync(CancellationToken cancellationToken);
    public ClinicDbContext GetDbContext();
}
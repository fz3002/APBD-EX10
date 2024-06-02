using ClinicApp2.Context;
using ClinicApp2.Repositories;

namespace ClinicAppTests2.TestObjects;

public class FakeUnitOfWork : IUnitOfWork
{
    public void Dispose()
    {

    }

    public ValueTask DisposeAsync()
    {
        return ValueTask.CompletedTask;
    }

    public Task CommitAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public ClinicDbContext GetDbContext()
    {
        return null;
    }
}
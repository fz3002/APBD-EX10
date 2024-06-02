using ClinicApp2.Context;
using ClinicApp2.Repositories;

namespace ClinicAppTests2.TestObjects;

public class FakeUnitOfWork : IUnitOfWork
{
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public ValueTask DisposeAsync()
    {
        throw new NotImplementedException();
    }

    public Task CommitAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public ClinicDbContext GetDbContext()
    {
        throw new NotImplementedException();
    }
}
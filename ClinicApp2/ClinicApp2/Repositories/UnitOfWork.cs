using ClinicApp2.Context;

namespace ClinicApp2.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly ClinicDbContext _context;

    public UnitOfWork(ClinicDbContext context)
    {
        _context = context;
    }

    public ClinicDbContext GetDbContext()
    {
        return _context;
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _context.SaveChangesAsync(cancellationToken);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        await _context.DisposeAsync();
    }
}
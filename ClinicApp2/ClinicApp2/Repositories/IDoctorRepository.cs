using ClinicApp2.Models;

namespace ClinicApp2.Repositories;

public interface IDoctorRepository : IRepository
{
    Task<Doctor?> GetDoctorAsync(int id, CancellationToken cancellationToken);
}
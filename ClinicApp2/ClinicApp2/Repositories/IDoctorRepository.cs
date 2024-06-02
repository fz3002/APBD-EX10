using ClinicApp.Models;

namespace ClinicApp.Repositories;

public interface IDoctorRepository : IRepository
{
    Task<Doctor?> GetDoctorAsync(int id, CancellationToken cancellationToken);
}
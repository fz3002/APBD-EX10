using ClinicApp.Models;

namespace ClinicApp.Repositories;

public interface IMedicationRepository : IRepository
{
    Task<Medicament?> GetMedicamentAsync(int id, CancellationToken cancellationToken);
}
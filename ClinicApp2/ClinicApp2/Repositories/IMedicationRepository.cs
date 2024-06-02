using ClinicApp2.Models;

namespace ClinicApp2.Repositories;

public interface IMedicationRepository : IRepository
{
    Task<Medicament?> GetMedicamentAsync(int id, CancellationToken cancellationToken);
}
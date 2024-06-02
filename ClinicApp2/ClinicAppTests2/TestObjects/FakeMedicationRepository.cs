using ClinicApp2.Models;
using ClinicApp2.Repositories;

namespace ClinicAppTests2.TestObjects;

public class FakeMedicationRepository : IMedicationRepository
{
    public Task<Medicament?> GetMedicamentAsync(int id, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
using ClinicApp2.DTO;
using ClinicApp2.Models;
using ClinicApp2.Repositories;
using ClinicApp2.Services;

namespace ClinicAppTests2.TestObjects;

public class FakeClinicRepository : IClinicRepository
{
    public Task<int> CreatePrescriptionAsync(int idDoctor, int idPatient, DateTime date, DateTime dateDue,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task AddMedToPrescriptionAsync(PrescriptionMedicament prescriptionMedicament, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Prescription>> GetPatientsPrescriptionsAsync(int IdPatient, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<MedicamentResponseDTO>> GetMedicamentsForPrescriptionAsync(int IdPrescription, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
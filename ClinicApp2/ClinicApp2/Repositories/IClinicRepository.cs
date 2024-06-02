using ClinicApp2.DTO;
using ClinicApp2.Models;

namespace ClinicApp2.Repositories;

public interface IClinicRepository : IRepository
{
    Task<int> CreatePrescriptionAsync(int idDoctor, int idPatient, DateTime date, DateTime dateDue, CancellationToken cancellationToken);

    Task AddMedToPrescriptionAsync(PrescriptionMedicament prescriptionMedicament, CancellationToken cancellationToken);

    Task<ICollection<Prescription>> GetPatientsPrescriptionsAsync(int IdPatient, CancellationToken cancellationToken);

    Task<ICollection<MedicamentResponseDTO>>
        GetMedicamentsForPrescriptionAsync(int IdPrescription, CancellationToken cancellationToken);
}
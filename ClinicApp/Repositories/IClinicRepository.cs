using ClinicApp.Models;

namespace ClinicApp.Repositories;

public interface IClinicRepository : IRepository
{
    Task<int> CreatePrescriptionAsync(int idDoctor, int idPatient, DateTime date, DateTime dateDue, CancellationToken cancellationToken);
    Task AddMedToPrescriptionAsync(PrescriptionMedicament prescriptionMedicament, CancellationToken cancellationToken);
}
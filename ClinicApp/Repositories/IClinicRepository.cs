using ClinicApp.Models;

namespace ClinicApp.Repositories;

public interface IClinicRepository : IRepository
{
    Task<int> CreatePrescriptionAsync(int idDoctor, int idPatient, DateOnly date, DateOnly dateDue, CancellationToken cancellationToken);
    Task AddMedToPrescriptionAsync(PrescriptionMedicament prescriptionMedicament, CancellationToken cancellationToken);
}
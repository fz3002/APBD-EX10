using ClinicApp2.DTO;

namespace ClinicApp2.Services;

public interface IClinicService
{
    Task<int> AddPrescriptionAsync(PrescriptionDOT prescriptionDot, CancellationToken cancellationToken);
    Task<PatientResponseDTO> GetPatient(int idPatient, CancellationToken cancellationToken);
}
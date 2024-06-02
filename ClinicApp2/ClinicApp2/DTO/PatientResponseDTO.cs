namespace ClinicApp2.DTO;

public record PatientResponseDTO(int IdPatient, string FirstName, string LastName, ICollection<PrescriptionResponseDTO> Prescriptions);
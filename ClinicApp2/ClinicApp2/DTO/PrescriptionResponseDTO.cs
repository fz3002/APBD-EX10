namespace ClinicApp.DTO;

public record PrescriptionResponseDTO(int IdPrescription, DateOnly Date, DateOnly DueDate, ICollection<MedicamentResponseDTO> Medicaments, DoctorResponseDTO Doctor);
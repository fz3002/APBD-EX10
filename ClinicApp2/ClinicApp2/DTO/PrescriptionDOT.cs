namespace ClinicApp2.DTO;

public record PrescriptionDOT(int IdDoctor, PatientDTO Patient, ICollection<MedicamentDTO> Medicaments, DateTime Date, DateTime DateDue, string Details);
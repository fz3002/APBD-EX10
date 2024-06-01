using ClinicApp.Models;

namespace ClinicApp.DTO;

public record PrescriptionDOT(int IdDoctor, PatientDTO Patient, ICollection<MedicamentDTO> Medicaments, DateOnly Date, DateOnly DateDue, string Details);
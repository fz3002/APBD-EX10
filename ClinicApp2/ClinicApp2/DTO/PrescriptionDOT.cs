using ClinicApp.Models;

namespace ClinicApp.DTO;

public record PrescriptionDOT(int IdDoctor, PatientDTO Patient, ICollection<MedicamentDTO> Medicaments, DateTime Date, DateTime DateDue, string Details);
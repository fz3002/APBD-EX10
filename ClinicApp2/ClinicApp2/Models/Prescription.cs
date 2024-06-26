namespace ClinicApp2.Models;

public class Prescription
{
    public int IdPrescription { get; set; }

    public DateOnly Date { get; set; }

    public DateOnly DateDue { get; set; }

    public int IdDoctor { get; set; }

    public int IdPatient { get; set; }

    public Doctor Doctor { get; set; }

    public Patient Patient { get; set; }

    public ICollection<PrescriptionMedicament> PrescriptionMedicaments { get; set; }
}
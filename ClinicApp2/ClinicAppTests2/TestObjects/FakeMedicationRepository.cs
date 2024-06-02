using ClinicApp2.Models;
using ClinicApp2.Repositories;

namespace ClinicAppTests2.TestObjects;

public class FakeMedicationRepository : IMedicationRepository
{
    private readonly ICollection<Medicament> _medicaments;

    public FakeMedicationRepository()
    {
        _medicaments = new List<Medicament>()
        {
            new Medicament
            {
                IdMedicament = 1, Name = "Aspirin", Description = "Pain reliever and fever reducer", Type = "Analgesic"
            },
            new Medicament
            {
                IdMedicament = 2, Name = "Amoxicillin", Description = "Antibiotic for bacterial infections",
                Type = "Antibiotic"
            },
            new Medicament
            {
                IdMedicament = 3, Name = "Lisinopril", Description = "Treats high blood pressure",
                Type = "Antihypertensive"
            },
            new Medicament
            {
                IdMedicament = 4, Name = "Metformin", Description = "Used to treat type 2 diabetes",
                Type = "Antidiabetic"
            },
            new Medicament
            {
                IdMedicament = 5, Name = "Omeprazole", Description = "Treats acid reflux and stomach ulcers",
                Type = "Proton Pump Inhibitor"
            }
        };
    }

    public Task<Medicament?> GetMedicamentAsync(int id, CancellationToken cancellationToken)
    {
        return Task.FromResult(_medicaments.FirstOrDefault(m => m.IdMedicament == id));
    }
}
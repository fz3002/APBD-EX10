using ClinicApp2.DTO;
using ClinicApp2.Models;
using ClinicApp2.Repositories;
using ClinicApp2.Services;

namespace ClinicAppTests2.TestObjects;

public class FakeClinicRepository : IClinicRepository
{
    private ICollection<Prescription> _prescriptions;
    
    private ICollection<PrescriptionMedicament> _prescriptionMedicaments;

    public FakeClinicRepository()
    {
        _prescriptions = new List<Prescription>()
        {
            new Prescription
            {
                IdPrescription = 1, Date = DateOnly.FromDateTime(DateTime.Now),
                DateDue = DateOnly.FromDateTime(DateTime.Now).AddDays(30), IdDoctor = 1, IdPatient = 1
            },
            new Prescription
            {
                IdPrescription = 2, Date = DateOnly.FromDateTime(DateTime.Now),
                DateDue = DateOnly.FromDateTime(DateTime.Now).AddDays(30), IdDoctor = 2, IdPatient = 2
            },
            new Prescription
            {
                IdPrescription = 3, Date = DateOnly.FromDateTime(DateTime.Now),
                DateDue = DateOnly.FromDateTime(DateTime.Now).AddDays(30), IdDoctor = 1, IdPatient = 3
            },
            new Prescription
            {
                IdPrescription = 4, Date = DateOnly.FromDateTime(DateTime.Now),
                DateDue = DateOnly.FromDateTime(DateTime.Now).AddDays(30), IdDoctor = 3, IdPatient = 4
            },
            new Prescription
            {
                IdPrescription = 5, Date = DateOnly.FromDateTime(DateTime.Now),
                DateDue = DateOnly.FromDateTime(DateTime.Now).AddDays(30), IdDoctor = 2, IdPatient = 5
            }
        };

        _prescriptionMedicaments = new List<PrescriptionMedicament>()
        {
            new PrescriptionMedicament
                { IdMedicament = 1, IdPrescription = 1, Dose = 500, Details = "Take twice daily", Medicament = new Medicament()
                {
                    IdMedicament = 1,
                    Description = "sfasdf",
                    Name = "fasdf",
                    Type = "fasfas"
                }},
            new PrescriptionMedicament
                { IdMedicament = 2, IdPrescription = 1, Dose = 250, Details = "Take once daily", Medicament = new Medicament()
                {
                    IdMedicament = 2,
                    Description = "sfasdf",
                    Name = "fasdf",
                    Type = "fasfas"
                }},
            new PrescriptionMedicament
                { IdMedicament = 3, IdPrescription = 2, Dose = 100, Details = "Take in the morning", Medicament = new Medicament()
                {
                    IdMedicament = 3,
                    Description = "sfasdf",
                    Name = "fasdf",
                    Type = "fasfas"
                }},
            new PrescriptionMedicament
                { IdMedicament = 1, IdPrescription = 3, Dose = 500, Details = "Take twice daily", Medicament = new Medicament()
                {
                    IdMedicament = 1,
                    Description = "sfasdf",
                    Name = "fasdf",
                    Type = "fasfas"
                }},
            new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 4, Dose = 250, Details = "Take once daily", Medicament = new Medicament()
            {
                IdMedicament = 2,
                Description = "sfasdf",
                Name = "fasdf",
                Type = "fasfas"
            }}
        };
    }

    public async Task<int> CreatePrescriptionAsync(int idDoctor, int idPatient, DateTime date, DateTime dateDue,
        CancellationToken cancellationToken)
    {
        var p = new Prescription()
        {
            IdDoctor = idDoctor,
            IdPatient = idPatient,
            Date = DateOnly.FromDateTime(date),
            DateDue = DateOnly.FromDateTime(dateDue)
        };
        int newId = _prescriptions.Max(p => p.IdPrescription) + 1;
        _prescriptions.Add(p);

        return await Task.FromResult(newId);
    }

    public async Task AddMedToPrescriptionAsync(PrescriptionMedicament prescriptionMedicament, CancellationToken cancellationToken)
    {
        _prescriptionMedicaments.Add(prescriptionMedicament);
    }

    public async Task<ICollection<Prescription>> GetPatientsPrescriptionsAsync(int IdPatient, CancellationToken cancellationToken)
    {
        var prescriptions = _prescriptions
            .Where(p => p.IdPatient == IdPatient)
            .Select(p => p)
            .ToList();

        return await Task.FromResult(prescriptions);
    }

    public async Task<ICollection<MedicamentResponseDTO>> GetMedicamentsForPrescriptionAsync(int IdPrescription, CancellationToken cancellationToken)
    {
        var meds = _prescriptionMedicaments
            .Where(mp => mp.IdPrescription == IdPrescription)
            .Select(mp => new MedicamentResponseDTO(
                mp.Medicament.IdMedicament,
                mp.Medicament.Name,
                mp.Dose,
                mp.Medicament.Description
            ))
            .ToList();
        return await Task.FromResult(meds);
    }
}
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
                { IdMedicament = 1, IdPrescription = 1, Dose = 500, Details = "Take twice daily" },
            new PrescriptionMedicament
                { IdMedicament = 2, IdPrescription = 1, Dose = 250, Details = "Take once daily" },
            new PrescriptionMedicament
                { IdMedicament = 3, IdPrescription = 2, Dose = 100, Details = "Take in the morning" },
            new PrescriptionMedicament
                { IdMedicament = 1, IdPrescription = 3, Dose = 500, Details = "Take twice daily" },
            new PrescriptionMedicament { IdMedicament = 2, IdPrescription = 4, Dose = 250, Details = "Take once daily" }
        };
    }

    public Task<int> CreatePrescriptionAsync(int idDoctor, int idPatient, DateTime date, DateTime dateDue,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task AddMedToPrescriptionAsync(PrescriptionMedicament prescriptionMedicament, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<Prescription>> GetPatientsPrescriptionsAsync(int IdPatient, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<ICollection<MedicamentResponseDTO>> GetMedicamentsForPrescriptionAsync(int IdPrescription, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
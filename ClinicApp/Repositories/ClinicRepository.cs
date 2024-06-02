using ClinicApp.Context;
using ClinicApp.DTO;
using ClinicApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Repositories;

public class ClinicRepository : IClinicRepository
{
    private readonly IUnitOfWork _unitOfWork;

    public ClinicRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<int> CreatePrescriptionAsync(int idDoctor, int idPatient, DateTime date, DateTime dateDue, CancellationToken cancellationToken)
    {
        var prescription = new Prescription
        {
            Date = DateOnly.FromDateTime(date),
            DateDue = DateOnly.FromDateTime(dateDue),
            IdDoctor = idDoctor,
            IdPatient = idPatient
        };
        await _unitOfWork.GetDbContext().Prescriptions.AddAsync(prescription, cancellationToken);
        return await GetLastPrescriptionIdAsync(cancellationToken) + 1;
    }

    private async Task<int> GetLastPrescriptionIdAsync(CancellationToken cancellationToken)
    {
        var lastPrescription = await _unitOfWork.GetDbContext().Prescriptions
            .OrderByDescending(p => p.IdPrescription)
            .FirstOrDefaultAsync(cancellationToken);

        return lastPrescription?.IdPrescription ?? 0;
    }

    public async Task AddMedToPrescriptionAsync(PrescriptionMedicament prescriptionMedicament, CancellationToken cancellationToken)
    {
        await _unitOfWork.GetDbContext().PrescriptionMedicaments.AddAsync(prescriptionMedicament, cancellationToken);
    }

    public async Task<ICollection<Prescription>> GetPatientsPrescriptionsAsync(int IdPatient, CancellationToken cancellationToken)
    {
        var prescriptions = await _unitOfWork
            .GetDbContext().Prescriptions
            .Where(p => p.IdPatient == IdPatient)
            .Select(p => p)
            .ToListAsync(cancellationToken);

        return prescriptions;
    }

    public async Task<ICollection<MedicamentResponseDTO>> GetMedicamentsForPrescriptionAsync(int IdPrescription, CancellationToken cancellationToken)
    {
        var meds = await _unitOfWork
            .GetDbContext().PrescriptionMedicaments
            .Where(mp => mp.IdPrescription == IdPrescription)
            .Include(mp => mp.Medicament)
            .Select(mp => new MedicamentResponseDTO(
                mp.Medicament.IdMedicament,
                mp.Medicament.Name,
                mp.Dose,
                mp.Medicament.Description
            ))
            .ToListAsync(cancellationToken);

        return meds;
    }
}
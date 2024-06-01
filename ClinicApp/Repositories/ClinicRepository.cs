using ClinicApp.Context;
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

    public async Task<int> CreatePrescriptionAsync(int idDoctor, int idPatient, DateOnly date, DateOnly dateDue, CancellationToken cancellationToken)
    {
        var prescription = new Prescription
        {
            Date = date,
            DateDue = dateDue,
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
}
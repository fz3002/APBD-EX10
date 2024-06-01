using ClinicApp.Context;
using ClinicApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Repositories;

public class PatientRepository : IPatientRepository
{
    private readonly IUnitOfWork _unitOfWork;

    public PatientRepository(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<Patient?> GetPatientAsync(int idPatient, string firstName, string lastName, DateOnly birthdate, CancellationToken cancellationToken)
    {
        var context = _unitOfWork.GetDbContext();
        return await context.Patients
            .Where(p =>
                p.IdPatient == idPatient && p.FirstName == firstName && p.LastName == lastName &&
                p.Birthdate == birthdate)
            .Select(p => p)
            .FirstOrDefaultAsync(cancellationToken);
    }

    public async Task<int> CreatePatientAsync(int idPatient, string firstName, string lastName, DateOnly birthdate, CancellationToken cancellationToken)
    {
        var patient = new Patient
        {
            IdPatient = idPatient,
            FirstName = firstName,
            LastName = lastName,
            Birthdate = birthdate
        };
        await _unitOfWork.GetDbContext().Patients.AddAsync(patient, cancellationToken);
        return await GetLastPatientAsync(cancellationToken);
    }

    private async Task<int> GetLastPatientAsync(CancellationToken cancellationToken)
    {
        var lastPrescription = await _unitOfWork.GetDbContext().Patients
            .OrderByDescending(p => p.IdPatient)
            .FirstOrDefaultAsync(cancellationToken);

        return lastPrescription?.IdPatient ?? 0;
    }
}
using ClinicApp.Models;

namespace ClinicApp.Repositories;

public interface IPatientRepository : IRepository
{
    Task<Patient?> GetPatientAsync(int idPatient, string firstName, string lastName, DateOnly birthdate, CancellationToken cancellationToken);
    Task<int> CreatePatientAsync(int idPatient, string firstName, string lastName, DateOnly birthdate, CancellationToken cancellationToken);
}
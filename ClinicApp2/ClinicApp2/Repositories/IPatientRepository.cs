using ClinicApp.Models;

namespace ClinicApp.Repositories;

public interface IPatientRepository : IRepository
{
    Task<Patient?> GetPatientAsync(int idPatient, string firstName, string lastName, DateTime birthdate, CancellationToken cancellationToken);
    Task<Patient?> GetPatientAsync(int idPatient, CancellationToken cancellationToken);
    Task<int> CreatePatientAsync(int idPatient, string firstName, string lastName, DateTime birthdate, CancellationToken cancellationToken);
}
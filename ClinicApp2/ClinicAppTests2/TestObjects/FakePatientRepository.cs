using ClinicApp2.Models;
using ClinicApp2.Repositories;

namespace ClinicAppTests2.TestObjects;

public class FakePatientRepository : IPatientRepository
{
    private readonly ICollection<Patient> _patients;

    public FakePatientRepository()
    {
        _patients = new List<Patient>
        {
            new Patient { IdPatient = 1, FirstName = "Alice", LastName = "Johnson", Birthdate = new DateOnly(1985, 4, 23) },
            new Patient { IdPatient = 2, FirstName = "Bob", LastName = "Smith", Birthdate = new DateOnly(1990, 8, 15) },
            new Patient { IdPatient = 3, FirstName = "Charlie", LastName = "Brown", Birthdate = new DateOnly(1975, 12, 1) },
            new Patient { IdPatient = 4, FirstName = "Diana", LastName = "Prince", Birthdate = new DateOnly(1988, 6, 30) },
            new Patient { IdPatient = 5, FirstName = "Edward", LastName = "Norton", Birthdate = new DateOnly(1995, 11, 5) }
        };
    }
    public Task<Patient?> GetPatientAsync(int idPatient, string firstName, string lastName, DateTime birthdate,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<Patient?> GetPatientAsync(int idPatient, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<int> CreatePatientAsync(int idPatient, string firstName, string lastName, DateTime birthdate,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
using ClinicApp2.Models;
using ClinicApp2.Repositories;

namespace ClinicAppTests2.TestObjects;

public class FakeDoctorRepository : IDoctorRepository
{
    private ICollection<Doctor> _doctors;

    public FakeDoctorRepository()
    {
        _doctors = new List<Doctor>
        {
            new Doctor { IdDoctor = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com" },
            new Doctor { IdDoctor = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com" },
            new Doctor { IdDoctor = 3, FirstName = "Jan", LastName = "Kowalski", Email = "jan.kowalski@clinci.com"}
        };
    }

    public Task<Doctor?> GetDoctorAsync(int id, CancellationToken cancellationToken)
    {
        return Task.FromResult(_doctors.FirstOrDefault(d => d.IdDoctor == id));
    }
}
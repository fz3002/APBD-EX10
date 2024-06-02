

using ClinicApp2.Services;
using ClinicAppTests2.TestObjects;

namespace ClinicAppTests2;

public class ClinicServiceTest
{

    private readonly IClinicService _service;

    public ClinicServiceTest()
    {
        _service = new ClinicService(
            new FakeUnitOfWork(),
            new FakeClinicRepository(),
            new FakeDoctorRepository(),
            new FakePatientRepository(),
            new FakeMedicationRepository()
            );
    }

    [Fact]
    public void Test1()
    {
    }
}
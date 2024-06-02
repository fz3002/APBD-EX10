

using ClinicApp2.DTO;
using ClinicApp2.Exceptions;
using ClinicApp2.Services;
using ClinicAppTests2.TestObjects;
using Shouldly;

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
    public async Task Should_ThrowException_WhenMoreThen10Meds()
    {
        //Arrange
        var prescriptionReq = new PrescriptionDOT
        (
            1,
            new PatientDTO
            (
                1,
                "John",
                "Doe",
                DateTime.Now.Subtract(new TimeSpan(5000,0,0,0))
            ),
            new List<MedicamentDTO>()
            {
                new MedicamentDTO(1, 100, "fasdfa"),
                new MedicamentDTO(2, 100, "fasdfa"),
                new MedicamentDTO(3, 100, "fasdfa"),
                new MedicamentDTO(4, 100, "fasdfa"),
                new MedicamentDTO(5, 100, "fasdfa"),
                new MedicamentDTO(6, 100, "fasdfa"),
                new MedicamentDTO(7, 100, "fasdfa"),
                new MedicamentDTO(8, 100, "fasdfa"),
                new MedicamentDTO(9, 100, "fasdfa"),
                new MedicamentDTO(10, 100, "fasdfa"),
                new MedicamentDTO(11, 100, "fasdfa"),
                new MedicamentDTO(12, 100, "fasdfa"),
                new MedicamentDTO(13, 100, "fasdfa")
            },
            DateTime.Now,
            DateTime.Now.AddDays(30),
            "Dasfasdfas"
        );

        //Act and Assert
        await Should.ThrowAsync<DomainException>(_service.AddPrescriptionAsync(prescriptionReq,
            CancellationToken.None));
    }

    [Fact]
    public async Task Should_ThrowException_WhenDateDueBeforeDate()
    {
        //Arrange
        var prescriptionReq = new PrescriptionDOT
        (
            1,
            new PatientDTO
            (
                1,
                "John",
                "Doe",
                DateTime.Now.Subtract(new TimeSpan(5000,0,0,0))
            ),
            new List<MedicamentDTO>()
            {
                new MedicamentDTO(1, 100, "fasdfa"),
                new MedicamentDTO(2, 100, "fasdfa"),
                new MedicamentDTO(3, 100, "fasdfa"),
                new MedicamentDTO(4, 100, "fasdfa")
            },
            DateTime.Now.AddDays(60),
            DateTime.Now.AddDays(30),
            "Dasfasdfas"
        );

        //Act and Assert
        await Should.ThrowAsync<DomainException>(_service.AddPrescriptionAsync(prescriptionReq,
            CancellationToken.None));
    }

    [Fact]
    public async Task Should_ThrowException_WhenDoctorDoesntExist()
    {
        //Arrange
        var prescriptionReq = new PrescriptionDOT
        (
            12312,
            new PatientDTO
            (
                1,
                "John",
                "Doe",
                DateTime.Now.Subtract(new TimeSpan(5000,0,0,0))
            ),
            new List<MedicamentDTO>()
            {
                new MedicamentDTO(1, 100, "fasdfa"),
                new MedicamentDTO(2, 100, "fasdfa"),
                new MedicamentDTO(3, 100, "fasdfa"),
                new MedicamentDTO(4, 100, "fasdfa")
            },
            DateTime.Now,
            DateTime.Now.AddDays(30),
            "Dasfasdfas"
        );

        //Act and Assert
        await Should.ThrowAsync<DomainException>(_service.AddPrescriptionAsync(prescriptionReq,
            CancellationToken.None));
    }

    [Fact]
    public async Task Should_ThrowException_WhenMedDoesntExist()
    {
        //Arrange
        var prescriptionReq = new PrescriptionDOT
        (
            1,
            new PatientDTO
            (
                1,
                "John",
                "Doe",
                DateTime.Now.Subtract(new TimeSpan(5000,0,0,0))
            ),
            new List<MedicamentDTO>()
            {
                new MedicamentDTO(8, 100, "fasdfa"),
                new MedicamentDTO(9, 100, "fasdfa"),
                new MedicamentDTO(10, 100, "fasdfa"),
                new MedicamentDTO(11, 100, "fasdfa"),
                new MedicamentDTO(12, 100, "fasdfa"),
                new MedicamentDTO(13, 100, "fasdfa")
            },
            DateTime.Now,
            DateTime.Now.AddDays(30),
            "Dasfasdfas"
        );

        //Act and Assert
        await Should.ThrowAsync<DomainException>(_service.AddPrescriptionAsync(prescriptionReq,
            CancellationToken.None));
    }

    [Fact]
    public async Task Should_ReturnID_WhenNewPrescriptionAdded()
    {
        //Arrange
        var prescriptionReq = new PrescriptionDOT
        (
            1,
            new PatientDTO
            (
                1, "Alice", "Johnson", new DateTime(1985, 4, 23)
            ),
            new List<MedicamentDTO>()
            {
                new MedicamentDTO(1, 100, "fasdfa"),
                new MedicamentDTO(2, 100, "fasdfa"),
            },
            DateTime.Now,
            DateTime.Now.AddDays(30),
            "Dasfasdfas"
        );

        //Act and Assert

        var result = await _service.AddPrescriptionAsync(prescriptionReq,
            CancellationToken.None);
        result.ShouldBeGreaterThan(0);
    }

    [Fact]
    public async Task Should_ReturnID_WhenNewPrescriptionAddedEvenWhenClientDoesntExist()
    {
        //Arrange
        var prescriptionReq = new PrescriptionDOT
        (
            1,
            new PatientDTO
            (
                6,
                "Mark",
                "Twain",
                DateTime.Now.Subtract(new TimeSpan(5000,0,0,0))
            ),
            new List<MedicamentDTO>()
            {
                new MedicamentDTO(1, 100, "fasdfa"),
                new MedicamentDTO(2, 100, "fasdfa"),
            },
            DateTime.Now,
            DateTime.Now.AddDays(30),
            "Dasfasdfas"
        );

        //Act and Assert

        var result = await _service.AddPrescriptionAsync(prescriptionReq,
            CancellationToken.None);
        result.ShouldBeGreaterThan(0);
    }

    [Fact]
    public async Task Should_ThrowException_WhenClientRequestedDoesntExist()
    {
        await Should.ThrowAsync<DomainException>(_service.GetPatient(123123, CancellationToken.None));
    }

    [Fact]
    public async Task Should_ReturnPatientResponseDTO_WhenClientExists()
    {
        var result = await _service.GetPatient(1, CancellationToken.None);
        var initialItem = new PatientResponseDTO(
            1,
            "Alice",
            "Johnson",
            new List<PrescriptionResponseDTO>()
            {
                new PrescriptionResponseDTO(
                    1,
                    DateOnly.FromDateTime(DateTime.Now),
                    DateOnly.FromDateTime(DateTime.Now).AddDays(30),
                    new List<MedicamentResponseDTO>()
                    {
                        new MedicamentResponseDTO(1, "fasdf",500,"sfasdf"),
                        new MedicamentResponseDTO(2, "fasdf",250,"sfasdf"),
                    },
                    new DoctorResponseDTO(1, "John")
                    )
            }
        );
        result.ShouldBeEquivalentTo(initialItem);
    }
}
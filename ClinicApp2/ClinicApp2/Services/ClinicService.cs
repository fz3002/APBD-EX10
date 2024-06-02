using ClinicApp.DTO;
using ClinicApp.Exceptions;
using ClinicApp.Models;
using ClinicApp.Repositories;

namespace ClinicApp.Services;

public class ClinicService : IClinicService
{
    private readonly IClinicRepository _clinicRepository;
    private readonly IDoctorRepository _doctorRepository;
    private readonly IPatientRepository _patientRepository;
    private readonly IMedicationRepository _medicationRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ClinicService(IUnitOfWork unitOfWork, IClinicRepository clinicRepository, IDoctorRepository doctorRepository, IPatientRepository patientRepository, IMedicationRepository medicationRepository)
    {
        _unitOfWork = unitOfWork;
        _clinicRepository = clinicRepository;
        _doctorRepository = doctorRepository;
        _patientRepository = patientRepository;
        _medicationRepository = medicationRepository;
    }

    public async Task<int> AddPrescriptionAsync(PrescriptionDOT prescriptionDot, CancellationToken cancellationToken)
    {
        EnsureNotMoreThen10Medicaments(prescriptionDot.Medicaments);
        EnsureDueDateGreaterThenDate(prescriptionDot.Date, prescriptionDot.DateDue);
        Doctor? doctor = await _doctorRepository.GetDoctorAsync(prescriptionDot.IdDoctor, cancellationToken);
        EnsureDoctorExists(doctor, prescriptionDot.IdDoctor);
        var medicaments = new List<Medicament>();
        foreach (var med in prescriptionDot.Medicaments)
        {
            Medicament? medicament = await _medicationRepository.GetMedicamentAsync(med.IdMedicament, cancellationToken);
            EnsureMedicamentExists(medicament, med.IdMedicament);
            medicaments.Add(medicament);
        }
        var patient = await _patientRepository.GetPatientAsync(prescriptionDot.Patient.IdPatient,
            prescriptionDot.Patient.FirstName, prescriptionDot.Patient.LastName, prescriptionDot.Patient.Birthdate, cancellationToken);
        var idPatient = await EnsurePatientExistsIfNotCreate(patient, prescriptionDot.Patient, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
        var idPrescription = await _clinicRepository.CreatePrescriptionAsync(prescriptionDot.IdDoctor, idPatient,
            prescriptionDot.Date, prescriptionDot.DateDue, cancellationToken);
        await _unitOfWork.CommitAsync(cancellationToken);
        foreach (var med in medicaments)
        {
            var prescriptionMedicament = new PrescriptionMedicament
            {
                IdMedicament = med.IdMedicament,
                IdPrescription = idPrescription,
                Details = prescriptionDot.Details
            };
            await _clinicRepository.AddMedToPrescriptionAsync(prescriptionMedicament, cancellationToken);
        }

        await _unitOfWork.CommitAsync(cancellationToken);

        return idPrescription;
    }

    public async Task<PatientResponseDTO> GetPatient(int idPatient, CancellationToken cancellationToken)
    {
        var patient = await _patientRepository.GetPatientAsync(idPatient, cancellationToken);
        EnsurePatientExists(patient, idPatient);
        var prescriptions = await _clinicRepository.GetPatientsPrescriptionsAsync(patient.IdPatient, cancellationToken);
        var prescriptionsResponse = new List<PrescriptionResponseDTO>();
        foreach (var prescription in prescriptions)
        {
            var medicaments =
                await _clinicRepository.GetMedicamentsForPrescriptionAsync(prescription.IdPrescription,
                    cancellationToken);
            var doctor = await _doctorRepository.GetDoctorAsync(prescription.IdDoctor, cancellationToken);
            var doctorResponse = new DoctorResponseDTO(doctor.IdDoctor, doctor.FirstName);
            var prescriptionResponse = new PrescriptionResponseDTO(prescription.IdPrescription, prescription.Date,
                prescription.DateDue, medicaments, doctorResponse);
            prescriptionsResponse.Add(prescriptionResponse);
        }

        var patientResponse = new PatientResponseDTO(patient.IdPatient, patient.FirstName, patient.LastName,
            prescriptionsResponse);
        return patientResponse;
    }

    private static void EnsureDoctorExists(Doctor? doctor, int id)
    {
        if (doctor == null)
        {
            throw new DomainException($"Doctor with id {id} doesn't exist");
        }
    }

    private async Task<int> EnsurePatientExistsIfNotCreate(Patient? patient, PatientDTO patientRequested, CancellationToken cancellationToken)
    {
        if (patient == null)
        {
            return await _patientRepository.CreatePatientAsync(patientRequested.IdPatient, patientRequested.FirstName,
                patientRequested.LastName, patientRequested.Birthdate, cancellationToken);
        }

        return patient.IdPatient;
    }

    private static void EnsurePatientExists(Patient? patient, int id)
    {
        if (patient == null)
        {
            throw new DomainException($"Patient with id {id} doesn't exist");
        }
    }

    private static void EnsureMedicamentExists(Medicament? med, int id)
    {
        if (med == null)
        {
            throw new DomainException($"Medicament with id {id} doesn't exist");
        }
    }

    private static void EnsureNotMoreThen10Medicaments(ICollection<MedicamentDTO> medicamentDtos)
    {
        if (medicamentDtos.Count > 10)
        {
            throw new DomainException($"Number of Medicaments must be under 10. Current value is {medicamentDtos.Count}");
        }
    }

    private static void EnsureDueDateGreaterThenDate(DateTime date, DateTime dateDue)
    {
        if (dateDue < date)
        {
            throw new DomainException(
                $"Given date due ({dateDue}) of prescription is smaller then current date ({date})");
        }
    }
}
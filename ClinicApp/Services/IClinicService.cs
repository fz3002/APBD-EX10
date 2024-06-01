using ClinicApp.DTO;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Services;

public interface IClinicService
{
    Task<int> AddPrescriptionAsync(PrescriptionDOT prescriptionDot, CancellationToken cancellationToken);
}
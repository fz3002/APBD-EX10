using ClinicApp2.DTO;
using ClinicApp2.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp2.Controllers;

[ApiController]
[Route("api/clinic")]
public class ClinicController : ControllerBase
{
    private readonly IClinicService _service;

    public ClinicController(IClinicService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> AddPrescription(PrescriptionDOT prescriptionDot, CancellationToken cancellationToken)
    {
        return Ok(await _service.AddPrescriptionAsync(prescriptionDot, cancellationToken));
    }

    [HttpGet("patients/{idPatient:int}")]
    public async Task<IActionResult> GetPatient(int idPatient, CancellationToken cancellationToken)
    {
        return Ok(await _service.GetPatient(idPatient, cancellationToken));
    }
}

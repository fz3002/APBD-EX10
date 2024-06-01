using ClinicApp.Context;
using ClinicApp.DTO;
using ClinicApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace ClinicApp.Controllers;

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
}

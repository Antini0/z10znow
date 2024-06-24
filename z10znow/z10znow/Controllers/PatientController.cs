using Microsoft.AspNetCore.Mvc;
using z10znow.Services;

namespace z10znow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly IDbService _dbService;

    public PatientController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{patientId}")]
    public async Task<IActionResult> GetPatientData(int patientId)
    {
        var patientData = await _dbService.GetPatientsData(patientId);
        if (patientData == null)
        {
            return NotFound();
        }
        return Ok(patientData);
    }
}
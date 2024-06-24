using Microsoft.AspNetCore.Mvc;
using z10znow.Context;
using z10znow.DTOs;
using z10znow.Models;
using z10znow.Services;

namespace z10znow.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PerscriptionController : ControllerBase
{
    private readonly IDbService _dbService;

    public PerscriptionController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpPost("add")]
    public async Task<IActionResult> addPerscription([FromBody] PrescriptionRequest request)
    {
        if (!await _dbService.doesPatientExist(request.Patient.IdPatient))
        {
            var patient = new Patient
            {
                IdPatient = request.Patient.IdPatient,
                firstName = request.Patient.FirstName,
                lastName = request.Patient.LastName,
                BirthDate = request.Patient.BirthDate
            };
            await _dbService.addNewPatient(patient);
        }

        foreach (var medicament in request.Medicaments)
        {
            if (!await _dbService.doesMedicamentExist(medicament.IdMedicament))
            {
                return NotFound();
            }
        }

        if (!await _dbService.isMedNumberRight(request.Medicaments.Count))
        {
            return BadRequest();
        }

        if (!await _dbService.isDateRight(request.Date, request.DueDate))
        {
            return BadRequest();
        }
        var perscription = new Perscription
        {
            Date = request.Date,
            DueDate = request.DueDate,
            IdPatient = request.Patient.IdPatient,
            IdDoctor = request.DoctorId,
            PerscriptionMedicaments = request.Medicaments.Select(m => new Perscription_Medicament
            {
                IdMedicament = m.IdMedicament,
                Dose = m.Dose,
                Details = m.Description
            }).ToList()
        };

        await _dbService.addNewPerscription(perscription);

        return Ok("Prescription added successfully.");
        
    }
}
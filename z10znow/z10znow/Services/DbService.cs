using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using z10znow.Context;
using z10znow.DTOs;
using z10znow.Models;

namespace z10znow.Services;

public class DbService : IDbService
{
    private readonly W7Context _w7Context;

    public DbService(W7Context w7Context)
    {
        _w7Context = w7Context;
    }

    public async Task addNewPerscription(Perscription perscription)
    {
        await _w7Context.Perscriptions.AddAsync(perscription);
        await _w7Context.SaveChangesAsync();
    }

    public async Task<bool> doesPatientExist(int patientID)
    {
        return await _w7Context.Patients.AnyAsync(p => p.IdPatient == patientID);
    }

    public async Task<Patient> GetPatientById(int patientId)
    {
        return await _w7Context.Patients.FindAsync(patientId);
    }

    public async Task addNewPatient(Patient patient)
    {
        await _w7Context.Patients.AddAsync(patient);
        await _w7Context.SaveChangesAsync();
    }

    public async Task<bool> doesMedicamentExist(int medicamentID)
    {
        return await _w7Context.Medicaments.AnyAsync(m => m.IdMedicament == medicamentID);
    }

    public async Task<bool> isMedNumberRight(int numOfMeds)
    {
        return numOfMeds >= 10;
    }

    public async Task<bool> isDateRight(DateTime date, DateTime dueDate)
    {
        return dueDate >= date;
    }

    public async Task<GetPatientDataDTO> GetPatientsData(int patientId)
    {
        var patient = await _w7Context.Patients
            .Include(p => p.Perscriptions)
            .ThenInclude(pr => pr.PerscriptionMedicaments)
            .ThenInclude(pm => pm.Medicament)
            .Include(p => p.Perscriptions)
            .ThenInclude(pr => pr.Doctor)
            .FirstOrDefaultAsync(p => p.IdPatient == patientId);

        if (patient == null)
        {
            return null;
        }

        var patientDataDto = new GetPatientDataDTO
        {
            Patient = new PatientDto
            {
                IdPatient = patient.IdPatient,
                FirstName = patient.firstName,
                LastName = patient.lastName,
                BirthDate = patient.BirthDate
            },
            Perscritpions = patient.Perscriptions
                .OrderBy(pr => pr.DueDate)
                .Select(pr => new PerscritpionDTO
                {
                    IdPerscritpion = pr.IdPerscription,
                    Date = pr.Date,
                    DueDate = pr.DueDate,
                    Doctor = new DoctorDTO
                    {
                        IdDoctor = pr.Doctor.IdDoctor,
                        FirstName = pr.Doctor.firstName,
                        LastName = pr.Doctor.lastName
                    },
                    Medicaments = pr.PerscriptionMedicaments
                        .Select(pm => new MedicamentDto
                        {
                            IdMedicament = pm.Medicament.IdMedicament,
                            Name = pm.Medicament.name,
                            Description = pm.Medicament.desc,
                            Dose = pm.Dose
                        })
                        .ToList()
                })
                .ToList()
        };

        return patientDataDto;
    }
}
using z10znow.DTOs;
using z10znow.Models;

namespace z10znow.Services;

public interface IDbService
{
    Task addNewPerscription(Perscription perscription);
    Task<bool> doesPatientExist(int patientID);
    Task<Patient> GetPatientById(int patientId);
    Task addNewPatient(Patient patient);
    Task<bool> doesMedicamentExist(int numOfMeds);
    Task<bool> isMedNumberRight(int perscriptionID);
    Task<bool> isDateRight(DateTime date, DateTime dueDate);
    Task<GetPatientDataDTO> GetPatientsData(int patientID);
}
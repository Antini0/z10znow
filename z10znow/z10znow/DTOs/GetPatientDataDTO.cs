using z10znow.Models;

namespace z10znow.DTOs;

public class GetPatientDataDTO
{
    public PatientDto Patient { get; set; }
    public ICollection<PerscritpionDTO> Perscritpions { get; set; }
}

public class PerscritpionDTO
{
    public int IdPerscritpion { get; set; }
    public DateTime Date { get; set; }
    public DateTime DueDate { get; set; }
    public ICollection<MedicamentDto> Medicaments { get; set; }
    public DoctorDTO Doctor { get; set; }
}

public class DoctorDTO
{
    public int IdDoctor { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}

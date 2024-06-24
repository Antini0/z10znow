using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace z10znow.Models;

public class Perscription
{
    [Key]
    public int IdPerscription { get; set; }
    
    [Required] 
    public DateTime Date { get; set; }
    
    [Required] 
    public DateTime DueDate { get; set; }
    
    [Required]
    public int IdPatient { get; set; }
    
    [ForeignKey(nameof(IdPatient))]
    public Patient Patient { get; set; }
    
    [Required]
    public int IdDoctor { get; set; }
    
    [ForeignKey(nameof(IdDoctor))]
    public Doctor Doctor { get; set; }
    
    public ICollection<Perscription_Medicament> PerscriptionMedicaments { get; set; }
}
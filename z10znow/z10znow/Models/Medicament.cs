using System.ComponentModel.DataAnnotations;

namespace z10znow.Models;

public class Medicament
{
    [Key]
    public int IdMedicament { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string name { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string desc { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string type { get; set; }

    public ICollection<Perscription_Medicament> PerscriptionMedicaments { get; set; }
}
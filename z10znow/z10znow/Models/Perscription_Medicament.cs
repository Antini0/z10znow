using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace z10znow.Models;

[PrimaryKey(nameof(IdMedicament), nameof(IdPerscription))]
public class Perscription_Medicament
{
    [Key] 
    public int IdMedicament { get; set; }
    public int IdPerscription { get; set; }
    
    [ForeignKey(nameof(IdMedicament))]
    public Medicament Medicament { get; set; }
    
    [ForeignKey(nameof(IdPerscription))]
    public Perscription Perscription { get; set; }

    public int Dose { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string Details { get; set; }
}
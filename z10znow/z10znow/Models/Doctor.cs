using System.ComponentModel.DataAnnotations;

namespace z10znow.Models;

public class Doctor
{
    [Key]
    public int IdDoctor { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string firstName { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string lastName { get; set; }
    
    [MaxLength(100)]
    [Required]
    public string email { get; set; }
    
    public ICollection<Perscription> Perscriptions { get; set; }
}
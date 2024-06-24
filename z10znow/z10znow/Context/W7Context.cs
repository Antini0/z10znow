using Microsoft.EntityFrameworkCore;
using z10znow.Models;

namespace z10znow.Context;

public partial class W7Context : DbContext
{
    public W7Context()
    {
    }

    public W7Context(DbContextOptions<W7Context> options) : base(options)
    {
    }
    
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Perscription> Perscriptions { get; set; }
    public DbSet<Medicament> Medicaments { get; set; }
    public DbSet<Perscription_Medicament> PerscriptionMedicaments { get; set; }
}
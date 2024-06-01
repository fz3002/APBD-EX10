using ClinicApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicApp.Context;

public partial class ClinicDbContext : DbContext
{
    public ClinicDbContext()
    {
    }

    public ClinicDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Doctor> Doctors { get; set; }

    public DbSet<Prescription> Prescriptions { get; set; }

    public DbSet<Patient> Patients { get; set; }

    public DbSet<Medicament> Medicaments { get; set; }

    public DbSet<PrescriptionMedicament> PrescriptionMedicaments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ClinicDbContext).Assembly);
    }
}
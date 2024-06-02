using ClinicApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicApp.Configurations;

public class PrescriptionEntityTypeConfiguration : IEntityTypeConfiguration<Prescription>
{
    public void Configure(EntityTypeBuilder<Prescription> builder)
    {
        builder.HasKey(d => d.IdPrescription);
        builder.HasOne(p => p.Doctor).WithMany(p => p.Prescriptions).HasForeignKey(p => p.IdDoctor);
        builder.HasOne(p => p.Patient).WithMany(p => p.Prescriptions).HasForeignKey(p => p.IdPatient);
        builder.Property(d => d.Date).IsRequired();
        builder.Property(d => d.DateDue).IsRequired();
    }
};
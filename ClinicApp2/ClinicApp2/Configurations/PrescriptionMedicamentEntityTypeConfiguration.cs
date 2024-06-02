using ClinicApp2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicApp2.Configurations;

public class PrescriptionMedicamentEntityTypeConfiguration : IEntityTypeConfiguration<PrescriptionMedicament>
{
    public void Configure(EntityTypeBuilder<PrescriptionMedicament> builder)
    {
        builder.HasKey(pm => new {pm.IdMedicament, pm.IdPrescription});
        builder.HasOne(pm => pm.Prescription).WithMany(pm => pm.PrescriptionMedicaments)
            .HasForeignKey(pm => pm.IdPrescription);
        builder.HasOne(pm => pm.Medicament).WithMany(pm => pm.PrescriptionMedicaments)
            .HasForeignKey(pm => pm.IdMedicament);
        builder.Property(pm => pm.Details).IsRequired().HasMaxLength(100);
    }
}
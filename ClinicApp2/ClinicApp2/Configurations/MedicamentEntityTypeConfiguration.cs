using ClinicApp2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicApp2.Configurations;

public class MedicamentEntityTypeConfiguration : IEntityTypeConfiguration<Medicament>
{
    public void Configure(EntityTypeBuilder<Medicament> builder)
    {
        builder.HasKey(m => m.IdMedicament);
        builder.Property(m => m.Name).IsRequired().HasMaxLength(100).IsConcurrencyToken();
        builder.Property(m => m.Description).IsRequired().HasMaxLength(100);
        builder.Property(m => m.Type).IsRequired().HasMaxLength(100);
    }
}
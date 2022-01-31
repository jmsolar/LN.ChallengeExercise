using LN.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LN.Infraestructure.Persistence.Configurations
{
    public static class PhoneNumberConfiguration
    {
        public static void InitTableStructure(ModelBuilder builder) {
            builder.Entity<PhoneNumber>(entity =>
            {
                entity.Property(pn => pn.StateCode)
                    .IsRequired()
                    .HasMaxLength(5);
                entity.Property(pn => pn.CountryCode)
                    .IsRequired()
                    .HasMaxLength(4);
                entity.Property(pn => pn.Number)
                    .IsRequired()
                    .HasMaxLength(8);
            });
        }
    }
}

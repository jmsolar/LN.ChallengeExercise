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
                    .HasMaxLength(8);
                entity.Property(pn => pn.CountryCode)
                    .HasMaxLength(8);
                entity.Property(pn => pn.Number)
                    .HasMaxLength(10);
            });
        }
    }
}

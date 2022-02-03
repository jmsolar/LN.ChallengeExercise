using LN.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LN.Infraestructure.Persistence.Configurations
{
    public static class CountryConfiguration
    {
        public static void InitTableStructure(ModelBuilder builder)
        {
            builder.Entity<Country>(entity =>
            {
                entity.Property(co => co.Name)
                    .HasMaxLength(20);
                entity.Property(co => co.NumericCode)
                    .HasMaxLength(8);
                entity.Property(co => co.AlphaCode)
                    .HasMaxLength(8);
            });
        }
    }
}

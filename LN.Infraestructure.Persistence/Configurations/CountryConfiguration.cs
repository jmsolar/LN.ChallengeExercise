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
                    .IsRequired()
                    .HasMaxLength(20);
                entity.Property(co => co.NumericCode)
                    .IsRequired()
                    .HasMaxLength(4);
                entity.Property(co => co.AlphaCode)
                    .IsRequired()
                    .HasMaxLength(4);
            });
        }
    }
}

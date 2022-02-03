using LN.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LN.Infraestructure.Persistence.Configurations
{
    public static class CityConfiguration
    {
        public static void InitTableStructure(ModelBuilder builder)
        {
            builder.Entity<City>(entity =>
            {
                entity.Property(ci => ci.Name)
                    .HasMaxLength(20);
                entity.Property(ci => ci.ZipCode)
                    .HasMaxLength(8);
            });
        }
    }
}

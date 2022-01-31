using LN.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LN.Infraestructure.Persistence.Configurations
{
    public static class AddressConfiguration
    {
        public static void InitTableStructure(ModelBuilder builder)
        {
            builder.Entity<Address>(entity =>
            {
                entity.Property(ad => ad.Detail)
                    .HasMaxLength(50);
            });
        }
    }
}

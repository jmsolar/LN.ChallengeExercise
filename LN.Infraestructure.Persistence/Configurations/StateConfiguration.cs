using LN.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LN.Infraestructure.Persistence.Configurations
{
    public static class StateConfiguration
    {
        public static void InitTableStructure(ModelBuilder builder)
        {
            builder.Entity<State>(entity =>
            {
                entity.Property(st => st.Name)
                    .HasMaxLength(20);
                entity.Property(st => st.Code)
                    .HasMaxLength(8);
            });
        }
    }
}

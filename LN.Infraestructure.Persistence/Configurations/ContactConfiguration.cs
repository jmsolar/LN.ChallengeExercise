using LN.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LN.Infraestructure.Persistence.Configurations
{
    public static class ContactConfiguration
    {
        public static void InitTableStructure(ModelBuilder builder)
        {
            builder.Entity<Contact>(entity =>
            {
                entity.Property(cn => cn.Name)
                    .HasMaxLength(30);
                entity.Property(cn => cn.Company)
                    .HasMaxLength(15);
                entity.Property(cn => cn.Profile)
                    .HasMaxLength(10);
                entity.Property(cn => cn.Image);
                entity.Property(cn => cn.Email)
                    .HasMaxLength(30);
                entity.Property(cn => cn.Birthdate)
                    .HasColumnType("datetime2(0)");
            });
        }
    }
}

using LN.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace LN.Infraestructure.Persistence.Configurations
{
    public static class ContactConfiguration
    {
        public static void InitTableStructure(ModelBuilder builder)
        {

            //builder.InsertData(
            //    table: "Blogs",
            //    columns: new[] { "Url" },
            //    values: new object[] { "http://generated.com" });

            //builder.Entity<Contact>(entity =>
            //{
            //    entity.Property(cn => cn.Name)
            //        .HasMaxLength(30);
            //    entity.Property(cn => cn.Company)
            //        .IsRequired()
            //        .HasMaxLength(15);
            //    entity.Property(cn => cn.Profile)
            //        .IsRequired()
            //        .HasMaxLength(10);
            //    entity.Property(cn => cn.Image);
            //    entity.Property(cn => cn.Email)
            //        .HasColumnType("EmailAddress")
            //        .HasMaxLength(30);
            //    entity.Property(cn => cn.Birthdate)
            //        .HasColumnType("DateTime");

            //    entity.HasData(
            //        new Contact()
            //        {
            //            Id = Guid.NewGuid(),
            //            Created = DateTime.Now.ToUniversalTime(),
            //            CreatedBy = Guid.NewGuid(),
            //            Name = "Juan",
            //            Company = "LN",
            //            Profile = "Admin",
            //            Email = "juan@juan.com",
            //            Birthdate = new DateTime(1979, 2, 13)
            //        });

            //    entity.OwnsOne(cn => cn.PhoneNumber).HasData(
            //        new PhoneNumber()
            //        {
            //            Id = Guid.NewGuid(),
            //            Created = DateTime.Now.ToUniversalTime(),
            //            CreatedBy = Guid.NewGuid(),
            //            StateCode = "88",
            //            CountryCode = "44",
            //            Number = "12345678"
            //        }
            //    );

            //    entity.OwnsOne(cn => cn.Address.City).HasData(
            //        new Address()
            //        {
            //            Id = Guid.NewGuid(),
            //            Created = DateTime.Now.ToUniversalTime(),
            //            CreatedBy = Guid.NewGuid(),
            //            Country = new Country()
            //            {
            //                Id = Guid.NewGuid(),
            //                Created = DateTime.Now.ToUniversalTime(),
            //                CreatedBy = Guid.NewGuid(),
            //                Name = "Argentina",
            //                NumericCode = 32,
            //                AlphaCode = "AR"
            //            },
            //            State = new State()
            //            {
            //                Id = Guid.NewGuid(),
            //                Created = DateTime.Now.ToUniversalTime(),
            //                CreatedBy = Guid.NewGuid(),
            //                Code = "AR-B",
            //                Name = "Buenos Aires"
            //            },
            //            City = new City()
            //            {
            //                Id = Guid.NewGuid(),
            //                Created = DateTime.Now.ToUniversalTime(),
            //                CreatedBy = Guid.NewGuid(),
            //                Name = "Lisandro Olmos",
            //                ZipCode = 1901
            //            },
            //            Detail = "Av 7 N°1"
            //        }
            //    );
            //});
        }
    }
}

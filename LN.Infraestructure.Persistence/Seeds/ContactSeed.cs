using LN.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace LN.Infraestructure.Persistence.Seeds
{
    public class ContactSeed : IEntityTypeConfiguration<Contact>
    {
        private EntityTypeBuilder<Contact> _builder;

        private void Seed()
        {
            _builder.HasData(
                new Contact() {
                    Id = Guid.NewGuid(),
                    Created = DateTime.Now.ToUniversalTime(),
                    CreatedBy = Guid.NewGuid(),
                    Name = "Juan",
                    Company = "LN",
                    Profile = "Admin",
                    Email = "juan@juan.com",
                    Birthdate = new DateTime(1979, 2, 13),
                    PhoneNumber = new PhoneNumber()
                    {
                        Id = Guid.NewGuid(),
                        Created = DateTime.Now.ToUniversalTime(),
                        CreatedBy = Guid.NewGuid(),
                        StateCode = "88",
                        CountryCode = "44",
                        Number = "12345678"
                    },
                    Address = new Address()
                    {
                        Id = Guid.NewGuid(),
                        Created = DateTime.Now.ToUniversalTime(),
                        CreatedBy = Guid.NewGuid(),
                        Country = new Country()
                        {
                            Id = Guid.NewGuid(),
                            Created = DateTime.Now.ToUniversalTime(),
                            CreatedBy = Guid.NewGuid(),
                            Name = "Argentina",
                            NumericCode = 32,
                            AlphaCode = "AR"
                        },
                        State = new State()
                        {
                            Id = Guid.NewGuid(),
                            Created = DateTime.Now.ToUniversalTime(),
                            CreatedBy = Guid.NewGuid(),
                            Code = "AR-B",
                            Name = "Buenos Aires"
                        },
                        City = new City()
                        {
                            Id = Guid.NewGuid(),
                            Created = DateTime.Now.ToUniversalTime(),
                            CreatedBy = Guid.NewGuid(),
                            Name = "Lisandro Olmos",
                            ZipCode = 1901
                        },
                        Detail = "Av 7 N°1"
                    }
                },
                new Contact()
                {
                    Id = Guid.NewGuid(),
                    Created = DateTime.Now.ToUniversalTime(),
                    CreatedBy = Guid.NewGuid(),
                    Name = "Pedro",
                    Company = "Min. de Educación",
                    Profile = "Usuario",
                    Email = "jpedro@pedroj.com",
                    Birthdate = new DateTime(2002, 5, 21),
                    PhoneNumber = new PhoneNumber()
                    {
                        Id = Guid.NewGuid(),
                        Created = DateTime.Now.ToUniversalTime(),
                        CreatedBy = Guid.NewGuid(),
                        StateCode = "5",
                        CountryCode = "6",
                        Number = "87654321"
                    },
                    Address = new Address()
                    {
                        Id = Guid.NewGuid(),
                        Created = DateTime.Now.ToUniversalTime(),
                        CreatedBy = Guid.NewGuid(),
                        Country = new Country()
                        {
                            Id = Guid.NewGuid(),
                            Created = DateTime.Now.ToUniversalTime(),
                            CreatedBy = Guid.NewGuid(),
                            Name = "Argentina",
                            NumericCode = 32,
                            AlphaCode = "AR"
                        },
                        State = new State()
                        {
                            Id = Guid.NewGuid(),
                            Created = DateTime.Now.ToUniversalTime(),
                            CreatedBy = Guid.NewGuid(),
                            Code = "AR-K",
                            Name = "Catamarca"
                        },
                        City = new City()
                        {
                            Id = Guid.NewGuid(),
                            Created = DateTime.Now.ToUniversalTime(),
                            CreatedBy = Guid.NewGuid(),
                            Name = "City Bell",
                            ZipCode = 1896
                        },
                        Detail = "520 N°9999"
                    }
                },
                new Contact()
                {
                    Id = Guid.NewGuid(),
                    Created = DateTime.Now.ToUniversalTime(),
                    CreatedBy = Guid.NewGuid(),
                    Name = "Juan Martin",
                    Company = "Facebook",
                    Profile = "Superadmin",
                    Email = "jmartin@martin.com.ar",
                    Birthdate = new DateTime(1987, 11, 30),
                    PhoneNumber = new PhoneNumber()
                    {
                        Id = Guid.NewGuid(),
                        Created = DateTime.Now.ToUniversalTime(),
                        CreatedBy = Guid.NewGuid(),
                        StateCode = "3",
                        CountryCode = "86",
                        Number = "123123123"
                    },
                    Address = new Address()
                    {
                        Id = Guid.NewGuid(),
                        Created = DateTime.Now.ToUniversalTime(),
                        CreatedBy = Guid.NewGuid(),
                        Country = new Country()
                        {
                            Id = Guid.NewGuid(),
                            Created = DateTime.Now.ToUniversalTime(),
                            CreatedBy = Guid.NewGuid(),
                            Name = "Egipto",
                            NumericCode = 818,
                            AlphaCode = "EG"
                        },
                        State = new State()
                        {
                            Id = Guid.NewGuid(),
                            Created = DateTime.Now.ToUniversalTime(),
                            CreatedBy = Guid.NewGuid(),
                            Code = "EG-B",
                            Name = "Luxor"
                        },
                        City = new City()
                        {
                            Id = Guid.NewGuid(),
                            Created = DateTime.Now.ToUniversalTime(),
                            CreatedBy = Guid.NewGuid(),
                            Name = "Luxor City ",
                            ZipCode = 32
                        },
                        Detail = "St Lux"
                    }
                }
            );
        }

        public void Configure(EntityTypeBuilder<Contact> builder)
        {
            _builder = builder;
            Seed();
        }
    }
}

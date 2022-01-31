using LN.Core.Domain.Entities;
using LN.Infraestructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LN.Infraestructure.Persistence.Seeds
{
    public class SeedContacts
    {
        private readonly ApplicationContext _applicationContext;

        public SeedContacts(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public async Task Seed()
        {
            if (!_applicationContext.Contacts.Any())
            {
                var contacts = new List<Contact>()
                {
                    new Contact()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Juan",
                        Company = "LN",
                        Profile = "Admin",
                        Email = "juan@juan.com",
                        Birthdate = new DateTime(1979, 2, 13),
                        PhoneNumber = new PhoneNumber()
                        {
                            Id = Guid.NewGuid(),
                            StateCode = "88",
                            CountryCode = "44",
                            Number = "12345678"
                        },
                        Address = new Address()
                        {
                            Id = Guid.NewGuid(),
                            Country = new Country()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Argentina",
                                NumericCode = 32,
                                AlphaCode = "AR"
                            },
                            State = new State()
                            {
                                Id = Guid.NewGuid(),
                                Code = "AR-B",
                                Name = "Buenos Aires"
                            },
                            City = new City()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Lisandro Olmos",
                                ZipCode = 1901
                            },
                            Detail = "Av 7 N°1"
                        }
                    },
                    new Contact()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Estefania",
                        Company = "GL",
                        Profile = "Admin",
                        Email = "estefi@es.com",
                        Birthdate = new DateTime(1988, 5, 12),
                        PhoneNumber = new PhoneNumber()
                        {
                            Id = Guid.NewGuid(),
                            StateCode = "12",
                            CountryCode = "54",
                            Number = "87609833"
                        },
                        Address = new Address()
                        {
                            Id = Guid.NewGuid(),
                            Country = new Country()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Argentina",
                                NumericCode = 32,
                                AlphaCode = "AR"
                            },
                            State = new State()
                            {
                                Id = Guid.NewGuid(),
                                Code = "AR-BC",
                                Name = "Ciudad de Buenos Aires"
                            },
                            City = new City()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Palermo",
                                ZipCode = 1401
                            },
                            Detail = "Suipacha Nº 123"
                        }
                    },
                    new Contact()
                    {
                        Id = Guid.NewGuid(),
                        Name = "Lucia",
                        Company = "LN",
                        Profile = "Admin",
                        Email = "lucia@lucia.com.ar",
                        Birthdate = new DateTime(2000, 11, 25),
                        PhoneNumber = new PhoneNumber()
                        {
                            Id = Guid.NewGuid(),
                            StateCode = "88",
                            CountryCode = "44",
                            Number = "12345678"
                        },
                        Address = new Address()
                        {
                            Id = Guid.NewGuid(),
                            Country = new Country()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Argentina",
                                NumericCode = 32,
                                AlphaCode = "AR"
                            },
                            State = new State()
                            {
                                Id = Guid.NewGuid(),
                                Code = "AR-CA",
                                Name = "Catamarca"
                            },
                            City = new City()
                            {
                                Id = Guid.NewGuid(),
                                Name = "Ciuda de Catamarca",
                                ZipCode = 345
                            },
                            Detail = "Calle Mitre 56"
                        }
                    }
                };

                var c = new Contact()
                {
                    Id = Guid.NewGuid(),
                    Name = "Juan",
                    Company = "LN",
                    Profile = "Admin",
                    Email = "juan@juan.com",
                    Birthdate = new DateTime(1979, 2, 13),
                    PhoneNumber = new PhoneNumber()
                    {
                        Id = Guid.NewGuid(),
                        StateCode = "88",
                        CountryCode = "44",
                        Number = "12345678"
                    },
                    Address = new Address()
                    {
                        Id = Guid.NewGuid(),
                        Country = new Country()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Argentina",
                            NumericCode = 32,
                            AlphaCode = "AR"
                        },
                        State = new State()
                        {
                            Id = Guid.NewGuid(),
                            Code = "AR-B",
                            Name = "Buenos Aires"
                        },
                        City = new City()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Lisandro Olmos",
                            ZipCode = 1901
                        },
                        Detail = "Av 7 N°1"
                    }
                };

                await _applicationContext.Contacts.AddAsync(c);
                //await _applicationContext.Contacts.AddRangeAsync(contacts);
                await _applicationContext.SaveChangesAsync();
            }
        }
    }
}

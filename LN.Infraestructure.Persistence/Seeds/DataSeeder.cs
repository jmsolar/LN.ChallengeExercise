using LN.Core.Domain.Entities;
using LN.Infraestructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LN.Infraestructure.Persistence.Seeds
{
    public class DataSeeder
    {
        private readonly ApplicationContext _applicationContext;

        public DataSeeder(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public void Seed()
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
                    }
                };

                _applicationContext.Contacts.AddRange(contacts);
                _applicationContext.SaveChanges();
            }
        }
    }
}

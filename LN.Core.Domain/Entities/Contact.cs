using LN.Core.Domain.Entities.Common;
using System;

namespace LN.Core.Domain.Entities
{
    public class Contact : AuditableEntity
    {
        public string Name { get; set; }
        public string Company { get; set; }
        public string Profile { get; set; }
        public string Image { get; set; }
        public string Email { get; set; }
        public DateTime Birthdate { get; set; }
        public PhoneNumber PhoneNumber { get; set; }
        public Address Address { get; set; }
    }
}

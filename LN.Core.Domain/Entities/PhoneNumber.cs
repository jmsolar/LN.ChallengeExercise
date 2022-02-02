using LN.Core.Domain.Entities.Common;
using System;

namespace LN.Core.Domain.Entities
{
    public class PhoneNumber : AuditableEntity
    {
        public string CountryCode { get; set; }
        public string StateCode { get; set; }
        public string Number { get; set; }
        public Guid ContactId { get; set; }
    }
}

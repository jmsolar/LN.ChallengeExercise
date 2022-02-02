using LN.Core.Domain.Entities.Common;
using System;

namespace LN.Core.Domain.Entities
{
    public class City : AuditableEntity
    {
        public int ZipCode { get; set; }
        public string Name { get; set; }
        public Guid AddressId { get; set; }
    }
}

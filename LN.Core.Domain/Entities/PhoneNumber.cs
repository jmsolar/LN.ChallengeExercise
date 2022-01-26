using LN.Core.Domain.Entities.Common;

namespace LN.Core.Domain.Entities
{
    public class PhoneNumber : AuditableEntity
    {
        public string CountryCode { get; set; }
        public string StateCode { get; set; }
        public string Number { get; set; }
    }
}

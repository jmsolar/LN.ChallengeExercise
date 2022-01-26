using LN.Core.Domain.Entities.Common;

namespace LN.Core.Domain.Entities
{
    public class Address : AuditableEntity
    {
        public Country Country { get; set; }
        public State State { get; set; }
        public City City { get; set; }

        // Calle + numero + piso
        public string Detail { get; set; }
    }
}

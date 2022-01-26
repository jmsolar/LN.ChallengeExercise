using LN.Core.Domain.Entities.Common;

namespace LN.Core.Domain.Entities
{
    public class Country : AuditableEntity
    {
        public string Name { get; set; }
        public int NumericCode { get; set; }
        public string AlphaCode { get; set; }
    }
}

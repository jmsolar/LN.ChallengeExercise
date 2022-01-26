using LN.Core.Domain.Entities.Common;

namespace LN.Core.Domain.Entities
{
    public class State : AuditableEntity
    {
        public string Code { get; set; }
        public string Name { get; set; }
    }
}

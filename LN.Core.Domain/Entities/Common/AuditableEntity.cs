using System;

namespace LN.Core.Domain.Entities.Common
{
    public abstract class AuditableEntity : BaseEntity
    {
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastModified { get; set; }
    }
}

using System;

namespace LN.Core.Domain.Entities.Common
{
    public abstract class BaseEntity
    {
        public Guid Id { get; set; }
    }
}

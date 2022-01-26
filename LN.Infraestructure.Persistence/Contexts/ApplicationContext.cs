using LN.Core.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LN.Infraestructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
        {

        }

        /// <summary>
        /// Custom method adding audit and identifier fields
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                entry.Entity.LastModified = DateTime.Now;

                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.Created = DateTime.Now;
                        entry.Entity.CreatedBy = new Guid();
                        break;
                    case EntityState.Modified:
                        entry.Entity.ModifiedBy = new Guid();
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

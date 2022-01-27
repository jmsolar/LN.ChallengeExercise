using LN.Core.Domain.Entities;
using LN.Core.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LN.Infraestructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<State> States { get; set; }

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

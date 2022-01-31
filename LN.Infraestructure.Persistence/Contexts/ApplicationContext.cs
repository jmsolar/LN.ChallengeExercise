using LN.Core.Domain.Entities;
using LN.Core.Domain.Entities.Common;
using LN.Infraestructure.Persistence.Configurations;
using LN.Infraestructure.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace LN.Infraestructure.Persistence.Contexts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        #region define tables
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<State> States { get; set; }
        #endregion

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

        /// <summary>
        /// Custom method to config tables
        /// </summary>
        /// <param name="builder"></param>
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("ApplicationDB");

            InitializeDB(builder);
        }

        /// <summary>
        /// Initialize DB
        /// </summary>
        /// <param name="builder"></param>
        private static void InitializeDB(ModelBuilder builder) {
            PhoneNumberConfiguration.InitTableStructure(builder);
            StateConfiguration.InitTableStructure(builder);
            CountryConfiguration.InitTableStructure(builder);
            CityConfiguration.InitTableStructure(builder);
            AddressConfiguration.InitTableStructure(builder);
            ContactConfiguration.InitTableStructure(builder);
        }
    }
}

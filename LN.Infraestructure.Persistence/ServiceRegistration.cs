using LN.Infraestructure.Persistence.Contexts;
using LN.Infraestructure.Persistence.Repositories.Implementations;
using LN.Infraestructure.Persistence.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LN.Infraestructure.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration["ConnectionStrings:ApplicationConnection"];
            services.AddDbContext<ApplicationContext>(options => 
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName))
            );

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IContactRepository, ContactRepository>();
            #endregion
        }
    }
}

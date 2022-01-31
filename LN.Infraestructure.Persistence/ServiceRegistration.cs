using LN.Infraestructure.Persistence.Contexts;
using LN.Infraestructure.Persistence.Repositories.Implementations;
using LN.Infraestructure.Persistence.Repositories.Interfaces;
using LN.Infraestructure.Persistence.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LN.Infraestructure.Persistence
{
    public static class ServiceRegistration
    {
        private static IServiceCollection _services;
        private static IConfiguration _configuration;

        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            _services = services;
            _configuration = configuration;

            ConfigDB();
            ConfigRepo();
            InitSeeder();
        }

        private static void ConfigDB()
        {
            var connectionString = _configuration["ConnectionStrings:ApplicationConnection"];
            _services.AddDbContext<ApplicationContext>(options => options
                .UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(ApplicationContext).Assembly.FullName))
                .EnableSensitiveDataLogging()
            );
        }

        private static void ConfigRepo()
        {
            _services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            _services.AddTransient<IContactRepository, ContactRepository>();
        }

        private static void InitSeeder()
        {
            _services.AddTransient<DataSeeder>();
        }
    }
}

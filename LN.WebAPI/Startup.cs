using LN.Infraestructure.Persistence;
using LN.Service.Implementations;
using LN.Service.Interfaces;
using LN.WebAPI.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;

namespace LN.WebAPI
{
    public class Startup
    {
        private string connectionString { get => Configuration["ConnectionStrings:ApplicationConnection"]; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            
            services.AddPersistenceInfrastructure(Configuration);
            services.AddTransient<IContactService, ContactService>();
            services.AddSwaggerExtension();
            services.AddMemoryCache(options =>
            {
                options.SizeLimit = 1024; // Tamaño maximo en cache
            });
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSerilogExtension(logger, Configuration, connectionString);
            app.UseSerilogRequestLogging();
            app.UseRequestResponseHandlingMiddleware();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwaggerExtension();
        }
    }
}

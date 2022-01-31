using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace LN.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddSwaggerExtension(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Challenge LN.WebApi",
                    Description = "API for LN challenge",
                    Contact = new OpenApiContact
                    {
                        Name = "Jonatan Matias Solar",
                        Email = "matias.solar@outlook.c",
                        Url = new Uri("https://github.com/jmsolar"),
                    }
                });
            });
        }
    }
}

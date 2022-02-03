using LN.WebAPI.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.MSSqlServer;

namespace LN.WebAPI.Extensions
{
    public static class AppExtensions
    {
        public static void UseSwaggerExtension(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LN.WebApi");
            });
        }

        public static void UseRequestResponseHandlingMiddleware(this IApplicationBuilder app)
        {
            app.UseMiddleware<RequestResponseLoggingMiddleware>();
        }
        public static void UseSerilogExtension(this IApplicationBuilder app, ILoggerFactory logger, IConfiguration config, string connectionString)
        {
            var expr = "@Message not like '%/swagger/%' and @MessageTemplate not like '%HTTP {RequestMethod}%'";
            var columnOptions = new ColumnOptions();

            // Delete standard column
            columnOptions.Store.Remove(StandardColumn.MessageTemplate);
            columnOptions.Store.Remove(StandardColumn.Exception);

            // Exclude data that has customized columns
            columnOptions.Properties.ExcludeAdditionalProperties = true;

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(config)
                .Enrich.FromLogContext()
                .Filter.ByIncludingOnly(expr)
                .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
                .WriteTo.MSSqlServer(
                    connectionString: connectionString,
                    columnOptions: columnOptions,
                    sinkOptions: new MSSqlServerSinkOptions
                    {
                        TableName = "Logs",
                        AutoCreateSqlTable = true,
                        SchemaName = "ApplicationDB"
                    }).CreateLogger();

            logger.AddSerilog();
        }
    }
}

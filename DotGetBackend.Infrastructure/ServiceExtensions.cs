using DotGetBackend.Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotGetBackend.Infrastructure;

public static class ServiceExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSqlServer<ApplicationContext>(configuration.GetConnectionString("Database"));
    }
}
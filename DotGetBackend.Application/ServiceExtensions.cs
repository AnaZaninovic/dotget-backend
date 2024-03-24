using DotGetBackend.Infrastructure.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DotGetBackend.Application;

public static class ServiceExtensions
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(ServiceExtensions).Assembly);
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ServiceExtensions).Assembly));
    }
}
using Microsoft.Extensions.DependencyInjection;
using MyWebBank.Application.Interfaces;
using MyWebBank.Infrastructure.Identity;

namespace MyWebBank.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            services.AddTransient<IIdentityService, IdentityService>();

            return services;
        }
    }
}

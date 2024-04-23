using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Stonks.Stocks.Application
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetAssembly(typeof(ServiceCollectionExtensions));

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(assembly!));

            return services;
        }
    }
}

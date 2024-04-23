using Microsoft.Extensions.DependencyInjection;
using Stonks.Stocks.Application.Common.Interfaces;
using Stonks.Stocks.Infrastructure.Data;
using Stonks.Stocks.Infrastructure.Data.Queriers;
using Stonks.Stocks.Infrastructure.Data.Repositories;
using Stonks.Stocks.Infrastructure.Services;

namespace Stonks.Stocks.Infrastructure
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services
                .AddSingleton<StocksFakeEventStore>()
                .AddSingleton<ReadModelDatabase>()
                .AddScoped<IEventStoreRepository, EventStoreRepository>()
                .AddScoped<IDomainEventService, DomainEventService>()
                .AddScoped<IStocksRepository, StocksRepository>()
                .AddScoped<IStocksQuerier, StocksQuerier>()
                .AddScoped<IReadModelRepository, ReadModelRepository>();

            return services;
        }
    }
}

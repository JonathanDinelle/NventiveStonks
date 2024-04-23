using Stonks.Stocks.Application.Common.Interfaces;
using Stonks.Stocks.Domain.Entities;
using Stonks.Stocks.Domain.Events.Prices;
using Stonks.Stocks.Domain.Events.Stocks;

namespace Stonks.Stocks.Infrastructure.Data.Repositories
{
    internal class StocksRepository(
        ReadModelDatabase database,
        IDomainEventService domainEventService,
        IEventStoreRepository eventStoreRepository) : IStocksRepository
    {
        private readonly ReadModelDatabase _database = database;
        private readonly IDomainEventService _domainEventService = domainEventService;
        private readonly IEventStoreRepository _eventStoreRepository = eventStoreRepository;

        public async Task AddStock(Stock stock)
        {
            if (_eventStoreRepository.AggregateExists(stock.Id))
            {
                throw new Exception("Already exists");
            }

            _eventStoreRepository.SaveEvent(stock.Id, [stock]);

            var stockCreatedEvent = new StockCreatedEvent(stock.Id, stock.Ticker, stock.SecurityName);
            await _domainEventService.Publish(stockCreatedEvent);
        }

        public async Task UpdateStockPrice(Price price)
        {
            _eventStoreRepository.SaveEvent(price.StockId, [price]);

            var priceUpdatedEvent = new PriceUpdatedEvent(price.StockId, price.State, price.Value);
            await _domainEventService.Publish(priceUpdatedEvent);
        }

    }
}

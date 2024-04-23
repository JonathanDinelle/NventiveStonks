using MediatR;
using Stonks.Stocks.Application.Common;
using Stonks.Stocks.Application.Common.Interfaces;
using Stonks.Stocks.Domain.Events.Stocks;
using Stonks.Stocks.Domain.ReadEntities;

namespace Stonks.Stocks.Application.EventHandlers
{
    internal class StockCreatedEventHandler : INotificationHandler<DomainEventNotification<StockCreatedEvent>>
    {
        private readonly IReadModelRepository _readModelRepository;

        public StockCreatedEventHandler(IReadModelRepository readModelRepository)
        {
            _readModelRepository = readModelRepository;
        }

        public Task Handle(DomainEventNotification<StockCreatedEvent> notification, CancellationToken cancellationToken)
        {
            var stockEvent = notification.DomainEvent;
            var stock = new StockReadEntity
            {
                Id = stockEvent.Id,
                Ticker = stockEvent.Ticker,
                SecurityName = stockEvent.SecurityName
            };

            _readModelRepository.CreateStock(stock);

            return Task.CompletedTask;
        }
    }
}

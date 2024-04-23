using MediatR;
using Stonks.Stocks.Application.Common;
using Stonks.Stocks.Application.Common.Interfaces;
using Stonks.Stocks.Domain.Entities;
using Stonks.Stocks.Domain.Events.Prices;
using Stonks.Stocks.Domain.ReadEntities;

namespace Stonks.Stocks.Application.EventHandlers
{
    internal class StockPriceUpdatedEventHandler : INotificationHandler<DomainEventNotification<PriceUpdatedEvent>>
    {
        private readonly IReadModelRepository _readModelRepository;
        private readonly IEventStoreRepository _eventStoreRepository;

        public StockPriceUpdatedEventHandler(
            IReadModelRepository readModelRepository,
            IEventStoreRepository eventStoreRepository)
        {
            _readModelRepository = readModelRepository;
            _eventStoreRepository = eventStoreRepository;
        }

        public Task Handle(DomainEventNotification<PriceUpdatedEvent> notification, CancellationToken cancellationToken)
        {
            var random = new Random();

            // This is not the proper way to cast and build from an event history but for the sake of the test
            // this will do :)
            var aggregateEvents = _eventStoreRepository.GetEventsForAggregate(notification.DomainEvent.Id)
                .Where(x => x.Type == nameof(Price))
                .OfType<Price>();

            var priceUpdatesByMonth = aggregateEvents.GroupBy(e => e.DateOccurred.Month.ToString());

            // Do the projection with proper calculation, this is mostly mock and random values for the sake of it
            var stockDetail = new StockDetailReadEntity
            {
                Id = notification.DomainEvent.Id,
                StockId = notification.DomainEvent.Id,
                BetaScore = (decimal)CalculateBetaScore(),
                DailyAverageVolume = random.Next(100, 500000),
                MonthlyAveragePrice = priceUpdatesByMonth.Select(month => month.Average(updates => updates.Value)).Average(), // this gives out yearly
                MonthlyHighPrice = priceUpdatesByMonth.FirstOrDefault(month => month.Key == DateTime.UtcNow.Month.ToString())?.Max(x => x.Value) ?? 0,
                MonthlyLowPrice = priceUpdatesByMonth.FirstOrDefault(month => month.Key == DateTime.UtcNow.Month.ToString())?.Min(x => x.Value) ?? 0,
                Open = aggregateEvents.OrderByDescending(x => x.DateOccurred).First(x => x.State == Domain.StockState.Open).Value,
                PreviousClose = aggregateEvents.OrderByDescending(x => x.DateOccurred).FirstOrDefault(x => x.State == Domain.StockState.Close)?.Value ?? 0,
                YearlyAveragePrice = priceUpdatesByMonth.Select(month => month.Average(updates => updates.Value)).Average()
            };

            _readModelRepository.UpsertPrice(notification.DomainEvent.Id, stockDetail);

            return Task.CompletedTask;
        }

        private double CalculateBetaScore()
        {
            var random = new Random();
            return 0.1 + (random.NextDouble() * (1 - 0.1));
        }
    }
}

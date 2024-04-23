using Stonks.Stocks.Application.Common.Interfaces;
using Stonks.Stocks.Domain.Events;

namespace Stonks.Stocks.Infrastructure.Data.Repositories
{
    internal class EventStoreRepository(StocksFakeEventStore eventStore) : IEventStoreRepository
    {
        private readonly StocksFakeEventStore _eventStore = eventStore;

        public void SaveEvent(Guid aggregateId, List<BaseAggregate> eventsToPublish, DateTime? eventDate = null /* Used for mock insertion */)
        {
            if (!_eventStore.Events.TryGetValue(aggregateId, out List<BaseAggregate>? events))
            {
                events = [];
                _eventStore.Events.Add(aggregateId, events);
            }

            eventsToPublish.ForEach(e => e.DateOccurred = eventDate ?? DateTime.UtcNow);

            events.AddRange(eventsToPublish);
        }

        public bool AggregateExists(Guid aggregateId)
        {
            return _eventStore.Events.Any(x => x.Key == aggregateId);
        }

        public List<BaseAggregate> GetEventsForAggregate(Guid aggregateId)
        {
            if (!_eventStore.Events.TryGetValue(aggregateId, out List<BaseAggregate>? eventDescriptors))
            {
                throw new Exception("Aggregate not found.");
            }

            return eventDescriptors?.ToList() ?? [];
        }
    }
}

using Stonks.Stocks.Domain.Events;

namespace Stonks.Stocks.Application.Common.Interfaces
{
    public interface IEventStoreRepository
    {
        void SaveEvent(Guid aggregateId, List<BaseAggregate> eventsToPublish, DateTime? eventDate = null /* Used for mock insertion */);

        bool AggregateExists(Guid aggregateId);

        List<BaseAggregate> GetEventsForAggregate(Guid aggregateId);
    }
}

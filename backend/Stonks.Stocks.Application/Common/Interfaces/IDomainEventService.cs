using Stonks.Stocks.Domain.Events;

namespace Stonks.Stocks.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(BaseAggregate domainEvent);
    }
}

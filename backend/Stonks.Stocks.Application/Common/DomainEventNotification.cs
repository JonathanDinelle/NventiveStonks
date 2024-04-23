using MediatR;
using Stonks.Stocks.Domain.Events;

namespace Stonks.Stocks.Application.Common
{
    public class DomainEventNotification<TDomainEvent>(TDomainEvent domainEvent) : INotification where TDomainEvent : BaseAggregate
    {
        public TDomainEvent DomainEvent { get; } = domainEvent;
    }
}

using MediatR;
using Stonks.Stocks.Application.Common;
using Stonks.Stocks.Application.Common.Interfaces;
using Stonks.Stocks.Domain.Events;

namespace Stonks.Stocks.Infrastructure.Services
{
    internal class DomainEventService : IDomainEventService
    {
        private readonly IMediator _mediator;

        public DomainEventService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Publish(BaseAggregate domainEvent)
        {
            await _mediator.Publish(GetNotificationCorrespondingToDomainEvent(domainEvent));
        }

        private INotification GetNotificationCorrespondingToDomainEvent(BaseAggregate domainEvent)
        {
            return (INotification)Activator.CreateInstance(typeof(DomainEventNotification<>).MakeGenericType(domainEvent.GetType()), domainEvent);
        }
    }
}

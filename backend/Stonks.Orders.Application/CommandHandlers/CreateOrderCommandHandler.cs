using MediatR;
using Stonks.Orders.Domain;

namespace Stonks.Orders.Application.CommandHandlers
{
    public record CreateOrderCommand : IRequest
    {
        public Guid StockId { get; set; }
        public Guid BrokerId { get; set; }
        public OrderSide Side { get; set; }
        public int Quantity { get; set; }
        public decimal LimitPrice { get; set; }
    }

    internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand>
    {
        public Task Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

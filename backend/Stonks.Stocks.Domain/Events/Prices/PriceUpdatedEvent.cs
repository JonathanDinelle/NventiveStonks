using Stonks.Stocks.Domain.Entities;

namespace Stonks.Stocks.Domain.Events.Prices
{
    public class PriceUpdatedEvent(Guid stockId, StockState state, decimal value) : BaseAggregate
    {
        public override Guid Id => stockId;

        public StockState State { get; } = state;
        public decimal Value { get; } = value;

        public override string Type => nameof(Price);
    }
}

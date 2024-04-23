using Stonks.Stocks.Domain.Events;

namespace Stonks.Stocks.Domain.Entities
{
    public class Price : BaseAggregate
    {
        public override Guid Id => StockId;

        public required Guid StockId { get; set; }
        public DateTime Date { get; set; }
        public decimal Value { get; set; }
        public StockState State { get; set; }

        public override string Type => nameof(Price);
    }
}

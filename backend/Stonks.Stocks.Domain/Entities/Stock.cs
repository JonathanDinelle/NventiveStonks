using Stonks.Stocks.Domain.Events;

namespace Stonks.Stocks.Domain.Entities
{
    public class Stock(Guid id) : BaseAggregate
    {
        private readonly Guid _id = id;

        public override Guid Id => _id;
        public required string Ticker { get; set; }
        public required string SecurityName { get; set; } = string.Empty;

        public override string Type => nameof(Stock);
    }
}

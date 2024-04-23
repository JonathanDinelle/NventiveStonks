using Stonks.Stocks.Domain.Entities;

namespace Stonks.Stocks.Domain.Events.Stocks
{
    public class StockCreatedEvent(Guid id, string ticker, string securityName) : BaseAggregate
    {
        private readonly Guid _id = id;

        public override Guid Id => _id;

        public string Ticker { get; set; } = ticker;
        public string SecurityName { get; set; } = securityName;

        public override string Type => nameof(Stock);
    }
}

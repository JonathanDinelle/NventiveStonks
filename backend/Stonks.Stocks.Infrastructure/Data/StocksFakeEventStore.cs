using Stonks.Stocks.Domain.Events;

namespace Stonks.Stocks.Infrastructure.Data
{
    public class StocksFakeEventStore
    {
        public Dictionary<Guid, List<BaseAggregate>> Events { get; set; } = [];
    }
}

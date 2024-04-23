using Stonks.Stocks.Domain.ReadEntities;

namespace Stonks.Stocks.Infrastructure.Data
{
    public class ReadModelDatabase
    {
        public Dictionary<Guid, StockReadEntity> Stocks { get; set; } = [];
        public Dictionary<Guid, StockDetailReadEntity> StockDetails { get; set; } = [];
    }
}

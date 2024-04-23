using Stonks.Stocks.Application.Common.Interfaces;
using Stonks.Stocks.Application.Queries;
using Stonks.Stocks.Domain.ReadEntities;

namespace Stonks.Stocks.Infrastructure.Data.Queriers
{
    public class StocksQuerier(ReadModelDatabase database) : IStocksQuerier
    {
        private readonly ReadModelDatabase _db = database;

        public IEnumerable<StockReadEntity> ListStocks()
        {
            return [.. _db.Stocks.Values];
        }

        public GetStockDetailsQueryResult? GetStockDetails(Guid id)
        {
            var stockEntity = _db.Stocks.FirstOrDefault(s => s.Key == id).Value;
            if (stockEntity == null)
            {
                return null;
            }

            var stockDetails = _db.StockDetails.FirstOrDefault(d => d.Key == stockEntity.Id).Value;
            GetStockDetailsQueryResult result = new()
            {
                Id = id,
                SecurityName = stockEntity.SecurityName,
                Ticker = stockEntity.Ticker,
                Details = stockDetails,
            };

            return result;
        }
    }
}

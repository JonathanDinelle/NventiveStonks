using Stonks.Stocks.Application.Queries;
using Stonks.Stocks.Domain.ReadEntities;

namespace Stonks.Stocks.Application.Common.Interfaces
{
    public interface IStocksQuerier
    {
        IEnumerable<StockReadEntity> ListStocks();
        GetStockDetailsQueryResult? GetStockDetails(Guid id);
    }
}

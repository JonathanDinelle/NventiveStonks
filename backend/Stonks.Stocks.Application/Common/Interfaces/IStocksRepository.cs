using Stonks.Stocks.Domain.Entities;

namespace Stonks.Stocks.Application.Common.Interfaces
{
    public interface IStocksRepository
    {
        Task AddStock(Stock stock);
        Task UpdateStockPrice(Price price);
    }
}

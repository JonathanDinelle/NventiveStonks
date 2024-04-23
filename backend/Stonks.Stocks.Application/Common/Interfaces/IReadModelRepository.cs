using Stonks.Stocks.Domain.ReadEntities;

namespace Stonks.Stocks.Application.Common.Interfaces
{
    public interface IReadModelRepository
    {
        void CreateStock(StockReadEntity entity);
        void UpsertPrice(Guid stockId, StockDetailReadEntity details);
    }
}

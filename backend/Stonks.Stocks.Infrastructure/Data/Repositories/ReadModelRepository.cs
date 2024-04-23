using Stonks.Stocks.Application.Common.Interfaces;
using Stonks.Stocks.Domain.ReadEntities;

namespace Stonks.Stocks.Infrastructure.Data.Repositories
{
    internal class ReadModelRepository : IReadModelRepository
    {
        private readonly ReadModelDatabase _readModelDatabase;

        public ReadModelRepository(ReadModelDatabase readModelDatabase)
        {
            _readModelDatabase = readModelDatabase;
        }

        public void CreateStock(StockReadEntity entity)
        {
            if (_readModelDatabase.Stocks.Any(x => x.Key == entity.Id))
            {
                return;
            }

            _readModelDatabase.Stocks.Add(entity.Id, entity);
        }

        public void UpsertPrice(Guid stockId, StockDetailReadEntity details)
        {
            _readModelDatabase.StockDetails[stockId] = details;
        }
    }
}

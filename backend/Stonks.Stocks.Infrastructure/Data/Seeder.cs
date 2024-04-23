using Stonks.Stocks.Application.Common.Interfaces;
using Stonks.Stocks.Domain;
using Stonks.Stocks.Domain.Entities;

namespace Stonks.Stocks.Infrastructure.Data
{
    public class Seeder
    {
        private readonly IStocksRepository _stocksRepository;
        public List<Stock> Stocks = [
            new Stock(Guid.Parse("4aa12cb7-1526-4cc3-8a81-6d919c01d4be")){
                Ticker = "MSFT",
                SecurityName = "Microsoft Inc"
            },
            new Stock(Guid.Parse("bd9a6ef2-952a-4384-b06a-71044b578b9d")){
                Ticker = "IBM",
                SecurityName = "International Business Machines"
            },
            new Stock(Guid.Parse("add34879-c25a-472e-8623-243d49fc72ed")){
                Ticker = "ABCD",
                SecurityName = "Alphabet"
            },
            new Stock(Guid.Parse("d74160b0-4d69-4ae7-a60c-e570e519cf3b")){
                Ticker = "APPL",
                SecurityName = "Apple Inc"
            },
            new Stock(Guid.Parse("33e3618a-1f82-46ec-b357-832c38e6e4bb")){
                Ticker = "TSLA",
                SecurityName = "Tesla"
            },
        ];


        public Seeder(IStocksRepository stocksRepository)
        {
            _stocksRepository = stocksRepository;
        }

        public async Task Seed()
        {
            Stocks.ForEach(stock => { _stocksRepository.AddStock(stock); });

            int priceUpdatesMaxCount = 10;
            Random randomGenerator = new Random();

            foreach (var stock in Stocks)
            {
                double lastPrice = randomGenerator.Next(3, 150);
                int priceDeltaMax = 50;
                double priceDeltaMin = 0.3;

                for (int i = 0; i < priceUpdatesMaxCount; i++)
                {
                    var randomVariation = randomGenerator.NextDouble();
                    var priceVariation = priceDeltaMin + (randomVariation * (priceDeltaMax - priceDeltaMin));
                    var isAdd = randomGenerator.Next(0, 2) == 1;

                    lastPrice = isAdd ? lastPrice + priceVariation : Math.Max(0.1, lastPrice - priceVariation);

                    Price priceUpdate = new()
                    {
                        StockId = stock.Id,
                        Value = (decimal)lastPrice,
                        Date = DateTime.Now.AddDays(i),
                        State = getState(i)
                    };

                    await _stocksRepository.UpdateStockPrice(priceUpdate);
                }
            }

            static StockState getState(int updateCount)
            {
                return updateCount switch
                {
                    0 => StockState.Open,
                    10 => StockState.Close,
                    _ => StockState.Update,
                };
            }

        }
    }
}

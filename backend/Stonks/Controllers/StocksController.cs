using Microsoft.AspNetCore.Mvc;
using Stonks.Stocks.Domain.ReadEntities;

namespace Stonks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        public StocksController() { }

        [HttpGet]
        public StockReadEntity ListStocks()
        {
            return new StockReadEntity
            {
                Id = Guid.NewGuid(),
                Ticker = "ABCD",
                SecurityName = "Gooloo"
            };
        }

        [HttpGet("{id}")]
        public StockReadEntity ListStocks(Guid id)
        {
            return new StockReadEntity
            {
                Id = id,
                Ticker = "ABCD",
                SecurityName = "Gooloo",
                StockDetails = new StockDetailReadEntity
                {
                    Id = Guid.NewGuid(),
                    StockId = id,
                    BetaScore = 1.3m
                }
            };
        }
    }
}

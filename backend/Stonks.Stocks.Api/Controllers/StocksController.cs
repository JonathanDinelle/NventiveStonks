using MediatR;
using Microsoft.AspNetCore.Mvc;
using Stonks.Stocks.Application.Queries;
using Stonks.Stocks.Domain.ReadEntities;

namespace Stonks.Stocks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StocksController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StocksController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<GetStocksListQueryResult> ListStocks()
        {
            var result = await _mediator.Send(new GetStocksListQuery());

            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StockReadEntity>> ListStocks(Guid id)
        {
            var result = await _mediator.Send(new GetStockDetailsQuery { Id = id });
            if (result == null)
            {
                return NotFound();

            }

            return Ok(result);
        }
    }
}

using MediatR;
using Stonks.Stocks.Application.Common.Interfaces;

namespace Stonks.Stocks.Application.Queries
{
    public class GetStocksListQuery : IRequest<GetStocksListQueryResult> { }

    public record GetStocksListQueryResult
    {
        public IEnumerable<StockDto> Stocks { get; set; } = [];

        public class StockDto
        {
            public Guid Id { get; set; }
            public string Ticker { get; set; } = string.Empty;
            public string SecurityName { get; set; } = string.Empty;
        }
    }

    internal class GetStocksListQueryHandler : IRequestHandler<GetStocksListQuery, GetStocksListQueryResult>
    {
        private readonly IStocksQuerier _stocksQuerier;

        public GetStocksListQueryHandler(IStocksQuerier stocksQuerier)
        {
            _stocksQuerier = stocksQuerier;
        }

        public Task<GetStocksListQueryResult> Handle(GetStocksListQuery request, CancellationToken cancellationToken)
        {
            GetStocksListQueryResult result = new()
            {
                Stocks = _stocksQuerier.ListStocks().Select(s => new GetStocksListQueryResult.StockDto
                {
                    Id = s.Id,
                    SecurityName = s.SecurityName,
                    Ticker = s.Ticker,
                })
            };

            return Task.FromResult(result);
        }
    }
}

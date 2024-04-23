using MediatR;
using Stonks.Stocks.Application.Common.Interfaces;
using Stonks.Stocks.Domain.ReadEntities;

namespace Stonks.Stocks.Application.Queries
{
    public record GetStockDetailsQuery : IRequest<GetStockDetailsQueryResult?>
    {
        public Guid Id { get; set; }
    }

    public record GetStockDetailsQueryResult
    {
        public Guid Id { get; set; }
        public string Ticker { get; set; } = string.Empty;
        public string SecurityName { get; set; } = string.Empty;

        public StockDetailReadEntity? Details { get; set; }

    }

    internal class GetStockDetailsQueryHandler : IRequestHandler<GetStockDetailsQuery, GetStockDetailsQueryResult?>
    {
        private readonly IStocksQuerier _stocksQuerier;

        public GetStockDetailsQueryHandler(IStocksQuerier stocksQuerier)
        {
            _stocksQuerier = stocksQuerier;
        }

        public Task<GetStockDetailsQueryResult?> Handle(GetStockDetailsQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(_stocksQuerier.GetStockDetails(request.Id));
        }
    }
}

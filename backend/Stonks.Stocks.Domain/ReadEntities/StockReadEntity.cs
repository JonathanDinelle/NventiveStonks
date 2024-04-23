namespace Stonks.Stocks.Domain.ReadEntities
{
    public class StockReadEntity
    {
        public required Guid Id { get; set; }
        public required string Ticker { get; set; }
        public string SecurityName { get; set; } = string.Empty;
    }
}

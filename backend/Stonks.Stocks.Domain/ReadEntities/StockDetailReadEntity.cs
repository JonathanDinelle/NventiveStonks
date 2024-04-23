namespace Stonks.Stocks.Domain.ReadEntities
{
    public class StockDetailReadEntity
    {
        public required Guid Id { get; set; }
        public required Guid StockId { get; set; }

        public decimal BetaScore { get; set; }
        public decimal PreviousClose { get; set; }
        public decimal Open { get; set; }

        public int DailyAverageVolume { get; set; }
        public decimal MonthlyAveragePrice { get; set; }
        public decimal YearlyAveragePrice { get; set; }
        public decimal MonthlyHighPrice { get; set; }
        public decimal MonthlyLowPrice { get; set; }
    }
}

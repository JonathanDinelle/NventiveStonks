namespace Stonks.Stocks.Domain.Events
{
    public abstract class BaseAggregate
    {
        public abstract Guid Id { get; }

        public DateTime DateOccurred;

        public abstract string Type { get; }
    }
}

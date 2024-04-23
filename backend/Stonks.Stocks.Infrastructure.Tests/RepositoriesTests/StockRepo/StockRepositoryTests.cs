using FluentAssertions;
using Moq;
using Moq.AutoMock;
using Stonks.Stocks.Application.Common.Interfaces;
using Stonks.Stocks.Domain.Entities;
using Stonks.Stocks.Infrastructure.Data;
using Stonks.Stocks.Infrastructure.Data.Repositories;

namespace Stonks.Stocks.Infrastructure.Tests.RepositoriesTests.StockRepo
{
    public class StockRepositoryTests
    {
        private readonly StocksRepository _sut;
        public ReadModelDatabase DatabaseMock { get; set; } = new ReadModelDatabase();
        public Mock<IDomainEventService> DomainEventServiceMock { get; set; } = new Mock<IDomainEventService>();
        public Mock<IEventStoreRepository> EventStoreRepositoryMock { get; set; } = new Mock<IEventStoreRepository>();

        public StockRepositoryTests()
        {
            var autoMocker = new AutoMocker();
            autoMocker.Use(DomainEventServiceMock);
            autoMocker.Use(EventStoreRepositoryMock);
            autoMocker.Use(DatabaseMock);

            _sut = autoMocker.CreateInstance<StocksRepository>();
        }

        [Fact]
        public async Task GivenExistingStock_WhenCreateStockIsInvoked_ShouldThrowException()
        {
            // Arrange
            var stockId = Guid.NewGuid();
            EventStoreRepositoryMock.Setup(x => x.AggregateExists(It.Is<Guid>(id => id == stockId)))
                .Returns(true);

            Stock stock = new(stockId)
            {
                SecurityName = "test",
                Ticker = "TT"
            };

            // Act + Assert
            Func<Task> act = async () => { await _sut.AddStock(stock); };
            await act.Should().ThrowAsync<Exception>();

        }
    }
}

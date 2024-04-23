
using Stonks.Stocks.Application;
using Stonks.Stocks.Application.Common.Interfaces;
using Stonks.Stocks.Infrastructure;
using Stonks.Stocks.Infrastructure.Data;

namespace Stonks.Stocks.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(
                options => options.WithOrigins("*") // .WithOrigins("http://example.com")
                .AllowAnyMethod());

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            using (var scope = app.Services.CreateScope())
            {
                var stocksRepository = scope.ServiceProvider.GetRequiredService<IStocksRepository>();
                var seeder = new Seeder(stocksRepository);
                seeder.Seed().GetAwaiter().GetResult();
            }

            app.Run();
        }
    }
}

using NameOut;
using Microsoft.EntityFrameworkCore;
using TradeInterfaceApi.Data;
using PortfolioApi.Repository;
using PortfolioRepositoryInterface;
using TradeRepositoryInterface;
using TradeApi.Repository;


var builder = WebApplication.CreateBuilder(args);

var serverVersion = new MariaDbServerVersion(new Version(11, 4));

builder.Services.AddDbContext<TradeDbContext>(options =>
	options.UseMySql(
		builder.Configuration.GetConnectionString("DefaultConnection"),
		serverVersion));

builder.Services.AddControllers();

// Registering the repository
builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddScoped<ITradeRepository, TradeRepository>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/test", () => 
{
	var kelvin = new NameGenerator();
	return kelvin.PrintName("Kelvin");
}
);

app.MapControllers();
app.Run();

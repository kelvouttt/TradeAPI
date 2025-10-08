using NameOut;
using Microsoft.EntityFrameworkCore;
using Data.AppDbContext;
using Repositories.PortfolioAPIInterface;
using Repositories.TradeAPIInterface;
using Repositories.PortfolioAPI;
using Repositories.TradeAPI;
using Repositories.InstrumentAPIInterface;
using Repositories.InterfaceAPI;


var builder = WebApplication.CreateBuilder(args);

var serverVersion = new MariaDbServerVersion(new Version(11, 4));

builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseMySql(
		builder.Configuration.GetConnectionString("DefaultConnection"),
		serverVersion));

builder.Services.AddControllers();

// Registering the repository
builder.Services.AddScoped<IPortfolioRepository, PortfolioRepository>();
builder.Services.AddScoped<ITradeRepository, TradeRepository>();
builder.Services.AddScoped<IInstrumentRepository, InstrumentRepository>();

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

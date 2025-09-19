using Microsoft.EntityFrameworkCore;
using PortfolioApi.Models;
using TradeApi.Models;

namespace TradeInterfaceApi.Data
{
    public class TradeDbContext : DbContext
    {
        public TradeDbContext(DbContextOptions<TradeDbContext> options) : base(options) { }

        public DbSet<Trade> Trades { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
    }
}
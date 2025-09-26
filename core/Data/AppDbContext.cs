using Microsoft.EntityFrameworkCore;
using Models.Domain.PortfolioAPI;
using Models.Domain.TradeAPI;


namespace Data.AppDbContext
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Trade> Trades { get; set; }
        public DbSet<Portfolio> Portfolios { get; set; }
    }
}
using FinanceProject_WebApp_1_1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FinanceProject_WebApp_1_1.DbContexts
{
    public class FinanceDBContext : DbContext
    {
        public DbSet<Tickers> Tickers { get; set; }

        private readonly IConfiguration _configuration;

        public FinanceDBContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connString = _configuration.GetConnectionString("FinanceAppConnString");
                optionsBuilder.UseSqlServer(connString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tickers>().HasData(new Tickers
            {
                Ticker = "AAPL",
                Active = true,
                Name = "Apple Comapny",
                Currency_Name = "USD"
            });

        }


    }
}

using PortfolioTracker.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PortfolioTracker.Data.Dtos.Auth;

namespace PortfolioTracker.Data
{
    public class PortfolioTrackerContext : IdentityDbContext<PortfolioUser>
    {
        public DbSet<Asset> Asset { get; set; }
        public DbSet<Portfolio> Portfolio { get; set; }
        public DbSet<Trade> Trade { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // !!! DON'T STORE THE REAL CONNECTION STRING THE IN PUBLIC REPO !!!
            // Use secret managers provided by your chosen cloud provider
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=aspnet-53bc9b9d-9d6a-45d4-8429-2a2761773502;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
    }
}

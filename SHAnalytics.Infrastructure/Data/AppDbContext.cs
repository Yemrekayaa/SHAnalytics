using Microsoft.EntityFrameworkCore;
using SHAnalytics.Core.Entities;

namespace SHAnalytics.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Player> Players { get; set; }


    }
}

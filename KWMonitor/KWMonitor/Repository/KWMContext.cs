using KoronaWirusMonitor3.Models;
using Microsoft.EntityFrameworkCore;

namespace KoronaWirusMonitor3.Repository
{
    public class KWMContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<City> Cities { get; set; }

        public KWMContext(DbContextOptions<KWMContext> options) : base(options)
        {
        }

        public KWMContext()
        {
            
        }
    }
}

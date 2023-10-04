using Microsoft.EntityFrameworkCore;
using System.Runtime.Serialization;

namespace SuperHeroAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Server=OSKRACERPC; Database=superHerodb; Trusted_Connection=True; TrustServerCertificate=True;");
        }

        public DbSet<SuperHero> SuperHeroes { get; set; }

    }
}

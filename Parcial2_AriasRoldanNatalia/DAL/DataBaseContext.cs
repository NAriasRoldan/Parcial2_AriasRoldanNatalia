
using Microsoft.EntityFrameworkCore;
using Parcial2_AriasRoldanNatalia.DAL.Entities;

namespace Parcial2_AriasRoldanNatalia.DAL
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }

        public DbSet<Entrance> Entrances { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Entrance>().HasIndex(entrance => entrance.Name).IsUnique();

        }
    }
}


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
    }
}

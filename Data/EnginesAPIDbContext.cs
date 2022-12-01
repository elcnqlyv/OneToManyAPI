using Microsoft.EntityFrameworkCore;
using OneToManyAPI.Models;

namespace OneToManyAPI.Data
{
    public class EnginesAPIDbContext : DbContext
    {
        public EnginesAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Engine> Engines { get; set; }
    }
}

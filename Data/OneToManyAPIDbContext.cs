using Microsoft.EntityFrameworkCore;
using OneToManyAPI.Models;

namespace OneToManyAPI.Data
{
    public class OneToManyAPIDbContext : DbContext
    {
        public OneToManyAPIDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Engine> Engines { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }   
    }
}

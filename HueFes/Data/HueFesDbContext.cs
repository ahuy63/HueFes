using HueFes.Models;
using Microsoft.EntityFrameworkCore;

namespace HueFes.Data
{
    public class HueFesDbContext : DbContext
    {
        public HueFesDbContext(DbContextOptions<HueFesDbContext> options) : base(options)
        {
        }

        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationCategory> LocationCategories { get; set; }

    }
}

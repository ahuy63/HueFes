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
        public DbSet<Event> Events { get; set; }
        public DbSet<Show> Shows { get; set; }
        public DbSet<ShowCategory> ShowCategories { get; set; }
        public DbSet<EventImage> EventImages { get; set; }
        public DbSet<HelpMenu> HelpMenus { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<Favourite> Favorites { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Checkin> Checkins { get; set; }
    }
}

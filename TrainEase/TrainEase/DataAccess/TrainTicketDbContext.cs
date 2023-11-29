using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using TrainEase.Models;

namespace TrainEase.DataAccess
{

    public class TrainTicketDbContext : DbContext
    {
        public DbSet<Train> Trains { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Booking> Bookings { get; set; }

        // Add other DbSet properties for additional entities

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("@\"Data Source=(local);Initial Catalog=TrainEase;Integrated Security=True\"");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure your model here (e.g., relationships, constraints)
            // modelBuilder.Entity<YourEntity>().HasOne(...);
        }
    }

}

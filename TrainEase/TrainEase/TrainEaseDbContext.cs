//using Microsoft.EntityFrameworkCore;
using System;
using TrainEase.Models;

using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace TrainEase.Data
{
    public class TrainEaseDbContext : DbContext
    {
        public TrainEaseDbContext() : base("name=TrainEaseDBEntities")
        {
        }

        public DbSet<Train> Trains { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Audit> Audits { get; set; }
       /* public DbSet<AuditTrain> AuditTrains { get; set; }
        public DbSet<AuditTicket> AuditTickets { get; set; }
        public DbSet<AuditUser> AuditUsers { get; set; }
        public DbSet<AuditAnnouncement> AuditAnnouncements { get; set; }
        public DbSet<AuditBooking> AuditBookings { get; set; }*/

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            // Configure table names
            modelBuilder.Entity<Train>().ToTable("Train");
            modelBuilder.Entity<Ticket>().ToTable("Ticket");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Announcement>().ToTable("Announcement");
            modelBuilder.Entity<Booking>().ToTable("Booking");
            modelBuilder.Entity<Audit>().ToTable("Audit");
            /* modelBuilder.Entity<AuditTrain>().ToTable("AuditTrain");
             modelBuilder.Entity<AuditTicket>().ToTable("AuditTicket");
             modelBuilder.Entity<AuditUser>().ToTable("AuditUser");
             modelBuilder.Entity<AuditAnnouncement>().ToTable("AuditAnnouncement");
             modelBuilder.Entity<AuditBooking>().ToTable("AuditBooking");*/

            // Configure UserRole property
           
        }
    }
}

using Logit_Transport.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logit_Transport.Data
{
    public class LogitDbContext : DbContext
    {
        public LogitDbContext()
        {
        }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Driver> Drivers { get; set; }

        public DbSet<Offer> Offers { get; set; }

        public DbSet<Participant> Participants { get; set; }

        public DbSet<Shipment> Shipments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }
}

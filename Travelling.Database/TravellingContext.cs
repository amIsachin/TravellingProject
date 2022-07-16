using System;
using System.Data.Entity;
using Travelling.Business;

namespace Travelling.Database
{
    public class TravellingContext : DbContext, IDisposable
    {
        public TravellingContext() : base("TravellingConnection")
        { 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().Property(x => x.Name).IsRequired().HasMaxLength(100);
            modelBuilder.Entity<Country>().Property(x => x.Description).IsRequired().HasMaxLength(500);
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Place> Places { get; set; }
        public DbSet<PlaceOrder> PlaceOrders { get; set; }
    }
}

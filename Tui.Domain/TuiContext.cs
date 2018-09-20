using Microsoft.EntityFrameworkCore;
using Tui.Domain.Configuration;

namespace Tui.Domain
{
    public class TuiContext : DbContext
    {
        public TuiContext(DbContextOptions<TuiContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Aircraft> Aircrafts { get; set; }
        public DbSet<Airport> Airports { get; set; }
        public DbSet<Flight> Flights { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            AircraftConfiguration.Configuration(modelBuilder);
            AirportConfiguration.Configuration(modelBuilder);
            FlightConfiguration.Configuration(modelBuilder);
        }
    }
}

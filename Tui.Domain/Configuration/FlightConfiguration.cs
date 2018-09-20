using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tui.Domain.Configuration
{
    public static class FlightConfiguration
    {
        public static void Configuration(ModelBuilder builder)
        {
            builder.Entity<Flight>()
                    .ToTable("Flight");

            builder.Entity<Flight>()
                    .HasKey(e => e.Id);

            builder.Entity<Flight>()
                   .Property(e => e.DepartureAirportId)
                  .IsRequired(false);

            builder.Entity<Flight>()
                  .Property(e => e.DestinationAirportId)
                 .IsRequired(false);

            builder.Entity<Flight>()
                  .Property(e => e.AircraftId)
                 .IsRequired(false);

            builder.Entity<Flight>()
                .HasOne(f => f.DestinationAirport)
                .WithMany()
                .HasForeignKey(fk => fk.DestinationAirportId)                
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Flight>()
                .HasOne(f => f.DepartureAirport)
                .WithMany()
                .HasForeignKey(fk => fk.DepartureAirportId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Flight>()
                .HasOne(f => f.Aircraft)
                .WithMany()
                .HasForeignKey(fk => fk.AircraftId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

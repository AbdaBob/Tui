using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tui.Domain.Configuration
{
    public static class AirportConfiguration
    {
        public static void Configuration(ModelBuilder builder)
        {
            builder.Entity<Airport>()
                   .ToTable("Airport");

            builder.Entity<Airport>()
                    .HasKey(e => e.Id);

            builder.Entity<Airport>()
                   .Property(e => e.Name)
                  .IsRequired();

            builder.Entity<Airport>()
                   .Property(e => e.Latitude)
                  .IsRequired();

            builder.Entity<Airport>()
                   .Property(e => e.Longitude)
                  .IsRequired();
        }
    }
}

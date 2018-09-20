using Microsoft.EntityFrameworkCore;

namespace Tui.Domain.Configuration
{
    public static class AircraftConfiguration
    {
        public static void Configuration(ModelBuilder builder)
        {
            builder.Entity<Aircraft>()
                 .ToTable("Aircraft");

            builder.Entity<Aircraft>()
                    .HasKey(e => e.Id);

            builder.Entity<Aircraft>()
                   .Property(e => e.Name)
                  .IsRequired();

            builder.Entity<Aircraft>()
                   .Property(e => e.TakeOffEffort)
                  .IsRequired();

            builder.Entity<Aircraft>()
                   .Property(e => e.FuelConsumption)
                  .IsRequired();
        }
    }
}

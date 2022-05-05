using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmoothDrivingAPI.Domain.Entities;
using System;

namespace SmoothDriving.Infra.Data.Configurations
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasData(
                    new Trip
                    {
                        Id = "4",
                        DateTimeInicio = DateTime.Now,
                        DateTimeFim = DateTime.Now + TimeSpan.FromHours(2),
                        Duration = new TimeSpan(2, 1, 0),
                        // EventsCount = new EventsCount(2, 3, 2, 2, 2, 2),
                        MaxSpeedReached = 160,
                        MaxRPMReached = 6500
                    }
                );
        }
    }
}

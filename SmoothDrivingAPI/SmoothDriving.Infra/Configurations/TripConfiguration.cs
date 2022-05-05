using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmoothDrivingAPI.Domain.Entities;
using System;
using System.Timers;

namespace SmoothDriving.Infra.Data.Configurations
{
    public class TripConfiguration : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasNoKey();
            builder.HasData(
                    new Trip
                    {
                        DateTimeInicio = DateTime.Now,
                        DateTimeFim = DateTime.Now + TimeSpan.FromHours(2),
                        Duration = new TimeSpan(2, 1, 0),
                        EventsCount = new EventsCount(
                            60, 57, 24, 12, 23, 70
                        ),
                        MaxRPMReached = 6500
                    }
                );
        }
    }
}

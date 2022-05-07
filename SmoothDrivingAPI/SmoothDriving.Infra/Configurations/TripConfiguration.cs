// using Microsoft.EntityFrameworkCore;
// using Microsoft.EntityFrameworkCore.Metadata.Builders;
// using SmoothDrivingAPI.Domain.Entities;
// using System;

// namespace SmoothDriving.Infra.Data.Configurations
// {
//     public class TripConfiguration : IEntityTypeConfiguration<Trip>
//     {
//         public void Configure(EntityTypeBuilder<Trip> builder)
//         {
//             builder.HasData(
//                     new Trip
//                     {
//                         DateTimeStart = "2020-01-01T00:00:00",
//                         DateTimeEnd = "2020-01-01T00:00:00",
//                         Duration = "7200000",
//                         // EventsCount = new EventsCount(2, 3, 2, 2, 2, 2),
//                         MaxSpeedReached = 160,
//                         MaxRPMReached = 6500
//                     }
//                 );
//         }
//     }
// }

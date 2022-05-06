using System;
using SmoothDrivingAPI.Domain.Entities;

namespace SmoothDrivingAPI.Domain.Interfaces
{
    public interface ITripService : IBaseService<Trip>
    {
        int calculateTripDuration(DateTime start, DateTime end);
    }
}

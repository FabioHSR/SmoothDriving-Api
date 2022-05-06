using System;
using System.Collections.Generic;
using SmoothDrivingAPI.Domain.Entities;

namespace SmoothDrivingAPI.Domain.Interfaces
{
    public interface ITripService : IBaseService<Trip>
    {
        int calculateTripDuration(DateTime start, DateTime end);
        Tuple<List<string>, bool> ValidateDocument(Trip trip);
        bool isValidEndDate(DateTime DateTimeStart, DateTime DateTimeEnd);
    }
}

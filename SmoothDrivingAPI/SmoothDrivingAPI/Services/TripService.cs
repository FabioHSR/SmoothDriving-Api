using System;
using SmoothDrivingAPI.Domain.Interfaces;

namespace SmoothDrivingAPI.Services
{
    public class TripService : ITripService
    {
        public int calculateTripDuration(DateTime start, DateTime end){
            return (int)(end - start).TotalMilliseconds;
        }
    }
}
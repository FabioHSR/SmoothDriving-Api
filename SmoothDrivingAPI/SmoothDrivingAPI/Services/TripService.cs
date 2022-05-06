using System;
using System.Collections.Generic;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;

namespace SmoothDrivingAPI.Services
{
    public class TripService : BaseService<Trip>, ITripService
    {
        public int calculateTripDuration(DateTime start, DateTime end){
            return (int)(end - start).TotalMilliseconds;
        }

    public Tuple<List<string>, bool> ValidateDocument(Trip trip)
    {
      bool validation = true;
      List<string> invalidFields = new List<string>();

      if(!isValidEndDate(trip.DateTimeStart, trip.DateTimeEnd)){
        validation = false;
        invalidFields.Add("DateTimeEnd");
      }

      return Tuple.Create(invalidFields, validation);
    }

    public bool isValidEndDate(DateTime DateTimeStart, DateTime DateTimeEnd)
    {
      return DateTimeEnd > DateTimeStart;
    }
  }
}
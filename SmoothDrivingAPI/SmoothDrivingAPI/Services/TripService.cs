using System;
using System.Collections.Generic;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;

namespace SmoothDrivingAPI.Services
{
  public class TripService : BaseService<Trip>, ITripService
  {
    private readonly IUserRepository _userRepository;
    private readonly IVehicleRepository _vehicleRepository;
    public TripService(IUserRepository _userRepository, IVehicleRepository _vehicleRepository)
    {
      this._userRepository = _userRepository;
      this._vehicleRepository = _vehicleRepository;
    }
    public Tuple<List<string>, bool> ValidateDocument(Trip trip){
      List<string> invalidFields = new List<string>();

      ValidateEndDate(trip.DateTimeStart, trip.DateTimeEnd, ref invalidFields);

      ValidateIfChildDocumentsExist(ref invalidFields, trip.UserId, trip.VehicleId);

      return ServiceUtils.ValidateInvalidFields(invalidFields);
    }
    public int calculateTripDuration(DateTime start, DateTime end){
      return (int)(end - start).TotalMilliseconds;
    }

    private void ValidateEndDate(
      DateTime DateTimeStart, 
      DateTime DateTimeEnd, 
      ref List<string> invalidFields){

      if(DateTimeStart > DateTimeEnd){
        invalidFields.Add("DateTimeEnd must be greater than DateTimeStart.");
      }
    }

    private void ValidateIfChildDocumentsExist(
      ref List<string> invalidFields, 
      string UserId, 
      string VehicleId){

      if(!_userRepository.Exists(UserId)){
        invalidFields.Add("UserId does not exist.");
      }

      if(!_vehicleRepository.Exists(VehicleId)){
        invalidFields.Add("VehicleId does not exist.");
      }
    }
  }
}
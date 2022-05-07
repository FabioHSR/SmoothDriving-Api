using System;
using System.Collections.Generic;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Enums;
using SmoothDrivingAPI.Domain.Interfaces;

namespace SmoothDrivingAPI.Services
{
  public class VehicleService : BaseService<Vehicle>, IVehicleService
  {
    public Tuple<List<string>, bool> ValidateDocument(Vehicle vehicle)
    {
      List<string> invalidFields = new List<string>();

      ValidateYear(vehicle.Year, ref invalidFields);

      ValidateEnums(vehicle.IPVA, vehicle.Fuel, vehicle.Transmission, ref invalidFields);

      return ServiceUtils.ValidateInvalidFields(invalidFields);
    }

    private void ValidateYear(int Year, ref List<string> invalidFields)
    {
      if(Year > DateTime.Now.Year){
        invalidFields.Add("Year must be less than current year.");
      }
    }

    private void ValidateEnums(
      string IPVA, 
      string Fuel, 
      string Transmission, 
      ref List<string> invalidFields)
    {
      if(!Enum.IsDefined(typeof(IPVAEnum), IPVA)){
        invalidFields.Add("IPVA is not valid.");
      }

      if(!Enum.IsDefined(typeof(FuelEnum), Fuel)){
        invalidFields.Add("Fuel is not valid.");
      }

      if(!Enum.IsDefined(typeof(TransmissionEnum), Transmission)){
        invalidFields.Add("Transmission is not valid.");
      }
    }
  }
}
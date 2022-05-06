using System;
using System.Collections.Generic;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;

namespace SmoothDrivingAPI.Services
{
  public class VehicleService : BaseService<Vehicle>, IVehicleService
  {
    public Tuple<List<string>, bool> ValidateDocument(Vehicle vehicle)
    {
      bool validation = true;
      List<string> invalidFields = new List<string>();

      return Tuple.Create(invalidFields, validation);
    }
  }
}
using System;
using System.Collections.Generic;
using SmoothDrivingAPI.Domain.Entities;

namespace SmoothDrivingAPI.Domain.Interfaces
{
    public interface IVehicleService : IBaseService<Vehicle>
    {
        Tuple<List<string>, bool> ValidateDocument(Vehicle vehicle);
    }
}

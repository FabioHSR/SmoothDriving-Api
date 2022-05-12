using System.Collections.Generic;
using SmoothDrivingAPI.Domain.Entities;

namespace SmoothDrivingAPI.Domain.Interfaces
{
    public interface ITripRepository : IBaseRepository<Trip>
    {
        List<Trip> SelectByUserIdAndVehicleId(string UserId, string VehicleId);
    }
}

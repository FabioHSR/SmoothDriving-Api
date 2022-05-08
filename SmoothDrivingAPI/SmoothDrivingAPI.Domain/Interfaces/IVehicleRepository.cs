using SmoothDrivingAPI.Domain.Entities;

namespace SmoothDrivingAPI.Domain.Interfaces
{
    public interface IVehicleRepository : IBaseRepository<Vehicle>
    {
        Vehicle SelectByPlate(string Plate);
    }
}

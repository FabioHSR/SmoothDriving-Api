using MongoDB.Driver;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;
namespace SmoothDriving.Infra.Data.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(IMongoClient mongoClient) : base(mongoClient, "Vehicle"){    }

        public Vehicle SelectByPlate(string Plate)
        {
            return base.FindByField("Plate", Plate.ToUpper()).FirstOrDefault();
        }
    }
}

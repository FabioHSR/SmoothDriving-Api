using System.Collections.Generic;
using MongoDB.Driver;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;
namespace SmoothDriving.Infra.Data.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(IMongoClient mongoClient) : base(mongoClient, "Vehicle", "smooth-driving-db") {    }

        public Vehicle SelectByPlate(string Plate)
        {
            return base.FindByField("Plate", Plate.ToUpper()).FirstOrDefault();
        }

        public List<Vehicle> SelectVehiclesByIds(List<string> Ids)
        {
            return base.FindByIds(Ids);
        }
    }
}

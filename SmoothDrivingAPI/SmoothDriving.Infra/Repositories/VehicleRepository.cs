using System.Collections.Generic;
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

        public List<Vehicle> SelectVehiclesByIds(List<string> Ids)
        {
            return base.FindByIds(Ids);
        }

        public void AddCNHToVehicles(List<string> Ids, string CNH){
            List<Vehicle> vehicles = SelectVehiclesByIds(Ids);
            foreach(Vehicle vehicle in vehicles){
                vehicle.CNH = CNH;
                base.Update(vehicle, vehicle.Id);
            }
        }
    }
}

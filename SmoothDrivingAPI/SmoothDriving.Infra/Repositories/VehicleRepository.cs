using Microsoft.EntityFrameworkCore;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SmoothDriving.Infra.Data.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>, IVehicleRepository
    {
        public VehicleRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public override Vehicle Select(int id)
        {
            return dbContext.Set<Vehicle>()
                .FirstOrDefault(vehicle => vehicle.Id == id);
        }
        public override IList<Vehicle> Select()
        {
            return dbContext.Set<Vehicle>()
                .ToList();
        }
    }
}

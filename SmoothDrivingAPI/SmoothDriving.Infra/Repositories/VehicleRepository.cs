using Microsoft.EntityFrameworkCore;
using SmoothDrivingAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDriving.Infra.Data.Repositories
{
    public class VehicleRepository : BaseRepository<Vehicle>
    {
        public VehicleRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }
}

using Microsoft.EntityFrameworkCore;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDriving.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public override User Select(int id)
        {
            return dbContext.Set<User>()
                .Include(user => user.Vehicles)
                .FirstOrDefault(user => user.Id == id);
        }
        public override IList<User> Select()
        {
            return dbContext.Set<User>()
                .Include(user => user.Vehicles)
                .ToList();
        }
    }
}

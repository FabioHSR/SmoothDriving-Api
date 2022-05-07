using MongoDB.Driver;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;
namespace SmoothDriving.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoClient mongoClient) : base(mongoClient, "User"){    }
    }
}

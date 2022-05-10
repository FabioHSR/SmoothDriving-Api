using System;
using MongoDB.Driver;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;
namespace SmoothDriving.Infra.Data.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(IMongoClient mongoClient) : base(mongoClient, "User"){
        }

        public bool EmailExists(string Email)
        {
            return base.Exists("Email", Email.ToLower());
        }

        public User SelectByEmail(string Email)
        {
            return base.FindByField("Email", Email.ToLower()).FirstOrDefault();
        }
    }
}

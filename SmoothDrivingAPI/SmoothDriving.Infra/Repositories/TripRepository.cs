using MongoDB.Driver;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;

namespace SmoothDriving.Infra.Data.Repositories
{
    public class TripRepository : BaseRepository<Trip>, ITripRepository
    { 
        public TripRepository(IMongoClient mongoClient) : base(mongoClient){

        }
    }
}
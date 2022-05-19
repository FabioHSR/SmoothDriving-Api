// using MongoDB.Bson;
// using MongoDB.Driver;
// using SmoothDriving.Infra.Data.Context;
// using SmoothDrivingAPI.Domain.Entities;
// using SmoothDrivingAPI.Domain.Interfaces;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;

// namespace SmoothDrivingAPI.WebApi.Services
// {
//     public class BrokerService : IBrokerService
//     {
//         private readonly BrokerContext brokerContext;
//         private readonly IBrokerMongoRepository brokerRepository;
//         private readonly IMongoDatabase db;
//         public BrokerService(BrokerContext _brokerContext, IBrokerMongoRepository _brokerMongoRepository, IMongoDatabase _db)
//         {
//             brokerContext = _brokerContext;
//             brokerRepository = _brokerMongoRepository;
//             db = _db;
//         }

//         public List<BrokerTrip> GetTrips(string EntityId)
//         {
//             var trips = brokerRepository.GetBrokerTrips(EntityId);
//             return trips;
//         }
//     }
// }
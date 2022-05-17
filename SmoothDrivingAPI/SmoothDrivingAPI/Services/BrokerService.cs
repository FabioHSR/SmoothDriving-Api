// using MongoDB.Bson;
// using MongoDB.Driver;
// using SmoothDriving.Infra.Data.Context;
// using SmoothDrivingAPI.Domain.Entities.BrokerEntity;
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

//         public async Task<List<BsonDocument>> GetTrips(string idVeiculo)
//         {

//         }

//         public async Task<List<Attr>> GetByIdViagem()
//         {
//             return brokerRepository.Select("IdViagem", "748639709");
//         }
//     }
    
// }

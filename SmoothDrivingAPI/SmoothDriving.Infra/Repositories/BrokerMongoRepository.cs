// using MongoDB.Driver;
// using SmoothDrivingAPI.Domain.Entities.BrokerEntity;
// using SmoothDrivingAPI.Domain.Interfaces;
// using System.Collections.Generic;
// using System.Linq;

// namespace SmoothDriving.Infra.Data.Repositories
// {
//     public class BrokerMongoRepository : BaseRepository<Attr>, IBrokerMongoRepository
//     {

//         public BrokerMongoRepository(IMongoClient mongoClient) : base(mongoClient, "sth_/_urn:ngsi-ld:entity:025_iot", "sth_helixiot") { }

//         public List<Attr> Select(string UserId, string VehicleId)
//         {
//             return base.FindByField("IdViagem", "748639709").ToList();
//         }
//     }
// }

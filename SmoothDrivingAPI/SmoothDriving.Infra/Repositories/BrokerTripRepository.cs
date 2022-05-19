using MongoDB.Bson;
using MongoDB.Driver;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SmoothDriving.Infra.Data.Repositories
{
    public class BrokerTripRepository : IBrokerTripRepository
    {
        public List<BrokerTrip> GetBrokerTrips(string EntityId)
        {
            MongoClient mongoClient = new MongoClient("mongodb://helix:H3l1xNG@15.228.222.191:27000/?authSource=admin&readPreference=primary&appname=MongoDB%20Compass&ssl=false");
            IMongoDatabase database = mongoClient.GetDatabase("sth_helixiot");

            IMongoCollection<BrokerTrip> _dataCollection = database.GetCollection<BrokerTrip>("sth_/_" + EntityId);

            var pipe = new List<BsonDocument>{
                new BsonDocument{
                    {
                        "$match", new BsonDocument{{ "attrName", "IdViagem" }}
                    }
                },
                new BsonDocument{
                    {
                        "$group", 
                        new BsonDocument{
                            { "_id", "$attrValue" },
                            {"maxTripDate", new BsonDocument{{ "$max", "$recvTime" }}},
                            {"minTripDate", new BsonDocument{{ "$min", "$recvTime" }}}
                        }
                    }
                }
            };

            return _dataCollection.Aggregate<BrokerTrip>(pipe).ToList();
        }
  }
}

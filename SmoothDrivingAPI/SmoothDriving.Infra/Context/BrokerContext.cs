using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;
using SmoothDrivingAPI.Domain.Entities;

namespace SmoothDriving.Infra.Data.Context
{
    public class BrokerContext : DbContext
    {
        private readonly IMongoDatabase _db;
        public BrokerContext(IMongoClient client, string dbName)
        {
            _db = client.GetDatabase(dbName);
        }

        // public IMongoCollection<Attr> Attrs => _db.GetCollection<Attr>("sth_/_urn:ngsi-ld:entity:025_iot");
    }
}

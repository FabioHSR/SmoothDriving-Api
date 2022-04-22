using MongoDB.Driver;
using SmoothDrivingAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SmoothDrivingAPI.Domain.Interfaces;

namespace SmoothDriving.Infra.Data.Repositories
{
    public class DataRepository : IDataRepository
    {
        private IMongoCollection<SensorData> _dataCollection;
        public DataRepository(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase("SmoothDrivingDb");
            _dataCollection = database.GetCollection<SensorData>("brokerSimulation");
        }
        public IList<SensorData> Select()
        {
            return _dataCollection.Find(e => true).ToList();
        }

        public void Delete(SensorData entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(SensorData entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public SensorData Select(int id)
        {
            throw new NotImplementedException();
        }

    }
}

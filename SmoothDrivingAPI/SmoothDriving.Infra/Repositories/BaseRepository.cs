using MongoDB.Driver;
using SmoothDrivingAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using SmoothDrivingAPI.Domain.Interfaces;
using MongoDB.Bson;
namespace SmoothDriving.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private IMongoCollection<TEntity> _dataCollection;
        public BaseRepository(IMongoClient mongoClient, string collectionName)
        {
            var database = mongoClient.GetDatabase("smooth-driving-db");
            _dataCollection = database.GetCollection<TEntity>(collectionName);
        }
        public IList<TEntity> Select()
        {
            return _dataCollection.Find(e => true).ToList();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(ObjectId id)
        {
            throw new NotImplementedException();
        }

        public void InsertOrUpdate(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public TEntity Select(ObjectId id)
        {
            throw new NotImplementedException();
        }

    }
}

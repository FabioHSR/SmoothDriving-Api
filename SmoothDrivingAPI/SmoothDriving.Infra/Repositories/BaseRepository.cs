using MongoDB.Driver;
using SmoothDrivingAPI.Domain.Entities;
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
            _dataCollection.DeleteOne(CreateIdFilter(entity.Id));
        }

        public void Delete(string Id)
        {
            _dataCollection.DeleteOneAsync(
                CreateIdFilter(Id));
        }

        public void Insert(TEntity entity)
        {
            _dataCollection.InsertOne(entity);
        }
        public void Update(TEntity entity, string Id)
        {
            entity.Id = Id;
            _dataCollection.ReplaceOne(
                CreateIdFilter(Id), entity);
        }

        public TEntity Select(string Id)
        {
            return _dataCollection.Find(CreateIdFilter(Id)).FirstOrDefault();
        }

        public bool Exists(string Id)
        {
            return _dataCollection.Find(CreateIdFilter(Id)).Any();
        }

        private FilterDefinition<TEntity> CreateIdFilter(string Id){
            return Builders<TEntity>.Filter.Eq("_id", new ObjectId(Id));
        }
    }
}

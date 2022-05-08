using MongoDB.Driver;
using SmoothDrivingAPI.Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using SmoothDrivingAPI.Domain.Interfaces;
using MongoDB.Bson;
using System;

namespace SmoothDriving.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        private IMongoCollection<TEntity> _dataCollection;

        private readonly string DefaultIdMongoName = "_id";

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
            _dataCollection.DeleteOne(CreateFilter(DefaultIdMongoName, entity.Id));
        }

        public void Delete(string Id)
        {
            _dataCollection.DeleteOneAsync(
                CreateFilter(DefaultIdMongoName, Id));
        }

        public void Insert(TEntity entity)
        {
            _dataCollection.InsertOne(entity);
        }

        public void Update(TEntity entity, string Id)
        {
            entity.Id = Id;
            _dataCollection.ReplaceOne(
                CreateFilter(DefaultIdMongoName, Id), entity);
        }
        public IFindFluent<TEntity, TEntity> FindByField(string FieldName, string FieldValue)
        {
            return _dataCollection.Find(CreateFilter(FieldName, FieldValue));
        }

        public TEntity Select(string Id)
        {
            return FindByField(DefaultIdMongoName, Id).FirstOrDefault();
        }

        public bool Exists(string FieldName, string FieldValue)
        {
            return FindByField(FieldName, FieldValue).Any();
        }
        private FilterDefinition<TEntity> CreateFilter(string FieldName, string FieldValue){

            if(FieldName == DefaultIdMongoName){
                return Builders<TEntity>.Filter.Eq(DefaultIdMongoName, new ObjectId(FieldValue));
            }

            if(FieldName == "Email"){
                FieldValue = FieldValue.ToLower();
            }

            return Builders<TEntity>.Filter.Eq(FieldName, FieldValue);
        }
    }
}

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

        public BaseRepository(IMongoClient mongoClient, string collectionName, string dataBase)
        {
            var database = mongoClient.GetDatabase(dataBase);
            _dataCollection = database.GetCollection<TEntity>(collectionName);
        }
        public IList<TEntity> Select()
        {
            return _dataCollection.Find(e => true).ToList();
        }
        public List<TEntity> FindByIds(List<string> Ids)
        {
            return _dataCollection.Find(e => Ids.Contains(e.Id)).ToList();
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
        public IFindFluent<TEntity, TEntity> FindByTwoFields(
            string FieldName1, 
            string FieldValue1, 
            string FieldName2, 
            string FieldValue2)
        {
            return _dataCollection.Find(CreateFilterByTwoFields(FieldName1, FieldValue1, FieldName2, FieldValue2));
        }

        public TEntity Select(string Id)
        {
            return FindByField(DefaultIdMongoName, Id).FirstOrDefault();
        }

        public bool Exists(string FieldName, string FieldValue)
        {
            return FindByField(FieldName, FieldValue).Any();
        }

        private FilterDefinition<TEntity> CreateFilterByTwoFields(string FieldName, string FieldValue, string FieldName2, string FieldValue2)
        {
            return Builders<TEntity>.Filter.Eq(FieldName, FieldValue) & Builders<TEntity>.Filter.Eq(FieldName2, FieldValue2);
        }

        public FilterDefinition<TEntity> CreateFilter(string FieldName, string FieldValue){

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

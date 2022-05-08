using SmoothDrivingAPI.Domain.Entities;
using System.Collections.Generic;
using MongoDB.Bson;

namespace SmoothDrivingAPI.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void Insert(TEntity entity);
        void Update(TEntity entity, string Id);
        void Delete(TEntity entity);
        void Delete(string Id);
        TEntity Select(string Id);
        IList<TEntity> Select();
        bool Exists(string FieldName, string FieldValue);
    }
}

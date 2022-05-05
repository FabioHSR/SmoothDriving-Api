using SmoothDrivingAPI.Domain.Entities;
using System.Collections.Generic;
using MongoDB.Bson;

namespace SmoothDrivingAPI.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void InsertOrUpdate(TEntity entity); 
        void Delete(TEntity entity);
        void Delete(ObjectId id);
        TEntity Select(ObjectId id);
        IList<TEntity> Select();
        void SaveChanges();
    }
}

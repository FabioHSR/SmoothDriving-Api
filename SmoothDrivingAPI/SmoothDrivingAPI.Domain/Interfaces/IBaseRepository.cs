using SmoothDrivingAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDrivingAPI.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        void InsertOrUpdate(TEntity entity); 
        void Delete(TEntity entity);
        void Delete(int id);
        TEntity Select(int id);
        IList<TEntity> Select();
        void SaveChanges();
    }
}

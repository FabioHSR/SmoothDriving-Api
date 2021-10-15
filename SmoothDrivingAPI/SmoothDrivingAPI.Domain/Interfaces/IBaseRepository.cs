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
        TEntity InsertOrUpdate(TEntity entity); 
        void Delete(TEntity entity);
        TEntity Select(int id);
        IEnumerable<TEntity> Select();
        void SaveChanges();
    }
}

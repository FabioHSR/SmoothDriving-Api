using Microsoft.EntityFrameworkCore;
using SmoothDrivingAPI.Domain.Entities;
using SmoothDrivingAPI.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmoothDriving.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DbContext dbContext;
        public BaseRepository(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public virtual void Delete(TEntity entity)
        {
            dbContext.Set<TEntity>().Remove(entity);
        }
        public virtual void Delete(int id)
        {
            var entity = Select(id);
            dbContext.Set<TEntity>().Remove(entity);
        }

        public virtual void InsertOrUpdate(TEntity entity)
        {
            dbContext.Set<TEntity>().Update(entity);
        }

        public virtual TEntity Select(int id)
        {
            return dbContext.Set<TEntity>().Find(id);
        }

        public virtual IList<TEntity> Select()
        {
            return dbContext.Set<TEntity>().ToList();
        }
        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}

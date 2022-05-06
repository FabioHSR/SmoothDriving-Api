using System;
using SmoothDrivingAPI.Domain.Entities;

namespace SmoothDrivingAPI.Domain.Interfaces
{
    public interface IBaseService<TEntity> where TEntity : BaseEntity
    {
    }
}

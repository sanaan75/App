using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Persistence;

public interface IRepository
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;
    IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity;

    EntityEntry<TEntity> Entry<TEntity>(TEntity entity)
        where TEntity : class;

    int Save();
}
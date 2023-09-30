using Microsoft.EntityFrameworkCore;
using Research.Abstractions;

namespace Research.DB;

public interface IRepository : IDisposable
{
    DbSet<TEntity> Set<TEntity>() where TEntity : class;

    IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity;
    public IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class, IEntity, new();

    public TEntity GetById<TEntity>(int id) where TEntity : class, IEntity, new();

    List<T> GetAll<T>() where T : class, IEntity, new();

    void DeleteById<TEntity>(int id) where TEntity : class, IEntity, new();

    void Add<TEntity>(TEntity item) where TEntity : class, IEntity, new();
    void Update<TEntity>(TEntity item) where TEntity : class, IEntity, new();
    
    void Save();
}
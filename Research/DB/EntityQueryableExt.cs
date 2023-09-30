using System.Linq.Expressions;
using Research.Abstractions;

namespace Research.DB;

public static class EntityQueryableExt
{
    public static TResult GetById<TEntity, TResult>(this IQueryable<TEntity> set, int id, Expression<Func<TEntity, TResult>> selector) where TEntity : class, IEntity
    {
        return set.Where<TEntity>((Expression<Func<TEntity, bool>>) (i => i.Id == id)).Select<TEntity, TResult>(selector).FirstOrDefault<TResult>();
    }

    public static TResult GetById<TEntity, TResult>(this IQueryable<TEntity> set, int? id, Expression<Func<TEntity, TResult>> selector)
        where TEntity : class, IEntity
        where TResult : class
    {
        TResult byId;
        if (id.HasValue)
            byId = set.Where<TEntity>((Expression<Func<TEntity, bool>>) (i => (int?) i.Id == id)).Select<TEntity, TResult>(selector).FirstOrDefault<TResult>();
        else
            byId = default (TResult);
        return byId;
    }
}
using System.Linq.Expressions;
using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Research.Abstractions;
using Research.Entities;
using SQLite;

namespace Research.DB;

public class Repository : DbContext, IRepository
{
    readonly SQLiteConnection _connection;
    public string StatusMessage { get; set; }

    public Repository()
    {
        _connection = new SQLiteConnection(Costants.DbPath, Costants.Flags);
        _connection.CreateTable<Person>();
        _connection.CreateTable<ToDo>();
    }

    // protected override void OnModelCreating(ModelBuilder model)
    // {
    //     base.OnModelCreating(model);
    //
    //     model.ApplyConfigurationsFromAssembly(GetType().Assembly);
    //     model.RegisterEntitiesFromAssembly(typeof(EntitiesDummy).Assembly);
    // }
    //
    // protected override void OnConfiguring(DbContextOptionsBuilder options)
    //     => options.UseSqlite("Data Source=AppDatabase.db3");

    public IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity =>
        (IQueryable<TEntity>)this.Set<TEntity>()
            .OrderByDescending<TEntity, int>((Expression<Func<TEntity, int>>)(i => i.Id));

    public IQueryable<TEntity> GetQuery<TEntity>() where TEntity : class, IEntity, new()
    {
        try
        {
            return _connection.Table<TEntity>().AsQueryable();
        }
        catch (Exception ex)
        {
            StatusMessage = $"error : {ex.Message}";
        }

        return null;
    }

    public TEntity GetById<TEntity>(int id) where TEntity : class, IEntity, new()
    {
        try
        {
            return _connection.Table<TEntity>().FirstOrDefault(x => x.Id == id);
        }
        catch (Exception ex)
        {
            StatusMessage = $"error : {ex.Message}";
        }

        return null;
    }

    public List<T> GetAll<T>() where T : class, IEntity, new()
    {
        try
        {
            return _connection.Table<T>().ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        return null;
    }

    public void DeleteById<TEntity>(int id) where TEntity : class, IEntity, new()
    {
        try
        {
            var item = GetById<TEntity>(id);
            _connection.Delete(item);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
            throw;
        }
    }

    public void Add<TEntity>(TEntity item) where TEntity : class, IEntity, new()
    {
        int result = 0;
        try
        {
            result = _connection.Insert(item);
            StatusMessage = $"{result} row(s) added.";
        }
        catch (Exception ex)
        {
            StatusMessage = $"error : {ex.Message}.";
        }
    }

    public void Update<TEntity>(TEntity item) where TEntity : class, IEntity, new()
    {
        int result = 0;
        try
        {
            result = _connection.Update(item);
            StatusMessage = $"{result} row(s) updated.";
        }
        catch (Exception ex)
        {
            StatusMessage = $"error : {ex.Message}.";
        }
    }
    
    public void Save()
    {
        this.SaveChanges();
    }

    public void Dispose()
    {
        _connection.Dispose();
    }
}

public static class DbModelBuilderExt
{
    public static void RegisterEntitiesFromAssembly(
        this ModelBuilder modelBuilder,
        Assembly assembly)
    {
        List<Type> list = ((IEnumerable<Type>)assembly.GetTypes())
            .Where<Type>((Func<Type, bool>)(t => typeof(IEntity).IsAssignableFrom(t)))
            .Where<Type>((Func<Type, bool>)(t => !t.IsAbstract)).ToList<Type>();
        MethodInfo entityMethod = typeof(ModelBuilder).GetMethod("Entity");
        list.ForEach((Action<Type>)(type =>
            entityMethod.MakeGenericMethod(type).Invoke((object)modelBuilder, new object[0])));
    }
}
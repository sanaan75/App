using System.Linq.Expressions;
using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Services;

namespace Persistence;

public class AppContext : DbContext, IDb
{
    public AppContext()
    {
    }

    public AppContext(DbContextOptions<AppContext> options)
        : base(options)
    {
        try
        {
            RelationalDatabaseCreator databaseCreator =
                (RelationalDatabaseCreator)Database.GetService<IDatabaseCreator>();
            databaseCreator.CreateTables();
        }
        catch (Exception ex)
        {
            // error when table already exist
        }
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
    {
        options.UseSqlite(DbSettings.Connection);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IEntityTypeConfiguration<>).Assembly);
    }

    public DbSet<Person> Persons { get; set; }
    public DbSet<Post> Posts { get; set; }

    public IQueryable<TEntity> Query<TEntity>() where TEntity : class, IEntity =>
        (IQueryable<TEntity>)this.Set<TEntity>()
            .OrderByDescending<TEntity, int>((Expression<Func<TEntity, int>>)(i => i.Id));

    public int Save()
    {
        return this.SaveChanges();
    }

    public void Dispose()
    {
        this.Dispose();
    }
}
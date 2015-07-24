using System.Data.Entity;
using Models;

namespace ServiceForMinibuses.Manager.EntityFramework
{
    public interface IDatabaseContext
    {
        DbSet<Stop> Stops { get; set; }

       DbSet<Route> Routes { get; set; }

           DbSet<TEntity> Set<TEntity>() where TEntity : class;
    }
}

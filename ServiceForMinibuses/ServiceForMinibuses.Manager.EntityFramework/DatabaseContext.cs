using System.Data.Entity;
using System.Reflection;
using Models;

namespace ServiceForMinibuses.Manager.EntityFramework
{
    public class DatabaseContext : DbContext, IDatabaseContext
    {
        public DatabaseContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        public DbSet<Stop> Stops { get; set; }

        public DbSet<Route> Routes { get; set; }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            Assembly configurationAssembly = Assembly.GetAssembly(GetType());
            modelBuilder.Configurations.AddFromAssembly(configurationAssembly);
        }
    }
}

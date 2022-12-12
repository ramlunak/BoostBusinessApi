using BoostBusinessApi.Data.Entity;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace BoostBusinessApi.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {

        }

        public DbSet<UserEntity> Users => Set<UserEntity>();
    }
}

using BoostBusinessApi.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace BoostBusinessApi.Data
{
    public class DBContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite(Configuration.GetConnectionString("SQliteDbConnection"));
        }

        public DbSet<UserEntity> Users => Set<UserEntity>();
    }
}

using entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace repositories
{
    public class PostgresBank : DbContext
    {
        private IConfiguration Configuration { get; set; }

        public PostgresBank(IConfiguration config)
        {
            Configuration = config;
        }

        public DbSet<EventEntity> Event { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Configuration.GetConnectionString("tech.operations");//"postgresRemoteDatabase");
            optionsBuilder.UseSqlServer(connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EventEntity>()
                .HasOne(c => c.Role as RoleEntity);
        }
    }
}

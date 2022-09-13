using entities;
using entities.Dto;
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

        public DbSet<EventDtoModel> Event { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Configuration.GetConnectionString("postgresRemoteDatabase");

            optionsBuilder
                .UseNpgsql(connString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

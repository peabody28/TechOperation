using entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace repositories
{
    public class Bank : DbContext
    {
        private IConfiguration Configuration { get; set; }

        public Bank(IConfiguration config)
        {
            Configuration = config;
        }

        public DbSet<UserEntity> User { get; set; }
        public DbSet<RoleEntity> Role { get; set; }
        public DbSet<EventEntity> Event { get; set; }
        public DbSet<LocationEntity> Location { get; set; }
        public DbSet<ReportEntity> Report { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Configuration.GetConnectionString("postgresRemoteDatabase");
            
            optionsBuilder
                .UseNpgsql(connString)
                .UseSnakeCaseNamingConvention()
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>()
                .HasOne(c => c.Role as RoleEntity);

            modelBuilder.Entity<EventEntity>()
                .HasOne(c => c.Role as RoleEntity);

            modelBuilder.Entity<ReportEntity>()
                .HasOne(c => c.User as UserEntity);

            modelBuilder.Entity<ReportEntity>()
                .HasOne(c => c.Location as LocationEntity);
        }
    }
}
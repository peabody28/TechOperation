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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connString = Configuration.GetConnectionString("tech.operations");
            optionsBuilder.UseSqlServer(connString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserEntity>()
                .HasOne(c => c.Role as RoleEntity);

            modelBuilder.Entity<EventEntity>()
                .HasOne(c => c.Role as RoleEntity);
        }
    }
}
using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext : DbContext
    {
        
        public DbSet<ClientEntity> clients { get; set; }
        
        public DbSet<UserEntity> users { get; set; }

        public DbSet<SessionEntity> sessions { get; set; }

        public DbSet<PermissionEntity> permissions { get; set; }

        public DbSet<ConfigEntity> config { get; set; }

        public DbSet<ReceiveEntity> receives { get; set; }


        public DbSet<LayoutEntity> layouts {get; set;}

        public MyContext(DbContextOptions<MyContext> options) :base (options) {}


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ClientEntity>(new ClientMap().Configure);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<SessionEntity>(new SessionsMap().Configure);
            modelBuilder.Entity<PermissionEntity>(new PermissionMap().Configure);
            modelBuilder.Entity<ConfigEntity>(new ConfigMap().Configure);
            modelBuilder.Entity<ReceiveEntity>(new ReceiveMap().Configure);
            modelBuilder.Entity<LayoutEntity>(new LayoutMap().Configure);
        }
    }
}

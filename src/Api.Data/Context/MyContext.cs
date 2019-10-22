using Api.Data.Mapping;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Context
{
    public class MyContext: DbContext
    {
        public DbSet<UserEntity> users { get; set; }

        public DbSet<SessionEntity> sessions {get; set;}

        public DbSet<PermissionEntity> permissions {get; set;}

        public MyContext(DbContextOptions<MyContext> options) :base (options) {}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating (modelBuilder);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<SessionEntity>(new SessionsMap().Configure);
            modelBuilder.Entity<PermissionEntity>(new PermissionMap().Configure);
        }
    }
}

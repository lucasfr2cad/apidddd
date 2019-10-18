using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.Data.Context
{
    public class ContextFactory : IDesignTimeDbContextFactory<MyContext>
    {
        public MyContext CreateDbContext(string[] args)
        {
            //Usado para criar migrações
            var connectionString = "Host=10.0.0.10;Port=5432;Pooling=true;Database=gcad; Id=rei;Password=teste;";
            var OptionsBuilder = new DbContextOptionsBuilder<MyContext>();
            OptionsBuilder.UseNpgsql(connectionString);
            return new MyContext(OptionsBuilder.Options);
        }
    }
}

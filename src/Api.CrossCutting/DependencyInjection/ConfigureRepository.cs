using Api.Data.Context;
using Api.Data.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
         public static void ConfigureDependenciesRepository(IServiceCollection serviceColletion)
        {
            serviceColletion.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));

             serviceColletion.AddDbContext<MyContext>(
                options => options.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=teste;User Id=rei;Password=teste;")
            );
        }
    }
}

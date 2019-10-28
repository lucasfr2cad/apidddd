using Api.Data.Context;
using Api.Data.Implementations;
using Api.Data.Repository;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureRepository
    {
         public static void ConfigureDependenciesRepository(IServiceCollection serviceColletion)
        {
            serviceColletion.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            serviceColletion.AddScoped<IUserRepository, UserImplementation>();
            serviceColletion.AddScoped<ISessionRepository, SessionImplementation>();
            serviceColletion.AddTransient<IPermissionRepository, PermissionImplementation>();
             serviceColletion.AddDbContext<MyContext>(
                options => options.UseNpgsql("Host=10.0.0.10;Port=5432;Database=gcad;User Id=rei;Password=teste;")
            );
        }
    }
}

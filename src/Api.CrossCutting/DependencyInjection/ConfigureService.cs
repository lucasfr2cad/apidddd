using Api.Domain.Interfaces.Services.Permission;
using Api.Domain.Interfaces.Services.Receive;
using Api.Domain.Interfaces.Services.Session;
using Api.Domain.Interfaces.Services.User;
using Api.Service.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Api.CrossCutting.DependencyInjection
{
    public class ConfigureService
    {
        public static void ConfigureDependenciesService(IServiceCollection serviceColletion)
        {
            serviceColletion.AddScoped<IUserService, UserService>();
            serviceColletion.AddScoped<ILoginService, LoginService>();
            serviceColletion.AddScoped<ISessionService, SessionService>();
            serviceColletion.AddScoped<IPermissionService, PermissionService>();
            serviceColletion.AddScoped<IReceiveService, ReceiveService>();
        }
    }
}

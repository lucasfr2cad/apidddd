using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Response;

namespace Api.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
          Task<LoginResponse>  FindByLogin(LoginDto user);
          Task<UserEntity> Post (UserEntity user);
          Task<SessionEntity> UnchekSession (string token);
    }
}

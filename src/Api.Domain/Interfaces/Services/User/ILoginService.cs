using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.User
{
    public interface ILoginService
    {
          Task<object>  FindByLogin(LoginDto user);

          Task<UserEntity> Post (UserEntity user);


          Task<SessionEntity> UnchekSession (int id);

    }
}

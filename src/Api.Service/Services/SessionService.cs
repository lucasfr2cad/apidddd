using System.Threading.Tasks;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Session;
using Api.Domain.Repository;

namespace Api.Service.Services
{
    public class SessionService : ISessionService
    {

         private ISessionRepository _repository2;

        public SessionService(ISessionRepository repository2)
        {
           _repository2 = repository2;
        }


        public async Task<int> CheckSession(UserEntity user )
        {   
         return await _repository2.CheckSession(user.cd_codigo);
        }

    }
}

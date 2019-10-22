using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Session
{
    public interface ISessionService
    {
         Task<int> CheckSession (UserEntity user);
    }
}

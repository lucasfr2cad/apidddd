using System.Threading.Tasks;
using Api.Data.Repository;
using Api.Domain.Entities;
namespace Api.Domain.Repository
{
    public interface ISessionRepository: IRepository<SessionEntity>
    {
         Task<int> CheckSession (int cd_codigo);
         Task<SessionEntity> GetSessionInfo(string token);
    }
}

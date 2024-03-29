using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;
namespace Api.Data.Implementations
{
    public class SessionImplementation : BaseRepository<SessionEntity>, ISessionRepository
    {
        public SessionImplementation(MyContext context) : base(context)
        {
            
        }
        public async Task<int> CheckSession(int cd_codigo)
        {
            return await  _dataset.CountAsync(s => s.st_ativo == true && s.cd_usuario == cd_codigo);
        }
        public async Task<SessionEntity> GetSessionInfo(string token)
        {
            return await _dataset.FirstOrDefaultAsync(s => s.txt_hash.Equals(token));
        }
    }
}

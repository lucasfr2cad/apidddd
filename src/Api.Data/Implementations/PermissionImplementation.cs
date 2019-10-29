using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class PermissionImplementation : BaseRepository<PermissionEntity>, IPermissionRepository
    {
        public PermissionImplementation(MyContext context) : base(context)
        {

        }

        public async Task<PermissionEntity> FindPermission(int form, int idUser, int cd_condicao)
        {
            if(cd_condicao == 0)
            {
                return await _dataset.FirstOrDefaultAsync(p => p.cd_usuario == idUser && p.cd_form == form);
            }
            else
            {
                return await _dataset.FirstOrDefaultAsync(p => p.cd_usuario == idUser && p.cd_condicao == cd_condicao);
            }
           
        }
    }
}

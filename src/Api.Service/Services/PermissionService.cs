using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Permission;
using Api.Domain.Repository;

namespace Api.Service.Services
{
    public class PermissionService:IPermissionService
    {

         private IPermissionRepository _repository;

         public PermissionService(IPermissionRepository repository)
         {
             _repository = repository;
         }

        public async Task<PermissionEntity> FindPermission(int form, int idUser, int cd_condicao)
        {
            return await _repository.FindPermission(form, idUser, cd_condicao);
        }
    }
}

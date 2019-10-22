using System.Threading.Tasks;
using Api.Data.Repository;
using Api.Domain.Entities;

namespace Api.Domain.Repository
{
    public interface IPermissionRepository:IRepository<PermissionEntity>
    {
         Task <PermissionEntity>  FindPermission(int form, int idUser, int cd_condicao);
    }
}

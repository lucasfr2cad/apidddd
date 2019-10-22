using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Permission
{
    public interface IPermissionService
    {
         Task <PermissionEntity>  FindPermission(int form, int idUser, int cd_condicao);
    }
}

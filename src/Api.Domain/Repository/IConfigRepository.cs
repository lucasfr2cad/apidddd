using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Repository
{
    public interface IConfigRepository
    {
         Task <ConfigEntity>  FindLanguage(int cd_empresa);
    }
}

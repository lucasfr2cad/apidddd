using System.Threading.Tasks;
using Api.Data.Repository;
using Api.Domain.Entities;

namespace Api.Domain.Repository
{
    public interface IUserRepository : IRepository<UserEntity>
    {
        Task<UserEntity> FindByLogin (string email);
    }
}

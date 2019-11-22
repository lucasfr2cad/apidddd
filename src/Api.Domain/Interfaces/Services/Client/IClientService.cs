using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Client
{
    public interface IClientService
    {
        Task<ClientEntity> Get(int id);

        Task<IEnumerable<ClientEntity>> GetAll();

        Task<ClientEntity> Post(ClientEntity client);

        Task<ClientEntity> Put(ClientEntity client);

        Task<bool> Delete(int id);
    }
}
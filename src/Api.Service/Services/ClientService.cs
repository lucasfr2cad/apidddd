using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Client;

namespace Api.Service.Services
{
    public class ClientService : IClientService
    {

        private IRepository<ClientEntity> _repository;

        public ClientService(IRepository<ClientEntity> repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<ClientEntity> Get(int id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<ClientEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public async Task<ClientEntity> Post(ClientEntity client)
        {
            return await _repository.InsertAsync(client);
        }

        public async Task<ClientEntity> Put(ClientEntity client)
        {
            return await _repository.UpdateAsync(client);
        }
    }
}

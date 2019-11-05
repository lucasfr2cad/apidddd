using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.Receive;

namespace Api.Service.Services
{
    public class ReceiveService : IReceiveService
    {

        private IRepository<ReceiveEntity> _repository;


        public ReceiveService(IRepository<ReceiveEntity> repository)
        {
            _repository = repository;
        }


        public async Task<IEnumerable<ReceiveEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }
    }
}

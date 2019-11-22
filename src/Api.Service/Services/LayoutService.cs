using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.LayoutService;
using Api.Domain.Repository;

namespace Api.Service.Services
{
    public class LayoutService : ILayoutService
    {


        private ILayoutRepository _repository;

        public LayoutService(ILayoutRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Delete(int id)
        {
            return await _repository.DeleteAsync(id);
        }

        public async Task<LayoutEntity> Get(int id)
        {
            return await _repository.SelectAsync(id);
        }

        public async Task<IEnumerable<LayoutEntity>> GetAll()
        {
            return await _repository.SelectAsync();
        }

        public void Insert(LayoutEntity layout)
        {
            _repository.Insert(layout);
        }

        public async Task<LayoutEntity> Post(LayoutEntity layout)
        {
            return await _repository.InsertAsync(layout);
        }

        public async Task<LayoutEntity> Put(LayoutEntity layout)
        {
            return await _repository.UpdateAsync(layout);
        }

        public void Update(LayoutEntity layout)
        {
            _repository.Update(layout);
        }
    }
}

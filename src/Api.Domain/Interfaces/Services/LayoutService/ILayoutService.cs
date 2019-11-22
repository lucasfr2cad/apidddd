using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.LayoutService
{
    public interface ILayoutService
    {
        Task<LayoutEntity> Get (int id);

         Task<IEnumerable<LayoutEntity>> GetAll();

         Task<LayoutEntity> Post (LayoutEntity layout);

         Task<LayoutEntity> Put (LayoutEntity layout);

         Task<bool> Delete (int id);

         void Update(LayoutEntity layout);

         void Insert(LayoutEntity layout);
    }
}

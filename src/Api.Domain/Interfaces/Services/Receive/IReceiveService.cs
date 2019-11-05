using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Domain.Entities;

namespace Api.Domain.Interfaces.Services.Receive
{
    public interface IReceiveService
    {
         Task<IEnumerable<ReceiveEntity>> GetAll();
    }
}

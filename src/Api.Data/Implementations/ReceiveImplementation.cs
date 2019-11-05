using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class ReceiveImplementation : BaseRepository<ReceiveEntity>
    {

        public ReceiveImplementation(MyContext context) : base(context)
        {
           
        }
    }
}

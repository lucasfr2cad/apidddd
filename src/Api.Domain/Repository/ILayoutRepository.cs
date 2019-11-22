using Api.Data.Repository;
using Api.Domain.Entities;

namespace Api.Domain.Repository
{
    public interface ILayoutRepository : IRepository<LayoutEntity>
    {
            void Update(LayoutEntity layout);

            void Insert(LayoutEntity layout);
    }
}

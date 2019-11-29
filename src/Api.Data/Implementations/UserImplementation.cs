using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Context;
using Api.Data.Repository;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {

        public UserImplementation(MyContext context) : base(context)
        {
            
        }

        public List<UserEntity> Where(System.Linq.Expressions.Expression<System.Func<UserEntity, bool>> p_Filtro)
        {
            return _dataset.Where(p_Filtro).ToList();
        }


        public async Task<UserEntity> FindByLogin(string ds_nome)
        {
            return await _dataset.FirstOrDefaultAsync(u => u.ds_nome.Equals(ds_nome));
        }
    }
}

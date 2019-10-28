using System.Threading.Tasks;
using Api.Data.Context;
using Api.Domain.Entities;
using Api.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Implementations
{
    public class ConfigImplementation : IConfigRepository
    {

        private DbSet<ConfigEntity> _dataset;

        public ConfigImplementation(MyContext context)
        {
            _dataset = context.Set<ConfigEntity> ();
        }

        public async Task<ConfigEntity> FindLanguage(int cd_cliente)
        {
            return await _dataset.FirstOrDefaultAsync(c => c.cd_empresa.Equals(cd_cliente) && c.campo.Equals("idioma"));
        }
    }
}

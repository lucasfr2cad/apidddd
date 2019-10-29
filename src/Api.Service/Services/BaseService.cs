using System.Reflection;
using System.Threading.Tasks;
using Api.CrossCutting.Languages;
using Api.Domain.Repository;
using Microsoft.Extensions.Localization;

namespace Api.Service.Services
{
    public abstract class BaseService
    { protected IStringLocalizer _localizer;
        protected IConfigRepository _repository;
        protected IStringLocalizerFactory teste;
        public BaseService(IStringLocalizerFactory factory, IConfigRepository repository)
        {
            _repository = repository;
            var type = typeof(Resource);
            var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
            _localizer = factory.Create("Resource", assemblyName.Name);
        }
        public async Task<string> GetLanguage(int codigo)
        {
            var language = await _repository.FindLanguage(codigo);
            return language.descricao;
        }

    }
}

using System.Reflection;
using Api.CrossCutting.Languages;
using Microsoft.Extensions.Localization;

namespace Api.Service.Services
{
    public abstract class BaseService
    {
        private readonly IStringLocalizer _localizer;

        public BaseService(IStringLocalizerFactory factory)
        {
           var type = typeof(Resource);
           var assemblyName = new AssemblyName(type.GetTypeInfo().Assembly.FullName);
           _localizer = factory.Create("Resource", assemblyName.Name);
           System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es-PY");
           System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("es-PY");
        }

        

    }
}

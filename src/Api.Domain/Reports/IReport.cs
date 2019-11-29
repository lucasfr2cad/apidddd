using Api.Domain.Interfaces.Services.LayoutService;

namespace Api.Application.Services
{
    public abstract class IReport
    {
    
        protected ParametrosReport C_ParametrosReport { get; set; }
        protected ILayoutService C_LayoutService { get; set; }

        public IReport(ParametrosReport p_ParametrosReport, ILayoutService p_LayoutService)
        {
            C_ParametrosReport = p_ParametrosReport;
            C_LayoutService = p_LayoutService;
        }

        public abstract object CM_CarregaDataSource();

        public string CM_GetLayout()
        {
            var layoutFinded = C_LayoutService.Get(C_ParametrosReport.cd_report);
            return layoutFinded.Result.ds_conteudo;
        }
    }
}
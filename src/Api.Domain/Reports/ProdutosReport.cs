using Api.Domain.Interfaces.Services.LayoutService;
using System;

namespace Api.Application.Services
{
    public class ProdutosReport : IReport
    {
        public ProdutosReport(ParametrosReport p_ParametrosReport, ILayoutService p_LayoutService) : base(p_ParametrosReport, p_LayoutService)
        {
        }

        public override object CM_CarregaDataSource()
        {
            throw new NotImplementedException();
        }
    }
}

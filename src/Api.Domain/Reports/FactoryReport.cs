using System;
using System.Collections.Generic;
using Api.Domain.Interfaces.Services.LayoutService;
using Api.Domain.Interfaces.Services.User;

namespace Api.Application.Services
{
    public abstract class FactoryReport
    {
        public static IReport CM_GetReport(ParametrosReport p_ParametroReport, Dictionary<String, Object> services)
        {
            var layoutService = (ILayoutService)services[DictionaryServices.LAYOUT_SERVICE_KEY];
            switch (p_ParametroReport.ds_tipo_report)
            {
                case "PRODUCT_REPORT":
                    return new ProdutosReport(p_ParametroReport, layoutService);
                case "USER_REPORT":
                    var userService = (IUserService)services[DictionaryServices.USER_SERVICE_KEY];
                    return new UserReport(p_ParametroReport, layoutService, userService);
            }
            throw new ApplicationException("Report não encontrado.");
        }
    }
}
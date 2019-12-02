using DevExpress.AspNetCore.Reporting.ReportDesigner.Native.Services;
using DevExpress.XtraReports.Web.ReportDesigner;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Application.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    [Route("[controller]")]
    [Route("DXXRD")]
    public class ReportDesignerController : DevExpress.AspNetCore.Reporting.ReportDesigner.ReportDesignerController
    {
        public ReportDesignerController(IReportDesignerMvcControllerService controllerService) : base(controllerService)
        {
        }

        [HttpPost("[action]")]
        public ActionResult GetReportDesignerModel(string reportUrl)
        {
            string modelJsonScript =
                new ReportDesignerClientSideModelGenerator(HttpContext.RequestServices)
                .GetJsonModelScript(
                    reportUrl,                 // The URL of a report that is opened in the Report Designer when the application starts.
                    GetAvailableDataSources(), // Available data sources in the Report Designer that can be added to reports.
                    "DXXRD",   // The URI path of the default controller that processes requests from the Report Designer.
                    "DXXRDV",// The URI path of the default controller that that processes requests from the Web Document Viewer.
                    "DXXQB"      // The URI path of the default controller that processes requests from the Query Builder.
                );
            var retorno = Content(modelJsonScript, "application/json");
            return retorno;
        }




        Dictionary<string, object> GetAvailableDataSources()
        {
            var dataSources = new Dictionary<string, object>();
            // SqlDataSource dsClientes = new SqlDataSource("Test_Connection");
            // var queryClients = SelectQueryFluentBuilder
            //     .AddTable("public.clientes")
            //     .SelectAllColumns()
            //     .Build("Clientes");
            // dsClientes.Queries.Add(queryClients);
            // dsClientes.RebuildResultSchema();

            // SqlDataSource dsUsers = new SqlDataSource("Test_Connection");
            // var queryUsers = SelectQueryFluentBuilder
            //     .AddTable("base.usuarios")
            //     .SelectAllColumns()
            //     .Build("Usuarios");
            // dsUsers.Queries.Add(queryUsers);
            // dsUsers.RebuildResultSchema();

            // dataSources.Add("DataSourceClients", dsClientes);
            // dataSources.Add("DataSourceUsers", dsUsers);
            return dataSources;
        }
    }
}

using DevExpress.DataAccess.Sql;
using DevExpress.XtraReports.Web.ReportDesigner;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Application.Controllers
{

    [Route("[controller]/[action]")] 
    public class ReportDesignerController : Controller  {

        
        public ActionResult GetReportDesignerModel(string reportUrl) {
            string modelJsonScript =
                new ReportDesignerClientSideModelGenerator(HttpContext.RequestServices)
                .GetJsonModelScript(
                    reportUrl,                 // The URL of a report that is opened in the Report Designer when the application starts.
                    null, // Available data sources in the Report Designer that can be added to reports.
                    "DXXRD",   // The URI path of the default controller that processes requests from the Report Designer.
                    "DXXRDV",// The URI path of the default controller that that processes requests from the Web Document Viewer.
                    "DXXQB"      // The URI path of the default controller that processes requests from the Query Builder.
                );
            return Content(modelJsonScript, "application/json");
        }


        
    Dictionary<string, object> GetAvailableDataSources() {
        var dataSources = new Dictionary<string, object>();
        SqlDataSource ds = new SqlDataSource("Northwind_Connection");
        var query = SelectQueryFluentBuilder.AddTable("Products").SelectAllColumns().Build("Products");
        ds.Queries.Add(query);
        ds.RebuildResultSchema();
        dataSources.Add("SqlDataSource", ds);
        return dataSources;
    }

   
    }
}

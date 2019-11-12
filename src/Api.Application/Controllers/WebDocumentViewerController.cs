using System.Threading.Tasks;
using DevExpress.AspNetCore.Reporting.Native;
using DevExpress.AspNetCore.Reporting.Native.Services;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer.Native.Services;
using DevExpress.Charts.Model;
using Microsoft.AspNetCore.Mvc;
using DevExpress.AspNetCore.Reporting.QueryBuilder;  
using DevExpress.AspNetCore.Reporting.QueryBuilder.Native.Services;  
using DevExpress.AspNetCore.Reporting.ReportDesigner;  
using DevExpress.AspNetCore.Reporting.ReportDesigner.Native.Services;  
using DevExpress.AspNetCore.Reporting.WebDocumentViewer;  

namespace Api.Application.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]  
    [Route("DXXRDV")]  
    public class WebDocumentViewerController : DevExpress.AspNetCore.Reporting.Native.ControllerBase
    {
        public WebDocumentViewerController(IWebDocumentViewerMvcControllerService controllerService) : base(controllerService) { }  
        public override Task<IActionResult> Invoke() {  
        return base.Invoke();  
    }  
    }  
      
}

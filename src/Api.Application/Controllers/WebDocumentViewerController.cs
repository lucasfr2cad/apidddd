using System.Threading.Tasks;
using DevExpress.AspNetCore.Reporting.WebDocumentViewer.Native.Services;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
 //   [Route("DXXRDV")]
    public class WebDocumentViewerController : DevExpress.AspNetCore.Reporting.Native.ControllerBase
    {
        public WebDocumentViewerController(IWebDocumentViewerMvcControllerService controllerService) : base(controllerService) { }

        public override Task<IActionResult> Invoke()
        {
            return base.Invoke();
        }
    }
}

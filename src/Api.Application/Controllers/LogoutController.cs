using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace Api.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LogoutController : ControllerBase
    {
         private ILoginService _service;
        public LogoutController (ILoginService service){
            _service = service;
        }
         [Authorize("Bearer")]
         [HttpPost]
         public async Task<ActionResult> Post()
         {
            try
            {
                var header = HttpContext.Request.Headers["Authorization"];
                var token = header.ToString().Split(' ', 2);
                var result = await _service.UnchekSession(token[1]);
                if(result != null)
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (ArgumentException e)
            {
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
         }
    }
}



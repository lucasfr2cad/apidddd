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
         public async Task<ActionResult> Post([FromBody] int id)
         {
            try
            {
                var result = await _service.UnchekSession(id);
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

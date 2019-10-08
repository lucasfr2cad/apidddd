using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class LoginController: ControllerBase
    {
        //injetção de depêndencia
        private ILoginService _service;

        public LoginController (ILoginService service){
            _service = service;
        }

        [HttpPost]
         public async Task<object> Login([FromBody] UserEntity user)
         {
             if(!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }
             if(user == null)
             {
                 return BadRequest();
             }
             try
             {
              var result = await _service.FindByLogin(user);
              if(result != null)
              {
                  return  Ok(result);
              }
              else
              {
                  return NotFound();
              }   
             }
             catch (ArgumentException e)
             {
                 
                 return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
             }
         }
        
    }
}

using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
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

        [AllowAnonymous]
         [HttpPut]
         public async Task<object> Login([FromBody] LoginDto loginDto)
         {
             if(!ModelState.IsValid)
             {
                 return BadRequest(ModelState);
             }
             if(loginDto == null)
             {
                 return BadRequest();
             }
             try
             {
              var result = await _service.FindByLogin(loginDto);
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

        [AllowAnonymous]
        [HttpPost]
         public async Task<ActionResult> Post([FromBody] UserEntity user)
         {
               if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }
              try
            {
                var result = await _service.Post(user);
                if(result != null)
                {
                    result.Senha = "Magic Word";
                    // caso criado retorna o objeto criado e no cabeçalho uma url para a consulta
                    return Created (new Uri(Url.Link("GetWhithId", new {id = result.Id})), result);
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

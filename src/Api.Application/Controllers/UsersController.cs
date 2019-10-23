using System;
using System.Net;
using System.Threading.Tasks;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Application.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController: ControllerBase
    {

        private const int c_codigoForm = 5;
        private IUserService _service;

        public UsersController(IUserService service)
        {
            _service = service;
        }

        public class authorize : AuthorizeAttribute
        {
            public int codigo_form;

           
            
            public authorize (string P1, int pcod): base(P1)
            {
                codigo_form = pcod;
               
            }
        }
        [Authorize(Policy = "actionRequirement")]
        [Authorize("Bearer")]
        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }
            try
            {
                return Ok (await _service.GetAll());
            }
            catch (ArgumentException e)
            {
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet]
        [Route("{id}", Name = "GetWhithId")]

         public async Task<ActionResult> Get(int id)
         {
             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }
            try
            {
                return Ok (await _service.Get(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }

         }


         [Authorize("Bearer")]
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
                    // caso criado retorna o objeto criado e no cabeçalho uma url para a consulta
                    return Created (new Uri(Url.Link("GetWhithId", new {id = result.cd_codigo})), result);
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
         
         [Authorize("Bearer")]
         [HttpPut]
         public async Task<ActionResult> Put([FromBody] UserEntity user)
         {
                 if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }
              try
            {
                var result = await _service.Put(user);
                
                if(result != null)
                {
                    // caso criado retorna o objeto criado e no cabeçalho uma url para a consulta
                    return Ok (result);
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
         [Authorize("Bearer")]
         [HttpDelete ("{id}")]
         public async Task<ActionResult> Delete(int id)
         {
             if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); //400 
            }
            try
            {
                return Ok (await _service.Delete(id));
            }
            catch (ArgumentException e)
            {
                return StatusCode ((int) HttpStatusCode.InternalServerError, e.Message);
            }

         }

    }
}

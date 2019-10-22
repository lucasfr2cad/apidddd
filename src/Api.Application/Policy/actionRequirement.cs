using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.Web;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;
using Api.Data.Repository;
using Api.Domain.Interfaces.Services.Permission;


namespace  Api.Application.Policy
{
    
    public class actionRequirement : AuthorizationHandler<actionRequirement>, IAuthorizationRequirement
    {

            private readonly IHttpContextAccessor _httpContextAccessor;


        private IPermissionService _service;


        public actionRequirement()
        {
        }

        public actionRequirement(IHttpContextAccessor httpContextAccessor, IPermissionService service)
        {
            _httpContextAccessor = httpContextAccessor;
            _service = service;
        }


        protected override  Task HandleRequirementAsync(AuthorizationHandlerContext context, actionRequirement requirement)
        {
            
            var teste = context.User.Identity.Name;
          
            int cod = Int32.Parse(teste);

            var contentStream = context.Resource;


            
          //  if (context.Resource is AuthorizationFilterContext api)
            {
                var headers = _httpContextAccessor.HttpContext.Request.Headers;
                var requestType = _httpContextAccessor.HttpContext.Request.Method;
                var codeString = headers["codigo"].ToString();
                var column = headers["coluna"].ToString();
                var condicao = headers["condicao"];

                int condicao2 = Int32.Parse(condicao);

                int codeForm = Int32.Parse(codeString);


                var teste2 =  _service.FindPermission(codeForm, cod, condicao2);

                var m_retorno = teste2.GetType().GetProperty(column).GetValue(teste2, null);

                var teste3 =  Convert.ToBoolean(m_retorno);

                if(teste3)
                {
                    context.Succeed(requirement);
                }

            }


            return  Task.CompletedTask;

          
        }
    }
}

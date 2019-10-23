using Microsoft.AspNetCore.Authorization;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Api.Domain.Interfaces.Services.Permission;


namespace Api.Application.Policy
{

    public class ActionRequirement : IAuthorizationRequirement
   {
   }
   public class actionRequirement : AuthorizationHandler<ActionRequirement>
    {

        private readonly IHttpContextAccessor _httpContextAccessor;

        private readonly IPermissionService _service;


        public actionRequirement(IHttpContextAccessor httpContextAccessor, IPermissionService service)
        {
            _httpContextAccessor = httpContextAccessor;
            _service = service;
        }


        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, ActionRequirement requirement)
        {
            
                var userId = context.User.Identity.Name;
                var headers = _httpContextAccessor.HttpContext.Request.Headers;
                var requestType = _httpContextAccessor.HttpContext.Request.Method;
                var codeString = headers["codigo"].ToString();
                var column = headers["coluna"].ToString();
                var condicao = headers["condicao"];

                int condicao2 = 0;

                int codeForm = 0;

                int codeUser = 0;

                if(!string.IsNullOrEmpty(condicao))
                {
                     condicao2 = Int32.Parse(condicao);
                }

                if(!string.IsNullOrEmpty(codeString))
                {
                     codeForm = Int32.Parse(codeString);
                }

                if(!string.IsNullOrEmpty(userId))
                {
                     codeUser = Int32.Parse(userId);
                }


                var permission = await _service.FindPermission(codeForm, codeUser, condicao2);
               

                var m_retorno = permission.GetType().GetProperty(column).GetValue(permission, null);

                var result =  Convert.ToBoolean(m_retorno);


                if(result)
                 {
                     context.Succeed(requirement);
                 }



            return;

          
        }
    }
}

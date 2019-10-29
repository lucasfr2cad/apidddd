using System;
using System.IdentityModel.Tokens.Jwt;
using System.Reflection;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Api.Domain.Dtos;
using Api.Domain.Entities;
using Api.Domain.Interfaces.Services.User;
using Api.Domain.Repository;
using Api.Domain.Security;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Localization;
namespace Api.Service.Services
{
    public class LoginService: BaseService, ILoginService
    {
        private IUserRepository _repository;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;
        private IConfiguration _configuration {get;}
        private ISessionRepository _repository2;
        private IConfigRepository _repository3;
 
  
        public LoginService(IUserRepository repository, 
        SigningConfigurations signingConfigurations,
        TokenConfigurations tokenConfigurations,
        IConfiguration configuration,
        ISessionRepository repository2,
        IStringLocalizerFactory factory,
        IConfigRepository repository3
        ): base(factory, repository3)
        {
            _repository = repository;
            _repository2 = repository2;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
            _repository3 = repository3;
  
        }
        
        public async Task<UserEntity> Post(UserEntity user)
        {
            return await _repository.InsertAsync(user);
        }
        public async Task<int> CheckSession(UserEntity user )
        {   
         return await _repository2.CheckSession(user.cd_codigo);
        }
        public async Task<SessionEntity> UnchekSession(int id)
        {
            var result = await _repository2.SelectAsync(id);
            result.st_ativo = false;
            return await _repository2.UpdateAsync(result);
        }
        public async Task<SessionEntity> InserteSession(SessionEntity session)
        {
            return await _repository2.InsertAsync(session);
        } 
        public async Task<ConfigEntity> FindLanguage(UserEntity user)
        {
            return await _repository3.FindLanguage((int)user.cd_cliente);
        }
       
        public async Task<object> FindByLogin(LoginDto user)
        {
            var baseUser = new UserEntity();
            if(user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                baseUser = await _repository.FindByLogin(user.Email);
                if((baseUser == null)||(baseUser.ds_senha != user.Senha))
                {
                    
                    if(baseUser == null){
                    return new
                    {
                        message = _localizer["userNotFound"].Value
                    };    
                    }
                    else
                    return new
                    {
                        message = _localizer["passNotFound"].Value
                    };
                }
                else
                {
                    var language = await GetLanguage((int)baseUser.cd_cliente);
                    System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(language);
                    System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(language);
              
                    var activeSessions = await CheckSession(baseUser);
                    if(baseUser.vl_max_sessoes - activeSessions <= 0){
                        return new
                    {
                        message = _localizer["sessionLimit"].Value
                    };    
                    }
                    else
                    {
                        
                        var identity = new ClaimsIdentity(
                        new GenericIdentity(baseUser.cd_codigo.ToString()),
                        new[]
                        {
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), //jti O Id do Token
                            new Claim(JwtRegisteredClaimNames.UniqueName, user.Email),
                        }
                    );
                    DateTime createDate = DateTime.Now;
                    DateTime expirationDate = createDate + TimeSpan.FromSeconds(_tokenConfigurations.Seconds);
                    var handler = new JwtSecurityTokenHandler();
                    string token = CreateToken(identity, createDate, expirationDate, handler);
                    var session = new SessionEntity(){
                        cd_usuario = baseUser.cd_codigo,
                        st_ativo = true,
                        ds_ip = "10.0.0.13",
                        ds_estacao_trabalho = "webUser",
                        txt_hash = token,
                        txt_data_login = DateTime.Now.ToString()
                    };
                    var rSession =  await InserteSession(session);
                    user.sessionId = rSession.cd_codigo;
                    
                    return SucessObject(createDate, expirationDate, token, user);
                     }
                }
            }
            else
            {
                 return new
                    {
                        message = _localizer["authenticateFailed"].Value
                    };
            }
        }
        private string CreateToken(ClaimsIdentity identity, DateTime createDate, DateTime expirationDate, JwtSecurityTokenHandler handler)
        {
             var securityToken = handler.CreateToken(new SecurityTokenDescriptor{
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = createDate,
                Expires = expirationDate,
             });
             var token = handler.WriteToken(securityToken);
             return token;
        }
        private object SucessObject(DateTime createDate, DateTime expirationDate, string token, LoginDto user)
        {
            return new
            {
                authenticated = true,
                created = createDate.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = expirationDate.ToString("yyyy-MM-dd HH:mm:ss"),
                acessToken = token,
                userName = user.Email,
                message = _localizer["authenticateSuccessful"].Value,
                sessionId = user.sessionId
            };
        }
    }
}




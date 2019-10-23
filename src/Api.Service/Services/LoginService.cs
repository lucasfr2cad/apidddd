using System;
using System.IdentityModel.Tokens.Jwt;
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

namespace Api.Service.Services
{
    public class LoginService:ILoginService
    {
        private IUserRepository _repository;

        private SigningConfigurations _signingConfigurations;

        private TokenConfigurations _tokenConfigurations;

        private IConfiguration _configuration {get;}


        private ISessionRepository _repository2;

        public LoginService(IUserRepository repository, 
        SigningConfigurations signingConfigurations,
        TokenConfigurations tokenConfigurations,
        IConfiguration configuration,
        ISessionRepository repository2
        )
        {
            _repository = repository;
            _repository2 = repository2;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _configuration = configuration;
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

        public async Task<object> FindByLogin(LoginDto user)
        {

            var baseUser = new UserEntity();


            if(user != null && !string.IsNullOrWhiteSpace(user.Email))
            {
                baseUser = await _repository.FindByLogin(user.Email);


                 var activeSessions = await CheckSession(baseUser);


                if((baseUser == null)||(baseUser.ds_senha != user.Senha))
                {
                    
                    if(baseUser == null){
                    return new
                    {
                        authenticated = false,
                        message = "Email não cadastrado!"
                    };    
                    }
                    else
                    return new
                    {
                        authenticated = false,
                        message = "Senha incorreta!"
                    };
                }
                else
                {
                    if(baseUser.vl_max_sessoes - activeSessions <= 0){
                        return new
                    {
                        authenticated = false,
                        message = "Número máximo de sessões ativas!"
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
                        authenticated = false,
                        message = "Falha ao autenticar"
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
                userPass = "HAHAHAHA",
                message = "Usuário Logado com Sucesso",
                sessionId = user.sessionId
            };
        }
    }
}
